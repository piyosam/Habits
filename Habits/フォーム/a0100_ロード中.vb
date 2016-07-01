'システム名 ： HABITS
'機能名　　 ： a0100_ロード中
'概要　　　 ： 初期ロード処理
'履歴　　　 ： 2010/04/26　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Imports System.Text

Public Class a0100_ロード中

#Region "変数・定数定義"

    Private bChecked As Boolean = False         ' マスタデータチェック済フラグ
    Private logic As Habits.Logic.a0100_Logic

    Private logic_base As Habits.Logic.LogicBase
#End Region

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0100_ロード中_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '画面イメージを表示させるため、Timerにて処理を行う。

        ' システムVerを取得しサーバに登録する。
        logic_base = New Habits.Logic.LogicBase
        logic_base.SystemVerForSever(My.Application.Info.Version.ToString())

    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <remarks></remarks>
    Private Sub a0100_ロード中_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "タイマー処理"
    ''' <summary>タイマー処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LoadTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadTimer.Tick
        If (bChecked = False) Then
            ' マスタダウンロードチェック
            checkMasterDownload()
            Me.Close()
        End If
    End Sub
#End Region

#End Region

#Region "メソッド"

#Region "マスタダウンロードチェック"
    ''' <summary>マスタダウンロードチェック</summary>
    ''' <remarks></remarks>
    Protected Sub checkMasterDownload()
        logic = New Habits.Logic.a0100_Logic
        Me.Activate()

        'チェック済に変更
        bChecked = True
        Try
            '（Webシステム）マスタ更新データ有無チェック
            Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "MasterUpdateCheck.aspx"
            Dim wc As New System.Net.WebClient

            'NameValueCollectionの作成
            Dim ps As New System.Collections.Specialized.NameValueCollection
            Dim sUdDate As String
            Dim dt As New DataTable

            ' 最終ダウンロード時間取得
            dt = logic.selectDownloadDate()
            sUdDate = dt.Rows(0)("最終ダウンロード").ToString()

            '送信するデータ（フィールド名と値の組み合わせ）を追加
            ps.Add("q1", My.Settings.LoginName)
            ps.Add("q2", My.Settings.LoginPassword)
            ps.Add("q3", sShopcode)
            ps.Add("q4", sUdDate)
            wc.QueryString = ps

            'データを送信し、また受信する
            Dim resData As Byte() = wc.UploadValues(url, ps)
            Dim result As String = Encoding.UTF8.GetString(resData)
            wc.Dispose()

            If result.ToString.StartsWith("1") = True Then
                '正常時
                rtn = MsgBox("マスタデータが更新されています。　" & Chr(13) & Chr(13) & _
                "データ受信を行ってください。　", Clng_Okinb1, TTL)

            ElseIf result.ToString.StartsWith("-2") = True Then
                '更新必要が無い場合メッセージなし
            Else
                'Web側で認証に失敗した場合
                rtn = MsgBox("認証エラーが発生しました。　" & Chr(13) & Chr(13) & _
                "システム管理者に連絡してください。　", Clng_Okexb1, TTL)
            End If

        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("接続エラーが発生しました。　" & Chr(13) & Chr(13) & _
                    "インターネットへの接続を確認してください。　", Clng_Okexb1, TTL)
        End Try
    End Sub
#End Region

#End Region

End Class
