''' <summary>f1000_工程画面処理</summary>
''' <remarks></remarks>
Public Class f1000_工程

    Private param As New Habits.DB.DBParameter
#Region "イベント"
    Private logic As New Habits.Logic.f1000_Logic

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f1000_工程_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim param As New Habits.DB.DBParameter
        param.Add("@売上区分番号", Me.売上区分番号.Text)
        param.Add("@分類番号", Me.分類番号.Text)
        param.Add("@商品番号", Me.商品番号.Text)
        logic.delete_W工程()
        logic.insert_工程マスタ()
        Me.データ表示()
        logic.マスタ調整(param)

        Me.工程マスタ.DataSource = Nothing
        Me.マスタ表示()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ前処理"
    ''' <summary>フォームが閉じられる前処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub f1000_工程_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        logic.工程表示順変更_ALL(Me.売上区分番号.Text, Me.分類番号.Text, Me.商品番号.Text)
        Me.Dispose()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        f0500_商品.ReDisplay_dgv商品一覧()
        Me.Close()
    End Sub
#End Region

#Region "削除ボタン押下"
    ''' <summary>
    ''' 削除ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 削除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dt As New DataTable
        param.Clear()
        getParam(param)
        param.Add("@工程番号", Me.登録済データ.CurrentRow.Cells("番号").Value)
        logic.C_商品工程削除(param)

        データ表示()
    End Sub
#End Region

#Region "選択ボタン押下"
    ''' <summary>
    ''' 選択ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn選択_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn選択.Click
        If Me.工程マスタ.SelectedRows.Count <> 0 Then
            param.Clear()
            param.Add("@売上区分番号", Me.売上区分番号.Text)
            param.Add("@分類番号", Me.分類番号.Text)
            param.Add("@商品番号", Me.商品番号.Text)
            param.Add("@工程番号", Me.工程マスタ.CurrentRow.Cells("番号").Value)
            param.Add("@工程名", Me.工程マスタ.CurrentRow.Cells("工程名").Value)
            param.Add("@ポイント", Me.工程マスタ.CurrentRow.Cells("ポイント").Value)
            '最大値を設定
            Dim maxOrder As Integer
            maxOrder = logic.GetMaxCount_商品工程(param)
            param.Add("@表示順", maxOrder + 1)
            param.Add("@登録日", Now())
            param.Add("@更新日", Now())

            logic.工程削除fromW_工程(param)
            logic.工程追加toC_商品工程(param)
            Me.マスタ表示()
            Me.データ表示()
            If 工程マスタ.RowCount <> 0 Then
                工程マスタ.Rows(0).Selected = True
            End If
        Else
            MsgBox("工程一覧より追加する工程を選択してください。　", Clng_Okexb1, TTL)
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
    Private Sub btn解除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn解除.Click
        If Me.登録済データ.SelectedRows.Count <> 0 Then
            param.Clear()
            param.Add("@売上区分番号", Me.売上区分番号.Text)
            param.Add("@分類番号", Me.分類番号.Text)
            param.Add("@商品番号", Me.商品番号.Text)
            param.Add("@工程番号", Me.登録済データ.CurrentRow.Cells("番号").Value)
            param.Add("@工程名", Me.登録済データ.CurrentRow.Cells("工程名").Value)
            param.Add("@ポイント", Me.登録済データ.CurrentRow.Cells("ポイント").Value)
            param.Add("@マスタ表示順", Me.登録済データ.CurrentRow.Cells("マスタ表示順").Value)
            param.Add("@登録日", Now)
            logic.C_商品工程削除(param)
            logic.工程追加toW_工程(param)
            Me.マスタ表示()
            Me.データ表示()
        Else
            MsgBox("登録済工程一覧から工程を選択してください。　", Clng_Okexb1, TTL)
        End If
    End Sub
#End Region

#Region "上へボタン押下"
    ''' <summary>
    ''' 上へボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn上へ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn上へ.Click
        If Me.登録済データ.SelectedRows.Count <> 0 Then
            If 登録済データ.SelectedRows(0).Index <= 0 Then Exit Sub

            param.Clear()
            param.Add("@売上区分番号", Me.売上区分番号.Text)
            param.Add("@分類番号", Me.分類番号.Text)
            param.Add("@商品番号", Me.商品番号.Text)
            param.Add("@更新日", Now())

            Dim index As Integer = 0
            index = Me.登録済データ.SelectedRows(0).Index - 1

            param.Add("@工程番号1", Me.登録済データ.SelectedRows(0).Cells("番号").Value)
            param.Add("@表示順1", Me.登録済データ.Rows(index).Cells("表示順").Value)

            param.Add("@工程番号2", Me.登録済データ.Rows(index).Cells("番号").Value)
            param.Add("@表示順2", Me.登録済データ.SelectedRows(0).Cells("表示順").Value)

            logic.工程表示順変更(param)

            Me.データ表示()

            Me.登録済データ.Rows(index).Selected = True
        Else
            MsgBox("表示順を変更する工程を選択してください。　", Clng_Okexb1, TTL)
        End If
    End Sub
#End Region

#Region "下へボタン押下"
    ''' <summary>
    ''' 下へボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn下へ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn下へ.Click
        If Me.登録済データ.SelectedRows.Count <> 0 Then
            If 登録済データ.SelectedRows(0).Index < 0 OrElse 登録済データ.SelectedRows(0).Index >= (登録済データ.Rows.Count - 1) Then Exit Sub

            param.Clear()
            param.Add("@売上区分番号", Me.売上区分番号.Text)
            param.Add("@分類番号", Me.分類番号.Text)
            param.Add("@商品番号", Me.商品番号.Text)
            param.Add("@更新日", Now())

            Dim index As Integer = 0
            index = Me.登録済データ.SelectedRows(0).Index + 1

            param.Add("@工程番号1", Me.登録済データ.Rows(index).Cells("番号").Value)
            param.Add("@表示順1", Me.登録済データ.SelectedRows(0).Cells("表示順").Value)

            param.Add("@工程番号2", Me.登録済データ.SelectedRows(0).Cells("番号").Value)
            param.Add("@表示順2", Me.登録済データ.Rows(index).Cells("表示順").Value)

            logic.工程表示順変更(param)
            Me.データ表示()
            Me.登録済データ.Rows(index).Selected = True
        Else
            MsgBox("表示順を変更する工程を選択してください。　", Clng_Okexb1, TTL)
        End If
    End Sub
#End Region

#Region "工程マスタ一覧選択処理"
    ''' <summary>
    ''' 工程マスタ一覧選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 工程マスタ_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 工程マスタ.SelectionChanged
        If 登録済データ.RowCount <> 0 AndAlso 登録済データ.SelectedRows.Count > 0 Then
            登録済データ.CurrentRow.Selected = False
        End If

    End Sub
#End Region

#Region "登録済一覧選択処理"
    ''' <summary>
    ''' 登録済一覧選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 登録済データ_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 登録済データ.SelectionChanged
        If 工程マスタ.RowCount <> 0 AndAlso 工程マスタ.SelectedRows.Count > 0 Then
            工程マスタ.CurrentRow.Selected = False
        End If
    End Sub
#End Region

#End Region

#Region "メソッド"

    Private Sub データ表示()
        Dim dt As New DataTable
        param.Clear()
        getParam(param)
        dt = logic.更新内容(param)

        Me.登録済データ.DataSource = Nothing
        If dt.Rows.Count = 0 Then Exit Sub
        Me.登録済データ.DataSource = dt
        Me.登録済データ.Columns(0).Width = 55
        Me.登録済データ.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.登録済データ.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.登録済データ.Columns(1).Width = 127
        Me.登録済データ.Columns(1).SortMode = Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.登録済データ.Columns(2).Width = 67
        Me.登録済データ.Columns(2).SortMode = Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.登録済データ.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.登録済データ.Columns(3).Visible = False
        Me.登録済データ.Columns(4).Visible = False
        Me.登録済データ.ClearSelection()
    End Sub

    Private Sub マスタ表示()
        Dim dt As New DataTable
        dt = logic.内容更新()

        If dt.Rows.Count = 0 Then
            Me.工程マスタ.DataSource = Nothing
            Exit Sub
        Else
            Me.工程マスタ.DataSource = dt
            Me.工程マスタ.Columns(0).Width = 55
            Me.工程マスタ.Columns(0).SortMode = Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.工程マスタ.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
            Me.工程マスタ.Columns(1).Width = 127
            Me.工程マスタ.Columns(1).SortMode = Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.工程マスタ.Columns(2).Width = 67
            Me.工程マスタ.Columns(2).SortMode = Windows.Forms.DataGridViewColumnSortMode.NotSortable
            Me.工程マスタ.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
            Me.工程マスタ.Columns(3).Visible = False
            Me.工程マスタ.ClearSelection()
        End If
    End Sub

    Private Function getParam(ByVal param As Habits.DB.DBParameter) As Habits.DB.DBParameter
        param.Add("@売上区分番号", Me.売上区分番号.Text)
        param.Add("@分類番号", Me.分類番号.Text)
        param.Add("@商品番号", Me.商品番号.Text)

        Return param
    End Function
#End Region

End Class