''' <summary>c0100_売上画面処理</summary>
''' <remarks></remarks>
Public Class c0100_売上

    Private Const PAGE_TITLE As String = "c0100_売上"
    Private logic As Habits.Logic.c0100_Logic

    Private DKO As New DataTable        'D_顧客
    Private EUR As New DataTable        'E_売上
    Private ERA As New DataTable        'E_来店者
    Private bfr_sales As New DataTable  '更新前売上情報
    Private param As New Habits.DB.DBParameter

    Private j As Integer = 0
    Private pointPurchases As Long = 0

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub c0100_売上_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logic = New Habits.Logic.c0100_Logic
        MESSAGE_CHECK_FLAG = True

        Dim param As New Habits.DB.DBParameter
        Dim dSMoney As Double

        '' レシート印刷機能非表示
        If My.MySettings.Default.ReceiptFlag = "1" Then
            btnSlip.Enabled = True
            btnSlip.Visible = True
        Else
            btnSlip.Enabled = False
            btnSlip.Visible = False
        End If

        '性別：コンボボックス表示
        Me.性別番号.DataSource = logic.B_性別()
        Me.性別番号.DisplayMember = "性別"
        Me.性別番号.ValueMember = "性別番号"
        Me.性別番号.SelectedIndex = -1

        '主担当者：コンボボックス表示
        param.Clear()
        param.Add("@営業日", USER_DATE)
        Me.主担当者.DataSource = logic.W_スタッフPlus_E_売上(param)
        Me.主担当者.DisplayMember = "担当者名"
        Me.主担当者.ValueMember = "担当者番号"

        '来店区分：コンボボックス表示
        Me.来店区分.DataSource = logic.getVisitDiv()
        Me.来店区分.DisplayMember = "来店区分"
        Me.来店区分.ValueMember = "来店区分番号"

        '売上区分リスト表示
        Me.dgv売上区分.DataSource = logic.getSalesDivList()
        Me.dgv売上区分.Columns(0).Visible = False
        Me.dgv売上区分.Columns(1).Width = 280
        Me.dgv売上区分.ClearSelection()
        メーカー.Enabled = False

        'ポイント割引：コンボボックス表示
        Me.cmbポイント割引.DataSource = logic.getPointService_exclude()
        Me.cmbポイント割引.DisplayMember = "ポイント割引名"
        Me.cmbポイント割引.ValueMember = "ポイント割引番号"
        Me.cmbポイント割引.SelectedIndex = -1
        Me.txtポイント割引額.Text = "0"

        'サービス：コンボボックス表示
        Me.cmbサービス.DataSource = logic.getService_exclude()
        Me.cmbサービス.DisplayMember = "サービス名"
        Me.cmbサービス.ValueMember = "サービス番号"
        Me.cmbサービス.SelectedIndex = -1
        Me.txtサービス率.Text = Format("0", "0.0")
        Me.txtサービス.Text = "0"
        Me.rbnServiceRate.Select()

        'パラメータ設定（@来店日/@来店者番号/@顧客番号）
        param.Clear()
        param.Add("@来店日", USER_DATE)
        param.Add("@来店者番号", SER_NO)
        param.Add("@顧客番号", CST_CODE)

        ' 顧客情報設定
        DKO = logic.GetCustomerData(CST_CODE.ToString)
        Me.氏名.Text = DKO.Rows(0)("姓").ToString & " " & DKO.Rows(0)("名").ToString

        If String.IsNullOrEmpty(DKO.Rows(0)("性別番号").ToString) = True Then
            Me.性別番号.SelectedIndex = -1
        Else
            Me.性別番号.SelectedValue = DKO.Rows(0)("性別番号").ToString
        End If

        ' 売上データ取得
        EUR = logic.getSales(param)
        If EUR.Rows.Count <> 0 Then
            ' 再会計時「仮登録」ボタン非活性表示
            Me.btn仮登録.Enabled = False

            'E_売上に該当データがあった場合、売上情報を設定
            Me.btn会計.Text = "再会計"

            If String.IsNullOrEmpty(EUR.Rows(0)("主担当者番号").ToString()) = True Then
                Me.主担当者.SelectedIndex = -1
            Else
                Me.主担当者.SelectedValue = Integer.Parse(EUR.Rows(0)("主担当者番号").ToString)
            End If

            If String.IsNullOrEmpty(EUR.Rows(0)("来店区分番号").ToString) = True Then
                Me.来店区分.SelectedIndex = -1
            Else

                Me.来店区分.SelectedValue = Integer.Parse(EUR.Rows(0)("来店区分番号").ToString)
            End If

            Me.指名.Checked = Boolean.Parse(EUR.Rows(0)("指名").ToString)

            If EUR.Rows(0)("ポイント割引番号").ToString() <> 0 Then
                Me.cmbポイント割引.SelectedValue = EUR.Rows(0)("ポイント割引番号").ToString()
            End If
            If EUR.Rows(0)("ポイント割引支払").ToString() <> 0 Then
                Me.txtポイント割引額.Text = EUR.Rows(0)("ポイント割引支払").ToString()
            End If

            If EUR.Rows(0)("サービス番号").ToString() <> 0 Then
                Me.cmbサービス.SelectedValue = EUR.Rows(0)("サービス番号").ToString()
            End If
            If EUR.Rows(0)("サービス区分").ToString = "1" Then
                setRBNService(True)
                If EUR.Rows(0)("サービス金額").ToString() <> 0 Then
                    dSMoney = EUR.Rows(0)("サービス金額")
                    dSMoney = dSMoney / 100
                    Me.txtサービス率.Text = Format(dSMoney, "0.0")
                End If
            Else
                setRBNService(False)
                If EUR.Rows(0)("サービス金額").ToString() <> 0 Then
                    Me.txtサービス.Text = EUR.Rows(0)("サービス金額").ToString()
                End If
            End If

            ''更新前売上情報設定
            bfr_sales = logic.getSalesInfoForLog(param)
        Else
            'E_売上に該当データがなかった場合、来店情報を設定
            ERA = logic.getVisiter(param)
            Me.btn会計.Text = "会計"

            If String.IsNullOrEmpty(ERA.Rows(0)("主担当者番号").ToString()) = True Then ''会計ボタン押下時エラーが発生している
                Me.主担当者.SelectedIndex = -1
            Else
                Me.主担当者.SelectedValue = Integer.Parse(ERA.Rows(0)("主担当者番号").ToString)
            End If

            If String.IsNullOrEmpty(ERA.Rows(0)("来店区分番号").ToString) = True Then
                Me.来店区分.SelectedIndex = -1
            Else
                Me.来店区分.SelectedValue = Integer.Parse(ERA.Rows(0)("来店区分番号").ToString)
            End If

            Me.指名.Checked = Boolean.Parse(ERA.Rows(0)("指名").ToString)

            If ERA.Rows(0)("ポイント割引番号").ToString() <> 0 Then
                Me.cmbポイント割引.SelectedValue = ERA.Rows(0)("ポイント割引番号").ToString()
            End If
            If ERA.Rows(0)("ポイント割引支払").ToString() <> 0 Then
                Me.txtポイント割引額.Text = ERA.Rows(0)("ポイント割引支払").ToString()
            End If

            If ERA.Rows(0)("サービス番号").ToString() <> 0 Then
                Me.cmbサービス.SelectedValue = ERA.Rows(0)("サービス番号").ToString()
            End If
            If ERA.Rows(0)("サービス区分").ToString = "1" Then
                setRBNService(True)
                If ERA.Rows(0)("サービス金額").ToString() <> 0 Then

                    dSMoney = ERA.Rows(0)("サービス金額")
                    dSMoney = dSMoney / 100
                    Me.txtサービス率.Text = Format(dSMoney, "0.0")

                End If
            Else
                setRBNService(False)
                If ERA.Rows(0)("サービス金額").ToString() <> 0 Then
                    Me.txtサービス.Text = ERA.Rows(0)("サービス金額").ToString()
                End If
        End If
        End If

        '売上一覧表示処理
        Call gdv売上一覧更新()
        '合計算出
        Call getTotal()

        If Me.dgv売上一覧.Rows.Count = 0 Then
            Me.btn削除.Enabled = False
        Else
            Me.btn削除.Enabled = True
        End If
        Me.性別番号.Focus()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub c0100_売上_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If ReCheckFlag = True Then
            'ログ出力
            Dim aft_sales As DataTable

            'パラメータ設定（@来店日/@来店者番号/@顧客番号）
            param.Clear()
            param.Add("@来店日", USER_DATE)
            param.Add("@来店者番号", SER_NO)
            param.Add("@顧客番号", CST_CODE)

            '更新後売上情報設定
            aft_sales = logic.getSalesInfoForLog(param)
            FileUtil.WriteDataHistoryLogFile(bfr_sales, aft_sales)

        End If
        MESSAGE_CHECK_FLAG = False
        Me.Dispose()
    End Sub
#End Region

#Region "売上区分選択変更イベント"
    ''' <summary>
    ''' 売上区分選択変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv売上区分_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv売上区分.SelectionChanged

        Dim dt As New DataTable

        '初期化
        Me.dgv分類一覧.DataSource = Nothing
        Me.メーカー.Enabled = False
        Me.メーカー.DataSource = Nothing
        Me.メーカー.SelectedIndex = -1
        Me.dgv商品一覧.DataSource = Nothing

        '売上区分が選択されていない場合、処理を抜ける
        If dgv売上区分.SelectedRows.Count <> 1 Then
            Exit Sub
        End If
        param.Clear()
        param.Add("@売上区分番号", Me.dgv売上区分.SelectedRows(0).Cells(0).Value)

        Me.dgv分類一覧.RowTemplate.Height = 16
        dt = logic.getClass_exclude(param)
        Me.dgv分類一覧.DataSource = dt
        Me.dgv分類一覧.ClearSelection()
        Me.dgv分類一覧.Columns(0).Visible = False '分類番号
        Me.dgv分類一覧.Columns(2).Visible = False '店販対象フラグ
        Me.dgv分類一覧.Columns(1).Width = 280

    End Sub
#End Region

#Region "分類一覧選択変更イベント"
    ''' <summary>
    ''' 分類一覧選択変更処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub dgv分類一覧_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv分類一覧.SelectionChanged
        '初期化
        Me.メーカー.Enabled = False
        Me.メーカー.DataSource = Nothing
        Me.メーカー.SelectedIndex = -1
        Me.dgv商品一覧.DataSource = Nothing

        '分類一覧が選択されていない場合、処理を抜ける
        If dgv売上区分.SelectedRows.Count <> 1 OrElse Me.dgv分類一覧.SelectedRows.Count <> 1 Then
            Exit Sub
        End If
        param.Clear()
        param.Add("@売上区分番号", Me.dgv売上区分.SelectedRows(0).Cells(0).Value)
        param.Add("@分類番号", Me.dgv分類一覧.SelectedRows(0).Cells(0).Value)

        If (Boolean.Parse(Me.dgv分類一覧.SelectedRows(0).Cells(2).Value.ToString)) Then
            Me.メーカー.DataSource = logic.getMakerList(param)
            Me.メーカー.DisplayMember = "メーカー名"
            Me.メーカー.ValueMember = "メーカー番号"
            Me.メーカー.Enabled = True
            If メーカー.Items.Count = 1 Then
                メーカー.SelectedIndex = 0
                メーカー.Enabled = False
            Else
                メーカー.SelectedIndex = -1
            End If
        End If
        ' 商品一覧表示
        setGoodList()
    End Sub

#End Region

#Region "メーカー選択変更イベント"
    ''' <summary>
    ''' メーカー選択変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub メーカー_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles メーカー.SelectionChangeCommitted
        If (メーカー.Items.Count < 1) Then
            Exit Sub
        End If
        '店販対象で、メーカー未選択
        If (Boolean.Parse(dgv分類一覧.SelectedRows(0).Cells(2).Value.ToString)) Then
            If (メーカー.SelectedIndex < 0) Then
                Exit Sub
            End If
        End If
        ' 商品一覧表示
        setGoodList()
    End Sub
#End Region

#Region "商品選択変更処理"
    Private Sub dgv商品一覧_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv商品一覧.CellClick
        If Me.dgv商品一覧.SelectedRows.Count <> 0 AndAlso checkStaff() Then
            c0200_売上入力.ShowDialog()
            Me.btn会計.Focus()
        Else
            dgv商品一覧.ClearSelection()
        End If
    End Sub
#End Region

#Region "売上一覧選択処理"
    Private Sub dgv売上一覧_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv売上一覧.Click
        Dim EUM As New DataTable 'E_売上明細

        If dgv売上一覧.SelectedRows.Count <> 0 Then
            param.Clear()
            param.Add("@売上番号", dgv売上一覧.SelectedRows(0).Cells(0).Value)
            param.Add("@来店日", USER_DATE)
            param.Add("@来店者番号", SER_NO)
            param.Add("@顧客番号", CST_CODE)

            EUM = logic.E_売上明細取得(param)

            If EUM.Rows.Count <> 0 Then
            Else
                Call Sys_Trap("c0100_売上", "dgv売上一覧_Click", "売上明細取得エラー")
            End If
        End If
    End Sub
#End Region

#Region "フォーカス移動"
    Private Sub 性別番号_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 性別番号.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.主担当者.Focus()
        End If
    End Sub

    Private Sub 主担当者_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 主担当者.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.来店区分.Focus()
        End If
    End Sub

    Private Sub 指名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 指名.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.dgv売上区分.Focus()
        End If
    End Sub

    Private Sub 売上区分_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.dgv分類一覧.Focus()
        End If
    End Sub

    Private Sub 来店区分_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 来店区分.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.指名.Focus()
        End If
    End Sub
#End Region

#Region "フォーカスが外れた時のイベント"

#Region "サービス率のフォーカス外れ"
    Private Sub rbnServiceRate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnServiceRate.Leave
        serviceRate_check()
    End Sub
#End Region

#Region "サービス率のフォーカス外れ"
    Private Sub txtサービス率_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtサービス率.Leave
        serviceRate_check()
    End Sub
#End Region

#Region "サービスのフォーカス外れ"
    Private Sub txtサービス_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtサービス.Leave
        Dim checkText As String

        'サービスのチェック
        checkText = Replace(Me.txtサービス.Text, ",", "")
        If checkText = "" OrElse IsNumeric(checkText) = True Then
            '合計金額算出
            getTotal()
        Else
            Sys_Error("サービス金額 は半角数字9文字以内で入力してください。　", Me.txtサービス)
            Me.txtサービス.Text = ""
        End If
    End Sub
#End Region

#Region "ポイント割引のフォーカス外れ"
    Private Sub txtポイント割引額_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtポイント割引額.Leave
        Dim checkText As String

        'ポイント割引額のチェック
        checkText = Replace(Me.txtポイント割引額.Text, ",", "")
        If checkText = "" OrElse IsNumeric(checkText) = True Then
            '合計金額算出
            getTotal()
        Else
            Sys_Error("ポイント割引額 は半角数字9文字以内で入力してください。　", Me.txtポイント割引額)
            Me.txtポイント割引額.Text = ""
        End If
    End Sub
#End Region

#End Region

#Region "キープレスイベント"
    Private Sub txtポイント割引額_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtポイント割引額.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txtサービス率_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtサービス率.KeyPress
        '        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txtサービス_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtサービス.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

#End Region

#Region "キーダウンイベント"
    Private Sub txtサービス率_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtサービス率.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtサービス率.Focus()
        End If
    End Sub
#End Region

#Region "ラジオボタン（サービス割合）選択"
    ''' <summary>
    ''' ラジオボタン（サービス割合）選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbnServiceRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnServiceRate.Click

        setRBNService(True)

    End Sub
#End Region

#Region "ラジオボタン（サービス金額）選択"
    ''' <summary>
    ''' ラジオボタン（サービス金額）選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbnServiceAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnServiceAmount.Click

        setRBNService(False)

    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "伝票ボタン押下"
    ''' <summary>
    ''' 伝票ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlip.Click
        '入力チェック
        If Not (input_check()) Then Exit Sub

        If (Me.主担当者.SelectedIndex < 0) Then
            Call Sys_Error("主担当者 を選択してください。　", Me.主担当者)
            Exit Sub
        End If

        'D_顧客、E_来店者登録処理
        売上情報登録処理(False)

        '伝票印刷
        伝票印刷()

        If Me.btn会計.Text = "再会計" Then
            ReCheckDenpyoFlag = True ' 再会計時伝票ボタン押下チェックフラグ
            c0400_会計.ShowDialog()
            Me.btn閉じる.Focus()
        End If

    End Sub
#End Region

#Region "会計ボタン押下"
    ''' <summary>
    ''' 会計ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn会計_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn会計.Click
        If Not (input_check()) Then Exit Sub

        'D_顧客、E_来店者登録処理
        売上情報登録処理(False)

        c0400_会計.ShowDialog()
        Me.btn閉じる.Focus()
    End Sub
#End Region

#Region "仮登録ボタン押下"
    ''' <summary>
    ''' 仮登録ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn仮登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn仮登録.Click
        'D_顧客、E_来店者登録処理
        売上情報登録処理(True)
    End Sub
#End Region

#Region "メモ設定ボタン押下"
    ''' <summary>
    ''' メモ設定ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnメモ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnメモ.Click
        c0500_メモ設定.ShowDialog()

    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn閉じる.Click
        Me.Close()
    End Sub
#End Region

#Region "削除ボタン押下"
    ''' <summary>
    ''' 削除ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn削除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn削除.Click

        '入力チェック
        If Me.主担当者.Text = "" Then
            Call Sys_Error("主担当者を選択してください。　", Me.主担当者)
            Exit Sub
        End If

        If dgv売上一覧.SelectedRows.Count <> 0 Then
            If (MsgBox("削除しますか？　", Clng_Ynqub2, TTL) = vbNo) Then
                dgv売上一覧.ClearSelection()
                Exit Sub
            End If
        Else
            MsgBox("削除する売上を選択してください。  ", Clng_Okexb1, TTL)
            Exit Sub
        End If

        Try
            ' トランザクション開始
            DBA.TransactionStart()

            '在庫数調整（E_入出庫、C_商品）
            param.Clear()
            param.Add("@来店日", USER_DATE)
            param.Add("@来店者番号", SER_NO)
            param.Add("@顧客番号", CST_CODE)
            logic.在庫数調整_戻し(param, PAGE_TITLE)

            '売上明細削除処理（E_売上明細、E_ポイント）
            param.Add("@売上番号", dgv売上一覧.SelectedRows(0).Cells(0).Value)
            logic.売上明細削除(param)

            'その他の売上明細を会計済から未会計に変更
            param.Add("@更新日", Now)
            logic.update会計済_売上明細(param, False, PAGE_TITLE)

            'E_売上削除
            logic.E_売上削除(param, PAGE_TITLE)

            '来店者情報更新
            logic.update会計済_来店者(param, False, PAGE_TITLE)

            '顧客情報更新
            If Me.btn会計.Text = "再会計" Then
                logic.顧客情報戻し(PAGE_TITLE)
            End If

            '売上一覧再表示
            dgv売上一覧.ClearSelection()
            gdv売上一覧更新()

            Me.btn会計.Text = "会計"
            If Me.dgv売上一覧.RowCount = 0 Then
                Me.btn削除.Enabled = False

            End If

            ' コミット
            DBA.TransactionCommit()

        Catch ex As Exception
            ' ロールバック
            DBA.TransactionRollBack()
            Call Sys_Error("エラーが発生しました。再度処理を行ってください。　", Me.btn削除)

        End Try

    End Sub
#End Region

#End Region

#Region "メソッド"

#Region "ラジオボタン変更時処理"
    ''' <summary>ラジオボタン変更時処理</summary>
    ''' <remarks></remarks>
    Private Sub setRBNService(ByVal bFlg As Boolean)

        If bFlg = True Then
            ' サービス割合選択時
            Me.txtサービス率.Enabled = True
            Me.txtサービス.Enabled = False

            Me.txtサービス率.BackColor = Color.White
            Me.txtサービス.BackColor = SystemColors.Control

            Me.txtサービス率.Focus()

            rbnServiceRate.Checked() = True
            rbnServiceAmount.Checked() = False

        Else
            ' サービス金額選択時
            Me.txtサービス率.Enabled = False
            Me.txtサービス.Enabled = True

            Me.txtサービス率.BackColor = SystemColors.Control
            Me.txtサービス.BackColor = Color.White

            Me.txtサービス.Focus()
            rbnServiceAmount.Checked() = True
            rbnServiceRate.Checked() = False

        End If

    End Sub
#End Region

#Region "サービス率チェック"
    ''' <summary>サービス率チェック</summary>
    ''' <remarks></remarks>
    Private Function serviceRate_check() As Boolean
        serviceRate_check = False

        If Not String.IsNullOrEmpty(Me.txtサービス率.Text) Then
            If Sys_InputCheck(Me.txtサービス率.Text, 6, "F1", 0) Then
                Me.txtサービス率.Text = Format("0", "0.0")
                Call Sys_Error("サービス割合 は100%以内の半角数字(小数第1位まで)で入力してください。　", Me.txtサービス率)
                Exit Function
            End If

            If ((Double.Parse(Me.txtサービス率.Text) < 0) Or (Double.Parse(Me.txtサービス率.Text) > 100)) Then
                Me.txtサービス率.Text = Format("0", "0.0")
                Call Sys_Error("サービス割合 は0～100%となる半角数字(小数第1位まで)で入力してください。　", Me.txtサービス率)
                Exit Function
            End If
        End If

        '合計金額算出
        getTotal()

        serviceRate_check = True
        Return serviceRate_check

    End Function
#End Region

#Region "入力チェック"
    ''' <summary>入力チェック</summary>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        input_check = False

        ''選択項目チェック
        If selected_check() = False Then
            Me.dgv商品一覧.ClearSelection()
            Me.dgv売上一覧.ClearSelection()
            Return input_check
            Exit Function
        End If

        If (Me.txtサービス.Text <> "" AndAlso CLng(Me.txtサービス.Text > 0) AndAlso Me.cmbサービス.SelectedIndex = -1) Then
            Call Sys_Error("サービス を選択してください。　", Me.cmbサービス)
            Exit Function
        ElseIf ((Me.txtサービス.Text = "" OrElse CLng(Me.txtサービス.Text = 0)) AndAlso (Me.cmbサービス.SelectedIndex <> -1)) Then
            Me.cmbサービス.SelectedIndex = -1
        End If

        If (Me.txtポイント割引額.Text <> "" AndAlso CLng(Me.txtポイント割引額.Text) > 0 AndAlso Me.cmbポイント割引.SelectedIndex = -1) Then
            Call Sys_Error("ポイント割引 を選択してください。　", Me.cmbポイント割引)
            Exit Function
        ElseIf ((Me.txtポイント割引額.Text = "" OrElse CLng(Me.txtポイント割引額.Text = 0)) AndAlso (Me.cmbポイント割引.SelectedIndex <> -1)) Then
            Me.cmbポイント割引.SelectedIndex = -1
        End If

        If (Me.dgv売上一覧.RowCount = 0) Then
            Call Sys_Error("売上 が登録されていません。　", Me.来店区分)
            Return input_check
            Exit Function
        End If

        '合計算出
        Call getTotal()

        If (Replace(Me.合計金額.Text, ",", "") < 0) Then
            Call Sys_Error("合計金額がマイナスです。　", Me.cmbサービス)
            Return input_check
            Exit Function
        End If

        input_check = True
        Return input_check
    End Function
#End Region

#Region "選択項目チェック"
    ''' <summary>選択項目チェック</summary>
    ''' <remarks></remarks>
    Private Function selected_check() As Boolean
        selected_check = False

        If (Me.性別番号.SelectedIndex < 0 OrElse Me.性別番号.Text = "") Then
            Call Sys_Error("性別 を選択してください。　", Me.性別番号)
            Exit Function
        End If

        ' 主担当者チェック
        If Not checkStaff() Then
            Exit Function
        End If

        If (Me.来店区分.SelectedIndex < 0 OrElse Me.来店区分.Text = "") Then
            Call Sys_Error("来店区分 を選択してください。　", Me.来店区分)
            Exit Function
        End If

        selected_check = True
    End Function
#End Region

#Region "主担当者チェック"
    ''' <summary>主担当者チェック</summary>
    ''' <returns>True：正常、False：エラー</returns>
    ''' <remarks></remarks>
    Private Function checkStaff() As Boolean
        checkStaff = False
        If (Me.主担当者.SelectedIndex < 0) AndAlso Me.dgv分類一覧.SelectedRows.Count > 0 Then
            Call Sys_Error("主担当者 を選択してください。　", Me.主担当者)
            Exit Function
        End If
        checkStaff = True
    End Function
#End Region

#Region "商品一覧設定"
    ''' <summary>商品一覧設定</summary>
    ''' <remarks></remarks>
    Private Sub setGoodList()
        Dim makerFlag As Boolean = False

        param.Clear()
        param.Add("@売上区分番号", Me.dgv売上区分.SelectedRows(0).Cells(0).Value)
        param.Add("@分類番号", Me.dgv分類一覧.SelectedRows(0).Cells(0).Value)

        '店販対象
        If (Boolean.Parse(dgv分類一覧.SelectedRows(0).Cells(2).Value.ToString) AndAlso Not (メーカー.SelectedValue Is DBNull.Value)) Then
            If (メーカー.SelectedIndex >= 0 AndAlso メーカー.SelectedIndex >= 0) Then
                makerFlag = True
                param.Add("@メーカー番号", Me.メーカー.SelectedValue)
            End If
        End If

        Me.dgv商品一覧.DataSource = logic.getGoods(param, makerFlag)
        Me.dgv商品一覧.ClearSelection()
        Me.dgv商品一覧.Columns("商品番号").Visible = False
        Me.dgv商品一覧.Columns("商品名").Width = 280
        Me.dgv商品一覧.Columns("販売金額").Visible = False
        Me.dgv商品一覧.Columns("金額管理区分").Visible = False
    End Sub
#End Region

#Region "売上一覧表示"
    ''' <summary>売上一覧データグリットビューを更新する</summary>
    ''' <remarks></remarks>
    Private Sub gdv売上一覧更新()

        'パラメータ設定（@来店日/@来店者番号/@顧客番号）
        param.Clear()
        param.Add("@来店日", USER_DATE)
        param.Add("@来店者番号", SER_NO)
        param.Add("@顧客番号", CST_CODE)
        Me.dgv売上一覧.RowTemplate.Height = 16
        Me.dgv売上一覧.DataSource = logic.getSalesList(param)
        Me.dgv売上一覧.ClearSelection()
        Me.dgv売上一覧.Columns("売上番号").Visible = False
        Me.dgv売上一覧.Columns("分類名").Width = 190
        Me.dgv売上一覧.Columns("商品名").Width = 200

        Me.dgv売上一覧.Columns("編集数量").Width = 35
        Me.dgv売上一覧.Columns("編集数量").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv売上一覧.Columns("編集数量").DefaultCellStyle.Format = "#,##0"

        Me.dgv売上一覧.Columns("編集金額").Width = 80
        Me.dgv売上一覧.Columns("編集金額").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv売上一覧.Columns("編集金額").DefaultCellStyle.Format = "#,##0"

        Me.dgv売上一覧.Columns("編集サービス").Width = 80
        Me.dgv売上一覧.Columns("編集サービス").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv売上一覧.Columns("編集サービス").DefaultCellStyle.Format = "#,##0"

        Me.dgv売上一覧.Columns("小計").Width = 80
        Me.dgv売上一覧.Columns("小計").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv売上一覧.Columns("小計").DefaultCellStyle.Format = "#,##0"

        Me.dgv売上一覧.Columns("担当者名").Width = 90
        Me.dgv売上一覧.Columns("消費税").Visible = False
    End Sub
#End Region

#Region "合計金額算出"
    ''' <summary>売上明細、割引から合計金額を算出する</summary>
    ''' <remarks></remarks>
    Private Sub getTotal()
        Dim i As Integer
        Dim subAmount As Long = 0
        Dim totalAmount As Long = 0
        Dim totalTax As Long = 0
        Dim a As Double

        If dgv売上一覧.Rows.Count > 0 Then
            For i = 0 To dgv売上一覧.Rows.Count - 1
                subAmount += CLng(Replace(Me.dgv売上一覧.Rows(i).Cells("小計").Value, ",", ""))
                totalTax += CLng(Me.dgv売上一覧.Rows(i).Cells("消費税").Value)
            Next i

            'サービス金額算出
            If rbnServiceRate.Checked Then
                If txtサービス率.Text = "" Then
                    txtサービス.Text = 0
                Else
                    txtサービス.Text = Sys_Service(subAmount * (txtサービス率.Text / 100))
                End If
            Else
                If Me.txtサービス.Text = "" Then
                    a = 0
                Else
                    Select Case iServicetype
                        Case 1 ' 切り上げ
                            Me.txtサービス率.Text = (Math.Ceiling(Double.Parse(Me.txtサービス.Text) / Double.Parse(subAmount) * 1000) / 10).ToString
                            a = Double.Parse(Me.txtサービス率.Text)
                            Exit Select
                        Case 2 ' 切り捨て
                            Me.txtサービス率.Text = (Math.Floor(Double.Parse(Me.txtサービス.Text) / Double.Parse(subAmount) * 1000) / 10).ToString
                            a = Double.Parse(Me.txtサービス率.Text)
                            Exit Select
                        Case 3 ' 四捨五入
                            Me.txtサービス率.Text = (Double.Parse(Me.txtサービス.Text) / Double.Parse(subAmount) * 100).ToString
                            a = Double.Parse(Me.txtサービス率.Text)
                            Exit Select
                        Case Else
                            ' エラー
                    End Select
                End If
                Me.txtサービス率.Text = Format(a, "0.0")
            End If

            totalAmount = subAmount - CLng(Replace(txtポイント割引額.Text, "", "0")) - CLng(Replace(txtサービス.Text, "", "0"))
            Me.合計金額.Text = Format(totalAmount, "#,##0")
            Me.消費税.Text = totalTax - Sys_Tax(CLng(Replace(txtサービス.Text, ",", "")), USER_DATE, 1)

        End If
    End Sub
#End Region

#Region "売上情報登録処理"
    ''' <summary>
    ''' 売上情報登録処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 売上情報登録処理(ByVal bCloseFlg As Boolean)

        '入力チェック
        If (Len(Trim(Me.性別番号.Text)) = 0 Or Me.性別番号.Text = "0" Or Me.性別番号.Text = "その他") Then
            Call Sys_Error("性別 を選択してください。　", Me.性別番号)
            Exit Sub
        End If

        If (Len(Trim(Me.主担当者.Text)) = 0 Or Me.主担当者.Text = "0") Then
            Call Sys_Error("主担当者 を選択してください。　", Me.主担当者)
            Exit Sub
        End If

        If (Me.txtポイント割引額.Text <> "" AndAlso CLng(Me.txtポイント割引額.Text) > 0 AndAlso Me.cmbポイント割引.SelectedIndex = -1) Then
            Call Sys_Error("ポイント割引 を選択してください。　", Me.cmbポイント割引)
            Exit Sub
        ElseIf ((Me.txtポイント割引額.Text = "" OrElse CLng(Me.txtポイント割引額.Text = 0)) AndAlso (Me.cmbポイント割引.SelectedIndex <> -1)) Then
            Me.cmbポイント割引.SelectedIndex = -1
        End If

        If (Me.txtサービス.Text <> "" AndAlso CLng(Me.txtサービス.Text > 0) AndAlso Me.cmbサービス.SelectedIndex = -1) Then
            Call Sys_Error("サービス を選択してください。　", Me.cmbサービス)
            Exit Sub
        ElseIf ((Me.txtサービス.Text = "" OrElse CLng(Me.txtサービス.Text = 0)) AndAlso (Me.cmbサービス.SelectedIndex <> -1)) Then
            Me.cmbサービス.SelectedIndex = -1
        End If

        If (Me.txtサービス率.Text <> "" AndAlso CLng(Me.txtサービス率.Text > 0) AndAlso Me.cmbサービス.SelectedIndex = -1) Then
            Call Sys_Error("サービス を選択してください。　", Me.cmbサービス)
            Exit Sub
        ElseIf ((Me.txtサービス率.Text = "" OrElse CLng(Me.txtサービス率.Text = 0)) AndAlso (Me.cmbサービス.SelectedIndex <> -1)) Then
            Me.cmbサービス.SelectedIndex = -1
        End If

        '更新値設定
        param.Clear()
        param.Add("@来店日", USER_DATE)
        param.Add("@来店者番号", SER_NO)
        param.Add("@顧客番号", CST_CODE)

        param.Add("@性別番号", Me.性別番号.SelectedValue)
        param.Add("@主担当者番号", Me.主担当者.SelectedValue)


        If Me.指名.Checked = False Then
            param.Add("@指名", 0)
        Else
            param.Add("@指名", 1)
        End If

        If Me.cmbポイント割引.SelectedIndex = -1 Then
            param.Add("@ポイント割引番号", 0)
            param.Add("@ポイント割引支払", 0)
        Else
            param.Add("@ポイント割引番号", Me.cmbポイント割引.SelectedValue)
            param.Add("@ポイント割引支払", Me.txtポイント割引額.Text)
        End If

        If Me.cmbサービス.SelectedIndex = -1 Then
            param.Add("@サービス番号", 0)
            param.Add("@サービス区分", 1)
            param.Add("@サービス金額", 0)
        Else
            param.Add("@サービス番号", Me.cmbサービス.SelectedValue)
            If rbnServiceRate.Checked = True Then
                param.Add("@サービス区分", "1")

                param.Add("@サービス金額", Val(Me.txtサービス率.Text) * 100)

            Else
                param.Add("@サービス区分", "2")
                param.Add("@サービス金額", Me.txtサービス.Text)
            End If
        End If

        param.Add("@更新日", Now)

        Try
            ' トランザクション開始
            DBA.TransactionStart()

            logic.D_顧客データ更新(param)
            logic.E_来店者データ保持(param)

            ' コミット
            DBA.TransactionCommit()

            ' 「仮登録」時はメインメニュー画面へ
            ' 「伝票」、「会計」時は売上画面のまま
            If bCloseFlg = True Then
                Me.Close()
            End If

        Catch ex As Exception
            ' ロールバック
            DBA.TransactionRollBack()
            Throw ex
        End Try

    End Sub
#End Region

#Region "伝票印刷"
    Private Sub 伝票印刷()
        Dim i As Integer
        Dim param As New Habits.DB.DBParameter
        Dim receiptFlag As Boolean = True
        Dim service As Long = 0

        Try
            ' トランザクション開始
            DBA.TransactionStart()

            'W_レシート削除
            logic.W_レシート削除()

            '割引の算出
            j = 0
            pointPurchases = 0
            If txtポイント割引額.Text <> "" Then
                pointPurchases = CLng(Me.txtポイント割引額.Text)
            End If
            If txtサービス.Text <> "" Then
                service = CLng(Me.txtサービス.Text)
            End If

            For i = 0 To dgv売上一覧.RowCount - 1
                j += 1
                '売上詳細行(売上)
                W_レシート追加(1, dgv売上一覧.Rows(i).Cells(2).Value, dgv売上一覧.Rows(i).Cells(3).Value, dgv売上一覧.Rows(i).Cells(4).Value)

                '売上詳細行(サービス)
                If dgv売上一覧.Rows(i).Cells(5).Value.ToString() <> 0 Then
                    W_レシート追加(1, "　　割引", 0, dgv売上一覧.Rows(i).Cells(5).Value.ToString())
                End If
            Next

            'サービス値引行
            If service <> 0 Then
                W_レシート追加(2, "割引", 0, service * -1)
            End If

            'ポイント割引行
            If pointPurchases <> 0 Then
                W_レシート追加(3, cmbポイント割引.SelectedText, 0, pointPurchases * -1)
                W_レシート追加(4, cmbポイント割引.SelectedText + "後", 0, CLng(Replace(Me.合計金額.Text, ",", "")))
            End If

            '  引数：
            '       レポート名
            '       データソース名
            '       データソース
            '       プリンタ True：いつも使うプリンター False: 設定されたプリンタ
            '       0:印刷 / 1:プレビュー
            '       印刷の向き True：横 / False:縦
            '       印刷サイズ
            If My.MySettings.Default.ReceiptFlag = 1 Then
                receiptFlag = False
            Else
                receiptFlag = True
            End If

            rtn = Rep_Print("c0101_伝票.rdlc", "DS0001_レシート", logic.getReceipt(), receiptFlag, 0, False, 2)

            ' コミット
            DBA.TransactionCommit()
        Catch ex As Exception
            ' ロールバック
            DBA.TransactionRollBack()
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
            param.Add("@氏名", Me.氏名.Text)
            param.Add("@主担当者名", 主担当者.Text)
            param.Add("@品名", name)
            param.Add("@数量", num)
            param.Add("@金額", amount)

            param.Add("@小計", CLng(Me.合計金額.Text) + pointPurchases)
            param.Add("@消費税", CLng(Me.消費税.Text))
            param.Add("@合計", CLng(Me.合計金額.Text))
            param.Add("@お釣り", 0)

            'Wレシート追加
            logic.insertW_Receipt(param)
        End If
    End Sub
#End Region

#Region "売上区分一覧選択"
    ''' <summary>
    ''' 売上区分一覧選択
    ''' </summary>
    Protected Friend Sub changeSalesDiv()



    End Sub
#End Region

#End Region

End Class
