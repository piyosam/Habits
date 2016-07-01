'システム名 ： HABITS
'機能名　　 ： a0800_スタッフ選択
'概要　　　 ： 実行日付の出勤スタッフ選択処理
'履歴　　　 ： 2010/05/12　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a0800_スタッフ選択
    Public int_mode As Integer                  '場合分け用変数
    Private logic As Habits.Logic.a0800_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>
    ''' ページロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0800_スタッフ選択_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim select_dt As New DataTable
        Dim rtn As New Integer
        Dim param As New Habits.DB.DBParameter
        logic = New Habits.Logic.a0800_Logic
        param.Add("@削除フラグ", "False")
        select_dt = logic.select_D_担当者
        If select_dt.Rows.Count = 0 Then ''追加しました2010/08/23(削除フラグfalseで該当スタッフがいない場合)
            rtn = MsgBox("該当担当者が未設定です。　" & Chr(13) & _
            "担当者で編集してください。　", Clng_Okexb1, TTL)
            f0600_スタッフ.ShowDialog()
        End If

        rtn = logic.delete_W_担当者
        If (int_mode = 0) Then
            '' 当日初回設定
            rtn = logic.delete_W_スタッフ
            rtn = logic.insert_W_担当者(param)
        Else
            '' 当日再設定
            rtn = logic.insert_W_担当者_again(param)

        End If
        redisplay_担当者一覧()
        redisplay_スタッフ一覧()

        'ボタンの設定
        If (dgv担当者一覧.RowCount > 0) Then
            Me.選択.Enabled = True
            Me.全選択.Enabled = True
        Else
            Me.選択.Enabled = False
            Me.全選択.Enabled = False
        End If

        If (dgvスタッフ一覧.RowCount > 0) Then
            Me.解除.Enabled = True
            Me.全解除.Enabled = True
        Else
            Me.解除.Enabled = False
            Me.全解除.Enabled = False
        End If
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <remarks></remarks>
    Private Sub a0800_スタッフ選択_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim dt As New DataTable
        dt = logic.select_W_スタッフ
        If (dt.Rows.Count = 0) Then
            rtn = MsgBox("担当者が選択されていません。　" & Chr(13) & Chr(13) & "全ての担当者を選択します。　", Clng_Okexb1, TTL)
            Dim insert_dt As New Integer
            Dim param As New Habits.DB.DBParameter
            param.Add("@削除フラグ", "False")
            logic = New Habits.Logic.a0800_Logic
            insert_dt = logic.insert_W_スタッフ(param)
        End If
        redisplay_メイン()
        Me.Dispose()
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "登録ボタン押下"
    ''' <summary>
    ''' 登録ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        rtn = MsgBox("選択しました。　　　　" & Chr(13), Clng_Okinb1, TTL)

        redisplay_メイン()
        Me.dgvスタッフ一覧.DataSource = Nothing
        Me.dgv担当者一覧.DataSource = Nothing

        Me.dgvスタッフ一覧.Columns.Clear()
        Me.dgv担当者一覧.Columns.Clear()

        Me.Close()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn選択.Click
        Me.Close()
    End Sub
#End Region

#Region "全選択ボタン押下"
    ''' <summary>
    ''' 全選択ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 全選択_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 全選択.Click
        Dim dt As New Integer
        Dim param As New Habits.DB.DBParameter
        logic = New Habits.Logic.a0800_Logic
        dt = logic.delete_W_担当者
        dt = logic.delete_W_スタッフ

        param.Add("@削除フラグ", "False")
        dt = logic.insert_W_スタッフ(param)
        redisplay_スタッフ一覧()
        redisplay_担当者一覧()

        Me.解除.Enabled = True
        Me.全解除.Enabled = True
        Me.選択.Enabled = False
        Me.全選択.Enabled = False

        Me.btn選択.Focus()
    End Sub
#End Region

#Region "選択ボタン押下"
    ''' <summary>
    ''' 選択ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 選択_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 選択.Click
        Dim dt As New Integer
        Dim select_dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        logic = New Habits.Logic.a0800_Logic
        param.Add("@担当者番号", Me.dgv担当者一覧.SelectedRows(0).Cells(0).Value)
        dt = logic.insert_part_W_スタッフ(param)
        dt = logic.delete_part_W_担当者(param)
        redisplay_担当者一覧()
        redisplay_スタッフ一覧()
        Me.解除.Enabled = True
        Me.全解除.Enabled = True
        select_dt = logic.select_W_担当者()
        If (select_dt.Rows.Count = 0) Then
            Me.選択.Enabled = False
            Me.全選択.Enabled = False
            Me.btn選択.Focus()
        End If
    End Sub
#End Region

#Region "解除ボタン押下"
    ''' <summary>
    ''' 解除ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 解除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 解除.Click
        Dim dt As New Integer
        Dim select_dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        logic = New Habits.Logic.a0800_Logic
        param.Add("@担当者番号", Me.dgvスタッフ一覧.SelectedRows(0).Cells(0).Value)
        dt = logic.insert_part_W_担当者(param)
        dt = logic.delete_part_W_スタッフ(param)
        redisplay_スタッフ一覧()
        redisplay_担当者一覧()
        select_dt = logic.select_W_スタッフ()
        Me.選択.Enabled = True
        Me.全選択.Enabled = True
        If (select_dt.Rows.Count = 0) Then
            Me.解除.Enabled = False
            Me.全解除.Enabled = False
        End If
    End Sub
#End Region

#Region "全解除ボタン押下"
    ''' <summary>
    ''' 全解除ボタンクリック時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 全解除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 全解除.Click
        Dim dt As New Integer
        Dim param As New Habits.DB.DBParameter
        logic = New Habits.Logic.a0800_Logic
        dt = logic.delete_W_担当者
        dt = logic.delete_W_スタッフ
        param.Add("@削除フラグ", "False")
        dt = logic.insert_W_担当者(param)
        redisplay_スタッフ一覧()
        redisplay_担当者一覧()

        Me.解除.Enabled = False
        Me.全解除.Enabled = False
        Me.選択.Enabled = True
        Me.全選択.Enabled = True

        Me.全選択.Focus()
    End Sub
#End Region

#End Region

#Region "メソッド"

#Region "総スタッフ一覧表示"
    ''' <summary>
    ''' 総スタッフ一覧表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub redisplay_担当者一覧()
        Dim dt As New DataTable
        logic = New Habits.Logic.a0800_Logic
        dt = logic.select_W_担当者
        Me.dgv担当者一覧.DataSource = dt
        Me.dgv担当者一覧.Columns(0).Visible = False
        Me.dgv担当者一覧.Columns(1).Width = 131
        Me.dgv担当者一覧.Columns(2).Visible = False
        Me.dgv担当者一覧.Columns(3).Visible = False
        Me.dgv担当者一覧.Columns(4).Visible = False
        Me.dgv担当者一覧.Columns(5).Visible = False
    End Sub
#End Region

#Region "出勤スタッフ一覧表示"
    ''' <summary>
    ''' 出勤スタッフ一覧表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub redisplay_スタッフ一覧()
        Dim dt As New DataTable
        logic = New Habits.Logic.a0800_Logic
        dt = logic.select_W_スタッフ
        Me.dgvスタッフ一覧.DataSource = dt
        Me.dgvスタッフ一覧.Columns(0).Visible = False
        Me.dgvスタッフ一覧.Columns(1).Width = 131
        Me.dgvスタッフ一覧.Columns(2).Visible = False
        Me.dgvスタッフ一覧.Columns(3).Visible = False
        Me.dgvスタッフ一覧.Columns(4).Visible = False
        Me.dgvスタッフ一覧.Columns(5).Visible = False
    End Sub
#End Region

#Region "遷移画面判定処理"
    ''' <summary>
    ''' 遷移画面判定処理
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub redisplay_メイン()
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        param.Add("@営業日", USER_DATE)
        dt = logic.select_E_営業日(param)
        If dt.Rows.Count = 1 Then
            registe更新日()
        End If
        dt = logic.select_W_スタッフ()
        If int_mode = 1 Then
            a0200_メイン.ReDisplay()
        Else
            a0600_営業日.lblスタッフ数.Text = dt.Rows.Count.ToString
        End If
    End Sub
#End Region

#Region "営業日情報更新処理"
    Public Sub registe更新日()
        Dim param As New Habits.DB.DBParameter
        Dim dt As New DataTable
        dt = logic.select_W_スタッフ()
        param.Add("@スタッフ数", dt.Rows.Count.ToString)
        param.Add("@更新日", Now)
        param.Add("@営業日", USER_DATE)

        Call logic.E_営業日更新(param)
    End Sub
#End Region

#End Region
End Class