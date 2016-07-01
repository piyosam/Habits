#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic

    ''' <summary>ユーザ情報画面ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class a1000_Logic
        Inherits Habits.Logic.LogicBase

        Private Const PAGE_TITLE As String = "a1000_ユーザー情報"

        ''' <summary>A_システム取得</summary>
        ''' <returns>システム情報</returns>
        ''' <remarks></remarks>
        Protected Friend Function getA_System() As DataTable
            Return MyBase.A_System()
        End Function

        ''' <summary>A_システム更新</summary>
        ''' <param name="v_param">
        ''' パラメータ：@店名1/@店名2/@代表者名/@店郵便番号/@店住所1/@店住所2
        ''' @店電話番号/@店FAX番号/@設備台数/@レジ金額/@都道府県/@市区町村/@変更日時/@月締開始日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function updateA_System(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("UPDATE A_システム SET")
                builSQL.Append(" 店名1 = @店名1")
                builSQL.Append(", 店名2 = @店名2")
                builSQL.Append(", 代表者名 = @代表者名")
                builSQL.Append(", 店郵便番号 = @店郵便番号")
                builSQL.Append(", 店住所1 = @店住所1")
                builSQL.Append(", 店住所2 = @店住所2")
                builSQL.Append(", 店電話番号 = @店電話番号")
                builSQL.Append(", 店FAX番号 = @店FAX番号")
                builSQL.Append(", 設備台数 = @設備台数")
                builSQL.Append(", レジ金額 = @レジ金額")
                builSQL.Append(", 都道府県 = @都道府県")
                builSQL.Append(", 市区町村 = @市区町村")
                builSQL.Append(", 変更日時 = @変更日時")
                builSQL.Append(", 月締開始日 = @月締開始日")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE system SET")
                builSQL.Append(" shop_name1 =" & VbSQLNStr(v_param.GetValue("@店名1")))
                builSQL.Append(", shop_name2 =" & VbSQLNStr(v_param.GetValue("@店名2")))
                builSQL.Append(", manager =" & VbSQLNStr(v_param.GetValue("@代表者名")))
                builSQL.Append(", post_code =" & VbSQLNStr(v_param.GetValue("@店郵便番号")))
                builSQL.Append(", address1 =" & VbSQLNStr(v_param.GetValue("@店住所1")))
                builSQL.Append(", address2 =" & VbSQLNStr(v_param.GetValue("@店住所2")))
                builSQL.Append(", phone =" & VbSQLNStr(v_param.GetValue("@店電話番号")))
                builSQL.Append(", fax =" & VbSQLNStr(v_param.GetValue("@店FAX番号")))
                builSQL.Append(", accommodated_count =" & VbSQLStr(v_param.GetValue("@設備台数")))
                builSQL.Append(", register_amount =" & VbSQLStr(v_param.GetValue("@レジ金額")))
                builSQL.Append(", prefectures_name =" & VbSQLNStr(v_param.GetValue("@都道府県")))
                builSQL.Append(", cities_name =" & VbSQLNStr(v_param.GetValue("@市区町村")))
                builSQL.Append(", update_date =" & VbSQLStr(v_param.GetValue("@変更日時")))
                builSQL.Append(", start_day =" & VbSQLStr(v_param.GetValue("@月締開始日")))
                builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Function

        ''' <summary>A_システム更新</summary>
        ''' <param name="v_param">
        ''' パラメータ：@店名1/@店名2/@代表者名/@店郵便番号/@店住所1/@店住所2
        ''' @店電話番号/@店FAX番号/@設備台数/@レジ金額/@都道府県/@市区町村/@変更日時/@月締開始日</param>
        ''' <returns>処理フラグ</returns>
        ''' <remarks></remarks>
        Protected Friend Function updatePartOfA_System(ByVal v_param As Habits.DB.DBParameter) As Integer
            Dim rtn As Integer = 0
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Try
                ' トランザクション開始
                DBA.TransactionStart()

                builSQL.Append("UPDATE A_システム SET")
                builSQL.Append(" 店名1 = @店名1")
                builSQL.Append(", 店名2 = @店名2")
                builSQL.Append(", 代表者名 = @代表者名")
                builSQL.Append(", 店郵便番号 = @店郵便番号")
                builSQL.Append(", 店住所1 = @店住所1")
                builSQL.Append(", 店住所2 = @店住所2")
                builSQL.Append(", 店電話番号 = @店電話番号")
                builSQL.Append(", 店FAX番号 = @店FAX番号")
                builSQL.Append(", 設備台数 = @設備台数")
                builSQL.Append(", レジ金額 = @レジ金額")
                builSQL.Append(", 変更日時 = @変更日時")
                builSQL.Append(", 月締開始日 = @月締開始日")

                str_sql = builSQL.ToString
                rtn = DBA.ExecuteNonQuery(str_sql, v_param)

                '------------------------------
                'Z_SQL実行履歴 INSERT
                '------------------------------
                builSQL.Length = 0
                ' SQL1設定
                builSQL.Append("UPDATE system SET")
                builSQL.Append(" shop_name1 =" & VbSQLNStr(v_param.GetValue("@店名1")))
                builSQL.Append(", shop_name2 =" & VbSQLNStr(v_param.GetValue("@店名2")))
                builSQL.Append(", manager =" & VbSQLNStr(v_param.GetValue("@代表者名")))
                builSQL.Append(", post_code =" & VbSQLNStr(v_param.GetValue("@店郵便番号")))
                builSQL.Append(", address1 =" & VbSQLNStr(v_param.GetValue("@店住所1")))
                builSQL.Append(", address2 =" & VbSQLNStr(v_param.GetValue("@店住所2")))
                builSQL.Append(", phone =" & VbSQLNStr(v_param.GetValue("@店電話番号")))
                builSQL.Append(", fax =" & VbSQLNStr(v_param.GetValue("@店FAX番号")))
                builSQL.Append(", accommodated_count =" & VbSQLStr(v_param.GetValue("@設備台数")))
                builSQL.Append(", register_amount =" & VbSQLStr(v_param.GetValue("@レジ金額")))
                builSQL.Append(", update_date =" & VbSQLStr(v_param.GetValue("@変更日時")))
                builSQL.Append(", start_day =" & VbSQLStr(v_param.GetValue("@月締開始日")))
                builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                rtn = InsertZSqlExecHis(PAGE_TITLE, builSQL.ToString)

                ' コミット
                DBA.TransactionCommit()
            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try
        End Function


        ''' <summary>郵便番号にて市区町村検索</summary>
        ''' <param name="v_param">SQLパラメータ：@新郵便番号表示用</param>
        ''' <returns>市区町村名</returns>
        ''' <remarks></remarks>
        Protected Friend Function select_address(ByVal v_param As Habits.DB.DBParameter) As DataTable
            Return MyBase.SearchAddress(v_param)
        End Function
    End Class
End Namespace
