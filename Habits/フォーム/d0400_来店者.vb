''' <summary>d0400_来店者画面処理</summary>
''' <remarks></remarks>
Public Class d0400_来店者
    Private logic As Habits.Logic.d0400_logic

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub d0400_来店者_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        param.Add("@終了日", d0300_店集計.txtEndDay.Text)
        logic = New Habits.Logic.d0400_logic
        dt = logic.select_customer(param)
        ''来店者一覧へ表示
        Me.dgv来店者一覧.DataSource = dt
        Me.dgv来店者一覧.Columns(0).Width = 85      ''顧客番号
        Me.dgv来店者一覧.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv来店者一覧.Columns(1).Width = 90      ''氏名
        Me.dgv来店者一覧.Columns(2).Width = 70      ''性別
        Me.dgv来店者一覧.Columns(3).Width = 85      ''来店区分
        Me.dgv来店者一覧.Columns(4).Width = 70      ''指名
        Me.dgv来店者一覧.Columns(5).Width = 100     ''担当者名
        Me.dgv来店者一覧.Columns(6).Width = 82      ''支払
        Me.dgv来店者一覧.Columns(7).Width = 90      ''売上金額
        Me.dgv来店者一覧.Columns(7).DefaultCellStyle.Format = "#,##0"
        Me.dgv来店者一覧.Columns(7).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv来店者一覧.Columns(8).Width = 90      ''サービス
        Me.dgv来店者一覧.Columns(8).HeaderText = "(サービス)"
        Me.dgv来店者一覧.Columns(8).DefaultCellStyle.Format = "#,##0"
        Me.dgv来店者一覧.Columns(8).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv来店者一覧.Columns(9).Width = 87      ''消費税
        Me.dgv来店者一覧.Columns(9).DefaultCellStyle.Format = "#,##0"
        Me.dgv来店者一覧.Columns(9).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        'Me.dgv来店者一覧.Columns(10).Width = 90      ''税込
        'Me.dgv来店者一覧.Columns(10).DefaultCellStyle.Format = "#,##0"
        'Me.dgv来店者一覧.Columns(10).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv来店者一覧.Columns(10).Visible = False ''来店者番号
        'Me.dgv来店者一覧.Columns(11).Visible = False ''来店者番号

        LblDate.Text = d0300_店集計.txtEndDay.Text
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub d0400_来店者_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>閉じるボタンクリック処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub
#End Region

End Class