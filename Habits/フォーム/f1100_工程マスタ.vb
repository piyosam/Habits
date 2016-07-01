''' <summary>f1000_工程マスタ画面処理</summary>
''' <remarks></remarks>
Public Class f1100_工程マスタ

#Region "変数・定数"

    Private logic As New Habits.Logic.f1100_Logic
    Private Next_工程番号 As String = Nothing
    Private SelectionChangeLocked_登録済データ As Boolean = False

#End Region

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f1100_工程マスタ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.登録.Enabled = False
        Me.lbl工程番号.Text = ""
        Me.工程名.Clear()
        Me.ポイント.Clear()
        Me.表示順.Clear()
        Me.登録済データ.DataSource = Nothing
        ''画面再描画処理
        ReDisplay()
        Me.新規.Enabled = True
        Me.工程名.Focus()
        Me.ActiveControl = Me.新規
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f1100_工程マスタ_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
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

        If Sys_InputCheck(Me.lbl工程番号.Text, 4, "N+", 1) Then
            Call Sys_Error("工程番号 が不正です。　", Me.lbl工程番号)
            Exit Sub
        End If

        Me.工程名.Text = Trim(Me.工程名.Text)
        If String.IsNullOrEmpty(Me.工程名.Text) Then
            Call Sys_Error("工程名 は必須入力です。　", Me.工程名)
            Exit Sub
        End If
        If Sys_InputCheck(Me.工程名.Text, 32, "M", 1) Then
            Call Sys_Error("工程名 は32文字以内で入力してください。　", Me.工程名)
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.ポイント.Text) Then
            Call Sys_Error("ポイント は必須入力です。　", Me.ポイント)
            Exit Sub
        End If
        If Sys_Zenkaku(Me.ポイント.Text) Then
            Call Sys_Error("ポイント は半角数字で入力してください。　", Me.ポイント)
            Exit Sub
        End If
        If Sys_InputCheck(Me.ポイント.Text, 4, "N+", 1) Then
            Call Sys_Error("ポイント は半角数字4文字以内で入力してください。　", Me.ポイント)
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.表示順.Text) Then
            Call Sys_Error("表示順 は必須入力です。　", Me.表示順)
            Exit Sub
        End If
        If Sys_Zenkaku(Me.表示順.Text) Then
            Call Sys_Error("表示順 は半角数字で入力してください。　", Me.表示順)
            Exit Sub
        End If
        If (Sys_InputCheck(Me.表示順.Text, 4, "N+", 1)) Then
            Call Sys_Error("表示順 は半角数字4文字以内で入力してください。　", Me.表示順)
            Exit Sub
        End If

        If String.Equals(Me.登録.Text, BTN_REGIST) Then
            If Me.chk工程番号 = False Then
                Call Sys_Error("指定された工程番号は既に登録されています。　", Me.lbl工程番号)
                Me.lbl工程番号.Text = ""
                Me.lbl工程番号.Focus()
                Exit Sub
            End If

            param.Add("@工程番号", Me.lbl工程番号.Text)
            param.Add("@工程名", Me.工程名.Text)
            param.Add("@ポイント", Me.ポイント.Text)
            param.Add("@表示順", Me.表示順.Text)
            param.Add("@削除フラグ", IIf(Me.削除フラグ.Checked, "1", "0"))
            param.Add("@登録日", Now())
            param.Add("@更新日", Now())

            logic.工程登録(param)
        Else
            ''更新
            param.Add("@工程番号", Me.lbl工程番号.Text)
            param.Add("@工程名", Me.工程名.Text)
            param.Add("@ポイント", Me.ポイント.Text)
            param.Add("@表示順", Me.表示順.Text)
            param.Add("@削除フラグ", IIf(Me.削除フラグ.Checked, "1", "0"))
            param.Add("@更新日", Now())

            logic.工程変更(param)
        End If

        ReDisplay_登録済データ()
        MsgBox(tmp登録 & "しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
        Me.新規.Enabled = True
        Me.新規.Focus()
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

#Region "項目クリアボタン押下"
    ''' <summary>
    ''' 項目クリアボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 項目クリア_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 項目クリア.Click
        ReDisplay_登録済データ()
        Me.新規.Enabled = True
    End Sub
#End Region

#Region "新規ボタン押下"
    ''' <summary>
    ''' 新規ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 新規_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新規.Click
        Dim dt As New DataTable
        Dim max_processNo As Integer
        dt = logic.getMaxProcessNumber()
        If Not dt.Rows(0)("最大番号").Equals(System.DBNull.Value) Then
            max_processNo = Integer.Parse(dt.Rows(0)("最大番号").ToString)
        Else
            max_processNo = 0
        End If

        If (max_processNo >= Max_MasterNo) Then
            Sys_Error("登録最大数に達したため登録できません。　", Me.閉じる)
            Exit Sub
        End If

        Me.登録済データ.ClearSelection()

        Clear_入力項目()
        SetEnable_入力項目(True)

        Me.工程名.Focus()
        Me.登録.Text = "登録"
        Me.lbl工程番号.Text = Next_工程番号
    End Sub
#End Region

    Private Sub ポイント_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ポイント.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub 表示順_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles 表示順.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

#End Region

#Region "メソッド"
    Private Function chk工程番号() As Boolean
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        param.Add("@工程番号", Me.lbl工程番号.Text)
        dt = logic.番号確認(param)

        If dt.Rows.Count <> 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Protected Friend Sub Clear_入力項目()
        Me.lbl工程番号.Text = ""
        Me.工程名.Clear()
        Me.ポイント.Clear()
        Me.表示順.Clear()
        Me.削除フラグ.Checked = False
    End Sub

    Protected Friend Sub SetEnable_入力項目(ByVal v_bool As Boolean)
        If v_bool Then
            Me.lbl工程番号.BackColor = Color.White
            Me.工程名.Enabled = True
            Me.工程名.BackColor = Color.White
            Me.ポイント.Enabled = True
            Me.ポイント.BackColor = Color.White
            Me.表示順.Enabled = True
            Me.表示順.BackColor = Color.White
            Me.削除フラグ.Enabled = True
            Me.削除フラグ.BackColor = Color.White

            Me.項目クリア.Enabled = True
            Me.新規.Enabled = True
            Me.登録.Enabled = True
        Else
            Me.lbl工程番号.BackColor = SystemColors.Control
            Me.工程名.Enabled = False
            Me.工程名.BackColor = SystemColors.Control
            Me.ポイント.Enabled = False
            Me.ポイント.BackColor = SystemColors.Control
            Me.表示順.Enabled = False
            Me.表示順.BackColor = SystemColors.Control
            Me.削除フラグ.Enabled = False
            Me.削除フラグ.BackColor = SystemColors.Control

            Me.項目クリア.Enabled = False
            Me.新規.Enabled = True
            Me.登録.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' 入力項目再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_入力項目()

        '' 工程一覧で選択された商品を反映
        If 登録済データ.SelectedRows.Count > 0 Then

            Me.lbl工程番号.Text = Me.登録済データ.SelectedRows(0).Cells("工程番号").Value.ToString
            Me.工程名.Text = Me.登録済データ.SelectedRows(0).Cells("工程名").Value.ToString
            Me.ポイント.Text = Me.登録済データ.SelectedRows(0).Cells("ポイント").Value.ToString
            Me.表示順.Text = Me.登録済データ.SelectedRows(0).Cells("表示順").Value.ToString

            If Me.登録済データ.SelectedRows(0).Cells("表示").Value.Equals("  ") Then
                Me.削除フラグ.Checked = False
            Else
                Me.削除フラグ.Checked = True
            End If

            SetEnable_入力項目(True)

            Me.新規.Enabled = True
            Me.登録.Enabled = True
            Me.登録.Text = "変更"

            Me.工程名.Focus()
        Else
            Clear_入力項目()

            SetEnable_入力項目(False)

            If 新規.Enabled = True Then
                Me.登録.Enabled = False
                Me.登録.Text = "変更"
            Else
                If Me.登録済データ.SelectedRows.Count > 0 Then
                    Me.登録.Enabled = True
                    Me.登録.Text = "登録"
                Else
                    Me.登録.Enabled = False
                    Me.登録.Text = "変更"
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' 画面再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay()

        '' 新規ボタン非活性
        Me.新規.Enabled = False

        '' 変更ボタン非活性
        Me.登録.Enabled = False

        '工程一覧表示
        ReDisplay_登録済データ()

    End Sub

    ''' <summary>
    ''' 工程一覧再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_登録済データ()
        Dim dt As DataTable
        Dim param As New Habits.DB.DBParameter

        '工程一覧取得
        dt = logic.内容更新()
        Me.登録済データ.RowTemplate.Height = 16
        SelectionChangeLocked_登録済データ = True              'DataSource設定時のSelectionChangedイベントで入力項目再表示を抑止
        Me.登録済データ.DataSource = dt
        SelectionChangeLocked_登録済データ = False

        Next_工程番号 = GetNextSequence(dt, "工程番号").ToString
        Me.登録済データ.ColumnHeadersDefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft

        Me.登録済データ.Columns(0).Width = 80 '工程番号
        Me.登録済データ.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.登録済データ.Columns(1).Width = 123 '工程名
        Me.登録済データ.Columns(1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft
        Me.登録済データ.Columns(2).Width = 73 'ポイント
        Me.登録済データ.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.登録済データ.Columns(3).Width = 66 '表示順
        Me.登録済データ.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.登録済データ.Columns(4).Width = 55 '表示
        Me.登録済データ.Columns(4).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomCenter
        Me.登録済データ.ClearSelection()

        Me.登録済データ.ClearSelection()
        ReDisplay_入力項目()
    End Sub

    Private Sub 登録済データ_SelectionChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles 登録済データ.SelectionChanged
        If SelectionChangeLocked_登録済データ = False Then
            ReDisplay_入力項目()
        End If
    End Sub

#End Region

    Private Sub 工程名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 工程名.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.ポイント.Focus()
        End If
    End Sub

    Private Sub ポイント_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ポイント.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.表示順.Focus()
        End If
    End Sub

    Private Sub 表示順_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 表示順.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.削除フラグ.Focus()
        End If
    End Sub

    Private Sub 削除フラグ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 削除フラグ.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.登録.Focus()
        End If
    End Sub

End Class

