<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a2000_モード変更
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a2000_モード変更))
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn閉じる = New System.Windows.Forms.Button
        Me.btn管理者モード = New System.Windows.Forms.Button
        Me.txtPwd = New System.Windows.Forms.TextBox
        Me.txtDefaultMode = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(19, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "パスワード : "
        '
        'btn閉じる
        '
        Me.btn閉じる.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn閉じる.Location = New System.Drawing.Point(199, 103)
        Me.btn閉じる.Name = "btn閉じる"
        Me.btn閉じる.Size = New System.Drawing.Size(90, 23)
        Me.btn閉じる.TabIndex = 4
        Me.btn閉じる.Text = "閉じる"
        Me.btn閉じる.UseVisualStyleBackColor = True
        '
        'btn管理者モード
        '
        Me.btn管理者モード.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn管理者モード.Location = New System.Drawing.Point(199, 13)
        Me.btn管理者モード.Name = "btn管理者モード"
        Me.btn管理者モード.Size = New System.Drawing.Size(90, 45)
        Me.btn管理者モード.TabIndex = 2
        Me.btn管理者モード.Text = "管理者モードへ設定"
        Me.btn管理者モード.UseVisualStyleBackColor = True
        '
        'txtPwd
        '
        Me.txtPwd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPwd.Location = New System.Drawing.Point(21, 49)
        Me.txtPwd.MaxLength = 128
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(156, 19)
        Me.txtPwd.TabIndex = 1
        '
        'txtDefaultMode
        '
        Me.txtDefaultMode.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtDefaultMode.Location = New System.Drawing.Point(199, 74)
        Me.txtDefaultMode.Name = "txtDefaultMode"
        Me.txtDefaultMode.Size = New System.Drawing.Size(90, 23)
        Me.txtDefaultMode.TabIndex = 3
        Me.txtDefaultMode.Text = "モード解除"
        Me.txtDefaultMode.UseVisualStyleBackColor = True
        '
        'a2000_モード変更
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 144)
        Me.Controls.Add(Me.txtDefaultMode)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.btn閉じる)
        Me.Controls.Add(Me.btn管理者モード)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a2000_モード変更"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "モード変更"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn閉じる As System.Windows.Forms.Button
    Friend WithEvents btn管理者モード As System.Windows.Forms.Button
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents txtDefaultMode As System.Windows.Forms.Button
End Class
