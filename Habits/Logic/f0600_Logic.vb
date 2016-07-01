#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>担当者画面ロジック</summary>
    ''' <remarks></remarks>
    Public Class f0600_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f0600_スタッフ"

        ''' <summary>担当者一覧（表示フラグ付）取得</summary>
        ''' <returns>担当者リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function 担当者全件取得() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT 担当者番号 AS 番号,担当者名 AS スタッフ名,表示順,")
                builSQL.Append(" CASE WHEN 削除フラグ = 'False' THEN '  ' ELSE '×' END AS 表示")
                builSQL.Append(" FROM D_担当者")
                builSQL.Append(" ORDER BY 表示順,担当者番号")
                str_sql = builSQL.ToString

                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>担当者一覧（有効のみ）取得</summary>
        ''' <returns>担当者番号リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_d_stuff() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function

        ''' <summary>担当者一覧（有効のみ、表示フラグ付）取得</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 担当者一覧取得() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT 担当者番号 AS 番号,担当者名 AS スタッフ名,表示順,")
                builSQL.Append(" CASE WHEN 削除フラグ = 'False' THEN '  ' ELSE '×' END AS 表示")
                builSQL.Append(" FROM D_担当者")
                builSQL.Append(" WHERE 削除ﾌﾗｸﾞ = 'False'")
                builSQL.Append(" ORDER BY 表示順,担当者番号")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>D_担当者登録</summary>
        ''' <param name="v_param">SQLパラメータ：@担当者番号/@担当者名/@表示順/@削除フラグ/@登録日/@更新日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 担当者追加(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO D_担当者(")
                builSQL.Append(" 担当者番号")
                builSQL.Append(" ,担当者名")
                builSQL.Append(" ,表示順")
                builSQL.Append(" ,削除フラグ")
                builSQL.Append(" ,登録日")
                builSQL.Append(" ,更新日)")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @担当者番号,")
                builSQL.Append(" @担当者名,")
                builSQL.Append(" @表示順,")
                builSQL.Append(" @削除フラグ,@登録日,@更新日)")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("INSERT INTO basis_staff(")
                builSQL.Append(" shop_code")
                builSQL.Append(" ,code")         '担当者番号
                builSQL.Append(" ,name")        '担当者名
                builSQL.Append(" ,display_order")   '表示順
                builSQL.Append(" ,delete_flag")     '削除フラグ
                builSQL.Append(" ,insert_date")     '登録日
                builSQL.Append(" ,update_date)")    '更新日

                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@担当者番号")) & ",")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@担当者名")) & ",")
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

        ''' <summary>D_担当者更新</summary>
        ''' <param name="v_param">SQLパラメータ：@担当者/@表示順/@削除フラグ/@更新日/@担当者番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 担当者更新(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0

            Try
                builSQL.Append("UPDATE D_担当者 SET 担当者名 = @担当者名,")
                builSQL.Append(" 表示順 = @表示順,")
                builSQL.Append(" 削除フラグ = @削除フラグ,")
                builSQL.Append(" 更新日 = @更新日")
                builSQL.Append(" WHERE 担当者番号 = @担当者番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE basis_staff SET name =" & VbSQLNStr(v_param.GetValue("@担当者名")) & ",")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue("@表示順")) & ",")
                builSQL.Append(" delete_flag =" & VbSQLStr(v_param.GetValue("@削除フラグ")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@担当者番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                ''例外時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>D_担当者の有効レコード数取得</summary>
        ''' <returns>レコード数</returns>
        ''' <remarks></remarks>
        Protected Friend Function 担当者削除フラグチェック() As DataTable
            Dim dt As New DataTable
            Dim str_sql As String

            Try
                str_sql = "SELECT COUNT(削除フラグ) AS 表示件数 FROM D_担当者 WHERE (削除フラグ = 'False')"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                ''例外時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>担当者番号レコード存在チェック</summary>
        ''' <param name="v_param">SQLパラメータ：@担当者番号</param>
        ''' <returns>担当者番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_number(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = " SELECT 担当者番号 FROM D_担当者 WHERE 担当者番号 = @担当者番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>担当者名レコード存在チェック</summary>
        ''' <param name="v_param">SQLパラメータ：@担当者名</param>
        ''' <returns>担当者名</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_name(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = " SELECT 担当者名 FROM D_担当者 WHERE 担当者名 = @担当者名"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>D_担当者の最大番号取得</summary>
        ''' <returns>最大番号情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function 担当者_最大番号取得() As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT MAX(担当者番号) AS 最大番号 FROM D_担当者"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace

