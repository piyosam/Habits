Namespace Habits.Logic
    ''' <summary>空番号選択画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class z0200_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>空番号取得</summary>
        ''' <returns>空番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function z_空番号取得() As DataTable
            Dim rtn As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 空番号,顧客名 FROM W_空番号 ORDER BY 空番号"
                rtn = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                '’例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>空番号更新</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 空番号一覧更新(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Try
                str_sql = "INSERT INTO W_空番号 (空番号,顧客名) VALUES(@空番号,'未使用')"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param, 0)

            Catch ex As Exception
                '’例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>顧客番号取得</summary>
        ''' <param name="v_param">SQLパラメータ：@開始顧客番号/@終了顧客番号</param>
        ''' <returns>顧客番号リスト</returns>
        ''' <remarks>開始顧客番号から終了顧客番号までの顧客番号リスト取得</remarks>
        Protected Friend Function 顧客番号取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.GetCustomerNum(v_param)
        End Function

        ''' <summary>空番号削除</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 空番号削除() As Integer
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                str_sql = "DELETE W_空番号 FROM W_空番号;"
                rtn = DBA.ExecuteNonQuery(str_sql)
                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>新規顧客番号取得</summary>
        ''' <returns>最大顧客番号＋1</returns>
        ''' <remarks></remarks>
        Protected Friend Function 最小空番号() As String
            Return MyBase.NewCustomerNumber()
        End Function

    End Class
End Namespace
