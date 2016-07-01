'システム名 ： HABITS
'機能名　　 ： a0700_日付設定
'概要　　　 ： 実行日付の設定処理
'履歴　　　 ： 2010/05/12　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a0700_日付設定

    Private m_beforeDate As Date

    ''' <summary>
    ''' フォームロード時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0700_日付設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtp設定日.Value = USER_DATE
        Me.m_beforeDate = USER_DATE
        Me.Activate()
    End Sub

    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <remarks></remarks>
    Private Sub a0700_日付設定_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' 今日ボタンクリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn今日_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn今日.Click
        Me.dtp設定日.Value = Now()
    End Sub

    ''' <summary>
    ''' 閉じるボタンクリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn閉じる.Click
        USER_DATE = Me.m_beforeDate
        Me.Close()
    End Sub

    ''' <summary>
    ''' 設定ボタンクリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn設定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn設定.Click
        USER_DATE = Me.dtp設定日.Value.Date
        Me.Close()
    End Sub

End Class