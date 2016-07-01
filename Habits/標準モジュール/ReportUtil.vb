Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

'' 【基本ソース参考元】 http://msdn.microsoft.com/ja-jp/library/ms251691(VS.80).aspx
'' 【用紙の設定】       http://www.atmarkit.co.jp/bbs/phpBB/viewtopic.php?topic=47345&forum=7   ※未実装

''' <summary>レポート用ユーティリティー</summary>
''' <remarks></remarks>
Public Class ReportUtil
    Implements IDisposable

#Region "変数・定数"
    Private Const SFWER_SUCCESS As Integer = 0
    Private Const MSG_NOMONITOR As Integer = 0

    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)

    Dim m_RepName As String      '' レポート定義ファイル名
    Dim m_DSName As String       '' データセット名
    Dim m_RepData As DataTable   '' データテーブル
    Dim m_DefaultPrinter As Boolean
    Dim m_Params As List(Of Microsoft.Reporting.WinForms.ReportParameter)    '' パラメータ
    Dim m_Landscape As Boolean
    Dim m_RawKind As Integer

    Private m_PrinterName As String = My.Settings.PrinterName        '' コマンドタイムアウト(s)

#End Region

#Region "コンストラクタ"

    ''' <summary>コンストラクタ</summary>
    ''' <param name="vRepName">レポート定義ファイル名</param>
    ''' <param name="vDSName">データセット名</param>
    ''' <param name="vRepData">データテーブル</param>
    ''' <param name="vDefaultPrinter">True：デフォルトプリンタに出力、False：指定のプリンタに出力</param>
    ''' <param name="vParams">パラメータ ※省略時は設定なし</param>
    ''' <param name="vLandscape">用紙向き ※省略時は横向き</param>
    ''' <param name="vRawKind">用紙サイズ ※省略時はA4</param>
    ''' <remarks></remarks>
    Sub New( _
        ByVal vRepName As String, _
        ByVal vDSName As String, _
        ByVal vRepData As DataTable, _
        ByVal vDefaultPrinter As Boolean, _
        Optional ByVal vParams As List(Of Microsoft.Reporting.WinForms.ReportParameter) = Nothing, _
        Optional ByVal vLandscape As Boolean = True, _
        Optional ByVal vRawKind As Integer = PaperKind.A4 _
    )
        m_RepName = vRepName
        m_DSName = vDSName
        m_RepData = vRepData
        m_DefaultPrinter = vDefaultPrinter
        m_Params = vParams
        m_Landscape = vLandscape
        m_RawKind = vRawKind

    End Sub

#End Region

#Region "Protected Friend SetLandscapeメソッド / SetRawKindメソッド"

    ''' <summary>
    ''' 用紙の向きを設定する
    ''' </summary>
    ''' <param name="vLandscape">True:横向き / False:それ以外(規定値)</param>
    ''' <remarks></remarks>
    Protected Friend Sub SetLandscape(ByVal vLandscape As Boolean)
        m_Landscape = vLandscape
    End Sub

    ''' <summary>
    ''' 用紙のサイズを設定する
    ''' </summary>
    ''' <param name="vRawKind">PaperKindで設定される値</param>
    ''' <remarks></remarks>
    Protected Friend Sub SetRawKind(ByVal vRawKind As Integer)
        m_RawKind = vRawKind
    End Sub
#End Region

#Region "Public Sendメソッド"

    ''' <summary>プリンターに出力する</summary>
    ''' <param name="printName">プリンタ名　※省略時は規定のプリンタに出力</param>
    ''' <returns>印刷が成功したか否か：True=印刷成功 / False=印刷失敗</returns>
    ''' <remarks></remarks>
    Public Function SendPrinter(Optional ByVal printName As String = Nothing) As Boolean
        '' 出力データ無しの場合、処理を抜ける
        If Not ChkData() Then
            'MessageUtil.ShowMsg(MSGLST.PRINT_NODATE)
            'Exit Function
        End If
        Return PrintMain(m_RepName, m_DSName, m_RepData, m_Params, printName, m_DefaultPrinter)
    End Function

    ''' <summary>ImageWriter(Microsoft Office Document Image Writer)に出力する</summary>
    ''' <returns>印刷が成功したか否か：True=印刷成功 / False=印刷失敗</returns>
    ''' <remarks></remarks>
    Public Function SendImage() As Boolean
        '' 出力データ無しの場合、処理を抜ける
        If Not ChkData() Then
            'MessageUtil.ShowMsg(MSGLST.PRINT_NODATE)
            'Exit Function
        End If

        Return PrintMain(m_RepName, m_DSName, m_RepData, m_Params, "Microsoft Office Document Image Writer", m_DefaultPrinter)

    End Function

#End Region

#Region "Private ChkData"

    ''' <summary>
    ''' 出力データチェック
    ''' </summary>
    ''' <returns>True:出力データ有り / False:出力データ無し</returns>
    ''' <remarks></remarks>
    Private Function ChkData() As Boolean
        '' 出力データ無し
        If m_RepData Is Nothing OrElse m_RepData.Rows.Count = 0 Then
            'Return False
        Else
            Return True
        End If
    End Function
#End Region

#Region "Private メソッド"

#Region "PrintMain / 印刷メイン"

    ''' <summary>印刷メイン</summary>
    ''' <param name="vRepName">レポート定義ファイル名</param>
    ''' <param name="vDSName">データセット名</param>
    ''' <param name="vRepData">データテーブル</param>
    ''' <param name="vParams">パラメータ ※省略時はデータテーブルから生成</param>
    ''' <param name="vPrintSetthings">プリンタセッティング　※省略時は規定のプリンタに出力</param>
    ''' <returns>印刷が成功したか否か：True=印刷成功 / False=印刷失敗</returns>
    ''' <remarks></remarks>
    Private Function PrintMain( _
        ByVal vRepName As String, _
        ByVal vDSName As String, _
        ByVal vRepData As DataTable, _
        ByVal vParams As List(Of Microsoft.Reporting.WinForms.ReportParameter), _
        ByVal vPrintSetthings As PrinterSettings _
    ) As Boolean
        Dim report As Microsoft.Reporting.WinForms.LocalReport
        Try
            report = getReport(vRepName, vDSName, vRepData, vParams)

            '' 用紙の向きとサイズを設定する
            vPrintSetthings.DefaultPageSettings.Landscape = m_Landscape
            For i As Integer = 0 To vPrintSetthings.PaperSizes.Count - 1
                vPrintSetthings.PaperSizes.Item(i).RawKind = m_RawKind
            Next

            '' EMFファイル生成
            Call Export(report)

            m_currentPageIndex = 0

            '' 通常使うプリンタ取得
            If vPrintSetthings Is Nothing Or vPrintSetthings.PrinterName Is String.Empty Then
                Dim pd As New System.Drawing.Printing.PrintDocument
                'プリンタ名の取得
                vPrintSetthings = CType(pd.PrinterSettings.Clone, PrinterSettings)
                pd = Nothing
            End If

            '' 印刷実行
            Return PrintExec(vPrintSetthings)

        Catch ex As Exception
            Throw New Exception(ex.Message & vbCrLf & ex.InnerException.Message)
        Finally
            report = Nothing
        End Try

    End Function

    ''' <summary>印刷メイン</summary>
    ''' <param name="vRepName">レポート定義ファイル名</param>
    ''' <param name="vDSName">データセット名</param>
    ''' <param name="vRepData">データテーブル</param>
    ''' <param name="vParams">パラメータ ※省略時は設定なし</param>
    ''' <param name="vPrintName">プリンタ名　※省略時は規定のプリンタに出力</param>
    ''' <param name="vDefaultPrinter">True：デフォルトプリンタに出力、False：規定のプリンタに出力</param>
    ''' <returns>印刷が成功したか否か：True=印刷成功 / False=印刷失敗</returns>
    ''' <remarks></remarks>
    Private Function PrintMain( _
        ByVal vRepName As String, _
        ByVal vDSName As String, _
        ByVal vRepData As DataTable, _
        ByVal vParams As List(Of Microsoft.Reporting.WinForms.ReportParameter), _
        ByVal vPrintName As String, _
        ByVal vDefaultPrinter As Boolean _
    ) As Boolean
        Dim rds As Microsoft.Reporting.WinForms.ReportDataSource
        Dim report As Microsoft.Reporting.WinForms.LocalReport
        Try
            '' レポートデータソース生成
            rds = New Microsoft.Reporting.WinForms.ReportDataSource
            rds.Name = vDSName
            rds.Value = vRepData

            '' ローカルで処理されて表示されるレポートを生成
            report = New Microsoft.Reporting.WinForms.LocalReport
            report.DataSources.Add(rds)
            report.ReportEmbeddedResource = APP_NAME & "." & vRepName '' APP_NAME = "HabitsProject"
            If Not vParams Is Nothing Then report.SetParameters(vParams)

            report.Refresh()

            '' EMFファイル生成
            Call Export(report)

            m_currentPageIndex = 0

            '' 通常使うプリンタ取得
            If vPrintName Is Nothing Or vPrintName Is String.Empty Then


                Dim pd As New System.Drawing.Printing.PrintDocument
                If vDefaultPrinter = True Then
                    'プリンタ名の取得
                    vPrintName = pd.PrinterSettings.PrinterName

                Else
                    vPrintName = m_PrinterName
                End If

                pd = Nothing
            End If

                '' 印刷実行
                Return PrintExec(vPrintName)

        Catch ex As Exception
            Throw New Exception(ex.Message & vbCrLf & ex.InnerException.Message)
        Finally
            rds = Nothing
            report = Nothing
        End Try

    End Function
#End Region

#Region "Export / EMFファイル変換"

    ''' <summary>EMFファイル変換</summary>
    ''' <param name="report"></param>
    ''' <remarks></remarks>
    Private Sub Export(ByVal report As LocalReport)
        Dim deviceInfo As String = _
        "<DeviceInfo>" + _
        " <OutputFormat>EMF</OutputFormat>" + _
        "</DeviceInfo>"
        '"  <PageWidth>8.5in</PageWidth>" + _
        '"  <PageHeight>11in</PageHeight>" + _
        '"  <MarginTop>0.25in</MarginTop>" + _
        '"  <MarginLeft>0.25in</MarginLeft>" + _
        '"  <MarginRight>0.25in</MarginRight>" + _
        '"  <MarginBottom>0.25in</MarginBottom>" + _

        Dim warnings() As Warning = Nothing
        m_streams = New List(Of Stream)()

        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)

        Dim stream As Stream
        For Each stream In m_streams
            stream.Position = 0
        Next
    End Sub
#End Region

#Region "CreateStream / EMFファイル生成"

    ''' <summary>EMFファイル生成</summary>
    ''' <param name="name"></param>
    ''' <param name="fileNameExtension"></param>
    ''' <param name="encoding"></param>
    ''' <param name="mimeType"></param>
    ''' <param name="willSeek"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        '' Exeと同じフォルダに拡張子emfのファイルを生成する。例：「./Sample1_1.emf」
        Dim sFolder As String = "./emf/"
        If Not Directory.Exists(sFolder) Then Directory.CreateDirectory(sFolder)
        Dim stream As Stream = New FileStream(sFolder + name + "." + fileNameExtension, FileMode.Create)
        m_streams.Add(stream)
        Return stream
    End Function
#End Region

#Region "PrintPage / ページ制御"

    ''' <summary>ページ制御？</summary>
    ''' <param name="sender"></param>
    ''' <param name="ev"></param>
    ''' <remarks></remarks>
    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))
        ev.Graphics.DrawImage(pageImage, ev.PageBounds)
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub
#End Region

#Region "PrintExec / 印刷実行"

    ''' <summary>
    ''' 印刷実行
    ''' </summary>
    ''' <param name="printerSet">プリンター設定</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function PrintExec(ByVal printerSet As PrinterSettings) As Boolean
        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return False
        End If

        '' プリンターチェック
        Dim printDoc As New PrintDocument()
        printDoc.PrinterSettings = printerSet
        If Not printDoc.PrinterSettings.IsValid Then
            'MessageUtil.ShowMsg( _
            '    MessageBoxIcon.Error, _
            '    MessageBoxButtons.OK, _
            '    MessageBoxDefaultButton.Button1, _
            '    printerSet.PrinterName & "プリンターが見つかりませんでした。" _
            ')
            Return False
        End If

        '' プリンター出力
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        printDoc.Print()
        Return True

    End Function

    ''' <summary>印刷実行</summary>
    ''' <param name="printerName">プリンター名</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function PrintExec(ByVal printerName As String) As Boolean
        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return False
        End If

        '' プリンターチェック
        Dim printDoc As New PrintDocument()
        printDoc.PrinterSettings.PrinterName = printerName
        If Not printDoc.PrinterSettings.IsValid Then
            'MessageUtil.ShowMsg( _
            '    MessageBoxIcon.Error, _
            '    MessageBoxButtons.OK, _
            '    MessageBoxDefaultButton.Button1, _
            '    printerName & "プリンターが見つかりませんでした。" _
            ')
            Return False
        End If

        '' プリンター出力
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        printDoc.Print()
        Return True

    End Function
#End Region


#End Region


#Region "Private GetReportメソッド"

    ''' <summary>
    ''' レポートを生成して返す
    ''' </summary>
    ''' <param name="vRepName">レポート名</param>
    ''' <param name="vDSName">レポートデータソース名</param>
    ''' <param name="vRepData">レポートデータソース</param>
    ''' <param name="vParams">パラメータ</param>
    ''' <returns>生成レポート</returns>
    ''' <remarks></remarks>
    Private Function getReport(ByVal vRepName As String, _
                                 ByVal vDSName As String, _
                                 ByVal vRepData As DataTable, _
                                 ByVal vParams As List(Of ReportParameter) _
                                 ) As LocalReport
        Dim rds As ReportDataSource
        Dim report As LocalReport
        Try
            '' レポートデータソース生成
            rds = New ReportDataSource
            rds.Name = vDSName
            rds.Value = vRepData

            '' ローカルで処理されて表示されるレポートを生成
            report = New LocalReport
            report.DataSources.Add(rds)
            report.ReportEmbeddedResource = APP_NAME & "." & vRepName

            '' パラメータセット
            If Not vParams Is Nothing Then
                report.SetParameters(vParams)
            Else
                Dim prm As List(Of ReportParameter) = GetParameters(report, vRepData)
                If Not prm Is Nothing Then report.SetParameters(prm)
            End If

            Return report
        Catch ex As Exception
            Throw New Exception(ex.Message & vbCrLf & ex.InnerException.Message)
        End Try
    End Function
#End Region

#Region "Private GetParametersメソッド"

    ''' <summary>
    ''' パラメータをデータソースから生成する
    ''' </summary>
    ''' <param name="vReport">対象レポート</param>
    ''' <param name="vRepData">データテーブル</param>
    ''' <returns>パラメータ ※無い場合はNothing</returns>
    ''' <remarks></remarks>
    Private Function GetParameters(ByVal vReport As Microsoft.Reporting.WinForms.LocalReport, ByVal vRepData As DataTable) _
                                            As List(Of Microsoft.Reporting.WinForms.ReportParameter)

        Try
            Dim Parameters As New List(Of ReportParameter)
            '' データソースがない場合
            If vRepData.Rows.Count = 0 Then
                For Each rp As ReportParameterInfo In vReport.GetParameters()
                    Parameters.Add(getParameter(rp.Name, StringUtil.BLANK))
                Next
            Else
                '' レポートのパラメータを作成
                For Each rp As ReportParameterInfo In vReport.GetParameters()
                    If IsDataItemExist(rp.Name, vRepData) Then
                        Parameters.Add(getParameter(rp.Name, vRepData))
                    End If
                Next
            End If

            If Parameters.Count = 0 Then
                Return Nothing
            Else
                Return Parameters
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message & vbCrLf & ex.InnerException.Message)
        End Try
    End Function

    ''' <summary>
    ''' パラメータ作成
    ''' </summary>
    ''' <param name="vPrmName">パラメータ名</param>
    ''' <param name="vRepData">データテーブル</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getParameter(ByVal vPrmName As String, ByVal vRepData As DataTable) As ReportParameter
        Return New ReportParameter(vPrmName, CnvUtil.VbStr(vRepData.Rows(0).Item(vPrmName)))
    End Function

    ''' <summary>
    ''' パラメータ作成
    ''' </summary>
    ''' <param name="vPrmName">パラメータ名</param>
    ''' <param name="vDataValue">パラメータ内容</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getParameter(ByVal vPrmName As String, ByVal vDataValue As String) As ReportParameter
        Return New ReportParameter(vPrmName, vDataValue)
    End Function

    ''' <summary>
    ''' データソースカラム存在チェック
    ''' </summary>
    ''' <param name="vPrmName">カラム名</param>
    ''' <param name="vRepData">データテーブル</param>
    ''' <returns>True:存在する / False:存在しない</returns>
    ''' <remarks></remarks>
    Private Function IsDataItemExist(ByVal vPrmName As String, ByVal vRepData As DataTable) As Boolean
        Try
            Dim obj As Object = vRepData.Rows(0).Item(vPrmName)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "終了処理"
    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        If Not (m_streams Is Nothing) Then
            Dim stream As Stream
            For Each stream In m_streams
                stream.Close()
                '' ファイル削除
                Dim sFileName As String = CType(stream, System.IO.FileStream).Name
                If Not (sFileName Is Nothing OrElse sFileName = String.Empty) Then
                    If File.Exists(sFileName) Then File.Delete(sFileName)
                End If
            Next
            m_streams = Nothing
        End If

    End Sub

    Protected Overrides Sub Finalize()
        Me.Dispose()
        MyBase.Finalize()
    End Sub
#End Region

End Class

Public Class CnvUtil
    ''' <summary>
    ''' ObjectをStringに変換
    ''' </summary>
    ''' <param name="obj">変換対象</param>
    ''' <param name="nullDef">NothingやNullの時に返す値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function VbStr(ByVal obj As Object, Optional ByVal nullDef As String = "") As String
        If obj Is Nothing OrElse obj Is DBNull.Value Then Return nullDef
        Return CStr(obj)
    End Function
End Class

Public Class StringUtil
    Public Shared BLANK As String = ""

End Class