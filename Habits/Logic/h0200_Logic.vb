#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>データ抽出（確認）画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class h0200_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "h0200_確認"

        ''' <summary>W_出力対象更新</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Function 選択変更(ByVal outputFlag As Boolean, ByVal customer As String) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Dim param As New Habits.DB.DBParameter
            Try
                param.Add("@選択", outputFlag)
                param.Add("@顧客番号", customer)
                builSQL.Append("UPDATE W_顧客抽出 SET 選択 = @選択")
                If Not String.IsNullOrEmpty(customer) AndAlso customer <> "" Then
                    builSQL.Append(" WHERE 顧客番号 = @顧客番号")
                End If
                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>出力対象一覧取得</summary>
        ''' <returns>出力対象リスト</returns>
        ''' <remarks></remarks>
        Function Q_h0200_出力対象一覧() As DataTable
            Dim rtn As DataTable
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Try
                builSQL.Append("SELECT")
                builSQL.Append(" 選択")
                builSQL.Append(" ,顧客番号")
                builSQL.Append(" ,姓")
                builSQL.Append(" ,名")
                builSQL.Append(" ,姓カナ")
                builSQL.Append(" ,名カナ")
                builSQL.Append(" ,case 性別番号 when 1 then '女' else '男' end AS 性別")
                builSQL.Append(" ,[住所1]")
                builSQL.Append(" ,ISNULL ( [住所2], '') + ISNULL ( [住所3], '') AS 住所2")
                builSQL.Append(" ,D_担当者.担当者名 AS 最終担当者")
                builSQL.Append(" FROM W_顧客抽出")
                builSQL.Append(" LEFT OUTER JOIN D_担当者")
                builSQL.Append(" ON W_顧客抽出.主担当者番号 = D_担当者.担当者番号")
                builSQL.Append(" ORDER BY 姓カナ,名カナ,顧客番号 ASC")
                str_sql = builSQL.ToString
                rtn = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>データ抽出出力パスの取得</summary>
        ''' <returns>データ抽出出力パス</returns>
        ''' <remarks>Excel出力先のデフォルトフォルダを取得する</remarks>
        Protected Friend Function select_ASY() As String
            Dim rtn As String
            rtn = getPath(2)
            Return rtn
        End Function

        ''' <summary>データ抽出出力パスの更新</summary>
        ''' <param name="v_param">SQLパラメータ：@データ抽出出力パス名/@変更日時</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks>Excel出力先のデフォルトフォルダを更新する</remarks>
        Protected Friend Function update_ASY(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Try
                str_sql = "UPDATE A_システム SET データ抽出出力パス名 = @データ抽出出力パス名 , 変更日時 = @変更日時"
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                str_sql = "UPDATE system SET data_output_path=" & VbSQLNStr(v_param.GetValue("@データ抽出出力パス名")) & _
                        ", update_date = " & VbSQLStr(v_param.GetValue("@変更日時")) & _
                        " WHERE shop_code=" & VbSQLNStr(sShopcode)
                InsertZSqlExecHis(PAGE_TITLE, str_sql)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>出力対象一覧取得</summary>
        ''' <returns>出力対象リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_W出力対象() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT")
                builSQL.Append(" 顧客番号")
                builSQL.Append(" ,姓")
                builSQL.Append(" ,名")
                builSQL.Append(" ,姓カナ")
                builSQL.Append(" ,名カナ")
                builSQL.Append(" ,case 性別番号 when 1 then '女' else '男' end AS 性別")
                builSQL.Append(" ,郵便番号")
                builSQL.Append(" ,都道府県")
                builSQL.Append(" ,住所1")
                builSQL.Append(" ,ISNULL(住所2, '') + ' ' + ISNULL(住所3, '') AS 住所2")
                builSQL.Append(" ,電話番号")
                builSQL.Append(" ,D_担当者.担当者名 AS 最終担当者")
                builSQL.Append(" ,CONVERT(char,前回来店日,111) AS 最終来店日")
                builSQL.Append(" ,来店回数")
                builSQL.Append(" ,CONVERT(char,生年月日,111) AS 生年月日")
                builSQL.Append(" ,Emailアドレス")
                builSQL.Append(" ,B_売上区分.売上区分")
                builSQL.Append(" ,区分合計金額")
                builSQL.Append(" FROM W_顧客抽出")
                builSQL.Append(" LEFT JOIN D_担当者 ON 主担当者番号 = D_担当者.担当者番号")
                builSQL.Append(" LEFT OUTER JOIN B_売上区分 ON W_顧客抽出.売上区分番号 = B_売上区分.売上区分番号")
                builSQL.Append(" WHERE 選択 = 'True'")
                builSQL.Append(" ORDER BY 姓カナ ASC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

    End Class
End Namespace

