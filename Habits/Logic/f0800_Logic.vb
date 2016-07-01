#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>カード会社画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class f0800_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f0800_カード会社"

        ''' <summary>カード会社一覧取得</summary>
        ''' <returns>カード会社リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_cardinfo() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT カード会社番号 AS 番号, カード会社名, 表示順,")
                builSQL.Append(" CASE WHEN 削除フラグ = 'False' THEN '  ' ELSE '×' END AS 表示")
                builSQL.Append(" FROM C_カード会社")
                builSQL.Append(" ORDER BY 表示順,カード会社番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>カード会社番号存在チェック</summary>
        ''' <param name="v_param">SQLパラメータ：@カード会社番号</param>
        ''' <returns>カード会社番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_number(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT カード会社番号 FROM C_カード会社 WHERE カード会社番号 = @カード会社番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>カード会社名存在チェック</summary>
        ''' <param name="v_param">SQLパラメータ：@カード会社名</param>
        ''' <returns>カード会社名</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_cardname(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT カード会社名 FROM C_カード会社 WHERE カード会社名 = @カード会社名"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>カード会社情報登録</summary>
        ''' <param name="v_param">SQLパラメータ：@カード会社番号/@カード会社名/@表示順/@削除フラグ/@登録日/@更新日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_cardinfo(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("INSERT INTO C_カード会社 (")
                builSQL.Append(" カード会社番号,")
                builSQL.Append(" カード会社名,")
                builSQL.Append(" 表示順,")
                builSQL.Append(" 削除フラグ,")
                builSQL.Append(" 登録日,")
                builSQL.Append(" 更新日)")

                builSQL.Append(" VALUES (@カード会社番号,@カード会社名, @表示順, @削除フラグ, @登録日, @更新日)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("INSERT INTO card_corporation (")
                builSQL.Append(" shop_code,")       '店舗コード
                builSQL.Append(" code,")            'カード会社番号
                builSQL.Append(" name,")            'カード会社名
                builSQL.Append(" display_order,")   '表示順
                builSQL.Append(" delete_flag,")     '削除フラグ
                builSQL.Append(" insert_date,")     '登録日
                builSQL.Append(" update_date)")     '更新日
                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@カード会社番号")) & ",")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@カード会社名")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@表示順")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@削除フラグ")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@登録日")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@更新日")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>カード会社情報更新</summary>
        ''' <param name="v_param">SQLパラメータ：@カード会社番号/@カード会社名/@表示順/@削除フラグ/@更新日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_cardinfo(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append(" UPDATE C_カード会社 SET")
                builSQL.Append(" カード会社名 = @カード会社名,")
                builSQL.Append(" 表示順 = @表示順,")
                builSQL.Append(" 削除フラグ = @削除フラグ,")
                builSQL.Append(" 更新日 = @更新日")
                builSQL.Append(" WHERE カード会社番号 = @カード会社番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append(" UPDATE card_corporation SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@カード会社名")) & "")
                builSQL.Append(" ,display_order =" & VbSQLStr(v_param.GetValue("@表示順")) & "")
                builSQL.Append(" ,delete_flag =" & VbSQLStr(v_param.GetValue("@削除フラグ")) & "")
                builSQL.Append(" ,update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@カード会社番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>カード会社番号最大取得取得</summary>
        ''' <returns>最大カード会社番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function カード会社_最大番号取得() As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT MAX(カード会社番号) AS 最大番号 FROM C_カード会社"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
    End Class
End Namespace