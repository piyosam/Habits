'システム名 ： HABITS
'機能名　　 ： a1300_カルテ
'概要　　　 ： カルテ情報登録機能
'履歴　　　 ： 2010/05/12　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a1300_カルテ
    Private logic As Habits.Logic.a1300_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1300_カルテ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dgv来店日一覧.DataSource = Nothing
        Me.redisplay()
        ''コンボボックススタッフ名一覧表示
        Dim WST As New DataTable
        Dim param As New Habits.DB.DBParameter
        param.Add("@削除フラグ", "False")
        WST = logic.select_name(param)
        Me.登録者番号.DataSource = WST
        Me.登録者番号.DisplayMember = "担当者名"
        Me.登録者番号.ValueMember = "担当者番号"

        If Not Me.担当者名.Text.Equals("") Then
            Me.登録者番号.Text = Me.担当者名.Text
        End If

        Me.来店者番号.Text = SER_NO.ToString
        Me.変更.Enabled = False
        Me.コピー.Enabled = False

        Me.カルテ.Clear()
        Me.過去カルテ.Clear()
        Me.TabControl1.SelectedIndex = 0
        Me.カルテ.Focus()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1300_カルテ_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.dgv来店日一覧.DataSource = Nothing
        Me.Close()
    End Sub
#End Region

#Region "登録ボタン押下"
    ''' <summary>
    ''' 登録ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 登録.Click
        If Not (input_check()) Then Exit Sub
        register()
    End Sub
#End Region

#Region "変更ボタン押下"
    ''' <summary>
    ''' 変更ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 変更_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 変更.Click
        If Me.dgv来店日一覧.SelectedRows.Count = 0 Then Exit Sub
        If Not (input_check()) Then Exit Sub
        Dim update_dt As New Integer
        Dim param As New Habits.DB.DBParameter
        param.Add("@顧客番号", Me.dgv来店日一覧.CurrentRow.Cells("顧客番号").Value)
        param.Add("@来店者番号", Me.dgv来店日一覧.CurrentRow.Cells("来店者番号").Value)
        param.Add("@来店日", Me.dgv来店日一覧.CurrentRow.Cells("来店日").Value)
        param.Add("@変更日時", Now.ToString("yyyy/MM/dd HH:mm:ss"))
        param.Add("@カルテ", Me.過去カルテ.Text)
        update_dt = logic.update_E_カルテ(param)
        rtn = MsgBox("変更しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
        Me.redisplay()  ''アップデート後のデータをdgv来店日一覧に再表示
        redisplayEdit()
    End Sub
#End Region

#Region "コピーボタン押下"
    ''' <summary>
    ''' コピーボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub コピー_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles コピー.Click
        Me.カルテ.Text = Me.過去カルテ.Text
        Me.TabControl1.SelectTab(0)
        Me.カルテ.Focus()
    End Sub
#End Region

#Region "来店日一覧選択処理"
    ''' <summary>
    ''' 来店日一覧選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv来店日一覧_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv来店日一覧.SelectionChanged
        redisplayEdit()
        If Me.dgv来店日一覧.SelectedRows.Count > 0 Then
            Me.TabControl1.SelectTab(1)
        End If
    End Sub
#End Region

#End Region

#Region "メソッド"
    Protected Friend Function input_check() As Boolean
        input_check = False

        If Sys_InputCheck(Me.カルテ.Text, 256, "M", 0) Then
            Call Sys_Error("カルテ は256文字以内で入力してください。　", Me.カルテ)
            Exit Function
        End If

        If Sys_InputCheck(Me.過去カルテ.Text, 256, "M", 0) Then
            Call Sys_Error("カルテ は256文字以内で入力してください。　", Me.過去カルテ)
            Exit Function
        End If
        input_check = True
    End Function

    Protected Friend Sub register()
        Dim select_dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        logic = New Habits.Logic.a1300_Logic
        param.Add("@顧客番号", CST_CODE)
        param.Add("@来店者番号", SER_NO)
        param.Add("@来店日", USER_DATE.ToString("yyyy/MM/dd"))
        select_dt = logic.exist_check(param)

        If (select_dt.Rows.Count > 0) Then
            Call Sys_Error("カルテは既に登録されています。　", Me.カルテ)
        Else
            Dim insert_dt As New Integer ''E_カルテにインサート
            param.Add("@カルテ", Me.カルテ.Text)
            param.Add("@登録者番号", Me.登録者番号.SelectedValue)
            param.Add("@登録日時", Now.ToString("yyyy/MM/dd HH:mm:ss"))
            param.Add("@変更日時", Now.ToString("yyyy/MM/dd HH:mm:ss"))
            insert_dt = logic.insert_E_カルテ(param)
            rtn = MsgBox("登録しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
            Me.redisplay()  ''インサート後のデータをdgv来店日一覧に再表示
            Me.Close()
        End If
    End Sub

    ''来店日一覧に過去来店日、担当者を表示
    Protected Friend Sub redisplay()
        Dim param As New Habits.DB.DBParameter
        param.Add("@顧客番号", CST_CODE)
        logic = New Habits.Logic.a1300_Logic ''来店日時、担当者名取得
        Dim EKA As New DataTable
        EKA = logic.select_day_name(param)
        If EKA.Rows.Count > 0 Then
            Me.dgv来店日一覧.DataSource = EKA
            Me.dgv来店日一覧.Columns(0).Width = 85
            Me.dgv来店日一覧.Columns(1).Width = 152
            Me.dgv来店日一覧.Columns(2).Visible = False
            Me.dgv来店日一覧.Columns(3).Visible = False
            Me.dgv来店日一覧.Columns(4).Visible = False
            Me.dgv来店日一覧.ClearSelection()
        End If
    End Sub

    ''編集項目を再設定
    Protected Friend Sub redisplayEdit()
        Dim select_dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        logic = New Habits.Logic.a1300_Logic
        param.Add("@顧客番号", CST_CODE)
        param.Add("@来店者番号", SER_NO)
        param.Add("@来店日", USER_DATE.ToString("yyyy/MM/dd"))
        select_dt = logic.exist_check(param)

        If (select_dt.Rows.Count > 0) Then
            Me.カルテ.BackColor = SystemColors.Control
            Me.カルテ.Enabled = False
            Me.登録者番号.Enabled = False
            Me.登録.Enabled = False
            Me.コピー.Enabled = False
        Else
            Me.カルテ.BackColor = Color.White
            Me.カルテ.Enabled = True
            Me.登録者番号.Enabled = True
            Me.登録.Enabled = True
            Me.コピー.Enabled = True
        End If

        If dgv来店日一覧.SelectedRows.Count > 0 Then
            Me.変更.Enabled = True
            Me.過去カルテ.Text = IIf(Me.dgv来店日一覧.SelectedRows(0).Cells(2).Value.Equals(System.DBNull.Value), "", Me.dgv来店日一覧.SelectedRows(0).Cells(2).Value).ToString
            Me.過去カルテ.BackColor = Color.White
            Me.過去カルテ.Enabled = True
        Else
            Me.変更.Enabled = False
            Me.過去カルテ.Clear()
            Me.過去カルテ.BackColor = SystemColors.Control
            Me.過去カルテ.Enabled = False
        End If
    End Sub
#End Region

End Class