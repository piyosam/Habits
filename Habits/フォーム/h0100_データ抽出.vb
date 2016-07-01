''' <summary>h0100_データ抽出画面処理</summary>
''' <remarks></remarks>
Public Class h0100_データ抽出

#Region "変数・定数"
    Dim str_Type, str_Value1, str_Value2 As String
    Private logic As New Habits.Logic.h0100_Logic
    Dim lng_CmdNo As Long
    Dim bFinishRoading As Boolean
    Dim bFinishMaking As Boolean
    Dim treeNode_sd As New System.Windows.Forms.TreeNode
    Dim Node1, Node2 As New System.Windows.Forms.TreeNode
    Private smoney, lmoney As String
    Private w_smoney, w_lmoney As Double
    Dim registerFlag As Boolean
#End Region

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub h0100_データ抽出_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '管理者モード機能の設定
        If MANAGER_MODE = False Then
            rtn = MsgBox("この機能は管理者のみ使用できる機能です。　", Clng_Okexb1, TTL)
            Me.Close()
            Exit Sub
        End If

        Call Sys_ClearTextBox(Me)
        Me.bFinishRoading = False
        Me.bFinishMaking = False

        Me.新規.Checked = True
        Me.仮登録除外.Enabled = True
        Me.確認.Enabled = False
        Me.追加.Enabled = False
        Me.絞込.Enabled = False

        Dim d性別 As New DataTable
        d性別 = logic.SexType()
        Me.cmb性別番号.DataSource = d性別
        Me.cmb性別番号.DisplayMember = "性別"
        Me.cmb性別番号.ValueMember = "性別番号"
        Me.cmb性別番号.SelectedValue = -1
        Me.cmb性別番号.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList

        Me.txt基準日.Text = USER_DATE.ToString("yyyy/MM/dd")

        Dim d担当者名 As New DataTable
        d担当者名 = logic.ChargePerson()

        Me.cmb主担当者番号.DataSource = d担当者名
        Me.cmb主担当者番号.DisplayMember = "担当者名"
        Me.cmb主担当者番号.ValueMember = "担当者番号"
        Me.cmb主担当者番号.SelectedValue = -1
        Me.cmb主担当者番号.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList

        Dim dサービス名 As New DataTable
        dサービス名 = logic.ServiceName()
        Me.cmbサービス一覧.DataSource = dサービス名
        Me.cmbサービス一覧.DisplayMember = "サービス名"
        Me.cmbサービス一覧.ValueMember = "サービス番号"
        Me.cmbサービス一覧.SelectedValue = -1
        Me.cmbサービス一覧.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList

        Dim d区分 As New DataTable
        d区分 = logic.get_saleDivision()

        If d区分.Rows.Count > 0 Then
            Me.cmb区分.DataSource = d区分
            Me.cmb区分.DisplayMember = "売上区分"
            Me.cmb区分.ValueMember = "売上区分番号"
            Me.cmb区分.SelectedIndex = 0
            Me.cmb区分.Enabled = True
            Me.cmb区分.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        End If

        Me.txt最終来店日開始.Text = DateSerial(Year(USER_DATE), Month(USER_DATE), 1).ToString("yyyy/MM/dd")
        Me.txt最終来店日終了.Text = USER_DATE.ToString("yyyy/MM/dd")
        Me.txt生年月日終了.Text = ""
        Me.txt生年月日開始.Text = ""

        logic.Q_h0100_W_顧客抽出削除()
        logic.Q_h0100_W_抽出履歴削除()

        Me.bFinishRoading = True
        Me.抽出履歴一覧.DataSource = Nothing

        Me.tcCondition.SelectedIndex = 0
        init() 'メニュー
        Me.ActiveControl = Me.cmb性別番号
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub h0100_データ抽出_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.tvメニュー.Nodes.Clear()
        Me.Dispose()
    End Sub
#End Region

#Region "ラジオボタン（新規）変更処理"
    ''' <summary>
    ''' 新規ラジオボタン変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 新規_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新規.CheckedChanged
        Me.仮登録除外.Enabled = True
        Me.仮登録除外.Checked = True
    End Sub
#End Region

#Region "ラジオボタン（追加）変更処理"
    ''' <summary>
    ''' 追加ラジオボタン変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub 追加_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 追加.CheckedChanged
        Me.仮登録除外.Enabled = False
        Me.仮登録除外.Checked = registerFlag
    End Sub
#End Region

#Region "ラジオボタン（絞込）変更処理"
    ''' <summary>
    ''' 絞込ラジオボタン変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub 絞込_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 絞込.CheckedChanged
        Me.仮登録除外.Enabled = False
        Me.仮登録除外.Checked = registerFlag
    End Sub
#End Region

#Region "タブ変更処理"
    ''' <summary>
    ''' タブ変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcCondition.SelectedIndexChanged
        Select Case tcCondition.SelectedIndex
            Case 0    ' タブ(性別)
                cmb性別番号.Focus()
            Case 1  ' タブ(生年月日)
                txt生年月日開始.Focus()
            Case 2  ' タブ(誕生月)
                txt誕生月開始.Focus()
            Case 3  ' タブ(年齢)
                txt年齢開始.Focus()
            Case 4  ' タブ(メニュー)
                tvメニュー.Focus()
            Case 5  ' タブ(来店回数)
                txt来店回数開始.Focus()
            Case 6  ' タブ(区分売上)
                cmb区分.Focus()
            Case 7  ' タブ(主担当)
                cmb主担当者番号.Focus()
            Case 8  ' タブ(最終来店日)
                txt最終来店日開始.Focus()
            Case 9  ' タブ(サービス)
                cmbサービス一覧.Focus()
        End Select
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "抽出ボタン押下"
    ''' <summary>
    ''' 抽出ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 抽出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 抽出.Click

        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        Dim iNUM1 As Integer
        Dim iNUM2 As Integer
        If Not (input_check()) Then Exit Sub

        Me.txt区分売上開始.Text = Replace(Me.txt区分売上開始.Text, ",", "")
        Me.txt区分売上終了.Text = Replace(Me.txt区分売上終了.Text, ",", "")

        param.Add("@顧客番号", Clng_STFreeNo)
        If Me.新規.Checked Then
            logic.Q_h0100_W_顧客抽出削除()
            logic.Q_h0100_W_抽出履歴削除()
            logic.Q_h0100_W_顧客削除()
            registerFlag = Me.仮登録除外.Checked
            If (Me.仮登録除外.Checked = True) Then
                logic.顧客新規作成登録済(param)
            Else
                logic.顧客新規作成全体(param)
            End If

            lng_CmdNo = 1

            param.Clear()
            Call select_新規絞込_追加()
            param.Add("@履歴番号", 1)
            param.Add("@区分", "新規")
            param.Add("@条件", str_Type)
            param.Add("@値1", str_Value1)
            param.Add("@値2", str_Value2)
            logic.W_抽出履歴追加(param)

        ElseIf Me.追加.Checked Then
            lng_CmdNo = lng_CmdNo + 1

            Call select_新規絞込_追加()
            param.Clear()
            param.Add("@履歴番号", lng_CmdNo)
            param.Add("@区分", "追加")
            param.Add("@条件", str_Type)
            param.Add("@値1", str_Value1)
            param.Add("@値2", str_Value2)
            logic.W_抽出履歴追加(param)

        ElseIf Me.絞込.Checked Then
            logic.Q_h0100_W_顧客削除()
            logic.顧客抽出作成()
            logic.Q_h0100_W_顧客抽出削除()
            lng_CmdNo = lng_CmdNo + 1

            Call select_新規絞込_追加()
            param.Clear()
            param.Add("@履歴番号", lng_CmdNo)
            param.Add("@区分", "絞込")
            param.Add("@条件", str_Type)
            param.Add("@値1", str_Value1)
            param.Add("@値2", str_Value2)
            logic.W_抽出履歴追加(param)
        End If

        If (Integer.Parse(Me.lbl抽出件数.Text) <> 0) Then
            Me.追加.Enabled = True
            Me.絞込.Enabled = True
            Me.確認.Enabled = True
        Else
            Me.絞込.Enabled = False
            Me.確認.Enabled = False
            Me.新規.Checked = True
        End If

        dt = logic.Q_h0100_抽出履歴一覧()
        Me.抽出履歴一覧.DataSource = dt
        Me.抽出履歴一覧.Columns(0).Width = 45
        Me.抽出履歴一覧.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.抽出履歴一覧.Columns(1).Width = 60
        Me.抽出履歴一覧.Columns(2).Width = 137
        Me.抽出履歴一覧.Columns(3).Width = 135
        Me.抽出履歴一覧.Columns(4).Width = 135
        Me.抽出履歴一覧.ClearSelection()

        If Not Me.txt区分売上開始.Text = "" Then
            iNUM1 = Integer.Parse(Me.txt区分売上開始.Text)
            Me.txt区分売上開始.Text = Format(iNUM1, "#,##0")
        End If

        If Not Me.txt区分売上終了.Text = "" Then
            iNUM2 = Integer.Parse(Me.txt区分売上終了.Text)
            Me.txt区分売上終了.Text = Format(iNUM2, "#,##0")
        End If
    End Sub
#End Region

#Region "確認ボタン押下"
    ''' <summary>
    ''' 確認ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 確認_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 確認.Click
        h0200_確認.ShowDialog()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.tvメニュー.Nodes.Clear()
        Me.Close()
    End Sub
#End Region

#End Region

#Region "キー押下イベント（KeyDown）"

    Private Sub 生年月日開始_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt生年月日開始.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Or e.KeyCode = Windows.Forms.Keys.Tab Then
            Me.txt生年月日終了.Focus()
        End If
    End Sub

    Private Sub 最終来店日開始_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt最終来店日開始.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Dim date1 As DateTime

            Try
                date1 = DateTime.Parse(Me.txt最終来店日開始.Text)
                Me.txt最終来店日開始.Text = date1.ToString("yyyy/MM/dd")
                Me.txt最終来店日終了.Focus()
            Catch ex As Exception
                Me.txt最終来店日開始.Text = ""
                Me.txt最終来店日開始.Focus()
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub 誕生月開始_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt誕生月開始.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt誕生月終了.Focus()
        End If
    End Sub

    Private Sub 誕生月終了_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt誕生月終了.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.新規.Focus()
        End If
    End Sub

    Private Sub 生年月日終了_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt生年月日終了.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.新規.Focus()
        End If
    End Sub
    Private Sub 年齢開始_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt年齢開始.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt年齢終了.Focus()
        End If
    End Sub

    Private Sub 基準日_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt基準日.KeyDown
        Dim date1 As DateTime

        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Try
                date1 = DateTime.Parse(Me.txt基準日.Text)
                Me.txt基準日.Text = date1.ToString("yyyy/MM/dd")
                Me.新規.Focus()
            Catch ex As Exception
                Me.txt基準日.Text = ""
                Me.txt基準日.Focus()
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub 最終来店日終了_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt最終来店日終了.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Dim date1 As DateTime
            Try
                date1 = DateTime.Parse(Me.txt最終来店日終了.Text)
                Me.txt最終来店日終了.Text = date1.ToString("yyyy/MM/dd")
            Catch ex As Exception
                Me.txt最終来店日終了.Text = ""
                Me.txt最終来店日終了.Focus()
                Exit Sub
            End Try
        End If

    End Sub

    Private Sub サービス開始_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtサービス開始.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Dim date1 As DateTime
            Try
                date1 = DateTime.Parse(Me.txtサービス開始.Text)
                Me.txtサービス開始.Text = date1.ToString("yyyy/MM/dd")
            Catch ex As Exception
                Me.txtサービス開始.Text = ""
                Me.txtサービス開始.Focus()
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub サービス終了_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtサービス終了.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Dim date1 As DateTime
            Try
                date1 = DateTime.Parse(Me.txtサービス終了.Text)
                Me.txtサービス終了.Text = date1.ToString("yyyy/MM/dd")
            Catch ex As Exception
                Me.txtサービス終了.Text = ""
                Me.txtサービス終了.Focus()
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub 区分売上開始_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt区分売上開始.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt区分売上終了.Focus()
        End If
    End Sub

    Private Sub 区分売上終了_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt区分売上終了.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.抽出.Focus()
        End If
    End Sub

    Private Sub 区分売上期間開始_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt区分売上期間開始.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Dim date1 As DateTime
            Try
                date1 = DateTime.Parse(Me.txt区分売上期間開始.Text)
                Me.txt区分売上期間開始.Text = date1.ToString("yyyy/MM/dd")
            Catch ex As Exception
                Me.txt区分売上期間開始.Text = ""
                Me.txt区分売上期間開始.Focus()
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub 区分売上期間終了_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt区分売上期間終了.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Dim date1 As DateTime
            Try
                date1 = DateTime.Parse(Me.txt区分売上期間終了.Text)
                Me.txt区分売上期間終了.Text = date1.ToString("yyyy/MM/dd")
            Catch ex As Exception
                Me.txt区分売上期間終了.Text = ""
                Me.txt区分売上期間終了.Focus()
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub 年齢終了_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt年齢終了.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.新規.Focus()
        End If
    End Sub

#End Region

#Region "フォーカスイベント（Enter）"
    Private Sub 選択区分_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 選択区分.Enter
        If Me.新規.Checked Then
            Me.仮登録除外.Enabled = True
        ElseIf Me.追加.Checked Then
            Me.仮登録除外.Enabled = False
        ElseIf Me.絞込.Checked Then
            Me.仮登録除外.Enabled = False
        End If
    End Sub
#End Region

#Region "キープレスイベント"
    Private Sub 誕生月開始_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt誕生月開始.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub 誕生月終了_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt誕生月終了.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub 年齢開始_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt年齢開始.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub 年齢終了_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt年齢終了.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub 来店回数開始_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt来店回数開始.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub 来店回数終了_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt来店回数終了.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub
#End Region

#Region "メソッド"
    ''' <summary>抽出履歴-性別設定</summary>
    ''' <remarks></remarks>
    Private Sub set_性別()
        str_Type = "性別"
        str_Value1 = Me.cmb性別番号.Text
        str_Value2 = ""
    End Sub

    ''' <summary>抽出履歴-生年月日設定</summary>
    ''' <remarks></remarks>
    Private Sub set_生年月日()
        str_Type = "生年月日"
        str_Value1 = Me.txt生年月日開始.Text
        str_Value2 = Me.txt生年月日終了.Text
    End Sub

    ''' <summary>抽出履歴-誕生月設定</summary>
    ''' <remarks></remarks>
    Private Sub set_誕生月()
        str_Type = "誕生月"
        str_Value1 = Me.txt誕生月開始.Text
        str_Value2 = Me.txt誕生月終了.Text
    End Sub

    ''' <summary>抽出履歴-年齢設定</summary>
    ''' <remarks></remarks>
    Private Sub set_年齢()
        str_Type = "年齢"
        str_Value1 = Me.txt年齢開始.Text
        str_Value2 = Me.txt年齢終了.Text
    End Sub

    ''' <summary>抽出履歴-主担当設定</summary>
    ''' <remarks></remarks>
    Private Sub set_主担当()
        str_Type = "主担当"
        str_Value1 = Me.cmb主担当者番号.Text
        If chk指名.Checked Then
            str_Value2 = "指名あり"
        Else
            str_Value2 = "指名なし"
        End If
    End Sub

    ''' <summary>抽出履歴-最終来店日設定</summary>
    ''' <remarks></remarks>
    Private Sub set_最終来店日()
        str_Type = "最終来店日"
        str_Value1 = Me.txt最終来店日開始.Text
        str_Value2 = Me.txt最終来店日終了.Text
    End Sub

    ''' <summary>抽出履歴-サービス設定</summary>
    ''' <remarks></remarks>
    Private Sub set_サービス()
        str_Type = "サービス"
        str_Value1 = Me.cmbサービス一覧.Text
        str_Value2 = ""
    End Sub

    ''' <summary>抽出履歴-メニュー設定</summary>
    ''' <remarks></remarks>
    Private Sub set_メニュー()
        str_Type = "メニュー"
        str_Value1 = ""
        str_Value2 = ""
    End Sub

    ''' <summary>抽出履歴-来店回数設定</summary>
    ''' <remarks></remarks>
    Private Sub set_来店回数()
        str_Type = "来店回数"
        str_Value1 = Me.txt来店回数開始.Text
        str_Value2 = Me.txt来店回数終了.Text
    End Sub

    ''' <summary>抽出履歴-区分売上設定</summary>
    ''' <remarks></remarks>
    Private Sub set_区分売上()
        str_Type = Me.cmb区分.Text & "売上"
        str_Value1 = Me.txt区分売上開始.Text
        str_Value2 = Me.txt区分売上終了.Text
    End Sub

#Region "入力チェック"
    ''' <summary>入力チェック</summary>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        Dim count As New Stopwatch
        Dim 比較日 As Date = Date.Parse(Min_Date)
        input_check = False
        count.Start()

        Select Case Me.tcCondition.SelectedIndex
            Case 0    ' 性別
                If Sys_InputCheck(Me.cmb性別番号.SelectedIndex, 4, "N+", 1) Then
                    Call Sys_Error("性別 を選択してください。　", Me.cmb性別番号)
                    Exit Function
                End If

            Case 1    ' 生年月日
                '生年月日開始
                Dim errMsg As String = Nothing

                If Not Sys_InputCheck_Date(Me.txt生年月日開始.Text, errMsg) Then
                    Call Sys_Error("生年月日 " & errMsg, Me.txt生年月日開始)
                    Exit Function
                End If
                Me.txt生年月日開始.Text = Format(DateTime.Parse(Me.txt生年月日開始.Text), "yyyy/M/d")

                '生年月日終了
                If Not Sys_InputCheck_Date(Me.txt生年月日終了.Text, errMsg) Then
                    Call Sys_Error("生年月日 " & errMsg, Me.txt生年月日終了)
                    Exit Function
                End If
                Me.txt生年月日終了.Text = Format(DateTime.Parse(Me.txt生年月日終了.Text), "yyyy/M/d")

                If DateTime.Parse(Me.txt生年月日開始.Text) > DateTime.Parse(Me.txt生年月日終了.Text) Then
                    Call Sys_Error("生年月日（To） は生年月日（From）以降の日付を設定してください。　", Me.txt生年月日終了)
                    Exit Function
                End If

            Case 2    ' 誕生月
                '誕生月開始
                If String.IsNullOrEmpty(Me.txt誕生月開始.Text) Then
                    Call Sys_Error("誕生月 は必須入力です。　", Me.txt誕生月開始)
                    Exit Function
                End If
                If Sys_Zenkaku(Me.txt誕生月開始.Text) Then
                    Call Sys_Error("誕生月 は半角で入力してください。　", Me.txt誕生月開始)
                    Exit Function
                End If
                If (Sys_InputCheck(Me.txt誕生月開始.Text, 2, "N+", 1)) Then
                    Call Sys_Error("誕生月 は半角数字2文字以内で入力してください。　", Me.txt誕生月開始)
                    Exit Function
                End If
                If Not (Integer.Parse(Me.txt誕生月開始.Text) >= 1 And Integer.Parse(Me.txt誕生月開始.Text) <= 12) Then
                    Call Sys_Error("誕生月 は1～12の半角数字で入力してください。　", Me.txt誕生月開始)
                    Exit Function
                End If
                '誕生月終了
                If String.IsNullOrEmpty(Me.txt誕生月終了.Text) Then
                    Call Sys_Error("誕生月 は必須入力です。　", Me.txt誕生月終了)
                    Exit Function
                End If
                If Sys_Zenkaku(Me.txt誕生月終了.Text) Then
                    Call Sys_Error("誕生月 は半角で入力してください。　", Me.txt誕生月終了)
                    Exit Function
                End If
                If (Sys_InputCheck(Me.txt誕生月終了.Text, 2, "N", 1)) Then
                    Call Sys_Error("誕生月 は半角数字2文字以内で入力してください。　", Me.txt誕生月終了)
                    Exit Function
                End If
                If Not (Integer.Parse(Me.txt誕生月終了.Text) >= 1 And Integer.Parse(Me.txt誕生月終了.Text) <= 12) Then
                    Call Sys_Error("誕生月 は1～12の半角数字で入力してください。　", Me.txt誕生月終了)
                    Exit Function
                End If
                If Integer.Parse(Me.txt誕生月開始.Text) > Integer.Parse(Me.txt誕生月終了.Text) Then
                    Call Sys_Error("誕生月（To） は誕生月（From）以降の日付を設定してください。　", Me.txt誕生月終了)
                    Exit Function
                End If

            Case 3    ' 年齢
                '年齢開始
                If String.IsNullOrEmpty(Me.txt年齢開始.Text) Then
                    Call Sys_Error("年齢 は必須入力です。　", Me.txt年齢開始)
                    Exit Function
                End If
                If Sys_Zenkaku(Me.txt年齢開始.Text) Then
                    Call Sys_Error("年齢 は半角で入力してください。　", Me.txt年齢開始)
                    Exit Function
                End If
                If (Sys_InputCheck(Me.txt年齢開始.Text, 3, "N+", 1)) Then
                    Call Sys_Error("年齢 は0～200で入力してください。　", Me.txt年齢開始)
                    Exit Function
                End If
                If Integer.Parse(Me.txt年齢開始.Text) < 0 Then
                    Call Sys_Error("年齢 は0以上を入力してください。　", Me.txt年齢開始)
                    Exit Function
                End If
                '年齢終了
                If String.IsNullOrEmpty(Me.txt年齢終了.Text) Then
                    Call Sys_Error("年齢 は必須入力です。　", Me.txt年齢終了)
                    Exit Function
                End If
                If Sys_Zenkaku(Me.txt年齢終了.Text) Then
                    Call Sys_Error("年齢 は半角で入力してください。　", Me.txt年齢終了)
                    Exit Function
                End If
                If (Sys_InputCheck(Me.txt年齢終了.Text, 3, "N+", 1)) Then
                    Call Sys_Error("年齢 は半角数字3文字以内で入力してください。　", Me.txt年齢終了)
                    Exit Function
                End If
                If Integer.Parse(Me.txt年齢終了.Text) < 0 Then
                    Call Sys_Error("年齢 は0以上を入力してください。　", Me.txt年齢終了)
                    Exit Function
                End If

                If Integer.Parse(Me.txt年齢開始.Text) > Integer.Parse(Me.txt年齢終了.Text) Then
                    Call Sys_Error("年齢（To） は年齢（From）以上の数値を入力してください。　", Me.txt年齢終了)
                    Exit Function
                End If

                Dim errMsg As String = Nothing
                If Not Sys_InputCheck_Date(Me.txt基準日.Text, errMsg) Then
                    Call Sys_Error("基準日 " & errMsg, Me.txt基準日)
                    Exit Function
                End If
                Me.txt基準日.Text = Format(DateTime.Parse(Me.txt基準日.Text), "yyyy/M/d")

                Try
                    Dim d基準日 As Date = Date.Parse(Me.txt基準日.Text)
                    Dim i年齢開始 As Integer = Integer.Parse(Me.txt年齢開始.Text) * -1
                    Dim i年齢終了 As Integer = (Integer.Parse(Me.txt年齢終了.Text) + 1) * -1
                    Dim s年齢開始 As Date
                    Dim s年齢終了 As Date
                    s年齢開始 = DateAdd("yyyy", i年齢開始, d基準日)
                    s年齢終了 = DateAdd("yyyy", i年齢終了, d基準日)

                    If s年齢開始 < 比較日 OrElse s年齢終了 < 比較日 Then
                        Call Sys_Error("生年月日が" & Min_Date & "以前となる検索は　" & Chr(13) & Chr(13) & "対応しておりません。　", Me.txt基準日)
                        Exit Function
                    End If
                Catch ex As Exception
                    Call Sys_Error("生年月日が" & Min_Date & "以前となる検索は　" & Chr(13) & Chr(13) & "対応しておりません。　", Me.txt基準日)
                    Exit Function
                End Try

            Case 4  ' メニュー''メニュー修正のためコメントアウトしました
                If menuCheck() = False Then
                    Call Sys_Error("商品 を選択してください。", Me.tvメニュー)
                    Exit Function
                End If

            Case 5 ' 来店回数
                '来店回数開始
                If String.IsNullOrEmpty(Me.txt来店回数開始.Text) Then
                    Call Sys_Error("来店回数 は必須入力です。　", Me.txt来店回数開始)
                    Exit Function
                End If
                If Sys_Zenkaku(Me.txt来店回数開始.Text) Then
                    Call Sys_Error("来店回数 は半角で入力してください。　", Me.txt来店回数開始)
                    Exit Function
                End If
                If (Sys_InputCheck(Me.txt来店回数開始.Text, 9, "N+", 1)) Then
                    Call Sys_Error("来店回数 は半角数字9文字以内で入力してください。　", Me.txt来店回数開始)
                    Exit Function
                End If
                '来店回数終了
                If String.IsNullOrEmpty(Me.txt来店回数終了.Text) Then
                    Call Sys_Error("来店回数 は必須入力です。　", Me.txt来店回数終了)
                    Exit Function
                End If
                If Sys_Zenkaku(Me.txt来店回数終了.Text) Then
                    Call Sys_Error("来店回数 は半角で入力してください。　", Me.txt来店回数終了)
                    Exit Function
                End If
                If (Sys_InputCheck(Me.txt来店回数終了.Text, 9, "N+", 1)) Then
                    Call Sys_Error("来店回数 は半角数字9文字以内で入力してください。　", Me.txt来店回数終了)
                    Exit Function
                End If

                If Integer.Parse(Me.txt来店回数開始.Text) > Integer.Parse(Me.txt来店回数終了.Text) Then
                    Call Sys_Error("来店回数（To） は来店回数（From）以上の数値を入力してください。　", Me.txt来店回数終了)
                    Exit Function
                End If

            Case 6 ' 区分売上

                '区分売上開始
                If String.IsNullOrEmpty(Me.txt区分売上開始.Text) Then
                    Call Sys_Error("売上金額 は必須入力です。　", Me.txt区分売上開始)
                    Exit Function
                End If
                If Sys_Zenkaku(Me.txt区分売上開始.Text) Then
                    Call Sys_Error("売上金額 は半角で入力してください。　", Me.txt区分売上開始)
                    Exit Function
                End If
                If (Sys_InputCheck(Me.txt区分売上開始.Text, 11, "N+", 1)) Then
                    Call Sys_Error("売上金額 は半角数字11文字以内で入力してください。　", Me.txt区分売上開始)
                    Exit Function
                End If

                '区分売上終了
                If String.IsNullOrEmpty(Me.txt区分売上終了.Text) Then
                    Call Sys_Error("売上金額 は必須入力です。　", Me.txt区分売上終了)
                    Exit Function
                End If
                If Sys_Zenkaku(Me.txt区分売上終了.Text) Then
                    Call Sys_Error("売上金額 は半角で入力してください。　", Me.txt区分売上終了)
                    Exit Function
                End If
                If (Sys_InputCheck(Me.txt区分売上終了.Text, 11, "N+", 1)) Then
                    Call Sys_Error("売上金額 は半角数字11文字以内で入力してください。　", Me.txt区分売上終了)
                    Exit Function
                End If

                If (Double.Parse(smoney) > Double.Parse(lmoney)) Then
                    Call Sys_Error("売上金額（To） は売上金額（From）以上の数値を入力してください。　", Me.txt区分売上終了)
                    Exit Function
                End If

                '期間開始
                Dim errMsg As String = Nothing
                If Not Sys_InputCheck_Date(Me.txt区分売上期間開始.Text, errMsg) Then
                    Call Sys_Error("期間（From） " & errMsg, Me.txt区分売上期間開始)
                    Exit Function
                End If
                Me.txt区分売上期間開始.Text = Format(DateTime.Parse(Me.txt区分売上期間開始.Text), "yyyy/M/d")

                '期間終了
                If Not Sys_InputCheck_Date(Me.txt区分売上期間終了.Text, errMsg) Then
                    Call Sys_Error("期間（To） " & errMsg, Me.txt区分売上期間終了)
                    Exit Function
                End If
                Me.txt区分売上期間終了.Text = Format(DateTime.Parse(Me.txt区分売上期間終了.Text), "yyyy/M/d")

                If DateTime.Parse(Me.txt区分売上期間開始.Text) > DateTime.Parse(Me.txt区分売上期間終了.Text) Then
                    Call Sys_Error("期間（To） は期間（From）以降の日付を設定してください。　", Me.txt区分売上期間終了)
                    Exit Function
                End If

            Case 7     ' 主担当
                If Me.cmb主担当者番号.Text = "" Then
                    Call Sys_Error("主担当者 を選択してください。　", Me.cmb主担当者番号)
                    Exit Function
                End If

            Case 8    ' 最終来店日
                '最終来店日開始
                Dim errMsg As String = Nothing
                If Not Sys_InputCheck_Date(Me.txt最終来店日開始.Text, errMsg) Then
                    Call Sys_Error("最終来店日（From） " & errMsg, Me.txt最終来店日開始)
                    Exit Function
                End If
                Me.txt最終来店日開始.Text = Format(DateTime.Parse(Me.txt最終来店日開始.Text), "yyyy/M/d")

                '最終来店日終了
                If Not Sys_InputCheck_Date(Me.txt最終来店日終了.Text, errMsg) Then
                    Call Sys_Error("最終来店日（To） " & errMsg, Me.txt最終来店日終了)
                    Exit Function
                End If
                Me.txt最終来店日終了.Text = Format(DateTime.Parse(Me.txt最終来店日終了.Text), "yyyy/M/d")

                If DateTime.Parse(Me.txt最終来店日開始.Text) > DateTime.Parse(Me.txt最終来店日終了.Text) Then
                    Call Sys_Error("最終来店日（To） は最終来店日（From）以降の日付を設定してください。　", Me.txt最終来店日終了)
                    Exit Function
                End If

            Case 9     'サービス
                If Me.cmbサービス一覧.Items.Count < 1 Then
                    Call Sys_Error("サービスが未登録です。　", Me.cmbサービス一覧)
                    Exit Function
                End If

                If String.IsNullOrEmpty(Me.cmbサービス一覧.Text) Then
                    Call Sys_Error("サービスを選択してください。　", Me.cmbサービス一覧)
                    Exit Function
                End If

                'サービス開始
                Dim errMsg As String = Nothing
                If Not Sys_InputCheck_Date(Me.txtサービス開始.Text, errMsg) Then
                    Call Sys_Error("期間（From） " & errMsg, Me.txtサービス開始)
                    Exit Function
                End If
                Try
                    Me.txtサービス開始.Text = Format(DateTime.Parse(Me.txtサービス開始.Text), "yyyy/M/d")
                Catch ex As Exception
                    Call Sys_Error("日付が不正です。　", Me.txtサービス開始)
                    Exit Function
                End Try

                'サービス終了
                If Not Sys_InputCheck_Date(Me.txtサービス終了.Text, errMsg) Then
                    Call Sys_Error("期間（To） " & errMsg, Me.txtサービス終了)
                    Exit Function
                End If
                Try
                    Me.txtサービス終了.Text = Format(DateTime.Parse(Me.txtサービス終了.Text), "yyyy/M/d")
                Catch ex As Exception
                    Call Sys_Error("日付が不正です。　", Me.txtサービス終了)
                    Exit Function
                End Try

                If DateTime.Parse(Me.txtサービス開始.Text) > DateTime.Parse(Me.txtサービス終了.Text) Then
                    Call Sys_Error("期間（To） は期間（From）以降の日付を設定してください。　", Me.txtサービス終了)
                    Exit Function
                End If
        End Select

        input_check = True
        count.Stop()
    End Function
#End Region

    Private Sub init()
        treeNode_sd = tvメニュー.Nodes.Add("全て") '親ルートノード

        Dim dt_division, dt_group, dt_item As DataTable
        Dim param As New Habits.DB.DBParameter
        Dim i As Integer 'ループ用(売上区分)
        Dim h As Integer 'ループ用(分類名)
        Dim j As Integer 'ループ用(商品名)
        dt_division = logic.get_saleDivision()
        If dt_division.Rows.Count <> 0 Then
            i = 0
            While i < dt_division.Rows.Count
                treeNode_sd.Nodes.Add(dt_division.Rows(i)("売上区分").ToString)
                param.Add("売上区分番号", dt_division.Rows(i)("売上区分番号"))
                dt_group = logic.get_group(param)
                param.Clear()
                If dt_group.Rows.Count <> 0 Then
                    h = 0
                    While h < dt_group.Rows.Count
                        Node1 = treeNode_sd.Nodes(i)
                        Node1.Nodes.Add(dt_group.Rows(h)("分類名").ToString)
                        param.Add("売上区分番号", dt_division.Rows(i)("売上区分番号"))
                        param.Add("分類番号", dt_group.Rows(h)("分類番号"))
                        param.Add("削除フラグ", 0)
                        dt_item = logic.get_itemname(param)
                        param.Clear()
                        If dt_item.Rows.Count <> 0 Then
                            j = 0
                            While j < dt_item.Rows.Count
                                Node2 = Node1.Nodes(h)
                                Node2.Nodes.Add(dt_item.Rows(j)("商品名").ToString)
                                j += 1
                            End While
                        End If
                        h += 1
                    End While
                End If
                i += 1
            End While
        End If
    End Sub

#Region "新規絞込・追加"
    ''' <summary>新規絞込・追加</summary>
    ''' <remarks></remarks>
    Private Sub select_新規絞込_追加()
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        Dim iCount As Integer

        Select Case Me.tcCondition.SelectedIndex
            Case 0    ' 性別
                param.Clear()
                param.Add("@性別番号", Me.cmb性別番号.Text)
                iCount = logic.insert_W_顧客抽出(Me.tcCondition.SelectedIndex, param)
                Call set_性別()

            Case 1    ' 生年月日
                param.Clear()
                param.Add("@生年月日開始", Me.txt生年月日開始.Text)
                param.Add("@生年月日終了", Me.txt生年月日終了.Text)
                iCount = logic.insert_W_顧客抽出(Me.tcCondition.SelectedIndex, param)
                Call set_生年月日()

            Case 2    ' 誕生月
                param.Clear()
                param.Add("@誕生月開始", Me.txt誕生月開始.Text)
                param.Add("@誕生月終了", Me.txt誕生月終了.Text)
                iCount = logic.insert_W_顧客抽出(Me.tcCondition.SelectedIndex, param)
                Call set_誕生月()

            Case 3    ' 年齢
                param.Clear()
                Dim i年齢開始 As Integer = Integer.Parse(Me.txt年齢開始.Text) * -1
                Dim i年齢終了 As Integer = (Integer.Parse(Me.txt年齢終了.Text) + 1) * -1
                Dim d基準日 As Date = Date.Parse(Me.txt基準日.Text)
                Dim s年齢開始 As String
                Dim s年齢終了 As String
                param.Add("@基準日", Me.txt基準日.Text)
                s年齢開始 = DateAdd("yyyy", i年齢開始, d基準日).ToString
                s年齢終了 = DateAdd("yyyy", i年齢終了, d基準日).ToString

                param.Add("@年齢開始", s年齢開始)
                param.Add("@年齢終了", s年齢終了)
                iCount = logic.insert_W_顧客抽出(Me.tcCondition.SelectedIndex, param)
                Call set_年齢()

            Case 4    ' メニュー
                param.Clear()
                Cursor.Current = Windows.Forms.Cursors.WaitCursor
                Call send_number(0)
                Cursor.Current = Windows.Forms.Cursors.Default
                Call set_メニュー()

            Case 5 ' 来店回数
                param.Clear()
                param.Add("@来店回数開始", Me.txt来店回数開始.Text)
                param.Add("@来店回数終了", Me.txt来店回数終了.Text)
                iCount = logic.insert_W_顧客抽出(Me.tcCondition.SelectedIndex, param)
                Call set_来店回数()

            Case 6    ' 区分売上
                param.Clear()
                param.Add("@売上区分番号", Me.cmb区分.SelectedValue.ToString)
                param.Add("@区分売上開始", smoney)
                param.Add("@区分売上終了", lmoney)
                param.Add("@区分売上期間開始", Me.txt区分売上期間開始.Text)
                param.Add("@区分売上期間終了", Me.txt区分売上期間終了.Text)
                iCount = logic.insert_W_顧客抽出(Me.tcCondition.SelectedIndex, param)
                Call set_区分売上()

            Case 7 ' 主担当
                param.Clear()
                If Me.chk指名.Checked = False Then
                    param.Add("主担当者番号", Me.cmb主担当者番号.SelectedValue)
                    param.Add("指名", 0)
                Else
                    param.Add("主担当者番号", Me.cmb主担当者番号.SelectedValue)
                    param.Add("指名", 1)
                End If
                iCount = logic.insert_W_顧客抽出(Me.tcCondition.SelectedIndex, param)
                Call set_主担当()

            Case 8   ' 最終来店日
                param.Clear()
                param.Add("@最終来店日開始", Me.txt最終来店日開始.Text)
                param.Add("@最終来店日終了", Me.txt最終来店日終了.Text)
                iCount = logic.insert_W_顧客抽出(Me.tcCondition.SelectedIndex, param)
                Call set_最終来店日()

            Case 9 'サービス
                param.Clear()
                param.Add("@サービス名", Me.cmbサービス一覧.Text)
                param.Add("@サービス開始", Me.txtサービス開始.Text)
                param.Add("@サービス終了", Me.txtサービス終了.Text)
                iCount = logic.insert_W_顧客抽出(Me.tcCondition.SelectedIndex, param)
                Call set_サービス()

        End Select
        dt = logic.件数カウント用()
        Me.lbl抽出件数.Text = dt.Rows.Count.ToString
    End Sub
#End Region

    ''' <summary>メニュー用チェック</summary>
    ''' <remarks>商品のチェックボックスに一つもチェックが無かった場合、Falseを返す</remarks>
    Private Function menuCheck() As Boolean
        Dim dt_division, dt_group, dt_item As DataTable
        Dim param As New Habits.DB.DBParameter
        Dim i As Integer
        Dim h As Integer
        Dim j As Integer
        Dim node As New System.Windows.Forms.TreeNode
        dt_division = logic.get_saleDivision()
        param.Clear()
        If dt_division.Rows.Count <> 0 Then
            i = 0
            While i < dt_division.Rows.Count
                param.Add("売上区分番号", dt_division.Rows(i)("売上区分番号"))
                dt_group = logic.get_group(param)
                param.Clear()
                If dt_group.Rows.Count <> 0 Then
                    h = 0
                    While h < dt_group.Rows.Count
                        param.Add("売上区分番号", dt_division.Rows(i)("売上区分番号"))
                        param.Add("分類番号", dt_group.Rows(h)(0))
                        param.Add("削除フラグ", 0)
                        dt_item = logic.get_itemname(param)
                        param.Clear()
                        If dt_item.Rows.Count <> 0 Then
                            j = 0
                            While j < dt_item.Rows.Count
                                node = GetNodeFormPosision(Me.treeNode_sd.Nodes, i, h, j)
                                If node.Checked Then
                                    Return True
                                End If
                                j += 1
                            End While
                        End If
                        h += 1
                    End While
                End If
                i += 1
            End While
        End If
        Return False
    End Function

    ''' <summary>メニューのノード取得</summary>
    ''' <param name="Nodes">ノード</param>
    ''' <param name="Indexes">ノードの位置</param>
    ''' <remarks>menuCheckでチェックされているnodeを位置から得てそのnodeを返す(nodeのテキスト,チェックの有無を得るため）</remarks>
    Private Function GetNodeFormPosision(ByVal Nodes As System.Windows.Forms.TreeNodeCollection, ByVal ParamArray Indexes() As Integer) As System.Windows.Forms.TreeNode
        Dim i As Integer
        Dim Node As System.Windows.Forms.TreeNode

        Node = Nodes(Indexes(0))
        For i = 1 To Indexes.Length - 1
            Node = Node.Nodes(Indexes(i))
        Next

        Return Node
    End Function

    Private Sub send_number(ByVal modenum As Integer)
        Dim dt_division, dt_group, dt_item As DataTable
        Dim dt_set As New DataTable
        Dim dt As DataTable
        Dim param As New Habits.DB.DBParameter
        Dim i As Integer
        Dim h As Integer
        Dim j As Integer

        Dim node As New System.Windows.Forms.TreeNode
        dt_division = logic.get_saleDivision()
        param.Clear()

        If dt_division.Rows.Count <> 0 Then
            For i = 0 To dt_division.Rows.Count - 1

                param.Add("売上区分番号", dt_division.Rows(i)("売上区分番号"))
                dt_group = logic.get_group(param)
                param.Clear()

                If dt_group.Rows.Count <> 0 Then
                    For h = 0 To dt_group.Rows.Count - 1
                        param.Add("売上区分番号", dt_division.Rows(i)("売上区分番号"))
                        param.Add("分類番号", dt_group.Rows(h)(0))
                        param.Add("削除フラグ", 0)
                        dt_item = logic.get_itemname(param)
                        param.Clear()

                        If dt_item.Rows.Count <> 0 Then
                            For j = 0 To dt_item.Rows.Count - 1
                                node = GetNodeFormPosision(Me.treeNode_sd.Nodes, i, h, j)
                                If node.Checked Then
                                    If modenum = 0 Then ''新規
                                        param.Clear()
                                        param.Add("売上区分番号", dt_division.Rows(i)("売上区分番号"))
                                        param.Add("分類番号", dt_group.Rows(h)(0))
                                        param.Add("削除フラグ", 0)
                                        param.Add("商品名", node.Text)
                                        dt = logic.get_iteminfo(param)

                                        param.Clear()
                                        param.Add("売上区分番号", dt_item.Rows(0)(2))
                                        param.Add("分類番号", dt_item.Rows(0)(3))
                                        param.Add("@商品番号", dt.Rows(0).Item("商品番号"))
                                        logic.insert_W_顧客抽出(Me.tcCondition.SelectedIndex, param)
                                        param.Clear()

                                    ElseIf modenum = 1 Then ''追加
                                        param.Clear()
                                        param.Add("売上区分番号", dt_item.Rows(0)(2))
                                        param.Add("分類番号", dt_item.Rows(0)(3))
                                        param.Add("@商品番号", dt_item.Rows(0)(1))

                                        logic.insert_W_顧客抽出(Me.tcCondition.SelectedIndex, param)
                                        param.Clear()
                                    End If
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If
    End Sub

#End Region

    Private Sub tvメニュー_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvメニュー.AfterCheck
        If e.Action <> Windows.Forms.TreeViewAction.Unknown Then
            If e.Node.Nodes.Count > 0 Then
                Me.CheckAllChildNodes(e.Node, e.Node.Checked)
            End If
        End If
    End Sub

    Private Sub CheckAllChildNodes(ByVal treeNode As Windows.Forms.TreeNode, ByVal nodeChecked As Boolean)
        Dim node As Windows.Forms.TreeNode
        For Each node In treeNode.Nodes
            node.Checked = nodeChecked
            If node.Nodes.Count > 0 Then
                Me.CheckAllChildNodes(node, nodeChecked)
            End If
        Next node
    End Sub

#Region "バリデート処理"
    ''' <summary>
    ''' 区分売上の売上金額（From）入力チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 区分売上開始_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt区分売上開始.Validated
        Me.txt区分売上開始.Text = Trim(Me.txt区分売上開始.Text)
        If Me.txt区分売上開始.Text <> Nothing Then
            smoney = Replace(Me.txt区分売上開始.Text, ",", "")
            If IsNumeric(smoney) Then
                w_smoney = Double.Parse(smoney)
                Me.txt区分売上開始.Text = Format(w_smoney, "#,##0")
                RemoveHandler txt区分売上開始.Validated, AddressOf 区分売上開始_Validated
                AddHandler txt区分売上開始.Validated, AddressOf 区分売上開始_Validated
            Else
                Call Sys_Error("金額が不正です。　", Me.txt区分売上開始)
                Me.txt区分売上開始.Text = Nothing
                smoney = Nothing
            End If
        Else
            Me.txt区分売上終了.Focus()
        End If
    End Sub

    ''' <summary>
    ''' 区分売上の売上金額（To）入力チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 区分売上終了_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt区分売上終了.Validated
        Me.txt区分売上終了.Text = Trim(Me.txt区分売上終了.Text)
        If Me.txt区分売上終了.Text <> Nothing Then
            lmoney = Replace(Me.txt区分売上終了.Text, ",", "")
            If IsNumeric(lmoney) Then
                w_lmoney = Double.Parse(lmoney)
                Me.txt区分売上終了.Text = Format(w_lmoney, "#,##0")
                RemoveHandler txt区分売上終了.Validated, AddressOf 区分売上終了_Validated
                AddHandler txt区分売上終了.Validated, AddressOf 区分売上終了_Validated
            Else
                Call Sys_Error("金額が不正です。　", Me.txt区分売上終了)
                Me.txt区分売上終了.Text = Nothing
                lmoney = Nothing
            End If
        Else
            Me.txt区分売上期間開始.Focus()
        End If
    End Sub

#End Region

End Class