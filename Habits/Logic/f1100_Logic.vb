#Region "C|[g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>Hö}X^æÊWbNNX</summary>
    ''' <remarks></remarks>
    Public Class f1100_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f1100_Hö}X^"

        ''' <summary>Höêæ¾</summary>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function àeXV() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                'f[^ðæ¾
                builSQL.Append("SELECT HöÔ,Hö¼,|Cg,\¦,")
                builSQL.Append(" CASE WHEN ítO = 'False' THEN '  ' ELSE '~' END AS \¦")
                builSQL.Append(" FROM B_Hö")
                builSQL.Append(" ORDER BY \¦,HöÔ")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>B_Höo^</summary>
        ''' <param name="v_param">SQLp[^F@HöÔ/@Hö¼/@|Cg/@ítO/@o^ú/@XVú</param>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function Höo^(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' gUNVJn
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO B_Hö(")
                builSQL.Append(" HöÔ,")
                builSQL.Append(" Hö¼,")
                builSQL.Append(" |Cg,")
                builSQL.Append(" \¦,")
                builSQL.Append(" ítO,")
                builSQL.Append(" o^ú,")
                builSQL.Append(" XVú)")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @HöÔ,")
                builSQL.Append(" @Hö¼,")
                builSQL.Append(" @|Cg,")
                builSQL.Append(" @\¦,")
                builSQL.Append(" @ítO,")
                builSQL.Append(" @o^ú,")
                builSQL.Append(" @XVú)")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQLÀsð INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1Ýè
                builSQL.Append("INSERT INTO process(")
                builSQL.Append(" shop_code,")
                builSQL.Append(" code,")        'HöÔ
                builSQL.Append(" name,")        'Hö¼
                builSQL.Append(" point,")       '|Cg
                builSQL.Append(" display_order,")   '\¦
                builSQL.Append(" delete_flag,")     'ítO
                builSQL.Append(" insert_date,")     'o^ú
                builSQL.Append(" update_date)")     'XVú
                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@HöÔ")) & ",")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@Hö¼")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@|Cg")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@\¦")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@ítO")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@o^ú")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@XVú")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' R~bg
                DBA.TransactionCommit()
            Catch ex As Exception
                '' áO­¶Í[obN
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>B_HöÌ|Cgæ¾</summary>
        ''' <param name="v_param">SQLp[^F@HöÔ</param>
        ''' <returns>|Cg</returns>
        ''' <remarks></remarks>
        Protected Friend Function ÔmF(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT |Cg FROM B_Hö WHERE HöÔ = @HöÔ"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>¤iiXÌÎÛOjÌXV</summary>
        ''' <param name="v_param">SQLp[^F@Hö¼/@|Cg/@\¦/@ítO/@XVú/@HöÔ</param>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function HöÏX(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' gUNVJn
                DBA.TransactionStart()

                builSQL.Append("UPDATE B_Hö SET")
                builSQL.Append(" Hö¼ = @Hö¼,")
                builSQL.Append(" |Cg = @|Cg,")
                builSQL.Append(" \¦ = @\¦,")
                builSQL.Append(" ítO = @ítO,")
                builSQL.Append(" XVú = @XVú")
                builSQL.Append(" WHERE HöÔ = @HöÔ ")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQLÀsð INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1Ýè
                builSQL.Append("UPDATE process SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@Hö¼")) & ",")
                builSQL.Append(" point =" & VbSQLStr(v_param.GetValue("@|Cg")) & ",")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue("@\¦")) & ",")
                builSQL.Append(" delete_flag =" & VbSQLStr(v_param.GetValue("@ítO")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@XVú")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@HöÔ")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' R~bg
                DBA.TransactionCommit()
            Catch ex As Exception
                '' áO­¶Í[obN
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>ÅåHöÔæ¾</summary>
        ''' <returns>ÅåHöÔ</returns>
        ''' <remarks></remarks>
        Protected Friend Function getMaxProcessNumber() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT MAX(HöÔ) AS ÅåÔ FROM B_Hö"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

    End Class

End Namespace
