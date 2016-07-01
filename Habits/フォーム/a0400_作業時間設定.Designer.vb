<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a0400_作業時間設定
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a0400_作業時間設定))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt作業開始 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txt作業終了 = New System.Windows.Forms.TextBox
        Me.btn設定 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "作業時間 :"
        '
        'txt作業開始
        '
        Me.txt作業開始.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt作業開始.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt作業開始.Location = New System.Drawing.Point(77, 14)
        Me.txt作業開始.MaxLength = 4
        Me.txt作業開始.Name = "txt作業開始"
        Me.txt作業開始.Size = New System.Drawing.Size(70, 20)
        Me.txt作業開始.TabIndex = 1
        Me.txt作業開始.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(153, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "～"
        '
        'txt作業終了
        '
        Me.txt作業終了.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt作業終了.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt作業終了.Location = New System.Drawing.Point(176, 14)
        Me.txt作業終了.MaxLength = 4
        Me.txt作業終了.Name = "txt作業終了"
        Me.txt作業終了.Size = New System.Drawing.Size(70, 20)
        Me.txt作業終了.TabIndex = 2
        Me.txt作業終了.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn設定
        '
        Me.btn設定.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn設定.Location = New System.Drawing.Point(255, 13)
        Me.btn設定.Name = "btn設定"
        Me.btn設定.Size = New System.Drawing.Size(100, 23)
        Me.btn設定.TabIndex = 3
        Me.btn設定.Text = "設定"
        Me.btn設定.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.閉じる.Location = New System.Drawing.Point(255, 49)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 4
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'a0400_作業時間設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 86)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.btn設定)
        Me.Controls.Add(Me.txt作業終了)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt作業開始)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a0400_作業時間設定"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 作業時間設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt作業開始 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt作業終了 As System.Windows.Forms.TextBox
    Friend WithEvents btn設定 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
End Class
