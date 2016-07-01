'システム名 ： HABITS
'機能名　　 ： a1800_通信設定
'概要　　　 ： 通信するかしないかを設定する機能
'履歴　　　 ： 2011/06/10　ＳＷＪ　作成
'バージョン ： Ver1.00
'Copyright(c) System Works Japan Co.,Ltd. 2011 All Rights Reserved.
Public Class a1800_通信設定

    Private logic As Habits.Logic.a1800_Logic ''ロジッククラス

#Region "イベント"

#Region "ページロード処理"
    ''' <summary>
    ''' ロード時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1800_通信設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        logic = New Habits.Logic.a1800_Logic
        init()
        Me.Activate()
    End Sub
#End Region

#Region "フォームクローズ後処理"
    ''' <summary>フォームが閉じられた後処理</summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub a1800_通信設定_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
#End Region

#End Region

#Region "ボタン押下イベント"

#Region "設定ボタン押下"
    ''' <summary>
    ''' 設定ボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn設定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn設定.Click
        If (MsgBox(" 通信設定を変更しますか？　", Clng_Ynqub1, TTL) = MsgBoxResult.No) Then
            Exit Sub
        End If
        SetConectFlag()
    End Sub
#End Region

#Region "閉じるボタン押下"
    ''' <summary>
    ''' 閉じるボタンクリック処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn閉じる_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn閉じる.Click
        Me.cmb_connect.Items.Clear()
        Me.Close()
    End Sub
#End Region

#End Region

#Region "メソッド"

#Region "初期処理"
    ''' <summary>
    ''' 初期処理
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub init()
        Dim item As MyComboBoxItem

        'コンボボックス設定
        Me.cmb_connect.Items.Clear()

        item = New MyComboBoxItem("001", "通信する")
        Me.cmb_connect.Items.Add(item)
        item = New MyComboBoxItem("002", "通信しない")
        Me.cmb_connect.Items.Add(item)

        Me.cmb_connect.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        ReadConectFlag()
    End Sub
#End Region

#Region "コンボボックス初期設定"
    ''' <summary>
    ''' コンボボックス初期設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReadConectFlag()
        Dim dt As DataTable
        dt = logic.GetConnectFlag()
        If Boolean.Parse(dt.Rows(0)("通信許可フラグ").ToString) = False Then
            Me.cmb_connect.Text = Me.cmb_connect.GetItemText(Me.cmb_connect.Items(1))
        Else
            Me.cmb_connect.Text = Me.cmb_connect.GetItemText(Me.cmb_connect.Items(0))
        End If
    End Sub
#End Region

#Region "通信許可フラグ設定"
    ''' <summary>
    ''' 通信許可フラグ設定
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetConectFlag()
        Dim param As New Habits.DB.DBParameter

        If Me.cmb_connect.SelectedIndex <> -1 Then

            Dim item As MyComboBoxItem

            'Load時に追加したオブジェクトの中から選択中のものを取得
            item = DirectCast(Me.cmb_connect.SelectedItem, MyComboBoxItem)

            If item.Id = "001" Then
                param.Add("@通信許可フラグ", 1)
                NETWORK_FLAG = True
            Else
                param.Add("@通信許可フラグ", 0)
                a0200_メイン.lbl_Connect.Visible = False
                NETWORK_FLAG = False
            End If
            logic.UpdateConnectFlag(param)
            param.Clear()

            MsgBox("通信設定を変更しました。　", Clng_Okinb1, TTL)
            Me.cmb_connect.Items.Clear()
            Me.Close()

        End If
    End Sub
#End Region

#Region "コンボボックスに追加される項目クラス"
    ''コンボボックスに追加する項目となるクラス
    Public Class MyComboBoxItem

        Private m_id As String = ""
        Private m_name As String = ""

        'コンストラクタ
        Public Sub New(ByVal id As String, ByVal name As String)
            m_id = id
            m_name = name
        End Sub

        '実際の値
        Public ReadOnly Property Id() As String
            Get
                Return m_id
            End Get
        End Property

        '表示名称
        '（このプロパティはこのサンプルでは使わないのでなくても良い）
        Public ReadOnly Property Name() As String
            Get
                Return m_name
            End Get
        End Property

        'オーバーライドしたメソッド
        'これがコンボボックスに表示される
        Public Overrides Function ToString() As String
            Return m_name
        End Function
    End Class
#End Region

#End Region

End Class