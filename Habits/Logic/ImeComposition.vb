Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Text
Imports Microsoft.VisualBasic

Namespace ImeComposition

    '----------------------------------------------------------------
    '	 変換イベントクラス
    '----------------------------------------------------------------
    Public Class ConvertedEventArgs
        Inherits EventArgs
        Private yomi As String      ' フリガナ
        Private bSingle As Boolean      ' 半角文字か
        Private yomiLength As Integer = 0    ' フリガナの文字数
        Public Sub New(ByVal f As String, ByVal singleFlag As Boolean, ByVal friLen As Integer)
            yomi = f
            bSingle = singleFlag
            yomiLength = friLen
        End Sub
        Public ReadOnly Property YomiString() As String
            Get
                Return yomi
            End Get
        End Property
        Public ReadOnly Property YomiLen() As Integer
            Get
                Return yomiLength
            End Get
        End Property

        Public ReadOnly Property IsSingleChar() As Boolean
            Get
                Return bSingle
            End Get
        End Property
    End Class

    '----------------------------------------------------------------
    ' 読みを取得するクラス
    '----------------------------------------------------------------
    Public Class ImeYomiConversion

        '----------------------------------------------------------------
        ' 	ローカル変数
        '----------------------------------------------------------------
        Private targetControl As Control        '  漢字入力のコントロール
        Private targetYomiControl As Control        '  読みをセットするコントロール
        Private listener As MsgListener
        Private isHalf As Boolean

#Region "IME API定義"

        Private Const WM_CHAR As Integer = &H102
        Private Const WM_IME_STARTCOMPOSITION As Integer = &H10D
        Private Const WM_IME_ENDCOMPOSITION As Integer = &H10E
        Private Const WM_IME_COMPOSITION As Integer = &H10F      ' WM_IME_COMPOSITION
        Private Const GCS_COMPREADSTR As Integer = &H1
        Private Const GCS_COMPREADATTR As Integer = &H2
        Private Const GCS_COMPREADCLAUSE As Integer = &H4
        Private Const GCS_COMPSTR As Integer = &H8
        Private Const GCS_COMPATTR As Integer = &H10
        Private Const GCS_COMPCLAUSE As Integer = &H20
        Private Const GCS_CURSORPOS As Integer = &H80
        Private Const GCS_DELTASTART As Integer = &H100
        Private Const GCS_RESULTREADSTR As Integer = &H200
        Private Const GCS_RESULTREADCLAUSE As Integer = &H400
        Private Const GCS_RESULTSTR As Integer = &H800
        Private Const GCS_RESULTCLAUSE As Integer = &H1000

        Private Const IMM_ERROR_NODATA As Integer = -1
        Private Const IMM_ERROR_GENERAL As Integer = -2

        '----------------------------------------------------------------
        ' コンテキストハンドルの取得
        '
        <DllImport("Imm32.dll")> _
        Private Shared Function ImmGetContext(ByVal hWnd As Integer) As Integer
        End Function

        '----------------------------------------------------------------
        ' コンテキストハンドルの開放
        '
        <DllImport("Imm32.dll")> _
        Private Shared Function ImmReleaseContext(ByVal hWnd As Integer, ByVal hIMC As Integer) As Integer
        End Function

        '----------------------------------------------------------------
        ' IMEよりフリガナ等の文字列を取得する
        '
        <DllImport("Imm32.dll")> _
        Private Shared Function ImmGetCompositionString(ByVal hIMC As Integer, ByVal dwIndex As Integer, ByVal lpBuf As StringBuilder, ByVal dwBufLen As Integer) As Integer
        End Function

        '----------------------------------------------------------------
        ' Windowの検索
        '
        '<DllImport("User32.dll")> _
        'Private Shared Function FindWindowEx(ByVal hwndParent As Integer, ByVal hwndChildAfter As Integer, ByVal lpszClass As String, ByVal lpszWindow As String) As Integer
        'End Function

        '----------------------------------------------------------------
        ' IMEの状態取得
        '
        <DllImport("Imm32.dll")> _
        Private Shared Function ImmGetOpenStatus(ByVal hIMC As Integer) As Integer
        End Function

#End Region

        ' targetCtrl ... 日本語入力が行われるコントロール
        ' yomiCtrl ... 読みをセットするコントロール
        Public Sub New(ByVal targetCtrl As Control, ByVal yomiCtrl As Control, Optional ByVal half As Boolean = False)
            targetControl = targetCtrl
            Me.targetYomiControl = yomiCtrl
            listener = New MsgListener(targetControl)
            isHalf = half
            '日本語入力が確定したらイベントで通知
            AddHandler listener.OnConverted, AddressOf eventConverted
        End Sub

        ' メッセージ監視のOn/Off
        Public Property Enabled() As Boolean
            Get
                Return listener.Enabled
            End Get
            Set(ByVal value As Boolean)
                listener.Enabled = value
            End Set
        End Property


        ' 読みをコントロールにセットする
        Private Sub eventConverted(ByVal sender As Object, ByVal ea As ConvertedEventArgs)
            If targetControl.Text.Length = 0 Then
                ' 漢字入力のコントロールが空なら読みも空に
                targetYomiControl.Text = ""
            End If
            Dim s As String = ""
            If ea.IsSingleChar Then
                s = ea.YomiString
            Else
                s = Strings.StrConv(ea.YomiString, VbStrConv.Wide, &H411)
            End If
            ' フリガナをコントロールにセットする
            If isHalf Then
                s = StrConv(s, VbStrConv.Narrow)
            End If
            targetYomiControl.Text += s
        End Sub



#Region "Window Message Listener"
        ' 漢字入力のコントロールに送られるメッセージをチェックする
        Private Class MsgListener
            Inherits NativeWindow

            Protected m_enabled As Boolean = False          ' メッセージの監視状態(on/Off)
            Public Delegate Sub Converted(ByVal sender As System.Object, ByVal e As ConvertedEventArgs)
            Public Event OnConverted As Converted

            '-- constructor
            Public Sub New(ByVal c As Control)
                AssignHandle(c.Handle)
                AddHandler c.HandleDestroyed, AddressOf OnHandleDestroyed
            End Sub
            Friend Sub OnHandleDestroyed(ByVal sender As Object, ByVal e As EventArgs)
                ' Window was destroyed, release hook.
                ReleaseHandle()
            End Sub

            Public Property Enabled() As Boolean
                Get
                    Return m_enabled
                End Get
                Set(ByVal value As Boolean)
                    m_enabled = value
                End Set
            End Property

            ''----------------------------------------------------------------
            '' 	読み取得対象コントロールのウィンドウプロシージャ
            ''----------------------------------------------------------------
            Protected Overloads Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
                Dim hIMC As Integer
                Dim intLength As Integer

                If m_enabled Then
                    Select Case m.Msg
                        Case WM_IME_COMPOSITION
                            Dim strYomi As String = ""
                            If (CUInt(m.LParam) And CUInt(GCS_RESULTREADSTR)) <> 0 Then
                                hIMC = ImmGetContext(Me.Handle.ToInt32())

                                ' 読みの文字列
                                intLength = ImmGetCompositionString(hIMC, GCS_RESULTREADSTR, Nothing, 0)
                                If intLength > 0 Then
                                    Dim temp As New StringBuilder(intLength)
                                    ImmGetCompositionString(hIMC, GCS_RESULTREADSTR, temp, intLength)
                                    strYomi = temp.ToString()
                                    If strYomi.Length > intLength Then
                                        strYomi = strYomi.Substring(0, intLength)
                                    End If
                                    ' イベント起動
                                    Dim ea As New ConvertedEventArgs(strYomi, False, intLength)

                                    RaiseEvent OnConverted(Me, ea)
                                End If
                                ImmReleaseContext(Me.Handle.ToInt32(), hIMC)
                            End If
                            Exit Select
                        Case WM_CHAR '半角英数字
                            hIMC = ImmGetContext(Me.Handle.ToInt32())
                            If ImmGetOpenStatus(hIMC) = 0 Then
                                Dim chr As Char = Convert.ToChar(m.WParam.ToInt32() And &HFF)
                                If m.WParam.ToInt32() >= 32 Then
                                    'イベント起動
                                    Dim str As String = chr.ToString()
                                    Dim ea As ConvertedEventArgs = New ConvertedEventArgs(str, True, 1)
                                    RaiseEvent OnConverted(Me, ea)
                                End If
                            End If
                            ImmReleaseContext(Me.Handle.ToInt32(), hIMC)
                            Exit Select

                    End Select
                End If
                MyBase.WndProc(m)
            End Sub
        End Class
#End Region
    End Class
End Namespace
