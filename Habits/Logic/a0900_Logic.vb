Namespace Habits.Logic
    ''' <summary>伝言メモ画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a0900_Logic
        Inherits Habits.Logic.LogicBase ''ロジックベースを継承

        ''' <summary>伝言メモ取得</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>伝言メモ</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_a0900_伝言メモ(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT メモ FROM D_顧客 WHERE 顧客番号 = @顧客番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                ''例外時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace

