'システム名 ： HABITS
'機能名　　 ： a1400_入出庫登録
'概要　　　 ： 入出庫情報の登録機能
'履歴　　　 ： 2010/05/12　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a1400_入出庫登録
    Public Initial_入出庫日 As Date
    Public Initial_売上区分番号 As String
    Public Initial_売上区分 As String
    Public Initial_分類番号 As String
    Public Initial_分類名 As String
    Public Initial_メーカー番号 As String
    Public Initial_メーカー名 As String
    Public Initial_商品番号 As String
    Public Initial_商品名 As String
    Private storage_num As Integer
    Private logic As Habits.Logic.a1400_Logic
    Private c0400_logic As Habits.Logic.c0400_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1400_入出庫登録_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Initial_売上区分番号 = vbNullString
        Initial_売上区分 = vbNullString
        Initial_分類番号 = vbNullString
        Initial_分類名 = vbNullString
        Initial_メーカー番号 = vbNullString
        Initial_メーカー名 = vbNullString
        Initial_商品番号 = vbNullString
        Initial_商品名 = vbNullString
        '' ロジッククラス生成
        logic = New Habits.Logic.a1400_Logic
        c0400_logic = New Habits.Logic.c0400_Logic

        ''画面再描画処理
        ReDisplay()

        Clear_入力項目()
        Me.ActiveControl = Me.btn商品選択
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1400_入出庫登録_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

    Private Sub dgv入出庫区分_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReDisplay_dgv入出庫理由()
    End Sub

    Private Sub 登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 登録.Click
        Dim param_ht As New Hashtable
        Dim numStr As String

        '' 入力チェック
        If Not (input_check()) Then Exit Sub

        '' E_入出庫、C_商品（在庫数）を更新
        param_ht.Add("@入出庫日", Me.txt入出庫日.Text)
        param_ht.Add("@入出庫番号", Me.lbl入出庫番号.Text)
        param_ht.Add("@入出庫区分番号", storage_num)
        param_ht.Add("@入出庫理由番号", Me.dgv入出庫理由.SelectedRows(0).Cells("入出庫理由番号").Value)
        param_ht.Add("@売上区分番号", Initial_売上区分番号)
        param_ht.Add("@分類番号", Initial_分類番号)
        param_ht.Add("@商品番号", Initial_商品番号)
        param_ht.Add("@入出庫数", Me.txt入出庫数.Text)
        param_ht.Add("@受入金額", "0")
        param_ht.Add("@担当者番号", Me.dgv担当者.SelectedRows(0).Cells("担当者番号").Value)
        param_ht.Add("@コメント", Me.txtコメント.Text)
        param_ht.Add("@登録日", Now())

        logic.StockInsert(param_ht)
        param_ht.Clear()

        numStr = Me.lbl入出庫番号.Text

        '' 入出庫履歴再表示
        ReDisplay_dgv入出庫履歴()

        '' 追加した入出庫の履歴にフォーカス移動
        SelectRow_dgv入出庫履歴(Me.lbl入出庫番号.Text, Initial_入出庫日.ToString("yyyy/MM/dd"))
        MsgBox("登録しました。　　　　" & Chr(13), Clng_Okinb1, TTL)

        '' 在庫数再表示
        ReDisplay_在庫数()

        '' 入出庫番号再表示
        ReDisplay_入出庫番号()

        '' 項目クリア
        Clear_入力項目()

        Me.txt入出庫日.Focus()
        Me.btn商品選択.Focus()
    End Sub

    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub

    Private Sub dgv入出庫履歴_全商品_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgv入出庫履歴.DataBindingComplete
        Me.dgv入出庫履歴.ClearSelection()
    End Sub

    Private Sub txt入出庫数_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt入出庫数.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.dgv入出庫理由.Focus()
        End If
    End Sub

    Private Sub txt入出庫数_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt入出庫数.KeyPress
        Sys_KeyPressNumeric(e)
    End Sub

    Private Sub rb入庫_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb入庫.CheckedChanged
        If Me.rb入庫.Checked Then
            storage_num = 1
            Me.dgv入出庫理由.DataSource = logic.GetStockReason(storage_num)
            Me.dgv入出庫理由.Columns("入出庫理由番号").Visible = False
            Me.dgv入出庫理由.Columns("入出庫理由").Width = 137
            Me.dgv入出庫理由.Columns("入出庫理由").Visible = True
            Me.dgv入出庫理由.Columns("入出庫理由").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft
            Me.dgv入出庫理由.Columns("コメントチェック").Visible = False

            Me.dgv入出庫理由.Enabled = True
            Me.dgv入出庫理由.ClearSelection()
            Me.登録.Text = "入庫登録"
        End If
    End Sub

    Private Sub rb出庫_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb出庫.CheckedChanged
        If Me.rb出庫.Checked Then
            storage_num = 2
            Me.dgv入出庫理由.DataSource = logic.GetStockReason(storage_num)
            Me.dgv入出庫理由.Columns("入出庫理由番号").Visible = False
            Me.dgv入出庫理由.Columns("入出庫理由").Width = 137
            Me.dgv入出庫理由.Columns("入出庫理由").Visible = True
            Me.dgv入出庫理由.Columns("入出庫理由").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft
            Me.dgv入出庫理由.Columns("コメントチェック").Visible = False

            Me.dgv入出庫理由.Enabled = True
            Me.dgv入出庫理由.ClearSelection()
            Me.登録.Text = "出庫登録"
        End If
    End Sub

    Private Sub btn商品選択_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn商品選択.Click
        If Sys_InputCheck(Me.txt入出庫日.Text, 10, "D", 0) Then
            Sys_Error("入出庫日 はYYYY/MM/DD形式で入力してください。　", Me.txt入出庫日)
            Exit Sub
        End If
        a1400_入出庫.ShowDialog()
        If Me.Initial_商品番号 <> Nothing Then
            ReDisplay_商品情報()
            ReDisplay_dgv入出庫履歴()
            Me.txt入出庫日.Focus()
        End If
    End Sub

    Private Sub txt入出庫日_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt入出庫日.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.btn商品選択.Focus()
        End If
    End Sub

    Private Sub txt入出庫日_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt入出庫日.Validated
        Dim SJIS As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim errMsg As String = Nothing
        If Not Sys_InputCheck_Date(Me.txt入出庫日.Text, errMsg) Then
            Sys_Error("入出庫日 " & errMsg, Me.txt入出庫日)
            Me.txt入出庫日.Text = Nothing
            Exit Sub
        Else
            ReDisplay_入出庫番号()
            RemoveHandler txt入出庫日.Validated, AddressOf txt入出庫日_Validated
            Me.txt入出庫数.Focus()
            AddHandler txt入出庫日.Validated, AddressOf txt入出庫日_Validated
        End If
        Try
            Me.txt入出庫日.Text = Format(DateTime.Parse(Me.txt入出庫日.Text), "yyyy/M/d")
        Catch ex As Exception
            Sys_Error("入出庫日が不正です。　", Me.txt入出庫日)
            Me.txt入出庫日.Text = Nothing
            Exit Sub
        End Try
    End Sub

    Private Sub btn項目クリア_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn項目クリア.Click
        Sys_ClearTextBox(Me)
        Clear_商品情報()
        ReDisplay()
        Me.dgv入出庫理由.ClearSelection()
        Me.dgv担当者.ClearSelection()
        Me.dgv入出庫履歴.DataSource = Nothing
        Me.btn商品選択.Focus()
        Me.Initial_メーカー番号 = Nothing
        Me.Initial_商品番号 = Nothing
        Me.Initial_売上区分番号 = Nothing
    End Sub

#End Region

#Region "メソッド"

    ''' <summary>データチェック</summary>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        Dim dt As DataTable
        Dim str As String
        Dim param As New Habits.DB.DBParameter
        Dim stock As Integer

        input_check = False

        Me.lbl入出庫番号.Text = Trim(Me.lbl入出庫番号.Text)
        str = Me.lbl入出庫番号.Text
        If (Sys_InputCheck(str, 4, "N+", 0)) Then
            Sys_Error("入出庫番号 が不正です。　", Me.lbl入出庫番号)
            Exit Function
        End If

        Me.txt入出庫数.Text = Trim(Me.txt入出庫数.Text)
        str = Me.txt入出庫数.Text
        If (Sys_InputCheck(str, 9, "N+", 1)) OrElse Integer.Parse(Me.txt入出庫数.Text) = 0 Then
            Sys_Error("入出庫数 は1～999,999,999の半角数字で入力してください。　", Me.txt入出庫数)
            Exit Function
        End If

        If Initial_売上区分番号 = "" OrElse Initial_分類番号 = "" OrElse Initial_商品番号 = "" Then
            Sys_Error("商品 を選択してください。　", Me.btn商品選択)
            Exit Function
        End If

        Try
            If storage_num = 1 Then
                stock = Integer.Parse(Replace(lbl在庫数.Text, ",", "")) + Integer.Parse(txt入出庫数.Text)
            Else
                stock = Integer.Parse(Replace(lbl在庫数.Text, ",", "")) - Integer.Parse(txt入出庫数.Text)
            End If
        Catch ex As OverflowException
            Sys_Error("在庫数が-2,147,483,648～2,147,483,647を超える" & Chr(13) & Chr(13) & _
                           " 入出庫数 は登録できません。　", Me.txt入出庫数)
            Exit Function
        End Try

        If Me.dgv入出庫理由.SelectedRows.Count = 0 Then
            Sys_Error("入出庫理由 を選択してください。　", Me.dgv入出庫理由)
            Me.dgv入出庫理由.ClearSelection()
            Exit Function
        End If

        If Me.dgv担当者.SelectedRows.Count = 0 Then
            Sys_Error("担当者 を選択してください。　", Me.dgv担当者)
            Me.dgv担当者.ClearSelection()
            Exit Function
        End If

        Me.txtコメント.Text = Trim(Me.txtコメント.Text)
        str = Me.txtコメント.Text
        If (Sys_InputCheck(str, 64, "M", 0)) Then
            Sys_Error("コメント は64文字以内で入力してください。　", Me.txtコメント)
            Exit Function
        End If

        dt = Me.dgv入出庫理由.DataSource
        str = dt.Rows(Me.dgv入出庫理由.SelectedRows(0).Index).Item("コメントチェック").ToString
        If String.Equals(str, "True") Then
            If String.IsNullOrEmpty(Me.txtコメント.Text.Replace(vbCrLf, "")) Then
                Sys_Error("入出庫理由が " & Me.dgv入出庫理由.SelectedRows(0).Cells("入出庫理由").Value.ToString & _
                                " の場合はコメントを入力してください。　", Me.txtコメント)
                Exit Function
            End If
        End If

        '入出庫番号の重複チェック
        param.Clear()
        param.Add("@入出庫日", Me.txt入出庫日.Text)
        param.Add("@入出庫番号", Me.lbl入出庫番号.Text)
        If logic.IsExistStockNumber(param) Then
            Sys_Error("入出庫番号が登録済です。　", Me.lbl入出庫番号)
            Exit Function
        End If

        input_check = True

    End Function

    ''' <summary>画面再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay()
        '入出庫日表示
        ReDisplay_入出庫日()

        '担当者表示
        ReDisplay_dgv担当者()

        Me.rb入庫.Checked = True
    End Sub

    ''' <summary>入出庫日再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_入出庫日()
        '初期値（営業日）を表示
        Me.txt入出庫日.Text = USER_DATE.ToString("yyyy/MM/dd")
    End Sub

    ''' <summary>商品情報再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_商品情報()
        '売上区分を表示
        Me.lbl売上区分.Text = Initial_売上区分

        '分類名を表示
        Me.lbl分類名.Text = Initial_分類名

        'メーカー名を表示
        Me.lblメーカー名.Text = Initial_メーカー名

        '商品名を表示
        Me.lbl商品名.Text = Initial_商品名

        '在庫数を表示
        ReDisplay_在庫数()

        Me.lbl売上区分.BackColor = Color.White
        Me.lbl分類名.BackColor = Color.White
        Me.lblメーカー名.BackColor = Color.White
        Me.lbl商品名.BackColor = Color.White
        Me.lbl在庫数.BackColor = Color.White
    End Sub

    ''' <summary>
    ''' 在庫数再表示処理
    '''</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_在庫数()
        Dim dt As DataTable
        Dim param As New Habits.DB.DBParameter

        param.Clear()
        param.Add("@売上区分番号", Initial_売上区分番号)
        param.Add("@分類番号", Initial_分類番号)
        param.Add("@商品番号", Initial_商品番号)
        dt = logic.C_商品在庫数取得(param)
        Me.lbl在庫数.Text = Format(Long.Parse(dt.Rows(0).Item("在庫数").ToString), "#,##0")
    End Sub

    ''' <summary>
    ''' 入出庫理由再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_dgv入出庫理由()
        Dim dt As DataTable

        '入出庫理由一覧取得
        dt = logic.GetStockReason(storage_num)

        '入出庫理由表示
        Me.dgv入出庫理由.DataSource = dt

        Me.dgv入出庫理由.Columns("入出庫理由番号").Visible = False

        Me.dgv入出庫理由.Columns("入出庫理由").Width = 153
        Me.dgv入出庫理由.Columns("入出庫理由").Visible = True
        Me.dgv入出庫理由.Columns("入出庫理由").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft

        Me.dgv入出庫理由.Columns("コメントチェック").Visible = False

        Me.dgv入出庫理由.Enabled = True
        Me.dgv入出庫理由.ClearSelection()
        Me.dgv入出庫理由.Focus()
    End Sub

    ''' <summary>
    ''' 担当者コンボボックス再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_dgv担当者()
        Dim dt As DataTable

        '担当者一覧取得
        dt = logic.GetStaff()

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
    ''' dgv入出庫履歴再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_dgv入出庫履歴()
        Dim dt As DataTable
        Dim param As New Habits.DB.DBParameter
        Dim tmpDate As Date

        '入出庫履歴_全商品取得

        tmpDate = USER_DATE
        param.Add("@入出庫年月", tmpDate.ToString("yyyyMM"))
        param.Add("@売上区分番号", Initial_売上区分番号)
        param.Add("@分類番号", Initial_分類番号)
        param.Add("@商品番号", Initial_商品番号)
        dt = logic.GetSelectedStockHistory(param)

        'dgv入出庫履歴_全商品表示
        Me.dgv入出庫履歴.DataSource = dt

        Me.dgv入出庫履歴.Columns("入出庫日").Width = 90
        Me.dgv入出庫履歴.Columns("入出庫日").Visible = True
        Me.dgv入出庫履歴.Columns("入出庫日").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight

        Me.dgv入出庫履歴.Columns("番号").Visible = False
        Me.dgv入出庫履歴.Columns("入出庫区分番号").Visible = False

        Me.dgv入出庫履歴.Columns("区分").Width = 60
        Me.dgv入出庫履歴.Columns("区分").Visible = True

        Me.dgv入出庫履歴.Columns("入出庫理由番号").Visible = False

        Me.dgv入出庫履歴.Columns("理由").Width = 60
        Me.dgv入出庫履歴.Columns("理由").Visible = True

        Me.dgv入出庫履歴.Columns("売上区分番号").Visible = False
        Me.dgv入出庫履歴.Columns("売上区分").Visible = False
        Me.dgv入出庫履歴.Columns("分類番号").Visible = False
        Me.dgv入出庫履歴.Columns("分類名").Visible = False
        Me.dgv入出庫履歴.Columns("商品番号").Visible = False
        Me.dgv入出庫履歴.Columns("商品名").Visible = False
        Me.dgv入出庫履歴.Columns("メーカー名").Visible = False

        Me.dgv入出庫履歴.Columns("数量").Width = 70
        Me.dgv入出庫履歴.Columns("数量").Visible = True
        Me.dgv入出庫履歴.Columns("数量").DefaultCellStyle.Format = "#,##0"
        Me.dgv入出庫履歴.Columns("数量").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight

        Me.dgv入出庫履歴.Columns("受入金額").Visible = False
        Me.dgv入出庫履歴.Columns("担当者番号").Visible = False

        Me.dgv入出庫履歴.Columns("スタッフ名").Width = 95
        Me.dgv入出庫履歴.Columns("スタッフ名").Visible = True

        Me.dgv入出庫履歴.Columns("コメント").Width = 288
        Me.dgv入出庫履歴.Columns("コメント").Visible = True

        Me.dgv入出庫履歴.Columns("登録日").Visible = False

        Me.dgv入出庫履歴.SelectAll()
        Me.dgv入出庫履歴.ClearSelection()
    End Sub

    ''' <summary>
    ''' 入出庫番号再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_入出庫番号()
        If Sys_InputCheck(Me.txt入出庫日.Text, 10, "D", 0) Then
            Sys_Error("入出庫日 はYYYY/MM/DD形式で入力してください。　", Me.txt入出庫日)
            Exit Sub
        End If
        Dim str As String
        str = Me.txt入出庫日.Text
        Me.lbl入出庫番号.Text = c0400_logic.E_次入出庫番号取得(str)
    End Sub

    ''' <summary>
    ''' dgv入出庫履歴の行選択
    ''' </summary>
    ''' <param name="v_number">入出庫番号</param>
    ''' <param name="v_date">入出庫日</param>
    ''' <remarks></remarks>
    Protected Friend Sub SelectRow_dgv入出庫履歴(ByVal v_number As String, ByVal v_date As String)
        Dim tmp_str As String
        Dim tmp_date As Date

        For i As Integer = 0 To Me.dgv入出庫履歴.Rows.Count - 1
            tmp_str = Me.dgv入出庫履歴.Rows(i).Cells("番号").Value
            tmp_date = Me.dgv入出庫履歴.Rows(i).Cells("入出庫日").Value
            If String.Equals(tmp_str, v_number) _
               And String.Equals(v_date, tmp_date.ToString("yyyy/MM/dd")) Then
                Me.dgv入出庫履歴.Rows(i).Selected = True
                Me.dgv入出庫履歴.Focus()
                Me.dgv入出庫履歴.CurrentCell = dgv入出庫履歴.Rows(i).Cells("番号")
                Exit For
            End If
        Next
    End Sub

    ''' <summary>
    ''' 入力項目クリア処理
    '''</summary>
    ''' <remarks></remarks>
    Protected Friend Sub Clear_入力項目()
        Me.txt入出庫数.Text = Nothing
        Me.dgv入出庫理由.ClearSelection()
        Me.dgv入出庫履歴.ClearSelection()
        Me.dgv担当者.ClearSelection()
        Me.txtコメント.Text = Nothing
    End Sub

    ''' <summary>
    ''' 商品情報クリア処理
    '''</summary>
    ''' <remarks></remarks>
    Protected Friend Sub Clear_商品情報()
        Me.lbl入出庫番号.Text = Nothing
        Me.lbl売上区分.Text = Nothing
        Me.lbl分類名.Text = Nothing
        Me.lblメーカー名.Text = Nothing
        Me.lbl商品名.Text = Nothing
        Me.lbl在庫数.Text = Nothing

        Me.lbl売上区分.BackColor = SystemColors.Control
        Me.lbl分類名.BackColor = SystemColors.Control
        Me.lblメーカー名.BackColor = SystemColors.Control
        Me.lbl商品名.BackColor = SystemColors.Control
        Me.lbl在庫数.BackColor = SystemColors.Control
    End Sub
#End Region

End Class