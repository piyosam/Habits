<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a0600_営業日
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a0600_営業日))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmb天候 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtレジ金額 = New System.Windows.Forms.TextBox
        Me.btn登録 = New System.Windows.Forms.Button
        Me.担当者選択 = New System.Windows.Forms.Button
        Me.lbl営業日 = New System.Windows.Forms.Label
        Me.lblスタッフ数 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "営業日 :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(46, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "天候 :"
        '
        'cmb天候
        '
        Me.cmb天候.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb天候.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb天候.FormattingEnabled = True
        Me.cmb天候.Location = New System.Drawing.Point(92, 41)
        Me.cmb天候.Name = "cmb天候"
        Me.cmb天候.Size = New System.Drawing.Size(102, 21)
        Me.cmb天候.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "スタッフ数 :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "レジ金額 :"
        '
        'txtレジ金額
        '
        Me.txtレジ金額.BackColor = System.Drawing.Color.White
        Me.txtレジ金額.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtレジ金額.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtレジ金額.Location = New System.Drawing.Point(92, 94)
        Me.txtレジ金額.MaxLength = 9
        Me.txtレジ金額.Name = "txtレジ金額"
        Me.txtレジ金額.Size = New System.Drawing.Size(100, 20)
        Me.txtレジ金額.TabIndex = 4
        Me.txtレジ金額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn登録
        '
        Me.btn登録.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn登録.Location = New System.Drawing.Point(200, 125)
        Me.btn登録.Name = "btn登録"
        Me.btn登録.Size = New System.Drawing.Size(100, 26)
        Me.btn登録.TabIndex = 5
        Me.btn登録.Text = "登録"
        Me.btn登録.UseVisualStyleBackColor = True
        '
        '担当者選択
        '
        Me.担当者選択.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.担当者選択.Location = New System.Drawing.Point(200, 67)
        Me.担当者選択.Name = "担当者選択"
        Me.担当者選択.Size = New System.Drawing.Size(100, 23)
        Me.担当者選択.TabIndex = 3
        Me.担当者選択.Text = "スタッフ選択"
        Me.担当者選択.UseVisualStyleBackColor = True
        '
        'lbl営業日
        '
        Me.lbl営業日.AutoSize = True
        Me.lbl営業日.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.lbl営業日.Location = New System.Drawing.Point(95, 18)
        Me.lbl営業日.Name = "lbl営業日"
        Me.lbl営業日.Size = New System.Drawing.Size(54, 13)
        Me.lbl営業日.TabIndex = 8
        Me.lbl営業日.Text = "(実行日)"
        '
        'lblスタッフ数
        '
        Me.lblスタッフ数.BackColor = System.Drawing.Color.White
        Me.lblスタッフ数.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblスタッフ数.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.lblスタッフ数.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblスタッフ数.Location = New System.Drawing.Point(92, 68)
        Me.lblスタッフ数.Name = "lblスタッフ数"
        Me.lblスタッフ数.Padding = New System.Windows.Forms.Padding(0, 3, 5, 2)
        Me.lblスタッフ数.Size = New System.Drawing.Size(100, 20)
        Me.lblスタッフ数.TabIndex = 2
        Me.lblスタッフ数.Text = "(出勤ｽﾀｯﾌ数)"
        Me.lblスタッフ数.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'a0600_営業日
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 166)
        Me.Controls.Add(Me.lblスタッフ数)
        Me.Controls.Add(Me.lbl営業日)
        Me.Controls.Add(Me.担当者選択)
        Me.Controls.Add(Me.btn登録)
        Me.Controls.Add(Me.txtレジ金額)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmb天候)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a0600_営業日"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 営業日"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmb天候 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtレジ金額 As System.Windows.Forms.TextBox
    Friend WithEvents btn登録 As System.Windows.Forms.Button
    Friend WithEvents 担当者選択 As System.Windows.Forms.Button
    Friend WithEvents lbl営業日 As System.Windows.Forms.Label
    Friend WithEvents lblスタッフ数 As System.Windows.Forms.Label
End Class
