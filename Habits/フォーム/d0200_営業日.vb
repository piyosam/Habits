''' <summary>d0200_営業日画面処理</summary>
''' <remarks></remarks>
Public Class d0200_営業日

    Private logic As Habits.Logic.d0200_Logic
    Private money As String
    Private w_money As Double

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub d0200_営業日_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logic = New Habits.Logic.d0200_Logic

        '天候一覧取得
        Me.天候.DataSource = logic.B_天候取得()
        Me.天候.DisplayMember = "天候"
        Me.天候.ValueMember = "天候番号"

        Call default_status()
        Call 一覧更新()
        Me.閉じる.Focus()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub d0200_営業日_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "変更ボタン押下"
    ''' <summary>変更ボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 変更_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 変更.Click
        Dim param As New Habits.DB.DBParameter
        Dim EEI As New DataTable

        If Not (input_check()) Then Exit Sub

        param.Add("@天候番号", Me.天候.SelectedValue)
        param.Add("@スタッフ数", Me.スタッフ数.Text)
        param.Add("@レジ金額", money)
        param.Add("@更新日", Now)
        param.Add("@営業日", Date.Parse(Mid(Me.dgv一覧.SelectedRows(0).Cells(0).Value.ToString, 1, 10)))

        Call logic.E_営業日更新(param)
        rtn = MsgBox("変更しました。　　　　" & Chr(13), Clng_Okinb1, TTL)

        Call default_status()
        Call 一覧更新()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>閉じるボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub
#End Region

#Region "営業日一覧クリック処理"
    ''' <summary>
    ''' 営業日一覧のどこかがClickされた場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv一覧_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv一覧.CellClick
        setEdit()
    End Sub
#End Region

    Private Sub スタッフ数_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles スタッフ数.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.レジ金額.Focus()
        End If
    End Sub

    Private Sub スタッフ数_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles スタッフ数.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub レジ金額_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles レジ金額.Enter
        If (input_check()) Then
            Me.レジ金額.Text = Replace(Me.レジ金額.Text, ",", "")
        End If
    End Sub

    Private Sub レジ金額_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles レジ金額.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.変更.Focus()
        End If
    End Sub

    Private Sub レジ金額_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles レジ金額.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub レジ金額_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles レジ金額.Validated
        If (input_check()) Then
            money = Replace(Me.レジ金額.Text, ",", "")
            w_money = Double.Parse(money)
            Me.レジ金額.Text = Format(w_money, "#,##0")
            RemoveHandler レジ金額.Validated, AddressOf レジ金額_Validated
            Me.変更.Focus()
            AddHandler レジ金額.Validated, AddressOf レジ金額_Validated
        End If
    End Sub


    Private Sub dgv一覧_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv一覧.Sorted
        setEdit()
    End Sub

#End Region

#Region "メソッド"

    Private Sub default_status()
        Me.dgv一覧.ClearSelection()

        Me.営業日.Text = ""
        Me.天候.SelectedIndex = -1
        Me.スタッフ数.Text = ""
        Me.レジ金額.Text = ""

        Me.変更.Enabled = False
        Me.営業日.BackColor = SystemColors.Control
        Me.天候.Enabled = False
        Me.スタッフ数.ReadOnly = True
        Me.スタッフ数.Enabled = False
        Me.スタッフ数.BackColor = SystemColors.Control
        Me.レジ金額.ReadOnly = True
        Me.レジ金額.Enabled = False
        Me.レジ金額.BackColor = SystemColors.Control
    End Sub

    Private Sub 一覧更新()
        Dim param As New Habits.DB.DBParameter
        Dim dt As New DataTable
        Dim a As Date

        a = Now
        a = DateAdd("M", -6, a)
        param.Add("@半年前", a)

        'dgv一覧にデータを読込みさせる
        dt = logic.Q_d0200_営業日一覧(param)
        dgv一覧.DataSource = dt

        '幅調整
        Me.dgv一覧.Columns(1).Width = 100   '日付
        Me.dgv一覧.Columns(2).Width = 60   '天候
        Me.dgv一覧.Columns(3).Width = 80   'スタッフ数
        Me.dgv一覧.Columns(4).Width = 96   'レジ金額

        '可視
        Me.dgv一覧.Columns(0).Visible = False

        'フォーマット
        Me.dgv一覧.Columns(1).DefaultCellStyle.Format = "MM\月dd\日\(ddd\)"
        Me.dgv一覧.Columns(1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv一覧.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomCenter
        Me.dgv一覧.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv一覧.Columns(4).DefaultCellStyle.Format = "#,##0"
        Me.dgv一覧.Columns(4).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight

        Me.dgv一覧.ClearSelection()
    End Sub

    Private Function input_check() As Boolean
        input_check = False
        Dim str As String

        If (Sys_InputCheck(Me.営業日.Text, 7, "D", 1)) Then
            Call Sys_Error("営業日 が不正です。　", Me.営業日)
            Exit Function
        End If

        If (Sys_InputCheck(Me.天候.SelectedIndex, 4, "N", 1)) Then
            Call Sys_Error("天候 を選択してください。　", Me.天候.SelectedIndex)
            Exit Function
        End If
        If (String.IsNullOrEmpty(Me.スタッフ数.Text)) Then
            Call Sys_Error("スタッフ数 は必須入力です。　", Me.スタッフ数)
            Exit Function
        End If
        If (Sys_InputCheck(Me.スタッフ数.Text, 3, "N", 1)) Then
            Call Sys_Error("スタッフ数 は1～999で入力してください。　", Me.スタッフ数)
            Exit Function
        End If
        If Integer.Parse(Me.スタッフ数.Text) = 0 Then
            Call Sys_Error("スタッフ数 は1～999で入力してください。　", Me.スタッフ数)
            Exit Function
        End If
        If (String.IsNullOrEmpty(Me.レジ金額.Text)) Then
            Call Sys_Error("レジ金額 は必須入力です。　", Me.レジ金額)
            Exit Function
        End If
        str = Replace(Me.レジ金額.Text, ",", "")
        If (Sys_InputCheck(str, 9, "N+", 1)) Then
            Call Sys_Error("レジ金額 は半角数字9文字以内で入力してください。　", Me.レジ金額)
            Exit Function
        End If
        input_check = True
    End Function

    ''' <summary>
    ''' 編集項目設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setEdit()
        Dim param As New Habits.DB.DBParameter
        Dim EEI As New DataTable ' E_営業日

        param.Add("@営業日", Date.Parse(Mid(Me.dgv一覧.SelectedRows(0).Cells(0).Value.ToString, 1, 10)))
        EEI = logic.E_営業日取得(param)

        If EEI.Rows.Count <> 0 Then
            Me.変更.Enabled = True
            Me.営業日.BackColor = Color.White
            Me.天候.Enabled = True
            Me.スタッフ数.BackColor = Color.White
            Me.スタッフ数.ReadOnly = False
            Me.スタッフ数.Enabled = True
            Me.レジ金額.BackColor = Color.White
            Me.レジ金額.ReadOnly = False
            Me.レジ金額.Enabled = True


            Me.営業日.Text = DateTime.Parse(EEI.Rows(0)("営業日").ToString).ToString("yyyy/M/d(ddd)")
            Me.天候.SelectedValue = EEI.Rows(0)("天候番号").ToString
            Me.スタッフ数.Text = EEI.Rows(0)("スタッフ数").ToString
            money = EEI.Rows(0)("レジ金額").ToString
            w_money = Double.Parse(money)
            Me.レジ金額.Text = Format(w_money, "#,##0")

            Me.スタッフ数.Focus()
        End If
    End Sub
#End Region

End Class