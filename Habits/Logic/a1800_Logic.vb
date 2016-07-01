#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    Public Class a1800_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1800_通信設定"

        ''' <summary></summary>
        ''' <returns>通信許可フラグ取得</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetConnectFlag() As DataTable
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                str_sql = "SELECT 通信許可フラグ FROM A_システム"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary></summary>
        ''' <returns>通信許可フラグ更新</returns>
        ''' <remarks></remarks>
        Protected Friend Function UpdateConnectFlag(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                str_sql = "UPDATE A_システム SET 通信許可フラグ = @通信許可フラグ"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

                str_sql = "UPDATE system SET network_flag=" & VbSQLStr(v_param.GetValue("@通信許可フラグ")) & _
                        " WHERE shop_code=" & VbSQLNStr(sShopcode)
                rtn = InsertZSqlExecHis(PAGE_TITLE, str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function


    End Class
End Namespace