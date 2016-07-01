'システム名 ： HABITS
'機能名　　 ： z_0200_空番号選択
'概要　　　 ： 未使用顧客番号の検索機能
'履歴　　　 ： 2010/06/14　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.Imports System.Data
Public Class z_0200_空番号選択

#Region "変数・定数"

    Dim empty_no As Long
    Private logic As Habits.Logic.z0200_Logic
    Public loaded As Boolean = False
    Private bTextChange As Boolean = False
    Private mIsMouseDown As Boolean = False
    Private Const END_NUM As Integer = Clng_STFreeNo - 1
    Private Const CNT_NUM As Integer = 1000

#End Region

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub z_0200_空番号選択_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        logic = New Habits.Logic.z0200_Logic
        '項目初期化
        clearItem()
        Me.選択.Enabled = False
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub z_0200_空番号選択_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        logic.空番号削除()
        If Me.loaded = False Then
            a0300_来店.txt新規姓.Focus()
        Else
            f0100_顧客登録.姓.Focus()
        End If

        Me.loaded = False
        Me.bTextChange = False
        Me.Close()
    End Sub

    Private Sub 選択_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 選択.Click
        If ((Me.dgv空番号一覧.SelectedRows.Count <> 1)) Then Exit Sub
        a0300_来店.lbl新規顧客番号.Text = Me.dgv空番号一覧.CurrentRow.Cells(0).Value.ToString
        f0100_顧客登録.lbl顧客番号.Text = Me.dgv空番号一覧.CurrentRow.Cells(0).Value.ToString

        logic.空番号削除()
        If Me.loaded = False Then
            a0300_来店.txt新規姓.Focus()
        Else
            f0100_顧客登録.姓.Focus()
        End If

        logic.空番号削除()

        Me.loaded = False
        Me.bTextChange = False
        Me.Close()
    End Sub

    Private Sub txt開始顧客番号_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt開始顧客番号.KeyDown
        If (e.KeyData.Equals(System.Windows.Forms.Keys.Enter)) Then
            Me.bTextChange = False
            '入力チェック
            If Not input_check() Then Exit Sub

            Call 開始空番号処理()
        End If
    End Sub

    Private Sub dgv空番号一覧_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv空番号一覧.CellContentDoubleClick
        Call 選択_Click(sender, e)
    End Sub

    Private Sub txt開始顧客番号_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt開始顧客番号.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

    Private Sub txt開始顧客番号_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt開始顧客番号.Leave
        If (bTextChange = True) Then
            Me.bTextChange = False
            '入力チェック
            If Not input_check() Then Exit Sub

            Call 開始空番号処理()
        End If
        mIsMouseDown = False
    End Sub

    Private Sub txt開始顧客番号_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt開始顧客番号.TextChanged
        Me.bTextChange = True
    End Sub

#End Region

#Region "メソッド"

#Region "入力チェック"
    ''' <summary>入力チェック</summary>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        input_check = False

        If String.IsNullOrEmpty(Me.txt開始顧客番号.Text) Then
            Call Sys_Error("顧客番号 は必須入力です。　", Me.txt開始顧客番号)
            Exit Function
        End If
        If (Sys_InputCheck(Me.txt開始顧客番号.Text, 6, "N", 1)) Then
            Call Sys_Error("顧客番号 は半角数字6文字以内で入力してください。　", Me.txt開始顧客番号)
            Exit Function
        End If
        input_check = True
    End Function
#End Region

#Region "空番号追加"
    ''' <summary>
    ''' 空番号追加
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub 共通_空番号追加()
        Dim h As Integer
        Dim i As Integer
        Dim param As New Habits.DB.DBParameter
        Dim kb As DataTable
        Dim ab As DataTable
        Dim 終了 As Integer
        Dim 新規顧客番号 As Integer

        logic.空番号削除()
        empty_no = CLng(Me.txt開始顧客番号.Text)

        新規顧客番号 = Integer.Parse(logic.最小空番号())
        i = Integer.Parse(Me.txt開始顧客番号.Text)
        終了 = Integer.Parse(Me.lbl終了顧客番号.Text)

        param.Add("@開始顧客番号", Me.txt開始顧客番号.Text)
        param.Add("@終了顧客番号", Me.lbl終了顧客番号.Text)
        kb = logic.顧客番号取得(param)
        param.Clear()

        If (kb.Rows.Count() < CNT_NUM) Then
            While (i <= 終了)
                h = 0
                While (h < kb.Rows.Count())
                    If (kb.Rows(h)("顧客番号").Equals(i)) Then
                        Exit While
                    End If
                    h += 1
                End While
                If (kb.Rows.Count() <= h) Then
                    param.Add("@空番号", i)
                    logic.空番号一覧更新(param)
                    param.Clear()
                End If
                i += 1
            End While

        Else
            MsgBox("空番号はありません。" & Chr(13) & Chr(13) & _
            "新規番号または仮登録番号を使用してください。　", Clng_Okinb1, TTL)
            param.Add("@空番号", 新規顧客番号)
            logic.空番号一覧更新(param)
            param.Clear()
        End If

        ab = logic.z_空番号取得()
        If ab.Rows.Count > 0 Then
            Me.dgv空番号一覧.DataSource = ab
            Me.dgv空番号一覧.Columns(0).Width = 60
            Me.dgv空番号一覧.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
            Me.dgv空番号一覧.Columns(1).Width = 106
            Me.dgv空番号一覧.Columns(1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft
            Me.dgv空番号一覧.Rows(0).Selected = True
            Me.選択.Enabled = True
        Else
            MsgBox("空番号はありません。" & Chr(13) & Chr(13) & _
            "新規番号または仮登録番号を使用してください。　", Clng_Okinb1, TTL)
        End If

        ab.Dispose()
        kb.Dispose()
    End Sub
#End Region

#Region "空番号設定処理"
    ''' <summary>
    ''' 空番号設定処理
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub 開始空番号処理()
        If (Integer.Parse(Me.txt開始顧客番号.Text) <= (END_NUM - CNT_NUM)) Then
            Me.lbl終了顧客番号.Text = (Integer.Parse(Me.txt開始顧客番号.Text) + CNT_NUM - 1).ToString
        ElseIf (Integer.Parse(Me.txt開始顧客番号.Text) <= END_NUM) Then
            Me.lbl終了顧客番号.Text = END_NUM.ToString
        Else
            MsgBox("空番号はありません。" & Chr(13) & Chr(13) & _
          "新規番号または仮登録番号を使用してください。　", Clng_Okinb1, TTL)
            Me.txt開始顧客番号.Text = String.Empty
            Me.lbl終了顧客番号.Text = String.Empty
            Exit Sub
        End If

        Call 共通_空番号追加()
        Me.選択.Focus()
    End Sub
#End Region

#Region "項目初期化"
    ''' <summary>
    ''' 項目初期化処理
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub clearItem()
        txt開始顧客番号.Text = Nothing
        lbl終了顧客番号.Text = Nothing
        dgv空番号一覧.DataSource = Nothing
    End Sub
#End Region

#End Region
End Class