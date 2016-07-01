#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>工程マスタ画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class f1100_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f1100_工程マスタ"

        ''' <summary>工程一覧取得</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 内容更新() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                'データを取得
                builSQL.Append("SELECT 工程番号,工程名,ポイント,表示順,")
                builSQL.Append(" CASE WHEN 削除フラグ = 'False' THEN '  ' ELSE '×' END AS 表示")
                builSQL.Append(" FROM B_工程")
                builSQL.Append(" ORDER BY 表示順,工程番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>B_工程登録</summary>
        ''' <param name="v_param">SQLパラメータ：@工程番号/@工程名/@ポイント/@削除フラグ/@登録日/@更新日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 工程登録(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO B_工程(")
                builSQL.Append(" 工程番号,")
                builSQL.Append(" 工程名,")
                builSQL.Append(" ポイント,")
                builSQL.Append(" 表示順,")
                builSQL.Append(" 削除フラグ,")
                builSQL.Append(" 登録日,")
                builSQL.Append(" 更新日)")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @工程番号,")
                builSQL.Append(" @工程名,")
                builSQL.Append(" @ポイント,")
                builSQL.Append(" @表示順,")
                builSQL.Append(" @削除フラグ,")
                builSQL.Append(" @登録日,")
                builSQL.Append(" @更新日)")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("INSERT INTO process(")
                builSQL.Append(" shop_code,")
                builSQL.Append(" code,")        '工程番号
                builSQL.Append(" name,")        '工程名
                builSQL.Append(" point,")       'ポイント
                builSQL.Append(" display_order,")   '表示順
                builSQL.Append(" delete_flag,")     '削除フラグ
                builSQL.Append(" insert_date,")     '登録日
                builSQL.Append(" update_date)")     '更新日
                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@工程番号")) & ",")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@工程名")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@ポイント")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@表示順")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@削除フラグ")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@登録日")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@更新日")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                '' 例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>B_工程のポイント取得</summary>
        ''' <param name="v_param">SQLパラメータ：@工程番号</param>
        ''' <returns>ポイント</returns>
        ''' <remarks></remarks>
        Protected Friend Function 番号確認(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT ポイント FROM B_工程 WHERE 工程番号 = @工程番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>商品（店販対象外）の更新</summary>
        ''' <param name="v_param">SQLパラメータ：@工程名/@ポイント/@表示順/@削除フラグ/@更新日/@工程番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 工程変更(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("UPDATE B_工程 SET")
                builSQL.Append(" 工程名 = @工程名,")
                builSQL.Append(" ポイント = @ポイント,")
                builSQL.Append(" 表示順 = @表示順,")
                builSQL.Append(" 削除フラグ = @削除フラグ,")
                builSQL.Append(" 更新日 = @更新日")
                builSQL.Append(" WHERE 工程番号 = @工程番号 ")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE process SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@工程名")) & ",")
                builSQL.Append(" point =" & VbSQLStr(v_param.GetValue("@ポイント")) & ",")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue("@表示順")) & ",")
                builSQL.Append(" delete_flag =" & VbSQLStr(v_param.GetValue("@削除フラグ")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@工程番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                '' 例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function

        ''' <summary>最大工程番号取得</summary>
        ''' <returns>最大工程番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function getMaxProcessNumber() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT MAX(工程番号) AS 最大番号 FROM B_工程"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

    End Class

End Namespace
