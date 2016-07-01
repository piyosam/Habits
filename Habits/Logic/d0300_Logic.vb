#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>店集計画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class d0300_Logic
        Inherits Habits.Logic.LogicBase

        Private builSQL As New StringBuilder()

#Region "テーブル削除"
        ''' <summary>削除テーブル：W_目標、W_支払</summary>
        ''' <remarks></remarks>
        Protected Friend Sub deleteWkTbl()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                'W_目標テーブル削除
                str_sql = "DELETE FROM W_目標"
                DBA.ExecuteNonQuery(str_sql)

                'W_支払テーブル削除
                str_sql = "DELETE FROM W_支払"
                DBA.ExecuteNonQuery(str_sql)

                DBA.TransactionCommit()
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Sub
#End Region

#Region "レシート情報取得"
        ''' <summary>レシートに印刷する情報を取得する</summary>
        ''' <param name="v_param">SQLパラメータ：@精算日</param>
        ''' <returns>レシート情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function レシート移入(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As New DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT")
                builSQL.Append(" 1 AS データタイプ")
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
                builSQL.Append(" ,@精算日 AS 精算日")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money,(W_支払.総客本)),1),'.00','') AS 客数")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money,(W_支払.現金本)),1),'.00','') AS 現金入金")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money,(W_支払.カード本)),1),'.00','') AS 現金外入金")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money,(W_支払.その他本 + W_支払.ポイント割引本)),1),'.00','') AS その他")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money,(W_支払.消費税本)),1),'.00','') AS 売上消費税")
                builSQL.Append(" ,REPLACE(CONVERT(varchar,CONVERT(money,(W_支払.現金本 + W_支払.カード本 + W_支払.その他本 + W_支払.ポイント割引本 - W_支払.消費税本)),1),'.00','') AS 純売上")
                builSQL.Append(" FROM A_システム,W_支払")

                If (My.Settings.PrinterLogoFlag = 0) Then
                    builSQL.Append(" UNION SELECT 0 AS データタイプ")
                    builSQL.Append(" ,@社名 AS 店名1")
                    builSQL.Append(" ,'' AS 店名2")
                    builSQL.Append(" ,'' AS 店住所1")
                    builSQL.Append(" ,'' AS 店住所2")
                    builSQL.Append(" ,'' AS 店電話番号")
                    builSQL.Append(" ,'' AS 精算日")
                    builSQL.Append(" ,'' AS 客数")
                    builSQL.Append(" ,'' AS 現金入金")
                    builSQL.Append(" ,'' AS 現金外入金")
                    builSQL.Append(" ,'' AS その他")
                    builSQL.Append(" ,'' AS 売上消費税")
                    builSQL.Append(" ,'' AS 純売上")
                    builSQL.Append(" ORDER BY データタイプ")
                End If

                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "売上区分一覧取得"
        ''' <summary>売上区分一覧取得</summary>
        ''' <returns>売上区分リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function getSalesDivList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.getSalesDiv(v_param)
        End Function
#End Region

#Region "目標額情報取得"
        ''' <summary>目標額情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@対象年月</param>
        ''' <returns>目標額情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_E_目標額(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append(" SELECT E_目標額.売上区分番号,売上区分,ISNULL(目標額,0) AS 目標額,営業日数")
                builSQL.Append(" FROM E_目標額")
                builSQL.Append(" INNER JOIN B_売上区分 ON E_目標額.売上区分番号 = B_売上区分.売上区分番号")
                builSQL.Append(" WHERE 対象年月 = @対象年月")
                builSQL.Append(" ORDER BY B_売上区分.表示順,B_売上区分.売上区分番号")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "目標額情報登録"
        ''' <summary>目標額情報登録</summary>
        ''' <param name="v_param">SQLパラメータ：@売上区分番号/@対象年月/@目標額/@営業日数/@売上累/@売上人累</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_W_目標(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Try
                builSQL.Length = 0
                builSQL.Append("INSERT INTO W_目標 (")
                builSQL.Append(" 売上区分番号")
                builSQL.Append(" ,対象年月")
                builSQL.Append(" ,目標額")
                builSQL.Append(" ,営業日数)")

                builSQL.Append(" VALUES(")
                builSQL.Append("@売上区分番号")
                builSQL.Append(",@対象年月")
                builSQL.Append(",@目標額")
                builSQL.Append(",@営業日数)")

                rtn = DBA.ExecuteNonQuery(builSQL.ToString, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return rtn
        End Function
#End Region

#Region "目標額情報更新"
        ''' <summary>目標額情報更新</summary>
        ''' <param name="v_param">SQLパラメータ：@売上累/@売上人累/@売上本/@売上人本/@売上区分番号</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function update_W_目標(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim dt As Integer
            Dim str_sql As String
            Try
                str_sql = "UPDATE W_目標 SET 売上累 = @売上累, 売上人累 = @売上人累,売上本 = @売上本,売上人本 = @売上人本 WHERE 売上区分番号 = @売上区分番号"
                dt = DBA.ExecuteNonQuery(str_sql, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "目標額情報取得"
        ''' <summary>目標額情報取得</summary>
        ''' <returns>目標額情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_W_目標() As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT W_目標.売上区分番号 ,売上区分 ,ISNULL(目標額,0) AS 目標額")
                builSQL.Append(" ,営業日数,売上累,売上人累,売上人本")
                builSQL.Append(" FROM W_目標")
                builSQL.Append(" INNER JOIN B_売上区分")
                builSQL.Append(" ON W_目標.売上区分番号 = B_売上区分.売上区分番号")
                builSQL.Append(" ORDER BY B_売上区分.表示順,B_売上区分.売上区分番号")
                dt = DBA.ExecuteDataTable(builSQL.ToString)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "性別指名客売上情報取得"
        ''' <summary>性別売上情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@開始日/@終了日/@性別番号</param>
        ''' <returns>性別売上リスト</returns>
        ''' <remarks>男女別指名売上を集計
        ''' 性別指名売上：E_売上より「現金支払 + カード支払 + その他支払 + ポイント割引支払 - 消費税」を集計</remarks>
        Protected Friend Function select_nomination(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT COUNT(E_売上.顧客番号) AS 人数")
                builSQL.Append(" ,ISNULL(SUM(E_売上.現金支払 + E_売上.カード支払 + E_売上.その他支払 + E_売上.ポイント割引支払 - E_売上.消費税),0) AS 売上")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" WHERE E_売上.来店日>=@開始日")
                builSQL.Append(" AND E_売上.来店日<= @終了日")
                builSQL.Append(" AND E_売上.指名='True'")
                builSQL.Append(" AND E_売上.性別番号=@性別番号")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "性別来店人数一覧取得"
        ''' <summary>性別来店人数一覧取得</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>性別来店人数リスト</returns>
        ''' <remarks>男女別客数を集計</remarks>
        Protected Friend Function select_number_storecustomer(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT COUNT(E_売上.来店者番号) AS 人数")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" WHERE E_売上.来店日>=@開始日")
                builSQL.Append(" AND E_売上.来店日<= @終了日")
                builSQL.Append(" AND E_売上.性別番号=@性別番号")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "期間内営業情報集計"
        ''' <summary>期間営業情報集計</summary>
        ''' <param name="v_param">SQLパラメータ：@開始日/@終了日</param>
        ''' <returns>期間営業情報</returns>
        ''' <remarks>営業日数、スタッフ数を集計</remarks>
        Protected Friend Function select_number_store_totalday(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT COUNT(E_営業日.営業日) AS 営業日数")
                builSQL.Append(" ,ISNULL(SUM(E_営業日.スタッフ数),0) AS スタッフ数")
                builSQL.Append(" FROM E_営業日")
                builSQL.Append(" WHERE E_営業日.営業日>=@開始日")
                builSQL.Append(" AND E_営業日.営業日<= @終了日")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "1日の営業情報取得"
        ''' <summary>1日の営業情報取得</summary>
        ''' <param name="v_param">SQLパラメータ：@営業日</param>
        ''' <returns>営業情報ト</returns>
        ''' <remarks>当日の天候、スタッフ数を取得(Q_d0300_店本日)</remarks>
        Protected Friend Function select_number_store_today(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT E_営業日.スタッフ数, B_天候.天候")
                builSQL.Append(" FROM E_営業日")
                builSQL.Append(" INNER JOIN B_天候")
                builSQL.Append(" ON E_営業日.天候番号 = B_天候.天候番号")
                builSQL.Append(" WHERE E_営業日.営業日=@営業日")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "来店者数集計"
        ''' <summary>来店者数集計</summary>
        ''' <param name="v_param">SQLパラメータ：@開始日/@終了日</param>
        ''' <returns>来店者数</returns>
        ''' <remarks>総客数を集計</remarks>
        Protected Friend Function select_number_customer(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT COUNT(E_売上.来店者番号) AS 人数")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" WHERE E_売上.来店日>=@開始日")
                builSQL.Append(" AND E_売上.来店日<= @終了日 ")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "来店区分別来店者数集計"
        ''' <summary>来店区分別来店者数集計</summary>
        ''' <param name="v_param">SQLパラメータ：@開始日/@終了日/@来店区分番号</param>
        ''' <returns>来店者数リスト</returns>
        ''' <remarks>来店区分別客数を集計</remarks>
        Protected Friend Function select_coming_store_division(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT COUNT(E_売上.来店者番号) AS 人数")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" WHERE E_売上.来店日>=@開始日")
                builSQL.Append(" AND E_売上.来店日<= @終了日")
                builSQL.Append(" AND E_売上.来店区分番号=@来店区分番号")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "性別来店区分別来店者数集計"
        ''' <summary>性別来店区分別来店者数集計</summary>
        ''' <param name="v_param">SQLパラメータ：@開始日/@終了日/@性別番号/@来店区分番号</param>
        ''' <returns>来店者数リスト</returns>
        ''' <remarks>来店区分別、男女別来客数を集計</remarks>
        Protected Friend Function selet_coming_division_sex(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT COUNT(E_売上.来店者番号) AS 人数")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" WHERE E_売上.来店日>=@開始日 AND E_売上.来店日<= @終了日")
                builSQL.Append(" AND E_売上.性別番号=@性別番号")
                builSQL.Append(" AND E_売上.来店区分番号=@来店区分番号")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try

            Return dt
        End Function
#End Region

#Region "性別売上集計"
        ''' <summary>性別売上集計</summary>
        ''' <param name="v_param">SQLパラメータ：@性別番号/@登録区分番号/@開始日/@終了日</param>
        ''' <returns>売上情報</returns>
        ''' <remarks>売上、サービス、人数、サービス人数を男女別に集計</remarks>
        Protected Friend Function select_sale_figue(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT ISNULL(SUM(売上区分.売上 - 売上区分.サービス),0) AS 売上")
                builSQL.Append(" ,ISNULL(SUM(売上区分.サービス),0) AS サービス")
                builSQL.Append(" ,COUNT(売上区分.売上) AS 人数")
                builSQL.Append(" ,ISNULL(SUM(CASE WHEN 売上区分.サービス<>0 THEN 1 ELSE 0 END),0) AS サービス人数")
                builSQL.Append(" FROM (SELECT SUM(数量*金額) AS 売上")
                builSQL.Append(" ,SUM(E_売上明細.サービス) AS サービス")
                builSQL.Append(" FROM E_売上明細")
                builSQL.Append(" INNER JOIN E_売上")
                builSQL.Append(" ON E_売上明細.来店日 = E_売上.来店日")
                builSQL.Append(" AND E_売上明細.来店者番号 = E_売上.来店者番号")
                builSQL.Append(" AND E_売上明細.顧客番号 = E_売上.顧客番号")
                builSQL.Append(" WHERE E_売上.性別番号 = @性別番号")
                builSQL.Append(" AND E_売上明細.売上区分番号 = @売上区分番号")
                builSQL.Append(" AND E_売上明細.会計済 = 'True'")
                builSQL.Append(" AND E_売上明細.来店日 >= @開始日")
                builSQL.Append(" AND E_売上明細.来店日 <= @終了日")
                builSQL.Append(" GROUP BY E_売上明細.来店日, E_売上明細.来店者番号,E_売上明細.顧客番号")
                builSQL.Append(" ) 売上区分")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "来店区分、売上区分別売上集計"
        ''' <summary>来店区分、売上区分別売上集計</summary>
        ''' <param name="v_param">SQLパラメータ：@来店区分番号/@売上区分番号/@開始日/@終了日</param>
        ''' <returns>売上情報</returns>
        ''' <remarks>期間中の売上、人数を来店区分と売上区分別に集計</remarks>
        Protected Friend Function sale_value_coming_storedivision(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT ISNULL(SUM(来店区分.売上),0) AS 売上")
                builSQL.Append(" ,COUNT(来店区分.売上) AS 人数")
                builSQL.Append(" FROM (SELECT SUM([数量]*[金額] - サービス) AS 売上")
                builSQL.Append(" FROM E_売上明細")
                builSQL.Append(" INNER JOIN E_売上")
                builSQL.Append(" ON E_売上明細.顧客番号 = E_売上.顧客番号")
                builSQL.Append(" AND E_売上明細.来店者番号 = E_売上.来店者番号")
                builSQL.Append(" AND E_売上明細.来店日 = E_売上.来店日")
                builSQL.Append(" WHERE E_売上.来店区分番号=@来店区分番号")
                builSQL.Append(" AND E_売上明細.売上区分番号=@売上区分番号")
                builSQL.Append(" AND E_売上明細.会計済='True'")
                builSQL.Append(" AND E_売上明細.来店日>=@開始日")
                builSQL.Append(" AND E_売上明細.来店日<= @終了日")
                builSQL.Append(" GROUP BY E_売上明細.来店日, E_売上明細.来店者番号, E_売上明細.顧客番号")
                builSQL.Append(" ) 来店区分")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "支払額集計"
        ''' <summary>支払額集計</summary>
        ''' <param name="v_param">SQLパラメータ：@開始日/@終了日</param>
        ''' <returns>支払額情報</returns>
        ''' <remarks>月と当日の各支払額を集計</remarks>
        Protected Friend Function select_pay(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT")
                builSQL.Append(" SUM(E_売上.現金支払) AS 現金支払")
                builSQL.Append(" ,SUM(E_売上.カード支払) AS カード支払")
                builSQL.Append(" ,SUM(E_売上.その他支払) AS その他支払")
                builSQL.Append(" ,SUM(E_売上.ポイント割引支払) AS ポイント割引支払")
                builSQL.Append(" ,SUM(E_売上.サービス金額) AS サービス")
                builSQL.Append(" ,SUM(CASE WHEN E_売上.サービス金額>0 THEN 1 ELSE 0 END) AS サービス人数")
                builSQL.Append(" ,SUM(E_売上.消費税) AS 消費税")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" WHERE E_売上.来店日>=@開始日 AND E_売上.来店日<= @終了日")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "W_支払の登録"
        ''' <summary>W_支払の登録</summary>
        ''' <param name="v_param">SQLパラメータ：@現金本/@カード本/@消費税本/@現金累/@カード累/@消費税累</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function insert_W_支払(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim dt As Integer
            Try
                builSQL.Length = 0
                builSQL.Append("INSERT INTO W_支払(")
                builSQL.Append(" 総客本")
                builSQL.Append(" ,現金本")
                builSQL.Append(" ,カード本")
                builSQL.Append(" ,その他本")
                builSQL.Append(" ,ポイント割引本")
                builSQL.Append(" ,消費税本")
                builSQL.Append(" ,現金累")
                builSQL.Append(" ,カード累")
                builSQL.Append(" ,その他累")
                builSQL.Append(" ,ポイント割引累")
                builSQL.Append(" ,消費税累)")
                builSQL.Append(" VALUES(@総客本,@現金本,@カード本,@その他本,@ポイント割引本,@消費税本,@現金累,@カード累,@その他累,@ポイント割引累,@消費税累)")

                dt = DBA.ExecuteNonQuery(builSQL.ToString, v_param)
            Catch ex As Exception
                DBA.TransactionRollBack()
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "売上集計"
        ''' <summary>売上集計</summary>
        ''' <returns>目標情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function W_目標集計() As DataTable
            Dim dt As DataTable
            Dim str_sql As String
            Try
                str_sql = "SELECT SUM(売上本) AS 総売本,SUM(売上人本) AS 総本人,SUM(売上累) AS 総売累,SUM(売上人累) AS 総累人 FROM W_目標"
                dt = DBA.ExecuteDataTable(str_sql)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "期間内純売上合計取得"
        ''' <summary>期間内純売上合計取得</summary>
        ''' <returns>純売上金額,総売上金額</returns>
        ''' <remarks></remarks>
        Protected Friend Function getPeriodSales(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT ISNULL(SUM(MEISAI.売上 - E_売上.サービス金額 - E_売上.消費税),0) AS 売上")
                builSQL.Append(", ISNULL(SUM(MEISAI.売上 - E_売上.サービス金額),0) AS 税込")
                builSQL.Append(" FROM E_売上 INNER JOIN")
                builSQL.Append(" (SELECT 来店日, 来店者番号, ISNULL(SUM([数量] * [金額] - サービス),0) AS 売上")
                builSQL.Append(" FROM E_売上明細")
                builSQL.Append(" WHERE 来店日>=@開始日 AND 来店日<= @終了日 AND 会計済='1'")
                builSQL.Append(" GROUP BY 来店日,来店者番号) MEISAI")
                builSQL.Append(" ON E_売上.来店日=MEISAI.来店日")
                builSQL.Append(" AND E_売上.来店者番号=MEISAI.来店者番号")
                builSQL.Append(" WHERE E_売上.来店日>=@開始日 AND E_売上.来店日<= @終了日")

                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "営業日情報取得"
        ''' <summary>営業日情報取得</summary>
        ''' <returns>営業日データ</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_business_day(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT E_営業日.レジ金額 AS レジ金額")
                builSQL.Append(" FROM E_営業日")
                builSQL.Append(" WHERE E_営業日.営業日=@営業日")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "入出金情報取得"
        ''' <summary>入出金情報取得</summary>
        ''' <returns>入出金データ</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_receive_and_invest_money(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT E_入出金.入出金区分番号 AS 入出金区分番号,")
                builSQL.Append(" SUM(E_入出金.金額) AS 金額")
                builSQL.Append(" FROM E_入出金")
                builSQL.Append(" WHERE E_入出金.入出金日=@入出金日")
                builSQL.Append(" GROUP BY E_入出金.入出金区分番号")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "スタッフ集計データ取得"
        ''' <summary>スタッフ集計データ取得</summary>
        ''' <param name="v_param">SQLパラメータ：@開始日/@終了日</param>
        ''' <returns>スタッフ集計一覧</returns>
        ''' <remarks>期間内スタッフ別売上、ポイント情報を取得
        ''' 
        ''' </remarks>
        Protected Friend Function getStaffSalesList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT [D_担当者].[担当者番号]")
                builSQL.Append(" ,[D_担当者].[担当者名]")
                builSQL.Append(" ,ISNULL(再来,0) AS 再来")
                builSQL.Append(" ,ISNULL(新規,0) AS 新規")
                builSQL.Append(" ,ISNULL(担当数,0) AS 担当数")
                builSQL.Append(" ,ISNULL(指名,0) AS 指名")
                builSQL.Append(" ,ISNULL(ポイント,0) AS ポイント")
                builSQL.Append(" ,ISNULL(技術金額.売上金額,0) AS 技術売上")
                builSQL.Append(" ,ISNULL(店販金額.売上金額,0) AS 店販売上")
                builSQL.Append(" ,ISNULL(全体ｻｰﾋﾞｽ,0) AS 全体ｻｰﾋﾞｽ")
                'builSQL.Append(" ,ISNULL(総売上,0) AS 総売上")
                builSQL.Append(" ,ISNULL(技術金額.売上金額,0) + ISNULL(店販金額.売上金額,0) - ISNULL(全体ｻｰﾋﾞｽ,0) AS 総売上")
                builSQL.Append(" FROM D_担当者")

                builSQL.Append(" LEFT OUTER JOIN")
                builSQL.Append(" (SELECT [主担当者番号]")
                builSQL.Append(" ,SUM(CASE WHEN 来店区分番号='1' THEN 1 ELSE 0 END) AS 再来")
                builSQL.Append(" ,SUM(CASE WHEN 来店区分番号='2' THEN 1 ELSE 0 END) AS 新規")
                builSQL.Append(" ,SUM(CASE WHEN 指名='1' THEN 1 ELSE 0 END) AS 指名")
                builSQL.Append(" ,COUNT([主担当者番号]) AS 担当数")
                builSQL.Append(" ,SUM(サービス金額) AS 全体ｻｰﾋﾞｽ ")
                builSQL.Append(" ,SUM(現金支払 + カード支払 + その他支払 + ポイント割引支払) AS 総売上 ")
                builSQL.Append(" FROM [E_売上]")
                builSQL.Append(" WHERE [E_売上].来店日>=@開始日")
                builSQL.Append(" AND [E_売上].来店日<= @終了日")
                builSQL.Append(" GROUP BY [主担当者番号]) E_売上")
                builSQL.Append(" ON [E_売上].[主担当者番号]=[D_担当者].[担当者番号]")

                builSQL.Append(" LEFT OUTER JOIN (SELECT [担当者コード],ISNULL(SUM(ポイント),0) AS ポイント FROM [E_ポイント]")
                builSQL.Append(" WHERE [E_ポイント].来店日>=@開始日 AND [E_ポイント].来店日<= @終了日 GROUP BY [担当者コード]) E_ポイント")
                builSQL.Append(" ON [E_ポイント].[担当者コード]=[D_担当者].[担当者番号]")

                'builSQL.Append(" LEFT OUTER JOIN (SELECT [主担当者番号] ,ISNULL(SUM(数量 * 金額 - サービス),0) AS 売上金額 FROM [E_売上明細]")
                'builSQL.Append(" LEFT OUTER JOIN [E_売上] ON E_売上.来店日=E_売上明細.来店日")
                'builSQL.Append(" AND E_売上.来店者番号=E_売上明細.来店者番号")
                'builSQL.Append(" WHERE [E_売上明細].来店日>=@開始日 AND [E_売上明細].来店日<= @終了日 AND 会計済='1' AND 売上区分番号='1'")
                'builSQL.Append(" GROUP BY [主担当者番号]) 技術金額 ON 技術金額.[主担当者番号]=[D_担当者].[担当者番号]")
                builSQL.Append(" LEFT OUTER JOIN (SELECT [売上担当者番号] ,ISNULL(SUM(数量 * 金額 - サービス),0) AS 売上金額 FROM [E_売上明細]")
                builSQL.Append(" WHERE [E_売上明細].来店日>=@開始日 AND [E_売上明細].来店日<= @終了日 AND 会計済='1' AND 売上区分番号='1'")
                builSQL.Append(" GROUP BY [売上担当者番号]) 技術金額 ON 技術金額.[売上担当者番号]=[D_担当者].[担当者番号]")

                builSQL.Append(" LEFT OUTER JOIN (SELECT [売上担当者番号] ,ISNULL(SUM(数量 * 金額 - サービス),0) AS 売上金額 FROM [E_売上明細]")
                builSQL.Append(" WHERE [E_売上明細].来店日>=@開始日 AND [E_売上明細].来店日<= @終了日 AND 会計済='1' AND 売上区分番号='2'")
                'builSQL.Append(" GROUP BY [売上区分番号],[売上担当者番号]) 店販金額 ON 店販金額.[売上担当者番号]=[D_担当者].[担当者番号]")
                builSQL.Append(" GROUP BY [売上担当者番号]) 店販金額 ON 店販金額.[売上担当者番号]=[D_担当者].[担当者番号]")

                builSQL.Append(" WHERE [削除フラグ]='0'")
                builSQL.Append(" GROUP BY [D_担当者].[担当者番号],[D_担当者].[担当者名],[D_担当者].[表示順],[再来],[新規],[担当数]")
                builSQL.Append(" ,[指名],[ポイント],技術金額.売上金額,店販金額.売上金額,全体ｻｰﾋﾞｽ,総売上")
                builSQL.Append(" ORDER BY [D_担当者].[表示順]")

                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)
                Dim newRow As DataRow = dt.NewRow()
                newRow("担当者番号") = DBNull.Value
                newRow("担当者名") = "合計"

                newRow("再来") = Str(dt.Compute("Sum(再来)", Nothing))
                newRow("新規") = Str(dt.Compute("Sum(新規)", Nothing))
                newRow("担当数") = Str(dt.Compute("Sum(担当数)", Nothing))
                newRow("指名") = Str(dt.Compute("Sum(指名)", Nothing))
                newRow("ポイント") = Str(dt.Compute("Sum(ポイント)", Nothing))
                newRow("技術売上") = Str(dt.Compute("Sum(技術売上)", Nothing))
                newRow("店販売上") = Str(dt.Compute("Sum(店販売上)", Nothing))
                newRow("全体ｻｰﾋﾞｽ") = Str(dt.Compute("Sum(全体ｻｰﾋﾞｽ)", Nothing))
                newRow("総売上") = Str(dt.Compute("Sum(総売上)", Nothing))

                dt.Rows.Add(newRow)
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "店集計データ取得（売上）"
        ''' <summary>店集計データ取得（売上）</summary>
        ''' <param name="v_param">SQLパラメータ：@開始日/@終了日</param>
        ''' <returns>売上情報</returns>
        ''' <remarks>期間内の売上情報を取得
        ''' 売上区分別売上 ：E_売上明細より「数量 * 金額 - サービス」の集計
        ''' 全体サービス　 ：E_売上より「サービス金額 * -1」の集計
        ''' 総売上　　　　 ：E_売上より「現金支払 + カード支払 + その他支払 + ポイント割引支払」の集計
        ''' 消費税　　　　 ：E_売上より「消費税」の集計
        ''' 純売上　　　　 ：E_売上より「現金支払 + カード支払 + その他支払 + ポイント割引支払 - 消費税」の集計
        ''' 売上区分別ｻｰﾋﾞｽ：E_売上明細より「サービス」の集計
        ''' </remarks>
        Protected Friend Function getShopSalesList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT name ,num ,amount ,delflag")
                builSQL.Append(" FROM (")

                builSQL.Append("SELECT 売上区分 + '売上' AS name")
                builSQL.Append(" ,CAST(ISNULL(COUNT(MEISAI.売上区分番号),0) AS varchar) AS num")
                builSQL.Append(" ,ISNULL(SUM(amount),0) AS amount")
                builSQL.Append(" ,B_売上区分.売上区分番号 AS dispOrder")
                builSQL.Append(" ,B_売上区分.削除フラグ AS delflag")
                builSQL.Append(" FROM  (")
                builSQL.Append("  SELECT 来店日,来店者番号,売上区分番号,SUM(数量 * 金額 - サービス) AS amount")
                builSQL.Append("  FROM E_売上明細")
                builSQL.Append("  WHERE 来店日 >= @開始日 AND 来店日 <= @終了日 AND 会計済 ='1'")
                builSQL.Append("  GROUP BY 来店日,来店者番号,売上区分番号) AS MEISAI")
                builSQL.Append(" RIGHT OUTER JOIN")
                builSQL.Append("  B_売上区分")
                builSQL.Append(" ON MEISAI.売上区分番号 =B_売上区分.売上区分番号")
                builSQL.Append(" GROUP BY B_売上区分.売上区分番号,売上区分 + '売上',B_売上区分.削除フラグ")

                builSQL.Append(" UNION SELECT '全体ｻｰﾋﾞｽ' AS name")
                builSQL.Append(" ,CAST(ISNULL(COUNT(来店者番号),0) AS varchar) AS num")
                builSQL.Append(" ,ISNULL(SUM(サービス金額 * -1),0) AS amount")
                builSQL.Append(" ,'1001' AS dispOrder")
                builSQL.Append(" ,'0' AS delflag")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" WHERE 来店日 >= @開始日 AND 来店日 <= @終了日 AND サービス金額>0")

                builSQL.Append(" UNION SELECT  '総売上' AS name")
                builSQL.Append(" ,CAST(ISNULL(COUNT(消費税),0) AS varchar) AS num")
                builSQL.Append(" ,ISNULL(SUM(現金支払+カード支払+その他支払+ポイント割引支払),0) AS amount")
                builSQL.Append(" ,'1002' AS dispOrder")
                builSQL.Append(" ,'0' AS delflag")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" WHERE 来店日 >= @開始日 AND 来店日 <= @終了日")

                builSQL.Append(" UNION SELECT '消費税' AS name")
                builSQL.Append(" ,'' AS num")
                builSQL.Append(" ,ISNULL(SUM(消費税),0) AS amount")
                builSQL.Append(" ,'1003' AS dispOrder")
                builSQL.Append(" ,'0' AS delflag")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" WHERE 来店日 >= @開始日 AND 来店日 <= @終了日")

                builSQL.Append(" UNION SELECT  '純売上' AS name")
                builSQL.Append(" ,CAST(ISNULL(COUNT(消費税),0) AS varchar) AS num")
                builSQL.Append(" ,ISNULL(SUM(現金支払+カード支払+その他支払+ポイント割引支払-消費税),0) AS amount")
                builSQL.Append(" ,'1004' AS dispOrder")
                builSQL.Append(" ,'0' AS delflag")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" WHERE 来店日 >= @開始日 AND 来店日 <= @終了日")

                builSQL.Append(" UNION SELECT '('+売上区分 + 'ｻｰﾋﾞｽ)' AS name")
                builSQL.Append(" ,CAST(ISNULL(COUNT(MEISAI.売上区分番号),0) AS varchar) AS num")
                builSQL.Append(" ,ISNULL(SUM(amount),0) AS amount")
                builSQL.Append("  ,B_売上区分.売上区分番号+1050 AS dispOrder")
                builSQL.Append(" ,B_売上区分.削除フラグ AS delflag")
                builSQL.Append("  FROM ( ")
                builSQL.Append("   SELECT 売上区分番号,SUM(サービス) AS amount")
                builSQL.Append("   FROM E_売上明細")
                builSQL.Append("   WHERE 来店日 >= @開始日 AND 来店日 <= @終了日 AND 会計済 ='1' AND サービス>0")
                builSQL.Append("   GROUP BY 来店日,来店者番号,売上区分番号) AS MEISAI")
                builSQL.Append("  RIGHT OUTER JOIN")
                builSQL.Append("  B_売上区分")
                builSQL.Append("  ON MEISAI.売上区分番号 =B_売上区分.売上区分番号")
                builSQL.Append("  GROUP BY B_売上区分.売上区分番号,'('+売上区分 + 'ｻｰﾋﾞｽ)',B_売上区分.削除フラグ")

                builSQL.Append(" ) AS A")
                builSQL.Append(" ORDER BY A.dispOrder")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "店集計データ取得（来店区分）"
        ''' <summary>店集計データ取得（来店区分）</summary>
        ''' <param name="v_param">SQLパラメータ：@開始日/@終了日</param>
        ''' <returns>来店情報</returns>
        ''' <remarks>期間内の来店情報を取得</remarks>
        Protected Friend Function getShopVisitList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT 来店区分 AS name")
                builSQL.Append(" ,ISNULL(COUNT(MEISAI.amount),0) AS num")
                builSQL.Append(" ,ISNULL(SUM(MEISAI.amount - E_売上.サービス金額),0) AS amount")
                builSQL.Append(" FROM  (")
                builSQL.Append("  SELECT 来店日,来店者番号,SUM(数量 * 金額 - サービス) AS amount")
                builSQL.Append("  FROM E_売上明細")
                builSQL.Append("  WHERE 来店日 >= @開始日 AND 来店日 <= @終了日 AND 会計済 ='1'")
                builSQL.Append("  GROUP BY 来店日,来店者番号) AS MEISAI")
                builSQL.Append(" LEFT OUTER JOIN")
                builSQL.Append("  E_売上")
                builSQL.Append(" ON   MEISAI.来店日=E_売上.来店日")
                builSQL.Append("  AND MEISAI.来店者番号=E_売上.来店者番号")
                builSQL.Append(" RIGHT OUTER JOIN")
                builSQL.Append("  B_来店区分")
                builSQL.Append(" ON E_売上.来店区分番号 =B_来店区分.来店区分番号 ")
                builSQL.Append(" GROUP BY B_来店区分.来店区分番号,来店区分")
                builSQL.Append(" ORDER BY B_来店区分.来店区分番号")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "店集計データ取得（指名）"
        ''' <summary>店集計データ取得（指名）</summary>
        ''' <param name="v_param">SQLパラメータ：@開始日/@終了日</param>
        ''' <returns>指名情報</returns>
        ''' <remarks>期間内の指名情報を取得</remarks>
        Protected Friend Function getShopDesignatedList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT '指名' AS name")
                builSQL.Append(" ,ISNULL(COUNT(E_売上.指名),0) AS num")
                builSQL.Append(" ,ISNULL(SUM(MEISAI.amount - E_売上.サービス金額),0) AS amount")
                builSQL.Append(" FROM  (")
                builSQL.Append("  SELECT 来店日,来店者番号,SUM(数量 * 金額 - サービス) AS amount")
                builSQL.Append("  FROM E_売上明細")
                builSQL.Append("  WHERE 来店日 >= @開始日 AND 来店日 <= @終了日 AND 会計済 ='1'")
                builSQL.Append("  GROUP BY 来店日,来店者番号) AS MEISAI")
                builSQL.Append(" LEFT OUTER JOIN")
                builSQL.Append("  E_売上")
                builSQL.Append(" ON   MEISAI.来店日=E_売上.来店日")
                builSQL.Append("  AND MEISAI.来店者番号=E_売上.来店者番号")
                builSQL.Append(" WHERE E_売上.指名='1'")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "店集計データ取得（支払）"
        ''' <summary>店集計データ取得（支払）</summary>
        ''' <param name="v_param">SQLパラメータ：@開始日/@終了日</param>
        ''' <returns>支払情報</returns>
        ''' <remarks>期間内の支払情報を取得</remarks>
        Protected Friend Function getShopPaymentList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT name,num,amount")
                builSQL.Append(" FROM (")
                builSQL.Append("  SELECT '現金' AS name")
                builSQL.Append("  ,ISNULL(SUM(CASE WHEN 現金支払>0 THEN 1 ELSE 0 END),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(現金支払),0) AS amount")
                builSQL.Append("  ,'1' AS dispOrder")
                builSQL.Append("  FROM  E_売上")
                builSQL.Append("  WHERE E_売上.来店日>=@開始日 AND E_売上.来店日<= @終了日")

                builSQL.Append("  UNION")
                builSQL.Append("  SELECT 'カード' AS name")
                builSQL.Append("  ,ISNULL(SUM(CASE WHEN カード支払>0 THEN 1 ELSE 0 END),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(カード支払),0) AS amount")
                builSQL.Append("  ,'2' AS dispOrder")
                builSQL.Append("  FROM  E_売上")
                builSQL.Append("  WHERE E_売上.来店日>=@開始日 AND E_売上.来店日<= @終了日")

                builSQL.Append("  UNION")
                builSQL.Append("  SELECT 'その他' AS name")
                builSQL.Append("  ,ISNULL(SUM(CASE WHEN その他支払>0 THEN 1 ELSE 0 END),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(その他支払),0) AS amount")
                builSQL.Append("  ,'3' AS dispOrder")
                builSQL.Append("  FROM  E_売上")
                builSQL.Append("  WHERE E_売上.来店日>=@開始日 AND E_売上.来店日<= @終了日")

                builSQL.Append("  UNION")
                builSQL.Append("  SELECT 'ポイント割引' AS name")
                builSQL.Append("  ,ISNULL(SUM(CASE WHEN ポイント割引支払>0 THEN 1 ELSE 0 END),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(ポイント割引支払),0) AS amount")
                builSQL.Append("  ,'3' AS dispOrder")
                builSQL.Append("  FROM  E_売上")
                builSQL.Append("  WHERE E_売上.来店日>=@開始日 AND E_売上.来店日<= @終了日")

                builSQL.Append("  UNION")
                builSQL.Append("  SELECT '合計' AS name")
                builSQL.Append("  ,ISNULL(COUNT(来店日),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(現金支払+カード支払+その他支払+ポイント割引支払),0) AS amount")
                builSQL.Append("  ,'99' AS dispOrder")
                builSQL.Append("  FROM  E_売上")
                builSQL.Append("  WHERE E_売上.来店日>=@開始日 AND E_売上.来店日<= @終了日")
                builSQL.Append("  ) AS E_売上")
                builSQL.Append("  ORDER BY dispOrder")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "店集計データ取得（入出金）"
        ''' <summary>店集計データ取得（入出金）</summary>
        ''' <param name="v_param">SQLパラメータ：@開始日/@終了日</param>
        ''' <returns>入出金情報</returns>
        ''' <remarks>期間内の入出金情報を取得</remarks>
        Protected Friend Function getShopCashList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT name,num,amount")
                builSQL.Append(" FROM (")
                builSQL.Append("  SELECT '入金' AS name")
                builSQL.Append("  ,ISNULL(COUNT(E_入出金.入出金区分番号),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(金額),0) AS amount")
                builSQL.Append("  ,'1' AS dispOrder")
                builSQL.Append("  FROM  E_入出金")
                builSQL.Append("  WHERE E_入出金.入出金日>=@開始日 AND E_入出金.入出金日<= @終了日")
                builSQL.Append("  AND E_入出金.入出金区分番号='1'")

                builSQL.Append("  UNION")
                builSQL.Append("  SELECT '出金' AS name")
                builSQL.Append("  ,ISNULL(COUNT(E_入出金.入出金区分番号),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(金額),0) AS amount")
                builSQL.Append("  ,'2' AS dispOrder")
                builSQL.Append("  FROM  E_入出金")
                builSQL.Append("  WHERE E_入出金.入出金日>=@開始日 AND E_入出金.入出金日<= @終了日")
                builSQL.Append("  AND E_入出金.入出金区分番号='2'")

                builSQL.Append("  UNION")
                builSQL.Append("  SELECT '合計' AS name")
                builSQL.Append("  ,ISNULL(COUNT(E_入出金.入出金区分番号),0) AS num")
                builSQL.Append("  ,ISNULL(SUM(CASE E_入出金.入出金区分番号 WHEN '1' THEN 金額 ")
                builSQL.Append("  WHEN '2' THEN 金額*-1 END),0) AS amount")
                builSQL.Append("  ,'99' AS dispOrder")
                builSQL.Append("  FROM  E_入出金")
                builSQL.Append("  WHERE E_入出金.入出金日>=@開始日 AND E_入出金.入出金日<= @終了日")
                builSQL.Append(" ) AS E_入出金")
                builSQL.Append(" ORDER BY dispOrder")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

#Region "店集計データ取得（単価）"
        ''' <summary>店集計データ取得（単価）</summary>
        ''' <param name="v_param">SQLパラメータ：@開始日/@終了日</param>
        ''' <returns>売上単価情報</returns>
        ''' <remarks>期間内の売上単価情報を取得</remarks>
        Protected Friend Function getShopCostList(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Dim dt As DataTable
            Try
                builSQL.Length = 0
                builSQL.Append("SELECT name ,amount")
                builSQL.Append(" FROM (")
                builSQL.Append(" SELECT '売上単価' AS name")
                builSQL.Append(" ,CASE WHEN ISNULL(COUNT(MEISAI1.cnt),0) >0 THEN")
                builSQL.Append(" ISNULL(SUM(MEISAI1.amount- E_売上.サービス金額),0) / ISNULL(COUNT(MEISAI1.cnt),0)")
                builSQL.Append(" ELSE 0 END AS amount")
                builSQL.Append(" ,'0' AS dispOrder")
                builSQL.Append(" FROM  (")
                builSQL.Append("  SELECT MEISAI0.来店日,MEISAI0.来店者番号,SUM(MEISAI0.amount) AS amount")
                builSQL.Append(" ,COUNT(MEISAI0.売上区分番号) AS cnt")
                builSQL.Append("  FROM (")
                builSQL.Append("  SELECT 来店日,来店者番号,売上区分番号,SUM(数量 * 金額 - サービス) AS amount")
                builSQL.Append("  FROM E_売上明細")
                builSQL.Append("  WHERE 来店日 >= @開始日 AND 来店日 <= @終了日 AND 会計済 ='1'")
                builSQL.Append("  GROUP BY 来店日,来店者番号,売上区分番号) AS MEISAI0")
                builSQL.Append(" GROUP BY 来店日,来店者番号) AS MEISAI1")
                builSQL.Append(" LEFT OUTER JOIN E_売上")
                builSQL.Append(" ON E_売上.来店日 = MEISAI1.来店日")
                builSQL.Append(" AND E_売上.来店者番号 = MEISAI1.来店者番号")

                builSQL.Append(" UNION SELECT 売上区分 + '単価' AS name")
                builSQL.Append(" ,CASE WHEN ISNULL(COUNT(MEISAI.売上区分番号),0) >0 THEN")
                builSQL.Append(" ISNULL(SUM(MEISAI.amount),0) / ISNULL(COUNT(MEISAI.売上区分番号),0) ")
                builSQL.Append(" ELSE 0 END AS amount")
                builSQL.Append(" ,B_売上区分.売上区分番号 AS dispOrder")
                builSQL.Append(" FROM  (")
                builSQL.Append("  SELECT 来店日,来店者番号,売上区分番号,SUM(数量 * 金額 - サービス) AS amount")
                builSQL.Append("  FROM E_売上明細")
                builSQL.Append("  WHERE 来店日 >= @開始日 AND 来店日 <= @終了日 AND 会計済 ='1'")
                builSQL.Append("  GROUP BY 来店日,来店者番号,売上区分番号) AS MEISAI")
                builSQL.Append(" RIGHT OUTER JOIN")
                builSQL.Append("  B_売上区分")
                builSQL.Append(" ON MEISAI.売上区分番号 = B_売上区分.売上区分番号")
                builSQL.Append(" GROUP BY B_売上区分.売上区分番号,売上区分 + '単価'")

                builSQL.Append(" UNION SELECT '顧客単価' AS name")
                builSQL.Append(" ,CASE WHEN ISNULL(COUNT(MEISAI2.amount),0)>0 THEN ")
                builSQL.Append("  ISNULL(SUM(MEISAI2.amount - E_売上.サービス金額),0) / ISNULL(COUNT(MEISAI2.amount),0)")
                builSQL.Append("  ELSE 0 END AS amount")
                builSQL.Append(" ,'30' AS dispOrder")
                builSQL.Append(" FROM  (")
                builSQL.Append("  SELECT 来店日,来店者番号,SUM(数量 * 金額 - サービス) AS amount")
                builSQL.Append("  FROM E_売上明細")
                builSQL.Append("  WHERE 来店日 >= @開始日 AND 来店日 <= @終了日 AND 会計済 ='1'")
                builSQL.Append("  GROUP BY 来店日,来店者番号) AS MEISAI2")
                builSQL.Append(" LEFT OUTER JOIN")
                builSQL.Append("  E_売上")
                builSQL.Append(" ON   MEISAI2.来店日=E_売上.来店日")
                builSQL.Append("  AND MEISAI2.来店者番号=E_売上.来店者番号")

                builSQL.Append(" UNION SELECT 'スタッフ1人当り' AS name")
                builSQL.Append(" ,CASE WHEN ISNULL(SUM(スタッフ数),0)>0 THEN")
                builSQL.Append(" SUM(amount) / ISNULL(SUM(スタッフ数),0) ")
                builSQL.Append(" ELSE ISNULL(SUM(amount),0) END AS amount")
                builSQL.Append(" ,'40' AS dispOrder")
                builSQL.Append(" FROM  E_営業日")
                builSQL.Append(" LEFT OUTER JOIN")
                builSQL.Append(" (SELECT 来店日,")
                builSQL.Append(" ISNULL(SUM(現金支払+カード支払+その他支払+ポイント割引支払-サービス金額),0) AS amount")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" WHERE 来店日 >= @開始日 AND 来店日 <= @終了日")
                builSQL.Append(" GROUP BY 来店日)AS meisai")
                builSQL.Append(" ON meisai.来店日 =  E_営業日.営業日")
                builSQL.Append(" WHERE 営業日 >= @開始日 AND 営業日 <= @終了日")

                builSQL.Append(" UNION SELECT '1日当り' AS name")
                builSQL.Append(" ,CASE WHEN ISNULL(COUNT(営業日),0)>0 THEN")
                builSQL.Append(" SUM(amount) / ISNULL(COUNT(営業日),0) ")
                builSQL.Append(" ELSE ISNULL(SUM(amount),0) END AS amount")
                builSQL.Append(" ,'50' AS dispOrder")
                builSQL.Append(" FROM  E_営業日")
                builSQL.Append(" LEFT OUTER JOIN")
                builSQL.Append(" (SELECT 来店日,")
                builSQL.Append(" ISNULL(SUM(現金支払+カード支払+その他支払+ポイント割引支払-サービス金額),0) AS amount")
                builSQL.Append(" FROM E_売上")
                builSQL.Append(" WHERE 来店日 >= @開始日 AND 来店日 <= @終了日")
                builSQL.Append(" GROUP BY 来店日)AS meisai")
                builSQL.Append(" ON meisai.来店日 =  E_営業日.営業日")
                builSQL.Append(" WHERE 営業日 >= @開始日 AND 営業日 <= @終了日")
                builSQL.Append("  ) AS A")
                builSQL.Append(" ORDER BY A.dispOrder")
                dt = DBA.ExecuteDataTable(builSQL.ToString, v_param)

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
#End Region

    End Class
End Namespace
