#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>来店画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a0300_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a0300_来店"

#Region "カルテデータ取得"
        ''' <summary>カルテデータの取得</summary>
        ''' <param name="v_number">顧客番号</param>
        ''' <returns>カルテデータリスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetClinicalRecord(ByVal v_number As String) As String
            Dim rtn As String = ""
            Dim builSQL As New StringBuilder()
            Dim dt As New DataTable
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                builSQL.Append("SELECT 来店日,来店者番号,顧客番号,カルテ,登録者番号,登録日時,変更日時")
                builSQL.Append(" FROM E_カルテ")
                builSQL.Append(" WHERE 顧客番号=@顧客番号")
                builSQL.Append(" ORDER BY 来店日 DESC,来店者番号 DESC")

                str_sql = builSQL.ToString
                param.Add("@顧客番号", v_number)
                dt = DBA.ExecuteDataTable(str_sql, param)

                If dt.Rows.Count > 0 Then
                    rtn = dt.Rows(0)("カルテ").ToString
                End If
            Catch ex As Exception
                Throw ex
            Finally
                dt.Dispose()
            End Try

            Return rtn
        End Function
#End Region

#Region "新規フリー顧客番号取得"
        ''' <summary>新規フリー顧客番号の取得</summary>
        ''' <returns>顧客番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function NewFreeNumber() As String
            Dim rtn As String = Clng_STFreeNo.ToString
            Dim obj As New Object
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                str_sql = "SELECT MAX(顧客番号) + 1 FROM E_来店者 WHERE 来店日=@来店日 AND 顧客番号 < @顧客番号 AND 顧客番号 >= @フリー番号"

                param.Add("@来店日", Format(USER_DATE, "yyyy/MM/dd HH:mm:ss"))
                param.Add("@顧客番号", CInt(Clng_STFreeNo) + 32767)
                param.Add("@フリー番号", CInt(Clng_STFreeNo))
                obj = DBA.ExecuteScalar(str_sql, param)

                If Not IsDBNull(obj) Then
                    If CInt(obj) < Clng_MAXCstNo Then
                        rtn = obj.ToString
                    End If
                End If

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "新規来店者番号取得"
        ''' <summary>新規来店者番号の取得</summary>
        ''' <returns>来店者番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function NewVisitorNumber() As String
            Dim rtn As String = ""
            Dim obj As New Object
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                str_sql = "SELECT MAX(来店者番号) + 1 FROM E_来店者 WHERE 来店日=@来店日 "

                param.Add("@来店日", Format(USER_DATE, "yyyy/MM/dd"))
                obj = DBA.ExecuteScalar(str_sql, param)

                If IsDBNull(obj) Then
                    rtn = "1"
                Else
                    rtn = obj.ToString
                End If

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "予約テーブル検索"
        ''' <summary>W_予約テーブル検索</summary>
        ''' <param name="v_param">SQLパラメータ:@予約番号</param>
        ''' <returns>予約者情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_reserve(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT 顧客姓,顧客名,顧客姓カナ,顧客名カナ,担当者名")
                builSQL.Append(" FROM W_予約 WHERE 予約番号 = @予約番号")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "担当者番号取得"
        ''' <summary>D_担当者より担当者番号取得</summary>
        ''' <param name="v_param">SQLパラメータ:@担当者名</param>
        ''' <returns>担当者番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function getOwnerNum(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String

            Try
                str_sql = "SELECT 担当者番号 FROM D_担当者 WHERE 担当者名 = @担当者名"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "同一日同一顧客来店判定"
        ''' <summary>同一日同一顧客来店判定</summary>
        ''' <param name="v_param">SQLパラメータ:@来店日、@顧客番号</param>
        ''' <returns>True：同一日に来店あり、False：同一日に来店なし</returns>
        ''' <remarks></remarks>
        Protected Friend Function checkTwiceVisits(ByVal v_param As Habits.DB.DBParameter) As Boolean
            checkTwiceVisits = False
            Dim dt As DataTable
            Dim str_sql As String

            Try

                str_sql = "SELECT COUNT(来店日) FROM E_来店者 WHERE 来店日 = @来店日 AND 顧客番号 = @顧客番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
                If Integer.Parse(dt.Rows(0)(0).ToString()) > 0 Then
                    checkTwiceVisits = True
                End If
            Catch ex As Exception
                Throw ex
            End Try

            Return checkTwiceVisits
        End Function
#End Region

#Region "来店回数取得"
        ''' <summary>来店回数検索</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>来店回数</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_customer(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String

            Try
                str_sql = "SELECT 来店回数 FROM D_顧客 WHERE 顧客番号 = @顧客番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "伝言存在チェック"
        ''' <summary>伝言有無チェック</summary>
        ''' <param name="v_dt">顧客情報</param>
        ''' <returns>伝言フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function isMessageFlag(ByVal v_dt As DataTable) As Boolean
            Dim rtn As Boolean = False

            If v_dt.Rows.Count > 0 Then
                If Not IsDBNull(v_dt.Rows(0)("伝言フラグ")) AndAlso Boolean.Parse(v_dt.Rows(0)("伝言フラグ").ToString) Then
                    rtn = True
                End If
            End If

            Return rtn
        End Function
#End Region

#Region "テーブル更新"

#Region "E_来店者登録処理"
        ''' <summary>来店者情報の登録</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function InsertVisitorData(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            'Dim objItem As Object

            Try
                ' トランザクション開始
                DBA.TransactionStart()
                v_param.Add("@更新日", Now)

                '------------------------------
                'E_来店者 INSERT
                '------------------------------
                builSQL.Append("INSERT INTO E_来店者")
                builSQL.Append(" (来店日")
                builSQL.Append(" ,来店者番号")
                builSQL.Append(" ,顧客番号")
                builSQL.Append(" ,姓")
                builSQL.Append(" ,名")
                builSQL.Append(" ,姓カナ")
                builSQL.Append(" ,住所")
                builSQL.Append(" ,前回来店日")
                builSQL.Append(" ,来店間隔")
                builSQL.Append(" ,主担当者番号")
                builSQL.Append(" ,来店区分番号")
                builSQL.Append(" ,指名")
                builSQL.Append(" ,作業開始")
                builSQL.Append(" ,作業終了")
                builSQL.Append(" ,会計済")
                builSQL.Append(" ,更新日,予約番号")
                builSQL.Append(" ) VALUES (")
                builSQL.Append("  @来店日")
                builSQL.Append(" ,@来店者番号")
                builSQL.Append(" ,@顧客番号")
                builSQL.Append(" ,@姓")
                builSQL.Append(" ,@名")
                builSQL.Append(" ,@姓カナ")
                builSQL.Append(" ,@住所")
                builSQL.Append(" ,@前回来店日")
                builSQL.Append(" ,@来店間隔")
                builSQL.Append(" ,@主担当者番号")
                builSQL.Append(" ,@来店区分番号")
                builSQL.Append(" ,@指名")
                builSQL.Append(" ,@作業開始")
                builSQL.Append(" ,@作業終了")
                builSQL.Append(" ,@会計済")
                builSQL.Append(" ,@更新日")
                builSQL.Append(" ,@予約番号)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("INSERT INTO visit(")
                builSQL.Append("shop_code")                 '店舗コード     (varchar)
                builSQL.Append(" ,date")                    '来店日
                builSQL.Append(" ,number")                  '来店者番号
                builSQL.Append(" ,basis_customer_code")     '顧客番号
                builSQL.Append(" ,last_name")               '姓
                builSQL.Append(" ,first_name")              '名
                builSQL.Append(" ,last_name_kana")          '姓カナ
                builSQL.Append(" ,address")                 '住所
                builSQL.Append(" ,last_visit_date")         '前回来店日
                builSQL.Append(" ,visit_interval")          '来店間隔
                builSQL.Append(" ,main_staff_code")         '主担当者番号
                builSQL.Append(" ,visit_division_code")     '来店区分番号
                builSQL.Append(" ,designated_flag")         '指名
                builSQL.Append(" ,start_date")              '作業開始
                builSQL.Append(" ,end_date")                '作業終了
                builSQL.Append(" ,paid_flag")               '会計済
                builSQL.Append(" ,update_date")             '更新日
                builSQL.Append(" ,reserve_sequence")        '予約番号
                builSQL.Append(" ) VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@姓")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@名")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@姓カナ")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@住所")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@前回来店日")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@来店間隔")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@主担当者番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@来店区分番号")))
                builSQL.Append("," & VbSQLStr(BoolToString(v_param.GetValue("@指名"))))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@作業開始")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@作業終了")))
                builSQL.Append("," & VbSQLStr(BoolToString(v_param.GetValue("@会計済"))))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@予約番号")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "D_顧客登録処理"
        ''' <summary>顧客情報の登録</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function InsertCustomerData(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            'Dim objItem As Object

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                '------------------------------
                'D_顧客 INSERT
                '------------------------------
                builSQL.Append("INSERT INTO D_顧客")
                builSQL.Append(" (顧客番号")
                builSQL.Append(" ,姓")
                builSQL.Append(" ,名")
                builSQL.Append(" ,姓カナ")
                builSQL.Append(" ,名カナ")
                builSQL.Append(" ,性別番号")
                builSQL.Append(" ,登録区分番号")
                builSQL.Append(" ,登録日")
                builSQL.Append(" ,更新日")
                builSQL.Append(" ) VALUES (")
                builSQL.Append("  @顧客番号")
                builSQL.Append(" ,@姓")
                builSQL.Append(" ,@名")
                builSQL.Append(" ,@姓カナ")
                builSQL.Append(" ,@名カナ")
                builSQL.Append(" ,@性別番号")
                builSQL.Append(" ,@登録区分番号")
                builSQL.Append(" ,@登録日")
                builSQL.Append(" ,@登録日)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("INSERT INTO basis_customer(")
                builSQL.Append("shop_code")             '店舗コード     (varchar)
                builSQL.Append(" ,code")                '顧客番号
                builSQL.Append(" ,last_name")           '姓
                builSQL.Append(" ,first_name")          '名
                builSQL.Append(" ,last_name_kana")      '姓カナ
                builSQL.Append(" ,first_name_kana")     '名カナ
                builSQL.Append(" ,gender_code")         '性別番号
                builSQL.Append(" ,register_code")       '登録区分番号
                builSQL.Append(" ,insert_date")         '登録日
                builSQL.Append(" ,update_date")         '更新日
                builSQL.Append(" ) VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@姓")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@名")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@姓カナ")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@名カナ")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@性別番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@登録区分番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@登録日")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@登録日")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "D_顧客更新処理"
        ''' <summary>顧客情報の更新</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function UpdateCustomerData(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                '------------------------------
                'D_顧客 UPDATE
                '------------------------------
                builSQL.Append("UPDATE D_顧客")
                builSQL.Append(" SET 姓=@姓")
                builSQL.Append(" ,名=@名")
                builSQL.Append(" ,姓カナ=@姓カナ")
                builSQL.Append(" ,名カナ=@名カナ")
                builSQL.Append(" ,性別番号=@性別番号")
                builSQL.Append(" ,登録区分番号=@登録区分番号")
                builSQL.Append(" ,登録日=@登録日")
                builSQL.Append(" ,更新日=@更新日")
                builSQL.Append(" WHERE 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE basis_customer SET ")
                builSQL.Append(" last_name=" & VbSQLNStr(v_param.GetValue("@姓")))
                builSQL.Append(" ,first_name=" & VbSQLNStr(v_param.GetValue("@名")))
                builSQL.Append(" ,last_name_kana=" & VbSQLNStr(v_param.GetValue("@姓カナ")))
                builSQL.Append(" ,first_name_kana=" & VbSQLNStr(v_param.GetValue("@名カナ")))
                builSQL.Append(" ,gender_code=" & VbSQLStr(v_param.GetValue("@性別番号")))
                builSQL.Append(" ,register_code=" & VbSQLStr(v_param.GetValue("@登録区分番号")))
                builSQL.Append(" ,insert_date=" & VbSQLStr(v_param.GetValue("@登録日")))
                builSQL.Append(" ,update_date=" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "D_顧客の来店回数更新処理"
        ''' <summary>来店回数の更新</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号/@来店回数/@更新日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks>来店時、顧客の現在来店回数＋1をする</remarks>
        Protected Friend Function customer_update(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Dim builSQL As New StringBuilder()

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                '------------------------------
                'D_顧客 UPDATE
                '------------------------------
                str_sql = "UPDATE D_顧客 SET 来店回数 = @来店回数 , 更新日 = @更新日 WHERE 顧客番号 = @顧客番号"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE basis_customer SET")
                builSQL.Append(" visit_times=" & VbSQLStr(v_param.GetValue("@来店回数")) & ",")
                builSQL.Append(" update_date=" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#End Region

    End Class
End Namespace