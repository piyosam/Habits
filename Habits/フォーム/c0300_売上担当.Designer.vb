<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class c0300_売上担当
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(c0300_売上担当))
        Me.Label1 = New System.Windows.Forms.Label
        Me.ddl担当者 = New System.Windows.Forms.ComboBox
        Me.btn設定 = New System.Windows.Forms.Button
        Me.btn閉じる = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "担当者 :"
        '
        'ddl担当者
        '
        Me.ddl担当者.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddl担当者.DropDownWidth = 450
        Me.ddl担当者.FormattingEnabled = True
        Me.ddl担当者.Location = New System.Drawing.Point(68, 15)
        Me.ddl担当者.Name = "ddl担当者"
        Me.ddl担当者.Size = New System.Drawing.Size(142, 21)
        Me.ddl担当者.TabIndex = 1
        '
        'btn設定
        '
        Me.btn設定.Location = New System.Drawing.Point(229, 13)
        Me.btn設定.Name = "btn設定"
        Me.btn設定.Size = New System.Drawing.Size(100, 23)
        Me.btn設定.TabIndex = 2
        Me.btn設定.Text = "設定"
        Me.btn設定.UseVisualStyleBackColor = True
        '
        'btn閉じる
        '
        Me.btn閉じる.Location = New System.Drawing.Point(229, 48)
        Me.btn閉じる.Name = "btn閉じる"
        Me.btn閉じる.Size = New System.Drawing.Size(100, 23)
        Me.btn閉じる.TabIndex = 3
        Me.btn閉じる.Text = "閉じる"
        Me.btn閉じる.UseVisualStyleBackColor = True
        '
        'c0300_売上担当
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 84)
        Me.Controls.Add(Me.btn閉じる)
        Me.Controls.Add(Me.btn設定)
        Me.Controls.Add(Me.ddl担当者)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "c0300_売上担当"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 担当者変更"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ddl担当者 As System.Windows.Forms.ComboBox
    Friend WithEvents btn設定 As System.Windows.Forms.Button
    Friend WithEvents btn閉じる As System.Windows.Forms.Button
End Class
