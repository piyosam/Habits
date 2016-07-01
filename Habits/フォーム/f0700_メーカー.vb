''' <summary>f0700_メーカー画面処理</summary>
''' <remarks></remarks>
Public Class f0700_メーカー
    Private logic As Habits.Logic.f0700_Logic

#Region " イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0700_メーカー_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        default_status()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0700_メーカー_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
        Dim max_makerno As Integer

        dt = logic.get_nextnum
        If Not dt.Rows(0)("最大メーカー番号").Equals(System.DBNull.Value) Then
            max_makerno = Integer.Parse(dt.Rows(0)("最大メーカー番号").ToString)
        Else
            max_makerno = 0
        End If
        If (max_makerno >= Max_MasterNo) Then
            Call Sys_Error("登録最大数に達したため登録できません。　", Me.閉じる)
            Exit Sub
        End If

        default_status()
        Me.登録.Text = BTN_REGIST
        Me.メーカー名.Focus()
        Me.メーカー番号.Text = (max_makerno + 1).ToString
        Me.削除フラグ.Checked = False
        ''入力項目活性化
        set_input()
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
        If (Me.登録.Text = "登録") Then ''登録ボタンのテキストが登録だった場合、新規登録

            If Not (input_check(True)) Then Exit Sub

            param.Add("@メーカー番号", Me.メーカー番号.Text)
            param.Add("@メーカー名", Me.メーカー名.Text)
            param.Add("@表示順", Me.表示順.Text)
            If (Me.削除フラグ.Checked = True) Then
                param.Add("@削除フラグ", 1)
            ElseIf (Me.削除フラグ.Checked = False) Then
                param.Add("@削除フラグ", 0)
            End If
            param.Add("@登録日", Now())
            param.Add("@更新日", Now())
            dt = logic.insert_makerinfo(param)
            rtn = MsgBox("登録しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
        Else                          ''登録ボタンのテキストが変更だった場合、アップデート
            If Not (input_check(False)) Then Exit Sub
            param.Clear()
            param.Add("@メーカー名", Me.メーカー名.Text)
            param.Add("@表示順", Me.表示順.Text)
            If (Me.削除フラグ.Checked = True) Then
                param.Add("@削除フラグ", 1)
            ElseIf (Me.削除フラグ.Checked = False) Then
                param.Add("@削除フラグ", 0)
            End If
            param.Add("@更新日", Now())
            param.Add("@メーカー番号", Me.メーカー番号.Text)
            dt = logic.update_makerinfo(param)
            rtn = MsgBox("変更しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
        End If
        Me.登録.Text = "登録"
        default_status()
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
        default_status()
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
        Me.Close()
    End Sub
#End Region

    Private Sub dgv一覧_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv一覧.SelectionChanged ''追加しました井村
        If Me.dgv一覧.SelectedRows.Count = 0 Then Exit Sub
        Me.メーカー番号.Text = Me.dgv一覧.SelectedRows(0).Cells(0).Value.ToString
        Me.メーカー名.Text = Me.dgv一覧.SelectedRows(0).Cells(1).Value.ToString
        Me.表示順.Text = Me.dgv一覧.SelectedRows(0).Cells(2).Value.ToString

        Me.削除フラグ.Checked = False

        If (Me.dgv一覧.SelectedRows(0).Cells(3).Value.ToString = "×") Then
            Me.削除フラグ.Checked = True
        End If
        Me.登録.Text = "変更"
        ''入力項目活性化
        set_input()
    End Sub

    Private Sub 表示順_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles 表示順.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub
#End Region

#Region "メソッド"
    Public Sub default_status()
        logic = New Habits.Logic.f0700_Logic
        Dim dt As New DataTable
        dt = logic.select_maker
        If dt.Rows.Count = 0 Then
            Exit Sub
        End If
        Me.dgv一覧.DataSource = dt
        Me.dgv一覧.ColumnHeadersDefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgv一覧.Columns("番号").Width = 61
        Me.dgv一覧.Columns("番号").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv一覧.Columns("メーカー名").Width = 172
        Me.dgv一覧.Columns("メーカー名").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.dgv一覧.Columns("表示順").Width = 71
        Me.dgv一覧.Columns("表示順").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv一覧.Columns("表示").Width = 61
        Me.dgv一覧.Columns("表示").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomCenter

        ''非活性に設定
        Me.登録.Enabled = False
        Me.項目クリア.Enabled = False
        Me.メーカー番号.Text = ""
        Me.メーカー番号.BackColor = SystemColors.Control
        Me.メーカー名.Text = ""
        Me.メーカー名.BackColor = SystemColors.Control
        Me.メーカー名.Enabled = False
        Me.表示順.Text = ""
        Me.表示順.BackColor = SystemColors.Control
        Me.表示順.Enabled = False
        Me.削除フラグ.Checked = False
        Me.削除フラグ.Enabled = False

        Me.dgv一覧.ClearSelection()
        Me.新規.Focus()
    End Sub

    Public Sub set_input()
        ''活性に設定
        Me.登録.Enabled = True
        Me.項目クリア.Enabled = True
        Me.メーカー番号.BackColor = Color.White
        Me.メーカー名.BackColor = Color.White
        Me.メーカー名.Enabled = True
        Me.表示順.BackColor = Color.White
        Me.表示順.Enabled = True
        Me.削除フラグ.Enabled = True
        Me.メーカー名.Focus()
    End Sub

    Private Function input_check(ByVal mode As Boolean) As Boolean
        input_check = False
        Me.メーカー番号.Text = Trim(Me.メーカー番号.Text)
        If (Sys_InputCheck(Me.メーカー番号.Text, 4, "N+", 1)) Then
            Call Sys_Error("メーカー番号 が不正です。　", Me.メーカー番号)
            Exit Function
        End If
        Me.メーカー名.Text = Trim(Me.メーカー名.Text)
        If String.IsNullOrEmpty(Me.メーカー名.Text) Then
            Call Sys_Error("メーカー名 は必須入力です。　", Me.メーカー名)
            Exit Function
        End If
        If (Sys_InputCheck(Me.メーカー名.Text, 32, "M", 1)) Then
            Call Sys_Error("メーカー名 は32文字以内で入力してください。　", Me.メーカー名)
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

        Select Case mode ''登録か変更

            Case True ''登録の場合
                Dim dt As New DataTable
                Dim param As New Habits.DB.DBParameter
                param.Add("@メーカー番号", Me.メーカー番号.Text)
                dt = logic.select_number(param)
                If (dt.Rows.Count > 0) Then
                    Call Sys_Error("指定されたメーカー番号は既に登録されています。　", Me.メーカー番号)
                    Exit Function
                End If

                param.Clear()
                param.Add("@メーカー名", Me.メーカー名.Text)
                dt = logic.select_makername(param)
                If (dt.Rows.Count > 0) Then
                    Call Sys_Error("入力したメーカー名は登録済です。　" & Chr(13) & Chr(13) & "メーカー名を変更して登録してください。　", Me.メーカー名)
                    Exit Function
                End If

            Case False ''変更の場合
                Dim dt As New DataTable
                Dim param As New Habits.DB.DBParameter
                param.Add("@メーカー名", Me.メーカー名.Text)
                dt = logic.select_makername(param)

                If (Me.dgv一覧.SelectedRows(0).Cells(1).Value.ToString = Me.メーカー名.Text) Then ''変更元の名前と一緒だった場合のみ名前の重複が可能
                    Exit Select
                End If
                If (dt.Rows.Count <> 0) Then
                    Call Sys_Error("入力したメーカー名は登録済です。　" & Chr(13) & Chr(13) & "メーカー名を変更して登録してください。　", Me.メーカー名)
                    Exit Function
                End If
        End Select
        input_check = True

    End Function
#End Region

    Private Sub メーカー名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles メーカー名.KeyDown
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

End Class