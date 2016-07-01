<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class c0500_メモ設定
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(c0500_メモ設定))
        Me.Label1 = New System.Windows.Forms.Label
        Me.ラベル = New System.Windows.Forms.TextBox
        Me.設定 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.伝言フラグ = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "メモ : "
        '
        'ラベル
        '
        Me.ラベル.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.ラベル.Location = New System.Drawing.Point(20, 33)
        Me.ラベル.MaxLength = 32
        Me.ラベル.Multiline = True
        Me.ラベル.Name = "ラベル"
        Me.ラベル.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ラベル.Size = New System.Drawing.Size(324, 77)
        Me.ラベル.TabIndex = 1
        '
        '設定
        '
        Me.設定.Location = New System.Drawing.Point(358, 31)
        Me.設定.Name = "設定"
        Me.設定.Size = New System.Drawing.Size(100, 23)
        Me.設定.TabIndex = 3
        Me.設定.Text = "設定"
        Me.設定.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(358, 66)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 4
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        '伝言フラグ
        '
        Me.伝言フラグ.AutoSize = True
        Me.伝言フラグ.Location = New System.Drawing.Point(20, 125)
        Me.伝言フラグ.Name = "伝言フラグ"
        Me.伝言フラグ.Size = New System.Drawing.Size(117, 17)
        Me.伝言フラグ.TabIndex = 2
        Me.伝言フラグ.Text = "次回来店時伝言"
        Me.伝言フラグ.UseVisualStyleBackColor = True
        '
        'c0500_メモ設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 154)
        Me.Controls.Add(Me.伝言フラグ)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.設定)
        Me.Controls.Add(Me.ラベル)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "c0500_メモ設定"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - メモ設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ラベル As System.Windows.Forms.TextBox
    Friend WithEvents 設定 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents 伝言フラグ As System.Windows.Forms.CheckBox
End Class
