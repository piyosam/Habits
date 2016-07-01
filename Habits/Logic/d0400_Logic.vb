#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>来店者画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class d0400_logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>来店者一覧取得</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>来店者情報リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_customer(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT E_売上.顧客番号")
                builSQL.Append(" ,(E_来店者.姓 + '  ' + ISNULL(E_来店者.名,'')) AS 氏名")
                builSQL.Append(" ,B_性別.性別")
                builSQL.Append(" ,B_来店区分.来店区分")
                builSQL.Append(" ,CASE WHEN E_売上.指名 = 'True' THEN '指名' ELSE '  ' END 指名")
                builSQL.Append(" ,D_担当者.担当者名")
                builSQL.Append(" ,CASE WHEN (E_売上.カード支払>0 OR E_売上.その他支払>0) AND E_売上.ポイント割引支払>0 THEN '現金他 ﾎﾟｲﾝﾄ'")
                builSQL.Append(" WHEN (E_売上.カード支払>0 OR E_売上.その他支払>0) THEN '現金他'")
                builSQL.Append(" WHEN E_売上.ポイント割引支払>0 THEN 'ﾎﾟｲﾝﾄ' END AS 支払")
                builSQL.Append(" ,売上明細.売上 - E_売上.サービス金額 AS 売上金額")
                builSQL.Append(" ,売上明細.サービス + E_売上.サービス金額 AS サービス")
                builSQL.Append(" ,E_売上.消費税 AS 消費税")
                'builSQL.Append(" ,(売上明細.売上+E_売上.消費税) AS 税込")
                builSQL.Append(" ,E_売上.来店者番号")

                builSQL.Append(" FROM E_売上")

                builSQL.Append(" INNER JOIN E_来店者")
                builSQL.Append(" ON E_売上.来店日 = E_来店者.来店日 AND E_売上.来店者番号 = E_来店者.来店者番号")
                builSQL.Append(" AND E_売上.顧客番号 = E_来店者.顧客番号")

                builSQL.Append(" INNER JOIN (SELECT 来店日,来店者番号,顧客番号,SUM(数量 * 金額 - サービス) AS 売上,SUM(サービス) AS サービス")
                builSQL.Append(" FROM E_売上明細 WHERE 来店日 = @終了日 AND 会計済 = 'True' GROUP BY 来店日,来店者番号,顧客番号) AS 売上明細")
                builSQL.Append(" ON E_売上.来店日 = 売上明細.来店日 AND E_売上.来店者番号 = 売上明細.来店者番号 AND E_売上.顧客番号 = 売上明細.顧客番号")

                builSQL.Append(" INNER JOIN B_性別 ON E_売上.性別番号 = B_性別.性別番号")
                builSQL.Append(" INNER JOIN B_来店区分 ON E_売上.来店区分番号 = B_来店区分.来店区分番号")
                builSQL.Append(" INNER JOIN D_担当者 ON E_売上.主担当者番号 = D_担当者.担当者番号")
                builSQL.Append(" INNER JOIN D_顧客 ON E_売上.顧客番号 = D_顧客.顧客番号")

                builSQL.Append(" WHERE E_売上.来店日 = @終了日")
                builSQL.Append(" ORDER BY E_売上.来店者番号 ASC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
    End Class
End Namespace