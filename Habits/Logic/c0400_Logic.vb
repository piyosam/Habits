#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic

    ''' <summary>会計画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class c0400_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "c0400_会計"

#Region "売上区分別リスト取得 "
        ''' <summary>売上区分別リスト取得</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function 売上区分別売上リスト取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT MAX(E_売上明細.来店日) AS 来店日")
                builSQL.Append(" ,MAX(E_売上明細.来店者番号) AS 来店者番号")
                builSQL.Append(" ,MAX(E_売上明細.顧客番号) AS 顧客番号")
                builSQL.Append(" ,E_売上明細.売上区分番号")
                builSQL.Append(" ,MAX(B_売上区分.売上区分) AS 売上区分")
                builSQL.Append(" ,SUM(E_売上明細.数量) AS 合計数量")
                builSQL.Append(" ,SUM(E_売上明細.金額 * E_売上明細.数量) AS 合計金額")
                builSQL.Append(" ,SUM(E_売上明細.サービス *-1) AS サービス")
                builSQL.Append(" ,SUM(E_売上明細.消費税) AS 消費税")
                builSQL.Append(" FROM E_売上明細 LEFT OUTER JOIN")
                builSQL.Append(" B_売上区分 ON E_売上明細.売上区分番号 = B_売上区分.売上区分番号")
                builSQL.Append(" WHERE (E_売上明細.来店日 = @来店日)")
                builSQL.Append(" AND (E_売上明細.顧客番号 = @顧客番号)")
                builSQL.Append(" AND (E_売上明細.来店者番号 = @来店者番号)")
                builSQL.Append(" GROUP BY E_売上明細.売上区分番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "E_売上取得"
        ''' <summary>E_売上取得</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>売上情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_売上取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT * FROM E_売上")
                builSQL.Append(" WHERE 来店日 = @来店日")
                builSQL.Append(" AND 来店者番号 = @来店者番号")
                builSQL.Append(" AND 顧客番号 = @顧客番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "D_顧客取得"
        ''' <summary>D_顧客取得</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>顧客情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function D_顧客取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT (姓 + ' ' + ISNULL(名,'')) AS 氏名,(姓カナ + ' ' + ISNULL(名カナ,'')) AS 氏名カナ,")
                builSQL.Append(" 生年月日, 登録区分番号, 前回来店日,都道府県,住所1,来店日N_1,")
                builSQL.Append(" 来店日N_2,来店回数,主担当者番号,登録日,更新日")
                builSQL.Append(" FROM D_顧客")
                builSQL.Append(" WHERE 顧客番号 = @顧客番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                'ログ出力
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("顧客情報の取得に失敗しました。　" & Chr(13) & Chr(13) & _
                "処理を再度行ってください。　", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "E_来店者取得"
        ''' <summary>E_来店者取得</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>来店者情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_来店者取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                str_sql = "SELECT * FROM E_来店者 WHERE 来店日 = @来店日 AND 来店者番号 = @来店者番号 AND 顧客番号 = @顧客番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "E_売上追加"
        ''' <summary>E_売上追加</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_E_売上(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("INSERT INTO E_売上(")
                builSQL.Append(" 来店日")
                builSQL.Append(" ,来店者番号")
                builSQL.Append(" ,顧客番号")
                builSQL.Append(" ,性別番号")
                builSQL.Append(" ,年齢")
                builSQL.Append(" ,主担当者番号")
                builSQL.Append(" ,来店区分番号")
                builSQL.Append(" ,指名")
                builSQL.Append(" ,カード支払")
                builSQL.Append(" ,カード会社番号")
                builSQL.Append(" ,現金支払")
                builSQL.Append(" ,お預り")
                builSQL.Append(" ,消費税")
                builSQL.Append(" ,更新日")
                builSQL.Append(" ,その他支払")
                builSQL.Append(" ,ポイント割引番号")
                builSQL.Append(" ,ポイント割引支払")
                builSQL.Append(" ,サービス番号")
                builSQL.Append(" ,サービス金額")

                builSQL.Append(" )VALUES(")
                builSQL.Append(" @来店日")
                builSQL.Append(" ,@来店者番号")
                builSQL.Append(" ,@顧客番号")
                builSQL.Append(" ,@性別番号")
                builSQL.Append(" ,@年齢")
                builSQL.Append(" ,@主担当者番号")
                builSQL.Append(" ,@来店区分番号")
                builSQL.Append(" ,@指名")
                builSQL.Append(" ,@カード支払")
                builSQL.Append(" ,@カード会社番号")
                builSQL.Append(" ,@現金支払")
                builSQL.Append(" ,@お預り")
                builSQL.Append(" ,@消費税")
                builSQL.Append(" ,@更新日")
                builSQL.Append(" ,@その他支払")
                builSQL.Append(" ,@ポイント割引番号")
                builSQL.Append(" ,@ポイント割引支払")
                builSQL.Append(" ,@サービス番号")
                builSQL.Append(" ,@サービス金額")
                builSQL.Append(" )")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("INSERT INTO sales(")
                builSQL.Append(" shop_code")
                builSQL.Append(" ,visit_date")
                builSQL.Append(" ,visit_number")
                builSQL.Append(" ,basis_customer_code")
                builSQL.Append(" ,gender_code")
                builSQL.Append(" ,age")
                builSQL.Append(" ,main_staff_code")
                builSQL.Append(" ,visit_division_code")
                builSQL.Append(" ,designated_flag")
                builSQL.Append(" ,credit_purchases")
                builSQL.Append(" ,card_corporation_code")
                builSQL.Append(" ,cash_purchases")
                builSQL.Append(" ,deposit")
                builSQL.Append(" ,tax")
                builSQL.Append(" ,update_date")
                builSQL.Append(" ,other_purchases")
                builSQL.Append(" ,point_purchases_code")
                builSQL.Append(" ,point_purchases")
                builSQL.Append(" ,service_code")
                builSQL.Append(" ,service_amount")

                builSQL.Append(" )VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@性別番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@年齢")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@主担当者番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@来店区分番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@指名")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@カード支払")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@カード会社番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@現金支払")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@お預り")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@消費税")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@その他支払")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@ポイント割引番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@ポイント割引支払")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@サービス番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@サービス金額")))
                builSQL.Append(")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                'ログ出力
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("売上データの登録に失敗しました。　" & Chr(13) & Chr(13) & _
                "処理を再度行ってください。　", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "E_売上更新"
        ''' <summary>E_売上更新</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_E_売上(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("UPDATE E_売上 SET")
                builSQL.Append(" 来店日 = @来店日")
                builSQL.Append(" ,来店者番号 = @来店者番号")
                builSQL.Append(" ,顧客番号 = @顧客番号")
                builSQL.Append(" ,性別番号 = @性別番号")
                builSQL.Append(" ,年齢 = @年齢")
                builSQL.Append(" ,主担当者番号 = @主担当者番号")
                builSQL.Append(" ,来店区分番号 = @来店区分番号")
                builSQL.Append(" ,指名 = @指名")
                builSQL.Append(" ,カード支払 = @カード支払")
                builSQL.Append(" ,カード会社番号 = @カード会社番号")
                builSQL.Append(" ,現金支払 = @現金支払")
                builSQL.Append(" ,お預り = @お預り")
                builSQL.Append(" ,消費税 = @消費税")
                builSQL.Append(" ,更新日 = @更新日")
                builSQL.Append(" ,その他支払 = @その他支払")
                builSQL.Append(" ,ポイント割引番号 = @ポイント割引番号")
                builSQL.Append(" ,ポイント割引支払 = @ポイント割引支払")
                builSQL.Append(" ,サービス番号 = @サービス番号")
                builSQL.Append(" ,サービス金額 = @サービス金額")

                builSQL.Append(" WHERE 来店日=@来店日")
                builSQL.Append(" AND 来店者番号=@来店者番号")
                builSQL.Append(" AND 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE sales SET")
                builSQL.Append(" visit_date =" & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append(" ,visit_number =" & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append(" ,basis_customer_code =" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" ,gender_code =" & VbSQLStr(v_param.GetValue("@性別番号")))
                builSQL.Append(" ,age =" & VbSQLStr(v_param.GetValue("@年齢")))
                builSQL.Append(" ,main_staff_code =" & VbSQLStr(v_param.GetValue("@主担当者番号")))
                builSQL.Append(" ,visit_division_code =" & VbSQLStr(v_param.GetValue("@来店区分番号")))
                builSQL.Append(" ,designated_flag =" & VbSQLStr(v_param.GetValue("@指名")))
                builSQL.Append(" ,credit_purchases =" & VbSQLStr(v_param.GetValue("@カード支払")))
                builSQL.Append(" ,card_corporation_code =" & VbSQLStr(v_param.GetValue("@カード会社番号")))
                builSQL.Append(" ,cash_purchases =" & VbSQLStr(v_param.GetValue("@現金支払")))
                builSQL.Append(" ,deposit =" & VbSQLStr(v_param.GetValue("@お預り")))
                builSQL.Append(" ,tax =" & VbSQLStr(v_param.GetValue("@消費税")))
                builSQL.Append(" ,update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" ,other_purchases =" & VbSQLStr(v_param.GetValue("@その他支払")))
                builSQL.Append(" ,point_purchases_code =" & VbSQLStr(v_param.GetValue("@ポイント割引番号")))
                builSQL.Append(" ,point_purchases =" & VbSQLStr(v_param.GetValue("@ポイント割引支払")))
                builSQL.Append(" ,service_code =" & VbSQLStr(v_param.GetValue("@サービス番号")))
                builSQL.Append(" ,service_amount =" & VbSQLStr(v_param.GetValue("@サービス金額")))

                builSQL.Append(" WHERE visit_date=" & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append(" AND visit_number=" & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "カード会社リスト取得"
        ''' <summary>カード会社リスト取得</summary>
        ''' <returns>カード会社リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function カード会社リスト取得() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT")
                builSQL.Append(" C_カード会社.カード会社番号")
                builSQL.Append(" ,C_カード会社.カード会社名")
                builSQL.Append(" FROM C_カード会社")
                builSQL.Append(" WHERE C_カード会社.削除フラグ = 'False'")
                builSQL.Append(" ORDER BY C_カード会社.表示順")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "D_顧客更新"
        '''<summary>D_顧客更新</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function D_顧客更新(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("UPDATE D_顧客 SET")
                builSQL.Append(" 性別番号=@性別番号,")
                builSQL.Append(" 主担当者番号=@主担当者番号,")
                builSQL.Append(" 登録区分番号=@登録区分番号,")
                builSQL.Append(" 前回来店日=@前回来店日,")
                builSQL.Append(" 来店日N_2=@来店日Ｎ２,")
                builSQL.Append(" 来店日N_1=@来店日Ｎ１,")
                builSQL.Append(" 更新日=@更新日,")
                builSQL.Append(" 伝言フラグ = 0")
                builSQL.Append(" WHERE 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE basis_customer SET")
                builSQL.Append(" gender_code=" & VbSQLStr(v_param.GetValue("@性別番号")) & ",")
                builSQL.Append(" main_staff_code=" & VbSQLStr(v_param.GetValue("@主担当者番号")) & ",")
                builSQL.Append(" register_code=" & VbSQLStr(v_param.GetValue("@登録区分番号")) & ",")
                builSQL.Append(" last_visit_date=" & VbSQLStr(v_param.GetValue("@前回来店日")) & ",")
                builSQL.Append(" two_before_last_visit_date=" & VbSQLStr(v_param.GetValue("@来店日Ｎ２")) & ",")
                builSQL.Append(" one_before_last_visit_date=" & VbSQLStr(v_param.GetValue("@来店日Ｎ１")) & ",")
                builSQL.Append(" update_date=" & VbSQLStr(v_param.GetValue("@更新日")) & ",")
                builSQL.Append(" message_flag = 0")
                builSQL.Append(" WHERE code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "E_来店者更新"
        '''<summary>E_来店者更新</summary>
        ''' <param name="v_param">SQLパラメータ：@主担当者番号/@作業終了/@更新日/@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_来店者更新(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("UPDATE E_来店者 SET")
                builSQL.Append(" 主担当者番号=@主担当者番号,")
                builSQL.Append(" 来店区分番号 = @来店区分番号,")
                builSQL.Append(" 指名 = @指名,")
                builSQL.Append(" 作業終了=@作業終了,")
                builSQL.Append(" 会計済=1,")
                builSQL.Append(" 更新日=@更新日")
                builSQL.Append(" WHERE 来店日=@来店日")
                builSQL.Append(" AND 来店者番号=@来店者番号")
                builSQL.Append(" AND 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0

                builSQL.Append("UPDATE visit SET")
                builSQL.Append(" main_staff_code=" & VbSQLStr(v_param.GetValue("@主担当者番号")) & ",")
                builSQL.Append(" visit_division_code=" & VbSQLStr(v_param.GetValue("@来店区分番号")) & ",")
                builSQL.Append(" designated_flag=" & VbSQLStr(v_param.GetValue("@指名")) & ",")
                builSQL.Append(" end_date=" & VbSQLStr(v_param.GetValue("@作業終了")) & ",")
                builSQL.Append(" paid_flag=''1'',")
                builSQL.Append(" update_date=" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE date=" & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append(" AND number=" & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "店販対象の売上明細の取得"
        ''' <summary>店販対象の売上明細の取得</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>売上明細</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_売上明細_店販(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT E_売上明細.来店日,")
                builSQL.Append(" E_売上明細.来店者番号,")
                builSQL.Append(" E_売上明細.顧客番号,")
                builSQL.Append(" E_売上明細.売上番号,")
                builSQL.Append(" E_売上明細.売上担当者番号,")
                builSQL.Append(" E_売上明細.売上区分番号,")
                builSQL.Append(" E_売上明細.分類番号,")
                builSQL.Append(" E_売上明細.名称番号,")
                builSQL.Append(" E_売上明細.数量,")
                builSQL.Append(" E_売上明細.金額,")
                builSQL.Append(" E_売上明細.サービス番号,")
                builSQL.Append(" E_売上明細.サービス,")
                builSQL.Append(" E_売上明細.会計済,")
                builSQL.Append(" C_分類.店販対象フラグ")
                builSQL.Append(" FROM E_売上明細 LEFT OUTER JOIN")
                builSQL.Append(" C_分類 ON E_売上明細.売上区分番号 = C_分類.売上区分番号")
                builSQL.Append(" AND E_売上明細.分類番号 = C_分類.分類番号")
                builSQL.Append(" WHERE (C_分類.店販対象フラグ = 1)")
                builSQL.Append(" AND 来店日=@来店日")
                builSQL.Append(" AND 来店者番号=@来店者番号")
                builSQL.Append(" AND 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                'ログ出力
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("店販対象の売上明細取得に失敗しました。　" & Chr(13) & Chr(13) & _
                "処理を再度行ってください。　", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "入出庫データの登録"
        ''' <summary>入出庫データの登録</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_入出庫追加(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("INSERT INTO E_入出庫(")
                builSQL.Append(" 入出庫日,")
                builSQL.Append(" 入出庫番号,")
                builSQL.Append(" 入出庫区分番号,")
                builSQL.Append(" 入出庫理由番号,")
                builSQL.Append(" 売上区分番号,")
                builSQL.Append(" 分類番号,")
                builSQL.Append(" 商品番号,")
                builSQL.Append(" 入出庫数,")
                builSQL.Append(" 担当者番号,")
                builSQL.Append(" 登録日)")
                builSQL.Append(" VALUES(")
                builSQL.Append(" @入出庫日,")
                builSQL.Append(" @入出庫番号,")
                builSQL.Append(" @入出庫区分番号,")
                builSQL.Append(" @入出庫理由番号,")
                builSQL.Append(" @売上区分番号,")
                builSQL.Append(" @分類番号,")
                builSQL.Append(" @商品番号,")
                builSQL.Append(" @入出庫数,")
                builSQL.Append(" @担当者番号,")
                builSQL.Append(" @登録日)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL実行履歴 INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlInsReceive_ship(v_param, False))

            Catch ex As Exception
                'ログ出力
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("入出庫データの登録に失敗しました。　" & Chr(13) & Chr(13) & _
                "処理を再度行ってください。　", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return rtn
        End Function
#End Region


#Region "在庫数の更新"
        ''' <summary>在庫数の更新</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号/@商品番号/@更新日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function C_商品在庫数更新(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("UPDATE C_商品 SET")
                builSQL.Append(" 在庫数= @在庫数")
                builSQL.Append(" ,更新日=@更新日")
                builSQL.Append(" WHERE 売上区分番号=@売上区分番号")
                builSQL.Append(" AND 分類番号=@分類番号")
                builSQL.Append(" AND 商品番号=@商品番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE goods SET")
                builSQL.Append(" stock =" & VbSQLStr(v_param.GetValue("@在庫数")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@売上区分番号")))
                builSQL.Append(" AND class_code =" & VbSQLStr(v_param.GetValue("@分類番号")))
                builSQL.Append(" AND code =" & VbSQLStr(v_param.GetValue("@商品番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

    End Class
End Namespace
