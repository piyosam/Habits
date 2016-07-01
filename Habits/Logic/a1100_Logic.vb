#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic

    ''' <summary>目標額画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a1100_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1100_目標額"

#Region "B_売上区分取得"
        ''' <summary>B_売上区分取得</summary>
        ''' <returns>売上区分リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function 売上区分Plus_E_目標額(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Try

                builSQL.Append("SELECT 売上区分番号")
                builSQL.Append(" ,売上区分")
                builSQL.Append(" ,表示順")
                builSQL.Append(" FROM B_売上区分")
                builSQL.Append(" WHERE 削除フラグ = 'false'")

                builSQL.Append(" UNION SELECT E_目標額.売上区分番号")
                builSQL.Append(" ,B_売上区分.売上区分")
                builSQL.Append(" ,B_売上区分.表示順")
                builSQL.Append(" FROM E_目標額")
                builSQL.Append(" LEFT OUTER JOIN B_売上区分")
                builSQL.Append(" ON E_目標額.売上区分番号 = B_売上区分.売上区分番号")
                builSQL.Append(" WHERE E_目標額.対象年月>=@過去年月")

                builSQL.Append(" ORDER BY 表示順,売上区分番号")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "B_売上区分取得"
        ''' <summary>E_目標額取得</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@対象年月</param>
        ''' <returns>目標額</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_目標額取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 売上区分番号,対象年月,目標額,営業日数,更新日 FROM E_目標額 WHERE 売上区分番号=@売上区分番号 AND 対象年月=@対象年月"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "目標一覧取得"
        ''' <summary>目標一覧データの取得</summary>
        ''' <param name="v_param">SQLパラメータ：@過去年月</param>
        ''' <returns>目標額情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function 目標一覧取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT E_目標額.対象年月,")
                builSQL.Append(" E_目標額.売上区分番号,")
                builSQL.Append(" B_売上区分.売上区分,")
                builSQL.Append(" E_目標額.目標額,")
                builSQL.Append(" E_目標額.営業日数 AS 日数")
                builSQL.Append(" FROM E_目標額 LEFT JOIN B_売上区分 ON E_目標額.売上区分番号 = B_売上区分.売上区分番号")
                builSQL.Append(" WHERE E_目標額.対象年月>=@過去年月")
                builSQL.Append(" ORDER BY E_目標額.対象年月 DESC, B_売上区分.表示順,E_目標額.売上区分番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "E_目標額テーブル更新"
        ''' <summary>E_目標額テーブル更新</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_目標額更新(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("UPDATE E_目標額 SET")
                builSQL.Append(" 売上区分番号=@売上区分番号,")
                builSQL.Append(" 対象年月=@対象年月,")
                builSQL.Append(" 目標額=@目標額,")
                builSQL.Append(" 営業日数=@営業日数,")
                builSQL.Append(" 更新日=@更新日")
                builSQL.Append(" WHERE 売上区分番号=@売上区分番号")
                builSQL.Append(" AND 対象年月=@対象年月")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 UPDATE
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE target_figure SET")
                builSQL.Append(" sales_division_code=" & VbSQLStr(v_param.GetValue("@売上区分番号")) & ",")
                builSQL.Append(" ym=" & VbSQLStr(v_param.GetValue("@対象年月")) & ",")
                builSQL.Append(" amount=" & VbSQLStr(v_param.GetValue("@目標額")) & ",")
                builSQL.Append(" days=" & VbSQLStr(v_param.GetValue("@営業日数")) & ",")
                builSQL.Append(" update_date=" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE sales_division_code=" & VbSQLStr(v_param.GetValue("@売上区分番号")))
                builSQL.Append(" AND ym=" & VbSQLStr(v_param.GetValue("@対象年月")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Function
#End Region

#Region "E_目標額テーブル追加"
        ''' <summary>E_目標額テーブル追加</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@対象年月/@目標額/@営業日数/@更新日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_目標額追加(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO E_目標額")
                builSQL.Append(" (売上区分番号,")
                builSQL.Append(" 対象年月,")
                builSQL.Append(" 目標額,")
                builSQL.Append(" 営業日数,")
                builSQL.Append(" 更新日)")
                builSQL.Append(" VALUES")
                builSQL.Append(" (@売上区分番号,")
                builSQL.Append(" @対象年月,")
                builSQL.Append(" @目標額,")
                builSQL.Append(" @営業日数,")
                builSQL.Append(" @更新日)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("INSERT INTO target_figure")
                builSQL.Append(" (shop_code,")
                builSQL.Append(" sales_division_code,")
                builSQL.Append(" ym,")
                builSQL.Append(" amount,")
                builSQL.Append(" days,")
                builSQL.Append(" update_date")
                builSQL.Append(" ) VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@売上区分番号")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@対象年月")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@目標額")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@営業日数")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@更新日")) & ")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Function
#End Region

    End Class
End Namespace
