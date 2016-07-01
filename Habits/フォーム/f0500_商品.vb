''' <summary>f0500_商品画面処理</summary>
''' <remarks></remarks>
Public Class f0500_商品

    '初期表示パラメータ
    Private Initial_売上区分番号 As String = Nothing
    Private Initial_分類番号 As String = Nothing

    Private Next_商品番号 As String = Nothing
    Private buy, sale As String
    Private w_buy, w_sale As Double
    Private SelectionChangeLocked_dgv商品一覧 As Boolean = False
    Private logic As Habits.Logic.f0500_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0500_商品_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        logic = New Habits.Logic.f0500_Logic    '' ロジッククラス生成
        ReDisplay()                             ''コンボボックス、ボタン設定

        ''初期選択
        If Not String.IsNullOrEmpty(Initial_売上区分番号) Then

            Me.売上区分.SelectedValue = Initial_売上区分番号
            売上区分_SelectionChangeCommitted(Nothing, Nothing)

            If Not String.IsNullOrEmpty(Initial_分類番号) Then
                Me.分類.SelectedValue = Initial_分類番号
                分類_SelectionChangeCommitted(Nothing, Nothing)
            End If
        End If

        ''初期表示パラメータ初期化
        Initial_売上区分番号 = Nothing
        Initial_分類番号 = Nothing

        ''背後の表示中画面への遷移防止
        If f0500_売上区分.Visible Then
            Me.売上区分編集.Enabled = False
        Else
            Me.売上区分編集.Enabled = True
        End If

        If f0500_分類.Visible Then
            Me.分類編集.Enabled = False
        Else
            Me.分類編集.Enabled = True
        End If
        SetEnable_入力項目(False)
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0500_商品_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "売上区分変更"
    ''' <summary>売上区分変更</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 売上区分_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 売上区分.SelectionChangeCommitted
        ReDisplay_分類()
    End Sub
#End Region

#Region "分類変更"
    ''' <summary>分類変更</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 分類_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 分類.SelectionChangeCommitted
        ReDisplay_dgv商品一覧()

        '' 新規ボタン活性
        Me.新規.Enabled = True
    End Sub
#End Region

#Region "商品一覧変更"
    ''' <summary>商品一覧変更</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv商品一覧_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv商品一覧.SelectionChanged
        If SelectionChangeLocked_dgv商品一覧 = False Then
            ReDisplay_入力項目()
        End If
    End Sub
#End Region

#Region "商品一覧ソート"
    ''' <summary>商品一覧ソート</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv商品一覧_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv商品一覧.Sorted
        ReDisplay_入力項目()
    End Sub
#End Region

#Region "キーダウンイベント"
    Private Sub txt商品名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt商品名.KeyDown
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
            If Me.txt標準時間.Visible Then
                Me.txt標準時間.Focus()
            Else
                Me.txtメーカー名.Focus()
            End If
        End If
    End Sub

    Private Sub txt標準時間_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt標準時間.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt販売金額.Focus()
        End If
    End Sub

    Private Sub txtメーカー名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtメーカー名.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt仕入金額.Focus()
        End If
    End Sub

    Private Sub txt仕入金額_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt仕入金額.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt販売金額.Focus()

        End If
    End Sub

    Private Sub txt販売金額_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt販売金額.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            If Me.txt在庫数.Visible Then
                Me.txt在庫数.Focus()
            Else
                Me.登録.Focus()
            End If
        End If
    End Sub

    Private Sub txt在庫数_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt在庫数.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt発注点.Focus()
        End If
    End Sub

    Private Sub txt発注点_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt発注点.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.既定在庫数.Focus()
        End If
    End Sub

    Private Sub 既定在庫数_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 既定在庫数.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.登録.Focus()
        End If
    End Sub
#End Region

#Region "キープレスイベント"
    Private Sub txt表示順_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt表示順.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txt標準時間_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt標準時間.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txt仕入金額_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt仕入金額.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txt販売金額_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt販売金額.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txt在庫数_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt在庫数.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txt発注点_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt発注点.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub 既定在庫数_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles 既定在庫数.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

#End Region

#Region "フォーカスイベント"
    Private Sub txt表示順_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt表示順.Enter
        txt表示順.Text = Replace(Me.txt表示順.Text, ",", "")
    End Sub

    Private Sub txt標準時間_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt標準時間.Enter
        txt標準時間.Text = Replace(Me.txt標準時間.Text, ",", "")
    End Sub

    Private Sub txt仕入金額_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt仕入金額.Enter
        txt仕入金額.Text = Replace(Me.txt仕入金額.Text, ",", "")
    End Sub

    Private Sub txt販売金額_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt販売金額.Enter
        txt販売金額.Text = Replace(Me.txt販売金額.Text, ",", "")
    End Sub

    Private Sub txt在庫数_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt在庫数.Enter
        txt在庫数.Text = Replace(Me.txt在庫数.Text, ",", "")
    End Sub

    Private Sub txt発注点_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt発注点.Enter
        txt発注点.Text = Replace(Me.txt発注点.Text, ",", "")
    End Sub

    Private Sub 既定在庫数_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 既定在庫数.Enter
        既定在庫数.Text = Replace(Me.既定在庫数.Text, ",", "")
    End Sub

#End Region

#Region "入力チェックイベント"
    Private Sub txt仕入金額_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt仕入金額.Validated
        If Me.txt仕入金額.Text <> Nothing Then
            Me.txt仕入金額.Text = Replace(Me.txt仕入金額.Text, ",", "")

            '仕入金額チェック
            If (input_check_purchase()) Then
                'buy = StrConv(Me.txt仕入金額.Text, VbStrConv.Narrow)
                'w_buy = buy
                w_buy = Double.Parse(Me.txt仕入金額.Text)
                Me.txt仕入金額.Text = Format(w_buy, "#,##0")
                RemoveHandler txt仕入金額.Validated, AddressOf txt仕入金額_Validated
                Me.txt販売金額.Focus()
                AddHandler txt仕入金額.Validated, AddressOf txt仕入金額_Validated
            Else
                Me.txt仕入金額.Focus()
            End If
        End If
    End Sub

    Private Sub txt販売金額_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt販売金額.Validated
        If Me.txt販売金額.Text <> Nothing Then
            Me.txt販売金額.Text = Replace(Me.txt販売金額.Text, ",", "")

            '販売金額チェック
            If (input_check_buy()) Then
                'sale = StrConv(Me.txt販売金額.Text, VbStrConv.Narrow)
                'w_sale = sale
                w_sale = Double.Parse(Me.txt販売金額.Text)
                Me.txt販売金額.Text = Format(w_sale, "#,##0")
                RemoveHandler txt販売金額.Validated, AddressOf txt販売金額_Validated
                If Me.txt在庫数.Visible Then
                    Me.txt在庫数.Focus()
                Else
                    Me.登録.Focus()
                End If
                AddHandler txt販売金額.Validated, AddressOf txt販売金額_Validated
            Else
                Me.txt販売金額.Focus()
            End If
        End If
    End Sub

    Private Sub txt在庫数_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt在庫数.Validated
        If Me.txt在庫数.Text <> Nothing Then
            Me.txt在庫数.Text = Replace(Me.txt在庫数.Text, ",", "")

            '在庫数チェック
            If (input_check_stock()) Then
                'buy = StrConv(Me.txt在庫数.Text, VbStrConv.Narrow)
                'w_buy = buy
                w_buy = Double.Parse(Me.txt在庫数.Text)
                Me.txt在庫数.Text = Format(w_buy, "#,##0")
                RemoveHandler txt在庫数.Validated, AddressOf txt在庫数_Validated
                Me.txt発注点.Focus()
                AddHandler txt在庫数.Validated, AddressOf txt在庫数_Validated
            Else
                Me.txt在庫数.Focus()
            End If
        End If
    End Sub

    Private Sub txt発注点_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt発注点.Validated
        If Me.txt発注点.Text <> Nothing Then
            Me.txt発注点.Text = Replace(Me.txt発注点.Text, ",", "")

            '発注点チェック
            If (input_check_order()) Then
                'buy = StrConv(Me.txt発注点.Text, VbStrConv.Narrow)
                'w_buy = buy
                w_buy = Double.Parse(Me.txt発注点.Text)
                Me.txt発注点.Text = Format(w_buy, "#,##0")
                RemoveHandler txt発注点.Validated, AddressOf txt発注点_Validated
                Me.既定在庫数.Focus()
                AddHandler txt発注点.Validated, AddressOf txt発注点_Validated
            Else
                Me.txt発注点.Focus()
            End If
        End If
    End Sub

    Private Sub 既定在庫数_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles 既定在庫数.Validated
        If Me.既定在庫数.Text <> Nothing Then
            Me.既定在庫数.Text = Replace(Me.既定在庫数.Text, ",", "")

            '既定在庫数チェック
            If (input_check_fixedStock()) Then
                'buy = StrConv(Me.既定在庫数.Text, VbStrConv.Narrow)
                'w_buy = buy
                w_buy = Double.Parse(Me.既定在庫数.Text)
                Me.既定在庫数.Text = Format(w_buy, "#,##0")
                RemoveHandler 既定在庫数.Validated, AddressOf 既定在庫数_Validated
                Me.登録.Focus()
                AddHandler 既定在庫数.Validated, AddressOf 既定在庫数_Validated
            Else
                Me.既定在庫数.Focus()
            End If
        End If
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "売上区分編集ボタン押下"
    ''' <summary>売上区分編集ボタン押下</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 売上区分編集_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 売上区分編集.Click
        Dim salesDiv As String
        salesDiv = 売上区分.SelectedValue

        f0500_売上区分.ShowDialog()
        ReDisplay_売上区分()
        If Not String.IsNullOrEmpty(salesDiv) Then
            売上区分.SelectedValue = salesDiv
        End If
    End Sub
#End Region

#Region "分類編集ボタン押下"
    ''' <summary>分類編集ボタン押下</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 分類編集_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 分類編集.Click
        Dim classCode As String
        classCode = 分類.SelectedValue

        If Me.売上区分.SelectedIndex >= 0 Then
            f0500_分類.ShowDialogWithParam(Me.売上区分.SelectedValue)
        Else
            f0500_分類.ShowDialog()
        End If
        ReDisplay_分類()
        If Not String.IsNullOrEmpty(classCode) Then
            分類.SelectedValue = classCode
            ReDisplay_dgv商品一覧()
        End If
    End Sub
#End Region

#Region "新規ボタン押下"
    ''' <summary>新規ボタン押下</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 新規_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新規.Click
        If Integer.Parse(Next_商品番号) <= Max_MasterNo Then
            Me.dgv商品一覧.ClearSelection()
            Me.lbl商品番号.Text = Next_商品番号
            Clear_入力項目()
            SetEnable_入力項目(True)

            Me.登録.Text = "登録"
        Else
            Sys_Error("登録最大数に達したため登録できません。　", Me.閉じる)
        End If
        Me.txt商品名.Focus()
    End Sub
#End Region

#Region "登録ボタン押下"
    ''' <summary>登録ボタン押下</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 登録.Click
        Dim param As New Habits.DB.DBParameter
        Dim tmp登録 As String = Me.登録.Text

        ''入力チェック
        If Not (input_check()) Then Exit Sub

        '共通パラメータ値設定
        param.Add("@売上区分番号", Me.売上区分.SelectedValue)
        param.Add("@分類番号", Me.分類.SelectedValue)
        param.Add("@商品番号", Me.lbl商品番号.Text)
        param.Add("@商品名", Me.txt商品名.Text)
        param.Add("@販売金額", Replace(Me.txt販売金額.Text, ",", ""))
        param.Add("@表示順", Me.txt表示順.Text)
        param.Add("@削除フラグ", IIf(Me.削除フラグ.Checked, "1", "0"))
        param.Add("@登録日", Now())
        param.Add("@更新日", Now())
        param.Add("@金額管理区分", IIf(Me.rbnWithoutTax.Checked, "1", "2"))

        If Get_店販対象フラグ() Then
            ''店販対象の場合 （C_分類.店販対象フラグ=True）
            param.Add("@メーカー番号", Me.txtメーカー名.SelectedValue)
            param.Add("@仕入金額", Replace(Me.txt仕入金額.Text, ",", ""))
            param.Add("@在庫数", Replace(Me.txt在庫数.Text, ",", ""))
            param.Add("@発注点", Replace(Me.txt発注点.Text, ",", ""))
            param.Add("@既定在庫数", Replace(Me.既定在庫数.Text, ",", ""))

            If String.Equals(Me.登録.Text, "登録") Then
                ''登録
                logic.CommodityInsert(param, True)
            Else
                ''更新
                logic.CommodityUpdate(param, True)
            End If
        Else
            ''店販対象外場合
            param.Add("@標準時間", Me.txt標準時間.Text)

            If String.Equals(Me.登録.Text, "登録") Then
                ''登録
                logic.CommodityInsert(param, False)
            Else
                ''更新
                logic.CommodityUpdate(param, False)
            End If
        End If

        Me.lbl商品番号.Text = ""
        ReDisplay_dgv商品一覧()
        MsgBox(tmp登録 & "しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
        SetEnable_入力項目(False)
        Me.新規.Focus()
    End Sub
#End Region

#Region "項目クリアボタン押下"
    ''' <summary>項目クリアボタン押下</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 項目クリア_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 項目クリア.Click
        Me.dgv商品一覧.ClearSelection()
        Clear_入力項目()
        lbl商品番号.Text = Nothing
        Me.登録.Text = "変更"
        SetEnable_入力項目(False)
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>閉じるボタン押下</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub
#End Region

#Region "工程ボタン押下"
    ''' <summary>工程ボタン押下</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 工程_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 工程.Click
        If Me.dgv商品一覧.SelectedRows.Count <> 0 Then
            f1000_工程.商品番号.Text = Me.lbl商品番号.Text
            f1000_工程.商品名.Text = Me.txt商品名.Text
            f1000_工程.売上区分番号.Text = Me.売上区分.SelectedValue.ToString
            f1000_工程.分類番号.Text = Me.分類.SelectedValue.ToString

            f1000_工程.分類番号.Focus()
            f1000_工程.ShowDialog()
        Else
            Call Sys_Error("商品を選択してください。　", Me.工程)
        End If
    End Sub
#End Region

#End Region

#Region "メソッド"

#Region "引数指定付きダイアログ表示"
    ''' <summary>引数指定付きダイアログ表示</summary>
    ''' <param name="v_number_売上区分番号">売上区分番号</param>
    ''' <param name="v_number_分類番号">分類番号</param>
    ''' <remarks></remarks>
    Public Sub ShowDialogWithParam(ByVal v_number_売上区分番号 As String, ByVal v_number_分類番号 As String)
        Initial_売上区分番号 = v_number_売上区分番号
        Initial_分類番号 = v_number_分類番号
        ShowDialog()
    End Sub
#End Region

#Region "入力チェック"
    ''' <summary>入力チェック</summary>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        Dim str As String
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        input_check = False

        Me.lbl商品番号.Text = Trim(Me.lbl商品番号.Text)
        str = Me.lbl商品番号.Text
        If (Sys_InputCheck(str, 4, "N+", 1)) Then
            Call Sys_Error("商品番号 が不正です。　", Me.lbl商品番号)
            Exit Function
        End If

        Me.txt商品名.Text = Trim(Me.txt商品名.Text)
        str = Me.txt商品名.Text
        If String.IsNullOrEmpty(str) Then
            Call Sys_Error("商品名 は必須入力です。　", Me.txt商品名)
            Exit Function
        End If
        If (Sys_InputCheck(str, 32, "M", 1)) Then
            Call Sys_Error("商品名 は32文字以内で入力してください。　", Me.txt商品名)
            Exit Function
        End If

        Me.txt表示順.Text = Trim(Me.txt表示順.Text)
        str = Me.txt表示順.Text
        If String.IsNullOrEmpty(str) Then
            Call Sys_Error("表示順 は必須入力です。　", Me.txt表示順)
            Exit Function
        End If
        If Sys_Zenkaku(str) Then
            Call Sys_Error("表示順 は半角数字で入力してください。　", Me.txt表示順)
            Exit Function
        End If
        str = Me.txt表示順.Text
        If (Sys_InputCheck(str, 4, "N+", 1)) Then
            Call Sys_Error("表示順 は半角数字4文字以内で入力してください。　", Me.txt表示順)
            Exit Function
        End If

        If Get_店販対象フラグ() Then
            ''店販対象の場合 （C_分類.店販対象フラグ=True）
            If Me.txtメーカー名.SelectedIndex < 0 Then
                Call Sys_Error("メーカー名 を選択してください。　", Me.txtメーカー名)
                Exit Function
            Else
                str = Me.txtメーカー名.SelectedValue
                If (Sys_InputCheck(str, 4, "N+", 1)) Then
                    Call Sys_Error("メーカー が不正です。　", Me.txtメーカー名)
                    Exit Function
                End If
            End If

            '仕入金額チェック
            If Not input_check_purchase() Then Exit Function

            '販売金額チェック
            If Not input_check_buy() Then Exit Function

            '在庫数チェック
            If Not input_check_stock() Then Exit Function

            '発注点チェック
            If Not input_check_order() Then Exit Function

            '既定在庫数チェック
            If Not input_check_fixedStock() Then Exit Function

            '発注点と既定在庫数の論理チェック
            If Integer.Parse(Replace(Me.txt発注点.Text, ",", "")) > Integer.Parse(Replace(Me.既定在庫数.Text, ",", "")) Then
                Call Sys_Error("発注点 は既定在庫数以下の数字を入力してください。　", Me.txt発注点)
                Exit Function
            End If
        Else
            ''店販対象外場合
            Me.txt標準時間.Text = Trim(Me.txt標準時間.Text)
            str = Me.txt標準時間.Text
            If String.IsNullOrEmpty(str) Then
                Call Sys_Error("標準時間 は必須入力です。　", Me.txt標準時間)
                Exit Function
            End If
            If Sys_Zenkaku(str) Then
                Call Sys_Error("標準時間 は半角数字で入力してください。　", Me.txt標準時間)
                Exit Function
            End If
            If (Sys_InputCheck(str, 4, "N+", 1)) Then
                Call Sys_Error("標準時間 は半角数字4文字以内で入力してください。　", Me.txt標準時間)
                Exit Function
            End If

            '販売金額チェック
            If Not input_check_buy() Then Exit Function
        End If

        Select Case Me.登録.Text
            Case "登録"
                If Me.dgv商品一覧.Rows.Count <> 0 AndAlso DataTableSelect(Me.dgv商品一覧.DataSource, _
                                        "No = " & Me.lbl商品番号.Text) Then

                    Call Sys_Error("指定された商品番号は既に登録されています。　", Me.lbl商品番号)
                    Exit Function
                End If

                param.Add("@売上区分番号", Me.売上区分.SelectedValue)
                param.Add("@分類番号", Me.分類.SelectedValue)
                param.Add("@商品名", Me.txt商品名.Text)
                dt = logic.checkDuplicate(param)
                param.Clear()
                If dt.Rows.Count <> 0 Then
                    Call Sys_Error("入力した商品名は登録済です。　" & Chr(13) & Chr(13) & "商品名を変更して登録してください。　", Me.txt商品名)
                    Exit Function
                End If

            Case "変更"
                param.Add("@売上区分番号", Me.売上区分.SelectedValue)
                param.Add("@分類番号", Me.分類.SelectedValue)
                param.Add("@商品名", Me.txt商品名.Text)
                dt = logic.checkDuplicate(param)
                If Me.txt商品名.Text = Me.dgv商品一覧.SelectedRows(0).Cells("商品名").Value.ToString Then
                    Exit Select
                ElseIf dt.Rows.Count <> 0 Then
                    Call Sys_Error("入力した商品名は登録済です。　" & Chr(13) & Chr(13) & "商品名を変更して登録してください。　", Me.txt商品名)
                    Exit Function
                End If
        End Select

        input_check = True
    End Function
#End Region

#Region "入力チェック-仕入金額"
    ''' <summary>入力チェック-仕入金額</summary>
    ''' <remarks></remarks>
    Private Function input_check_purchase() As Boolean
        Dim str As String
        input_check_purchase = False

        Me.txt仕入金額.Text = Trim(Me.txt仕入金額.Text)
        str = Replace(Me.txt仕入金額.Text, ",", "")
        If String.IsNullOrEmpty(str) Then
            Call Sys_Error("仕入金額 は必須入力です。　", Me.txt仕入金額)
            Exit Function
        End If
        If Sys_Zenkaku(str) Then
            Call Sys_Error("仕入金額 は半角数字で入力してください。　", Me.txt仕入金額)
            Exit Function
        End If
        If (Sys_InputCheck(str, 9, "N+", 1)) Then
            Call Sys_Error("仕入金額 は半角数字9文字以内で入力してください。　", Me.txt仕入金額)
            Exit Function
        End If

        input_check_purchase = True
    End Function
#End Region

#Region "入力チェック-販売金額"
    ''' <summary>入力チェック-販売金額</summary>
    ''' <remarks></remarks>
    Private Function input_check_buy() As Boolean
        Dim str As String
        input_check_buy = False

        Me.txt販売金額.Text = Trim(Me.txt販売金額.Text)
        str = Replace(Me.txt販売金額.Text, ",", "")
        If String.IsNullOrEmpty(str) Then
            Call Sys_Error("販売金額 は必須入力です。　", Me.txt販売金額)
            Exit Function
        End If
        If Sys_Zenkaku(str) Then
            Call Sys_Error("販売金額 は半角数字で入力してください。　", Me.txt販売金額)
            Exit Function
        End If
        If (Sys_InputCheck(str, 9, "N+", 1)) Then
            Call Sys_Error("販売金額 は半角数字9文字以内で入力してください。　", Me.txt販売金額)
            Exit Function
        End If

        input_check_buy = True
    End Function
#End Region

#Region "入力チェック-在庫数"
    ''' <summary>入力チェック-在庫数</summary>
    ''' <remarks></remarks>
    Private Function input_check_stock() As Boolean
        Dim str As String
        input_check_stock = False

        Me.txt在庫数.Text = Trim(Me.txt在庫数.Text)
        str = Replace(Me.txt在庫数.Text, ",", "")
        If String.IsNullOrEmpty(str) Then
            Call Sys_Error("在庫数 は必須入力です。　", Me.txt在庫数)
            Exit Function
        End If
        If Sys_Zenkaku(str) Then
            Call Sys_Error("在庫数 は半角数字で入力してください。　", Me.txt在庫数)
            Exit Function
        End If
        If (Sys_InputCheck(str, 9, "N+", 1)) Then
            Call Sys_Error("在庫数 は半角数字9文字以内で入力してください。　", Me.txt在庫数)
            Exit Function
        End If

        input_check_stock = True
    End Function
#End Region

#Region "入力チェック-発注点"
    ''' <summary>入力チェック-発注点</summary>
    ''' <remarks></remarks>
    Private Function input_check_order() As Boolean
        Dim str As String
        input_check_order = False

        Me.txt発注点.Text = Trim(Me.txt発注点.Text)
        str = Replace(Me.txt発注点.Text, ",", "")
        If String.IsNullOrEmpty(str) Then
            Call Sys_Error("発注点 は必須入力です。　", Me.txt発注点)
            Exit Function
        End If
        If Sys_Zenkaku(str) Then
            Call Sys_Error("発注点 は半角数字で入力してください。　", Me.txt発注点)
            Exit Function
        End If
        If (Sys_InputCheck(str, 9, "N+", 1)) Then
            Call Sys_Error("発注点 は半角数字9文字以内で入力してください。　", Me.txt発注点)
            Exit Function
        End If

        input_check_order = True
    End Function
#End Region

#Region "入力チェック-既定在庫数"
    ''' <summary>入力チェック-既定在庫数</summary>
    ''' <remarks></remarks>
    Private Function input_check_fixedStock() As Boolean
        Dim str As String
        input_check_fixedStock = False

        Me.既定在庫数.Text = Trim(Me.既定在庫数.Text)
        str = Replace(Me.既定在庫数.Text, ",", "")
        If String.IsNullOrEmpty(str) Then
            Call Sys_Error("既定在庫数 は必須入力です。　", Me.既定在庫数)
            Exit Function
        End If
        If Sys_Zenkaku(str) Then
            Call Sys_Error("既定在庫数 は半角数字で入力してください。　", Me.既定在庫数)
            Exit Function
        End If
        If (Sys_InputCheck(str, 9, "N+", 1)) Then
            Call Sys_Error("既定在庫数 は半角数字9文字以内で入力してください。　", Me.既定在庫数)
            Exit Function
        End If

        input_check_fixedStock = True
    End Function
#End Region

#Region "画面再表示処理"
    ''' <summary>画面再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay()
        ' 新規ボタン非活性
        Me.新規.Enabled = False

        ' 変更ボタン非活性
        Me.登録.Enabled = False

        '売上区分コンボボックス表示
        ReDisplay_売上区分()

        '分類コンボボックス表示
        ReDisplay_分類()

        'メーカー名コンボボックス表示
        ReDisplay_メーカー名()
    End Sub
#End Region

#Region "売上区分コンボボックス再表示処理"
    ''' <summary>売上区分コンボボックス再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_売上区分()
        Dim dt As DataTable
        '売上区分名一覧取得
        dt = logic.GetSalesDivisionNames()

        '売上区分：コンボボックス表示
        Me.売上区分.DataSource = dt
        Me.売上区分.DisplayMember = "売上区分"
        Me.売上区分.ValueMember = "売上区分番号"
        Me.売上区分.SelectedIndex = -1
    End Sub
#End Region

#Region "分類コンボボックス再表示処理"
    ''' <summary>分類コンボボックス再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_分類()
        Dim dt As DataTable
        If Me.売上区分.SelectedIndex >= 0 Then
            '分類名一覧取得
            dt = logic.GetCommodityDivisionNames(Me.売上区分.SelectedValue)

            '分類：コンボボックス表示
            Me.分類.DataSource = dt
            Me.分類.DisplayMember = "分類名"
            Me.分類.ValueMember = "分類番号"
            Me.分類.SelectedIndex = -1
            Me.分類.Enabled = True
        Else
            Me.分類.DataSource = Nothing
            Me.分類.SelectedIndex = -1
            Me.分類.Enabled = False
        End If

        ReDisplay_dgv商品一覧()
    End Sub
#End Region

#Region "商品一覧再表示処理"
    ''' <summary>商品一覧再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_dgv商品一覧()
        Dim dt As DataTable
        Dim param As New Habits.DB.DBParameter

        If Me.売上区分.SelectedIndex >= 0 AndAlso _
           Me.分類.SelectedIndex >= 0 Then

            param.Add("@売上区分番号", Me.売上区分.SelectedValue)
            param.Add("@分類番号", Me.分類.SelectedValue)

            '商品一覧取得
            dt = logic.GetCommodity(param)

            If dt.Rows.Count > 0 Then
                SelectionChangeLocked_dgv商品一覧 = True              'DataSource設定時のSelectionChangedイベントで入力項目再表示を抑止
                Me.dgv商品一覧.DataSource = dt
                SelectionChangeLocked_dgv商品一覧 = False

                Next_商品番号 = GetNextSequence(dt, "No")

                Me.dgv商品一覧.Columns("No").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
                Me.dgv商品一覧.Columns("標準時間").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
                Me.dgv商品一覧.Columns("仕入金額").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
                Me.dgv商品一覧.Columns("仕入金額").DefaultCellStyle.Format = "#,##0"
                Me.dgv商品一覧.Columns("販売金額").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
                Me.dgv商品一覧.Columns("販売金額").DefaultCellStyle.Format = "#,##0"
                Me.dgv商品一覧.Columns("在庫数").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
                Me.dgv商品一覧.Columns("在庫数").DefaultCellStyle.Format = "#,##0"
                Me.dgv商品一覧.Columns("発注点").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
                Me.dgv商品一覧.Columns("発注点").DefaultCellStyle.Format = "#,##0"
                Me.dgv商品一覧.Columns("既定数").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
                Me.dgv商品一覧.Columns("既定数").DefaultCellStyle.Format = "#,##0"
                Me.dgv商品一覧.Columns("表示順").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
                Me.dgv商品一覧.Columns("表示").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomCenter
                Me.dgv商品一覧.Columns("工程").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomCenter
                'Me.dgv商品一覧.Columns("管理").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomCenter

                Me.dgv商品一覧.Columns("メーカー番号").Visible = False
                Me.dgv商品一覧.Columns("登録日").Visible = False
                Me.dgv商品一覧.Columns("更新日").Visible = False

                If Get_店販対象フラグ() Then
                    ''店販対象の場合 （C_分類.店販対象フラグ=True）：906
                    Me.dgv商品一覧.Columns("No").Width = 38
                    Me.dgv商品一覧.Columns("商品名").Width = 190
                    Me.dgv商品一覧.Columns("メーカー名").Visible = True
                    Me.dgv商品一覧.Columns("メーカー名").Width = 88
                    Me.dgv商品一覧.Columns("標準時間").Visible = False
                    Me.dgv商品一覧.Columns("仕入金額").Visible = True
                    Me.dgv商品一覧.Columns("仕入金額").Width = 84
                    Me.dgv商品一覧.Columns("販売金額").Width = 84
                    Me.dgv商品一覧.Columns("在庫数").Visible = True
                    Me.dgv商品一覧.Columns("在庫数").Width = 71
                    Me.dgv商品一覧.Columns("発注点").Visible = True
                    Me.dgv商品一覧.Columns("発注点").Width = 71
                    Me.dgv商品一覧.Columns("既定数").Visible = True
                    Me.dgv商品一覧.Columns("既定数").Width = 71
                    Me.dgv商品一覧.Columns("表示順").Width = 71
                    Me.dgv商品一覧.Columns("工程").Visible = False
                    Me.dgv商品一覧.Columns("表示").Width = 58
                    Me.dgv商品一覧.Columns("管理").Width = 58

                Else
                    ''店販対象外場合：906
                    Me.dgv商品一覧.Columns("No").Width = 58
                    Me.dgv商品一覧.Columns("商品名").Width = 314
                    Me.dgv商品一覧.Columns("メーカー名").Visible = False
                    Me.dgv商品一覧.Columns("標準時間").Visible = True
                    Me.dgv商品一覧.Columns("標準時間").Width = 105
                    Me.dgv商品一覧.Columns("仕入金額").Visible = False
                    Me.dgv商品一覧.Columns("販売金額").Width = 105
                    Me.dgv商品一覧.Columns("在庫数").Visible = False
                    Me.dgv商品一覧.Columns("発注点").Visible = False
                    Me.dgv商品一覧.Columns("既定数").Visible = False
                    Me.dgv商品一覧.Columns("表示順").Width = 71
                    Me.dgv商品一覧.Columns("工程").Visible = True
                    Me.dgv商品一覧.Columns("工程").Width = 71
                    Me.dgv商品一覧.Columns("表示").Width = 71
                    Me.dgv商品一覧.Columns("管理").Width = 89

                End If
                Me.dgv商品一覧.ClearSelection()
            Else
                Me.dgv商品一覧.DataSource = Nothing
                Next_商品番号 = 1
            End If
        Else
            Me.dgv商品一覧.DataSource = Nothing
            Next_商品番号 = 1
        End If
        Me.lbl商品番号.Text = ""
        ReDisplay_入力項目()
    End Sub
#End Region

#Region "メーカー名コンボボックス再表示処理"
    ''' <summary>メーカー名コンボボックス再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_メーカー名()
        Dim dt As DataTable

        'メーカー名一覧取得
        dt = logic.GetBrandNames()

        'メーカー名：コンボボックス表示
        Me.txtメーカー名.DataSource = dt
        Me.txtメーカー名.DisplayMember = "メーカー名"
        Me.txtメーカー名.ValueMember = "メーカー番号"

        Me.txtメーカー名.SelectedIndex = -1
    End Sub
#End Region

#Region "入力項目再表示処理"
    ''' <summary>入力項目再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_入力項目()
        Dim str As Object

        '' 店販対象フラグにより項目の配置を変更
        If Get_店販対象フラグ() Then
            ''店販対象の場合 （C_分類.店販対象フラグ=True）

            '標準時間
            Me.Label14.Visible = False
            Me.txt標準時間.Enabled = False
            Me.txt標準時間.Visible = False
            Me.Label13.Visible = False

            'メーカー名
            Me.Label5.Location = New System.Drawing.Point(440, 360)
            Me.Label5.Visible = True
            Me.txtメーカー名.Location = New System.Drawing.Point(535, 360)
            Me.txtメーカー名.Enabled = True
            Me.txtメーカー名.Visible = True

            '仕入金額
            Me.Label6.Location = New System.Drawing.Point(440, 386)
            Me.Label6.Visible = True
            Me.txt仕入金額.Location = New System.Drawing.Point(535, 386)
            Me.txt仕入金額.Enabled = True
            Me.txt仕入金額.Visible = True

            '販売金額
            Me.Label7.Location = New System.Drawing.Point(440, 412)
            Me.Label7.Visible = True
            Me.txt販売金額.Location = New System.Drawing.Point(535, 412)
            Me.txt販売金額.Enabled = True
            Me.txt販売金額.Visible = True

            '在庫数
            Me.Label8.Location = New System.Drawing.Point(440, 438)
            Me.Label8.Visible = True
            Me.txt在庫数.Location = New System.Drawing.Point(535, 438)
            Me.txt在庫数.Enabled = True
            Me.txt在庫数.Visible = True

            '発注点
            Me.Label9.Location = New System.Drawing.Point(440, 464)
            Me.Label9.Visible = True
            Me.txt発注点.Location = New System.Drawing.Point(535, 464)
            Me.txt発注点.Enabled = True
            Me.txt発注点.Visible = True

            '既定在庫数
            Me.Label15.Location = New System.Drawing.Point(452, 490)
            Me.Label15.Visible = True
            Me.既定在庫数.Location = New System.Drawing.Point(535, 490)
            Me.既定在庫数.Enabled = True
            Me.既定在庫数.Visible = True
            '工程ボタン
            Me.工程.Visible = False
            Me.工程.Enabled = False

        Else
            ''店販対象外場合

            '標準時間
            Me.Label14.Location = New System.Drawing.Point(440, 360)
            Me.Label14.Visible = True
            Me.txt標準時間.Location = New System.Drawing.Point(535, 360)
            Me.txt標準時間.Enabled = True
            Me.txt標準時間.Visible = True
            Me.Label13.Location = New System.Drawing.Point(608, 360)
            Me.Label13.Visible = True

            'メーカー名
            Me.Label5.Visible = False
            Me.txtメーカー名.Enabled = False
            Me.txtメーカー名.Visible = False

            '仕入金額
            Me.Label6.Visible = False
            Me.txt仕入金額.Enabled = False
            Me.txt仕入金額.Visible = False

            '販売金額
            Me.Label7.Location = New System.Drawing.Point(440, 386)
            Me.Label7.Visible = True
            Me.txt販売金額.Location = New System.Drawing.Point(535, 386)
            Me.txt販売金額.Enabled = True
            Me.txt販売金額.Visible = True

            '在庫数
            Me.Label8.Visible = False
            Me.txt在庫数.Enabled = False
            Me.txt在庫数.Visible = False

            '発注点
            Me.Label9.Visible = False
            Me.txt発注点.Enabled = False
            Me.txt発注点.Visible = False

            '既定在庫数
            Me.Label15.Visible = False
            Me.既定在庫数.Enabled = False
            Me.既定在庫数.Visible = False

            '工程ボタン
            Me.工程.Location = New System.Drawing.Point(535, 412)
            Me.工程.Visible = True
            If Me.dgv商品一覧.SelectedRows.Count = 0 Then
                Me.工程.Enabled = False
            Else
                Me.工程.Enabled = True
            End If

        End If
        '' 商品一覧で選択された商品を反映
        If Me.dgv商品一覧.SelectedRows.Count > 0 Then
            Me.登録.Text = "変更"

            Me.lbl商品番号.Text = Me.dgv商品一覧.SelectedRows(0).Cells("No").Value
            Me.txt商品名.Text = Me.dgv商品一覧.SelectedRows(0).Cells("商品名").Value
            Me.txt表示順.Text = Me.dgv商品一覧.SelectedRows(0).Cells("表示順").Value

            If Not (String.IsNullOrEmpty(Me.dgv商品一覧.SelectedRows(0).Cells("表示").Value)) Then
                Me.削除フラグ.Checked = True
            Else
                Me.削除フラグ.Checked = False
            End If

            Me.txt標準時間.Text = Me.dgv商品一覧.SelectedRows(0).Cells("標準時間").Value

            str = Me.dgv商品一覧.SelectedRows(0).Cells("メーカー番号").Value
            If IsDBNull(str) Then
                Me.txtメーカー名.SelectedIndex = -1
            Else
                Me.txtメーカー名.SelectedValue = str
            End If

            buy = Me.dgv商品一覧.SelectedRows(0).Cells("仕入金額").Value
            w_buy = buy
            Me.txt仕入金額.Text = Format(w_buy, "#,##0")

            sale = Me.dgv商品一覧.SelectedRows(0).Cells("販売金額").Value
            w_sale = sale
            Me.txt販売金額.Text = Format(w_sale, "#,##0")

            sale = Me.dgv商品一覧.SelectedRows(0).Cells("在庫数").Value
            w_sale = sale
            Me.txt在庫数.Text = Format(w_sale, "#,##0")

            sale = Me.dgv商品一覧.SelectedRows(0).Cells("発注点").Value
            w_sale = sale
            Me.txt発注点.Text = Format(w_sale, "#,##0")

            sale = Me.dgv商品一覧.SelectedRows(0).Cells("既定数").Value
            w_sale = sale
            Me.既定在庫数.Text = Format(w_sale, "#,##0")

            If Me.dgv商品一覧.SelectedRows(0).Cells("管理").Value.Equals("税込") Then
                Me.rbnWithTax.Checked = True
            Else
                Me.rbnWithoutTax.Checked = True
            End If
            SetEnable_入力項目(True)
            Me.新規.Enabled = True
            Me.登録.Enabled = True
            Me.txt商品名.Focus()
        Else
            Clear_入力項目()
            If String.IsNullOrEmpty(lbl商品番号.Text) Then
                Me.登録.Text = "変更"
                SetEnable_入力項目(False)
            Else
                Me.登録.Text = "登録"
                SetEnable_入力項目(True)
            End If
        End If
    End Sub
#End Region

#Region "入力項目クリア処理"
    ''' <summary>入力項目クリア処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub Clear_入力項目()
        Me.txt商品名.Text = Nothing
        Me.txt表示順.Text = Nothing
        Me.削除フラグ.Checked = False
        Me.txt標準時間.Text = Nothing
        Me.txtメーカー名.SelectedIndex = -1
        Me.txt仕入金額.Text = Nothing
        Me.txt販売金額.Text = Nothing
        Me.txt在庫数.Text = Nothing
        Me.txt発注点.Text = Nothing
        Me.既定在庫数.Text = Nothing
        If TAX_MANAGEMENT_TYPE = 1 Then
            Me.GroupBox1.Visible = False
            Me.rbnWithTax.Checked = True
        Else
            Me.rbnWithoutTax.Checked = True
            Me.GroupBox1.Enabled = False
        End If

        If 売上区分.SelectedIndex >= 0 AndAlso 分類.SelectedIndex >= 0 Then
            Me.新規.Enabled = True
        Else
            Me.新規.Enabled = False
        End If
    End Sub
#End Region

#Region "店販対象フラグ取得"
    ''' <summary>店販対象フラグ取得</summary>
    ''' <remarks></remarks>
    Protected Friend Function Get_店販対象フラグ() As Boolean
        Dim rtn As Boolean = False

        If Me.分類.SelectedIndex >= 0 Then
            ''分類コンボボックス選択済み
            Dim dt As DataTable = Me.分類.DataSource
            Dim str As String = "分類番号 = " & Me.分類.SelectedValue.ToString
            Dim dr As DataRow() = dt.Select(str)
            If dr.Length > 0 Then
                If dr(0).Item(2).ToString = True Then
                    '' 選択された分類が店販対象フラグ=Trueの場合
                    rtn = True
                End If
            End If
        End If
        Get_店販対象フラグ = rtn
    End Function
#End Region

#Region "入力項目Enable設定"
    ''' <summary>入力項目Enable設定</summary>
    ''' <param name="v_bool">True：登録可、False：登録不可</param>
    ''' <remarks></remarks>
    Protected Friend Sub SetEnable_入力項目(ByVal v_bool As Boolean)
        If v_bool Then
            Me.lbl商品番号.BackColor = Color.White
            Me.txt商品名.Enabled = True
            Me.txt商品名.BackColor = Color.White
            Me.txt表示順.Enabled = True
            Me.txt表示順.BackColor = Color.White
            Me.削除フラグ.Enabled = True
            If TAX_MANAGEMENT_TYPE = 1 Then
                Me.GroupBox1.Visible = False
                Me.rbnWithTax.Checked = True
            Else
                Me.GroupBox1.Enabled = True
            End If
            Me.txt標準時間.Enabled = True
            Me.txt標準時間.BackColor = Color.White
            Me.txtメーカー名.Enabled = True
            Me.txtメーカー名.BackColor = Color.White
            Me.txt仕入金額.Enabled = True
            Me.txt仕入金額.BackColor = Color.White
            Me.txt販売金額.Enabled = True
            Me.txt販売金額.BackColor = Color.White
            Me.txt在庫数.Enabled = True
            Me.txt在庫数.BackColor = Color.White
            Me.txt発注点.Enabled = True
            Me.txt発注点.BackColor = Color.White
            Me.既定在庫数.Enabled = True
            Me.既定在庫数.BackColor = Color.White

            Me.項目クリア.Enabled = True
            Me.登録.Enabled = True
        Else
            ''項目初期化
            Clear_入力項目()
            Me.lbl商品番号.Text = ""

            Me.lbl商品番号.BackColor = SystemColors.Control
            Me.txt商品名.Enabled = False
            Me.txt商品名.BackColor = SystemColors.Control
            Me.txt表示順.Enabled = False
            Me.txt表示順.BackColor = SystemColors.Control
            Me.削除フラグ.Enabled = False
            If TAX_MANAGEMENT_TYPE = 1 Then
                Me.GroupBox1.Visible = False
                Me.rbnWithTax.Checked = True
            Else
                Me.rbnWithoutTax.Checked = True
                Me.GroupBox1.Enabled = False
            End If
            Me.txt標準時間.Enabled = False
            Me.txt標準時間.BackColor = SystemColors.Control
            Me.txtメーカー名.Enabled = False
            Me.txtメーカー名.BackColor = SystemColors.Control
            Me.txt仕入金額.Enabled = False
            Me.txt仕入金額.BackColor = SystemColors.Control
            Me.txt販売金額.Enabled = False
            Me.txt販売金額.BackColor = SystemColors.Control
            Me.txt在庫数.Enabled = False
            Me.txt在庫数.BackColor = SystemColors.Control
            Me.txt発注点.Enabled = False
            Me.txt発注点.BackColor = SystemColors.Control
            Me.既定在庫数.Enabled = False
            Me.既定在庫数.BackColor = SystemColors.Control

            Me.項目クリア.Enabled = False
            Me.登録.Enabled = False
        End If
    End Sub
#End Region

#Region "dgv商品一覧のインデックス取得"
    ''' <summary>dgv商品一覧のインデックス取得</summary>
    ''' <param name="v_number">商品番号</param>
    ''' <remarks></remarks>
    Protected Friend Function GetIndex_dgv商品一覧(ByVal v_number As String) As Integer
        Dim numStr As String

        For i As Integer = 0 To Me.dgv商品一覧.Rows.Count - 1
            numStr = Me.dgv商品一覧.Rows(i).Cells(0).Value
            If String.Equals(numStr, v_number) Then
                GetIndex_dgv商品一覧 = i
                Exit Function
            End If
        Next

        ''取得失敗
        GetIndex_dgv商品一覧 = -1
    End Function
#End Region

#End Region


End Class