#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>顧客登録画面ロジック</summary>
    ''' <remarks></remarks>
    Public Class f0100_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f0100_顧客登録"

        ''' <summary>市区町村取得</summary>
        ''' <param name="v_param">SQLパラメータ：@新郵便番号表示用</param>
        ''' <returns>市区町村情報</returns>
        ''' <remarks>郵便番号より市区町村を取得する</remarks>
        Protected Friend Function select_placename(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT 都道府県名, 市区町村名, 町域名")
                builSQL.Append(" FROM B_郵便番号")
                builSQL.Append(" WHERE 新郵便番号表示用 LIKE @新郵便番号表示用")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>性別一覧取得</summary>
        ''' <returns>性別リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_sex() As DataTable
            Return MyBase.B_性別()
        End Function

        ''' <summary>登録区分一覧取得</summary>
        ''' <returns>登録区分リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_登録区分() As DataTable
            Return MyBase.B_登録区分()
        End Function

        ''' <summary>担当者一覧取得</summary>
        ''' <returns>担当者リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_主担当者() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function

        ''' <summary>D_顧客登録</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_customer_infomation(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0

            Try
                builSQL.Append("INSERT INTO D_顧客(")
                builSQL.Append(" 顧客番号")
                builSQL.Append(" ,姓")
                builSQL.Append(" ,名")
                builSQL.Append(" ,姓カナ")
                builSQL.Append(" ,名カナ")
                builSQL.Append(" ,性別番号")
                builSQL.Append(" ,生年月日")
                builSQL.Append(" ,郵便番号")
                builSQL.Append(" ,都道府県")
                builSQL.Append(" ,住所1")
                builSQL.Append(" ,住所2")
                builSQL.Append(" ,住所3")
                builSQL.Append(" ,電話番号")
                builSQL.Append(" ,Emailアドレス")
                builSQL.Append(" ,家族名")
                builSQL.Append(" ,趣味")
                builSQL.Append(" ,好きな話題")
                builSQL.Append(" ,嫌いな話題")
                builSQL.Append(" ,伝言フラグ")
                builSQL.Append(" ,メモ")
                builSQL.Append(" ,紹介者")
                builSQL.Append(" ,前回来店日")
                builSQL.Append(" ,来店日N_1")
                builSQL.Append(" ,来店日N_2")
                builSQL.Append(" ,来店回数")
                builSQL.Append(" ,主担当者番号")
                builSQL.Append(" ,登録区分番号")
                builSQL.Append(" ,登録日")
                builSQL.Append(" ,更新日)")

                builSQL.Append(" VALUES (@顧客番号, @姓, @名, @姓カナ, @名カナ,@性別番号, @生年月日,")
                builSQL.Append("  @郵便番号,@都道府県, @住所1,@住所2,@住所3,@電話番号,@アドレス,@家族名,")
                builSQL.Append(" @趣味, @好きな話題, @嫌いな話題, @伝言フラグ, @メモ,")
                builSQL.Append(" @紹介者, @前回来店日, @来店日1,@来店日2, @来店回数,")
                builSQL.Append(" @主担当者番号, @登録区分番号,@登録日, @更新日)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
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
                builSQL.Append(VbSQLNStr(sShopcode) & "," & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@姓")) & "," & VbSQLNStr(v_param.GetValue("@名")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@姓カナ")) & "," & VbSQLNStr(v_param.GetValue("@名カナ")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@性別番号")) & "," & VbSQLStr(v_param.GetValue("@生年月日")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@郵便番号")) & "," & VbSQLNStr(v_param.GetValue("@都道府県")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@住所1")) & "," & VbSQLNStr(v_param.GetValue("@住所2")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@住所3")) & "," & VbSQLNStr(v_param.GetValue("@電話番号")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@アドレス")) & "," & VbSQLNStr(v_param.GetValue("@家族名")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@趣味")) & "," & VbSQLNStr(v_param.GetValue("@好きな話題")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@嫌いな話題")) & "," & VbSQLStr(v_param.GetValue("@伝言フラグ")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@メモ")) & "," & VbSQLNStr(v_param.GetValue("@紹介者")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@前回来店日")) & "," & VbSQLStr(v_param.GetValue("@来店日1")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@来店日2")) & "," & VbSQLStr(v_param.GetValue("@来店回数")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@主担当者番号")) & "," & VbSQLStr(v_param.GetValue("@登録区分番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@登録日")) & "," & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>顧客番号一覧取得</summary>
        ''' <param name="v_param">SQLパラメータ：@開始顧客番号/@終了顧客番号</param>
        ''' <returns>顧客番号リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_customer_num(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.GetCustomerNum(v_param)
        End Function
    End Class
End Namespace