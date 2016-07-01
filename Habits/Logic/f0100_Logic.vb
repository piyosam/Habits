#Region "ƒCƒ“ƒ|[ƒg"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>ŒÚ‹q“o˜^‰æ–ÊƒƒWƒbƒN</summary>
    ''' <remarks></remarks>
    Public Class f0100_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f0100_ŒÚ‹q“o˜^"

        ''' <summary>s‹æ’¬‘ºæ“¾</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@V—X•Ö”Ô†•\¦—p</param>
        ''' <returns>s‹æ’¬‘ºî•ñ</returns>
        ''' <remarks>—X•Ö”Ô†‚æ‚ès‹æ’¬‘º‚ğæ“¾‚·‚é</remarks>
        Protected Friend Function select_placename(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT “s“¹•{Œ§–¼, s‹æ’¬‘º–¼, ’¬ˆæ–¼")
                builSQL.Append(" FROM B_—X•Ö”Ô†")
                builSQL.Append(" WHERE V—X•Ö”Ô†•\¦—p LIKE @V—X•Ö”Ô†•\¦—p")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>«•Êˆê——æ“¾</summary>
        ''' <returns>«•ÊƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_sex() As DataTable
            Return MyBase.B_«•Ê()
        End Function

        ''' <summary>“o˜^‹æ•ªˆê——æ“¾</summary>
        ''' <returns>“o˜^‹æ•ªƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_“o˜^‹æ•ª() As DataTable
            Return MyBase.B_“o˜^‹æ•ª()
        End Function

        ''' <summary>’S“–Òˆê——æ“¾</summary>
        ''' <returns>’S“–ÒƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_å’S“–Ò() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function

        ''' <summary>D_ŒÚ‹q“o˜^</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^</param>
        ''' <returns>ˆ—ƒtƒ‰ƒO</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_customer_infomation(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0

            Try
                builSQL.Append("INSERT INTO D_ŒÚ‹q(")
                builSQL.Append(" ŒÚ‹q”Ô†")
                builSQL.Append(" ,©")
                builSQL.Append(" ,–¼")
                builSQL.Append(" ,©ƒJƒi")
                builSQL.Append(" ,–¼ƒJƒi")
                builSQL.Append(" ,«•Ê”Ô†")
                builSQL.Append(" ,¶”NŒ“ú")
                builSQL.Append(" ,—X•Ö”Ô†")
                builSQL.Append(" ,“s“¹•{Œ§")
                builSQL.Append(" ,ZŠ1")
                builSQL.Append(" ,ZŠ2")
                builSQL.Append(" ,ZŠ3")
                builSQL.Append(" ,“d˜b”Ô†")
                builSQL.Append(" ,EmailƒAƒhƒŒƒX")
                builSQL.Append(" ,‰Æ‘°–¼")
                builSQL.Append(" ,ï–¡")
                builSQL.Append(" ,D‚«‚È˜b‘è")
                builSQL.Append(" ,Œ™‚¢‚È˜b‘è")
                builSQL.Append(" ,“`Œ¾ƒtƒ‰ƒO")
                builSQL.Append(" ,ƒƒ‚")
                builSQL.Append(" ,Ğ‰îÒ")
                builSQL.Append(" ,‘O‰ñ—ˆ“X“ú")
                builSQL.Append(" ,—ˆ“X“úN_1")
                builSQL.Append(" ,—ˆ“X“úN_2")
                builSQL.Append(" ,—ˆ“X‰ñ”")
                builSQL.Append(" ,å’S“–Ò”Ô†")
                builSQL.Append(" ,“o˜^‹æ•ª”Ô†")
                builSQL.Append(" ,“o˜^“ú")
                builSQL.Append(" ,XV“ú)")

                builSQL.Append(" VALUES (@ŒÚ‹q”Ô†, @©, @–¼, @©ƒJƒi, @–¼ƒJƒi,@«•Ê”Ô†, @¶”NŒ“ú,")
                builSQL.Append("  @—X•Ö”Ô†,@“s“¹•{Œ§, @ZŠ1,@ZŠ2,@ZŠ3,@“d˜b”Ô†,@ƒAƒhƒŒƒX,@‰Æ‘°–¼,")
                builSQL.Append(" @ï–¡, @D‚«‚È˜b‘è, @Œ™‚¢‚È˜b‘è, @“`Œ¾ƒtƒ‰ƒO, @ƒƒ‚,")
                builSQL.Append(" @Ğ‰îÒ, @‘O‰ñ—ˆ“X“ú, @—ˆ“X“ú1,@—ˆ“X“ú2, @—ˆ“X‰ñ”,")
                builSQL.Append(" @å’S“–Ò”Ô†, @“o˜^‹æ•ª”Ô†,@“o˜^“ú, @XV“ú)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQLÀs—š—ğ INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1İ’è
                builSQL.Append("INSERT INTO basis_customer(")
                builSQL.Append(" shop_code")
                builSQL.Append(" ,code")
                builSQL.Append(" ,last_name")
                builSQL.Append(" ,first_name")
                builSQL.Append(" ,last_name_kana")
                builSQL.Append(" ,first_name_kana")
                builSQL.Append(" ,gender_code")
                builSQL.Append(" ,birthday")
                builSQL.Append(" ,post_code")
                builSQL.Append(" ,prefectures")
                builSQL.Append(" ,address1")
                builSQL.Append(" ,address2")
                builSQL.Append(" ,address3")
                builSQL.Append(" ,phone")
                builSQL.Append(" ,mail")
                builSQL.Append(" ,family")
                builSQL.Append(" ,hobby")
                builSQL.Append(" ,favorite_topic")
                builSQL.Append(" ,offensive_topic")
                builSQL.Append(" ,message_flag")
                builSQL.Append(" ,memo")
                builSQL.Append(" ,introducer")
                builSQL.Append(" ,last_visit_date")
                builSQL.Append(" ,one_before_last_visit_date")
                builSQL.Append(" ,two_before_last_visit_date")
                builSQL.Append(" ,visit_times")
                builSQL.Append(" ,main_staff_code")
                builSQL.Append(" ,register_code")
                builSQL.Append(" ,insert_date")
                builSQL.Append(" ,update_date)")
                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & "," & VbSQLStr(v_param.GetValue("@ŒÚ‹q”Ô†")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@©")) & "," & VbSQLNStr(v_param.GetValue("@–¼")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@©ƒJƒi")) & "," & VbSQLNStr(v_param.GetValue("@–¼ƒJƒi")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@«•Ê”Ô†")) & "," & VbSQLStr(v_param.GetValue("@¶”NŒ“ú")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@—X•Ö”Ô†")) & "," & VbSQLNStr(v_param.GetValue("@“s“¹•{Œ§")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@ZŠ1")) & "," & VbSQLNStr(v_param.GetValue("@ZŠ2")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@ZŠ3")) & "," & VbSQLNStr(v_param.GetValue("@“d˜b”Ô†")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@ƒAƒhƒŒƒX")) & "," & VbSQLNStr(v_param.GetValue("@‰Æ‘°–¼")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@ï–¡")) & "," & VbSQLNStr(v_param.GetValue("@D‚«‚È˜b‘è")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@Œ™‚¢‚È˜b‘è")) & "," & VbSQLStr(v_param.GetValue("@“`Œ¾ƒtƒ‰ƒO")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@ƒƒ‚")) & "," & VbSQLNStr(v_param.GetValue("@Ğ‰îÒ")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@‘O‰ñ—ˆ“X“ú")) & "," & VbSQLStr(v_param.GetValue("@—ˆ“X“ú1")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@—ˆ“X“ú2")) & "," & VbSQLStr(v_param.GetValue("@—ˆ“X‰ñ”")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@å’S“–Ò”Ô†")) & "," & VbSQLStr(v_param.GetValue("@“o˜^‹æ•ª”Ô†")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@“o˜^“ú")) & "," & VbSQLStr(v_param.GetValue("@XV“ú")))
                builSQL.Append(")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>ŒÚ‹q”Ô†ˆê——æ“¾</summary>
        ''' <param name="v_param">SQLƒpƒ‰ƒ[ƒ^F@ŠJnŒÚ‹q”Ô†/@I—¹ŒÚ‹q”Ô†</param>
        ''' <returns>ŒÚ‹q”Ô†ƒŠƒXƒg</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_customer_num(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.GetCustomerNum(v_param)
        End Function
    End Class
End Namespace