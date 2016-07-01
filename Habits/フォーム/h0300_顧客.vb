''' <summary>h0300_顧客画面処理</summary>
''' <remarks></remarks>
Public Class h0300_顧客
    Private logic As Habits.Logic.h0300_Logic
    Private iNumber As Integer = 0
    Private minDispNum As Integer = 25

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>
    ''' ロード時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub h0300_顧客_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        logic = New Habits.Logic.h0300_Logic
        dt = logic.selectMinMaxCustomerId()

        If dt.Rows.Count > 0 AndAlso Not dt.Rows(0).Item("最大顧客番号") Is System.DBNull.Value Then
            ''最小、最大顧客番号設定
            Me.lbl最小顧客番号.Text = dt.Rows(0).Item("最小顧客番号")
            Me.lbl最大顧客番号.Text = dt.Rows(0).Item("最大顧客番号")
            Me.lbl最小顧客番号_仮登録.Text = dt.Rows(0).Item("最小顧客番号_仮登録")
            Me.lbl最大顧客番号_仮登録.Text = dt.Rows(0).Item("最大顧客番号_仮登録")
            Me.lbl最小顧客番号_登録済.Text = dt.Rows(0).Item("最小顧客番号_登録済")
            Me.lbl最大顧客番号_登録済.Text = dt.Rows(0).Item("最大顧客番号_登録済")

            Me.txt開始顧客番号.Text = "1"
            ''表示件数リスト設定
            getDispNumList()

            ''登録区分リスト設定
            getRegKbnList()

            ''顧客一覧表示
            redisplay()

            Me.ActiveControl = Me.txt開始顧客番号
        Else
            rtn = MsgBox("顧客が登録されていません。    ", Clng_Okexb1, TTL)
            Me.Close()
        End If
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub h0300_顧客_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "戻るボタン押下"
    ''' <summary>
    ''' 戻るボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn戻る_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn戻る.Click
        ''再表示
        redisplay_Back()
    End Sub
#End Region

#Region "進むボタン押下"
    ''' <summary>
    ''' 進むボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn進む_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn進む.Click
        ''開始顧客番号設定
        txt開始顧客番号.Text = lbl_検索最大顧客番号.Text + 1
        ''終了顧客番号設定
        setEndNum()
        ''再表示
        redisplay()
    End Sub
#End Region

#Region "検索ボタン押下"
    ''' <summary>
    ''' 検索ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Search.Click
        If Not (input_check()) Then Exit Sub

        ''再表示
        redisplay()
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
        Me.Close()
    End Sub
#End Region

#End Region

    Private Sub txt開始顧客番号_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt開始顧客番号.KeyDown
        If (e.KeyData.Equals(System.Windows.Forms.Keys.Enter)) Then
            If Not (input_check()) Then Exit Sub
            ''終了顧客番号設定
            setEndNum()
        End If
    End Sub

    Private Sub cmd表示件数_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb表示件数.SelectedIndexChanged
        ''終了顧客番号設定
        setEndNum()
    End Sub

    Private Sub txt開始顧客番号_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt開始顧客番号.Leave
        If txt開始顧客番号.Text <> "" AndAlso Sys_InputCheck(Me.txt開始顧客番号.Text, 6, "N+", 1) = False Then
            If Integer.Parse(Me.txt開始顧客番号.Text) >= Integer.Parse(Me.lbl最大顧客番号.Text) Then
                Me.txt開始顧客番号.Text = Me.lbl最大顧客番号.Text
            End If
            ''終了顧客番号設定
            setEndNum()
        Else
            Me.lbl終了顧客番号.Text = ""
        End If
    End Sub

#Region "メソッド"

#Region "入力チェック"
    ''' <summary>
    ''' 入力チェック
    ''' </summary>
    ''' <returns>True：正常、False：エラー</returns>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        input_check = False

        If Sys_InputCheck(Me.txt開始顧客番号.Text, 6, "N+", 1) Then
            Call Sys_Error("顧客番号 は半角数字で入力してください。　", Me.txt開始顧客番号)
            Exit Function
        End If
        If Sys_InputCheck(Me.lbl終了顧客番号.Text, 6, "N+", 1) Then
            Call Sys_Error("顧客番号 が不正です。　", Me.lbl終了顧客番号)
            Exit Function
        End If
        input_check = True
    End Function
#End Region

#Region "顧客一覧取得"
    ''' <summary>
    ''' 顧客一覧取得
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub redisplay()
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        Dim num As String = minDispNum.ToString

        '検索開始番号設定
        If Me.lbl_検索最大顧客番号.Text = "" Then
            iNumber = 0
        Else
            iNumber = Me.txt開始顧客番号.Text
        End If
        param.Add("@検索開始番号", iNumber)

        '検索終了番号設定
        If Me.lbl最大顧客番号.Text = "" Then
            iNumber = Clng_STFreeNo - 1
        Else
            iNumber = lbl最大顧客番号.Text
        End If
        param.Add("@検索終了番号", iNumber)

        '検索数設定
        num = Me.cmb表示件数.SelectedValue.ToString

        Try
            ''顧客一覧取得
            dt = logic.select_customerinfo(param, num, cmbReg.SelectedValue, True)

            Me.dgv一覧.DataSource = dt
            If dt.Rows.Count > 0 Then
                ''顧客一覧の設定
                setDgvDefault()
                Me.lbl_検索最大顧客番号.Text = dt.Rows(dt.Rows.Count - 1)("番号")
            Else
                Me.lbl_検索最大顧客番号.Text = ""
            End If

            ''戻る・進むボタン設定
            setGoBackBtn()

        Catch ex As Exception
            Sys_Error("顧客番号が不正です。　", Me.txt開始顧客番号)
            Exit Sub
        End Try
    End Sub
#End Region

#Region "前頁表示処理"
    ''' <summary>
    ''' 前頁表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub redisplay_Back()
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        Dim num As String = minDispNum.ToString

        If Me.lbl_検索最大顧客番号.Text = "" Then
            iNumber = 0
        Else
            iNumber = Me.txt開始顧客番号.Text
        End If
        param.Add("@検索開始番号", iNumber)

        num = Me.cmb表示件数.SelectedItem(0).ToString
        Try
            dt = logic.select_customerinfo(param, num, cmbReg.SelectedValue, False)
            If dt.Rows.Count > 0 Then
                Me.dgv一覧.DataSource = dt
                ' 顧客一覧の設定
                setDgvDefault()

                Me.txt開始顧客番号.Text = dt.Rows(dt.Rows.Count - 1)("番号")
                Me.lbl_検索最大顧客番号.Text = dt.Rows(0)("番号")
            Else
                Me.lbl_検索最大顧客番号.Text = 0
            End If

            ''戻る・進むボタン設定
            setGoBackBtn()

        Catch ex As Exception
            Sys_Error("顧客番号が不正です。　", Me.txt開始顧客番号)
            Exit Sub
        End Try

    End Sub
#End Region

#Region "一覧の設定値設定"
    ''' <summary>
    ''' 顧客一覧の表示設定値の設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setDgvDefault()
        ' 顧客番号
        Me.dgv一覧.Columns(0).Width = 65
        Me.dgv一覧.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.TopRight
        '氏名
        Me.dgv一覧.Columns(1).Width = 100
        Me.dgv一覧.Columns(1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.TopLeft
        'カナ
        Me.dgv一覧.Columns(2).Width = 100
        Me.dgv一覧.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.TopLeft
        '性別
        Me.dgv一覧.Columns(3).Width = 65
        Me.dgv一覧.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.TopLeft
        '生年月日
        Me.dgv一覧.Columns(4).Width = 85
        Me.dgv一覧.Columns(4).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.TopLeft
        '郵便番号
        Me.dgv一覧.Columns(5).Width = 70
        Me.dgv一覧.Columns(5).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.TopCenter
        '都道
        Me.dgv一覧.Columns(6).Width = 85
        Me.dgv一覧.Columns(6).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.TopLeft
        '住所
        Me.dgv一覧.Columns(7).Width = 244
        Me.dgv一覧.Columns(7).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.TopLeft
        '電話番号
        Me.dgv一覧.Columns(8).Width = 85
        Me.dgv一覧.Columns(8).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.TopLeft
        Me.dgv一覧.Columns(9).Visible = False
        Me.dgv一覧.Sort(Me.dgv一覧.Columns(0), ComponentModel.ListSortDirection.Ascending)
    End Sub
#End Region

#Region "表示件数設定"
    ''' <summary>
    ''' 表示件数設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getDispNumList()
        Me.cmb表示件数.Items.Clear()
        Dim dt As New DataTable
        dt.Columns.Add("num")
        dt.Columns.Add("display")

        dt.Rows.Add(minDispNum.ToString, minDispNum.ToString & "件表示")
        dt.Rows.Add("100", "100件表示")
        dt.Rows.Add("200", "200件表示")
        dt.Rows.Add("500", "500件表示")
        dt.Rows.Add("1000", "1000件表示")
        dt.Rows.Add("2000", "2000件表示")
        dt.Rows.Add("3000", "3000件表示")
        Me.cmb表示件数.DataSource = dt
        Me.cmb表示件数.DisplayMember = "display"
        Me.cmb表示件数.ValueMember = "num"
        Me.cmb表示件数.SelectedIndex = 0
    End Sub
#End Region

#Region "登録区分設定"
    ''' <summary>
    ''' 登録区分設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getRegKbnList()
        Me.cmbReg.Items.Clear()
        Dim dt As New DataTable
        dt = logic.SelectedDivision()
        Me.cmbReg.DataSource = dt
        Me.cmbReg.DisplayMember = "登録区分"
        Me.cmbReg.ValueMember = "登録区分番号"
        Me.cmbReg.SelectedIndex = 0
    End Sub
#End Region

#Region "終了顧客番号設定"
    ''' <summary>
    ''' 終了顧客番号設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setEndNum()
        If ((Integer.Parse(txt開始顧客番号.Text) + Integer.Parse(Me.cmb表示件数.SelectedItem(0).ToString) - 1) < Clng_STFreeNo _
        AndAlso (Integer.Parse(txt開始顧客番号.Text) + Integer.Parse(Me.cmb表示件数.SelectedItem(0).ToString) - 1) < lbl最大顧客番号.Text) Then
            lbl終了顧客番号.Text = Integer.Parse(txt開始顧客番号.Text) + Integer.Parse(Me.cmb表示件数.SelectedItem(0).ToString) - 1
        Else
            lbl終了顧客番号.Text = lbl最大顧客番号.Text
        End If
    End Sub
#End Region

#Region "戻る進むボタン設定"
    ''' <summary>
    ''' 戻る・進むボタン設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setGoBackBtn()

        ''戻るボタンの設定
        Me.btn戻る.Enabled = True

        Select Case cmbReg.SelectedValue.ToString
            Case 0              '仮登録
                If (Not IsNumeric(txt開始顧客番号.Text) OrElse Not IsNumeric(lbl最小顧客番号_仮登録.Text) OrElse _
                    (Integer.Parse(txt開始顧客番号.Text) <= Integer.Parse(lbl最小顧客番号_仮登録.Text))) Then
                    Me.btn戻る.Enabled = False
                End If

            Case 1              '登録済
                If (Not IsNumeric(txt開始顧客番号.Text) OrElse Not IsNumeric(lbl最小顧客番号_登録済.Text) OrElse _
                    (Integer.Parse(txt開始顧客番号.Text) <= Integer.Parse(lbl最小顧客番号_登録済.Text))) Then
                    Me.btn戻る.Enabled = False
                End If

            Case Else           '全て
                If (Not IsNumeric(txt開始顧客番号.Text) OrElse Not IsNumeric(lbl最小顧客番号.Text) OrElse _
                    (Integer.Parse(txt開始顧客番号.Text) <= Integer.Parse(lbl最小顧客番号.Text))) Then
                    Me.btn戻る.Enabled = False
                End If
        End Select

        ''進むボタンの設定
        Me.btn進む.Enabled = True

        Select Case cmbReg.SelectedValue.ToString
            Case 0              '仮登録
                If (Not IsNumeric(lbl_検索最大顧客番号.Text) OrElse Not IsNumeric(lbl最大顧客番号_仮登録.Text) OrElse _
                    (Integer.Parse(lbl_検索最大顧客番号.Text) >= Integer.Parse(lbl最大顧客番号_仮登録.Text))) Then
                    Me.btn進む.Enabled = False
                End If

            Case 1              '登録済
                If (Not IsNumeric(lbl_検索最大顧客番号.Text) OrElse Not IsNumeric(lbl最大顧客番号_登録済.Text) OrElse _
                    (Integer.Parse(lbl_検索最大顧客番号.Text) >= Integer.Parse(lbl最大顧客番号_登録済.Text))) Then
                    Me.btn進む.Enabled = False
                End If

            Case Else           '全て
                If (Not IsNumeric(lbl_検索最大顧客番号.Text) OrElse Not IsNumeric(lbl最大顧客番号.Text) OrElse _
                    (Integer.Parse(lbl_検索最大顧客番号.Text) >= Integer.Parse(lbl最大顧客番号.Text))) Then
                    Me.btn進む.Enabled = False
                End If
        End Select

    End Sub
#End Region

#End Region

End Class
