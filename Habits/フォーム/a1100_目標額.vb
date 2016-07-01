'システム名 ： HABITS
'機能名　　 ： a1100_目標額
'概要　　　 ： 売上区分別月間目標額設定機能
'履歴　　　 ： 2010/05/12　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a1100_目標額

    Private logic As Habits.Logic.a1100_Logic
    Private m_targetYearMonth As DateTime
    Private m_lastYearTargetFigure As Integer = 0
    Private m_coefficient As Double = 1
    Dim money As String
    Dim w_money As Double

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1100_目標額_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logic = New Habits.Logic.a1100_Logic
        If logic.getSalesDiv.Rows.Count > 0 Then
            Call formatItem()
            Me.ActiveControl = Me.txt対象年月
            Me.Activate()
        Else
            rtn = MsgBox("売上区分が設定されていません。　　　　" & Chr(13), Clng_Okinb1, TTL)
            Me.Close()
        End If
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1100_目標額_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "売上区分変更処理"
    ''' <summary>
    ''' 売上区分のドロップダウンリストが閉じられた時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmb売上区分_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb売上区分.SelectionChangeCommitted
        If cmb売上区分.SelectedIndex <> -1 AndAlso Not String.IsNullOrEmpty(txt対象年月.Text.ToString) Then
            ' 対象年月と売上区分に入力がある場合
            Call E_目標額取得処理()
            Call 前年度目標額取得()
        End If
    End Sub
#End Region

#Region "目標額一覧選択処理"
    ''' <summary>
    ''' 目標額一覧を選択した時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv目標額一覧_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv目標額一覧.SelectionChanged
        If (dgv目標額一覧.SelectedRows.Count > 0) Then
            編集項目設定()
        End If
    End Sub
#End Region

#Region "バリデートチェック"
    ''' <summary>
    ''' 対象年月が検証された後の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt対象年月_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt対象年月.Validated
        Dim str_date As String

        If String.IsNullOrEmpty(Me.txt対象年月.Text) Then Exit Sub

        If (input_check_ym() = False) Then
            Call formatItem()
            Exit Sub
        End If

        If Not Mid(Me.txt対象年月.Text, 5, 1) = "/" Then
            Call Sys_Error("対象年月 はYYYY/MM形式で入力してください。　", Me.txt対象年月)
            Call formatItem()
            Exit Sub
        End If
        str_date = Mid(Me.txt対象年月.Text, 1, 2)
        If IsNumeric(str_date) Then
            If Integer.Parse(str_date) <= 18 Then
                Call Sys_Error("対象年月 はYYYY/MM形式で入力してください。　", Me.txt対象年月)
                Call formatItem()
                Exit Sub
            End If
        Else
            Call Sys_Error("対象年月 はYYYY/MM形式で入力してください。　", Me.txt対象年月)
            Call formatItem()
            Exit Sub
        End If

        If Not m_targetYearMonth = Date.Parse(Me.txt対象年月.Text) Then
            '' 対象年月が変更されたときだけ処理する
            Call E_目標額取得処理()
            Me.dgv目標額一覧.ClearSelection()
            Call 前年度目標額取得()
        End If
        m_targetYearMonth = Date.Parse(Me.txt対象年月.Text)

        RemoveHandler txt対象年月.Validated, AddressOf txt対象年月_Validated
        Me.cmb売上区分.Focus()
        AddHandler txt対象年月.Validated, AddressOf txt対象年月_Validated
    End Sub

    ''' <summary>
    ''' 前年度比が検証された後の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txt前年度比_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt前年度比.Validated
        Dim coefficient As Double = 1  ' 係数

        If Sys_InputCheck(Me.txt前年度比.Text, 3, "N+", 1) Then
            Call Sys_Error("前年度比 0～999の半角数字で入力してください。　", Me.txt前年度比)
            Exit Sub
        End If

        If Me.txt前年度比.Text.Length <> 0 Then
            '' 入力された前年度比を係数に変換
            coefficient = CInt(Me.txt前年度比.Text) * 0.01
        End If

        '' 基準係数と入力された前年度の係数が違う場合
        If m_coefficient <> coefficient Then
            ''目標額を設定（前年度比が変更された時）
            Me.txt目標額.Text = (m_lastYearTargetFigure * coefficient).ToString
        End If
        '' 基準係数に入力された前年度の係数を設定
        m_coefficient = coefficient
    End Sub

    Private Sub txt目標額_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt目標額.Validated
        If Me.txt目標額.TextLength <> 0 Then
            money = Replace(Me.txt目標額.Text, ",", "")

            If (input_check_target() = False) Then
                Exit Sub
            End If

            If IsNumeric(money) Then
                w_money = Double.Parse(money)
                Me.txt目標額.Text = Format(w_money, "#,##0")
                RemoveHandler txt目標額.Validated, AddressOf txt目標額_Validated
                Me.txt営業日数.Focus()
                AddHandler txt目標額.Validated, AddressOf txt目標額_Validated
            Else
                Call Sys_Error("目標額 は0～999,999,999の半角数字で入力してください。　", Me.txt目標額)
                Me.txt目標額.Text = Nothing
            End If
        End If
    End Sub
#End Region

#Region "目標額一覧ソート"
    ''' <summary>
    ''' 目標額一覧のソート
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv目標額一覧_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv目標額一覧.Sorted
        編集項目設定()
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "登録ボタン押下"
    ''' <summary>
    ''' 登録ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn登録.Click
        If Not (input_check()) Then Exit Sub

        Dim param As New Habits.DB.DBParameter
        Dim EMO As New DataTable 'E_目標額
        Dim dt As New DataTable
        Dim 対象年月 As String

        対象年月 = Me.txt対象年月.Text & "/01"
        Try
            param.Add("@対象年月", Date.Parse(対象年月))
            param.Add("@売上区分番号", Me.cmb売上区分.SelectedValue)

            '' 入力・選択されている対象年月、売上区分番号でE_目標額テーブルを取得

            EMO = logic.E_目標額取得(param)
        Catch ex As Exception
            Exit Sub
        End Try

        '' 入力された目標額、営業日数をパラメータに設定
        param.Add("@目標額", money)
        param.Add("@営業日数", Me.txt営業日数.Text)
        param.Add("@更新日", Now)
        If EMO.Rows.Count = 0 Then
            logic.E_目標額追加(param)
            btn登録.Text = BTN_REGIST
        Else
            logic.E_目標額更新(param)
            btn登録.Text = "更新"
        End If
        rtn = MsgBox(Me.btn登録.Text.ToString & "しました。　　　　" & Chr(13), Clng_Okinb1, TTL)

        ' 一覧更新
        Call 目標一覧取得処理()
        Call formatItem()
        'Call 前年度目標額取得()
    End Sub
#End Region

#Region "項目クリアボタン押下"
    ''' <summary>
    ''' 項目クリアボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn項目クリア_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn項目クリア.Click
        formatItem()
        Me.dgv目標額一覧.ClearSelection()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn閉じる.Click
        Me.Close()
    End Sub
#End Region

#End Region

#Region "キープレスイベント"
    Private Sub 前年度比_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt前年度比.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub 目標額_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt目標額.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub 営業日数_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt営業日数.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub
#End Region

#Region "フォーカスイベント"
    Private Sub 目標額_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt目標額.Enter
        txt目標額.Text = Replace(Me.txt目標額.Text, ",", "")
    End Sub

    Private Sub 営業日数_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt営業日数.Enter
        txt営業日数.Text = Replace(Me.txt営業日数.Text, ",", "")
    End Sub
#End Region

#Region "キーダウンイベント"
    Private Sub 対象年月_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt対象年月.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.cmb売上区分.Focus()
        End If
    End Sub

    Private Sub 売上区分_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmb売上区分.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            If Me.txt前年度比.Enabled Then
                Me.txt前年度比.Focus()
            Else
                Me.txt目標額.Focus()
            End If
        End If
    End Sub

    Private Sub 前年度比_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt前年度比.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt目標額.Focus()
        End If
    End Sub

    Private Sub 目標額_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt目標額.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt営業日数.Focus()
        End If
    End Sub

    Private Sub 営業日数_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt営業日数.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.btn登録.Focus()
        End If
    End Sub
#End Region

#Region "メソッド"

#Region "編集項目の設定"
    ''' <summary>
    ''' 編集項目の設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 編集項目設定()
        Dim index As Integer = 0    '' 売上区分リストのインデックス

        If Me.dgv目標額一覧.SelectedRows.Count > 0 Then
            Me.txt対象年月.Text = Format(Me.dgv目標額一覧.SelectedRows(0).Cells(0).Value, "yyyy/MM")

            '' 売上区分に設定されているデータを取得してループ
            For Each data As DataRowView In Me.cmb売上区分.Items
                '' 目標額一覧の売上区分番号と、売上区分の売上区分番号が同じだった場合
                If data.Item(0).ToString = Me.dgv目標額一覧.SelectedRows(0).Cells(1).Value.ToString Then
                    '' インデックス番号で売上区分を選択状態にする。
                    Me.cmb売上区分.SelectedIndex = index
                    Exit For
                End If
                '' ループ毎にインデックス＋１
                index += 1
            Next

            '' 目標額を設定する
            Call E_目標額取得処理()
            '' 前年度目標額を設定する
            Call 前年度目標額取得()

            txt対象年月.Enabled = False
            Me.txt対象年月.BackColor = SystemColors.Control
            cmb売上区分.Enabled = False
            lbl前年度目標額.Enabled = True
            txt前年度比.Enabled = True
            txt目標額.Enabled = True
            txt営業日数.Enabled = True
            btn登録.Text = "変更"
        End If
    End Sub
#End Region

#Region "E_目標額テーブル取得"
    ''' <summary>
    ''' E_目標額テーブル取得
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub E_目標額取得処理()
        Dim param As New Habits.DB.DBParameter
        Dim EMO As New DataTable 'E_目標額
        Dim 対象年月日 As String
        Try
            対象年月日 = Me.txt対象年月.Text & "/01"
            param.Add("@対象年月", Date.Parse(対象年月日))
            param.Add("@売上区分番号", Me.cmb売上区分.SelectedValue)

            EMO = logic.E_目標額取得(param)
        Catch ex As Exception

            Exit Sub
        End Try

        If EMO.Rows.Count <> 0 Then
            money = EMO.Rows(0)("目標額").ToString
            w_money = Double.Parse(money)
            Me.txt目標額.Text = Format(w_money, "#,##0")
            Me.txt営業日数.Text = EMO.Rows(0)("営業日数").ToString
            Me.txt月日数.Text = DatePart("d", Sys_EndDate(対象年月日)).ToString

        Else
            Me.txt目標額.Text = "0"
            Me.txt営業日数.Text = DatePart("d", Sys_EndDate(対象年月日)).ToString
            Me.txt月日数.Text = DatePart("d", Sys_EndDate(対象年月日)).ToString
        End If
    End Sub
#End Region

#Region "目標額一覧取得"
    ''' <summary>
    ''' 過去36ヶ月目標額一覧の取得
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 目標一覧取得処理()
        Dim param As New Habits.DB.DBParameter
        Dim dt As New DataTable
        Dim a As Date

        a = Now
        a = DateAdd("m", -36, a)

        param.Add("@過去年月", a)
        dt = logic.目標一覧取得(param)
        If dt.Rows.Count <> 0 Then
            Me.dgv目標額一覧.DataSource = dt
            Me.dgv目標額一覧.Columns(0).Width = 90
            Me.dgv目標額一覧.Columns(0).DefaultCellStyle.Format = "yyyy/MM"
            Me.dgv目標額一覧.Columns(1).Visible = False
            Me.dgv目標額一覧.Columns(2).Width = 85
            Me.dgv目標額一覧.Columns(3).Width = 90
            Me.dgv目標額一覧.Columns(3).DefaultCellStyle.Format = "#,##0"
            Me.dgv目標額一覧.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
            Me.dgv目標額一覧.Columns(4).Width = 69
            Me.dgv目標額一覧.Columns(4).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
            Me.dgv目標額一覧.ClearSelection()
        End If
    End Sub
#End Region

#Region "入力チェック"
    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        input_check = False
        ' 対象年月チェック
        If (input_check_ym() = False) Then
            Exit Function
        End If
        ' 売上区分チェック
        If (input_check_salesDiv() = False) Then
            Exit Function
        End If
        ' 目標額チェック
        If (input_check_target() = False) Then
            Exit Function
        End If
        ' 営業日数チェック
        If (input_check_workday() = False) Then
            Exit Function
        End If
        input_check = True
    End Function
#End Region

#Region "対象年月チェック"
    ''' <summary>対象年月入力チェック</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function input_check_ym() As Boolean
        If String.IsNullOrEmpty(Me.txt対象年月.Text) Then
            Call Sys_Error("対象年月 は必須入力です。　", Me.txt対象年月)
            Return False
        End If
        If Sys_Zenkaku(Me.txt対象年月.Text) Then
            Call Sys_Error("対象年月 は半角で入力してください。　", Me.txt対象年月)
            Exit Function
        End If
        If Sys_InputCheck(Me.txt対象年月.Text, 7, "D", 1) Then
            Call Sys_Error("対象年月 はYYYY/MM形式で入力してください。　", Me.txt対象年月)
            Return False
        End If
        If System.Text.Encoding.GetEncoding("shift_jis").GetByteCount(Me.txt対象年月.Text) > 7 Then
            Call Sys_Error("前年度比 が不正です。　", Me.txt前年度比)
            Return False
        End If
        If Len(Me.txt対象年月.Text) > 7 Then
            Call Sys_Error("対象年月 はYYYY/MM形式で入力してください。　", Me.txt対象年月)
            Return False
        End If
        txt対象年月.Text = Format(Date.Parse(txt対象年月.Text & "/01"), "yyyy/MM")
        Return True
    End Function
#End Region

#Region "売上区分チェック"
    ''' <summary>売上区分入力チェック</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function input_check_salesDiv() As Boolean
        Dim dt As DataTable
        Dim param As New Habits.DB.DBParameter
        If cmb売上区分.SelectedIndex < 0 Then
            Call Sys_Error("売上区分 を選択してください。　", Me.cmb売上区分)
            Return False
        End If
        If btn登録.Text = BTN_REGIST Then
            param.Add("@売上区分番号", Me.cmb売上区分.SelectedValue)
            dt = logic.getSalesDiv_One(param)
            If dt.Rows.Count <> 1 Then
                Call Sys_Error("この売上区分は無効のため新規登録はできません。　", Me.cmb売上区分)
                Return False
            End If
        End If

        Return True
    End Function
#End Region

#Region "目標額チェック"
    ''' <summary>目標額入力チェック</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function input_check_target() As Boolean
        money = Replace(Me.txt目標額.Text, ",", "")
        If String.IsNullOrEmpty(Me.txt目標額.Text) Then
            Call Sys_Error("目標額 は必須入力です。　", Me.txt目標額)
            Return False
        End If
        If Sys_InputCheck(money, 9, "N+", 1) Then
            Call Sys_Error("目標額 は0～999,999,999の半角数字で入力してください。　", Me.txt目標額)
            Return False
        End If
        If Len(money) > 9 Then
            Call Sys_Error("目標額 は0～999,999,999の半角数字で入力してください。　", Me.txt目標額)
            Return False
        End If
        Return True
    End Function
#End Region

#Region "営業日数チェック"
    ''' <summary>営業日数入力チェック</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function input_check_workday() As Boolean

        If String.IsNullOrEmpty(Me.txt営業日数.Text) Then
            Call Sys_Error("営業日数 は必須入力です。　", Me.txt営業日数)
            Return False
        End If
        If Sys_InputCheck(Me.txt営業日数.Text, 2, "N+", 1) Then
            Call Sys_Error("営業日数 は半角数字で入力してください。　", Me.txt営業日数)
            Return False
        End If
        If (Me.txt営業日数.Text > Me.txt月日数.Text) Then
            Call Sys_Error("営業日数 は0～" & Me.txt月日数.Text & "で入力してください。　", Me.txt営業日数)
            Return False
        End If

        Return True
    End Function
#End Region

#Region "初期化"
    ''' <summary>
    ''' 画面の項目を初期化する。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub formatItem()
        Dim param As New Habits.DB.DBParameter
        Dim a As Date

        Me.dgv目標額一覧.DataSource = Nothing
        Call 目標一覧取得処理()

        m_targetYearMonth = Nothing
        Me.txt対象年月.Text = Nothing
        Me.txt対象年月.Enabled = True
        Me.txt対象年月.BackColor = Color.White

        a = Now
        a = DateAdd("m", -36, a)

        param.Add("@過去年月", a)
        Me.cmb売上区分.DataSource = logic.売上区分Plus_E_目標額(param)
        Me.cmb売上区分.DisplayMember = "売上区分"
        Me.cmb売上区分.ValueMember = "売上区分番号"
        Me.cmb売上区分.SelectedIndex = -1
        Me.cmb売上区分.Enabled = True

        Me.txt目標額.Text = ""
        Me.txt目標額.Enabled = True
        Me.txt目標額.BackColor = Color.White

        Me.txt営業日数.Text = ""
        Me.txt営業日数.Enabled = True
        Me.txt営業日数.BackColor = Color.White

        Me.lbl前年度目標額.Text = ""
        Me.lbl前年度目標額.BackColor = Color.White

        Me.txt前年度比.Text = ""
        Me.txt前年度比.Enabled = True
        Me.txt前年度比.BackColor = Color.White

        Me.btn登録.Text = BTN_REGIST
        Me.btn登録.Enabled = True
        Me.txt対象年月.Focus()
    End Sub
#End Region

#Region "前年度目標額設定"
    ''' <summary>
    ''' 前年度の目標額を取得・設定する。
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 前年度目標額取得()
        Dim lastYear As String
        Dim month As String
        Dim param As New Habits.DB.DBParameter
        Dim dt As New DataTable
        Dim targetFigure As Integer = 0
        Dim lastw_money As Double

        '' 基準係数に1（100%）を設定
        m_coefficient = 1

        '' 現在の目標額を取得
        If Me.txt目標額.Text.Length <> 0 Then
            targetFigure = CInt(Me.txt目標額.Text)
        End If

        If txt対象年月.Text.Length = 7 _
          AndAlso Me.cmb売上区分.SelectedValue IsNot Nothing _
          AndAlso Integer.Parse(Me.cmb売上区分.SelectedValue.ToString) > -1 Then
            lastYear = (CInt(Mid(txt対象年月.Text, 1, 4)) - 1).ToString
            month = Mid(txt対象年月.Text, 6, 2)

            param.Add("@対象年月", Date.Parse(lastYear & "/" & month & "/01"))
            param.Add("@売上区分番号", Me.cmb売上区分.SelectedValue)

            dt = logic.E_目標額取得(param)

            If dt.Rows.Count > 0 Then
                '' 前年度目標額の設定
                m_lastYearTargetFigure = CInt(dt.Rows(0)("目標額").ToString())
                lastw_money = m_lastYearTargetFigure
                Me.lbl前年度目標額.Text = Format(lastw_money, "#,##0")

                ' 係数を計算
                If (m_lastYearTargetFigure <> 0) Then
                    m_coefficient = Double.Parse((targetFigure / m_lastYearTargetFigure).ToString("F"))
                Else
                    m_coefficient = 0
                End If

                '' 前年度比の設定
                ' パーセントにするため100倍する
                Me.txt前年度比.Text = (m_coefficient * 100).ToString
            Else
                m_lastYearTargetFigure = 0
                Me.lbl前年度目標額.Text = ""
                Me.txt前年度比.Text = "0"
            End If
        End If
    End Sub
#End Region

#End Region

End Class
