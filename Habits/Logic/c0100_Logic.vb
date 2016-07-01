#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>売上画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class c0100_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "c0100_売上"

#Region "売上情報取得"
        ''' <summary>売上情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>売上情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSales(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT E_売上.来店日")
                builSQL.Append(" ,E_売上.来店者番号")
                builSQL.Append(" ,E_売上.顧客番号")
                builSQL.Append(" ,E_売上.性別番号")
                builSQL.Append(" ,E_売上.年齢")
                builSQL.Append(" ,E_売上.主担当者番号")
                builSQL.Append(" ,E_売上.来店区分番号")
                builSQL.Append(" ,E_売上.指名")
                builSQL.Append(" ,E_売上.カード支払")
                builSQL.Append(" ,E_売上.カード会社番号")
                builSQL.Append(" ,E_売上.現金支払")
                builSQL.Append(" ,E_売上.お預り")
                builSQL.Append(" ,E_売上.消費税")
                builSQL.Append(" ,E_売上.その他支払")
                builSQL.Append(" ,E_売上.ポイント割引番号")
                builSQL.Append(" ,E_売上.ポイント割引支払")
                builSQL.Append(" ,E_来店者.サービス番号")
                builSQL.Append(" ,E_来店者.サービス区分")
                builSQL.Append(" ,E_来店者.サービス金額")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" LEFT OUTER JOIN E_来店者")
                builSQL.Append(" ON E_来店者.来店日=E_売上.来店日")
                builSQL.Append(" AND E_来店者.来店者番号=E_売上.来店者番号")
                builSQL.Append(" AND E_来店者.顧客番号=E_売上.顧客番号")
                builSQL.Append(" WHERE E_売上.顧客番号=@顧客番号")
                builSQL.Append(" AND E_売上.来店日=@来店日")
                builSQL.Append(" AND E_売上.来店者番号=@来店者番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                '’例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "ログ出力用売上情報取得"
        ''' <summary>売上情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>売上情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSalesInfoForLog(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT CONVERT(varchar, E_来店者.来店日,111),E_来店者.来店者番号,E_来店者.顧客番号")
                builSQL.Append(" ,姓 +' '+名 AS 顧客名,担当者名 AS 主担当者名,ISNULL(売上,0)")
                builSQL.Append(" FROM (SELECT 来店日,来店者番号,顧客番号,SUM(数量 * 金額 - サービス) AS 売上")
                builSQL.Append("  FROM E_売上明細")
                builSQL.Append("  WHERE 顧客番号=@顧客番号 AND 来店日=@来店日 AND 来店者番号=@来店者番号")
                builSQL.Append("  GROUP BY 来店日,来店者番号,顧客番号")
                builSQL.Append(" ) AS SALES")
                builSQL.Append(" RIGHT OUTER JOIN E_来店者")
                builSQL.Append("  ON SALES.来店日= E_来店者.来店日")
                builSQL.Append("  AND SALES.来店者番号= E_来店者.来店者番号")
                builSQL.Append(" LEFT OUTER JOIN D_担当者")
                builSQL.Append("  ON D_担当者.担当者番号= E_来店者.主担当者番号")
                builSQL.Append(" WHERE E_来店者.顧客番号=@顧客番号 AND E_来店者.来店日=@来店日 AND E_来店者.来店者番号=@来店者番号")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                '’例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "リストデータ取得"

#Region "来店区分リスト取得"
        '''<summary>来店区分リスト取得</summary>
        ''' <returns>来店区分リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function getVisitDiv() As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 来店区分番号,来店区分 FROM B_来店区分 ORDER BY 来店区分番号"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "売上区分リスト取得"
        '''<summary>売上区分リスト取得</summary>
        ''' <returns>有効な売上区分リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSalesDivList() As DataTable
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                str_sql = "SELECT 売上区分番号,売上区分 FROM B_売上区分 WHERE 削除フラグ = 'False' ORDER BY 表示順,売上区分番号"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "メーカーリスト取得"
        ''' <summary>メーカー一覧取得</summary>
        ''' <returns>メーカーリスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function getMakerList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT メーカー番号,メーカー名")
                builSQL.Append(" FROM C_メーカー")
                builSQL.Append(" WHERE メーカー番号 IN ")
                builSQL.Append(" (SELECT DISTINCT メーカー番号")
                builSQL.Append(" FROM C_商品")
                builSQL.Append(" WHERE 売上区分番号 = @売上区分番号")
                builSQL.Append(" AND 分類番号 = @分類番号")
                builSQL.Append(" AND 削除フラグ = 'False')")
                builSQL.Append(" ORDER BY 表示順")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "商品リスト取得"
        ''' <summary>商品リスト取得</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号/@メーカー番号</param>
        ''' <returns>商品販売金額リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function getGoods(ByVal v_param As Habits.DB.DBParameter, ByVal makerFlag As Boolean) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT 商品番号,商品名,販売金額,金額管理区分")
                builSQL.Append(" FROM C_商品")
                builSQL.Append(" WHERE (売上区分番号 = @売上区分番号)")
                builSQL.Append(" AND (分類番号 = @分類番号)")
                If (makerFlag) Then
                    builSQL.Append(" AND (メーカー番号 = @メーカー番号)")
                End If
                builSQL.Append(" AND (削除フラグ='False')")
                builSQL.Append(" ORDER BY 表示順,商品番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#End Region

#Region "データ更新"

#Region "顧客データ更新"
        ''' <summary>D_顧客データ更新</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function D_顧客データ更新(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                '' D_顧客にデータを更新
                builSQL.Append("UPDATE D_顧客")
                builSQL.Append(" SET 性別番号=@性別番号,主担当者番号=@主担当者番号,更新日=@更新日")
                builSQL.Append(" WHERE 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE basis_customer")
                builSQL.Append(" SET gender_code=" & VbSQLStr(v_param.GetValue("@性別番号")))
                builSQL.Append(",main_staff_code=" & VbSQLStr(v_param.GetValue("@主担当者番号")))
                builSQL.Append(",update_date=" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "来店者データ更新（画面のデータ保持）"
        ''' <summary>来店者データ更新（画面のデータ保持）</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks>売上情報登録時、画面の値をE_来店者に設定する</remarks>
        Protected Friend Function E_来店者データ保持(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                '' E_来店者にデータを登録
                builSQL.Append("UPDATE E_来店者")
                builSQL.Append(" SET 主担当者番号=@主担当者番号")
                builSQL.Append(" ,指名=@指名,更新日=@更新日")
                builSQL.Append(" ,ポイント割引番号=@ポイント割引番号")
                builSQL.Append(" ,ポイント割引支払=@ポイント割引支払")
                builSQL.Append(" ,サービス番号=@サービス番号")
                builSQL.Append(" ,サービス区分=@サービス区分")
                builSQL.Append(" ,サービス金額=@サービス金額")
                builSQL.Append(" WHERE 顧客番号=@顧客番号")
                builSQL.Append("  AND 来店者番号=@来店者番号")
                builSQL.Append("  AND 来店日=@来店日")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE visit")
                builSQL.Append(" SET main_staff_code=" & VbSQLStr(v_param.GetValue("@主担当者番号")))
                builSQL.Append(",designated_flag=" & VbSQLStr(v_param.GetValue("@指名")))
                builSQL.Append(",update_date=" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(",point_purchases_code=" & VbSQLStr(v_param.GetValue("@ポイント割引番号")))
                builSQL.Append(",point_purchases=" & VbSQLStr(v_param.GetValue("@ポイント割引支払")))
                builSQL.Append(",service_code=" & VbSQLStr(v_param.GetValue("@サービス番号")))
                builSQL.Append(",service_type=" & VbSQLStr(v_param.GetValue("@サービス区分")))
                builSQL.Append(",service_amount=" & VbSQLStr(v_param.GetValue("@サービス金額")))
                builSQL.Append(" WHERE basis_customer_code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND number=" & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append(" AND date=" & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "売上明細削除"
        '''<summary>E_売上明細とE_ポイントの削除</summary>
        ''' <param name="v_param">@売上番号/@来店日/@来店者番号/@顧客番号/@担当者番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 売上明細削除(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                'E_売上明細削除
                builSQL.Length = 0
                builSQL.Append("DELETE FROM E_売上明細")
                builSQL.Append(" WHERE 売上番号=@売上番号")
                builSQL.Append(" AND 来店日=@来店日")
                builSQL.Append(" AND 来店者番号=@来店者番号")
                builSQL.Append(" AND 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("DELETE FROM sales_details")
                builSQL.Append(" WHERE code=" & VbSQLStr(v_param.GetValue("@売上番号")))
                builSQL.Append(" AND visit_date=" & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append(" AND visit_number=" & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                'E_ポイント削除
                ポイント削除(v_param, PAGE_TITLE)

            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#End Region

#Region "売上明細取得"
        ''' <summary>E_売上明細取得</summary>
        ''' <param name="v_param">@売上番号/@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>売上明細</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_売上明細取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT * FROM E_売上明細")
                builSQL.Append(" WHERE 売上番号=@売上番号")
                builSQL.Append(" AND 来店日=@来店日")
                builSQL.Append(" AND 来店者番号=@来店者番号")
                builSQL.Append(" AND 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

    End Class
End Namespace
