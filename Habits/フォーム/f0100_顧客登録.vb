''' <summary>f0100_顧客登録者画面処理</summary>
''' <remarks></remarks>
Public Class f0100_顧客登録

    Private logic As Habits.Logic.f0100_Logic                      '' ロジッククラス　
    Private yomiNewLastName As ImeComposition.ImeYomiConversion    '' 新規姓の読みを取得
    Private yomiNewFirstName As ImeComposition.ImeYomiConversion   '' 新規名の読みを取得

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0100_顧客登録_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        logic = New Habits.Logic.f0100_Logic
        yomiNewLastName = New ImeComposition.ImeYomiConversion(Me.姓, Me.姓カナ, True)
        yomiNewFirstName = New ImeComposition.ImeYomiConversion(Me.名, Me.名カナ, True)
        Dim dt As New DataTable

        dt = logic.select_登録区分()
        Me.登録区分番号.DataSource = dt
        Me.登録区分番号.DisplayMember = "登録区分"
        Me.登録区分番号.ValueMember = "登録区分番号"

        dt = logic.select_sex()
        Me.性別番号.DataSource = dt
        Me.性別番号.DisplayMember = "性別"
        Me.性別番号.ValueMember = "性別番号"

        dt = logic.select_主担当者()
        Me.主担当者.DataSource = dt
        Me.主担当者.DisplayMember = "担当者名"
        Me.主担当者.ValueMember = "担当者番号"

        format()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0100_顧客登録_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "登録ボタン押下"
    ''' <summary>登録ボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 登録.Click ''D_顧客テーブルにインサート
        If Not (input_check()) Then Exit Sub
        If (MsgBox(Me.姓.Text & " 様を登録しますか？　", Clng_Ynqub1, TTL) = vbYes) Then
            Dim dt As New Integer
            Dim param As New Habits.DB.DBParameter
            param.Add("@顧客番号", Me.lbl顧客番号.Text)
            param.Add("@姓", Me.姓.Text)
            param.Add("@姓カナ", Me.姓カナ.Text)
            param.Add("@名", Me.名.Text)
            param.Add("@名カナ", Me.名カナ.Text)
            param.Add("@性別番号", Me.性別番号.SelectedValue)
            param.Add("@生年月日", IIf(IsDate(Me.lbl生年月日.Text), Me.lbl生年月日.Text, System.DBNull.Value))
            If (Sys_Len(Me.郵便番号.Text) = 8) Then
                param.Add("@郵便番号", Me.郵便番号.Text)
            Else
                param.Add("@郵便番号", Mid(Me.郵便番号.Text, 1, 3) & "-" & Mid(Me.郵便番号.Text, 4, 4))
            End If
            param.Add("@都道府県", Me.都道府県.Text)
            param.Add("@住所1", Me.住所１.Text)
            param.Add("@住所2", Me.住所２.Text)
            param.Add("@住所3", Me.住所３.Text)
            param.Add("@電話番号", Me.電話番号.Text)
            param.Add("@アドレス", Me.メールアドレス.Text)
            param.Add("@家族名", Me.家族名.Text)
            param.Add("@趣味", Me.趣味.Text)
            param.Add("@好きな話題", Me.好きな話題.Text)
            param.Add("@嫌いな話題", Me.嫌いな話題.Text)
            param.Add("@伝言フラグ", 0)
            param.Add("@メモ", Me.メモ.Text)
            param.Add("@紹介者", Me.紹介者.Text)
            param.Add("@前回来店日", System.DBNull.Value)
            param.Add("@来店日1", System.DBNull.Value)
            param.Add("@来店日2", System.DBNull.Value)
            param.Add("@来店回数", 0)
            param.Add("@主担当者番号", Me.主担当者.SelectedValue)
            param.Add("@登録区分番号", Me.登録区分番号.SelectedValue)
            param.Add("@登録日", Now())
            param.Add("@更新日", Now)

            dt = logic.insert_customer_infomation(param)
            format()
        End If
    End Sub
#End Region

#Region "郵便番号検索ボタン押下"
    ''' <summary>郵便番号検索ボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 郵便番号検索_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 郵便番号検索.Click
        z_0600_郵便番号検索.z_0600_郵便番号検索_loaded = 2 ''郵便番号検索画面での場合分け
        z_0600_郵便番号検索.ShowDialog()
        Me.郵便番号.Focus()
        Me.TabControl1.SelectedIndex = 0
    End Sub
#End Region

#Region "空番号ボタン押下"
    ''' <summary>空番号ボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 空番_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 空番.Click
        z_0200_空番号選択.ShowDialog()
        Me.姓.Focus()
        Me.TabControl1.SelectedIndex = 0
    End Sub
#End Region

#Region "項目クリアボタン押下"
    ''' <summary>項目クリアボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub クリア_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles クリア.Click
        format()
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

#End Region

#Region "Enter押下イベント"

    Private Sub 姓_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles 姓.Enter
        yomiNewLastName.Enabled = True
    End Sub

    Private Sub 名_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles 名.Enter
        yomiNewFirstName.Enabled = True
    End Sub
    Private Sub 姓_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 姓.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.姓カナ.Focus()
        End If
    End Sub

    Private Sub 姓カナ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 姓カナ.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.名.Focus()
        End If
    End Sub

    Private Sub 名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 名.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.名カナ.Focus()
        End If
    End Sub

    Private Sub 名カナ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 名カナ.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.TabControl1.Focus()
        End If
    End Sub

    Private Sub 郵便番号_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 郵便番号.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.都道府県.Focus()
        End If
    End Sub

    Private Sub 都道府県_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 都道府県.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.住所１.Focus()
        End If
    End Sub

    Private Sub 住所１_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 住所１.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.住所２.Focus()
        End If
    End Sub
    Private Sub 住所２_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 住所２.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.住所３.Focus()
        End If
    End Sub

    Private Sub 住所３_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 住所３.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.電話番号.Focus()
        End If
    End Sub

    Private Sub 電話番号_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 電話番号.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.メールアドレス.Focus()
        End If
    End Sub

    Private Sub メールアドレス_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles メールアドレス.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.登録区分番号.Focus()
        End If
    End Sub

    Private Sub 性別番号_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 性別番号.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.家族名.Focus()
        End If
    End Sub

    Private Sub 紹介者_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 紹介者.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.主担当者.Focus()
        End If
    End Sub

    Private Sub 家族名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 家族名.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.趣味.Focus()
        End If
    End Sub

    Private Sub 登録区分番号_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 登録区分番号.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.登録.Focus()
        End If
    End Sub

    Private Sub 主担当者_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 主担当者.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.登録.Focus()
        End If
    End Sub

    Private Sub 元号生年月日_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 元号生年月日.KeyDown
        If (e.KeyData.Equals(System.Windows.Forms.Keys.Enter)) Then
            setBirthday()
        End If
    End Sub

#End Region

#Region "テキスト変更イベント"
    Private Sub 姓_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 姓.TextChanged
        If (Len(Me.姓.Text & "") = 0) Then
            Me.登録.Enabled = False
            Me.姓カナ.Text = ""
        Else
            Me.登録.Enabled = True
        End If
    End Sub

    Private Sub 名_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 名.TextChanged
        If (Len(Me.名.Text & "") = 0) Then
            Me.名カナ.Text = ""
        End If
    End Sub

    Private Sub 郵便番号_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 郵便番号.TextChanged
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        Dim str_num As String
        param.Clear()
        If (Me.郵便番号.TextLength = 0) Then
            Me.都道府県.Text = ""
            Me.住所１.Text = ""
            Me.住所２.Text = ""

        ElseIf (Me.郵便番号.TextLength = 3) Then
            str_num = Me.郵便番号.Text
            param.Add("新郵便番号表示用", str_num & "%")
            dt = logic.select_placename(param)
            If (dt.Rows.Count > 0) Then
                Me.都道府県.Text = dt.Rows(0)("都道府県名").ToString
            Else
                Me.都道府県.Text = ""
            End If
            Me.住所１.Text = ""
            Me.住所２.Text = ""

        ElseIf (Me.郵便番号.TextLength = 7) Then
            str_num = Mid(Me.郵便番号.Text, 1, 3) & "-" & Mid(Me.郵便番号.Text, 4, 4)
            param.Add("新郵便番号表示用", str_num & "%")
            dt = logic.select_placename(param)
            If (dt.Rows.Count > 0) Then
                Me.都道府県.Text = dt.Rows(0)("都道府県名").ToString
                Me.住所１.Text = dt.Rows(0)("市区町村名").ToString
                Me.住所２.Text = dt.Rows(0)("町域名").ToString
                param.Clear()
            Else
                Me.都道府県.Text = ""
                Me.住所１.Text = ""
                Me.住所２.Text = ""
            End If

        ElseIf (Me.郵便番号.TextLength = 8) Then
            str_num = Me.郵便番号.Text
            param.Add("新郵便番号表示用", str_num & "%")
            dt = logic.select_placename(param)
            If (dt.Rows.Count > 0) Then
                Me.都道府県.Text = dt.Rows(0)("都道府県名").ToString
                Me.住所１.Text = dt.Rows(0)("市区町村名").ToString
                Me.住所２.Text = dt.Rows(0)("町域名").ToString
                param.Clear()
            Else
                Me.都道府県.Text = ""
                Me.住所１.Text = ""
                Me.住所２.Text = ""
            End If
        End If
    End Sub

    Private Sub 住所２_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 住所２.TextChanged
        Dim select_postnumber As New DataTable
        Dim param As New Habits.DB.DBParameter
        Dim logic As New Habits.Logic.z0500_Logic
        param.Add("都道府県名", Me.都道府県.Text)
        param.Add("市区町村名", Me.住所１.Text)
        param.Add("町域名", Me.住所２.Text)
        select_postnumber = logic.select_postnumber(param)
        If (select_postnumber.Rows.Count > 0) Then
            Me.郵便番号.Text = select_postnumber.Rows(0)("新郵便番号表示用").ToString
        End If
        param.Clear()
    End Sub

    Private Sub 元号生年月日_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 元号生年月日.TextChanged
        If (Me.元号生年月日.Text.Length = 0) Then
            Me.lbl生年月日.Text = ""
        End If
    End Sub

#End Region

    Private Sub 元号生年月日_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 元号生年月日.Leave
        setBirthday()
    End Sub

#Region "メソッド"
    ''' <summary>入力チェック</summary>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        Dim str_date As String
        input_check = False

        Me.姓.Text = Trim(Me.姓.Text)
        If String.IsNullOrEmpty(Me.姓.Text) Then
            Call Sys_Error("姓 は必須入力です。　", Me.姓)
            Exit Function
        End If
        If (Sys_InputCheck(Me.姓.Text, 16, "M", 1)) Then
            Call Sys_Error("姓 は16文字以内で入力してください。　", Me.姓)
            Exit Function
        End If

        Me.姓カナ.Text = Trim(Me.姓カナ.Text)
        If String.IsNullOrEmpty(Me.姓カナ.Text) Then
            Call Sys_Error("姓カナ は必須入力です。　", Me.姓カナ)
            Exit Function
        End If
        If Sys_Zenkaku(Me.姓カナ.Text) Then
            Call Sys_Error("姓カナ は半角で入力してください。　", Me.姓カナ)
            Exit Function
        End If
        If (Sys_InputCheck(Me.姓カナ.Text, 32, "A", 1)) Then
            Call Sys_Error("姓カナ は半角32文字以内で入力してください。　", Me.姓カナ)
            Exit Function
        End If

        Me.名.Text = Trim(Me.名.Text)
        If (Sys_InputCheck(Me.名.Text, 16, "M", 0)) Then
            Call Sys_Error("名 は16文字以内で入力してください。　", Me.名)
            Exit Function
        End If

        Me.名カナ.Text = Trim(Me.名カナ.Text)
        If Sys_Zenkaku(Me.名カナ.Text) Then
            Call Sys_Error("名カナ は半角で入力してください。　", Me.名カナ)
            Exit Function
        End If
        If (Sys_InputCheck(Me.名カナ.Text, 32, "A", 0)) Then
            Call Sys_Error("名カナ は半角32文字以内で入力してください。　", Me.名カナ)
            Exit Function
        End If

        If Not String.IsNullOrEmpty(Me.名.Text) AndAlso String.IsNullOrEmpty(Me.名カナ.Text) Then
            Call Sys_Error("名カナ を入力してください。　", Me.名カナ)
            Exit Function
        ElseIf String.IsNullOrEmpty(Me.名.Text) AndAlso Not String.IsNullOrEmpty(名カナ.Text) Then
            Call Sys_Error("名 を入力してください。　", Me.名)
            Exit Function
        End If

        Me.郵便番号.Text = Trim(Me.郵便番号.Text)
        If Not Me.郵便番号.Text = Nothing Then
            If Sys_Zenkaku(Me.郵便番号.Text) Then
                Call Sys_Error("郵便番号 は半角で入力してください。", Me.郵便番号)
                Exit Function
            End If
            If Sys_InputCheck(Me.郵便番号.Text, 8, "A", 1) Then
                Call Sys_Error("郵便番号 はハイフンあり半角8文字で入力してください。　", Me.郵便番号)
                Exit Function
            End If

            If Me.郵便番号.TextLength <= 7 Then
                Call Sys_Error("郵便番号 はハイフンあり半角8文字で入力してください。　", Me.郵便番号)
                Exit Function
            End If
            If Mid(Me.郵便番号.Text, 4, 1) <> "-" Then
                Call Sys_Error("郵便番号 はハイフンあり半角8文字で入力してください。　", Me.郵便番号)
                Exit Function
            End If

            If Sys_InputCheck(Mid(Me.郵便番号.Text, 1, 3), 3, "N+", 1) Then
                Call Sys_Error("郵便番号 はハイフンあり半角8文字で入力してください。　", Me.郵便番号)
                Exit Function
            End If
            If Sys_InputCheck(Mid(Me.郵便番号.Text, 5, 8), 4, "N+", 1) Then
                Call Sys_Error("郵便番号 はハイフンあり半角8文字で入力してください。　", Me.郵便番号)
                Exit Function
            End If
        End If

        If (Sys_InputCheck(Me.都道府県.Text, 8, "K", 0)) Then
            Call Sys_Error("都道府県 は全角8文字以内で入力してください。　", Me.都道府県)
            Exit Function
        End If

        If (Sys_InputCheck(Me.住所１.Text, 64, "M", 0)) Then
            Call Sys_Error("市区町村 は64文字以内で入力してください。　", Me.住所１)
            Exit Function
        End If

        If (Sys_InputCheck(Me.住所２.Text, 64, "M", 0)) Then
            Call Sys_Error("町域 は64文字以内で入力してください。　", Me.住所２)
            Exit Function
        End If

        If (Sys_InputCheck(Me.住所３.Text, 64, "M", 0)) Then
            Call Sys_Error("番地・建物等 は64文字以内で入力してください。　", Me.住所３)
            Exit Function
        End If

        ' 論理チェック（住所）
        If (String.IsNullOrEmpty(Me.郵便番号.Text) OrElse _
            String.IsNullOrEmpty(Me.都道府県.Text) OrElse _
            String.IsNullOrEmpty(Me.住所１.Text) OrElse _
            String.IsNullOrEmpty(Me.住所２.Text) OrElse _
            String.IsNullOrEmpty(Me.住所３.Text)) _
        AndAlso (Not String.IsNullOrEmpty(Me.郵便番号.Text) OrElse _
            Not String.IsNullOrEmpty(Me.都道府県.Text) OrElse _
            Not String.IsNullOrEmpty(Me.住所１.Text) OrElse _
            Not String.IsNullOrEmpty(Me.住所２.Text) OrElse _
            Not String.IsNullOrEmpty(Me.住所３.Text)) Then

            Select Case True
                Case String.IsNullOrEmpty(Me.郵便番号.Text)
                    Call Sys_Error("郵便番号 を入力してください。　", Me.郵便番号)
                Case String.IsNullOrEmpty(Me.都道府県.Text)
                    Call Sys_Error("都道府県 を入力してください。　", Me.都道府県)
                Case String.IsNullOrEmpty(Me.住所１.Text)
                    Call Sys_Error("市区町村 を入力してください。　", Me.住所１)
                Case String.IsNullOrEmpty(Me.住所２.Text)
                    Call Sys_Error("町域 を入力してください。　", Me.住所２)
                Case Else
                    Call Sys_Error("番地・建物等 を入力してください。　", Me.住所３)
            End Select
            Exit Function
        End If

        Me.電話番号.Text = Trim(Me.電話番号.Text)
        If Sys_Zenkaku(Me.電話番号.Text) Then
            Call Sys_Error("電話番号 は半角で入力してください。　", Me.電話番号)
            Exit Function
        End If
        If (Sys_InputCheck(Me.電話番号.Text, 19, "A", 0)) Then
            Call Sys_Error("電話番号 は半角19文字以内で入力してください。　", Me.電話番号)
            Exit Function
        End If

        Me.メールアドレス.Text = Trim(Me.メールアドレス.Text)
        If Sys_Zenkaku(Me.メールアドレス.Text) Then
            Call Sys_Error("E-mailアドレス は半角で入力してください。　", Me.メールアドレス)
            Exit Function
        End If
        If (Sys_InputCheck(Me.メールアドレス.Text, 256, "A", 0)) Then
            Call Sys_Error("E-mailアドレス は半角英数字256文字以内で入力してください。　", Me.メールアドレス)
            Exit Function
        End If

        Me.lbl生年月日.Text = Trim(Me.lbl生年月日.Text)
        If Sys_Zenkaku(Me.lbl生年月日.Text) Then
            Call Sys_Error("生年月日 は半角で入力してください。　", Me.lbl生年月日)
            Exit Function
        End If
        If (Sys_InputCheck(Me.lbl生年月日.Text, 7, "D", 0)) Then
            Call Sys_Error("生年月日 が不正です。　", Me.lbl生年月日)
            Exit Function
        End If
        If Not Me.lbl生年月日.Text = Nothing Then
            str_date = Mid(Me.lbl生年月日.Text, 1, 2)
            If Integer.Parse(str_date) < 18 Then
                Call Sys_Error("生年月日 が不正です。　", Me.lbl生年月日)
                Exit Function
            End If
        End If

        Me.家族名.Text = Trim(Me.家族名.Text)
        If (Sys_InputCheck(Me.家族名.Text, 32, "M", 0)) Then
            Call Sys_Error("家族名 は32文字以内で入力してください。　", Me.家族名)
            Exit Function
        End If

        Me.趣味.Text = Trim(Me.趣味.Text)
        If (Sys_InputCheck(Me.趣味.Text, 32, "M", 0)) Then
            Call Sys_Error("趣味 は32文字以内で入力してください。　", Me.趣味)
            Exit Function
        End If

        Me.好きな話題.Text = Trim(Me.好きな話題.Text)
        If (Sys_InputCheck(Me.好きな話題.Text, 32, "M", 0)) Then
            Call Sys_Error("好きな話題 は32文字以内で入力してください。　", Me.好きな話題)
            Exit Function
        End If

        Me.嫌いな話題.Text = Trim(Me.嫌いな話題.Text)
        If (Sys_InputCheck(Me.嫌いな話題.Text, 32, "M", 0)) Then
            Call Sys_Error("嫌いな話題 は32文字以内で入力してください。　", Me.嫌いな話題)
            Exit Function
        End If

        Me.メモ.Text = Trim(Me.メモ.Text)
        If (Sys_InputCheck(Me.メモ.Text, 32, "M", 0)) Then
            Call Sys_Error("メモ は32文字以内で入力してください。　", Me.メモ)
            Exit Function
        End If

        Me.紹介者.Text = Trim(Me.紹介者.Text)
        If (Sys_InputCheck(Me.紹介者.Text, 32, "M", 0)) Then
            Call Sys_Error("紹介者 は32文字以内で入力してください。　", Me.紹介者)
            Exit Function
        End If
        input_check = True
    End Function

    Private Sub format() ''画面を初期化
        Me.lbl顧客番号.Text = logic.NewCustomerNumber() ''新規顧客番号を表示
        Me.姓.Text = ""
        Me.姓カナ.Text = ""
        Me.名.Text = ""
        Me.名カナ.Text = ""
        Me.郵便番号.Text = ""
        Me.都道府県.Text = ""
        Me.住所１.Text = ""
        Me.住所２.Text = ""
        Me.住所３.Text = ""
        Me.電話番号.Text = ""
        Me.メールアドレス.Text = ""
        Me.元号生年月日.Text = ""
        Me.lbl生年月日.Text = ""
        Me.家族名.Text = ""
        Me.趣味.Text = ""
        Me.好きな話題.Text = ""
        Me.嫌いな話題.Text = ""
        Me.メモ.Text = ""
        Me.紹介者.Text = ""

        If 登録区分番号.Items.Count > 0 Then
            登録区分番号.SelectedValue = REGISTER_COMPLETION
        End If
        If 性別番号.Items.Count > 0 Then
            性別番号.SelectedIndex = 0
        End If
        If 主担当者.Items.Count > 0 Then
            主担当者.SelectedIndex = 0
        End If
        Me.登録.Enabled = False
        Me.TabControl1.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' 生年月日設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setBirthday()
        Try
            If Me.元号生年月日.Text.Length <> 0 Then
                Dim date1 As DateTime
                date1 = DateTime.Parse(Me.元号生年月日.Text)
                Me.lbl生年月日.Text = date1.ToString("yyyy/MM/dd")
                Dim culture As Globalization.CultureInfo = New System.Globalization.CultureInfo("ja-JP", True)
                culture.DateTimeFormat.Calendar = New Globalization.JapaneseCalendar
                Me.元号生年月日.Text = date1.ToString("ggyy年M月d日", culture)
            End If
            Me.性別番号.Focus()
        Catch ex As Exception
            Me.元号生年月日.Text = ""
            Me.lbl生年月日.Text = ""
            Me.元号生年月日.Focus()
            Exit Sub
        End Try

    End Sub
#End Region

End Class