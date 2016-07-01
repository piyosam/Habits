''' <summary>f0500_分類画面処理</summary>
''' <remarks></remarks>
Public Class f0500_分類
    '初期表示パラメータ
    Private Initial_売上区分番号 As String = Nothing
    Private SelectionChangeLocked_dgv分類一覧 As Boolean = False
    Private Next_分類番号 As String = Nothing
    Private logic As Habits.Logic.f0500_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0500_分類_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' ロジッククラス生成
        logic = New Habits.Logic.f0500_Logic

        ''画面再描画処理
        ReDisplay()

        ''初期選択
        If Not String.IsNullOrEmpty(Initial_売上区分番号) Then
            Me.売上区分.SelectedValue = Initial_売上区分番号
            売上区分_SelectionChangeCommitted(Nothing, Nothing)
        End If

        ''初期表示パラメータ初期化
        Initial_売上区分番号 = Nothing

        ''背後の表示中画面への遷移防止
        If f0500_商品.Visible Then
            Me.商品.Enabled = False
        Else
            Me.商品.Enabled = True
        End If
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0500_分類_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

    Private Sub 売上区分_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 売上区分.SelectionChangeCommitted
        ReDisplay_dgv分類一覧()

        '' 新規ボタン活性
        Me.新規.Enabled = True
    End Sub

    Private Sub 売上区分_DataSourceChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 売上区分.DataSourceChanged
        '' 新規ボタン非活性
        Me.新規.Enabled = False
        '' 変更ボタン非活性
        Me.登録.Enabled = False
        Me.登録.Text = "変更"
    End Sub

    Private Sub dgv分類一覧_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv分類一覧.SelectionChanged
        If SelectionChangeLocked_dgv分類一覧 = False Then
            Me.lbl分類番号.Text = Nothing
            ReDisplay_入力項目()
        End If
    End Sub
#End Region

#Region "ボタン押下処理"

#Region "新規ボタン押下"
    ''' <summary>
    ''' 新規ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 新規_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新規.Click
        If Integer.Parse(Next_分類番号) <= Max_MasterNo Then
            Me.dgv分類一覧.ClearSelection()
            Clear_入力項目()
            SetEnable_入力項目(True)

            Me.txt分類名.Focus()
            Me.登録.Enabled = True
            Me.登録.Text = BTN_REGIST
            Me.lbl分類番号.Text = Next_分類番号
        Else
            Sys_Error("登録最大数に達したため登録できません。　", Me.閉じる)
        End If
    End Sub
#End Region

#Region "登録ボタン押下"
    ''' <summary>
    ''' 登録ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 登録.Click
        Dim param As New Habits.DB.DBParameter
        Dim tmp登録 As String = Me.登録.Text

        ''入力チェック
        If Not (input_check()) Then Exit Sub

        If String.Equals(Me.登録.Text, "登録") Then
            ''登録
            param.Add("@売上区分番号", Me.売上区分.SelectedValue)
            param.Add("@分類番号", Me.lbl分類番号.Text)
            param.Add("@分類名", Me.txt分類名.Text)
            param.Add("@表示順", Me.txt表示順.Text)
            param.Add("@店販対象フラグ", IIf(Me.店販対象フラグ.Checked, "1", "0"))
            param.Add("@削除フラグ", IIf(Me.削除フラグ.Checked, "1", "0"))
            param.Add("@登録日", Now())
            param.Add("@更新日", Now())

            logic.CommodityDivisionInsert(param)
        Else
            ''更新
            param.Add("@売上区分番号", Me.売上区分.SelectedValue)
            param.Add("@分類番号", Me.lbl分類番号.Text)
            param.Add("@分類名", Me.txt分類名.Text)
            param.Add("@表示順", Me.txt表示順.Text)
            param.Add("@店販対象フラグ", IIf(Me.店販対象フラグ.Checked, "1", "0"))
            param.Add("@削除フラグ", IIf(Me.削除フラグ.Checked, "1", "0"))
            param.Add("@更新日", Now())

            logic.CommodityDivisionUpdate(param)
        End If
        Me.lbl分類番号.Text = ""
        ReDisplay_dgv分類一覧()
        MsgBox(tmp登録 & "しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
        Me.新規.Focus()
    End Sub
#End Region

#Region "項目クリアボタン押下"
    ''' <summary>
    ''' 項目クリアボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 項目クリア_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 項目クリア.Click
        Me.dgv分類一覧.ClearSelection()
        Clear_入力項目()
        lbl分類番号.Text = Nothing
        Me.登録.Text = "変更"
        SetEnable_入力項目(False)
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub
#End Region

#Region "商品ボタン押下"
    ''' <summary>
    ''' 商品ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 商品_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 商品.Click
        Dim Selected売上区分番号 As String = Nothing
        Dim Selected分類番号 As String = Nothing

        If Me.売上区分.SelectedIndex >= 0 Then
            Selected売上区分番号 = Me.売上区分.SelectedValue
            If Me.dgv分類一覧.SelectedRows.Count > 0 Then
                Selected分類番号 = Me.dgv分類一覧.SelectedRows(0).Cells(0).Value
            End If
            f0500_商品.ShowDialogWithParam(Selected売上区分番号, Selected分類番号)
        Else
            f0500_商品.ShowDialog()
        End If
    End Sub
#End Region

#End Region

#Region "メソッド"

    ''' <summary>引数指定付きダイアログ表示</summary>
    ''' <param name="v_number_売上区分番号">売上区分番号</param>
    ''' <remarks></remarks>
    Public Sub ShowDialogWithParam(ByVal v_number_売上区分番号 As String)
        Initial_売上区分番号 = v_number_売上区分番号
        ShowDialog()
    End Sub

#Region "入力チェック"
    ''' <summary>入力チェック</summary>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        Dim str As String
        Dim param As New Habits.DB.DBParameter
        Dim dt As DataTable
        input_check = False

        Me.lbl分類番号.Text = Trim(Me.lbl分類番号.Text)
        str = Me.lbl分類番号.Text
        If (Sys_InputCheck(str, 4, "N+", 1)) Then
            Call Sys_Error("分類番号 が不正です。　", Me.lbl分類番号)
            Exit Function
        End If

        Me.txt分類名.Text = Trim(Me.txt分類名.Text)
        str = Me.txt分類名.Text
        If String.IsNullOrEmpty(str) Then
            Call Sys_Error("分類名 は必須入力です。　", Me.txt分類名)
            Exit Function
        End If
        If (Sys_InputCheck(str, 32, "M", 1)) Then
            Call Sys_Error("分類名 は32文字以内で入力してください。　", Me.txt分類名)
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
        If (Sys_InputCheck(str, 4, "N+", 1)) Then
            Call Sys_Error("表示順 は半角数字4文字以内で入力してください。　", Me.txt表示順)
            Exit Function
        End If

        param.Add("@売上区分", Me.売上区分.SelectedValue)
        param.Add("@分類名", Me.txt分類名.Text)
        dt = logic.checkDuplicate_Class(param)
        Select Case Me.登録.Text
            Case "登録"
                If DataTableSelect(Me.dgv分類一覧.DataSource, "番号 = " & Me.lbl分類番号.Text) Then
                    Call Sys_Error("指定された分類番号は既に登録されています。　", Me.lbl分類番号)
                    Exit Function
                End If
                If dt.Rows.Count <> 0 Then
                    Call Sys_Error("入力した分類名は登録済です。　" & Chr(13) & Chr(13) & "分類名を変更して登録してください。　", Me.txt分類名)
                    Exit Function
                End If
            Case "変更"
                If Me.txt分類名.Text <> Me.dgv分類一覧.SelectedRows(0).Cells("分類名").Value.ToString AndAlso dt.Rows.Count <> 0 Then
                    Call Sys_Error("入力した分類名は登録済です。　" & Chr(13) & Chr(13) & "分類名を変更して登録してください。　", Me.txt分類名)
                    Exit Function
                End If

                '店販対象のチェック
                param.Clear()
                param.Add("@売上区分番号", Me.売上区分.SelectedValue)
                param.Add("@分類番号", Me.lbl分類番号.Text)
                '店販対象フラグが更新されている場合、
                dt = logic.getClassData(param)
                If dt.Rows.Count > 0 AndAlso Boolean.Parse(dt.Rows(0).Item("店販対象フラグ").ToString) <> 店販対象フラグ.Checked Then
                    '紐付く商品が存在していたら、エラー
                    If logic.GetCommodity(param).Rows.Count > 0 Then
                        Call Sys_Error("商品が登録されているため　" & Chr(13) & Chr(13) & "店販対象を変更できません。　", Me.店販対象フラグ)
                        Exit Function
                    End If
                End If
        End Select
        input_check = True
    End Function
#End Region

    ''' <summary>画面再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay()
        '' 新規ボタン非活性
        Me.新規.Enabled = False

        '' 変更ボタン非活性
        Me.登録.Enabled = False

        '売上区分コンボボックス表示
        ReDisplay_売上区分()

        '分類一覧表示
        ReDisplay_dgv分類一覧()
    End Sub

    ''' <summary>
    ''' 売上区分コンボボックス再表示処理
    ''' </summary>
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

    ''' <summary>
    ''' 分類一覧再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_dgv分類一覧()
        Dim dt As DataTable
        Dim param As New Habits.DB.DBParameter

        If Me.売上区分.SelectedIndex >= 0 Then
            '分類一覧取得
            dt = logic.GetCommodityDivision(Me.売上区分.SelectedValue)
            SelectionChangeLocked_dgv分類一覧 = True              'DataSource設定時のSelectionChangedイベントで入力項目再表示を抑止
            Me.dgv分類一覧.DataSource = dt
            SelectionChangeLocked_dgv分類一覧 = False

            Next_分類番号 = GetNextSequence(dt, "番号")

            Me.dgv分類一覧.Columns("番号").Width = 60
            Me.dgv分類一覧.Columns("番号").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
            Me.dgv分類一覧.Columns("分類名").Width = 174
            Me.dgv分類一覧.Columns("分類名").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft
            Me.dgv分類一覧.Columns("表示順").Width = 71
            Me.dgv分類一覧.Columns("表示順").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
            Me.dgv分類一覧.Columns("店販対象").Width = 86
            Me.dgv分類一覧.Columns("店販対象").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomCenter
            Me.dgv分類一覧.Columns("非表示").Width = 71
            Me.dgv分類一覧.Columns("非表示").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomCenter
            Me.dgv分類一覧.Columns("登録日").Visible = False
            Me.dgv分類一覧.Columns("更新日").Visible = False

            Me.dgv分類一覧.ClearSelection()
        Else
            Me.dgv分類一覧.DataSource = Nothing
            Next_分類番号 = Nothing
        End If
        Me.dgv分類一覧.ClearSelection()
        ReDisplay_入力項目()
    End Sub

    ''' <summary>
    ''' 入力項目再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_入力項目()
        '' 分類一覧で選択された商品を反映
        If Me.dgv分類一覧.SelectedRows.Count > 0 Then
            Me.登録.Text = "変更"
            Me.lbl分類番号.Text = Me.dgv分類一覧.SelectedRows(0).Cells("番号").Value
            Me.txt分類名.Text = Me.dgv分類一覧.SelectedRows(0).Cells("分類名").Value
            Me.txt表示順.Text = Me.dgv分類一覧.SelectedRows(0).Cells("表示順").Value

            If Not (String.IsNullOrEmpty(Me.dgv分類一覧.SelectedRows(0).Cells("店販対象").Value)) Then
                Me.店販対象フラグ.Checked = True
            Else
                Me.店販対象フラグ.Checked = False
            End If

            If Not (String.IsNullOrEmpty(Me.dgv分類一覧.SelectedRows(0).Cells("非表示").Value)) Then
                Me.削除フラグ.Checked = True
            Else
                Me.削除フラグ.Checked = False
            End If

            SetEnable_入力項目(True)
            Me.新規.Enabled = True
            Me.登録.Enabled = True
            Me.txt分類名.Focus()
        Else
            Me.登録.Text = "登録"
            Clear_入力項目()
            If (String.IsNullOrEmpty(Me.lbl分類番号.Text)) Then
                SetEnable_入力項目(False)
            Else
                SetEnable_入力項目(True)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 入力項目クリア処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub Clear_入力項目()
        Me.txt分類名.Text = Nothing
        Me.txt表示順.Text = Nothing
        Me.店販対象フラグ.Checked = False
        Me.削除フラグ.Checked = False
        If Me.売上区分.SelectedIndex >= 0 Then
            Me.新規.Enabled = True
        Else
            Me.新規.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' 入力項目Enable設定
    ''' </summary>
    ''' <param name="v_bool">True：登録可、False：登録不可</param>
    ''' <remarks></remarks>
    Protected Friend Sub SetEnable_入力項目(ByVal v_bool As Boolean)
        If v_bool Then
            Me.lbl分類番号.BackColor = Color.White
            Me.txt分類名.Enabled = True
            Me.txt分類名.BackColor = Color.White
            Me.txt表示順.Enabled = True
            Me.txt表示順.BackColor = Color.White
            Me.店販対象フラグ.Enabled = True
            Me.削除フラグ.Enabled = True

            Me.項目クリア.Enabled = True
            Me.登録.Enabled = True
        Else
            Me.lbl分類番号.BackColor = SystemColors.Control
            Me.txt分類名.Enabled = False
            Me.txt分類名.BackColor = SystemColors.Control
            Me.txt表示順.Enabled = False
            Me.txt表示順.BackColor = SystemColors.Control
            Me.店販対象フラグ.Enabled = False
            Me.削除フラグ.Enabled = False

            Me.項目クリア.Enabled = False
            Me.登録.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' dgv分類一覧のインデックス取得
    ''' </summary>
    ''' <param name="v_number">分類番号</param>
    ''' <remarks></remarks>
    Protected Friend Function GetIndex_dgv分類一覧(ByVal v_number As String) As Integer
        Dim numStr As String

        For i As Integer = 0 To Me.dgv分類一覧.Rows.Count - 1
            numStr = Me.dgv分類一覧.Rows(i).Cells(0).Value
            If String.Equals(numStr, v_number) Then
                GetIndex_dgv分類一覧 = i
                Exit Function
            End If
        Next

        ''取得失敗
        GetIndex_dgv分類一覧 = -1
    End Function
#End Region

#Region "キープレスイベント"
    Private Sub txt表示順_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt表示順.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub
#End Region

#Region "フォーカス移動イベント（Enter）"
    Private Sub txt分類名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt分類名.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt表示順.Focus()
        End If
    End Sub

    Private Sub txt表示順_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt表示順.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.店販対象フラグ.Focus()
        End If
    End Sub

    Private Sub 店販対象フラグ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 店販対象フラグ.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.削除フラグ.Focus()
        End If
    End Sub

    Private Sub 削除フラグ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 削除フラグ.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.登録.Focus()
        End If
    End Sub
#End Region

End Class