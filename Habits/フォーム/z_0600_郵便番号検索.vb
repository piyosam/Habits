'システム名 ： HABITS
'機能名　　 ： z_0600_郵便番号検索
'概要　　　 ： 住所から郵便番号を検索する機能
'履歴　　　 ： 2010/06/14　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.Imports System.Data
Public Class z_0600_郵便番号検索

    Dim i As Integer
    Public z_0600_郵便番号検索_loaded As Integer
    Private logic As Habits.Logic.z0600_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>
    ''' ロード時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub z_共通_郵便番号検索_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''デフォルトで設定する都道府県、市区町村をA_システムより抽出
        Dim select_TOD, select_ASY As New DataTable
        Dim logic As New Habits.Logic.z0600_Logic
        select_ASY = logic.select_ASY()
        If select_ASY.Rows.Count > 0 Then

            select_TOD = logic.select_都道府県名()
            If select_TOD.Rows.Count > 0 Then
                Me.都道府県.Items.Clear()
                For i = 1 To select_TOD.Rows.Count
                    Me.都道府県.Items.Add(select_TOD.Rows(i - 1)("都道府県名"))
                Next i

                Me.都道府県.Text = select_ASY.Rows(0)("都道府県")   ''デフォルトのデータを初期に設定
                Me.市区町村.Text = select_ASY.Rows(0)("市区町村")   ''デフォルトのデータを初期に設定
                Me.TabControl1.SelectedIndex = 0                    ''初期にあ行が表示される
            Else
                MsgBox("郵便番号が登録されていません。　", Clng_Okexb1, TTL)
                Me.Close()
            End If
        Else
            MsgBox("店舗の登録に不備があります。　", Clng_Okexb1, TTL)
            Me.Close()
        End If
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <remarks></remarks>
    Private Sub z_0600_郵便番号検索_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

    Private Sub 選択_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 選択.Click
        setpostnumber()
    End Sub

    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub

    Private Sub 都道府県_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 都道府県.SelectedIndexChanged
        ''都道府県名を抽出
        Dim select_SHI As New DataTable
        Dim param As New Habits.DB.DBParameter
        param.Add("@都道府県名", Me.都道府県.SelectedItem.ToString)
        Dim logic As New Habits.Logic.z0600_Logic
        select_SHI = logic.select_市区町村名(param)
        Me.市区町村.Items.Clear()
        For i = 1 To select_SHI.Rows.Count
            Me.市区町村.Items.Add(select_SHI.Rows(i - 1)("市区町村名"))
        Next
        Me.市区町村.SelectedIndex = 0
    End Sub

    Private Sub 市区町村_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 市区町村.SelectedIndexChanged, TabControl1.SelectedIndexChanged
        Select Case Me.TabControl1.SelectedIndex
            Case 0
                select_postnumber(Me.市区町村.SelectedItem.ToString, "[ｱ-ｵ]%", 0)
            Case 1
                select_postnumber(Me.市区町村.SelectedItem.ToString, "[ｶ-ｺﾞ]%", 1)
            Case 2
                select_postnumber(Me.市区町村.SelectedItem.ToString, "[ｻ-ｿﾞ]%", 2)
            Case 3
                select_postnumber(Me.市区町村.SelectedItem.ToString, "[ﾀ-ﾄﾞ]%", 3)
            Case 4
                select_postnumber(Me.市区町村.SelectedItem.ToString, "[ﾅ-ﾉ]%", 4)
            Case 5
                select_postnumber(Me.市区町村.SelectedItem.ToString, "[ﾊ-ﾎﾟ]%", 5)
            Case 6
                select_postnumber(Me.市区町村.SelectedItem.ToString, "[ﾏ-ﾓ]%", 6)
            Case 7
                select_postnumber(Me.市区町村.SelectedItem.ToString, "[ﾔ-ﾖ]%", 7)
            Case 8
                select_postnumber(Me.市区町村.SelectedItem.ToString, "[ﾗ-ﾛ]%", 8)
            Case 9
                select_postnumber(Me.市区町村.SelectedItem.ToString, "[ﾜ-ﾝ]%", 9)
            Case 10
                select_postnumber(Me.市区町村.SelectedItem.ToString, "[*]%", 10)
        End Select
    End Sub
#End Region

#Region "ダブルクリックイベント"

    Private Sub dgv町域名0_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv町域名0.CellDoubleClick
        setpostnumber()
    End Sub

    Private Sub dgv町域名1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv町域名1.DoubleClick
        setpostnumber()
    End Sub

    Private Sub dgv町域名2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv町域名2.DoubleClick
        setpostnumber()
    End Sub

    Private Sub dgv町域名3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv町域名3.DoubleClick
        setpostnumber()
    End Sub

    Private Sub dgv町域名4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv町域名4.DoubleClick
        setpostnumber()
    End Sub

    Private Sub dgv町域名5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv町域名5.DoubleClick
        setpostnumber()
    End Sub

    Private Sub dgv町域名6_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv町域名6.DoubleClick
        setpostnumber()
    End Sub

    Private Sub dgv町域名7_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv町域名7.DoubleClick
        setpostnumber()
    End Sub

    Private Sub dgv町域名8_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv町域名8.DoubleClick
        setpostnumber()
    End Sub

    Private Sub dgv町域名9_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv町域名9.DoubleClick
        setpostnumber()
    End Sub

    Private Sub dgv町域名10_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv町域名10.DoubleClick
        setpostnumber()
    End Sub

#End Region

#Region "メソッド"

    Private Sub select_postnumber(ByVal str_shi As String, ByVal str_initial As String, ByVal int_number As Integer)
        ''各頭文字の町域名、郵便番号を抽出し、各タブに表示
        Dim select_YUU As New DataTable
        Dim param As New Habits.DB.DBParameter
        Dim logic As New Habits.Logic.z0600_Logic
        param.Add("@市区町村名", str_shi)
        param.Add("@頭文字", str_initial)
        select_YUU = logic.select_YUU(param)

        Select Case int_number
            Case 0
                Me.dgv町域名0.DataSource = select_YUU
                Me.dgv町域名0.Columns(0).Width = 65
                Me.dgv町域名0.Columns(1).Width = 348
            Case 1
                Me.dgv町域名1.DataSource = select_YUU
                Me.dgv町域名1.Columns(0).Width = 65
                Me.dgv町域名1.Columns(1).Width = 348
            Case 2
                Me.dgv町域名2.DataSource = select_YUU
                Me.dgv町域名2.Columns(0).Width = 65
                Me.dgv町域名2.Columns(1).Width = 348
            Case 3
                Me.dgv町域名3.DataSource = select_YUU
                Me.dgv町域名3.Columns(0).Width = 65
                Me.dgv町域名3.Columns(1).Width = 348
            Case 4
                Me.dgv町域名4.DataSource = select_YUU
                Me.dgv町域名4.Columns(0).Width = 65
                Me.dgv町域名4.Columns(1).Width = 348
            Case 5
                Me.dgv町域名5.DataSource = select_YUU
                Me.dgv町域名5.Columns(0).Width = 65
                Me.dgv町域名5.Columns(1).Width = 348
            Case 6
                Me.dgv町域名6.DataSource = select_YUU
                Me.dgv町域名6.Columns(0).Width = 65
                Me.dgv町域名6.Columns(1).Width = 348
            Case 7
                Me.dgv町域名7.DataSource = select_YUU
                Me.dgv町域名7.Columns(0).Width = 65
                Me.dgv町域名7.Columns(1).Width = 348
            Case 8
                Me.dgv町域名8.DataSource = select_YUU
                Me.dgv町域名8.Columns(0).Width = 65
                Me.dgv町域名8.Columns(1).Width = 348
            Case 9
                Me.dgv町域名9.DataSource = select_YUU
                Me.dgv町域名9.Columns(0).Width = 65
                Me.dgv町域名9.Columns(1).Width = 348
            Case 10
                Me.dgv町域名10.DataSource = select_YUU
                Me.dgv町域名10.Columns(0).Width = 65
                Me.dgv町域名10.Columns(1).Width = 348
        End Select
    End Sub

    Private Sub setpostnumber()
        Select Case Me.TabControl1.SelectedIndex
            Case 0
                If (z_0600_郵便番号検索_loaded = 0) Then
                    If Me.dgv町域名0.SelectedRows.Count = 0 Then Exit Sub
                    z_0500_顧客変更.郵便番号.Text = Me.dgv町域名0.SelectedRows(0).Cells(0).Value
                    z_0500_顧客変更.住所２.Text = Me.dgv町域名0.SelectedRows(0).Cells(1).Value

                ElseIf (z_0600_郵便番号検索_loaded = 1) Then
                    If Me.dgv町域名0.SelectedRows.Count = 0 Then Exit Sub

                ElseIf (z_0600_郵便番号検索_loaded = 2) Then
                    If Me.dgv町域名0.SelectedRows.Count = 0 Then Exit Sub
                    f0100_顧客登録.郵便番号.Text = Me.dgv町域名0.SelectedRows(0).Cells(0).Value
                    f0100_顧客登録.住所２.Text = Me.dgv町域名0.SelectedRows(0).Cells(1).Value
                End If

            Case 1
                If (z_0600_郵便番号検索_loaded = 0) Then
                    If Me.dgv町域名1.SelectedRows.Count = 0 Then Exit Sub
                    z_0500_顧客変更.郵便番号.Text = Me.dgv町域名1.SelectedRows(0).Cells(0).Value
                    z_0500_顧客変更.住所２.Text = Me.dgv町域名1.SelectedRows(0).Cells(1).Value

                ElseIf (z_0600_郵便番号検索_loaded = 1) Then
                    If Me.dgv町域名1.SelectedRows.Count = 0 Then Exit Sub

                ElseIf (z_0600_郵便番号検索_loaded = 2) Then
                    If Me.dgv町域名1.SelectedRows.Count = 0 Then Exit Sub
                    f0100_顧客登録.郵便番号.Text = Me.dgv町域名1.SelectedRows(0).Cells(0).Value
                    f0100_顧客登録.住所２.Text = Me.dgv町域名1.SelectedRows(0).Cells(1).Value
                End If

            Case 2
                If (z_0600_郵便番号検索_loaded = 0) Then
                    If Me.dgv町域名2.SelectedRows.Count = 0 Then Exit Sub
                    z_0500_顧客変更.郵便番号.Text = Me.dgv町域名2.SelectedRows(0).Cells(0).Value
                    z_0500_顧客変更.住所２.Text = Me.dgv町域名2.SelectedRows(0).Cells(1).Value

                ElseIf (z_0600_郵便番号検索_loaded = 1) Then
                    If Me.dgv町域名2.SelectedRows.Count = 0 Then Exit Sub

                ElseIf (z_0600_郵便番号検索_loaded = 2) Then
                    If Me.dgv町域名2.SelectedRows.Count = 0 Then Exit Sub
                    f0100_顧客登録.郵便番号.Text = Me.dgv町域名2.SelectedRows(0).Cells(0).Value
                    f0100_顧客登録.住所２.Text = Me.dgv町域名2.SelectedRows(0).Cells(1).Value
                End If

            Case 3
                If (z_0600_郵便番号検索_loaded = 0) Then
                    If Me.dgv町域名3.SelectedRows.Count = 0 Then Exit Sub
                    z_0500_顧客変更.郵便番号.Text = Me.dgv町域名3.SelectedRows(0).Cells(0).Value
                    z_0500_顧客変更.住所２.Text = Me.dgv町域名3.SelectedRows(0).Cells(1).Value

                ElseIf (z_0600_郵便番号検索_loaded = 1) Then
                    If Me.dgv町域名3.SelectedRows.Count = 0 Then Exit Sub

                ElseIf (z_0600_郵便番号検索_loaded = 2) Then
                    If Me.dgv町域名3.SelectedRows.Count = 0 Then Exit Sub
                    f0100_顧客登録.郵便番号.Text = Me.dgv町域名3.SelectedRows(0).Cells(0).Value
                    f0100_顧客登録.住所２.Text = Me.dgv町域名3.SelectedRows(0).Cells(1).Value
                End If

            Case 4
                If (z_0600_郵便番号検索_loaded = 0) Then
                    If Me.dgv町域名4.SelectedRows.Count = 0 Then Exit Sub
                    z_0500_顧客変更.郵便番号.Text = Me.dgv町域名4.SelectedRows(0).Cells(0).Value
                    z_0500_顧客変更.住所２.Text = Me.dgv町域名4.SelectedRows(0).Cells(1).Value

                ElseIf (z_0600_郵便番号検索_loaded = 1) Then
                    If Me.dgv町域名4.SelectedRows.Count = 0 Then Exit Sub

                ElseIf (z_0600_郵便番号検索_loaded = 2) Then
                    If Me.dgv町域名4.SelectedRows.Count = 0 Then Exit Sub
                    f0100_顧客登録.郵便番号.Text = Me.dgv町域名4.SelectedRows(0).Cells(0).Value
                    f0100_顧客登録.住所２.Text = Me.dgv町域名4.SelectedRows(0).Cells(1).Value
                End If

            Case 5
                If (z_0600_郵便番号検索_loaded = 0) Then
                    If Me.dgv町域名5.SelectedRows.Count = 0 Then Exit Sub
                    z_0500_顧客変更.郵便番号.Text = Me.dgv町域名5.SelectedRows(0).Cells(0).Value
                    z_0500_顧客変更.住所２.Text = Me.dgv町域名5.SelectedRows(0).Cells(1).Value

                ElseIf (z_0600_郵便番号検索_loaded = 1) Then
                    If Me.dgv町域名5.SelectedRows.Count = 0 Then Exit Sub

                ElseIf (z_0600_郵便番号検索_loaded = 2) Then
                    If Me.dgv町域名5.SelectedRows.Count = 0 Then Exit Sub
                    f0100_顧客登録.郵便番号.Text = Me.dgv町域名5.SelectedRows(0).Cells(0).Value
                    f0100_顧客登録.住所２.Text = Me.dgv町域名5.SelectedRows(0).Cells(1).Value
                End If

            Case 6
                If (z_0600_郵便番号検索_loaded = 0) Then
                    If Me.dgv町域名6.SelectedRows.Count = 0 Then Exit Sub
                    z_0500_顧客変更.郵便番号.Text = Me.dgv町域名6.SelectedRows(0).Cells(0).Value
                    z_0500_顧客変更.住所２.Text = Me.dgv町域名6.SelectedRows(0).Cells(1).Value

                ElseIf (z_0600_郵便番号検索_loaded = 1) Then
                    If Me.dgv町域名6.SelectedRows.Count = 0 Then Exit Sub

                ElseIf (z_0600_郵便番号検索_loaded = 2) Then
                    If Me.dgv町域名6.SelectedRows.Count = 0 Then Exit Sub
                    f0100_顧客登録.郵便番号.Text = Me.dgv町域名6.SelectedRows(0).Cells(0).Value
                    f0100_顧客登録.住所２.Text = Me.dgv町域名6.SelectedRows(0).Cells(1).Value
                End If

            Case 7
                If (z_0600_郵便番号検索_loaded = 0) Then
                    If Me.dgv町域名7.SelectedRows.Count = 0 Then Exit Sub
                    z_0500_顧客変更.郵便番号.Text = Me.dgv町域名7.SelectedRows(0).Cells(0).Value
                    z_0500_顧客変更.住所２.Text = Me.dgv町域名7.SelectedRows(0).Cells(1).Value

                ElseIf (z_0600_郵便番号検索_loaded = 1) Then
                    If Me.dgv町域名7.SelectedRows.Count = 0 Then Exit Sub

                ElseIf (z_0600_郵便番号検索_loaded = 2) Then
                    If Me.dgv町域名7.SelectedRows.Count = 0 Then Exit Sub
                    f0100_顧客登録.郵便番号.Text = Me.dgv町域名7.SelectedRows(0).Cells(0).Value
                    f0100_顧客登録.住所２.Text = Me.dgv町域名7.SelectedRows(0).Cells(1).Value
                End If

            Case 8
                If (z_0600_郵便番号検索_loaded = 0) Then
                    If Me.dgv町域名8.SelectedRows.Count = 0 Then Exit Sub
                    z_0500_顧客変更.郵便番号.Text = Me.dgv町域名8.SelectedRows(0).Cells(0).Value
                    z_0500_顧客変更.住所２.Text = Me.dgv町域名8.SelectedRows(0).Cells(1).Value

                ElseIf (z_0600_郵便番号検索_loaded = 1) Then
                    If Me.dgv町域名8.SelectedRows.Count = 0 Then Exit Sub

                ElseIf (z_0600_郵便番号検索_loaded = 2) Then
                    If Me.dgv町域名8.SelectedRows.Count = 0 Then Exit Sub
                    f0100_顧客登録.郵便番号.Text = Me.dgv町域名8.SelectedRows(0).Cells(0).Value
                    f0100_顧客登録.住所２.Text = Me.dgv町域名8.SelectedRows(0).Cells(1).Value
                End If

            Case 9
                If (z_0600_郵便番号検索_loaded = 0) Then
                    If Me.dgv町域名9.SelectedRows.Count = 0 Then Exit Sub
                    z_0500_顧客変更.郵便番号.Text = Me.dgv町域名9.SelectedRows(0).Cells(0).Value
                    z_0500_顧客変更.住所２.Text = Me.dgv町域名9.SelectedRows(0).Cells(1).Value

                ElseIf (z_0600_郵便番号検索_loaded = 1) Then
                    If Me.dgv町域名9.SelectedRows.Count = 0 Then Exit Sub

                ElseIf (z_0600_郵便番号検索_loaded = 2) Then
                    If Me.dgv町域名9.SelectedRows.Count = 0 Then Exit Sub
                    f0100_顧客登録.郵便番号.Text = Me.dgv町域名9.SelectedRows(0).Cells(0).Value
                    f0100_顧客登録.住所２.Text = Me.dgv町域名9.SelectedRows(0).Cells(1).Value
                End If

            Case 10
                If (z_0600_郵便番号検索_loaded = 0) Then
                    If Me.dgv町域名10.SelectedRows.Count = 0 Then Exit Sub
                    z_0500_顧客変更.郵便番号.Text = Me.dgv町域名10.SelectedRows(0).Cells(0).Value
                    z_0500_顧客変更.住所２.Text = Me.dgv町域名10.SelectedRows(0).Cells(1).Value

                ElseIf (z_0600_郵便番号検索_loaded = 1) Then
                    If Me.dgv町域名10.SelectedRows.Count = 0 Then Exit Sub

                ElseIf (z_0600_郵便番号検索_loaded = 2) Then
                    If Me.dgv町域名10.SelectedRows.Count = 0 Then Exit Sub
                    f0100_顧客登録.郵便番号.Text = Me.dgv町域名10.SelectedRows(0).Cells(0).Value
                    f0100_顧客登録.住所２.Text = Me.dgv町域名10.SelectedRows(0).Cells(1).Value
                End If
        End Select

        If (z_0600_郵便番号検索_loaded = 0) Then
            z_0500_顧客変更.都道府県.Text = Me.都道府県.Text
            z_0500_顧客変更.住所１.Text = Me.市区町村.Text

        ElseIf (z_0600_郵便番号検索_loaded = 1) Then

        ElseIf (z_0600_郵便番号検索_loaded = 2) Then
            f0100_顧客登録.都道府県.Text = Me.都道府県.Text
            f0100_顧客登録.住所１.Text = Me.市区町村.Text
        End If
        Me.Close()
    End Sub
#End Region

End Class
