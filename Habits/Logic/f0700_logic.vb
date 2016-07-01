#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>メーカー画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class f0700_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f0700_メーカー"

        ''' <summary>メーカー一覧取得</summary>
        ''' <returns>メーカーリスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_maker() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT メーカー番号 AS 番号, メーカー名, 表示順,")
                builSQL.Append(" CASE WHEN 削除フラグ = 'False'")
                builSQL.Append(" THEN '  ' ELSE '×' END AS 表示")
                builSQL.Append(" FROM C_メーカー")
                builSQL.Append(" ORDER BY 表示順,メーカー番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>メーカー番号存在チェック</summary>
        ''' <param name="v_param">SQLパラメータ：@メーカー番号</param>
        ''' <returns>メーカー番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_number(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT メーカー番号")
                builSQL.Append(" FROM C_メーカー")
                builSQL.Append(" WHERE メーカー番号 = @メーカー番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>メーカー名存在チェック</summary>
        ''' <param name="v_param">SQLパラメータ：@メーカー名</param>
        ''' <returns>メーカー名</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_makername(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT メーカー名")
                builSQL.Append(" FROM C_メーカー")
                builSQL.Append(" WHERE メーカー名 = @メーカー名")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>メーカー情報登録</summary>
        ''' <param name="v_param">SQLパラメータ：@メーカー番号/@メーカー名/@表示順/@削除フラグ/@登録日/@更新日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_makerinfo(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("INSERT INTO C_メーカー(")
                builSQL.Append(" メーカー番号,")
                builSQL.Append(" メーカー名,")
                builSQL.Append(" 表示順,")
                builSQL.Append(" 削除フラグ,")
                builSQL.Append(" 登録日,")
                builSQL.Append(" 更新日)")

                builSQL.Append(" VALUES(@メーカー番号, @メーカー名, @表示順, @削除フラグ, @登録日, @更新日)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("INSERT INTO maker(")
                builSQL.Append(" shop_code,")       '店舗コード
                builSQL.Append(" code,")            'メーカー番号
                builSQL.Append(" name,")            'メーカー名
                builSQL.Append(" display_order,")   '表示順
                builSQL.Append(" delete_flag,")     '削除フラグ
                builSQL.Append(" insert_date,")     '登録日
                builSQL.Append(" update_date)")     '更新日
                builSQL.Append(" VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@メーカー番号")) & ", ")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@メーカー名")) & ", ")
                builSQL.Append(VbSQLStr(v_param.GetValue("@表示順")) & ", ")
                builSQL.Append(VbSQLStr(v_param.GetValue("@削除フラグ")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@登録日")) & ", ")
                builSQL.Append(VbSQLStr(v_param.GetValue("@更新日")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>作業時間情報更新</summary>
        ''' <param name="v_param">SQLパラメータ：@メーカー名/@表示順/@削除フラグ/@更新日/@メーカー番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_makerinfo(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("UPDATE C_メーカー SET")
                builSQL.Append(" メーカー名 = @メーカー名,")
                builSQL.Append(" 表示順 = @表示順,")
                builSQL.Append(" 削除フラグ = @削除フラグ,")
                builSQL.Append(" 更新日 = @更新日")
                builSQL.Append(" WHERE メーカー番号 = @メーカー番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE maker SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@メーカー名")) & ",")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue("@表示順")) & ",")
                builSQL.Append(" delete_flag =" & VbSQLStr(v_param.GetValue("@削除フラグ")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@メーカー番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>最大メーカー番号取得</summary>
        ''' <returns>メーカー番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_nextnum() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT MAX(メーカー番号) AS 最大メーカー番号 FROM C_メーカー"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace