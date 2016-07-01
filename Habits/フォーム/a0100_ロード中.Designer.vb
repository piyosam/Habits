<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a0100_ロード中
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a0100_ロード中))
        Me.LoadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pbロード中 = New System.Windows.Forms.PictureBox
        CType(Me.pbロード中, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LoadTimer
        '
        Me.LoadTimer.Enabled = True
        Me.LoadTimer.Interval = 200
        '
        'pbロード中
        '
        Me.pbロード中.Image = CType(resources.GetObject("pbロード中.Image"), System.Drawing.Image)
        Me.pbロード中.Location = New System.Drawing.Point(0, 0)
        Me.pbロード中.Name = "pbロード中"
        Me.pbロード中.Size = New System.Drawing.Size(416, 416)
        Me.pbロード中.TabIndex = 0
        Me.pbロード中.TabStop = False
        '
        'a0100_ロード中
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(416, 416)
        Me.ControlBox = False
        Me.Controls.Add(Me.pbロード中)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "a0100_ロード中"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pbロード中, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Friend WithEvents LoadTimer As System.Windows.Forms.Timer
    Friend WithEvents pbロード中 As System.Windows.Forms.PictureBox
End Class
