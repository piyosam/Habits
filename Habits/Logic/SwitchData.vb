#Region "インポート"
Imports System.Text
#End Region

Namespace Habits.Logic
    ''' <summary>データ移行ロジッククラス</summary>
    ''' <remarks></remarks>
    Public Class SwitchData
        Inherits Habits.Logic.LogicBase

        Const tax As Double = 0.05
        Public managementTax As Int16
        Public taxType As Int16
        Public ServiceType As Int16
        Const TITLE As String = "データ修正"

#Region "[OK]過去データ登録可能へ切替"
        ''' <summary>過去データ登録可能へ切替</summary>
        ''' <remarks></remarks>
        Sub switchOKPast()
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                dt = A_System()

                If dt Is Nothing OrElse dt.Rows(0).Item("予備1").Equals("True") Then
                    '対応済のため終了
                    Exit Sub
                End If

                ' トランザクション開始
                DBA.TransactionStart()

                'ローカルデータ更新用
                str_sql = "UPDATE A_システム SET 予備1 = 'True'"
                rtn = DBA.ExecuteNonQuery(str_sql)

                'サーバデータ更新用
                UpDateForSever_System()

                ' コミット
                DBA.TransactionCommit()

            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

        End Sub
#End Region

#Region "[NG]過去データ登録不可へ切替"
        ''' <summary>過去データ登録不可へ切替</summary>
        ''' <remarks></remarks>
        Sub switchNGPast()
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                dt = A_System()

                'If dt Is Nothing OrElse Not dt.Rows(0).Item("予備1").Equals("True") Then
                '    '対応済のため終了
                '    Exit Sub
                'End If

                ' トランザクション開始
                DBA.TransactionStart()

                'ローカルデータ更新用
                str_sql = "UPDATE A_システム SET 予備1 = ''"
                rtn = DBA.ExecuteNonQuery(str_sql)

                'サーバデータ更新用
                UpDateForSever_System()

                ' コミット
                DBA.TransactionCommit()

            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

        End Sub
#End Region

#Region "税込対応データ移行処理"
        ''' <summary>データ移行処理</summary>
        ''' <remarks></remarks>
        Sub upPoint()
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                '税込対応状況チェック
                str_sql = "SELECT 予備2 FROM A_システム"
                dt = DBA.ExecuteDataTable(str_sql)
                If dt Is Nothing OrElse dt.Rows(0).Item("予備2").Equals("ポイント割引") Then
                    '対応済のため終了
                    Exit Sub
                End If

                ' トランザクション開始
                DBA.TransactionStart()

                'データ変更
                upServerPoint()

                ' コミット
                DBA.TransactionCommit()

            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

        End Sub
#End Region

#Region "税込対応データ移行処理"
        ''' <summary>データ移行処理</summary>
        ''' <remarks></remarks>
        Sub switchDataTable()
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As DataTable
            Try
                '税込対応状況チェック
                str_sql = "SELECT 予備2 FROM A_システム"
                dt = DBA.ExecuteDataTable(str_sql)
                If dt Is Nothing OrElse dt.Rows(0).Item("予備2").Equals("税込対応") Then
                    '対応済のため終了
                    Exit Sub
                End If

                ' トランザクション開始
                DBA.TransactionStart()

                'テーブル項目追加
                makeTable()

                '消費税チェック
                managementTax = judgeTaxType()
                taxType = My.MySettings.Default.TaxType
                ServiceType = My.MySettings.Default.ServiceType
                'データ変換
                changeData()

                ' コミット
                DBA.TransactionCommit()
                'Aシステムの値設定
                setA_SystemVariable()

            Catch ex As Exception
                ' ロールバック
                DBA.TransactionRollBack()
                Throw ex
            End Try

        End Sub
#End Region

#Region "テーブル項目追加"
        ''' <summary>ダウンロードデータからテーブル更新</summary>
        ''' <remarks></remarks>
        Sub makeTable()
            Dim builSQL As New StringBuilder()


            '■SQL（確認に使用）
            'CREATE TABLE [dbo].[B_ポイント割引](
            '[ポイント割引番号] [smallint] NOT NULL,
            '[ポイント割引名] [nvarchar](32) NOT NULL,
            '[表示順] [smallint] NOT NULL,
            '[削除フラグ] [bit] NOT NULL,
            '[登録日] [datetime] NOT NULL CONSTRAINT [DF_B_ポイント割引_登録日]  DEFAULT (getdate()),
            '[更新日] [datetime] NOT NULL CONSTRAINT [DF_B_ポイント割引_更新日]  DEFAULT (getdate()),
            'CONSTRAINT [PK_B_ポイント割引] PRIMARY KEY NONCLUSTERED
            '(
            '            [ポイント割引番号](Asc)
            ') ON [PRIMARY]
            ') ON [PRIMARY]
            '--■A_システム
            'ALTER TABLE [A_システム] ADD 税区分 smallint NOT NULL CONSTRAINT [DF_A_システム_税区分]  DEFAULT ((2));
            '--■C_商品
            'ALTER TABLE [C_商品] ADD 金額管理区分 smallint NOT NULL CONSTRAINT [DF_C_商品_金額管理区分]  DEFAULT ((1));
            '--■E_売上
            'ALTER TABLE [E_売上] ADD ポイント割引番号 smallint NOT NULL CONSTRAINT [DF_E_売上_ポイント割引番号]  DEFAULT ((0));
            'ALTER TABLE [E_売上] ADD ポイント割引支払 int NOT NULL CONSTRAINT [DF_E_売上_ポイント割引支払]  DEFAULT ((0));
            'ALTER TABLE [E_売上] ADD サービス番号 smallint NOT NULL CONSTRAINT [DF_E_売上_サービス番号]  DEFAULT ((0));
            'ALTER TABLE [E_売上] ADD サービス金額 int NOT NULL CONSTRAINT [DF_E_売上_サービス金額]  DEFAULT ((0));
            '--■E_売上明細
            'ALTER TABLE [E_売上明細] ADD 消費税 int NOT NULL CONSTRAINT [DF_E_売上明細_消費税]  DEFAULT ((0));
            '--■E_来店者
            'ALTER TABLE [E_来店者] ADD ポイント割引番号 smallint NOT NULL CONSTRAINT [DF_E_来店者_ポイント割引番号]  DEFAULT ((0));
            'ALTER TABLE [E_来店者] ADD ポイント割引支払 int NOT NULL CONSTRAINT [DF_E_来店者_ポイント割引支払]  DEFAULT ((0));
            'ALTER TABLE [E_来店者] ADD サービス番号 smallint NOT NULL CONSTRAINT [DF_E_来店者_サービス番号]  DEFAULT ((0));
            'ALTER TABLE [E_来店者] ADD サービス区分 smallint NOT NULL CONSTRAINT [DF_E_来店者_サービス区分]  DEFAULT ((1));
            'ALTER TABLE [E_来店者] ADD サービス金額 int NOT NULL CONSTRAINT [DF_E_来店者_サービス金額]  DEFAULT ((0));
            '--■W_レシート
            'DROP TABLE W_レシート
            'CREATE TABLE [dbo].[W_レシート](
            '[番号] [smallint] NOT NULL,
            '[データタイプ] [int] NULL,
            '[氏名] [nvarchar](33) NULL,
            '[主担当者名] [nvarchar](32) NULL,
            '[品名] [nvarchar](32) NULL,
            '[数量] [int] NOT NULL CONSTRAINT [DF_W_レシート_数量]  DEFAULT ((0)),
            '[金額] [int] NOT NULL CONSTRAINT [DF_W_レシート_金額]  DEFAULT ((0)),
            '[小計] [int] NOT NULL CONSTRAINT [DF_W_レシート_小計]  DEFAULT ((0)),
            '[消費税] [int] NOT NULL CONSTRAINT [DF_W_レシート_消費税]  DEFAULT ((0)),
            '[合計] [int] NOT NULL CONSTRAINT [DF_W_レシート_合計]  DEFAULT ((0)),
            '[お釣り] [int] NULL CONSTRAINT [DF_W_レシート_お釣り]  DEFAULT ((0)),
            'CONSTRAINT [PK_W_レシート] PRIMARY KEY NONCLUSTERED 
            '(
            '            [番号](Asc)
            ') ON [PRIMARY]
            ') ON [PRIMARY]
            '--■W_顧客抽出
            'DROP TABLE W_顧客抽出
            'CREATE TABLE [dbo].[W_顧客抽出](
            '[選択] [bit] NOT NULL CONSTRAINT [DF_W_顧客抽出_選択]  DEFAULT ((0)),
            '[顧客番号] [int] NULL,
            '[姓] [nvarchar](32) NULL,
            '[名] [nvarchar](32) NULL,
            '[姓カナ] [nvarchar](32) NULL,
            '[名カナ] [nvarchar](32) NULL,
            '[性別番号] [smallint] NULL,
            '[生年月日] [datetime] NULL,
            '[郵便番号] [nvarchar](8) NULL,
            '[都道府県] [nvarchar](16) NULL,
            '[住所1] [nvarchar](128) NULL,
            '[住所2] [nvarchar](128) NULL,
            '[住所3] [nvarchar](128) NULL,
            '[電話番号] [nvarchar](19) NULL,
            '[Emailアドレス] [nvarchar](256) NULL,
            '[家族名] [nvarchar](32) NULL,
            '[趣味] [nvarchar](32) NULL,
            '[好きな話題] [nvarchar](32) NULL,
            '[嫌いな話題] [nvarchar](32) NULL,
            '[伝言フラグ] [bit] NULL,
            '[メモ] [nvarchar](64) NULL,
            '[紹介者] [nvarchar](32) NULL,
            '[前回来店日] [datetime] NULL,
            '[来店日N_1] [datetime] NULL,
            '[来店日N_2] [datetime] NULL,
            '[来店回数] [int] NULL,
            '[売上区分番号] [int] NULL,
            '[区分合計金額] [int] NULL,
            '[主担当者番号] [smallint] NULL,
            '[登録区分番号] [smallint] NULL,
            '[DM希望フラグ] [bit] NULL,
            '[登録日] [datetime] NULL,
            '[更新日] [datetime] NULL
            ') ON [PRIMARY]
            '--■W_支払
            'DROP TABLE W_支払
            'CREATE TABLE [dbo].[W_支払](
            '[総客本] [int] NOT NULL CONSTRAINT [DF_W_支払_総客本]  DEFAULT ((0)),
            '[現金本] [int] NOT NULL CONSTRAINT [DF_W_支払_現金本]  DEFAULT ((0)),
            '[カード本] [int] NOT NULL CONSTRAINT [DF_W_支払_カード本]  DEFAULT ((0)),
            '[その他本] [int] NOT NULL CONSTRAINT [DF_W_支払_その他本]  DEFAULT ((0)),
            '[ポイント割引本] [int] NOT NULL CONSTRAINT [DF_W_支払_ポイント割引本]  DEFAULT ((0)),
            '[消費税本] [int] NOT NULL CONSTRAINT [DF_W_支払_消費税本]  DEFAULT ((0)),
            '[現金累] [int] NOT NULL CONSTRAINT [DF_W_支払_現金累]  DEFAULT ((0)),
            '[カード累] [int] NOT NULL CONSTRAINT [DF_W_支払_カード累]  DEFAULT ((0)),
            '[その他累] [int] NOT NULL CONSTRAINT [DF_W_支払_その他累]  DEFAULT ((0)),
            '[ポイント割引累] [int] NOT NULL CONSTRAINT [DF_W_支払_ポイント割引累]  DEFAULT ((0)),
            '[消費税累] [int] NOT NULL CONSTRAINT [DF_W_支払_消費税累]  DEFAULT ((0)),
            ') ON [PRIMARY]
            '--■W_出力対象
            'DROP TABLE W_出力対象

            '--■B_ポイント割引
            builSQL.Length = 0
            builSQL.Append("CREATE TABLE [dbo].[B_ポイント割引](")
            builSQL.Append("[ポイント割引番号] [smallint] NOT NULL,")
            builSQL.Append("[ポイント割引名] [nvarchar](32) NOT NULL,")
            builSQL.Append("[表示順] [smallint] NOT NULL,")
            builSQL.Append("[削除フラグ] [bit] NOT NULL,")
            builSQL.Append("[登録日] [datetime] NOT NULL CONSTRAINT [DF_B_ポイント割引_登録日]  DEFAULT (getdate()),")
            builSQL.Append("[更新日] [datetime] NOT NULL CONSTRAINT [DF_B_ポイント割引_更新日]  DEFAULT (getdate()),")
            builSQL.Append("CONSTRAINT [PK_B_ポイント割引] PRIMARY KEY NONCLUSTERED")
            builSQL.Append("(")
            builSQL.Append("[ポイント割引番号] Asc")
            builSQL.Append(") ON [PRIMARY]")
            builSQL.Append(") ON [PRIMARY]")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--■A_システム
            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [A_システム] ADD 税区分 smallint NOT NULL CONSTRAINT [DF_A_システム_税区分]  DEFAULT ((2));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--■C_商品
            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [C_商品] ADD 金額管理区分 smallint NOT NULL CONSTRAINT [DF_C_商品_金額管理区分]  DEFAULT ((1));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--■E_売上
            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_売上] ADD ポイント割引番号 smallint NOT NULL CONSTRAINT [DF_E_売上_ポイント割引番号]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_売上] ADD ポイント割引支払 int NOT NULL CONSTRAINT [DF_E_売上_ポイント割引支払]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_売上] ADD サービス番号 smallint NOT NULL CONSTRAINT [DF_E_売上_サービス番号]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_売上] ADD サービス金額 int NOT NULL CONSTRAINT [DF_E_売上_サービス金額]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--■E_売上明細
            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_売上明細] ADD 消費税 int NOT NULL CONSTRAINT [DF_E_売上明細_消費税]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--■E_来店者
            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_来店者] ADD ポイント割引番号 smallint NOT NULL CONSTRAINT [DF_E_来店者_ポイント割引番号]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_来店者] ADD ポイント割引支払 int NOT NULL CONSTRAINT [DF_E_来店者_ポイント割引支払]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_来店者] ADD サービス番号 smallint NOT NULL CONSTRAINT [DF_E_来店者_サービス番号]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_来店者] ADD サービス区分 smallint NOT NULL CONSTRAINT [DF_E_来店者_サービス区分]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("ALTER TABLE [E_来店者] ADD サービス金額 int NOT NULL CONSTRAINT [DF_E_来店者_サービス金額]  DEFAULT ((0));")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--■W_レシート
            builSQL.Length = 0
            builSQL.Append("DROP TABLE W_レシート")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("CREATE TABLE [dbo].[W_レシート](")
            builSQL.Append("[番号] [smallint] NOT NULL,")
            builSQL.Append("[データタイプ] [int] NULL,")
            builSQL.Append("[氏名] [nvarchar](33) NULL,")
            builSQL.Append("[主担当者名] [nvarchar](32) NULL,")
            builSQL.Append("[品名] [nvarchar](32) NULL,")
            builSQL.Append("[数量] [int] NOT NULL CONSTRAINT [DF_W_レシート_数量]  DEFAULT ((0)),")
            builSQL.Append("[金額] [int] NOT NULL CONSTRAINT [DF_W_レシート_金額]  DEFAULT ((0)),")
            builSQL.Append("[小計] [int] NOT NULL CONSTRAINT [DF_W_レシート_小計]  DEFAULT ((0)),")
            builSQL.Append("[消費税] [int] NOT NULL CONSTRAINT [DF_W_レシート_消費税]  DEFAULT ((0)),")
            builSQL.Append("[合計] [int] NOT NULL CONSTRAINT [DF_W_レシート_合計]  DEFAULT ((0)),")
            builSQL.Append("[お釣り] [int] NULL CONSTRAINT [DF_W_レシート_お釣り]  DEFAULT ((0)),")
            builSQL.Append("CONSTRAINT [PK_W_レシート] PRIMARY KEY NONCLUSTERED ")
            builSQL.Append("(")
            builSQL.Append("[番号] Asc")
            builSQL.Append(") ON [PRIMARY]")
            builSQL.Append(") ON [PRIMARY]")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--■W_顧客抽出
            builSQL.Length = 0
            builSQL.Append("DROP TABLE W_顧客抽出")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("CREATE TABLE [dbo].[W_顧客抽出](")
            builSQL.Append("[選択] [bit] NOT NULL CONSTRAINT [DF_W_顧客抽出_選択]  DEFAULT ((0)),")
            builSQL.Append("[顧客番号] [int] NULL,")
            builSQL.Append("[姓] [nvarchar](32) NULL,")
            builSQL.Append("[名] [nvarchar](32) NULL,")
            builSQL.Append("[姓カナ] [nvarchar](32) NULL,")
            builSQL.Append("[名カナ] [nvarchar](32) NULL,")
            builSQL.Append("[性別番号] [smallint] NULL,")
            builSQL.Append("[生年月日] [datetime] NULL,")
            builSQL.Append("[郵便番号] [nvarchar](8) NULL,")
            builSQL.Append("[都道府県] [nvarchar](16) NULL,")
            builSQL.Append("[住所1] [nvarchar](128) NULL,")
            builSQL.Append("[住所2] [nvarchar](128) NULL,")
            builSQL.Append("[住所3] [nvarchar](128) NULL,")
            builSQL.Append("[電話番号] [nvarchar](19) NULL,")
            builSQL.Append("[Emailアドレス] [nvarchar](256) NULL,")
            builSQL.Append("[家族名] [nvarchar](32) NULL,")
            builSQL.Append("[趣味] [nvarchar](32) NULL,")
            builSQL.Append("[好きな話題] [nvarchar](32) NULL,")
            builSQL.Append("[嫌いな話題] [nvarchar](32) NULL,")
            builSQL.Append("[伝言フラグ] [bit] NULL,")
            builSQL.Append("[メモ] [nvarchar](64) NULL,")
            builSQL.Append("[紹介者] [nvarchar](32) NULL,")
            builSQL.Append("[前回来店日] [datetime] NULL,")
            builSQL.Append("[来店日N_1] [datetime] NULL,")
            builSQL.Append("[来店日N_2] [datetime] NULL,")
            builSQL.Append("[来店回数] [int] NULL,")
            builSQL.Append("[売上区分番号] [int] NULL,")
            builSQL.Append("[区分合計金額] [int] NULL,")
            builSQL.Append("[主担当者番号] [smallint] NULL,")
            builSQL.Append("[登録区分番号] [smallint] NULL,")
            builSQL.Append("[DM希望フラグ] [bit] NULL,")
            builSQL.Append("[登録日] [datetime] NULL,")
            builSQL.Append("[更新日] [datetime] NULL")
            builSQL.Append(") ON [PRIMARY]")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--■W_支払
            builSQL.Length = 0
            builSQL.Append("DROP TABLE W_支払")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            builSQL.Length = 0
            builSQL.Append("CREATE TABLE [dbo].[W_支払](")
            builSQL.Append("[総客本] [int] NOT NULL CONSTRAINT [DF_W_支払_総客本]  DEFAULT ((0)),")
            builSQL.Append("[現金本] [int] NOT NULL CONSTRAINT [DF_W_支払_現金本]  DEFAULT ((0)),")
            builSQL.Append("[カード本] [int] NOT NULL CONSTRAINT [DF_W_支払_カード本]  DEFAULT ((0)),")
            builSQL.Append("[その他本] [int] NOT NULL CONSTRAINT [DF_W_支払_その他本]  DEFAULT ((0)),")
            builSQL.Append("[ポイント割引本] [int] NOT NULL CONSTRAINT [DF_W_支払_ポイント割引本]  DEFAULT ((0)),")
            builSQL.Append("[消費税本] [int] NOT NULL CONSTRAINT [DF_W_支払_消費税本]  DEFAULT ((0)),")
            builSQL.Append("[現金累] [int] NOT NULL CONSTRAINT [DF_W_支払_現金累]  DEFAULT ((0)),")
            builSQL.Append("[カード累] [int] NOT NULL CONSTRAINT [DF_W_支払_カード累]  DEFAULT ((0)),")
            builSQL.Append("[その他累] [int] NOT NULL CONSTRAINT [DF_W_支払_その他累]  DEFAULT ((0)),")
            builSQL.Append("[ポイント割引累] [int] NOT NULL CONSTRAINT [DF_W_支払_ポイント割引累]  DEFAULT ((0)),")
            builSQL.Append("[消費税累] [int] NOT NULL CONSTRAINT [DF_W_支払_消費税累]  DEFAULT ((0)),")
            builSQL.Append(") ON [PRIMARY]")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

            '--■W_出力対象
            builSQL.Length = 0
            builSQL.Append("DROP TABLE W_出力対象")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())

        End Sub
#End Region

#Region "税込扱い判定"
        ''' <summary>judgeTaxType</summary>
        ''' <returns>1：税抜（本体価格）管理、2:税込価格管理</returns>
        ''' <remarks></remarks>
        Function judgeTaxType() As Int16
            Dim builSQL As New StringBuilder()
            Dim str_sql As String
            Dim dt As New DataTable
            Dim rtn As Int16 = 1

            Try
                str_sql = "SELECT COUNT(*) FROM B_消費税 WHERE 税率=0"
                dt = DBA.ExecuteDataTable(str_sql)

                If (dt.Rows(0)(0).ToString() > 0) Then
                    rtn = 2
                End If
                Return rtn

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "テーブルの値変換"
        ''' <summary>テーブルの値変換</summary>
        ''' <remarks></remarks>
        Sub upServerPoint()
            Dim builSQL As New StringBuilder()
            Dim dt As New DataTable

            '■ポイント割引
            builSQL.Length = 0
            builSQL.Append("SELECT * FROM [B_ポイント割引]")
            dt = DBA.ExecuteDataTable(builSQL.ToString())

            For Each dr As DataRow In dt.Rows
                '□Z_SQL実行履歴 DELETE
                builSQL.Length = 0
                builSQL.Append("DELETE FROM point_purchases WHERE")
                builSQL.Append(" shop_code=" & VbSQLNStr(sShopcode))
                builSQL.Append(" AND code=" & VbSQLStr(dr.Item("ポイント割引番号").ToString()))
                InsertZSqlExecHis(TITLE, builSQL.ToString)

                '□Z_SQL実行履歴 INSERT
                builSQL.Length = 0
                builSQL.Append("INSERT INTO point_purchases (shop_code,code,name,display_order,delete_flag,insert_date,update_date) VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(dr.Item("ポイント割引番号").ToString()))
                builSQL.Append("," & VbSQLNStr(dr.Item("ポイント割引名").ToString()))
                builSQL.Append("," & VbSQLStr(dr.Item("表示順").ToString()))
                If dr.Item("削除フラグ") = True Then
                    builSQL.Append(",''1''")
                Else
                    builSQL.Append(",''0''")
                End If

                builSQL.Append("," & VbSQLStr(dr.Item("登録日").ToString()))
                builSQL.Append("," & VbSQLStr(dr.Item("更新日").ToString()))
                builSQL.Append(")")
                InsertZSqlExecHis(TITLE, builSQL.ToString)
            Next

            '■サービス
            builSQL.Length = 0
            builSQL.Append("SELECT * FROM [B_サービス]")
            dt = DBA.ExecuteDataTable(builSQL.ToString())

            For Each dr As DataRow In dt.Rows
                '□Z_SQL実行履歴 DELETE
                builSQL.Length = 0
                builSQL.Append("DELETE FROM service WHERE")
                builSQL.Append(" shop_code=" & VbSQLNStr(sShopcode))
                builSQL.Append(" AND code=" & VbSQLStr(dr.Item("サービス番号").ToString()))
                InsertZSqlExecHis(TITLE, builSQL.ToString)

                '□Z_SQL実行履歴 INSERT
                builSQL.Length = 0
                builSQL.Append("INSERT INTO service (shop_code,code,name,display_order,delete_flag,insert_date,update_date) VALUES (")
                builSQL.Append(VbSQLNStr(sShopcode))
                builSQL.Append("," & VbSQLStr(dr.Item("サービス番号").ToString()))
                builSQL.Append("," & VbSQLNStr(dr.Item("サービス名").ToString()))
                builSQL.Append("," & VbSQLStr(dr.Item("表示順").ToString()))
                If dr.Item("削除フラグ") = True Then
                    builSQL.Append(",''1''")
                Else
                    builSQL.Append(",''0''")
                End If

                builSQL.Append("," & VbSQLStr(dr.Item("登録日").ToString()))
                builSQL.Append("," & VbSQLStr(dr.Item("更新日").ToString()))
                builSQL.Append(")")
                InsertZSqlExecHis(TITLE, builSQL.ToString)
            Next
            '■A_システム変更
            builSQL.Length = 0
            builSQL.Append("UPDATE A_システム SET 予備2='ポイント割引'")
            dt = DBA.ExecuteDataTable(builSQL.ToString())

            '□Z_SQL実行履歴 INSERT
            UpDateForSever_System()

        End Sub
#End Region

#Region "テーブルの値変換"
        ''' <summary>テーブルの値変換</summary>
        ''' <remarks></remarks>
        Sub changeData()
            Dim builSQL As New StringBuilder()
            Dim dt As New DataTable

            '--■B_ポイント割引
            '--変換なし

            '--■A_システム（1：免税事業者、2：課税事業者）
            builSQL.Length = 0
            builSQL.Append("UPDATE [A_システム] SET 税区分='2',予備2='税込対応',変更日時=getdate()")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())
            '□Z_SQL実行履歴 INSERT
            UpDateForSever_System()

            '--■C_商品（1：税抜（本体価格）管理、2:税込価格管理）
            builSQL.Length = 0
            builSQL.Append("UPDATE [C_商品] SET 金額管理区分='" & managementTax & "';")
            rtn = DBA.ExecuteNonQuery(builSQL.ToString())
            '□Z_SQL実行履歴 INSERT
            builSQL.Length = 0
            builSQL.Append("UPDATE goods SET")
            builSQL.Append(" management_tax=" & VbSQLStr(managementTax))
            builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
            InsertZSqlExecHis(TITLE, builSQL.ToString)

            '--■E_売上
            '--変換なし

            '--■E_売上明細
            If managementTax = 1 Then
                builSQL.Length = 0
                Select Case taxType
                    Case 1 ' 切り捨て
                        builSQL.Append("UPDATE E_売上明細 SET 消費税 = FLOOR((金額 * 数量 - サービス) * " & tax & ")")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '□Z_SQL実行履歴 INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" tax= FLOOR((amount * count - service_amount) * " & tax & ")")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                    Case 2 ' 四捨五入
                        builSQL.Append("UPDATE E_売上明細 SET 消費税 = ROUND((金額 * 数量 - サービス) * " & tax & ",0)")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '□Z_SQL実行履歴 INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" tax= ROUND((amount * count - service_amount) * " & tax & ",0)")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                    Case Else ' 切り上げ
                        builSQL.Append("UPDATE E_売上明細 SET 消費税 = CEILING((金額 * 数量 - サービス) * " & tax & ")")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '□Z_SQL実行履歴 INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" tax= CEILING((amount * count - service_amount) * " & tax & ")")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                End Select

                builSQL.Length = 0
                builSQL.Append("UPDATE E_売上明細 SET 金額 = CEILING(金額 * " & 1 + tax & ")")
                rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                '□Z_SQL実行履歴 INSERT
                builSQL.Length = 0
                builSQL.Append("UPDATE sales_details SET")
                builSQL.Append(" amount= CEILING(amount * " & 1 + tax & ")")
                builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(TITLE, builSQL.ToString)

                builSQL.Length = 0
                Select Case ServiceType
                    Case 1 ' 切り捨て
                        builSQL.Append("UPDATE E_売上明細 SET サービス = FLOOR(サービス * " & 1 + tax & ")")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '□Z_SQL実行履歴 INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" service_amount= FLOOR(service_amount * " & 1 + tax & ")")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                    Case 2 ' 四捨五入
                        builSQL.Append("UPDATE E_売上明細 SET サービス = ROUND(サービス * " & 1 + tax & ",0)")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '□Z_SQL実行履歴 INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" service_amount= ROUND(service_amount * " & 1 + tax & ",0)")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                    Case Else ' 切り上げ
                        builSQL.Append("UPDATE E_売上明細 SET サービス = CEILING(サービス * " & 1 + tax & ")")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '□Z_SQL実行履歴 INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" service_amount= CEILING(service_amount * " & 1 + tax & ")")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                End Select

                builSQL.Length = 0
                builSQL.Append("SELECT c.来店日,c.来店者番号,c.売上番号,c.金額+差額 AS 修正金額")
                builSQL.Append(" FROM ( SELECT")
                builSQL.Append(" E_売上.来店日 AS 来店日")
                builSQL.Append(" ,E_売上.来店者番号 AS 来店者番号")
                builSQL.Append(" ,現金支払+カード支払+その他支払-支払 AS 差額")
                builSQL.Append(" ,支払")
                builSQL.Append(" ,現金支払+カード支払+その他支払 AS 金額")
                builSQL.Append(" FROM (")
                builSQL.Append(" SELECT 来店日,来店者番号,SUM(金額*数量 -サービス) AS 支払 FROM E_売上明細")
                builSQL.Append(" GROUP BY 来店日,来店者番号) AS MEISAI")
                builSQL.Append(" LEFT OUTER JOIN E_売上")
                builSQL.Append(" ON E_売上.来店日=MEISAI.来店日")
                builSQL.Append(" AND E_売上.来店者番号=MEISAI.来店者番号")
                builSQL.Append(" WHERE 現金支払+カード支払 + その他支払  > MEISAI.支払")
                builSQL.Append(" ) AS a")
                builSQL.Append(" INNER JOIN")
                builSQL.Append(" (SELECT E_売上明細.*")
                builSQL.Append(" FROM E_売上明細,")
                builSQL.Append(" (SELECT 来店日,来店者番号,MIN(売上番号) AS 売上番号")
                builSQL.Append(" FROM E_売上明細")
                builSQL.Append(" GROUP BY 来店日,来店者番号) AS b")
                builSQL.Append(" WHERE(E_売上明細.来店日 = b.来店日)")
                builSQL.Append(" AND E_売上明細.来店者番号 =b.来店者番号")
                builSQL.Append(" AND E_売上明細.売上番号 =b.売上番号")
                builSQL.Append(" ) AS c")
                builSQL.Append(" ON c.来店日=a.来店日")
                builSQL.Append(" AND c.来店者番号=a.来店者番号")
                dt = DBA.ExecuteDataTable(builSQL.ToString())

                For Each dr As DataRow In dt.Rows
                    builSQL.Length = 0
                    builSQL.Append("UPDATE E_売上明細 SET 金額='" & dr.Item("修正金額").ToString() & "'")
                    builSQL.Append(" WHERE 来店日='" & dr.Item("来店日").ToString() & "'")
                    builSQL.Append(" AND 来店者番号='" & dr.Item("来店者番号").ToString() & "'")
                    builSQL.Append(" AND 売上番号='" & dr.Item("売上番号").ToString() & "'")
                    rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                    '□Z_SQL実行履歴 INSERT
                    builSQL.Length = 0
                    builSQL.Append("UPDATE sales_details SET")
                    builSQL.Append(" amount=" & VbSQLStr(dr.Item("修正金額").ToString()))
                    builSQL.Append(" WHERE visit_date=" & VbSQLStr(dr.Item("来店日").ToString()))
                    builSQL.Append(" AND visit_number=" & VbSQLStr(dr.Item("来店者番号").ToString()))
                    builSQL.Append(" AND code=" & VbSQLStr(dr.Item("売上番号").ToString()))
                    builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                    InsertZSqlExecHis(TITLE, builSQL.ToString)
                Next

                builSQL.Length = 0
                builSQL.Append("SELECT c.来店日,c.来店者番号,c.売上番号,c.サービス-差額 AS 修正金額")
                builSQL.Append(" FROM ( SELECT")
                builSQL.Append(" E_売上.来店日 AS 来店日")
                builSQL.Append(" ,E_売上.来店者番号 AS 来店者番号")
                builSQL.Append(" ,現金支払+カード支払+その他支払-支払 AS 差額")
                builSQL.Append(" ,支払")
                builSQL.Append(" ,現金支払+カード支払+その他支払 AS 金額")
                builSQL.Append(" FROM (")
                builSQL.Append(" SELECT 来店日,来店者番号,SUM(金額*数量 -サービス) AS 支払 FROM E_売上明細")
                builSQL.Append(" GROUP BY 来店日,来店者番号) AS MEISAI")
                builSQL.Append(" LEFT OUTER JOIN E_売上")
                builSQL.Append(" ON E_売上.来店日=MEISAI.来店日")
                builSQL.Append(" AND E_売上.来店者番号=MEISAI.来店者番号")
                builSQL.Append(" WHERE 現金支払+カード支払 + その他支払 <> MEISAI.支払")
                builSQL.Append(" ) AS a")
                builSQL.Append(" INNER JOIN")
                builSQL.Append(" (SELECT E_売上明細.*")
                builSQL.Append(" FROM E_売上明細,")
                builSQL.Append(" (SELECT 来店日,来店者番号,MIN(売上番号) AS 売上番号")
                builSQL.Append(" FROM E_売上明細")
                builSQL.Append(" GROUP BY 来店日,来店者番号) AS b")
                builSQL.Append(" WHERE(E_売上明細.来店日 = b.来店日)")
                builSQL.Append(" AND E_売上明細.来店者番号 =b.来店者番号")
                builSQL.Append(" AND E_売上明細.売上番号 =b.売上番号")
                builSQL.Append(" ) AS c")
                builSQL.Append(" ON c.来店日=a.来店日")
                builSQL.Append(" AND c.来店者番号=a.来店者番号")
                dt = DBA.ExecuteDataTable(builSQL.ToString())

                For Each dr As DataRow In dt.Rows
                    builSQL.Length = 0
                    builSQL.Append("UPDATE E_売上明細 SET サービス='" + dr.Item("修正金額").ToString() + "'")
                    builSQL.Append(" WHERE 来店日='" + dr.Item("来店日").ToString() + "'")
                    builSQL.Append(" AND 来店者番号='" + dr.Item("来店者番号").ToString() + "'")
                    builSQL.Append(" AND 売上番号='" + dr.Item("売上番号").ToString() + "'")
                    rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                    '□Z_SQL実行履歴 INSERT
                    builSQL.Length = 0
                    builSQL.Append("UPDATE sales_details SET")
                    builSQL.Append(" service_amount=" & VbSQLStr(dr.Item("修正金額").ToString()))
                    builSQL.Append(" WHERE visit_date=" & VbSQLStr(dr.Item("来店日").ToString()))
                    builSQL.Append(" AND visit_number=" & VbSQLStr(dr.Item("来店者番号").ToString()))
                    builSQL.Append(" AND code=" & VbSQLStr(dr.Item("売上番号").ToString()))
                    builSQL.Append(" AND shop_code=" & VbSQLNStr(sShopcode))
                    InsertZSqlExecHis(TITLE, builSQL.ToString)
                Next
            Else
                builSQL.Length = 0
                Select Case taxType
                    Case 1 ' 切り捨て
                        builSQL.Append("UPDATE E_売上明細 SET 消費税 = FLOOR((金額 * 数量 - サービス) /" & 1 + tax & " * " & tax & ")")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '□Z_SQL実行履歴 INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" tax= FLOOR((amount * count - service_amount) / " & 1 + tax & " * " & tax & ")")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                    Case 2 ' 四捨五入
                        builSQL.Append("UPDATE E_売上明細 SET 消費税 = ROUND((金額 * 数量 - サービス) /" & 1 + tax & " * " & tax & ",0)")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '□Z_SQL実行履歴 INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" tax= ROUND((amount * count - service_amount) / " & 1 + tax & " * " & tax & ",0)")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                    Case Else ' 切り上げ
                        builSQL.Append("UPDATE E_売上明細 SET 消費税 = CEILING((金額 * 数量 - サービス) /" & 1 + tax & " * " & tax & ")")
                        rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                        '□Z_SQL実行履歴 INSERT
                        builSQL.Length = 0
                        builSQL.Append("UPDATE sales_details SET")
                        builSQL.Append(" tax= CEILING((amount * count - service_amount) / " & 1 + tax & " * " & tax & ")")
                        builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                        InsertZSqlExecHis(TITLE, builSQL.ToString)
                End Select

                builSQL.Length = 0
                builSQL.Append("UPDATE E_売上 SET ")
                builSQL.Append(" 消費税=(")
                builSQL.Append(" SELECT SUM(消費税)")
                builSQL.Append(" FROM E_売上明細")
                builSQL.Append(" WHERE E_売上.来店日 = E_売上明細.来店日")
                builSQL.Append(" AND E_売上.来店者番号=E_売上明細.来店者番号")
                builSQL.Append(" GROUP BY E_売上明細.来店日,E_売上明細.来店者番号")
                builSQL.Append(")")
                rtn = DBA.ExecuteNonQuery(builSQL.ToString())
                '□Z_SQL実行履歴 INSERT
                builSQL.Length = 0
                builSQL.Append("UPDATE sales SET")
                builSQL.Append(" tax= ( SELECT SUM(tax) FROM sales_details")
                builSQL.Append(" WHERE sales.visit_date = sales_details.visit_date")
                builSQL.Append(" AND sales.visit_number = sales_details.visit_number")
                builSQL.Append(" GROUP BY sales_details.visit_date,sales_details.visit_number")
                builSQL.Append(" )")
                builSQL.Append(" WHERE shop_code=" & VbSQLNStr(sShopcode))
                InsertZSqlExecHis(TITLE, builSQL.ToString)
            End If

            '--■E_来店者
            '--変換なし

            '--■W_レシート
            '--変換なし

            '--■W_顧客抽出
            '--変換なし

            '--■W_支払
            '--変換なし

            '--■W_出力対象
            '--変換なし

        End Sub
#End Region
    End Class
End Namespace
