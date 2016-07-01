'システム名 ： HABITS
'機能名　　 ： z_0400_顧客情報
'概要　　　 ： 顧客情報表示機能
'履歴　　　 ： 2010/06/14　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.Imports System.Data
Public Class z_0400_顧客情報

    Private logic As New Habits.Logic.z0400_Logic

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>ロード時処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub z_0400_顧客情報_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetDetailInfo()
        Me.dgv過去来店日一覧.ClearSelection()
        Me.カルテ一覧.ClearSelection()
        Me.dgv売上一覧.ClearSelection()
        Me.Activate()
    End Sub
#End Region

#Region "変更ボタン押下"
    ''' <summary>
    ''' 変更ボタン押下処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 変更_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 変更.Click
        '顧客番号に該当する顧客がいた場合に処理
        If Not Me.lbl顧客番号.Text.Equals("") Then
            z_0500_顧客変更.lbl顧客番号.Text = Me.lbl顧客番号.Text
            z_0500_顧客変更.ShowDialog()
        End If
        z_0500_顧客変更.mode = 0
    End Sub
#End Region

#Region "閉じる（顧客）ボタン押下"
    ''' <summary>閉じる（顧客）ボタン押下処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる.Click
        Me.Close()
    End Sub
#End Region

#Region "閉じる（カルテ）ボタン押下"
    ''' <summary>閉じる（カルテ）ボタン押下処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 閉じる２_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 閉じる２.Click
        Me.Close()
    End Sub
#End Region

#Region "過去来店日一覧選択処理"
    ''' <summary>
    ''' 過去来店日一覧選択処理
    ''' </summary>
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
            Me.dgv売上一覧.Columns(0).Width = 80        '売上区分
            Me.dgv売上一覧.Columns(1).Width = 183       '名称
            Me.dgv売上一覧.Columns(2).Width = 60        '数量
            Me.dgv売上一覧.Columns(2).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.dgv売上一覧.Columns(3).Width = 90        '金額
            Me.dgv売上一覧.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.dgv売上一覧.Columns(4).Width = 90        'サービス
            Me.dgv売上一覧.Columns(4).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight
            Me.dgv売上一覧.Columns(5).Visible = False   '売上区分番号
        Else
            '' 選択行がない場合はデータクリア
            Me.dgv売上一覧.DataSource = Nothing
        End If

        Me.dgv売上一覧.ClearSelection()
        Me.カルテ一覧.ClearSelection()
    End Sub
#End Region


#End Region

#Region "メソッド"

#Region "画面表示"
    ''' <summary>
    ''' 画面表示
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetDetailInfo()
        顧客情報表示()
        Dim dt As New DataTable
        '' 過去来店日データ取得
        dt = logic.ClinicalRecordHistoryDay(Me.lbl顧客番号.Text)
        Me.dgv過去来店日一覧.DataSource = dt
        Me.dgv過去来店日一覧.Columns(0).Width = 100        ' 来店日
        Me.dgv過去来店日一覧.Columns(0).DefaultCellStyle.Format() = "yyyy/MM/dd (ddd)"
        Me.dgv過去来店日一覧.Columns(0).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgv過去来店日一覧.Columns(1).Visible = False    ' 来店者番号
        Me.dgv過去来店日一覧.Columns(2).Visible = False    ' 顧客番号
        Me.dgv過去来店日一覧.Columns(3).Width = 150        ' 担当者
        Me.dgv過去来店日一覧.Columns(3).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgv過去来店日一覧.Columns(4).Width = 28         ' 指名
        Me.dgv過去来店日一覧.Columns(4).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.dgv過去来店日一覧.Columns(5).Width = 110        ' 金額文字
        Me.dgv過去来店日一覧.Columns(5).DefaultCellStyle.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleRight

        dt = logic.ClinicalRecordInfo(Me.lbl顧客番号.Text)

        Me.カルテ一覧.DataSource = dt
        Me.カルテ一覧.Columns(0).Width = 70            ' 来店日
        Me.カルテ一覧.Columns(1).Width = 120            ' 担当者名
        Me.カルテ一覧.Columns(2).Width = 314            ' カルテ
        Me.カルテ一覧.ClearSelection()
    End Sub
#End Region

#Region "顧客情報表示"
    ''' <summary>
    ''' 顧客情報表示
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub 顧客情報表示()
        Dim dt As New DataTable
        Dim param As New Habits.DB.DBParameter
        param.Add("@顧客番号", Me.lbl顧客番号.Text)
        dt = logic.CustomerInfo(param)
        param.Clear()

        If dt.Rows.Count > 0 Then
            Dim txt_前回来店日 As String
            Dim txt_来店日N1 As String
            Dim txt_来店日N2 As String

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
                Dim AD As DateTime
                AD = DateTime.Parse(Me.lbl西暦.Text)
                Dim culture As Globalization.CultureInfo = New System.Globalization.CultureInfo("ja-JP", True)
                culture.DateTimeFormat.Calendar = New Globalization.JapaneseCalendar
                Me.lbl生年月日.Text = AD.ToString("ggyy年M月d日", culture)
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
                If DateValue(dt.Rows(0)("前回来店日").ToString) > Date.Parse("1900/01/01") Then
                    txt_前回来店日 = DateValue(dt.Rows(0)("前回来店日").ToString).ToString("yyyy/MM/dd (ddd)")
                End If
            End If
            Me.lbl来店履歴1.Text = txt_前回来店日

            txt_来店日N1 = ""
            If Not IsDBNull(dt.Rows(0)("来店日N_1")) Then
                If DateValue(dt.Rows(0)("来店日N_1").ToString) > Date.Parse("1900/01/01") Then
                    txt_来店日N1 = DateValue(dt.Rows(0)("来店日N_1").ToString).ToString("yyyy/MM/dd (ddd)")
                End If
            End If
            Me.lbl来店履歴2.Text = txt_来店日N1

            txt_来店日N2 = ""
            If Not IsDBNull(dt.Rows(0)("来店日N_2")) Then
                If DateValue(dt.Rows(0)("来店日N_2").ToString) > Date.Parse("1900/01/01") Then
                    txt_来店日N2 = DateValue(dt.Rows(0)("来店日N_2").ToString).ToString("yyyy/MM/dd (ddd)")
                End If
            End If
            Me.lbl来店履歴3.Text = txt_来店日N2

            Me.lbl主担当者.Text = dt.Rows(0)("担当者名").ToString
            If Not IsDBNull(dt.Rows(0)("登録日")) Then
                Me.lbl登録日.Text = DateValue(dt.Rows(0)("登録日").ToString).ToString("yyyy/MM/dd (ddd)")
            End If
        End If
    End Sub
#End Region

#End Region

End Class