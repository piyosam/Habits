#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>営業日画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class d0200_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "d0200_営業日"

        ''' <summary>Q_d0200_営業日一覧を取得</summary>
        ''' <param name="v_param">SQLパラメータ：@半年前</param>
        ''' <returns>営業日リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_d0200_営業日一覧(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT E_営業日.営業日,")
                builSQL.Append(" 営業日 AS 日付,")
                builSQL.Append(" B_天候.天候,")
                builSQL.Append(" RIGHT(Space(4) + スタッフ数,4) + '人　' AS ｽﾀｯﾌ数,")
                builSQL.Append(" レジ金額 AS ﾚｼﾞ金額")
                builSQL.Append(" FROM E_営業日")
                builSQL.Append(" INNER JOIN B_天候")
                builSQL.Append(" ON E_営業日.天候番号=B_天候.天候番号")
                builSQL.Append(" WHERE E_営業日.営業日 >= @半年前")
                builSQL.Append(" ORDER BY E_営業日.営業日 DESC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>E_営業日取得</summary>
        ''' <param name="v_param">SQLパラメータ：@営業日</param>
        ''' <returns>営業日情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_営業日取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.E_営業日(v_param)
        End Function

        ''' <summary>B_天候取得</summary>
        ''' <returns>天候リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function B_天候取得() As DataTable
            Return MyBase.B_天候()
        End Function

        ''' <summary>E_営業日更新</summary>
        ''' <param name="v_param">SQLパラメータ：@天候番号,@スタッフ数,@レジ金額,@更新日,@営業日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_営業日更新(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                ''SQL文生成
                builSQL.Append("UPDATE E_営業日")
                builSQL.Append(" SET 天候番号=@天候番号")
                builSQL.Append(" ,スタッフ数=@スタッフ数")
                builSQL.Append(" ,レジ金額=@レジ金額")
                builSQL.Append(" ,更新日=@更新日")
                builSQL.Append(" WHERE 営業日=@営業日")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE business_day")
                builSQL.Append(" SET weather_code=" & VbSQLStr(v_param.GetValue("@天候番号")))
                builSQL.Append(" ,staff_count=" & VbSQLStr(v_param.GetValue("@スタッフ数")))
                builSQL.Append(" ,cash_of_register=" & VbSQLStr(v_param.GetValue("@レジ金額")))
                builSQL.Append(" ,update_date=" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE date=" & VbSQLStr(v_param.GetValue("@営業日")))
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
    End Class
End Namespace
