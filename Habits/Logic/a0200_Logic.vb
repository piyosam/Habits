#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic

    ''' <summary>メイン画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a0200_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a0200_メイン"

#Region "データ取得"

#Region "営業日データ取得"
        ''' <summary>営業日データ取得</summary>
        ''' <param name="v_date">作業日</param>
        ''' <returns>営業日情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function BusinessDay(ByVal v_date As Date) As DataTable
            Dim param As New Habits.DB.DBParameter
            param.Add("@営業日", Format(v_date, "yyyy/MM/dd"))
            Return MyBase.E_営業日(param)
        End Function
#End Region

#Region "来店者（未会計・会計済）リスト取得"
        ''' <summary>来店者データリロード</summary>
        ''' <param name="v_type">"1":未会計／"2":会計済み</param>
        ''' <returns>来店者リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetListData(ByVal v_type As String) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Dim param As New Habits.DB.DBParameter

            Try
                builSQL.Append("SELECT E_来店者.来店日,")
                builSQL.Append(" E_来店者.来店者番号,")
                builSQL.Append(" RIGHT(Space(7) + E_来店者.顧客番号,7) AS 顧客,")
                builSQL.Append(" E_来店者.姓 + ' ' + ISNULL(E_来店者.名,'') AS 名前,")
                builSQL.Append(" E_来店者.姓カナ AS カナ,")
                builSQL.Append(" E_来店者.住所 AS 現住所,")
                builSQL.Append(" CASE ISNULL(E_来店者.前回来店日,0) WHEN 0 THEN 'なし' ELSE LEFT(CONVERT(char,E_来店者.前回来店日,111),10) END AS 前回,")
                builSQL.Append(" ISNULL(CONVERT(VARCHAR(5),E_来店者.来店間隔,108),'') AS 間隔,")
                builSQL.Append(" CASE ISNULL(D_担当者.担当者名,'') WHEN '' THEN Space(16) ELSE D_担当者.担当者名 END AS 担当,")
                builSQL.Append(" CASE WHEN E_来店者.指名 ='True' THEN '指' ELSE '' END AS 指名,")
                builSQL.Append(" ISNULL(CONVERT(VARCHAR(5),作業開始,108),'待ち') AS 開始,")
                builSQL.Append(" CONVERT(VARCHAR(5),作業終了,108) AS 終了")

                If v_type = "1" Then
                    builSQL.Append(", '' AS 会計")
                    builSQL.Append(", CASE WHEN 伝言フラグ = 'True' THEN 'あり' ELSE '' END AS 伝言")

                ElseIf v_type = "2" Then
                    builSQL.Append(", '済' AS 会計")
                End If

                builSQL.Append(" FROM E_来店者 LEFT JOIN D_担当者 ON E_来店者.主担当者番号 = D_担当者.担当者番号,D_顧客")
                builSQL.Append(" WHERE DateDiff(day, E_来店者.来店日, @来店日)=0")

                If v_type = "1" Then
                    builSQL.Append(" AND E_来店者.会計済 = 0")

                ElseIf v_type = "2" Then
                    builSQL.Append(" AND E_来店者.会計済 <> 0")
                End If

                builSQL.Append(" AND E_来店者.顧客番号 = D_顧客.顧客番号")
                builSQL.Append(" ORDER BY E_来店者.作業終了 DESC ,E_来店者.来店者番号 DESC")

                str_sql = builSQL.ToString
                param.Add("@来店日", Format(USER_DATE, "yyyy-MM-dd"))
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "予約者リスト取得"
        ''' <summary>予約データリロード</summary>
        ''' <returns>予約者リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetReserveListData() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Dim param As New Habits.DB.DBParameter

            Try
                builSQL.Append("SELECT (顧客姓 + ' ' + 顧客名) AS 氏名 , 担当者名,メニュー,開始時刻,予約番号")
                builSQL.Append(" FROM W_予約 WHERE 予約番号 NOT IN ( ")
                builSQL.Append(" SELECT 予約番号 FROM E_来店者 WHERE 来店日 = @来店日 AND 予約番号 IS NOT NULL)")
                builSQL.Append(" ORDER BY W_予約.開始時刻 ASC")

                str_sql = builSQL.ToString
                param.Add("@来店日", Format(USER_DATE, "yyyy-MM-dd"))
                dt = DBA.ExecuteDataTable(str_sql, param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "来店者一覧取得"
        ''' <summary>来店者一覧取得</summary>
        ''' <returns>来店者一覧</returns>
        ''' <remarks></remarks>
        Protected Friend Function VisitorList() As DataTable
            Return GetListData("1")
        End Function
#End Region

#Region "会計済一覧取得"
        ''' <summary>会計済み一覧取得</summary>
        ''' <returns>会計済来店者一覧</returns>
        ''' <remarks></remarks>
        Protected Friend Function AccountingEndList() As DataTable
            Return GetListData("2")
        End Function
#End Region

#Region "予約者一覧取得"
        ''' <summary>予約者一覧取得</summary>
        ''' <returns>予約者一覧</returns>
        ''' <remarks></remarks>
        Protected Friend Function ReserveList() As DataTable
            Return GetReserveListData()
        End Function
#End Region

#Region "顧客情報取得"
        ''' <summary>顧客情報取得</summary>
        ''' <returns>顧客情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function CustomerInfo() As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                builSQL.Append("SELECT D_顧客.顧客番号 ,D_顧客.姓 ,D_顧客.名 ,D_顧客.姓カナ ,D_顧客.名カナ")
                builSQL.Append(" ,D_顧客.性別番号 ,B_性別.性別 ,D_顧客.生年月日 ,D_顧客.郵便番号")
                builSQL.Append(" ,D_顧客.都道府県 ,D_顧客.住所1 ,D_顧客.住所2 ,D_顧客.住所3")
                builSQL.Append(" ,D_顧客.電話番号 ,D_顧客.Emailアドレス ,D_顧客.家族名 ,D_顧客.趣味")
                builSQL.Append(" ,D_顧客.好きな話題 ,D_顧客.嫌いな話題 ,D_顧客.伝言フラグ ,D_顧客.メモ")
                builSQL.Append(" ,D_顧客.紹介者 ,D_顧客.前回来店日 ,D_顧客.来店日N_1 ,D_顧客.来店日N_2")
                builSQL.Append(" ,D_顧客.来店回数 ,D_顧客.主担当者番号 ,D_担当者.担当者名")
                builSQL.Append(" ,D_顧客.登録区分番号 ,B_登録区分.登録区分 ,D_顧客.登録日 ,D_顧客.更新日")
                builSQL.Append(" FROM D_顧客 LEFT JOIN B_性別 ON D_顧客.性別番号 = B_性別.性別番号")
                builSQL.Append(" LEFT JOIN D_担当者 ON D_顧客.主担当者番号 = D_担当者.担当者番号")
                builSQL.Append(" LEFT JOIN B_登録区分 ON D_顧客.登録区分番号 = B_登録区分.登録区分番号")
                builSQL.Append(" WHERE D_顧客.顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                param.Add("@顧客番号", CST_CODE)
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "来店者情報取得"
        ''' <summary>来店者情報取得(当日のみ)</summary>
        ''' <param name="v_number">来店者番号</param>
        ''' <returns>来店者情報リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetVisitorData(ByVal v_number As String) As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                str_sql = "SELECT * FROM E_来店者 WHERE 来店日 = @来店日 AND 来店者番号 = @来店者番号"
                param.Add("@来店日", Format(USER_DATE, "yyyy/MM/dd"))
                param.Add("@来店者番号", v_number)
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "来店回数取得"
        ''' <summary>来店取消時、来店回数取得</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>来店回数</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_number(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String

            Try
                str_sql = "SELECT 来店回数 ,前回来店日,来店日N_1,来店日N_2 FROM D_顧客 WHERE 顧客番号 = @顧客番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "アップロードデータ格納パス取得"
        ''' <summary>アップロードデータ格納パス取得</summary>
        ''' <returns>データ格納パス名</returns>
        ''' <remarks></remarks>
        Function getStockPath() As String
            Return MyBase.getDataStockPath()
        End Function
#End Region

#Region "カルテ存在チェック"
        ''' <summary>カルテ有無確認</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>カルテ</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_carte(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT カルテ FROM E_カルテ WHERE 来店日 = @来店日 AND 顧客番号 = @顧客番号 AND 来店者番号 = @来店者番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "最終ダウンロード時間取得"
        ''' <summary>最終ダウンロード時間取得</summary>
        ''' <returns>M_送受信レコード</returns>
        ''' <remarks></remarks>
        Function selectDownloadDate() As DataTable
            Return MyBase.GetDownloadDate()
        End Function
#End Region

#Region "システム情報取得"
        ''' <summary>システム情報取得</summary>
        ''' <returns>システム情報</returns>
        ''' <remarks></remarks>
        Function selectShopcode() As DataTable
            Return MyBase.A_System()
        End Function
#End Region

#End Region

#Region "テーブル更新"

#Region "来店取消時、D_顧客更新処理"
        ''' <summary>来店取り消し時のD_顧客テーブル更新</summary>
        ''' <param name="v_param">SQLパラメータ：@来店回数/@更新日/@顧客番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function DeleteCustomer(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                '------------------------------
                'D_顧客 UPDATE
                '------------------------------
                builSQL.Append("UPDATE D_顧客 SET")
                builSQL.Append(" 来店回数=@来店回数,")
                builSQL.Append(" 更新日=@更新日")
                builSQL.Append(" WHERE 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE basis_customer SET")
                builSQL.Append(" visit_times=" & VbSQLStr(v_param.GetValue("@来店回数")) & ",")
                builSQL.Append(" update_date=" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

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

#Region "来店取消時、E_来店者削除処理"
        ''' <summary>来店取り消し時のE_来店者テーブル削除</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function DeleteVisitor(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                '------------------------------
                'E_来店者 DELETE
                '------------------------------
                str_sql = "DELETE FROM E_来店者 WHERE 来店日=@来店日 AND 来店者番号=@来店者番号"

                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                '' SQL1設定
                builSQL.Append("DELETE FROM visit")
                builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))                      '店舗コード
                builSQL.Append(" AND date=" & VbSQLStr(v_param.GetValue("@来店日")))            '来店日
                builSQL.Append(" AND number=" & VbSQLStr(v_param.GetValue("@来店者番号")))      '来店者番号
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "マスタテーブルトランケート"
        ''' <summary>テーブル更新前のトランケート</summary>
        ''' <param name="bTableName">テーブル名</param>
        ''' <remarks></remarks>
        Sub BedoreMakeSQL(ByVal bTableName As String)
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                If (bTableName = "tax") Then
                    bTableName = "B_消費税"
                ElseIf (bTableName.ToString = "gender") Then
                    bTableName = "B_性別"
                ElseIf (bTableName.ToString = "weather") Then
                    bTableName = "B_天候"
                ElseIf (bTableName.ToString = "register") Then
                    bTableName = "B_登録区分"
                ElseIf (bTableName.ToString = "receive_ship_division") Then
                    bTableName = "B_入出庫区分"
                ElseIf (bTableName.ToString = "receive_ship_reason") Then
                    bTableName = "B_入出庫理由"
                ElseIf (bTableName = "post_code") Then
                    bTableName = "B_郵便番号"
                ElseIf (bTableName = "visit_division") Then
                    bTableName = "B_来店区分"
                ElseIf (bTableName = "reserve") Then
                    bTableName = "W_予約"
                Else
                End If

                str_sql = "TRUNCATE TABLE " & bTableName
                rtn = DBA.ExecuteNonQuery(str_sql)
                ' コミット
                DBA.TransactionCommit()

            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Sub
#End Region

#Region "ダウンロードデータをテーブルに反映"
        ''' <summary>ダウンロードデータからテーブル更新</summary>
        ''' <param name="bTableName">テーブル名</param>
        ''' <param name="sColumnValue">テーブルレコード</param>
        ''' <remarks></remarks>
        Sub makeDownloadSQL(ByVal bTableName As String, ByVal sColumnValue As String)
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                sColumnValue = Replace(sColumnValue, """,""", "','")
                sColumnValue = Mid(sColumnValue, 2, sColumnValue.Length - 2)

                If (bTableName = "tax") Then
                    bTableName = "B_消費税"
                ElseIf (bTableName = "gender") Then
                    bTableName = "B_性別"
                ElseIf (bTableName = "weather") Then
                    bTableName = "B_天候"
                ElseIf (bTableName = "register") Then
                    bTableName = "B_登録区分"
                ElseIf (bTableName = "receive_ship_division") Then
                    bTableName = "B_入出庫区分"
                ElseIf (bTableName = "receive_ship_reason") Then
                    bTableName = "B_入出庫理由"
                ElseIf (bTableName = "post_code") Then
                    bTableName = "B_郵便番号"
                ElseIf (bTableName = "visit_division") Then
                    bTableName = "B_来店区分"
                ElseIf (bTableName = "reserve") Then
                    bTableName = "W_予約"
                Else
                End If

                builSQL.AppendLine("INSERT INTO " + bTableName)
                builSQL.AppendLine(" VALUES('" + sColumnValue + "')")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql)
                ' コミット
                DBA.TransactionCommit()

            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Sub
#End Region

#Region "E_売上明細を削除"
        '''<summary>E_売上明細削除</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号/@売上番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_売上明細削除(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                '------------------------------
                'E_売上明細 DELETE
                '------------------------------
                builSQL.Append("DELETE FROM E_売上明細")
                builSQL.Append(" WHERE 来店日=@来店日")
                builSQL.Append(" AND 来店者番号=@来店者番号")
                builSQL.Append(" AND 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("DELETE FROM sales_details")
                builSQL.Append(" WHERE visit_date=" & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append(" AND visit_number=" & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "M_送受信の最終ダウンロード時間更新"
        ''' <summary>M_送受信の最終ダウンロード時間更新</summary>
        ''' <remarks></remarks>
        Sub finishDownload(ByVal upTime As String)
            Try
                Dim str_sql As String
                str_sql = "UPDATE [M_送受信] SET 最終ダウンロード = '" & upTime & "'"
                rtn = DBA.ExecuteNonQuery(str_sql)

            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Sub
#End Region

#Region "W_予約テーブルの全行を削除"
        ''' <summary>W_予約テーブルの全行を削除する</summary>
        ''' <remarks></remarks>
        Protected Friend Sub delete_reserveDate()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()
                str_sql = "TRUNCATE TABLE W_予約"
                DBA.ExecuteNonQuery(str_sql)
                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Sub
#End Region

#End Region

#Region "通信中エラー回数取得"
        ''' <summary></summary>
        ''' <returns>通信中エラー回数取得</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetConnectError() As DataTable
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                str_sql = "SELECT 通信中エラー回数 FROM M_送受信"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

    End Class
End Namespace
