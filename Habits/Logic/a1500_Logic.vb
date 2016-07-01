#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>作業時間設定（工程別）画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a1500_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1500_作業時間設定"

        ''' <summary>スタッフ一覧取得</summary>
        ''' <returns>スタッフリスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function スタッフ一覧() As DataTable
            Dim param As New Habits.DB.DBParameter
            param.Add("@営業日", USER_DATE)
            Return MyBase.W_スタッフPlus_E_売上(param)
        End Function

        ''' <summary>ポイントデータ追加</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks>W_ポイントInsert</remarks>
        Protected Friend Function pointAdd_W(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim str_sql As String
            Dim sb As New StringBuilder()

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                sb.Append("INSERT INTO W_ポイント(")
                sb.Append(" 来店日,")
                sb.Append("来店者番号,")
                sb.Append(" 顧客番号,")
                sb.Append(" 売上番号,")
                sb.Append(" 売上区分番号,")
                sb.Append(" 分類番号,")
                sb.Append(" 商品番号,")
                sb.Append(" 工程番号,")
                sb.Append(" 工程名,")
                sb.Append(" ポイント,")
                sb.Append(" 担当者コード)")
                sb.Append(" VALUES (")
                sb.Append(" @来店日,")
                sb.Append(" @来店者番号,")
                sb.Append(" @顧客番号,")
                sb.Append(" @売上番号,")
                sb.Append(" @売上区分番号,")
                sb.Append(" @分類番号,")
                sb.Append(" @商品番号,")
                sb.Append(" @工程番号,")
                sb.Append(" @工程名,")
                sb.Append(" @ポイント,")
                sb.Append(" 0)")

                str_sql = sb.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                '' 例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>ポイントデータ追加</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks>E_ポイントInsert</remarks>
        Protected Friend Function pointAdd(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim str_sql As String
            Dim sb As New StringBuilder()

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                sb.Append("INSERT INTO E_ポイント(")
                sb.Append(" 来店日,")
                sb.Append(" 来店者番号,")
                sb.Append(" 顧客番号,")
                sb.Append(" 売上番号,")
                sb.Append(" 売上区分番号,")
                sb.Append(" 分類番号,")
                sb.Append(" 商品番号,")
                sb.Append(" 工程番号,")
                sb.Append(" 工程名,")
                sb.Append(" ポイント,")
                sb.Append(" 担当者コード,")
                sb.Append(" 担当者名,")
                sb.Append(" 更新日 )")

                sb.Append(" VALUES (")
                sb.Append(" @来店日,")
                sb.Append(" @来店者番号,")
                sb.Append(" @顧客番号,")
                sb.Append(" @売上番号,")
                sb.Append(" @売上区分番号,")
                sb.Append(" @分類番号,")
                sb.Append(" @商品番号,")
                sb.Append(" @工程番号,")
                sb.Append(" @工程名,")
                sb.Append(" @ポイント,")
                sb.Append(" @担当者コード,")
                sb.Append(" @担当者名, ")
                sb.Append(" @更新日 )")

                str_sql = sb.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                sb.Length = 0
                sb.Append("INSERT INTO staff_point(")
                sb.Append("shop_code,")             '店舗コード(varchar
                sb.Append(" visit_date,")           '来店日(datetime)
                sb.Append(" visit_number,")         '来店者番号(smallint)
                sb.Append(" basis_customer_code,")  '顧客番号(int)
                sb.Append(" sales_details_code,")   '売上番号(smallint)
                sb.Append(" sales_division_code,")  '売上区分番号(smallint)
                sb.Append(" class_code,")           '分類番号(smallint)
                sb.Append(" goods_code,")           '商品番号(smallint)
                sb.Append(" process_code,")         '工程番号(smallint)
                sb.Append(" process_name,")         '工程名(nvarchar)
                sb.Append(" point,")                'ポイント(smallint)
                sb.Append(" basis_staff_code,")     '担当者コード(smallint)
                sb.Append(" basis_staff_name,")     '担当者名(nvarchar)
                sb.Append(" update_date )")         '更新日(datetime)

                sb.Append(" VALUES (")
                sb.Append(VbSQLNStr(sShopcode) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@来店日")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@来店者番号")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@顧客番号")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@売上番号")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@売上区分番号")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@分類番号")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@商品番号")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@工程番号")) & ",")
                sb.Append(VbSQLNStr(v_param.GetValue("@工程名")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@ポイント")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@担当者コード")) & ",")
                sb.Append(VbSQLNStr(v_param.GetValue("@担当者名")) & ",")
                sb.Append(VbSQLStr(v_param.GetValue("@更新日")) & ")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, sb.ToString)

                ' コミット
                DBA.TransactionCommit()

            Catch ex As Exception
                '' 例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>工程情報取得</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>工程情報リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function 工程内容取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Dim sb As New StringBuilder()

            Try
                sb.Append("SELECT C_商品工程.工程番号,B_工程.工程名,B_工程.ポイント")
                sb.Append(" FROM C_商品工程 JOIN B_工程 ON  C_商品工程.工程番号 = B_工程.工程番号")
                sb.Append(" WHERE C_商品工程.売上区分番号 = @売上区分番号")
                sb.Append(" AND C_商品工程.分類番号 = @分類番号")
                sb.Append(" AND C_商品工程.商品番号 = @商品番号")
                sb.Append(" AND B_工程.削除フラグ = 'FALSE'")
                sb.Append(" ORDER BY C_商品工程.表示順")

                str_sql = sb.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>ポイント情報取得</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>ポイント情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function ポイント結果(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Dim sb As New StringBuilder()

            Try
                sb.Append("SELECT P.売上区分番号, P.分類番号, P.商品番号, P.工程番号")
                sb.Append(" ,P.工程名, P.来店日, P.来店者番号, P.顧客番号, P.売上番号")
                sb.Append(" ,P.ポイント AS ポイント, P.担当者コード, P.担当者名")
                sb.Append(" ,P.更新日")
                sb.Append(" FROM E_ポイント AS P")
                sb.Append(" LEFT OUTER JOIN C_商品工程")
                sb.Append(" ON P.売上区分番号 = C_商品工程.売上区分番号")
                sb.Append(" AND P.分類番号 = C_商品工程.分類番号")
                sb.Append(" AND P.商品番号 = C_商品工程.商品番号")
                sb.Append(" AND P.工程番号 = C_商品工程.工程番号")
                sb.Append(" WHERE P.来店日 = @来店日")
                sb.Append(" AND P.来店者番号 = @来店者番号")
                sb.Append(" AND P.顧客番号 = @顧客番号")
                sb.Append(" AND P.売上番号 = @売上番号")
                sb.Append(" AND P.売上区分番号 = @売上区分番号")
                sb.Append(" AND P.分類番号 = @分類番号")
                sb.Append(" AND P.商品番号 = @商品番号")
                sb.Append(" ORDER BY C_商品工程.表示順")

                str_sql = sb.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>W_ポイント一括削除</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_W_ポイント() As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0

            Try
                ' トランザクション開始
                DBA.TransactionStart()
                str_sql = "DELETE W_ポイント FROM W_ポイント"

                rtn = DBA.ExecuteNonQuery(str_sql)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>ポイント情報取得</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>ポイント情報</returns>
        ''' <remarks>W_ポイント</remarks>
        Function select_W(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim rtn As DataTable
            Dim str_sql As String
            Dim sb As New StringBuilder()

            Try
                sb.Append("SELECT 売上区分番号,分類番号,商品番号,工程番号,工程名,来店日,")
                sb.Append(" 来店者番号,顧客番号,売上番号,ポイント,担当者コード,担当者名")
                sb.Append(" FROM W_ポイント")
                sb.Append(" WHERE 来店日 = @来店日")
                sb.Append(" AND 来店者番号 = @来店者番号")
                sb.Append(" AND 顧客番号 = @顧客番号")
                sb.Append(" AND 売上番号 = @売上番号")
                sb.Append(" AND 売上区分番号 = @売上区分番号")
                sb.Append(" AND 分類番号 = @分類番号")
                sb.Append(" AND 商品番号 = @商品番号")

                str_sql = sb.ToString
                rtn = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>ポイント情報取得</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>ポイント情報</returns>
        ''' <remarks>E_ポイント</remarks>
        Function selectPoint(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim rtn As DataTable
            Dim str_sql As String
            Dim sb As New StringBuilder()

            Try
                sb.Append("SELECT 売上区分番号,分類番号,商品番号,工程番号,工程名,来店日,")
                sb.Append(" 来店者番号,顧客番号,売上番号,ポイント,担当者コード,担当者名,更新日")
                sb.Append(" FROM E_ポイント")
                sb.Append(" WHERE 来店日 = @来店日")
                sb.Append(" AND 来店者番号 = @来店者番号")
                sb.Append(" AND 顧客番号 = @顧客番号")
                sb.Append(" AND 売上番号 = @売上番号")
                sb.Append(" AND 売上区分番号 = @売上区分番号")
                sb.Append(" AND 分類番号 = @分類番号")
                sb.Append(" AND 商品番号 = @商品番号")
                sb.Append(" AND 工程番号 = @工程番号")

                str_sql = sb.ToString
                rtn = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>W_ポイント削除</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_W_ポイント(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim dt As Integer
            Dim sb As New StringBuilder()

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                sb.Append("DELETE FROM W_ポイント")
                sb.Append(" WHERE 来店日 = @来店日")
                sb.Append(" AND 来店者番号 = @来店者番号")
                sb.Append(" AND 顧客番号 = @顧客番号")
                sb.Append(" AND 売上番号 = @売上番号")
                sb.Append(" AND 売上区分番号 = @売上区分番号")
                sb.Append(" AND 分類番号 = @分類番号")
                sb.Append(" AND 商品番号 = @商品番号")
                sb.Append(" AND 工程番号 = @工程番号")

                str_sql = sb.ToString
                dt = DBA.ExecuteNonQuery(str_sql, v_param)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>E_ポイント削除</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_E_ポイント(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim dt As Integer
            Dim sb As New StringBuilder()

            Try
                ' トランザクション開始
                DBA.TransactionStart()
                sb.Length = 0
                sb.Append("DELETE FROM E_ポイント")
                sb.Append(" WHERE 来店日 = @来店日")
                sb.Append(" AND 来店者番号 = @来店者番号")
                sb.Append(" AND 顧客番号 = @顧客番号")
                sb.Append(" AND 売上区分番号 = @売上区分番号")
                sb.Append(" AND 分類番号 = @分類番号")
                sb.Append(" AND 商品番号 = @商品番号")
                sb.Append(" AND 工程番号 = @工程番号")

                str_sql = sb.ToString
                dt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                sb.Length = 0
                sb.Append("DELETE FROM staff_point")

                sb.Append(" WHERE visit_date=" & VbSQLStr(v_param.GetValue("@来店日")))
                sb.Append(" AND visit_number=" & VbSQLStr(v_param.GetValue("@来店者番号")))
                sb.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                sb.Append(" AND sales_division_code=" & VbSQLStr(v_param.GetValue("@売上区分番号")))
                sb.Append(" AND class_code=" & VbSQLStr(v_param.GetValue("@分類番号")))
                sb.Append(" AND goods_code=" & VbSQLStr(v_param.GetValue("@商品番号")))
                sb.Append(" AND process_code=" & VbSQLStr(v_param.GetValue("@工程番号")))
                sb.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, sb.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>売上明細の作業時間更新</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 作業時間設定(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim dt As Boolean
            Dim sb As New StringBuilder()

            Try
                sb.Append("UPDATE E_売上明細 ")
                sb.Append(" SET 作業開始 = @作業開始, 作業終了 = @作業終了 ,更新日 = @更新日")
                sb.Append(" WHERE 来店日 = @来店日")
                sb.Append(" AND 来店者番号 = @来店者番号")
                sb.Append(" AND 顧客番号 = @顧客番号")
                sb.Append(" AND 売上番号 = @売上番号")
                sb.Append(" AND 更新日 = @更新日")
                str_sql = sb.ToString
                dt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                sb.Length = 0
                sb.Append("UPDATE sales_details ")
                sb.Append(" SET start_date=" & VbSQLStr(v_param.GetValue("@作業開始")))
                sb.Append(", end_date=" & VbSQLStr(v_param.GetValue("@作業終了")))
                sb.Append(", update_date=" & VbSQLStr(v_param.GetValue("@更新日")))
                sb.Append(" WHERE visit_date=" & VbSQLStr(v_param.GetValue("@来店日")))
                sb.Append(" AND visit_number=" & VbSQLStr(v_param.GetValue("@来店者番号")))
                sb.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                sb.Append(" AND code=" & VbSQLStr(v_param.GetValue("@売上番号")))
                sb.Append(" AND update_date=" & VbSQLStr(v_param.GetValue("@更新日")))
                sb.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, sb.ToString)
            Catch ex As Exception
                ''例外時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>売上明細の作業時間更新</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_starttime(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String

            Try
                str_sql = "SELECT 作業開始, 作業終了 FROM E_来店者 WHERE 来店日 = @来店日 AND 来店者番号 = @来店者番号 "
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>商品情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>商品情報リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_skillItem(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT 商品.商品名,商品.売上区分番号,商品.分類番号,商品.商品番号,C_分類.分類名,売上番号,数量 FROM ( ")
                builSQL.Append(" SELECT C_商品.商品名,売上明細.売上区分番号,売上明細.分類番号,売上明細.商品番号,売上明細.売上番号,売上明細.数量 FROM ( ")
                builSQL.Append(" SELECT 売上区分番号,分類番号,名称番号  AS 商品番号 ,売上番号,数量 FROM E_売上明細 ")
                builSQL.Append(" WHERE 来店者番号 = @来店者番号 AND 来店日 = @来店日 AND 顧客番号 = @顧客番号) AS 売上明細")
                builSQL.Append(" INNER JOIN C_商品 ON 売上明細.売上区分番号 = C_商品.売上区分番号")
                builSQL.Append(" AND 売上明細.分類番号 = C_商品.分類番号")
                builSQL.Append(" AND 売上明細.商品番号 = C_商品.商品番号) AS 商品")
                builSQL.Append(" INNER JOIN C_分類 ON 商品.分類番号 = C_分類.分類番号")
                builSQL.Append(" AND 商品.売上区分番号 = C_分類.売上区分番号")
                builSQL.Append(" WHERE C_分類.店販対象フラグ = 'False'")
                builSQL.Append(" AND C_分類.削除フラグ = 'False'")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace