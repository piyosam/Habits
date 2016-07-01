Imports System
Imports System.Threading
Imports System.Text

Public Class MultiThreadMsg

#Region "未チェックメッセージのチェック"
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
#End Region

#Region "メッセージ件数取得"
    ''' <summary>
    ''' メッセージ件数取得
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function ThreadMethod(ByVal c As String) As Integer
        Try
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            '（Webシステム）未チェックメッセージ件数取得
            Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "MessageDataCheck.aspx"
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
                Dim startIndex As Integer = InStr(result.ToString, ":") + 1
                Dim endIndex As Integer = InStr(startIndex, result.ToString, ":")
                MESSAGE_CNT = Mid(result.ToString(), startIndex, endIndex - startIndex)

            ElseIf result.ToString.StartsWith("-1") = True Then
                MsgBox("ログインエラー：" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-2") = True Then
                MsgBox("アップロードフォルダ無しエラー：" & result, Clng_Okexb1, TTL)
            Else
                MsgBox("不明：" & result, Clng_Okexb1, TTL)
            End If
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            'メッセージ機能は本体機能に影響を与えないため、タイマー起動のエラーメッセージは表示しない
            'MsgBox("接続エラーが発生しました。　" & Chr(13) & Chr(13) & _
            '        "インターネットへの接続状況を確認してください。　", Clng_Okexb1, TTL)
        End Try
        Return 1
    End Function
#End Region

    ' スレッド処理終了後に呼び出されるコールバック・メソッド
    Public Shared Sub MyCallback(ByVal ar As IAsyncResult) ' 
        'MESSAGE_CHECK_FLAG = False

    End Sub

End Class
