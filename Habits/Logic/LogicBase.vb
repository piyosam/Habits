#Region "インポート"
Imports System.Text
Imports Excel = Microsoft.Office.Interop.Excel
#End Region

Namespace Habits.Logic
    ''' <summary>共通ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class LogicBase

#Region "******各テーブル情報処理******"

#Region "A_システムデータ取得"
        ''' <summary>A_システムテーブルデータを取得</summary>
        ''' <returns>A_システム情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function A_System() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                builSQL.Append("SELECT 店舗コード,処理区分,店名1,店名2,代表者名,")
                builSQL.Append("店郵便番号,店住所1,店住所2,店電話番号,店ＦＡＸ番号,")
                builSQL.Append("設備台数,レジ金額,変更日時,")
                builSQL.Append("データ格納パス名, 発注出力パス名,データ抽出出力パス名,")
                builSQL.Append("都道府県,市区町村,通信許可フラグ,月締開始日")
                builSQL.Append(",予備1,予備2,予備3,予備4,予備5,税区分")
                builSQL.Append(" FROM A_システム")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "A_システム出力パス取得"
        ''' <summary>発注出力パス取得</summary>
        ''' <param name="i">1：発注出力パス名更新、2：データ抽出出力パス名更新</param>
        ''' <returns>発注出力パス</returns>
        ''' <remarks></remarks>
        Protected Friend Function getPath(ByVal i As Integer) As String
            Dim dt As DataTable
            Dim str_sql As String
            Dim rtn As String = Nothing
            Try
                If i = 1 Then
                    '発注出力パス名
                    str_sql = "SELECT 発注出力パス名 FROM A_システム"
                Else
                    'データ抽出出力パス
                    str_sql = "SELECT データ抽出出力パス名 FROM A_システム"
                End If
                dt = DBA.ExecuteDataTable(str_sql)
                If dt.Rows.Count > 0 Then
                    rtn = dt.Rows(0)(0).ToString()
                End If
                Return rtn
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "A_システム出力パス更新"
        ''' <summary>発注出力パス取得</summary>
        ''' <param name="i">1：発注出力パス名更新、2：データ抽出出力パス名更新</param>
        ''' <param name="v_param">SQLパラメータ：@発注出力パス名/@変更日時</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_Path(ByVal i As Integer, ByVal v_param As Habits.DB.DBParameter, ByVal PAGE_TITLE As String) As Integer
            Dim dt As Integer
            Dim str_sql As String
            Try
                str_sql = "UPDATE A_システム SET 変更日時 = @変更日時"
                If i = 1 Then
                    str_sql = str_sql + ",発注出力パス名 = @出力パス名"
                Else
                    str_sql = str_sql + ",データ抽出出力パス名 = @出力パス名"
                End If
                dt = DBA.ExecuteNonQuery(str_sql, v_param)

                str_sql = "UPDATE system SET"
                If i = 1 Then
                    str_sql = str_sql + " order_output_path=" & VbSQLNStr(v_param.GetValue("@発注出力パス名"))
                Else
                    str_sql = str_sql + " order_output_path=" & VbSQLNStr(v_param.GetValue("@発注出力パス名"))
                End If
                str_sql = str_sql + ", update_date = " & VbSQLStr(v_param.GetValue("@変更日時")) & " WHERE shop_code=" & VbSQLNStr(sShopcode)
                rtn = InsertZSqlExecHis(PAGE_TITLE, str_sql)

            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "A_システム変数設定"
        ''' <summary>A_システム変数設定</summary>
        ''' <remarks></remarks>
        Protected Friend Sub setA_SystemVariable()
            Dim dt As DataTable = New DataTable
            dt = A_System()
            If dt.Rows.Count = 1 Then
                sShopcode = dt.Rows(0).Item("店舗コード").ToString()
                NETWORK_FLAG = dt.Rows(0).Item("通信許可フラグ").ToString
                TAX_MANAGEMENT_TYPE = dt.Rows(0).Item("税区分").ToString

                If dt.Rows(0).Item("予備1").ToString.Equals("True") Then
                    Visit_Mode = True
                    Cashiers_Mode = True
                End If
            End If
        End Sub
#End Region

#Region "A_システムアップロード/ダウンロードデータ格納パス取得"
        ''' <summary>アップロード/ダウンロードデータ格納パス取得</summary>
        ''' <returns>データ格納パス名</returns>
        ''' <remarks></remarks>
        Protected Friend Function getDataStockPath() As String
            Dim str_sql As String
            Dim dt As DataTable
            Dim rtn As String = ""
            Try
                str_sql = "SELECT データ格納パス名 FROM A_システム"
                dt = DBA.ExecuteDataTable(str_sql)
                If (dt.Rows.Count > 0) Then
                    rtn = dt.Rows(0).Item(0).ToString

                    '/区切りの場合、\区切りに変更
                    rtn = Replace(rtn, "/", "\")

                    '出力先パスの最後に\をつける
                    If rtn.Substring(rtn.Length - 1) <> "\" Then rtn = rtn & "\"

                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "B_天候一覧取得"
        ''' <summary>B_天候一覧を取得</summary>
        ''' <returns>天候リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function B_天候() As DataTable
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                str_sql = "SELECT 天候番号,天候 FROM B_天候 ORDER BY 天候番号"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "B_性別一覧取得"
        ''' <summary>B_性別一覧取得</summary>
        ''' <returns>性別リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function B_性別() As DataTable
            Dim rtn As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 性別番号,性別 FROM B_性別 ORDER BY 性別番号"
                rtn = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "B_登録区分一覧取得"
        ''' <summary>登録区分一覧取得</summary>
        ''' <returns>登録区分名リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function B_登録区分() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 登録区分番号,登録区分 FROM B_登録区分 ORDER BY 登録区分番号"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "B_サービス一覧取得（有効データのみ）"
        ''' <summary>サービス一覧取得</summary>
        ''' <returns>サービスリスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function getService_exclude() As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT サービス番号,サービス名,表示順,削除フラグ,登録日,更新日 FROM B_サービス WHERE 削除フラグ='False' ORDER BY 表示順,サービス番号"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "B_ポイント割引一覧取得（有効データのみ）"
        ''' <summary>ポイント割引一覧取得</summary>
        ''' <returns>ポイント割引リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function getPointService_exclude() As DataTable
            Dim builSQL As New StringBuilder()
            Dim dt As New DataTable
            Dim str_sql As String
            Try
                builSQL.Append("SELECT")
                builSQL.Append(" ポイント割引番号")
                builSQL.Append(" ,ポイント割引名")
                builSQL.Append(" ,表示順")
                builSQL.Append(" ,削除フラグ")
                builSQL.Append(" ,登録日")
                builSQL.Append(" ,更新日")
                builSQL.Append(" FROM B_ポイント割引")
                builSQL.Append(" WHERE  削除フラグ='False'")
                builSQL.Append(" ORDER BY 表示順,ポイント割引番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "B_売上区分一覧取得（無効データ含む）"
        ''' <summary>売上区分番号一覧を取得</summary>
        ''' <returns>売上区分番号リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSalesDiv() As DataTable
            Dim dt As DataTable
            Dim str_sql As String

            Try
                str_sql = "SELECT 売上区分番号,売上区分,表示順,削除フラグ,登録日,更新日 FROM B_売上区分 ORDER BY 表示順,売上区分番号"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

#End Region

#Region "B_売上区分一覧取得（無効データ含まない）"
        ''' <summary>売上区分番号一覧を取得</summary>
        ''' <param name="v_param">@開始日 @終了日</param>
        ''' <returns>売上区分番号リスト</returns>
        ''' <remarks>店集計では無効となっているメニューでも対象期間内に売上があれば選択可能とする。</remarks>
        Protected Friend Function getSalesDiv(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            'Dim str_sql As String
            Dim sbSql As StringBuilder
            Try
                sbSql = New StringBuilder
                sbSql.AppendLine("SELECT DISTINCT")
                sbSql.AppendLine("  売上区分番号,売上区分,表示順,削除フラグ,登録日,更新日")
                sbSql.AppendLine("FROM (")
                sbSql.AppendLine("  SELECT")
                sbSql.AppendLine("    売上区分 + '売上' AS name,")
                sbSql.AppendLine("    CAST(ISNULL(COUNT(MEISAI.売上区分番号),0) AS varchar) AS num,")
                sbSql.AppendLine("    ISNULL(SUM(amount),0) AS amount,")
                sbSql.AppendLine("    B_売上区分.売上区分番号 AS dispOrder")
                sbSql.AppendLine("  FROM (")
                sbSql.AppendLine("    SELECT")
                sbSql.AppendLine("      売上区分番号,SUM(数量 * 金額 - サービス) AS amount")
                sbSql.AppendLine("    FROM E_売上明細")
                sbSql.AppendLine("    WHERE 来店日 >= @開始日 AND 来店日 <= @終了日 AND 会計済 ='1'")
                sbSql.AppendLine("    GROUP BY 来店日,来店者番号,売上区分番号) AS MEISAI RIGHT OUTER JOIN B_売上区分 ON")
                sbSql.AppendLine("      MEISAI.売上区分番号 =B_売上区分.売上区分番号")
                sbSql.AppendLine("    GROUP BY B_売上区分.売上区分番号,売上区分 + '売上'")
                sbSql.AppendLine("  UNION")
                sbSql.AppendLine("  SELECT")
                sbSql.AppendLine("    '('+売上区分 + 'ｻｰﾋﾞｽ)' AS name,")
                sbSql.AppendLine("    CAST(ISNULL(COUNT(MEISAI.売上区分番号),0) AS varchar) AS num,")
                sbSql.AppendLine("    ISNULL(SUM(amount),0) AS amount,")
                sbSql.AppendLine("    B_売上区分.売上区分番号 AS dispOrder")
                sbSql.AppendLine("  FROM (")
                sbSql.AppendLine("    SELECT")
                sbSql.AppendLine("      売上区分番号,SUM(サービス) AS amount")
                sbSql.AppendLine("    FROM E_売上明細")
                sbSql.AppendLine("    WHERE 来店日 >= @開始日 AND 来店日 <= @終了日 AND 会計済 ='1' AND サービス>0")
                sbSql.AppendLine("    GROUP BY 来店日,来店者番号,売上区分番号) AS MEISAI RIGHT OUTER JOIN B_売上区分 ON")
                sbSql.AppendLine("      MEISAI.売上区分番号 =B_売上区分.売上区分番号")
                sbSql.AppendLine("    GROUP BY B_売上区分.売上区分番号,'('+売上区分 + 'ｻｰﾋﾞｽ)'")
                sbSql.AppendLine(") AS A INNER JOIN B_売上区分 ON")
                sbSql.AppendLine("  B_売上区分.売上区分番号 = A.dispOrder")
                sbSql.AppendLine("  WHERE")
                sbSql.AppendLine("  削除フラグ = '0' OR (num > 0 AND amount > 0 AND 削除フラグ = '1')")
                sbSql.AppendLine("  UNION SELECT 売上区分番号,売上区分,表示順,削除フラグ,登録日,更新日 FROM B_売上区分 WHERE 削除フラグ = 'false'")
                sbSql.AppendLine("  ORDER BY 表示順,売上区分番号")
                dt = DBA.ExecuteDataTable(sbSql.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

#End Region

#Region "B_売上区分一覧取得（有効データのみ）"
        ''' <summary>売上区分番号一覧を取得</summary>
        ''' <returns>売上区分番号リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSalesDiv_exclude() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 売上区分番号,売上区分,表示順,削除フラグ,登録日,更新日 FROM B_売上区分 WHERE 削除フラグ = 'false' ORDER BY 表示順,売上区分番号"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "B_売上区分データ取得"
        ''' <summary>売上区分データを取得</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号</param>
        ''' <returns>売上区分情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSalesDiv_One(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 売上区分番号,売上区分,表示順,削除フラグ,登録日,更新日 FROM B_売上区分 WHERE 削除フラグ = 'false' AND 売上区分番号 =@売上区分番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "B_郵便番号郵便番号から市区町村検索"
        ''' <summary>郵便番号にて市区町村検索</summary>
        ''' <param name="v_param">SQLパラメータ：@新郵便番号表示用</param>
        ''' <returns>市区町村名</returns>
        ''' <remarks></remarks>
        Protected Friend Function SearchAddress(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT DISTINCT 都道府県名,市区町村名,町域名 FROM B_郵便番号 WHERE 新郵便番号表示用 LIKE @新郵便番号表示用"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "C_分類一覧取得（有効データのみ）"
        ''' <summary>分類一覧を取得</summary>
        ''' <returns>分類リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function getClass_exclude(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Try

                builSQL.Append("SELECT 分類番号,分類名,店販対象フラグ")
                builSQL.Append(" FROM C_分類")
                builSQL.Append(" WHERE (売上区分番号 = @売上区分番号)")
                builSQL.Append(" AND (削除フラグ='False')")
                builSQL.Append(" ORDER BY 表示順,分類番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "C_メーカー一覧取得（有効データのみ）"
        ''' <summary>メーカー一覧取得</summary>
        ''' <returns>メーカーリスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function getMaker_exclude() As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT メーカー番号,メーカー名,表示順,削除フラグ,登録日,更新日 FROM C_メーカー WHERE 削除フラグ='False' ORDER BY 表示順,メーカー番号"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "D_担当者一覧取得（無効データ含む）"
        ''' <summary>担当者名一覧取得</summary>
        ''' <returns>担当者リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetStaffNameList() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 担当者名 FROM D_担当者 ORDER BY 表示順,担当者番号"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "D_担当者一覧取得（有効データのみ）"
        ''' <summary>担当者名一覧取得</summary>
        ''' <returns>担当者リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function getDStaff_exclude() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                builSQL.Append("SELECT 担当者番号,担当者名,表示順,削除フラグ,登録日,更新日")
                builSQL.Append(" FROM D_担当者")
                builSQL.Append(" WHERE 削除フラグ = 'false'")
                builSQL.Append(" ORDER BY 表示順,担当者番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "D_担当者情報取得"
        ''' <summary>D_担当者取得</summary>
        ''' <param name="v_param">@担当者番号</param>
        ''' <returns>担当者情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function D_担当者取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                str_sql = "SELECT 担当者番号,担当者名,表示順,削除フラグ,登録日,更新日 FROM D_担当者 WHERE 担当者番号=@担当者番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                'ログ出力
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("担当者情報の取得に失敗しました。　" & Chr(13) & Chr(13) & _
                "処理を再度行ってください。　", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "D_新規顧客番号取得"
        ''' <summary>新規顧客番号を取得</summary>
        ''' <returns>最大顧客番号＋１</returns>
        ''' <remarks></remarks>
        Protected Friend Function NewCustomerNumber() As String
            Dim rtn As String = ""
            Dim obj As Object
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                str_sql = "SELECT MAX(顧客番号) + 1 FROM D_顧客 WHERE 顧客番号 < @顧客番号"
                param.Add("@顧客番号", Clng_STFreeNo)

                obj = DBA.ExecuteScalar(str_sql, param)

                If Not IsDBNull(obj) Then
                    rtn = obj.ToString
                Else
                    rtn = "1"
                End If

                If rtn >= Clng_STFreeNo Then
                    str_sql = "SELECT MIN(顧客番号) + 1 FROM D_顧客 WHERE 顧客番号 + 1 NOT IN (SELECT 顧客番号 FROM D_顧客)"
                    obj = DBA.ExecuteScalar(str_sql, param)

                    If Not IsDBNull(obj) Then
                        rtn = obj.ToString
                    Else
                        rtn = "1"
                    End If

                End If
            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "D_顧客カナから顧客情報取得"
        ''' <summary>姓カナ、名カナでD_顧客テーブルを検索</summary>
        ''' <param name="v_seikana">姓カナ</param>
        ''' <param name="v_meikana">名カナ</param>
        ''' <returns>顧客情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function SearchCustomerSeiMei(ByVal v_seikana As String, ByVal v_meikana As String) As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                builSQL.Append("SELECT")
                builSQL.Append(" 顧客番号 AS 番号,")
                builSQL.Append(" 姓 AS 姓, 名 AS 名,")
                builSQL.Append(" D_担当者.担当者名 AS 主担当者,")
                builSQL.Append(" 前回来店日,")
                builSQL.Append(" 住所2 AS 住所")
                builSQL.Append(" FROM D_顧客")
                builSQL.Append(" LEFT OUTER JOIN D_担当者")
                builSQL.Append(" ON D_担当者.担当者番号 = D_顧客.主担当者番号")
                builSQL.Append(" WHERE 姓カナ Like @姓カナ")
                If (v_meikana.Length > 0) Then
                    builSQL.Append(" AND 名カナ Like @名カナ")
                End If
                builSQL.Append(" ORDER BY 姓カナ, 名カナ")

                param.Add("@姓カナ", v_seikana & "%")
                If (v_meikana.Length > 0) Then
                    param.Add("@名カナ", v_meikana & "%")
                End If
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "D_顧客顧客番号から顧客情報取得"
        ''' <summary>顧客番号でD_顧客テーブルを検索</summary>
        ''' <param name="v_number">顧客番号</param>
        ''' <returns>顧客情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCustomerData(ByVal v_number As String) As DataTable
            Dim dt As New DataTable
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                str_sql = "SELECT * FROM D_顧客 WHERE 顧客番号=@顧客番号"

                param.Add("@顧客番号", v_number)
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "D_顧客番号一覧取得"
        ''' <summary>顧客番号一覧取得</summary>
        ''' <param name="v_param">SQLパラメータ：@開始顧客番号/@終了顧客番号</param>
        ''' <returns>顧客番号リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCustomerNum(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 顧客番号 FROM D_顧客 WHERE 顧客番号 BETWEEN @開始顧客番号 AND @終了顧客番号"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "D_顧客情報取得"
        ''' <summary>顧客情報取得</summary>
        ''' <returns>顧客情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCustomerInfo(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT D_顧客.顧客番号 ,D_顧客.姓 ,D_顧客.名 ,D_顧客.姓カナ ,D_顧客.名カナ")
                builSQL.Append(" ,D_顧客.性別番号 ,B_性別.性別 ,D_顧客.生年月日 ,D_顧客.郵便番号")
                builSQL.Append(" ,D_顧客.都道府県 ,D_顧客.住所1 ,D_顧客.住所2 ,D_顧客.住所3")
                builSQL.Append(" ,D_顧客.電話番号 ,D_顧客.Emailアドレス ,D_顧客.家族名 ,D_顧客.趣味")
                builSQL.Append(" ,D_顧客.好きな話題 ,D_顧客.嫌いな話題 ,D_顧客.伝言フラグ ,D_顧客.メモ")
                builSQL.Append(" ,D_顧客.紹介者 ,D_顧客.前回来店日 ,D_顧客.来店日N_1 ,D_顧客.来店日N_2")
                builSQL.Append(" ,D_顧客.来店回数 ,D_顧客.主担当者番号 ,D_担当者.担当者名 ,D_顧客.登録区分番号")
                builSQL.Append(" ,B_登録区分.登録区分,D_顧客.登録日 ,D_顧客.更新日")
                builSQL.Append(" FROM D_顧客")
                builSQL.Append(" LEFT JOIN B_性別 ON D_顧客.性別番号 = B_性別.性別番号")
                builSQL.Append(" LEFT JOIN D_担当者 ON D_顧客.主担当者番号 = D_担当者.担当者番号")
                builSQL.Append(" LEFT JOIN B_登録区分 ON D_顧客.登録区分番号 = B_登録区分.登録区分番号")
                builSQL.Append(" WHERE D_顧客.顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "E_営業日情報取得"
        ''' <summary>営業日情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@営業日</param>
        ''' <returns>営業日情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_営業日(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim str_sql As String
            Dim dt As DataTable
            Try
                str_sql = "SELECT 営業日,スタッフ数,天候番号,レジ金額,登録日,更新日 FROM E_営業日 WHERE 営業日 = @営業日"
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "E_来店者情報取得"
        ''' <summary>来店者情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>来店者情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function getVisiter(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT 来店日")
                builSQL.Append(" ,来店者番号")
                builSQL.Append(" ,顧客番号")
                builSQL.Append(" ,姓")
                builSQL.Append(" ,名")
                builSQL.Append(" ,姓カナ")
                builSQL.Append(" ,住所")
                builSQL.Append(" ,前回来店日")
                builSQL.Append(" ,来店間隔")
                builSQL.Append(" ,主担当者番号")
                builSQL.Append(" ,来店区分番号")
                builSQL.Append(" ,指名")
                builSQL.Append(" ,作業開始")
                builSQL.Append(" ,作業終了")
                builSQL.Append(" ,会計済")
                builSQL.Append(" ,E_来店者.更新日")
                builSQL.Append(" ,予約番号")
                builSQL.Append(" ,E_来店者.ポイント割引番号")
                builSQL.Append(" ,ポイント割引支払")
                builSQL.Append(" ,ポイント割引名")
                builSQL.Append(" ,E_来店者.サービス番号")
                builSQL.Append(" ,E_来店者.サービス区分")
                builSQL.Append(" ,E_来店者.サービス金額")
                builSQL.Append(" ,サービス名")
                builSQL.Append(" FROM E_来店者")
                builSQL.Append(" LEFT OUTER JOIN B_ポイント割引")
                builSQL.Append(" ON B_ポイント割引.ポイント割引番号=E_来店者.ポイント割引番号")
                builSQL.Append(" LEFT OUTER JOIN B_サービス")
                builSQL.Append(" ON B_サービス.サービス番号=E_来店者.サービス番号")
                builSQL.Append(" WHERE 顧客番号=@顧客番号")
                builSQL.Append(" AND 来店日=@来店日")
                builSQL.Append(" AND 来店者番号=@来店者番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                '’例外発生時はロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "E_売上情報取得"
        ''' <summary>E_売上情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@顧客番号</param>
        ''' <returns>売上情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_salestime(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT * FROM E_売上 WHERE 顧客番号 = @顧客番号 AND 来店日 = @来店日"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "M_送受信最終ダウンロード時間取得"
        ''' <summary>M_最終ダウンロード時間取得</summary>
        ''' <returns>最終ダウンロード時間</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetDownloadDate() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT 最終ダウンロード,通信中エラー回数 FROM [M_送受信]"
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "W_スタッフ出勤スタッフ一覧取得"
        '''<summary>W_スタッフテーブルデータを取得</summary>
        ''' <returns>スタッフリスト</returns>
        ''' <remarks>表示順の昇順</remarks>
        Protected Friend Function W_スタッフ() As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                builSQL.Append("SELECT 担当者番号,担当者名,表示順,削除フラグ,登録日,更新日")
                builSQL.Append(" FROM W_スタッフ")
                builSQL.Append(" ORDER BY 表示順,担当者番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "売上スタッフ一覧取得"
        '''<summary>W_スタッフテーブルデータプラスE_売上に存在するスタッフ一覧を取得</summary>
        ''' <param name="v_param">SQLパラメータ：@営業日</param>
        ''' <returns>スタッフリスト</returns>
        ''' <remarks>表示順の昇順</remarks>
        Protected Friend Function W_スタッフPlus_E_売上(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Try
                builSQL.Append("SELECT 担当者番号,担当者名,表示順 FROM W_スタッフ")

                builSQL.Append(" UNION SELECT 担当者番号,担当者名,表示順")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" LEFT OUTER JOIN D_担当者")
                builSQL.Append(" ON E_売上.主担当者番号 = D_担当者.担当者番号")
                builSQL.Append(" WHERE E_売上.来店日 = @営業日")

                builSQL.Append(" UNION SELECT 担当者番号,担当者名,表示順")
                builSQL.Append(" FROM E_売上明細")
                builSQL.Append(" LEFT OUTER JOIN D_担当者")
                builSQL.Append(" ON E_売上明細.売上担当者番号 = D_担当者.担当者番号")
                builSQL.Append(" WHERE E_売上明細.来店日 = @営業日")

                builSQL.Append(" UNION SELECT 担当者番号,D_担当者.担当者名,表示順")
                builSQL.Append(" FROM E_ポイント")
                builSQL.Append(" LEFT OUTER JOIN D_担当者")
                builSQL.Append(" ON E_ポイント.担当者コード = D_担当者.担当者番号")
                builSQL.Append(" WHERE E_ポイント.来店日 = @営業日")

                builSQL.Append(" ORDER BY 表示順,担当者番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "Z_SQL新規処理番号取得"
        ''' <summary>Z_SQL新規処理番号を取得</summary>
        ''' <returns>最大処理番号＋１</returns>
        ''' <remarks></remarks>
        Protected Friend Function NewSQLNumber() As Integer
            Dim rtn As Integer = 0
            Dim obj As Object
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                str_sql = "SELECT MAX(処理番号) + 1 FROM Z_SQL実行履歴"
                obj = DBA.ExecuteScalar(str_sql, param)

                If Not IsDBNull(obj) Then
                    rtn = obj.ToString
                End If
            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#End Region

#Region "******レシート印刷系処理******"

#Region "W_レシートデータ取得"
        ''' <summary>レシート取得</summary>
        ''' <returns>レシート情報</returns>
        ''' <remarks>レシート出力に使用</remarks>
        Protected Friend Function getReceiptInfo() As DataTable
            Dim dt As DataTable
            Dim param As New Habits.DB.DBParameter
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT W_レシート.番号")
                builSQL.Append(" ,W_レシート.データタイプ")
                builSQL.Append(" ,W_レシート.氏名")
                builSQL.Append(" ,W_レシート.主担当者名")
                builSQL.Append(" ,W_レシート.品名")
                builSQL.Append(" ,W_レシート.数量")
                builSQL.Append(" ,W_レシート.金額")
                builSQL.Append(" ,W_レシート.小計")
                builSQL.Append(" ,W_レシート.消費税")
                builSQL.Append(" ,W_レシート.合計")
                builSQL.Append(" ,W_レシート.お釣り")
                builSQL.Append(" ,A_システム.店名1")
                builSQL.Append(" ,A_システム.店名2")
                builSQL.Append(" ,A_システム.店住所1")
                builSQL.Append(" ,A_システム.店住所2")
                builSQL.Append(" ,REPLACE(REPLACE(REPLACE(")
                builSQL.Append(" REPLACE(REPLACE(REPLACE(")
                builSQL.Append(" REPLACE(REPLACE(REPLACE(")
                builSQL.Append(" REPLACE(A_システム.店電話番号,'9','９'),")
                builSQL.Append(" '8','８'),'7','７'),'6','６'),")
                builSQL.Append(" '5','５'),'4','４'),'3','３'),")
                builSQL.Append(" '2','２'),'1','１'),'0','０') AS 店電話番号")
                builSQL.Append(" FROM W_レシート")
                builSQL.Append(" CROSS JOIN A_システム")
                builSQL.Append(" ORDER BY W_レシート.番号")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "W_レシート追加"
        ''' <summary>W_レシート追加</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function insertW_Receipt(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("INSERT INTO W_レシート(")
                builSQL.Append(" データタイプ")
                builSQL.Append(" ,番号")
                builSQL.Append(" ,氏名")
                builSQL.Append(" ,主担当者名")
                builSQL.Append(" ,品名")
                builSQL.Append(" ,数量")
                builSQL.Append(" ,金額")
                builSQL.Append(" ,小計")
                builSQL.Append(" ,消費税")
                builSQL.Append(" ,合計")
                builSQL.Append(" ,お釣り")

                builSQL.Append(" )VALUES(")
                builSQL.Append(" @データタイプ")
                builSQL.Append(" ,@番号")
                builSQL.Append(" ,@氏名")
                builSQL.Append(" ,@主担当者名")
                builSQL.Append(" ,@品名")
                builSQL.Append(" ,@数量")
                builSQL.Append(" ,@金額")
                builSQL.Append(" ,@小計")
                builSQL.Append(" ,@消費税")
                builSQL.Append(" ,@合計")
                builSQL.Append(" ,@お釣り")
                builSQL.Append(" )")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "W_レシート削除"
        ''' <summary>W_レシート削除</summary>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function W_レシート削除() As Integer
            Dim rtn As Integer = 0
            Dim str_sql As String
            Try
                str_sql = "DELETE FROM W_レシート"
                rtn = DBA.ExecuteNonQuery(str_sql)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "D_顧客取得"
        ''' <summary>店舗情報取得</summary>
        ''' <returns>店舗情報</returns>
        ''' <remarks>レシート出力に使用</remarks>
        Protected Friend Function getReceipt() As DataTable
            Return getReceiptInfo()
        End Function
#End Region

#Region "ブランクレシート印刷"
        ''' <summary>ブランクレシート印刷</summary>
        ''' <remarks>ブランクレシートを印刷する</remarks>
        Protected Friend Sub printBlankReceipt(ByVal amount As Integer, ByVal tax As Integer)
            '  引数：
            '       レポート名
            '       データソース名
            '       データソース
            '       プリンタ True：いつも使うプリンター False: 設定されたプリンタ
            '       0:印刷 / 1:プレビュー
            '       印刷の向き True：横 / False:縦
            '       印刷サイズ
            rtn = Rep_Print("c0501_領収書.rdlc", "DS0001_ブランクレシート", getBlankReceipt(amount, tax), False, 0, False, 2)
        End Sub
#End Region

#Region "ブランクレシート情報取得"
        ''' <summary>ブランクレシート情報取得</summary>
        ''' <returns>ブランクレシート情報</returns>
        ''' <remarks>ブランクレシート出力に使用</remarks>
        Protected Friend Function getBlankReceipt(ByVal amount As Integer, ByVal tax As Integer) As DataTable

            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim param As New Habits.DB.DBParameter
            Dim str_sql As String
            Dim company As String = ""
            Try
                param.Add("@社名", My.Settings.CompanyName.ToString)
                param.Add("@金額", amount)
                param.Add("@消費税", tax)

                builSQL.Append("SELECT 1 AS データタイプ")
                'builSQL.Append(" ,@社名 AS 社名")
                builSQL.Append(" ,A_システム.店名1 AS 店名1")
                builSQL.Append(" ,A_システム.店名2 AS 店名2")
                builSQL.Append(" ,A_システム.店住所1 AS 店住所1")
                builSQL.Append(" ,A_システム.店住所2 AS 店住所2")
                builSQL.Append(" ,REPLACE(REPLACE(REPLACE(")
                builSQL.Append(" REPLACE(REPLACE(REPLACE(")
                builSQL.Append(" REPLACE(REPLACE(REPLACE(")
                builSQL.Append(" REPLACE(A_システム.店電話番号,'9','９'),")
                builSQL.Append(" '8','８'),'7','７'),'6','６'),")
                builSQL.Append(" '5','５'),'4','４'),'3','３'),")
                builSQL.Append(" '2','２'),'1','１'),'0','０') AS 店電話番号")
                builSQL.Append(" ,@金額 AS 金額")
                builSQL.Append(" ,@消費税 AS 消費税")
                builSQL.Append(" FROM A_システム")

                If (My.Settings.PrinterLogoFlag = 0) Then
                    builSQL.Append(" UNION SELECT 0 AS データタイプ")
                    'builSQL.Append(" ,@社名 AS 社名")
                    builSQL.Append(" ,@社名 AS 店名1")
                    builSQL.Append(" ,'' AS 店名2")
                    builSQL.Append(" ,'' AS 店住所1")
                    builSQL.Append(" ,'' AS 店住所2")
                    builSQL.Append(" ,'' AS 店電話番号")
                    builSQL.Append(" ,'' AS 金額")
                    builSQL.Append(" ,'' AS 消費税")
                    builSQL.Append(" ORDER BY データタイプ")
                End If
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#End Region

#Region "******売上系処理******"

#Region "売上明細取得"
        ''' <summary>
        ''' 売上明細取得
        ''' </summary>
        ''' <param name="v_param">パラメータ：@来店日、@顧客番号、@来店者番号</param>
        ''' <returns>売上明細情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_売上明細売上番号取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT 売上番号,売上担当者番号 AS 担当者番号")
                builSQL.Append(" FROM E_売上明細")
                builSQL.Append(" WHERE 来店日 = @来店日")
                builSQL.Append(" AND 顧客番号 = @顧客番号")
                builSQL.Append(" AND 来店者番号 = @来店者番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "売上一覧取得"
        ''' <summary>売上一覧取得</summary>
        ''' <returns>売上詳細リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSalesList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("SELECT E_売上明細.売上番号")
                builSQL.Append(" ,C_分類.分類名")
                builSQL.Append(" ,C_商品.商品名")
                builSQL.Append(" ,E_売上明細.数量 AS 編集数量")
                builSQL.Append(" ,E_売上明細.数量 * E_売上明細.金額 AS 編集金額")
                builSQL.Append(" ,CASE WHEN E_売上明細.サービス = 0 THEN CONVERT(varchar,E_売上明細.サービス) ELSE E_売上明細.サービス * -1 END AS 編集サービス")
                builSQL.Append(" ,(E_売上明細.数量 * E_売上明細.金額)+(CASE WHEN E_売上明細.サービス = 0 THEN CONVERT(varchar,E_売上明細.サービス) ELSE E_売上明細.サービス * -1 END) AS 小計")
                builSQL.Append(" ,D_担当者.担当者名")
                builSQL.Append(" ,E_売上明細.消費税")
                builSQL.Append(" FROM E_売上明細")
                builSQL.Append(" INNER JOIN D_担当者 ON E_売上明細.売上担当者番号 = D_担当者.担当者番号")
                builSQL.Append(" INNER JOIN C_商品 ON E_売上明細.名称番号 = C_商品.商品番号")
                builSQL.Append(" AND E_売上明細.売上区分番号 = C_商品.売上区分番号")
                builSQL.Append(" AND E_売上明細.分類番号 = C_商品.分類番号")
                builSQL.Append(" INNER JOIN C_分類 ON E_売上明細.分類番号 = C_分類.分類番号")
                builSQL.Append(" AND E_売上明細.売上区分番号 = C_分類.売上区分番号")
                builSQL.Append(" WHERE E_売上明細.来店日 = @来店日")
                builSQL.Append(" AND E_売上明細.来店者番号 = @来店者番号")
                builSQL.Append(" AND E_売上明細.顧客番号 = @顧客番号")
                builSQL.Append(" ORDER BY E_売上明細.売上区分番号, E_売上明細.売上番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "売上明細存在チェック"
        ''' <summary>売上明細存在チェック</summary>
        ''' <param name="v_param">パラメータ</param>
        ''' <param name="paid_flag">会計済の抽出条件（0：全て、1：会計済のみ、2：未会計のみ）</param>
        ''' <returns>存在数</returns>
        ''' <remarks></remarks>
        Protected Friend Function chkSalesDetails(ByVal v_param As Habits.DB.DBParameter, ByVal paid_flag As Integer) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Dim rtn As Integer = 0
            Try
                builSQL.Append("SELECT COUNT(来店者番号) FROM E_売上明細")
                builSQL.Append(" WHERE 来店日=@来店日")
                builSQL.Append(" AND 来店者番号=@来店者番号")
                builSQL.Append(" AND 顧客番号=@顧客番号")
                Select Case paid_flag
                    Case 1
                        builSQL.Append(" AND 会計済='true'")
                    Case 2
                        builSQL.Append(" AND 会計済='false'")
                End Select

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
                If dt.Rows.Count > 0 Then
                    rtn = dt.Rows(0).Item(0).ToString()
                End If
            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "入出庫取消し情報取得"
        '''<summary>E_入出庫取消情報取得</summary>
        ''' <param name="v_param">@売上番号/@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>売上数量情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_入出庫取消情報取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                '入出庫の取消有無を判定
                'C_分類：店販対象フラグ=TrueかつE_売上明細：会計済=Trueの場合
                'E_売上明細から売上区分番号, 分類番号, 商品番号, 数量を返す
                builSQL.Append("SELECT")
                builSQL.Append(" E_売上明細.売上区分番号 AS 売上区分番号")
                builSQL.Append(" , E_売上明細.分類番号 AS 分類番号")
                builSQL.Append(" , E_売上明細.名称番号 AS 商品番号")
                builSQL.Append(" , E_売上明細.数量 AS 数量")
                builSQL.Append(" , E_売上明細.売上担当者番号 AS 売上担当者番号")
                builSQL.Append(" FROM E_売上明細")
                builSQL.Append(" INNER JOIN C_分類")
                builSQL.Append(" ON E_売上明細.売上区分番号 = C_分類.売上区分番号")
                builSQL.Append(" AND E_売上明細.分類番号 = C_分類.分類番号")
                builSQL.Append(" WHERE")
                builSQL.Append(" C_分類.店販対象フラグ = 1")
                builSQL.Append(" AND E_売上明細.来店日 = @来店日")
                builSQL.Append(" AND E_売上明細.来店者番号 = @来店者番号")
                builSQL.Append(" AND E_売上明細.顧客番号 = @顧客番号")
                builSQL.Append(" AND E_売上明細.会計済 = 1")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "次の入出庫番号（最大値+1）を取得"
        ''' <summary>次の入出庫番号（最大値+1）を取得</summary>
        ''' <param name="v_date">入出庫日("yyyy/MM/dd")</param>
        ''' <returns>入出庫番号</returns>
        ''' <remarks>初期の入出庫番号=1とする</remarks>
        Protected Friend Function E_次入出庫番号取得(ByVal v_date As Date) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Dim param As New Habits.DB.DBParameter

            Dim const_開始入出庫番号 As Integer = 1
            Dim rtn As Integer = -1

            Try
                param.Clear()
                param.Add("@入出庫日", v_date)

                builSQL.Append("SELECT MAX(入出庫番号) AS 入出庫番号")
                builSQL.Append(" FROM E_入出庫")
                builSQL.Append(" WHERE DATEDIFF(d, @入出庫日, 入出庫日) = 0")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)

                If dt.Rows.Count = 0 Then
                    rtn = const_開始入出庫番号
                Else
                    If IsDBNull(dt.Rows(0).Item("入出庫番号")) Then
                        rtn = const_開始入出庫番号
                    Else
                        rtn = CLng(dt.Rows(0)("入出庫番号").ToString) + 1
                    End If
                End If

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "Z_SQL実行履歴のSQL1生成(goods)"
        ''' <summary>
        ''' Z_SQL実行履歴のSQL1生成(goods)
        ''' </summary>
        ''' <param name="v_param">SQLパラメータ：@在庫登録数/@更新日/@売上区分番号/@分類番号/@商品番号</param>
        ''' <returns>SQL1</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSqlUpGoods(ByVal v_param As Habits.DB.DBParameter) As String
            Dim builSQL As New StringBuilder()
            Try
                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE goods SET")
                builSQL.Append(" stock=stock + (" & v_param.GetValue("@在庫登録数").ToString & ")")
                builSQL.Append(",update_date = " & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE sales_division_code=" & VbSQLStr(v_param.GetValue("@売上区分番号")))
                builSQL.Append(" AND class_code=" & VbSQLStr(v_param.GetValue("@分類番号")))
                builSQL.Append(" AND code=" & VbSQLStr(v_param.GetValue("@商品番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                Return builSQL.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "過去来店日の売上情報取得"
        ''' <summary>過去来店日の売上情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@顧客番号</param>
        ''' <returns>顧客番号</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_LastDateSales(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT * FROM E_売上 WHERE 顧客番号 = @顧客番号 AND 来店日 < @来店日 ORDER BY 来店日"
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "来店取消し時D_顧客テーブル更新"
        ''' <summary>来店取り消し時のD_顧客テーブル更新</summary>
        ''' <param name="v_param">SQLパラメータ：@来店回数/@顧客番号/@更新日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function DelCustomer_kaikeizumi(ByVal v_param As Habits.DB.DBParameter, ByVal title As String) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("UPDATE D_顧客 SET")
                builSQL.Append(" 更新日=@更新日,")
                builSQL.Append(" 前回来店日=@前回来店日,")
                builSQL.Append(" 来店日N_1=@来店日N_1,")
                builSQL.Append(" 来店日N_2=@来店日N_2")
                builSQL.Append(" WHERE 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE basis_customer SET")
                builSQL.Append(" update_date=" & VbSQLStr(v_param.GetValue("@更新日")) & ",")
                builSQL.Append(" last_visit_date=" & VbSQLStr(v_param.GetValue("@前回来店日")) & ",")
                builSQL.Append(" one_before_last_visit_date=" & VbSQLStr(v_param.GetValue("@来店日N_1")) & ",")
                builSQL.Append(" two_before_last_visit_date=" & VbSQLStr(v_param.GetValue("@来店日N_2")))
                builSQL.Append(" WHERE code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(title, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "顧客情報戻し"
        ''' <summary>
        ''' 顧客情報を会計前に戻す処理
        ''' </summary>
        ''' <param name="title">画面ID</param>
        ''' <remarks></remarks>
        Protected Friend Sub 顧客情報戻し(ByVal title As String)
            Dim param As New Habits.DB.DBParameter
            Dim param_lastDate As New Habits.DB.DBParameter
            Dim EUR As New DataTable    'E_売上
            Dim EUMS As New DataTable   'E_売上明細
            Dim i As Integer = 0
            Dim dt As New DataTable

            '' D_顧客テーブル更新
            param.Clear()
            param.Add("@顧客番号", CST_CODE)
            dt = GetCustomerInfo(param)

            param.Add("@来店日", USER_DATE)
            EUR = select_salestime(param)

            If dt.Rows(0)("前回来店日").ToString = USER_DATE.ToString("yyyy/MM/dd") AndAlso EUR.Rows.Count < 1 Then
                param.Clear()
                If dt.Rows(0)("来店日N_1").ToString.Equals("") OrElse Len(Trim(dt.Rows(0)("来店日N_1").ToString)) = 0 Then
                    param.Add("@前回来店日", System.DBNull.Value)
                    param.Add("@来店日N_1", System.DBNull.Value)
                    param.Add("@来店日N_2", System.DBNull.Value)
                Else
                    param.Add("@前回来店日", dt.Rows(0)("来店日N_1").ToString)

                    If dt.Rows(0)("来店日N_2").ToString.Equals("") OrElse Len(Trim(dt.Rows(0)("来店日N_2").ToString)) = 0 Then
                        param.Add("@来店日N_1", System.DBNull.Value)
                        param.Add("@来店日N_2", System.DBNull.Value)
                    Else
                        param.Add("@来店日N_1", dt.Rows(0)("来店日N_2").ToString)
                        param_lastDate.Clear()
                        param_lastDate.Add("@顧客番号", CST_CODE)
                        param_lastDate.Add("@来店日", dt.Rows(0)("来店日N_2").ToString)
                        EUR = select_LastDateSales(param_lastDate)

                        If EUR.Rows.Count > 0 Then
                            param.Add("@来店日N_2", EUR.Rows(EUR.Rows.Count - 1)("来店日").ToString)
                        Else
                            param.Add("@来店日N_2", System.DBNull.Value)
                        End If

                    End If
                End If

                param.Add("@顧客番号", CST_CODE)
                param.Add("@更新日", Now)
                DelCustomer_kaikeizumi(param, title)

            End If

        End Sub
#End Region

#Region "会計済、未会計の更新（E_売上明細）"
        ''' <summary>
        ''' 会計済、未会計の更新（E_売上明細）
        ''' E_売上明細の会計済を会計済または未会計に更新
        ''' </summary>
        ''' <param name="v_param">SQLパラメータ：@更新日/@来店日/@来店者番号/@顧客番号</param>
        ''' <param name="vFlag">会計済フラグ（True：会計済に変更、False：未会計に変更）</param>
        ''' <param name="title" >画面/処理名</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function update会計済_売上明細(ByVal v_param As Habits.DB.DBParameter, ByVal vFlag As Boolean, ByVal title As String) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            builSQL.Append("UPDATE E_売上明細 SET")
            If vFlag Then
                builSQL.Append(" 会計済=1,")
            Else
                builSQL.Append(" 会計済=0,")
            End If
            builSQL.Append(" 更新日 = @更新日")
            builSQL.Append(" WHERE")
            builSQL.Append(" 来店日=@来店日")
            builSQL.Append(" AND 来店者番号=@来店者番号")
            builSQL.Append(" AND 顧客番号=@顧客番号")
            If vFlag Then
                builSQL.Append(" AND 会計済=0")
            Else
                builSQL.Append(" AND 会計済=1")
            End If

            str_sql = builSQL.ToString
            rtn = DBA.ExecuteNonQuery(str_sql, v_param)

            '------------------------------
            'Z_SQL実行履歴 INSERT
            '------------------------------
            rtn = InsertZSqlExecHis(title, getSqlUpSales_detailsPaid_flag(v_param, True))

            Return rtn
        End Function
#End Region

#Region "会計済、未会計の更新（E_来店者）"
        ''' <summary>来店者データ更新（会計済→未会計）</summary>
        ''' <param name="v_param">SQLパラメータ：@更新日/@来店日/@来店者番号/@顧客番号</param>
        ''' <param name="vFlag">会計済フラグ（True：会計済に変更、False：未会計に変更）</param>
        ''' <param name="title" >画面/処理名</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function update会計済_来店者(ByVal v_param As Habits.DB.DBParameter, ByVal vFlag As Boolean, ByVal title As String) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                ''E_来店者にデータを更新
                builSQL.Append("UPDATE E_来店者 SET")
                If vFlag Then
                    builSQL.Append(" 作業終了=@作業終了,")
                    builSQL.Append(" 会計済=1,")
                Else
                    builSQL.Append(" 作業終了=null,")
                    builSQL.Append(" 会計済=0,")
                End If
                builSQL.Append(" 更新日=@更新日")
                builSQL.Append(" WHERE 来店日=@来店日")
                builSQL.Append(" AND 来店者番号=@来店者番号")
                builSQL.Append(" AND 顧客番号=@顧客番号")
                If vFlag Then
                    builSQL.Append(" AND 会計済=0")
                Else
                    builSQL.Append(" AND 会計済=1")
                End If

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                rtn = InsertZSqlExecHis(title, getSqlUpVisitPaid_flag(v_param, vFlag))

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#Region "E_売上削除"
        ''' <summary>E_売上削除</summary>
        ''' <param name="v_param">SQLパラメータ：@更新日/@来店日/@来店者番号/@顧客番号</param>
        ''' <param name="title" >画面/処理名</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_売上削除(ByVal v_param As Habits.DB.DBParameter, ByVal title As String) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                '' E_売上削除
                builSQL.Length = 0
                builSQL.Append("DELETE E_売上")
                builSQL.Append(" WHERE 来店日=@来店日")
                builSQL.Append(" AND 来店者番号=@来店者番号")
                builSQL.Append(" AND 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("DELETE sales")
                builSQL.Append(" WHERE visit_date=" & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append(" AND visit_number=" & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(title, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#End Region

#Region "******在庫上系処理******"

#Region "在庫数の取得"
        ''' <summary>在庫数の取得</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@分類番号/@商品番号</param>
        ''' <returns>在庫数</returns>
        ''' <remarks></remarks>
        Protected Friend Function C_商品在庫数取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable

            Try
                builSQL.Append("SELECT 在庫数 FROM C_商品")
                builSQL.Append(" WHERE 売上区分番号=@売上区分番号")
                builSQL.Append(" AND 分類番号=@分類番号")
                builSQL.Append(" AND 商品番号=@商品番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                'ログ出力
                FileUtil.WriteLogFile(ex.ToString, _
                                                My.Application.Info.DirectoryPath, _
                                                TraceEventType.Error, _
                                                FileUtil.OutPutType.Weekly)

                MsgBox("商品の在庫数取得に失敗しました。　" & Chr(13) & Chr(13) & _
                "処理を再度行ってください。　", Clng_Okexb1, TTL)
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "在庫数調整_戻し"
        '''<summary>在庫数調整_戻し</summary>
        ''' <param name="v_param">@売上番号/@来店日/@来店者番号/@顧客番号/@担当者番号</param>
        ''' <param name="title" >画面ID</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function 在庫数調整_戻し(ByVal v_param As Habits.DB.DBParameter, ByVal title As String) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt_入出庫取消情報 As DataTable
            Dim tmp_int As Integer
            Dim sub_param As New Habits.DB.DBParameter
            Dim i As Integer = 0

            Try
                '入出庫の取消情報取得
                dt_入出庫取消情報 = E_入出庫取消情報取得(v_param)

                '入出庫の取消
                While i < dt_入出庫取消情報.Rows.Count
                    '入出庫の取消ありの場合

                    'E_入出庫に入出庫理由：売上取消のデータを追加
                    sub_param.Clear()
                    sub_param.Add("@入出庫日", v_param.GetValue(0))

                    tmp_int = E_次入出庫番号取得(CDate(v_param.GetValue(0)).ToString("yyyy/MM/dd"))
                    sub_param.Add("@入出庫番号", tmp_int)

                    sub_param.Add("@売上区分番号", dt_入出庫取消情報.Rows(i).Item("売上区分番号"))
                    sub_param.Add("@分類番号", dt_入出庫取消情報.Rows(i).Item("分類番号"))
                    sub_param.Add("@商品番号", dt_入出庫取消情報.Rows(i).Item("商品番号"))
                    sub_param.Add("@入出庫数", dt_入出庫取消情報.Rows(i).Item("数量"))
                    'sub_param.Add("@担当者番号", v_param.GetValue(2))
                    sub_param.Add("@担当者番号", dt_入出庫取消情報.Rows(i).Item("売上担当者番号"))
                    sub_param.Add("@登録日", Now())

                    builSQL.Length = 0
                    builSQL.Append("INSERT INTO E_入出庫")
                    builSQL.Append(" ( 入出庫日")
                    builSQL.Append(" , 入出庫番号")
                    builSQL.Append(" , 入出庫区分番号")
                    builSQL.Append(" , 入出庫理由番号")
                    builSQL.Append(" , 売上区分番号")
                    builSQL.Append(" , 分類番号")
                    builSQL.Append(" , 商品番号")
                    builSQL.Append(" , 入出庫数")
                    builSQL.Append(" , 担当者番号")
                    builSQL.Append(" , 登録日 )")

                    builSQL.Append(" VALUES")
                    builSQL.Append(" (")
                    builSQL.Append(" @入出庫日")
                    builSQL.Append(" , @入出庫番号")
                    builSQL.Append(" , 1")               '1:入庫
                    builSQL.Append(" , 50")              '50:売上取消
                    builSQL.Append(" , @売上区分番号")
                    builSQL.Append(" , @分類番号")
                    builSQL.Append(" , @商品番号")
                    builSQL.Append(" , @入出庫数")
                    builSQL.Append(" , @担当者番号")
                    builSQL.Append(" , @登録日 )")

                    str_sql = builSQL.ToString
                    rtn += DBA.ExecuteNonQuery(str_sql, sub_param)

                    'Z_SQL実行履歴 INSERT
                    InsertZSqlExecHis(title, getSqlInsReceive_ship(sub_param, True))

                    'C_商品の在庫数更新
                    sub_param.Clear()
                    sub_param.Add("@在庫登録数", Integer.Parse(dt_入出庫取消情報.Rows(i).Item("数量")))
                    sub_param.Add("@売上区分番号", dt_入出庫取消情報.Rows(i).Item("売上区分番号"))
                    sub_param.Add("@分類番号", dt_入出庫取消情報.Rows(i).Item("分類番号"))
                    sub_param.Add("@商品番号", dt_入出庫取消情報.Rows(i).Item("商品番号"))
                    sub_param.Add("@更新日", Now)

                    builSQL.Length = 0
                    builSQL.Append("UPDATE C_商品 SET")
                    builSQL.Append(" 在庫数=在庫数 + (@在庫登録数),更新日 = @更新日")
                    builSQL.Append(" WHERE 売上区分番号=@売上区分番号")
                    builSQL.Append(" AND 分類番号=@分類番号")
                    builSQL.Append(" AND 商品番号=@商品番号")

                    str_sql = builSQL.ToString
                    rtn += DBA.ExecuteNonQuery(str_sql, sub_param)

                    'Z_SQL実行履歴 INSERT
                    InsertZSqlExecHis(title, getSqlUpGoods(sub_param))

                    i += 1
                End While

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#End Region

#Region "******ポイント系処理******"

#Region "ポイント情報取得"
        ''' <summary>
        ''' E_ポイント取得
        ''' </summary>
        ''' <param name="v_param">パラメータ：@売上番号、@来店日、@来店者番号、@顧客番号</param>
        ''' <returns>ポイント情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function E_ポイント取得(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Dim builSQL As New StringBuilder()

            Try
                builSQL.Append("SELECT * FROM  E_ポイント WHERE 売上番号=@売上番号")
                builSQL.Append(" AND 来店日=@来店日")
                builSQL.Append(" AND 来店者番号=@来店者番号")
                builSQL.Append(" AND 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "ポイントデータ削除"
        ''' <summary>ポイント削除</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>  
        Protected Friend Function ポイント削除(ByVal v_param As Habits.DB.DBParameter, ByVal title As String) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim rtn As Integer = 0

            Try
                builSQL.Length = 0
                builSQL.Append(" DELETE FROM E_ポイント")
                builSQL.Append(" WHERE 売上番号=@売上番号")
                builSQL.Append(" AND 来店日=@来店日")
                builSQL.Append(" AND 来店者番号=@来店者番号")
                builSQL.Append(" AND 顧客番号=@顧客番号")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("DELETE FROM staff_point")

                builSQL.Append(" WHERE sales_details_code=" & VbSQLStr(v_param.GetValue("@売上番号")))
                builSQL.Append(" AND visit_date=" & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append(" AND visit_number=" & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(title, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try

            Return rtn
        End Function
#End Region

#End Region

#Region "******カルテ一覧表示系処理******"

#Region "カルテ（過去来店日）一覧取得"
        ''' <summary>カルテ情報－過去来店日取得</summary>
        ''' <param name="code">顧客番号</param>
        ''' <returns>カルテ情報一覧</returns>
        ''' <remarks></remarks>
        Protected Friend Function ClinicalRecordHistoryDay(ByVal code As Long) As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim param As New Habits.DB.DBParameter

            Try
                builSQL.Append("SELECT E_売上.来店日")
                builSQL.Append(" ,E_売上.来店者番号")
                builSQL.Append(" ,E_売上.顧客番号")
                builSQL.Append(" ,D_担当者.担当者名")
                builSQL.Append(" ,CASE WHEN E_売上.指名 ='True' THEN '指' ELSE '' END AS 指名")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money, E_売上.現金支払 + E_売上.カード支払 + E_売上.その他支払 + E_売上.ポイント割引支払),1),'.00','') AS 金額文字")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" LEFT JOIN D_担当者")
                builSQL.Append(" ON E_売上.主担当者番号 = D_担当者.担当者番号")
                builSQL.Append(" WHERE E_売上.顧客番号 = @顧客番号")
                builSQL.Append(" ORDER BY E_売上.来店日 DESC ,E_売上.来店者番号 DESC")

                str_sql = builSQL.ToString
                param.Add("@顧客番号", code)
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "カルテ（売上）一覧取得"
        ''' <summary>カルテ情報-売上一覧取得</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <returns>カルテ表示の売上情報リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function ClinicalRecordSales(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT B_売上区分.売上区分 AS 区分")
                builSQL.Append(" ,C_商品.商品名 AS 商品")
                builSQL.Append(" ,RIGHT('   ' + CONVERT(varchar, [数量]), 4) AS 数量")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money,E_売上明細.数量 * E_売上明細.金額),1),'.00','') AS 金額")
                builSQL.Append(" ,CASE WHEN E_売上明細.サービス=0 THEN REPLACE(CONVERT(varchar,CONVERT(money,E_売上明細.サービス),1),'.00','')")
                builSQL.Append(" ELSE REPLACE(CONVERT(varchar,CONVERT(money,E_売上明細.サービス * -1),1),'.00','') END AS ｻｰﾋﾞｽ")
                builSQL.Append(" ,E_売上明細.売上区分番号 AS 売上区分番号")
                builSQL.Append(" FROM (E_売上明細 LEFT JOIN B_売上区分 ON E_売上明細.売上区分番号 = B_売上区分.売上区分番号)")
                builSQL.Append(" LEFT JOIN C_商品 ON E_売上明細.名称番号 = C_商品.商品番号")
                builSQL.Append(" AND E_売上明細.分類番号 = C_商品.分類番号")
                builSQL.Append(" AND E_売上明細.売上区分番号 = C_商品.売上区分番号")
                builSQL.Append(" WHERE E_売上明細.来店日 = @来店日")
                builSQL.Append(" AND E_売上明細.来店者番号 = @来店者番号")
                builSQL.Append(" AND E_売上明細.顧客番号 = @顧客番号")

                builSQL.Append(" UNION ALL")
                builSQL.Append(" SELECT '割引' AS 区分")
                builSQL.Append(" ,B_サービス.サービス名 AS 商品")
                builSQL.Append(" ,'' AS 数量")
                builSQL.Append(" ,'' AS 金額")

                builSQL.Append(" ,CASE WHEN サービス金額=0 THEN REPLACE(CONVERT(varchar,CONVERT(money,サービス金額),1),'.00','')")
                builSQL.Append(" ELSE REPLACE(CONVERT(varchar,CONVERT(money,サービス金額 * -1),1),'.00','') END AS ｻｰﾋﾞｽ")

                builSQL.Append(" ,9999 AS 売上区分番号")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" LEFT OUTER JOIN B_サービス ")
                builSQL.Append(" ON E_売上.サービス番号 = B_サービス.サービス番号")
                builSQL.Append(" WHERE E_売上.来店日 = @来店日")
                builSQL.Append(" AND E_売上.来店者番号 = @来店者番号")
                builSQL.Append(" AND E_売上.顧客番号 = @顧客番号")
                builSQL.Append(" AND E_売上.サービス金額 > 0")
                builSQL.Append(" ORDER BY 売上区分番号 ")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "カルテ（カルテ）一覧取得"
        ''' <summary>カルテ情報-カルテ一覧取得</summary>
        ''' <param name="code">顧客番号</param>
        ''' <returns>カルテ情報一覧</returns>
        ''' <remarks></remarks>
        Protected Friend Function ClinicalRecordInfo(ByVal code As Integer) As DataTable
            Dim dt As New DataTable
            Dim param As New Habits.DB.DBParameter
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                param.Add("@顧客番号", code)

                builSQL.Append("SELECT E_カルテ.来店日")
                builSQL.Append(" ,D_担当者.担当者名")
                builSQL.Append(" ,E_カルテ.カルテ")
                builSQL.Append(" FROM E_カルテ")
                builSQL.Append(" INNER JOIN D_担当者 ON E_カルテ.登録者番号 = D_担当者.担当者番号")
                builSQL.Append(" WHERE E_カルテ.顧客番号=@顧客番号")
                builSQL.Append(" ORDER BY E_カルテ.来店日 DESC ,E_カルテ.来店者番号 DESC")

                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql, param)

            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "カルテデータ削除"
        ''' <summary>E_カルテデータ削除</summary>
        ''' <param name="v_param">SQLパラメータ：@来店日/@来店者番号/@顧客番号</param>
        ''' <remarks></remarks>
        Protected Friend Sub delete_carte(ByVal v_param As Habits.DB.DBParameter, ByVal title As String)
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                str_sql = "DELETE FROM E_カルテ WHERE 顧客番号 = @顧客番号 AND 来店日 = @来店日 AND 来店者番号 = @来店者番号"

                DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("DELETE FROM chart")
                builSQL.Append(" WHERE basis_customer_code =" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND visit_date =" & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append(" AND visit_number =" & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(title, builSQL.ToString)

            Catch ex As Exception
                Throw ex
            End Try
        End Sub
#End Region

#End Region

#Region "******サーバへのアップロード系処理******"

#Region "Z_SQL実行履歴INSERT"
        ''' <summary>
        ''' Z_SQL実行履歴をINSERTする。
        ''' </summary>
        ''' <param name="vPageTitle">ページタイトル</param>
        ''' <param name="SQL1">SQL1</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Function InsertZSqlExecHis(ByVal vPageTitle As String, ByVal SQL1 As String) As Integer
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                builSQL.Append("INSERT INTO Z_SQL実行履歴")
                builSQL.Append("(処理番号")
                builSQL.Append(",画面ID")
                builSQL.Append(",SQL1")
                builSQL.Append(") VALUES (")
                builSQL.Append(NewSQLNumber())
                builSQL.Append(",'" & vPageTitle & "'")
                builSQL.Append(",'" & SQL1 & "')")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql)

                Return rtn

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "項目をSQL用Stringに変換"
        ''' <summary>
        ''' ObjectをSQL用Stringに変換
        ''' </summary>
        ''' <param name="obj">変換対象</param>
        ''' <param name="nullDef">NothingやNullの時に返す値</param>
        ''' <returns>''値''</returns>
        ''' <remarks></remarks>
        Protected Friend Shared Function VbSQLStr(ByVal obj As Object, Optional ByVal nullDef As String = "null") As String
            If obj Is Nothing OrElse obj Is DBNull.Value Then Return nullDef
            Return "''" & CStr(obj) & "''"
        End Function
#End Region

#Region "日本語項目を用Stringに変換"
        ''' <summary>
        ''' Objectを日本語入力可能項目用のSQL用Stringに変換
        ''' </summary>
        ''' <param name="obj">変換対象</param>
        ''' <param name="nullDef">NothingやNullの時に返す値</param>
        ''' <returns>N''値''</returns>
        ''' <remarks></remarks>
        Protected Friend Shared Function VbSQLNStr(ByVal obj As Object, Optional ByVal nullDef As String = "null") As String
            If obj Is Nothing OrElse obj Is DBNull.Value Then Return nullDef
            Return "N''" & VBSQLNewLine(VBSQLEscape(CStr(obj))) & "''"
            Return "N''" & VBSQLEscape(CStr(obj)) & "''"
        End Function
#End Region

#Region "日本語項目を用Stringに変換（テーブルに保管せずそのまま送信する用）"
        ''' <summary>
        ''' Objectを日本語入力可能項目用のSQL用Stringに変換
        ''' </summary>
        ''' <param name="obj">変換対象</param>
        ''' <param name="nullDef">NothingやNullの時に返す値</param>
        ''' <returns>N''値''</returns>
        ''' <remarks></remarks>
        Protected Friend Shared Function VbSQLNStrCSV(ByVal obj As Object, Optional ByVal nullDef As String = "null") As String
            If obj Is Nothing OrElse obj Is DBNull.Value Then Return nullDef
            Return "N'" & VBSQLNewLineCSV(VBSQLEscapeCSV(CStr(obj))) & "'"
            Return "N'" & VBSQLEscapeCSV(CStr(obj)) & "'"
        End Function
#End Region

#Region "エスケープ処理"
        ''' <summary>
        ''' エスケープ処理
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Shared Function VBSQLEscape(ByVal obj As String) As String
            Return Replace(obj, "'", "''''")
        End Function
#End Region

#Region "エスケープ処理（テーブルに保管せずそのまま送信する用）"
        ''' <summary>
        ''' エスケープ処理（テーブルに保管せずそのまま送信する用）
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Shared Function VBSQLEscapeCSV(ByVal obj As String) As String
            Return Replace(obj, "'", "''")
        End Function
#End Region

#Region "改行処理"
        ''' <summary>
        ''' 改行処理
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Shared Function VBSQLNewLine(ByVal obj As String) As String
            Const sNewLineCode As String = "''+nchar(13)+nchar(10)+N''"
            Return Replace(obj, vbCrLf, sNewLineCode)
        End Function
#End Region

#Region "改行処理（テーブルに保管せずそのまま送信する用）"
        ''' <summary>
        ''' 改行処理（テーブルに保管せずそのまま送信する用）
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Friend Shared Function VBSQLNewLineCSV(ByVal obj As String) As String
            Const sNewLineCode As String = "'+nchar(13)+nchar(10)+N'"
            Return Replace(obj, vbCrLf, sNewLineCode)
        End Function
#End Region

#Region "Bool値変換処理"
        ''' <summary>
        ''' Bool値を "1" or "0" で返す
        ''' </summary>
        ''' <param name="vBln">Bool値</param>
        ''' <returns>True : "0", False : "1"</returns>
        ''' <remarks></remarks>
        Protected Friend Shared Function BoolToString(ByVal vBln As Object) As String
            If vBln Is Nothing OrElse vBln Is DBNull.Value Then Return vBln
            If CBool(vBln) Then
                Return "1"
            Else
                Return "0"
            End If
        End Function
#End Region

#Region "SQL1生成共通"

#Region "SQL１作成（売上明細の会計済更新）"
        ''' <summary>
        ''' Z_SQL実行履歴のSQL1生成(Sales_detailsの会計済、未会計の更新)
        ''' </summary>
        ''' <param name="v_param">SQLパラメータ：@更新日/@来店日/@来店者番号/@顧客番号</param>
        ''' <param name="vFlag">会計済みフラグ</param>
        ''' <returns>SQL1</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSqlUpSales_detailsPaid_flag(ByVal v_param As Habits.DB.DBParameter, ByVal vFlag As Boolean) As String
            Dim builSQL As New StringBuilder()
            Try
                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("UPDATE sales_details SET")
                If vFlag Then
                    builSQL.Append(" paid_flag=''1'',")
                Else
                    builSQL.Append(" paid_flag=''0'',")
                End If
                builSQL.Append(" update_date=" & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE visit_date=" & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append(" AND visit_number=" & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append(" AND basis_customer_code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                If vFlag Then
                    builSQL.Append(" AND paid_flag=''0''")
                Else
                    builSQL.Append(" AND paid_flag=''1''")
                End If
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                Return builSQL.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "SQL１作成（来店者の会計済更新）"
        ''' <summary>
        ''' Z_SQL実行履歴のSQL1生成(Visitの会計済、未会計の更新)
        ''' </summary>
        ''' <param name="v_param">SQLパラメータ：@更新日/@来店日/@来店者番号/@顧客番号</param>
        ''' <param name="vFlag">会計済みフラグ</param>
        ''' <returns>SQL1</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSqlUpVisitPaid_flag(ByVal v_param As Habits.DB.DBParameter, ByVal vFlag As Boolean) As String
            Dim builSQL As New StringBuilder()
            Try
                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0

                builSQL.Append("UPDATE visit SET")
                If vFlag Then
                    builSQL.Append(" paid_flag=''1'', end_date=" & VbSQLStr(v_param.GetValue("@作業終了")))
                Else
                    builSQL.Append(" paid_flag=''0'', end_date=Null")
                End If
                builSQL.Append(" ,update_date = " & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(" WHERE basis_customer_code=" & VbSQLStr(v_param.GetValue("@顧客番号")))
                builSQL.Append(" AND number=" & VbSQLStr(v_param.GetValue("@来店者番号")))
                builSQL.Append(" AND date=" & VbSQLStr(v_param.GetValue("@来店日")))
                builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                If vFlag Then
                    builSQL.Append(" AND paid_flag=''0''")
                Else
                    builSQL.Append(" AND paid_flag=''1''")
                End If

                Return builSQL.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "SQL１作成（入出庫更新）"
        ''' <summary>Z_SQL実行履歴のSQL1生成(receive_ship)</summary>
        ''' <param name="v_param">
        ''' SQLパラメータ：@入出庫日/@入出庫番号/@売上区分番号/@分類番号/@商品番号/@入出庫数/@担当者番号/@登録日
        ''' </param>
        ''' <param name="vKbnFixed">True:入出庫区分番号、入出庫理由番号固定値 / False:パラメータ値</param>
        ''' <returns>SQL1</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSqlInsReceive_ship(ByVal v_param As Habits.DB.DBParameter, ByVal vKbnFixed As Boolean) As String
            Dim builSQL As New StringBuilder()
            Try
                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                builSQL.Append("INSERT INTO receive_ship")
                builSQL.Append(" ( shop_code")
                builSQL.Append(" , date")
                builSQL.Append(" , code")
                builSQL.Append(" , receive_ship_division_code")
                builSQL.Append(" , receive_ship_reason_code")
                builSQL.Append(" , sales_division_code")
                builSQL.Append(" , class_code")
                builSQL.Append(" , goods_code")
                builSQL.Append(" , count")
                builSQL.Append(" , amount")
                builSQL.Append(" , basis_staff_code")
                builSQL.Append(" , insert_date )")
                builSQL.Append(" VALUES")
                builSQL.Append(" (")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@入出庫日")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@入出庫番号")))
                If vKbnFixed Then
                    builSQL.Append(", ''1''")               '1:入庫
                    builSQL.Append(", ''50''")              '50:売上取消
                Else
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@入出庫区分番号")))
                    builSQL.Append("," & VbSQLStr(v_param.GetValue("@入出庫理由番号")))
                End If
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@売上区分番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@分類番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@商品番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@入出庫数")))
                builSQL.Append("," & VbSQLStr(0))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@担当者番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@登録日")))
                builSQL.Append(")")

                Return builSQL.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#End Region

#Region "「A_システム」のデータをサーバ側に設定"
        ''' <summary>ローカルのAシステム取得</summary>
        ''' <remarks>
        ''' 緊急時に使用
        ''' トランザクション処理は呼出元で行ってください
        ''' </remarks>
        Protected Friend Function UpDateForSever_System() As Integer

            Dim dt As New DataTable
            Dim strData As String
            Dim builSQL As New StringBuilder()
            Try

                ' A_システムテーブルからデータ取得
                dt = A_System()

                If dt.Rows.Count > 0 Then

                    If Boolean.Parse(dt.Rows(0)("通信許可フラグ").ToString()) = True Then
                        strData = "1"
                    Else
                        strData = "0"
                    End If

                    '------------------------------
                    'Z_SQL実行履歴 INSERT
                    '------------------------------
                    builSQL.Length = 0
                    ' SQL1設定
                    builSQL.Append("UPDATE system SET")
                    builSQL.Append(" shop_code = " & VbSQLNStr(dt.Rows(0)("店舗コード")))
                    builSQL.Append(",action_code = " & VbSQLNStr(dt.Rows(0)("処理区分")))
                    builSQL.Append(",shop_name1 = " & VbSQLNStr(dt.Rows(0)("店名1")))
                    builSQL.Append(",shop_name2 = " & VbSQLNStr(dt.Rows(0)("店名2")))
                    builSQL.Append(",manager = " & VbSQLNStr(dt.Rows(0)("代表者名")))
                    builSQL.Append(",post_code = " & VbSQLNStr(dt.Rows(0)("店郵便番号")))
                    builSQL.Append(",address1 = " & VbSQLNStr(dt.Rows(0)("店住所1")))
                    builSQL.Append(",address2 = " & VbSQLNStr(dt.Rows(0)("店住所2")))
                    builSQL.Append(",phone = " & VbSQLNStr(dt.Rows(0)("店電話番号")))
                    builSQL.Append(",fax = " & VbSQLNStr(dt.Rows(0)("店ＦＡＸ番号")))
                    builSQL.Append(",accommodated_count = " & VbSQLStr(dt.Rows(0)("設備台数")))
                    builSQL.Append(",register_amount = " & VbSQLStr(dt.Rows(0)("レジ金額")))
                    builSQL.Append(",update_date = " & VbSQLStr(dt.Rows(0)("変更日時")))
                    builSQL.Append(",network_data_path = " & VbSQLNStr(dt.Rows(0)("データ格納パス名")))
                    builSQL.Append(",order_output_path = " & VbSQLNStr(dt.Rows(0)("発注出力パス名")))
                    builSQL.Append(",data_output_path = " & VbSQLNStr(dt.Rows(0)("データ抽出出力パス名")))
                    builSQL.Append(",prefectures_name = " & VbSQLNStr(dt.Rows(0)("都道府県")))
                    builSQL.Append(",cities_name = " & VbSQLNStr(dt.Rows(0)("市区町村")))
                    builSQL.Append(",network_flag = " & strData)        ' 通信許可フラグ
                    builSQL.Append(",start_day = " & VbSQLStr(dt.Rows(0)("月締開始日")))
                    builSQL.Append(",dummy1 = " & VbSQLNStr(dt.Rows(0)("予備1")))
                    builSQL.Append(",dummy2 = " & VbSQLNStr(dt.Rows(0)("予備2")))
                    builSQL.Append(",dummy3 = " & VbSQLNStr(dt.Rows(0)("予備3")))
                    builSQL.Append(",dummy4 = " & VbSQLNStr(dt.Rows(0)("予備4")))
                    builSQL.Append(",dummy5 = " & VbSQLNStr(dt.Rows(0)("予備5")))
                    builSQL.Append(",tax_division = " & VbSQLStr(dt.Rows(0)("税区分")))
                    builSQL.Append(" WHERE ")
                    builSQL.Append(" shop_code = " & VbSQLNStr(dt.Rows(0)("店舗コード")))
                    builSQL.Append(" AND action_code = " & VbSQLNStr(dt.Rows(0)("処理区分")))
                    rtn = InsertZSqlExecHis("A_システム取得", builSQL.ToString)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "システムのバージョン情報をサーバ側に設定"
        ''' <summary>システムのバージョン情報取得</summary>
        ''' <remarks>システムロード時に使用</remarks>
        Protected Friend Function SystemVerForSever(ByVal strVer As String) As Integer

            Dim dt As New DataTable
            Dim strData As String
            Dim builSQL As New StringBuilder()
            Try
                ' A_システムテーブルからデータ取得
                dt = A_System()

                If dt.Rows.Count > 0 Then

                    If (strVer.Length <> 0) Then
                        strData = strVer
                    Else
                        strData = "err"
                    End If

                    '------------------------------
                    'Z_SQL実行履歴 INSERT
                    '------------------------------
                    builSQL.Length = 0
                    ' SQL1設定
                    builSQL.Append("UPDATE system SET")
                    builSQL.Append(" dummy4 = " & VbSQLNStr(strData))
                    builSQL.Append(" WHERE ")
                    builSQL.Append(" shop_code = " & VbSQLNStr(dt.Rows(0)("店舗コード")))
                    builSQL.Append("AND action_code = " & VbSQLNStr(dt.Rows(0)("処理区分")))
                    rtn = InsertZSqlExecHis("システムVer取得", builSQL.ToString)
                End If
            Catch ex As Exception
                Throw ex
            End Try

        End Function
#End Region

#End Region

#Region "帳票・Excelファイル出力店舗名データ取得"
        ''' <summary>店舗名取得</summary>
        ''' <returns>店舗名</returns>
        ''' <remarks>帳票・Excelファイル出力時に使用</remarks>
        Protected Friend Function GetShopName() As String
            Dim dt As DataTable
            Dim param As New Habits.DB.DBParameter
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                builSQL.Append("SELECT 店名1 ")
                builSQL.Append(" FROM A_システム")
                str_sql = builSQL.ToString
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt.Rows(0)("店名1")

        End Function
#End Region

#Region "Excelのバージョン情報取得"
        ''' <summary>
        ''' Excelのバージョン情報取得
        ''' </summary>
        ''' <returns>Excelのバージョン</returns>
        ''' <remarks></remarks>
        Protected Friend Function SystemVerForSaveType() As String
            Dim rtn As String = ""
            Dim xlapp As New Excel.Application
            Dim Ver As Decimal
            Ver = CType(xlapp.Version.ToString, Decimal)

            If Ver >= 12 Then
                'Ver2007以上
                rtn = "Excel ブック"
            Else
                rtn = "Microsoft Offics Excel ブック(*.xls)|*.xls"
            End If

            Return rtn
        End Function
#End Region

    End Class
End Namespace

