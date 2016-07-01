#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>スタッフ選択画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a0800_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a0800_スタッフ選択"

#Region "総スタッフ登録（当日初回時）"
        ''' <summary>総スタッフ登録（当日初回時）</summary>
        ''' <param name="v_param">SQLパラメータ：@削除フラグ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks>W_担当者テーブルにD_担当者の削除フラグがFalseのデータを全インサート</remarks>
        Protected Friend Function insert_W_担当者(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("INSERT INTO W_担当者")
                builSQL.Append(" SELECT *")
                builSQL.Append(" FROM D_担当者")
                builSQL.Append(" WHERE 削除フラグ = @削除フラグ")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "総スタッフ登録（再設定）"
        ''' <summary>総スタッフ登録（再設定）</summary>
        ''' <param name="v_param">SQLパラメータ：@削除フラグ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks>W_担当者テーブルにW_スタッフに存在しないD_担当者の削除フラグがFalseのデータを全インサート</remarks>
        Protected Friend Function insert_W_担当者_again(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("INSERT INTO W_担当者")
                builSQL.Append(" SELECT * FROM D_担当者")
                builSQL.Append(" WHERE 担当者番号 NOT IN")
                builSQL.Append(" (SELECT 担当者番号 FROM W_スタッフ)")
                builSQL.Append(" AND 削除フラグ= @削除フラグ")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "出勤スタッフ登録（全件）"
        ''' <summary>出勤スタッフ登録</summary>
        ''' <param name="v_param">SQLパラメータ：@削除フラグ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks>W_スタッフテーブルにD_担当者の削除フラグがFalseのデータを全インサート</remarks>
        Protected Friend Function insert_W_スタッフ(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("INSERT INTO W_スタッフ")
                builSQL.Append(" SELECT *")
                builSQL.Append(" FROM D_担当者")
                builSQL.Append(" WHERE 削除フラグ = @削除フラグ")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "総スタッフ削除（全件）"
        ''' <summary>W_担当者削除（全件）</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_W_担当者() As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "DELETE FROM W_担当者"
                rtn = DBA.ExecuteNonQuery(str_sql)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "出勤スタッフ削除（全件）"
        ''' <summary>W_スタッフ削除（全件）</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_W_スタッフ() As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "DELETE FROM W_スタッフ"
                rtn = DBA.ExecuteNonQuery(str_sql)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "総スタッフ一覧取得"
        ''' <summary>W_担当者取得</summary>
        ''' <returns>担当者リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_W_担当者() As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT 担当者番号,担当者名,表示順,削除フラグ,登録日,更新日 FROM W_担当者 ORDER BY 表示順,担当者番号"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "出勤スタッフ一覧取得"
        ''' <summary>出勤スタッフ一覧取得</summary>
        ''' <returns>スタッフリスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_W_スタッフ() As DataTable
            Return MyBase.W_スタッフ()
        End Function
#End Region

#Region "総スタッフ削除（担当者）"
        ''' <summary>W_担当者削除</summary>
        ''' <param name="v_param">SQLパラメータ:@担当者番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_part_W_担当者(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "DELETE FROM W_担当者 WHERE 担当者番号 = @担当者番号"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "出勤スタッフ削除（担当者）"
        ''' <summary>W_スタッフ削除（担当者）</summary>
        ''' <param name="v_param">SQLパラメータ:@担当者番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_part_W_スタッフ(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "DELETE FROM W_スタッフ WHERE 担当者番号 = @担当者番号"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "総スタッフ登録（担当者）"
        ''' <summary>総スタッフ登録（担当者）</summary>
        ''' <param name="v_param">SQLパラメータ:@担当者番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_part_W_担当者(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "INSERT INTO W_担当者 SELECT * FROM W_スタッフ WHERE 担当者番号 = @担当者番号"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "出勤スタッフ登録（担当者）"
        ''' <summary>W_スタッフ登録（）</summary>
        ''' <param name="v_param">SQLパラメータ:@担当者番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_part_W_スタッフ(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                str_sql = "INSERT INTO W_スタッフ SELECT * FROM W_担当者 WHERE 担当者番号 = @担当者番号"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "営業日情報更新"
        ''' <summary>営業日情報更新</summary>
        ''' <param name="v_param">SQLパラメータ:@スタッフ数/@更新日/@営業日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_営業日更新(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String

            Try
                ' トランザクション開始
                DBA.TransactionStart()
                str_sql = "UPDATE E_営業日 SET スタッフ数=@スタッフ数,更新日=@更新日 WHERE 営業日=@営業日"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                Dim builSQL As New StringBuilder()
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE business_day SET")
                builSQL.Append(" staff_count=" & VbSQLStr(v_param.GetValue("@スタッフ数")))      'スタッフ数     (smallint)
                builSQL.Append(", update_date=" & VbSQLStr(v_param.GetValue("@更新日")))         '更新日         (datetime)
                builSQL.Append(" WHERE date=" & VbSQLStr(v_param.GetValue("@営業日")))           '営業日         (datetime)
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))                        '店舗コード     (varchar)
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "有効な担当者情報取得"
        ''' <summary>有効な担当者情報取得</summary>
        ''' <returns>担当者情報リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_D_担当者() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function
#End Region

#Region "営業日取得"
        ''' <summary>営業日取得</summary>
        ''' <returns>担当者情報リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_E_営業日(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.E_営業日(v_param)
        End Function
#End Region
    End Class
End Namespace