#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>メモ設定画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class c0500_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "c0500_メモ設定"

        ''' <summary>メモデータ更新</summary>
        ''' <param name="v_param">SQLパラメータ：@更新日/@顧客番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_c0500_メモ(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As Integer
            Try
                builSQL.Append("UPDATE D_顧客")
                builSQL.Append(" SET メモ = @メモ, 伝言フラグ = @伝言フラグ,更新日 = @更新日")
                builSQL.Append(" WHERE 顧客番号 = @顧客番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE basis_customer")
                builSQL.Append(" SET memo =" & VbSQLNStr(v_param.GetValue("@メモ")))
                builSQL.Append(",message_flag =" & VbSQLStr(v_param.GetValue("@伝言フラグ")))
                builSQL.Append(",update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                ''例外時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>メモデータ取得</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>メモ</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_c0500_メモ_Select(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                str_sql = "SELECT D_顧客.メモ FROM D_顧客 WHERE 顧客番号=@顧客番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
    End Class
End Namespace