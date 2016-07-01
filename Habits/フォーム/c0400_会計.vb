''' <summary>c0400_会計画面処理</summary>
''' <remarks></remarks>
Public Class c0400_会計

    Private Const PAGE_TITLE As String = "c0400_会計"
    Private logic As Habits.Logic.c0400_Logic

    Private param As New Habits.DB.DBParameter
    Private j As Integer

    Private Const SC_CLOSE As Long = &HF060L
    Private Const WM_SYSCOMMAND As Integer = &H112

    <System.Security.Permissions.SecurityPermission( _
        System.Security.Permissions.SecurityAction.LinkDemand, _
        Flags:=System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_SYSCOMMAND AndAlso (m.WParam.ToInt64() And &HFFF0L) = SC_CLOSE Then
            If ReCheckDenpyoFlag = True Then
                Return
            End If
        End If
        MyBase.WndProc(m)
    End Sub

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub c0400_会計_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        logic = New Habits.Logic.c0400_Logic

        Dim DKO As New DataTable 'D_顧客
        Dim EUR As New DataTable 'E_売上
        Dim ERI As New DataTable  'E_来店者
        Dim param As New Habits.DB.DBParameter
        Dim a As Double
        Dim i As Long

        ' 再会計：伝票ボタンからの遷移かどうか
        If ReCheckDenpyoFlag = True Then
            ' 閉じるボタン非活性
            Me.btn閉じる.Enabled = False
        End If

        '' レシート印刷機能非表示
        If My.MySettings.Default.ReceiptFlag = "1" Then
            btn領収書.Enabled = True
            btn領収書.Visible = True
        Else
            btn領収書.Enabled = False
            btn領収書.Visible = False
        End If

        ' 領収書ボタン非活性
        Me.btn領収書.Enabled = False

        param.Add("@来店日", USER_DATE)
        param.Add("@来店者番号", SER_NO)
        param.Add("@顧客番号", CST_CODE)

        '売上区分別売上の設定
        Call ReDisplay()

        'カード会社リストを設定
        Call カード会社一覧()

        '選択値の設定
        ERI = logic.getVisiter(param)
        Me.lblポイント割引名.Text = ERI.Rows(0)("ポイント割引名").ToString()
        a = CLng(ERI.Rows(0)("ポイント割引支払").ToString())
        Me.lblポイント割引.Text = Format(a, "#,##0")
        Me.lblサービス名.Text = ERI.Rows(0)("サービス名").ToString()
        a = CLng(c0100_売上.txtサービス.Text)
        Me.lblサービス.Text = Format(a, "#,##0")

        '売上一覧の売上、消費税算出
        Me.txt売上一覧小計.Text = 0
        Me.txt売上一覧消費税.Text = 0

        For i = 0 To Me.dgv売上発行.Rows.Count - 1
            Me.txt売上一覧小計.Text += CLng(Me.dgv売上発行.Rows(i).Cells("合計金額").Value) + CLng(Me.dgv売上発行.Rows(i).Cells("サービス").Value)
            Me.txt売上一覧消費税.Text += CLng(Me.dgv売上発行.Rows(i).Cells("消費税").Value)
        Next i

        合計内訳算出()

        If (c0100_売上.btn会計.Text = "会計") Then

            Me.btn登録.Text = "登録"
            Me.txtその他支払.Text = 0
            Me.txtカード支払.Text = 0
            Me.cmbカード会社.SelectedValue = 0
            Me.cmbカード会社.Enabled = False

            Me.txt現金支払.Text = Me.lbl割引後.Text
            Me.txtお預り.Text = 0

            a = CLng(Replace(Me.txtお預り.Text, ",", "")) - CLng(Replace(Me.txt現金支払.Text, ",", ""))
            Me.lblお釣り.Text = Format(a, "#,##0")

        Else    ' 登録済み
            Me.btn登録.Text = "変更"
            EUR = logic.E_売上取得(param)

            a = CLng(EUR.Rows(0)("その他支払").ToString)
            Me.txtその他支払.Text = Format(a, "#,##0")

            a = CLng(EUR.Rows(0)("カード支払").ToString)
            Me.txtカード支払.Text = Format(a, "#,##0")
            If (a <> 0) Then
                Me.cmbカード会社.Enabled = True
            Else
                Me.cmbカード会社.Enabled = False
            End If

            If String.IsNullOrEmpty(EUR.Rows(0)("カード会社番号").ToString()) = False Then
                Me.cmbカード会社.SelectedValue = CLng(EUR.Rows(0)("カード会社番号").ToString)
            End If

            a = CLng(EUR.Rows(0)("現金支払").ToString)
            Me.txt現金支払.Text = Format(a, "#,##0")

            a = CLng(EUR.Rows(0)("お預り").ToString)
            Me.txtお預り.Text = Format(a, "#,##0")

            a = Double.Parse(Replace(Me.txtお預り.Text, ",", "")) - Double.Parse(Replace(Me.txt現金支払.Text, ",", ""))
            Me.lblお釣り.Text = Format(a, "#,##0")
        End If

        DKO = logic.D_顧客取得(param)
        Me.lbl氏名カナ.Text = DKO.Rows(0)(1).ToString
        Me.lbl氏名.Text = DKO.Rows(0)(0).ToString

        If Len(DKO.Rows(0)("生年月日").ToString) = 0 Then
            Me.lbl年齢.Text = "誕生日未設定"

        Else
            Me.lbl年齢.Text = Format(Date.Parse(DKO.Rows(0)("生年月日").ToString), "誕生日　M月d日　")

            If (Mid(Format(Date.Parse(DKO.Rows(0)("生年月日").ToString), "yyyy/MM/dd"), 6, 5) > Mid(Format(USER_DATE, "yyyy/MM/dd"), 6, 5)) Then

                Me.lbl年齢.Text = Me.lbl年齢.Text & CStr(DateDiff("yyyy", DKO.Rows(0)("生年月日").ToString, USER_DATE) - 1) & "才"
            Else
                Me.lbl年齢.Text = Me.lbl年齢.Text & CStr(DateDiff("yyyy", DKO.Rows(0)("生年月日"), USER_DATE)) & "才"
            End If
        End If

        Me.ActiveControl = Me.txtお預り
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub c0400_会計_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ReCheckDenpyoFlag = False ' 再会計時伝票ボタン押下チェックフラグ
        Me.Dispose()
    End Sub
#End Region

#End Region

#Region "ボタン押下"

#Region "領収書ボタン押下"
    ''' <summary>領収書ボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn領収書_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn領収書.Click

        'ブランクレシート印刷
        logic.printBlankReceipt(Replace(lbl割引後.Text, ",", ""), Replace(lbl割引後消費税.Text, ",", ""))
        btn閉じる.Focus()

    End Sub
#End Region

#Region "登録ボタン押下"
    ''' <summary>登録ボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn登録.Click
        Dim EUR As New DataTable ' E_売上
        Dim DKO As New DataTable ' D_顧客
        Dim ERA As New DataTable ' E_来店者
        Dim param As New Habits.DB.DBParameter

        If Not (input_check()) Then Exit Sub

        Try
            ' トランザクション開始
            DBA.TransactionStart()

            param.Add("@来店日", USER_DATE)
            param.Add("@来店者番号", SER_NO)
            param.Add("@顧客番号", CST_CODE)

            param.Add("@性別番号", c0100_売上.性別番号.SelectedValue)

            If c0100_売上.cmbポイント割引.SelectedIndex <> -1 Then
                param.Add("@ポイント割引番号", c0100_売上.cmbポイント割引.SelectedValue)
            Else
                param.Add("@ポイント割引番号", 0)
            End If

            If c0100_売上.txtポイント割引額.Text <> "" Then
                param.Add("@ポイント割引支払", c0100_売上.txtポイント割引額.Text)
            Else
                param.Add("@ポイント割引支払", 0)
            End If

            If c0100_売上.cmbサービス.SelectedIndex <> -1 Then
                param.Add("@サービス番号", c0100_売上.cmbサービス.SelectedValue)
            Else
                param.Add("@サービス番号", 0)
            End If

            If c0100_売上.txtサービス.Text <> "" Then
                param.Add("@サービス金額", c0100_売上.txtサービス.Text)
            Else
                param.Add("@サービス金額", 0)
            End If

            'D_顧客の取得
            DKO = logic.D_顧客取得(param)

            If Len(Trim(DKO.Rows(0)("生年月日").ToString)) = 0 Then
                param.Add("@年齢", 0)
            Else
                If (Mid(Format(Date.Parse(DKO.Rows(0)("生年月日").ToString), "yyyy/MM/dd"), 6, 5) > Mid(Format(USER_DATE, "yyyy/MM/dd"), 6, 5)) Then
                    param.Add("@年齢", CStr(DateDiff("yyyy", DKO.Rows(0)("生年月日").ToString, USER_DATE) - 1))
                Else
                    param.Add("@年齢", CStr(DateDiff("yyyy", DKO.Rows(0)("生年月日").ToString, USER_DATE)))
                End If
            End If

            param.Add("@主担当者番号", c0100_売上.主担当者.SelectedValue)
            param.Add("@来店区分番号", c0100_売上.来店区分.SelectedValue)
            If c0100_売上.指名.Checked = False Then
                param.Add("@指名", 0)
            Else
                param.Add("@指名", 1)
            End If

            param.Add("@カード支払", Replace(Me.txtカード支払.Text, ",", ""))
            If Me.cmbカード会社.SelectedIndex < 0 Then
                param.Add("@カード会社番号", 0)
            Else
                param.Add("@カード会社番号", Me.cmbカード会社.SelectedValue)
            End If
            param.Add("@現金支払", Replace(Me.txt現金支払.Text, ",", ""))
            param.Add("@お預り", Replace(Me.txtお預り.Text, ",", ""))
            param.Add("@消費税", Replace(Me.lbl消費税.Text, ",", ""))
            param.Add("@更新日", Now)
            param.Add("@その他支払", Replace(Me.txtその他支払.Text, ",", ""))

            If (c0100_売上.btn会計.Text = "会計") Then
                'E_売上データ追加
                logic.insert_E_売上(param)
                '在庫数変更（E_入出庫、C_商品）
                在庫変更処理()

            Else
                'E_売上データ修正
                logic.update_E_売上(param)
            End If
            'E_売上明細を会計済に修正
            logic.update会計済_売上明細(param, True, PAGE_TITLE)

            'D_顧客データ修正
            If Integer.Parse(c0100_売上.来店区分.SelectedValue.ToString) = 1 And _
                    Integer.Parse(DKO.Rows(0)("登録区分番号").ToString) = 0 Then
                param.Add("@登録区分番号", 1)
            Else
                param.Add("@登録区分番号", DKO.Rows(0)("登録区分番号").ToString)
            End If

            If Len(Trim(DKO.Rows(0)("前回来店日").ToString)) = 0 Then
                param.Add("@前回来店日", USER_DATE)
                If Not (DKO.Rows(0)("来店日N_2").ToString.Equals("")) Then
                    param.Add("@来店日Ｎ２", DKO.Rows(0)("来店日N_2").ToString)
                Else
                    param.Add("@来店日Ｎ２", System.DBNull.Value)
                End If
                If Not (DKO.Rows(0)("来店日N_1").ToString.Equals("")) Then
                    param.Add("@来店日Ｎ１", DKO.Rows(0)("来店日N_1").ToString)
                Else
                    param.Add("@来店日Ｎ１", System.DBNull.Value)
                End If
            Else
                If Date.Parse(DKO.Rows(0)("前回来店日").ToString) < USER_DATE Then
                    If Not (DKO.Rows(0)("来店日N_1").ToString.Equals("")) Then
                        param.Add("@来店日Ｎ２", DKO.Rows(0)("来店日N_1").ToString)
                    Else
                        param.Add("@来店日Ｎ２", System.DBNull.Value)
                    End If

                    If Not (DKO.Rows(0)("前回来店日").ToString.Equals("")) Then
                        param.Add("@来店日Ｎ１", DKO.Rows(0)("前回来店日").ToString)
                    Else
                        param.Add("@来店日Ｎ１", System.DBNull.Value)
                    End If
                    param.Add("@前回来店日", USER_DATE)
                Else
                    param.Add("@前回来店日", DKO.Rows(0)("前回来店日").ToString)
                    If Not (DKO.Rows(0)("来店日N_2").ToString.Equals("")) Then
                        param.Add("@来店日Ｎ２", DKO.Rows(0)("来店日N_2").ToString)
                    Else
                        param.Add("@来店日Ｎ２", System.DBNull.Value)
                    End If
                    If Not (DKO.Rows(0)("来店日N_1").ToString.Equals("")) Then
                        param.Add("@来店日Ｎ１", DKO.Rows(0)("来店日N_1").ToString)
                    Else
                        param.Add("@来店日Ｎ１", System.DBNull.Value)
                    End If
                End If
            End If

            ERA = logic.E_来店者取得(param)

            If ERA.Rows(0)("会計済").Equals(False) Then
                param.Add("@来店回数", CLng(DKO.Rows(0)("来店回数").ToString) + 1)
            Else
                param.Add("@来店回数", CLng(DKO.Rows(0)("来店回数").ToString))
            End If

            'D_顧客更新
            logic.D_顧客更新(param)

            If ERA.Rows(0)("作業終了").Equals(System.DBNull.Value) Then
                Dim 現在日付 As String
                現在日付 = USER_DATE.Date & Format(Now, " HH:mm:ss")

                param.Add("@作業終了", 現在日付)
            Else
                param.Add("@作業終了", ERA.Rows(0)("作業終了").ToString)
            End If

            'E_来店者更新
            logic.E_来店者更新(param)

            'E_売上取得
            EUR = logic.E_売上取得(param)

            'レシート印刷
            If My.MySettings.Default.ReceiptFlag = 1 Then
                If (c0100_売上.btn会計.Text = "会計" OrElse MsgBox("再会計です。" & Chr(13) & Chr(13) & _
                            "レシートを印刷しますか？　　", Clng_Ynqub2, TTL) = vbYes) Then
                    レシート印刷()
                End If
            End If

            ' コミット
            DBA.TransactionCommit()
        Catch ex As Exception
            ' ロールバック
            DBA.TransactionRollBack()
            Throw ex
        End Try

        c0100_売上.来店区分.SelectedValue = EUR.Rows(0)("来店区分番号").ToString
        c0100_売上.指名.Checked = EUR.Rows(0)("指名").ToString
        c0100_売上.btn会計.Text = "再会計"
        ReCheckFlag = True         '再会計チェックフラグ：再会計
        btn閉じる.Focus()

        ' 再会計：伝票ボタンからの遷移かどうか
        If ReCheckDenpyoFlag = True Then
            ReCheckDenpyoFlag = True
            ' 閉じるボタン活性
            Me.btn閉じる.Enabled = True
        End If
        ' 領収書ボタン活性
        Me.btn領収書.Enabled = True

    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>閉じるボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn閉じる.Click
        c0100_売上.dgv商品一覧.DataSource = Nothing
        Me.Close()
    End Sub
#End Region

#End Region

#Region "キープレスイベント"
    Private Sub 現金支払_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt現金支払.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub カード支払_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtカード支払.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub その他支払_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtその他支払.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub お預り_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtお預り.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub
#End Region

#Region "フォーカス取得時のイベント"
    Private Sub 現金支払_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt現金支払.Enter
        txt現金支払.Text = Replace(Me.txt現金支払.Text, ",", "")
    End Sub

    Private Sub その他支払_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtその他支払.Enter
        txtその他支払.Text = Replace(Me.txtその他支払.Text, ",", "")
    End Sub

    Private Sub カード支払_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtカード支払.Enter
        txtカード支払.Text = Replace(Me.txtカード支払.Text, ",", "")
        Me.cmbカード会社.Enabled = True
    End Sub

    Private Sub お預り_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtお預り.Enter
        txtお預り.Text = Replace(Me.txtお預り.Text, ",", "")
    End Sub
#End Region

#Region "フォーカスが外れた時のイベント"

#Region "現金支払のフォーカス外れ"
    Private Sub txt現金支払_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt現金支払.Leave
        Dim a As Double
        Dim checkText As String

        '現金支払金額のチェック
        checkText = Replace(Me.txt現金支払.Text, ",", "")
        If IsNumeric(checkText) = True Then
            If (CLng(Replace(Me.txtその他支払.Text, ",", "")) + CLng(checkText) _
                >= CLng(Replace(Me.lbl割引後.Text, ",", ""))) Then

                Me.txt現金支払.Text = CLng(Replace(Me.lbl割引後.Text, ",", "")) - CLng(Replace(Me.txtその他支払.Text, ",", ""))
            Else
                a = Double.Parse(checkText)
                Me.txt現金支払.Text = Format(a, "#,##0")
            End If
        Else
            Sys_Error("現金支払 は半角数字9文字以内で入力してください。　", Me.txt現金支払)
            Me.txt現金支払.Text = CLng(Replace(Me.lbl割引後.Text, ",", "")) - CLng(Replace(Me.txtその他支払.Text, ",", "")) + CLng(Replace(Me.txtカード支払.Text, ",", ""))
        End If

        'カード支払金額の算出
        a = Replace(Me.lbl割引後.Text, ",", "") - Replace(Me.txt現金支払.Text, ",", "") - Replace(Me.txtその他支払.Text, ",", "")
        Me.txtカード支払.Text = Format(a, "#,##0")
        If a = 0 Then
            Me.cmbカード会社.SelectedValue = 0
            Me.cmbカード会社.Enabled = False
        End If
        'お釣りの算出
        a = Replace(Me.txtお預り.Text, ",", "") - Replace(Me.txt現金支払.Text, ",", "")
        Me.lblお釣り.Text = Format(a, "#,##0")

    End Sub
#End Region

#Region "その他支払のフォーカス外れ"
    Private Sub txtその他支払_leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtその他支払.Leave
        Dim a As Double
        Dim checkText As String

        'その他支払金額のチェック
        checkText = Replace(Me.txtその他支払.Text, ",", "")
        If IsNumeric(checkText) = True Then
            If (CLng(checkText) >= CLng(Replace(Me.lbl割引後.Text, ",", ""))) Then
                Me.txtその他支払.Text = Me.lbl割引後.Text
                Me.txtお預り.Text = 0
            Else
                a = checkText
                Me.txtその他支払.Text = Format(a, "#,##0")
            End If
        Else
            Sys_Error("その他支払 は半角数字9文字以内で入力してください。　", Me.txtその他支払)
            Me.txtその他支払.Text = 0
        End If

        'カード支払金額のチェック
        If CLng(Replace(Me.txtその他支払.Text, ",", "")) + CLng(Replace(Me.txtカード支払.Text, ",", "")) _
            >= CLng(Replace(Me.lbl割引後.Text, ",", "")) Then
            a = Replace(Me.lbl割引後.Text, ",", "") - Replace(Me.txtその他支払.Text, ",", "")
            Me.txtカード支払.Text = Format(a, "#,##0")
            Me.txtお預り.Text = 0
            If a = 0 Then
                Me.cmbカード会社.SelectedValue = 0
                Me.cmbカード会社.Enabled = False
            End If
        End If

        '現金支払の算出
        a = Replace(Me.lbl割引後.Text, ",", "") - Replace(Me.txtカード支払.Text, ",", "") - Replace(Me.txtその他支払.Text, ",", "")
        Me.txt現金支払.Text = Format(a, "#,##0")
        'お釣りの算出
        a = Replace(Me.txtお預り.Text, ",", "") - Replace(Me.txt現金支払.Text, ",", "")
        Me.lblお釣り.Text = Format(a, "#,##0")
    End Sub
#End Region

#Region "カード支払のフォーカス外れ"
    Private Sub txtカード支払_leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtカード支払.Leave
        Dim a As Double
        Dim checkText As String

        'カード支払金額のチェック
        checkText = Replace(Me.txtカード支払.Text, ",", "")
        If IsNumeric(checkText) = True Then
            If (CLng(Replace(Me.txtその他支払.Text, ",", "")) + CLng(checkText) _
                >= CLng(Replace(Me.lbl割引後.Text, ",", ""))) Then
                Me.txtお預り.Text = 0
                a = Replace(Me.lbl割引後.Text, ",", "") - Replace(Me.txtその他支払.Text, ",", "")
            Else
                a = checkText
            End If
            Me.txtカード支払.Text = Format(a, "#,##0")
        Else
            Sys_Error("カード支払 は半角数字9文字以内で入力してください。　", Me.txtカード支払)
            Me.txtカード支払.Text = 0
        End If

        If (Replace(Me.txtカード支払.Text, ",", "") <> 0) Then
            Me.cmbカード会社.Enabled = True
        Else
            Me.cmbカード会社.SelectedValue = 0
            Me.cmbカード会社.Enabled = False
        End If

        '現金支払の算出
        a = Replace(Me.lbl割引後.Text, ",", "") - Replace(Me.txtカード支払.Text, ",", "") - Replace(Me.txtその他支払.Text, ",", "")
        Me.txt現金支払.Text = Format(a, "#,##0")
        'お釣りの算出
        a = Replace(Me.txtお預り.Text, ",", "") - Replace(Me.txt現金支払.Text, ",", "")
        Me.lblお釣り.Text = Format(a, "#,##0")
    End Sub
#End Region

#Region "お預りのフォーカス外れ"
    Private Sub txtお預り_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtお預り.Leave
        C_釣り銭計算処理()
    End Sub
#End Region

#End Region

#Region "キーダウンイベント"
    Private Sub 現金支払_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt現金支払.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtその他支払.Focus()
        End If
    End Sub

    Private Sub その他支払_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtその他支払.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtカード支払.Focus()
        End If
    End Sub

    Private Sub カード支払_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtカード支払.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.cmbカード会社.Focus()
        End If
    End Sub

    Private Sub カード会社_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbカード会社.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtお預り.Focus()
        End If
    End Sub

    Private Sub お預り_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtお預り.KeyDown
        If (e.KeyData.Equals(System.Windows.Forms.Keys.Enter)) Then
            C_釣り銭計算処理()
            Me.btn登録.Focus()
        End If
    End Sub
#End Region

#Region "メソッド"

#Region "レシート印刷"
    Private Sub レシート印刷()
        Dim i As Integer
        Dim service As Long = 0
        Dim pointPurchases As Long = 0

        Try
            'W_レシート削除
            logic.W_レシート削除()

            '割引の算出
            If lblポイント割引.Text <> "" Then
                pointPurchases = CLng(Me.lblポイント割引.Text)
            End If
            If lblサービス.Text <> "" Then
                service = CLng(Me.lblサービス.Text)
            End If
            j = 0
            ''W_レシート登録
            If (My.Settings.PrinterLogoFlag = 0) Then
                '社名印字
                W_レシート追加(0, My.Settings.CompanyName.ToString, 0, 0)
            End If

            For i = 0 To c0100_売上.dgv売上一覧.RowCount - 1
                j += 1
                '売上詳細行(売上)
                W_レシート追加(1, c0100_売上.dgv売上一覧.Rows(i).Cells(2).Value, c0100_売上.dgv売上一覧.Rows(i).Cells(3).Value, c0100_売上.dgv売上一覧.Rows(i).Cells(4).Value)

                '売上詳細行(サービス)
                If c0100_売上.dgv売上一覧.Rows(i).Cells(5).Value.ToString() <> 0 Then
                    W_レシート追加(1, "　　割引", 0, c0100_売上.dgv売上一覧.Rows(i).Cells(5).Value.ToString())
                End If
            Next

            'サービス値引行
            W_レシート追加(2, "割引", 0, service * -1)

            'ポイント割引行
            If pointPurchases <> 0 Then
                W_レシート追加(3, lblポイント割引名.Text, 0, pointPurchases * -1)
                W_レシート追加(4, lblポイント割引名.Text + "後", 0, CLng(Replace(Me.lbl割引後.Text, ",", "")))
            End If

            '支払行
            W_レシート追加(5, "カード支払", 0, CLng(Replace(Me.txtカード支払.Text, ",", "")))
            W_レシート追加(5, "その他支払", 0, CLng(Replace(Me.txtその他支払.Text, ",", "")))

            W_レシート追加(5, "お預り", 0, CLng(Replace(Me.txtお預り.Text, ",", "")))

            '  引数：
            '       レポート名
            '       データソース名
            '       データソース
            '       プリンタ True：いつも使うプリンター False: 設定されたプリンタ
            '       0:印刷 / 1:プレビュー
            '       印刷の向き True：横 / False:縦
            '       印刷サイズ
            rtn = Rep_Print("c0401_レシート.rdlc", "DS0001_レシート", logic.getReceipt(), False, 0, False, 2)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region

#Region "W_レシート追加"
    ''' <summary>
    ''' W_レシート追加
    ''' </summary>
    ''' <param name="type">データタイプ（1：売上詳細、2：ポイント割引、3：ポイント割引後、4：支払）</param>
    ''' <param name="name">品名</param>
    ''' <param name="num">数量</param>
    ''' <param name="amount">金額</param>
    ''' <remarks></remarks>
    Private Sub W_レシート追加(ByVal type As Integer, ByVal name As String, ByVal num As Integer, ByVal amount As Integer)
        If amount <> 0 OrElse type = 0 OrElse type = 1 Then
            param.Clear()
            j += 1
            param.Add("@データタイプ", type)
            param.Add("@番号", j)
            param.Add("@氏名", c0100_売上.氏名.Text)
            param.Add("@主担当者名", c0100_売上.主担当者.Text)
            param.Add("@品名", name)
            param.Add("@数量", num)
            param.Add("@金額", amount)
            param.Add("@小計", CLng(Me.lbl合計.Text))
            param.Add("@消費税", CLng(Replace(Me.lbl消費税.Text, ",", "")))
            param.Add("@合計", CLng(Replace(Me.lbl割引後.Text, ",", "")))
            param.Add("@お釣り", CLng(Replace(Me.lblお釣り.Text, ",", "")))

            'Wレシート追加
            logic.insertW_Receipt(param)
        End If
    End Sub
#End Region

#Region "入力チェック"
    ''' <summary>入力チェック</summary>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        Dim money As Integer
        input_check = False

        '現金支払チェック
        If Sys_InputCheck(Replace(Me.txt現金支払.Text, ",", ""), 10, "N+", 1) Then
            Call Sys_Error("現金支払 は 0～2,147,483,647の半角数字で入力してください。　", Me.txt現金支払)
            Exit Function
        Else
            Try
                money = Integer.Parse(Replace(Me.txt現金支払.Text, ",", ""))
            Catch ex As OverflowException
                Sys_Error("現金支払 は 0～2,147,483,647の半角数字で入力してください。　", Me.txt現金支払)
                Exit Function
            End Try
        End If

        'その他支払チェック
        If Sys_InputCheck(Replace(Me.txtその他支払.Text, ",", ""), 10, "N+", 1) Then
            Call Sys_Error("その他支払 は 0～2,147,483,647の半角数字で入力してください。　", Me.txtその他支払)
            Exit Function
        Else
            Try
                money = Integer.Parse(Replace(Me.txtその他支払.Text, ",", ""))
            Catch ex As OverflowException
                Sys_Error("その他支払 は 0～2,147,483,647の半角数字で入力してください。　", Me.txtその他支払)
                Exit Function
            End Try
        End If

        'カード支払チェック
        If Sys_InputCheck(Replace(Me.txtカード支払.Text, ",", ""), 10, "N+", 1) Then
            Call Sys_Error("カード支払 は 0～2,147,483,647の半角数字で入力してください。　", Me.txtカード支払)
            Exit Function
        Else
            Try
                money = Integer.Parse(Replace(Me.txtカード支払.Text, ",", ""))
            Catch ex As OverflowException
                Sys_Error("カード支払 は 0～2,147,483,647の半角数字で入力してください。　", Me.txtカード支払)
                Exit Function
            End Try
        End If

        If CLng(Replace(Me.txtカード支払.Text, ",", "")) <> 0 AndAlso _
           (Len(Trim(Me.cmbカード会社.Text)) = 0 Or Me.cmbカード会社.Text = "未設定") Then
            Call Sys_Error("カード会社 が選択されていません。　", Me.cmbカード会社)
            Exit Function
        End If

        '現金支払論理チェック
        If (CLng(Replace(Me.txt現金支払.Text, ",", "")) _
                + CLng(Replace(Me.txtその他支払.Text, ",", ""))) _
                + CLng(Replace(Me.txtカード支払.Text, ",", "")) _
            <> CLng(Replace(Me.lbl割引後.Text, ",", "")) Then
            Call Sys_Error("現金支払 が不正です。　", Me.txt現金支払)
            Exit Function
        End If

        If Sys_InputCheck(Replace(Me.txtお預り.Text, ",", ""), 10, "N+", 1) Then
            Call Sys_Error("お預り は0～2,147,483,647で入力してください。　", Me.txtお預り)
            Exit Function
        Else
            Try
                money = Integer.Parse(Replace(Me.txtお預り.Text, ",", ""))
            Catch ex As OverflowException
                Sys_Error("お預り は 0～2,147,483,647の半角数字で入力してください。　", Me.txtお預り)
                Exit Function
            End Try
        End If

        If (Replace(Me.lblお釣り.Text, ",", "") < 0) Then
            Call Sys_Error("お預り が不足しています。　", Me.txtお預り)
            Exit Function
        End If
        input_check = True

    End Function
#End Region

#Region "画面再表示処理"
    ''' <summary>
    ''' 画面再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReDisplay()
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        If a0200_メイン.dgv来店者一覧.SelectedRows.Count <> 0 Or _
           a0200_メイン.dgv会計済み一覧.SelectedRows.Count <> 0 Then
            'パラメータ設定（@来店日/@来店者番号/@顧客番号）
            param.Add("@来店日", USER_DATE)
            param.Add("@来店者番号", SER_NO)
            param.Add("@顧客番号", CST_CODE)
        Else
            MsgBox("来店者がいません。　　　　" & Chr(13), Clng_Okexb1, TTL)
            Exit Sub
        End If

        Me.dgv売上発行.DataSource = logic.売上区分別売上リスト取得(param)

        Me.dgv売上発行.Columns("来店日").Visible = False
        Me.dgv売上発行.Columns("来店者番号").Visible = False
        Me.dgv売上発行.Columns("顧客番号").Visible = False
        Me.dgv売上発行.Columns("売上区分番号").Visible = False
        Me.dgv売上発行.Columns("売上区分").Width = 166
        Me.dgv売上発行.Columns("合計数量").Visible = False
        Me.dgv売上発行.Columns("合計金額").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv売上発行.Columns("合計金額").DefaultCellStyle.Format = "#,##0"
        Me.dgv売上発行.Columns("合計金額").Width = 109
        Me.dgv売上発行.Columns("サービス").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv売上発行.Columns("サービス").DefaultCellStyle.Format = "#,##0"
        Me.dgv売上発行.Columns("サービス").Width = 109
        Me.dgv売上発行.Columns("消費税").Visible = False

        Me.dgv売上発行.ClearSelection()

    End Sub
#End Region

#Region "カード会社一覧設定"
    ''' <summary>
    ''' コンボボックス設定（カード会社一覧）
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub カード会社一覧()
        Dim dt As New DataTable
        dt = logic.カード会社リスト取得

        cmbカード会社.DataSource = dt
        cmbカード会社.DisplayMember = "カード会社名"
        cmbカード会社.ValueMember = "カード会社番号"
    End Sub
#End Region

#Region "在庫変更処理"
    Private Sub 在庫変更処理()
        Dim EUM As New DataTable 'E_売上明細
        Dim CSH As New DataTable 'C_商品
        Dim param As New Habits.DB.DBParameter
        Dim i As Long
        Dim stock As Long

        param.Add("@来店日", USER_DATE)
        param.Add("@来店者番号", SER_NO)
        param.Add("@顧客番号", CST_CODE)

        EUM = logic.E_売上明細_店販(param)

        For i = 0 To EUM.Rows.Count - 1
            param.Clear()
            param.Add("@入出庫日", USER_DATE)
            param.Add("@入出庫番号", logic.E_次入出庫番号取得(USER_DATE))
            param.Add("@入出庫区分番号", 2)
            param.Add("@入出庫理由番号", 30)
            param.Add("@売上区分番号", EUM.Rows(i)("売上区分番号").ToString)
            param.Add("@分類番号", EUM.Rows(i)("分類番号").ToString)
            param.Add("@商品番号", EUM.Rows(i)("名称番号").ToString)
            param.Add("@入出庫数", EUM.Rows(i)("数量").ToString)
            param.Add("@担当者番号", EUM.Rows(i)("売上担当者番号").ToString)
            param.Add("@登録日", Now)
            param.Add("@更新日", Now)

            logic.E_入出庫追加(param)

            'C_商品在庫数変更
            CSH = logic.C_商品在庫数取得(param)
            stock = CLng(CSH.Rows(0)("在庫数").ToString - EUM.Rows(i)("数量").ToString)

            If stock < -2147483648 Then
                MsgBox("在庫数が-2,147,483,648～2,147,483,647を超えるため　" & Chr(13) & _
                          "在庫数を変更しません。　", Clng_Okexb1, TTL)
                param.Add("@在庫数", -2147483648)
            Else
                param.Add("@在庫数", CLng(CSH.Rows(0)("在庫数").ToString) - CLng(EUM.Rows(i)("数量").ToString))
            End If

            'C_商品を更新
            logic.C_商品在庫数更新(param)

            If item_mode = True Then
                If CLng(CSH.Rows(0)("在庫数").ToString) - CLng(EUM.Rows(i)("数量").ToString) <= 0 Then
                    MsgBox("商品の在庫数が不足しております。　", Clng_Okexb1, TTL)
                End If
            End If
        Next i
    End Sub
#End Region

#Region "合計内訳算出"
    ''' <summary>
    ''' 合計内訳算出
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 合計内訳算出()
        Dim service As Integer = 0
        Dim point As Integer = 0

        service = Replace(lblサービス.Text, ",", "")
        point = Replace(lblポイント割引.Text, ",", "")

        Me.lbl合計.Text = Format(txt売上一覧小計.Text - service, "#,##0")
        Me.lbl消費税.Text = Format(txt売上一覧消費税.Text - Sys_Tax(service, USER_DATE, 1), "#,##0")

        Me.lbl割引後.Text = Format(txt売上一覧小計.Text - service - point, "#,##0")
        Me.lbl割引後消費税.Text = Format(txt売上一覧消費税.Text - Sys_Tax(service, USER_DATE, 1) - Sys_Tax(point, USER_DATE, 1), "#,##0")
    End Sub
#End Region

#Region "おつり計算"
    ''' <summary>
    ''' おつり計算
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub C_釣り銭計算処理()
        Dim a As Double
        Dim checkText As String

        checkText = Replace(Me.txtお預り.Text, ",", "")
        If IsNumeric(checkText) = True Then
            a = checkText
            Me.txtお預り.Text = Format(a, "#,##0")

            a = Replace(Me.txtお預り.Text, ",", "") - Replace(Me.txt現金支払.Text, ",", "")
            Me.lblお釣り.Text = Format(a, "#,##0")

            RemoveHandler txtお預り.Leave, AddressOf txtお預り_Leave
            Me.btn登録.Focus()
            AddHandler txtお預り.Leave, AddressOf txtお預り_Leave
        Else
            Call Sys_Error("お預り は半角数字9文字以内で入力してください。　", Me.txtお預り)
            Me.txtお預り.Text = 0
            a = Replace(Me.txtお預り.Text, ",", "") _
                + Replace(Me.txtその他支払.Text, ",", "") _
                + Replace(Me.txtカード支払.Text, ",", "") _
                - Replace(Me.lbl割引後.Text, ",", "")
            Me.lblお釣り.Text = Format(a, "#,##0")
        End If
    End Sub
#End Region

#End Region

End Class
