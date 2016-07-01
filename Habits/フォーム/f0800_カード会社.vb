''' <summary>f0800_カード会社画面処理</summary>
''' <remarks></remarks>
Public Class f0800_カード会社
    Private logic As Habits.Logic.f0800_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0800_カード会社_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        default_status()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0800_カード会社_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
        Dim max_cardno As Integer

        dt = logic.カード会社_最大番号取得()
        If Not dt.Rows(0)("最大番号").Equals(System.DBNull.Value) Then
            max_cardno = Integer.Parse(dt.Rows(0)("最大番号").ToString)
        Else
            max_cardno = 0
        End If
        If (max_cardno >= Max_MasterNo) Then
            Call Sys_Error("登録最大数に達したため登録できません。　", Me.閉じる)
            Exit Sub
        End If

        default_status()
        Me.登録.Text = BTN_REGIST
        Me.新規.Focus()
        Me.カード会社番号.Text = (max_cardno + 1).ToString
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
        If (Me.登録.Text = "登録") Then ''登録ボタンのテキストが登録の場合(インサート処理)
            If Not (input_check(True)) Then Exit Sub
            param.Add("@カード会社番号", Me.カード会社番号.Text)
            param.Add("@カード会社名", Me.カード会社名.Text)
            param.Add("@表示順", Me.表示順.Text)
            If (Me.削除フラグ.Checked = True) Then
                param.Add("@削除フラグ", 1)
            ElseIf (Me.削除フラグ.Checked = False) Then
                param.Add("@削除フラグ", 0)
            End If
            param.Add("@登録日", Now())
            param.Add("@更新日", Now())
            dt = logic.insert_cardinfo(param)
            rtn = MsgBox("登録しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
        Else                            ''登録ボタンのテキストが変更の場合(アップデート処理)
            If Not (input_check(False)) Then Exit Sub
            param.Add("@カード会社名", Me.カード会社名.Text)
            param.Add("@表示順", Me.表示順.Text)
            If (Me.削除フラグ.Checked = True) Then
                param.Add("@削除フラグ", 1)
            ElseIf (Me.削除フラグ.Checked = False) Then
                param.Add("@削除フラグ", 0)
            End If
            param.Add("@更新日", Now())
            param.Add("@カード会社番号", Me.カード会社番号.Text)
            dt = logic.update_cardinfo(param)
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
        Me.dgv一覧.ClearSelection()
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

    Private Sub 表示順_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles 表示順.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub カード会社名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles カード会社名.KeyDown
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

    Private Sub dgv一覧_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv一覧.SelectionChanged ''追加しました井村
        If Me.dgv一覧.SelectedRows.Count = 0 Then Exit Sub
        Me.カード会社番号.Text = Me.dgv一覧.SelectedRows(0).Cells(0).Value.ToString
        Me.カード会社名.Text = Me.dgv一覧.SelectedRows(0).Cells(1).Value.ToString
        Me.表示順.Text = Me.dgv一覧.SelectedRows(0).Cells(2).Value.ToString

        Me.削除フラグ.Checked = False

        If (Me.dgv一覧.SelectedRows(0).Cells(3).Value.ToString = "×") Then
            Me.削除フラグ.Checked = True
        End If
        Me.登録.Text = "変更"
        ''入力項目を活性に設定
        set_input()
    End Sub
#End Region

#Region "メソッド"
    Private Sub default_status()
        logic = New Habits.Logic.f0800_Logic
        Dim dt As New DataTable
        dt = logic.select_cardinfo
        If dt.Rows.Count = 0 Then Exit Sub
        Me.dgv一覧.RowTemplate.Height = 17
        Me.dgv一覧.DataSource = dt
        Me.dgv一覧.ColumnHeadersDefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgv一覧.Columns(0).Width = 60
        Me.dgv一覧.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv一覧.Columns(1).Width = 172
        Me.dgv一覧.Columns(1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.dgv一覧.Columns(2).Width = 71
        Me.dgv一覧.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv一覧.Columns(3).Width = 60
        Me.dgv一覧.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomCenter

        ''非活性に設定
        Me.登録.Enabled = False
        Me.項目クリア.Enabled = False
        Me.カード会社番号.Text = ""
        Me.カード会社番号.BackColor = SystemColors.Control
        Me.カード会社名.Text = ""
        Me.カード会社名.BackColor = SystemColors.Control
        Me.カード会社名.Enabled = False
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
        Me.カード会社番号.BackColor = Color.White
        Me.カード会社名.BackColor = Color.White
        Me.カード会社名.Enabled = True
        Me.表示順.BackColor = Color.White
        Me.表示順.Enabled = True
        Me.削除フラグ.Enabled = True
        Me.カード会社名.Focus()
    End Sub

    ''' <summary>入力チェック</summary>
    ''' <param name="mode">True：登録、False：変更</param>
    ''' <remarks></remarks>
    Private Function input_check(ByVal mode As Boolean) As Boolean
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        input_check = False

        Me.カード会社番号.Text = Trim(Me.カード会社番号.Text)
        If (Sys_InputCheck(Me.カード会社番号.Text, 4, "N+", 1)) Then
            Call Sys_Error("カード会社番号 が不正です。　", Me.カード会社番号)
            Exit Function
        End If

        Me.カード会社名.Text = Trim(Me.カード会社名.Text)
        If String.IsNullOrEmpty(Me.カード会社名.Text) Then
            Call Sys_Error("カード会社名 は必須入力です。　", Me.カード会社名)
            Exit Function
        End If
        If (Sys_InputCheck(Me.カード会社名.Text, 32, "M", 1)) Then
            Call Sys_Error("カード会社名 は32文字以内で入力してください。　", Me.カード会社名)
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

        Select Case mode ''登録と変更の場合わけ

            Case True ''登録の場合
                param.Add("@カード会社番号", Me.カード会社番号.Text)
                dt = logic.select_number(param)
                If (dt.Rows.Count > 0) Then
                    Call Sys_Error("指定されたカード会社番号は既に登録されています。　", Me.カード会社番号)
                    Exit Function
                End If
                param.Clear()
                param.Add("@カード会社名", Me.カード会社名.Text)
                dt = logic.select_cardname(param)
                If (dt.Rows.Count > 0) Then
                    Call Sys_Error("入力したカード会社名は登録済です。　" & Chr(13) & Chr(13) & "カード会社名を変更して登録してください。　", Me.カード会社名)
                    Exit Function
                End If

            Case False ''変更の場合
                param.Clear()
                param.Add("@カード会社名", Me.カード会社名.Text)
                dt = logic.select_cardname(param)
                If (Me.dgv一覧.SelectedRows(0).Cells(1).Value.ToString = Me.カード会社名.Text) Then ''変更前と同名の場合は同名での変更が可能
                    Exit Select
                End If
                If (dt.Rows.Count > 0) Then
                    Call Sys_Error("入力したカード会社名は登録済です。　" & Chr(13) & Chr(13) & "カード会社名を変更して登録してください。　", Me.カード会社名)
                    Exit Function
                End If
        End Select

        input_check = True
    End Function
#End Region

End Class