'システム名 ： HABITS
'機能名　　 ： z_0500_顧客変更
'概要　　　 ： 顧客情報変更機能
'履歴　　　 ： 2010/06/14　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.Imports System.Data
Public Class z_0500_顧客変更

    Private logic As Habits.Logic.z0500_Logic
    Public mode As Integer ''顧客情報画面から遷移時条件付け
    Public z_0500_loaded As Boolean
    Public button_mode As Boolean ''マスタの変更削除からのみ検索ボタン出現
    Private yomiNewLastName As ImeComposition.ImeYomiConversion    '' 新規姓の読みを取得
    Private yomiNewFirstName As ImeComposition.ImeYomiConversion   '' 新規名の読みを取得

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub z_0500_顧客変更_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '顧客情報設定
        SetDetailInfo()
        yomiNewLastName = New ImeComposition.ImeYomiConversion(Me.姓, Me.姓カナ, True)
        yomiNewFirstName = New ImeComposition.ImeYomiConversion(Me.名, Me.名カナ, True)

        Me.btn顧客検索.Visible = False
        If (button_mode = True) Then
            Me.btn顧客検索.Visible = True
            Me.ActiveControl = Me.btn顧客検索
        End If
        Me.来店日.Enabled = False
        ChkEnable()

        If Me.郵便番号.Text.Equals("-") Then
            Me.郵便番号.Text = ""
        End If
        Me.z_0500_loaded = True
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub z_0500_顧客変更_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If (Me.z_0500_loaded = True) Then
            Me.z_0500_loaded = False
        End If
        Me.Dispose()
    End Sub
#End Region

#Region "元号生年月日キーダウン設定"
    ''' <summary>元号生年月日キーダウン設定</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 元号生年月日_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 元号生年月日.KeyDown
        If (e.KeyData.Equals(System.Windows.Forms.Keys.Enter)) Then
            setBirthday()
        End If
    End Sub
#End Region

#Region "元号生年月日_Leaveイベント"
    ''' <summary>元号生年月日カーソル遷移</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 元号生年月日_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 元号生年月日.Leave
        setBirthday()
    End Sub
#End Region

#Region "姓_Enterイベント"
    ''' <summary>姓からのカーソル移動処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 姓_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles 姓.Enter
        yomiNewLastName.Enabled = True
    End Sub
#End Region

#Region "名_Enterイベント"
    ''' <summary>名からのカーソル移動処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 名_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles 名.Enter
        yomiNewFirstName.Enabled = True
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "顧客番号検索ボタン押下"
    ''' <summary>顧客番号検索ボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn顧客検索_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn顧客検索.Click
        z_0300_顧客検索.検索loaded = True
        z_0300_顧客検索.ShowDialog()
        ChkEnable()
        Me.姓.Focus()
    End Sub
#End Region

#Region "郵便番号検索ボタン押下"
    ''' <summary>郵便番号検索ボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 郵便番号検索_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 郵便番号検索.Click
        z_0600_郵便番号検索.z_0600_郵便番号検索_loaded = False
        z_0600_郵便番号検索.ShowDialog()
        郵便番号.Focus()
    End Sub
#End Region

#Region "変更ボタン押下"
    ''' <summary>変更ボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 変更_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 変更.Click
        '入力チェック
        If Not (input_check()) Then Exit Sub

        If Me.主担当者.SelectedValue Is Nothing Then
            rtn = MsgBox("主担当者を選択してください。　", Clng_Okexb1, TTL)
            Exit Sub
        End If

        If Me.性別番号.SelectedValue Is Nothing Then
            rtn = MsgBox("性別を選択してください。　", Clng_Okexb1, TTL)
            Exit Sub
        End If

        If Me.登録区分番号.SelectedValue Is Nothing AndAlso Me.登録区分番号.SelectedValue.ToString <> "0" Then
            rtn = MsgBox("登録区分を選択してください。　", Clng_Okexb1, TTL)
            Exit Sub
        End If

        '確認メッセージ出力
        If (MsgBox(Me.姓.Text & " 様を変更しますか？　", Clng_Ynqub1, TTL) = vbYes) Then
            Dim update_dt As New Integer
            Dim param As New Habits.DB.DBParameter
            logic = New Habits.Logic.z0500_Logic

            param.Add("@顧客番号", Me.lbl顧客番号.Text)
            param.Add("@姓", Me.姓.Text)
            param.Add("@名", IIf(Me.名.Text.Length > 0, Me.名.Text, System.DBNull.Value))
            param.Add("@姓カナ", IIf(Me.姓カナ.Text.Length > 0, Me.姓カナ.Text, System.DBNull.Value))
            param.Add("@名カナ", IIf(Me.名カナ.Text.Length > 0, Me.名カナ.Text, System.DBNull.Value))
            param.Add("@性別", Me.性別番号.Text)
            param.Add("@生年月日", IIf(IsDate(Me.生年月日.Text), Me.生年月日.Text, System.DBNull.Value))

            If (Sys_Len(Me.郵便番号.Text) = 8) Then
                param.Add("@郵便番号", Me.郵便番号.Text)
            ElseIf (Me.lbl顧客番号.Text.Length = 7) Then
                param.Add("@郵便番号", Mid(Me.郵便番号.Text, 1, 3) & "-" & Mid(Me.郵便番号.Text, 4, 4))
            Else
                param.Add("@郵便番号", System.DBNull.Value)
            End If

            param.Add("@都道府県", IIf(Me.都道府県.Text.Length > 0, Me.都道府県.Text, System.DBNull.Value))
            param.Add("@住所1", IIf(Me.住所１.Text.Length > 0, Me.住所１.Text, System.DBNull.Value))
            param.Add("@住所2", IIf(Me.住所２.Text.Length > 0, Me.住所２.Text, System.DBNull.Value))
            param.Add("@住所3", IIf(Me.住所３.Text.Length > 0, Me.住所３.Text, System.DBNull.Value))
            param.Add("@電話番号", IIf(Me.電話番号.Text.Length > 0, Me.電話番号.Text, System.DBNull.Value))
            param.Add("@アドレス", IIf(Me.メールアドレス.Text.Length > 0, Me.メールアドレス.Text, System.DBNull.Value))
            param.Add("@家族名", IIf(Me.家族名.Text.Length > 0, Me.家族名.Text, System.DBNull.Value))
            param.Add("@趣味", IIf(Me.趣味.Text.Length > 0, Me.趣味.Text, System.DBNull.Value))
            param.Add("@好きな話題", IIf(Me.好きな話題.Text.Length > 0, Me.好きな話題.Text, System.DBNull.Value))
            param.Add("@嫌いな話題", IIf(Me.嫌いな話題.Text.Length > 0, Me.嫌いな話題.Text, System.DBNull.Value))
            param.Add("@メモ", IIf(Me.メモ.Text.Length > 0, Me.メモ.Text, System.DBNull.Value))
            param.Add("@紹介者", IIf(Me.紹介者.Text.Length > 0, Me.紹介者.Text, System.DBNull.Value))
            param.Add("@担当者名", IIf(Me.主担当者.Text.Length > 0, Me.主担当者.Text, System.DBNull.Value))
            param.Add("@登録区分", Me.登録区分番号.Text)
            param.Add("@更新日", Now())
            update_dt = logic.update_D_顧客(param)
        Else
            Exit Sub
        End If
        Dim update_ERA As New Integer
        Dim param_ERA As New Habits.DB.DBParameter

        param_ERA.Add("@顧客番号", Me.lbl顧客番号.Text)
        param_ERA.Add("@来店日", USER_DATE)
        param_ERA.Add("@姓", Me.姓.Text)
        param_ERA.Add("@姓カナ", IIf(Me.姓カナ.Text.Length > 0, Me.姓カナ.Text, System.DBNull.Value))
        param_ERA.Add("@名", IIf(Me.名.Text.Length > 0, Me.名.Text, System.DBNull.Value))
        param_ERA.Add("@住所", IIf(Me.住所１.Text.Length > 0, Me.住所１.Text, System.DBNull.Value))
        param_ERA.Add("@更新日", Now())
        param_ERA.Add("@主担当者番号", Me.主担当者.SelectedValue)
        update_ERA = logic.update_E_来店者(param_ERA)

        a0200_メイン.ReDisplay()
        item_clear()
        If (mode = 0) Then ''顧客情報画面遷移時、変更ボタン押下後顧客情報画面へ情報反映
            z_0400_顧客情報.顧客情報表示()
        End If
        mode = 1
        If (Me.z_0500_loaded = True) Then
            Me.z_0500_loaded = False
            Me.Close()
        End If
    End Sub
#End Region

#Region "削除ボタン押下"
    ''' <summary>削除ボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 削除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 削除.Click
        ''現在の来店者かどうか確認
        Dim select_dt As New DataTable
        Dim param_select As New Habits.DB.DBParameter
        logic = New Habits.Logic.z0500_Logic
        param_select.Add("@顧客番号", Me.lbl顧客番号.Text)
        param_select.Add("@来店日", USER_DATE)
        select_dt = logic.select_E_来店者(param_select)

        If (select_dt.Rows.Count > 0) Then
            rtn = MsgBox("来店情報が存在するため、削除できません。　", Clng_Okexb1, TTL)
            Exit Sub

        End If

        If (Select_Data() <> True) Then
            rtn = MsgBox("顧客に紐付く情報が存在するため、削除できません。　", Clng_Okexb1, TTL)
            Exit Sub
        End If

        If (MsgBox("削除すると元に戻せませんが、よろしいですか？　", Clng_Ynqub2, TTL) = vbNo) Then
            Exit Sub
        End If

        Dim delete_dt As New Integer
        Dim param_delete As New Habits.DB.DBParameter
        param_delete.Add("@顧客番号", Me.lbl顧客番号.Text)
        delete_dt = logic.delete_D_顧客(param_delete)

        item_clear()
        If (Me.z_0500_loaded = True) Then
            Me.z_0500_loaded = False
            Me.Close()
        End If
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>閉じるボタンクリック</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub

    Private Sub 郵便番号_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 郵便番号.TextChanged
        Dim select_placename As New DataTable
        Dim param As New Habits.DB.DBParameter
        Dim logic As New Habits.Logic.z0500_Logic
        Dim str_num As String
        param.Clear()
        If (Me.郵便番号.TextLength = 0) Then
            Me.都道府県.Text = ""
            Me.住所１.Text = ""
            Me.住所２.Text = ""

        ElseIf (Me.郵便番号.TextLength = 3) Then
            str_num = Me.郵便番号.Text
            param.Add("@新郵便番号表示用", str_num & "%")
            select_placename = logic.select_placename(param)
            If (select_placename.Rows.Count > 0) Then
                Me.都道府県.Text = select_placename.Rows(0)("都道府県名")
            Else
                Me.都道府県.Text = ""
            End If
            Me.住所１.Text = ""
            Me.住所２.Text = ""

        ElseIf (Me.郵便番号.TextLength = 7) Then
            str_num = Mid(Me.郵便番号.Text, 1, 3) & "-" & Mid(Me.郵便番号.Text, 4, 4)
            param.Add("@新郵便番号表示用", str_num & "%")
            select_placename = logic.select_placename(param)

            If (select_placename.Rows.Count > 0) Then
                Me.都道府県.Text = select_placename.Rows(0)("都道府県名")
                Me.住所１.Text = select_placename.Rows(0)("市区町村名")
                Me.住所２.Text = select_placename.Rows(0)("町域名")
            Else
                Me.都道府県.Text = ""
                Me.住所１.Text = ""
                Me.住所２.Text = ""
            End If

        ElseIf (Me.郵便番号.TextLength = 8) Then
            str_num = Me.郵便番号.Text
            param.Add("@新郵便番号表示用", str_num & "%")
            select_placename = logic.select_placename(param)
            If (select_placename.Rows.Count > 0) Then
                Me.都道府県.Text = select_placename.Rows(0)("都道府県名")
                Me.住所１.Text = select_placename.Rows(0)("市区町村名")
                Me.住所２.Text = select_placename.Rows(0)("町域名")
            Else
                Me.都道府県.Text = ""
                Me.住所１.Text = ""
                Me.住所２.Text = ""
            End If
        End If
    End Sub
#End Region

#End Region

#Region "テキスト変更"

#Region "住所２変更時処理"
    ''' <summary>住所２変更時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 住所２_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 住所２.TextChanged
        Dim select_postnumber As New DataTable
        Dim param As New Habits.DB.DBParameter
        Dim logic As New Habits.Logic.z0500_Logic
        param.Clear()
        param.Add("@都道府県名", Me.都道府県.Text)
        param.Add("@市区町村名", Me.住所１.Text)
        param.Add("@町域名", Me.住所２.Text)
        select_postnumber = logic.select_postnumber(param)
        If (select_postnumber.Rows.Count > 0) Then
            Me.郵便番号.Text = select_postnumber.Rows(0)("新郵便番号表示用")
        End If
    End Sub
#End Region

#Region "顧客番号変更時処理"
    ''' <summary>顧客番号変更時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 顧客番号_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '活性、非活性設定
        ChkEnable()
    End Sub
#End Region

#Region "元号生年月日変更時処理"
    ''' <summary>元号生年月日変更時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 元号生年月日_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 元号生年月日.TextChanged
        If (Me.元号生年月日.Text.Length = 0) Then
            Me.生年月日.Text = ""
        End If
    End Sub
#End Region

#Region "姓テキスト変更時処理"
    ''' <summary>姓テキスト変更時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 姓_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 姓.TextChanged
        If Me.姓.TextLength = 0 Then
            Me.姓カナ.Text = Nothing
        End If
    End Sub
#End Region

#Region "名テキスト変更時処理"
    ''' <summary>名テキスト変更時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 名_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 名.TextChanged
        If Me.名.TextLength = 0 Then
            Me.名カナ.Text = Nothing
        End If
    End Sub
#End Region

#End Region

#Region "メソッド"

#Region "入力チェック"
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
                Call Sys_Error("郵便番号 は半角数字で入力してください。", Me.郵便番号)
                Exit Function
            End If
            If Sys_InputCheck(Me.郵便番号.Text, 8, "A", 1) Then
                Call Sys_Error("郵便番号 はハイフンあり半角数字8文字で入力してください。　", Me.郵便番号)
                Exit Function
            End If

            If Me.郵便番号.TextLength <= 7 Then
                Call Sys_Error("郵便番号 はハイフンあり半角数字8文字で入力してください。　", Me.郵便番号)
                Exit Function
            End If
            If Mid(Me.郵便番号.Text, 4, 1) <> "-" Then
                Call Sys_Error("郵便番号 はハイフンあり半角数字8文字で入力してください。　", Me.郵便番号)
                Exit Function
            End If

            If Sys_InputCheck(Mid(Me.郵便番号.Text, 1, 3), 3, "N", 1) Then
                Call Sys_Error("郵便番号 はハイフンあり半角数字8文字で入力してください。　", Me.郵便番号)
                Exit Function
            End If
            If Sys_InputCheck(Mid(Me.郵便番号.Text, 5, 8), 4, "N", 1) Then
                Call Sys_Error("郵便番号 はハイフンあり半角数字8文字で入力してください。　", Me.郵便番号)
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

        Me.生年月日.Text = Trim(Me.生年月日.Text)
        If Sys_Zenkaku(Me.生年月日.Text) Then
            Call Sys_Error("生年月日 は半角で入力してください。　", Me.生年月日)
            Exit Function
        End If
        If (Sys_InputCheck(Me.生年月日.Text, 7, "D", 0)) Then
            Call Sys_Error("生年月日 が不正です。　", Me.生年月日)
            Exit Function
        End If
        If Not Me.生年月日.Text = Nothing Then
            str_date = Mid(Me.生年月日.Text, 1, 2)
            If str_date <= 18 Then
                Call Sys_Error("生年月日 が不正です。　", Me.生年月日)
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
#End Region

#Region "入力項目クリア"
    ''' <summary>
    ''' 入力項目クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub item_clear()
        Me.lbl顧客番号.Text = ""
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
        Me.生年月日.Text = ""
        Me.家族名.Text = ""
        Me.趣味.Text = ""
        Me.好きな話題.Text = ""
        Me.嫌いな話題.Text = ""
        Me.メモ.Text = ""
        Me.紹介者.Text = ""
        Me.lbl前回来店日.Text = ""
        Me.lbl来店日N_1.Text = ""
        Me.lbl来店日N_2.Text = ""
        Me.lbl登録日.Text = ""

        If 登録区分番号.Items.Count > 0 Then
            登録区分番号.SelectedIndex = 0
        End If
        If 性別番号.Items.Count > 0 Then
            性別番号.SelectedIndex = 0
        End If
        If 主担当者.Items.Count > 0 Then
            主担当者.SelectedIndex = 0
        End If

        Me.変更.Enabled = False
        Me.削除.Enabled = False
        Me.TabControl1.SelectedIndex = 0
    End Sub
#End Region

#Region "活性設定"
    ''' <summary>
    ''' 活性、非活性設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChkEnable()
        If Me.lbl顧客番号.Text.Equals("") Then
            Me.郵便番号検索.Enabled = False
            Me.削除.Enabled = False
            Me.変更.Enabled = False
            Me.lbl顧客番号.Enabled = False
            Me.lbl顧客番号.BackColor = SystemColors.Control
            Me.姓.Enabled = False
            Me.姓.BackColor = SystemColors.Control
            Me.名.Enabled = False
            Me.名.BackColor = SystemColors.Control
            Me.姓カナ.Enabled = False
            Me.姓カナ.BackColor = SystemColors.Control
            Me.名カナ.Enabled = False
            Me.名カナ.BackColor = SystemColors.Control
            Me.郵便番号.Enabled = False
            Me.郵便番号.BackColor = SystemColors.Control
            Me.都道府県.Enabled = False
            Me.都道府県.BackColor = SystemColors.Control
            Me.住所１.Enabled = False
            Me.住所１.BackColor = SystemColors.Control
            Me.住所２.Enabled = False
            Me.住所２.BackColor = SystemColors.Control
            Me.住所３.Enabled = False
            Me.住所３.BackColor = SystemColors.Control
            Me.電話番号.Enabled = False
            Me.電話番号.BackColor = SystemColors.Control
            Me.メールアドレス.Enabled = False
            Me.メールアドレス.BackColor = SystemColors.Control
            Me.登録区分番号.Enabled = False
            Me.登録区分番号.BackColor = SystemColors.Control
            Me.元号生年月日.Enabled = False
            Me.元号生年月日.BackColor = SystemColors.Control
            Me.生年月日.Enabled = False
            Me.生年月日.BackColor = SystemColors.Control
            Me.性別番号.Enabled = False
            Me.性別番号.BackColor = SystemColors.Control
            Me.家族名.Enabled = False
            Me.家族名.BackColor = SystemColors.Control
            Me.趣味.Enabled = False
            Me.趣味.BackColor = SystemColors.Control
            Me.好きな話題.Enabled = False
            Me.好きな話題.BackColor = SystemColors.Control
            Me.嫌いな話題.Enabled = False
            Me.嫌いな話題.BackColor = SystemColors.Control
            Me.メモ.Enabled = False
            Me.メモ.BackColor = SystemColors.Control
            Me.紹介者.Enabled = False
            Me.紹介者.BackColor = SystemColors.Control
            Me.主担当者.Enabled = False
            Me.主担当者.BackColor = SystemColors.Control
            Me.lbl前回来店日.Enabled = False
            Me.lbl前回来店日.BackColor = SystemColors.Control
            Me.lbl来店日N_1.Enabled = False
            Me.lbl来店日N_1.BackColor = SystemColors.Control
            Me.lbl来店日N_2.Enabled = False
            Me.lbl来店日N_2.BackColor = SystemColors.Control
            Me.lbl登録日.Enabled = False
            Me.lbl登録日.BackColor = SystemColors.Control
        Else
            Me.郵便番号検索.Enabled = True
            Me.削除.Enabled = True
            Me.変更.Enabled = True
            Me.lbl顧客番号.Enabled = True
            Me.lbl顧客番号.BackColor = Color.White
            Me.姓.Enabled = True
            Me.姓.BackColor = Color.White
            Me.名.Enabled = True
            Me.名.BackColor = Color.White
            Me.姓カナ.Enabled = True
            Me.姓カナ.BackColor = Color.White
            Me.名カナ.Enabled = True
            Me.名カナ.BackColor = Color.White
            Me.郵便番号.Enabled = True
            Me.郵便番号.BackColor = Color.White
            Me.都道府県.Enabled = True
            Me.都道府県.BackColor = Color.White
            Me.住所１.Enabled = True
            Me.住所１.BackColor = Color.White
            Me.住所２.Enabled = True
            Me.住所２.BackColor = Color.White
            Me.住所３.Enabled = True
            Me.住所３.BackColor = Color.White
            Me.電話番号.Enabled = True
            Me.電話番号.BackColor = Color.White
            Me.メールアドレス.Enabled = True
            Me.メールアドレス.BackColor = Color.White
            Me.登録区分番号.Enabled = True
            Me.登録区分番号.BackColor = Color.White
            Me.元号生年月日.Enabled = True
            Me.元号生年月日.BackColor = Color.White
            Me.生年月日.Enabled = True
            Me.生年月日.BackColor = Color.White
            Me.性別番号.Enabled = True
            Me.性別番号.BackColor = Color.White
            Me.家族名.Enabled = True
            Me.家族名.BackColor = Color.White
            Me.趣味.Enabled = True
            Me.趣味.BackColor = Color.White
            Me.好きな話題.Enabled = True
            Me.好きな話題.BackColor = Color.White
            Me.嫌いな話題.Enabled = True
            Me.嫌いな話題.BackColor = Color.White
            Me.メモ.Enabled = True
            Me.メモ.BackColor = Color.White
            Me.紹介者.Enabled = True
            Me.紹介者.BackColor = Color.White
            Me.主担当者.Enabled = True
            Me.主担当者.BackColor = Color.White
            Me.lbl前回来店日.Enabled = True
            Me.lbl前回来店日.BackColor = Color.White
            Me.lbl来店日N_1.Enabled = True
            Me.lbl来店日N_1.BackColor = Color.White
            Me.lbl来店日N_2.Enabled = True
            Me.lbl来店日N_2.BackColor = Color.White
            Me.lbl登録日.Enabled = True
            Me.lbl登録日.BackColor = Color.White
        End If
    End Sub
#End Region

#Region "関係データ存在チェック"
    ''' <summary>
    ''' 関係データ存在チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Select_Data() As Boolean
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        Dim logic As New Habits.Logic.z0500_Logic
        Dim rtn_flg As Boolean = True
        param.Add("@顧客番号", Integer.Parse(Me.lbl顧客番号.Text))

        ' E_カルテ
        dt = logic.select_record(param)
        If (dt.Rows.Count <> 0) Then rtn_flg = False
        ' E_ポイント
        dt = logic.select_point(param)
        If (dt.Rows.Count <> 0) Then rtn_flg = False
        ' E_売上
        dt = logic.select_sales(param)
        If (dt.Rows.Count <> 0) Then rtn_flg = False
        ' E_売上明細
        dt = logic.select_sales_details(param)
        If (dt.Rows.Count <> 0) Then rtn_flg = False
        ' E_来店者
        dt = logic.select_customer(param)
        If (dt.Rows.Count <> 0) Then rtn_flg = False
        Return rtn_flg
    End Function
#End Region

#Region "生年月日設定"
    ''' <summary>
    ''' 生年月日設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setBirthday()
        Try
            If Me.元号生年月日.Text.Length <> 0 Then
                Dim date1 As DateTime
                date1 = DateTime.Parse(Me.元号生年月日.Text)
                Me.生年月日.Text = date1.ToString("yyyy/MM/dd")
                Dim culture As Globalization.CultureInfo = New System.Globalization.CultureInfo("ja-JP", True)
                culture.DateTimeFormat.Calendar = New Globalization.JapaneseCalendar
                Me.元号生年月日.Text = date1.ToString("ggyy年M月d日", culture)
            End If
            Me.性別番号.Focus()
        Catch ex As Exception
            Me.元号生年月日.Text = ""
            Me.生年月日.Text = ""
            Me.元号生年月日.Focus()
            Exit Sub
        End Try
    End Sub
#End Region

#Region "顧客情報設定"
    ''' <summary>
    ''' 顧客情報設定
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetDetailInfo()
        logic = New Habits.Logic.z0500_Logic

        Me.来店日.Text = ""    ' men_来店者登録以外は設定不要
        Me.来店者番号.Text = ""
        Dim dt As New DataTable

        'コンボボックスにアイテムを追加
        Dim d性別 As New DataTable
        d性別 = logic.SexType()
        Me.性別番号.DataSource = d性別
        Me.性別番号.DisplayMember = "性別"
        Me.性別番号.ValueMember = "性別番号"
        Me.性別番号.SelectedIndex = -1

        Dim d登録区分 As New DataTable
        d登録区分 = logic.SelectedDivision()
        Me.登録区分番号.DataSource = d登録区分
        Me.登録区分番号.DisplayMember = "登録区分"
        Me.登録区分番号.ValueMember = "登録区分番号"
        Me.登録区分番号.SelectedIndex = -1

        Dim d担当者名 As New DataTable
        d担当者名 = logic.ChargeTanyouPerson()
        Me.主担当者.DataSource = d担当者名
        Me.主担当者.DisplayMember = "担当者名"
        Me.主担当者.ValueMember = "担当者番号"
        Me.主担当者.SelectedIndex = -1

        Dim param As New Habits.DB.DBParameter
        param.Add("@顧客番号", Me.lbl顧客番号.Text)
        dt = logic.CustomerInfo(param)
        param.Clear()

        '顧客番号に該当する顧客がいた場合に処理
        If (Not Me.lbl顧客番号.Text.Equals("")) OrElse (dt.Rows.Count > 0) Then
            Me.lbl顧客番号.Text = dt.Rows(0)("顧客番号").ToString
            Me.姓.Text = dt.Rows(0)("姓").ToString
            Me.名.Text = dt.Rows(0)("名").ToString
            Me.姓カナ.Text = dt.Rows(0)("姓カナ").ToString
            Me.名カナ.Text = dt.Rows(0)("名カナ").ToString

            ' 住所
            Me.郵便番号.Text = dt.Rows(0)("郵便番号").ToString
            Me.都道府県.Text = dt.Rows(0)("都道府県").ToString
            Me.住所１.Text = dt.Rows(0)("住所1").ToString
            Me.住所２.Text = dt.Rows(0)("住所2").ToString
            Me.住所３.Text = dt.Rows(0)("住所3").ToString
            Me.電話番号.Text = dt.Rows(0)("電話番号").ToString
            Me.メールアドレス.Text = dt.Rows(0)("Emailアドレス").ToString
            Me.登録区分番号.Text = dt.Rows(0)("登録区分").ToString

            ' 個人情報
            If Not IsDBNull(dt.Rows(0)("生年月日")) Then
                Me.生年月日.Text = DateValue(dt.Rows(0)("生年月日").ToString).ToString("yyyy/M/d")
                Dim culture As Globalization.CultureInfo = New System.Globalization.CultureInfo("ja-JP", True)
                culture.DateTimeFormat.Calendar = New Globalization.JapaneseCalendar
                Me.元号生年月日.Text = DateTime.Parse(Me.生年月日.Text).ToString("ggyy年M月d日", culture)
            End If
            Me.性別番号.Text = dt.Rows(0)("性別").ToString
            Me.家族名.Text = dt.Rows(0)("家族名").ToString
            Me.趣味.Text = dt.Rows(0)("趣味").ToString

            ' 店使用
            Me.好きな話題.Text = dt.Rows(0)("好きな話題").ToString
            Me.嫌いな話題.Text = dt.Rows(0)("嫌いな話題").ToString
            Me.メモ.Text = dt.Rows(0)("メモ").ToString
            Me.紹介者.Text = dt.Rows(0)("紹介者").ToString

            Me.lbl前回来店日.Text = ""
            If Not IsDBNull(dt.Rows(0)("前回来店日")) AndAlso DateValue(dt.Rows(0)("前回来店日").ToString) > Date.Parse("1900/01/01") Then
                Me.lbl前回来店日.Text = DateValue(dt.Rows(0)("前回来店日").ToString).ToString("yyyy/MM/dd (ddd)")
            End If

            Me.lbl来店日N_1.Text = ""
            If Not IsDBNull(dt.Rows(0)("来店日N_1")) AndAlso DateValue(dt.Rows(0)("来店日N_1").ToString) > Date.Parse("1900/01/01") Then
                Me.lbl来店日N_1.Text = DateValue(dt.Rows(0)("来店日N_1").ToString).ToString("yyyy/MM/dd (ddd)")
            End If

            Me.lbl来店日N_2.Text = ""
            If Not IsDBNull(dt.Rows(0)("来店日N_2")) AndAlso DateValue(dt.Rows(0)("来店日N_2").ToString) > Date.Parse("1900/01/01") Then
                Me.lbl来店日N_2.Text = DateValue(dt.Rows(0)("来店日N_2").ToString).ToString("yyyy/MM/dd (ddd)")
            End If

            Me.性別番号.Text = dt.Rows(0)("性別").ToString
            Me.登録区分番号.Text = dt.Rows(0)("登録区分").ToString
            Me.主担当者.Text = dt.Rows(0)("担当者名").ToString

            If Not IsDBNull(dt.Rows(0)("登録日")) Then
                Me.lbl登録日.Text = DateValue(dt.Rows(0)("登録日").ToString).ToString("yyyy/MM/dd (ddd)")
            End If

            Me.変更.Enabled = True
            Me.削除.Enabled = True
            Me.姓.Focus()
            dt.Dispose()
        End If
    End Sub
#End Region

#End Region

#Region "フォーカス移動"
    'エンター押下時のフォーカス移動処理

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

    Private Sub 登録区分番号_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 登録区分番号.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.変更.Focus()
        End If
    End Sub

    Private Sub 性別番号_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 性別番号.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.家族名.Focus()
        End If
    End Sub

    Private Sub 家族名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 家族名.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.趣味.Focus()
        End If
    End Sub

    Private Sub 紹介者_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 紹介者.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.主担当者.Focus()
        End If
    End Sub

    Private Sub 主担当者_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 主担当者.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.変更.Focus()
        End If
    End Sub
#End Region
End Class