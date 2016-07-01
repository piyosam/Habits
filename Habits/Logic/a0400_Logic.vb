#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>作業時間設定（施術時間）画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a0400_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a0400_作業時間設定"

        ''' <summary>作業時間情報更新</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_a0400_作業時間設定(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                '------------------------------
                'E_来店者 UPDATE
                '------------------------------
                builSQL.Append("UPDATE E_来店者 ")
                builSQL.Append(" SET 作業開始 = @作業開始, 作業終了 = @作業終了, 更新日 = @更新日")
                builSQL.Append(" WHERE 来店日 = @来店日")
                builSQL.Append(" AND 来店者番号 = @来店者番号")
                builSQL.Append(" AND 顧客番号 = @顧客番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE visit SET")
                builSQL.Append(" start_date=" & VbSQLStr(v_param.GetValue("@作業開始")))     '作業開始       (datetime)
                builSQL.Append(",end_date=" & VbSQLStr(v_param.GetValue("@作業終了")))       '作業終了       (datetime)
                builSQL.Append(",update_date=" & VbSQLStr(v_param.GetValue("@更新日")))      '更新日         (datetime)
                builSQL.Append(" WHERE date=" & VbSQLStr(v_param.GetValue("@来店日")))       '来店日         (datetime)
                builSQL.Append(" AND number=" & VbSQLStr(v_param.GetValue("@来店者番号")))   '来店番号       (smallint)
                builSQL.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@顧客番号")))  '顧客番号       (int)
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))                        '店舗コード     (varchar)
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                DBA.TransactionCommit()
            Catch ex As Exception
                ''例外時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
    End Class
End Namespace