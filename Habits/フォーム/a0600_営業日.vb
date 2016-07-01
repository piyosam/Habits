'システム名 ： HABITS
'機能名　　 ： a0600_営業日
'概要　　　 ： 実行する営業日情報の設定処理
'履歴　　　 ： 2010/05/12　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a0600_営業日

    Private logic As Habits.Logic.a0600_Logic
    Private money As String
    Private dis_money As Double

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0600_営業日_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        logic = New Habits.Logic.a0600_Logic

        '' 営業日
        Me.lbl営業日.Text = USER_DATE.ToString("yyyy\/MM\/dd")
        '' 天候
        dt = logic.GetWeather()
        cmb天候.DataSource = dt
        cmb天候.DisplayMember = "天候"
        cmb天候.ValueMember = "天候番号"
        '' スタッフ数
        lblスタッフ数.Text = ""
        '' レジ金額
        money = logic.GetCashRegisterMoney().ToString
        dis_money = Double.Parse(money)
        txtレジ金額.Text = Format(dis_money, "#,##0")
        Me.担当者選択.Focus()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0600_営業日_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        logic = Nothing
        Me.Dispose()
    End Sub
#End Region

    ''' <summary>登録ボタンクリック</summary>
    ''' <remarks></remarks>
    Private Sub btn登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn登録.Click

        If Not InputCheck() Then Exit Sub
        Dim param As New Habits.DB.DBParameter

        param.Add("@営業日", Me.lbl営業日.Text)
        param.Add("@スタッフ数", Me.lblスタッフ数.Text)
        param.Add("@天候番号", Me.cmb天候.SelectedValue)
        param.Add("@レジ金額", money)
        param.Add("@登録日", Now())
        param.Add("@更新日", Now())

        logic.InSertData(param)
        MsgBox("登録しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
        Me.Close()
    End Sub

    Private Sub 担当者選択_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 担当者選択.Click
        a0800_スタッフ選択.int_mode = 0
        a0800_スタッフ選択.ShowDialog()
        Me.btn登録.Focus()
        Me.Activate()
    End Sub

    Private Sub txtレジ金額_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtレジ金額.Enter
        Me.txtレジ金額.Text = Replace(Me.txtレジ金額.Text, ",", "")
    End Sub

    Private Sub txtレジ金額_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtレジ金額.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.btn登録.Focus()
        End If
    End Sub

    Private Sub txtレジ金額_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtレジ金額.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txtレジ金額_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtレジ金額.Validated
        Dim SJIS As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        If Me.txtレジ金額.TextLength <> 0 Then
            'レジ金額チェック
            If Not input_check_register() Then
                Me.txtレジ金額.Text = Nothing
                Exit Sub
            End If
        End If
        money = Replace(Me.txtレジ金額.Text, ",", "")
        If IsNumeric(money) Then
            dis_money = Double.Parse(money)
            Me.txtレジ金額.Text = Format(dis_money, "#,##0")
        Else
            Call Sys_Error("レジ金額 は半角数字9文字以内で入力してください。　", Me.txtレジ金額)
            Me.txtレジ金額.Text = Nothing
            Exit Sub
        End If
        RemoveHandler txtレジ金額.Validated, AddressOf txtレジ金額_Validated
        AddHandler txtレジ金額.Validated, AddressOf Me.txtレジ金額_Validated
    End Sub
#End Region

#Region "メソッド"

    ''' <summary>入力チェック</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InputCheck() As Boolean
        InputCheck = False
        If (Sys_InputCheck(Me.cmb天候.SelectedIndex, 4, "N", 1)) Then
            Call Sys_Error("天候 を選択してください。　", Me.cmb天候)
            Exit Function
        End If

        If (Sys_InputCheck(Me.lblスタッフ数.Text, 3, "N+", 1)) Then
            Call Sys_Error("スタッフ数 が不正です。　", Me.担当者選択)
            Exit Function
        End If

        'レジ金額チェック
        If Not (input_check_register()) Then Exit Function

        InputCheck = True
    End Function

    ''' <summary>レジ金額入力チェック</summary>
    ''' <remarks></remarks>
    Private Function input_check_register() As Boolean
        input_check_register = False

        'レジ金額チェック
        Me.txtレジ金額.Text = Trim(Me.txtレジ金額.Text)
        money = Replace(Me.txtレジ金額.Text, ",", "")
        If (String.IsNullOrEmpty(money)) Then
            Call Sys_Error("レジ金額 は必須入力です。　", Me.txtレジ金額)
            Exit Function
        End If
        If Sys_Zenkaku(money) Then
            Call Sys_Error("レジ金額 は半角数字で入力してください。　", Me.txtレジ金額)
            Exit Function
        End If
        If (Sys_InputCheck(money, 9, "N+", 1)) Then
            Call Sys_Error("レジ金額 は半角数字9文字以内で入力してください。", Me.txtレジ金額)
            Exit Function
        End If

        input_check_register = True
    End Function
#End Region
End Class