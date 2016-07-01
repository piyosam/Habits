'システム名 ： HABITS
'機能名　　 ： a1800_通信設定
'概要　　　 ： 通信するかしないかを設定する機能
'履歴　　　 ： 2011/06/10　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a2000_モード変更

    Private logic As Habits.Logic.a2000_Logic ''ロジッククラス

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>
    ''' ロード時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a2000_モード変更_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        logic = New Habits.Logic.a2000_Logic
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a2000_モード変更_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
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
    Private Sub btn管理者モード_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn管理者モード.Click
        If logic.GetManagementMode(txtPwd.Text) Then
            '管理者モードへ
            MANAGER_MODE = True
            MsgBox("管理者モードへ変更しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
            Me.Close()
        Else
            MANAGER_MODE = False
            Call Sys_Error("パスワードが間違っています。　", Me.txtPwd)
            Exit Sub
        End If
    End Sub
#End Region

#Region "解除ボタン押下"
    ''' <summary>
    ''' 解除ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtDefaultMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDefaultMode.Click
        MANAGER_MODE = False
        MsgBox("管理者モードを解除しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
        Me.Close()

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

#Region "パスワードKeyDown"
    Private Sub txtPwd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPwd.KeyDown
        If (e.KeyData.Equals(System.Windows.Forms.Keys.Enter)) Then
            Me.btn管理者モード.Focus()
        End If
    End Sub
#End Region

End Class