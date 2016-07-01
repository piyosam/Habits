Imports System.IO
Imports System.Text

''' <summary>
''' ファイル用クラス
''' </summary>
''' <remarks></remarks>
Public Class FileUtil

#Region "変数・定数"

    Public Enum OutPutType
        Normal = 0
        Daily = 1
        Weekly = 2
    End Enum

#End Region

#Region "メソッド"

#Region "ファイル出力"
    ''' <summary>
    ''' ファイル出力
    ''' </summary>
    ''' <param name="vContents">出力内容</param>
    ''' <param name="vPath">出力先パス</param>
    ''' <param name="vType">イベント</param>
    ''' <param name="vOutput">出力モード</param>
    ''' <param name="vFileName">出力ファイル名</param>
    ''' <param name="vOverType">上書き許可(True: 上書きする/False:上書きしない/Default：上書きしない)</param>
    ''' <returns>出力結果(True: 成功/False: 失敗)</returns>
    ''' <remarks></remarks>
    Public Shared Function WriteLogFile(ByVal vContents As String, ByVal vPath As String, _
        Optional ByVal vType As TraceEventType = TraceEventType.Warning, _
        Optional ByVal vOutput As OutPutType = OutPutType.Normal, _
        Optional ByVal vFileName As String = Nothing, _
        Optional ByVal vOverType As Boolean = False) As Boolean

        Dim filePath As String
        Dim filename As String

        Try
            '出力先パスの最後に\ + log\ をつける
            If vPath.Substring(vPath.Length - 1) <> "\" Then vPath = vPath & "\"
            vPath = vPath & "log\"

            'ディレクトリが存在しない場合作成する
            chkDir(vPath)

            '出力先パスの有無
            If Directory.Exists(vPath) = True Then

                Dim logdate As DateTime = DateTime.Now      '現在時刻
                Dim sb As New StringBuilder                 '出力内容
                Dim typestring As String

                Select Case vType
                    Case TraceEventType.Critical : typestring = "Critical"
                    Case TraceEventType.Error : typestring = "Error"
                    Case TraceEventType.Information : typestring = "Information"
                    Case Else : typestring = "Warning"
                End Select
                '書き込み内容
                sb.Append(logdate.ToString("yyyy/MM/dd HH:mm:ss") & ": ")   '現在日時:
                sb.Append(typestring & ",")                                 '内容ヘッダ
                sb.Append(vContents)                                        '内容
                sb.Append(ControlChars.NewLine)                             '改行

                If vOutput = OutPutType.Normal Then
                    '新規作成モード
                    If String.IsNullOrEmpty(vFileName) = True Then Return False
                    filePath = vPath & vFileName
                    '上書き
                    If vOverType = False Then
                        If File.Exists(filePath) = True Then Return False
                    End If
                    'ファイル書き込み
                    File.WriteAllText(filePath, sb.ToString)
                Else
                    '追加モード
                    Select Case vOutput
                        Case OutPutType.Daily
                            filename = logdate.ToString("yyyyMMdd") & ".log"
                        Case OutPutType.Weekly
                            Dim diff As Double
                            Dim diffE As Double
                            Select Case logdate.DayOfWeek
                                Case DayOfWeek.Sunday : diff = 0 : diffE = 6
                                Case DayOfWeek.Monday : diff = -1 : diffE = 5
                                Case DayOfWeek.Tuesday : diff = -2 : diffE = 4
                                Case DayOfWeek.Wednesday : diff = -3 : diffE = 3
                                Case DayOfWeek.Thursday : diff = -4 : diffE = 2
                                Case DayOfWeek.Friday : diff = -5 : diffE = 1
                                Case DayOfWeek.Saturday : diff = -6 : diffE = 0
                            End Select
                            Dim weekly As Date = logdate.AddDays(diff)
                            Dim weeklyE As Date = logdate.AddDays(diffE)
                            filename = weekly.ToString("yyyyMMdd") & "-" & weeklyE.ToString("MMdd") & ".log"
                        Case Else
                            If String.IsNullOrEmpty(vFileName) = True Then Return False
                            filename = vFileName
                    End Select
                    filePath = vPath & filename

                    '追加モードファイル書き込み
                    File.AppendAllText(filePath, sb.ToString, System.Text.Encoding.GetEncoding("Shift_Jis"))
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function
#End Region

#Region "ファイル出力（売上データ更新ログ）"
    ''' <summary>
    ''' ファイル出力（売上データ更新ログ）
    ''' </summary>
    ''' <param name="vContents1">出力内容1</param>
    ''' <param name="vContents2">出力内容2</param>
    ''' <param name="vTableName">テーブル名</param>
    ''' <param name="vType">イベント</param>
    ''' <returns>出力結果(True: 成功/False: 失敗)</returns>
    ''' <remarks></remarks>
    Public Shared Function WriteDataHistoryLogFile(ByVal vContents1 As DataTable, ByVal vContents2 As DataTable, _
        Optional ByVal vTableName As String = Nothing, _
        Optional ByVal vType As String = Nothing) As Boolean

        Dim logdate As DateTime = DateTime.Now                      '現在時刻
        Dim vPath As String = My.Settings.LogPath
        Dim startDate As DateTime = getMonthlyStartDate(logdate)
        Dim filePath As String = vPath & "HabitsHistory" & startDate.AddMonths(1).AddDays(-1).ToString("yyyyMM") & ".csv"

        Try
            '出力先パスの有無
            If Directory.Exists(vPath) = True Then

                Dim sb As New System.Text.StringBuilder                     '出力内容
                Dim typestring As String = ""
                Dim contents As String = ""
                '書き込み内容
                contents = logdate.ToString("yyyy/MM/dd HH:mm:ss") & ",来店日,来店者番号,顧客番号,顧客名,主担当者名,売上合計（税抜）"

                sb.Append(contents)                                         'ヘッダ
                sb.Append(ControlChars.NewLine)                             '改行

                contents = edtContents(vContents1)
                sb.Append("変更前," & contents)                             '更新前レコード
                sb.Append(ControlChars.NewLine)                             '改行
                contents = edtContents(vContents2)
                sb.Append("　　後," & contents)                             '更新後レコード
                sb.Append(ControlChars.NewLine)                             '改行

                'ファイル書き込み
                Dim Writer As New IO.StreamWriter(filePath, True, System.Text.Encoding.UTF8)
                Writer.WriteLine(sb.ToString)

                Writer.Close()

            Else
                Return False
            End If

        Catch ex As Exception
            Throw
        End Try
    End Function
#End Region

#Region "データベース内容をカンマ区切り文字に編集"
    Private Shared Function edtContents(ByVal dt As DataTable) As String
        Dim rtn As String = ""
        Dim i As Integer = 0
        If Not dt Is Nothing _
            AndAlso dt.Rows.Count > 0 _
            AndAlso dt.Columns.Count > 0 Then
            For i = 0 To dt.Columns.Count - 1
                If i > 0 Then
                    rtn &= ","
                End If
                rtn &= dt.Rows(0).Item(i).ToString()
            Next
        End If
        Return rtn
    End Function
#End Region

#Region "ファイル名取得"
    ''' <summary>
    ''' ファイル名取得
    ''' </summary>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFilename(ByVal path As Object) As String
        Dim i As Integer
        Dim fnm As String

        '** ファイル名切り出し
        fnm = LCase(Trim(path))
        If Strings.Right(fnm, 1) = "\" Then
            GetFilename = ""
        Else
            For i = Len(fnm) To 1 Step -1
                If Mid(fnm, i, 1) = "\" Then Exit For
            Next
            If i > 0 Then
                GetFilename = Strings.Right(fnm, Len(fnm) - i)
            Else
                For i = 1 To Len(fnm)
                    If Mid(fnm, i, 1) = ":" Then Exit For
                Next
                If i < Len(fnm) Then
                    GetFilename = Strings.Right(fnm, Len(fnm) - i)
                Else
                    GetFilename = ""
                End If
            End If
        End If
    End Function
#End Region

#Region "ディレクトリ作成"

    ''' <summary>
    ''' ディレクトリ作成
    ''' </summary>
    ''' <param name="strDir"></param>
    ''' <remarks>ディレクトリが存在しない場合、ディレクトリを作成</remarks>
    Public Shared Sub chkDir(ByVal strDir As String)
        If Not System.IO.Directory.Exists(strDir) Then
            MkDir(strDir)
        End If
    End Sub

#End Region

#End Region

End Class

