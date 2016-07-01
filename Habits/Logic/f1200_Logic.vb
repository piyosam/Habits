#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>ポイント割引画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class f1200_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f1200_ポイント割引"

        ''' <summary>B_ポイント割引取得</summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function B_ポイント割引取得() As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT ポイント割引番号 AS 番号, ポイント割引名, 表示順,")
                builSQL.Append(" CASE WHEN 削除フラグ = 'False' THEN '  ' ELSE '×' END AS 表示,")
                builSQL.Append(" 登録日,更新日")
                builSQL.Append(" FROM B_ポイント割引")
                builSQL.Append(" ORDER BY 表示順,ポイント割引番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>
        ''' ポイント割引番号最大取得取得
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function ポイント割引_最大番号取得() As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT MAX(ポイント割引番号) AS 最大番号 FROM B_ポイント割引"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        Protected Friend Function 選択B_ポイント割引取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Try
                str_sql = "SELECT * FROM B_ポイント割引 WHERE ポイント割引番号=@ポイント割引番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>
        ''' ポイント割引名重複チェックに使用
        ''' </summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function 選択B_ポイント割引名取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Try
                str_sql = "SELECT * FROM B_ポイント割引 WHERE ポイント割引名=@ポイント割引名 AND ポイント割引番号<>@ポイント割引番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>
        ''' B_ポイント割引更新
        ''' </summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function B_ポイント割引更新(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("UPDATE B_ポイント割引 SET")
                builSQL.Append(" ポイント割引名 = @ポイント割引名,")
                builSQL.Append(" 表示順 = @表示順,")
                builSQL.Append(" 削除フラグ = @削除フラグ,")
                builSQL.Append(" 更新日 = @更新日")
                builSQL.Append(" WHERE ポイント割引番号 = @ポイント割引番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE point_purchases SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@ポイント割引名")) & ",")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue("@表示順")) & ",")
                builSQL.Append(" delete_flag =" & VbSQLStr(v_param.GetValue("@削除フラグ")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@ポイント割引番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' 例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>
        ''' B_ポイント割引追加
        ''' </summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function B_ポイント割引登録(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO B_ポイント割引")
                builSQL.Append(" (ポイント割引番号,")
                builSQL.Append(" ポイント割引名,")
                builSQL.Append(" 表示順,")
                builSQL.Append(" 削除フラグ,")
                builSQL.Append(" 登録日,")
                builSQL.Append(" 更新日)")

                builSQL.Append(" VALUES")
                builSQL.Append(" (@ポイント割引番号,")
                builSQL.Append(" @ポイント割引名,")
                builSQL.Append(" @表示順,")
                builSQL.Append(" @削除フラグ,")
                builSQL.Append(" @登録日,")
                builSQL.Append(" @更新日)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("INSERT INTO point_purchases(")
                builSQL.Append(" shop_code,")       '店舗コード
                builSQL.Append(" code,")            'ポイント割引番号
                builSQL.Append(" name,")            'ポイント割引名
                builSQL.Append(" display_order,")   '表示順
                builSQL.Append(" delete_flag,")     '削除フラグ
                builSQL.Append(" insert_date,")     '登録日
                builSQL.Append(" update_date)")     '更新日
                builSQL.Append(" VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@ポイント割引番号")) & ",")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@ポイント割引名")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@表示順")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@削除フラグ")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@登録日")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@更新日")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ''例外処理はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
    End Class
End Namespace
