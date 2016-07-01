'システム名 ： HABITS
'機能名　　 ： a1400_入出庫
'概要　　　 ： 入出庫情報の商品選択機能
'履歴　　　 ： 2010/05/12　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a1400_入出庫
    Private SelectionChangeLocked_dgv売上区分 As Boolean = False
    Private SelectionChangeLocked_dgv分類 As Boolean = False
    Private SelectionChangeLocked_dgvメーカー As Boolean = False
    Private SelectionChangeLocked_dgv商品 As Boolean = False

    Private logic As Habits.Logic.a1400_Logic
    Private c0400_logic As Habits.Logic.c0400_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1400_入出庫_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '' ロジッククラス生成
        logic = New Habits.Logic.a1400_Logic
        ''画面再描画処理
        ReDisplay()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1400_入出庫_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

    Private Sub dgv売上区分_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv売上区分.SelectionChanged
        If Not SelectionChangeLocked_dgv売上区分 Then 'DataSource設定後に先頭行が初期選択された場合は無視する
            '売上区分選択再表示
            ReDisplay_分類()
        End If
    End Sub

    Private Sub dgv分類_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv分類.SelectionChanged
        If Not SelectionChangeLocked_dgv分類 Then 'DataSource設定後に先頭行が初期選択された場合は無視する
            '分類選択再表示
            ReDisplay_メーカー()
        End If
    End Sub

    Private Sub dgvメーカー_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvメーカー.SelectionChanged
        If Not SelectionChangeLocked_dgvメーカー Then 'DataSource設定後に先頭行が初期選択された場合は無視する
            '商品選択再表示
            ReDisplay_商品()
        End If
    End Sub

    Private Sub btn選択_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn選択.Click
        If Me.dgv商品.SelectedRows.Count <> 0 Then
            a1400_入出庫登録.Initial_売上区分番号 = Me.dgv売上区分.SelectedRows(0).Cells("売上区分番号").Value.ToString
            a1400_入出庫登録.Initial_売上区分 = Me.dgv売上区分.SelectedRows(0).Cells("売上区分").Value.ToString
            a1400_入出庫登録.Initial_分類番号 = Me.dgv分類.SelectedRows(0).Cells("分類番号").Value.ToString
            a1400_入出庫登録.Initial_分類名 = Me.dgv分類.SelectedRows(0).Cells("分類名").Value.ToString
            a1400_入出庫登録.Initial_メーカー番号 = Me.dgvメーカー.SelectedRows(0).Cells("メーカー番号").Value.ToString
            a1400_入出庫登録.Initial_メーカー名 = Me.dgvメーカー.SelectedRows(0).Cells("メーカー名").Value.ToString
            a1400_入出庫登録.Initial_商品番号 = Me.dgv商品.SelectedRows(0).Cells("番号").Value.ToString
            a1400_入出庫登録.Initial_商品名 = Me.dgv商品.SelectedRows(0).Cells("商品名").Value.ToString
            Me.Close()
        Else
            Call Sys_Error("商品 を選択してください。　", Me.dgv商品)
        End If
    End Sub

    Private Sub dgv商品_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv商品.DoubleClick
        If Me.dgv商品.SelectedRows.Count <> 0 Then
            a1400_入出庫登録.Initial_売上区分番号 = Me.dgv売上区分.SelectedRows(0).Cells("売上区分番号").Value.ToString
            a1400_入出庫登録.Initial_売上区分 = Me.dgv売上区分.SelectedRows(0).Cells("売上区分").Value.ToString
            a1400_入出庫登録.Initial_分類番号 = Me.dgv分類.SelectedRows(0).Cells("分類番号").Value.ToString
            a1400_入出庫登録.Initial_分類名 = Me.dgv分類.SelectedRows(0).Cells("分類名").Value.ToString
            a1400_入出庫登録.Initial_メーカー番号 = Me.dgvメーカー.SelectedRows(0).Cells("メーカー番号").Value.ToString
            a1400_入出庫登録.Initial_メーカー名 = Me.dgvメーカー.SelectedRows(0).Cells("メーカー名").Value.ToString
            a1400_入出庫登録.Initial_商品番号 = Me.dgv商品.SelectedRows(0).Cells("番号").Value.ToString
            a1400_入出庫登録.Initial_商品名 = Me.dgv商品.SelectedRows(0).Cells("商品名").Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub 項目クリア_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 項目クリア.Click
        Clear_項目()
    End Sub

    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub

    Private Sub dgv売上区分_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgv売上区分.DataBindingComplete
        Me.dgv売上区分.ClearSelection()
        SelectionChangeLocked_dgv売上区分 = False
    End Sub

    Private Sub dgv分類_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgv分類.DataBindingComplete
        Me.dgv分類.ClearSelection()
        SelectionChangeLocked_dgv分類 = False
    End Sub

    Private Sub dgvメーカー_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvメーカー.DataBindingComplete
        Me.dgvメーカー.ClearSelection()
        SelectionChangeLocked_dgvメーカー = False
    End Sub

    Private Sub dgv商品_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgv商品.DataBindingComplete
        Me.dgv商品.ClearSelection()
        SelectionChangeLocked_dgv商品 = False
    End Sub

#End Region

#Region "メソッド"

    ''' <summary>
    ''' 画面再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay()
        '売上区分選択表示
        ReDisplay_売上区分選択()

    End Sub

    ''' <summary>
    ''' 売上区分選択再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_売上区分選択()
        Dim dt As DataTable

        '売上区分名一覧取得
        dt = logic.GetSalesDivisionNames()

        '売上区分：コンボボックス表示
        SelectionChangeLocked_dgv売上区分 = True
        Me.dgv売上区分.DataSource = dt

        Me.dgv売上区分.Columns("売上区分番号").Visible = False

        Me.dgv売上区分.Columns("売上区分").Visible = True
        Me.dgv売上区分.Columns("売上区分").Width = 191

        Me.dgv売上区分.Enabled = True

        If Me.dgv売上区分.RowCount = 1 Then
            '選択項目が1つの場合は自動選択
            Me.dgv売上区分.Rows(0).Selected = True
        Else
            Me.dgv分類.DataSource = Nothing
            Me.dgvメーカー.DataSource = Nothing
            Me.dgv商品.DataSource = Nothing
        End If
    End Sub

    ''' <summary>
    ''' 分類再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_分類()
        Dim dt As DataTable
        Dim var_int As Integer

        If Me.dgv売上区分.SelectedRows.Count > 0 Then
            '分類名一覧取得
            var_int = Integer.Parse(Me.dgv売上区分.SelectedRows(0).Cells("売上区分番号").Value.ToString)
            dt = logic.GetCommodityDivisionNames(var_int.ToString)

            '分類選択表示
            SelectionChangeLocked_dgv分類 = True
            Me.dgv分類.DataSource = dt

            Me.dgv分類.Columns("分類番号").Visible = False

            Me.dgv分類.Columns("分類名").Visible = True
            Me.dgv分類.Columns("分類名").Width = 191

            Me.dgv分類.Enabled = True
        Else
            Me.dgv分類.DataSource = Nothing
            Me.dgv分類.Enabled = False
        End If

        If Me.dgv分類.RowCount = 1 Then
            '選択項目が1つの場合は自動選択
            Me.dgv分類.Rows(0).Selected = True
        Else
            Me.dgvメーカー.DataSource = Nothing
            Me.dgv商品.DataSource = Nothing
        End If
    End Sub

    ''' <summary>
    ''' メーカー再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_メーカー()
        Dim dt As DataTable
        Dim param As New Habits.DB.DBParameter

        If Me.dgv分類.SelectedRows.Count > 0 Then
            'メーカー名一覧取得
            param.Add("@売上区分番号", Me.dgv売上区分.SelectedRows(0).Cells("売上区分番号").Value)
            param.Add("@分類番号", Me.dgv分類.SelectedRows(0).Cells("分類番号").Value)

            dt = logic.GetBrandNames(param)

            'メーカー選択表示
            SelectionChangeLocked_dgvメーカー = True
            Me.dgvメーカー.DataSource = dt

            Me.dgvメーカー.Columns("メーカー番号").Visible = False

            Me.dgvメーカー.Columns("メーカー名").Visible = True
            Me.dgvメーカー.Columns("メーカー名").Width = 191

            Me.dgvメーカー.Enabled = True
        Else
            Me.dgvメーカー.DataSource = Nothing
            Me.dgvメーカー.Enabled = False
        End If

        If Me.dgvメーカー.RowCount = 1 Then
            '選択項目が1つの場合は自動選択
            Me.dgvメーカー.Rows(0).Selected = True
        Else
            Me.dgv商品.DataSource = Nothing
        End If
    End Sub

    ''' <summary>
    ''' 商品再表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay_商品()
        Dim dt As DataTable
        Dim param As Habits.DB.DBParameter

        If Me.dgvメーカー.SelectedRows.Count > 0 Then
            param = New Habits.DB.DBParameter
            param.Add("@売上区分番号", Me.dgv売上区分.SelectedRows(0).Cells("売上区分番号").Value)
            param.Add("@分類番号", Me.dgv分類.SelectedRows(0).Cells("分類番号").Value)
            param.Add("@メーカー番号", Me.dgvメーカー.SelectedRows(0).Cells("メーカー番号").Value)

            '商品一覧取得
            dt = logic.GetCommodityList(param)

            '商品選択表示
            SelectionChangeLocked_dgv商品 = True
            Me.dgv商品.DataSource = dt

            Me.dgv商品.Columns("番号").Width = 60
            Me.dgv商品.Columns("番号").Visible = True
            Me.dgv商品.Columns("番号").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight

            Me.dgv商品.Columns("商品名").Width = 150
            Me.dgv商品.Columns("商品名").Visible = True
            Me.dgv商品.Columns("商品名").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft

            Me.dgv商品.Columns("在庫数").Width = 77
            Me.dgv商品.Columns("在庫数").Visible = True
            Me.dgv商品.Columns("在庫数").DefaultCellStyle.Format = "#,##0"
            Me.dgv商品.Columns("在庫数").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight

            Me.dgv商品.Columns("最新入出庫日").Width = 112
            Me.dgv商品.Columns("最新入出庫日").Visible = True
            Me.dgv商品.Columns("最新入出庫日").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight

            Me.dgv商品.Columns("入出庫番号").Visible = False

            Me.dgv商品.Columns("スタッフ名").Width = 90
            Me.dgv商品.Columns("スタッフ名").Visible = True
            Me.dgv商品.Columns("スタッフ名").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft

            Me.dgv商品.Columns("入出庫").Width = 80
            Me.dgv商品.Columns("入出庫").Visible = True
            Me.dgv商品.Columns("入出庫").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft

            Me.dgv商品.Columns("理由").Width = 80
            Me.dgv商品.Columns("理由").Visible = True
            Me.dgv商品.Columns("理由").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft

            Me.dgv商品.Columns("コメント").Width = 204
            Me.dgv商品.Columns("コメント").Visible = True
            Me.dgv商品.Columns("コメント").DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft

            Me.dgv商品.Enabled = True
        Else
            Me.dgv商品.DataSource = Nothing
            Me.dgv商品.Enabled = False
        End If
        If Me.dgv商品.RowCount = 1 Then
            '選択項目が1つの場合は自動選択
            Me.dgv商品.Rows(0).Selected = True
        Else
            Me.dgv商品.ClearSelection()
        End If

    End Sub

    ''' <summary>
    ''' 選択クリア処理
    ''' </summary>
    ''' <remarks></remarks>
    Protected Friend Sub Clear_項目()
        Me.dgv売上区分.ClearSelection()
    End Sub
#End Region
End Class