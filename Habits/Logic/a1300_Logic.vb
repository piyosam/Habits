#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>カルテ画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a1300_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1300_カルテ"

        ''' <summary>カルテ一覧取得</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_day_name(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT 来店日,担当者名 AS 登録スタッフ,カルテ,来店者番号,顧客番号")
                builSQL.Append(" FROM E_カルテ")
                builSQL.Append(" INNER JOIN D_担当者")
                builSQL.Append(" ON E_カルテ.登録者番号 = D_担当者.担当者番号")
                builSQL.Append(" WHERE 顧客番号 = @顧客番号")
                builSQL.Append(" ORDER BY 来店日 DESC,来店者番号 DESC")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>担当者一覧取得</summary>
        ''' <param name="v_param">SQLパラメータ：@削除フラグ</param>
        ''' <returns>担当者リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_name(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append(" SELECT 担当者名, 担当者番号")
                builSQL.Append(" FROM D_担当者")
                builSQL.Append(" WHERE 削除フラグ = @削除フラグ")
                builSQL.Append(" ORDER BY 表示順,担当者番号")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>カルテ情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号/@来店日/@来店者番号</param>
        ''' <returns>カルテ情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function exist_check(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT 来店日,来店者番号,顧客番号,カルテ,登録者番号,登録日時,変更日時")
                builSQL.Append(" FROM E_カルテ")
                builSQL.Append(" WHERE 顧客番号 = @顧客番号")
                builSQL.Append(" AND 来店日 = @来店日")
                builSQL.Append(" AND 来店者番号 = @来店者番号")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>カルテ登録</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_E_カルテ(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append(" INSERT INTO E_カルテ")
                builSQL.Append(" VALUES(@来店日,@来店者番号,@顧客番号,@カルテ,@登録者番号,@登録日時,@変更日時)")
                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append(" INSERT INTO chart")
                builSQL.Append(" (shop_code")
                builSQL.Append(",visit_date")
                builSQL.Append(",visit_number")
                builSQL.Append(",basis_customer_code")
                builSQL.Append(",chart")
                builSQL.Append(",basis_staff_code")
                builSQL.Append(",insert_date")
                builSQL.Append(",update_date")
                builSQL.Append(" ) VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@カルテ")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@登録者番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@登録日時")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@変更日時")))
                builSQL.Append(")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>カルテ更新</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_E_カルテ(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("UPDATE E_カルテ")
                builSQL.Append(" SET 変更日時 =@変更日時, カルテ = @カルテ ")
                builSQL.Append(" WHERE 来店日 = @来店日 ")
                builSQL.Append(" AND 来店者番号 = @来店者番号 ")
                builSQL.Append(" AND 顧客番号 = @顧客番号")
                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 UPDATE
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE chart")
                builSQL.Append(" SET update_date =" & VbSQLStr(v_param.GetValue("@変更日時")))
                builSQL.Append(", chart = " & VbSQLNStr(v_param.GetValue("@カルテ")))
                builSQL.Append(" WHERE visit_date = " & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append(" AND visit_number = " & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append(" AND basis_customer_code = " & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
    End Class
End Namespace