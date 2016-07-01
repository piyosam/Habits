#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>商品マスタ編集ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class f0500_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f0500_分類"

#Region "データ取得"

#Region "売上区分リスト取得"
        ''' <summary>B_売上区分テーブルから売上区分名一覧を取得</summary>
        ''' <returns>売上区分名リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetSalesDivisionNames() As DataTable
            Return MyBase.getSalesDiv()
        End Function
#End Region

#Region "売上区分情報一覧取得"
        ''' <summary>B_売上区分テーブルから売上区分一覧を取得</summary>
        ''' <returns>売上区分情報リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetSalesDivision() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT")
                builSQL.Append(" 売上区分番号 AS 番号,")
                builSQL.Append(" 売上区分,")
                builSQL.Append(" 表示順,")
                builSQL.Append(" (CASE WHEN B_売上区分.削除フラグ = 'True' THEN '×' ELSE '' END) AS 表示,")
                builSQL.Append(" 登録日,")
                builSQL.Append(" 更新日")
                builSQL.Append(" FROM B_売上区分")
                builSQL.Append(" ORDER BY 表示順,売上区分番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "分類リスト取得"
        ''' <summary>C_分類テーブルから分類名一覧を取得</summary>
        ''' <param name="v_number">SQLパラメータ：@売上区分番号</param>
        ''' <returns>分類名リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCommodityDivisionNames(ByVal v_number As String) As DataTable
            Dim param As New Habits.DB.DBParameter
            param.Add("@売上区分番号", v_number)

            Return getClass_exclude(param)
        End Function
#End Region

#Region "分類情報一覧取得"
        ''' <summary>C_分類テーブルから売上区分別分類一覧を取得</summary>
        ''' <param name="v_number">SQLパラメータ：@売上区分番号</param>
        ''' <returns>分類情報リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCommodityDivision(ByVal v_number As String) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Try
                builSQL.Append("SELECT")
                builSQL.Append(" 分類番号 AS 番号,")
                builSQL.Append(" 分類名,")
                builSQL.Append(" 表示順,")
                builSQL.Append(" (CASE WHEN C_分類.店販対象フラグ = 'True' THEN '○' ELSE '' END) AS 店販対象,")
                builSQL.Append(" (CASE WHEN C_分類.削除フラグ = 'True' THEN '×' ELSE '' END) AS 非表示,")
                builSQL.Append(" 登録日,")
                builSQL.Append(" 更新日")
                builSQL.Append(" FROM C_分類")
                builSQL.Append(" WHERE 売上区分番号 = @売上区分番号")
                builSQL.Append(" ORDER BY 表示順,分類番号")

                '' パラメータ設定
                param.Add("@売上区分番号", v_number)
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "商品情報一覧取得"
        ''' <summary>C_商品テーブルから商品一覧を取得</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号</param>
        ''' <returns>商品リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCommodity(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT")
                builSQL.Append(" C_商品.商品番号 AS No")
                builSQL.Append(" ,C_商品.商品名 AS 商品名")
                builSQL.Append(" ,C_商品.メーカー番号 AS メーカー番号")
                builSQL.Append(" ,C_メーカー.メーカー名 AS メーカー名")
                builSQL.Append(" ,C_商品.標準時間 AS 標準時間")
                builSQL.Append(" ,C_商品.仕入金額 AS 仕入金額")
                builSQL.Append(" ,C_商品.販売金額 AS 販売金額")
                builSQL.Append(" ,C_商品.在庫数 AS 在庫数")
                builSQL.Append(" ,C_商品.発注点 AS 発注点")
                builSQL.Append(" ,C_商品.規定在庫数 AS 既定数")
                builSQL.Append(" ,C_商品.表示順 AS 表示順")
                builSQL.Append(" ,(CASE WHEN (SELECT DISTINCT 売上区分番号 FROM C_商品工程")
                builSQL.Append(" WHERE C_商品.売上区分番号 = C_商品工程.売上区分番号 AND C_商品.分類番号 = C_商品工程.分類番号")
                builSQL.Append(" AND C_商品.商品番号 = C_商品工程.商品番号)")
                builSQL.Append(" IS NULL THEN '' ELSE '○' END) AS 工程")
                builSQL.Append(" ,(CASE WHEN C_商品.削除フラグ = 'True' THEN '×' ELSE '' END) AS 表示")
                builSQL.Append(" ,C_商品.登録日 AS 登録日")
                builSQL.Append(" ,C_商品.更新日 AS 更新日")
                builSQL.Append(" ,(CASE WHEN C_商品.金額管理区分 = '1' THEN '本体' ELSE '税込' END) AS 管理")
                builSQL.Append(" FROM (C_商品 LEFT JOIN C_メーカー ON C_商品.メーカー番号 = C_メーカー.メーカー番号)")
                builSQL.Append(" WHERE C_商品.売上区分番号 = @売上区分番号 AND C_商品.分類番号 = @分類番号")
                builSQL.Append(" ORDER BY 表示順,C_商品.商品番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "メーカーリスト取得"
        ''' <summary>C_メーカーテーブルからメーカー名一覧を取得</summary>
        ''' <returns>有効なメーカーリスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetBrandNames() As DataTable
            Return MyBase.getMaker_exclude
        End Function
#End Region

#Region "売上区分検索"
        ''' <summary>売上区分の検索</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分</param>
        ''' <returns>売上区分</returns>
        ''' <remarks>新規登録時、同売上区分での登録防止用</remarks>
        Protected Friend Function checkDuplicate_SalesDiv(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 売上区分番号,売上区分 FROM B_売上区分 WHERE 売上区分 = @売上区分"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "分類名検索"
        ''' <summary>分類名の検索</summary>
        ''' <param name="v_param">SQLパラメータ：@分類</param>
        ''' <returns>分類</returns>
        ''' <remarks>新規登録時、同売上区分での登録防止用</remarks>
        Protected Friend Function checkDuplicate_Class(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 売上区分番号,分類番号,分類名 FROM C_分類 WHERE 分類名 = @分類名 AND 売上区分番号 = @売上区分"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "分類情報取得"
        ''' <summary>分類情報の取得</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号</param>
        ''' <returns>分類</returns>
        ''' <remarks>対象レコード出力</remarks>
        Protected Friend Function getClassData(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 分類番号,分類名,店販対象フラグ FROM C_分類 WHERE 売上区分番号 = @売上区分番号 AND 分類番号 = @分類番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "商品名検索"
        ''' <summary>商品名の取得</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号/@商品名</param>
        ''' <returns>商品名</returns>
        ''' <remarks>新規登録時、同売上区分、同分類番号、同商品名での登録防止用</remarks>
        Protected Friend Function checkDuplicate(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 商品番号,商品名 FROM C_商品 WHERE 売上区分番号 = @売上区分番号 AND 分類番号 = @分類番号 AND 商品名 = @商品名"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#End Region

#Region "データ更新"

#Region "売上区分新規登録"
        ''' <summary>売上区分の新規登録</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@売上区分/@表示順/@削除フラグ/@登録日.@更新日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function SalesDivisionInsert(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO B_売上区分 (")
                builSQL.Append(" 売上区分番号,")
                builSQL.Append(" 売上区分,")
                builSQL.Append(" 表示順,")
                builSQL.Append(" 削除フラグ,")
                builSQL.Append(" 登録日,")
                builSQL.Append(" 更新日 )")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @売上区分番号,")
                builSQL.Append(" @売上区分,")
                builSQL.Append(" @表示順,")
                builSQL.Append(" @削除フラグ,")
                builSQL.Append(" @登録日,")
                builSQL.Append(" @更新日 )")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("INSERT INTO sales_division (")
                builSQL.Append(" shop_code,")
                builSQL.Append(" code,")
                builSQL.Append(" name,")
                builSQL.Append(" display_order,")
                builSQL.Append(" delete_flag,")
                builSQL.Append(" insert_date,")
                builSQL.Append(" update_date )")

                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@売上区分番号")) & ",")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@売上区分")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@表示順")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@削除フラグ")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@登録日")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@更新日")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

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

#Region "売上区分更新"
        ''' <summary>売上区分の更新</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分/@表示順/@削除フラグ/@更新日/@売上区分番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function SalesDivisionUpdate(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("UPDATE B_売上区分 SET")
                builSQL.Append(" 売上区分 = @売上区分,")
                builSQL.Append(" 表示順 = @表示順,")
                builSQL.Append(" 削除フラグ = @削除フラグ,")
                builSQL.Append(" 更新日 = @更新日")
                builSQL.Append(" WHERE 売上区分番号 = @売上区分番号")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE sales_division SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@売上区分")) & ",")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue("@表示順")) & ",")
                builSQL.Append(" delete_flag =" & VbSQLStr(v_param.GetValue("@削除フラグ")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE code =" & VbSQLStr(v_param.GetValue("@売上区分番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))                        '店舗コード     (varchar)
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

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

#Region "分類新規登録"
        ''' <summary>分類の新規登録</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function CommodityDivisionInsert(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO C_分類 (")
                builSQL.Append(" 売上区分番号,")
                builSQL.Append(" 分類番号,")
                builSQL.Append(" 分類名,")
                builSQL.Append(" 表示順,")
                builSQL.Append(" 店販対象フラグ,")
                builSQL.Append(" 削除フラグ,")
                builSQL.Append(" 登録日,")
                builSQL.Append(" 更新日)")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @売上区分番号,")
                builSQL.Append(" @分類番号,")
                builSQL.Append(" @分類名,")
                builSQL.Append(" @表示順,")
                builSQL.Append(" @店販対象フラグ,")
                builSQL.Append(" @削除フラグ,")
                builSQL.Append(" @登録日,")
                builSQL.Append(" @更新日)")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("INSERT INTO class (")
                builSQL.Append(" shop_code,")
                builSQL.Append(" sales_division_code,")
                builSQL.Append(" code,")
                builSQL.Append(" name,")
                builSQL.Append(" display_order,")
                builSQL.Append(" stock_manage_flag,")
                builSQL.Append(" delete_flag,")
                builSQL.Append(" insert_date,")
                builSQL.Append(" update_date)")
                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@売上区分番号")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@分類番号")) & ",")
                builSQL.Append(VbSQLNStr(v_param.GetValue("@分類名")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@表示順")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@店販対象フラグ")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@削除フラグ")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@登録日")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@更新日")) & ")")
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

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

#Region "分類更新"
        ''' <summary>分類の更新</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function CommodityDivisionUpdate(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("UPDATE C_分類 SET")
                builSQL.Append(" 分類名 = @分類名,")
                builSQL.Append(" 表示順 = @表示順,")
                builSQL.Append(" 店販対象フラグ = @店販対象フラグ,")
                builSQL.Append(" 削除フラグ = @削除フラグ,")
                builSQL.Append(" 更新日 = @更新日")
                builSQL.Append(" WHERE 売上区分番号 = @売上区分番号")
                builSQL.Append(" AND 分類番号 = @分類番号")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE class SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@分類名")) & ",")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue("@表示順")) & ",")
                builSQL.Append(" stock_manage_flag =" & VbSQLStr(v_param.GetValue("@店販対象フラグ")) & ",")
                builSQL.Append(" delete_flag =" & VbSQLStr(v_param.GetValue("@削除フラグ")) & ",")
                builSQL.Append(" update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@売上区分番号")))
                builSQL.Append(" AND code =" & VbSQLStr(v_param.GetValue("@分類番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))                        '店舗コード     (varchar)
                InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

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

#Region "商品新規登録"
        ''' <summary>商品の新規登録</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <param name="v_stckFlag">True:在庫管理あり / False:在庫管理なし</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function CommodityInsert(ByVal v_param As Habits.DB.DBParameter, ByVal v_stckFlag As Boolean) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO C_商品 (")
                builSQL.Append(" 売上区分番号")
                builSQL.Append(" ,分類番号")
                builSQL.Append(" ,商品番号")
                builSQL.Append(" ,商品名")
                builSQL.Append(" ,販売金額")
                builSQL.Append(" ,表示順")
                builSQL.Append(" ,削除フラグ")
                builSQL.Append(" ,登録日")
                builSQL.Append(" ,更新日")
                builSQL.Append(" ,規定在庫数")
                builSQL.Append(" ,金額管理区分")
                If v_stckFlag Then
                    builSQL.Append(" ,メーカー番号")
                    builSQL.Append(" ,仕入金額")
                    builSQL.Append(" ,在庫数")
                    builSQL.Append(" ,発注点")
                Else
                    builSQL.Append(" ,標準時間")
                End If

                builSQL.Append(" )VALUES (")
                builSQL.Append(" @売上区分番号")
                builSQL.Append(" ,@分類番号")
                builSQL.Append(" ,@商品番号")
                builSQL.Append(" ,@商品名")
                builSQL.Append(" ,@販売金額")
                builSQL.Append(" ,@表示順")
                builSQL.Append(" ,@削除フラグ")
                builSQL.Append(" ,@登録日")
                builSQL.Append(" ,@更新日")
                If v_stckFlag Then
                    builSQL.Append(" ,@既定在庫数")
                Else
                    builSQL.Append(" ,0")
                End If
                builSQL.Append(" ,@金額管理区分")
                If v_stckFlag Then
                    builSQL.Append(" ,@メーカー番号")
                    builSQL.Append(" ,@仕入金額")
                    builSQL.Append(" ,@在庫数")
                    builSQL.Append(" ,@発注点")
                Else
                    builSQL.Append(" ,@標準時間")
                End If
                builSQL.Append(" )")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL実行履歴 INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlInsGoods(v_param, v_stckFlag))

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

#Region "商品更新"
        ''' <summary>商品（店販対象）の更新</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <param name="v_stckFlag">True:在庫管理あり / False:在庫管理なし</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function CommodityUpdate(ByVal v_param As Habits.DB.DBParameter, ByVal v_stckFlag As Boolean) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("UPDATE C_商品 SET")
                builSQL.Append(" 商品名 = @商品名")
                builSQL.Append(" ,販売金額 = @販売金額")
                builSQL.Append(" ,表示順 = @表示順")
                builSQL.Append(" ,削除フラグ = @削除フラグ")
                builSQL.Append(" ,更新日 = @更新日")
                builSQL.Append(" ,金額管理区分 = @金額管理区分")
                If v_stckFlag Then
                    builSQL.Append(" ,メーカー番号 = @メーカー番号")
                    builSQL.Append(" ,仕入金額 = @仕入金額")
                    builSQL.Append(" ,在庫数 = @在庫数")
                    builSQL.Append(" ,発注点 = @発注点")
                    builSQL.Append(" ,規定在庫数 = @既定在庫数")
                Else
                    builSQL.Append(" ,標準時間 = @標準時間")
                End If
                builSQL.Append(" WHERE 売上区分番号 = @売上区分番号")
                builSQL.Append(" AND 分類番号 = @分類番号")
                builSQL.Append(" AND 商品番号 = @商品番号")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL実行履歴 INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlUpdGoods(v_param, v_stckFlag))

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

#Region "商品削除"
        ''' <summary>商品削除</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function goodsDelete(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("DELETE FROM C_商品")
                builSQL.Append(" WHERE 売上区分番号 = @売上区分番号")
                builSQL.Append(" AND 分類番号 = @分類番号")
                builSQL.Append(" AND 商品番号 = @商品番号")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL実行履歴 INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlDltGoods(v_param))

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

#End Region

#Region "Z_SQL実行履歴（INSERT GOODS）"
        ''' <summary>Z_SQL実行履歴のSQL1生成(INSERT GOODS)</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <param name="v_stckFlag">True:在庫管理あり / False:在庫管理なし</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function getSqlInsGoods(ByVal v_param As Habits.DB.DBParameter, ByVal v_stckFlag As Boolean) As String
            Dim builSQL As New StringBuilder()
            Try
                'Z_SQL実行履歴 SQL1
                builSQL.Length = 0
                builSQL.Append("INSERT INTO goods (")
                builSQL.Append(" shop_code")               '店舗コード
                builSQL.Append(" ,sales_division_code")    '売上区分番号
                builSQL.Append(" ,class_code")             '分類番号
                builSQL.Append(" ,code")                   '商品番号
                builSQL.Append(" ,name")                   '商品名
                If v_stckFlag Then
                    builSQL.Append(" ,maker_code")         'メーカー番号
                    builSQL.Append(" ,cost_price")         '仕入金額
                End If
                builSQL.Append(" ,salling_price")          '販売金額
                If v_stckFlag Then
                    builSQL.Append(" ,stock")              '在庫数
                    builSQL.Append(" ,order_point")        '発注点
                Else
                    builSQL.Append(" ,basic_time")         '標準時間
                End If
                builSQL.Append(" ,display_order")          '表示順
                builSQL.Append(" ,delete_flag")            '削除フラグ
                builSQL.Append(" ,insert_date")            '登録日
                builSQL.Append(" ,update_date")            '更新日
                builSQL.Append(" ,regular_stock")          '既定在庫数
                builSQL.Append(" ,management_tax")         '金額管理区分

                builSQL.Append(" )VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@売上区分番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@分類番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@商品番号")))
                builSQL.Append("," & VbSQLNStr(v_param.GetValue("@商品名")))
                If v_stckFlag Then
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@メーカー番号")))
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@仕入金額")))
                End If
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@販売金額")))

                If v_stckFlag Then
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@在庫数")))
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@発注点")))
                Else
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@標準時間")))
                End If
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@表示順")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@削除フラグ")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@登録日")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@更新日")))
                If v_stckFlag Then
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@既定在庫数")))
                Else
                    builSQL.Append(" ,0")
                End If
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@金額管理区分")))
                builSQL.Append(" )")


                Return builSQL.ToString

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "Z_SQL実行履歴（UPDATE GOODS）"
        ''' <summary>Z_SQL実行履歴のSQL1生成(UPDATE GOODS)</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <param name="v_stckFlag">True:在庫管理あり / False:在庫管理なし</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function getSqlUpdGoods(ByVal v_param As Habits.DB.DBParameter, ByVal v_stckFlag As Boolean) As String
            Dim builSQL As New StringBuilder()
            Try
                'Z_SQL実行履歴 SQL1
                builSQL.Length = 0

                builSQL.Append("UPDATE goods SET")
                builSQL.Append(" name =" & VbSQLNStr(v_param.GetValue("@商品名")))
                builSQL.Append(", salling_price =" & VbSQLStr(v_param.GetValue("@販売金額")))
                If v_stckFlag Then
                    builSQL.Append(", maker_code =" & VbSQLStr(v_param.GetValue("@メーカー番号")))
                    builSQL.Append(", cost_price =" & VbSQLStr(v_param.GetValue("@仕入金額")))
                    builSQL.Append(", stock =" & VbSQLStr(v_param.GetValue("@在庫数")))
                    builSQL.Append(", order_point =" & VbSQLStr(v_param.GetValue("@発注点")))
                    builSQL.Append(", regular_stock =" & VbSQLStr(v_param.GetValue("@既定在庫数")))
                Else
                    builSQL.Append(", basic_time =" & VbSQLStr(v_param.GetValue("@標準時間")))
                End If
                builSQL.Append(", display_order =" & VbSQLStr(v_param.GetValue("@表示順")))
                builSQL.Append(", delete_flag =" & VbSQLStr(v_param.GetValue("@削除フラグ")))
                builSQL.Append(", update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(", management_tax =" & VbSQLStr(v_param.GetValue("@金額管理区分")))

                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@売上区分番号")))
                builSQL.Append(" AND class_code =" & VbSQLStr(v_param.GetValue("@分類番号")))
                builSQL.Append(" AND code =" & VbSQLStr(v_param.GetValue("@商品番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))

                Return builSQL.ToString

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "Z_SQL実行履歴（DELETE GOODS）"
        ''' <summary>Z_SQL実行履歴のSQL1生成(DELETE GOODS)</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function getSqlDltGoods(ByVal v_param As Habits.DB.DBParameter) As String
            Dim builSQL As New StringBuilder()
            Try
                'Z_SQL実行履歴 SQL1
                builSQL.Length = 0

                builSQL.Append("DELETE FROM goods")
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@売上区分番号")))
                builSQL.Append(" AND class_code =" & VbSQLStr(v_param.GetValue("@分類番号")))
                builSQL.Append(" AND code =" & VbSQLStr(v_param.GetValue("@商品番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))

                Return builSQL.ToString

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

    End Class
End Namespace
