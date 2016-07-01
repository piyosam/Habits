'システム名 ： HABITS
'機能名　　 ： d0500_現金入出金登録
'概要　　　 ： 入出金情報の登録機能
'履歴　　　 ： 2010/05/12　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.

Imports Excel = Microsoft.Office.Interop.Excel

Public Class d0500_現金入出金登録
    Public Initial_入出金日 As Date
    Private storage_num As Integer
    Private base_logic As Habits.Logic.LogicBase
    Private a1400_logic As Habits.Logic.a1400_Logic
    Private d0500_logic As Habits.Logic.d0500_Logic
    Private dtPaymentHistory As DataTable
    Private Const PAGE_TITLE As String = "d0500_現金入出金登録"


#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub d0500_現金入出金登録_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '' ロジッククラス生成
        a1400_logic = New Habits.Logic.a1400_Logic
        d0500_logic = New Habits.Logic.d0500_Logic
        base_logic = New Habits.Logic.LogicBase

        ''画面再描画処理
        ReDisplay()

        Clear_入力項目()
        'Me.ActiveControl = Me.btn商品選択
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub d0500_現金入出金登録_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

    Private Sub 登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 登録.Click
        Dim param_ht As New Hashtable
        Dim numStr As String

        '' 入力チェック
        If Not (input_check()) Then Exit Sub

        ' E_入出金を更新
        param_ht.Add("@入出金日", Me.txt入出金日.Text)
        param_ht.Add("@入出金番号", Me.lbl入出金番号.Text)
        param_ht.Add("@入出金区分番号", storage_num)
        param_ht.Add("@金額", Me.txt入出金額.Text)
        param_ht.Add("@担当者番号", Me.dgv担当者.SelectedRows(0).Cells("担当者番号").Value)
        param_ht.Add("@摘要", Me.txt摘要.Text)
        param_ht.Add("@登録日", Now())

        d0500_logic.ReceivingAndMakingPaymentsInsert(param_ht)
        param_ht.Clear()

        numStr = Me.lbl入出金番号.Text

        ' 入出金履歴再表示
        ReDisplay_dgv入出金履歴()

        ' 追加した入出金の履歴にフォーカス移動
        SelectRow_dgv入出金履歴(Me.lbl入出金番号.Text, Initial_入出金日.ToString("yyyy/MM/dd"))
        MsgBox("登録しました。　　　　" & Chr(13), Clng_Okinb1, TTL)

        ' 入出金番号再表示
        ReDisplay_入出金番号()
        ' 入出金履歴表示
        ReDisplay_dgv入出金履歴()
        ' 項目クリア
        Clear_入力項目()

        Me.txt入出金日.Focus()
    End Sub

    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub

    Private Sub dgv入出金履歴_全商品_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgv入出金履歴.DataBindingComplete
        Me.dgv入出金履歴.ClearSelection()
    End Sub

    Private Sub txt入出金数_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt入出金額.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            'Me.dgv入出庫理由.Focus()
        End If
    End Sub

    Private Sub txt入出金数_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt入出金額.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub rb入金_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb入金.CheckedChanged
        If Me.rb入金.Checked Then
            storage_num = 1
            Me.登録.Text = "入金登録"
        End If
    End Sub

    Private Sub rb出金_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb出金.CheckedChanged
        If Me.rb出金.Checked Then
            storage_num = 2
            Me.登録.Text = "出金登録"
        End If
    End Sub

    Private Sub txt入出金日_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt入出金日.Validated
        Dim SJIS As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim errMsg As String = Nothing
        If Not Sys_InputCheck_Date(Me.txt入出金日.Text, errMsg) Then
            Call Sys_Error("入出金日 " & errMsg, Me.txt入出金日)
            Me.txt入出金日.Text = Nothing
            Exit Sub
        Else
            ReDisplay_入出金番号()
            RemoveHandler txt入出金日.Validated, AddressOf txt入出金日_Validated
            Me.txt入出金額.Focus()
            AddHandler txt入出金日.Validated, AddressOf txt入出金日_Validated
        End If
        Try
            Me.txt入出金日.Text = Format(DateTime.Parse(Me.txt入出金日.Text), "yyyy/M/d")
        Catch ex As Exception
            Call Sys_Error("入出金日が不正です。　", Me.txt入出金日)
            Me.txt入出金日.Text = Nothing
            Exit Sub
        End Try
    End Sub

    Private Sub btn項目クリア_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn項目クリア.Click
        Call Sys_ClearTextBox(Me)

        Call ReDisplay()

        Me.dgv担当者.ClearSelection()

    End Sub

#End Region

#Region "メソッド"

    ''' <summary>データチェック</summary>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        Dim str As String
        Dim param As New Habits.DB.DBParameter

        input_check = False

        Me.lbl入出金番号.Text = Trim(Me.lbl入出金番号.Text)
        str = Me.lbl入出金番号.Text
        If (Sys_InputCheck(str, 4, "N+", 0)) Then
            Call Sys_Error("入出金番号 が不正です。　", Me.lbl入出金番号)
            Exit Function
        End If

        Me.txt入出金額.Text = Trim(Me.txt入出金額.Text)
        str = Me.txt入出金額.Text
        If (Sys_InputCheck(str, 9, "N+", 1)) OrElse Integer.Parse(Me.txt入出金額.Text) = 0 Then
            Call Sys_Error("入出金数 は1～999,999,999の半角数字で入力してください。　", Me.txt入出金額)
            Exit Function
        End If

        If Me.dgv担当者.SelectedRows.Count = 0 Then
            Call Sys_Error("担当者 を選択してください。　", Me.dgv担当者)
            Me.dgv担当者.ClearSelection()
            Exit Function
        End If

        Me.txt摘要.Text = Trim(Me.txt摘要.Text)
        str = Me.txt摘要.Text
        If (Sys_InputCheck(str, 64, "M", 0)) Then
            Call Sys_Error("摘要 は64文字以内で入力してください。　", Me.txt摘要)
            Exit Function
        End If

        '入出金番号の重複チェック
        param.Clear()
        param.Add("@入出金日", Me.txt入出金日.Text)
        param.Add("@入出金番号", Me.lbl入出金番号.Text)
        If d0500_logic.IsExistPaymentsNumber(param) Then
            Call Sys_Error("入出金番号が登録済です。　", Me.lbl入出金番号)
            Exit Function
        End If

        input_check = True

    End Function

    ''' <summary>画面再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay()
        '入出金日表示
        ReDisplay_入出金日()

        '入出金番号表示
        ReDisplay_入出金番号()

        '担当者表示
        ReDisplay_dgv担当者()

        '検索期間初期値表示
        ReDisplay_検索入出金日()

        '入出金履歴表示
        ReDisplay_dgv入出金履歴()

        Me.rb入金.Checked = True
    End Sub

    ''' <summary>入出金日再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_入出金日()
        '初期値（営業日）を表示
        Me.txt入出金日.Text = USER_DATE.ToString("yyyy/MM/dd")
    End Sub

    ''' <summary>入出金日再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_検索入出金日()
        '初期値（1か月前～現在日）を表示
        Me.txt検索開始日.Text = USER_DATE.AddMonths(-1).ToString("yyyy/MM/dd")
        Me.txt検索終了日.Text = USER_DATE.ToString("yyyy/MM/dd")
    End Sub

    ''' <summary>
    ''' 担当者コンボボックス再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_dgv担当者()
        Dim dt As DataTable

        '担当者一覧取得
        dt = a1400_logic.GetStaff()

        '担当者表示
        Me.dgv担当者.DataSource = dt

        Me.dgv担当者.Columns("担当者番号").Visible = False

        Me.dgv担当者.Columns("担当者名").Width = 187
        Me.dgv担当者.Columns("担当者名").Visible = True
        Me.dgv担当者.Columns("担当者名").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft

        Me.dgv担当者.Enabled = True
        Me.dgv担当者.ClearSelection()
    End Sub

    ''' <summary>
    ''' dgv入出金履歴再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_dgv入出金履歴()
        Dim param As New Habits.DB.DBParameter
        Dim tmpDate As Date

        '入出金履歴_全商品取得

        tmpDate = USER_DATE
        param.Add("@検索開始日", DateTime.Parse(Me.txt検索開始日.Text))
        param.Add("@検索終了日", DateTime.Parse(Me.txt検索終了日.Text))
        dtPaymentHistory = d0500_logic.GetSelectedPaymentsHistory(param)

        Dim intTotalRecieve As Integer = 0
        Dim intTotalPayment As Integer = 0

        For Each row As Data.DataRow In dtPaymentHistory.Rows
            If Not row.Item("入金").Equals(System.DBNull.Value) Then
                intTotalRecieve += Integer.Parse(row.Item("入金").ToString())
            End If
            If Not row.Item("出金").Equals(System.DBNull.Value) Then
                intTotalPayment += Integer.Parse(row.Item("出金").ToString())
            End If
        Next

        '合計行を追加する
        If dtPaymentHistory.Rows.Count > 0 Then
            dtPaymentHistory.Rows.Add(New Object() {System.DBNull.Value, "合計", System.DBNull.Value, intTotalRecieve, intTotalPayment, (intTotalRecieve - intTotalPayment).ToString("#,##0"), System.DBNull.Value})
        End If

        'dgv入出金履歴_全商品表示
        Me.dgv入出金履歴.DataSource = dtPaymentHistory

        Me.dgv入出金履歴.Columns("入出金日").Width = 90
        Me.dgv入出金履歴.Columns("入出金日").Visible = True
        Me.dgv入出金履歴.Columns("入出金日").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight

        Me.dgv入出金履歴.Columns("番号").Width = 60
        Me.dgv入出金履歴.Columns("番号").Visible = True
        Me.dgv入出金履歴.Columns("番号").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight

        Me.dgv入出金履歴.Columns("入出金区分番号").Visible = False

        Me.dgv入出金履歴.Columns("入金").Width = 90
        Me.dgv入出金履歴.Columns("入金").Visible = True
        Me.dgv入出金履歴.Columns("入金").DefaultCellStyle.Format = "#,##0"
        Me.dgv入出金履歴.Columns("入金").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv入出金履歴.Columns("出金").Width = 90
        Me.dgv入出金履歴.Columns("出金").Visible = True
        Me.dgv入出金履歴.Columns("出金").DefaultCellStyle.Format = "#,##0"
        Me.dgv入出金履歴.Columns("出金").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight

        Me.dgv入出金履歴.Columns("担当者名").Width = 90
        Me.dgv入出金履歴.Columns("担当者名").Visible = True
        Me.dgv入出金履歴.Columns("担当者名").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight

        Me.dgv入出金履歴.Columns("摘要").Visible = True
        Me.dgv入出金履歴.Columns("摘要").MinimumWidth = 259
        Me.dgv入出金履歴.Columns("摘要").AutoSizeMode = Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells

        '合計行についてスタイルを設定する
        If dtPaymentHistory.Rows.Count > 0 Then
            'Me.dgv入出金履歴.Rows(Me.dgv入出金履歴.Rows.Count - 1).Frozen = True
            Me.dgv入出金履歴.Rows(Me.dgv入出金履歴.Rows.Count - 1).DefaultCellStyle.BackColor = Color.MidnightBlue
            Me.dgv入出金履歴.Rows(Me.dgv入出金履歴.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.White
            'Me.dgv入出金履歴.Rows(Me.dgv入出金履歴.Rows.Count - 1).DefaultCellStyle.Font = New Font(DefaultFont, FontStyle.Bold)
        End If

        Me.dgv入出金履歴.SelectAll()
        Me.dgv入出金履歴.ClearSelection()
    End Sub

    ''' <summary>
    ''' 入出金番号再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_入出金番号()
        If Sys_InputCheck(Me.txt入出金日.Text, 10, "D", 0) Then
            Call Sys_Error("入出金日 はYYYY/MM/DD形式で入力してください。　", Me.txt入出金日)
            Exit Sub
        End If
        Dim str As String
        str = Me.txt入出金日.Text
        Me.lbl入出金番号.Text = d0500_logic.E_次入出金番号取得(str)
    End Sub

    ''' <summary>
    ''' dgv入出金履歴の行選択
    ''' </summary>
    ''' <param name="v_number">入出金番号</param>
    ''' <param name="v_date">入出金日</param>
    ''' <remarks></remarks>
    Protected Friend Sub SelectRow_dgv入出金履歴(ByVal v_number As String, ByVal v_date As String)
        Dim tmp_str As String = Nothing
        Dim tmp_date As Date

        For i As Integer = 0 To Me.dgv入出金履歴.Rows.Count - 1
            If Not Me.dgv入出金履歴.Rows(i).Cells("番号").Value.Equals(System.DBNull.Value) Then
                tmp_str = Me.dgv入出金履歴.Rows(i).Cells("番号").Value
            End If
            If Not Me.dgv入出金履歴.Rows(i).Cells("入出金日").Value.Equals(System.DBNull.Value) Then
                tmp_date = Me.dgv入出金履歴.Rows(i).Cells("入出金日").Value
            End If
            If String.Equals(tmp_str, v_number) _
               And String.Equals(v_date, tmp_date.ToString("yyyy/MM/dd")) Then
                Me.dgv入出金履歴.Rows(i).Selected = True
                Me.dgv入出金履歴.Focus()
                Me.dgv入出金履歴.CurrentCell = dgv入出金履歴.Rows(i).Cells("番号")
                Exit For
            End If
        Next
    End Sub

    ''' <summary>
    ''' 入力項目クリア処理
    '''</summary>
    ''' <remarks></remarks>
    Protected Friend Sub Clear_入力項目()
        Me.txt入出金額.Text = Nothing
        Me.dgv入出金履歴.ClearSelection()
        Me.dgv担当者.ClearSelection()
        Me.txt摘要.Text = Nothing
    End Sub

    '''' <summary>
    '''' 入出金履歴検索処理
    ''''</summary>
    '''' <remarks></remarks>
    Private Sub btn検索_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn検索.Click
        Dim errMsg As String = Nothing
        If Not Sys_InputCheck_Date(Me.txt検索開始日.Text, errMsg) Then
            Call Sys_Error("入出金履歴検索日 " & errMsg, Me.txt検索開始日)
            Me.txt検索開始日.Text = Nothing
            Exit Sub
        End If
        If Not Sys_InputCheck_Date(Me.txt検索終了日.Text, errMsg) Then
            Call Sys_Error("入出金履歴検索日 " & errMsg, Me.txt検索終了日)
            Me.txt検索終了日.Text = Nothing
            Exit Sub
        End If

        ReDisplay_dgv入出金履歴()

    End Sub

    '''' <summary>
    '''' 入出金履歴削除処理
    ''''</summary>
    '''' <remarks></remarks>
    Private Sub btn入出金履歴削除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn入出金履歴削除.Click

        Dim param As New Habits.DB.DBParameter

        If dgv入出金履歴.SelectedRows.Count < 1 Then
            MsgBox("削除する行を選択してください。", MsgBoxStyle.OkOnly, TTL)
            Exit Sub ' 削除をキャンセル
        End If

        If Me.dgv入出金履歴.Rows(Me.dgv入出金履歴.Rows.Count - 1).Selected = True Then
            MsgBox("合計行は削除できません。", MsgBoxStyle.OkOnly, TTL)
            Exit Sub ' 削除をキャンセル
        End If

        If MsgBox("選択した行を削除しますか？", MsgBoxStyle.YesNo, TTL) = System.Windows.Forms.DialogResult.No Then
            Exit Sub ' 削除をキャンセル
        End If

        '選択された行を削除する
        param.Clear()
        param.Add("@入出金日", dgv入出金履歴.CurrentRow.Cells("入出金日").Value.ToString)
        param.Add("@入出金番号", dgv入出金履歴.CurrentRow.Cells("番号").Value.ToString)

        d0500_logic.DeletePaymentsHistory(param)
        ReDisplay_dgv入出金履歴()

    End Sub

    '''' <summary>
    '''' 入出金履歴Excel出力
    ''''</summary>
    '''' <remarks></remarks>
    Private Sub btnExcel出力_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel出力.Click
        Dim sfd As New Windows.Forms.SaveFileDialog()
        Dim update_dt As New Integer
        Dim param As New Habits.DB.DBParameter
        sfd.FileName = "入出金データ"
        sfd.InitialDirectory = base_logic.getPath(2)
        sfd.Filter = _
               "Microsoft Offics Excel ブック(*.xls)|*.xls"
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
                "ファイルを閉じて下さい。", Me.btnExcel出力)
                Exit Sub
            End If
        Next
        '--------------------------------------------------------------------------------------------------
        Cursor.Current = Windows.Forms.Cursors.WaitCursor

        If Replace(sfd.FileName, FileUtil.GetFilename(sfd.FileName), "").Length > 128 Then
            Call Sys_Error("ファイルの出力に失敗しました。　" & Chr(13) & Chr(13) & _
                           "指定先ディレクトリのパスの文字数が、128以内であることを確認してください。　", Me.btnExcel出力)
            Exit Sub
        End If
        excel_output_order(sfd.FileName)
        Cursor.Current = Windows.Forms.Cursors.Default

        param.Add("@出力パス名", Replace(sfd.FileName, FileUtil.GetFilename(sfd.FileName), ""))
        param.Add("@変更日時", Now)

        update_dt = base_logic.update_Path(2, param, PAGE_TITLE)
    End Sub

    '''' <summary>
    '''' Excel出力
    ''''</summary>
    '''' <remarks></remarks>
    Private Sub excel_output_order(ByVal str_fullpath As String)
        Dim param As New Habits.DB.DBParameter
        param.Add("@検索開始日", Me.txt検索開始日.Text.Replace("/", ""))
        param.Add("@検索終了日", Me.txt検索終了日.Text.Replace("/", ""))

        Dim xlapp As New Excel.Application
        Dim xlbooks As Excel.Workbooks = xlapp.Workbooks
        Dim xlbook As Excel.Workbook = xlbooks.Add
        Dim xlsheets As Excel.Sheets = xlbook.Worksheets
        Dim xlsheet As Excel.Worksheet = DirectCast(xlsheets.Item(1), Excel.Worksheet)
        Dim xlrange As Excel.Range

        xlrange = xlsheet.Range("1:6")
        xlsheet.Name = "入出金データ"
        Dim i As Integer = 1
        Dim shopName As String

        ' 店舗名取得
        shopName = base_logic.GetShopName()

        xlrange(1, 1) = "店名：" & shopName

        xlrange(3, 1) = "入出金日"
        xlrange(3, 2) = "番号"
        xlrange(3, 3) = "入金"
        xlrange(3, 4) = "出金"
        xlrange(3, 5) = "担当者名"
        xlrange(3, 6) = "摘要"

        xlsheet.Columns("C").NumberFormatLocal = "#,##0"
        xlsheet.Columns("D").NumberFormatLocal = "#,##0"

        Try
            Do Until i = dtPaymentHistory.Rows.Count + 1
                xlrange(i + 3, 1) = dtPaymentHistory.Rows(i - 1)("入出金日")
                xlrange(i + 3, 2) = dtPaymentHistory.Rows(i - 1)("番号")
                xlrange(i + 3, 3) = dtPaymentHistory.Rows(i - 1)("入金")
                xlrange(i + 3, 4) = dtPaymentHistory.Rows(i - 1)("出金")
                xlrange(i + 3, 5) = dtPaymentHistory.Rows(i - 1)("担当者名")
                xlrange(i + 3, 6) = dtPaymentHistory.Rows(i - 1)("摘要")
                i = i + 1
            Loop

        Catch ex As Exception
            MsgBox(ex.ToString, Clng_Okexb1, TTL)

        Finally
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
