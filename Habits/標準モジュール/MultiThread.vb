Imports System
Imports System.Threading
Imports System.Text

Public Class MultiThread

#Region "データ送受信-Auto"
    ' 戻り値とパラメータのあるデリゲート
    Delegate Function ThreadMethodDelegate(ByVal c As String) As Integer ' 
    Shared threadMethodDelegateInstance As ThreadMethodDelegate ' 

    Public Shared Sub UpdateToServer()
        threadMethodDelegateInstance _
          = New ThreadMethodDelegate(AddressOf ThreadMethod) ' 

        ' デリゲートによるスレッド処理呼び出し
        threadMethodDelegateInstance.BeginInvoke(".", _
          New AsyncCallback(AddressOf MyCallback), DateTime.Now) ' 
    End Sub

    Public Shared Function ThreadMethod(ByVal c As String) As Integer
        Dim logic As Habits.Logic.MultiThread_Logic = New Habits.Logic.MultiThread_Logic
        Dim dt As DataTable = logic.select_ASY
        Dim str_path As String = Nothing
        Dim param As New Habits.DB.DBParameter

        ' データ格納パス名取得
        If dt.Rows.Count <> 0 Then
            str_path = dt.Rows(0)("データ格納パス名")
        Else
            MsgBox("データ格納パスが設定されていません。　", Clng_Okexb1, TTL)
            a0200_メイン.TimerDataSync.Enabled = True
            Return -1
        End If

        Do
            Try
                ' Z_SQL実行履歴データ取得
                dt = logic.get_SQLHistory

                If dt.Rows.Count = 0 Then
                    ' レコードが存在しない場合、終了
                    Exit Do
                End If

                アップロードファイル削除()
                '----------------------------
                ' CSVデータ作成
                '----------------------------
                My.Computer.FileSystem.WriteAllText((str_path & "\upload_" & sShopcode & ".csv"), dt.Rows(0)(1), True, System.Text.Encoding.GetEncoding("Shift-JIS"))

                '----------------------------
                ' ZIPファイル作成
                '----------------------------
                '作成するZIPファイルの設定
                Dim zipPath As String = str_path & "\upload_" & sShopcode & ".zip"
                '圧縮するファイルの設定
                Dim filePaths As String() = {str_path & "\upload_" & sShopcode & ".csv"}
                'ZipOutputStreamの作成
                Dim fos As New java.io.FileOutputStream(zipPath)
                Dim zos As New java.util.zip.ZipOutputStream(fos)
                Dim file As String

                For Each file In filePaths
                    'ZIPに追加するときのファイル名を決定する
                    Dim f As String = System.IO.Path.GetFileName(file)
                    'ディレクトリを保持する時は次のようにする
                    'Dim f As String = file.Remove( _
                    '    0, System.IO.Path.GetPathRoot(file).Length)
                    'f = f.Replace("\", "/")
                    Dim ze As New java.util.zip.ZipEntry(f)
                    ze.setMethod(java.util.zip.ZipEntry.DEFLATED)
                    zos.putNextEntry(ze)
                    'FileInputStreamの作成
                    Dim fis As New java.io.FileInputStream(file)
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
                Next file

                zos.close()
                fos.close()

                '----------------------------
                ' ファイル送信
                '----------------------------
                Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "DataUpLoad.aspx"

                '送信するデータ（フィールド名と値の組み合わせ）を追加
                Dim filePath As String = str_path & "\upload_" & sShopcode & ".zip"
                Dim fileName As String = System.IO.Path.GetFileName(filePath)
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
                Dim ret As Byte() = wc.UploadFile(url, filePath)
                Dim result As String = Encoding.UTF8.GetString(ret)
                wc.Dispose()

                If result.ToString.StartsWith("1") OrElse result.ToString.StartsWith("3") Then
                    ' 成功
                    param.Clear()
                    param.Add("@処理番号", dt.Rows(0)(0))
                    Dim rtn As Integer = logic.delete_SQLHistory(param)
                    UpdateConnectErrorTimes(False)
                Else
                    UpdateConnectErrorTimes(True)
                    Return -1
                End If

            Catch ex As Exception
                'ログ出力
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)
                UpdateConnectErrorTimes(True)
                Return -1
            End Try
            ''強制終了時、途中終了
            If (FORCED_CLOSE_FLAG) Then
                Exit Do
            End If
        Loop

        Return 1
    End Function
#End Region

#Region "アップロードファイルの削除"
    ''' <summary>
    ''' CSV,ZIPファイルの削除を行う
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub アップロードファイル削除()
        Dim str_path As String = Nothing
        Dim dt As DataTable
        Dim logic As Habits.Logic.MultiThread_Logic

        logic = New Habits.Logic.MultiThread_Logic

        dt = logic.select_ASY
        If dt.Rows.Count <> 0 Then
            str_path = dt.Rows(0)("データ格納パス名")
        End If

        Try
            Dim fileName1 As String = str_path & "\upload_" & sShopcode & ".zip"
            Dim fileName2 As String = str_path & "\upload_" & sShopcode & ".csv"

            ' FileSystemObject (FSO) の新しいインスタンスを生成する
            ' ファイルを削除する
            System.IO.File.Delete(fileName1)
            System.IO.File.Delete(fileName2)

        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("アップロードファイルの削除に失敗しました。　" & Chr(13) & Chr(13) & _
                    "繰り返し発生する場合は、管理者に連絡してくださ。　", Clng_Okexb1, TTL)
        End Try
    End Sub
#End Region

    ' スレッド処理終了後に呼び出されるコールバック・メソッド
    Public Shared Sub MyCallback(ByVal ar As IAsyncResult) ' 
        Dim dt As DataTable
        Dim iError As Integer = 0
        Dim logic As Habits.Logic.MultiThread_Logic = New Habits.Logic.MultiThread_Logic
        ACTIVE_NETWORK_FLAG = False

        dt = logic.GetConnectError()
        If dt.Rows.Count > 0 Then
            iError = dt.Rows(0)("通信中エラー回数")
            If iError >= CONNECT_ERROR Then
                a0200_メイン.lbl_Connect.Visible = True
            End If
        End If
    End Sub

    ' 通信中エラー回数更新処理
    Public Shared Sub UpdateConnectErrorTimes(ByVal bError As Boolean) '
        Dim logic As Habits.Logic.MultiThread_Logic = New Habits.Logic.MultiThread_Logic
        Dim param As New Habits.DB.DBParameter
        Dim dt As DataTable
        Dim iError As Integer = 0

        If bError = False Then
            param.Add("@通信中エラー回数", 0)
        Else
            dt = logic.GetConnectError()
            If dt.Rows.Count > 0 Then
                iError = dt.Rows(0)("通信中エラー回数")
                If iError >= CONNECT_ERROR Then
                    param.Add("@通信中エラー回数", (iError))
                Else
                    param.Add("@通信中エラー回数", (iError + 1))
                End If
            Else
                param.Add("@通信中エラー回数", 1)
            End If
        End If

        logic.UpdateConnectError(param)
    End Sub

End Class
