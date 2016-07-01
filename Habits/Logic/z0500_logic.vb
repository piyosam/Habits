#Region "ƒCƒ“ƒ|[ƒg"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>ŒÚ‹q•ÏX‰æ–ÊƒƒWƒbƒNƒNƒ‰ƒX</summary>
    ''' <remarks></remarks>
    Public Class z0500_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "z_0500_ŒÚ‹q•ÏX"

        ''' <summary>ŒÚ‹qî•ñ‚ÌXV</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^</param>
        ''' <returns>ˆ—ƒtƒ‰ƒO</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_D_ŒÚ‹q(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("UPDATE D_ŒÚ‹q SET")
                builSQL.Append(" © = @©,")
                builSQL.Append(" –¼ = @–¼,")
                builSQL.Append(" ©ƒJƒi = @©ƒJƒi,")
                builSQL.Append(" –¼ƒJƒi = @–¼ƒJƒi,")
                builSQL.Append(" «•Ê”Ô† = ( SELECT «•Ê”Ô† FROM B_«•Ê WHERE «•Ê = @«•Ê), ")
                builSQL.Append(" ¶”NŒ“ú = @¶”NŒ“ú,")
                builSQL.Append(" —X•Ö”Ô† =@—X•Ö”Ô†,")
                builSQL.Append(" “s“¹•{Œ§ = @“s“¹•{Œ§,")
                builSQL.Append(" ZŠ1 = @ZŠ1,")
                builSQL.Append(" ZŠ2 = @ZŠ2,")
                builSQL.Append(" ZŠ3 = @ZŠ3,")
                builSQL.Append(" “d˜b”Ô† = @“d˜b”Ô†,")
                builSQL.Append(" EmailƒAƒhƒŒƒX = @ƒAƒhƒŒƒX,")
                builSQL.Append(" ‰Æ‘°–¼ = @‰Æ‘°–¼,")
                builSQL.Append(" ï–¡ = @ï–¡,")
                builSQL.Append(" D‚«‚È˜b‘è = @D‚«‚È˜b‘è,")
                builSQL.Append(" Œ™‚¢‚È˜b‘è = @Œ™‚¢‚È˜b‘è,")
                builSQL.Append(" ƒƒ‚ = @ƒƒ‚,")
                builSQL.Append(" Ğ‰îÒ = @Ğ‰îÒ,")
                builSQL.Append(" å’S“–Ò”Ô† = ( SELECT ’S“–Ò”Ô† FROM D_’S“–Ò WHERE ’S“–Ò–¼ = @’S“–Ò–¼),")
                builSQL.Append(" “o˜^‹æ•ª”Ô† = ( SELECT “o˜^‹æ•ª”Ô† FROM B_“o˜^‹æ•ª WHERE “o˜^‹æ•ª = @“o˜^‹æ•ª),")
                builSQL.Append(" XV“ú = @XV“ú")
                builSQL.Append(" WHERE ŒÚ‹q”Ô† = @ŒÚ‹q”Ô†")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQLÀs—š—ğ INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlUpdBasis_customer(v_param))

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>E_—ˆ“XÒ‚ÌXV</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@©/@©ƒJƒi/@–¼/@ZŠ/@XV“ú/@ŒÚ‹q”Ô†/@—ˆ“X“ú</param>
        ''' <returns>ˆ—ƒtƒ‰ƒO</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_E_—ˆ“XÒ(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Dim dt As DataTable
            Try
                '—ˆ“XÒƒŒƒR[ƒh‘¶İƒ`ƒFƒbƒN
                builSQL.Append("SELECT * FROM E_—ˆ“XÒ")
                builSQL.Append(" WHERE ŒÚ‹q”Ô† = @ŒÚ‹q”Ô†")
                builSQL.Append(" AND —ˆ“X“ú = @—ˆ“X“ú")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

                If (dt.Rows.Count > 0) Then
                    builSQL.Length = 0
                    builSQL.Append("UPDATE E_—ˆ“XÒ SET")
                    builSQL.Append(" © = @©,")
                    builSQL.Append(" ©ƒJƒi = @©ƒJƒi,")
                    builSQL.Append(" –¼ = @–¼,")
                    builSQL.Append(" ZŠ = @ZŠ,")
                    builSQL.Append(" XV“ú=@XV“ú,")
                    builSQL.Append(" å’S“–Ò”Ô†=@å’S“–Ò”Ô†")
                    builSQL.Append(" WHERE ŒÚ‹q”Ô† = @ŒÚ‹q”Ô†")
                    builSQL.Append(" AND —ˆ“X“ú = @—ˆ“X“ú")

                    str_sql = builSQL.ToString
                    rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                    '------------------------------
                    'Z_SQLÀs—š—ğ INSERT
                    '------------------------------
                    builSQL.Length = 0
                    ' SQL1İ’è
                    builSQL.Append("UPDATE visit SET")
                    builSQL.Append(" last_name =" & VbSQLNStr(v_param.GetValue("@©")) & ",")
                    builSQL.Append(" last_name_kana =" & VbSQLNStr(v_param.GetValue("@©ƒJƒi")) & ",")
                    builSQL.Append(" first_name =" & VbSQLNStr(v_param.GetValue("@–¼")) & ",")
                    builSQL.Append(" address =" & VbSQLNStr(v_param.GetValue("@ZŠ")) & ",")
                    builSQL.Append(" update_date=" & VbSQLStr(v_param.GetValue("@XV“ú")) & ",")
                    builSQL.Append(" main_staff_code=" & VbSQLStr(v_param.GetValue("@å’S“–Ò”Ô†")))
                    builSQL.Append(" WHERE basis_customer_code =" & VbSQLStr(v_param.GetValue("@ŒÚ‹q”Ô†")))
                    builSQL.Append(" AND date =" & VbSQLStr(v_param.GetValue("@—ˆ“X“ú")))
                    builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                    InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)
                End If
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>—ˆ“XÒ”Ô†‚Ìæ“¾</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@ŒÚ‹q”Ô†/@—ˆ“X“ú</param>
        ''' <returns>—ˆ“XÒ”Ô†</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_E_—ˆ“XÒ(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT —ˆ“XÒ”Ô† FROM E_—ˆ“XÒ WHERE ŒÚ‹q”Ô† = @ŒÚ‹q”Ô† AND —ˆ“X“ú = @—ˆ“X“ú"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>D_ŒÚ‹q‚©‚çŒÚ‹qî•ñíœ</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@V—X•Ö”Ô†•\¦—p</param>
        ''' <returns>s‹æ’¬‘º–¼</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_D_ŒÚ‹q(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "DELETE FROM D_ŒÚ‹q WHERE ŒÚ‹q”Ô† = @ŒÚ‹q”Ô†"
                rtn += DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQLÀs—š—ğ INSERT
                str_sql = "DELETE FROM basis_customer WHERE code =" & VbSQLStr(v_param.GetValue("@ŒÚ‹q”Ô†")) & " AND shop_code=" & VbSQLNStr(sShopcode)
                rtn += InsertZSqlExecHis(PAGE_TITLE, str_sql)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>—X•Ö”Ô†‚É‚Äs‹æ’¬‘ºŒŸõ</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@V—X•Ö”Ô†•\¦—p</param>
        ''' <returns>s‹æ’¬‘º–¼</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_placename(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.SearchAddress(v_param)
        End Function

        ''' <summary>ZŠ‚©‚ç—X•Ö”Ô†ŒŸõ</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@“s“¹•{Œ§/@s‹æ’¬‘º–¼/@’¬ˆæ–¼</param>
        ''' <returns>ŒÚ‹q”Ô†</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_postnumber(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT V—X•Ö”Ô†•\¦—p")
                builSQL.Append(" FROM B_—X•Ö”Ô†")
                builSQL.Append(" WHERE “s“¹•{Œ§–¼ =@“s“¹•{Œ§–¼")
                builSQL.Append(" AND s‹æ’¬‘º–¼ = @s‹æ’¬‘º–¼ AND ’¬ˆæ–¼ = @’¬ˆæ–¼")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex

            End Try
            Return dt
        End Function

        ''' <summary>ŒÚ‹q”Ô†‚ÅE_ƒJƒ‹ƒeƒe[ƒuƒ‹‚ğŒŸõ</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@ŒÚ‹q”Ô†</param>
        ''' <returns>ŒÚ‹q”Ô†</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_record(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT ŒÚ‹q”Ô† FROM E_ƒJƒ‹ƒe WHERE ŒÚ‹q”Ô† = @ŒÚ‹q”Ô†"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>ŒÚ‹q”Ô†‚ÅE_ƒ|ƒCƒ“ƒgƒe[ƒuƒ‹‚ğŒŸõ</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@ŒÚ‹q”Ô†</param>
        ''' <returns>ŒÚ‹q”Ô†</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_point(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT ŒÚ‹q”Ô† FROM E_ƒ|ƒCƒ“ƒg WHERE ŒÚ‹q”Ô† = @ŒÚ‹q”Ô†"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>ŒÚ‹q”Ô†‚ÅE_”„ãƒe[ƒuƒ‹‚ğŒŸõ</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@ŒÚ‹q”Ô†</param>
        ''' <returns>ŒÚ‹q”Ô†</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_sales(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT ŒÚ‹q”Ô† FROM E_”„ã WHERE ŒÚ‹q”Ô† = @ŒÚ‹q”Ô†"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>ŒÚ‹q”Ô†‚ÅE_”„ã–¾×ƒe[ƒuƒ‹‚ğŒŸõ</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@ŒÚ‹q”Ô†</param>
        ''' <returns>ŒÚ‹q”Ô†</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_sales_details(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT ŒÚ‹q”Ô† FROM E_”„ã–¾× WHERE ŒÚ‹q”Ô† = @ŒÚ‹q”Ô†"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>ŒÚ‹q”Ô†‚ÅE_—ˆ“XÒƒe[ƒuƒ‹‚ğŒŸõ</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@ŒÚ‹q”Ô†</param>
        ''' <returns>ŒÚ‹q”Ô†</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_customer(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT ŒÚ‹q”Ô† FROM E_—ˆ“XÒ WHERE ŒÚ‹q”Ô† = @ŒÚ‹q”Ô†"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>ŒÚ‹q”Ô†‚ÅD_ŒÚ‹qƒe[ƒuƒ‹‚ğŒŸõ</summary>
        ''' <returns>ŒÚ‹qî•ñ</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_D_ŒÚ‹q(ByVal customer_No As String) As DataTable
            Return MyBase.GetCustomerData(customer_No)
        End Function

        ''' <summary>«•Ê–¼Ìˆê——æ“¾</summary>
        ''' <returns>«•ÊƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Function SexType() As DataTable
            Return MyBase.B_«•Ê()
        End Function

        ''' <summary>“o˜^‹æ•ª–¼Ìæ“¾</summary>
        ''' <returns>“o˜^‹æ•ª–¼ƒŠƒXƒg</returns>
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


        ''' <summary>’S“–Ò–¼æ“¾</summary>
        ''' <returns>’S“–Ò–¼ƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Function ChargeTanyouPerson() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function

        ''' <summary>ŒÚ‹qî•ñæ“¾</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@ŒÚ‹q”Ô†</param>
        ''' <returns>ŒÚ‹qî•ñ</returns>
        ''' <remarks></remarks>
        Protected Friend Function CustomerInfo(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.GetCustomerInfo(v_param)
        End Function

        ''' <summary>Z_SQLÀs—š—ğ‚ÌSQL1¶¬(basis_customer‚ÌUpdate)</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function getSqlUpdBasis_customer(ByVal v_param As Habits.DB.DBParameter) As String
            Dim builSQL As New StringBuilder()
            Dim objSexNmb As Object
            Dim objStfNmb As Object
            Dim objDivNmb As Object

            Try
                objSexNmb = getSexNmb(v_param)
                objStfNmb = getStaffNmb(v_param)
                objDivNmb = getDivNmb(v_param)

                '------------------------------
                'Z_SQLÀs—š—ğ INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1İ’è
                builSQL.Append("UPDATE basis_customer SET")
                builSQL.Append(" last_name =" & VbSQLNStr(v_param.GetValue("@©")) & ",")
                builSQL.Append(" first_name =" & VbSQLNStr(v_param.GetValue("@–¼")) & ",")
                builSQL.Append(" last_name_kana =" & VbSQLNStr(v_param.GetValue("@©ƒJƒi")) & ",")
                builSQL.Append(" first_name_kana =" & VbSQLNStr(v_param.GetValue("@–¼ƒJƒi")) & ",")
                builSQL.Append(" gender_code = " & VbSQLStr(objSexNmb) & ", ")
                builSQL.Append(" birthday =" & VbSQLStr(v_param.GetValue("@¶”NŒ“ú")) & ",")
                builSQL.Append(" post_code =" & VbSQLNStr(v_param.GetValue("@—X•Ö”Ô†")) & ",")
                builSQL.Append(" prefectures =" & VbSQLNStr(v_param.GetValue("@“s“¹•{Œ§")) & ",")
                builSQL.Append(" address1 =" & VbSQLNStr(v_param.GetValue("@ZŠ1")) & ",")
                builSQL.Append(" address2 =" & VbSQLNStr(v_param.GetValue("@ZŠ2")) & ",")
                builSQL.Append(" address3 =" & VbSQLNStr(v_param.GetValue("@ZŠ3")) & ",")
                builSQL.Append(" phone =" & VbSQLNStr(v_param.GetValue("@“d˜b”Ô†")) & ",")
                builSQL.Append(" mail =" & VbSQLNStr(v_param.GetValue("@ƒAƒhƒŒƒX")) & ",")
                builSQL.Append(" family =" & VbSQLNStr(v_param.GetValue("@‰Æ‘°–¼")) & ",")
                builSQL.Append(" hobby =" & VbSQLNStr(v_param.GetValue("@ï–¡")) & ",")
                builSQL.Append(" favorite_topic =" & VbSQLNStr(v_param.GetValue("@D‚«‚È˜b‘è")) & ",")
                builSQL.Append(" offensive_topic =" & VbSQLNStr(v_param.GetValue("@Œ™‚¢‚È˜b‘è")) & ",")
                builSQL.Append(" memo =" & VbSQLNStr(v_param.GetValue("@ƒƒ‚")) & ",")
                builSQL.Append(" introducer =" & VbSQLNStr(v_param.GetValue("@Ğ‰îÒ")) & ",")
                builSQL.Append(" main_staff_code = " & VbSQLStr(objStfNmb) & ",")
                builSQL.Append(" register_code = " & VbSQLStr(objDivNmb) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@XV“ú")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@ŒÚ‹q”Ô†")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))

                Return builSQL.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>«•Ê”Ô†æ“¾</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@«•Ê</param>
        ''' <returns>«•Ê”Ô†</returns>
        ''' <remarks></remarks>
        Private Function getSexNmb(ByVal v_param As Habits.DB.DBParameter) As Object
            Dim str_sql As String
            Try
                str_sql = "SELECT «•Ê”Ô† FROM B_«•Ê WHERE «•Ê = @«•Ê"
                Return DBA.ExecuteScalar(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>’S“–Ò”Ô†æ“¾ </summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@’S“–Ò–¼</param>
        ''' <returns>’S“–Ò”Ô†</returns>
        ''' <remarks></remarks>
        Private Function getStaffNmb(ByVal v_param As Habits.DB.DBParameter) As Object
            Dim str_sql As String
            Try
                str_sql = "SELECT ’S“–Ò”Ô† FROM D_’S“–Ò WHERE ’S“–Ò–¼ = @’S“–Ò–¼"
                Return DBA.ExecuteScalar(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>“o˜^‹æ•ª”Ô†æ“¾</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@“o˜^‹æ•ª</param>
        ''' <returns>“o˜^‹æ•ª”Ô†</returns>
        ''' <remarks></remarks>
        Private Function getDivNmb(ByVal v_param As Habits.DB.DBParameter) As Object
            Dim str_sql As String
            Try
                str_sql = "SELECT “o˜^‹æ•ª”Ô† FROM B_“o˜^‹æ•ª WHERE “o˜^‹æ•ª = @“o˜^‹æ•ª"
                Return DBA.ExecuteScalar(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace
