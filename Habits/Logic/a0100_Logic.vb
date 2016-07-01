#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>ロード中ロジッククラス</summary>
    ''' <remarks>マスタダウンロードチェック処理</remarks>
    Public Class a0100_Logic
        Inherits Habits.Logic.LogicBase

        ''' <summary>最終ダウンロード時間取得</summary>
        ''' <returns>M_送受信レコード</returns>
        ''' <remarks></remarks>
        Protected Friend Function selectDownloadDate() As DataTable
            Return MyBase.GetDownloadDate()
        End Function

        '#Region "ダウンロードデータをテーブルに反映"
        '        ''' <summary>ダウンロードデータからテーブル更新</summary>
        '        ''' <remarks></remarks>
        '        Sub updateMiura()
        '            Dim builSQL As New StringBuilder()
        '            Dim str_sql As String
        '            Dim dt As DataTable
        '            Try
        '                dt = A_System()
        '                If dt Is Nothing OrElse Not dt.Rows(0).Item("予備2").Equals("True") Then
        '                    Exit Sub
        '                End If
        '                ' トランザクション開始
        '                DBA.TransactionStart()

        '                str_sql = "UPDATE Z_SQL実行履歴 SET SQL1='INSERT INTO cash_book(shop_code,date,code,cash_division_code,amount,basis_staff_code,summary,insert_date) VALUES(N''miura'',''2012/06/23'',''1'',''2'',''2889'',''4'',N''浄化槽清掃代  '',''2012/06/23 17:33:04'')' WHERE 処理番号='1056' AND 画面ID='d0500_現金入出金登録'"
        '                rtn = DBA.ExecuteNonQuery(str_sql)

        '                str_sql = "UPDATE A_システム SET 通信許可フラグ='1',予備2='2012/06/26'"
        '                rtn = DBA.ExecuteNonQuery(str_sql)

        '                str_sql = "UPDATE system SET Dummy2=" & VbSQLNStr("2012/06/26") & " where shop_code=" & VbSQLNStr(sShopcode)
        '                rtn = InsertZSqlExecHis("データ修正2012/6/26", str_sql)
        '                ' コミット
        '                DBA.TransactionCommit()

        '            Catch ex As Exception
        '                ' ロールバック
        '                DBA.TransactionRollBack()
        '                Throw ex
        '            End Try
        '        End Sub
        '#End Region

#Region "ダウンロードデータをテーブルに反映"
        ''' <summary>ダウンロードデータからテーブル更新</summary>
        ''' <remarks></remarks>
        Sub updateKurihama()
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                'str_sql = "SELECT COUNT(*) FROM D_顧客 where 顧客番号 ='0'"

                'dt = DBA.ExecuteDataTable(str_sql)
                'If Integer.Parse(dt.Rows(0).Item(0).ToString()) = 0 Then
                '    '対応済のため終了
                '    Exit Sub
                'End If

                ' トランザクション開始
                DBA.TransactionStart()

                str_sql = "delete from E_来店者 where 顧客番号 ='0'"
                rtn = DBA.ExecuteNonQuery(str_sql)

                str_sql = "delete from D_顧客 where 顧客番号 ='0'"
                rtn = DBA.ExecuteNonQuery(str_sql)

                'str_sql = "UPDATE [E_売上] SET [現金支払]=ISNULL((SELECT ROUND(SUM([数量]*[金額]-[サービス])* "
                'str_sql += " (CASE WHEN 来店日>='1989/4/1' AND 来店日<'1997/4/1' THEN 1.03 WHEN 来店日>='1997/4/1' THEN 1.05 ELSE 0 END),0) "
                'str_sql += " FROM E_売上明細 WHERE [E_売上].来店日 =E_売上明細.来店日 AND [E_売上].来店者番号 =E_売上明細.来店者番号 "
                'str_sql += " AND [E_売上].顧客番号 =E_売上明細.顧客番号 GROUP BY E_売上明細.来店日,E_売上明細.来店者番号,E_売上明細.顧客番号),0)"
                'str_sql += " ,[お預り]=ISNULL((SELECT ROUND(SUM([数量]*[金額]-[サービス])*"
                'str_sql += " (CASE WHEN 来店日>='1989/4/1' AND 来店日<'1997/4/1' THEN 1.03 WHEN 来店日>='1997/4/1' THEN 1.05	ELSE 0 END),0)"
                'str_sql += " FROM E_売上明細 WHERE [E_売上].来店日 =E_売上明細.来店日 AND [E_売上].来店者番号 =E_売上明細.来店者番号"
                'str_sql += " AND [E_売上].顧客番号 =E_売上明細.顧客番号 GROUP BY E_売上明細.来店日,E_売上明細.来店者番号,E_売上明細.顧客番号),0)"
                'str_sql += " ,[消費税]=ISNULL((SELECT ROUND(SUM([数量]*[金額]-[サービス])*"
                'str_sql += " (CASE WHEN 来店日>='1989/4/1' AND 来店日<'1997/4/1' THEN 0.03 WHEN 来店日>='1997/4/1' THEN 0.05	ELSE 0 END),0)"
                'str_sql += " FROM E_売上明細 WHERE [E_売上].来店日 =E_売上明細.来店日 AND [E_売上].来店者番号 =E_売上明細.来店者番号"
                'str_sql += " AND [E_売上].顧客番号 =E_売上明細.顧客番号 GROUP BY E_売上明細.来店日,E_売上明細.来店者番号,E_売上明細.顧客番号),0)"
                'str_sql += " WHERE E_売上.来店日<'2012/6/11'"
                'rtn = DBA.ExecuteNonQuery(str_sql)

                'str_sql = "UPDATE A_システム SET 予備2='2012/9/29'"
                'rtn = DBA.ExecuteNonQuery(str_sql)

                str_sql = "DELETE FROM visit where basis_customer_code = ''0'' AND shop_code=" & VbSQLNStr(sShopcode)
                rtn = InsertZSqlExecHis("データ修正", str_sql)

                str_sql = "DELETE FROM basis_customer where code = ''0'' AND shop_code=" & VbSQLNStr(sShopcode)
                rtn = InsertZSqlExecHis("データ修正", str_sql)

                ' コミット
                DBA.TransactionCommit()

            Catch ex As Exception
                Throw ex
                ' ロールバック
                DBA.TransactionRollBack()
            End Try
        End Sub
#End Region

    End Class
End Namespace
