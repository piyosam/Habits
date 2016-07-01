'システム名 ： HABITS
'概要　　　 ：
'説明　　　 ： システム
'履歴　　　 ： 2010/04/01　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2010 All Rights Reserved.

Option Explicit On
Option Strict Off
Option Compare Binary

Module システム

    Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)

    '概要 ： Sys_Init
    '引数 ： なし
    '説明 ： システム開始時の初期処理
    Public Function Sys_Init() As Long

        '' データベースアクセスクラス生成／接続オープン
        Try
            DBA = New Habits.DB.DBAccess(True)
            DBA2 = New Habits.DB.DBAccess(True)
        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)

            MsgBox("ロード処理に失敗しました。　" & Chr(13) & Chr(13) & _
            "PCを再起動しても同じエラーが発生する場合は　" & Chr(13) & Chr(13) & _
            "システム管理者に連絡してください。　", Clng_Okexb1, TTL)
            Return 1
            Exit Function
        End Try

        Try
            '起動画面を表示する
            a0100_ロード中.ShowDialog()

            '' システム日付取得
            USER_DATE = System.DateTime.Today()

            '通信許可フラグ、当日以外修正不可フラグ、税区分設定
            Dim logicBase As Habits.Logic.LogicBase = New Habits.Logic.LogicBase
            logicBase.setA_SystemVariable()

            ''フラグ初期化
            ACTIVE_NETWORK_FLAG = False
            FORCED_CLOSE_FLAG = False
            MESSAGE_CHECK_FLAG = False
            MANAGER_MODE = False        '管理者権限削除

        Catch ex As Exception
            'ログ出力
            FileUtil.WriteLogFile(ex.ToString, _
                                            My.Application.Info.DirectoryPath, _
                                            TraceEventType.Error, _
                                            FileUtil.OutPutType.Weekly)

            MsgBox("ロード処理に失敗しました。　" & Chr(13) & Chr(13) & _
                        "PCを再起動しても同じエラーが発生する場合は　" & Chr(13) & Chr(13) & _
                        "システム管理者に連絡してください。　", Clng_Okexb1, TTL)
            rtn = 2
            Sys_Exit()
        End Try
    End Function

    '概要 ： Sys_Exit
    '引数 ： なし
    '説明 ： システム終了時の終了処理
    Public Function Sys_Exit() As Long
        Try
            If (ACTIVE_NETWORK_FLAG) Then
                FORCED_CLOSE_FLAG = True
                MsgBox("データ送信中のため、しばらくお待ちください。　", Clng_Okexb1, TTL)
                While (ACTIVE_NETWORK_FLAG)
                    Sleep(10000)
                End While
            End If

            MANAGER_MODE = False        '管理者権限解除

            '' データベース接続クローズ
            DBA.Close()
            '' データベースアクセスクラス破棄
            DBA.Dispose()
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    '概要 ： Sys_Error
    '引数 ： str_ErrMsg ,In ,string  ,エラーメッセージ
    '　　 ： con_Target ,In ,control ,飛び先
    '説明 ： エラーメッセージを出力し、該当コントロールへ位置付ける
    Public Sub Sys_Error(ByVal str_ErrMsg As String, ByVal con_Target As Object)

        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep())
        rtn = MsgBox(str_ErrMsg, Clng_Okinb1, TTL)
        con_Target.Focus()
    End Sub

    '概要 ： Sys_Trap
    '引数 ： str_Fname  ,In ,string ,フォーム名
    '　　 ： str_Mname  ,In ,string ,モジュール名
    '　　 ： str_Reason ,In ,string ,理由
    '説明 ： 論理エラー発生時の処理
    Public Sub Sys_Trap(ByVal str_Fname As String, ByVal str_Mname As String, ByVal str_Reason As String)

        rtn = MsgBox("論理エラーが発生しました。　" & Chr(13) & _
                     "以下の情報を担当者に連絡してください。　" & Chr(13) & Chr(13) & _
                     "　フォーム名　：　" & str_Fname & Chr(13) & _
                     "モジュール名　：　" & str_Mname & Chr(13) & _
                     "　　　　理由　：　" & str_Reason, Clng_Okcrb1, TTL)
    End Sub

    '概要 ： Sys_InputCheck
    '引数 ： var_Check     ,In ,Variant ,対象文字列
    '　　 ： int_Length    ,In ,Integer ,最大長
    '　　 ： str_Type      ,In ,string  ,タイプ（A：半角英数カナ, N：数字, N+：数字(0以上), K：全角文字, M：全角・半角文字, D：日付,
    '　　 ： 　　　　　       Fn：小数点数値(nは小数点以下の桁数、最大長は小数点及び小数点以下含む)）
    '　　 ： int_Operation ,In ,Integer ,必須（0：NOP, 1：CHECK）
    '説明 ：
    Public Function Sys_InputCheck(ByVal var_Check As Object, ByVal int_Length As Integer, ByVal str_Type As String, ByVal int_Operation As Integer) As Boolean

        Dim intDec As Integer

        If (int_Operation = 1) Then    'Operation判定
            Sys_InputCheck = True
        Else
            Sys_InputCheck = False
        End If

        If (var_Check.ToString = "") Then Exit Function

        If (Sys_Len(var_Check) = 0) Then Exit Function

        If (int_Operation = 0) Then    'Operation判定
            Sys_InputCheck = True
        End If

        If (int_Length = 0) Then Exit Function

        Select Case Left(str_Type, 1)

            Case "A"    '半角英数カナ

                If (Sys_Len(var_Check) > int_Length) Then Exit Function
                If (Sys_Zenkaku(var_Check)) Then Exit Function

            Case "N"    '数字

                If (Sys_Len(var_Check) > int_Length) Then Exit Function
                If Not (IsNumeric(var_Check)) Then Exit Function

                If (InStr(1, var_Check, ".", vbTextCompare) > 0) Then Exit Function '小数点チェック

                If String.Equals(str_Type, "N+") Then
                    If (CDec(var_Check) < CDec(0)) Then Exit Function '正数チェック
                End If

            Case "K"    '全角文字

                If (Sys_Len(var_Check) > int_Length * 2) Then Exit Function

            Case "M"    '全角・半角文字

                If (Len(var_Check) > int_Length) Then Exit Function

            Case "D"    '日付

                If Not (IsDate(var_Check)) Then Exit Function

            Case "F"    '小数点数値

                If (Sys_Len(var_Check) > int_Length) Then Exit Function
                If Not (IsNumeric(var_Check)) Then Exit Function

                intDec = InStr(1, var_Check, ".", vbTextCompare)    '小数点位置
                ' 少数点なしも可
                If (intDec > 0 AndAlso (Len(var_Check) - intDec) > CInt(Right(str_Type, 1))) Then Exit Function

            Case Else    'パラメータエラー

                Exit Function
        End Select

        Sys_InputCheck = False

    End Function

    '概要 ： Sys_InputCheck_Date
    '引数 ： var_Check     ,In ,Variant ,対象文字列
    '　　 ： err_Msg      ,Out ,String  ,エラーメッセージ内容
    '説明 ：
    Public Function Sys_InputCheck_Date(ByVal var_Check As Object, ByRef err_Msg As String) As Boolean
        Sys_InputCheck_Date = False

        If String.IsNullOrEmpty(var_Check) Then
            err_Msg = "は必須入力です。　"
            Exit Function
        End If
        If Sys_Zenkaku(var_Check) Then
            err_Msg = "は半角で入力してください。　"
            Exit Function
        End If
        If Sys_InputCheck(var_Check, 10, "D", 1) Then
            err_Msg = "はYYYY/MM/DD形式で入力してください。　"
            Exit Function
        End If
        If Date.Parse(var_Check) < Date.Parse(Min_Date) Then
            err_Msg = "は" & Min_Date & "以降で入力してください。　"
            Exit Function
        End If
        Sys_InputCheck_Date = True

    End Function

    '概要 ： Sys_InputCheck_Month
    '引数 ： var_Check     ,In ,Variant ,対象文字列
    '　　 ： err_Msg      ,Out ,String  ,エラーメッセージ内容
    '説明 ：
    Public Function Sys_InputCheck_Month(ByVal var_Check As Object, ByRef err_Msg As String) As Boolean
        Sys_InputCheck_Month = False

        If String.IsNullOrEmpty(var_Check) Then
            err_Msg = "は必須入力です。　"
            Exit Function
        End If
        If Sys_Zenkaku(var_Check) Then
            err_Msg = "は半角で入力してください。　"
            Exit Function
        End If
        If Sys_InputCheck(var_Check, 10, "D", 1) Then
            err_Msg = "はYYYY/MM形式で入力してください。　"
            Exit Function
        End If
        Sys_InputCheck_Month = True

    End Function

    '概要 ： Sys_Len
    '引数 ： str_Check ,In ,Variant ,対象文字列
    '説明 ： 文字数を返す
    Public Function Sys_Len(ByVal str_Check As Object) As Long

        Sys_Len = 0
        If str_Check.ToString = "" Then Exit Function
        Sys_Len = str_Check.ToString.Length

    End Function

    '概要 ： Sys_Zenkaku
    '引数 ： str_Check    ,In  ,Variant ,対象文字列
    '　　 ： Sys_Zenkaku ,In  ,Boolean ,（False：無, True：有）
    '説明 ： 全角文字の有無をチェックする
    Public Function Sys_Zenkaku(ByVal str_Check As Object) As Boolean

        Dim SJIS As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Sys_Zenkaku = False

        If SJIS.GetByteCount(str_Check.ToString()) <> str_Check.ToString().Length Then
            Sys_Zenkaku = True
        End If
    End Function

    ''' <summary>指定されたコントロール配下のテキストボックスの値をクリアする。（再帰）</summary>
    ''' <param name="v_control"></param>
    ''' <remarks></remarks>
    Public Sub Sys_ClearTextBox(ByVal v_control As System.Windows.Forms.Control)
        Dim o As System.Windows.Forms.Control
        For Each o In v_control.Controls
            If o.GetType Is GetType(System.Windows.Forms.TextBox) Then
                o.Text = ""
            End If
            If o.Controls.Count > 0 Then
                Call Sys_ClearTextBox(o)
            End If
        Next
    End Sub

    '概要 ： Sys_Lock
    '引数 ： con_Target ,In ,Control ,ロックするコントロール
    '説明 ： 指定されたコントロールをロックする
    Public Sub Sys_Lock(ByVal con_Target As Object)

        con_Target.Enabled = False
        con_Target.Locked = True

    End Sub

#Region "消費税算出"
    '概要 ： Sys_Tax
    '引数 ： var_Charge   ,In ,variant ,金額
    '　　 ： var_BaseDate ,In ,variant ,基準日
    '　　 ： var_Total ,In ,variant ,税込価格から算出の場合：1、それ以外：0
    '説明 ： 本体価格または税込価格より消費税額を計算する
    Public Function Sys_Tax(ByVal var_Charge As Object, ByVal var_BaseDate As Object, ByVal var_Total As Object) As Decimal

        Dim i As Integer
        Dim total As Integer = 100

        Sys_Tax = 0

        If IsDBNull(var_Charge) OrElse IsDBNull(var_BaseDate) OrElse var_Charge = 0 Then Exit Function

        Dim BSZ As New DataTable ' B_消費税
        Dim str_sql As String

        Try
            str_sql = "SELECT * FROM B_消費税 ORDER BY 施行日 DESC"
            BSZ = DBA.ExecuteDataTable(str_sql)
        Catch ex As Exception
            Throw ex
        End Try
        For i = 0 To (BSZ.Rows.Count - 1) Step +1
            If (var_BaseDate >= (BSZ.Rows(i)("施行日").ToString)) Then
                '税込価格からの算出の場合
                If var_Total = 1 Then
                    total = total + BSZ.Rows(i)("税率").ToString
                End If

                Select Case iTaxtype
                    Case 1 ' 切り捨て
                        Sys_Tax = Math.Floor(var_Charge * BSZ.Rows(i)("税率").ToString / total)

                    Case 2 ' 四捨五入
                        Sys_Tax = Int((var_Charge * BSZ.Rows(i)("税率").ToString / total) + 0.5)

                    Case 3 ' 切り上げ
                        Sys_Tax = Math.Ceiling(var_Charge * BSZ.Rows(i)("税率").ToString / total)

                    Case Else
                        'エラー
                        Sys_Tax = Math.Ceiling(var_Charge * BSZ.Rows(i)("税率").ToString / total)
                End Select
                Exit For
            End If
        Next i
    End Function
#End Region

#Region "サービス金額算出"
    '概要 ： Sys_Service
    '引数 ： var_Charge   ,In ,variant ,金額
    '説明 ： サービス金額を計算する
    Public Function Sys_Service(ByVal var_Charge As Object) As Decimal
        Sys_Service = 0

        If IsDBNull(var_Charge) OrElse var_Charge = 0 Then Exit Function
        Select Case iServicetype
            Case 1 ' 切り捨て
                Sys_Service = Math.Floor(var_Charge)

            Case 2 ' 四捨五入
                Sys_Service = Math.Round(var_Charge, MidpointRounding.AwayFromZero)

            Case 3 ' 切り上げ
                Sys_Service = Math.Ceiling(var_Charge)

            Case Else
                ' エラー
                Sys_Service = Math.Ceiling(var_Charge)
        End Select
    End Function
#End Region

#Region "月締開始日取得"
    '概要 ： getMonthlyStartDate
    '引数 ： var_BaseDate ,In ,variant ,基準日
    '説明 ： 基準日が属する月締開始日を計算する
    Public Function getMonthlyStartDate(ByVal var_BaseDate As Object) As Date
        Dim baseLogic As Habits.Logic.LogicBase
        baseLogic = New Habits.Logic.LogicBase

        Dim dt As DataTable
        Dim start As Integer = 1
        Dim base As Integer = DatePart("d", var_BaseDate)

        Try
            '' 月締開始日取得
            dt = baseLogic.A_System()
            If dt.Rows.Count > 0 Then
                start = dt.Rows(0)("月締開始日").ToString()
            End If

            If start > base Then
                getMonthlyStartDate = DateSerial(DatePart("yyyy", var_BaseDate), DatePart("m", var_BaseDate) - 1, start)
            Else
                getMonthlyStartDate = DateSerial(DatePart("yyyy", var_BaseDate), DatePart("m", var_BaseDate), start)
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "月初日取得"
    '概要 ： Sys_Startdate
    '引数 ： var_BaseDate ,In ,variant ,基準日
    '説明 ： 基準日が属する月の1日を計算する
    Public Function Sys_StartDate(ByVal var_BaseDate As Object) As Date

        Sys_StartDate = DateSerial(DatePart("yyyy", var_BaseDate), DatePart("m", var_BaseDate), 1)

    End Function
#End Region

#Region "月末日取得"
    '概要 ： Sys_Enddate
    '引数 ： var_BaseDate ,In ,variant ,基準日
    '説明 ： 基準日が属する月の末日を計算する
    Public Function Sys_EndDate(ByVal var_BaseDate As Object) As Date

        Sys_EndDate = DateAdd("m", 1, DateSerial(DatePart("yyyy", var_BaseDate), DatePart("m", var_BaseDate), 1))
        Sys_EndDate = DateAdd("d", -1, Sys_EndDate)

    End Function
#End Region

#Region "数値キーのみ入力可設定"
    ''' <summary>
    ''' 数値キーのみ入力可設定
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub Sys_KeyPressNumeric(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar < "0"c Or e.KeyChar > "9"c) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
#End Region

#Region "COMオブジェクトを開放"
    ''' <summary>
    ''' COMオブジェクトを開放
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <remarks></remarks>
    Public Sub MRComObject(ByRef obj As Object)
        If Not obj Is Nothing Then System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
        obj = Nothing
        GC.Collect()
    End Sub
#End Region

End Module
