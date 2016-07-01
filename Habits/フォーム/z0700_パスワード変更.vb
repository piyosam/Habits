'システム名 ： HABITS
'機能名　　 ： z0700_パスワード変更
'概要　　　 ： 管理者パスワードを変更する機能
'履歴　　　 ： 2013/11/05　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2013 All Rights Reserved.

Public Class z0700_パスワード変更

    Private logic As Habits.Logic.z0700_Logic ''ロジッククラス
    Private logic_a2000 As Habits.Logic.a2000_Logic ''ロジッククラス

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>
    ''' ロード時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub z0700_パスワード変更_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        logic = New Habits.Logic.z0700_Logic
        logic_a2000 = New Habits.Logic.a2000_Logic
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub z0700_パスワード変更_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "管理者モードボタン押下"
    ''' <summary>
    ''' 管理者モードボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReg.Click

        If logic_a2000.GetManagementMode(TxtPwdOld.Text) Then
            '入力チェック
            If (txtPwd.Text <> txtPwd2.Text) Then
                Call Sys_Error("パスワードが間違っています。　", Me.txtPwd)
                Me.txtPwd.SelectAll()
                Exit Sub
            End If
            logic.updateA_Pwd(txtPwd.Text)
            MsgBox("管理者パスワードを変更しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
            Me.Close()
        Else
            Call Sys_Error("現在のパスワードが間違っています。　", Me.TxtPwdOld)
            Me.TxtPwdOld.SelectAll()
            Exit Sub
        End If

    End Sub
#End Region

#Region "キャンセルボタン押下"
    ''' <summary>
    ''' キャンセルボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
#End Region

#End Region

End Class