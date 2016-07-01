Namespace Habits.DB

    Public Class DBAccess
        Implements IDisposable

        Protected disposed As Boolean = False  '重複する呼び出しを検出するために使用
        Private m_setting As System.Configuration.ConnectionStringSettings _
                                = System.Configuration.ConfigurationManager.ConnectionStrings("Habits.My.MySettings.habitsConnectionString")
        Private m_conn As New System.Data.SqlClient.SqlConnection
        Private m_sql As System.Data.SqlClient.SqlCommand
        Private m_cmd As New SqlClient.SqlCommand
        Private m_Tran As SqlClient.SqlTransaction = Nothing
        Private m_TranAuto As Boolean = False                           ''トランザクションの自動処理(True:自動/False:手動)
        Private m_CommTimeOut As Int32 = My.Settings.CommTimeOut        '' コマンドタイムアウト(s)
        Private m_TranTimeOut As Int32 = My.Settings.TranTimeOut        '' トランザクションタイムアウト(ms)
        Private m_SqlException As SqlClient.SqlException

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <remarks></remarks>
        Sub New()
            ''データーベース接続及びトランザクションの開始は別途行う必要あり
        End Sub

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="vOpenAuto">接続処理制御(True：行う/False:行わない)</param>
        ''' <param name="vTranAuto">トランザクション制御(True:自動処理する/False:処理しない/Default:処理しない)</param>
        ''' <remarks></remarks>
        Sub New(ByVal vOpenAuto As Boolean, Optional ByVal vTranAuto As Boolean = False)
            Me.New()

            If vOpenAuto = True Then
                ''データーベースに接続する
                Call Open()
                If vTranAuto = True Then
                    ''トランザクションを開始する
                    m_TranAuto = vTranAuto
                    Call TransactionStart()
                End If
            End If

        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' データベース接続
        ''' </summary>
        ''' <remarks></remarks>
        Protected Friend Sub Open()
            Try
                If Not m_conn.State = ConnectionState.Closed Then
                    '' 接続終了
                    Me.Close()
                End If

                '' データベース接続
                m_conn.ConnectionString = m_setting.ConnectionString
                m_conn.Open()

                '' Commandオブジェクトの基本情報を設定する
                Call InitCommand()
            Catch ex As Exception
                Throw
            End Try

        End Sub

        ''' <summary>
        ''' Commandオブジェクトの基本情報を設定する
        ''' </summary>
        ''' <remarks></remarks>
        Protected Friend Sub InitCommand()

            With m_cmd
                .Parameters.Clear()
                .Connection = m_conn
                .CommandTimeout = m_CommTimeOut             '' コマンドタイムアウト
            End With
            '' トランザクションタイムアウト
            'Call ConnExecute("SET LOCK_TIMEOUT " & m_TranTimeOut.ToString, 1)

        End Sub

        ''' <summary>
        ''' コネクションのステータスがオープン状態かどうか
        ''' </summary>
        ''' <returns>True:OPEN /False:OPEN以外</returns>
        ''' <remarks></remarks>
        Protected Friend Function IsOpen() As Boolean
            Dim openStatus As Boolean = False
            Try
                m_SqlException = Nothing
                If m_conn.State = ConnectionState.Open Then
                    openStatus = True
                End If
                Return openStatus
            Catch ex As Exception
                Throw
            End Try
        End Function

        ''' <summary>
        ''' データベース接続を閉じる
        ''' </summary>
        ''' <remarks></remarks>
        Protected Friend Sub Close()

            Try
                '' Commandオブジェクトを解放
                m_cmd.Dispose()
                '' 接続を閉じる
                m_conn.Close()

                '' 接続オブジェクト解放
                m_conn.Dispose()

            Catch ex As Exception
                Throw
            End Try

        End Sub

        ''' <summary>
        ''' トランザクションを開始する
        ''' </summary>
        ''' <remarks></remarks>
        Protected Friend Sub TransactionStart()

            Try
                If IsOpen() = False Then
                    Throw New Exception("DB接続エラー")
                End If
                m_Tran = m_conn.BeginTransaction
                m_cmd.Transaction = m_Tran

            Catch ex As Exception
                Throw
            End Try

        End Sub

        ''' <summary>
        ''' トランザクションをコミットする
        ''' </summary>
        ''' <remarks></remarks>
        Protected Friend Sub TransactionCommit()

            Try
                If IsOpen() = False Then
                    Throw New Exception("DB接続エラー")
                End If
                If m_Tran IsNot Nothing Then
                    m_Tran.Commit()
                    m_cmd.Transaction = m_Tran
                End If

            Catch ex As Exception
                Throw
            Finally
                m_Tran = Nothing
            End Try

        End Sub

        ''' <summary>
        ''' トランザクションをロールバックする
        ''' </summary>
        ''' <remarks></remarks>
        Protected Friend Sub TransactionRollBack()

            Try
                If IsOpen() = False Then
                    Throw New Exception("DB接続エラー")
                End If
                If m_Tran IsNot Nothing Then
                    m_Tran.Rollback()
                    m_cmd.Transaction = m_Tran
                End If

            Catch ex As Exception
                Throw
            Finally
                m_Tran = Nothing
            End Try

        End Sub

        ''' <summary>
        ''' 実行前処理
        ''' </summary>
        ''' <param name="v_text"></param>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <param name="v_type"></param>
        ''' <remarks></remarks>
        Private Sub BeforeExecute(ByVal v_text As String, ByVal v_param As Habits.DB.DBParameter, Optional ByVal v_type As Integer = 0)
            Try
                '' DB接続状態
                If IsOpen() = False Then
                    Throw New Exception("DB接続エラー")
                End If

                '' コマンド設定
                With m_cmd
                    If v_type = 0 Then
                        .CommandType = CommandType.Text
                    Else
                        .CommandType = CommandType.StoredProcedure
                    End If
                    .CommandText = v_text
                End With

                '' パラメータ設定
                Call ParameterClear()
                If v_param IsNot Nothing Then
                    Call ParameterSet(v_param)
                End If
            Catch ex As Exception
                Throw
            End Try
        End Sub

        ''' <summary>
        ''' データを参照する
        ''' </summary>
        ''' <param name="v_text">IN: ストアドプロシージャ名又はクエリー文</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function ExecuteDataSet(ByVal v_text As String, Optional ByVal v_type As Integer = 0) As DataSet
            Return ExecuteDataSet(v_text, Nothing, v_type)
        End Function


        ''' <summary>
        ''' データを参照する
        ''' </summary>
        ''' <param name="v_text">IN: クエリー文又はストアドプロシージャ名</param>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <param name="v_type">IN:(省略可) コマンドタイプ(0:クエリー/1:ストアドプロシージャ/Default:0) </param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function ExecuteDataSet(ByVal v_text As String, _
                                                ByVal v_param As DBParameter, _
                                                Optional ByVal v_type As Integer = 0) As DataSet
            Dim ds As New DataSet
            Dim Adapter As New SqlClient.SqlDataAdapter()

            Try
                '' 実行前処理
                Call BeforeExecute(v_text, v_param, v_type)

                Adapter.SelectCommand = m_cmd
                Adapter.Fill(ds)

            Catch ex As Exception
                Throw ex
            Finally
                Adapter.Dispose()
            End Try

            Return ds
        End Function

        ''' <summary>
        ''' データを参照する
        ''' </summary>
        ''' <param name="v_text">IN: ストアドプロシージャ名又はクエリー文</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function ExecuteDataTable(ByVal v_text As String, Optional ByVal v_type As Integer = 0) As DataTable
            Return ExecuteDataTable(v_text, Nothing, v_type)
        End Function

        ''' <summary>
        ''' データを参照する
        ''' </summary>
        ''' <param name="v_text">IN: クエリー文又はストアドプロシージャ名</param>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <param name="v_type">IN:(省略可) コマンドタイプ(0:クエリー/1:ストアドプロシージャ/Default:0) </param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function ExecuteDataTable(ByVal v_text As String, _
                                                ByVal v_param As DBParameter, _
                                                Optional ByVal v_type As Integer = 0) As DataTable
            Dim ds As New DataSet
            Dim dt As New DataTable

            Try
                ds = ExecuteDataSet(v_text, v_param, v_type)

                If Not ds.Tables.Count = 0 Then
                    dt = ds.Tables(0)
                End If

            Catch ex As Exception
                Throw ex
            End Try

            Return dt

        End Function

        ''' <summary>
        ''' 単一の値を参照する
        ''' </summary>
        ''' <param name="v_text">IN: ストアドプロシージャ名又はクエリー文</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function ExecuteScalar(ByVal v_text As String, Optional ByVal v_type As Integer = 0) As Object
            Return ExecuteDataSet(v_text, Nothing, v_type)
        End Function


        ''' <summary>
        ''' 単一の値を参照する
        ''' </summary>
        ''' <param name="v_text">IN: クエリー文又はストアドプロシージャ名</param>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <param name="v_type">IN:(省略可) コマンドタイプ(0:クエリー/1:ストアドプロシージャ/Default:0) </param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function ExecuteScalar(ByVal v_text As String, _
                                                ByVal v_param As DBParameter, _
                                                Optional ByVal v_type As Integer = 0) As Object
            Dim obj As New Object

            Try
                '' 実行前処理
                Call BeforeExecute(v_text, v_param, v_type)
                '' 実行
                obj = m_cmd.ExecuteScalar

            Catch ex As Exception
                Throw ex
            End Try

            Return obj

        End Function

        ''' <summary>
        ''' データを操作する（登録／更新／削除）
        ''' </summary>
        ''' <param name="v_text"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function ExecuteNonQuery(ByVal v_text As String, _
                                                Optional ByVal v_type As Integer = 0) As Integer
            Return Me.ExecuteNonQuery(v_text, Nothing, v_type)
        End Function

        ''' <summary>
        ''' データを操作する（登録／更新／削除）
        ''' </summary>
        ''' <param name="v_text"></param>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function ExecuteNonQuery(ByVal v_text As String, _
                                                ByVal v_param As DBParameter, _
                                                Optional ByVal v_type As Integer = 0) As Integer
            Dim rtn As Integer

            Try
                '' 実行前処理
                Call BeforeExecute(v_text, v_param, v_type)
                '' 実行
                rtn = m_cmd.ExecuteNonQuery

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>
        ''' パラメーターの全クリア
        ''' </summary>
        ''' <remarks></remarks>
        Protected Friend Sub ParameterClear()
            m_cmd.Parameters.Clear()
        End Sub

        ''' <summary>
        ''' パラメーターの設定
        ''' </summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <remarks></remarks>
        Protected Friend Sub ParameterSet(ByVal v_param As DBParameter)
            Dim parameter As String
            Dim value As Object

            For i As Integer = 0 To v_param.Count() - 1
                parameter = v_param.GetParameterName(i)
                value = v_param.GetValue(i)
                m_cmd.Parameters.AddWithValue(parameter, value)
            Next

        End Sub

        ''' <summary>
        ''' Dispose
        ''' </summary>
        ''' <param name="disposing"></param>
        ''' <remarks></remarks>
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposed Then
                If disposing Then
                    ' Insert code to free unmanaged resources.
                End If

                ' Insert code to free shared resources.

            End If
            Me.disposed = True
        End Sub

#Region " IDisposable Support "
        ' Do not change or add Overridable to these methods.
        ' Put cleanup code in Dispose(ByVal disposing As Boolean).
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
        Protected Overrides Sub Finalize()
            Dispose(False)
            MyBase.Finalize()
        End Sub
#End Region

#End Region

    End Class

End Namespace
