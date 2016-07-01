#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>データ抽出画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class h0100_Logic
        Inherits Habits.Logic.LogicBase

#Region "性別名称一覧取得"
        ''' <summary>性別名称一覧取得</summary>
        ''' <returns>性別リスト</returns>
        ''' <remarks></remarks>
        Function SexType() As DataTable
            Return MyBase.B_性別()
        End Function
#End Region

#Region "担当者一覧取得"
        ''' <summary>担当者一覧取得</summary>
        ''' <returns>担当者リスト</returns>
        ''' <remarks></remarks>
        Function ChargePerson() As DataTable
            Return MyBase.getDStaff_exclude()
        End Function
#End Region

#Region "サービス一覧取得"
        ''' <summary>サービス一覧取得</summary>
        ''' <returns>サービスリスト</returns>
        ''' <remarks></remarks>
        Function ServiceName() As DataTable
            Return MyBase.getService_exclude()
        End Function
#End Region

#Region "売上区分を検索"
        ''' <summary>売上区分を検索</summary>
        ''' <returns>売上区分リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_saleDivision() As DataTable
            Return MyBase.getSalesDiv_exclude()
        End Function
#End Region

#Region "売上区分番号を条件に分類を検索"
        ''' <summary>売上区分番号を条件に分類を検索</summary>
        ''' <param name="v_param">SQLパラメータ：@削除フラグ</param>
        ''' <returns>分類リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_group(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return getClass_exclude(v_param)
        End Function
#End Region

#Region "売上区分番号,分類番号を条件に商品を検索"
        ''' <summary>売上区分番号,分類番号を条件に商品を検索</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号/@削除フラグ</param>
        ''' <returns>商品リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_itemname(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 商品名,商品番号,売上区分番号,分類番号 FROM C_商品 WHERE 売上区分番号 = @売上区分番号 AND 分類番号 = @分類番号 AND 削除フラグ = @削除フラグ ORDER BY 表示順,商品番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "商品情報取得"
        ''' <summary>商品情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号/@削除フラグ/@商品名</param>
        ''' <returns>商品名、商品番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function get_iteminfo(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 商品名,商品番号 FROM C_商品 WHERE 売上区分番号 = @売上区分番号 AND 分類番号 = @分類番号 AND 削除フラグ = @削除フラグ AND 商品名 = @商品名"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "D_顧客情報登録（登録済データのみ）"
        ''' <summary>D_顧客情報登録（登録済データのみ）</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 顧客新規作成登録済(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Try
                builSQL.Append("INSERT INTO W_顧客")
                builSQL.Append(" ( 顧客番号, 姓, 名, 姓カナ, 名カナ, 性別番号, 生年月日, 郵便番号, 都道府県, 住所1,")
                builSQL.Append(" 住所2, 住所3, 電話番号, Emailアドレス, 家族名, 趣味, 好きな話題, 嫌いな話題,")
                builSQL.Append(" 伝言フラグ, メモ, 紹介者, 前回来店日, 来店日N_1, 来店日N_2, 来店回数,")
                builSQL.Append(" 主担当者番号, 登録区分番号, DM希望フラグ,登録日, 更新日)")

                builSQL.Append(" SELECT D_顧客.*")
                builSQL.Append(" FROM D_顧客")
                builSQL.Append(" WHERE (((D_顧客.登録区分番号)=1) AND ((D_顧客.顧客番号)<@顧客番号));")

                str_sql = builSQL.ToString()
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                '’例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "D_顧客情報登録"
        ''' <summary>D_顧客情報登録</summary>
        ''' <param name="v_param">SQLパラメータ：@顧客番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 顧客新規作成全体(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Try
                builSQL.Append("INSERT INTO W_顧客")
                builSQL.Append(" ( 顧客番号, 姓, 名, 姓カナ, 名カナ, 性別番号, 生年月日, 郵便番号, 都道府県, 住所1,")
                builSQL.Append(" 住所2, 住所3, 電話番号, Emailアドレス, 家族名, 趣味, 好きな話題, 嫌いな話題,")
                builSQL.Append(" 伝言フラグ, メモ, 紹介者, 前回来店日, 来店日N_1, 来店日N_2, 来店回数,")
                builSQL.Append(" 主担当者番号, 登録区分番号,DM希望フラグ, 登録日, 更新日 )")

                builSQL.Append(" SELECT D_顧客.*")
                builSQL.Append(" FROM D_顧客")
                builSQL.Append(" WHERE ((D_顧客.顧客番号)<@顧客番号);")

                str_sql = builSQL.ToString()
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                '’例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "W_顧客抽出よりW_顧客に登録"
        ''' <summary>W_顧客抽出よりW_顧客に登録</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 顧客抽出作成() As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Dim i As Integer = 0
            Dim param As New Habits.DB.DBParameter
            Dim builSQL As New StringBuilder()
            Try
                builSQL.Append("INSERT INTO W_顧客")

                builSQL.Append(" SELECT ")
                builSQL.Append(" 顧客番号, 姓, 名, 姓カナ, 名カナ, 性別番号, 生年月日, 郵便番号, 都道府県, 住所1,")
                builSQL.Append(" 住所2, 住所3, 電話番号, Emailアドレス, 家族名, 趣味, 好きな話題, 嫌いな話題,")
                builSQL.Append(" 伝言フラグ, メモ, 紹介者, 前回来店日, 来店日N_1, 来店日N_2, 来店回数,")
                builSQL.Append(" 主担当者番号, 登録区分番号,DM希望フラグ ,登録日, 更新日 ")
                builSQL.Append(" FROM W_顧客抽出;")
                str_sql = builSQL.ToString()
                rtn = DBA.ExecuteNonQuery(str_sql)

            Catch ex As Exception
                '’例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "顧客番号一覧取得"
        ''' <summary>顧客番号一覧取得</summary>
        ''' <returns>顧客番号一覧</returns>
        ''' <remarks></remarks>
        Protected Friend Function 件数カウント用() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT DISTINCT 顧客番号 FROM W_顧客抽出 ORDER BY W_顧客抽出.顧客番号;"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                '’例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "W_顧客削除"
        ''' <summary>W_顧客削除</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_h0100_W_顧客削除() As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' トランザクション開始
                DBA.TransactionStart()
                str_sql = "DELETE W_顧客 FROM W_顧客;"
                rtn = DBA.ExecuteNonQuery(str_sql)
                DBA.TransactionCommit()

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "W_抽出履歴削除"
        ''' <summary>W_抽出履歴削除</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_h0100_W_抽出履歴削除() As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()
                str_sql = "DELETE W_抽出履歴 FROM W_抽出履歴;"
                rtn = DBA.ExecuteNonQuery(str_sql)
                DBA.TransactionCommit()

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "W_顧客抽出削除"
        ''' <summary>W_顧客抽出削除</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_h0100_W_顧客抽出削除() As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' トランザクション開始
                DBA.TransactionStart()
                str_sql = "DELETE W_顧客抽出 FROM W_顧客抽出;"
                rtn = DBA.ExecuteNonQuery(str_sql)
                DBA.TransactionCommit()

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "W_顧客抽出のINSERT文共通部取得"
        ''' <summary>W_顧客抽出のINSERT文共通部取得</summary>
        ''' <param name="type">抽出タイプ
        ''' 0：性別
        ''' 1：生年月日
        ''' 2：誕生月
        ''' 3：年齢
        ''' 4：メニュー
        ''' 5：来店回数
        ''' 6：区分売上
        ''' 7：主担当
        ''' 8：最終来店日
        ''' 9：サービス
        ''' </param>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Function insert_W_顧客抽出(ByVal type As Int32, ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO [W_顧客抽出](")
                builSQL.Append(" 顧客番号")
                builSQL.Append(",姓")
                builSQL.Append(",名")
                builSQL.Append(",姓カナ")
                builSQL.Append(",名カナ")
                builSQL.Append(",性別番号")
                builSQL.Append(",生年月日")
                builSQL.Append(",郵便番号")
                builSQL.Append(",都道府県")
                builSQL.Append(",住所1")
                builSQL.Append(",住所2")
                builSQL.Append(",住所3")
                builSQL.Append(",電話番号")
                builSQL.Append(",Emailアドレス")
                builSQL.Append(",家族名")
                builSQL.Append(",趣味")
                builSQL.Append(",好きな話題")
                builSQL.Append(",嫌いな話題")
                builSQL.Append(",伝言フラグ")
                builSQL.Append(",メモ")
                builSQL.Append(",紹介者")
                builSQL.Append(",前回来店日")
                builSQL.Append(",来店日N_1")
                builSQL.Append(",来店日N_2")
                builSQL.Append(",来店回数")
                If type = 6 Then
                    builSQL.Append(",売上区分番号")
                    builSQL.Append(",区分合計金額")
                End If
                builSQL.Append(",主担当者番号")
                builSQL.Append(",登録区分番号")
                builSQL.Append(",DM希望フラグ")
                builSQL.Append(",登録日")
                builSQL.Append(",更新日")
                builSQL.Append(")")

                builSQL.Append(" SELECT DISTINCT")
                builSQL.Append(" W_顧客.顧客番号")
                builSQL.Append(",W_顧客.姓")
                builSQL.Append(",W_顧客.名")
                builSQL.Append(",W_顧客.姓カナ")
                builSQL.Append(",W_顧客.名カナ")
                builSQL.Append(",W_顧客.性別番号")
                builSQL.Append(",W_顧客.生年月日")
                builSQL.Append(",W_顧客.郵便番号")
                builSQL.Append(",W_顧客.都道府県")
                builSQL.Append(",W_顧客.住所1")
                builSQL.Append(",W_顧客.住所2")
                builSQL.Append(",W_顧客.住所3")
                builSQL.Append(",W_顧客.電話番号")
                builSQL.Append(",W_顧客.Emailアドレス")
                builSQL.Append(",W_顧客.家族名")
                builSQL.Append(",W_顧客.趣味")
                builSQL.Append(",W_顧客.好きな話題")
                builSQL.Append(",W_顧客.嫌いな話題")
                builSQL.Append(",W_顧客.伝言フラグ")
                builSQL.Append(",W_顧客.メモ")
                builSQL.Append(",W_顧客.紹介者")
                builSQL.Append(",W_顧客.前回来店日")
                builSQL.Append(",W_顧客.来店日N_1")
                builSQL.Append(",W_顧客.来店日N_2")
                builSQL.Append(",W_顧客.来店回数")
                If type = 6 Then
                    builSQL.Append(",tmp2.売上区分番号")
                    builSQL.Append(",tmp2.区分合計金額")
                End If
                builSQL.Append(",W_顧客.主担当者番号")
                builSQL.Append(",W_顧客.登録区分番号")
                builSQL.Append(",W_顧客.DM希望フラグ")
                builSQL.Append(",W_顧客.登録日")
                builSQL.Append(",W_顧客.更新日")

                builSQL.Append(" FROM W_顧客")
                Select Case type
                    Case 0    ' タブ(性別)
                        builSQL.Append(" JOIN B_性別 ON W_顧客.性別番号 = B_性別.性別番号")
                        builSQL.Append(" WHERE B_性別.性別 = @性別番号")

                    Case 1  ' タブ(生年月日)
                        builSQL.Append(" WHERE W_顧客.生年月日 >= @生年月日開始 AND W_顧客.生年月日 <= @生年月日終了")

                    Case 2  ' タブ(誕生月)
                        builSQL.Append(" WHERE DatePart(""m"",[生年月日]) >= @誕生月開始 AND DatePart(""m"",[生年月日]) <= @誕生月終了")

                    Case 3  ' タブ(年齢)
                        builSQL.Append(" WHERE W_顧客.生年月日 <= @年齢開始 AND W_顧客.生年月日 > @年齢終了")

                    Case 4  ' タブ(メニュー)
                        builSQL.Append(" WHERE 顧客番号 IN(SELECT 顧客番号 FROM E_売上明細 WHERE 売上区分番号 = @売上区分番号 AND 会計済 = 'TRUE'")
                        builSQL.Append(" AND 分類番号 = @分類番号")
                        builSQL.Append(" AND 名称番号 = (SELECT 商品番号 FROM C_商品 WHERE 売上区分番号 = @売上区分番号 AND 分類番号 = @分類番号 AND 商品番号 = @商品番号))")

                    Case 5  ' タブ(来店回数)
                        builSQL.Append(" WHERE W_顧客.来店回数 >=@来店回数開始 AND W_顧客.来店回数 <= @来店回数終了")

                    Case 6  ' タブ(区分売上)
                        builSQL.Append(" INNER JOIN ")
                        builSQL.Append(" (SELECT 顧客番号, 売上区分番号,区分合計金額")
                        builSQL.Append(" FROM (SELECT cus.顧客番号, sale.売上区分番号,")
                        builSQL.Append(" SUM(sale.金額 * sale.数量 - sale.サービス) AS 区分合計金額")
                        builSQL.Append(" FROM W_顧客 AS cus INNER JOIN E_売上明細 AS sale ON")
                        builSQL.Append(" cus.顧客番号 = sale.顧客番号")
                        builSQL.Append(" where(sale.売上区分番号 = @売上区分番号)  AND (sale.来店日 BETWEEN @区分売上期間開始 AND @区分売上期間終了) AND sale.会計済 = 'TRUE'")
                        builSQL.Append(" GROUP BY cus.顧客番号, sale.売上区分番号) AS tmp1")
                        builSQL.Append("  WHERE (区分合計金額 BETWEEN @区分売上開始 AND @区分売上終了 )")
                        builSQL.Append(" ) AS tmp2")
                        builSQL.Append(" ON W_顧客.顧客番号 = tmp2.顧客番号")

                    Case 7  ' タブ(主担当)
                        builSQL.Append(" WHERE 顧客番号 IN ( ")
                        builSQL.Append(" SELECT 顧客番号 FROM E_売上 WHERE 主担当者番号 = @主担当者番号 AND 指名 = @指名 GROUP BY 顧客番号 )")

                    Case 8  ' タブ(最終来店日)
                        builSQL.Append(" WHERE W_顧客.前回来店日>=@最終来店日開始 AND W_顧客.前回来店日<= @最終来店日終了")

                    Case 9  ' タブ(サービス)
                        builSQL.Append(" JOIN (E_売上明細 JOIN B_サービス ON E_売上明細.サービス番号 = B_サービス.サービス番号) ON W_顧客.顧客番号 = E_売上明細.顧客番号")
                        builSQL.Append(" WHERE B_サービス.サービス名 = @サービス名 AND E_売上明細.会計済 = 'TRUE'")
                        builSQL.Append(" AND (E_売上明細.来店日 BETWEEN @サービス開始 AND @サービス終了)")
                        builSQL.Append(" AND NOT EXISTS (SELECT * FROM W_顧客抽出 WHERE W_顧客抽出.顧客番号 = W_顧客.顧客番号)")

                        builSQL.Append(" UNION SELECT DISTINCT")
                        builSQL.Append(" W_顧客.顧客番号")
                        builSQL.Append(",W_顧客.姓")
                        builSQL.Append(",W_顧客.名")
                        builSQL.Append(",W_顧客.姓カナ")
                        builSQL.Append(",W_顧客.名カナ")
                        builSQL.Append(",W_顧客.性別番号")
                        builSQL.Append(",W_顧客.生年月日")
                        builSQL.Append(",W_顧客.郵便番号")
                        builSQL.Append(",W_顧客.都道府県")
                        builSQL.Append(",W_顧客.住所1")
                        builSQL.Append(",W_顧客.住所2")
                        builSQL.Append(",W_顧客.住所3")
                        builSQL.Append(",W_顧客.電話番号")
                        builSQL.Append(",W_顧客.Emailアドレス")
                        builSQL.Append(",W_顧客.家族名")
                        builSQL.Append(",W_顧客.趣味")
                        builSQL.Append(",W_顧客.好きな話題")
                        builSQL.Append(",W_顧客.嫌いな話題")
                        builSQL.Append(",W_顧客.伝言フラグ")
                        builSQL.Append(",W_顧客.メモ")
                        builSQL.Append(",W_顧客.紹介者")
                        builSQL.Append(",W_顧客.前回来店日")
                        builSQL.Append(",W_顧客.来店日N_1")
                        builSQL.Append(",W_顧客.来店日N_2")
                        builSQL.Append(",W_顧客.来店回数")
                        builSQL.Append(",W_顧客.主担当者番号")
                        builSQL.Append(",W_顧客.登録区分番号")
                        builSQL.Append(",W_顧客.DM希望フラグ")
                        builSQL.Append(",W_顧客.登録日")
                        builSQL.Append(",W_顧客.更新日")

                        builSQL.Append(" FROM W_顧客")
                        builSQL.Append(" JOIN (E_売上 JOIN B_サービス ON E_売上.サービス番号 = B_サービス.サービス番号) ON W_顧客.顧客番号 = E_売上.顧客番号")
                        builSQL.Append(" WHERE B_サービス.サービス名 = @サービス名")
                        builSQL.Append(" AND (E_売上.来店日 BETWEEN @サービス開始 AND @サービス終了)")
                End Select
                builSQL.Append(" AND NOT EXISTS (SELECT * FROM W_顧客抽出 WHERE W_顧客抽出.顧客番号 = W_顧客.顧客番号);")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn

        End Function
#End Region

#Region "履歴一覧取得"
        ''' <summary>履歴一覧取得</summary>
        ''' <returns>履歴リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function Q_h0100_抽出履歴一覧() As DataTable
            Dim rtnCnt As DataTable
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("SELECT 履歴番号, W_抽出履歴.区分, W_抽出履歴.条件, W_抽出履歴.値１, W_抽出履歴.値２")
                builSQL.Append(" FROM W_抽出履歴")
                builSQL.Append(" ORDER BY 履歴番号;")

                str_sql = builSQL.ToString()
                rtnCnt = DBA.ExecuteDataTable(str_sql)
                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                '' 例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtnCnt
        End Function
#End Region

#Region "W_抽出履歴登録"
        ''' <summary>W_抽出履歴登録</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function W_抽出履歴追加(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim str_sql As String
            Dim builSQL As New StringBuilder()
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO W_抽出履歴 (履歴番号,区分,条件,値１,値２)")
                builSQL.Append(" VALUES(@履歴番号,@区分,@条件,@値１,@値２);")
                str_sql = builSQL.ToString()
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                '' 例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtnCnt
        End Function
#End Region

    End Class
End Namespace