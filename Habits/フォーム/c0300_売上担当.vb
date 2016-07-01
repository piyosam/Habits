''' <summary>c0300_売上担当画面処理</summary>
''' <remarks></remarks>
Public Class c0300_売上担当

    Private logic As Habits.Logic.c0300_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub c0300_売上担当_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        logic = New Habits.Logic.c0300_Logic

        Me.ddl担当者.DataSource = logic.Q_共通_スタッフ一覧()
        Me.ddl担当者.DisplayMember = "担当者名"
        Me.ddl担当者.ValueMember = "担当者番号"
        Me.ddl担当者.SelectedValue = c0200_売上入力.売上担当者番号.Text
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub c0300_売上担当_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "設定ボタン押下"
    ''' <summary>設定ボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn設定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn設定.Click
        Dim DTA As New DataTable ' D_担当者
        Dim param As New Habits.DB.DBParameter

        If Not (input_check()) Then Exit Sub

        c0200_売上入力.売上担当者番号.Text = Me.ddl担当者.SelectedValue.ToString
        param.Add("@担当者番号", c0200_売上入力.売上担当者番号.Text)

        DTA = logic.D_担当者取得(param)
        If DTA.Rows.Count <> 0 Then
            c0200_売上入力.売上担当者.Text = DTA.Rows(0)("担当者名").ToString
        End If

        Me.Close()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>閉じるボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn閉じる.Click
        Me.Close()
    End Sub
#End Region

#End Region

#Region "フォーカス移動(Enter)"

    Private Sub ddl担当者_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ddl担当者.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.btn設定.Focus()
        End If
    End Sub

#End Region

#Region "メソッド"

    Private Function input_check() As Boolean
        If Sys_InputCheck(Me.ddl担当者.SelectedValue, 4, "N+", 1) Then
            Call Sys_Error("担当者 を選択してください。　", Me.ddl担当者)
            Exit Function
        End If

        input_check = True
    End Function

#End Region

End Class