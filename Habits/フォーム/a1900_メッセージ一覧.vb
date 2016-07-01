'システム名 ： HABITS
'機能名　　 ： a1900_メッセージ一覧
'概要　　　 ： 送受信メッセージを表示する機能
'履歴　　　 ： 2011/07/07　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Text

Public Class a1900_メッセージ一覧

#Region "変数・定数定義"

    Dim select_moji As String
    Dim msg_moji As String
    Dim tmp_moji As String
    Dim page As Integer = 1
    Dim e_pos As Integer = 0
    Dim kp_flg As Boolean = False                               '改ページフラグ

    Dim downloadClient As System.Net.WebClient = Nothing

    Private Const CSV_RECEIVE As String = "受信"
    Private Const CSV_SEND As String = "送信"

    Private logic As Habits.Logic.a1900_Logic
    Private bMaster As Boolean = False
    Private folderPath As String = Nothing                      'ファイル格納フォルダパス
    Private messageCSVFileName As String = Nothing              'メッセージCSVファイル名
    Private messageZIPFileName As String = Nothing              'メッセージZIPファイル名

#End Region

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>
    ''' ロード時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1900_メッセージ一覧_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        logic = New Habits.Logic.a1900_Logic()
        '変数設定
        folderPath = logic.getStockPath() & MESSAGE_PATH & "\"
        messageCSVFileName = folderPath & "messageList_" & sShopcode & "_" & Format(Now, "yyyyMMdd") & ".csv"
        messageZIPFileName = "messageList_" & sShopcode & "_" & Format(Now, "yyyyMMdd") & ".zip"
        MESSAGE_CHECK_FLAG = True
        lbl本文.Text = Nothing

        'CSVからメッセージ一覧を設定
        receiveMessageList(0)
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <remarks></remarks>
    Private Sub a1900_メッセージ一覧_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        MESSAGE_CHECK_FLAG = False
        'ファイル削除
        deleteMessageListFile()
        Me.Dispose()
    End Sub
#End Region

#Region "受信一覧選択処理"
    ''' <summary>
    ''' 受信一覧選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv一覧_受信_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv一覧_受信.SelectionChanged
        '表示項目設定
        setContents()
    End Sub
#End Region

#Region "送信一覧選択処理"
    ''' <summary>
    ''' 送信一覧選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>  
    Private Sub dgv一覧_送信_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv一覧_送信.SelectionChanged
        '表示項目設定
        setContents()
    End Sub
#End Region

#Region "メッセージ一覧タブ選択処理"
    ''' <summary>
    ''' メッセージ一覧タブ選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>  
    Private Sub tabMessageList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabMessageList.SelectedIndexChanged
        '表示項目設定
        setContents()
    End Sub
#End Region

#Region "セルの値再表示処理"
    ''' <summary>
    ''' セルの値再表示処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv一覧_受信_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv一覧_受信.CellFormatting
        If dgv一覧_受信.Rows(e.RowIndex).Cells(4).Value.Equals("False") OrElse dgv一覧_受信.Rows(e.RowIndex).Cells(4).Value.Equals("0") Then
            e.CellStyle.Font = New Font("ＭＳ ゴシック", 9, FontStyle.Bold)
        End If
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "確認ボタン押下"
    ''' <summary>
    ''' 確認ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>　
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn確認_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn確認.Click
        If Me.lbl件名.Text = "" Then
            MsgBox("印刷対象が選択されていません。　", Clng_Okexb1, TTL)
            Return
        End If

        If (MsgBox("印刷しますか？　", Clng_Ynqub1, TTL) = vbYes) Then
            PrintDocument1.Print()
        End If
        ' 確認済に更新
        updateFlag()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub bnt閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnt閉じる.Click
        Me.Close()
    End Sub
#End Region

#End Region

#Region "チェック済フラグ更新処理（サーバ通信）"
    Private Sub updateFlag()
        Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "MessageDataFlgChenge.aspx"

        'フラグ更新対象か判定
        If tabMessageList.SelectedIndex = 1 OrElse _
            dgv一覧_受信.SelectedRows(0).Cells(4).Value.Equals("True") OrElse _
            dgv一覧_受信.SelectedRows(0).Cells(4).Value.Equals("1") Then
            Return
        End If

        '送信するデータ（フィールド名と値の組み合わせ）を追加
        Dim wc As WebClientEx = New WebClientEx()
        wc.Timeout = 600000

        Dim ps As System.Collections.Specialized.NameValueCollection = New System.Collections.Specialized.NameValueCollection()
        ps.Add("q1", My.Settings.LoginName)        ' ID
        ps.Add("q2", My.Settings.LoginPassword)    ' Password
        ps.Add("q3", sShopcode)                    ' ShopCode
        ps.Add("q4", dgv一覧_受信.SelectedRows(0).Cells(5).Value)    ' messageId
        wc.QueryString = ps

        'データを送信し、また受信する
        Dim resData As Byte() = wc.UploadValues(url, ps)
        Dim result As String = Encoding.UTF8.GetString(resData)
        wc.Dispose()

        Dim param As New Habits.DB.DBParameter
        If result.ToString.StartsWith("1") Then
            MsgBox("確認済に更新しました。　　", Clng_Okinb1, TTL)
            ' 再表示
            receiveMessageList(0)
        Else
            'ログ出力
            FileUtil.WriteLogFile(result, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("サーバとの通信に失敗しました。　　" & Chr(13) & Chr(13) & _
                    "繰り返し発生する場合は、管理者に連絡してください。　", Clng_Okinb1, TTL)
        End If

    End Sub
#End Region

#Region "表示項目クリア"
    ''' <summary>
    ''' 表示項目クリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearContents()
        Me.lbl送信日付.Text = Nothing
        Me.lbl件名.Text = Nothing
        Me.lbl送信者.Text = Nothing
        Me.lbl本文.Text = Nothing
    End Sub
#End Region

#Region "表示項目設定"
    ''' <summary>
    ''' 表示項目設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setContents()
        If tabMessageList.SelectedIndex = 0 Then
            If Me.dgv一覧_受信.SelectedRows.Count <> 0 Then
                lbl送信者.Text = Me.dgv一覧_受信.SelectedRows(0).Cells(0).Value.ToString
                lbl件名.Text = Me.dgv一覧_受信.SelectedRows(0).Cells(1).Value.ToString
                lbl送信日付.Text = Me.dgv一覧_受信.SelectedRows(0).Cells(2).Value.ToString
                select_moji = Me.dgv一覧_受信.SelectedRows(0).Cells(3).Value.ToString
                lbl本文.Text = Me.dgv一覧_受信.SelectedRows(0).Cells(3).Value.ToString.Replace(NEW_LINE_CODE, vbCrLf)
            Else
                clearContents()
            End If
        Else
            If Me.dgv一覧_送信.SelectedRows.Count <> 0 Then
                lbl送信者.Text = Me.dgv一覧_送信.SelectedRows(0).Cells(0).Value.ToString.Replace("&", "&&")
                lbl件名.Text = Me.dgv一覧_送信.SelectedRows(0).Cells(1).Value.ToString.Replace("&", "&&")
                lbl送信日付.Text = Me.dgv一覧_送信.SelectedRows(0).Cells(2).Value.ToString
                select_moji = Me.dgv一覧_送信.SelectedRows(0).Cells(3).Value.ToString
                lbl本文.Text = Me.dgv一覧_送信.SelectedRows(0).Cells(3).Value.ToString.Replace(NEW_LINE_CODE, vbCrLf).Replace("&", "&&")
            Else
                clearContents()
            End If
        End If
    End Sub
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

        If kp_flg = False Then
            '---------------------------
            ' 1ページ目の場合
            '---------------------------
            moji = "件名　　：" & lbl件名.Text.Replace("&&", "&")
            e.Graphics.DrawString(moji, moji_f, Brushes.Black, X, Y)

            ' 縦位置を１行分次に進ませる。（改行）
            Y += LineHeight + 5

            moji = "送信日時：" & lbl送信日付.Text
            e.Graphics.DrawString(moji, moji_f, Brushes.Black, X, Y)

            ' 縦位置を１行分次に進ませる。（改行）
            Y += LineHeight + 5

            moji = "送信者　：" & lbl送信者.Text.Replace("&&", "&")
            e.Graphics.DrawString(moji, moji_f, Brushes.Black, X, Y)

            ' 縦位置を１行分次に進ませる。（改行＋空行）
            Y += LineHeight + 20

            tmp_moji = select_moji
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

#Region "メッセージ一覧データ受信"
    ''' <summary>メッセージ一覧データ受信</summary>
    ''' <remarks></remarks>
    Private Sub receiveMessageList(ByVal iCount As Integer)
        Dim int_long As Integer
        Dim str_copypath As String
        Dim bEnd As Boolean = False
        Dim iStrCounter As Integer

        '' ファイル削除
        'deleteShopFile()

        int_long = folderPath.Length - 1
        If System.IO.Directory.Exists(folderPath) Then
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            'サーバよりデータ取得
            downloadMessageListData()
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
                            End Try
                        End If
                    End If
                End While
                receiveMessageList(1)
                Exit Sub
            Else
                rtn = MsgBox("ダウンロード先パスが正しくありません。　" & Chr(13) & Chr(13) & _
                                         "正しいパスを指定してください。　", Clng_Okexb1, TTL)
            End If
        End If
    End Sub
#End Region

#Region "メッセージ一覧ダウンロード"
    ''' <summary>
    ''' メッセージ一覧ダウンロード
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub downloadMessageListData()
        Try
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            '（Webシステム）マスタデータダウンロード処理
            Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "MessageDataSync.aspx"
            Dim wc As New System.Net.WebClient

            'NameValueCollectionの作成
            Dim ps As New System.Collections.Specialized.NameValueCollection
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
                '（Webサイド）ダウンロード元のURL
                Dim u As New Uri(URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NDATAFOLDER & messageZIPFileName)

                'WebClientの作成
                If downloadClient Is Nothing Then
                    downloadClient = New System.Net.WebClient()
                    'イベントハンドラの作成

                    AddHandler downloadClient.DownloadProgressChanged, _
                        AddressOf downloadClient_DownloadProgressChanged
                    AddHandler downloadClient.DownloadFileCompleted, _
                        AddressOf downloadClient_DownloadFileCompleted
                End If
                '非同期ダウンロードを開始する
                downloadClient.DownloadFileAsync(u, folderPath + messageZIPFileName)

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
            If (result.ToString.StartsWith("1") = False) Then
                'ログ出力
                FileUtil.WriteLogFile(result, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)
                Me.Close()
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
            Me.Close()
        End Try
    End Sub
#End Region

    Private Sub downloadClient_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)
    End Sub

    Private Sub downloadClient_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If bMaster = True Then
            'メッセージ一覧データ読込
            readMessageFile()
        End If
    End Sub

#Region "メッセージ一覧データ読込処理"
    ''' <summary>
    ''' メッセージ一覧データ読込処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub readMessageFile()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Me.bMaster = False
        Try
            '読み込む
            Dim fis As New java.io.FileInputStream(folderPath & messageZIPFileName)
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

            setMessageListAll()
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("ファイルの展開に失敗しました。　" & Chr(13) & Chr(13) & _
            "繰り返し発生する場合は管理者に連絡してください。　", Clng_Okexb1, TTL)
            Me.Close()
        End Try
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub
#End Region

#Region "メッセージ一覧データ表示処理"
    ''' <summary>
    ''' メッセージ一覧データ表示処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setMessageListAll()
        Dim bTableName As Boolean = False
        Dim sTablseName As String = ""
        Dim dtReceive As DataTable = New DataTable()
        Dim dtSend As DataTable = New DataTable()

        dtReceive.Columns.Add("送信者", Type.GetType("System.String"))
        dtReceive.Columns.Add("件名", Type.GetType("System.String"))
        dtReceive.Columns.Add("送信日時", Type.GetType("System.String"))
        dtReceive.Columns.Add("MSG", Type.GetType("System.String"))
        dtReceive.Columns.Add("CK", Type.GetType("System.String"))
        dtReceive.Columns.Add("メッセージID", Type.GetType("System.String"))

        dtSend.Columns.Add("送信者", Type.GetType("System.String"))
        dtSend.Columns.Add("件名", Type.GetType("System.String"))
        dtSend.Columns.Add("送信日時", Type.GetType("System.String"))
        dtSend.Columns.Add("MSG", Type.GetType("System.String"))

        'ダウンロードをShift-JISコードとして開く
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(messageCSVFileName, System.Text.Encoding.GetEncoding("shift_jis"))

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
                            If (sTablseName = CSV_RECEIVE) Then
                                'リストに追加
                                dtReceive.Rows.Add(currentRow(0), currentRow(1), currentRow(2), currentRow(3), currentRow(4), currentRow(5))
                            ElseIf (sTablseName = CSV_SEND) Then
                                'リストに追加
                                dtSend.Rows.Add(currentRow(0), currentRow(1), currentRow(2), currentRow(3))
                            End If

                        End If
                    End If
                Catch ex As Exception
                    'ログ出力
                    FileUtil.WriteLogFile(ex.ToString, _
                                                    My.Application.Info.DirectoryPath, _
                                                    TraceEventType.Error, _
                                                    FileUtil.OutPutType.Weekly)
                    MsgBox("ファイルの展開に失敗しました。　" & Chr(13) & Chr(13) & _
                    "繰り返し発生する場合は管理者に連絡してください。　", Clng_Okexb1, TTL)
                    Me.Close()
                End Try
            End While
        End Using

        ''-----------------
        ''送信メッセージ
        ''-----------------
        Me.dgv一覧_送信.DataSource = dtSend

        Me.dgv一覧_送信.Columns(0).Width = 157
        Me.dgv一覧_送信.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft

        Me.dgv一覧_送信.Columns(1).Width = 213
        Me.dgv一覧_送信.Columns(1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft

        Me.dgv一覧_送信.Columns(2).Width = 140
        Me.dgv一覧_送信.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.dgv一覧_送信.Columns(3).Visible = False
        ' 送信日付を降順にてソート
        Me.dgv一覧_送信.Sort(Me.dgv一覧_送信.Columns(2), ComponentModel.ListSortDirection.Descending)

        ''-----------------
        ''受信メッセージ
        ''-----------------
        Me.dgv一覧_受信.DataSource = dtReceive

        Me.dgv一覧_受信.Columns(0).Width = 157
        Me.dgv一覧_受信.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft

        Me.dgv一覧_受信.Columns(1).Width = 213
        Me.dgv一覧_受信.Columns(1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomLeft

        Me.dgv一覧_受信.Columns(2).Width = 140
        Me.dgv一覧_受信.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.BottomRight

        Me.dgv一覧_受信.Columns(3).Visible = False
        Me.dgv一覧_受信.Columns(4).Visible = False
        Me.dgv一覧_受信.Columns(5).Visible = False
        ' 送信日付を降順にてソート
        Me.dgv一覧_受信.Sort(Me.dgv一覧_受信.Columns(2), ComponentModel.ListSortDirection.Descending)
    End Sub
#End Region

#Region "メッセージ一覧ファイル削除"
    ''' <summary>
    ''' メッセージ一覧ファイル削除
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub deleteMessageListFile()
        Try
            ' ファイルを削除する
            System.IO.File.Delete(messageCSVFileName)
            System.IO.File.Delete(folderPath & messageZIPFileName)
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("メッセージ一覧ファイルの削除に失敗しました。　" & Chr(13) & Chr(13) & _
                      "繰り返し発生する場合は管理者に連絡してください。　", Clng_Okexb1, TTL)
        End Try
    End Sub
#End Region

End Class