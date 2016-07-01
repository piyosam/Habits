#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>入出庫ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a1400_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1400_入出庫登録"

        ''' <summary>売上区分名一覧を取得</summary>
        ''' <returns>売上区分</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetSalesDivisionNames() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT 売上区分番号, 売上区分 FROM B_売上区分 ")
                builSQL.Append(" WHERE B_売上区分.削除フラグ = 0")
                builSQL.Append(" AND EXISTS ( ")
                builSQL.Append(" SELECT * FROM C_分類")
                builSQL.Append(" WHERE C_分類.売上区分番号 = B_売上区分.売上区分番号")
                builSQL.Append(" AND C_分類.店販対象フラグ = 1")
                builSQL.Append(" AND C_分類.削除フラグ = 0 )")
                builSQL.Append(" ORDER BY 表示順,売上区分番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>分類名一覧を取得</summary>
        ''' <param name="v_number">SQLパラメータ：@売上区分番号</param>
        ''' <returns>分類名リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCommodityDivisionNames(ByVal v_number As String) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                builSQL.Append("SELECT 分類番号, 分類名 FROM C_分類")
                builSQL.Append(" WHERE 売上区分番号 = @売上区分番号")
                builSQL.Append(" AND 店販対象フラグ = 1")
                builSQL.Append(" AND 削除フラグ = 0")
                builSQL.Append(" AND EXISTS ( ")
                builSQL.Append(" SELECT * FROM C_商品")
                builSQL.Append(" INNER JOIN C_メーカー ON")
                builSQL.Append(" C_商品.メーカー番号 = C_メーカー.メーカー番号")
                builSQL.Append(" AND C_メーカー.削除フラグ = 0")
                builSQL.Append(" WHERE C_商品.売上区分番号 = C_分類.売上区分番号")
                builSQL.Append(" AND C_商品.分類番号 = C_分類.分類番号")
                builSQL.Append(" AND C_商品.削除フラグ = 0 )")
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

        ''' <summary>メーカー名一覧を取得</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号</param>
        ''' <returns>メーカー名</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetBrandNames(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                builSQL.Append("SELECT メーカー番号, メーカー名 FROM C_メーカー")
                builSQL.Append(" WHERE 削除フラグ = 0")
                builSQL.Append(" AND EXISTS ( ")
                builSQL.Append(" SELECT * FROM C_商品")
                builSQL.Append(" WHERE C_商品.メーカー番号 = C_メーカー.メーカー番号")
                builSQL.Append(" AND C_商品.売上区分番号 = @売上区分番号")
                builSQL.Append(" AND C_商品.分類番号 = @分類番号")
                builSQL.Append(" AND C_商品.削除フラグ = 0 )")
                builSQL.Append(" ORDER BY 表示順,メーカー番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>商品一覧を取得</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号/@メーカー番号</param>
        ''' <returns>商品リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCommodityList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT")
                builSQL.Append(" C_商品.商品番号 AS 番号")
                builSQL.Append(" , C_商品.商品名 AS 商品名")
                builSQL.Append(" , C_商品.在庫数 AS 在庫数")
                builSQL.Append(" , E_入出庫.入出庫日 AS 最新入出庫日")
                builSQL.Append(" , E_入出庫.入出庫番号 AS 入出庫番号")
                builSQL.Append(" , D_担当者.担当者名 AS スタッフ名")
                builSQL.Append(" , B_入出庫区分.入出庫区分 AS 入出庫")
                builSQL.Append(" , B_入出庫理由.入出庫理由 AS 理由")
                builSQL.Append(" , E_入出庫.コメント AS コメント")

                builSQL.Append(" FROM E_入出庫")
                builSQL.Append(" INNER JOIN ( ")
                builSQL.Append("   SELECT")
                builSQL.Append("   E_入出庫.売上区分番号 AS 売上区分番号")
                builSQL.Append("   , E_入出庫.分類番号 AS 分類番号")
                builSQL.Append("   , E_入出庫.商品番号 AS 商品番号")
                builSQL.Append("   , E_入出庫.入出庫日 AS 入出庫日")
                builSQL.Append("   , MAX(E_入出庫.入出庫番号) AS 入出庫番号")
                builSQL.Append("   FROM E_入出庫")
                builSQL.Append("   INNER JOIN (")
                builSQL.Append("     SELECT")
                builSQL.Append("     E_入出庫.売上区分番号 AS 売上区分番号")
                builSQL.Append("     , E_入出庫.分類番号 AS 分類番号")
                builSQL.Append("     , E_入出庫.商品番号 AS 商品番号")
                builSQL.Append("     , MAX(E_入出庫.入出庫日) AS 入出庫日")
                builSQL.Append("     FROM E_入出庫")
                builSQL.Append("     GROUP BY E_入出庫.売上区分番号,E_入出庫.分類番号,E_入出庫.商品番号")
                builSQL.Append("     ) SUB2_入出庫")
                builSQL.Append("     ON E_入出庫.売上区分番号 = SUB2_入出庫.売上区分番号")
                builSQL.Append("     AND E_入出庫.分類番号 = SUB2_入出庫.分類番号")
                builSQL.Append("     AND E_入出庫.商品番号 = SUB2_入出庫.商品番号")
                builSQL.Append("     AND E_入出庫.入出庫日 = SUB2_入出庫.入出庫日")
                builSQL.Append("     GROUP BY E_入出庫.売上区分番号,E_入出庫.分類番号,E_入出庫.商品番号,E_入出庫.入出庫日")
                builSQL.Append("   ) SUB_入出庫")
                builSQL.Append("   ON E_入出庫.売上区分番号 = SUB_入出庫.売上区分番号")
                builSQL.Append("   AND E_入出庫.分類番号 = SUB_入出庫.分類番号")
                builSQL.Append("   AND E_入出庫.商品番号 = SUB_入出庫.商品番号")
                builSQL.Append("   AND E_入出庫.入出庫日 = SUB_入出庫.入出庫日")
                builSQL.Append("   AND E_入出庫.入出庫番号 = SUB_入出庫.入出庫番号")

                builSQL.Append(" RIGHT JOIN C_商品")
                builSQL.Append(" ON E_入出庫.売上区分番号 = C_商品.売上区分番号")
                builSQL.Append(" AND E_入出庫.分類番号 = C_商品.分類番号")
                builSQL.Append(" AND E_入出庫.商品番号 = C_商品.商品番号")

                builSQL.Append(" LEFT JOIN D_担当者")
                builSQL.Append(" ON E_入出庫.担当者番号 = D_担当者.担当者番号")

                builSQL.Append(" LEFT JOIN B_入出庫区分")
                builSQL.Append(" ON E_入出庫.入出庫区分番号 = B_入出庫区分.入出庫区分番号")

                builSQL.Append(" LEFT JOIN B_入出庫理由")
                builSQL.Append(" ON E_入出庫.入出庫理由番号 = B_入出庫理由.入出庫理由番号")

                builSQL.Append(" WHERE C_商品.売上区分番号 = @売上区分番号")
                builSQL.Append(" AND C_商品.分類番号 = @分類番号")
                builSQL.Append(" AND C_商品.メーカー番号 = @メーカー番号")
                builSQL.Append(" AND C_商品.削除フラグ = 0")

                builSQL.Append(" ORDER BY C_商品.表示順 ASC,C_商品.商品番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>入出庫履歴（選択商品）を取得</summary>
        ''' <param name="v_param">SQLパラメータ：@入出庫年月(yyyyMM)/@売上区分番号/@分類番号/@商品番号</param>
        ''' <returns>入出庫情報リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetSelectedStockHistory(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT E_入出庫.入出庫日 AS 入出庫日,")
                builSQL.Append(" E_入出庫.入出庫番号 AS 番号,")
                builSQL.Append(" E_入出庫.入出庫区分番号 AS 入出庫区分番号,")
                builSQL.Append(" B_入出庫区分.入出庫区分 AS 区分,")
                builSQL.Append(" E_入出庫.入出庫理由番号 AS 入出庫理由番号,")
                builSQL.Append(" B_入出庫理由.入出庫理由 AS 理由,")
                builSQL.Append(" E_入出庫.売上区分番号 AS 売上区分番号,")
                builSQL.Append(" B_売上区分.売上区分 AS 売上区分,")
                builSQL.Append(" E_入出庫.分類番号 AS 分類番号,")
                builSQL.Append(" C_分類.分類名 AS 分類名,")
                builSQL.Append(" E_入出庫.商品番号 AS 商品番号,")
                builSQL.Append(" C_商品.商品名 AS 商品名,")
                builSQL.Append(" C_メーカー.メーカー名 AS メーカー名,")
                builSQL.Append(" E_入出庫.入出庫数 AS 数量,")
                builSQL.Append(" E_入出庫.受入金額 AS 受入金額,")
                builSQL.Append(" E_入出庫.担当者番号 AS 担当者番号,")
                builSQL.Append(" D_担当者.担当者名 AS スタッフ名,")
                builSQL.Append(" E_入出庫.コメント AS コメント,")
                builSQL.Append(" E_入出庫.登録日 AS 登録日")
                builSQL.Append(" FROM E_入出庫")

                builSQL.Append(" LEFT JOIN B_売上区分 ON")
                builSQL.Append(" E_入出庫.売上区分番号 = B_売上区分.売上区分番号")

                builSQL.Append(" LEFT JOIN C_分類 ON")
                builSQL.Append(" E_入出庫.売上区分番号 = C_分類.売上区分番号")
                builSQL.Append(" AND E_入出庫.分類番号 = C_分類.分類番号")

                builSQL.Append(" LEFT JOIN B_入出庫区分 ON")
                builSQL.Append(" E_入出庫.入出庫区分番号 = B_入出庫区分.入出庫区分番号")

                builSQL.Append(" LEFT JOIN B_入出庫理由 ON")
                builSQL.Append(" E_入出庫.入出庫理由番号 = B_入出庫理由.入出庫理由番号")

                builSQL.Append(" LEFT JOIN C_商品 ON")
                builSQL.Append(" E_入出庫.売上区分番号 = C_商品.売上区分番号")
                builSQL.Append(" AND E_入出庫.分類番号 = C_商品.分類番号")
                builSQL.Append(" AND E_入出庫.商品番号 = C_商品.商品番号")

                builSQL.Append(" LEFT JOIN C_メーカー ON")
                builSQL.Append(" C_商品.メーカー番号 IS NOT NULL")
                builSQL.Append(" AND C_商品.メーカー番号 = C_メーカー.メーカー番号")

                builSQL.Append(" LEFT JOIN D_担当者 ON")
                builSQL.Append(" E_入出庫.担当者番号 = D_担当者.担当者番号")

                builSQL.Append(" WHERE @入出庫年月 = SUBSTRING(CONVERT(varchar, E_入出庫.入出庫日, 112), 1, 6)")
                builSQL.Append(" AND E_入出庫.売上区分番号 = @売上区分番号")
                builSQL.Append(" AND E_入出庫.分類番号 = @分類番号")
                builSQL.Append(" AND E_入出庫.商品番号 = @商品番号")
                builSQL.Append(" ORDER BY E_入出庫.入出庫日 DESC, E_入出庫.入出庫番号 DESC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>入出庫区分一覧を取得</summary>
        ''' <returns>入出庫区分リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetStockDivision() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT B_入出庫区分.入出庫区分番号 AS 入出庫区分番号,")
                builSQL.Append(" B_入出庫区分.入出庫区分 AS 入出庫区分")
                builSQL.Append(" FROM B_入出庫区分")
                builSQL.Append(" ORDER BY B_入出庫区分.入出庫区分番号 ASC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>入出庫理由一覧を取得</summary>
        ''' <param name="v_number">入出庫区分番号</param>
        ''' <returns>入出庫理由リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetStockReason(ByVal v_number As String) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                builSQL.Append("SELECT B_入出庫理由.入出庫理由番号 AS 入出庫理由番号,")
                builSQL.Append(" B_入出庫理由.入出庫理由 AS 入出庫理由,")
                builSQL.Append(" B_入出庫理由.コメントチェック AS コメントチェック")
                builSQL.Append(" FROM B_入出庫理由")
                builSQL.Append(" WHERE B_入出庫理由.入出庫区分番号 = @入出庫区分番号")
                builSQL.Append(" AND B_入出庫理由.手動設定フラグ = 'True'")
                builSQL.Append(" ORDER BY B_入出庫理由.入出庫理由番号 ASC")

                param.Add("@入出庫区分番号", v_number)
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>担当者一覧を取得</summary>
        ''' <returns>スタッフリスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetStaff() As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT 担当者番号,担当者名")
                builSQL.Append(" FROM D_担当者")
                builSQL.Append(" WHERE 削除フラグ = 'false'")
                builSQL.Append(" ORDER BY 表示順 ASC,担当者番号 ASC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>E_入出庫テーブルの入出庫番号存在確認</summary>
        ''' <param name="v_param">SQLパラメータ：@入出庫日/@入出庫番号</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function IsExistStockNumber(ByVal v_param As Habits.DB.DBParameter) As Boolean
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT 1")
                builSQL.Append(" FROM E_入出庫")
                builSQL.Append(" WHERE 入出庫日 = @入出庫日")
                builSQL.Append(" AND 入出庫番号 = @入出庫番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>入出庫の新規登録</summary>
        ''' <param name="v_hashtable">
        ''' SQLパラメータ(Hashtable)：@入出庫日/@入出庫番号/@入出庫区分番号/@入出庫理由番号
        '''                /@売上区分番号/@分類番号/@商品番号/@入出庫数/@受入金額
        '''                /@担当者番号/@コメント/@登録日
        ''' </param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function StockInsert(ByRef v_hashtable As Hashtable) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter
            Dim tmp_int As Integer = 0

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                '' E_入出庫テーブル登録パラメータ
                param.Clear()
                param.Add("@入出庫日", v_hashtable("@入出庫日"))
                param.Add("@入出庫番号", v_hashtable("@入出庫番号"))
                param.Add("@入出庫区分番号", v_hashtable("@入出庫区分番号"))
                param.Add("@入出庫理由番号", v_hashtable("@入出庫理由番号"))
                param.Add("@売上区分番号", v_hashtable("@売上区分番号"))
                param.Add("@分類番号", v_hashtable("@分類番号"))
                param.Add("@商品番号", v_hashtable("@商品番号"))
                param.Add("@入出庫数", v_hashtable("@入出庫数"))
                param.Add("@受入金額", v_hashtable("@受入金額"))
                param.Add("@担当者番号", v_hashtable("@担当者番号"))
                param.Add("@コメント", v_hashtable("@コメント"))
                param.Add("@登録日", v_hashtable("@登録日"))

                '' E_入出庫テーブルにデータを登録
                builSQL.Append("INSERT INTO E_入出庫 (")
                builSQL.Append(" 入出庫日,")
                builSQL.Append(" 入出庫番号,")
                builSQL.Append(" 入出庫区分番号,")
                builSQL.Append(" 入出庫理由番号,")
                builSQL.Append(" 売上区分番号,")
                builSQL.Append(" 分類番号,")
                builSQL.Append(" 商品番号,")
                builSQL.Append(" 入出庫数,")
                builSQL.Append(" 受入金額,")
                builSQL.Append(" 担当者番号,")
                builSQL.Append(" コメント,")
                builSQL.Append(" 登録日 )")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @入出庫日,")
                builSQL.Append(" @入出庫番号,")
                builSQL.Append(" @入出庫区分番号,")
                builSQL.Append(" @入出庫理由番号,")
                builSQL.Append(" @売上区分番号,")
                builSQL.Append(" @分類番号,")
                builSQL.Append(" @商品番号,")
                builSQL.Append(" @入出庫数,")
                builSQL.Append(" @受入金額,")
                builSQL.Append(" @担当者番号,")
                builSQL.Append(" @コメント,")
                builSQL.Append(" @登録日 )")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("INSERT INTO receive_ship(")
                builSQL.Append("shop_code,")
                builSQL.Append("date,")
                builSQL.Append("code,")
                builSQL.Append("receive_ship_division_code,")
                builSQL.Append("receive_ship_reason_code,")
                builSQL.Append("sales_division_code,")
                builSQL.Append("class_code,")
                builSQL.Append("goods_code,")
                builSQL.Append("count,")
                builSQL.Append("amount,")
                builSQL.Append("basis_staff_code,")
                builSQL.Append("comment,")
                builSQL.Append("insert_date)")

                builSQL.Append("VALUES(")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@入出庫日")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@入出庫番号")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@入出庫区分番号")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@入出庫理由番号")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@売上区分番号")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@分類番号")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@商品番号")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@入出庫数")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@受入金額")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@担当者番号")) & ",")
                builSQL.Append(VbSQLNStr(param.GetValue("@コメント")) & ",")
                builSQL.Append(VbSQLStr(param.GetValue("@登録日")) & ")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)


                ''在庫数増減
                tmp_int = Integer.Parse(v_hashtable("@入出庫数").ToString)
                If String.Equals(v_hashtable("@入出庫区分番号").ToString, "2") Then
                    ''2:出庫の場合
                    tmp_int *= -1
                End If

                '' C_商品テーブル更新パラメータ
                param.Clear()
                param.Add("@入出庫数", tmp_int)
                param.Add("@更新日", v_hashtable("@登録日"))
                param.Add("@売上区分番号", v_hashtable("@売上区分番号"))
                param.Add("@分類番号", v_hashtable("@分類番号"))
                param.Add("@商品番号", v_hashtable("@商品番号"))

                '' C_商品テーブルのデータを登録
                builSQL.Length = 0
                builSQL.Append("UPDATE C_商品 SET")
                builSQL.Append(" 在庫数 = 在庫数  + (@入出庫数),")
                builSQL.Append(" 更新日 = @更新日")
                builSQL.Append(" WHERE 売上区分番号 = @売上区分番号")
                builSQL.Append(" AND 分類番号 = @分類番号")
                builSQL.Append(" AND 商品番号 = @商品番号")

                str_sql = builSQL.ToString
                rtnCnt += DBA.ExecuteNonQuery(str_sql, param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE goods SET")
                builSQL.Append(" stock = stock  + (" & param.GetValue("@入出庫数").ToString & "),")
                builSQL.Append(" update_date =" & VbSQLStr(param.GetValue("@更新日")))
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(param.GetValue("@売上区分番号")))
                builSQL.Append(" AND class_code =" & VbSQLStr(param.GetValue("@分類番号")))
                builSQL.Append(" AND code =" & VbSQLStr(param.GetValue("@商品番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtnCnt
        End Function
    End Class
End Namespace
