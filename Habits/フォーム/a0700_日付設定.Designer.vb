<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a0700_日付設定
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a0700_日付設定))
        Me.btn設定 = New System.Windows.Forms.Button
        Me.btn閉じる = New System.Windows.Forms.Button
        Me.dtp設定日 = New System.Windows.Forms.DateTimePicker
        Me.btn今日 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btn設定
        '
        Me.btn設定.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn設定.Location = New System.Drawing.Point(100, 63)
        Me.btn設定.Name = "btn設定"
        Me.btn設定.Size = New System.Drawing.Size(70, 23)
        Me.btn設定.TabIndex = 3
        Me.btn設定.Text = "設定"
        Me.btn設定.UseVisualStyleBackColor = True
        '
        'btn閉じる
        '
        Me.btn閉じる.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn閉じる.Location = New System.Drawing.Point(200, 63)
        Me.btn閉じる.Name = "btn閉じる"
        Me.btn閉じる.Size = New System.Drawing.Size(70, 23)
        Me.btn閉じる.TabIndex = 4
        Me.btn閉じる.Text = "閉じる"
        Me.btn閉じる.UseVisualStyleBackColor = True
        '
        'dtp設定日
        '
        Me.dtp設定日.CalendarFont = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!)
        Me.dtp設定日.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!)
        Me.dtp設定日.Location = New System.Drawing.Point(95, 26)
        Me.dtp設定日.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtp設定日.Name = "dtp設定日"
        Me.dtp設定日.Size = New System.Drawing.Size(152, 19)
        Me.dtp設定日.TabIndex = 1
        '
        'btn今日
        '
        Me.btn今日.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn今日.Location = New System.Drawing.Point(22, 63)
        Me.btn今日.Name = "btn今日"
        Me.btn今日.Size = New System.Drawing.Size(70, 23)
        Me.btn今日.TabIndex = 2
        Me.btn今日.Text = "今日"
        Me.btn今日.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(28, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "設定日 : "
        '
        'a0700_日付設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 106)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn今日)
        Me.Controls.Add(Me.dtp設定日)
        Me.Controls.Add(Me.btn閉じる)
        Me.Controls.Add(Me.btn設定)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a0700_日付設定"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 日付設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn設定 As System.Windows.Forms.Button
    Friend WithEvents btn閉じる As System.Windows.Forms.Button
    Friend WithEvents dtp設定日 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn今日 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
