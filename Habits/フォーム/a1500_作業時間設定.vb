'システム名 ： HABITS
'機能名　　 ： a1500_作業時間設定
'概要　　　 ： 作業工程登録機能
'履歴　　　 ： 2010/05/12　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a1500_作業時間設定

    Private logic As New Habits.Logic.a1500_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1500_作業時間設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        商品一覧更新()
        担当者一覧更新()
        Load用()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1500_作業時間設定_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        logic.delete_W_ポイント()
        Me.Close()
    End Sub

    Private Sub 登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 登録.Click
        Dim param As New Habits.DB.DBParameter

        If Me.商品一覧.Rows.Count <> 0 Then
            param.Clear()
            getParam(param)
            param.Add("@売上区分番号", Me.商品一覧.CurrentRow.Cells("売上区分番号").Value)
            param.Add("@分類番号", Me.商品一覧.CurrentRow.Cells("分類番号").Value)
            param.Add("@商品番号", Me.商品一覧.CurrentRow.Cells("商品番号").Value)
            param.Add("@工程番号", Me.工程一覧.CurrentRow.Cells("工程番号").Value)
            param.Add("@工程名", Me.工程一覧.CurrentRow.Cells("工程名").Value)

            logic.delete_W_ポイント(param)
            param.Add("@ポイント", Long.Parse(Me.工程一覧.CurrentRow.Cells("ポイント").Value.ToString) * Long.Parse(Me.商品一覧.CurrentRow.Cells("数量").Value.ToString))
            param.Add("@担当者コード", Me.担当者一覧.CurrentRow.Cells("担当者番号").Value)
            param.Add("@担当者名", Me.担当者一覧.CurrentRow.Cells("担当者名").Value)
            param.Add("@更新日", Now)
            logic.pointAdd(param)

            登録済一覧更新()
            工程一覧更新()
        End If
    End Sub

    Private Sub 削除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 削除.Click
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        getParam(param)
        param.Add("@売上区分番号", Me.登録済一覧.CurrentRow.Cells("売上区分番号").Value)
        param.Add("@分類番号", Me.登録済一覧.CurrentRow.Cells("分類番号").Value)
        param.Add("@商品番号", Me.登録済一覧.CurrentRow.Cells("商品番号").Value)
        param.Add("@工程番号", Me.登録済一覧.CurrentRow.Cells("工程番号").Value)
        param.Add("@工程名", Me.登録済一覧.CurrentRow.Cells("工程名").Value)

        dt = logic.selectPoint(param)
        If dt.Rows.Count > 0 Then
            logic.delete_E_ポイント(param)
        End If

        param.Add("@ポイント", Double.Parse(Me.登録済一覧.CurrentRow.Cells("ポイント").Value.ToString) / Double.Parse(Me.商品一覧.CurrentRow.Cells("数量").Value.ToString))
        logic.pointAdd_W(param)

        登録済一覧更新()
        工程一覧更新()
    End Sub

    Private Sub 担当者一覧_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles 担当者一覧.CellContentClick
        chk登録ボタン()
    End Sub

    Private Sub 工程一覧_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles 工程一覧.Click
        chk登録ボタン()
    End Sub

    Private Sub 工程一覧_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles 工程一覧.SelectionChanged
        chk登録ボタン()
    End Sub

    Private Sub 担当者一覧_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles 担当者一覧.SelectionChanged
        chk登録ボタン()
    End Sub

    Private Sub 商品一覧_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles 商品一覧.Click
        Dim dt0 As New DataTable
        Dim i As Integer = 0
        Dim h As Integer = 0
        Dim param As New Habits.DB.DBParameter

        If Me.商品一覧.SelectedRows.Count <> 0 Then
            logic.delete_W_ポイント()
            If 工程一覧_deta追加() = True Then
                chk登録ボタン()

                Do Until i = 工程一覧.Rows.Count
                    param.Clear()
                    getParam(param)
                    param.Add("@売上区分番号", Me.商品一覧.CurrentRow.Cells("売上区分番号").Value)
                    param.Add("@分類番号", Me.商品一覧.CurrentRow.Cells("分類番号").Value)
                    param.Add("@商品番号", Me.商品一覧.CurrentRow.Cells("商品番号").Value)
                    param.Add("@工程番号", Me.工程一覧.Rows(i).Cells("工程番号").Value)
                    param.Add("@工程名", Me.工程一覧.Rows(i).Cells("工程名").Value)
                    param.Add("@ポイント", Me.工程一覧.Rows(i).Cells("ポイント").Value)

                    logic.pointAdd_W(param)
                    dt0 = logic.selectPoint(param)

                    If dt0.Rows.Count = 1 Then
                        logic.delete_W_ポイント(param)
                    End If
                    i += 1
                Loop

                param.Clear()
                getParam(param)
                param.Add("@売上区分番号", Me.商品一覧.CurrentRow.Cells("売上区分番号").Value)
                param.Add("@分類番号", Me.商品一覧.CurrentRow.Cells("分類番号").Value)
                param.Add("@商品番号", Me.商品一覧.CurrentRow.Cells("商品番号").Value)
                dt0 = logic.select_W(param)
                Me.工程一覧.RowTemplate.Height = 16
                Me.工程一覧.DataSource = dt0
                Me.工程一覧.Columns(0).Visible = False
                Me.工程一覧.Columns(1).Visible = False
                Me.工程一覧.Columns(2).Visible = False
                Me.工程一覧.Columns(3).Width = 23
                Me.工程一覧.Columns(4).Width = 126
                Me.工程一覧.Columns(5).Visible = False
                Me.工程一覧.Columns(6).Visible = False
                Me.工程一覧.Columns(7).Visible = False
                Me.工程一覧.Columns(8).Visible = False
                Me.工程一覧.Columns(9).Width = 30
                Me.工程一覧.Columns(10).Visible = False
                Me.工程一覧.Columns(11).Visible = False

                Me.工程一覧.ClearSelection()
                登録済一覧更新()
            Else
                Me.工程一覧.DataSource = Nothing
                Me.登録済一覧.DataSource = Nothing

                MsgBox("この商品には工程が登録されていません。　", Clng_Okexb1, TTL)
                Me.商品一覧.ClearSelection()
            End If
        End If
    End Sub

    Private Sub 商品一覧_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles 商品一覧.SelectionChanged
        chk登録ボタン()
    End Sub

    Private Sub 登録済一覧_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles 登録済一覧.Click
        If Me.登録済一覧.SelectedRows.Count <> 0 Then
            Me.削除.Enabled = True
            chkfree登録()
        End If
    End Sub

    Private Sub 設定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 設定.Click
        a0400_作業時間設定.txt作業開始.Text = Me.作業開始.Text
        a0400_作業時間設定.txt作業終了.Text = Me.作業終了.Text
        a0400_作業時間設定.ShowDialog()
    End Sub

#End Region

#Region "メソッド"

    Private Sub chk登録ボタン()
        If Me.担当者一覧.SelectedRows.Count <> 0 And Me.商品一覧.SelectedRows.Count <> 0 And Me.工程一覧.SelectedRows.Count <> 0 Then
            Me.登録.Enabled = True
        Else
            Me.登録.Enabled = False
        End If
    End Sub

    Private Sub 商品一覧更新()
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        '' パラメータ設定（@来店日/@来店者番号/@顧客番号）
        param.Add("@来店日", Me.来店日.Text)
        param.Add("@来店者番号", Me.来店者番号.Text)
        param.Add("@顧客番号", Me.顧客番号.Text)

        dt = logic.select_skillItem(param)
        Me.商品一覧.DataSource = dt
        Me.商品一覧.Columns(0).Width = 130
        Me.商品一覧.Columns(1).Visible = False
        Me.商品一覧.Columns(2).Visible = False
        Me.商品一覧.Columns(3).Visible = False
        Me.商品一覧.Columns(4).Visible = False
        Me.商品一覧.Columns(5).Visible = False
        Me.商品一覧.Columns(6).Visible = False
        Me.商品一覧.ClearSelection()
    End Sub

    Private Sub 工程一覧更新()
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        If Me.商品一覧.SelectedRows.Count <> 0 Then
            param.Clear()
            getParam(param)
            param.Add("@売上区分番号", Me.商品一覧.CurrentRow.Cells("売上区分番号").Value)
            param.Add("@分類番号", Me.商品一覧.CurrentRow.Cells("分類番号").Value)
            param.Add("@商品番号", Me.商品一覧.CurrentRow.Cells("商品番号").Value)
            dt = logic.select_W(param)
            Me.工程一覧.DataSource = dt
            Me.工程一覧.Columns(0).Visible = False
            Me.工程一覧.Columns(1).Visible = False
            Me.工程一覧.Columns(2).Visible = False
            Me.工程一覧.Columns(3).Width = 23
            Me.工程一覧.Columns(4).Width = 126
            Me.工程一覧.Columns(5).Visible = False
            Me.工程一覧.Columns(6).Visible = False
            Me.工程一覧.Columns(7).Visible = False
            Me.工程一覧.Columns(8).Visible = False
            Me.工程一覧.Columns(9).Width = 30
            Me.工程一覧.Columns(10).Visible = False
            Me.工程一覧.Columns(11).Visible = False

            Me.工程一覧.ClearSelection()
        End If
    End Sub

    Private Sub 担当者一覧更新()
        Dim dt As New DataTable
        dt = logic.スタッフ一覧()
        Me.担当者一覧.DataSource = dt
        Me.担当者一覧.Columns(0).Visible = False     ' 担当者番号
        Me.担当者一覧.Columns(1).Width = 131         ' 担当者名
        Me.担当者一覧.Columns(2).Visible = False     ' 表示順

        Me.担当者一覧.ClearSelection()
    End Sub

    Private Sub 登録済一覧更新()
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        Me.削除.Enabled = False
        If Me.商品一覧.Rows.Count <> 0 Then
            getParam(param)
            param.Add("@売上区分番号", Me.商品一覧.CurrentRow.Cells("売上区分番号").Value)
            param.Add("@分類番号", Me.商品一覧.CurrentRow.Cells("分類番号").Value)
            param.Add("@商品番号", Me.商品一覧.CurrentRow.Cells("商品番号").Value)

            dt = logic.ポイント結果(param)

            If dt.Rows.Count = 0 Then
                Me.登録済一覧.DataSource = Nothing
            Else
                Me.登録済一覧.DataSource = dt
                Me.登録済一覧.Columns(0).Visible = False
                Me.登録済一覧.Columns(1).Visible = False
                Me.登録済一覧.Columns(2).Visible = False
                Me.登録済一覧.Columns(3).Width = 86
                Me.登録済一覧.Columns(4).Width = 266
                Me.登録済一覧.Columns(5).Visible = False
                Me.登録済一覧.Columns(6).Visible = False
                Me.登録済一覧.Columns(7).Visible = False
                Me.登録済一覧.Columns(8).Visible = False
                Me.登録済一覧.Columns(9).Width = 71
                Me.登録済一覧.Columns(9).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
                Me.登録済一覧.Columns(10).Visible = False
                Me.登録済一覧.Columns(11).Visible = 142
                Me.登録済一覧.Columns(12).Visible = False
                Me.登録済一覧.ClearSelection()
            End If
        End If
    End Sub

    Private Sub Load用()
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        param.Add("@来店者番号", SER_NO)
        param.Add("@来店日", USER_DATE)
        dt = logic.select_starttime(param)
        If Not IsDBNull(dt.Rows(0)("作業開始")) Then
            Me.作業開始.Text = Format(dt.Rows(0)("作業開始"), "HH:mm")
        End If
        If Not IsDBNull(dt.Rows(0)("作業終了")) Then
            Me.作業終了.Text = Format(dt.Rows(0)("作業終了"), "HH:mm")
        End If
        Me.削除.Enabled = False

        Me.担当者一覧.ClearSelection()
        Me.商品一覧.ClearSelection()
    End Sub

    Private Function input_check() As Boolean
        Dim SJIS As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        input_check = False

        If Sys_InputCheck(Me.作業開始.Text, 5, "D", 1) Then
            Call Sys_Error("作業開始 が不正です。　", Me.作業開始)
            Exit Function
        End If
        If Sys_InputCheck(Me.作業終了.Text, 5, "D", 1) Then
            Call Sys_Error("作業終了 が不正です。　", Me.作業終了)
            Exit Function
        End If

        input_check = True
    End Function

    Private Function 工程一覧_deta追加() As Boolean
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        Dim rtn As Boolean = False

        If Me.商品一覧.SelectedRows.Count <> 0 Then
            Me.売上番号.Text = Me.商品一覧.SelectedRows(0).Cells("売上番号").Value.ToString

            If (Me.商品一覧.Rows.Count <> 0) Then
                param.Clear()
                param.Add("@売上区分番号", Me.商品一覧.CurrentRow.Cells("売上区分番号").Value)
                param.Add("@分類番号", Me.商品一覧.CurrentRow.Cells("分類番号").Value)
                param.Add("@商品番号", Me.商品一覧.CurrentRow.Cells("商品番号").Value)
                dt = logic.工程内容取得(param)

                If (dt.Rows.Count <> 0) Then
                    Me.工程一覧.DataSource = dt
                    Me.工程一覧.Columns(0).Width = 23
                    Me.工程一覧.Columns(1).Width = 126
                    Me.工程一覧.Columns(2).Width = 30
                    Me.工程一覧.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
                    Me.工程一覧.Enabled = True
                    rtn = True
                End If
            End If
        End If

        Return rtn
    End Function

    Private Function getParam(ByVal param As Habits.DB.DBParameter) As Habits.DB.DBParameter
        param.Add("@来店日", Me.来店日.Text)
        param.Add("@来店者番号", Me.来店者番号.Text)
        param.Add("@顧客番号", Integer.Parse(Me.顧客番号.Text))
        param.Add("@売上番号", Me.売上番号.Text)

        Return param
    End Function

    Private Sub setTime()
        If Not (input_check()) Then Exit Sub

        Dim ERA As New Integer
        Dim param As New Habits.DB.DBParameter
        param.Add("@来店者番号", SER_NO)
        param.Add("@来店日", USER_DATE.ToString("yyyy/MM/dd"))
        param.Add("@顧客番号", Me.顧客番号.Text)
        param.Add("@売上番号", Me.売上番号.Text)
        param.Add("@作業開始", DateTime.Parse(Me.作業開始.Text))
        param.Add("@作業終了", DateTime.Parse(Me.作業終了.Text))
        param.Add("@更新日", Now)
        ERA = logic.作業時間設定(param)

    End Sub

    Private Sub chkfree登録()
        If Me.登録済一覧.SelectedRows.Count <> 0 Then
            Me.工程一覧.ClearSelection()
            Me.担当者一覧.ClearSelection()
        End If
    End Sub
#End Region

End Class