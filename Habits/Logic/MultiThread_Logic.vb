Namespace Habits.Logic
    ''' <summary>共通ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class MultiThread_Logic

        ''マルチスレッドにするため、他のロジックとコネクション分ける必要あり

#Region "アップロードデータ格納パス取得"
        ''' <summary>アップロードデータ格納パス取得</summary>
        ''' <returns>データ格納パス名</returns>
        ''' <remarks></remarks>
        Function select_ASY() As DataTable
            Dim dt As DataTable
            Dim v_param As New Habits.DB.DBParameter
            Dim str_sql As String
            Try
                str_sql = "SELECT データ格納パス名 FROM A_システム"
                dt = DBA2.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "通信中エラー回数取得"
        ''' <summary></summary>
        ''' <returns>通信中エラー回数取得</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetConnectError() As DataTable
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                str_sql = "SELECT 通信中エラー回数 FROM M_送受信"
                dt = DBA2.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "Z_SQL実行履歴取得"
        ''' <summary>Z_SQL実行履歴取得</summary>
        ''' <returns>顧客番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_SQLHistory() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 処理番号,SQL1 FROM Z_SQL実行履歴 WHERE 処理番号 = (SELECT MIN(処理番号) FROM Z_SQL実行履歴)"
                dt = DBA2.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "Z_SQL実行履歴削除"
        ''' <summary>Z_SQL実行履歴削除</summary>
        ''' <returns>顧客番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_SQLHistory(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String

            Try
                ' トランザクション開始
                DBA2.TransactionStart()

                'Z_SQL実行履歴削除
                str_sql = "DELETE FROM Z_SQL実行履歴 WHERE 処理番号 =@処理番号"
                rtn = DBA2.ExecuteNonQuery(str_sql, v_param)

                ' コミット
                DBA2.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA2.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "通信中エラー回数更新"
        ''' <summary>通信中エラー回数更新</summary>
        ''' <returns>処理結果</returns>
        ''' <remarks></remarks>
        Protected Friend Function UpdateConnectError(ByVal v_param As Habits.DB.DBParameter) As Long
            Dim str_sql As String
            Try
                str_sql = "UPDATE M_送受信 SET 通信中エラー回数 = @通信中エラー回数"
                rtn = DBA2.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

    End Class
End Namespace

