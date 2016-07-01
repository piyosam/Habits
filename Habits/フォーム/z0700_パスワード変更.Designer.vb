<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class z0700_パスワード変更
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(z0700_パスワード変更))
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnReg = New System.Windows.Forms.Button
        Me.txtPwd = New System.Windows.Forms.TextBox
        Me.txtPwd2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtPwdOld = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(19, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "新しいパスワード : "
        '
        'btnReg
        '
        Me.btnReg.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnReg.Location = New System.Drawing.Point(212, 53)
        Me.btnReg.Name = "btnReg"
        Me.btnReg.Size = New System.Drawing.Size(90, 26)
        Me.btnReg.TabIndex = 4
        Me.btnReg.Text = "変更"
        Me.btnReg.UseVisualStyleBackColor = True
        '
        'txtPwd
        '
        Me.txtPwd.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPwd.Location = New System.Drawing.Point(21, 112)
        Me.txtPwd.MaxLength = 128
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Size = New System.Drawing.Size(156, 19)
        Me.txtPwd.TabIndex = 2
        '
        'txtPwd2
        '
        Me.txtPwd2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPwd2.Location = New System.Drawing.Point(22, 153)
        Me.txtPwd2.MaxLength = 128
        Me.txtPwd2.Name = "txtPwd2"
        Me.txtPwd2.Size = New System.Drawing.Size(156, 19)
        Me.txtPwd2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(19, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "再入力 : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(18, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(231, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "管理者パスワードを入力してください。"
        '
        'TxtPwdOld
        '
        Me.TxtPwdOld.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TxtPwdOld.Location = New System.Drawing.Point(22, 58)
        Me.TxtPwdOld.MaxLength = 128
        Me.TxtPwdOld.Name = "TxtPwdOld"
        Me.TxtPwdOld.Size = New System.Drawing.Size(156, 19)
        Me.TxtPwdOld.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(20, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "現在のパスワード : "
        '
        'BtnCancel
        '
        Me.BtnCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.BtnCancel.Location = New System.Drawing.Point(212, 92)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(90, 26)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "キャンセル"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'z0700_パスワード変更
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 187)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.TxtPwdOld)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPwd2)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.btnReg)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "z0700_パスワード変更"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "管理者パスワード変更"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnReg As System.Windows.Forms.Button
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents txtPwd2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPwdOld As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
End Class
