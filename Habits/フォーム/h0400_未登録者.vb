''' <summary>h0200_確認画面処理</summary>
''' <remarks></remarks>
Public Class h0400_未登録者

    Private logic As New Habits.Logic.h0400_Logic
    Dim dt As New DataTable

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>
    ''' ロード時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub h0400_未登録者_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.chk区分.Checked = True
        Me.閉じる.Focus()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub h0400_未登録者_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
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
        Me.変更.Enabled = False
        Me.仮登録.Enabled = False
        Me.未登録者一覧.DataSource = Nothing
        Me.Close()
    End Sub
#End Region

#Region "変更ボタン押下"
    ''' <summary>
    ''' 変更ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 変更_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 変更.Click
        Dim param As New Habits.DB.DBParameter
        param.Add("@顧客番号", Me.未登録者一覧.CurrentRow.Cells(0).Value)
        dt = logic.CustomerInfo(param)
        param.Clear()

        z_0500_顧客変更.来店日.Text = ""    ' men_来店者登録以外は設定不要
        z_0500_顧客変更.来店者番号.Text = ""

        '顧客番号に該当する顧客がいた場合に処理
        If dt.Rows.Count > 0 Then
            z_0500_顧客変更.lbl顧客番号.Text = dt.Rows(0)("顧客番号").ToString
            Me.変更.Enabled = True
        Else
            Me.変更.Enabled = False
        End If

        z_0500_顧客変更.変更.Enabled = True
        z_0500_顧客変更.削除.Enabled = True

        z_0500_顧客変更.z_0500_loaded = True
        z_0500_顧客変更.ShowDialog()
        Me.変更.Enabled = False
        Me.仮登録.Enabled = False
        一覧更新()
    End Sub
#End Region

#Region "仮登録ボタン押下"
    ''' <summary>
    ''' 仮登録ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 仮登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 仮登録.Click
        Dim param As New Habits.DB.DBParameter
        param.Add("@顧客番号", Me.未登録者一覧.CurrentRow.Cells(0).Value)
        param.Add("@更新日", Now())
        logic.仮登録処理(param)

        一覧更新()
    End Sub
#End Region

    Private Sub 未登録者一覧_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles 未登録者一覧.CellContentDoubleClick
        If Me.未登録者一覧.SelectedRows.Count <> 0 Then
            Me.変更.Enabled = True
            Me.仮登録.Enabled = True
            Call 変更_Click(sender, e)
        End If
    End Sub

    Private Sub 未登録者一覧_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles 未登録者一覧.SelectionChanged
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        If Me.未登録者一覧.SelectedRows.Count <> 0 Then
            Me.変更.Enabled = True

            param.Add("@顧客番号", Me.未登録者一覧.CurrentRow.Cells(0).Value)
            dt = logic.登録済番号確認(param)
            If (Integer.Parse(dt.Rows(0)("登録区分番号").ToString) = 0) Then
                Me.仮登録.Enabled = False
            Else
                Me.仮登録.Enabled = True
            End If
        End If
    End Sub

    Private Sub chk区分_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk区分.CheckedChanged
        一覧更新()
    End Sub
#End Region

#Region "メソッド"
    Private Sub 一覧更新()
        Dim dt As New DataTable

        If Me.chk区分.Checked = True Then
            dt = logic.未登録者一覧()
        Else
            dt = logic.仮登録含む未登録一覧()
        End If

        If dt.Rows.Count > 0 Then
            Me.未登録者一覧.DataSource = dt

            Me.未登録者一覧.Columns(0).Width = 85
            Me.未登録者一覧.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.未登録者一覧.Columns(1).Width = 102
            Me.未登録者一覧.Columns(2).Width = 102
            Me.未登録者一覧.Columns(3).Width = 97
            Me.未登録者一覧.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.未登録者一覧.ClearSelection()
        Else
            Me.未登録者一覧.DataSource = Nothing
        End If

        Me.変更.Enabled = False
        Me.仮登録.Enabled = False
    End Sub
#End Region

End Class