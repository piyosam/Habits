'システム名 ： HABITS
'機能名　　 ： a0900_伝言メモ
'概要　　　 ： 伝言メモの表示機能
'履歴　　　 ： 2010/05/12　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a0900_伝言メモ

    Private logic As Habits.Logic.a0900_Logic ''ロジッククラス

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0900_伝言メモ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim param As New Habits.DB.DBParameter
        param.Add("@顧客番号", a0300_来店.txtCustomerNum.Text)
        logic = New Habits.Logic.a0900_Logic
        Dim DKO As New DataTable
        DKO = logic.Q_a0900_伝言メモ(param)
        Dim str As String
        str = DKO.Rows(0)("メモ").ToString
        lblMemo.Text = str
        Me.閉じる.Focus()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0900_伝言メモ_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>閉じるボタンクリック処理</summary>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub
#End Region

End Class