''' <summary>f0500_売上区分画面処理</summary>
''' <remarks></remarks>
Public Class f0500_売上区分
    Private logic As Habits.Logic.f0500_Logic
    Private Next_売上区分番号 As String = Nothing

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0500_売上区分_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' ロジッククラス生成
        logic = New Habits.Logic.f0500_Logic

        ''画面再描画処理
        ReDisplay()

        ''背後の表示中画面への遷移防止
        If f0500_分類.Visible Then
            Me.分類.Enabled = False
        Else
            Me.分類.Enabled = True
        End If
        Me.新規.Focus()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f0500_売上区分_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

    Private Sub dgv売上区分一覧_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv売上区分一覧.SelectionChanged
        ReDisplay_入力項目()
    End Sub

#End Region

#Region "ボタン押下イベント"

#Region "新規ボタン押下"
    ''' <summary>
    ''' 新規ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 新規_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新規.Click
        If Integer.Parse(Next_売上区分番号) <= Max_MasterNo Then
            Me.dgv売上区分一覧.ClearSelection()
            Clear_入力項目()
            SetEnable_入力項目(True)

            Me.txt売上区分.Focus()
            Me.登録.Enabled = True
            Me.登録.Text = BTN_REGIST

            Me.売上区分番号.Text = Next_売上区分番号
        Else
            Sys_Error("登録最大数に達したため登録できません。　", Me.閉じる)
        End If
        Me.txt売上区分.Focus()
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

        param.Add("@売上区分番号", Me.売上区分番号.Text)
        param.Add("@売上区分", Me.txt売上区分.Text)
        param.Add("@表示順", Me.txt表示順.Text)
        param.Add("@削除フラグ", IIf(Me.削除フラグ.Checked, "1", "0"))

        If String.Equals(Me.登録.Text, "登録") Then
            ''登録
            param.Add("@登録日", Now())
            param.Add("@更新日", Now())

            logic.SalesDivisionInsert(param)
        Else
            ''更新
            param.Add("@更新日", Now())

            logic.SalesDivisionUpdate(param)
        End If

        ReDisplay_dgv売上区分一覧()
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
        Me.dgv売上区分一覧.ClearSelection()
        Clear_入力項目()
        売上区分番号.Text = Nothing
        Me.登録.Text = "変更"
        SetEnable_入力項目(False)
    End Sub
#End Region

#Region "分類ボタン押下"
    ''' <summary>
    ''' 分類ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 分類_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 分類.Click
        If Me.dgv売上区分一覧.SelectedRows.Count > 0 Then
            f0500_分類.ShowDialogWithParam(Me.dgv売上区分一覧.SelectedRows(0).Cells(0).Value)
        Else
            f0500_分類.ShowDialog()
        End If
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

#End Region

    Private Sub txt売上区分_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt売上区分.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt表示順.Focus()
        End If
    End Sub

    Private Sub txt表示順_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt表示順.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txt表示順_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt表示順.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.削除フラグ.Focus()
        End If
    End Sub

    Private Sub 削除フラグ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 削除フラグ.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.登録.Focus()
        End If
    End Sub

#Region "メソッド"

    ''' <summary>入力チェック</summary>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        Dim str As String
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        input_check = False

        Me.売上区分番号.Text = Trim(Me.売上区分番号.Text)
        str = Me.売上区分番号.Text
        If (Sys_InputCheck(str, 4, "N+", 1)) Then
            Call Sys_Error("売上区分番号 が不正です。　", Me.売上区分番号)
            Exit Function
        End If

        Me.txt売上区分.Text = Trim(Me.txt売上区分.Text)
        str = Me.txt売上区分.Text
        If String.IsNullOrEmpty(str) Then
            Call Sys_Error("売上区分 は必須入力です。　", Me.txt売上区分)
            Exit Function
        End If
        If (Sys_InputCheck(str, 20, "M", 1)) Then
            Call Sys_Error("売上区分 は20文字以内で入力してください。　", Me.txt売上区分)
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

        param.Add("@売上区分", Me.txt売上区分.Text)
        dt = logic.checkDuplicate_SalesDiv(param)

        Select Case Me.登録.Text
            Case "登録"
                If DataTableSelect(Me.dgv売上区分一覧.DataSource, "番号 = " & Me.売上区分番号.Text) Then
                    Call Sys_Error("指定された売上区分番号は既に登録されています。　", Me.売上区分番号)
                    Exit Function
                End If

                If dt.Rows.Count <> 0 Then
                    Call Sys_Error("入力した売上区分は登録済です。　" & Chr(13) & Chr(13) & "売上区分を変更して登録してください。　", Me.txt売上区分)
                    Exit Function
                End If

            Case "変更"
                If Me.txt売上区分.Text = Me.dgv売上区分一覧.SelectedRows(0).Cells("売上区分").Value.ToString Then
                    Exit Select
                ElseIf dt.Rows.Count <> 0 Then
                    Call Sys_Error("入力した売上区分は登録済です。　" & Chr(13) & Chr(13) & "売上区分を変更して登録してください。　", Me.txt売上区分)
                    Exit Function
                End If
        End Select
        input_check = True

    End Function

    ''' <summary>画面再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay()
        '' 新規ボタン非活性
        Me.新規.Enabled = False

        '' 変更ボタン非活性
        Me.登録.Enabled = False

        '売上区分一覧表示
        ReDisplay_dgv売上区分一覧()
    End Sub

    ''' <summary>売上区分一覧再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_dgv売上区分一覧()
        Dim dt As DataTable
        Dim param As New Habits.DB.DBParameter

        '売上区分取得
        dt = logic.GetSalesDivision()

        Me.dgv売上区分一覧.DataSource = dt
        Next_売上区分番号 = GetNextSequence(dt, "番号")
        Me.dgv売上区分一覧.Columns("番号").Width = 55
        Me.dgv売上区分一覧.Columns("番号").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv売上区分一覧.Columns("売上区分").Width = 153
        Me.dgv売上区分一覧.Columns("売上区分").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.dgv売上区分一覧.Columns("表示順").Width = 66
        Me.dgv売上区分一覧.Columns("表示順").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv売上区分一覧.Columns("表示").Width = 55
        Me.dgv売上区分一覧.Columns("表示").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomCenter
        Me.dgv売上区分一覧.Columns("登録日").Visible = False
        Me.dgv売上区分一覧.Columns("更新日").Visible = False

        Me.dgv売上区分一覧.ClearSelection()
        Me.売上区分番号.Text = Nothing
        Clear_入力項目()
        ReDisplay_入力項目()
    End Sub

    ''' <summary>入力項目再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_入力項目()
        '' 売上区分一覧の選択行を入力項目に反映
        If Me.dgv売上区分一覧.SelectedRows.Count > 0 Then
            Me.登録.Text = "変更"
            Me.売上区分番号.Text = Me.dgv売上区分一覧.SelectedRows(0).Cells("番号").Value
            Me.txt売上区分.Text = Me.dgv売上区分一覧.SelectedRows(0).Cells("売上区分").Value
            Me.txt表示順.Text = Me.dgv売上区分一覧.SelectedRows(0).Cells("表示順").Value

            If Not (String.IsNullOrEmpty(Me.dgv売上区分一覧.SelectedRows(0).Cells("表示").Value)) Then
                Me.削除フラグ.Checked = True
            Else
                Me.削除フラグ.Checked = False
            End If

            SetEnable_入力項目(True)

            Me.新規.Enabled = True
            Me.登録.Enabled = True

            Me.txt売上区分.Focus()
        Else
            Me.登録.Text = "登録"
            Clear_入力項目()
            If (String.IsNullOrEmpty(Me.売上区分番号.Text)) Then
                SetEnable_入力項目(False)
            Else
                SetEnable_入力項目(True)
            End If
        End If
    End Sub

    ''' <summary>入力項目クリア処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub Clear_入力項目()
        Me.txt売上区分.Text = Nothing
        Me.txt表示順.Text = Nothing
        Me.削除フラグ.Checked = False
        Me.新規.Enabled = True
    End Sub

    ''' <summary>入力項目Enable設定</summary>
    ''' <param name="v_bool">True：登録可、False：登録不可</param>
    ''' <remarks></remarks>
    Protected Friend Sub SetEnable_入力項目(ByVal v_bool As Boolean)
        If v_bool Then
            Me.売上区分番号.BackColor = Color.White
            Me.txt売上区分.Enabled = True
            Me.txt売上区分.BackColor = Color.White
            Me.txt表示順.Enabled = True
            Me.txt表示順.BackColor = Color.White
            Me.削除フラグ.Enabled = True

            Me.項目クリア.Enabled = True
            Me.登録.Enabled = True
        Else
            Me.売上区分番号.BackColor = SystemColors.Control
            Me.txt売上区分.Enabled = False
            Me.txt売上区分.BackColor = SystemColors.Control
            Me.txt表示順.Enabled = False
            Me.txt表示順.BackColor = SystemColors.Control
            Me.削除フラグ.Enabled = False

            Me.項目クリア.Enabled = False
            Me.登録.Enabled = False
        End If
    End Sub

    ''' <summary>dgv売上区分一覧のインデックス取得
    ''' </summary>
    ''' <param name="v_number">売上区分番号</param>
    ''' <remarks></remarks>
    Protected Friend Function GetIndex_dgv売上区分一覧(ByVal v_number As String) As Integer
        Dim numStr As String

        For i As Integer = 0 To Me.dgv売上区分一覧.Rows.Count - 1
            numStr = Me.dgv売上区分一覧.Rows(i).Cells(0).Value
            If String.Equals(numStr, v_number) Then
                GetIndex_dgv売上区分一覧 = i
                Exit Function
            End If
        Next

        ''取得失敗
        GetIndex_dgv売上区分一覧 = -1
    End Function
#End Region
End Class