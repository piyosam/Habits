'<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
'Partial Class ProgressForm
'    Inherits System.Windows.Forms.Form

'    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
'    <System.Diagnostics.DebuggerNonUserCode()> _
'    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
'        Try
'            If disposing AndAlso components IsNot Nothing Then
'                components.Dispose()
'            End If
'        Finally
'            MyBase.Dispose(disposing)
'        End Try
'    End Sub

'    'Windows フォーム デザイナで必要です。
'    Private components As System.ComponentModel.IContainer

'    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
'    'Windows フォーム デザイナを使用して変更できます。  
'    'コード エディタを使って変更しないでください。
'    <System.Diagnostics.DebuggerStepThrough()> _
'    Private Sub InitializeComponent()
'        components = New System.ComponentModel.Container
'        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
'        Me.Text = "ProgressForm"
'    End Sub
'End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class z0100_progressForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.prgBar = New System.Windows.Forms.ProgressBar
        Me.lblMsg3 = New System.Windows.Forms.Label
        Me.lblMsg2 = New System.Windows.Forms.Label
        Me.lblMsg1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'prgBar
        '
        Me.prgBar.Location = New System.Drawing.Point(8, 70)
        Me.prgBar.Name = "prgBar"
        Me.prgBar.Size = New System.Drawing.Size(296, 23)
        Me.prgBar.TabIndex = 14
        '
        'lblMsg3
        '
        Me.lblMsg3.Location = New System.Drawing.Point(8, 54)
        Me.lblMsg3.Name = "lblMsg3"
        Me.lblMsg3.Size = New System.Drawing.Size(296, 16)
        Me.lblMsg3.TabIndex = 13
        Me.lblMsg3.Text = "進捗メッセージ"
        '
        'lblMsg2
        '
        Me.lblMsg2.Location = New System.Drawing.Point(8, 38)
        Me.lblMsg2.Name = "lblMsg2"
        Me.lblMsg2.Size = New System.Drawing.Size(296, 16)
        Me.lblMsg2.TabIndex = 12
        Me.lblMsg2.Text = "サブ・メッセージ"
        '
        'lblMsg1
        '
        Me.lblMsg1.Location = New System.Drawing.Point(8, 8)
        Me.lblMsg1.Name = "lblMsg1"
        Me.lblMsg1.Size = New System.Drawing.Size(296, 30)
        Me.lblMsg1.TabIndex = 11
        Me.lblMsg1.Text = "メイン・メッセージ"
        '
        'z0100_progressForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(311, 100)
        Me.ControlBox = False
        Me.Controls.Add(Me.prgBar)
        Me.Controls.Add(Me.lblMsg3)
        Me.Controls.Add(Me.lblMsg2)
        Me.Controls.Add(Me.lblMsg1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "z0100_progressForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ProgressForm"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents prgBar As System.Windows.Forms.ProgressBar
    Public WithEvents lblMsg3 As System.Windows.Forms.Label
    Public WithEvents lblMsg2 As System.Windows.Forms.Label
    Public WithEvents lblMsg1 As System.Windows.Forms.Label
End Class

