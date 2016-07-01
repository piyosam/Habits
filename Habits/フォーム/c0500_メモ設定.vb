''' <summary>c0500_メモ設定画面処理</summary>
''' <remarks></remarks>
Public Class c0500_メモ設定
    Private 伝言フラグチェック As Boolean = False
    Private logic As Habits.Logic.c0500_Logic ''ロジッククラス

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub c0500_メモ設定_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim param As New Habits.DB.DBParameter
        Dim dt As New DataTable

        param.Add("@顧客番号", CST_CODE)
        logic = New Habits.Logic.c0500_Logic
        dt = logic.Q_c0500_メモ_Select(param)

        Me.ラベル.Text = IIf(dt.Rows(0)("メモ").Equals(DBNull.Value), "", dt.Rows(0)("メモ")).ToString
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub c0500_メモ設定_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "設定ボタン押下"
    ''' <summary>設定ボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 設定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 設定.Click
        If Not (input_check()) Then Exit Sub
        Dim param As New Habits.DB.DBParameter
        param.Add("@顧客番号", CST_CODE)
        param.Add("@メモ", Me.ラベル.Text)
        If 伝言フラグチェック = False Then
            param.Add("@伝言フラグ", 0)
        Else
            param.Add("@伝言フラグ", 1)
        End If

        param.Add("@更新日", Now)
        logic = New Habits.Logic.c0500_Logic
        Dim DKO As New Integer
        DKO = logic.Q_c0500_メモ(param)

        Me.Close()
    End Sub
#End Region

#Region "伝言フラグ設定変更処理"
    ''' <summary>
    ''' 伝言フラグ設定変更処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 伝言フラグ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 伝言フラグ.CheckedChanged
        伝言フラグチェック = True
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>閉じるボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub
#End Region

#Region "入力チェック"
    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <returns>True：正常、False：エラー</returns>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        input_check = False
        Me.ラベル.Text = Trim(Me.ラベル.Text)

        If String.IsNullOrEmpty(Me.ラベル.Text) Then
            Call Sys_Error("メモ が入力されていません。　", Me.ラベル)
            Exit Function
        End If

        If Sys_InputCheck(Me.ラベル.Text, 32, "M", 1) Then
            Call Sys_Error("メモ は32文字以内で入力してください。　", Me.ラベル)
            Exit Function
        End If
        input_check = True

    End Function
#End Region

End Class