#Region "C|[g"
Imports System.Text
#End Region

Namespace Habits.Logic

    ''' <summary>[UîñæÊWbNNX</summary>
    ''' <remarks></remarks>
    Public Class a1000_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1000_[U[îñ"

        ''' <summary>A_VXeæ¾</summary>
        ''' <returns>VXeîñ</returns>
        ''' <remarks></remarks>
        Protected Friend Function getA_System() As DataTable
            Return MyBase.A_System()
        End Function

        ''' <summary>A_VXeXV</summary>
        ''' <param name="v_param">
        ''' p[^F@X¼1/@X¼2/@ã\Ò¼/@XXÖÔ/@XZ1/@XZ2
        ''' @XdbÔ/@XFAXÔ/@Ýõä/@Wàz/@s¹{§/@sæ¬º/@ÏXú/@÷Jnú</param>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function updateA_System(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' gUNVJn
                DBA.TransactionStart()

                builSQL.Append("UPDATE A_VXe SET")
                builSQL.Append(" X¼1 = @X¼1")
                builSQL.Append(", X¼2 = @X¼2")
                builSQL.Append(", ã\Ò¼ = @ã\Ò¼")
                builSQL.Append(", XXÖÔ = @XXÖÔ")
                builSQL.Append(", XZ1 = @XZ1")
                builSQL.Append(", XZ2 = @XZ2")
                builSQL.Append(", XdbÔ = @XdbÔ")
                builSQL.Append(", XFAXÔ = @XFAXÔ")
                builSQL.Append(", Ýõä = @Ýõä")
                builSQL.Append(", Wàz = @Wàz")
                builSQL.Append(", s¹{§ = @s¹{§")
                builSQL.Append(", sæ¬º = @sæ¬º")
                builSQL.Append(", ÏXú = @ÏXú")
                builSQL.Append(", ÷Jnú = @÷Jnú")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQLÀsð INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1Ýè
                builSQL.Append("UPDATE system SET")
                builSQL.Append(" shop_name1 =" & VbSQLNStr(v_param.GetValue("@X¼1")))
                builSQL.Append(", shop_name2 =" & VbSQLNStr(v_param.GetValue("@X¼2")))
                builSQL.Append(", manager =" & VbSQLNStr(v_param.GetValue("@ã\Ò¼")))
                builSQL.Append(", post_code =" & VbSQLNStr(v_param.GetValue("@XXÖÔ")))
                builSQL.Append(", address1 =" & VbSQLNStr(v_param.GetValue("@XZ1")))
                builSQL.Append(", address2 =" & VbSQLNStr(v_param.GetValue("@XZ2")))
                builSQL.Append(", phone =" & VbSQLNStr(v_param.GetValue("@XdbÔ")))
                builSQL.Append(", fax =" & VbSQLNStr(v_param.GetValue("@XFAXÔ")))
                builSQL.Append(", accommodated_count =" & VbSQLStr(v_param.GetValue("@Ýõä")))
                builSQL.Append(", register_amount =" & VbSQLStr(v_param.GetValue("@Wàz")))
                builSQL.Append(", prefectures_name =" & VbSQLNStr(v_param.GetValue("@s¹{§")))
                builSQL.Append(", cities_name =" & VbSQLNStr(v_param.GetValue("@sæ¬º")))
                builSQL.Append(", update_date =" & VbSQLStr(v_param.GetValue("@ÏXú")))
                builSQL.Append(", start_day =" & VbSQLStr(v_param.GetValue("@÷Jnú")))
                builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' R~bg
                DBA.TransactionCommit()
            Catch ex As Exception
                ' [obN
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Function

        ''' <summary>A_VXeXV</summary>
        ''' <param name="v_param">
        ''' p[^F@X¼1/@X¼2/@ã\Ò¼/@XXÖÔ/@XZ1/@XZ2
        ''' @XdbÔ/@XFAXÔ/@Ýõä/@Wàz/@s¹{§/@sæ¬º/@ÏXú/@÷Jnú</param>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function updatePartOfA_System(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' gUNVJn
                DBA.TransactionStart()

                builSQL.Append("UPDATE A_VXe SET")
                builSQL.Append(" X¼1 = @X¼1")
                builSQL.Append(", X¼2 = @X¼2")
                builSQL.Append(", ã\Ò¼ = @ã\Ò¼")
                builSQL.Append(", XXÖÔ = @XXÖÔ")
                builSQL.Append(", XZ1 = @XZ1")
                builSQL.Append(", XZ2 = @XZ2")
                builSQL.Append(", XdbÔ = @XdbÔ")
                builSQL.Append(", XFAXÔ = @XFAXÔ")
                builSQL.Append(", Ýõä = @Ýõä")
                builSQL.Append(", Wàz = @Wàz")
                builSQL.Append(", ÏXú = @ÏXú")
                builSQL.Append(", ÷Jnú = @÷Jnú")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQLÀsð INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1Ýè
                builSQL.Append("UPDATE system SET")
                builSQL.Append(" shop_name1 =" & VbSQLNStr(v_param.GetValue("@X¼1")))
                builSQL.Append(", shop_name2 =" & VbSQLNStr(v_param.GetValue("@X¼2")))
                builSQL.Append(", manager =" & VbSQLNStr(v_param.GetValue("@ã\Ò¼")))
                builSQL.Append(", post_code =" & VbSQLNStr(v_param.GetValue("@XXÖÔ")))
                builSQL.Append(", address1 =" & VbSQLNStr(v_param.GetValue("@XZ1")))
                builSQL.Append(", address2 =" & VbSQLNStr(v_param.GetValue("@XZ2")))
                builSQL.Append(", phone =" & VbSQLNStr(v_param.GetValue("@XdbÔ")))
                builSQL.Append(", fax =" & VbSQLNStr(v_param.GetValue("@XFAXÔ")))
                builSQL.Append(", accommodated_count =" & VbSQLStr(v_param.GetValue("@Ýõä")))
                builSQL.Append(", register_amount =" & VbSQLStr(v_param.GetValue("@Wàz")))
                builSQL.Append(", update_date =" & VbSQLStr(v_param.GetValue("@ÏXú")))
                builSQL.Append(", start_day =" & VbSQLStr(v_param.GetValue("@÷Jnú")))
                builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' R~bg
                DBA.TransactionCommit()
            Catch ex As Exception
                ' [obN
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Function


        ''' <summary>XÖÔÉÄsæ¬ºõ</summary>
        ''' <param name="v_param">SQLp[^F@VXÖÔ\¦p</param>
        ''' <returns>sæ¬º¼</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_address(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.SearchAddress(v_param)
        End Function
    End Class
End Namespace
