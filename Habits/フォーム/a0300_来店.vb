'システム名 ： HABITS
'機能名　　 ： a0300_来店
'概要　　　 ： 来店者登録機能
'履歴　　　 ： 2010/05/12　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a0300_来店

#Region "変数・定数定義"

    Private logic As Habits.Logic.a0300_Logic                       'ロジッククラス　
    Private yomiNewLastName As ImeComposition.ImeYomiConversion     '新規姓の読みを取得
    Private yomiNewFirstName As ImeComposition.ImeYomiConversion    '新規名の読みを取得
    Private yomiFreeLastName As ImeComposition.ImeYomiConversion    'フリー姓の読みを取得
    Private yomiFreeFirstName As ImeComposition.ImeYomiConversion   'フリー名の読みを取得
    Public reserve_mode As Boolean                                  '通常来店と予約来店での場合分け
    Public reserve_number As String                                 '予約番号
    Private first_kana, family_kana, first, family, owner_num, owners As String

#End Region

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0300_来店_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' ロジッククラス生成
        logic = New Habits.Logic.a0300_Logic
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        Me.dgv顧客一覧.DataSource = Nothing
        MESSAGE_CHECK_FLAG = True

        '' 顧客番号タブ項目初期化
        顧客検索_Init()

        '' 自動フリガナの設定
        yomiNewLastName = New ImeComposition.ImeYomiConversion(Me.txt新規姓, Me.txt新規姓カナ, True)
        yomiNewFirstName = New ImeComposition.ImeYomiConversion(Me.txt新規名, Me.txt新規名カナ, True)
        yomiFreeLastName = New ImeComposition.ImeYomiConversion(Me.txtフリー姓, Me.txtフリー姓カナ, True)
        yomiFreeFirstName = New ImeComposition.ImeYomiConversion(Me.txtフリー名, Me.txtフリー名カナ, True)

        Me.ActiveControl = Me.txtカードあり顧客番号
        Me.Activate()
        If Me.reserve_mode Then
            param.Add("@予約番号", Me.reserve_number)
            dt = logic.select_reserve(param)
            param.Clear()
            If dt.Rows.Count <> 0 Then
                Me.family = dt.Rows(0)("顧客姓").ToString
                Me.first = dt.Rows(0)("顧客名").ToString
                Me.family_kana = dt.Rows(0)("顧客姓カナ").ToString
                Me.first_kana = dt.Rows(0)("顧客名カナ").ToString
                Me.owners = dt.Rows(0)("担当者名").ToString
                Me.tc来店状況.SelectedIndex = 1
                Me.txtカードなし姓カナ.Text = family_kana
                Me.txtカードなし名カナ.Text = first_kana
            End If
        Else
            '' 顧客番号タブを選択状態にする。
            Me.tc来店状況.SelectedIndex = 0
        End If
        If Me.reserve_mode Then
            param.Add("@担当者名", Me.owners)
            dt = logic.getOwnerNum(param)
            param.Clear()
            If dt.Rows.Count <> 0 Then
                Me.owner_num = dt.Rows(0)("担当者番号").ToString
            Else
                Me.owner_num = ""
            End If
        End If
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a0300_来店_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        MESSAGE_CHECK_FLAG = False
        Me.reserve_mode = False
        Me.Dispose()
    End Sub
#End Region

#Region "タブ変更時処理"
    ''' <summary>タブコントロール(来店状況) 変更時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tc来店状況_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tc来店状況.SelectedIndexChanged
        Select Case Me.tc来店状況.SelectedIndex
            Case 0    ' タブ(顧客番号)
                顧客検索_Init()

            Case 1    ' タブ(顧客検索)
                If Not Me.dgv顧客一覧.Equals(Nothing) AndAlso Me.dgv顧客一覧.SelectedRows.Count > 0 Then
                    'ボタン活性設定
                    setBtnOk()
                Else
                    'ボタン非活性設定
                    setBtnNo()
                End If
                Me.btn空番.Enabled = False
                Me.btn設定.Enabled = False
                Me.btnクリア.Enabled = False
                Me.txtカードなし姓カナ.Focus()

            Case 2    ' タブ(新規)
                新規_Init()

            Case 3    ' タブ(フリー)
                フリー_Init()
        End Select
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "登録ボタン押下"
    ''' <summary>来店登録ボタンクリック時処理</summary>
    ''' <remarks></remarks>
    Private Sub btn来店登録_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn来店登録.Click
        Call VisitorInsert(False)
    End Sub
#End Region

#Region "待ちボタン押下"
    ''' <summary>待ちボタンクリック時処理</summary>
    ''' <remarks></remarks>
    Private Sub btn待ち_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn待ち.Click
        Call VisitorInsert(True)
    End Sub
#End Region

#Region "空番号ボタン押下"
    ''' <summary>空番ボタンクリック時の処理</summary>
    ''' <remarks></remarks>
    Private Sub btn空番_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn空番.Click
        z_0200_空番号選択.ShowDialog()
        z_0200_空番号選択.loaded = True
    End Sub
#End Region

#Region "設定ボタン押下"
    ''' <summary>設定ボタンクリック時の処理</summary>
    ''' <remarks></remarks>
    Private Sub btn設定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn設定.Click
        a0500_顧客番号設定.ShowDialog()
    End Sub
#End Region

#Region "カルテボタン押下"
    ''' <summary>カルテボタンクリック時処理</summary>
    ''' <remarks></remarks>
    Private Sub btnカルテ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnカルテ.Click
        If Me.tc来店状況.SelectedIndex = 0 Then
            z_0400_顧客情報.lbl顧客番号.Text = Me.txtカードあり顧客番号.Text

        ElseIf Me.tc来店状況.SelectedIndex = 1 Then
            If Me.dgv顧客一覧.SelectedRows.Count = 0 Then Exit Sub
            z_0400_顧客情報.lbl顧客番号.Text = Me.dgv顧客一覧.CurrentRow.Cells(0).Value.ToString
        End If
        z_0400_顧客情報.ShowDialog()
    End Sub
#End Region

#Region "クリアボタン押下"
    ''' <summary>クリアボタンクリック時処理</summary>
    ''' <remarks></remarks>
    Private Sub btnクリア_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnクリア.Click
        If Me.tc来店状況.SelectedIndex = 2 Then         'タブ(新規)
            新規_Init()

        ElseIf Me.tc来店状況.SelectedIndex = 3 Then     'タブ(フリー)
            フリー_Init()
        End If
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>閉じるボタンクリック時処理</summary>
    ''' <remarks></remarks>
    Private Sub btn閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn閉じる.Click
        Me.Close()
    End Sub
#End Region

#End Region

#Region "コントロール変更時処理"
    ''タブ[顧客氏名]
    Private Sub txtカードなし姓カナ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtカードなし姓カナ.TextChanged
        If Me.tc来店状況.SelectedIndex = 1 Then
            Call SetCustomerList()
        End If
    End Sub

    Private Sub txtカードなし名カナ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtカードなし名カナ.TextChanged
        Call SetCustomerList()
    End Sub

    Private Sub dgv顧客一覧_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv顧客一覧.SelectionChanged
        If Me.dgv顧客一覧.SelectedRows.Count > 0 Then
            'ボタン活性設定
            setBtnOk()
        Else
            'ボタン非活性設定
            setBtnNo()
        End If
    End Sub

    Private Sub dgv顧客一覧_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv顧客一覧.CellDoubleClick
        Call VisitorInsert(False)
    End Sub

    ''タブ[新規]
    Private Sub txt新規姓_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt新規姓.Enter
        yomiNewLastName.Enabled = True
    End Sub

    Private Sub txt新規姓_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt新規姓.TextChanged
        If (Len(Me.txt新規姓.Text & "") = 0) Then
            Me.btn来店登録.Enabled = False
            Me.btn待ち.Enabled = False
            Me.txt新規姓カナ.Text = ""
        Else
            Me.btn来店登録.Enabled = True
            Me.btn待ち.Enabled = True
        End If
    End Sub

    ''' <summary>タブ(新規) -> 名 のフォーカスがアクティブになった時の処理</summary>
    ''' <remarks></remarks>
    Private Sub txt新規名_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt新規名.Enter
        yomiNewFirstName.Enabled = True
    End Sub

    Private Sub txt新規名_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt新規名.TextChanged
        If (Len(Me.txt新規名.Text & "") = 0) Then
            Me.txt新規名カナ.Text = ""
        End If
    End Sub

    ''タブ[フリー]
    ''' <summary>タブ(フリー) -> 姓 のフォーカスがアクティブになった時の処理</summary>
    ''' <remarks></remarks>
    Private Sub txtフリー姓_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtフリー姓.Enter
        yomiFreeLastName.Enabled = True
    End Sub

    Private Sub txtフリー姓_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtフリー姓.TextChanged
        If (Len(Me.txtフリー姓.Text & "") = 0) Then
            Me.btn来店登録.Enabled = False
            Me.btn待ち.Enabled = False
            Me.txtフリー姓カナ.Text = ""
        Else
            Me.btn来店登録.Enabled = True
            Me.btn待ち.Enabled = True
        End If
    End Sub

    ''' <summary>タブ(フリー) -> 名 のフォーカスがアクティブになった時の処理</summary>
    ''' <remarks></remarks>
    Private Sub txtフリー名_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtフリー名.Enter
        yomiFreeFirstName.Enabled = True
    End Sub

    Private Sub txtフリー名_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtフリー名.TextChanged
        If (Len(Me.txtフリー名.Text & "") = 0) Then
            Me.txtフリー名カナ.Text = ""
        End If
    End Sub

#End Region

#Region "キープレス設定"
    ''' <summary>タブ(顧客番号) -> 顧客番号でキーが押された時の処理</summary>
    ''' <remarks>数値のみ入力可能とする。</remarks>
    Private Sub txtカードあり顧客番号_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtカードあり顧客番号.KeyPress
        Call Sys_KeyPressNumeric(e)
    End Sub
#End Region

#Region "キー押下時処理"
    ''タブ[顧客番号]
    Private Sub txtカードあり顧客番号_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtカードあり顧客番号.KeyDown
        If Me.tc来店状況.SelectedIndex = 0 AndAlso e.KeyData.Equals(System.Windows.Forms.Keys.Enter) Then
            GetCustomer()
        End If
    End Sub

    ''タブ[顧客氏名]
    Private Sub txtカードなし姓カナ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtカードなし姓カナ.KeyDown
        If Me.tc来店状況.SelectedIndex = 1 AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtカードなし名カナ.Focus()
        End If
    End Sub

    Private Sub txtカードなし名カナ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtカードなし名カナ.KeyDown
        If Me.tc来店状況.SelectedIndex = 1 AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.dgv顧客一覧.Focus()
        End If
    End Sub

    Private Sub dgv顧客一覧_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv顧客一覧.KeyDown
        If Me.tc来店状況.SelectedIndex = 1 AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then
            If Me.dgv顧客一覧.SelectedRows.Count > 0 Then
                Me.btn来店登録.Focus()
            End If
        End If
    End Sub

    ''タブ[新規]
    Private Sub txt新規姓_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt新規姓.KeyDown
        If Me.tc来店状況.SelectedIndex = 2 AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt新規姓カナ.Focus()
        End If
    End Sub

    Private Sub txt新規姓カナ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt新規姓カナ.KeyDown
        If Me.tc来店状況.SelectedIndex = 2 AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt新規名.Focus()
        End If
    End Sub

    Private Sub txt新規名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt新規名.KeyDown
        If Me.tc来店状況.SelectedIndex = 2 AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txt新規名カナ.Focus()
        End If
    End Sub

    Private Sub txt新規名カナ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt新規名カナ.KeyDown
        If Me.tc来店状況.SelectedIndex = 2 AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then
            If Me.btn来店登録.Enabled = True Then
                Me.btn来店登録.Focus()
            Else
                Me.btn閉じる.Focus()
            End If
        End If
    End Sub

    ''タブ[フリー]
    Private Sub txtフリー姓_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtフリー姓.KeyDown
        If Me.tc来店状況.SelectedIndex = 3 AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtフリー姓カナ.Focus()
        End If
    End Sub

    Private Sub txtフリー姓カナ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtフリー姓カナ.KeyDown
        If Me.tc来店状況.SelectedIndex = 3 AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtフリー名.Focus()
        End If
    End Sub

    Private Sub txtフリー名_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtフリー名.KeyDown
        If Me.tc来店状況.SelectedIndex = 3 AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.txtフリー名カナ.Focus()
        End If
    End Sub

    Private Sub txtフリー名カナ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtフリー名カナ.KeyDown
        If Me.tc来店状況.SelectedIndex = 3 AndAlso e.KeyCode = Windows.Forms.Keys.Enter Then
            If Me.btn来店登録.Enabled = True Then
                Me.btn来店登録.Focus()
            Else
                Me.btn閉じる.Focus()
            End If
        End If
    End Sub
#End Region

#Region "フォーカスが外れた時の処理"

    ''タブ[顧客番号]
    ''顧客情報設定
    Private Sub txtカードあり顧客番号_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtカードあり顧客番号.Leave
        If Me.tc来店状況.SelectedIndex = 0 AndAlso Not Me.reserve_mode Then
            GetCustomer()
        End If
    End Sub

    ''タブ[新規]
    Private Sub txt新規姓_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt新規姓.Leave
        yomiNewLastName.Enabled = False
    End Sub

    Private Sub txt新規名_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt新規名.Leave
        yomiNewFirstName.Enabled = False
    End Sub

    ''タブ[フリー]
    Private Sub txtフリー姓_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtフリー姓.Leave
        yomiFreeLastName.Enabled = False
    End Sub

    Private Sub txtフリー名_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtフリー名.Leave
        yomiFreeFirstName.Enabled = False
    End Sub

#End Region

#Region "メソッド"

#Region "顧客一覧の設定"
    ''' <summary>顧客一覧を設定する</summary>
    ''' <remarks></remarks>
    Private Sub SetCustomerList()
        Dim sei As String = ""      '' 検索キーワード：セイ
        Dim mei As String = ""      '' 検索キーワード：メイ

        Me.btn来店登録.Enabled = False
        Me.btn待ち.Enabled = False
        '' 顧客一覧をクリア
        Me.dgv顧客一覧.DataSource = Nothing

        If Len(Me.txtカードなし姓カナ.Text & "") > 0 _
                And Len(Me.txtカードなし名カナ.Text & "") > 0 Then
            '' 姓カナ、名カナともに入力あり
            sei = Me.txtカードなし姓カナ.Text & "%"
            mei = Me.txtカードなし名カナ.Text & "%"
        ElseIf Len(Me.txtカードなし姓カナ.Text & "") > 0 _
                And Len(Me.txtカードなし名カナ.Text & "") = 0 Then
            '' 姓カナのみ入力あり
            sei = Me.txtカードなし姓カナ.Text & "%"
            mei += "%"
        ElseIf Len(Me.txtカードなし姓カナ.Text & "") = 0 _
                And Len(Me.txtカードなし名カナ.Text & "") > 0 Then
            '' 名カナのみ入力あり
            sei = "%"
            mei = Me.txtカードなし名カナ.Text & "%"
        Else
            Exit Sub
        End If

        '' 顧客一覧データ取得
        Me.dgv顧客一覧.DataSource = logic.SearchCustomerSeiMei(Me.txtカードなし姓カナ.Text, Me.txtカードなし名カナ.Text)
        Me.dgv顧客一覧.Columns(0).Width = 60           ''顧客番号
        Me.dgv顧客一覧.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dgv顧客一覧.Columns(1).Width = 85           ''姓
        Me.dgv顧客一覧.Columns(2).Width = 85           ''名
        Me.dgv顧客一覧.Columns(3).Width = 85           ''主担当者
        Me.dgv顧客一覧.Columns(4).Width = 98           ''前回来店日
        Me.dgv顧客一覧.Columns(5).Width = 166          ''住所
        Me.dgv顧客一覧.ClearSelection()
    End Sub
#End Region

#Region "ボタン活性設定"
    Private Sub setBtnOk()
        Me.btn来店登録.Enabled = True
        Me.btn待ち.Enabled = True
        Me.btnカルテ.Enabled = True
    End Sub
#End Region

#Region "ボタン非活性設定"
    Private Sub setBtnNo()
        Me.btn来店登録.Enabled = False
        Me.btn待ち.Enabled = False
        Me.btnカルテ.Enabled = False
    End Sub
#End Region

#Region "入力チェック"
    ''' <summary>入力チェック</summary>
    ''' <remarks></remarks>
    ''' 
    Private Function InputCheck() As Boolean
        '' タブコントロールの選択状態で分岐
        Select Case Me.tc来店状況.SelectedIndex

            Case 0    ' タブ(顧客番号)
                If Sys_InputCheck(Me.txtカードあり顧客番号.Text, 6, "N+", 1) Then
                    Call Sys_Error("顧客番号 は6桁以内の半角数字で入力してください。　", Me.txtカードあり顧客番号)
                    Return False
                End If
                CST_CODE = Long.Parse(txtカードあり顧客番号.Text)

            Case 1    ' 顧客検索
                If Me.dgv顧客一覧.SelectedRows.Count = 0 Then
                    Call MsgBox("来店者 を選択してください。　", Clng_Okexb1, TTL)
                    Me.dgv顧客一覧.Focus()
                    Return False
                End If

            Case 2    ' タブ(新規)
                Me.txt新規姓.Text = Trim(Me.txt新規姓.Text)
                If String.IsNullOrEmpty(Me.txt新規姓.Text) Then
                    Call Sys_Error("姓 は必須入力です。　", Me.txt新規姓)
                    Exit Function
                End If
                If Sys_InputCheck(Me.txt新規姓.Text, 16, "M", 1) Then
                    Call Sys_Error("姓 は16文字以内で入力してください。　", Me.txt新規姓)
                    Exit Function
                End If

                Me.txt新規姓カナ.Text = Trim(Me.txt新規姓カナ.Text)
                If String.IsNullOrEmpty(Me.txt新規姓カナ.Text) Then
                    Call Sys_Error("姓カナ は必須入力です。　", Me.txt新規姓カナ)
                    Exit Function
                End If
                If Sys_Zenkaku(Me.txt新規姓カナ.Text) Then
                    Call Sys_Error("姓カナ は半角で入力してください。　", Me.txt新規姓カナ)
                    Exit Function
                End If
                If Sys_InputCheck(Me.txt新規姓カナ.Text, 32, "A", 1) Then
                    Call Sys_Error("姓カナ は半角32文字以内で入力してください。　", Me.txt新規姓カナ)
                    Exit Function
                End If

                Me.txt新規名.Text = Trim(Me.txt新規名.Text)
                If Sys_InputCheck(Me.txt新規名.Text, 16, "M", 0) Then
                    Call Sys_Error("名 は16文字以内で入力してください。　", Me.txt新規名)
                    Exit Function
                End If

                Me.txt新規名カナ.Text = Trim(Me.txt新規名カナ.Text)
                If Sys_Zenkaku(Me.txt新規名カナ.Text) Then
                    Call Sys_Error("名カナ は半角で入力してください。　", Me.txt新規名カナ)
                    Exit Function
                End If
                If Sys_InputCheck(Me.txt新規名カナ.Text, 32, "A", 0) Then
                    Call Sys_Error("名カナ は半角32文字以内で入力してください。　", Me.txt新規名カナ)
                    Exit Function
                End If

                If (String.IsNullOrEmpty(Me.txt新規名.Text) AndAlso Not String.IsNullOrEmpty(Me.txt新規名カナ.Text)) Then
                    Call Sys_Error("名 を入力してください。　", Me.txt新規名)
                    Exit Function
                End If
                If (Not String.IsNullOrEmpty(Me.txt新規名.Text) AndAlso String.IsNullOrEmpty(Me.txt新規名カナ.Text)) Then
                    Call Sys_Error("名カナ を入力してください。　", Me.txt新規名カナ)
                    Exit Function
                End If

            Case 3    ' タブ(フリー)
                Me.txtフリー姓.Text = Trim(Me.txtフリー姓.Text)
                If String.IsNullOrEmpty(Me.txtフリー姓.Text) Then
                    Call Sys_Error("姓 は必須入力です。　", Me.txtフリー姓)
                    Exit Function
                End If
                If Sys_InputCheck(Me.txtフリー姓.Text, 16, "M", 1) Then
                    Call Sys_Error("姓 は16文字以内で入力してください。　", Me.txtフリー姓)
                    Exit Function
                End If

                Me.txtフリー姓カナ.Text = Trim(Me.txtフリー姓カナ.Text)
                If String.IsNullOrEmpty(Me.txtフリー姓カナ.Text) Then
                    Call Sys_Error("姓カナ は必須入力です。　", Me.txtフリー姓カナ)
                    Exit Function
                End If
                If Sys_Zenkaku(Me.txtフリー姓カナ.Text) Then
                    Call Sys_Error("姓カナ は半角で入力してください。　", Me.txtフリー姓カナ)
                    Exit Function
                End If
                If Sys_InputCheck(Me.txtフリー姓カナ.Text, 32, "A", 1) Then
                    Call Sys_Error("姓カナ は半角32文字以内で入力してください。　", Me.txtフリー姓カナ)
                    Exit Function
                End If

                Me.txtフリー名.Text = Trim(Me.txtフリー名.Text)
                If Sys_InputCheck(Me.txtフリー名.Text, 16, "M", 0) Then
                    Call Sys_Error("名 は16文字以内で入力してください。　", Me.txtフリー名)
                    Exit Function
                End If

                Me.txtフリー名カナ.Text = Trim(Me.txtフリー名カナ.Text)
                If Sys_Zenkaku(Me.txtフリー名カナ.Text) Then
                    Call Sys_Error("名カナ は半角で入力してください。　", Me.txtフリー名カナ)
                    Exit Function
                End If
                If Sys_InputCheck(Me.txtフリー名カナ.Text, 32, "A", 0) Then
                    Call Sys_Error("名カナ は半角32文字以内で入力してください。　", Me.txtフリー名カナ)
                    Exit Function
                End If

                If (String.IsNullOrEmpty(Me.txtフリー名.Text) AndAlso Not String.IsNullOrEmpty(Me.txtフリー名カナ.Text)) Then
                    Call Sys_Error("名 を入力してください。　", Me.txtフリー名)
                    Exit Function
                End If
                If (Not String.IsNullOrEmpty(Me.txtフリー名.Text) AndAlso String.IsNullOrEmpty(Me.txtフリー名カナ.Text)) Then
                    Call Sys_Error("名カナ を入力してください。　", Me.txtフリー名カナ)
                    Exit Function
                End If
        End Select
        Return True
    End Function
#End Region

#Region "来店者登録処理"
    ''' <summary>
    ''' E_来店者テーブルに来店者を登録する。
    ''' </summary>
    ''' <param name="waitFlag">【待ち判定フラグ】True：施術待ち、False：来店</param>
    ''' <remarks></remarks>
    Private Sub VisitorInsert(ByVal waitFlag As Boolean)
        '' 入力チェック
        If Not InputCheck() Then Exit Sub

        Dim dt As New DataTable
        Dim vNumber As String = ""
        Dim messageFlag As String = ""
        Dim param As New Habits.DB.DBParameter

        '' タブコントロールの選択状態で分岐
        Select Case Me.tc来店状況.SelectedIndex

            Case 0, 1    ' タブ(顧客番号)、タブ(顧客検索)
                '' 顧客番号取得
                If Me.tc来店状況.SelectedIndex = 0 Then
                    txtCustomerNum.Text = Me.txtカードあり顧客番号.Text
                ElseIf Me.tc来店状況.SelectedIndex = 1 Then
                    txtCustomerNum.Text = Me.dgv顧客一覧.SelectedRows(0).Cells(0).Value.ToString
                End If

                ''来店回数チェック
                param.Clear()
                param.Add("@来店日", USER_DATE)
                param.Add("@顧客番号", txtCustomerNum.Text)
                If logic.checkTwiceVisits(param) Then
                    If (MsgBox("本日２回以上の来店となりますがよろしいですか？　", Clng_Ynqub1, TTL) = vbNo) Then
                        Exit Sub
                    End If
                End If

                '' 顧客情報の取得
                dt = logic.GetCustomerData(txtCustomerNum.Text)

                '' 伝言の有無チェック
                If logic.isMessageFlag(dt) Then
                    '' 伝言フラグ = 1 の場合は伝言メモを表示
                    a0900_伝言メモ.ShowDialog()
                End If

                ' 来店者番号取得
                vNumber = logic.NewVisitorNumber()

                '' 来店者情報設定
                param.Clear()
                param.Add("@来店日", USER_DATE)
                param.Add("@来店者番号", vNumber)
                param.Add("@顧客番号", txtCustomerNum.Text)
                param.Add("@姓", dt.Rows(0)("姓").ToString)
                param.Add("@名", IIf(dt.Rows(0)("名").ToString.Length > 0, dt.Rows(0)("名").ToString, System.DBNull.Value))
                param.Add("@姓カナ", dt.Rows(0)("姓カナ").ToString)
                param.Add("@住所", IIf(dt.Rows(0)("住所1").ToString.Length > 0, dt.Rows(0)("住所1").ToString, System.DBNull.Value))
                param.Add("@前回来店日", IIf(dt.Rows(0)("前回来店日").ToString.Length > 0, dt.Rows(0)("前回来店日"), System.DBNull.Value))
                If IsDBNull(dt.Rows(0)("前回来店日")) Then
                    param.Add("@来店間隔", System.DBNull.Value)
                Else
                    If DateDiff("d", dt.Rows(0)("前回来店日"), USER_DATE) >= 3650 Then
                        '' 10年以上
                        param.Add("@来店間隔", "9999")
                    Else
                        param.Add("@来店間隔", DateDiff("d", dt.Rows(0)("前回来店日"), USER_DATE))
                    End If
                End If
                If Me.reserve_mode Then
                    param.Add("@主担当者番号", IIf(Me.owner_num.Equals(""), dt.Rows(0)("主担当者番号"), Me.owner_num))
                Else
                    param.Add("@主担当者番号", dt.Rows(0)("主担当者番号"))
                End If

                param.Add("@来店区分番号", VISIT_RETURN)
                param.Add("@指名", False)
                If (waitFlag) Then
                    param.Add("@作業開始", System.DBNull.Value)
                Else
                    param.Add("@作業開始", USER_DATE.Date & Format(Now, " HH:mm:ss"))
                End If
                param.Add("@作業終了", System.DBNull.Value)
                param.Add("@会計済", False)
                param.Add("@登録日時", Now())
                If Me.reserve_mode Then
                    param.Add("@予約番号", Me.reserve_number)
                Else
                    param.Add("@予約番号", System.DBNull.Value)
                End If

                '' 来店者情報登録
                logic.InsertVisitorData(param)
                updateVisiter(txtCustomerNum.Text)

            Case 2    ' タブ(新規)
                If Me.lbl新規顧客番号.Text.Equals(String.Empty) Then
                    MsgBox("顧客番号を設定してください。　" & Chr(13), Clng_Okinb1, TTL)
                    Exit Sub
                End If
                '' 顧客情報設定
                param.Add("@顧客番号", Me.lbl新規顧客番号.Text)
                param.Add("@姓", Me.txt新規姓.Text)
                param.Add("@名", IIf(Me.txt新規名.Text.Length > 0, Me.txt新規名.Text, System.DBNull.Value))
                param.Add("@姓カナ", Me.txt新規姓カナ.Text)
                param.Add("@名カナ", IIf(Me.txt新規名カナ.Text.Length > 0, Me.txt新規名カナ.Text, System.DBNull.Value))
                param.Add("@性別番号", System.DBNull.Value)

                param.Add("@登録区分番号", 1)
                param.Add("@登録日", Now)
                param.Add("@更新日", Now)

                '' 顧客情報登録
                logic.InsertCustomerData(param)

                ' 来店者番号取得
                vNumber = logic.NewVisitorNumber()

                '' 来店者情報設定
                param.Clear()
                param.Add("@来店日", USER_DATE)
                param.Add("@来店者番号", vNumber)
                param.Add("@顧客番号", Me.lbl新規顧客番号.Text)
                param.Add("@姓", Me.txt新規姓.Text)
                param.Add("@名", IIf(Me.txt新規名.Text.Length > 0, Me.txt新規名.Text, System.DBNull.Value))
                param.Add("@姓カナ", Me.txt新規姓カナ.Text)
                param.Add("@住所", System.DBNull.Value)
                param.Add("@前回来店日", System.DBNull.Value)
                param.Add("@来店間隔", System.DBNull.Value)
                If Me.reserve_mode Then
                    param.Add("@主担当者番号", IIf(Me.owner_num.Equals(""), 0, Me.owner_num))
                Else
                    param.Add("@主担当者番号", 0)
                End If

                param.Add("@来店区分番号", VISIT_NEW)    '' 新規
                param.Add("@指名", False)
                If (waitFlag) Then
                    param.Add("@作業開始", System.DBNull.Value)
                Else
                    param.Add("@作業開始", USER_DATE.Date & Format(Now, " HH:mm:ss"))
                End If
                param.Add("@作業終了", System.DBNull.Value)
                param.Add("@会計済", False)
                param.Add("@登録日時", Now())
                If Me.reserve_mode Then
                    param.Add("@予約番号", Me.reserve_number)
                Else
                    param.Add("@予約番号", System.DBNull.Value)
                End If

                '' 来店者情報登録
                logic.InsertVisitorData(param)
                updateVisiter(Me.lbl新規顧客番号.Text)

            Case 3    ' フリー

                param.Add("@顧客番号", Me.lblフリー顧客番号.Text)
                param.Add("@姓", Me.txtフリー姓.Text)
                param.Add("@名", IIf(Me.txtフリー名.Text.Length > 0, Me.txtフリー名.Text, System.DBNull.Value))
                param.Add("@姓カナ", Me.txtフリー姓カナ.Text)
                param.Add("@名カナ", IIf(Me.txtフリー名カナ.Text.Length > 0, Me.txtフリー名カナ.Text, System.DBNull.Value))
                param.Add("@性別番号", System.DBNull.Value)
                param.Add("@登録日", Now())
                param.Add("@登録区分番号", 0)
                param.Add("@更新日", Now)

                vNumber = logic.NewVisitorNumber()
                '' 顧客情報の取得
                dt = logic.GetCustomerData(Me.lblフリー顧客番号.Text)
                If dt.Rows.Count > 0 Then
                    logic.UpdateCustomerData(param)
                Else
                    '' 未登録 -> 顧客情報登録
                    '' 登録済み -> 顧客情報更新
                    logic.InsertCustomerData(param)
                End If

                '' 来店者情報設定
                param.Clear()
                param.Add("@来店日", USER_DATE)
                param.Add("@来店者番号", vNumber)
                param.Add("@顧客番号", Me.lblフリー顧客番号.Text)
                param.Add("@姓", Me.txtフリー姓.Text)
                param.Add("@名", IIf(Me.txtフリー名.Text.Length > 0, Me.txtフリー名.Text, System.DBNull.Value))
                param.Add("@姓カナ", Me.txtフリー姓カナ.Text)
                param.Add("@住所", VISIT_FREE_CHAR)
                param.Add("@前回来店日", System.DBNull.Value)
                param.Add("@来店間隔", System.DBNull.Value)
                param.Add("@主担当者番号", 0)
                param.Add("@来店区分番号", VISIT_FREE)    '' フリー
                param.Add("@指名", False)
                If (waitFlag) Then
                    param.Add("@作業開始", System.DBNull.Value)
                Else
                    param.Add("@作業開始", USER_DATE.Date & Format(Now, " HH:mm:ss"))
                End If
                param.Add("@作業終了", System.DBNull.Value)
                param.Add("@会計済", False)
                param.Add("@登録日時", Now())
                If Me.reserve_mode Then
                    param.Add("@予約番号", Me.reserve_number)
                Else
                    param.Add("@予約番号", System.DBNull.Value)
                End If

                '' 来店者情報登録
                logic.InsertVisitorData(param)
        End Select
        Me.dgv顧客一覧.DataSource = Nothing

        a0200_メイン.ReDisplay()
        a0200_メイン.dgv来店者一覧.Rows(0).Selected = True
        a0200_メイン.btnカルテ.Enabled = True
        a0200_メイン.btn変更.Enabled = True

        Me.Close()
    End Sub
#End Region

#Region "来店回数変更"
    ''' <summary>
    ''' 来店する顧客の来店回数を増やす
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub updateVisiter(ByVal str_num As String)
        Dim dt As New DataTable
        Dim int_number As Integer = 0
        Dim param As New Habits.DB.DBParameter
        param.Add("@顧客番号", str_num)
        dt = logic.select_customer(param)
        param.Clear()
        If dt.Rows.Count <> 0 Then
            int_number = Integer.Parse(dt.Rows(0)("来店回数").ToString) + 1
        End If
        param.Add("@顧客番号", str_num)
        param.Add("@来店回数", int_number)
        param.Add("@更新日", Now)
        logic.customer_update(param)
    End Sub
#End Region

#Region "タブ[顧客番号]項目クリア"
    ''' <summary>タブ[顧客番号]項目クリア</summary>
    ''' <remarks></remarks>
    Private Sub 顧客検索_Init()
        Me.txtカードあり顧客番号.Clear()
        Me.lbl住所.Text = ""
        Me.lbl姓.Text = ""
        Me.lbl名.Text = ""
        Me.lbl姓カナ.Text = ""
        Me.lbl名カナ.Text = ""
        Me.lblカルテ.Text = ""

        If Me.tc来店状況.SelectedIndex = 0 Then
            'ボタン非活性設定
            setBtnNo()

            Me.btn空番.Enabled = False
            Me.btn設定.Enabled = False
            Me.btnクリア.Enabled = False
            Me.txtカードあり顧客番号.Focus()
        End If
    End Sub
#End Region

#Region "タブ[新規登録]項目クリア"
    ''' <summary>タブ[新規登録]項目クリア</summary>
    ''' <remarks></remarks>
    Private Sub 新規_Init()
        Me.lbl新規顧客番号.Text = logic.NewCustomerNumber()
        Me.txt新規姓.Clear()
        Me.txt新規名.Clear()
        Me.txt新規姓カナ.Clear()
        Me.txt新規名カナ.Clear()

        If Me.tc来店状況.SelectedIndex = 2 Then
            'ボタン活性設定
            setBtnNo()

            Me.btn空番.Enabled = True
            Me.btn設定.Enabled = True
            Me.btnクリア.Enabled = True
            Me.txt新規姓.Focus()
        End If

        If Integer.Parse(Me.lbl新規顧客番号.Text) >= Clng_STFreeNo Then
            Me.lbl新規顧客番号.Text = String.Empty
        End If
    End Sub
#End Region

#Region "タブ[フリー]項目クリア"
    ''' <summary>タブ[フリー]項目クリア</summary>
    ''' <remarks></remarks>
    Private Sub フリー_Init()
        Me.lblフリー顧客番号.Text = logic.NewFreeNumber()
        Me.txtフリー姓.Clear()
        Me.txtフリー名.Clear()
        Me.txtフリー姓カナ.Clear()
        Me.txtフリー名カナ.Clear()

        If Me.tc来店状況.SelectedIndex = 3 Then
            'ボタン非活性設定
            setBtnNo()

            Me.btn空番.Enabled = False
            Me.btn設定.Enabled = False
            Me.btnクリア.Enabled = True
            Me.txtフリー姓.Focus()
        End If
    End Sub
#End Region

#Region "顧客情報設定"
    ''' <summary>
    ''' 顧客情報の設定
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCustomer() As Integer
        Dim dt As New DataTable

        '' 入力チェック
        If (Sys_InputCheck(Me.txtカードあり顧客番号.Text, 6, "N+", 1)) Then
            顧客検索_Init()
            Exit Function
        End If

        '' 顧客情報を取得
        dt = logic.GetCustomerData(Me.txtカードあり顧客番号.Text)
        If Not dt.Rows.Count > 0 Then
            Call Sys_Error("顧客番号が登録されていません。　", Me.txtカードあり顧客番号)
            顧客検索_Init()
            Exit Function
        End If

        Me.lbl住所.Text = dt.Rows(0)("住所1").ToString
        Me.lbl姓.Text = dt.Rows(0)("姓").ToString
        Me.lbl名.Text = dt.Rows(0)("名").ToString
        Me.lbl姓カナ.Text = dt.Rows(0)("姓カナ").ToString
        Me.lbl名カナ.Text = dt.Rows(0)("名カナ").ToString
        Me.lbl住所.ForeColor = Color.Black

        '' カルテ情報取得
        Me.lblカルテ.Text = logic.GetClinicalRecord(Me.txtカードあり顧客番号.Text)

        'ボタン活性設定
        setBtnOk()

        RemoveHandler txtカードあり顧客番号.Leave, AddressOf txtカードあり顧客番号_Leave ''無限ループ回避用
        Me.btn来店登録.Focus()
        AddHandler txtカードあり顧客番号.Leave, AddressOf Me.txtカードあり顧客番号_Leave
    End Function
#End Region

#End Region

End Class

