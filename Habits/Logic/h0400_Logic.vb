#Region "C|[g"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>¢o^ÒæÊWbNNX</summary>
    ''' <remarks></remarks>
    Public Class h0400_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "h0400_¢o^Ò"

        ''' <summary>Z¢o^ÌÚqæ¾io^ÏÌÝj</summary>
        ''' <returns>ÚqXg</returns>
        ''' <remarks></remarks>
        Function ¢o^Òê() As DataTable
            Return getCustomerList(True)
        End Function

        ''' <summary>Z¢o^ÌÚqæ¾i¼o^ÜÞj</summary>
        ''' <returns>ÚqXg</returns>
        ''' <remarks></remarks>
        Function ¼o^ÜÞ¢o^ê() As DataTable
            Return getCustomerList(False)
        End Function

        ''' <summary>SÒ¼æ¾</summary>
        ''' <returns>SÒ¼Xg</returns>
        ''' <remarks></remarks>
        Function ChargeTanyouPerson() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function

        ''' <summary>Z¢o^ÌÚqXgæ¾</summary>
        ''' <param name="RegistedFlg">True:o^ÏAFalseF¼o^</param>
        ''' <returns>ÚqXg</returns>
        ''' <remarks></remarks>
        Function getCustomerList(ByVal RegistedFlg As Boolean) As DataTable
            Dim rtn As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT ÚqÔ, ©, ¼,")
                builSQL.Append(" CONVERT(nvarchar(11), o^ú, 111) AS o^ú")
                builSQL.Append(" FROM D_Úq ")
                builSQL.Append(" WHERE ( (s¹{§ IS NULL OR s¹{§='')")
                builSQL.Append(" OR ((Z1 IS NULL OR Z1='') AND (Z2 IS NULL OR Z2='')))")
                builSQL.Append(" AND ÚqÔ < ")
                builSQL.Append(Clng_STFreeNo)
                If (RegistedFlg) Then
                    builSQL.Append(" AND o^æªÔ = '1'")
                End If
                builSQL.Append(" ORDER BY ÚqÔ")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>Úqîñæ¾</summary>
        ''' <param name="v_param">SQLp[^F@ÚqÔ</param>
        ''' <returns>Úqîñ</returns>
        ''' <remarks></remarks>
        Protected Friend Function CustomerInfo(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT D_Úq.ÚqÔ ,D_Úq.© ,D_Úq.¼ ,D_Úq.©Ji ,D_Úq.¼Ji")
                builSQL.Append(" ,D_Úq.«ÊÔ ,B_«Ê.«Ê ,D_Úq.¶Nú ,D_Úq.XÖÔ")
                builSQL.Append(" ,D_Úq.s¹{§ ,D_Úq.Z1 ,D_Úq.Z2 ,D_Úq.Z3")
                builSQL.Append(" ,D_Úq.dbÔ ,D_Úq.EmailAhX ,D_Úq.Æ°¼ ,D_Úq.ï¡")
                builSQL.Append(" ,D_Úq.D«Èbè ,D_Úq.¢Èbè ,D_Úq.`¾tO ,D_Úq.")
                builSQL.Append(" ,D_Úq.ÐîÒ ,D_Úq.OñXú ,D_Úq.XúN_1 ,D_Úq.XúN_2")
                builSQL.Append(" ,D_Úq.Xñ ,D_Úq.åSÒÔ ,D_SÒ.SÒ¼ ,D_Úq.o^æªÔ")
                builSQL.Append(" ,B_o^æª.o^æª,D_Úq.o^ú ,D_Úq.XVú")
                builSQL.Append(" FROM D_Úq LEFT JOIN B_«Ê ON D_Úq.«ÊÔ = B_«Ê.«ÊÔ")
                builSQL.Append(" LEFT JOIN D_SÒ ON D_Úq.åSÒÔ = D_SÒ.SÒÔ")
                builSQL.Append(" LEFT JOIN B_o^æª ON D_Úq.o^æªÔ = B_o^æª.o^æªÔ")
                builSQL.Append(" WHERE D_Úq.ÚqÔ=@ÚqÔ")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            v_param.Clear()
            Return dt
        End Function

        ''' <summary>ÚqîñÌXV</summary>
        ''' <param name="v_param">SQLp[^F@o^æªÔ/@XVú/@ÚqÔ</param>
        ''' <returns>tO</returns>
        ''' <remarks></remarks>
        Protected Friend Function ¼o^(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("UPDATE D_Úq SET")
                builSQL.Append(" o^æªÔ = '0',")
                builSQL.Append(" XVú = @XVú")
                builSQL.Append(" WHERE ÚqÔ = @ÚqÔ")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQLÀsð INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1Ýè
                builSQL.Append("UPDATE basis_customer SET ")
                builSQL.Append("register_code =''0''")
                builSQL.Append(", update_date =" & VbSQLStr(v_param.GetValue("@XVú")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@ÚqÔ")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>«Ê¼Ìêæ¾</summary>
        ''' <returns>«ÊXg</returns>
        ''' <remarks></remarks>
        Function SexType() As DataTable
            Return MyBase.B_«Ê()
        End Function

        ''' <summary>o^æªêæ¾</summary>
        ''' <returns>o^æªXg</returns>
        ''' <remarks></remarks>
        Function SelectedDivision() As DataTable
            Return MyBase.B_o^æª()
        End Function

        ''' <summary>SÒ¼êæ¾</summary>
        ''' <returns>SÒXg</returns>
        ''' <remarks></remarks>
        Function ChargePerson() As DataTable
            Return MyBase.GetStaffNameList()
        End Function

        ''' <summary>o^æªÔæ¾</summary>
        ''' <param name="v_param">SQLp[^F@ÚqÔ</param>
        ''' <returns>o^æªÔ</returns>
        ''' <remarks></remarks>
        Function o^ÏÔmF(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT o^æªÔ FROM D_Úq WHERE ÚqÔ = @ÚqÔ"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace

