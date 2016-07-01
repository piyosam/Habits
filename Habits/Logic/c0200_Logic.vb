#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>売上入力画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Class c0200_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "c0200_売上入力"

#Region "最大売上番号取得"
        ''' <summary>最大売上番号を取得</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>売上番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function get次売上番号(ByVal v_param As Habits.DB.DBParameter) As String
            Dim rtn As String = "1"
            Dim obj As New Object
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT MAX(売上番号) + 1  AS 売上番号")
                builSQL.Append(" FROM E_売上明細")
                builSQL.Append(" WHERE 来店日=@来店日")
                builSQL.Append(" AND 来店者番号=@来店者番号")
                builSQL.Append(" AND 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                obj = DBA.ExecuteScalar(str_sql, v_param)
                If Not IsDBNull(obj) Then
                    rtn = obj.ToString
                End If
            Catch ex As Exception
                'ログ出力
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("次売上番号の取得に失敗しました。　" & Chr(13) & Chr(13) & _
                "処理を再度行ってください。　", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "売上明細検索"
        ''' <summary>E_売上明細検索</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@顧客番号</param>
        ''' <returns>顧客番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_saleDetails(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 顧客番号 FROM E_売上明細 WHERE 顧客番号 = @顧客番号 AND 来店日 = @来店日 AND 来店者番号 = @来店者番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                'ログ出力
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("売上明細検索に失敗しました。　" & Chr(13) & Chr(13) & _
                "処理を再度行ってください。　", Clng_Okexb1, TTL)
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "売上明細の登録"
        ''' <summary>E_売上明細にデータを登録</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function InSertDataEUM(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                '' E_売上明細にデータを登録
                builSQL.Append("INSERT INTO E_売上明細 (")
                builSQL.Append(" 来店日")
                builSQL.Append(" ,来店者番号")
                builSQL.Append(" ,顧客番号")
                builSQL.Append(" ,売上番号")
                builSQL.Append(" ,売上区分番号")
                builSQL.Append(" ,売上担当者番号")
                builSQL.Append(" ,分類番号")
                builSQL.Append(" ,名称番号")
                builSQL.Append(" ,数量")
                builSQL.Append(" ,金額")
                builSQL.Append(" ,サービス番号")
                builSQL.Append(" ,サービス")
                builSQL.Append(" ,会計済")
                builSQL.Append(" ,更新日")
                builSQL.Append(" ,消費税")

                builSQL.Append(" )VALUES (")
                builSQL.Append(" @来店日")
                builSQL.Append(" ,@来店者番号")
                builSQL.Append(" ,@顧客番号")
                builSQL.Append(" ,@売上番号")
                builSQL.Append(" ,@売上区分番号")
                builSQL.Append(" ,@売上担当者番号")
                builSQL.Append(" ,@分類番号")
                builSQL.Append(" ,@名称番号")
                builSQL.Append(" ,@数量")
                builSQL.Append(" ,@金額")
                builSQL.Append(" ,@サービス番号")
                builSQL.Append(" ,@サービス")
                builSQL.Append(" ,@会計済")
                builSQL.Append(" ,@更新日")
                builSQL.Append(" ,@消費税)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("INSERT INTO sales_details (")
                builSQL.Append(" shop_code")
                builSQL.Append(" ,visit_date")
                builSQL.Append(" ,visit_number")
                builSQL.Append(" ,basis_customer_code")
                builSQL.Append(" ,code")
                builSQL.Append(" ,sales_division_code")
                builSQL.Append(" ,sales_staff_code")
                builSQL.Append(" ,class_code")
                builSQL.Append(" ,goods_code")
                builSQL.Append(" ,count")
                builSQL.Append(" ,amount")
                builSQL.Append(" ,service_code")
                builSQL.Append(" ,service_amount")
                builSQL.Append(" ,paid_flag")
                builSQL.Append(" ,update_date")
                builSQL.Append(" ,tax")
                builSQL.Append(" )VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@売上番号")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@売上区分番号")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@売上担当者番号")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@分類番号")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@名称番号")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@数量")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@金額")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@サービス番号")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@サービス")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@会計済")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" ," & VbSQLStr(v_param.GetValue("@消費税")))
                builSQL.Append(")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                'ログ出力
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("売上明細の登録に失敗しました。　" & Chr(13) & Chr(13) & _
                "処理を再度行ってください。　", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "カルテ有無確認"
        ''' <summary>カルテ有無確認</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>カルテ</returns>
        ''' <remarks></remarks>
        Protected Friend Function chkExistChart(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT カルテ FROM E_カルテ WHERE 来店日 = @来店日 AND 顧客番号 = @顧客番号 AND 来店者番号 = @来店者番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                'ログ出力
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("カルテ情報有無確認に失敗しました。　" & Chr(13) & Chr(13) & _
                "処理を再度行ってください。　", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return dt
        End Function
#End Region

    End Class
End Namespace