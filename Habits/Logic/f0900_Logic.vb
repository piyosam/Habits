#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>サービス画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class f0900_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f0900_サービス"

        ''' <summary>B_サービス取得</summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function B_サービス取得() As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT サービス番号 AS 番号, サービス名, 表示順,")
                builSQL.Append(" CASE WHEN 削除フラグ = 'False' THEN '  ' ELSE '×' END AS 表示,")
                builSQL.Append(" 登録日,更新日")
                builSQL.Append(" FROM B_サービス")
                builSQL.Append(" ORDER BY 表示順,サービス番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>
        ''' サービス番号最大取得取得
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function サービス_最大番号取得() As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT MAX(サービス番号) AS 最大番号 FROM B_サービス"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        Protected Friend Function 選択B_サービス取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Try
                str_sql = "SELECT * FROM B_サービス WHERE サービス番号=@サービス番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>
        ''' サービス名重複チェックに使用
        ''' </summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function 選択B_サービス名取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Try
                str_sql = "SELECT * FROM B_サービス WHERE サービス名=@サービス名 AND サービス番号<>@サービス番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>
        ''' B_サービス更新
        ''' </summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function B_サービス更新(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("UPDATE B_サービス SET")
                builSQL.Append(" サービス名 = @サービス名,")
                builSQL.Append(" 表示順 = @表示順,")
                builSQL.Append(" 削除フラグ = @削除フラグ,")
                builSQL.Append(" 更新日 = @更新日")
                builSQL.Append(" WHERE サービス番号 = @サービス番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE service SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@サービス名")) & ",")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue("@表示順")) & ",")
                builSQL.Append(" delete_flag =" & VbSQLStr(v_param.GetValue("@削除フラグ")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@サービス番号")))
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
        ''' B_サービス追加
        ''' </summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function B_サービス登録(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO B_サービス")
                builSQL.Append(" (サービス番号,")
                builSQL.Append(" サービス名,")
                builSQL.Append(" 表示順,")
                builSQL.Append(" 削除フラグ,")
                builSQL.Append(" 登録日,")
                builSQL.Append(" 更新日)")

                builSQL.Append(" VALUES")
                builSQL.Append(" (@サービス番号,")
                builSQL.Append(" @サービス名,")
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
                builSQL.Append("INSERT INTO service(")
                builSQL.Append(" shop_code,")       '店舗コード
                builSQL.Append(" code,")            'サービス番号
                builSQL.Append(" name,")            'サービス名
                builSQL.Append(" display_order,")   '表示順
                builSQL.Append(" delete_flag,")     '削除フラグ
                builSQL.Append(" insert_date,")     '登録日
                builSQL.Append(" update_date)")     '更新日
                builSQL.Append(" VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@サービス番号")) & ",")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@サービス名")) & ",")
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
