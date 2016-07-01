Namespace Habits.Logic

    ''' <summary>顧客番号設定画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a0500_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>顧客番号存在チェック</summary>
        ''' <param name="v_param">SQLパラメータ:@顧客番号</param>
        ''' <returns>True:存在、False：存在しない</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_a0500_顧客番号(ByVal v_param As Habits.DB.DBParameter) As Boolean
            Dim str_sql As String
            Dim dt As DataTable
            Dim rtn As Boolean
            rtn = False
            Try
                str_sql = "SELECT 顧客番号 FROM D_顧客 WHERE 顧客番号 = @顧客番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
                If (dt.Rows.Count > 0) Then
                    rtn = True
                End If
            Catch ex As Exception
                ''例外時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
    End Class
End Namespace