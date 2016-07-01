''' <summary>c0200_売上入力画面処理</summary>
''' <remarks></remarks>
Public Class c0200_売上入力

    Private Const PAGE_TITLE As String = "c0200_売上入力"
    Private logic As Habits.Logic.c0200_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub c0200_売上入力_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logic = New Habits.Logic.c0200_Logic

        Dim DTA As New DataTable ' D_担当者
        Dim param As New Habits.DB.DBParameter
        Dim a As Double

        If c0100_売上.dgv商品一覧.SelectedRows(0).Cells(3).Value.ToString() = "2" Then
            Me.金額.Text = CLng(c0100_売上.dgv商品一覧.SelectedRows(0).Cells(2).Value.ToString)

        Else
            Me.金額.Text = CLng(c0100_売上.dgv商品一覧.SelectedRows(0).Cells(2).Value.ToString) + Sys_Tax(CLng(c0100_売上.dgv商品一覧.SelectedRows(0).Cells(2).Value.ToString), USER_DATE, 0)


        End If

        Me.分類.Text = c0100_売上.dgv分類一覧.SelectedRows(0).Cells(1).Value.ToString
        Me.名称.Text = c0100_売上.dgv商品一覧.SelectedRows(0).Cells(1).Value.ToString

        '初期値設定
        Me.数量.Text = "1"
        a = 0
        Me.txtサービス.Text = Format(a, "0.0")

        '金額算出、及びカンマ編集
        更新後計算()

        '売上担当者番号(隠し)
        Me.売上担当者番号.Text = c0100_売上.主担当者.SelectedValue.ToString

        param.Add("@担当者番号", Me.売上担当者番号.Text)
        DTA = logic.D_担当者取得(param)

        If DTA.Rows.Count <> 0 Then
            Me.売上担当者.Text = DTA.Rows(0)("担当者名").ToString
        End If

        'サービス名コンボボックス
        Me.Cmbサービス名.DataSource = logic.getService_exclude()
        Me.Cmbサービス名.DisplayMember = "サービス名"
        Me.Cmbサービス名.ValueMember = "サービス番号"
        Me.Cmbサービス名.SelectedIndex = -1

        Me.Cmbサービス名.Enabled = False
        Me.txtサービス.CausesValidation = True
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub c0200_売上入力_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

#End Region

#Region "ボタン押下処理"

#Region "閉じるボタン押下"
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
        c0100_売上.dgv商品一覧.ClearSelection()
        Call gdv売上一覧更新()
    End Sub
#End Region

#Region "売上ボタン押下"
    Private Sub 売上_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 売上.Click
        Dim rtn As Integer
        Dim param As New Habits.DB.DBParameter
        Dim sum As Long             '合計金額
        Dim tax As Long = 0         '消費税

        If Not (input_check()) Then Exit Sub

        For Each row As Windows.Forms.DataGridViewRow In c0100_売上.dgv売上一覧.Rows
            Dim value As Integer = DirectCast(row.Cells("編集金額").Value, Integer)
            sum += value
        Next

        sum += Integer.Parse(小計金額.Text)
        If sum > 1000000000 Then
            MsgBox("小計金額が1,000,000,000円以内で　" & Chr(13) & Chr(13) & _
            "入力してください。　", Clng_Okexb1, TTL)
            Exit Sub
        End If
        Try
            ' トランザクション開始
            DBA.TransactionStart()

            param.Clear()
            param.Add("@来店日", USER_DATE)
            param.Add("@来店者番号", SER_NO)
            param.Add("@顧客番号", CST_CODE)
            param.Add("@更新日", Now)

            If c0100_売上.btn会計.Text = "再会計" Then

                '在庫数調整（E_入出庫、C_商品）
                logic.在庫数調整_戻し(param, PAGE_TITLE)

                'その他の売上明細を会計済から未会計に変更
                logic.update会計済_売上明細(param, False, PAGE_TITLE)

                'E_売上削除
                logic.E_売上削除(param, PAGE_TITLE)

                '来店者情報更新
                logic.update会計済_来店者(param, False, PAGE_TITLE)

                '顧客情報更新
                logic.顧客情報戻し(PAGE_TITLE)
            End If

            '次売上番号を取得
            param.Add("@売上番号", Long.Parse(logic.get次売上番号(param)))

            '消費税を算出
            tax = Sys_Tax(CLng(Me.金額.Text), USER_DATE, 1) * CLng(Me.数量.Text) - Sys_Tax(CLng(Replace(Me.txtサービス額.Text, ",", "")), USER_DATE, 1)

            param.Add("@売上区分番号", (c0100_売上.dgv売上区分.SelectedRows(0).Cells(0).Value))
            param.Add("@売上担当者番号", Me.売上担当者番号.Text)
            param.Add("@分類番号", c0100_売上.dgv分類一覧.SelectedRows(0).Cells(0).Value)
            param.Add("@名称番号", c0100_売上.dgv商品一覧.SelectedRows(0).Cells(0).Value)
            param.Add("@数量", Me.数量.Text)
            param.Add("@金額", Me.金額.Text)
            param.Add("@サービス", CLng(Replace(Me.txtサービス額.Text, ",", "")))
            param.Add("@消費税", tax)
            param.Add("@会計済", "0")

            If Me.Cmbサービス名.SelectedIndex = -1 Then
                param.Add("@サービス番号", 0)
            Else
                param.Add("@サービス番号", Me.Cmbサービス名.SelectedValue)
            End If

            ' E_売上明細にデータを登録
            rtn = logic.InSertDataEUM(param)
            c0100_売上.btn会計.Focus()
            Me.Close()

            c0100_売上.btn会計.Text = "会計"

            c0100_売上.dgv商品一覧.ClearSelection()

            gdv売上一覧更新()
            c0100_売上.btn削除.Enabled = True

            Me.Cmbサービス名.Enabled = False

            ' コミット
            DBA.TransactionCommit()

        Catch ex As Exception
            ' ロールバック
            DBA.TransactionRollBack()
        End Try

    End Sub
#End Region

#Region "売上担当変更ボタン押下"
    Private Sub 売上担当変更_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 売上担当変更.Click
        Me.売上担当者番号.Text = c0100_売上.主担当者.SelectedValue.ToString
        c0300_売上担当.ShowDialog()
    End Sub
#End Region

#End Region

#Region "バリデーションチェック"
    Private Sub 数量_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles 数量.Validated
        ' 数量チェック
        If Not input_check_number() Then
            Me.数量.Text = "1"
        End If

        Call 更新後計算()
        RemoveHandler 数量.Validated, AddressOf 数量_Validated
        AddHandler 数量.Validated, AddressOf 数量_Validated
    End Sub

    Private Sub 金額_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles 金額.Validated
        ' 金額チェック
        If Not input_check_cost() Then
            Me.金額.Text = c0100_売上.dgv商品一覧.SelectedRows(0).Cells(2).Value.ToString
        End If
        Call 更新後計算()
        RemoveHandler 金額.Validated, AddressOf 金額_Validated
        AddHandler 金額.Validated, AddressOf 金額_Validated

    End Sub

    Private Sub 割引_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtサービス.Validated
        Dim a As Double
        If input_check_rate() Then
            a = Double.Parse(Me.txtサービス.Text)
            ''小数第２位四捨五入
            Me.txtサービス.Text = Format(a, "0.0")
            Call 更新後計算()
            Me.Cmbサービス名.Enabled = True
        Else
            a = 0
            Me.txtサービス.Text = Format(a, "0.0")
        End If

        If Double.Parse(Me.txtサービス.Text) = 0.0 Then
            Me.Cmbサービス名.Enabled = False
            Me.Cmbサービス名.SelectedIndex = -1
        End If
        RemoveHandler txtサービス.Validated, AddressOf 割引_Validated
        AddHandler txtサービス.Validated, AddressOf 割引_Validated
    End Sub

    Private Sub サービス_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtサービス額.Validated
        Dim a As Double
        ' カンマ削除処理
        Me.txtサービス額.Text = Replace(Me.txtサービス額.Text, ",", "")
        Me.金額.Text = Replace(Me.金額.Text, ",", "")

        If IsNumeric(Me.txtサービス額.Text) = True Then
            If Me.txtサービス額.Text > (Long.Parse(Me.金額.Text) * Long.Parse(Me.数量.Text)) Then
                Me.txtサービス額.Text = (Long.Parse(Me.金額.Text) * Long.Parse(Me.数量.Text))
            End If

            If Me.txtサービス額.Text = 0 Then
                a = 0
            Else
                Select Case iServicetype
                    Case 1 ' 切り上げ
                        Me.txtサービス.Text = (Math.Ceiling(Double.Parse(Me.txtサービス額.Text) / Double.Parse(Me.小計金額.Text) * 1000) / 10).ToString
                        a = Double.Parse(Me.txtサービス.Text)
                        Exit Select
                    Case 2 ' 切り捨て
                        Me.txtサービス.Text = (Math.Floor(Double.Parse(Me.txtサービス額.Text) / Double.Parse(Me.小計金額.Text) * 1000) / 10).ToString
                        a = Double.Parse(Me.txtサービス.Text)
                        Exit Select
                    Case 3 ' 四捨五入
                        Me.txtサービス.Text = (Double.Parse(Me.txtサービス額.Text) / Double.Parse(Me.小計金額.Text) * 100).ToString
                        a = Double.Parse(Me.txtサービス.Text)
                        Exit Select
                    Case Else
                        ' エラー
                End Select
            End If
            Me.txtサービス.Text = Format(a, "0.0")

            Me.小計金額.Text = (Long.Parse(Me.金額.Text) * Long.Parse(Me.数量.Text)).ToString
            a = Double.Parse(Me.小計金額.Text)
            Me.小計金額.Text = Format(a, "#,##0")

            Me.合計金額.Text = (Long.Parse(Me.金額.Text) * Long.Parse(Me.数量.Text) - Long.Parse(Me.txtサービス額.Text)).ToString
            a = Double.Parse(Me.合計金額.Text)
            Me.合計金額.Text = Format(a, "#,##0")

            a = Double.Parse(Me.金額.Text)
            Me.金額.Text = Format(a, "#,##0")

            Me.Cmbサービス名.Enabled = True
            If Double.Parse(Me.txtサービス額.Text) = 0 Then
                Me.Cmbサービス名.Enabled = False
                Me.Cmbサービス名.SelectedIndex = -1

            End If
            If Me.Cmbサービス名.Enabled Then
                RemoveHandler txtサービス額.Validated, AddressOf サービス_Validated
                Me.Cmbサービス名.Focus()
                AddHandler txtサービス額.Validated, AddressOf サービス_Validated
            Else
                RemoveHandler txtサービス額.Validated, AddressOf サービス_Validated
                Me.売上.Focus()
                AddHandler txtサービス額.Validated, AddressOf サービス_Validated
            End If
        Else
            MsgBox("サービス額 は半角数字で入力してください。　", Clng_Okexb1, TTL)
            Me.txtサービス額.Text = "0"
            a = Double.Parse(Me.txtサービス額.Text)
            Me.txtサービス額.Text = Format(a, "#,##0")

            Me.txtサービス.Text = (Double.Parse(Me.txtサービス額.Text) / Double.Parse(Me.小計金額.Text) * 100).ToString
            a = Double.Parse(Me.txtサービス.Text)
            ''小数第２位四捨五入
            Me.txtサービス.Text = Format(a, "0.0")

            Me.小計金額.Text = (Double.Parse(Me.金額.Text) * Double.Parse(Me.数量.Text)).ToString
            a = Double.Parse(Me.小計金額.Text)
            Me.小計金額.Text = Format(a, "#,##0")

            Me.合計金額.Text = (Double.Parse(Me.金額.Text) * Double.Parse(Me.数量.Text) - Double.Parse(Me.txtサービス額.Text)).ToString
            a = Double.Parse(Me.合計金額.Text)
            Me.合計金額.Text = Format(a, "#,##0")

            a = Double.Parse(Me.金額.Text)
            Me.金額.Text = Format(a, "#,##0")

            Me.Cmbサービス名.Enabled = False
            Me.Cmbサービス名.SelectedIndex = -1
        End If

        ' カンマ編集
        Me.txtサービス額.Text = Format(Double.Parse(Me.txtサービス額.Text), "#,##0")

    End Sub
#End Region

#Region "キープレスイベント"
    Private Sub 数量_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles 数量.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub 金額_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles 金額.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub サービス_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtサービス額.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub
#End Region

#Region "フォーカスイベント"
    Private Sub 金額_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 金額.Enter
        金額.Text = Replace(Me.金額.Text, ",", "")
    End Sub

    Private Sub 割引_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtサービス.Enter
        Me.Cmbサービス名.Enabled = True
    End Sub

    Private Sub サービス_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtサービス額.Enter
        txtサービス額.Text = Replace(Me.txtサービス額.Text, ",", "")
        Me.Cmbサービス名.Enabled = True
    End Sub
#End Region

#Region "キー押下イベント"
    Private Sub 数量_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 数量.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.金額.Focus()
        End If
    End Sub

    Private Sub 金額_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 金額.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtサービス.Focus()
        End If
    End Sub

    Private Sub 割引_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtサービス.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtサービス額.Focus()
        End If
    End Sub

    Private Sub サービス_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtサービス額.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.Cmbサービス名.Focus()
        End If
    End Sub

    Private Sub Cmbサービス名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmbサービス名.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.売上.Focus()
        End If
    End Sub

#End Region

#Region "メソッド"

#Region "入力データチェック"
    ''' <summary>入力データチェック</summary>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        input_check = False

        ' 数量チェック
        If Not input_check_number() Then
            Exit Function
        End If

        ' 金額チェック
        If Not input_check_cost() Then
            Exit Function
        End If

        ' 割引チェック
        If Not input_check_rate() Then
            Exit Function
        End If
        ' サービスチェック
        If Not input_check_service() Then
            Exit Function
        End If
        input_check = True

    End Function
#End Region

#Region "数量チェック"
    ''' <summary>数量の入力データチェック</summary>
    ''' <remarks></remarks>
    Private Function input_check_number() As Boolean
        input_check_number = False

        If String.IsNullOrEmpty(Me.数量.Text) Then
            MsgBox("数量 は必須入力です。　", Clng_Okexb1, TTL)
            Exit Function
        End If

        If Sys_InputCheck(Me.数量.Text, 3, "N+", 1) Then
            Call Sys_Error("数量 は半角数字3桁以内で入力してください。　", Me.数量)
            Exit Function
        End If

        If (Integer.Parse(Me.数量.Text) = 0) Then
            Call Sys_Error("数量 は1以上の半角数字で入力してください。　", Me.数量)
            Exit Function
        End If

        input_check_number = True
    End Function
#End Region

#Region "金額チェック"
    ''' <summary>金額の入力データチェック</summary>
    ''' <remarks></remarks>
    Private Function input_check_cost() As Boolean
        input_check_cost = False

        If String.IsNullOrEmpty(Me.金額.Text) Then
            Call Sys_Error("金額 は必須入力です。　", Me.金額)
            Exit Function
        End If

        Me.金額.Text = Replace(Me.金額.Text, ",", "")
        If Sys_InputCheck(Me.金額.Text, 9, "N+", 1) Then
            Call Sys_Error("金額 は半角数字9桁以内で入力してください。　", Me.金額)
            Exit Function
        End If

        If (Integer.Parse(Me.金額.Text) < 0) Then
            Call Sys_Error("金額 は0以上の半角数字で入力してください。　", Me.金額)
            Exit Function
        End If

        input_check_cost = True
    End Function
#End Region

#Region "割引チェック"
    ''' <summary>割引の入力データチェック</summary>
    ''' <remarks></remarks>
    Private Function input_check_rate() As Boolean
        input_check_rate = False

        If Not String.IsNullOrEmpty(Me.txtサービス.Text) Then
            If Sys_InputCheck(Me.txtサービス.Text, 6, "F1", 0) Then
                Call Sys_Error("サービス は100%以内の半角数字(小数第1位まで)で入力してください。　", Me.txtサービス)
                Exit Function
            End If

            'Me.txtサービス.Text = StrConv(Me.txtサービス.Text, VbStrConv.Narrow)
            If ((Double.Parse(Me.txtサービス.Text) < 0) Or (Double.Parse(Me.txtサービス.Text) > 100)) Then
                Call Sys_Error("サービス は0～100%となる半角数字(小数第1位まで)で入力してください。　", Me.txtサービス)
                Exit Function
            End If
        End If

        input_check_rate = True
    End Function
#End Region

#Region "サービスチェック"
    ''' <summary>サービスの入力データチェック</summary>
    ''' <remarks></remarks>
    Private Function input_check_service() As Boolean
        input_check_service = False

        If Not String.IsNullOrEmpty(Me.txtサービス額.Text) Then
            Me.txtサービス額.Text = Replace(Me.txtサービス額.Text, ",", "")
            If Sys_InputCheck(Me.金額.Text, 9, "N+", 1) Then
                Call Sys_Error("サービス額 は半角数字9桁以内で入力してください。　", Me.txtサービス額)
                Exit Function
            End If

            Me.小計金額.Text = Replace(Me.小計金額.Text, ",", "")
            If Integer.Parse(Me.txtサービス額.Text) > Integer.Parse(Me.小計金額.Text) Then
                Call Sys_Error("サービス額 は小計以下で入力してください。　", Me.txtサービス額)
                Exit Function
            End If

            If Integer.Parse(Me.txtサービス額.Text) <> 0 Then
                If (Me.Cmbサービス名.SelectedIndex = -1) Then
                    Call Sys_Error("サービスの種類を選択してください。　", Me.Cmbサービス名)
                    Exit Function
                End If
            End If
        End If

        input_check_service = True
    End Function
#End Region

#Region "売上一覧更新"
    ''' <summary>
    ''' 売上一覧データグリットビューを更新する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub gdv売上一覧更新()

        Dim param As New Habits.DB.DBParameter

        'パラメータ設定（@来店日/@来店者番号/@顧客番号）
        param.Add("@来店日", USER_DATE)
        param.Add("@来店者番号", SER_NO)
        param.Add("@顧客番号", CST_CODE)

        c0100_売上.dgv売上一覧.DataSource = logic.getSalesList(param)
        c0100_売上.dgv売上一覧.ClearSelection()

    End Sub
#End Region

#Region "更新後再計算"
    ''' <summary>
    ''' データを更新後、計算する
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 更新後計算()
        'カンマを外す
        Me.金額.Text = Replace(Me.金額.Text, ",", "")
        Me.小計金額.Text = Replace(Me.小計金額.Text, ",", "")
        Me.txtサービス額.Text = Replace(Me.txtサービス額.Text, ",", "")
        Me.合計金額.Text = Replace(Me.合計金額.Text, ",", "")

        '金額の算出
        Me.小計金額.Text = (Long.Parse(Me.金額.Text) * Long.Parse(Me.数量.Text)).ToString
        If Me.小計金額.Text.Length > 9 Then
            Call Sys_Error("小計 が999,999,999を超えないよう再入力してください。　", Me.数量)
            Me.数量.Text = "1"
            Me.小計金額.Text = Me.金額.Text
        End If

        Select Case iServicetype
            Case 0 ' 切り上げ
                Me.txtサービス額.Text = (Math.Ceiling(Decimal.Parse(Me.小計金額.Text) * Decimal.Parse(Me.txtサービス.Text) / 100D)).ToString
                Exit Select
            Case 1 ' 切り捨て
                Me.txtサービス額.Text = (Math.Floor(Decimal.Parse(Me.小計金額.Text) * Decimal.Parse(Me.txtサービス.Text) / 100D)).ToString
                Exit Select
            Case 2 ' 四捨五入
                Me.txtサービス額.Text = (Int((Decimal.Parse(Me.小計金額.Text) * Decimal.Parse(Me.txtサービス.Text) / 100D) + 0.5)).ToString
                Exit Select
            Case Else
                ' 切り上げ
                Me.txtサービス額.Text = (Math.Ceiling(Decimal.Parse(Me.小計金額.Text) * Decimal.Parse(Me.txtサービス.Text) / 100D)).ToString
                Exit Select

        End Select

        Me.合計金額.Text = (Long.Parse(Me.小計金額.Text) - Long.Parse(Me.txtサービス額.Text)).ToString

        'カンマ編集
        Dim a As Double

        a = Double.Parse(Me.金額.Text)
        Me.金額.Text = Format(a, "#,##0")

        a = Double.Parse(Me.小計金額.Text)
        Me.小計金額.Text = Format(a, "#,##0")

        a = Double.Parse(Me.txtサービス額.Text)
        Me.txtサービス額.Text = Format(a, "#,##0")

        a = Double.Parse(Me.合計金額.Text)
        Me.合計金額.Text = Format(a, "#,##0")
    End Sub
#End Region

#End Region
End Class