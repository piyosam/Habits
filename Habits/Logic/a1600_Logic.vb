#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>発注画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a1600_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1600_発注画面"

        ''' <summary>発注の必要があるもの一覧取得</summary>
        ''' <returns>発注必要商品リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function 発注一覧() As DataTable
            Dim dt As DataTable
            Dim rtn As DataTable = New DataTable()
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim amount As Integer

            Try
                builSQL.Append("SELECT DISTINCT")
                builSQL.Append(" C_商品.売上区分番号 AS 売上区分番号")
                builSQL.Append(" ,C_商品.分類番号 AS 分類番号")
                builSQL.Append(" ,C_分類.分類名 AS 分類名")
                builSQL.Append(" ,C_商品.商品番号 AS 商品番号")
                builSQL.Append(" ,C_商品.商品名 AS 商品名")
                builSQL.Append(" ,C_メーカー.メーカー名 AS メーカー名")
                builSQL.Append(" ,C_商品.金額管理区分 AS 金額管理区分")
                builSQL.Append(" ,C_商品.仕入金額 AS 仕入金額")
                builSQL.Append(" ,C_商品.販売金額 AS 販売金額")
                builSQL.Append(" ,C_商品.在庫数 AS 在庫数")
                builSQL.Append(" ,C_商品.発注点 AS 発注点")
                builSQL.Append(" ,C_商品.規定在庫数 AS 既定在庫数")
                builSQL.Append(" ,(C_商品.規定在庫数 - C_商品.在庫数) AS 目安発注数")
                builSQL.Append(" FROM  ((C_商品")
                builSQL.Append(" JOIN C_分類 ON C_分類.分類番号 = C_商品.分類番号 AND C_分類.売上区分番号 = C_商品.売上区分番号)")
                builSQL.Append(" JOIN C_メーカー ON C_商品.メーカー番号 = C_メーカー.メーカー番号)")
                builSQL.Append(" WHERE C_商品.発注点 >= C_商品.在庫数")
                builSQL.Append(" AND C_分類.店販対象フラグ = 'true'")
                builSQL.Append(" AND (C_商品.規定在庫数 - C_商品.在庫数)<>0;")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)

                'テーブルインスタンス作成
                rtn.Columns.Add("売上区分番号", Type.GetType("System.Int64"))
                rtn.Columns.Add("分類番号", Type.GetType("System.Int64"))
                rtn.Columns.Add("分類名", Type.GetType("System.String"))
                rtn.Columns.Add("商品番号", Type.GetType("System.Int64"))
                rtn.Columns.Add("商品名", Type.GetType("System.String"))
                rtn.Columns.Add("メーカー名", Type.GetType("System.String"))
                rtn.Columns.Add("仕入金額", Type.GetType("System.Int64"))
                rtn.Columns.Add("販売金額", Type.GetType("System.Int64"))
                rtn.Columns.Add("在庫数", Type.GetType("System.Int64"))
                rtn.Columns.Add("発注点", Type.GetType("System.Int64"))
                rtn.Columns.Add("既定在庫数", Type.GetType("System.Int64"))
                rtn.Columns.Add("目安発注数", Type.GetType("System.Int64"))

                For Each dr As DataRow In dt.Rows
                    Dim newRow As DataRow = rtn.NewRow()
                    rtn.Rows.Add(newRow)
                    newRow("売上区分番号") = dr.Item("売上区分番号")
                    newRow("分類番号") = dr.Item("分類番号")
                    newRow("分類名") = dr.Item("分類名")
                    newRow("商品番号") = dr.Item("商品番号")
                    newRow("商品名") = dr.Item("商品名")
                    newRow("メーカー名") = dr.Item("メーカー名")

                    If Integer.Parse(dr.Item("金額管理区分")) = 1 Then
                        amount = Integer.Parse(dr.Item("仕入金額").ToString())
                        newRow("仕入金額") = amount + Sys_Tax(amount, USER_DATE, 0)
                        amount = Integer.Parse(dr.Item("販売金額").ToString())
                        newRow("販売金額") = amount + Sys_Tax(amount, USER_DATE, 0)
                    Else
                        newRow("仕入金額") = dr.Item("仕入金額")
                        newRow("販売金額") = dr.Item("販売金額")
                    End If
                    newRow("在庫数") = dr.Item("在庫数")
                    newRow("発注点") = dr.Item("発注点")
                    newRow("既定在庫数") = dr.Item("既定在庫数")
                    newRow("目安発注数") = dr.Item("目安発注数")
                Next

                Return rtn
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>発注出力パス取得</summary>
        ''' <returns>発注出力パス</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_ASY() As String
            Dim rtn As String = Nothing
            rtn = getPath(1)
            Return rtn
        End Function

        ''' <summary>発注出力パス取得</summary>
        ''' <param name="v_param">SQLパラメータ：@発注出力パス名/@変更日時</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_ASY(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim dt As Integer
            Dim str_sql As String
            Try
                str_sql = "UPDATE A_システム SET 発注出力パス名 = @発注出力パス名 , 変更日時 = @変更日時"
                dt = DBA.ExecuteNonQuery(str_sql, v_param)

                str_sql = "UPDATE system SET order_output_path=" & VbSQLNStr(v_param.GetValue("@発注出力パス名")) & _
                        ", update_date = " & VbSQLStr(v_param.GetValue("@変更日時")) & " WHERE shop_code=" & VbSQLNStr(sShopcode)
                rtn = InsertZSqlExecHis(PAGE_TITLE, str_sql)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function
    End Class
End Namespace