'システム名 ： HABITS
'機能名　　 ： a0500_顧客番号設定
'概要　　　 ： 来店者の顧客番号を手動で設定する機能
'履歴　　　 ： 2010/05/12　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a0500_顧客番号設定
    Private logic As Habits.Logic.a0500_Logic   'ロジッククラス

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0500_顧客番号設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.顧客番号.Text = ""
        Me.顧客番号.Focus()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0500_顧客番号設定_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "設定ボタン押下"
    Private Sub 設定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 設定.Click
        If Not (input_check()) Then Exit Sub
        a0300_来店.lbl新規顧客番号.Text = Me.顧客番号.Text
        Me.Close()
    End Sub
#End Region

#Region "閉じるボタン押下"
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.顧客番号.Text = ""
        Me.Close()
    End Sub
#End Region

#Region "入力チェック"
    ''' <summary>入力チェック</summary>
    ''' <returns>True：エラーなし、False：エラーあり</returns>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean

        If String.IsNullOrEmpty(Me.顧客番号.Text) Then
            Call Sys_Error("顧客番号 は必須入力です。　", Me.顧客番号)
            Exit Function
        End If
        If Sys_InputCheck(Me.顧客番号.Text, 6, "N+", 1) Then
            Call Sys_Error("顧客番号 は6桁以内の半角数字で入力してください。　", Me.顧客番号)
            Me.顧客番号.Text = ""
            Exit Function
        End If
        input_check = False

        Dim param As New Habits.DB.DBParameter
        param.Add("@顧客番号", Me.顧客番号.Text)
        logic = New Habits.Logic.a0500_Logic
        If (logic.Q_a0500_顧客番号(param)) Then
            Call Sys_Error("この顧客番号 は使用済みです。　" & Chr(13) & Chr(13) & "別番号を入力してください。　", Me.顧客番号)
            Exit Function
        End If

        If Integer.Parse(Me.顧客番号.Text) = 0 Then
            Call Sys_Error("顧客番号 0 は登録できません。　" & Chr(13) & Chr(13) & "別番号を入力してください。　", Me.顧客番号)
            Me.顧客番号.Text = ""
            Exit Function
        End If

        If Integer.Parse(Me.顧客番号.Text) >= Clng_MAXCstNo Then
            Call Sys_Error("顧客番号の最大値 " & (Clng_STFreeNo - 1) & "を超えています。　", Me.顧客番号)
            Exit Function
        End If

        input_check = True
    End Function
#End Region

#Region "顧客番号KeyDown"
    Private Sub 顧客番号_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 顧客番号.KeyDown
        If (e.KeyData.Equals(System.Windows.Forms.Keys.Enter)) Then
            Me.設定.Focus()
        End If
    End Sub
#End Region

#Region "顧客番号KeyPress"
    Private Sub 顧客番号_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles 顧客番号.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub
#End Region

End Class