'システム名 ： HABITS
'機能名　　 ： d0600_履歴ログ出力
'概要　　　 ： 売上データ変更履歴ログ印刷処理
'履歴　　　 ： 2012/08/01　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Imports Excel = Microsoft.Office.Interop.Excel

Public Class d0600_履歴ログ出力

    Private base_logic As Habits.Logic.LogicBase
    Private MonthlyStartDate As Date

#Region "フォームロード処理"
    ''' <summary>
    ''' フォームロード時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub d0600_履歴ログ出力_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        base_logic = New Habits.Logic.LogicBase
        MonthlyStartDate = getMonthlyStartDate(USER_DATE).ToString("yyyy/MM/dd")
        Me.txtMonth.Text = getMonthlyStartDate(USER_DATE).AddMonths(1).AddDays(-1).ToString("yyyy/MM")
        Me.Activate()
    End Sub
#End Region

#Region "閉じるボタン押下処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <remarks></remarks>
    Private Sub d0600_履歴ログ出力_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "閉じるボタン押下処理"
    ''' <summary>
    ''' 閉じるボタンクリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
#End Region

#Region "印刷ボタン押下処理"
    ''' <summary>
    ''' 印刷ボタンクリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        If Not inputCheck() Then Exit Sub

        Dim param As New Habits.DB.DBParameter
        Dim logdate As DateTime = DateTime.Parse(txtMonth.Text & "/01")
        Dim vPath As String = My.Settings.LogPath
        Dim startDate As DateTime = getMonthlyStartDate(logdate)
        Dim filename As String = vPath & "HabitsHistory" & startDate.AddMonths(1).AddDays(-1).ToString("yyyyMM") & ".csv"
        Dim shopName As String

        'ファイル存在チェック
        If Not System.IO.File.Exists(filename) Then
            rtn = MsgBox("履歴ファイルが存在しません。　", Clng_Okinb1, TTL)
            Exit Sub
        End If

        Dim xlapp As New Excel.Application
        Dim xlbooks As Excel.Workbooks = xlapp.Workbooks
        Dim xlbook As Excel.Workbook = xlapp.Workbooks.Open(filename)
        Dim xlsheets As Excel.Sheets = xlbook.Worksheets
        Dim xlsheet As Excel.Worksheet = DirectCast(xlsheets.Item(1), Excel.Worksheet)
        Dim xlrange As Excel.Range

        xlrange = xlsheet.Range("1:3")
        xlsheet.Name = "売上データ変更履歴"
        Try
            xlsheet.Columns("A").ColumnWidth = 17               '修正日時
            xlsheet.Columns("B").ColumnWidth = 10               '来店日
            xlsheet.Columns("C").ColumnWidth = 10.5             '来店者番号
            xlsheet.Columns("D").ColumnWidth = 8.5              '顧客番号
            xlsheet.Columns("E").ColumnWidth = 18               '顧客名
            xlsheet.Columns("F").ColumnWidth = 18               '主担当者名
            xlsheet.Columns("G").NumberFormatLocal = "#,##0"    '売上金額
            xlsheet.Columns("G").ColumnWidth = 15

            ''セル設定
            xlsheet.Range("$A:$A").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            xlsheet.Range("$B:$B").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            xlsheet.Range("$G:$G").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight

            '----------------------
            'シートの印刷設定
            '----------------------
            With xlsheet.PageSetup
                '用紙サイズ  Ａ４
                .PaperSize = Excel.XlPaperSize.xlPaperA4

                '印刷の向き　横=xlLandscape 　　縦 = xlPortrait
                .Orientation = Excel.XlPageOrientation.xlPortrait

                '各余白をセンチ(Cm)単位で設定
                .LeftMargin = xlapp.CentimetersToPoints(0.6)
                .RightMargin = xlapp.CentimetersToPoints(0.6)
                .TopMargin = xlapp.CentimetersToPoints(3)
                .BottomMargin = xlapp.CentimetersToPoints(2.5)
                .HeaderMargin = xlapp.CentimetersToPoints(1)
                .FooterMargin = xlapp.CentimetersToPoints(1)
                'ヘッダー・フッター設定
                ' 集計期間設定
                Dim period As String = (vbCr) & "期間：" & startDate.ToString("yyyy/MM/dd") & "～" & startDate.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd")

                ' 店舗名取得
                shopName = base_logic.GetShopName()

                ' 店舗名をヘッダーの左側に設定
                .LeftHeader = (vbCrLf) & "店名：" & shopName & period
                .CenterHeader = "&B&14売上データ変更履歴"
                .RightHeader = Chr(13) + Chr(10) & "&D &T"
                .CenterFooter = "&P/&N"
            End With

            'シートを印刷
            xlsheet.PrintOut()
            'シートを出力
            'xlsheet.SaveAs("C:\test.xls")

        Catch ex As Exception
            MsgBox(ex.ToString, Clng_Okexb1, TTL)

        Finally
            xlapp.DisplayAlerts = False
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
#End Region

#Region "入力チェック"
    ''' <summary>
    ''' "入力チェック
    ''' </summary>
    ''' <returns>True：正常、False：エラー</returns>
    ''' <remarks></remarks>
    Private Function inputCheck() As Boolean
        Dim errMsg As String = Nothing
        inputCheck = False

        '対象月チェック
        If Not Sys_InputCheck_Month(Me.txtMonth.Text, errMsg) Then
            Call Sys_Error("対象月 " & errMsg, Me.txtMonth)
            Exit Function
        End If
        inputCheck = True
    End Function
#End Region

    Private Sub btnExcelOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelOut.Click
        Dim sfd As New Windows.Forms.SaveFileDialog()
        Dim dt As New DataTable
        Dim update_dt As New Integer
        Dim param As New Habits.DB.DBParameter

        Dim logdate As DateTime = DateTime.Parse(txtMonth.Text & "/01")
        Dim vPath As String = My.Settings.LogPath
        Dim startDate As DateTime = getMonthlyStartDate(logdate)
        Dim filename As String = vPath & "HabitsHistory" & startDate.AddMonths(1).AddDays(-1).ToString("yyyyMM")

        sfd.FileName = filename
        sfd.InitialDirectory = base_logic.getPath(2)
        sfd.Filter = _
        "Microsoft Offics Excel ブック(*.xls)|*.xls"
        sfd.FilterIndex = 1
        sfd.Title = "保存先のファイルを選択してください"
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

        '----------------------指定ファイルが開かれているか確認(COM開放バグ回避)----------------------------------------------------------------------------
        Dim localByName As Process() = Process.GetProcessesByName("Excel")
        Dim p As Process
        Dim fn As String = "Microsoft Excel - " & FileUtil.GetFilename(sfd.FileName)
        For Each p In localByName
            If System.String.Compare(p.MainWindowTitle, fn, True) = 0 Then
                Call Sys_Error("指定されたExcelファイルが起動中です。　" & Chr(13) & Chr(13) & _
                "ファイルを閉じて下さい。　", Me.btnExcelOut)
                Exit Sub
            End If
        Next
        '--------------------------------------------------------------------------------------------------
        Cursor.Current = Windows.Forms.Cursors.WaitCursor
        If Replace(sfd.FileName, FileUtil.GetFilename(sfd.FileName), "").Length > 128 Then
            Call Sys_Error("ファイルの出力に失敗しました。　" & Chr(13) & Chr(13) & _
                           "指定先ディレクトリのパスの文字数が、128以内であることを確認してください。", Me.btnExcelOut)
            Exit Sub
        End If

        print_ExcelOut(False, sfd.FileName)

    End Sub

#Region "印刷・Excel出力用データ作成処理"
    ''' <summary>
    ''' 印刷・Excel出力用データ作成時の処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub print_ExcelOut(ByVal printFlg As Boolean, ByVal filePath As String)

        If Not inputCheck() Then Exit Sub

        Dim param As New Habits.DB.DBParameter
        Dim logdate As DateTime = DateTime.Parse(txtMonth.Text & "/01")
        Dim vPath As String = My.Settings.LogPath
        Dim startDate As DateTime = getMonthlyStartDate(logdate)
        Dim filename As String = vPath & "HabitsHistory" & startDate.AddMonths(1).AddDays(-1).ToString("yyyyMM") & ".csv"
        Dim shopName As String

        'ファイル存在チェック
        If Not System.IO.File.Exists(filename) Then
            rtn = MsgBox("履歴ファイルが存在しません。　", Clng_Okinb1, TTL)
            Exit Sub
        End If

        ' csvからxlsへコピー
        System.IO.File.Copy(filename, filePath, True)

        Dim app As Excel.Application
        Dim book As Excel.Workbook
        Dim sheet As Excel.Worksheet

        app = CreateObject("Excel.Application")
        app.Visible = False                     'アプリケーションの非表示
        book = app.Workbooks.Open(filePath)     'ファイルを開く
        sheet = book.Worksheets(1)              'シート１を選択

        'コピーや切取りの操作を取り消します
        app.CutCopyMode = False

        ' 店舗名取得
        shopName = base_logic.GetShopName()

        ' 集計期間設定
        Dim period As String = (vbCr) & "期間：" & startDate.ToString("yyyy/MM/dd") & "～" & startDate.AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd")

        ' ４行分挿入
        sheet.Rows("1:4").Insert()

        sheet.Cells(1, 4).Value = "売上データ変更履歴"
        sheet.Cells(2, 1).Value = "店名：" & shopName
        sheet.Cells(3, 1).Value = period
        sheet.Cells(2, 7).Value = Now.ToString("yyyy/MM/dd HH:mm:ss")

        app.DisplayAlerts = False

        book.Save() '上書き保存

        app.Quit() '終了

        ' オブジェクトを解放します。
        sheet = Nothing
        book = Nothing
        app = Nothing
    End Sub
#End Region

End Class
