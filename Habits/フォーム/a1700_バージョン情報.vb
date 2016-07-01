'システム名 ： HABITS
'機能名　　 ： a1700_バージョン情報
'概要　　　 ： バージョン情報表示機能
'履歴　　　 ： 2011/01/18　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a1700_バージョン情報

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1700_バージョン情報_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LblProductName.Text = My.Application.Info.ProductName.ToString()
        LblVersion.Text = My.Application.Info.Version.ToString()
        LblCopyright.Text = My.Application.Info.Copyright.ToString()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1700_バージョン情報_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#End Region

#Region "OKボタン押下"
    ''' <summary>
    ''' OKボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
        Me.Close()
    End Sub
#End Region

End Class