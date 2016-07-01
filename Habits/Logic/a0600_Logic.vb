#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic

    ''' <summary>営業日画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a0600_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a0600_営業日"

        ''' <summary>天候データ取得</summary>
        ''' <returns>天候リスト</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetWeather() As DataTable
            Return MyBase.B_天候()
        End Function

        ''' <summary>レジ金額取得</summary>
        ''' <returns>レジ金額</returns>
        ''' <remarks></remarks>
        Protected Friend Function GetCashRegisterMoney() As Integer
            Dim dt As New DataTable
            Dim rtn As Integer

            dt = MyBase.A_System()

            If dt.Rows.Count > 0 Then
                rtn = dt.Rows(0)("レジ金額").ToString
            End If

            Return rtn
        End Function

        ''' <summary>E_営業日のデータ登録</summary>
        ''' <param name="v_param">SQLパラメータ</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function InSertData(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String

            Try
                ' トランザクション開始
                DBA.TransactionStart()

                '' E_営業日にデータを登録
                builSQL.Append("INSERT INTO E_営業日 (営業日 ,スタッフ数 ,天候番号 ,レジ金額 ,登録日,更新日)")
                builSQL.Append(" VALUES (@営業日 ,@スタッフ数 ,@天候番号 ,@レジ金額 ,@登録日,@更新日)")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("INSERT INTO business_day (")
                builSQL.Append("shop_code")             '店舗コード     (varchar)
                builSQL.Append(",date")                 '営業日         (datetime)
                builSQL.Append(",staff_count")          'スタッフ数       (smallint)
                builSQL.Append(",weather_code")         '天候番号       (int)
                builSQL.Append(",cash_of_register")     'レジ金額             (int)
                builSQL.Append(",insert_date")          '登録日             (datetime)
                builSQL.Append(",update_date")          '更新日             (datetime)
                builSQL.Append(" ) VALUES (")

                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@営業日")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@スタッフ数")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@天候番号")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@レジ金額")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@登録日")))
                builSQL.Append("," & VbSQLStr(v_param.GetValue("@更新日")))
                builSQL.Append(")")
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

            Return rtn
        End Function

    End Class
End Namespace