#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>顧客変更画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class z0500_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "z_0500_顧客変更"

        ''' <summary>顧客情報の更新</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_D_顧客(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("UPDATE D_顧客 SET")
                builSQL.Append(" 姓 = @姓,")
                builSQL.Append(" 名 = @名,")
                builSQL.Append(" 姓カナ = @姓カナ,")
                builSQL.Append(" 名カナ = @名カナ,")
                builSQL.Append(" 性別番号 = ( SELECT 性別番号 FROM B_性別 WHERE 性別 = @性別), ")
                builSQL.Append(" 生年月日 = @生年月日,")
                builSQL.Append(" 郵便番号 =@郵便番号,")
                builSQL.Append(" 都道府県 = @都道府県,")
                builSQL.Append(" 住所1 = @住所1,")
                builSQL.Append(" 住所2 = @住所2,")
                builSQL.Append(" 住所3 = @住所3,")
                builSQL.Append(" 電話番号 = @電話番号,")
                builSQL.Append(" Emailアドレス = @アドレス,")
                builSQL.Append(" 家族名 = @家族名,")
                builSQL.Append(" 趣味 = @趣味,")
                builSQL.Append(" 好きな話題 = @好きな話題,")
                builSQL.Append(" 嫌いな話題 = @嫌いな話題,")
                builSQL.Append(" メモ = @メモ,")
                builSQL.Append(" 紹介者 = @紹介者,")
                builSQL.Append(" 主担当者番号 = ( SELECT 担当者番号 FROM D_担当者 WHERE 担当者名 = @担当者名),")
                builSQL.Append(" 登録区分番号 = ( SELECT 登録区分番号 FROM B_登録区分 WHERE 登録区分 = @登録区分),")
                builSQL.Append(" 更新日 = @更新日")
                builSQL.Append(" WHERE 顧客番号 = @顧客番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL実行履歴 INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlUpdBasis_customer(v_param))

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>E_来店者の更新</summary>
        ''' <param name="v_param">SQLパラメータ：@姓/@姓カナ/@名/@住所/@更新日/@顧客番号/@来店日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_E_来店者(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Dim dt As DataTable
            Try
                '来店者レコード存在チェック
                builSQL.Append("SELECT * FROM E_来店者")
                builSQL.Append(" WHERE 顧客番号 = @顧客番号")
                builSQL.Append(" AND 来店日 = @来店日")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

                If (dt.Rows.Count > 0) Then
                    builSQL.Length = 0
                    builSQL.Append("UPDATE E_来店者 SET")
                    builSQL.Append(" 姓 = @姓,")
                    builSQL.Append(" 姓カナ = @姓カナ,")
                    builSQL.Append(" 名 = @名,")
                    builSQL.Append(" 住所 = @住所,")
                    builSQL.Append(" 更新日=@更新日,")
                    builSQL.Append(" 主担当者番号=@主担当者番号")
                    builSQL.Append(" WHERE 顧客番号 = @顧客番号")
                    builSQL.Append(" AND 来店日 = @来店日")

                    str_sql = builSQL.ToString
                    rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                    '------------------------------
                    'Z_SQL実行履歴 INSERT
                    '------------------------------
                    builSQL.Length = 0
                    ' SQL1設定
                    builSQL.Append("UPDATE visit SET")
                    builSQL.Append(" last_name =" & VbSQLNStr(v_param.GetValue("@姓")) & ",")
                    builSQL.Append(" last_name_kana =" & VbSQLNStr(v_param.GetValue("@姓カナ")) & ",")
                    builSQL.Append(" first_name =" & VbSQLNStr(v_param.GetValue("@名")) & ",")
                    builSQL.Append(" address =" & VbSQLNStr(v_param.GetValue("@住所")) & ",")
                    builSQL.Append(" update_date=" & VbSQLStr(v_param.GetValue("@更新日")) & ",")
                    builSQL.Append(" main_staff_code=" & VbSQLStr(v_param.GetValue("@主担当者番号")))
                    builSQL.Append(" WHERE basis_customer_code =" & VbSQLStr(v_param.GetValue("@顧客番号")))
                    builSQL.Append(" AND date =" & VbSQLStr(v_param.GetValue("@来店日")))
                    builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                    InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)
                End If
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>来店者番号の取得</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号/@来店日</param>
        ''' <returns>来店者番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_E_来店者(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT 来店者番号 FROM E_来店者 WHERE 顧客番号 = @顧客番号 AND 来店日 = @来店日"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>D_顧客から顧客情報削除</summary>
        ''' <param name="v_param">SQLパラメータ：@新郵便番号表示用</param>
        ''' <returns>市区町村名</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_D_顧客(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "DELETE FROM D_顧客 WHERE 顧客番号 = @顧客番号"
                rtn += DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL実行履歴 INSERT
                str_sql = "DELETE FROM basis_customer WHERE code =" & VbSQLStr(v_param.GetValue("@顧客番号")) & " AND shop_code=" & VbSQLNStr(sShopcode)
                rtn += InsertZSqlExecHis(PAGE_TITLE, str_sql)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>郵便番号にて市区町村検索</summary>
        ''' <param name="v_param">SQLパラメータ：@新郵便番号表示用</param>
        ''' <returns>市区町村名</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_placename(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.SearchAddress(v_param)
        End Function

        ''' <summary>住所から郵便番号検索</summary>
        ''' <param name="v_param">SQLパラメータ：@都道府県/@市区町村名/@町域名</param>
        ''' <returns>顧客番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_postnumber(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT 新郵便番号表示用")
                builSQL.Append(" FROM B_郵便番号")
                builSQL.Append(" WHERE 都道府県名 =@都道府県名")
                builSQL.Append(" AND 市区町村名 = @市区町村名 AND 町域名 = @町域名")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex

            End Try
            Return dt
        End Function

        ''' <summary>顧客番号でE_カルテテーブルを検索</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>顧客番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_record(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT 顧客番号 FROM E_カルテ WHERE 顧客番号 = @顧客番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>顧客番号でE_ポイントテーブルを検索</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>顧客番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_point(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT 顧客番号 FROM E_ポイント WHERE 顧客番号 = @顧客番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>顧客番号でE_売上テーブルを検索</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>顧客番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_sales(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT 顧客番号 FROM E_売上 WHERE 顧客番号 = @顧客番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>顧客番号でE_売上明細テーブルを検索</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>顧客番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_sales_details(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT 顧客番号 FROM E_売上明細 WHERE 顧客番号 = @顧客番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>顧客番号でE_来店者テーブルを検索</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>顧客番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_customer(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT 顧客番号 FROM E_来店者 WHERE 顧客番号 = @顧客番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>顧客番号でD_顧客テーブルを検索</summary>
        ''' <returns>顧客情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_D_顧客(ByVal customer_No As String) As DataTable
            Return MyBase.GetCustomerData(customer_No)
        End Function

        ''' <summary>性別名称一覧取得</summary>
        ''' <returns>性別リスト</returns>
        ''' <remarks></remarks>
        Function SexType() As DataTable
            Return MyBase.B_性別()
        End Function

        ''' <summary>登録区分名称取得</summary>
        ''' <returns>登録区分名リスト</returns>
        ''' <remarks></remarks>
        Function SelectedDivision() As DataTable
            Return MyBase.B_登録区分()
        End Function

        ''' <summary>担当者名一覧取得</summary>
        ''' <returns>担当者リスト</returns>
        ''' <remarks></remarks>
        Function ChargePerson() As DataTable
            Return MyBase.GetStaffNameList()
        End Function


        ''' <summary>担当者名取得</summary>
        ''' <returns>担当者名リスト</returns>
        ''' <remarks></remarks>
        Function ChargeTanyouPerson() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function

        ''' <summary>顧客情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>顧客情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function CustomerInfo(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.GetCustomerInfo(v_param)
        End Function

        ''' <summary>Z_SQL実行履歴のSQL1生成(basis_customerのUpdate)</summary>
        ''' <param name="v_param">SQLパラメータ</param>
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
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE basis_customer SET")
                builSQL.Append(" last_name =" & VbSQLNStr(v_param.GetValue("@姓")) & ",")
                builSQL.Append(" first_name =" & VbSQLNStr(v_param.GetValue("@名")) & ",")
                builSQL.Append(" last_name_kana =" & VbSQLNStr(v_param.GetValue("@姓カナ")) & ",")
                builSQL.Append(" first_name_kana =" & VbSQLNStr(v_param.GetValue("@名カナ")) & ",")
                builSQL.Append(" gender_code = " & VbSQLStr(objSexNmb) & ", ")
                builSQL.Append(" birthday =" & VbSQLStr(v_param.GetValue("@生年月日")) & ",")
                builSQL.Append(" post_code =" & VbSQLNStr(v_param.GetValue("@郵便番号")) & ",")
                builSQL.Append(" prefectures =" & VbSQLNStr(v_param.GetValue("@都道府県")) & ",")
                builSQL.Append(" address1 =" & VbSQLNStr(v_param.GetValue("@住所1")) & ",")
                builSQL.Append(" address2 =" & VbSQLNStr(v_param.GetValue("@住所2")) & ",")
                builSQL.Append(" address3 =" & VbSQLNStr(v_param.GetValue("@住所3")) & ",")
                builSQL.Append(" phone =" & VbSQLNStr(v_param.GetValue("@電話番号")) & ",")
                builSQL.Append(" mail =" & VbSQLNStr(v_param.GetValue("@アドレス")) & ",")
                builSQL.Append(" family =" & VbSQLNStr(v_param.GetValue("@家族名")) & ",")
                builSQL.Append(" hobby =" & VbSQLNStr(v_param.GetValue("@趣味")) & ",")
                builSQL.Append(" favorite_topic =" & VbSQLNStr(v_param.GetValue("@好きな話題")) & ",")
                builSQL.Append(" offensive_topic =" & VbSQLNStr(v_param.GetValue("@嫌いな話題")) & ",")
                builSQL.Append(" memo =" & VbSQLNStr(v_param.GetValue("@メモ")) & ",")
                builSQL.Append(" introducer =" & VbSQLNStr(v_param.GetValue("@紹介者")) & ",")
                builSQL.Append(" main_staff_code = " & VbSQLStr(objStfNmb) & ",")
                builSQL.Append(" register_code = " & VbSQLStr(objDivNmb) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))

                Return builSQL.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>性別番号取得</summary>
        ''' <param name="v_param">SQLパラメータ：@性別</param>
        ''' <returns>性別番号</returns>
        ''' <remarks></remarks>
        Private Function getSexNmb(ByVal v_param As Habits.DB.DBParameter) As Object
            Dim str_sql As String
            Try
                str_sql = "SELECT 性別番号 FROM B_性別 WHERE 性別 = @性別"
                Return DBA.ExecuteScalar(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>担当者番号取得 </summary>
        ''' <param name="v_param">SQLパラメータ：@担当者名</param>
        ''' <returns>担当者番号</returns>
        ''' <remarks></remarks>
        Private Function getStaffNmb(ByVal v_param As Habits.DB.DBParameter) As Object
            Dim str_sql As String
            Try
                str_sql = "SELECT 担当者番号 FROM D_担当者 WHERE 担当者名 = @担当者名"
                Return DBA.ExecuteScalar(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>登録区分番号取得</summary>
        ''' <param name="v_param">SQLパラメータ：@登録区分</param>
        ''' <returns>登録区分番号</returns>
        ''' <remarks></remarks>
        Private Function getDivNmb(ByVal v_param As Habits.DB.DBParameter) As Object
            Dim str_sql As String
            Try
                str_sql = "SELECT 登録区分番号 FROM B_登録区分 WHERE 登録区分 = @登録区分"
                Return DBA.ExecuteScalar(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace
