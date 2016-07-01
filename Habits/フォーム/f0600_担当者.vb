''' <summary>f0600_スタッフ画面処理</summary>
''' <remarks></remarks>
Public Class f0600_スタッフ
    Private logic As New Habits.Logic.f0600_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0600_スタッフ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        logic = New Habits.Logic.f0600_Logic
        Me.全件表示.Checked = False
        Me.新規.Enabled = True
        Me.登録.Enabled = False
        'スタッフ一覧表示
        ReDisp()

        Me.新規.Focus()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0600_スタッフ_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim dt As DataTable
        dt = logic.select_d_stuff
        If dt.Rows.Count = 0 Then
            Call Sys_Error("スタッフが1件も登録されていません。　", Me.新規)
            Exit Sub
        End If
        Me.Dispose()
    End Sub
#End Region

#Region "新規ボタン押下"
    ''' <summary>
    ''' 新規ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 新規_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新規.Click
        Dim dt As New DataTable
        Dim max_staffno As Integer

        dt = logic.担当者_最大番号取得()
        max_staffno = Integer.Parse(dt.Rows(0)("最大番号").ToString)
        If (max_staffno >= Max_MasterNo) Then
            Call Sys_Error("登録最大数に達したため登録できません。　", Me.閉じる)
            Exit Sub
        End If

        Me.担当者一覧.ClearSelection()
        Clear_入力項目()
        SetEnable_入力項目(True)

        Me.担当者名.Focus()
        Me.登録.Enabled = True
        Me.登録.Text = BTN_REGIST

        Me.lbl担当者番号.Text = (max_staffno + 1).ToString
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
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Dim dt As DataTable
        dt = logic.select_d_stuff
        If dt.Rows.Count = 0 Then
            Call Sys_Error("スタッフが1件も登録されていません。　", Me.新規)
            Exit Sub
        End If
        Me.Close()
    End Sub
#End Region

#Region "項目クリアボタン押下"
    ''' <summary>
    ''' 項目クリアボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 項目クリア_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 項目クリア.Click
        Me.担当者一覧.ClearSelection()
        Clear_入力項目()
        lbl担当者番号.Text = Nothing
        Me.登録.Text = "変更"
        SetEnable_入力項目(False)
    End Sub
#End Region

#Region "登録ボタン押下"
    ''' <summary>
    ''' 登録ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 登録.Click
        Dim dt As New Integer
        Dim param As New Habits.DB.DBParameter
        Dim deleteDt As DataTable
        Dim deleteCnt As Integer

        If Me.登録.Text = "登録" Then

            If Not input_check(True) Then Exit Sub
            param.Add("@担当者番号", Me.lbl担当者番号.Text)
            param.Add("@担当者名", Me.担当者名.Text)
            param.Add("@表示順", Me.表示順.Text)
            If Me.削除フラグ.Checked = True Then
                param.Add("@削除フラグ", 1)
            ElseIf Me.削除フラグ.Checked = False Then
                param.Add("@削除フラグ", 0)
            End If
            param.Add("@登録日", Now())
            param.Add("@更新日", Now())
            dt = logic.担当者追加(param)
            rtn = MsgBox("登録しました。　　　　" & Chr(13), Clng_Okinb1, TTL)

        ElseIf Me.登録.Text = "変更" Then
            If Not input_check(False) Then Exit Sub
            param.Add("@担当者番号", Me.lbl担当者番号.Text)
            param.Add("@担当者名", Me.担当者名.Text)
            param.Add("@表示順", Me.表示順.Text)
            If Me.削除フラグ.Checked = True Then
                deleteDt = logic.担当者削除フラグチェック()
                deleteCnt = Integer.Parse(deleteDt.Rows(0)("表示件数").ToString)
                If deleteCnt <= 1 Then
                    Call Sys_Error("スタッフを全て非表示にすることはできません。　", Me.削除フラグ)
                    ReDisp()
                    Exit Sub
                End If
                param.Add("@削除フラグ", 1)
            ElseIf Me.削除フラグ.Checked = False Then
                param.Add("@削除フラグ", 0)
            End If
            param.Add("@更新日", Now())
            dt = logic.担当者更新(param)
            rtn = MsgBox("変更しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
        End If
        ReDisp()
        Me.新規.Focus()
    End Sub
#End Region

    Private Sub 全件表示_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 全件表示.CheckedChanged
        ReDisp()
    End Sub

    Private Sub 担当者一覧_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles 担当者一覧.SelectionChanged
        ReDisplay_入力項目()
    End Sub

#End Region

#Region "キー押下時処理"
    Private Sub 担当者名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 担当者名.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.表示順.Focus()
        End If
    End Sub

    Private Sub 表示順_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 表示順.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.削除フラグ.Focus()
        End If
    End Sub

    Private Sub 削除フラグ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 削除フラグ.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.登録.Focus()
        End If
    End Sub
#End Region

#Region "キープレス設定"
    Private Sub 表示順_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles 表示順.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub
#End Region

#Region "メソッド"
    ''' <summary>入力チェック</summary>
    ''' <remarks></remarks>
    Private Function input_check(ByVal mode As Boolean) As Boolean
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        input_check = False
        Me.lbl担当者番号.Text = Trim(Me.lbl担当者番号.Text)

        If Sys_InputCheck(Me.lbl担当者番号.Text, 4, "N+", 1) Then
            Call Sys_Error("スタッフ番号 が不正です。　", Me.lbl担当者番号)
            Exit Function
        End If

        Me.担当者名.Text = Trim(Me.担当者名.Text)
        If String.IsNullOrEmpty(Me.担当者名.Text) Then
            Call Sys_Error("スタッフ名 は必須入力です。　", Me.担当者名)
            Exit Function
        End If
        If (Sys_InputCheck(Me.担当者名.Text, 32, "M", 1)) Then
            Call Sys_Error("スタッフ名 は32文字以内で入力してください。", Me.担当者名)
            Exit Function
        End If

        Me.表示順.Text = Trim(Me.表示順.Text)
        If String.IsNullOrEmpty(Me.表示順.Text) Then
            Call Sys_Error("表示順 は必須入力です。　", Me.表示順)
            Exit Function
        End If
        If Sys_Zenkaku(Me.表示順.Text) Then
            Call Sys_Error("表示順 は半角数字で入力してください。　", Me.表示順)
            Exit Function
        End If
        If (Sys_InputCheck(Me.表示順.Text, 4, "N+", 1)) Then
            Call Sys_Error("表示順 は半角数字4文字以内で入力してください。　", Me.表示順)
            Exit Function
        End If

        Select Case mode
            Case True ''登録の場合
                param.Add("@担当者番号", Me.lbl担当者番号.Text)
                dt = logic.select_number(param)
                param.Clear()
                If dt.Rows.Count > 0 Then
                    Call Sys_Error("指定されたスタッフ番号は既に登録されています。　", Me.lbl担当者番号)
                    Exit Function
                End If
                param.Add("@担当者名", Me.担当者名.Text)
                dt = logic.select_name(param)
                param.Clear()
                If dt.Rows.Count > 0 Then
                    Call Sys_Error("入力したスタッフ名は登録済です。　" & Chr(13) & Chr(13) & "スタッフ名を変更して登録してください。　", Me.担当者名)
                    Exit Function
                End If
            Case False ''変更の場合
                param.Add("@担当者名", Me.担当者名.Text)
                param.Add("@担当者番号", Me.lbl担当者番号.Text)
                dt = logic.select_name(param)
                param.Clear()
                If dt.Rows.Count > 0 Then
                    If Me.担当者一覧.SelectedRows(0).Cells(1).Value.ToString = Me.担当者名.Text Then
                        Exit Select
                    End If
                    Call Sys_Error("入力したスタッフ名は登録済です。　" & Chr(13) & Chr(13) & "スタッフ名を変更して登録してください。　", Me.担当者名)
                    Exit Function
                End If
        End Select

        input_check = True
    End Function

    ''' <summary>再表示</summary>
    ''' <remarks></remarks>
    Private Sub ReDisp()
        Dim dt As New System.Data.DataTable
        If Me.全件表示.Checked = True Then
            dt = logic.担当者全件取得
        ElseIf Me.全件表示.Checked = False Then
            dt = logic.担当者一覧取得
        End If

        If dt.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.担当者一覧.DataSource = dt
        Me.担当者一覧.ColumnHeadersDefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.担当者一覧.Columns(0).Width = 60
        Me.担当者一覧.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.担当者一覧.Columns(1).Width = 172
        Me.担当者一覧.Columns(1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.担当者一覧.Columns(2).Width = 71
        Me.担当者一覧.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.担当者一覧.Columns(3).Width = 60
        Me.担当者一覧.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomCenter
        Me.担当者一覧.ClearSelection()

        Me.lbl担当者番号.Text = Nothing
        Clear_入力項目()
        Me.担当者一覧.ClearSelection()
        ReDisplay_入力項目()
    End Sub

    ''' <summary>入力項目再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_入力項目()
        If Me.担当者一覧.SelectedRows.Count > 0 Then
            Me.登録.Text = "変更"
            Me.lbl担当者番号.Text = Me.担当者一覧.SelectedRows(0).Cells("番号").Value.ToString
            Me.担当者名.Text = Me.担当者一覧.SelectedRows(0).Cells("スタッフ名").Value.ToString
            Me.表示順.Text = Me.担当者一覧.SelectedRows(0).Cells("表示順").Value.ToString
            Me.削除フラグ.Checked = False
            If Me.担当者一覧.SelectedRows(0).Cells("表示").Value.ToString = "×" Then
                Me.削除フラグ.Checked = True
            Else
                Me.削除フラグ.Checked = False
            End If

            SetEnable_入力項目(True)

            Me.新規.Enabled = True
            Me.登録.Enabled = True

            Me.担当者名.Focus()
        Else
            Me.登録.Text = "登録"
            Clear_入力項目()
            If (String.IsNullOrEmpty(Me.lbl担当者番号.Text)) Then
                SetEnable_入力項目(False)
            Else
                SetEnable_入力項目(True)
            End If
        End If
    End Sub

    ''' <summary>入力項目クリア処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub Clear_入力項目()
        Me.担当者名.Text = Nothing
        Me.表示順.Text = Nothing
        Me.削除フラグ.Checked = False
        Me.新規.Enabled = True
    End Sub

    ''' <summary>入力項目Enable設定</summary>
    ''' <param name="v_bool">True：登録可、False：登録不可</param>
    ''' <remarks></remarks>
    Protected Friend Sub SetEnable_入力項目(ByVal v_bool As Boolean)
        If v_bool Then
            Me.lbl担当者番号.BackColor = Color.White
            Me.担当者名.Enabled = True
            Me.担当者名.BackColor = Color.White
            Me.表示順.Enabled = True
            Me.表示順.BackColor = Color.White
            Me.削除フラグ.Enabled = True

            Me.項目クリア.Enabled = True
            Me.登録.Enabled = True
        Else
            Me.lbl担当者番号.BackColor = SystemColors.Control
            Me.担当者名.Enabled = False
            Me.担当者名.BackColor = SystemColors.Control
            Me.表示順.Enabled = False
            Me.表示順.BackColor = SystemColors.Control
            Me.削除フラグ.Enabled = False

            Me.項目クリア.Enabled = False
            Me.登録.Enabled = False
        End If
    End Sub
#End Region

End Class