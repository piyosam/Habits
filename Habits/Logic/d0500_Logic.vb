#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>会計画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class d0500_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "d0500_現金入出金登録"

        ''' <summary>次の入出金番号（最大値+1）を取得</summary>
        ''' <param name="v_date">入出金日("yyyy/MM/dd")</param>
        ''' <returns>入出金番号</returns>
        ''' <remarks>初期の入出金番号=1とする</remarks>
        Protected Friend Function E_次入出金番号取得(ByVal v_date As Date) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Dim param As New Habits.DB.DBParameter

            Dim const_開始入出金番号 As Integer = 1
            Dim rtn As Integer = -1

            Try
                param.Clear()
                param.Add("@入出金日", v_date)

                builSQL.Append("SELECT MAX(入出金番号) AS 入出金番号")
                builSQL.Append(" FROM E_入出金")
                builSQL.Append(" WHERE DATEDIFF(d, @入出金日, 入出金日) = 0")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)

                If dt.Rows.Count = 0 Then
                    rtn = const_開始入出金番号
                Else
                    If IsDBNull(dt.Rows(0).Item("入出金番号")) Then
                        rtn = const_開始入出金番号
                    Else
                        rtn = Integer.Parse(dt.Rows(0)("入出金番号").ToString) + 1
                    End If
                End If

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function


        ''' <summary>入出金の新規登録</summary>
        ''' <param name="v_hashtable">
        ''' SQLパラメータ(Hashtable)：@入出金日/@入出金番号/@入出金区分番号/@金額
        '''                /@担当者番号/@摘要/@登録日
        ''' </param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function ReceivingAndMakingPaymentsInsert(ByRef v_hashtable As Hashtable) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Dim tmp_int As Integer = 0

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                ' E_入出金テーブル登録パラメータ
                param.Clear()
                param.Add("@入出金日", v_hashtable("@入出金日"))
                param.Add("@入出金番号", v_hashtable("@入出金番号"))
                param.Add("@入出金区分番号", v_hashtable("@入出金区分番号"))
                param.Add("@金額", v_hashtable("@金額"))
                param.Add("@担当者番号", v_hashtable("@担当者番号"))
                param.Add("@摘要", v_hashtable("@摘要"))
                param.Add("@登録日", v_hashtable("@登録日"))

                ' E_入出庫テーブルにデータを登録
                builSQL.Append("INSERT INTO E_入出金 (")
                builSQL.Append(" 入出金日,")
                builSQL.Append(" 入出金番号,")
                builSQL.Append(" 入出金区分番号,")
                builSQL.Append(" 金額,")
                builSQL.Append(" 担当者番号,")
                builSQL.Append(" 摘要,")
                builSQL.Append(" 登録日 )")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @入出金日,")
                builSQL.Append(" @入出金番号,")
                builSQL.Append(" @入出金区分番号,")
                builSQL.Append(" @金額,")
                builSQL.Append(" @担当者番号,")
                builSQL.Append(" @摘要,")
                builSQL.Append(" @登録日 )")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("INSERT INTO cash_book(")
                builSQL.Append(" shop_code,")
                builSQL.Append(" date,")
                builSQL.Append(" code,")
                builSQL.Append(" cash_division_code,")
                builSQL.Append(" amount,")
                builSQL.Append(" basis_staff_code,")
                builSQL.Append(" summary,")
                builSQL.Append(" insert_date)")

                builSQL.Append(" VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode) & ", ")
                builSQL.Append(VbSQLStr(param.GetValue("@入出金日")) & ", ")
                builSQL.Append(VbSQLStr(param.GetValue("@入出金番号")) & ", ")
                builSQL.Append(VbSQLStr(param.GetValue("@入出金区分番号")) & ", ")
                builSQL.Append(VbSQLStr(param.GetValue("@金額")) & ", ")
                builSQL.Append(VbSQLStr(param.GetValue("@担当者番号")) & ", ")
                builSQL.Append(VbSQLNStr(param.GetValue("@摘要")) & ", ")
                builSQL.Append(VbSQLStr(param.GetValue("@登録日")) & ")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>入出金履歴を取得</summary>
        ''' <param name="v_param">SQLパラメータ：@入出金年月(yyyyMMdd)</param>
        ''' <returns>入出金情報リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetSelectedPaymentsHistory(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT E_入出金.入出金日 AS 入出金日,")
                builSQL.Append(" CONVERT(varchar, E_入出金.入出金番号) AS 番号,")
                builSQL.Append(" E_入出金.入出金区分番号 AS 入出金区分番号,")
                builSQL.Append(" CASE E_入出金.入出金区分番号")
                builSQL.Append(" WHEN 1 THEN E_入出金.金額")
                builSQL.Append(" END AS 入金,")
                builSQL.Append(" CASE E_入出金.入出金区分番号")
                builSQL.Append(" WHEN 2 THEN E_入出金.金額")
                builSQL.Append(" END AS 出金,")
                builSQL.Append(" D_担当者.担当者名 AS 担当者名,")
                builSQL.Append(" E_入出金.摘要 AS 摘要")
                builSQL.Append(" FROM E_入出金 INNER JOIN D_担当者 ON E_入出金.担当者番号 = D_担当者.担当者番号")
                builSQL.Append(" WHERE E_入出金.入出金日")
                builSQL.Append(" BETWEEN @検索開始日")
                builSQL.Append(" AND @検索終了日")
                builSQL.Append(" ORDER BY E_入出金.入出金日 ASC, E_入出金.入出金番号 ASC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function


        ''' <summary>E_入出金テーブルの入出金番号存在確認</summary>
        ''' <param name="v_param">SQLパラメータ：@入出金日/@入出金番号</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function IsExistPaymentsNumber(ByVal v_param As Habits.DB.DBParameter) As Boolean
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT 1")
                builSQL.Append(" FROM E_入出金")
                builSQL.Append(" WHERE 入出金日 = @入出金日")
                builSQL.Append(" AND 入出金番号 = @入出金番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>入出金履歴を削除</summary>
        ''' <param name="v_param">SQLパラメータ：@入出金日、@入出金番号</param>
        ''' <remarks></remarks>
        Protected Friend Sub DeletePaymentsHistory(ByVal v_param As Habits.DB.DBParameter)
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Dim param As New Habits.DB.DBParameter

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                '------------------------------
                'E_入出金 DELETE
                '------------------------------
                str_sql = "DELETE FROM E_入出金 WHERE 入出金日 = @入出金日 AND 入出金番号 = @入出金番号"

                DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("DELETE FROM cash_book")
                builSQL.Append(" WHERE shop_code =" & VbSQLNStr(sShopcode))
                builSQL.Append(" AND date =" & VbSQLStr(v_param.GetValue("@入出金日")))
                builSQL.Append(" AND code =" & VbSQLStr(v_param.GetValue("@入出金番号")))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()

            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Sub

        ''' <summary>発注出力パス取得</summary>
        ''' <returns>発注出力パス</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_ASY() As String
            Dim rtn As String
            rtn = getPath(1)
            Return rtn
        End Function

        ''' <summary>発注出力パス取得</summary>
        ''' <param name="v_param">SQLパラメータ：@発注出力パス名/@変更日時</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_ASY(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim dt As Integer
            Dim str_sql As String
            Try
                str_sql = "UPDATE A_システム SET 発注出力パス名 = @発注出力パス名 , 変更日時 = @変更日時"
                dt = DBA.ExecuteNonQuery(str_sql, v_param)

                str_sql = "UPDATE system SET order_output_path=" & VbSQLNStr(v_param.GetValue("@発注出力パス名")) & _
                        ", update_date = " & VbSQLStr(v_param.GetValue("@変更日時")) & " WHERE shop_code=" & VbSQLNStr(sShopcode)
                rtn = InsertZSqlExecHis(PAGE_TITLE, str_sql)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function

    End Class
End Namespace
