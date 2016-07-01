#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>作業時間設定（施術時間）画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class f1000_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "f1000_工程"
        Private Enum gdsPrcsNmb As Integer
            dispOrd = 0
            dispOrd1 = 1
            dispOrd2 = 2
        End Enum

        ''' <summary>商品工程情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号/@商品番号</param>
        ''' <returns>商品工程情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function 更新内容(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT C_商品工程.工程番号 AS 番号,B_工程.工程名,")
                builSQL.Append(" B_工程.ポイント,C_商品工程.表示順,")
                builSQL.Append(" B_工程.表示順 AS マスタ表示順")
                builSQL.Append(" FROM C_商品工程")
                builSQL.Append(" JOIN B_工程 ON  C_商品工程.工程番号 = B_工程.工程番号")
                builSQL.Append(" WHERE C_商品工程.売上区分番号 = @売上区分番号")
                builSQL.Append(" AND C_商品工程.分類番号 = @分類番号")
                builSQL.Append(" AND C_商品工程.商品番号 = @商品番号")
                builSQL.Append(" ORDER BY C_商品工程.表示順")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>C_商品工程データ削除</summary>
        ''' <param name="v_param">SQLパラメータ：@更新日/@売上区分番号/@分類番号/@商品番号/@工程番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function C_商品工程削除(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' トランザクション開始
                DBA.TransactionStart()
                builSQL.Length = 0
                builSQL.Append("DELETE FROM C_商品工程")
                builSQL.Append(" WHERE 売上区分番号 = @売上区分番号")
                builSQL.Append(" AND 分類番号 = @分類番号")
                builSQL.Append(" AND 商品番号 = @商品番号")
                builSQL.Append(" AND 工程番号 = @工程番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL実行履歴 INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlDelGoods_process(v_param))

                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>工程情報一覧取得</summary>
        ''' <returns>工程リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function 内容更新() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 工程番号 AS 番号,工程名,ポイント,表示順 FROM W_工程 ORDER BY 表示順,番号"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        ''' <summary>W_工程データ追加</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_工程マスタ() As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                builSQL.Append("INSERT INTO W_工程")
                builSQL.Append(" SELECT 工程番号,")
                builSQL.Append(" 工程名,ポイント,")
                builSQL.Append(" 表示順")
                builSQL.Append(" FROM B_工程")
                builSQL.Append(" WHERE 削除フラグ = 'false'")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>W_工程データ削除</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function delete_W工程() As Integer
            Dim str_sql As String
            Dim rtn As Integer = 0
            Try
                ' トランザクション開始
                DBA.TransactionStart()
                str_sql = "DELETE W_工程 FROM W_工程"
                rtn = DBA.ExecuteNonQuery(str_sql)
                DBA.TransactionCommit()

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function

        ''' <summary>C_商品工程データ追加</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号/@商品番号/@工程番号/@更新日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 工程追加toC_商品工程(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO C_商品工程(")
                builSQL.Append(" 売上区分番号,")
                builSQL.Append(" 分類番号,")
                builSQL.Append(" 商品番号,")
                builSQL.Append(" 工程番号,")
                builSQL.Append(" 表示順,")
                builSQL.Append(" 更新日 )")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @売上区分番号,")
                builSQL.Append(" @分類番号,")
                builSQL.Append(" @商品番号,")
                builSQL.Append(" @工程番号,")
                builSQL.Append(" @表示順,")
                builSQL.Append(" @更新日 )")

                str_sql = builSQL.ToString
                rtnCnt = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("INSERT INTO goods_process(")
                builSQL.Append(" shop_code,")               '店舗コード
                builSQL.Append(" sales_division_code,")     '売上区分番号
                builSQL.Append(" class_code,")              '分類番号
                builSQL.Append(" goods_code,")              '商品番号
                builSQL.Append(" process_code,")            '工程番号
                builSQL.Append(" display_order,")           '表示順
                builSQL.Append(" update_date )")            '更新日
                builSQL.Append(" VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@売上区分番号")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@分類番号")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@商品番号")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@工程番号")) & ",")
                builSQL.Append(VbSQLStr(v_param.GetValue("@表示順")) & ",")
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

        ''' <summary>W_工程データ追加</summary>
        ''' <param name="v_param">SQLパラメータ：@工程番号/@工程名/@ポイント</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 工程追加toW_工程(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtnCnt As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("INSERT INTO W_工程(")
                builSQL.Append(" 工程番号,")
                builSQL.Append(" 工程名,")
                builSQL.Append(" ポイント,")
                builSQL.Append(" 表示順)")

                builSQL.Append(" VALUES (")
                builSQL.Append(" @工程番号,")
                builSQL.Append(" @工程名,")
                builSQL.Append(" @ポイント,")
                builSQL.Append(" @マスタ表示順)")

                str_sql = builSQL.ToString
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

        ''' <summary>W_工程データ削除</summary>
        ''' <param name="v_param">SQLパラメータ：@工程番号/@工程名/@ポイント</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 工程削除fromW_工程(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append(" DELETE FROM W_工程")
                builSQL.Append(" WHERE 工程番号 = @工程番号")
                builSQL.Append(" AND 工程名 = @工程名")
                builSQL.Append(" AND ポイント = @ポイント")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)
                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>W_工程データ削除</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号/@商品番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function マスタ調整(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As Integer

            Try
                ' トランザクション開始
                DBA.TransactionStart()
                builSQL.Append(" DELETE FROM W_工程")
                builSQL.Append(" WHERE 工程番号 IN(")
                builSQL.Append(" SELECT 工程番号 FROM C_商品工程")
                builSQL.Append(" WHERE 売上区分番号 = @売上区分番号")
                builSQL.Append(" AND 分類番号 = @分類番号")
                builSQL.Append(" AND 商品番号 = @商品番号)")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteNonQuery(str_sql, v_param)
                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return dt
        End Function

        ''' <summary>C_商品工程データ表示順変更</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号/@商品番号1/@表示順1/@商品番号2/@表示順2</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 工程表示順変更(ByVal v_param As Habits.DB.DBParameter) As Boolean
            Dim rtn As Boolean = False
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                ' 選択したレコード
                builSQL.Append("UPDATE C_商品工程 SET")
                builSQL.Append(" 表示順 = @表示順1,")
                builSQL.Append(" 更新日 = @更新日")
                builSQL.Append(" WHERE 売上区分番号 = @売上区分番号")
                builSQL.Append(" AND 分類番号 = @分類番号")
                builSQL.Append(" AND 商品番号 = @商品番号")
                builSQL.Append(" AND 工程番号 = @工程番号1")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL実行履歴 INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlUpdGoods_process(v_param, gdsPrcsNmb.dispOrd1))

                builSQL.Length = 0
                builSQL.Append("UPDATE C_商品工程 SET")
                builSQL.Append(" 表示順 = @表示順2,")
                builSQL.Append(" 更新日 = @更新日")
                builSQL.Append(" WHERE 売上区分番号 = @売上区分番号")
                builSQL.Append(" AND 分類番号 = @分類番号")
                builSQL.Append(" AND 商品番号 = @商品番号")
                builSQL.Append(" AND 工程番号 = @工程番号2")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                'Z_SQL実行履歴 INSERT
                InsertZSqlExecHis(PAGE_TITLE, getSqlUpdGoods_process(v_param, gdsPrcsNmb.dispOrd2))

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                '' 例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>C_商品工程データ表示順総変更</summary>
        ''' <param name="salesDiv">売上区分番号</param>
        ''' <param name="classCd">分類番号</param>
        ''' <param name="goodsCd">商品番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 工程表示順変更_ALL(ByVal salesDiv As String, ByVal classCd As String, ByVal goodsCd As String) As Boolean
            Dim rtn As Boolean = False
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim v_param As New Habits.DB.DBParameter
            Dim dt As New DataTable
            Dim i As Integer = 0

            builSQL.Append("UPDATE C_商品工程 SET")
            builSQL.Append(" 表示順 = @表示順,")
            builSQL.Append(" 更新日 = @更新日")
            builSQL.Append(" WHERE 売上区分番号 = @売上区分番号")
            builSQL.Append(" AND 分類番号 = @分類番号")
            builSQL.Append(" AND 商品番号 = @商品番号")
            builSQL.Append(" AND 工程番号 = @工程番号")
            str_sql = builSQL.ToString

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                ' 商品の全工程レコード取得
                v_param.Add("@売上区分番号", salesDiv)
                v_param.Add("@分類番号", classCd)
                v_param.Add("@商品番号", goodsCd)
                dt = 更新内容(v_param)

                Do While i < dt.Rows.Count
                    v_param.Clear()
                    v_param.Add("@表示順", i + 1)
                    v_param.Add("@更新日", Now)
                    v_param.Add("@売上区分番号", salesDiv)
                    v_param.Add("@分類番号", classCd)
                    v_param.Add("@商品番号", goodsCd)
                    v_param.Add("@工程番号", dt.Rows(i)(0).ToString)
                    str_sql = builSQL.ToString

                    rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                    'Z_SQL実行履歴 INSERT
                    InsertZSqlExecHis(PAGE_TITLE, getSqlUpdGoods_process(v_param, gdsPrcsNmb.dispOrd))

                    i += 1
                Loop

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                '' 例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

        ''' <summary>[C_商品工程]最大表示順取得</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号/@商品番号</param>
        ''' <returns>商品工程情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetMaxCount_商品工程(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim dt As DataTable
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT MAX(表示順)")
                builSQL.Append(" FROM C_商品工程")
                builSQL.Append(" WHERE C_商品工程.売上区分番号 = @売上区分番号")
                builSQL.Append(" AND C_商品工程.分類番号 = @分類番号")
                builSQL.Append(" AND C_商品工程.商品番号 = @商品番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            If dt.Rows.Count > 0 AndAlso Not String.IsNullOrEmpty(dt.Rows(0)(0).ToString()) Then
                rtn = dt.Rows(0)(0)
            End If
            Return rtn
        End Function

        ''' <summary>Z_SQL実行履歴のSQL1生成(goods_processのDelete)</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号/@商品番号/@工程番号</param>
        ''' <returns>SQL1</returns>
        ''' <remarks></remarks>
        Private Function getSqlDelGoods_process(ByVal v_param As Habits.DB.DBParameter) As String
            Dim builSQL As New StringBuilder()
            Try
                'Z_SQL実行履歴 SQL1
                builSQL.Length = 0
                builSQL.Append(" DELETE FROM goods_process")
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@売上区分番号")))
                builSQL.Append(" AND class_code =" & VbSQLStr(v_param.GetValue("@分類番号")))
                builSQL.Append(" AND goods_code =" & VbSQLStr(v_param.GetValue("@商品番号")))
                builSQL.Append(" AND process_code =" & VbSQLStr(v_param.GetValue("@工程番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))

                Return builSQL.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''' <summary>Z_SQL実行履歴のSQL1生成(goods_processのUpdate)</summary>
        ''' <param name="v_param">SQLパラメータ：@表示順/@更新日/@売上区分番号/@分類番号/@商品番号/@工程番号</param>
        ''' <param name="v_kbn">表示順、工程番号のパラメータ区分</param>
        ''' <returns>SQL1</returns>
        ''' <remarks></remarks>
        Private Function getSqlUpdGoods_process(ByVal v_param As Habits.DB.DBParameter, ByVal v_kbn As gdsPrcsNmb) As String
            Dim builSQL As New StringBuilder()
            Dim dispName As String = "@表示順"
            Dim prsName As String = "@工程番号"
            Try
                Select Case v_kbn
                    Case gdsPrcsNmb.dispOrd
                        dispName = "@表示順"
                        prsName = "@工程番号"
                    Case gdsPrcsNmb.dispOrd1
                        dispName = "@表示順1"
                        prsName = "@工程番号1"
                    Case gdsPrcsNmb.dispOrd2
                        dispName = "@表示順2"
                        prsName = "@工程番号2"
                End Select

                'Z_SQL実行履歴 SQL1
                builSQL.Length = 0
                builSQL.Append("UPDATE goods_process SET")
                builSQL.Append(" display_order =" & VbSQLStr(v_param.GetValue(dispName)))
                builSQL.Append(" ,update_date =" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE sales_division_code =" & VbSQLStr(v_param.GetValue("@売上区分番号")))
                builSQL.Append(" AND class_code =" & VbSQLStr(v_param.GetValue("@分類番号")))
                builSQL.Append(" AND goods_code =" & VbSQLStr(v_param.GetValue("@商品番号")))
                builSQL.Append(" AND process_code =" & VbSQLStr(v_param.GetValue(prsName)))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))

                Return builSQL.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace
