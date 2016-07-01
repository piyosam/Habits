#Region "ƒCƒ“ƒ|[ƒg"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>–¢“o˜^Ò‰æ–ÊƒƒWƒbƒNƒNƒ‰ƒX</summary>
    ''' <remarks></remarks>
    Public Class h0400_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "h0400_–¢“o˜^Ò"

        ''' <summary>ZŠ–¢“o˜^‚ÌŒÚ‹qæ“¾i“o˜^Ï‚Ì‚İj</summary>
        ''' <returns>ŒÚ‹qƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Function –¢“o˜^Òˆê——() As DataTable
            Return getCustomerList(True)
        End Function

        ''' <summary>ZŠ–¢“o˜^‚ÌŒÚ‹qæ“¾i‰¼“o˜^ŠÜ‚Şj</summary>
        ''' <returns>ŒÚ‹qƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Function ‰¼“o˜^ŠÜ‚Ş–¢“o˜^ˆê——() As DataTable
            Return getCustomerList(False)
        End Function

        ''' <summary>’S“–Ò–¼æ“¾</summary>
        ''' <returns>’S“–Ò–¼ƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Function ChargeTanyouPerson() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function

        ''' <summary>ZŠ–¢“o˜^‚ÌŒÚ‹qƒŠƒXƒgæ“¾</summary>
        ''' <param name="RegistedFlg">True:“o˜^ÏAFalseF‰¼“o˜^</param>
        ''' <returns>ŒÚ‹qƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Function getCustomerList(ByVal RegistedFlg As Boolean) As DataTable
            Dim rtn As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT ŒÚ‹q”Ô†, ©, –¼,")
                builSQL.Append(" CONVERT(nvarchar(11), “o˜^“ú, 111) AS “o˜^“ú")
                builSQL.Append(" FROM D_ŒÚ‹q ")
                builSQL.Append(" WHERE ( (“s“¹•{Œ§ IS NULL OR “s“¹•{Œ§='')")
                builSQL.Append(" OR ((ZŠ1 IS NULL OR ZŠ1='') AND (ZŠ2 IS NULL OR ZŠ2='')))")
                builSQL.Append(" AND ŒÚ‹q”Ô† < ")
                builSQL.Append(Clng_STFreeNo)
                If (RegistedFlg) Then
                    builSQL.Append(" AND “o˜^‹æ•ª”Ô† = '1'")
                End If
                builSQL.Append(" ORDER BY ŒÚ‹q”Ô†")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>ŒÚ‹qî•ñæ“¾</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@ŒÚ‹q”Ô†</param>
        ''' <returns>ŒÚ‹qî•ñ</returns>
        ''' <remarks></remarks>
        Protected Friend Function CustomerInfo(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT D_ŒÚ‹q.ŒÚ‹q”Ô† ,D_ŒÚ‹q.© ,D_ŒÚ‹q.–¼ ,D_ŒÚ‹q.©ƒJƒi ,D_ŒÚ‹q.–¼ƒJƒi")
                builSQL.Append(" ,D_ŒÚ‹q.«•Ê”Ô† ,B_«•Ê.«•Ê ,D_ŒÚ‹q.¶”NŒ“ú ,D_ŒÚ‹q.—X•Ö”Ô†")
                builSQL.Append(" ,D_ŒÚ‹q.“s“¹•{Œ§ ,D_ŒÚ‹q.ZŠ1 ,D_ŒÚ‹q.ZŠ2 ,D_ŒÚ‹q.ZŠ3")
                builSQL.Append(" ,D_ŒÚ‹q.“d˜b”Ô† ,D_ŒÚ‹q.EmailƒAƒhƒŒƒX ,D_ŒÚ‹q.‰Æ‘°–¼ ,D_ŒÚ‹q.ï–¡")
                builSQL.Append(" ,D_ŒÚ‹q.D‚«‚È˜b‘è ,D_ŒÚ‹q.Œ™‚¢‚È˜b‘è ,D_ŒÚ‹q.“`Œ¾ƒtƒ‰ƒO ,D_ŒÚ‹q.ƒƒ‚")
                builSQL.Append(" ,D_ŒÚ‹q.Ğ‰îÒ ,D_ŒÚ‹q.‘O‰ñ—ˆ“X“ú ,D_ŒÚ‹q.—ˆ“X“úN_1 ,D_ŒÚ‹q.—ˆ“X“úN_2")
                builSQL.Append(" ,D_ŒÚ‹q.—ˆ“X‰ñ” ,D_ŒÚ‹q.å’S“–Ò”Ô† ,D_’S“–Ò.’S“–Ò–¼ ,D_ŒÚ‹q.“o˜^‹æ•ª”Ô†")
                builSQL.Append(" ,B_“o˜^‹æ•ª.“o˜^‹æ•ª,D_ŒÚ‹q.“o˜^“ú ,D_ŒÚ‹q.XV“ú")
                builSQL.Append(" FROM D_ŒÚ‹q LEFT JOIN B_«•Ê ON D_ŒÚ‹q.«•Ê”Ô† = B_«•Ê.«•Ê”Ô†")
                builSQL.Append(" LEFT JOIN D_’S“–Ò ON D_ŒÚ‹q.å’S“–Ò”Ô† = D_’S“–Ò.’S“–Ò”Ô†")
                builSQL.Append(" LEFT JOIN B_“o˜^‹æ•ª ON D_ŒÚ‹q.“o˜^‹æ•ª”Ô† = B_“o˜^‹æ•ª.“o˜^‹æ•ª”Ô†")
                builSQL.Append(" WHERE D_ŒÚ‹q.ŒÚ‹q”Ô†=@ŒÚ‹q”Ô†")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            v_param.Clear()
            Return dt
        End Function

        ''' <summary>ŒÚ‹qî•ñ‚ÌXV</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@“o˜^‹æ•ª”Ô†/@XV“ú/@ŒÚ‹q”Ô†</param>
        ''' <returns>ˆ—ƒtƒ‰ƒO</returns>
        ''' <remarks></remarks>
        Protected Friend Function ‰¼“o˜^ˆ—(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("UPDATE D_ŒÚ‹q SET")
                builSQL.Append(" “o˜^‹æ•ª”Ô† = '0',")
                builSQL.Append(" XV“ú = @XV“ú")
                builSQL.Append(" WHERE ŒÚ‹q”Ô† = @ŒÚ‹q”Ô†")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQLÀs—š—ğ INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1İ’è
                builSQL.Append("UPDATE basis_customer SET ")
                builSQL.Append("register_code =''0''")
                builSQL.Append(", update_date =" & VbSQLStr(v_param.GetValue("@XV“ú")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@ŒÚ‹q”Ô†")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>«•Ê–¼Ìˆê——æ“¾</summary>
        ''' <returns>«•ÊƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Function SexType() As DataTable
            Return MyBase.B_«•Ê()
        End Function

        ''' <summary>“o˜^‹æ•ªˆê——æ“¾</summary>
        ''' <returns>“o˜^‹æ•ªƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Function SelectedDivision() As DataTable
            Return MyBase.B_“o˜^‹æ•ª()
        End Function

        ''' <summary>’S“–Ò–¼ˆê——æ“¾</summary>
        ''' <returns>’S“–ÒƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Function ChargePerson() As DataTable
            Return MyBase.GetStaffNameList()
        End Function

        ''' <summary>“o˜^‹æ•ª”Ô†æ“¾</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@ŒÚ‹q”Ô†</param>
        ''' <returns>“o˜^‹æ•ª”Ô†</returns>
        ''' <remarks></remarks>
        Function “o˜^Ï”Ô†Šm”F(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT “o˜^‹æ•ª”Ô† FROM D_ŒÚ‹q WHERE ŒÚ‹q”Ô† = @ŒÚ‹q”Ô†"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace

