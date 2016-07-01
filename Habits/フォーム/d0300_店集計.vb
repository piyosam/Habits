Imports Excel = Microsoft.Office.Interop.Excel

''' <summary>d0300_店集計画面処理</summary>
''' <remarks></remarks>
Public Class d0300_店集計

    Private daily_sale As Integer = 0           ''総純売上本日
    Private daily_sale_tax As Integer = 0       ''総売上本日（税込）
    Private total_sale As Integer = 0           ''総純売上累計
    Private total_sale_tax As Integer = 0       ''総純売上累計
    Private int_er As Integer = 0               ''営業日数累
    Private base_logic As Habits.Logic.LogicBase
    Private d0300_logic As Habits.Logic.d0300_Logic
    Private d0400_Logic As Habits.Logic.d0400_logic
    Private Const PAGE_TITLE As String = "d0300_店集計"

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub d0300_店集計_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As DataTable
        d0300_logic = New Habits.Logic.d0300_Logic
        base_logic = New Habits.Logic.LogicBase

        Me.txtStartDay.Text = getMonthlyStartDate(USER_DATE).ToString("yyyy/MM/dd")
        Me.txtEndDay.Text = USER_DATE.ToString("yyyy/MM/dd")

        Dim param As New Habits.DB.DBParameter
        param.Add("@開始日", DateTime.Parse(Me.txtStartDay.Text))
        param.Add("@終了日", DateTime.Parse(Me.txtEndDay.Text))

        dt = d0300_logic.getSalesDivList(param)
        RemoveHandler cmbSalesDivision.SelectedIndexChanged, AddressOf Me.cmbSalesDivision_SelectedIndexChanged
        Me.cmbSalesDivision.DataSource = dt
        Me.cmbSalesDivision.DisplayMember = "売上区分"
        Me.cmbSalesDivision.ValueMember = "売上区分番号"
        AddHandler cmbSalesDivision.SelectedIndexChanged, AddressOf Me.cmbSalesDivision_SelectedIndexChanged

        '管理者モード機能の設定
        If MANAGER_MODE = True Then
            btnStaffPrint.Enabled = True
            btnShopPrint.Enabled = True
        Else
            btnStaffPrint.Enabled = False
            btnShopPrint.Enabled = False
        End If
        Call 集計処理()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub d0300_店集計_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.dgv店目標.Rows.Clear()
        Me.Dispose()
    End Sub
#End Region

#Region "Enterキー押下処理"
    Private Sub txtStartDay_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStartDay.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtEndDay.Focus()
        End If
    End Sub

    Private Sub txtEndDay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEndDay.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.btnCulc.Focus()
        End If
    End Sub
#End Region

#Region "売上区分選択処理"
    Private Sub cmbSalesDivision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSalesDivision.SelectedIndexChanged
        売上(Integer.Parse(Me.cmbSalesDivision.SelectedValue.ToString))
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "集計ボタン押下"
    ''' <summary>
    ''' 集計ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCulc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCulc.Click
        Call 集計処理()
    End Sub
#End Region

#Region "精算レシート印刷ボタン押下"
    ''' <summary>
    ''' 精算レシート印刷ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnZReceiptPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZReceiptPrint.Click
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        If (MsgBox("印刷します。" & Chr(13) & "プリンタの準備はよろしいですか？　", Clng_Ynqub1, TTL) = vbNo) Then Exit Sub

        'エラー処理ルーチン開始
        On Error GoTo Print_Error
        Dim sdate As DateTime = Date.Parse(Me.txtEndDay.Text)
        Dim receiptFlag As Boolean = True
        param.Add("@精算日", Format(sdate, "yyyy年M月d日"))
        param.Add("@社名", My.Settings.CompanyName.ToString)

        dt = d0300_logic.レシート移入(param)

        '  引数：
        '       レポート名
        '       データソース名
        '       データソース
        '       プリンタ True：いつも使うプリンター False: 設定されたプリンタ
        '       0:印刷 / 1:プレビュー
        '       印刷の向き True：横 / False:縦
        '       印刷サイズ
        If My.MySettings.Default.ReceiptFlag = 1 Then
            receiptFlag = False
        Else
            receiptFlag = True
        End If

        rtn = Rep_Print("d0601_精算レシート.rdlc", "DS0001_精算レシート", dt, receiptFlag, 0, False, 2)

        'エラー処理ルーチン終了
        On Error GoTo 0
        Exit Sub

Print_Error:
        Resume Next
    End Sub
#End Region

#Region "スタッフ集計印刷ボタン押下"
    '''' <summary>
    '''' スタッフ別集計一覧Excel出力
    ''''</summary>
    '''' <remarks></remarks>
    Private Sub btnStaffPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStaffPrint.Click
        Dim param As New Habits.DB.DBParameter
        Dim dt As DataTable
        Dim shopName As String

        param.Add("@開始日", DateTime.Parse(Me.txtStartDay.Text))
        param.Add("@終了日", DateTime.Parse(Me.txtEndDay.Text))
        dt = d0300_logic.getStaffSalesList(param)

        Dim xlapp As New Excel.Application
        Dim xlbooks As Excel.Workbooks = xlapp.Workbooks
        Dim xlbook As Excel.Workbook = xlbooks.Add
        Dim xlsheets As Excel.Sheets = xlbook.Worksheets
        Dim xlsheet As Excel.Worksheet = DirectCast(xlsheets.Item(1), Excel.Worksheet)
        Dim xlrange As Excel.Range

        xlrange = xlsheet.Range("1:11")
        xlsheet.Name = "スタッフ集計"
        Dim i As Integer = 1

        xlrange(1, 1) = "ID"
        xlrange(1, 2) = "担当者名"
        xlrange(1, 3) = "再来"
        xlrange(1, 4) = "新規"
        xlrange(1, 5) = "担当数"
        xlrange(1, 6) = "指名"
        xlrange(1, 7) = "ポイント"
        xlrange(1, 8) = "技術売上"
        xlrange(1, 9) = "店販売上"
        xlrange(1, 10) = "全体ｻｰﾋﾞｽ"
        xlrange(1, 11) = "総売上"

        xlsheet.Columns("A").ColumnWidth = 5                '#
        xlsheet.Columns("B").ColumnWidth = 15               '担当者名
        xlsheet.Columns("C").NumberFormatLocal = "#,##0"    '再来
        xlsheet.Columns("C").ColumnWidth = 8
        xlsheet.Columns("D").NumberFormatLocal = "#,##0"    '新規
        xlsheet.Columns("D").ColumnWidth = 8
        xlsheet.Columns("E").NumberFormatLocal = "#,##0"    '担当数
        xlsheet.Columns("E").ColumnWidth = 8
        xlsheet.Columns("F").NumberFormatLocal = "#,##0"    '指名
        xlsheet.Columns("F").ColumnWidth = 8
        xlsheet.Columns("G").NumberFormatLocal = "#,##0"    'ポイント
        xlsheet.Columns("G").ColumnWidth = 14
        xlsheet.Columns("H").NumberFormatLocal = "#,##0"    '技術売上
        xlsheet.Columns("H").ColumnWidth = 14
        xlsheet.Columns("I").NumberFormatLocal = "#,##0"    '店販売上
        xlsheet.Columns("I").ColumnWidth = 14
        xlsheet.Columns("J").NumberFormatLocal = "#,##0"    '全体ｻｰﾋﾞｽ
        xlsheet.Columns("J").ColumnWidth = 14
        xlsheet.Columns("K").NumberFormatLocal = "#,##0"    '総売上
        xlsheet.Columns("K").ColumnWidth = 14

        Try
            Do Until i = dt.Rows.Count + 1
                xlrange(i + 1, 1) = dt.Rows(i - 1)("担当者番号")
                xlrange(i + 1, 2) = dt.Rows(i - 1)("担当者名")
                xlrange(i + 1, 3) = dt.Rows(i - 1)("再来")
                xlrange(i + 1, 4) = dt.Rows(i - 1)("新規")
                xlrange(i + 1, 5) = dt.Rows(i - 1)("担当数")
                xlrange(i + 1, 6) = dt.Rows(i - 1)("指名")
                xlrange(i + 1, 7) = dt.Rows(i - 1)("ポイント")
                xlrange(i + 1, 8) = dt.Rows(i - 1)("技術売上")
                xlrange(i + 1, 9) = dt.Rows(i - 1)("店販売上")
                xlrange(i + 1, 10) = dt.Rows(i - 1)("全体ｻｰﾋﾞｽ")
                xlrange(i + 1, 11) = dt.Rows(i - 1)("総売上")
                i = i + 1
            Loop
            'セル設定
            Dim cells As String = "A1:K" & (dt.Rows.Count + 1).ToString()
            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            xlrange.Range("A1:K1").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble

            '［ページ設定］ダイアログボックスを表示（参考）
            'xlapp.Dialogs(xlDialogPageSetup).Show()

            'シートの印刷設定
            With xlsheet.PageSetup
                '.PaperSize = xlPaperA4   '用紙サイズをＡ４

                '印刷の向き　横=xlLandscape 　　縦 = xlPortrait
                .Orientation = Excel.XlPageOrientation.xlLandscape

                '各余白をセンチ(Cm)単位で設定
                .LeftMargin = xlapp.CentimetersToPoints(2)
                .RightMargin = xlapp.CentimetersToPoints(2)
                .TopMargin = xlapp.CentimetersToPoints(3)
                .BottomMargin = xlapp.CentimetersToPoints(2.5)
                .HeaderMargin = xlapp.CentimetersToPoints(1)
                .FooterMargin = xlapp.CentimetersToPoints(1)

                'ヘッダー・フッター設定
                ' 集計期間設定
                Dim period As String = (vbCr) & "集計期間：" & txtStartDay.Text & "～" & txtEndDay.Text

                ' 店舗名取得
                shopName = base_logic.GetShopName()

                ' 店舗名をヘッダーの左側に設定
                .LeftHeader = (vbCrLf) & "店名：" & shopName & period
                .CenterHeader = "&B&14スタッフ集計"
                .RightHeader = Chr(13) + Chr(10) & "&D &T"
                .CenterFooter = "&P/&N"
            End With

            'シートを印刷
            xlsheet.PrintOut()
        Catch ex As Exception
            MsgBox(ex.ToString, Clng_Okexb1, TTL)

        Finally
            xlapp.DisplayAlerts = False
            'xlsheet.SaveAs(str_fullpath)
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

    '#Region "店集計印刷修正中"
    '    '''' <summary>
    '    '''' 店集計一覧Excel出力
    '    ''''</summary>
    '    '''' <remarks></remarks>
    '    Private Sub btnShopPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShopPrint.Click
    '        Dim param As New Habits.DB.DBParameter
    '        Dim dt As DataTable
    '        Dim i As Integer = 1
    '        Dim startX As Integer = 2
    '        Dim shopName As String

    '        Dim xlapp As New Excel.Application
    '        Dim xlbooks As Excel.Workbooks = xlapp.Workbooks
    '        Dim xlbook As Excel.Workbook = xlbooks.Add
    '        Dim xlsheets As Excel.Sheets = xlbook.Worksheets
    '        Dim xlsheet As Excel.Worksheet = DirectCast(xlsheets.Item(1), Excel.Worksheet)
    '        Dim xlrange As Excel.Range

    '        xlrange = xlsheet.Range("1:5")
    '        xlsheet.Name = "店集計"
    '        Try

    '            xlsheet.Columns("A").ColumnWidth = 18               '#
    '            xlsheet.Columns("B").NumberFormatLocal = "#,##0"    '当日人数
    '            xlsheet.Columns("B").ColumnWidth = 9
    '            xlsheet.Columns("C").NumberFormatLocal = "#,##0"    '当日金額
    '            xlsheet.Columns("C").ColumnWidth = 11
    '            xlsheet.Columns("D").NumberFormatLocal = "#,##0"    '累積人数
    '            xlsheet.Columns("D").ColumnWidth = 9
    '            xlsheet.Columns("E").NumberFormatLocal = "#,##0"    '累積金額
    '            xlsheet.Columns("E").ColumnWidth = 11

    '            xlsheet.Columns("F").ColumnWidth = 5

    '            xlsheet.Columns("G").ColumnWidth = 15               '#
    '            xlsheet.Columns("H").NumberFormatLocal = "#,##0"    '当日人数
    '            xlsheet.Columns("H").ColumnWidth = 11
    '            xlsheet.Columns("I").NumberFormatLocal = "#,##0"    '当日金額
    '            xlsheet.Columns("I").ColumnWidth = 11
    '            xlsheet.Columns("J").NumberFormatLocal = "#,##0"    '累積人数
    '            xlsheet.Columns("J").ColumnWidth = 11
    '            xlsheet.Columns("K").NumberFormatLocal = "#,##0"    '累積金額
    '            xlsheet.Columns("K").ColumnWidth = 11

    '            '----------------------
    '            '　売上
    '            '----------------------
    '            xlrange(1, 1) = "【売上】"
    '            xlrange(1, 2) = ""
    '            xlrange(1, 4) = "累計"
    '            xlrange(2, 2) = "人数"
    '            xlrange(2, 3) = "金額"
    '            xlrange(2, 4) = "人数"
    '            xlrange(2, 5) = "金額"

    '            ''当日
    '            param.Clear()
    '            param.Add("@開始日", DateTime.Parse(Me.txtStartDay.Text))
    '            param.Add("@終了日", DateTime.Parse(Me.txtEndDay.Text))
    '            dt = d0300_logic.getShopSalesList(param)

    '            Do Until i = dt.Rows.Count + 1
    '                xlrange(i + startX, 1) = dt.Rows(i - 1)("name")
    '                xlrange(i + startX, 2) = dt.Rows(i - 1)("num")
    '                xlrange(i + startX, 3) = dt.Rows(i - 1)("amount")
    '                i = i + 1
    '            Loop


    '            'セル設定
    '            Dim cells As String = "A2:C" & (dt.Rows.Count + 2).ToString()
    '            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
    '            xlrange.Range("A2:C2").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
    '            startX = startX + dt.Rows.Count + 2

    '            '----------------------
    '            '　来店別
    '            '----------------------
    '            xlrange(startX, 1) = "【来店別】"
    '            xlrange(startX + 1, 2) = "人数"
    '            xlrange(startX + 1, 3) = "金額"
    '            startX = startX + 1
    '            dt = d0300_logic.getShopVisitList(param)

    '            i = 1
    '            Do Until i = dt.Rows.Count + 1
    '                xlrange(i + startX, 1) = dt.Rows(i - 1)("name")
    '                xlrange(i + startX, 2) = dt.Rows(i - 1)("num")
    '                xlrange(i + startX, 3) = dt.Rows(i - 1)("amount")
    '                i = i + 1
    '            Loop

    '            'セル設定
    '            cells = "A" + startX.ToString() + ":C" & (dt.Rows.Count + startX).ToString()
    '            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
    '            xlrange.Range("A" + startX.ToString() + ":C" + startX.ToString()).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
    '            startX = startX + dt.Rows.Count + 2

    '            '----------------------
    '            '　指名
    '            '----------------------
    '            xlrange(startX, 1) = "【指名】"
    '            xlrange(startX + 1, 2) = "人数"
    '            xlrange(startX + 1, 3) = "金額"
    '            startX = startX + 1
    '            dt = d0300_logic.getShopDesignatedList(param)

    '            i = 1
    '            Do Until i = dt.Rows.Count + 1
    '                xlrange(i + startX, 1) = dt.Rows(i - 1)("name")
    '                xlrange(i + startX, 2) = dt.Rows(i - 1)("num")
    '                xlrange(i + startX, 3) = dt.Rows(i - 1)("amount")
    '                i = i + 1
    '            Loop

    '            'セル設定
    '            cells = "A" + startX.ToString() + ":C" & (dt.Rows.Count + startX).ToString()
    '            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
    '            xlrange.Range("A" + startX.ToString() + ":C" + startX.ToString()).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
    '            startX = startX + dt.Rows.Count + 2

    '            '----------------------
    '            '　支払
    '            '----------------------
    '            xlrange(startX, 1) = "【支払】"
    '            xlrange(startX + 1, 2) = "人数"
    '            xlrange(startX + 1, 3) = "金額"
    '            startX = startX + 1
    '            dt = d0300_logic.getShopPaymentList(param)

    '            i = 1
    '            Do Until i = dt.Rows.Count + 1
    '                xlrange(i + startX, 1) = dt.Rows(i - 1)("name")
    '                xlrange(i + startX, 2) = dt.Rows(i - 1)("num")
    '                xlrange(i + startX, 3) = dt.Rows(i - 1)("amount")
    '                i = i + 1
    '            Loop

    '            'セル設定
    '            cells = "A" + startX.ToString() + ":C" & (dt.Rows.Count + startX).ToString()
    '            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
    '            xlrange.Range("A" + startX.ToString() + ":C" + startX.ToString()).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
    '            startX = 2

    '            '----------------------
    '            '　入出金
    '            '----------------------
    '            xlrange(1, 6) = "【入出金】"
    '            xlrange(2, 7) = "件数"
    '            xlrange(2, 8) = "金額"
    '            dt = d0300_logic.getShopCashList(param)

    '            i = 1
    '            Do Until i = dt.Rows.Count + 1
    '                xlrange(i + startX, 6) = dt.Rows(i - 1)("name")
    '                xlrange(i + startX, 7) = dt.Rows(i - 1)("num")
    '                xlrange(i + startX, 8) = dt.Rows(i - 1)("amount")
    '                i = i + 1
    '            Loop

    '            'セル設定
    '            cells = "F2:H" & (dt.Rows.Count + 2).ToString()
    '            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
    '            xlrange.Range("F2:H2").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
    '            startX = startX + dt.Rows.Count + 2

    '            '----------------------
    '            '　営業日
    '            '----------------------
    '            xlrange(startX, 6) = "【営業日】"
    '            dt = d0300_logic.select_number_store_totalday(param)
    '            xlrange(startX + 1, 6) = "スタッフ数"
    '            xlrange(startX + 1, 7) = dt.Rows(0)("スタッフ数")
    '            xlrange(startX + 2, 6) = "営業日数"
    '            xlrange(startX + 2, 7) = dt.Rows(0)("営業日数")

    '            'セル設定
    '            cells = "F" + (startX + 1).ToString() + ":G" & (startX + 2).ToString()
    '            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
    '            startX = startX + 4

    '            '----------------------
    '            '　単価
    '            '----------------------
    '            xlrange(startX, 6) = "【単価】"
    '            xlrange(startX + 1, 7) = "金額"
    '            startX = startX + 1
    '            dt = d0300_logic.getShopCostList(param)

    '            i = 1
    '            Do Until i = dt.Rows.Count + 1
    '                xlrange(i + startX, 6) = dt.Rows(i - 1)("name")
    '                xlrange(i + startX, 7) = dt.Rows(i - 1)("amount")
    '                i = i + 1
    '            Loop

    '            'セル設定
    '            cells = "F" + startX.ToString() + ":G" & (dt.Rows.Count + startX).ToString()
    '            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
    '            xlrange.Range("F" + startX.ToString() + ":G" + startX.ToString()).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
    '            startX = startX + dt.Rows.Count + 2

    '            '----------------------
    '            'シートの印刷設定
    '            '----------------------
    '            With xlsheet.PageSetup
    '                '.PaperSize = xlPaperA4   '用紙サイズをＡ４

    '                '印刷の向き　横=xlLandscape 　　縦 = xlPortrait
    '                .Orientation = Excel.XlPageOrientation.xlLandscape

    '                '各余白をセンチ(Cm)単位で設定
    '                .LeftMargin = xlapp.CentimetersToPoints(2)
    '                .RightMargin = xlapp.CentimetersToPoints(2)
    '                .TopMargin = xlapp.CentimetersToPoints(2.3)
    '                .BottomMargin = xlapp.CentimetersToPoints(0.8)
    '                .HeaderMargin = xlapp.CentimetersToPoints(0.5)
    '                .FooterMargin = xlapp.CentimetersToPoints(0.5)
    '                '.CenterVertically = True   'ページ中央（垂直）
    '                '.CenterHorizontally = True 'ページ中央（水平）

    '                'ヘッダー・フッター設定
    '                ' 集計期間設定
    '                Dim period As String = (vbCr) & "集計期間：" & txtStartDay.Text & "～" & txtEndDay.Text

    '                ' 店舗名取得
    '                shopName = base_logic.GetShopName()

    '                ' 店舗名をヘッダーの左側に設定
    '                .LeftHeader = (vbCrLf) & "店名：" & shopName & period
    '                .CenterHeader = "&B&14店集計"
    '                .RightHeader = Chr(13) + Chr(10) & "&D &T"
    '                .CenterFooter = "&P/&N"
    '            End With

    '            'シートを印刷
    '            xlsheet.PrintOut()

    '            'シートを出力
    '            'xlsheet.SaveAs("C:\test.xls")

    '        Catch ex As Exception
    '            MsgBox(ex.ToString, Clng_Okexb1, TTL)

    '        Finally
    '            xlapp.DisplayAlerts = False
    '            'xlsheet.SaveAs(str_fullpath)
    '            '---終了処理------------
    '            MRComObject(xlrange)
    '            MRComObject(xlsheet)
    '            MRComObject(xlsheets)
    '            xlbook.Close(False)
    '            MRComObject(xlbook)
    '            MRComObject(xlbooks)
    '            xlapp.Quit()
    '            MRComObject(xlapp)

    '        End Try
    '    End Sub
    '#End Region

#Region "店集計印刷"
    '''' <summary>
    '''' 店集計一覧Excel出力
    ''''</summary>
    '''' <remarks></remarks>
    Private Sub btnShopPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShopPrint.Click
        Dim param As New Habits.DB.DBParameter
        Dim dt As DataTable
        Dim i As Integer = 1
        Dim startX As Integer = 2
        Dim shopName As String

        Dim xlapp As New Excel.Application
        Dim xlbooks As Excel.Workbooks = xlapp.Workbooks
        Dim xlbook As Excel.Workbook = xlbooks.Add
        Dim xlsheets As Excel.Sheets = xlbook.Worksheets
        Dim xlsheet As Excel.Worksheet = DirectCast(xlsheets.Item(1), Excel.Worksheet)
        Dim xlrange As Excel.Range

        xlrange = xlsheet.Range("1:3")
        xlsheet.Name = "店集計"
        Try

            xlsheet.Columns("A").ColumnWidth = 18               '#
            xlsheet.Columns("B").NumberFormatLocal = "#,##0"    '人数
            xlsheet.Columns("B").ColumnWidth = 10
            xlsheet.Columns("C").NumberFormatLocal = "#,##0"    '金額
            xlsheet.Columns("C").ColumnWidth = 15

            xlsheet.Columns("F").ColumnWidth = 15               '#
            xlsheet.Columns("G").NumberFormatLocal = "#,##0"    '人数
            xlsheet.Columns("G").ColumnWidth = 15
            xlsheet.Columns("H").NumberFormatLocal = "#,##0"    '金額
            xlsheet.Columns("H").ColumnWidth = 15

            '----------------------
            '　売上
            '----------------------
            xlrange(1, 1) = "【売上】"
            xlrange(2, 2) = "人数"
            xlrange(2, 3) = "金額"

            param.Add("@開始日", DateTime.Parse(Me.txtStartDay.Text))
            param.Add("@終了日", DateTime.Parse(Me.txtEndDay.Text))
            dt = d0300_logic.getShopSalesList(param)

            For Each row As DataRow In dt.Rows
                If row("delflag") = False Then
                    xlrange(i + startX, 1) = row("name")
                    xlrange(i + startX, 2) = row("num")
                    xlrange(i + startX, 3) = row("amount")
                    i = i + 1
                Else
                    If row("num") <> "0" AndAlso row("amount") <> "0" Then
                        xlrange(i + startX, 1) = row("name")
                        xlrange(i + startX, 2) = row("num")
                        xlrange(i + startX, 3) = row("amount")
                        i = i + 1
                    End If
                End If
            Next

            'セル設定
            'Dim cells As String = "A2:C" & (dt.Rows.Count + 2).ToString()
            Dim cells As String = "A2:C" & (i + 1).ToString()
            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            xlrange.Range("A2:C2").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
            'startX = startX + dt.Rows.Count + 2
            startX = startX + i + 1

            '----------------------
            '　来店別
            '----------------------
            xlrange(startX, 1) = "【来店別】"
            xlrange(startX + 1, 2) = "人数"
            xlrange(startX + 1, 3) = "金額"
            startX = startX + 1
            dt = d0300_logic.getShopVisitList(param)

            i = 1
            Do Until i = dt.Rows.Count + 1
                xlrange(i + startX, 1) = dt.Rows(i - 1)("name")
                xlrange(i + startX, 2) = dt.Rows(i - 1)("num")
                xlrange(i + startX, 3) = dt.Rows(i - 1)("amount")
                i = i + 1
            Loop

            'セル設定
            cells = "A" + startX.ToString() + ":C" & (dt.Rows.Count + startX).ToString()
            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            xlrange.Range("A" + startX.ToString() + ":C" + startX.ToString()).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
            startX = startX + dt.Rows.Count + 2

            '----------------------
            '　指名
            '----------------------
            xlrange(startX, 1) = "【指名】"
            xlrange(startX + 1, 2) = "人数"
            xlrange(startX + 1, 3) = "金額"
            startX = startX + 1
            dt = d0300_logic.getShopDesignatedList(param)

            i = 1
            Do Until i = dt.Rows.Count + 1
                xlrange(i + startX, 1) = dt.Rows(i - 1)("name")
                xlrange(i + startX, 2) = dt.Rows(i - 1)("num")
                xlrange(i + startX, 3) = dt.Rows(i - 1)("amount")
                i = i + 1
            Loop

            'セル設定
            cells = "A" + startX.ToString() + ":C" & (dt.Rows.Count + startX).ToString()
            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            xlrange.Range("A" + startX.ToString() + ":C" + startX.ToString()).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
            startX = startX + dt.Rows.Count + 2

            '----------------------
            '　支払
            '----------------------
            xlrange(startX, 1) = "【支払】"
            xlrange(startX + 1, 2) = "人数"
            xlrange(startX + 1, 3) = "金額"
            startX = startX + 1
            dt = d0300_logic.getShopPaymentList(param)

            i = 1
            Do Until i = dt.Rows.Count + 1
                xlrange(i + startX, 1) = dt.Rows(i - 1)("name")
                xlrange(i + startX, 2) = dt.Rows(i - 1)("num")
                xlrange(i + startX, 3) = dt.Rows(i - 1)("amount")
                i = i + 1
            Loop

            'セル設定
            cells = "A" + startX.ToString() + ":C" & (dt.Rows.Count + startX).ToString()
            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            xlrange.Range("A" + startX.ToString() + ":C" + startX.ToString()).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
            startX = 2

            '----------------------
            '　入出金
            '----------------------
            xlrange(1, 6) = "【入出金】"
            xlrange(2, 7) = "件数"
            xlrange(2, 8) = "金額"
            dt = d0300_logic.getShopCashList(param)

            i = 1
            Do Until i = dt.Rows.Count + 1
                xlrange(i + startX, 6) = dt.Rows(i - 1)("name")
                xlrange(i + startX, 7) = dt.Rows(i - 1)("num")
                xlrange(i + startX, 8) = dt.Rows(i - 1)("amount")
                i = i + 1
            Loop

            'セル設定
            cells = "F2:H" & (dt.Rows.Count + 2).ToString()
            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            xlrange.Range("F2:H2").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
            startX = startX + dt.Rows.Count + 2

            '----------------------
            '　営業日
            '----------------------
            xlrange(startX, 6) = "【営業日】"
            dt = d0300_logic.select_number_store_totalday(param)
            xlrange(startX + 1, 6) = "スタッフ数"
            xlrange(startX + 1, 7) = dt.Rows(0)("スタッフ数")
            xlrange(startX + 2, 6) = "営業日数"
            xlrange(startX + 2, 7) = dt.Rows(0)("営業日数")

            'セル設定
            cells = "F" + (startX + 1).ToString() + ":G" & (startX + 2).ToString()
            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            startX = startX + 4

            '----------------------
            '　単価
            '----------------------
            xlrange(startX, 6) = "【単価】"
            xlrange(startX + 1, 7) = "金額"
            startX = startX + 1
            dt = d0300_logic.getShopCostList(param)

            i = 1
            Do Until i = dt.Rows.Count + 1
                xlrange(i + startX, 6) = dt.Rows(i - 1)("name")
                xlrange(i + startX, 7) = dt.Rows(i - 1)("amount")
                i = i + 1
            Loop

            'セル設定
            cells = "F" + startX.ToString() + ":G" & (dt.Rows.Count + startX).ToString()
            xlrange.Range(cells).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            xlrange.Range("F" + startX.ToString() + ":G" + startX.ToString()).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble
            startX = startX + dt.Rows.Count + 2

            '----------------------
            'シートの印刷設定
            '----------------------
            With xlsheet.PageSetup
                '.PaperSize = xlPaperA4   '用紙サイズをＡ４

                '印刷の向き　横=xlLandscape 　　縦 = xlPortrait
                .Orientation = Excel.XlPageOrientation.xlLandscape

                '各余白をセンチ(Cm)単位で設定
                .LeftMargin = xlapp.CentimetersToPoints(2)
                .RightMargin = xlapp.CentimetersToPoints(2)
                .TopMargin = xlapp.CentimetersToPoints(2.3)
                .BottomMargin = xlapp.CentimetersToPoints(0.8)
                .HeaderMargin = xlapp.CentimetersToPoints(0.5)
                .FooterMargin = xlapp.CentimetersToPoints(0.5)
                '.CenterVertically = True   'ページ中央（垂直）
                '.CenterHorizontally = True 'ページ中央（水平）

                'ヘッダー・フッター設定
                ' 集計期間設定
                Dim period As String = (vbCr) & "集計期間：" & txtStartDay.Text & "～" & txtEndDay.Text

                ' 店舗名取得
                shopName = base_logic.GetShopName()

                ' 店舗名をヘッダーの左側に設定
                .LeftHeader = (vbCrLf) & "店名：" & shopName & period
                .CenterHeader = "&B&14店集計"
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
            'xlsheet.SaveAs(str_fullpath)
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

#Region "来店者ボタン押下"
    ''' <summary>
    ''' 来店者ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnShowList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowList.Click
        d0400_来店者.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
#End Region

#End Region

#Region "メソッド"

#Region "入力チェック"
    ''' <summary>
    ''' "入力チェック
    ''' </summary>
    ''' <returns>True：正常、False：エラー</returns>
    ''' <remarks></remarks>
    Private Function inputCheck() As Boolean
        Dim errMsg As String = Nothing
        inputCheck = False

        '開始日チェック
        If Not Sys_InputCheck_Date(Me.txtStartDay.Text, errMsg) Then
            Call Sys_Error("開始日 " & errMsg, Me.txtStartDay)
            Exit Function
        End If
        Me.txtStartDay.Text = Format(DateTime.Parse(Me.txtStartDay.Text), "yyyy/MM/dd")

        '終了日チェック
        If Not Sys_InputCheck_Date(Me.txtEndDay.Text, errMsg) Then
            Call Sys_Error("終了日 " & errMsg, Me.txtEndDay)
            Exit Function
        End If
        Me.txtEndDay.Text = Format(DateTime.Parse(Me.txtEndDay.Text), "yyyy/MM/dd")

        '論理チェック
        If Me.txtStartDay.Text > Me.txtEndDay.Text Then
            Call Sys_Error("開始日は終了日以前を入力してください。　 ", Me.txtStartDay)
            Exit Function
        End If

        If DateAdd("m", 1, Me.txtStartDay.Text) < Me.txtEndDay.Text Then
            Call Sys_Error("集計期間は1ヶ月以内で入力してください。　 ", Me.txtStartDay)
            Exit Function
        End If


        inputCheck = True
    End Function
#End Region

#Region "目標額設定チェック"
    ''' <summary>
    ''' 目標額設定チェック
    ''' </summary>
    ''' <returns>True：当月目標額の設定有、False：設定なし</returns>
    ''' <remarks></remarks>
    Private Function chkTagetExist() As Boolean
        Dim param As New Habits.DB.DBParameter
        Dim dt As DataTable
        Dim rtn As Boolean = False
        Dim dt_date As DateTime = Date.Parse(Me.txtEndDay.Text)
        param.Add("@対象年月", Sys_StartDate(dt_date).ToString)
        dt = d0300_logic.select_E_目標額(param)

        If (dt.Rows.Count > 0) Then
            rtn = True
        End If
        Return rtn
    End Function
#End Region

#Region "集計処理"
    ''' <summary>
    ''' 集計処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 集計処理()
        Dim i As Integer
        Dim dt As New DataTable
        Dim insert_dt As Integer
        Dim param As New Habits.DB.DBParameter
        Dim Last_Date As Date

        '入力チェック
        If Not inputCheck() Then Exit Sub

        'ワークテーブル削除
        d0300_logic.deleteWkTbl()

        ' 目標額情報設定
        param.Add("対象年月", Sys_StartDate(Me.txtEndDay.Text))
        dt = d0300_logic.select_E_目標額(param)
        param.Clear()

        For i = 0 To dt.Rows.Count - 1
            param.Add("@売上区分番号", dt.Rows(i)("売上区分番号"))
            param.Add("@対象年月", Sys_StartDate(Me.txtStartDay.Text))
            param.Add("@目標額", dt.Rows(i)("目標額"))
            param.Add("@営業日数", dt.Rows(i)("営業日数"))
            insert_dt = d0300_logic.insert_W_目標(param)
            param.Clear()
            売上(Integer.Parse(dt.Rows(i)("売上区分番号").ToString))
        Next

        ' 累計総売上
        param.Clear()
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        dt = d0300_logic.getPeriodSales(param)
        If dt.Rows.Count > 0 Then
            Me.total_sale = Integer.Parse(dt.Rows(0)("売上").ToString())
            Me.total_sale_tax = Integer.Parse(dt.Rows(0)("税込").ToString())
        End If
        Me.lbl総売上累計.Text = (Me.total_sale_tax).ToString("#,##0")

        ' 本日総売上
        param.Clear()
        param.Add("@開始日", Me.txtEndDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        dt = d0300_logic.getPeriodSales(param)
        If dt.Rows.Count > 0 Then
            Me.daily_sale = Integer.Parse(dt.Rows(0)("売上").ToString())
            Me.daily_sale_tax = Integer.Parse(dt.Rows(0)("税込").ToString())
        End If
        Me.lbl総売上本日.Text = (Me.daily_sale_tax).ToString("#,##0")

        If Me.cmbSalesDivision.SelectedIndex <> -1 Then
            売上(Integer.Parse(Me.cmbSalesDivision.SelectedValue.ToString))

            Call 店()
            Call 目標()
            Call 来店区分()
            Call 支払()
            Call 営業日()
            Call 入出金()

            param.Clear()
            param.Add("@終了日", Me.txtEndDay.Text)
            d0400_Logic = New Habits.Logic.d0400_logic
            dt = d0400_Logic.select_customer(param)

            Me.btnShowList.Enabled = False
            If dt.Rows.Count <> 0 Then
                Me.btnShowList.Enabled = True
            End If

            Me.lbl本日営業日数.Text = "-"
            Me.lbl累計天候.Text = "-"

            Last_Date = Date.Parse(Me.txtEndDay.Text)

            Me.lbl_日付.Text = Format(Last_Date, "MM/dd")
            Me.lbl_日付2.Text = Format(Last_Date, "MM/dd")
            Me.lbl_日付3.Text = Format(Last_Date, "MM/dd")
        End If
        ' 売上区分プルダウン再設定
        param.Clear()
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        Me.cmbSalesDivision.DataSource = d0300_logic.getSalesDivList(param)

        If (chkTagetExist() = False) Then
            MsgBox("目標額が設定されていないため達成率は表示されません。　", Clng_Okinb1, TTL)
        End If
    End Sub
#End Region

#Region "目標一覧設定"
    ''' <summary>
    ''' 目標一覧設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 目標()
        Dim param As New Habits.DB.DBParameter
        Dim i, int_MOK As Integer 'for用、目標額
        Dim target_money As Double
        int_MOK = 0
        Dim select_dt As DataTable

        Dim dt_date As DateTime = Date.Parse(Me.txtEndDay.Text)
        Me.dgv店目標.Rows.Clear()
        select_dt = d0300_logic.select_W_目標
        param.Add("@対象年月", Sys_StartDate(dt_date).ToString)
        If select_dt.Rows.Count <> 0 Then ''目標額分の行を追加
            Me.dgv店目標.Rows.Add(select_dt.Rows.Count + 1) ''各区分の集計を行う前にdgvに行を追加
            Me.dgv店目標.Columns(0).Width = 140
            Me.dgv店目標.Columns(1).Width = 105
            Me.dgv店目標.Columns(2).Width = 105
            Me.dgv店目標.Columns(3).Width = 90
            Me.dgv店目標.Columns(4).Width = 80
        End If
        Me.dgv店目標.DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight

        For i = 1 To select_dt.Rows.Count
            int_MOK += Integer.Parse(select_dt.Rows(i - 1)("目標額").ToString)
            Me.dgv店目標.Rows(i).Cells(0).Value = select_dt.Rows(i - 1)("売上区分") '区分名
            Me.dgv店目標.Rows(i).Cells(1).Value = Integer.Parse(select_dt.Rows(i - 1)("目標額").ToString).ToString("#,##0") '目標
            If Integer.Parse(select_dt.Rows(i - 1)("営業日数").ToString) <> 0 Then
                Me.dgv店目標.Rows(i).Cells(2).Value = (Integer.Parse(select_dt.Rows(i - 1)("目標額").ToString) _
                            / Integer.Parse(select_dt.Rows(i - 1)("営業日数").ToString)).ToString("#,##0") '一日平均目標
            Else
                Me.dgv店目標.Rows(i).Cells(2).Value = Integer.Parse(select_dt.Rows(i - 1)("目標額").ToString).ToString("#,##0") '一日平均目標
            End If
            target_money = Integer.Parse(select_dt.Rows(i - 1)("売上累").ToString) - (Integer.Parse(select_dt.Rows(i - 1)("目標額").ToString))

            If target_money < 0 Then
                Me.dgv店目標.Rows(i).Cells(3).Value = Format(target_money, "#,##0")
            Else
                Me.dgv店目標.Rows(i).Cells(3).Value = "+" & Format(target_money, "#,##0")
            End If

            target_money = Double.Parse(select_dt.Rows(i - 1)("売上累").ToString) _
                        / Double.Parse(IIf(Integer.Parse(select_dt.Rows(i - 1)("目標額").ToString) = 0, 1, Integer.Parse(select_dt.Rows(i - 1)("目標額").ToString)).ToString) * 100
            If target_money = 0 Then
                Me.dgv店目標.Rows(i).Cells(4).Value = "0.0%"
            Else
                Me.dgv店目標.Rows(i).Cells(4).Value = Format(target_money, "###0.0") & "%"
            End If
        Next i
        '---------総売上の表示----------------------------------------------------------------------
        If select_dt.Rows.Count <> 0 Then
            Me.dgv店目標.Rows(0).Cells(0).Value = "総売上" ''区分名
            Me.dgv店目標.Rows(0).Cells(1).Value = int_MOK.ToString("#,##0") ''目標
            If Integer.Parse(select_dt.Rows(0)("営業日数").ToString) <> 0 Then
                Me.dgv店目標.Rows(0).Cells(2).Value = (int_MOK / Integer.Parse(select_dt.Rows(0)("営業日数").ToString)).ToString("#,##0") ''一日平均目標
            Else
                Me.dgv店目標.Rows(0).Cells(2).Value = int_MOK.ToString("#,##0") ''一日平均目標
            End If
            Me.dgv店目標.Rows(0).Cells(3).Value = (Me.total_sale - int_MOK).ToString("#,##0") ''累計±
            Me.dgv店目標.Rows(0).Cells(4).Value = Format(Me.total_sale / Double.Parse(IIf(int_MOK = 0, 1, int_MOK).ToString) * 100, "###0.0") & "%" ''達成率
        Else
            Me.dgv店目標.Rows.Clear() ''目標額が無かった場合dgvを初期化
        End If
    End Sub
#End Region

#Region "店・客数情報設定"
    ''' <summary>
    ''' 店・客数情報及び全区分合計人数の設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 店()
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        '---------【本日】スタッフ数、天候---------
        param.Add("@営業日", Me.txtEndDay.Text)
        dt = d0300_logic.select_number_store_today(param)
        If dt.Rows.Count <> 0 Then
            Me.lbl本日天候.Text = dt.Rows(0)("天候").ToString
            Me.lbl本日スタッフ数.Text = dt.Rows(0)("スタッフ数").ToString
        Else
            Me.lbl本日天候.Text = "-"
            Me.lbl本日スタッフ数.Text = "0"
        End If
        param.Clear()
        '---------【累計】スタッフ数、営業日数---------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        dt = d0300_logic.select_number_store_totalday(param)

        Me.lbl累計スタッフ数.Text = dt.Rows(0)("スタッフ数").ToString
        Me.int_er = Integer.Parse(dt.Rows(0)("営業日数").ToString)
        Me.lbl累計営業日数.Text = int_er.ToString
        param.Clear()
        '---------【本日】総客数、及び総純売上人数------------
        param.Add("@開始日", Me.txtEndDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        dt = d0300_logic.select_number_customer(param)
        Me.lbl本日総客数.Text = dt.Rows(0)("人数").ToString
        Me.lbl総売上人数本日.Text = dt.Rows(0)("人数").ToString
        param.Clear()
        '---------【累計】総客数、及び総純売上人数------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        dt = d0300_logic.select_number_customer(param)
        Me.lbl累計総客数.Text = dt.Rows(0)("人数").ToString
        Me.lbl総売上人数累計.Text = dt.Rows(0)("人数").ToString
        param.Clear()
        '---------【本日】女性客数-----------
        param.Add("@開始日", Me.txtEndDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@性別番号", 1)
        dt = d0300_logic.select_number_storecustomer(param)
        Dim int_jhn As Integer = Integer.Parse(dt.Rows(0)("人数").ToString)
        param.Clear()
        '---------【本日】男性客数-----------
        param.Add("@開始日", Me.txtEndDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@性別番号", 2)
        dt = d0300_logic.select_number_storecustomer(param)
        Dim int_dhn As Integer = Integer.Parse(dt.Rows(0)("人数").ToString)
        param.Clear()
        '---------【累計】女性客数-----------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@性別番号", 1)
        dt = d0300_logic.select_number_storecustomer(param)
        Dim int_jrn As Integer = Integer.Parse(dt.Rows(0)("人数").ToString)
        param.Clear()
        '---------【累計】男性客数-----------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@性別番号", 2)
        dt = d0300_logic.select_number_storecustomer(param)
        Dim int_drn As Integer = Integer.Parse(dt.Rows(0)("人数").ToString)
        param.Clear()
        '---------【指名】女性---------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@性別番号", 1)
        dt = d0300_logic.select_nomination(param)
        Dim int_sjh As Integer = Integer.Parse(dt.Rows(0)("人数").ToString)
        Dim int_sju As Integer = Integer.Parse(dt.Rows(0)("売上").ToString)
        param.Clear()
        '---------【指名】男性---------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@性別番号", 2)
        dt = d0300_logic.select_nomination(param)
        Dim int_sdh As Integer = Integer.Parse(dt.Rows(0)("人数").ToString)
        Dim int_sdu As Integer = Integer.Parse(dt.Rows(0)("売上").ToString)
        param.Clear()
    End Sub
#End Region

#Region "来店区分別情報設定"
    Private Sub 来店区分()
        Dim int_saij, int_shij, int_frej, int_said, int_shid, int_fred As Integer ''再来女、新規女、フリ女、再来男、新規男、フリ男
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        '------【本日】再来----------------------------------------------------------------------------
        param.Add("@開始日", Me.txtEndDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", VISIT_RETURN) '再来
        dt = d0300_logic.select_coming_store_division(param)
        If dt.Rows.Count <> 0 Then
            Me.lbl本日再来.Text = dt.Rows(0)("人数").ToString
        End If
        param.Clear()
        '------【本日】新規----------------------------------------------------------------------------
        param.Add("@開始日", Me.txtEndDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", VISIT_NEW) '新規
        dt = d0300_logic.select_coming_store_division(param)
        If dt.Rows.Count <> 0 Then
            Me.lbl本日新規.Text = dt.Rows(0)("人数").ToString
        End If
        param.Clear()
        '------【本日】フリー----------------------------------------------------------------------------
        param.Add("@開始日", Me.txtEndDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", VISIT_FREE) 'フリー
        dt = d0300_logic.select_coming_store_division(param)
        If dt.Rows.Count <> 0 Then
            Me.lbl本日フリー.Text = dt.Rows(0)("人数").ToString
        End If
        param.Clear()
        '------【累計】再来----------------------------------------------------------------------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", VISIT_RETURN) '再来
        dt = d0300_logic.select_coming_store_division(param)
        If dt.Rows.Count <> 0 Then
            Me.lbl累計再来.Text = dt.Rows(0)("人数").ToString
        End If
        param.Clear()
        '------【累計】新規----------------------------------------------------------------------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", VISIT_NEW) '新規
        dt = d0300_logic.select_coming_store_division(param)
        If dt.Rows.Count <> 0 Then
            Me.lbl累計新規.Text = dt.Rows(0)("人数").ToString
        End If
        param.Clear()
        '------【累計】フリー----------------------------------------------------------------------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", VISIT_FREE) 'フリー
        dt = d0300_logic.select_coming_store_division(param)
        If dt.Rows.Count <> 0 Then
            Me.lbl累計フリー.Text = dt.Rows(0)("人数").ToString
        End If
        param.Clear()
        '------【累計】女性、再来----------------------------------------------------------------------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", VISIT_RETURN)
        param.Add("@性別番号", 1)
        dt = d0300_logic.selet_coming_division_sex(param)
        If dt.Rows.Count = 0 Then
            int_saij = 0
        Else
            int_saij = Integer.Parse(dt.Rows(0)("人数").ToString)
        End If
        param.Clear()
        '------【累計】女性、新規----------------------------------------------------------------------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", VISIT_NEW)
        param.Add("@性別番号", 1)
        dt = d0300_logic.selet_coming_division_sex(param)
        If dt.Rows.Count = 0 Then
            int_shij = 0
        Else
            int_shij = Integer.Parse(dt.Rows(0)("人数").ToString)
        End If
        param.Clear()
        '------【累計】女性、フリー--------------------------------------------------------------------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", VISIT_FREE)
        param.Add("@性別番号", 1)
        dt = d0300_logic.selet_coming_division_sex(param)
        If dt.Rows.Count = 0 Then
            int_frej = 0
        Else
            int_frej = Integer.Parse(dt.Rows(0)("人数").ToString)
        End If
        param.Clear()
        '------【累計】男性、再来----------------------------------------------------------------------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", VISIT_RETURN)
        param.Add("@性別番号", 2)
        dt = d0300_logic.selet_coming_division_sex(param)
        If dt.Rows.Count = 0 Then
            int_said = 0
        Else
            int_said = Integer.Parse(dt.Rows(0)("人数").ToString)
        End If
        param.Clear()
        '------【累計】男性、新規----------------------------------------------------------------------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", VISIT_NEW)
        param.Add("@性別番号", 2)
        dt = d0300_logic.selet_coming_division_sex(param)
        If dt.Rows.Count = 0 Then
            int_shid = 0
        Else
            int_shid = Integer.Parse(dt.Rows(0)("人数").ToString)
        End If
        param.Clear()
        '------【累計】男性、フリー----------------------------------------------------------------------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", VISIT_FREE)
        param.Add("@性別番号", 2)
        dt = d0300_logic.selet_coming_division_sex(param)
        If dt.Rows.Count = 0 Then
            int_fred = 0
        Else
            int_fred = Integer.Parse(dt.Rows(0)("人数").ToString)
        End If
        param.Clear()
    End Sub
#End Region

#Region "支払情報設定"
    ''' <summary>
    ''' 支払情報設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 支払()
        Dim dt As New DataTable
        Dim insert_dt As New Integer
        ''「本日」「累計」の「現金」「カード」「その他」「ポイント割引」「合計サービス」「消費税」変数
        Dim int_cash_today, int_cash_total, int_card_today, int_card_total, int_other_today, int_other_total, int_point_today, int_point_total, int_service_today, int_service_total, int_tax_today, int_tax_total As Integer
        Dim param As New Habits.DB.DBParameter
        '-------本日----------------------------
        param.Add("@開始日", Me.txtEndDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        dt = d0300_logic.select_pay(param)
        int_cash_today = Integer.Parse(IIf(dt.Rows(0)("現金支払").Equals(System.DBNull.Value), 0, dt.Rows(0)("現金支払")).ToString)
        int_card_today = Integer.Parse(IIf(dt.Rows(0)("カード支払").Equals(System.DBNull.Value), 0, dt.Rows(0)("カード支払")).ToString)
        int_other_today = Integer.Parse(IIf(dt.Rows(0)("その他支払").Equals(System.DBNull.Value), 0, dt.Rows(0)("その他支払")).ToString)
        int_point_today = Integer.Parse(IIf(dt.Rows(0)("ポイント割引支払").Equals(System.DBNull.Value), 0, dt.Rows(0)("ポイント割引支払")).ToString)
        int_service_today = Integer.Parse(IIf(dt.Rows(0)("サービス").Equals(System.DBNull.Value), 0, dt.Rows(0)("サービス")).ToString)
        int_tax_today = Integer.Parse(IIf(dt.Rows(0)("消費税").Equals(System.DBNull.Value), 0, dt.Rows(0)("消費税")).ToString)
        Me.lbl総サービス人数本日.Text = Integer.Parse(IIf(dt.Rows(0)("サービス人数").Equals(System.DBNull.Value), 0, dt.Rows(0)("サービス人数")).ToString).ToString("#,##0")
        param.Clear()
        '-------累計----------------------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        dt = d0300_logic.select_pay(param)
        int_cash_total = Integer.Parse(IIf(dt.Rows(0)("現金支払").Equals(System.DBNull.Value), 0, dt.Rows(0)("現金支払")).ToString)
        int_card_total = Integer.Parse(IIf(dt.Rows(0)("カード支払").Equals(System.DBNull.Value), 0, dt.Rows(0)("カード支払")).ToString)
        int_other_total = Integer.Parse(IIf(dt.Rows(0)("その他支払").Equals(System.DBNull.Value), 0, dt.Rows(0)("その他支払")).ToString)
        int_point_total = Integer.Parse(IIf(dt.Rows(0)("ポイント割引支払").Equals(System.DBNull.Value), 0, dt.Rows(0)("ポイント割引支払")).ToString)
        int_service_total = Integer.Parse(IIf(dt.Rows(0)("サービス").Equals(System.DBNull.Value), 0, dt.Rows(0)("サービス")).ToString)
        int_tax_total = Integer.Parse(IIf(dt.Rows(0)("消費税").Equals(System.DBNull.Value), 0, dt.Rows(0)("消費税")).ToString)
        Me.lbl総サービス人数累計.Text = Integer.Parse(IIf(dt.Rows(0)("サービス人数").Equals(System.DBNull.Value), 0, dt.Rows(0)("サービス人数")).ToString).ToString("#,##0")
        param.Clear()
        '-------表示----------------------------
        Me.lbl本日現金.Text = int_cash_today.ToString("#,##0")
        Me.lbl本日カード.Text = int_card_today.ToString("#,##0")
        Me.lbl本日その他.Text = int_other_today.ToString("#,##0")
        Me.lbl本日ポイント割引.Text = int_point_today.ToString("#,##0")
        Me.lbl本日消費税.Text = int_tax_today.ToString("#,##0")
        Me.lbl累計現金.Text = int_cash_total.ToString("#,##0")
        Me.lbl累計カード.Text = int_card_total.ToString("#,##0")
        Me.lbl累計その他.Text = int_other_total.ToString("#,##0")
        Me.lbl累計ポイント割引.Text = int_point_total.ToString("#,##0")
        Me.lbl累計消費税.Text = int_tax_total.ToString("#,##0")
        'lbl総純売上本日.Text  =
        Me.lbl総消費税本日.Text = int_tax_today.ToString("#,##0")
        Me.lbl総消費税累計.Text = int_tax_total.ToString("#,##0")
        Me.lbl総サービス本日.Text = int_service_today.ToString("#,##0")
        Me.lbl総サービス累計.Text = int_service_total.ToString("#,##0")
        '-----W_支払------------------------
        param.Add("@総客本", Me.lbl本日総客数.Text)
        param.Add("@現金本", int_cash_today)
        param.Add("@カード本", int_card_today)
        param.Add("@その他本", int_other_today)
        param.Add("@ポイント割引本", int_point_today)
        param.Add("@消費税本", int_tax_today)
        param.Add("@現金累", int_cash_total)
        param.Add("@カード累", int_card_total)
        param.Add("@その他累", int_other_total)
        param.Add("@ポイント割引累", int_point_total)
        param.Add("@消費税累", int_tax_total)
        insert_dt = d0300_logic.insert_W_支払(param)
    End Sub
#End Region

#Region "売上情報設定"
    ''' <summary>
    ''' 売上情報設定
    ''' </summary>
    ''' <param name="cmd_number"></param>
    ''' <remarks></remarks>
    Private Sub 売上(ByVal cmd_number As Integer)
        Dim dt As New DataTable
        Dim update_dt As New Integer
        Dim param As New Habits.DB.DBParameter
        Dim int_juh, int_jur, int_juhn, int_jurn, int_duh, int_dur, int_duhn, int_durn As Integer ''女売本（サービス引後）、女売累、女売本人、女売累人、男売本、男売累、男売本人、男売累人
        Dim int_jsh, int_jsr, int_jshn, int_jsrn, int_dsh, int_dsr, int_dshn, int_dsrn As Integer ''女サ本、女サ累、女サ本人、女サ累人、男サ本、男サ累、男サ本人、男サ累人
        Dim int_dailysale, int_totalsale, int_dailynum, int_totalnum As Integer ''総本売、総累売、総本人、総累人(一時的に保管用変数)

        '------【本日】女性(売上、サービス、サービス人数)--------------------------------------------------------------------------------
        param.Add("@性別番号", 1)       ''女性
        param.Add("@開始日", Me.txtEndDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@売上区分番号", cmd_number)
        dt = d0300_logic.select_sale_figue(param)
        int_juh = Integer.Parse(dt.Rows(0)("売上").ToString)
        int_jsh = Integer.Parse(dt.Rows(0)("サービス").ToString)
        int_juhn = Integer.Parse(dt.Rows(0)("人数").ToString)
        int_jshn = Integer.Parse(dt.Rows(0)("サービス人数").ToString)
        Me.lbl女性売上本日.Text = int_juh.ToString("#,##0")
        Me.lbl女性サービス本日.Text = int_jsh.ToString("#,##0")
        Me.lbl女性売上人数本日.Text = int_juhn.ToString
        Me.lbl女性サービス人数本日.Text = int_jshn.ToString
        param.Clear()

        '------【本日】男性(売上、サービス、サービス人数)--------------------------------------------------------------------------------
        param.Add("@性別番号", 2)       ''男性
        param.Add("@開始日", Me.txtEndDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@売上区分番号", cmd_number)
        dt = d0300_logic.select_sale_figue(param)
        int_duh = Integer.Parse(dt.Rows(0)("売上").ToString)
        int_dsh = Integer.Parse(dt.Rows(0)("サービス").ToString)
        int_duhn = Integer.Parse(dt.Rows(0)("人数").ToString)
        int_dshn = Integer.Parse(dt.Rows(0)("サービス人数").ToString)
        Me.lbl男性売上本日.Text = int_duh.ToString("#,##0")
        Me.lbl男性サービス本日.Text = int_dsh.ToString("#,##0")
        Me.lbl男性売上人数本日.Text = int_duhn.ToString
        Me.lbl男性サービス人数本日.Text = int_dshn.ToString
        param.Clear()

        '------【累計】女性(売上、サービス、サービス人数)--------------------------------------------------------------------------------
        param.Add("@性別番号", 1)       ''女性
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@売上区分番号", cmd_number)
        dt = d0300_logic.select_sale_figue(param)
        int_jur = Integer.Parse(dt.Rows(0)("売上").ToString)
        int_jsr = Integer.Parse(dt.Rows(0)("サービス").ToString)
        int_jurn = Integer.Parse(dt.Rows(0)("人数").ToString)
        int_jsrn = Integer.Parse(dt.Rows(0)("サービス人数").ToString)
        Me.lbl女性売上累計.Text = int_jur.ToString("#,##0")
        Me.lbl女性サービス累計.Text = int_jsr.ToString("#,##0")
        Me.lbl女性売上人数累計.Text = int_jurn.ToString
        Me.lbl女性サービス人数累計.Text = int_jsrn.ToString
        param.Clear()

        '------【累計】男性(売上、サービス、サービス人数)--------------------------------------------------------------------------------
        param.Add("@性別番号", 2)       ''男性
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@売上区分番号", cmd_number)
        dt = d0300_logic.select_sale_figue(param)
        int_dur = Integer.Parse(dt.Rows(0)("売上").ToString)
        int_dsr = Integer.Parse(dt.Rows(0)("サービス").ToString)
        int_durn = Integer.Parse(dt.Rows(0)("人数").ToString)
        int_dsrn = Integer.Parse(dt.Rows(0)("サービス人数").ToString)
        Me.lbl男性売上累計.Text = int_dur.ToString("#,##0")
        Me.lbl男性サービス累計.Text = int_dsr.ToString("#,##0")
        Me.lbl男性売上人数累計.Text = int_durn.ToString
        Me.lbl男性サービス人数累計.Text = int_dsrn.ToString
        param.Clear()

        '------【本日】再来(売上、人数)--------------------------------------------------------------------------------------------------
        param.Add("@開始日", Me.txtEndDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", 1)
        param.Add("@売上区分番号", cmd_number)
        dt = d0300_logic.sale_value_coming_storedivision(param)
        Me.lbl再来売上本日.Text = Integer.Parse(dt.Rows(0)("売上").ToString).ToString("#,##0")
        Me.lbl再来売上人数本日.Text = dt.Rows(0)("人数").ToString
        param.Clear()

        '------【本日】新規(売上、人数)--------------------------------------------------------------------------------------------------
        param.Add("@開始日", Me.txtEndDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", 2)
        param.Add("@売上区分番号", cmd_number)
        dt = d0300_logic.sale_value_coming_storedivision(param)
        Me.lbl新規売上本日.Text = Integer.Parse(dt.Rows(0)("売上").ToString).ToString("#,##0")
        Me.lbl新規売上人数本日.Text = dt.Rows(0)("人数").ToString
        param.Clear()

        '------【本日】フリー(売上、人数)------------------------------------------------------------------------------------------------
        param.Add("@開始日", Me.txtEndDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", 3)
        param.Add("@売上区分番号", cmd_number)
        dt = d0300_logic.sale_value_coming_storedivision(param)
        Me.lblフリー売上本日.Text = Integer.Parse(dt.Rows(0)("売上").ToString).ToString("#,##0")
        Me.lblフリー売上人数本日.Text = dt.Rows(0)("人数").ToString
        param.Clear()

        '------【累計】再来(売上、人数)--------------------------------------------------------------------------------------------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", 1)
        param.Add("@売上区分番号", cmd_number)
        dt = d0300_logic.sale_value_coming_storedivision(param)
        Me.lbl再来売上累計.Text = Integer.Parse(dt.Rows(0)("売上").ToString).ToString("#,##0")
        Me.lbl再来売上人数累計.Text = dt.Rows(0)("人数").ToString
        param.Clear()

        '------【累計】新規(売上、人数)--------------------------------------------------------------------------------------------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", 2)
        param.Add("@売上区分番号", cmd_number)
        dt = d0300_logic.sale_value_coming_storedivision(param)
        Me.lbl新規売上累計.Text = Integer.Parse(dt.Rows(0)("売上").ToString).ToString("#,##0")
        Me.lbl新規売上人数累計.Text = dt.Rows(0)("人数").ToString
        param.Clear()

        '------【累計】フリー(売上、人数)------------------------------------------------------------------------------------------------
        param.Add("@開始日", Me.txtStartDay.Text)
        param.Add("@終了日", Me.txtEndDay.Text)
        param.Add("@来店区分番号", 3)
        param.Add("@売上区分番号", cmd_number)
        dt = d0300_logic.sale_value_coming_storedivision(param)
        Me.lblフリー売上累計.Text = Integer.Parse(dt.Rows(0)("売上").ToString).ToString("#,##0")
        Me.lblフリー売上人数累計.Text = dt.Rows(0)("人数").ToString
        param.Clear()

        '-----女性各客単価計算-------------------------------------------------------------------------------------------
        Me.lbl女性売上客単価本日.Text = (Double.Parse(int_juh.ToString) / Double.Parse(IIf(int_juhn = 0, 1, int_juhn).ToString)).ToString("#,##0") ''本日の売上客単価
        Me.lbl女性サービス客単価本日.Text = (Double.Parse(int_jsh.ToString) / Double.Parse(IIf(int_jshn = 0, 1, int_jshn).ToString)).ToString("#,##0") ''本日のサービス客単価
        Me.lbl女性売上客単価累計.Text = (Double.Parse(int_jur.ToString) / Double.Parse(IIf(int_jurn = 0, 1, int_jurn).ToString)).ToString("#,##0") ''累計の売上客単価
        Me.lbl女性サービス客単価累計.Text = (Double.Parse(int_jsr.ToString) / Double.Parse(IIf(int_jsrn = 0, 1, int_jsrn).ToString)).ToString("#,##0") ''累計のサービス客単価

        '-----男性各客単価計算-------------------------------------------------------------------------------------------
        Me.lbl男性売上客単価本日.Text = (Double.Parse(int_duh.ToString) / Double.Parse(IIf(int_duhn = 0, 1, int_duhn).ToString)).ToString("#,##0") ''本日の売上客単価
        Me.lbl男性サービス客単価本日.Text = (Double.Parse(int_dsh.ToString) / Double.Parse(IIf(int_dshn = 0, 1, int_dshn).ToString)).ToString("#,##0") ''本日のサービス客単価
        Me.lbl男性売上客単価累計.Text = (Double.Parse(int_dur.ToString) / Double.Parse(IIf(int_durn = 0, 1, int_durn).ToString)).ToString("#,##0") ''累計の売上客単価
        Me.lbl男性サービス客単価累計.Text = (Double.Parse(int_dsr.ToString) / Double.Parse(IIf(int_dsrn = 0, 1, int_dsrn).ToString)).ToString("#,##0") ''累計のサービス客単価

        '-----売上合計、サービス合計-------------------------------------------------------------------------------------------
        int_dailysale = int_juh + int_duh
        int_dailynum = int_juhn + int_duhn
        int_totalsale = int_jur + int_dur
        int_totalnum = int_jurn + int_durn

        Me.lbl売上合計本日.Text = int_dailysale.ToString("#,##0") ''本日の売上合計
        Me.lblサービス合計本日.Text = (int_jsh + int_dsh).ToString("#,##0") ''本日のサービス合計

        Me.lbl売上合計人数本日.Text = int_dailynum.ToString ''本日の売上合計人数
        Me.lblサービス合計人数本日.Text = (Integer.Parse(Me.lbl女性サービス人数本日.Text) + Integer.Parse(Me.lbl男性サービス人数本日.Text)).ToString ''本日のサービス合計人数

        Me.lbl売上合計客単価本日.Text = (Double.Parse((int_juh + int_duh).ToString) / Double.Parse(IIf(Integer.Parse(Me.lbl売上合計人数本日.Text) = 0, 1, Integer.Parse(Me.lbl売上合計人数本日.Text)).ToString)).ToString("#,##0")
        Me.lblサービス合計客単価本日.Text = (Double.Parse((int_jsh + int_dsh).ToString) / Double.Parse(IIf(Integer.Parse(Me.lblサービス合計人数本日.Text) = 0, 1, Integer.Parse(Me.lblサービス合計人数本日.Text)).ToString)).ToString("#,##0")

        Me.lbl売上合計累計.Text = int_totalsale.ToString("#,##0")
        Me.lblサービス合計累計.Text = (int_jsr + int_dsr).ToString("#,##0")

        Me.lbl売上合計人数累計.Text = int_totalnum.ToString
        Me.lblサービス合計人数累計.Text = (int_jsrn + int_dsrn).ToString

        Me.lbl売上合計客単価累計.Text = (Double.Parse((int_jur + int_dur).ToString) / Double.Parse(IIf(int_jurn + int_durn = 0, 1, int_jurn + int_durn).ToString)).ToString("#,##0")
        Me.lblサービス合計客単価累計.Text = (Double.Parse((int_jsr + int_dsr).ToString) / Double.Parse(IIf(Integer.Parse(Me.lblサービス合計人数累計.Text) = 0, 1, Integer.Parse(Me.lblサービス合計人数累計.Text)).ToString)).ToString("#,##0")

        '-----W_目標に区分別に売上累、売上人累をUPDATE--------------------------------------------------------------------------------------------------------------
        param.Add("@売上累", int_totalsale)
        param.Add("@売上人累", int_totalnum)
        param.Add("@売上区分番号", cmd_number)
        param.Add("@売上本", int_dailysale)
        param.Add("@売上人本", int_dailynum)
        update_dt = d0300_logic.update_W_目標(param)
        param.Clear()
    End Sub
#End Region

#Region "営業日情報"
    ''' <summary>
    ''' 営業日情報
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 営業日()
        Dim dt As New DataTable
        '変数
        Dim int_register_money As Integer = 0
        Dim param As New Habits.DB.DBParameter
        '-------本日----------------------------
        param.Add("@営業日", Me.txtEndDay.Text)
        dt = d0300_logic.select_business_day(param)
        If dt.Rows.Count > 0 Then
            int_register_money = Integer.Parse(IIf(dt.Rows(0)("レジ金額").Equals(System.DBNull.Value), 0, dt.Rows(0)("レジ金額")).ToString)
            param.Clear()
        End If

        '-------表示----------------------------
        Me.lblレジ金額.Text = int_register_money.ToString("#,##0")

    End Sub
#End Region

#Region "入出金情報"
    ''' <summary>
    ''' 入出金情報
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 入出金()
        Dim dt As New DataTable
        Dim insert_dt As New Integer
        '変数
        Dim int_receive_money As Integer = 0
        Dim int_invest_money As Integer = 0
        Dim int_register_money_sum As Integer = 0
        Dim param As New Habits.DB.DBParameter

        param.Add("@入出金日", Me.txtEndDay.Text)
        dt = d0300_logic.select_receive_and_invest_money(param)

        Dim intTryResult As Integer
        For Each row As Data.DataRow In dt.Rows
            If row("入出金区分番号").Equals(System.DBNull.Value) _
                OrElse row("入出金区分番号").ToString.Length = 0 _
                OrElse Integer.TryParse(row("入出金区分番号").ToString, intTryResult) = False Then
                'なにもしない
            ElseIf Integer.Parse(row("入出金区分番号")) = 1 Then
                int_receive_money = row("金額")
            ElseIf Integer.Parse(row("入出金区分番号")) = 2 Then
                int_invest_money = row("金額")
            End If

        Next
        param.Clear()

        '-------表示----------------------------
        Me.lbl本日現金2.Text = Me.lbl本日現金.Text
        Me.lbl入金.Text = int_receive_money.ToString("#,##0")
        Me.lbl出金.Text = int_invest_money.ToString("#,##0")
        Me.lblレジ合計.Text = (Integer.Parse(Replace(Me.lblレジ金額.Text, ",", "")) + Integer.Parse(Replace(Me.lbl本日現金2.Text, ",", "")) + int_receive_money - int_invest_money).ToString("#,##0")

    End Sub
#End Region

#End Region

End Class
