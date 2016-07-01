Namespace My

    ''' <summary>
    ''' 次のイベントは MyApplication に対して利用できます:
    ''' 
    ''' Startup: アプリケーションが開始されたとき、スタートアップ フォームが作成される前に発生します。
    ''' Shutdown: アプリケーション フォームがすべて閉じられた後に発生します。このイベントは、通常の終了以外の方法でアプリケーションが終了されたときには発生しません。
    ''' UnhandledException: ハンドルされていない例外がアプリケーションで発生したときに発生するイベントです。
    ''' StartupNextInstance: 単一インスタンス アプリケーションが起動され、それが既にアクティブであるときに発生します。 
    ''' NetworkAvailabilityChanged: ネットワーク接続が接続されたとき、または切断されたときに発生します。
    ''' </summary>
    ''' <remarks></remarks>
    Partial Friend Class MyApplication

        ''' <summary>
        ''' 初期化処理
        ''' </summary>
        ''' <param name="commandLineArgs"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function OnInitialize(ByVal commandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean

            Return MyBase.OnInitialize(commandLineArgs)
        End Function

        ''' <summary>
        ''' ２つ目以降のインスタンスの初期処理
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance

            Me.MainForm.Activate()
            Windows.Forms.MessageBox.Show("既に起動しています。このアプリケーションは多重起動できません。", TTL, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)

        End Sub

        ''' <summary> 
        ''' 未処理例外をキャッチする
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

            'メッセージダイアログを表示
            Call ShowErrorMessage(e.Exception, "【MyApplication_UnhandledExceptionによる例外通知です。】")

            ''ログ出力する(app.configに設定を記述)
            'With My.Application.Log
            '    .DefaultFileLogWriter.Delimiter = ","
            '    .WriteException(e.Exception, _
            '        TraceEventType.Critical, _
            '        "datetime: " & _
            '        My.Computer.Clock.GmtTime.ToString)
            'End With

            FileUtil.WriteLogFile(e.Exception.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            e.ExitApplication = False

        End Sub

        ''' <summary>
        '''  エラーダイアログを表示する
        ''' </summary>
        ''' <param name="ex">例外</param>
        ''' <param name="extraMessage">例外メッセージ</param>
        ''' <remarks></remarks>
        Private Shared Sub ShowErrorMessage(ByVal ex As Exception, ByVal extraMessage As String)

            Dim errorMsg As IO.StringWriter = New IO.StringWriter()

            With errorMsg
                .WriteLine(extraMessage & Environment.NewLine)
                .WriteLine("――――――――" & Environment.NewLine)
                .WriteLine("エラーが発生しました。管理者にお知らせください" & Environment.NewLine)
                .WriteLine("【エラー内容】" & Environment.NewLine & ex.Message & Environment.NewLine)
                .WriteLine("【スタックトレース】" & Environment.NewLine & ex.StackTrace)
            End With
            Windows.Forms.MessageBox.Show(errorMsg.ToString, TTL)
        End Sub
    End Class

End Namespace

