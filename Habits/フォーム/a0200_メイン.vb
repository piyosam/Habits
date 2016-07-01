'システム名 ： HABITS
'機能名　　 ： a0200_メイン
'概要　　　 ： メイン画面表示機能
'履歴　　　 ： 2010/04/26　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Imports System.Text

Public Class a0200_メイン

#Region "変数・定数定義"

    Dim downloadClient As System.Net.WebClient = Nothing
    Private logic As Habits.Logic.a0200_Logic
    Private a0100_logic As Habits.Logic.a0100_Logic     'データ修正処理追加時に使用
    Private SwitchData_logic As Habits.Logic.SwitchData 'データ修正処理追加時に使用
    Private bReserve As Boolean = False
    Private bMaster As Boolean = False
    Private str_path As String = Nothing
    Private upTime As String = Nothing
    Private Const PAGE_TITLE As String = "a0200_メイン"

#End Region

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0200_メイン_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt As DataTable
        logic = New Habits.Logic.a0200_Logic
        a0100_logic = New Habits.Logic.a0100_Logic
        SwitchData_logic = New Habits.Logic.SwitchData
        Me.Activate()

        Try
            TimerDataSync.Enabled = False
            M01 = Me

            '' システム開始処理
            rtn = Sys_Init()

            '' 計算タイプ取得
            setTaxType()
            setServiceType()

            ' ダウンロード格納パス設定
            Me.str_path = logic.getStockPath()

            '----------------データ修正時に使用------------------
            ''20131113
            'a0100_logic.updateKurihama()

            '当日変更不可
            'If sShopcode = "kawasaki" Then
            '    SwitchData_logic.switchNGPast()
            'End If

            '当日変更可
            'If sShopcode = "ebina" Then
            'SwitchData_logic.switchNGPast()
            'End If

            'ポイント修正
            'SwitchData_logic.upPoint()
            ''A_システム変数設定
            'SwitchData_logic.setA_SystemVariable()
            '----------------データ修正時に使用------------------

            '' 予約データ受信
            receiveReserve(0)

            '' 機能の使用権限設定
            setAdminMenu()                  ' 管理者機能
            setReserveMenu()                ' 予約機能
            setReceiptMenu()                ' レシート印刷機能

            '' タイトルバーの文字設定
            setTitleBar()

            Me.lbl_Connect.Visible = False
            If (setTransmitMenu()) Then
                TimerDataSync.Enabled = True

                If NETWORK_FLAG = True Then
                    dt = logic.GetConnectError()
                    If (dt.Rows.Count > 0 AndAlso Integer.Parse(dt.Rows(0)("通信中エラー回数").ToString) >= CONNECT_ERROR) Then
                        Me.lbl_Connect.Visible = True
                    End If
                End If
            End If

            '' 画面再表示
            ReDisplay()
            FreeCursor()
            Me.ActiveControl = Me.btn来店   ' 「来店」ボタンにフォーカス            
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            Me.Close()
        End Try
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0200_メイン_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Sys_Exit()
    End Sub
#End Region

#Region "来店者タブクリック処理"
    ''' <summary>
    ''' 来店者タブのどこかがClickされた場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tp来店者_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tp来店者.Click
        setFocus()
    End Sub
#End Region

#Region "会計済タブクリック処理"
    ''' <summary>
    ''' 会計済タブのどこかがClickされた場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tp会計済_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tp会計済.Click
        setFocus()
    End Sub
#End Region

#Region "予約タブクリック処理"
    ''' <summary>
    ''' 予約タブのどこかがClickされた場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tp予約_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tp予約.Click
        setFocus()
    End Sub
#End Region

#Region "顧客情報タブクリック処理"
    ''' <summary>
    ''' 顧客情報タブのどこかがClickされた場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tc詳細情報_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tc詳細情報.Click
        setFocus()
    End Sub
#End Region

#Region "来店情報のタブ選択処理"
    ''' <summary>
    ''' 来店情報タブを変更した場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tc来店情報_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tc来店情報.SelectedIndexChanged
        ' コントロール初期化
        FreeCursor()
    End Sub
#End Region

#Region "詳細情報のタブ選択処理"
    ''' <summary>
    ''' 詳細情報タブを変更した場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tc詳細情報_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tc詳細情報.SelectedIndexChanged
        ' フォーカス設定
        setFocus()
    End Sub
#End Region

#Region "顧客情報のタブ選択処理"
    ''' <summary>
    ''' 顧客情報タブを変更した場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tc顧客詳細_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tc顧客詳細.SelectedIndexChanged
        ' フォーカス設定
        setFocus()
    End Sub
#End Region

#Region "来店者一覧クリック処理"
    ''' <summary>
    ''' 来店者一覧のどこかがClickされた場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv来店者一覧_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv来店者一覧.CellClick
        Me.btnカルテ.Enabled = True
        Me.btn変更.Enabled = True
        Me.btn待ち.Enabled = True
        If (dgv来店者一覧.SelectedRows(0).Cells(9).Value.ToString().Equals("待ち")) Then
            btn待ち.Text = "施術開始"
        Else
            btn待ち.Text = "施術待ち"
        End If

        ' フォーカス設定
        setFocus()
    End Sub
#End Region

#Region "会計済一覧クリック処理"
    ''' <summary>
    ''' 会計済一覧のどこかがClickされた場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv会計済み一覧_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv会計済み一覧.CellClick
        Me.btnカルテ.Enabled = True
        Me.btn変更.Enabled = True
        ' フォーカス設定
        setFocus()
    End Sub
#End Region

#Region "予約一覧クリック処理"
    ''' <summary>
    ''' 予約一覧のどこかがClickされた場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv予約一覧_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv予約一覧.CellClick
        ' フォーカス設定
        setFocus()
    End Sub
#End Region

#Region "過去来店日一覧クリック処理"
    ''' <summary>
    ''' 過去来店日一覧のどこかがClickされた場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv過去来店日一覧_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv過去来店日一覧.CellClick
        ' フォーカス設定
        setFocus()
    End Sub
#End Region

#Region "売上一覧クリック処理"
    ''' <summary>
    ''' 売上一覧のどこかがClickされた場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv売上一覧_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv売上一覧.CellClick
        ' フォーカス設定
        setFocus()
    End Sub
#End Region

#Region "カルテ一覧クリック処理"
    ''' <summary>
    ''' カルテ一覧のどこかがClickされた場合の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvカルテ一覧_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvカルテ一覧.CellClick
        ' フォーカス設定
        setFocus()
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "メッセージ登録ボタン押下"
    ''' <summary>メッセージ登録ボタンクリック時処理</summary>
    ''' <remarks></remarks>
    Private Sub BtnMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMessage.Click
        i0100_メッセージ登録.ShowDialog()
        ' フォーカス設定
        setFocus()
    End Sub
#End Region

#Region "設定日ボタン押下"
    ''' <summary>設定日ボタンクリック時処理</summary>
    ''' <remarks></remarks>
    Private Sub Btn設定日_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn設定日.Click
        a0700_日付設定.ShowDialog()
        ReDisplay()
        FreeCursor()
    End Sub
#End Region

#Region "スタッフ選択ボタン押下"
    ''' <summary>
    ''' スタッフ選択ボタンクリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Btnスタッフ選択_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnスタッフ選択.Click
        a0800_スタッフ選択.int_mode = 1
        a0800_スタッフ選択.ShowDialog()
        Me.ActiveControl = Me.btn来店   ' 「来店」ボタンにフォーカス
        Me.Activate()
    End Sub
#End Region

#Region "顧客検索ボタン押下"
    ''' <summary>
    ''' 顧客検索ボタンクリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnSearchCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn顧客検索.Click
        z_0300_顧客検索.検索loaded = False
        z_0300_顧客検索.ShowDialog()
        ' フォーカス設定
        setFocus()
    End Sub
#End Region

#Region "来店者・来店ボタン押下"
    ''' <summary>来店ボタンクリック時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn来店_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn来店.Click
        a0300_来店.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "来店者・会計ボタン押下"
    ''' <summary>来店者・会計ボタンクリック時の処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn売上_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn売上.Click
        If Not isVisitorSelection() Then Exit Sub

        ReCheckFlag = False         '再会計チェックフラグ：通常会計
        c0100_売上.ShowDialog()
        ReDisplay()
        FreeCursor()
        Me.Activate()
    End Sub
#End Region

#Region "来店者・取消ボタン押下"
    ''' <summary>来店者・取消ボタンクリック時の処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn取消_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn取消.Click
        Dim i As Integer = 0
        Dim int_number As Integer = 0   ' 来店回数
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        If Not isVisitorSelection() Then Exit Sub

        If (MsgBox(Me.lbl姓.Text & " 様の来店を取り消しますか？　", Clng_Ynqub1, TTL) = vbNo) Then
            Me.btn来店.Focus()
            Exit Sub
        End If

        Try
            ' トランザクション開始
            DBA.TransactionStart()

            Dim EUM As New DataTable     ' E_売上明細
            Dim EKA As New DataTable     ' E_カルテ

            'E_売上明細削除
            param.Clear()
            param.Add("@来店日", USER_DATE)
            param.Add("@来店者番号", SER_NO)
            param.Add("@顧客番号", CST_CODE)
            logic.E_売上明細削除(param)

            'E_カルテ削除
            logic.delete_carte(param, PAGE_TITLE)

            'E_来店者更新
            logic.DeleteVisitor(param)

            'D_顧客テーブル更新
            dt = logic.select_number(param)
            If dt.Rows.Count <> 0 Then
                int_number = Integer.Parse(dt.Rows(0)("来店回数").ToString) - 1
            End If

            param.Clear()
            param.Add("@来店回数", int_number)
            param.Add("@更新日", Now)
            param.Add("@顧客番号", CST_CODE)
            logic.DeleteCustomer(param)

            ' コミット
            DBA.TransactionCommit()
        Catch ex As Exception
            ' ロールバック
            DBA.TransactionRollBack()
            Throw ex
        End Try
        '' 画面再表示
        ReDisplay()
        FreeCursor()
    End Sub
#End Region

#Region "会計済・時間、工程ボタン押下"
    ''' <summary>会計済・時間、工程ボタンクリック時</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn作業時間_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn作業時間.Click

        If Me.dgv会計済み一覧.SelectedRows.Count <> 0 Then
            a1500_作業時間設定.顧客番号.Text = Me.dgv会計済み一覧.CurrentRow.Cells(2).Value.ToString
            a1500_作業時間設定.日付.Text = USER_DATE.ToString("yyyy/MM/dd(ddd\)")
            a1500_作業時間設定.来店者番号.Text = Me.dgv会計済み一覧.CurrentRow.Cells(1).Value.ToString
            a1500_作業時間設定.顧客名.Text = Me.dgv会計済み一覧.CurrentRow.Cells(3).Value.ToString
            a1500_作業時間設定.来店日.Text = Me.dgv会計済み一覧.CurrentRow.Cells(0).Value.ToString
            a1500_作業時間設定.主担当者名.Text = Me.dgv会計済み一覧.CurrentRow.Cells(8).Value.ToString

            a1500_作業時間設定.ShowDialog()
            Me.btn会計編集.Focus()
        Else
            MsgBox("会計済み来店者を選択してください。　", Clng_Okexb1, TTL)
            Me.btn作業時間.Focus()
        End If
        Me.Activate()
    End Sub
#End Region

#Region "会計済・会計ボタン押下"
    ''' <summary>会計済・会計ボタンクリック時の処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn会計編集_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn会計編集.Click
        '---------------↓たまにセルクリックイベントが発生しても顧客番号、来店者番号が取得できないときがあるので保険で追加しました--------------
        If CST_CODE = 0 Or SER_NO = 0 Then
            rtn = MsgBox("もう一度来店者を選択してください。　", Clng_Okexb1, TTL)
            Exit Sub
        End If
        '---------------↑同上------------------------------------------------------------------------------------------------------------------
        If Not isBilledSelection() Then Exit Sub
        ReCheckFlag = True         '再会計チェックフラグ：再会計
        c0100_売上.ShowDialog()
        ReDisplay()
        FreeCursor()
        Me.Activate()
    End Sub
#End Region

#Region "予約者・来店ボタン押下"
    ''' <summary>
    ''' 予約者・来店ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn予約者来店_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn予約者来店.Click
        If Me.dgv予約一覧.SelectedRows.Count <> 0 Then
            a0300_来店.reserve_number = Me.dgv予約一覧.CurrentRow.Cells(4).Value.ToString

            a0300_来店.reserve_mode = True
            a0300_来店.ShowDialog()
            Me.Activate()
        Else
            MsgBox("予約一覧から予約者を選択してください。　", Clng_Okexb1, TTL)
        End If
    End Sub
#End Region

#Region "予約者・データ受信ボタン押下"
    ''' <summary>
    ''' 予約者・データ受信ボタンクリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 予約受信_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 予約受信.Click
        receiveReserve(0)
        '' 画面再表示
        ReDisplay()
        FreeCursor()
    End Sub
#End Region

#Region "カルテ・カルテ入力ボタン押下"
    ''' <summary>カルテ・カルテ入力ボタンクリック時の処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnカルテ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnカルテ.Click
        If Me.dgv来店者一覧.SelectedRows.Count = 0 Then
            If Me.dgv会計済み一覧.SelectedRows.Count = 0 Then
                Exit Sub
            Else
                a1300_カルテ.担当者名.Text = Me.dgv会計済み一覧.CurrentRow.Cells("担当").Value.ToString
            End If
        Else
            a1300_カルテ.担当者名.Text = Me.dgv来店者一覧.CurrentRow.Cells("担当").Value.ToString
        End If
        a1300_カルテ.ShowDialog()

        SetDetailInfo()
        setFocus()
    End Sub
#End Region

#Region "顧客情報・変更ボタン押下"
    ''' <summary>
    ''' 顧客情報・変更ボタンクリック時の処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCustomerInfoChenge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn変更.Click
        Dim type As Integer = 0
        Dim count As Integer = 0

        z_0500_顧客変更.button_mode = False ''顧客情報変更ボタン押下時は顧客変更画面の検索ボタンは表示させない
        If Me.dgv来店者一覧.SelectedRows.Count = 0 Then
            If Me.dgv会計済み一覧.SelectedRows.Count = 0 Then
                Exit Sub
            Else
                type = 2
                count = Me.dgv会計済み一覧.SelectedRows(0).Index
            End If
        Else
            type = 1
            count = Me.dgv来店者一覧.SelectedRows(0).Index
        End If

        z_0500_顧客変更.来店日.Text = ""    ' men_来店者登録以外は設定不要
        z_0500_顧客変更.来店者番号.Text = ""

        Dim dt As New DataTable

        '顧客番号に該当する顧客がいた場合に処理
        If Not Me.lbl顧客番号.Text.Equals("") Then
            z_0500_顧客変更.lbl顧客番号.Text = Me.lbl顧客番号.Text
            z_0500_顧客変更.変更.Enabled = True
            z_0500_顧客変更.削除.Enabled = True

            z_0500_顧客変更.姓.Focus()
            z_0500_顧客変更.ShowDialog()

            If type = 1 Then
                Me.dgv来店者一覧.Rows(count).Selected = True
            ElseIf type = 2 Then
                Me.dgv会計済み一覧.Rows(count).Selected = True
            End If

            SetDetailInfo()
        End If
        dt.Dispose()
        Me.ActiveControl = Me.btn来店   ' 「来店」ボタンにフォーカス
        Me.Activate()
    End Sub

#Region "来店者一覧選択処理"
    ''' <summary>
    ''' 来店者一覧選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv来店者一覧_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv来店者一覧.SelectionChanged
        Dim dt As New DataTable

        If Me.dgv来店者一覧.SelectedRows.Count <> 0 Then
            '' 来店者番号を取得
            SER_NO = Integer.Parse(Me.dgv来店者一覧.SelectedRows(0).Cells(1).Value.ToString)

            '' 顧客番号を設定
            CST_CODE = Integer.Parse(Me.dgv来店者一覧.SelectedRows(0).Cells(2).Value.ToString)

            '' 詳細情報設定
            SetDetailInfo()

            '' 会計済み一覧選択解除
            Me.dgv会計済み一覧.ClearSelection()

            If Me.dgv来店者一覧.SelectedRows(0).Cells(12).Value.ToString = "○" Then
                Me.tc詳細情報.SelectedIndex = 1
                Me.tc顧客詳細.SelectedIndex = 2
            End If
        End If
        ' フォーカス設定
        setFocus()
    End Sub
#End Region

#Region "会計済一覧選択処理"
    ''' <summary>
    ''' 会計済一覧選択処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv会計済み一覧_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv会計済み一覧.SelectionChanged
        Dim dt As New DataTable

        If Me.dgv会計済み一覧.SelectedRows.Count <> 0 Then
            '' 来店者番号を取得
            SER_NO = Integer.Parse(Me.dgv会計済み一覧.SelectedRows(0).Cells(1).Value.ToString)

            '' 顧客番号を設定
            CST_CODE = Long.Parse(Me.dgv会計済み一覧.SelectedRows(0).Cells(2).Value.ToString)

            '' 詳細情報設定
            SetDetailInfo()

            '' 来店者一覧選択解除
            Me.dgv来店者一覧.ClearSelection()
        End If
    End Sub
#End Region

#Region "カルテ・過去来店日一覧選択"
    ''' <summary>カルテ情報-過去来店日一覧 選択変更</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgv過去来店日一覧_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgv過去来店日一覧.SelectionChanged
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        If Me.dgv過去来店日一覧.SelectedRows.Count <> 0 Then
            '' パラメータ設定（@来店日/@来店者番号/@顧客番号）
            param.Add("@来店日", Me.dgv過去来店日一覧.SelectedRows(0).Cells(0).Value)
            param.Add("@来店者番号", Me.dgv過去来店日一覧.SelectedRows(0).Cells(1).Value)
            param.Add("@顧客番号", Me.dgv過去来店日一覧.SelectedRows(0).Cells(2).Value)
            '' データ取得
            dt = logic.ClinicalRecordSales(param)
            Me.dgv売上一覧.DataSource = dt
            Me.dgv売上一覧.Columns(0).Width = 52     ' 売上区分 
            Me.dgv売上一覧.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            Me.dgv売上一覧.Columns(1).Width = 150    ' 商品
            Me.dgv売上一覧.Columns(1).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            Me.dgv売上一覧.Columns(2).Width = 30     ' 数量
            Me.dgv売上一覧.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.dgv売上一覧.Columns(3).Width = 55     ' 金額
            Me.dgv売上一覧.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.dgv売上一覧.Columns(4).Width = 55     ' サービス
            Me.dgv売上一覧.Columns(4).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.dgv売上一覧.Columns(5).Visible = False ' 売上区分番号
            Me.dgv売上一覧.ClearSelection()
        Else
            '' 選択行がない場合はデータクリア
            Me.dgv売上一覧.DataSource = Nothing
        End If
    End Sub
#End Region

#End Region

#Region "来店者・待ちボタン押下"
    ''' <summary>待ちボタンクリック時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn待ち_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn待ち.Click

    End Sub
#End Region

#End Region

#Region "メニューバーイベント"


#Region "ユーザ"
    ''' <summary>[メニューバー]-[システム]-[管理]-[ユーザ]</summary>
    ''' <remarks></remarks>
    Private Sub ユーザToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ユーザToolStripMenuItem.Click
        a1000_ユーザー情報.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "目標額"
    ''' <summary>[メニューバー]-[システム]-[管理]-[目標額]</summary>
    ''' <remarks></remarks>
    Private Sub 目標額ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles 目標額ToolStripMenuItem.Click
        a1100_目標額.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "在庫管理"
    ''' <summary>[メニューバー]-[システム]-[管理]-[在庫管理]</summary>
    ''' <remarks></remarks>
    Private Sub 在庫管理ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 在庫管理ToolStripMenuItem.Click
        a1400_入出庫登録.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "発注"
    ''' <summary>[メニューバー]-[システム]-[管理]-[発注]</summary>
    ''' <remarks></remarks>
    Private Sub 発注ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 発注ToolStripMenuItem.Click
        a1600_発注画面.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "モード変更"
    ''' <summary>モード変更選択時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub モード変更_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles モード変更ToolStripMenuItem.Click
        a2000_モード変更.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "パスワード変更"
    ''' <summary>モード変更選択時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub パスワード_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles パスワード変更ToolStripMenuItem.Click
        z0700_パスワード変更.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "システム終了"
    ''' <summary>システム終了選択時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub システム終了_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles システム終了ToolStripMenuItem.Click
        rtn = Men_システムの終了()
    End Sub
#End Region

#Region "営業日"
    ''' <summary>[メニューバー]-[日常業務]-[営業日]</summary>
    ''' <remarks></remarks>
    Private Sub 営業日ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles 営業日ToolStripMenuItem.Click
        d0200_営業日.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "日次集計"
    ''' <summary>[メニューバー]-[日常業務]-[日次集計]</summary>
    ''' <remarks></remarks>
    Private Sub 日次集計ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles 日次集計ToolStripMenuItem.Click
        d0300_店集計.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "変更履歴出力"
    ''' <summary>[メニューバー]-[日常業務]-[変更履歴出力]</summary>
    ''' <remarks></remarks>
    Private Sub 変更履歴出力ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 変更履歴出力ToolStripMenuItem.Click
        d0600_履歴ログ出力.ShowDialog()
        Me.Activate()
    End Sub
#End Region


#Region "新規登録"
    ''' <summary>[メニューバー]-[マスタ]-[顧客]-[新規登録]</summary>
    ''' <remarks></remarks>
    Private Sub 新規登録ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新規登録ToolStripMenuItem.Click
        f0100_顧客登録.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "変更・削除"
    ''' <summary>[メニューバー]-[マスタ]-[顧客]-[変更・削除]</summary>
    ''' <remarks></remarks>
    Private Sub 変更削除ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 変更削除ToolStripMenuItem.Click
        z_0500_顧客変更.button_mode = True
        z_0500_顧客変更.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "売上区分"
    ''' <summary>[メニューバー]-[マスタ]-[メニュー]-[売上区分]</summary>
    ''' <remarks></remarks>
    Private Sub 売上区分ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 売上区分ToolStripMenuItem.Click
        f0500_売上区分.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "分類"
    ''' <summary>[メニューバー]-[マスタ]-[メニュー]-[分類]</summary>
    ''' <remarks></remarks>
    Private Sub 分類ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 分類ToolStripMenuItem.Click
        f0500_分類.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "商品"
    ''' <summary>[メニューバー]-[マスタ]-[メニュー]-[商品]</summary>
    ''' <remarks></remarks>
    Private Sub 商品ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 商品ToolStripMenuItem.Click
        f0500_商品.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "工程"
    ''' <summary>[メニューバー]-[マスタ]-[メニュー]-[工程]</summary>
    ''' <remarks></remarks>
    Private Sub 工程ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 工程ToolStripMenuItem.Click
        f1100_工程マスタ.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "スタッフ"
    ''' <summary>[メニューバー]-[マスタ]-[スタッフ]</summary>
    ''' <remarks></remarks>
    Private Sub スタッフToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles スタッフToolStripMenuItem.Click
        f0600_スタッフ.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "メーカー"
    ''' <summary>[メニューバー]-[マスタ]-[メーカー]</summary>
    ''' <remarks></remarks>
    Private Sub メーカーToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles メーカーToolStripMenuItem.Click
        f0700_メーカー.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "カード会社"
    ''' <summary>[メニューバー]-[マスタ]-[カード会社]</summary>
    ''' <remarks></remarks>
    Private Sub カード会社ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles カード会社ToolStripMenuItem.Click
        f0800_カード会社.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "サービス"
    ''' <summary>[メニューバー]-[マスタ]-[サービス]</summary>
    ''' <remarks></remarks>
    Private Sub サービスToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles サービスToolStripMenuItem.Click
        f0900_サービス.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "ポイント割引"
    ''' <summary>[メニューバー]-[マスタ]-[ポイント割引]</summary>
    ''' <remarks></remarks>
    Private Sub ポイント割引ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ポイント割引ToolStripMenuItem.Click
        f1200_ポイント割引.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "データ受信"
    ''' <summary>[メニューバー]-[データ送受信]-[データ受信]</summary>
    ''' <remarks></remarks>
    Private Sub データ受信ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles データ受信ToolStripMenuItem.Click

        If NETWORK_FLAG = False Then
            rtn = MsgBox("通信が許可されていません。　" & Chr(13) & Chr(13) & _
              "通信設定を変更してください。　", Clng_Okexb1, TTL)
            Exit Sub
        End If

        If ACTIVE_NETWORK_FLAG = True Then
            rtn = MsgBox("現在サーバーと通信中です。　" & Chr(13) & Chr(13) & _
                        "しばらく時間をおいてから、再度実行して下さい。　", Clng_Okexb1, TTL)
            Exit Sub
        End If

        If (MsgBox("データ受信を開始します。　" & Chr(13) & Chr(13) & "よろしいですか？　", Clng_Ynqub1, TTL) = vbYes) Then
            receiveData(0)
        End If

    End Sub
#End Region

#Region "通信設定"
    ''' <summary>[メニューバー]-[データ送受信]-[通信設定]</summary>
    ''' <remarks></remarks>
    Private Sub 通信設定ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 通信設定ToolStripMenuItem.Click
        a1800_通信設定.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "ブランクレシート印刷"
    ''' <summary>[メニューバー]-[便利ツール]-[ブランクレシート印刷]</summary>
    ''' <remarks></remarks>
    Private Sub ブランクレシート印刷ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ブランクレシート印刷ToolStripMenuItem.Click
        'ブランクレシート印刷
        logic.printBlankReceipt(0, 0)

    End Sub
#End Region

#Region "データ抽出"
    ''' <summary>[メニューバー]-[便利ツール]-[データ抽出]</summary>
    ''' <remarks></remarks>
    Private Sub データ抽出ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles データ抽出ToolStripMenuItem.Click
        h0100_データ抽出.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "顧客一覧"
    ''' <summary>[メニューバー]-[便利ツール]-[顧客一覧]</summary>
    ''' <remarks></remarks>
    Private Sub 顧客一覧ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 顧客一覧ToolStripMenuItem.Click
        h0300_顧客.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "未登録者一覧"
    ''' <summary>[メニューバー]-[便利ツール]-[未登録者一覧]</summary>
    ''' <remarks></remarks>
    Private Sub 未登録者一覧ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 未登録者一覧ToolStripMenuItem.Click
        h0400_未登録者.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#Region "メッセージ一覧"
    ''' <summary>[メニューバー]-[便利ツール]-[メッセージ一覧]</summary>
    ''' <remarks></remarks>
    Private Sub メッセージ一覧ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles メッセージ一覧ToolStripMenuItem.Click
        a1900_メッセージ一覧.ShowDialog()
        Me.Activate()
    End Sub
#End Region


#Region "バージョン情報"
    ''' <summary>[メニューバー]-[ヘルプ]-[バージョン情報]</summary>
    ''' <remarks></remarks>
    Private Sub バージョン情報ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles バージョン情報ToolStripMenuItem.Click
        a1700_バージョン情報.ShowDialog()
        Me.Activate()
    End Sub
#End Region

#End Region

#Region "メソッド"

#Region "営業日設定チェック"
    ''' <summary>営業日設定チェック</summary>
    ''' <remarks></remarks>
    Private Function GetBusinessDay() As DataTable
        Dim dt As New DataTable
        Do
            If IsDate(USER_DATE) = True Then
                dt = logic.BusinessDay(USER_DATE)
                If dt.Rows.Count() > 0 Then
                    Return dt
                Else
                    a0600_営業日.ShowDialog()
                End If
                dt = logic.BusinessDay(USER_DATE)
                If dt.Rows.Count() > 0 Then
                    Return dt
                Else
                    MsgBox("営業日情報が設定されていません。　" & Chr(13) & Chr(13) & "日付の変更、または営業日情報を設定してください。　", Clng_Okexb1, TTL)
                    a0700_日付設定.ShowDialog()
                End If
            Else
                MsgBox("日付が不正です。日付設定し直してください。　", Clng_Okexb1, TTL)
                a0700_日付設定.ShowDialog()
            End If
        Loop
    End Function
#End Region

#Region "画面再表示処理"
    ''' <summary>画面再表示処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub ReDisplay()
        Dim dtBusinessDay As DataTable = GetBusinessDay()

        '' 来店者一覧
        Me.dgv来店者一覧.DataSource = logic.VisitorList()

        Me.dgv来店者一覧.Columns(0).Visible = False
        Me.dgv来店者一覧.Columns(1).Visible = False
        Me.dgv来店者一覧.Columns(2).Width = 60
        Me.dgv来店者一覧.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgv来店者一覧.Columns(3).Width = 122
        Me.dgv来店者一覧.Columns(4).Visible = False
        Me.dgv来店者一覧.Columns(5).Visible = False
        Me.dgv来店者一覧.Columns(6).Width = 80
        Me.dgv来店者一覧.Columns(7).Width = 37
        Me.dgv来店者一覧.Columns(7).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgv来店者一覧.Columns(8).Width = 78
        Me.dgv来店者一覧.Columns(9).Width = 25
        Me.dgv来店者一覧.Columns(9).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv来店者一覧.Columns(10).Width = 40
        Me.dgv来店者一覧.Columns(11).Visible = False
        Me.dgv来店者一覧.Columns(12).Visible = False
        Me.dgv来店者一覧.Columns(13).Width = 40
        Me.dgv来店者一覧.Columns(13).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        '' 会計済み一覧
        Me.dgv会計済み一覧.DataSource = logic.AccountingEndList()

        Me.dgv会計済み一覧.Columns(0).Visible = False
        Me.dgv会計済み一覧.Columns(1).Visible = False
        Me.dgv会計済み一覧.Columns(2).Width = 60
        Me.dgv会計済み一覧.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgv会計済み一覧.Columns(3).Width = 122
        Me.dgv会計済み一覧.Columns(4).Visible = False
        Me.dgv会計済み一覧.Columns(5).Visible = False
        Me.dgv会計済み一覧.Columns(6).Width = 80
        Me.dgv会計済み一覧.Columns(7).Width = 37
        Me.dgv会計済み一覧.Columns(7).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgv会計済み一覧.Columns(8).Width = 78
        Me.dgv会計済み一覧.Columns(9).Width = 25
        Me.dgv会計済み一覧.Columns(9).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv会計済み一覧.Columns(10).Width = 40
        Me.dgv会計済み一覧.Columns(11).Width = 40
        Me.dgv会計済み一覧.Columns(12).Visible = False

        '' 予約一覧
        If Format(USER_DATE, "yyyy/MM/dd") <> Format(Now, "yyyy/MM/dd") Then
            Me.dgv予約一覧.DataSource = Nothing
        Else
            Me.dgv予約一覧.DataSource = logic.ReserveList()
            Me.dgv予約一覧.Columns(0).Width = 87
            Me.dgv予約一覧.Columns(1).Width = 86
            Me.dgv予約一覧.Columns(2).Width = 190
            Me.dgv予約一覧.Columns(3).Width = 120
            Me.dgv予約一覧.Columns(4).Visible = False
        End If

        Me.dgv来店者一覧.ClearSelection()
        Me.dgv会計済み一覧.ClearSelection()
        ClearDetailInfo()

        dtBusinessDay.Dispose()

        If (Visit_Mode <> True) Then
            If Format(USER_DATE, "yyyy/MM/dd").Equals(Format(Now, "yyyy/MM/dd")) Then
                Me.btn来店.Enabled = True
                Me.btn取消.Enabled = True
                Me.btn予約者来店.Enabled = True
                Me.予約受信.Enabled = True
            Else
                Me.btn来店.Enabled = False
                Me.btn取消.Enabled = True
                Me.btn予約者来店.Enabled = False
                Me.予約受信.Enabled = False
            End If
        End If

        If (Cashiers_Mode <> True) Then
            If Format(USER_DATE, "yyyy/MM/dd").Equals(Format(Now, "yyyy/MM/dd")) Then
                Me.btn売上.Enabled = True
                Me.btn会計編集.Enabled = True
            Else
                Me.btn売上.Enabled = False
                Me.btn会計編集.Enabled = False
            End If
        End If
        Me.btn待ち.Enabled = False
        '' タイトルバーの文字設定
        setTitleBar()

    End Sub
#End Region

#Region "フォーカス設定処理"
    ''' <summary>フォーカス設定処理</summary>
    ''' <remarks></remarks>
    Protected Friend Sub setFocus()
        ' タブ設定
        Select Case Me.tc来店情報.SelectedIndex
            Case 0    ' タブ(来店者)
                btn来店.Focus()
            Case 1    ' タブ(会計済)
                btn作業時間.Focus()
            Case 2    ' タブ(予約)
                btn予約者来店.Focus()
        End Select
        Me.Activate()
    End Sub
#End Region

#Region "詳細情報の設定"
    ''' <summary>詳細情報の設定</summary>
    ''' <remarks></remarks>
    Private Sub SetDetailInfo()
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter

        Dim txt_前回来店日 As String
        Dim txt_来店日Ｎ1 As String
        Dim txt_来店日Ｎ2 As String

        ' 詳細情報のクリア
        ClearDetailInfo()

        '' 過去来店日データ取得
        dt = logic.ClinicalRecordHistoryDay(CST_CODE)
        Me.dgv過去来店日一覧.DataSource = dt
        Me.dgv過去来店日一覧.Columns(0).Width = 100        ' 来店日
        Me.dgv過去来店日一覧.Columns(0).DefaultCellStyle.Format() = "yyyy/MM/dd (ddd)"
        Me.dgv過去来店日一覧.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv過去来店日一覧.Columns(1).Visible = False    ' 来店者番号
        Me.dgv過去来店日一覧.Columns(2).Visible = False    ' 顧客番号
        Me.dgv過去来店日一覧.Columns(3).Width = 122        ' 担当者
        Me.dgv過去来店日一覧.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgv過去来店日一覧.Columns(4).Width = 20         ' 指名
        Me.dgv過去来店日一覧.Columns(4).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv過去来店日一覧.Columns(5).Width = 100        ' 金額文字
        Me.dgv過去来店日一覧.Columns(5).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

        '' カルテ一覧データ取得
        param.Clear()
        param.Add("@来店日", USER_DATE)
        param.Add("@来店者番号", SER_NO)

        dt = logic.ClinicalRecordInfo(CST_CODE)
        Me.dgvカルテ一覧.DataSource = dt
        Me.dgvカルテ一覧.Columns(0).Width = 70             ' 来店日
        Me.dgvカルテ一覧.Columns(1).Visible = False        ' 担当者
        Me.dgvカルテ一覧.Columns(2).Width = 272            ' カルテ
        Me.dgvカルテ一覧.ClearSelection()

        '' 顧客情報データ取得
        dt = logic.CustomerInfo()
        If dt.Rows.Count > 0 Then
            Me.lbl顧客番号.Text = dt.Rows(0)("顧客番号").ToString
            Me.lbl姓.Text = dt.Rows(0)("姓").ToString
            Me.lbl名.Text = dt.Rows(0)("名").ToString
            Me.lbl姓カナ.Text = dt.Rows(0)("姓カナ").ToString
            Me.lbl名カナ.Text = dt.Rows(0)("名カナ").ToString
            '' 住所
            Me.lbl郵便番号.Text = dt.Rows(0)("郵便番号").ToString
            Me.lbl都道府県.Text = dt.Rows(0)("都道府県").ToString
            Me.lbl市区町村.Text = dt.Rows(0)("住所1").ToString
            Me.lbl町域.Text = dt.Rows(0)("住所2").ToString
            Me.lbl番地建物.Text = dt.Rows(0)("住所3").ToString
            Me.lbl電話番号.Text = dt.Rows(0)("電話番号").ToString
            Me.lblEmail.Text = dt.Rows(0)("Emailアドレス").ToString
            Me.lbl登録区分.Text = dt.Rows(0)("登録区分").ToString
            '' 個人情報
            If Not IsDBNull(dt.Rows(0)("生年月日")) Then
                Me.lbl西暦.Text = DateValue(dt.Rows(0)("生年月日").ToString).ToString("yyyy/M/d")
                Dim ad As DateTime ''西暦を和暦に変更するための変数
                ad = DateTime.Parse(Me.lbl西暦.Text)
                Dim culture As Globalization.CultureInfo = New System.Globalization.CultureInfo("ja-JP", True)
                culture.DateTimeFormat.Calendar = New Globalization.JapaneseCalendar
                Me.lbl生年月日.Text = ad.ToString("ggyy年M月d日", culture) ''元号年月日表示追加しました
            End If
            Me.lbl性別.Text = dt.Rows(0)("性別").ToString
            Me.lbl家族名.Text = dt.Rows(0)("家族名").ToString
            Me.lbl趣味.Text = dt.Rows(0)("趣味").ToString
            '' 店使用
            Me.lbl好きな話題.Text = dt.Rows(0)("好きな話題").ToString
            Me.lbl嫌いな話題.Text = dt.Rows(0)("嫌いな話題").ToString
            Me.lblメモ.Text = dt.Rows(0)("メモ").ToString
            Me.lbl紹介者.Text = dt.Rows(0)("紹介者").ToString

            txt_前回来店日 = ""
            If Not IsDBNull(dt.Rows(0)("前回来店日")) Then
                If Not (DateValue(dt.Rows(0)("前回来店日").ToString) = Date.Parse("1900/01/01")) Then
                    txt_前回来店日 = DateValue(dt.Rows(0)("前回来店日").ToString).ToString("yyyy/MM/dd (ddd)")

                End If
            End If
            Me.lbl来店履歴1.Text = txt_前回来店日

            txt_来店日Ｎ1 = ""
            If Not IsDBNull(dt.Rows(0)("来店日N_1")) Then
                If Not (DateValue(dt.Rows(0)("来店日N_1").ToString) = Date.Parse("1900/01/01")) Then
                    txt_来店日Ｎ1 = DateValue(dt.Rows(0)("来店日N_1").ToString).ToString("yyyy/MM/dd (ddd)")
                End If
            End If
            Me.lbl来店履歴2.Text = txt_来店日Ｎ1

            txt_来店日Ｎ2 = ""
            If Not IsDBNull(dt.Rows(0)("来店日N_2")) Then
                If Not (DateValue(dt.Rows(0)("来店日N_2").ToString) = Date.Parse("1900/01/01")) Then
                    txt_来店日Ｎ2 = DateValue(dt.Rows(0)("来店日N_2").ToString).ToString("yyyy/MM/dd (ddd)")
                End If
            End If
            Me.lbl来店履歴3.Text = txt_来店日Ｎ2

            Me.lbl主担当者.Text = dt.Rows(0)("担当者名").ToString
            If Not IsDBNull(dt.Rows(0)("登録日")) Then
                Me.lbl登録日.Text = DateValue(dt.Rows(0)("登録日").ToString).ToString("yyyy/MM/dd (ddd)")
            End If
        End If
        dt.Dispose()
    End Sub
#End Region

#Region "詳細情報のクリア"
    ''' <summary>
    ''' 詳細情報のクリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearDetailInfo()
        '' カルテタブ
        Me.dgv過去来店日一覧.DataSource = Nothing
        Me.dgv売上一覧.DataSource = Nothing
        Me.dgvカルテ一覧.DataSource = Nothing

        '' 顧客情報タブ
        lbl顧客番号.Text = Nothing
        lbl姓.Text = Nothing
        lbl名.Text = Nothing
        lbl姓カナ.Text = Nothing
        lbl名カナ.Text = Nothing

        ' 住所タブ
        lbl郵便番号.Text = Nothing
        lbl都道府県.Text = Nothing
        lbl市区町村.Text = Nothing
        lbl町域.Text = Nothing
        lbl番地建物.Text = Nothing
        lbl電話番号.Text = Nothing
        lblEmail.Text = Nothing
        lbl登録区分.Text = Nothing

        ' 個人情報タブ
        lbl生年月日.Text = Nothing
        lbl西暦.Text = Nothing
        lbl性別.Text = Nothing
        lbl家族名.Text = Nothing
        lbl趣味.Text = Nothing

        ' 店使用タブ
        lbl好きな話題.Text = Nothing
        lbl嫌いな話題.Text = Nothing
        lblメモ.Text = Nothing
        lbl紹介者.Text = Nothing
        lbl主担当者.Text = Nothing
        lbl来店履歴1.Text = Nothing
        lbl来店履歴2.Text = Nothing
        lbl来店履歴3.Text = Nothing
        lbl登録日.Text = Nothing
    End Sub
#End Region

#Region "来店者一覧選択チェック"
    ''' <summary>
    ''' 来店者一覧選択チェック
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isVisitorSelection() As Boolean

        Dim vNumber As String
        Dim cNumber As String
        Dim dt As DataTable

        If Me.dgv来店者一覧.SelectedRows.Count <= 0 Then
            rtn = MsgBox("来店者を選択してください。　", Clng_Okexb1, TTL)
            Me.btn来店.Focus()
            Return False
        End If

        vNumber = Me.dgv来店者一覧.SelectedRows(0).Cells(1).Value.ToString
        dt = logic.GetVisitorData(vNumber)

        If dt.Rows.Count <= 0 Then
            Call Sys_Trap("モジュール", "Mod_来店者選択", "来店者一覧の連結列値の来店者番号が不正")
            Return False
        End If

        cNumber = dt.Rows(0)("顧客番号").ToString
        dt = logic.GetCustomerData(cNumber)

        If dt.Rows.Count <= 0 Then
            Call Sys_Trap("モジュール", "Mod_来店者選択", "来店者一覧の顧客番号が不正")
            Return False
        End If
        '---------------↓たまにセルクリックイベントが発生しても顧客番号、来店者番号が取得できないときがあるので保険で追加しました--------------
        If CST_CODE = 0 Or SER_NO = 0 Then
            rtn = MsgBox("もう一度来店者を選択してください。　", Clng_Okexb1, TTL)
            Exit Function
        End If
        '---------------↑同上------------------------------------------------------------------------------------------------------------------
        Return True
    End Function
#End Region

#Region "会計済一覧選択チェック"
    ''' <summary>会計済み一覧選択チェック</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isBilledSelection() As Boolean
        Dim vNumber As String
        Dim cNumber As String
        Dim dt As DataTable

        If Me.dgv会計済み一覧.SelectedRows.Count <= 0 Then
            rtn = MsgBox("会計済み来店者を選択してください。　", Clng_Okexb1, TTL)
            Me.btn来店.Focus()
            Return False
        End If

        vNumber = Me.dgv会計済み一覧.SelectedRows(0).Cells(1).Value.ToString
        dt = logic.GetVisitorData(vNumber)

        If dt.Rows.Count <= 0 Then
            Call Sys_Trap("モジュール", "Mod_来店者選択", "会計済み一覧の連結列値の来店者番号が不正")
            Return False
        End If

        cNumber = dt.Rows(0)("顧客番号").ToString
        dt = logic.GetCustomerData(cNumber)

        If dt.Rows.Count <= 0 Then
            Call Sys_Trap("モジュール", "Mod_来店者選択", "会計済み一覧の顧客番号が不正")
            Return False
        End If

        Return True
    End Function
#End Region

#Region "管理者機能使用可否設定"
    ''' <summary>管理者機能使用可or不可設定</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setAdminMenu() As Boolean
        '' データ抽出機能非表示
        If My.MySettings.Default.AdminFlag = "1" Then
            データ抽出ToolStripMenuItem.Enabled = True
            データ抽出ToolStripMenuItem.Visible = True
        Else
            データ抽出ToolStripMenuItem.Enabled = False
            データ抽出ToolStripMenuItem.Visible = False
        End If
    End Function
#End Region

#Region "予約機能使用可否設定"
    ''' <summary>予約機能使用可or不可設定</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setTransmitMenu() As Boolean
        '' 予約機能非表示
        If My.MySettings.Default.ReserveFlag = "1" Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "データ送受信使用可否設定"
    ''' <summary>データ送受信機能使用可or不可設定</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setReserveMenu() As Boolean
        '' データ送受信機能非表示
        If My.MySettings.Default.UpdateFlag = "1" Then
            データ送受信ToolStripMenuItem.Visible = True
            データ受信ToolStripMenuItem.Enabled = True
            データ受信ToolStripMenuItem.Visible = True
            通信設定ToolStripMenuItem.Enabled = True
            通信設定ToolStripMenuItem.Visible = True
        Else
            データ送受信ToolStripMenuItem.Visible = False
            データ受信ToolStripMenuItem.Enabled = False
            データ受信ToolStripMenuItem.Visible = False
            通信設定ToolStripMenuItem.Enabled = False
            通信設定ToolStripMenuItem.Visible = False
        End If
    End Function
#End Region

#Region "レシート印刷機能使用可否設定"
    ''' <summary>レシート印刷機能使用可否設定</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setReceiptMenu() As Boolean
        '' レシート印刷機能非表示
        If My.MySettings.Default.ReceiptFlag = "1" Then
            ブランクレシート印刷ToolStripMenuItem.Enabled = True
            ブランクレシート印刷ToolStripMenuItem.Visible = True
        Else
            ブランクレシート印刷ToolStripMenuItem.Enabled = False
            ブランクレシート印刷ToolStripMenuItem.Visible = False
        End If
    End Function
#End Region

#Region "消費税計算方法設定"
    ''' <summary>消費税小数点以下計算方法設定</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setTaxType() As Boolean
        iTaxtype = Integer.Parse(My.MySettings.Default.TaxType)
    End Function
#End Region

#Region "サービス計算方法設定"
    ''' <summary>サービス小数点以下計算方法設定</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function setServiceType() As Boolean
        iServicetype = Integer.Parse(My.MySettings.Default.ServiceType)
    End Function
#End Region

#Region "カーソル初期化設定"
    ''' <summary>
    ''' カーソルがフリーになった際の初期化処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FreeCursor()
        Me.dgvカルテ一覧.DataSource = Nothing
        Me.dgv過去来店日一覧.DataSource = Nothing
        Me.dgv売上一覧.DataSource = Nothing
        Me.lblEmail.Text = String.Empty
        Me.lblメモ.Text = String.Empty
        Me.lbl家族名.Text = String.Empty
        Me.lbl嫌いな話題.Text = String.Empty
        Me.lbl顧客番号.Text = String.Empty
        Me.lbl顧客番号.Text = String.Empty
        Me.lbl好きな話題.Text = String.Empty
        Me.lbl市区町村.Text = String.Empty
        Me.lbl主担当者.Text = String.Empty
        Me.lbl趣味.Text = String.Empty
        Me.lbl紹介者.Text = String.Empty
        Me.lbl姓.Text = String.Empty
        Me.lbl姓カナ.Text = String.Empty
        Me.lbl性別.Text = String.Empty
        Me.lbl生年月日.Text = String.Empty
        Me.lbl西暦.Text = String.Empty
        Me.lbl町域.Text = String.Empty
        Me.lbl電話番号.Text = String.Empty
        Me.lbl登録区分.Text = String.Empty
        Me.lbl登録日.Text = String.Empty
        Me.lbl都道府県.Text = String.Empty
        Me.lbl番地建物.Text = String.Empty
        Me.lbl名.Text = String.Empty
        Me.lbl名カナ.Text = String.Empty
        Me.lbl郵便番号.Text = String.Empty
        Me.lbl来店履歴1.Text = String.Empty
        Me.lbl来店履歴2.Text = String.Empty
        Me.lbl来店履歴3.Text = String.Empty

        Me.dgv予約一覧.ClearSelection()
        Me.dgv来店者一覧.ClearSelection()
        Me.dgv会計済み一覧.ClearSelection()

        Me.btnカルテ.Enabled = False
        Me.btn変更.Enabled = False
        Me.btn待ち.Enabled = False

        setFocus()
    End Sub
#End Region

#Region "データ受信選択"
    ''' <summary>データ受信選択処理</summary>
    ''' <remarks></remarks>
    Private Sub receiveData(ByVal iCount As Integer)

        Dim int_long As Integer
        Dim str_copypath As String
        Dim bEnd As Boolean = False
        Dim iStrCounter As Integer

        If System.IO.Directory.Exists(str_path) Then
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            マスタデータダウンロード()
            Me.bMaster = True
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Else

            iStrCounter = InStr(str_path, "\")
            If iCount < 1 And iStrCounter > 0 Then
                While (bEnd = False)
                    iStrCounter = InStr(iStrCounter + 1, str_path, "\")
                    If iStrCounter = 0 Then
                        bEnd = True
                    Else
                        str_copypath = Mid(str_path, 1, iStrCounter - 1)
                        If Not System.IO.Directory.Exists(Mid(str_copypath, 1, int_long)) Then
                            Try
                                MkDir(str_copypath)
                            Catch ex As Exception
                                'ログ出力
                                FileUtil.WriteLogFile(ex.ToString, _
                                                                My.Application.Info.DirectoryPath, _
                                                                TraceEventType.Error, _
                                                                FileUtil.OutPutType.Weekly)
                                MsgBox("出力先ファイルの作成に失敗しました。　" & Chr(13) & Chr(13) & _
                                        "繰り返し発生する場合は、管理者に連絡してください。　", Clng_Okexb1, TTL)
                            End Try
                        End If
                    End If
                End While
                receiveData(1)
                Exit Sub
            Else
                rtn = MsgBox("ダウンロード先パスが正しくありません。　" & Chr(13) & Chr(13) & _
                                         "正しいパスを指定してください。　", Clng_Okexb1, TTL)
            End If
        End If
    End Sub
#End Region

#Region "タイトルバーの表示文字設定"
    ''' <summary>
    ''' タイトルバーの表示文字設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setTitleBar()
        Me.Text = "HABITS - メイン　　" & USER_DATE.ToString("yyyy年M月d日 (ddd\)") & _
                "　　　来店者：" & dgv来店者一覧.Rows.Count & _
                "人　　　会計済：" & dgv会計済み一覧.Rows.Count & _
                "人　　　予約：" & dgv予約一覧.Rows.Count & _
                "人　　　総来店客数：" & (dgv来店者一覧.Rows.Count + dgv会計済み一覧.Rows.Count) & "人"
    End Sub
#End Region

#End Region

#Region "送受信・予約"

    Private Sub downloadClient_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)
    End Sub

    Private Sub downloadClient_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If bReserve = True Then
            Cursor.Current = Windows.Forms.Cursors.WaitCursor
            予約データ内部処理(0)
        End If

        If bMaster = True Then
            マスタデータ内部処理()
        End If

    End Sub

#Region "予約データダウンロード"
    ''' <summary>
    ''' 予約データダウンロード
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 予約データダウンロード()
        Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Try
            '（Webシステム）予約データダウンロード処理
            Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "ReserveDataSync.aspx"
            Dim wc As New System.Net.WebClient

            'NameValueCollectionの作成
            Dim ps As New System.Collections.Specialized.NameValueCollection

            '送信するデータ（フィールド名と値の組み合わせ）を追加
            ps.Add("q1", My.Settings.LoginName)         ' ID
            ps.Add("q2", My.Settings.LoginPassword)     ' Password
            ps.Add("q3", sShopcode)                     ' ShopCode
            wc.QueryString = ps

            'データを送信し、また受信する
            Dim resData As Byte() = wc.UploadValues(url, ps)
            Dim result As String = Encoding.UTF8.GetString(resData)
            wc.Dispose()

            If result.ToString.StartsWith("1") = True Then

                'ダウンロードしたファイルの保存先
                Dim fileName As String = Me.str_path
                Dim filename2 As String = "ReserveTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".zip"
                Dim filename3 As String = "ReserveTable.txt"

                '（Webサイド）ダウンロード元のURL
                Dim u As New Uri(URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NDATAFOLDER & filename2)

                'WebClientの作成
                If downloadClient Is Nothing Then
                    downloadClient = New System.Net.WebClient()
                End If
                '同期ダウンロードを開始する
                downloadClient.DownloadFile(u, fileName + filename2)
                downloadClient.Dispose()
            ElseIf result.ToString.StartsWith("-1") = True Then
                MsgBox("ログインエラー：" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-2") = True Then
                logic.delete_reserveDate()
            Else
                MsgBox("不明：" & result, Clng_Okexb1, TTL)
            End If
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("接続エラーが発生したため、予約情報の取得に失敗しました。　" & Chr(13) & Chr(13) & _
                    "インターネットへの接続状況を確認してください。　", Clng_Okexb1, TTL)
        End Try

        Cursor.Current = Windows.Forms.Cursors.WaitCursor
    End Sub
#End Region

#Region "予約データ内部処理"
    ''' <summary>
    ''' 予約データ内部処理
    ''' </summary>
    ''' <param name="iCount"></param>
    ''' <remarks></remarks>
    Private Sub 予約データ内部処理(ByVal iCount As Integer)
        Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Me.bReserve = False

        Dim int_long As Integer
        Dim str_copypath As String
        Dim bEnd As Boolean = False
        Dim iStrCounter As Integer
        Dim str_makepath As String = Me.str_path + "ReserveTable\"

        int_long = str_makepath.Length - 1

        Try
            'ダウンロードされたファイルの保存先
            Dim fileName1 As String = Me.str_path
            Dim filename2 As String = "ReserveTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".zip"
            Dim filename3 As String = "ReserveTable"

            If System.IO.Directory.Exists(Mid(str_makepath, 1, int_long)) Then

                '展開するZIPファイルの設定
                Dim zipPath As String = fileName1 + filename2
                '展開先のフォルダの設定
                Dim extractDir As String = fileName1 + filename3

                '読み込む
                If System.IO.File.Exists(zipPath) Then

                    Dim fis As New java.io.FileInputStream(zipPath)
                    Dim zis As New java.util.zip.ZipInputStream(fis)
                    'ZIP内のファイル情報を取得
                    While True
                        Dim ze As java.util.zip.ZipEntry = zis.getNextEntry()
                        If ze Is Nothing Then
                            Exit While
                        End If
                        If Not ze.isDirectory() Then
                            'ファイル名
                            Dim fileName As String = _
                                System.IO.Path.GetFileName(ze.getName())
                            '展開先のフォルダ
                            Dim destDir As String = System.IO.Path.Combine( _
                                extractDir, System.IO.Path.GetDirectoryName(ze.getName()))
                            System.IO.Directory.CreateDirectory(destDir)
                            '展開先のパス
                            Dim destPath As String = _
                                System.IO.Path.Combine(destDir, fileName)
                            'FileOutputStreamの作成
                            Dim fos As New java.io.FileOutputStream(destPath)
                            '書込み
                            Dim buffer(8191) As System.SByte
                            While True
                                Dim len As Integer = zis.read(buffer, 0, buffer.Length)
                                If len <= 0 Then
                                    Exit While
                                End If
                                fos.write(buffer, 0, len)
                            End While
                            '閉じる
                            fos.close()
                        End If
                    End While

                    zis.close()
                    fis.close()

                    予約読み込み()
                    予約ファイル削除()
                End If
            Else
                iStrCounter = InStr(str_makepath, "\")
                If iCount < 1 And iStrCounter > 0 Then
                    While (bEnd = False)
                        iStrCounter = InStr(iStrCounter + 1, str_makepath, "\")
                        If iStrCounter = 0 Then
                            bEnd = True
                        Else
                            str_copypath = Mid(str_makepath, 1, iStrCounter - 1)
                            If Not System.IO.Directory.Exists(Mid(str_copypath, 1, int_long)) Then
                                Try
                                    MkDir(str_copypath)
                                Catch ex As Exception
                                    'ログ出力
                                    FileUtil.WriteLogFile(ex.ToString, _
                                                                    My.Application.Info.DirectoryPath, _
                                                                    TraceEventType.Error, _
                                                                    FileUtil.OutPutType.Weekly)
                                    MsgBox("出力先ファイルの作成に失敗しました。　" & Chr(13) & Chr(13) & _
                                            "繰り返し発生する場合は、管理者に連絡してください。　", Clng_Okexb1, TTL)
                                End Try
                            End If
                        End If
                    End While
                    予約データ内部処理(1)
                    Exit Sub
                Else
                    MsgBox("ファイルの展開に失敗しました。　" & Chr(13) & Chr(13), Clng_Okexb1, TTL)
                End If

            End If
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("ファイルの展開に失敗しました。　" & Chr(13) & Chr(13) & _
                   "繰り返し発生する場合は、管理者に連絡してください。　", Clng_Okexb1, TTL)
        End Try
    End Sub
#End Region

#Region "予約読み込み"
    ''' <summary>
    ''' 予約読み込み
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 予約読み込み()
        Cursor.Current = Windows.Forms.Cursors.WaitCursor
        'ダウンロードファイルをShift-JISコードとして開く
        Dim sr As New System.IO.StreamReader(Me.str_path & "ReserveTable\ReserveTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".csv", _
            System.Text.Encoding.GetEncoding("shift_jis"))
        Try
            Dim txt As String
            Dim bTableName As Boolean = False
            Dim sTablseName As String = ""

            '内容を一行ずつ読み込む
            While sr.Peek() > -1
                txt = sr.ReadLine()
                If (txt = "-") Then
                    bTableName = True
                Else
                    If bTableName = True Then
                        sTablseName = txt
                        bTableName = False
                        logic.BedoreMakeSQL(sTablseName)
                    Else
                        logic.makeDownloadSQL(sTablseName, txt)
                    End If
                End If

            End While
            '閉じる
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("ファイルの読込に失敗しました。　" & Chr(13) & Chr(13) & _
                       "繰り返し発生する場合は、管理者に連絡してください。　", Clng_Okexb1, TTL)
        Finally

            sr.Close()
        End Try
    End Sub
#End Region

#Region "予約ファイル削除"
    ''' <summary>
    ''' 予約ファイル削除
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 予約ファイル削除()
        Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Try
            Dim fileName1 As String = Me.str_path
            Dim filename2 As String = "ReserveTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".zip"
            Dim filename3 As String = "ReserveTable\ReserveTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".csv"
            ' FileSystemObject (FSO) の新しいインスタンスを生成する
            ' ファイルを削除する
            System.IO.File.Delete(fileName1 + filename2)
            System.IO.File.Delete(fileName1 + filename3)

        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("ファイルの削除に失敗しました。　" & Chr(13) & Chr(13) & _
                       "繰り返し発生する場合は、管理者に連絡してください。　", Clng_Okexb1, TTL)
        End Try
    End Sub
#End Region

#Region "マスタデータダウンロード"
    ''' <summary>
    ''' マスタデータダウンロード
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub マスタデータダウンロード()
        Try
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
            '（Webシステム）マスタデータダウンロード処理
            Dim url As String = URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NETWORK & "MasterDataSync.aspx"
            Dim wc As New System.Net.WebClient

            'NameValueCollectionの作成
            Dim ps As New System.Collections.Specialized.NameValueCollection
            Dim sUdDate As String
            Dim dt As New DataTable

            dt = logic.selectDownloadDate()
            sUdDate = dt.Rows(0)("最終ダウンロード").ToString()

            '送信するデータ（フィールド名と値の組み合わせ）を追加
            ps.Add("q1", My.Settings.LoginName)         ' ID
            ps.Add("q2", My.Settings.LoginPassword)     ' Password
            ps.Add("q3", sShopcode)                     ' ShopCode
            ps.Add("q4", sUdDate)                       ' Date
            wc.QueryString = ps

            'データを送信し、また受信する
            Dim resData As Byte() = wc.UploadValues(url, ps)
            Dim result As String = Encoding.UTF8.GetString(resData)
            wc.Dispose()

            If result.ToString.StartsWith("1") = True Then
                'ダウンロードしたファイルの保存先
                Dim fileName As String = Me.str_path
                Dim filename2 As String = "MasterTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".zip"
                Dim filename3 As String = "MasterTable.txt"
                Dim startIndex As Integer = InStr(result.ToString, ";") + 1
                Dim endIndex As Integer = InStr(startIndex, result.ToString, ";")
                upTime = Mid(result.ToString(), startIndex, endIndex - startIndex)

                '（Webサイド）ダウンロード元のURL
                Dim u As New Uri(URL_HABITS_MAIN & My.Settings.Company & URL_HABITS_NDATAFOLDER & filename2)

                'WebClientの作成
                If downloadClient Is Nothing Then
                    downloadClient = New System.Net.WebClient()
                End If
                'イベントハンドラの作成

                AddHandler downloadClient.DownloadProgressChanged, _
                    AddressOf downloadClient_DownloadProgressChanged
                AddHandler downloadClient.DownloadFileCompleted, _
                    AddressOf downloadClient_DownloadFileCompleted
                '非同期ダウンロードを開始する
                downloadClient.DownloadFileAsync(u, fileName + filename2)

            ElseIf result.ToString.StartsWith("-1") = True Then
                MsgBox("ログインエラー：" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-2") = True Then
                MsgBox("アップロードフォルダ無しエラー：" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-3") = True Then
                MsgBox("ファイル保存失敗エラー：" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-4") = True Then
                MsgBox("Zipファイル以外送信エラー：" & result, Clng_Okexb1, TTL)
            ElseIf result.ToString.StartsWith("-5") = True Then
                MsgBox("Zipファイル展開失敗エラー：" & result, Clng_Okexb1, TTL)
            Else
                MsgBox("不明：" & result, Clng_Okexb1, TTL)
            End If
            Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("接続エラーが発生しました。　" & Chr(13) & Chr(13) & _
                    "インターネットへの接続状況を確認してください。　", Clng_Okexb1, TTL)
        End Try
    End Sub
#End Region

#Region "マスタデータ内部処理"
    ''' <summary>
    ''' マスタデータ内部処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub マスタデータ内部処理()
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.WaitCursor
        Me.bMaster = False

        Try
            'ダウンロードされたファイルの保存先
            Dim fileName1 As String = Me.str_path
            Dim filename2 As String = "MasterTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".zip"
            Dim filename3 As String = "MasterTable"

            '展開するZIPファイルの設定
            Dim zipPath As String = fileName1 + filename2
            '展開先のフォルダの設定
            Dim extractDir As String = fileName1 + filename3

            '読み込む
            Dim fis As New java.io.FileInputStream(zipPath)
            Dim zis As New java.util.zip.ZipInputStream(fis)
            'ZIP内のファイル情報を取得
            While True
                Dim ze As java.util.zip.ZipEntry = zis.getNextEntry()
                If ze Is Nothing Then
                    Exit While
                End If
                If Not ze.isDirectory() Then
                    'ファイル名
                    Dim fileName As String = _
                        System.IO.Path.GetFileName(ze.getName())
                    '展開先のフォルダ
                    Dim destDir As String = System.IO.Path.Combine( _
                        extractDir, System.IO.Path.GetDirectoryName(ze.getName()))
                    System.IO.Directory.CreateDirectory(destDir)
                    '展開先のパス
                    Dim destPath As String = _
                        System.IO.Path.Combine(destDir, fileName)
                    'FileOutputStreamの作成
                    Dim fos As New java.io.FileOutputStream(destPath)
                    '書込み
                    Dim buffer(8191) As System.SByte
                    While True
                        Dim len As Integer = zis.read(buffer, 0, buffer.Length)
                        If len <= 0 Then
                            Exit While
                        End If
                        fos.write(buffer, 0, len)
                    End While
                    '閉じる
                    fos.close()

                End If
            End While

            zis.close()
            fis.close()

            マスタ読み込み()
            マスタファイル削除()
            logic.finishDownload(upTime)
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("ファイルの展開に失敗しました。　" & Chr(13) & Chr(13) & _
            "繰り返し発生する場合は、管理者に連絡してください。　", Clng_Okexb1, TTL)
        End Try
        Windows.Forms.Cursor.Current = Windows.Forms.Cursors.Default
    End Sub
#End Region

#Region "マスタ読み込み"
    ''' <summary>
    ''' マスタ読み込み
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub マスタ読み込み()
        'ダウンロードをShift-JISコードとして開く
        Dim sr As New System.IO.StreamReader(Me.str_path & "MasterTable\MasterTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".csv", _
            System.Text.Encoding.GetEncoding("shift_jis"))
        Dim txt As String
        Dim bTableName As Boolean = False
        Dim sTablseName As String = ""

        '内容を一行ずつ読み込む
        While sr.Peek() > -1
            txt = sr.ReadLine()
            If (txt = "-") Then
                bTableName = True
            Else
                If bTableName = True Then
                    sTablseName = txt
                    bTableName = False
                    logic.BedoreMakeSQL(sTablseName)
                Else
                    logic.makeDownloadSQL(sTablseName, txt)
                End If
            End If

        End While
        '閉じる
        sr.Close()
    End Sub
#End Region

#Region "マスタファイル削除"
    ''' <summary>
    ''' マスタファイル削除
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub マスタファイル削除()
        Try
            Dim fileName1 As String = Me.str_path
            Dim filename2 As String = "MasterTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".zip"
            Dim filename3 As String = "MasterTable\MasterTable_" + sShopcode + "_" + Format(Now, "yyyyMMdd") + ".csv"
            ' FileSystemObject (FSO) の新しいインスタンスを生成する
            ' ファイルを削除する
            System.IO.File.Delete(fileName1 + filename2)
            System.IO.File.Delete(fileName1 + filename3)
            MsgBox("データを受信しました。　　　　" & Chr(13), Clng_Okinb1, TTL)
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)
            MsgBox("ファイルの削除に失敗しました。　" & Chr(13) & Chr(13) & _
                      "繰り返し発生する場合は、管理者に連絡してください。　", Clng_Okexb1, TTL)
        End Try
    End Sub
#End Region

#Region "予約データ受信処理"
    ''' <summary>予約データ受信処理</summary>
    ''' <remarks></remarks>
    Private Sub receiveReserve(ByVal iCount As Integer)

        Dim int_long As Integer
        Dim str_custompath As String
        Dim str_copypath As String
        Dim bEnd As Boolean = False
        Dim iStrCounter As Integer

        If setTransmitMenu() = False Then
            Exit Sub
        End If

        str_custompath = Me.str_path + "ReserveTable\"
        str_custompath = Replace(str_custompath, "/", "\")

        int_long = str_custompath.Length - 1

        If System.IO.Directory.Exists(Mid(str_custompath, 1, int_long)) Then
            Cursor.Current = Windows.Forms.Cursors.WaitCursor

            予約データダウンロード()
            bReserve = True

            If bReserve = True Then
                Cursor.Current = Windows.Forms.Cursors.WaitCursor
                予約データ内部処理(0)
            End If

            Cursor.Current = Windows.Forms.Cursors.Default
        Else
            iStrCounter = InStr(str_custompath, "\")
            If iCount < 1 And iStrCounter > 0 Then
                While (bEnd = False)
                    iStrCounter = InStr(iStrCounter + 1, str_custompath, "\")
                    If iStrCounter = 0 Then
                        bEnd = True
                    Else
                        str_copypath = Mid(str_custompath, 1, iStrCounter - 1)
                        If Not System.IO.Directory.Exists(Mid(str_copypath, 1, int_long)) Then
                            Try
                                MkDir(str_copypath)
                            Catch ex As Exception
                                'ログ出力
                                FileUtil.WriteLogFile(ex.ToString, _
                                                                My.Application.Info.DirectoryPath, _
                                                                TraceEventType.Error, _
                                                                FileUtil.OutPutType.Weekly)
                                MsgBox("出力先ファイルの作成に失敗しました。　" & Chr(13) & Chr(13) & _
                                        "繰り返し発生する場合は、管理者に連絡してください。　", Clng_Okexb1, TTL)
                            End Try
                        End If
                    End If
                End While
                receiveReserve(1)
                Exit Sub
            Else
                rtn = MsgBox("ファイル出力先パスが正しくありません。　" & Chr(13) & Chr(13) & _
                  "正しいパスを指定してください。　", Clng_Okexb1, TTL)
            End If
        End If
    End Sub
#End Region

#End Region

#Region "タイマー処理"
    ''' <summary>
    ''' サーバへのデータ送信処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TimerDataSync_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerDataSync.Tick
        Dim param As New Habits.DB.DBParameter
        Dim dt As DataTable
        Dim iError As Integer = 0

        '通信許可フラグチェック
        If NETWORK_FLAG = False Then
            Exit Sub
        End If

        If ACTIVE_NETWORK_FLAG = False Then
            Me.lbl_Connect.Visible = False
            '通信エラー回数チェック
            dt = logic.GetConnectError()
            If dt.Rows.Count > 0 Then
                iError = Integer.Parse(dt.Rows(0)("通信中エラー回数").ToString)
                If iError >= CONNECT_ERROR Then
                    Me.lbl_Connect.Visible = True
                End If
            End If

            '通信中フラグon
            ACTIVE_NETWORK_FLAG = True

            '通信開始
            MultiThread.UpdateToServer()
        Else
            Me.lbl_Connect.Visible = False
        End If

    End Sub

    ''' <summary>
    ''' 未チェックのメッセージ件数取得処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TimerMessageChk_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMessageChk.Tick
        If MESSAGE_CHECK_FLAG = False Then
            'メッセージ件数チェック中フラグ
            MESSAGE_CHECK_FLAG = True

            '通信開始
            MultiThreadMsg.UpdateToServer()

            If MESSAGE_CNT > 0 Then
                If (MsgBox("未確認のメッセージが" & MESSAGE_CNT & "件あります。　　", Clng_Okinb1, TTL) = vbOK) Then
                    MESSAGE_CHECK_FLAG = False
                End If
            Else
                MESSAGE_CHECK_FLAG = False
            End If
            MESSAGE_CNT = 0
        End If

    End Sub

#End Region

#Region "入出金"
    ''' <summary>[メニューバー]-[日常業務]-[入出金]</summary>
    ''' <remarks></remarks>
    Private Sub 入出金ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 入出金ToolStripMenuItem.Click
        d0500_現金入出金登録.ShowDialog()
        Me.Activate()
    End Sub
#End Region

End Class




