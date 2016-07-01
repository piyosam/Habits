'システム名 ： HABITS
'機能名　　 ： a1000_ユーザー情報
'概要　　　 ： システム使用ユーザ情報の変更機能
'履歴　　　 ： 2010/05/12　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a1000_ユーザー情報

    Private logic As Habits.Logic.a1000_Logic
    Private money As String
    Private w_money As Double

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1000_ユーザー情報_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ASY As New DataTable
        logic = New Habits.Logic.a1000_Logic
        ASY = logic.getA_System

        If ASY.Rows.Count <> 0 Then
            Me.lblShopCode.Text = ASY.Rows(0)("店舗コード").ToString
            Me.txtShopName.Text = ASY.Rows(0)("店名1").ToString
            Me.txtShopNameKana.Text = ASY.Rows(0)("店名2").ToString
            Me.txtOwner.Text = ASY.Rows(0)("代表者名").ToString
            Me.txtPostCode.Text = ASY.Rows(0)("店郵便番号").ToString
            Me.txtAddress.Text = ASY.Rows(0)("店住所1").ToString
            Me.txtAddress2.Text = ASY.Rows(0)("店住所2").ToString
            Me.txtPhone.Text = ASY.Rows(0)("店電話番号").ToString
            Me.txtFax.Text = ASY.Rows(0)("店ＦＡＸ番号").ToString
            Me.txtChairs.Text = ASY.Rows(0)("設備台数").ToString
            Me.txtStartDay.Text = ASY.Rows(0)("月締開始日").ToString

            money = ASY.Rows(0)("レジ金額").ToString
            w_money = Double.Parse(money)
            Me.txtCash.Text = Format(w_money, "#,##0")

        End If
        Me.txtShopName.Focus()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1000_ユーザー情報_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "設定ボタン押下"
    ''' <summary>
    ''' 設定ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 設定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        '入力チェック
        If Not (input_check()) Then Exit Sub

        'DB登録
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        param.Add("@新郵便番号表示用", Mid(Me.txtPostCode.Text, 1, 3) & "%")
        dt = logic.select_address(param)

        param.Clear()
        param.Add("@店名1", Me.txtShopName.Text)
        param.Add("@店名2", Me.txtShopNameKana.Text)
        param.Add("@代表者名", Me.txtOwner.Text)
        param.Add("@店郵便番号", Me.txtPostCode.Text)
        param.Add("@店住所1", Me.txtAddress.Text)
        param.Add("@店住所2", Me.txtAddress2.Text)
        param.Add("@店電話番号", Me.txtPhone.Text)
        param.Add("@店ＦＡＸ番号", Me.txtFax.Text)
        param.Add("@設備台数", Me.txtChairs.Text)
        param.Add("@レジ金額", money)
        param.Add("@変更日時", Now)
        param.Add("@月締開始日", Me.txtStartDay.Text)

        If dt.Rows.Count >= 1 Then
            param.Add("@都道府県", dt.Rows(0)("都道府県名"))
            param.Add("@市区町村", dt.Rows(0)("市区町村名"))

            logic.updateA_System(param)
        Else
            If (MsgBox("郵便番号辞書に存在しない郵便番号ですが　　" & Chr(13) & Chr(13) & _
                  "このまま登録しますか？　", Clng_Ynqub2, TTL) = vbNo) Then
                Me.txtPostCode.Focus()
                Exit Sub
            End If

            logic.updatePartOfA_System(param)
        End If

        rtn = MsgBox("設定しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
        Me.Close()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
#End Region

#End Region

#Region "メソッド"

#Region "入力チェック"
    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        '名称チェック
        Me.txtShopName.Text = Trim(Me.txtShopName.Text)
        If (String.IsNullOrEmpty(Me.txtShopName.Text)) Then
            Call Sys_Error("名称 は必須入力です。　", Me.txtShopName)
            Exit Function
        End If
        'レシート印字のため制限している
        If (Sys_InputCheck(Me.txtShopName.Text, 25, "M", 1)) Then
            Call Sys_Error("名称 は25文字以内で入力してください。　", Me.txtShopName)
            Exit Function
        End If

        '名称カナチェック
        Me.txtShopNameKana.Text = Trim(Me.txtShopNameKana.Text)
        'レシートに表示したくない場合があるため必須チェックを外す
        'If (String.IsNullOrEmpty(Me.txtShopNameKana.Text)) Then
        '    Call Sys_Error("名称カナ は必須入力です。　", Me.txtShopNameKana)
        '    Exit Function
        'End If
        If (Sys_InputCheck(Me.txtShopNameKana.Text, 25, "M", 0)) Then
            Call Sys_Error("名称カナ は25文字以内で入力してください。　", Me.txtShopNameKana)
            Exit Function
        End If

        '代表者名チェック
        Me.txtOwner.Text = Trim(Me.txtOwner.Text)
        If (String.IsNullOrEmpty(Me.txtOwner.Text)) Then
            Call Sys_Error("代表者名 は必須入力です。　", Me.txtOwner)
            Exit Function
        End If
        If (Sys_InputCheck(Me.txtOwner.Text, 25, "M", 1)) Then
            Call Sys_Error("代表者名 は25文字以内で入力してください。　", Me.txtOwner)
            Exit Function
        End If

        '郵便番号チェック
        Me.txtPostCode.Text = Trim(Me.txtPostCode.Text)
        If (String.IsNullOrEmpty(Me.txtPostCode.Text)) Then
            Call Sys_Error("郵便番号 は必須入力です。　", Me.txtPostCode)
            Exit Function
        End If
        If Sys_Zenkaku(Me.txtPostCode.Text) Then
            Call Sys_Error("郵便番号 は半角で入力してください。", Me.txtPostCode)
            Exit Function
        End If
        If (Sys_InputCheck(Me.txtPostCode.Text, 8, "A", 1)) Then
            Call Sys_Error("郵便番号 はハイフンあり半角8文字で入力してください。　", Me.txtPostCode)
            Exit Function
        End If
        If Sys_Len(Me.txtPostCode.Text) <= 7 Then
            Call Sys_Error("郵便番号 はハイフンあり半角8文字で入力してください。　", Me.txtPostCode)
            Exit Function
        End If
        If Mid(Me.txtPostCode.Text, 4, 1) <> "-" Then
            Call Sys_Error("郵便番号 はハイフンあり半角8文字で入力してください。　", Me.txtPostCode)
            Exit Function
        End If
        If Sys_InputCheck(Mid(Me.txtPostCode.Text, 1, 3), 3, "N", 1) Then
            Call Sys_Error("郵便番号 はハイフンあり半角8文字で入力してください。　", Me.txtPostCode)
            Exit Function
        End If
        If Sys_InputCheck(Mid(Me.txtPostCode.Text, 5, 8), 4, "N", 1) Then
            Call Sys_Error("郵便番号 はハイフンあり半角8文字で入力してください。　", Me.txtPostCode)
            Exit Function
        End If

        '住所（番地まで）チェック
        Me.txtAddress.Text = Trim(Me.txtAddress.Text)
        If (String.IsNullOrEmpty(Me.txtAddress.Text)) Then
            Call Sys_Error("住所 は必須入力です。　", Me.txtAddress)
            Exit Function
        End If
        If (Sys_InputCheck(Me.txtAddress.Text, 25, "M", 1)) Then
            Call Sys_Error("住所 は25文字以内で入力してください。　", Me.txtAddress)
            Exit Function
        End If

        'マンション名チェック
        Me.txtAddress2.Text = Trim(Me.txtAddress2.Text)
        If (Sys_InputCheck(Me.txtAddress2.Text, 25, "M", 0)) Then
            Call Sys_Error("建物名 は25文字以内で入力してください。　", Me.txtAddress2)
            Exit Function
        End If

        '電話番号チェック
        Me.txtPhone.Text = Trim(Me.txtPhone.Text)
        If (String.IsNullOrEmpty(Me.txtPhone.Text)) Then
            Call Sys_Error("電話番号 は必須入力です。　", Me.txtPhone)
            Exit Function
        End If
        If Sys_Zenkaku(Me.txtPhone.Text) Then
            Call Sys_Error("電話番号 は半角で入力してください。　", Me.txtPhone)
            Exit Function
        End If
        If (Sys_InputCheck(Me.txtPhone.Text, 19, "A", 1)) Then
            Call Sys_Error("電話番号 は半角19文字以内で入力してください。　", Me.txtPhone)
            Exit Function
        End If

        '店FAX番号チェック
        Me.txtFax.Text = Trim(Me.txtFax.Text)
        If Sys_Zenkaku(Me.txtFax.Text) Then
            Call Sys_Error("ＦＡＸ番号 は半角で入力してください。　", Me.txtFax)
            Exit Function
        End If
        If (Sys_InputCheck(Me.txtFax.Text, 19, "A", 0)) Then
            Call Sys_Error("ＦＡＸ番号 は半角19文字以内で入力してください。　", Me.txtFax)
            Exit Function
        End If

        '設備台数チェック
        Me.txtChairs.Text = Trim(Me.txtChairs.Text)
        If (String.IsNullOrEmpty(Me.txtChairs.Text)) Then
            Call Sys_Error("設備台数 は必須入力です。　", Me.txtChairs)
            Exit Function
        End If
        If Sys_Zenkaku(Me.txtChairs.Text) Then
            Call Sys_Error("設備台数 は半角で入力してください。　", Me.txtChairs)
            Exit Function
        End If
        If (Sys_InputCheck(Me.txtChairs.Text, 4, "N+", 1)) Then
            Call Sys_Error("設備台数 は0～9,999の半角数字で入力してください。　", Me.txtChairs)
            Exit Function
        End If

        'レジ金額チェック
        If Not (input_check_register()) Then
            Exit Function
        End If

        '月締開始日チェック
        Me.txtStartDay.Text = Trim(Me.txtStartDay.Text)
        If (String.IsNullOrEmpty(Me.txtStartDay.Text)) Then
            Call Sys_Error("月締・開始日 は必須入力です。　", Me.txtStartDay)
            Exit Function
        End If
        If Sys_Zenkaku(Me.txtStartDay.Text) Then
            Call Sys_Error("月締・開始日 は半角で入力してください。　", Me.txtStartDay)
            Exit Function
        End If
        If (Sys_InputCheck(Me.txtStartDay.Text, 2, "N+", 1) _
                OrElse Integer.Parse(Me.txtStartDay.Text) < 1 _
                OrElse Integer.Parse(Me.txtStartDay.Text) > 31) Then
            Call Sys_Error("月締・開始日 は1～31の半角数字で入力してください。　", Me.txtStartDay)
            Exit Function
        End If

        Return True
    End Function
#End Region

#Region "レジ金額入力チェック"
    ''' <summary>
    ''' レジ金額入力チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function input_check_register() As Boolean
        'レジ金額チェック
        Me.txtCash.Text = Trim(Me.txtCash.Text)
        money = Replace(Me.txtCash.Text, ",", "")
        If (String.IsNullOrEmpty(Me.txtCash.Text)) Then
            Call Sys_Error("レジ金額 は必須入力です。　", Me.txtCash)
            Return False
        End If
        If Sys_Zenkaku(money) Then
            Call Sys_Error("レジ金額 は半角で入力してください。　", Me.txtCash)
            Return False
        End If
        If (Sys_InputCheck(money, 9, "N", 1)) Then
            Call Sys_Error("レジ金額 は半角数字９文字以内で入力してください。　", Me.txtCash)
            Return False
        End If

        Return True
    End Function
#End Region

#End Region

#Region "フォーカス移動（Enter）"
    'エンター押下時のフォーカス移動処理
    Private Sub txtShopName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShopName.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtShopNameKana.Focus()
        End If
    End Sub

    Private Sub txtShopNameKana_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShopNameKana.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtOwner.Focus()
        End If
    End Sub

    Private Sub txtOwner_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOwner.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtPostCode.Focus()
        End If
    End Sub
    Private Sub txtPostCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPostCode.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtAddress.Focus()
        End If
    End Sub

    Private Sub txtAddress_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAddress.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtAddress2.Focus()
        End If
    End Sub

    Private Sub txtAddress2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAddress2.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtPhone.Focus()
        End If
    End Sub

    Private Sub txtPhone_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPhone.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtFax.Focus()
        End If
    End Sub

    Private Sub txtFax_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFax.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtChairs.Focus()
        End If
    End Sub

    Private Sub txtChairs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtChairs.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtCash.Focus()
        End If
    End Sub

    Private Sub txtCash_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCash.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtStartDay.Focus()
        End If
    End Sub

    Private Sub txtStartDay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStartDay.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.btnSubmit.Focus()
        End If
    End Sub

#End Region

    Private Sub txtPostCode_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPostCode.Enter
        Me.txtPostCode.Text = Replace(Me.txtPostCode.Text, "-", "")
    End Sub

    Private Sub txtPostCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPostCode.Leave
        Dim sYuubin As String

        sYuubin = Me.txtPostCode.Text
        Me.txtPostCode.Text = Trim(Me.txtPostCode.Text)

        If sYuubin.Length = 7 Then
            Me.txtPostCode.Text = sYuubin.Substring(0, 3)
            Me.txtPostCode.Text = Me.txtPostCode.Text & "-" & sYuubin.Substring(3, 4)
            Exit Sub
        End If
    End Sub

    Private Sub txtPostCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPostCode.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txtChairs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChairs.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txtCash_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCash.Enter
        Me.txtCash.Text = Replace(Me.txtCash.Text, ",", "")
    End Sub

    Private Sub txtCash_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCash.Validated
        If Me.txtCash.TextLength <> 0 Then
            money = Replace(Me.txtCash.Text, ",", "")
            If Not (input_check_register()) Then
                Exit Sub
            End If

            If IsNumeric(money) Then
                w_money = Double.Parse(money)
                Me.txtCash.Text = Format(w_money, "#,##0")
                RemoveHandler txtCash.Validated, AddressOf txtCash_Validated
                AddHandler txtCash.Validated, AddressOf Me.txtCash_Validated
            Else
                Call Sys_Error("レジ金額 は半角数字9文字以内で入力してください。　", Me.txtCash)
                Me.txtCash.Text = Nothing
            End If
        End If
    End Sub

    Private Sub txtStartDay_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStartDay.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

End Class