#Region "C|[g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>XÖÔõæÊWbN</summary>
    ''' <remarks></remarks>
    Public Class z0600_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>s¹{§¼êÌæ¾</summary>
        ''' <returns>s¹{§¼Xg</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_s¹{§¼() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable

            Try
                builSQL.Append("SELECT B_XÖÔ.s¹{§¼")
                builSQL.Append(" FROM B_XÖÔ")
                builSQL.Append(" GROUP BY B_XÖÔ.s¹{§¼")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex

            End Try
            Return dt
        End Function

        ''' <summary>sæ¬º¼êæ¾</summary>
        ''' <param name="v_param">SQLp[^F@s¹{§¼</param>
        ''' <returns>sæ¬ºXg</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_sæ¬º¼(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable

            Try
                builSQL.Append("SELECT sæ¬º¼")
                builSQL.Append(" FROM B_XÖÔ")
                builSQL.Append(" WHERE s¹{§¼ = @s¹{§¼")
                builSQL.Append(" GROUP BY sæ¬º¼")
                builSQL.Append(" ORDER BY sæ¬º¼")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex

            End Try
            Return dt
        End Function

        ''' <summary>A_VXeÌsæ¬ºæ¾</summary>
        ''' <returns>sæ¬ºîñ</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_ASY() As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT s¹{§,sæ¬º FROM A_VXe"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>¬æêæ¾</summary>
        ''' <param name="v_param">SQLp[^F@ª¶</param>
        ''' <returns>¬æXg</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_YUU(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT VXÖÔ\¦p, ¬æ¼")
                builSQL.Append(" FROM B_XÖÔ")
                builSQL.Append(" WHERE sæ¬º¼ = @sæ¬º¼ AND ¬æ¼Ji LIKE @ª¶ ")
                builSQL.Append(" ORDER BY ¬æ¼Ji")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace