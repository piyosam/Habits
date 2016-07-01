<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a1800_通信設定
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a1800_通信設定))
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn閉じる = New System.Windows.Forms.Button
        Me.btn設定 = New System.Windows.Forms.Button
        Me.cmb_connect = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(28, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "通信 : "
        '
        'btn閉じる
        '
        Me.btn閉じる.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn閉じる.Location = New System.Drawing.Point(238, 52)
        Me.btn閉じる.Name = "btn閉じる"
        Me.btn閉じる.Size = New System.Drawing.Size(90, 23)
        Me.btn閉じる.TabIndex = 6
        Me.btn閉じる.Text = "閉じる"
        Me.btn閉じる.UseVisualStyleBackColor = True
        '
        'btn設定
        '
        Me.btn設定.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn設定.Location = New System.Drawing.Point(238, 21)
        Me.btn設定.Name = "btn設定"
        Me.btn設定.Size = New System.Drawing.Size(90, 23)
        Me.btn設定.TabIndex = 5
        Me.btn設定.Text = "設定"
        Me.btn設定.UseVisualStyleBackColor = True
        '
        'cmb_connect
        '
        Me.cmb_connect.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!)
        Me.cmb_connect.FormattingEnabled = True
        Me.cmb_connect.Location = New System.Drawing.Point(78, 23)
        Me.cmb_connect.Name = "cmb_connect"
        Me.cmb_connect.Size = New System.Drawing.Size(133, 20)
        Me.cmb_connect.TabIndex = 7
        '
        'a1800_通信設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 116)
        Me.Controls.Add(Me.cmb_connect)
        Me.Controls.Add(Me.btn閉じる)
        Me.Controls.Add(Me.btn設定)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a1800_通信設定"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "通信設定"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn閉じる As System.Windows.Forms.Button
    Friend WithEvents btn設定 As System.Windows.Forms.Button
    Friend WithEvents cmb_connect As System.Windows.Forms.ComboBox
End Class
