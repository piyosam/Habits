<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a0500_顧客番号設定
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a0500_顧客番号設定))
        Me.Label1 = New System.Windows.Forms.Label
        Me.顧客番号 = New System.Windows.Forms.TextBox
        Me.設定 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "顧客番号 :"
        '
        '顧客番号
        '
        Me.顧客番号.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.顧客番号.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.顧客番号.Location = New System.Drawing.Point(84, 14)
        Me.顧客番号.MaxLength = 6
        Me.顧客番号.Name = "顧客番号"
        Me.顧客番号.Size = New System.Drawing.Size(78, 20)
        Me.顧客番号.TabIndex = 1
        Me.顧客番号.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '設定
        '
        Me.設定.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.設定.Location = New System.Drawing.Point(182, 11)
        Me.設定.Name = "設定"
        Me.設定.Size = New System.Drawing.Size(100, 23)
        Me.設定.TabIndex = 2
        Me.設定.Text = "設定"
        Me.設定.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.閉じる.Location = New System.Drawing.Point(182, 47)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 3
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'a0500_顧客番号設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(297, 87)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.設定)
        Me.Controls.Add(Me.顧客番号)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a0500_顧客番号設定"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 顧客番号設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 顧客番号 As System.Windows.Forms.TextBox
    Friend WithEvents 設定 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
End Class
