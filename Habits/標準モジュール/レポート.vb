'システム名 ： HABITS
'概要　　　 ：
'説明　　　 ： レポート
'履歴　　　 ： 2010/04/01　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2010 All Rights Reserved.

Option Explicit On
Option Strict Off
Option Compare Binary

Module レポート

    ''' <summary>レポート出力</summary>
    ''' <param name="vRepName">レポート名</param>
    ''' <param name="vDSName">データソース名</param>
    ''' <param name="vRepData">データソース</param>
    ''' <param name="vDefaultPrinter">True：いつも使うプリンター False: 設定されたプリンタ</param>
    ''' <param name="vPrintMode">0:印刷 / 1:プレビュー</param>
    ''' <param name="vLandscape">印刷の向き True：横 / False:縦</param>
    ''' <param name="vRawKind">印刷サイズ</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Rep_Print(ByVal vRepName As String, _
                                        ByVal vDSName As String, _
                                        ByVal vRepData As DataTable, _
                                        ByVal vDefaultPrinter As Boolean, _
                                        Optional ByVal vPrintMode As Integer = 0, _
                                        Optional ByVal vLandscape As Boolean = False, _
                                        Optional ByVal vRawKind As Integer = Printing.PaperKind.A4) As Integer

        Dim strRep As String = APP_NAME & "." & vRepName

        ' '' 印刷モード
        Dim repUtil As New ReportUtil(vRepName, vDSName, vRepData, vDefaultPrinter, , vLandscape, vRawKind)
        repUtil.SendPrinter()
        repUtil.Dispose()
        repUtil = Nothing

        Rep_Print = 0

    End Function
End Module
