Option Explicit On
Imports Excel = Microsoft.Office.Interop.Excel

''' <summary>h0200_確認画面処理</summary>
''' <remarks></remarks>
Public Class h0200_確認
    Private logic As New Habits.Logic.h0200_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub h0200_確認_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable

        'logic.Q_h0200_W_出力対象削除()
        'logic.Q_h0200_W_出力対象追加()

        '全選択
        logic.選択変更(True, "")

        画面再描画()

        Me.ActiveControl = Me.出力
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub h0200_確認_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "全選択ボタン押下"
    ''' <summary>
    ''' 全選択ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 全選択_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 全選択.Click
        Dim dt As New DataTable
        logic.選択変更(True, "")
        画面再描画()
    End Sub
#End Region

#Region "全解除ボタン押下"
    ''' <summary>
    ''' 全解除ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 全解除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 全解除.Click
        Dim dt As New DataTable
        logic.選択変更(False, "")
        画面再描画()
    End Sub
#End Region

#Region "出力ボタン押下"
    ''' <summary>
    ''' 出力ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 出力_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 出力.Click
        Dim sfd As New Windows.Forms.SaveFileDialog()
        Dim dt As New DataTable
        Dim update_dt As New Integer
        Dim param As New Habits.DB.DBParameter

        sfd.FileName = "抽出データ"
        sfd.InitialDirectory = logic.getPath(2)
        sfd.Filter = _
        "Microsoft Offics Excel ブック(*.xls)|*.xls"
        sfd.FilterIndex = 1
        sfd.Title = "保存先のファイルを選択してください"
        sfd.RestoreDirectory = True
        '既に存在するファイル名を指定したとき警告する
        'デフォルトでTrueなので指定する必要はない
        sfd.OverwritePrompt = True
        '存在しないパスが指定されたとき警告を表示する
        'デフォルトでTrueなので指定する必要はない
        sfd.CheckPathExists = True

        'ダイアログを表示する
        If sfd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき
            '選択されたファイル名を表示する
            Console.WriteLine(sfd.FileName)
        End If

        '----------------------指定ファイルが開かれているか確認(COM開放バグ回避)----------------------------------------------------------------------------
        Dim localByName As Process() = Process.GetProcessesByName("Excel")
        Dim p As Process
        Dim fn As String = "Microsoft Excel - " & FileUtil.GetFilename(sfd.FileName)
        For Each p In localByName
            If System.String.Compare(p.MainWindowTitle, fn, True) = 0 Then
                Call Sys_Error("指定されたExcelファイルが起動中です。　" & Chr(13) & Chr(13) & _
                "ファイルを閉じて下さい。　", Me.出力)
                Exit Sub
            End If
        Next
        '--------------------------------------------------------------------------------------------------
        Cursor.Current = Windows.Forms.Cursors.WaitCursor
        If Replace(sfd.FileName, FileUtil.GetFilename(sfd.FileName), "").Length > 128 Then
            Call Sys_Error("ファイルの出力に失敗しました。　" & Chr(13) & Chr(13) & _
                           "指定先ディレクトリのパスの文字数が、128以内であることを確認してください。", Me.出力)
            Exit Sub
        End If
        excel_output_customer(sfd.FileName)
        Cursor.Current = Windows.Forms.Cursors.Default
        param.Add("@データ抽出出力パス名", Replace(sfd.FileName, FileUtil.GetFilename(sfd.FileName), ""))
        param.Add("@変更日時", Now)
        update_dt = logic.update_ASY(param)
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
        GC.Collect()
        Me.Close()

    End Sub
#End Region

#End Region

#Region "出力ボタン押下"
    ''' <summary>
    ''' 出力ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        CheckChange(e)
    End Sub
#End Region

#Region "メソッド"
    Sub 画面再描画()
        Dim dt As New DataTable
        dt = logic.Q_h0200_出力対象一覧()
        If dt.Rows.Count <> 0 Then
            Me.DataGridView1.RowTemplate.Height = 18
            Me.DataGridView1.DataSource = dt
            ' 選択
            Me.DataGridView1.Columns(0).Width = 40
            ' 顧客番号
            Me.DataGridView1.Columns(1).Width = 85
            Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
            ' 姓
            Me.DataGridView1.Columns(2).Width = 75
            ' 名
            Me.DataGridView1.Columns(3).Width = 75
            ' 姓カナ
            Me.DataGridView1.Columns(4).Width = 75
            ' 名カナ
            Me.DataGridView1.Columns(5).Width = 75
            ' 性別
            Me.DataGridView1.Columns(6).Width = 40
            Me.DataGridView1.Columns(6).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            ' 住所１
            Me.DataGridView1.Columns(7).Width = 140
            ' 住所２
            Me.DataGridView1.Columns(8).Width = 140
            ' 最終担当者
            Me.DataGridView1.Columns(9).Width = 106
        End If
    End Sub

    Private Sub CheckChange(ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Select Case e.ColumnIndex

            Case 0
                Dim dt As New DataTable
                Dim param As New Habits.DB.DBParameter
                Dim num As New Integer
                num = e.RowIndex

                If Me.DataGridView1.SelectedRows.Count <> 0 Then
                    If Boolean.Parse(Me.DataGridView1.CurrentRow.Cells("選択").Value.ToString) = True Then
                        logic.選択変更(False, Me.DataGridView1.CurrentRow.Cells("顧客番号").Value)

                    Else
                        logic.選択変更(True, Me.DataGridView1.CurrentRow.Cells("顧客番号").Value)

                    End If
                    画面再描画()
                    If num < 0 Then
                        num = 0
                    End If
                    Me.DataGridView1.CurrentCell = DataGridView1(0, num)
                End If

        End Select
    End Sub

    Private Sub excel_output_customer(ByVal str_fullpath As String)

        'Excelに貼り付けるデータを準備
        Dim dt As New DataTable
        dt = logic.select_W出力対象

        'DataTableを二次元配列に格納する
        Dim data(dt.Rows.Count, dt.Columns.Count - 1) As String
        data(0, 0) = "顧客番号"
        data(0, 1) = "姓"
        data(0, 2) = "名"
        data(0, 3) = "姓カナ"
        data(0, 4) = "名カナ"
        data(0, 5) = "性別"
        data(0, 6) = "郵便番号"
        data(0, 7) = "都道府県"
        data(0, 8) = "住所1"
        data(0, 9) = "住所2"
        data(0, 10) = "電話番号"
        data(0, 11) = "最終担当者"
        data(0, 12) = "最終来店日"
        data(0, 13) = "来店回数"
        data(0, 14) = "生年月日"
        data(0, 15) = "Emailアドレス"
        data(0, 16) = "売上区分"
        data(0, 17) = "金額"

        For y As Integer = 0 To dt.Rows.Count - 1
            For x As Integer = 0 To dt.Columns.Count - 1
                data(y + 1, x) = dt.Rows(y)(x).ToString
            Next
        Next

        'Excelを起動する
        Dim excelApp As New Excel.Application()
        'Excelブックを追加する
        Dim bk As Excel.Workbook = excelApp.Workbooks.Add()
        'Excelシートを取得する
        Dim sheet As Excel.Worksheet = bk.Worksheets(1)
        sheet.Name = "抽出データ"

        excelApp.DisplayAlerts = False   '保存時の確認ダイアログを表示しない   


        'データを貼り付ける
        Dim range As Excel.Range = Nothing
        Dim range1 As Excel.Range = Nothing
        Dim range2 As Excel.Range = Nothing

        Try
            Dim startX As Integer = 1

            Dim startY As Integer = 1
            '始点
            range1 = DirectCast(sheet.Cells(startY, startX), Excel.Range)
            '終点
            range2 = DirectCast(sheet.Cells(startY + UBound(data), startX + UBound(data, 2)), Excel.Range)
            'セル範囲
            range = sheet.Range(range1, range2)
            '貼り付け
            range.Value = data

            ' 保存   
            bk.SaveAs(str_fullpath)

            bk.Close(False)

            excelApp.Quit()

        Catch ex As Exception
            Throw
        Finally
            '解放
            If Not range Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(range)
                range = Nothing
            End If

            If Not range1 Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(range1)
                range1 = Nothing
            End If

            If Not range2 Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(range2)
                range2 = Nothing
            End If

            If Not sheet Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet)
                sheet = Nothing
            End If

            If Not bk Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(bk)
                bk = Nothing
            End If

            If Not excelApp Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp)
                excelApp = Nothing
            End If

            GC.Collect()
        End Try

    End Sub

    Private Sub form_closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        GC.Collect()
    End Sub

    '（注意）Excelシートの行、列のインデックスは１から始まる   
    Private Const ROW_OFFSET As Integer = 2 'エクセルシートにデータを書き出す行番号   
    '（注意）Excelシートの行、列のインデックスは１から始まる   
    Private Const COLUMN_OFFSET As Integer = 1 'エクセルシートにデータを書き出す列番号   

#Region "エクセルファイルへ出力"
    '''<summary>   
    '''データテーブルをエクセルファイルに出力します   
    '''</summary>   
    Public Function CreateExcelFromDataTable(ByVal filePath As String) As Boolean
        'ヘッダー名称のリスト   
        Dim headers As List(Of String) = New List(Of String)

        Dim dt As New DataTable
        dt = logic.select_W出力対象

        For Each col As System.Data.DataColumn In dt.Columns
            headers.Add(col.ColumnName)
        Next

        Dim xlsApplication As Excel.Application = Nothing
        Dim xlsBooks As Excel.Workbooks = Nothing
        Dim xlsBook As Excel.Workbook = Nothing
        Dim xlsSheets As Excel.Sheets = Nothing
        Dim xlsSheet As Excel.Worksheet = Nothing
        Dim xlsRange As Excel.Range = Nothing
        Dim sheetName As String = "抽出データ"

        Try
            xlsApplication = New Excel.Application
            xlsApplication.DisplayAlerts = False   '保存時の確認ダイアログを表示しない   

            xlsBooks = xlsApplication.Workbooks
            xlsBook = xlsBooks.Add
            xlsSheets = xlsBook.Worksheets

            '（注意）シートのインデックスは１から始まる   
            xlsSheet = DirectCast(xlsSheets.Item(1), Excel.Worksheet)
            xlsSheet.Name = sheetName

            For i As Integer = 0 To headers.Count - 1
                xlsRange = DirectCast(xlsSheet.Cells(1, i + 1), Excel.Range)
                xlsRange.Value = headers.Item(i)
            Next

            ' セルに値を設定する。   
            Dim sheetRowIndex As Integer = ROW_OFFSET

            For Each row As DataRow In dt.Rows
                Dim sheetColumnIndex As Integer = COLUMN_OFFSET

                For Each column As DataColumn In dt.Columns

                    If Not row.IsNull(column) Then
                        xlsRange = DirectCast(xlsSheet.Cells(sheetRowIndex, sheetColumnIndex), Excel.Range)

                        If column.DataType.Name = "Integer" Or _
                           column.DataType.Name = "Int32" Or _
                           column.DataType.Name = "Decimal" Or _
                            column.DataType.Name = "Long" Or _
                            column.DataType.Name = "Double" Or _
                            column.DataType.Name = "Short" Then
                            'セルの書式を数値型に設定   
                            xlsRange.NumberFormatLocal = "G/標準"
                        ElseIf column.DataType.Name = "DateTime" Then
                            xlsRange.NumberFormatLocal = "yyyy/m/d"
                        Else
                            'セルの書式を文字列型に設定   
                            xlsRange.NumberFormatLocal = "@"
                        End If

                        xlsRange.Value = row(column)
                        ReleaseComObject(DirectCast(xlsRange, Object))
                        sheetColumnIndex += 1
                    End If
                Next
                sheetRowIndex += 1
            Next

            ' 保存   
            xlsBook.SaveAs(filePath)

            Return True

        Catch ex As Exception
            Return False
        Finally
            'エクセル関係のオブジェクトは必ず解放すること   
            ReleaseComObject(DirectCast(xlsRange, Object))
            ReleaseComObject(DirectCast(xlsSheet, Object))
            ReleaseComObject(DirectCast(xlsSheets, Object))
            xlsBook.Close(False)
            ReleaseComObject(DirectCast(xlsBook, Object))
            ReleaseComObject(DirectCast(xlsBooks, Object))
            xlsApplication.Quit()
            ReleaseComObject(DirectCast(xlsApplication, Object))
        End Try

        Return False
    End Function
#End Region

#Region "COMオブジェクト開放"
    ''' <summary>   
    ''' COMオブジェクトを開放します。   
    ''' </summary>   
    Private Shared Sub ReleaseComObject(ByRef target As Object)
        Try
            If Not target Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(target)
            End If
        Finally
            target = Nothing
        End Try
    End Sub
#End Region

#End Region
End Class









