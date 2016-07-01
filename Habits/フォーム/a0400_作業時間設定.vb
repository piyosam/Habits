'システム名 ： HABITS
'機能名　　 ： a0400_作業時間設定
'概要　　　 ： 来店から会計までの時間を修正する機能
'履歴　　　 ： 2010/05/11　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a0400_作業時間設定

#Region "変数・定数定義"

    Private logic As Habits.Logic.a0400_Logic   'ロジッククラス
    Private time As String
    Private w_time As Double

#End Region

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0400_作業時間設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        logic = New Habits.Logic.a0400_Logic
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0400_作業時間設定_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "作業開始入力時チェック"
    ''' <summary>
    ''' 作業開始入力時チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 作業開始_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt作業開始.Validated
        If Me.txt作業開始.TextLength <> 0 Then
            time = Replace(Me.txt作業開始.Text, ":", "")
            If IsNumeric(time) Then
                w_time = Double.Parse(time)
                Me.txt作業開始.Text = Format(w_time, "00:00")

                RemoveHandler txt作業開始.Validated, AddressOf 作業開始_Validated
                AddHandler txt作業開始.Validated, AddressOf Me.作業開始_Validated
            Else
                Call Sys_Error("作業開始 は4桁の半角数字で入力してください。　", Me.txt作業開始)
                Me.txt作業開始.Text = Nothing
            End If
            If Not (input_check()) Then
                Exit Sub
            End If
        End If
    End Sub
#End Region

#Region "作業終了入力時チェック"
    ''' <summary>
    ''' 作業終了入力時チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 作業終了_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt作業終了.Validated
        If Me.txt作業終了.TextLength <> 0 Then
            time = Replace(Me.txt作業終了.Text, ":", "")
            If IsNumeric(time) Then
                w_time = Double.Parse(time)
                Me.txt作業終了.Text = Format(w_time, "00:00")

                RemoveHandler txt作業終了.Validated, AddressOf 作業終了_Validated
                AddHandler txt作業終了.Validated, AddressOf Me.作業終了_Validated
            Else
                Call Sys_Error("作業終了 は4桁の半角数字で入力してください。　", Me.txt作業終了)
                Me.txt作業終了.Text = Nothing
            End If
            If Not (input_check()) Then
                Exit Sub
            End If
        End If
    End Sub
#End Region

#Region "キープレス処理"
    Private Sub txt作業開始_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt作業開始.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txt作業終了_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt作業終了.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub
#End Region

#Region "キー押下時処理"
    Private Sub txt作業開始_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt作業開始.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            txt作業終了.Focus()
        End If
    End Sub

    Private Sub txt作業終了_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt作業終了.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            btn設定.Focus()
        End If
    End Sub
#End Region

#Region "Enter押下時処理"
    Private Sub txt作業開始_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt作業開始.Enter
        txt作業開始.Text = Replace(Me.txt作業開始.Text, ":", "")
    End Sub

    Private Sub txt作業終了_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt作業終了.Enter
        txt作業終了.Text = Replace(Me.txt作業終了.Text, ":", "")
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "設定ボタン押下"
    ''' <summary>
    ''' 設定ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn設定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn設定.Click
        Call 作業時間変更()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub
#End Region

#End Region

#Region "メソッド"

#Region "入力チェック"
    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <returns>True：正常、False：入力エラー</returns>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        input_check = False

        If String.IsNullOrEmpty(Me.txt作業開始.Text) Then
            Call Sys_Error("作業開始 は必須入力です。　", Me.txt作業開始)
            Exit Function
        End If
        If Sys_Zenkaku(Me.txt作業開始.Text) Then
            Call Sys_Error("作業開始 は半角で入力してください。　", Me.txt作業開始)
            Exit Function
        End If
        If Sys_InputCheck(Me.txt作業開始.Text, 5, "D", 1) Then
            Call Sys_Error("作業開始 の時刻が不正です。　", Me.txt作業開始)
            Exit Function
        End If

        If String.IsNullOrEmpty(Me.txt作業終了.Text) Then
            Call Sys_Error("作業終了 は必須入力です。　", Me.txt作業終了)
            Exit Function
        End If
        If Sys_Zenkaku(Me.txt作業終了.Text) Then
            Call Sys_Error("作業終了 は半角で入力してください。　", Me.txt作業終了)
            Exit Function
        End If
        If Sys_InputCheck(Me.txt作業終了.Text, 5, "D", 1) Then
            Call Sys_Error("作業終了 の時刻が不正です。　", Me.txt作業終了)
            Exit Function
        End If

        If DateTime.Parse(Me.txt作業開始.Text) > DateTime.Parse(Me.txt作業終了.Text) Then
            Call Sys_Error("作業終了 は作業開始以降の時間を設定してください。　", Me.txt作業終了)
            Exit Function
        End If

        input_check = True
    End Function
#End Region

#Region "作業時間変更処理"
    ''' <summary>
    ''' 作業時間変更処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 作業時間変更()
        If Not (input_check()) Then Exit Sub

        Dim rtn As New Integer
        Dim param As New Habits.DB.DBParameter
        param.Add("@来店者番号", a1500_作業時間設定.来店者番号.Text)
        param.Add("@来店日", a1500_作業時間設定.来店日.Text)
        param.Add("@顧客番号", a1500_作業時間設定.顧客番号.Text)
        param.Add("@作業開始", USER_DATE & " " & Me.txt作業開始.Text)
        param.Add("@作業終了", USER_DATE & " " & Me.txt作業終了.Text)
        param.Add("@更新日", Now)
        logic = New Habits.Logic.a0400_Logic
        rtn = logic.Q_a0400_作業時間設定(param)

        a0200_メイン.ReDisplay()

        a1500_作業時間設定.作業開始.Text = Me.txt作業開始.Text
        a1500_作業時間設定.作業終了.Text = Me.txt作業終了.Text

        Me.Close()
    End Sub
#End Region

#End Region

End Class