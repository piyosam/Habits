'システム名 ： HABITS
'機能名　　 ： a1600_発注画面
'概要　　　 ： 発注商品一覧表示機能
'履歴　　　 ： 2010/07/08　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Imports Excel = Microsoft.Office.Interop.Excel

''' <summary>a1600_発注画面処理</summary>
''' <remarks></remarks>
Public Class a1600_発注画面

    Private logic As New Habits.Logic.a1600_Logic
    Private base_logic As New Habits.Logic.LogicBase


#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1600_発注画面_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dgv発注一覧.DataSource = logic.発注一覧()
        Me.dgv発注一覧.Columns("売上区分番号").Visible = False
        Me.dgv発注一覧.Columns("分類番号").Visible = False
        Me.dgv発注一覧.Columns("分類名").Width = 80
        Me.dgv発注一覧.Columns("商品番号").Visible = False
        Me.dgv発注一覧.Columns("商品名").Width = 193
        Me.dgv発注一覧.Columns("メーカー名").Width = 116
        Me.dgv発注一覧.Columns("仕入金額").Width = 78
        Me.dgv発注一覧.Columns("仕入金額").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv発注一覧.Columns("仕入金額").DefaultCellStyle.Format = "#,##0"
        Me.dgv発注一覧.Columns("販売金額").Width = 78
        Me.dgv発注一覧.Columns("販売金額").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv発注一覧.Columns("販売金額").DefaultCellStyle.Format = "#,##0"
        Me.dgv発注一覧.Columns("在庫数").Width = 67
        Me.dgv発注一覧.Columns("在庫数").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv発注一覧.Columns("在庫数").DefaultCellStyle.Format = "#,##0"
        Me.dgv発注一覧.Columns("発注点").Width = 67
        Me.dgv発注一覧.Columns("発注点").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv発注一覧.Columns("発注点").DefaultCellStyle.Format = "#,##0"
        Me.dgv発注一覧.Columns("既定在庫数").Width = 90
        Me.dgv発注一覧.Columns("既定在庫数").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv発注一覧.Columns("既定在庫数").DefaultCellStyle.Format = "#,##0"
        Me.dgv発注一覧.Columns("目安発注数").Width = 90
        Me.dgv発注一覧.Columns("目安発注数").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv発注一覧.Columns("目安発注数").DefaultCellStyle.Format = "#,##0"
        Me.dgv発注一覧.ClearSelection()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1600_発注画面_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub

    Private Sub Excel出力_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Excel出力.Click
        Dim sfd As New Windows.Forms.SaveFileDialog()
        Dim update_dt As New Integer
        Dim param As New Habits.DB.DBParameter
        sfd.FileName = "発注データ"
        sfd.InitialDirectory = logic.select_ASY
        Dim test As String = logic.SystemVerForSaveType()
        Dim test2 As String = "Microsoft Offics Excel ブック(*.xls)|*.xls"

        If test = test2 Then
            sfd.Filter = test

        Else
            sfd.Filter = test2
        End If
        sfd.FilterIndex = 1
        sfd.Title = "保存先のファイルを選択してください。"
        sfd.RestoreDirectory = True
        '既に存在するファイル名を指定したとき警告する
        'デフォルトでTrueなので指定する必要はない
        sfd.OverwritePrompt = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        sfd.CheckPathExists = True

        'ダイアログを表示する
        If sfd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき
            '選択されたファイル名を表示する
            Console.WriteLine(sfd.FileName)

        End If
        '--------------------------------------------------------------------------------------------------
        Dim localByName As Process() = Process.GetProcessesByName("Excel")
        Dim p As Process
        Dim fn As String = "Microsoft Excel - " & FileUtil.GetFilename(sfd.FileName)
        For Each p In localByName
            If System.String.Compare(p.MainWindowTitle, fn, True) = 0 Then
                Call Sys_Error("指定されたExcelファイルが起動中です。　" & Chr(13) & Chr(13) & _
                "ファイルを閉じて下さい。", Me.Excel出力)
                Exit Sub
            End If
        Next
        '--------------------------------------------------------------------------------------------------
        Cursor.Current = Windows.Forms.Cursors.WaitCursor

        If Replace(sfd.FileName, FileUtil.GetFilename(sfd.FileName), "").Length > 128 Then
            Call Sys_Error("ファイルの出力に失敗しました。　" & Chr(13) & Chr(13) & _
                           "指定先ディレクトリのパスの文字数が、128以内であることを確認してください。　", Me.Excel出力)
            Exit Sub
        End If
        excel_output_order(sfd.FileName)
        Cursor.Current = Windows.Forms.Cursors.Default

        param.Add("@発注出力パス名", Replace(sfd.FileName, FileUtil.GetFilename(sfd.FileName), ""))
        param.Add("@変更日時", Now)

        update_dt = logic.update_ASY(param)
    End Sub

#End Region

#Region "メソッド"
    Private Sub excel_output_order(ByVal str_fullpath As String)
        Dim dt As New DataTable

        Dim xlapp As New Excel.Application
        Dim xlbooks As Excel.Workbooks = xlapp.Workbooks
        Dim xlbook As Excel.Workbook = xlbooks.Add
        Dim xlsheets As Excel.Sheets = xlbook.Worksheets
        Dim xlsheet As Excel.Worksheet = DirectCast(xlsheets.Item(1), Excel.Worksheet)
        Dim xlrange As Excel.Range
        xlrange = xlsheet.Range("1:9")
        xlsheet.Name = "発注データ"
        Dim i As Integer = 1
        Dim shopName As String

        ' 店舗名取得
        shopName = base_logic.GetShopName()

        xlrange(1, 1) = "店名：" & shopName

        dt = logic.発注一覧

        xlrange(3, 1) = "分類名"
        xlrange(3, 2) = "商品名"
        xlrange(3, 3) = "メーカー名"
        xlrange(3, 4) = "仕入金額"
        xlrange(3, 5) = "販売金額"
        xlrange(3, 6) = "在庫数"
        xlrange(3, 7) = "発注点"
        xlrange(3, 8) = "既定在庫数"
        xlrange(3, 9) = "目安発注数"

        Try
            Do Until i = dt.Rows.Count + 1
                xlrange(i + 3, 1) = dt.Rows(i - 1)("分類名")
                xlrange(i + 3, 2) = dt.Rows(i - 1)("商品名")
                xlrange(i + 3, 3) = dt.Rows(i - 1)("メーカー名")
                xlrange(i + 3, 4) = dt.Rows(i - 1)("仕入金額")
                xlrange(i + 3, 5) = dt.Rows(i - 1)("販売金額")
                xlrange(i + 3, 6) = dt.Rows(i - 1)("在庫数")
                xlrange(i + 3, 7) = dt.Rows(i - 1)("発注点")
                xlrange(i + 3, 8) = dt.Rows(i - 1)("既定在庫数")
                xlrange(i + 3, 9) = dt.Rows(i - 1)("目安発注数")
                i = i + 1
            Loop

        Catch ex As Exception
            MsgBox(ex.ToString, Clng_Okexb1, TTL)

        Finally
            'xlapp.ActiveWorkbook.CheckCompatibility = False
            xlapp.DisplayAlerts = False
            xlsheet.SaveAs(str_fullpath)
            '---終了処理------------
            MRComObject(xlrange)
            MRComObject(xlsheet)
            MRComObject(xlsheets)
            xlbook.Close(False)
            MRComObject(xlbook)
            MRComObject(xlbooks)
            xlapp.Quit()
            MRComObject(xlapp)

        End Try
    End Sub

    Private Sub MRComObject(ByRef obj As Object) ''COMオブジェクトを開放
        If Not obj Is Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
        obj = Nothing
        GC.Collect()
    End Sub

#End Region

End Class
