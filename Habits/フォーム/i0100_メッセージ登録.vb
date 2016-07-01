'システム名 ： HABITS
'機能名　　 ： i0100_メッセージ登録
'概要　　　 ： 他店舗へのメッセージをサーバに送信する機能
'履歴　　　 ： 2011/07/07　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Imports System
Imports System.IO
Imports System.Text

Public Class i0100_メッセージ登録

#Region "変数・定数定義"

    Private Const NUMBER_OF_LETTERS_SENDER As Integer = 30      '送信者文字数上限
    Private Const NUMBER_OF_LETTERS_SUBJECT As Integer = 30     '件名文字数上限
    Private Const NUMBER_OF_LETTERS_MSG_BODY As Integer = 1000  '本文文字数上限
    Private Const NUMBER_OF_LETTERS_LINE_BODY As Integer = 30   '本文行文字数制限
    'Private Const NUMBER_OF_LINES_BODY As Integer = 17          '本文最大文字数の場合の行数

    Dim downloadClient As System.Net.WebClient = Nothing
    Private logic As Habits.Logic.i0100_Logic
    Private logicBase As Habits.Logic.LogicBase

    Private bMaster As Boolean = False
    Private blnCloseFlag As Boolean = False                     'フォームクローズフラグ

    Private folderPath As String = Nothing                      'ファイル格納フォルダパス
    Private messageCSVFileName As String = Nothing              'メッセージCSVファイル名
    Private messageZIPFileName As String = Nothing              'メッセージZIPファイル名
    Private shopCSVFileName As String = Nothing                 '店舗一覧CSVファイル名
    Private shopZIPFileName As String = Nothing                 '店舗一覧ZIPファイル名

    Dim msg_moji As String
    Dim tmp_moji As String
    Dim page As Integer = 1
    Dim e_pos As Integer = 0
    Dim kp_flg As Boolean = False                               '改ページフラグ
    Dim i As Integer = 0                                        'ループカウンター

#End Region

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>
    ''' ロード時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub i0100_メッセージ登録_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        logic = New Habits.Logic.i0100_Logic()
        '変数設定
        folderPath = logic.getStockPath() & MESSAGE_PATH & "\"
        messageCSVFileName = folderPath & "message_" & sShopcode & ".csv"
        messageZIPFileName = folderPath & "message_" & sShopcode & ".zip"
        shopCSVFileName = folderPath & "Shop_" & sShopcode & "_" & Format(Now, "yyyyMMdd") & ".csv"
        shopZIPFileName = "Shop_" & sShopcode & "_" & Format(Now, "yyyyMMdd") & ".zip"

        '入力項目クリア
        clearInput()
        '最大文字数設定
        txtSender.MaxLength = NUMBER_OF_LETTERS_SENDER
        txtSubject.MaxLength = NUMBER_OF_LETTERS_SUBJECT
        txtMsgBody.MaxLength = NUMBER_OF_LETTERS_MSG_BODY

        'CSVから店舗一覧を設定
        receiveShopList(0)
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ前処理"
    ''' <summary>フォームが閉じられる前処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub i0100_メッセージ登録_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If blnCloseFlag = False Then
            If (MsgBox("メッセージ登録を終了します。　" & Chr(13) & Chr(13) & _
                       "よろしいですか？　", Clng_Ynqub2, TTL) = vbNo) Then
                e.Cancel = True
            End If
        End If
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub i0100_メッセージ登録_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dim msgFlg As Boolean = False

        Try
            'ファイル削除
            deleteShopFile()
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            msgFlg = True
        End Try

        Try
            'ファイル削除
            deleteUploadFile()
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            msgFlg = True
        End Try

        If msgFlg = True Then
            MsgBox("ファイルの削除に失敗しました。　" & Chr(13) & Chr(13) & _
                    "繰り返し発生する場合は、管理者に連絡してください。　", Clng_Okexb1, TTL)
        End If

        Me.Dispose()
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "全店舗選択ボタン押下"
    ''' <summary>
    ''' 全店舗選択ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        Dim dt As DataTable = New DataTable()
        Dim i As Integer = 0

        dt.Columns.Add("店舗名", Type.GetType("System.String"))
        dt.Columns.Add("店舗コード", Type.GetType("System.String"))
        dt.Columns.Add("display_order", Type.GetType("System.String"))

        ' 全店舗一覧のレコード追加
        If (dgvShopAll.Rows.Count > 0) Then
            For i = 0 To dgvShopAll.Rows.Count - 1
                dt.Rows.Add(dgvShopAll.Rows(i).Cells("店舗名").Value, dgvShopAll.Rows(i).Cells("店舗コード").Value, dgvShopAll.Rows(i).Cells("display_order").Value)
            Next
            ' 選択店舗一覧のレコード追加
            If (dgvShopSelected.Rows.Count > 0) Then
                For i = 0 To dgvShopSelected.Rows.Count - 1
                    dt.Rows.Add(dgvShopSelected.Rows(i).Cells("店舗名").Value, dgvShopSelected.Rows(i).Cells("店舗コード").Value, dgvShopSelected.Rows(i).Cells("display_order").Value)
                Next
            End If
            dt.DefaultView.Sort = "display_order ASC"
            dgvShopAll.DataSource = Nothing
            dgvShopSelected.DataSource = dt.DefaultView
        End If
        ' 店舗一覧＆送信先店舗一覧設定
        setShopList()
    End Sub
#End Region

#Region "全店舗削除ボタン押下"
    ''' <summary>
    ''' 全店舗削除ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim dt As DataTable = New DataTable()
        Dim i As Integer = 0

        dt.Columns.Add("店舗名", Type.GetType("System.String"))
        dt.Columns.Add("店舗コード", Type.GetType("System.String"))
        dt.Columns.Add("display_order", Type.GetType("System.String"))

        If (dgvShopSelected.Rows.Count > 0) Then
            ' 選択店舗一覧のレコード追加
            For i = 0 To dgvShopSelected.Rows.Count - 1
                dt.Rows.Add(dgvShopSelected.Rows(i).Cells("店舗名").Value, dgvShopSelected.Rows(i).Cells("店舗コード").Value, dgvShopSelected.Rows(i).Cells("display_order").Value)
            Next
            ' 全店舗一覧のレコード追加
            If (dgvShopAll.Rows.Count > 0) Then
                For i = 0 To dgvShopAll.Rows.Count - 1
                    dt.Rows.Add(dgvShopAll.Rows(i).Cells("店舗名").Value, dgvShopAll.Rows(i).Cells("店舗コード").Value, dgvShopAll.Rows(i).Cells("display_order").Value)
                Next
            End If
            dt.DefaultView.Sort = "display_order ASC"
            dgvShopSelected.DataSource = Nothing
            dgvShopAll.DataSource = dt.DefaultView
        End If
        ' 店舗一覧＆送信先店舗一覧設定
        setShopList()
    End Sub
#End Region

#Region "単一店舗選択ボタン押下"
    ''' <summary>
    ''' 単一店舗選択ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSelectOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectOne.Click
        Dim dt As DataTable = New DataTable()
        Dim i As Integer = 0

        dt.Columns.Add("店舗名", Type.GetType("System.String"))
        dt.Columns.Add("店舗コード", Type.GetType("System.String"))
        dt.Columns.Add("display_order", Type.GetType("System.String"))

        ' 全店舗一覧のレコード追加
        If (dgvShopAll.SelectedRows.Count > 0) Then
            For i = 0 To dgvShopAll.SelectedRows.Count - 1
                dt.Rows.Add(dgvShopAll.SelectedRows(i).Cells("店舗名").Value, dgvShopAll.SelectedRows(i).Cells("店舗コード").Value, dgvShopAll.SelectedRows(i).Cells("display_order").Value)
            Next

            ' 選択店舗一覧のレコード追加
            If (dgvShopSelected.Rows.Count > 0) Then
                For i = 0 To dgvShopSelected.Rows.Count - 1
                    dt.Rows.Add(dgvShopSelected.Rows(i).Cells("店舗名").Value, dgvShopSelected.Rows(i).Cells("店舗コード").Value, dgvShopSelected.Rows(i).Cells("display_order").Value)
                Next
            End If

            '全店舗一覧で選択されているすべての行を削除する
            Dim r As Windows.Forms.DataGridViewRow
            For Each r In dgvShopAll.SelectedRows
                If Not r.IsNewRow Then
                    dgvShopAll.Rows.Remove(r)
                End If
            Next r

            If (dgvShopAll.Rows.Count < 1) Then
                dgvShopAll.DataSource = Nothing
            End If

            dt.DefaultView.Sort = "display_order ASC"
            dgvShopSelected.DataSource = dt.DefaultView
            ' 店舗一覧＆送信先店舗一覧設定
            setShopList()

        End If
    End Sub
#End Region

#Region "単一店舗削除ボタン押下"
    ''' <summary>
    ''' 単一店舗削除ボタンクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDeleteOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteOne.Click
        Dim dt As DataTable = New DataTable()
        Dim i As Integer = 0

        dt.Columns.Add("店舗名", Type.GetType("System.String"))
        dt.Columns.Add("店舗コード", Type.GetType("System.String"))
        dt.Columns.Add("display_order", Type.GetType("System.String"))

        If (dgvShopSelected.SelectedRows.Count > 0) Then
            ' 選択店舗一覧のレコード追加
            For i = 0 To dgvShopSelected.SelectedRows.Count - 1
                dt.Rows.Add(dgvShopSelected.SelectedRows(i).Cells("店舗名").Value, dgvShopSelected.SelectedRows(i).Cells("店舗コード").Value, dgvShopSelected.SelectedRows(i).Cells("display_order").Value)
            Next
            ' 全店舗一覧のレコード追加
            If (dgvShopAll.Rows.Count > 0) Then
                For i = 0 To dgvShopAll.Rows.Count - 1
                    dt.Rows.Add(dgvShopAll.Rows(i).Cells("店舗名").Value, dgvShopAll.Rows(i).Cells("店舗コード").Value, dgvShopAll.Rows(i).Cells("display_order").Value)
                Next
            End If
            '全店舗一覧で選択されているすべての行を削除する
            Dim r As Windows.Forms.DataGridViewRow
            For Each r In dgvShopSelected.SelectedRows
                If Not r.IsNewRow Then
                    dgvShopSelected.Rows.Remove(r)
                End If
            Next r

            If (dgvShopSelected.Rows.Count < 1) Then
                dgvShopSelected.DataSource = Nothing
            End If

            dt.DefaultView.Sort = "display_order ASC"
            dgvShopAll.DataSource = dt.DefaultView
            ' 店舗一覧＆送信先店舗一覧設定
            setShopList()
        End If

    End Sub
#End Region

#Region "送信ボタン押下"
    ''' <summary>
    ''' 送信ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        '入力チェック
        If (checkInput() = False) Then Exit Sub

        '----------------------------
        ' CSVデータ作成
        '----------------------------
        Dim sw As StreamWriter
        If File.Exists(messageCSVFileName) = False Then
            sw = File.CreateText(messageCSVFileName)
            sw.Close()
        End If
        sw = New StreamWriter(messageCSVFileName, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
        'messageテーブル用SQL
        sw.WriteLine(makeParentSQL())
        'message_detailsテーブル用SQL
        For i = 0 To dgvShopSelected.Rows.Count - 1
            sw.WriteLine(makeDetailsSQL(i))
        Next

        sw.Flush()
        sw.Close()

        '----------------------------
        ' ZIPファイル作成
        '----------------------------
        'ZipOutputStreamの作成
        Dim fos As New java.io.FileOutputStream(messageZIPFileName)
        Dim zos As New java.util.zip.ZipOutputStream(fos)

        'ZIPに追加するときのファイル名を決定する
        Dim f As String = System.IO.Path.GetFileName(messageCSVFileName)
        'ディレクトリを保持する時は次のようにする
        'Dim f As String = file.Remove( _
        '    0, System.IO.Path.GetPathRoot(file).Length)
        'f = f.Replace("\", "/")
        Dim ze As New java.util.zip.ZipEntry(f)
        ze.setMethod(java.util.zip.ZipEntry.DEFLATED)
        zos.putNextEntry(ze)
        'FileInputStreamの作成
        Dim fis As New java.io.FileInputStream(messageCSVFileName)
        '書込み
        Dim buffer(8191) As System.SByte
        While True
            Dim len As Integer = fis.read(buffer, 0, buffer.Length)
            If len <= 0 Then
                Exit While
            End If
            zos.write(buffer, 0, len)
        End While
        '閉じる
        fis.close()
        zos.closeEntry()

        zos.close()
        fos.close()

        '----------------------------
        ' ファイル送信
        '----------------------------
        Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "MessageDataUpLoad.aspx"

        '送信するデータ（フィールド名と値の組み合わせ）を追加
        Dim wc As WebClientEx = New WebClientEx()
        wc.Timeout = 600000

        Dim nvc As System.Collections.Specialized.NameValueCollection = New System.Collections.Specialized.NameValueCollection()

        ''------------------------------------------------
        ''ファイル更新処理
        ''------------------------------------------------
        '送信するデータ（フィールド名と値の組み合わせ）を追加
        nvc.Add("q1", My.Settings.LoginName)        ' ID
        nvc.Add("q2", My.Settings.LoginPassword)    ' Password
        wc.QueryString = nvc

        'データを送信し、また受信する
        Dim ret As Byte() = wc.UploadFile(url, messageZIPFileName)
        Dim result As String = Encoding.UTF8.GetString(ret)
        wc.Dispose()

        Dim param As New Habits.DB.DBParameter
        If result.ToString.StartsWith("1") Then
            MsgBox("送信しました。　　", Clng_Okinb1, TTL)
            btnClose.Focus()
        Else
            MsgBox("送信に失敗しました。　　" & Chr(13) & Chr(13) & _
                    "再度送信してください。　", Clng_Okcrb1, TTL)
        End If
    End Sub
#End Region

#Region "プレビューボタン押下"
    ''' <summary>
    ''' プレビューボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        '入力チェック
        If (checkInput() = False) Then Return

        ' 印刷プレビューサイズ設定
        PrintPreviewDialog1.Size = New Size(600, 700)
        ' 印刷プレビューダイアログのアイコン非表示
        PrintPreviewDialog1.ShowIcon = False
        ' 印刷プレビューダイアログを中心に表示
        PrintPreviewDialog1.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        ' 印刷プレビューダイアログを中心に表示
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1.0
        ' 印刷プレビュー表示
        PrintPreviewDialog1.ShowDialog()

    End Sub

#End Region

#Region "項目クリアボタン押下"
    ''' <summary>
    ''' 項目クリアボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        '入力項目クリア
        clearInput()
        '店舗一覧設定
        setShopListAll()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
#End Region

#End Region

#Region "メソッド"

#Region "店舗一覧データ受信"
    ''' <summary>店舗一覧データ受信</summary>
    ''' <remarks></remarks>
    Private Sub receiveShopList(ByVal iCount As Integer)
        Dim int_long As Integer
        Dim str_copypath As String
        Dim bEnd As Boolean = False
        Dim iStrCounter As Integer

        int_long = folderPath.Length - 1
        If System.IO.Directory.Exists(folderPath) Then
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            downloadShopData()
            Me.bMaster = True
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Else

            iStrCounter = InStr(folderPath, "\")
            If iCount < 1 And iStrCounter > 0 Then
                While (bEnd = False)
                    iStrCounter = InStr(iStrCounter + 1, folderPath, "\")
                    If iStrCounter = 0 Then
                        bEnd = True
                    Else
                        str_copypath = Mid(folderPath, 1, iStrCounter - 1)
                        If Not System.IO.Directory.Exists(Mid(str_copypath, 1, int_long)) Then
                            Try
                                MkDir(str_copypath)
                            Catch ex As Exception
                                'ログ出力
                                FileUtil.WriteLogFile(ex.ToString, _
                                                                My.Application.Info.DirectoryPath, _
                                                                TraceEventType.Error, _
                                                                FileUtil.OutPutType.Weekly)

                                MsgBox("出力先ファイルの作成に失敗しました。　" & Chr(13) & Chr(13) & _
                                        "繰り返し発生する場合は、管理者に連絡してください。　", Clng_Okexb1, TTL)
                                setForcedEnd()  '強制終了
                            End Try
                        End If
                    End If
                End While
                receiveShopList(1)
                Exit Sub
            Else
                rtn = MsgBox("ダウンロード先パスが正しくありません。　" & Chr(13) & Chr(13) & _
                                         "正しいパスを指定してください。　", Clng_Okexb1, TTL)
                setForcedEnd()  '強制終了
            End If
        End If
    End Sub
#End Region

#Region "入力項目クリア"
    ''' <summary>
    ''' 入力項目クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearInput()
        Me.txtSender.Text = Nothing
        Me.txtSubject.Text = Nothing
        Me.txtMsgBody.Text = Nothing

        Me.dgvShopAll.DataSource = Nothing
        Me.dgvShopSelected.DataSource = Nothing
    End Sub
#End Region

#Region "店舗一覧＆送信先店舗一覧の設定"
    ''' <summary>
    ''' 店舗一覧＆送信先店舗一覧の設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setShopList()
        setDgvShopAll()
        setDgvShopSelected()
    End Sub
#End Region

#Region "店舗一覧設定"
    ''' <summary>
    ''' 店舗一覧設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setDgvShopAll()
        If (dgvShopAll.Rows.Count = 0) Then
            btnSelectAll.Enabled = False
            btnSelectOne.Enabled = False
        Else
            dgvShopAll.Columns(0).Width = "210"
            dgvShopAll.Columns(1).Visible = False
            dgvShopAll.Columns(2).Visible = False
            btnSelectAll.Enabled = True
            btnSelectOne.Enabled = True
        End If
    End Sub
#End Region

#Region "送信先店舗一覧設定"
    ''' <summary>
    ''' 送信先店舗一覧設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setDgvShopSelected()
        If (dgvShopSelected.Rows.Count = 0) Then
            btnDeleteAll.Enabled = False
            btnDeleteOne.Enabled = False
        Else
            dgvShopSelected.Columns(0).Width = "210"
            dgvShopSelected.Columns(1).Visible = False
            dgvShopSelected.Columns(2).Visible = False
            btnDeleteAll.Enabled = True
            btnDeleteOne.Enabled = True
        End If
    End Sub
#End Region

#Region "入力チェック処理"
    Private Function checkInput() As Boolean

        checkInput = False
        '送信店舗
        If dgvShopSelected.Rows.Count < 1 Then
            dgvShopAll.Focus()
            MsgBox("送信先店舗を選択してください。　", Clng_Okexb1, TTL)
            dgvShopAll.Focus()
            Exit Function
        End If

        '送信者
        If String.IsNullOrEmpty(Me.txtSender.Text) Then
            MsgBox("送信者を入力してください。　", Clng_Okexb1, TTL)
            txtSender.Focus()
            Exit Function
        ElseIf Me.txtSender.Text.Length > NUMBER_OF_LETTERS_SENDER Then
            MsgBox("送信者は" & NUMBER_OF_LETTERS_SENDER & "文字以内で入力してください。　", Clng_Okexb1, TTL)
            txtSender.Focus()
            Exit Function
        End If

        '件名
        If String.IsNullOrEmpty(Me.txtSubject.Text) Then
            MsgBox("件名を入力してください。　", Clng_Okexb1, TTL)
            txtSubject.Focus()
            Exit Function
        ElseIf Me.txtSubject.Text.Length > NUMBER_OF_LETTERS_SUBJECT Then
            MsgBox("件名は" & NUMBER_OF_LETTERS_SUBJECT & "文字以内で入力してください。　", Clng_Okexb1, TTL)
            txtSubject.Focus()
            Exit Function
        End If

        '本文
        If String.IsNullOrEmpty(Me.txtMsgBody.Text) Then
            MsgBox("本文を入力してください。　", Clng_Okexb1, TTL)
            txtMsgBody.Focus()
            Exit Function
        End If

        '改行コードは2文字分
        If Me.txtMsgBody.Text.Length > NUMBER_OF_LETTERS_MSG_BODY Then
            MsgBox("本文は" & NUMBER_OF_LETTERS_MSG_BODY & "文字以内で入力してください。(改行は2文字分)　", Clng_Okexb1, TTL)
            txtMsgBody.Focus()
            Exit Function
        End If

        checkInput = True
    End Function
#End Region


#Region "印刷設定"
    ''' <summary>
    ''' 印刷設定
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' 文字フォント種別・文字フォントサイズ設定
        Dim moji_f As New Font("ＭＳ 明朝", 12)
        ' １行の高さ
        Dim LineHeight As Single = moji_f.GetHeight(e.Graphics)
        ' １行の幅
        Dim LineWidth As Integer
        ' 文字列の描画を開始する横位置
        Dim X As Integer = e.MarginBounds.X
        ' 文字列の描画を開始する縦位置
        Dim Y As Integer = e.MarginBounds.Y

        Dim moji As String
        Dim mojiLine As String
        Dim flg As Boolean = False
        Dim i As Integer
        Dim strBuilder As New StringBuilder()

        If kp_flg = False Then
            '---------------------------
            ' 1ページ目の場合
            '---------------------------
            moji = "件名　　：" & txtSubject.Text
            e.Graphics.DrawString(moji, moji_f, Brushes.Black, X, Y)

            ' 縦位置を１行分次に進ませる。（改行）
            Y += LineHeight + 5

            strBuilder.Append("送信日時：")
            strBuilder.Append(Now.ToString("yyyy/MM/dd HH:mm"))

            moji = strBuilder.ToString()
            e.Graphics.DrawString(moji, moji_f, Brushes.Black, X, Y)

            ' 縦位置を１行分次に進ませる。（改行）
            Y += LineHeight + 5

            moji = "送信者　：" & txtSender.Text
            e.Graphics.DrawString(moji, moji_f, Brushes.Black, X, Y)

            ' 縦位置を１行分次に進ませる。（改行＋空行）
            Y += LineHeight + 20

            tmp_moji = txtMsgBody.Text.ToString.Replace(vbCrLf, NEW_LINE_CODE)
        Else
            '---------------------------
            ' 2ページ目以降の場合
            '---------------------------
            If msg_moji <> NEW_LINE_CODE Then
                e.Graphics.DrawString(msg_moji, moji_f, Brushes.Black, X, Y)
            End If
            ' 縦位置を１行分次に進ませる。（改行）
            Y += LineHeight + 5
        End If

        '本文表示
        Do Until flg = True

            If InStr(tmp_moji, NEW_LINE_CODE) <> 0 Then
                '改行コード有り
                e_pos = InStr(tmp_moji, NEW_LINE_CODE)
                If e_pos <> 1 Then
                    msg_moji = Mid(tmp_moji, 1, e_pos - 1)              '１行分の文字列
                    '---------------------------
                    ' 1行分の文字列判定
                    '---------------------------
                    '印刷するのに必要な幅を計算
                    LineWidth = e.Graphics.MeasureString(msg_moji, moji_f).Width

                    '幅が印刷可能領域をオーバーする場合
                    If LineWidth > e.MarginBounds.Width Then
                        '１行分の文字を取得
                        For i = 1 To msg_moji.Length
                            mojiLine = Mid(msg_moji, 1, i)
                            If e.Graphics.MeasureString(mojiLine, moji_f).Width > e.MarginBounds.Width Then
                                msg_moji = Mid(tmp_moji, 1, i - 1)              '１行分の文字列修正
                                tmp_moji = Mid(tmp_moji, i, Len(tmp_moji))      '次行からの文字列
                                Exit For
                            End If
                        Next
                    Else
                        tmp_moji = Mid(tmp_moji, e_pos + 5, Len(tmp_moji))  '次行からの文字列
                    End If
                    '---------------------------

                    If Y + LineHeight > e.MarginBounds.Y + e.MarginBounds.Height Then
                        'スペースがない場合は改ページを指定していったんプロシージャを抜ける
                        kp_flg = True
                        e.HasMorePages = True
                        page = page + 1
                        Exit Do
                    Else
                        If msg_moji <> NEW_LINE_CODE Then
                            e.Graphics.DrawString(msg_moji, moji_f, Brushes.Black, X, Y)
                        End If
                    End If
                Else
                    '改行コードから始まる
                    msg_moji = NEW_LINE_CODE
                    tmp_moji = Mid(tmp_moji, e_pos + 5, Len(tmp_moji))
                    If Y + LineHeight > e.MarginBounds.Y + e.MarginBounds.Height Then
                        'スペースがない場合は改ページを指定していったんプロシージャを抜ける
                        kp_flg = True
                        e.HasMorePages = True
                        page = page + 1
                        Exit Do
                    End If
                End If
                Y += LineHeight + 5
            Else
                '改行なし
                Dim endFlg As Boolean = False
                '---------------------------
                ' 1行分の文字列判定
                '---------------------------
                msg_moji = tmp_moji                                         '１行分の文字列
                '印刷するのに必要な幅を計算
                LineWidth = e.Graphics.MeasureString(msg_moji, moji_f).Width

                '幅が印刷可能領域をオーバーする場合
                If LineWidth > e.MarginBounds.Width Then
                    '１行分の文字を取得
                    For i = 1 To msg_moji.Length
                        mojiLine = Mid(msg_moji, 1, i)
                        If e.Graphics.MeasureString(mojiLine, moji_f).Width > e.MarginBounds.Width Then
                            msg_moji = Mid(msg_moji, 1, i - 1)              '１行分の文字列修正
                            tmp_moji = Mid(tmp_moji, i, Len(tmp_moji))      '次行からの文字列
                            Exit For
                        End If
                    Next
                Else
                    endFlg = True
                End If
                '---------------------------
                If Y + LineHeight > e.MarginBounds.Y + e.MarginBounds.Height Then
                    'スペースがない場合は改ページを指定していったんプロシージャを抜ける
                    kp_flg = True
                    e.HasMorePages = True
                    Exit Do
                Else
                    e.Graphics.DrawString(msg_moji, moji_f, Brushes.Black, X, Y)
                    If endFlg = True Then
                        kp_flg = False          '改ページなし
                        flg = True              '最終行
                    End If
                End If
                Y += LineHeight + 5
            End If
        Loop
    End Sub
#End Region

#Region "店舗一覧ダウンロード"
    ''' <summary>
    ''' 店舗一覧ダウンロード
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub downloadShopData()
        Try
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            '（Webシステム）マスタデータダウンロード処理
            Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "ShopDataSync.aspx"
            Dim wc As New System.Net.WebClient

            'NameValueCollectionの作成
            Dim ps As New System.Collections.Specialized.NameValueCollection
            Dim dt As New DataTable

            '送信するデータ（フィールド名と値の組み合わせ）を追加
            ps.Add("q1", My.Settings.LoginName)         ' ID
            ps.Add("q2", My.Settings.LoginPassword)     ' Password
            ps.Add("q3", sShopcode)                     ' ShopCode
            wc.QueryString = ps

            'データを送信し、また受信する
            Dim resData As Byte() = wc.UploadValues(url, ps)
            Dim result As String = Encoding.UTF8.GetString(resData)
            wc.Dispose()

            If result.ToString.StartsWith("1") = True Then
                Dim startIndex As Integer = InStr(result.ToString, ";") + 1
                Dim endIndex As Integer = InStr(startIndex, result.ToString, ";")

                '（Webサイド）ダウンロード元のURL
                Dim u As New Uri(URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NDATAFOLDER & shopZIPFileName)

                'WebClientの作成
                If downloadClient Is Nothing Then
                    downloadClient = New System.Net.WebClient()
                    'イベントハンドラの作成

                    AddHandler downloadClient.DownloadFileCompleted, _
                        AddressOf downloadClient_DownloadFileCompleted
                End If
                '非同期ダウンロードを開始する
                downloadClient.DownloadFileAsync(u, folderPath & shopZIPFileName)

            ElseIf result.ToString.StartsWith("-1") = True Then
                MsgBox("ログインエラー：" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-2") = True Then
                MsgBox("アップロードフォルダ無しエラー：" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-3") = True Then
                MsgBox("ファイル保存失敗エラー：" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-4") = True Then
                MsgBox("Zipファイル以外送信エラー：" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-5") = True Then
                MsgBox("Zipファイル展開失敗エラー：" & result, Clng_Okexb1, TTL)
            Else
                MsgBox("不明：" & result, Clng_Okexb1, TTL)
            End If
            If result.ToString.StartsWith("1") = False Then
                setForcedEnd()  '強制終了
            End If
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("接続エラーが発生しました。　" & Chr(13) & Chr(13) & _
                    "インターネットへの接続状況を確認してください。　", Clng_Okexb1, TTL)
            setForcedEnd()  '強制終了
        End Try
    End Sub
#End Region

    Private Sub downloadClient_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)
    End Sub

    Private Sub downloadClient_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If bMaster = True Then
            '店舗データ読込
            readShopFile()
        End If
    End Sub

#Region "店舗データ読込処理"
    ''' <summary>
    ''' 店舗データ読込処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub readShopFile()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Me.bMaster = False
        Try
            '読み込む
            Dim fis As New java.io.FileInputStream(folderPath & shopZIPFileName)
            Dim zis As New java.util.zip.ZipInputStream(fis)
            'ZIP内のファイル情報を取得
            While True
                Dim ze As java.util.zip.ZipEntry = zis.getNextEntry()
                If ze Is Nothing Then
                    Exit While
                End If
                If Not ze.isDirectory() Then
                    'ファイル名
                    Dim fileName As String = _
                        System.IO.Path.GetFileName(ze.getName())
                    '展開先のフォルダ
                    Dim destDir As String = System.IO.Path.Combine( _
                        folderPath, System.IO.Path.GetDirectoryName(ze.getName()))
                    System.IO.Directory.CreateDirectory(destDir)
                    '展開先のパス
                    Dim destPath As String = _
                        System.IO.Path.Combine(destDir, fileName)
                    'FileOutputStreamの作成
                    Dim fos As New java.io.FileOutputStream(destPath)
                    '書込み
                    Dim buffer(8191) As System.SByte
                    While True
                        Dim len As Integer = zis.read(buffer, 0, buffer.Length)
                        If len <= 0 Then
                            Exit While
                        End If
                        fos.write(buffer, 0, len)
                    End While
                    '閉じる
                    fos.close()
                End If
            End While
            zis.close()
            fis.close()

            setShopListAll()
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("ファイルの展開に失敗しました。　" & Chr(13) & Chr(13) & _
            "繰り返し発生する場合は、管理者に連絡してください。　", Clng_Okexb1, TTL)
            setForcedEnd()  '強制終了
        End Try
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub
#End Region

#Region "店舗データ表示処理"
    ''' <summary>
    ''' 店舗データ表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setShopListAll()
        Dim bTableName As Boolean = False
        Dim sTablseName As String = ""
        Dim dt As DataTable = New DataTable()

        dt.Columns.Add("店舗名", Type.GetType("System.String"))
        dt.Columns.Add("店舗コード", Type.GetType("System.String"))
        dt.Columns.Add("display_order", Type.GetType("System.String"))

        'ダウンロードをShift-JISコードとして開く
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(shopCSVFileName, System.Text.Encoding.GetEncoding("shift_jis"))

            MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            MyReader.Delimiters = New String() {","}
            Dim currentRow As String()

            While Not MyReader.EndOfData
                Try
                    '内容を一行ずつ読み込む
                    currentRow = MyReader.ReadFields()
                    If (currentRow(0) = "-") Then
                        bTableName = True
                    Else
                        If bTableName = True Then
                            'Table名は読み飛ばし
                            sTablseName = currentRow(0)
                            bTableName = False
                        ElseIf (currentRow(0) <> "") Then
                            'リストに追加
                            dt.Rows.Add(currentRow(1), currentRow(0), currentRow(2))

                        End If
                    End If
                Catch ex As Exception
                    'ログ出力
                    FileUtil.WriteLogFile(ex.ToString, _
                                                    My.Application.Info.DirectoryPath, _
                                                    TraceEventType.Error, _
                                                    FileUtil.OutPutType.Weekly)
                    MsgBox("ファイルの展開に失敗しました。　" & Chr(13) & Chr(13) & _
                    "繰り返し発生する場合は、管理者に連絡してください。　", Clng_Okexb1, TTL)
                    setForcedEnd()  '強制終了
                End Try
            End While
        End Using
        Me.dgvShopAll.DataSource = dt
        ' 店舗一覧＆送信先店舗一覧設定
        setShopList()

    End Sub
#End Region

#Region "メッセージ内容登録SQL作成"
    ''' <summary>
    ''' メッセージ内容登録SQL作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Function makeParentSQL() As String
        Dim builSQL As New StringBuilder()

        builSQL.Append("INSERT INTO message")
        builSQL.Append(" (send_shop_code")
        builSQL.Append(" ,send_user_name")
        builSQL.Append(" ,subject")
        builSQL.Append(" ,[message]")
        builSQL.Append(" ,message_id")
        builSQL.Append(" ,send_time)")

        builSQL.Append(" VALUES(")
        builSQL.Append(logicBase.VbSQLNStrCSV(sShopcode))
        builSQL.Append("," & logicBase.VbSQLNStrCSV(txtSender.Text))
        builSQL.Append("," & logicBase.VbSQLNStrCSV(txtSubject.Text))
        builSQL.Append("," & logicBase.VbSQLNStrCSV(txtMsgBody.Text))
        Return builSQL.ToString
    End Function
#End Region

#Region "メッセージ詳細登録SQL作成"
    ''' <summary>
    ''' メッセージ詳細登録SQL作成
    ''' </summary>
    ''' <remarks></remarks>
    Private Function makeDetailsSQL(ByVal i As Integer) As String
        Dim builSQL As New StringBuilder()

        builSQL.Append("INSERT INTO message_details")
        builSQL.Append(" (receive_shop_code")
        builSQL.Append(" ,message_id)")

        builSQL.Append(" VALUES(")
        builSQL.Append(logicBase.VbSQLNStrCSV(dgvShopSelected.Rows(i).Cells("店舗コード").Value))
        Return builSQL.ToString
    End Function
#End Region

#Region "店舗一覧ファイル削除"
    ''' <summary>
    ''' 店舗一覧ファイル削除
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub deleteShopFile()
        Try
            ' ファイルを削除する
            System.IO.File.Delete(shopCSVFileName)
            System.IO.File.Delete(folderPath & shopZIPFileName)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "アップロードファイルの削除"
    ''' <summary>
    ''' CSV,ZIPファイルの削除を行う
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub deleteUploadFile()
        Try
            ' ファイルを削除する
            System.IO.File.Delete(messageCSVFileName)
            System.IO.File.Delete(messageZIPFileName)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "強制終了処理"
    ''' <summary>
    ''' 強制終了処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setForcedEnd()
        blnCloseFlag = True
        Me.Close()
    End Sub
#End Region

#End Region

End Class
