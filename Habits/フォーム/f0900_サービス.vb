''' <summary>f0900_サービス画面処理</summary>
''' <remarks></remarks>
Public Class f0900_サービス

    Private logic As Habits.Logic.f0900_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0900_サービス_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logic = New Habits.Logic.f0900_Logic
        default_status()
        Me.Btn登録.Text = BTN_REGIST
        Me.Btn新規.Focus()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0900_サービス_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
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
    Private Sub Btn新規_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn新規.Click
        Dim dt As New DataTable
        Dim max_serviceno As Integer

        dt = logic.サービス_最大番号取得()

        If Not dt.Rows(0)("最大番号").Equals(System.DBNull.Value) Then
            max_serviceno = dt.Rows(0)("最大番号")
        Else
            max_serviceno = 0
        End If
        If (max_serviceno >= Max_MasterNo) Then
            Call Sys_Error("登録最大数に達したため登録できません。　", Me.Btn閉じる)
            Exit Sub
        End If

        default_status()
        Me.Btn登録.Text = "登録"
        Me.txtサービス名.Focus()
        Me.lblサービス番号.Text = (max_serviceno + 1).ToString
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
    Private Sub Btn登録_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn登録.Click
        Dim param As New Habits.DB.DBParameter
        Dim dt As New DataTable
        Dim 日付 As Date

        日付 = Now
        If Not (input_check()) Then Exit Sub

        param.Add("@サービス番号", Me.lblサービス番号.Text)
        param.Add("@サービス名", Me.txtサービス名.Text)
        param.Add("@表示順", Me.txt表示順.Text)
        If Me.削除フラグ.Checked = True Then
            param.Add("@削除フラグ", 1)
        Else
            param.Add("@削除フラグ", 0)
        End If

        param.Add("@登録日", Now())
        param.Add("@更新日", Now())

        Select Case Me.Btn登録.Text
            Case "登録" '新規
                dt = logic.選択B_サービス取得(param)
                If dt.Rows.Count <> 0 Then '重複チェック
                    Call Sys_Error("指定されたサービス番号は既に登録されています。　", Me.lblサービス番号)
                    Exit Sub
                End If

                dt = logic.選択B_サービス名取得(param)
                If dt.Rows.Count <> 0 Then '重複チェック
                    Call Sys_Error("入力したサービス名は登録済です。　" & Chr(13) & Chr(13) & "サービス名を変更して登録してください。　", Me.txtサービス名)
                    Exit Sub
                End If

                logic.B_サービス登録(param)

            Case "変更"
                dt = logic.選択B_サービス名取得(param)
                If dt.Rows.Count <> 0 Then '重複チェック
                    Call Sys_Error("入力したサービス名は登録済です。　" & Chr(13) & Chr(13) & "サービス名を変更して登録してください。　", Me.txtサービス名)
                    Exit Sub
                End If

                logic.B_サービス更新(param)
        End Select

        rtn = MsgBox(Me.Btn登録.Text & "しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
        Me.Btn登録.Text = "登録"
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
    Private Sub Btn項目クリア_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn項目クリア.Click
        Call default_status()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btn閉じる_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn閉じる.Click
        Me.Close()
    End Sub
#End Region

    Private Sub dgvサービス一覧_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvサービス一覧.SelectionChanged
        If Me.dgvサービス一覧.SelectedRows.Count = 0 Then Exit Sub

        Dim param As New Habits.DB.DBParameter
        Dim dt As New DataTable
        param.Add("@サービス番号", Me.dgvサービス一覧.SelectedRows(0).Cells(0).Value)
        dt = logic.選択B_サービス取得(param)

        If dt.Rows.Count <> 0 Then
            Me.lblサービス番号.Text = dt.Rows(0)("サービス番号").ToString
            Me.txtサービス名.Text = dt.Rows(0)("サービス名").ToString
            Me.txt表示順.Text = dt.Rows(0)("表示順").ToString
            Me.削除フラグ.Checked = dt.Rows(0)("削除フラグ").ToString
            Me.txtサービス名.Focus()
            Me.Btn登録.Text = "変更"
            ''入力項目活性化
            set_input()
        End If
    End Sub

    Private Sub txt表示順_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt表示順.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txtサービス名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtサービス名.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt表示順.Focus()
        End If
    End Sub

    Private Sub txt表示順_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt表示順.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.削除フラグ.Focus()
        End If
    End Sub

    Private Sub 削除フラグ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 削除フラグ.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.Btn登録.Focus()
        End If
    End Sub
#End Region

#Region "メソッド"

    Private Sub default_status()
        Me.dgvサービス一覧.DataSource = logic.B_サービス取得()
        '幅
        Me.dgvサービス一覧.Columns(0).Width = 60 'サービス番号
        Me.dgvサービス一覧.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgvサービス一覧.Columns(1).Width = 172 'サービス名
        Me.dgvサービス一覧.Columns(1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgvサービス一覧.Columns(2).Width = 75 '表示順
        Me.dgvサービス一覧.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgvサービス一覧.Columns(3).Width = 60
        Me.dgvサービス一覧.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        '不可視
        Me.dgvサービス一覧.Columns(4).Visible = False '登録日
        Me.dgvサービス一覧.Columns(5).Visible = False '更新日

        ''非活性に設定
        Me.Btn登録.Enabled = False
        Me.Btn項目クリア.Enabled = False
        Me.lblサービス番号.Text = ""
        Me.lblサービス番号.BackColor = SystemColors.Control
        Me.txtサービス名.Text = ""
        Me.txtサービス名.BackColor = SystemColors.Control
        Me.txtサービス名.Enabled = False
        Me.txt表示順.Text = ""
        Me.txt表示順.BackColor = SystemColors.Control
        Me.txt表示順.Enabled = False
        Me.削除フラグ.Checked = False
        Me.削除フラグ.Enabled = False

        Me.dgvサービス一覧.ClearSelection()
        Me.Btn新規.Focus()
    End Sub

    Public Sub set_input()
        ''活性に設定
        Me.Btn登録.Enabled = True
        Me.Btn項目クリア.Enabled = True
        Me.lblサービス番号.BackColor = Color.White
        Me.txtサービス名.BackColor = Color.White
        Me.txtサービス名.Enabled = True
        Me.txt表示順.BackColor = Color.White
        Me.txt表示順.Enabled = True
        Me.削除フラグ.Enabled = True
        Me.txtサービス名.Focus()
    End Sub

    ''' <summary>入力チェック</summary>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        input_check = False
        Me.lblサービス番号.Text = Trim(Me.lblサービス番号.Text)
        If (Sys_InputCheck(Me.lblサービス番号.Text, 4, "N+", 1)) Then
            Call Sys_Error("サービス番号 が不正です。　", Me.lblサービス番号)
            Exit Function
        End If

        Me.txtサービス名.Text = Trim(Me.txtサービス名.Text)
        If String.IsNullOrEmpty(Me.txtサービス名.Text) Then
            Call Sys_Error("サービス名 は必須入力です。　", Me.txtサービス名)
            Exit Function
        End If
        If (Sys_InputCheck(Me.txtサービス名.Text, 32, "M", 1)) Then
            Call Sys_Error("サービス名 は32文字以内で入力してください。　", Me.txtサービス名)
            Exit Function
        End If

        Me.txt表示順.Text = Trim(Me.txt表示順.Text)
        If String.IsNullOrEmpty(Me.txt表示順.Text) Then
            Call Sys_Error("表示順 は必須入力です。　", Me.txt表示順)
            Exit Function
        End If
        If Sys_Zenkaku(Me.txt表示順.Text) Then
            Call Sys_Error("表示順 は半角数字で入力してください。　", Me.txt表示順)
            Exit Function
        End If
        If (Sys_InputCheck(Me.txt表示順.Text, 4, "N+", 1)) Then
            Call Sys_Error("表示順 は半角数字4文字以内で入力してください。　", Me.txt表示順)
            Exit Function
        End If

        input_check = True
    End Function
#End Region

End Class