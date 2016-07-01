'システム名 ： HABITS
'機能名　　 ： z_0300_顧客検索
'概要　　　 ： 顧客を選択する機能
'履歴　　　 ： 2010/06/14　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.Imports System.Data
Public Class z_0300_顧客検索

#Region "変数・定数"
    Dim dt As New DataTable
    Private logic As New Habits.Logic.z0300_Logic
    Public 検索loaded As Boolean

#End Region

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub z_0300_顧客検索_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.tcSearchGuest.SelectedIndex = 0
        顧客検索_Init()
        カナ検索_Init()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub z_0300_顧客検索_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "検索パターン変更"
    ''' <summary>
    ''' タブ変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 検索パターンチェンジ(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcSearchGuest.SelectedIndexChanged

        顧客検索_Init()
        カナ検索_Init()

        If Me.tcSearchGuest.SelectedIndex = 0 Then
            Me.番号検索顧客番号.Focus()
        Else
            Me.カナ検索姓カナ.Focus()
            If Me.顧客一覧.SelectedRows.Count > 0 Then
                Me.選択.Enabled = True
            End If
        End If
    End Sub
#End Region

#Region "顧客一覧選択変更"
    ''' <summary>
    ''' 顧客一覧選択変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 顧客一覧_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles 顧客一覧.SelectionChanged
        If Me.顧客一覧.SelectedRows.Count <> 0 Then
            Me.番号検索顧客番号.Text = Me.顧客一覧.CurrentRow.Cells(0).Value.ToString
            GetCustomer()

            Me.選択.Enabled = True
            Me.選択.Focus()
        End If
    End Sub
#End Region

#Region "顧客一覧押下"
    ''' <summary>
    ''' 顧客一覧ダブルクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 顧客一覧_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles 顧客一覧.CellContentDoubleClick
        Me.選択.Enabled = True
        Call 選択_Click(sender, e)
    End Sub
#End Region

#Region "カナ検索姓カナ入力"
    ''' <summary>
    ''' カナ検索姓カナ入力後処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub カナ検索姓カナ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles カナ検索姓カナ.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.カナ検索名カナ.Focus()
        End If
    End Sub
#End Region

#Region "カナ検索姓カナ変更"
    ''' <summary>
    ''' カナ検索姓カナ変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub カナ検索姓カナ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles カナ検索姓カナ.TextChanged
        Call SetCustomerList()
    End Sub
#End Region

#Region "カナ検索名カナ入力"
    ''' <summary>
    ''' カナ検索名カナ入力後処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub カナ検索名カナ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles カナ検索名カナ.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.顧客一覧.Focus()
        End If
    End Sub
#End Region

#Region "カナ検索名カナ変更"
    ''' <summary>
    ''' カナ検索名カナ変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub カナ検索名カナ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles カナ検索名カナ.TextChanged
        Call SetCustomerList()
    End Sub
#End Region

#Region "番号検索顧客番号入力"
    ''' <summary>
    ''' 番号検索顧客番号入力後処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 番号検索顧客番号_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 番号検索顧客番号.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            If Me.選択.Enabled Then
                Me.選択.Focus()
            Else
                Me.閉じる.Focus()
            End If
        End If
    End Sub
#End Region

    Private Sub 番号検索顧客番号_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles 番号検索顧客番号.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub

#Region "番号検索顧客番号入力チェック"
    ''' <summary>
    ''' 番号検索顧客番号入力チェック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 番号検索顧客番号_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles 番号検索顧客番号.Validated
        Me.番号検索顧客番号.Text = Trim(Me.番号検索顧客番号.Text)
        If Me.番号検索顧客番号.TextLength <> 0 Then
            If IsNumeric(Me.番号検索顧客番号.Text) Then
                GetCustomer()
                RemoveHandler 番号検索顧客番号.Validated, AddressOf 番号検索顧客番号_Validated
                Me.選択.Focus()
                AddHandler 番号検索顧客番号.Validated, AddressOf 番号検索顧客番号_Validated
            Else
                Call Sys_Error("顧客番号 は半角数字で入力してください。　", Me.番号検索顧客番号)
                Me.番号検索顧客番号.Text = Nothing
            End If
        End If
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "選択ボタン押下"
    ''' <summary>
    ''' 選択ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 選択_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 選択.Click
        Dim cult As CultureInfo = New CultureInfo("ja-JP")
        cult.DateTimeFormat.Calendar = New JapaneseCalendar
        Dim param As New Habits.DB.DBParameter

        If Me.tcSearchGuest.SelectedIndex = 1 Then
            If Me.顧客一覧.SelectedRows.Count <> 1 Then
                Call Sys_Error("顧客を選択してください。　", Me.顧客一覧)
                Exit Sub
            End If
        End If
        If Not (input_check()) Then Exit Sub
        param.Add("@顧客番号", Me.番号検索顧客番号.Text)
        dt = logic.CustomerInfo(param)
        param.Clear()

        Select Case True
            Case (Me.検索loaded = True)
                Me.検索loaded = False

                z_0500_顧客変更.来店日.Text = ""    ' men_来店者登録以外は設定不要
                z_0500_顧客変更.来店者番号.Text = ""

                '顧客番号に該当する顧客がいた場合に処理
                If dt.Rows.Count > 0 Then
                    z_0500_顧客変更.lbl顧客番号.Text = dt.Rows(0)("顧客番号").ToString
                End If

                z_0500_顧客変更.変更.Enabled = True
                z_0500_顧客変更.削除.Enabled = True
                z_0500_顧客変更.SetDetailInfo()
                Me.Close()
            Case Else

                Me.検索loaded = False
                z_0400_顧客情報.lbl顧客番号.Text = dt.Rows(0)("顧客番号").ToString
                z_0400_顧客情報.ShowDialog()
        End Select

        z_0500_顧客変更.姓.ReadOnly = False
        z_0500_顧客変更.名.ReadOnly = False

        dt.Dispose()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
        Me.検索loaded = False
    End Sub
#End Region

#End Region

#Region "メソッド"

#Region "入力チェック"
    ''' <summary>入力チェック</summary>
    ''' <remarks></remarks>
    Private Function input_check() As Boolean
        input_check = False

        Select Case tcSearchGuest.SelectedIndex
            Case 0    ' 番号検索

                If Sys_InputCheck(Me.番号検索顧客番号.Text, 6, "N+", 1) Then
                    Call Sys_Error("顧客番号 は半角数字6文字以内で入力してください。　", Me.番号検索顧客番号)
                    Exit Function
                End If

            Case 1    ' カナ検索
                If Me.顧客一覧.Rows.Count <= 0 Then
                    Exit Function
                End If

                If Me.顧客一覧.SelectedRows.Count = 0 Then
                    Call Sys_Error("顧客を選択してください。　", Me.顧客一覧)
                End If
        End Select

        input_check = True
    End Function
#End Region

#Region "候補リスト設定"
    ''' <summary>
    ''' 候補リスト設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetCustomerList()
        Dim sei As String = ""      '' 検索キーワード：セイ
        Dim mei As String = ""      '' 検索キーワード：メイ

        Me.選択.Enabled = False
        '' 顧客一覧をクリア
        Me.顧客一覧.DataSource = Nothing

        If Len(カナ検索姓カナ.Text & "") > 0 _
                And Len(Me.カナ検索名カナ.Text & "") > 0 Then
            '' 姓カナ、名カナともに入力あり
            sei = Me.カナ検索姓カナ.Text & "%"
            mei = Me.カナ検索名カナ.Text & "%"
        ElseIf Len(Me.カナ検索姓カナ.Text & "") > 0 _
                And Len(Me.カナ検索名カナ.Text & "") = 0 Then
            '' 姓カナのみ入力あり
            sei = Me.カナ検索姓カナ.Text & "%"
            mei += "%"
        ElseIf Len(Me.カナ検索姓カナ.Text & "") = 0 _
                And Len(Me.カナ検索名カナ.Text & "") > 0 Then
            '' 名カナのみ入力あり
            sei = "%"
            mei = Me.カナ検索名カナ.Text & "%"
        Else
            Exit Sub
        End If

        ' 顧客一覧データ取得
        RemoveHandler 顧客一覧.SelectionChanged, AddressOf 顧客一覧_SelectionChanged
        Me.顧客一覧.DataSource = logic.SearchCustomerSeiMei(Me.カナ検索姓カナ.Text, Me.カナ検索名カナ.Text)
        AddHandler 顧客一覧.SelectionChanged, AddressOf 顧客一覧_SelectionChanged

        If Me.顧客一覧.Rows.Count > 0 Then
            Me.顧客一覧.Columns(0).Width = 60           ''顧客番号
            Me.顧客一覧.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.顧客一覧.Columns(1).Width = 85           ''姓
            Me.顧客一覧.Columns(2).Width = 85           ''名
            Me.顧客一覧.Columns(3).Width = 85           ''主担当者
            Me.顧客一覧.Columns(4).Width = 98           ''前回来店日
            Me.顧客一覧.Columns(5).Width = 166          ''住所

            Me.顧客一覧.ClearSelection()

        Else
            顧客検索_Init()
            Exit Sub
        End If
    End Sub
#End Region

#Region "初期化（顧客番号タブ）"
    ''' <summary>
    ''' 初期化（顧客番号タブ）
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 顧客検索_Init()
        Me.番号検索顧客番号.Text = ""
        Me.lbl住所.Text = ""
        Me.lbl町域.Text = ""
        Me.lbl姓カナ.Text = ""
        Me.lbl名カナ.Text = ""
        Me.lbl姓.Text = ""
        Me.lbl名.Text = ""
        Me.lbl主担当者名.Text = ""
        Me.lbl前回来店日.Text = ""
        Me.lbl誕生日.Text = ""
        Me.lbl年齢.Text = ""

        Me.選択.Enabled = False
    End Sub
#End Region

#Region "初期化（顧客氏名タブ）"
    ''' <summary>
    ''' 初期化（顧客氏名タブ）
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub カナ検索_Init()
        Me.カナ検索姓カナ.Text = ""
        Me.カナ検索名カナ.Text = ""
        Me.顧客一覧.DataSource = Nothing

        Me.選択.Enabled = False
    End Sub
#End Region

#Region "顧客情報設定"
    ''' <summary>
    ''' 顧客情報設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GetCustomer()
        Dim dt As New DataTable
        Dim tkm As New DataTable
        Dim param As New Habits.DB.DBParameter

        If (Sys_InputCheck(Me.番号検索顧客番号.Text, 6, "N+", 1)) Then
            Me.番号検索顧客番号.Focus()
            顧客検索_Init()
            カナ検索_Init()
            Exit Sub
        End If

        param.Add("@顧客番号", Me.番号検索顧客番号.Text)

        dt = logic.CustomerInfo(param)
        param.Clear()

        If Not dt.Rows.Count > 0 Then
            Call Sys_Error("顧客番号が登録されていません。　", Me.番号検索顧客番号)
            顧客検索_Init()
            Exit Sub
        Else
            Me.lbl住所.Text = dt.Rows(0)("住所1").ToString
            Me.lbl町域.Text = dt.Rows(0)("住所2").ToString
            Me.lbl姓カナ.Text = dt.Rows(0)("姓カナ").ToString
            Me.lbl名カナ.Text = dt.Rows(0)("名カナ").ToString
            Me.lbl姓.Text = dt.Rows(0)("姓").ToString
            Me.lbl名.Text = dt.Rows(0)("名").ToString
            Me.lbl主担当者名.Text = dt.Rows(0)("担当者名").ToString

            If Not IsDBNull(dt.Rows(0)("前回来店日")) Then
                Me.lbl前回来店日.Text = DateValue(dt.Rows(0)("前回来店日").ToString).ToString("yyyy/MM/dd(ddd)")
            End If

            If (dt.Rows(0)("生年月日").ToString.Equals("")) Then

                Me.lbl誕生日.Text = "誕生日未設定"
                Me.lbl年齢.Text = "誕生日未設定"

            Else

                Me.lbl誕生日.Text = DateValue(dt.Rows(0)("生年月日").ToString).ToString("yyyy/MM/dd(ddd)")

                If (Mid(Format(Date.Parse(dt.Rows(0)("生年月日").ToString), "yyyy/MM/dd"), 6, 5) > Mid(Format(USER_DATE, "yyyy/MM/dd"), 6, 5)) Then

                    Me.lbl年齢.Text = CStr(DateDiff("yyyy", dt.Rows(0)("生年月日").ToString, USER_DATE) - 1) & "才"
                Else
                    Me.lbl年齢.Text = CStr(DateDiff("yyyy", dt.Rows(0)("生年月日").ToString, USER_DATE)) & "才"
                End If
            End If
        End If

        Me.選択.Enabled = True
        dt.Dispose()
        tkm.Dispose()
    End Sub
#End Region

#End Region

End Class




