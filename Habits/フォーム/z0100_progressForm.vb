'システム名 ： HABITS
'機能名　　 ： z0100_progressForm
'概要　　　 ： プログレスバー（進行状況）表示機能
'           ： 参照：http://www.atmarkit.co.jp/fdotnet/dotnettips/181waitdlg/waitdlg.vb
'履歴　　　 ： 2011/04/20　ＳＷＪ　作成
'           ： 2011/09/28　ＳＷＪ　現在未使用であるが、参考になるため削除せず残してみた
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.Imports System.Data
Public Class z0100_progressForm

    '----------------------------------------------------------------------
    '   進捗のMax件数が明確な場合
    '       ShowメソッドやInitメソッドでBarのMaxを設定して
    '       SetメソッドでBarの現在位置を指定します。
    '       ※各プロパティ(Msg1～3、BarMin、BarMax、BarVal)を設定してもOK
    '----------------------------------------------------------------------
    '   進捗のMax件数が不明な場合
    '       AutoOnメソッドで自動進捗を開始し
    '       AutoOffメソッドで自動進捗を終了します。
    '----------------------------------------------------------------------

#Region "変数・定数"
    ''' <summary>ダイアログ表示中フラグ</summary>
    Private bShowing As Boolean = False

    ''' <summary>呼び出しフォーム</summary>
    Dim fmParent As System.Windows.Forms.Form

    ''' <summary>バックグラウンド処理</summary>
    Private WithEvents m_Background As New ComponentModel.BackgroundWorker

    ''' <summary>進捗用メッセージ</summary>
    Enum enmMsg2
        ''' <summary>データ取得中…</summary>
        GetData
        ''' <summary>データ取得終了</summary>
        GotData
    End Enum

#End Region

#Region "インスタンス生成"
    Sub New(Optional ByVal fmParent As System.Windows.Forms.Form = Nothing)
        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        Me.Text = "処理中…"

        '' 呼び出しフォーム取得
        If fmParent Is Nothing Then
            Me.fmParent = CType(System.Windows.Forms.Form.ActiveForm, a0200_メイン)
        Else
            Me.fmParent = fmParent
        End If

        '' バッググラウンド変数設定
        m_Background.WorkerReportsProgress = True       '' 進行状況の更新を報告できるかどうかを設定。
        m_Background.WorkerSupportsCancellation = True  '' 非同期のキャンセルをサポートするかどうかを設定。

    End Sub
    Sub New(ByVal fmParentName As String)
        Me.New(DirectCast(My.Application.OpenForms.Item(fmParentName), System.Windows.Forms.Form))
        '' この呼び出しは、Windows フォーム デザイナで必要です。
        'InitializeComponent()

        'Dim fm As BaseForm = DirectCast(My.Application.OpenForms.Item(fmParentName), BaseForm)
    End Sub
#End Region

#Region "Showメソッドのシャドウ"
    ''' <summary>Showメソッドのシャドウ</summary>
    ''' <param name="vMsg1">１番目のメッセージ ※省略時は空文字をセット</param>
    ''' <param name="vMsg2">２番目のメッセージ ※省略時は空文字をセット</param>
    ''' <param name="vMsg3">３番目のメッセージ ※省略時は空文字をセット</param>
    ''' <param name="vBarMax">進捗バー最大値</param>
    ''' <remarks></remarks>
    Public Shadows Sub Show( _
        Optional ByVal vMsg1 As String = Nothing, _
        Optional ByVal vMsg2 As String = Nothing, _
        Optional ByVal vMsg3 As String = Nothing, _
        Optional ByVal vBarMax As Integer = 100 _
    )
        ' 変数の初期化
        Me.DialogResult = DialogResult.OK

        Me.Init(vMsg1, vMsg2, vMsg3, vBarMax)

        MyBase.Show() : Me.bShowing = True

        Me.fmParent.Enabled = False

        '' 砂時計表示
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        System.Windows.Forms.Application.DoEvents()

    End Sub
#End Region

#Region "ShowDialogメソッドのシャドウ / 使用不可"
    ''' <summary>ShowDialogメソッドのシャドウ（WaitDialogクラスでは、ShowDialogメソッドは使用不可）</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function ShowDialog() As System.Windows.Forms.DialogResult
        Debug.Assert(False, _
         "WaitDialogクラスはShowDialogメソッドを利用できません。" + vbCrLf + _
         "Showメソッドを使ってモードレス・ダイアログを構築してください。")
        Return DialogResult.Abort
    End Function
#End Region

#Region "Closeメソッドのシャドウ"
    ''' <summary>Closeメソッドのシャドウ</summary>
    ''' <remarks></remarks>
    Public Shadows Sub Close()

        '' バックグラウンド実行中なら、バックグラウンド処理中止
        If m_Background.IsBusy Then m_Background.CancelAsync()

        If Me.bShowing Then Me.bShowing = False : MyBase.Close()

        Me.fmParent.Enabled = True
        Me.fmParent.Activate()

        '' 砂時計解除
        Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub
#End Region

#Region "X キャンセル処理 / 使用不可"
    'Private bCancel As Boolean = False   ' 中止フラグ

    '''' <summary>キャンセル・ボタンが押されたときの処理</summary>
    '''' <param name="sender"></param>
    '''' <param name="e"></param>
    '''' <remarks>処理を途中でキャンセル（中断）する。</remarks>
    'Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ' 中止処理
    '    Cancel()
    'End Sub

    '''' <summary>中止（キャンセル）処理</summary>
    '''' <remarks></remarks>
    'Private Sub Cancel()
    '    Me.bCancel = True
    '    Me.DialogResult = DialogResult.Abort
    'End Sub

    '''' <summary>処理がキャンセル（中止）されているかどうかを示す値を取得する。</summary>
    '''' <value></value>
    '''' <returns></returns>
    '''' <remarks>キャンセルされた場合はtrue。それ以外はfalse。</remarks>
    'Public ReadOnly Property IsCancel() As Boolean
    '    Get
    '        Return Me.bCancel
    '    End Get
    'End Property
#End Region

#Region "イベント：MyBase_Closing / ダイアログが閉じられるときの処理"
    ''' <summary>ダイアログが閉じられるときの処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>右上の［閉じる］ボタンが押された場合には、閉じるイベントを無効にする。</remarks>
    Private Sub MyBase_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bShowing = True Then
            ' まだダイアログは閉じない
            e.Cancel = True
        Else
            ' フォームは閉じられるところので素直に閉じる
            e.Cancel = False
        End If
    End Sub
#End Region

#Region "プロパティ：Msg1 / １番目のメッセージ"
    ''' <summary>メイン・メッセージのテキストを設定する。</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>処理の概要を表示する。</item>
    ''' <item>例えば、ファイルの転送を行っているなら、「ファイルを転送しています……」のように表示する。</item>
    ''' </remarks>
    Public Property Msg1() As String
        Get
            Return Me.lblMsg1.Text
        End Get
        Set(ByVal Value As String)
            Me.lblMsg1.Text = Value
        End Set
    End Property
#End Region

#Region "プロパティ：Msg2 / ２番目のメッセージ"
    ''' <summary>サブ・メッセージのテキストを設定する。</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>詳細な処理内容を表示する。</item>
    ''' <item>例えば、ファイル転送なら、転送中の個別のファイル名（「readme.htm」「contents.htm」など）を表示する。</item>
    ''' </remarks>
    Public Property Msg2() As String
        Get
            Return Me.lblMsg2.Text
        End Get
        Set(ByVal Value As String)
            Me.lblMsg2.Text = Value
        End Set
    End Property
#End Region

#Region "プロパティ：Msg3 / ３番目のメッセージ"
    ' 処理の進行状況として、「何件分の何件が終わったのか」「全体の何％が終わったのか」などを表示する。
    ''' <summary>進行状況メッセージのテキストを設定する。</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>処理の進行状況として、「何件分の何件が終わったのか」「全体の何％が終わったのか」などを表示する。</item>
    ''' </remarks>
    Public Property Msg3() As String
        Get
            Return Me.lblMsg3.Text
        End Get
        Set(ByVal Value As String)
            Me.lblMsg3.Text = Value
        End Set
    End Property
#End Region

#Region "プロパティ：BarVal / 進行バーの現在位置を設定する。"
    ''' <summary>進行バーの現在位置を設定する。</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>例えば、処理に200の工数があった場合、現在その200の工数の中のどの位置にいるかを示す値。</item>
    ''' <item> 既定値は「0」。</item>
    ''' </remarks>
    Public Property BarVal() As Integer
        Get
            Return Me.prgBar.Value
        End Get
        Set(ByVal Value As Integer)
            Me.prgBar.Value = Value
        End Set
    End Property
#End Region

#Region "プロパティ：BarMax / 進行バーの範囲の最大値を設定する。"
    ''' <summary>進行バーの範囲の最大値を設定する。</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>処理に200の工数があるなら「200」になる。</item>
    ''' <item>既定値は「100」。</item>
    ''' </remarks>
    Public Property BarMax() As Integer
        Get
            Return Me.prgBar.Maximum
        End Get
        Set(ByVal Value As Integer)
            Me.prgBar.Maximum = Value
        End Set
    End Property
#End Region

#Region "プロパティ：BarMin / 進行バーの範囲の最小値を設定する。"
    ''' <summary>進行バーの範囲の最小値を設定する。</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>既定値は「0」。</item>
    ''' </remarks>
    Public Property BarMin() As Integer
        Get
            Return Me.prgBar.Minimum
        End Get
        Set(ByVal Value As Integer)
            Me.prgBar.Minimum = Value
        End Set
    End Property
#End Region

#Region "プロパティ：BarStep / 進行バーの現在位置（BarVal）を進める量を設定する。"
    ''' <summary>PerformStepメソッドを呼び出したときに、進行バーの現在位置を進める量（BarValの増分値）を設定する。</summary>
    ''' <value></value>
    ''' <remarks>
    ''' <item>処理工数が200で、5つの工数が終わった段階で進行バーを更新したい場合は「5」にする。</item>
    ''' <item>既定値は「10」。</item>
    ''' </remarks>
    Public Property BarStep() As Integer
        Get
            Return Me.prgBar.Step
        End Get
        Set(ByVal Value As Integer)
            Me.prgBar.Step = Value
        End Set
    End Property
#End Region

#Region "プロパティ：PerformStep / 進行バーの現在位置（BarVal）をBarStepプロパティの量だけ進める。"
    ''' <summary>進行バーの現在位置（BarVal）をBarStepプロパティの量だけ進める。</summary>
    ''' <remarks></remarks>
    Public Sub PerformStep()
        Me.prgBar.PerformStep()
    End Sub
#End Region

#Region "プロパティ：Init / 進行状況を初期化する。"
    ''' <summary>進行状況を初期化する。</summary>
    ''' <param name="vMsg1">１番目のメッセージ ※省略時は空文字をセット</param>
    ''' <param name="vMsg2">２番目のメッセージ ※省略時は空文字をセット</param>
    ''' <param name="vMsg3">３番目のメッセージ ※省略時は空文字をセット</param>
    ''' <param name="vBarMax">進捗バー最大値</param>
    ''' <remarks>自動進捗実行中なら自動進捗終了を行います。</remarks>
    Public Sub Init( _
        Optional ByVal vMsg1 As String = Nothing, _
        Optional ByVal vMsg2 As String = Nothing, _
        Optional ByVal vMsg3 As String = Nothing, _
        Optional ByVal vBarMax As Integer = 100 _
    )
        Call AutoOff()  '' 自動進捗終了
        If vMsg1 Is Nothing Then vMsg1 = ""
        If vMsg2 Is Nothing Then vMsg2 = ""
        If vMsg3 Is Nothing Then vMsg3 = ""
        Me.Msg1 = vMsg1
        Me.Msg2 = vMsg2
        Me.Msg3 = vMsg3
        Me.BarMax = vBarMax
        Me.BarStep = 1
        Me.BarVal = 0
        Me.Activate()
        System.Windows.Forms.Application.DoEvents()
    End Sub
#End Region

#Region "プロパティ：Set / 進行状況を設定する。"
    ''' <summary>進行状況を設定する。</summary>
    ''' <param name="vBarVal">進捗バー現在位置</param>
    ''' <param name="vMsg1">１番目のメッセージ ※省略時はそのまま</param>
    ''' <param name="vMsg2">２番目のメッセージ ※省略時はそのまま</param>
    ''' <param name="vMsg3">３番目のメッセージ ※省略時はそのまま</param>
    ''' <remarks></remarks>
    Public Sub [Set]( _
        ByVal vBarVal As Integer, _
        Optional ByVal vMsg1 As String = Nothing, _
        Optional ByVal vMsg2 As String = Nothing, _
        Optional ByVal vMsg3 As String = Nothing _
    )
        If Not vMsg1 Is Nothing Then Me.Msg1 = vMsg1
        If Not vMsg2 Is Nothing Then Me.Msg2 = vMsg2
        If Not vMsg3 Is Nothing Then Me.Msg3 = vMsg3
        Me.BarVal = vBarVal
        Me.Activate()
        System.Windows.Forms.Application.DoEvents()
    End Sub
#End Region

#Region "Private プロパティ：getMsg / 進行メッセージを返す。"
    Private Function getMsg(ByVal vMsg As enmMsg2) As String
        Dim sMsg As String = "処理中…"
        Select Case vMsg
            Case enmMsg2.GetData : sMsg = "データ取得中…"
            Case enmMsg2.GotData : sMsg = "データ取得終了"
        End Select
        Return sMsg
    End Function
#End Region

#Region "プロパティ：AutoOn / 自動進捗（バックグラウンド）開始"
    Public Sub AutoOn(ByVal vMsg2 As String)
        Me.Msg2 = vMsg2
        Me.BarVal = Me.BarMin
        Me.Activate()
        If Not m_Background.IsBusy Then m_Background.RunWorkerAsync(100) '' バックグラウンド処理を開始する。
    End Sub
    Public Sub AutoOn(ByVal vMsg2 As enmMsg2)
        Dim sMsg As String = getMsg(vMsg2)
        Call AutoOn(sMsg)
    End Sub
#End Region

#Region "プロパティ：AutoOff / 自動進捗（バックグラウンド）終了"
    Public Sub AutoOff(Optional ByVal vMsg2 As String = Nothing)
        If m_Background.IsBusy Then m_Background.CancelAsync() '' バックグラウンド処理を終了する。
        If vMsg2 Is Nothing Then vMsg2 = ""
        Me.Msg2 = vMsg2
        Me.Activate()
    End Sub
    Public Sub AutoOff(ByVal vMsg2 As enmMsg2)
        Dim sMsg As String = getMsg(vMsg2)
        Call AutoOff(sMsg)
    End Sub
#End Region

#Region "イベント：m_Background_DoWork / バックグラウンドのワーク処理。"
    Private Sub m_Background_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles m_Background.DoWork
        ' このメソッドへのパラメータ
        Dim iArg As Integer = CType(e.Argument, Integer)

        ' 時間のかかる処理
        For i As Integer = 1 To iArg

            ' キャンセルされてないか定期的にチェック
            If m_Background.CancellationPending Then
                e.Cancel = True
                Return
            End If

            System.Threading.Thread.Sleep(100)

            Dim percentage As Integer = CInt(i * 100 / iArg) ' 進ちょく率
            If percentage < Me.BarMin Then percentage = Me.BarMin
            If Me.BarMax < percentage Then percentage = Me.BarMax
            m_Background.ReportProgress(percentage)
            ' ProgressChangedイベント発生
        Next

        ' このメソッドからの戻り値
        e.Result = "すべて完了"

        ' この後、m_Background_RunWorkerCompletedイベントが発生
    End Sub
#End Region

#Region "イベント：m_Background_ProgressChanged / 進行状況をレポートするため、同期セッション中に定期的に発生します。"
    Private Sub m_Background_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles m_Background.ProgressChanged
        Try
            Me.prgBar.Value = e.ProgressPercentage
        Catch ex As Exception
            '' 何もしない
        End Try
    End Sub
#End Region

#Region "イベント：m_Background_RunWorkerCompleted / バックグラウンド操作の完了時、キャンセル時、またはバックグラウンド操作によって例外が発生したときに発生します。"
    Private Sub m_Background_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles m_Background.RunWorkerCompleted
        Me.Activate()
    End Sub
#End Region

End Class