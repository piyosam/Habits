<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class c0200_売上入力
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(c0200_売上入力))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.数量 = New System.Windows.Forms.TextBox
        Me.金額 = New System.Windows.Forms.TextBox
        Me.txtサービス = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtサービス額 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.売上 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.売上担当変更 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.売上担当者 = New System.Windows.Forms.Label
        Me.名称 = New System.Windows.Forms.Label
        Me.分類 = New System.Windows.Forms.Label
        Me.lblStaff = New System.Windows.Forms.Label
        Me.lblGoods = New System.Windows.Forms.Label
        Me.lblDivision = New System.Windows.Forms.Label
        Me.売上担当者番号 = New System.Windows.Forms.TextBox
        Me.Cmbサービス名 = New System.Windows.Forms.ComboBox
        Me.小計金額 = New System.Windows.Forms.Label
        Me.合計金額 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "数量 :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "金額 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "小計 :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "サービス :"
        '
        '数量
        '
        Me.数量.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.数量.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
        Me.数量.ForeColor = System.Drawing.Color.Black
        Me.数量.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.数量.Location = New System.Drawing.Point(88, 15)
        Me.数量.MaxLength = 3
        Me.数量.Name = "数量"
        Me.数量.Size = New System.Drawing.Size(100, 23)
        Me.数量.TabIndex = 1
        Me.数量.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '金額
        '
        Me.金額.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.金額.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
        Me.金額.ForeColor = System.Drawing.Color.Black
        Me.金額.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.金額.Location = New System.Drawing.Point(88, 46)
        Me.金額.MaxLength = 9
        Me.金額.Name = "金額"
        Me.金額.Size = New System.Drawing.Size(100, 23)
        Me.金額.TabIndex = 2
        Me.金額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtサービス
        '
        Me.txtサービス.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtサービス.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtサービス.ForeColor = System.Drawing.Color.Black
        Me.txtサービス.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtサービス.Location = New System.Drawing.Point(88, 110)
        Me.txtサービス.MaxLength = 5
        Me.txtサービス.Name = "txtサービス"
        Me.txtサービス.Size = New System.Drawing.Size(79, 23)
        Me.txtサービス.TabIndex = 3
        Me.txtサービス.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(168, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "％"
        '
        'txtサービス額
        '
        Me.txtサービス額.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtサービス額.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtサービス額.ForeColor = System.Drawing.Color.Black
        Me.txtサービス額.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtサービス額.Location = New System.Drawing.Point(88, 139)
        Me.txtサービス額.MaxLength = 9
        Me.txtサービス額.Name = "txtサービス額"
        Me.txtサービス額.Size = New System.Drawing.Size(100, 23)
        Me.txtサービス額.TabIndex = 4
        Me.txtサービス額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "合計 :"
        '
        '売上
        '
        Me.売上.Location = New System.Drawing.Point(259, 15)
        Me.売上.Name = "売上"
        Me.売上.Size = New System.Drawing.Size(100, 23)
        Me.売上.TabIndex = 6
        Me.売上.Text = "売上・発行"
        Me.売上.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(259, 48)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 7
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        '売上担当変更
        '
        Me.売上担当変更.Location = New System.Drawing.Point(259, 100)
        Me.売上担当変更.Name = "売上担当変更"
        Me.売上担当変更.Size = New System.Drawing.Size(100, 23)
        Me.売上担当変更.TabIndex = 8
        Me.売上担当変更.Text = "担当者変更"
        Me.売上担当変更.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "登録情報"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.売上担当者)
        Me.GroupBox1.Controls.Add(Me.名称)
        Me.GroupBox1.Controls.Add(Me.分類)
        Me.GroupBox1.Controls.Add(Me.lblStaff)
        Me.GroupBox1.Controls.Add(Me.lblGoods)
        Me.GroupBox1.Controls.Add(Me.lblDivision)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 234)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(343, 127)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox"
        '
        '売上担当者
        '
        Me.売上担当者.AutoEllipsis = True
        Me.売上担当者.BackColor = System.Drawing.SystemColors.Window
        Me.売上担当者.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.売上担当者.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.売上担当者.Location = New System.Drawing.Point(72, 86)
        Me.売上担当者.Margin = New System.Windows.Forms.Padding(3)
        Me.売上担当者.Name = "売上担当者"
        Me.売上担当者.Size = New System.Drawing.Size(249, 23)
        Me.売上担当者.TabIndex = 19
        Me.売上担当者.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '名称
        '
        Me.名称.AutoEllipsis = True
        Me.名称.BackColor = System.Drawing.SystemColors.Window
        Me.名称.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.名称.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.名称.Location = New System.Drawing.Point(72, 57)
        Me.名称.Margin = New System.Windows.Forms.Padding(3)
        Me.名称.Name = "名称"
        Me.名称.Size = New System.Drawing.Size(249, 23)
        Me.名称.TabIndex = 18
        Me.名称.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '分類
        '
        Me.分類.AutoEllipsis = True
        Me.分類.BackColor = System.Drawing.SystemColors.Window
        Me.分類.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.分類.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.分類.Location = New System.Drawing.Point(72, 28)
        Me.分類.Margin = New System.Windows.Forms.Padding(3)
        Me.分類.Name = "分類"
        Me.分類.Size = New System.Drawing.Size(249, 23)
        Me.分類.TabIndex = 16
        Me.分類.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStaff
        '
        Me.lblStaff.AutoSize = True
        Me.lblStaff.Location = New System.Drawing.Point(12, 91)
        Me.lblStaff.Name = "lblStaff"
        Me.lblStaff.Size = New System.Drawing.Size(53, 13)
        Me.lblStaff.TabIndex = 22
        Me.lblStaff.Text = "担当者 :"
        '
        'lblGoods
        '
        Me.lblGoods.AutoSize = True
        Me.lblGoods.Location = New System.Drawing.Point(25, 62)
        Me.lblGoods.Name = "lblGoods"
        Me.lblGoods.Size = New System.Drawing.Size(40, 13)
        Me.lblGoods.TabIndex = 21
        Me.lblGoods.Text = "商品 :"
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(25, 33)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(40, 13)
        Me.lblDivision.TabIndex = 20
        Me.lblDivision.Text = "分類 :"
        '
        '売上担当者番号
        '
        Me.売上担当者番号.Location = New System.Drawing.Point(217, 198)
        Me.売上担当者番号.Name = "売上担当者番号"
        Me.売上担当者番号.Size = New System.Drawing.Size(71, 20)
        Me.売上担当者番号.TabIndex = 17
        Me.売上担当者番号.TabStop = False
        Me.売上担当者番号.Visible = False
        '
        'Cmbサービス名
        '
        Me.Cmbサービス名.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbサービス名.DropDownWidth = 450
        Me.Cmbサービス名.Enabled = False
        Me.Cmbサービス名.FormattingEnabled = True
        Me.Cmbサービス名.Location = New System.Drawing.Point(88, 168)
        Me.Cmbサービス名.Name = "Cmbサービス名"
        Me.Cmbサービス名.Size = New System.Drawing.Size(157, 21)
        Me.Cmbサービス名.TabIndex = 5
        '
        '小計金額
        '
        Me.小計金額.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.小計金額.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.小計金額.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
        Me.小計金額.Location = New System.Drawing.Point(88, 79)
        Me.小計金額.Margin = New System.Windows.Forms.Padding(3)
        Me.小計金額.Name = "小計金額"
        Me.小計金額.Size = New System.Drawing.Size(100, 23)
        Me.小計金額.TabIndex = 24
        Me.小計金額.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '合計金額
        '
        Me.合計金額.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.合計金額.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.合計金額.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
        Me.合計金額.Location = New System.Drawing.Point(88, 196)
        Me.合計金額.Margin = New System.Windows.Forms.Padding(3)
        Me.合計金額.Name = "合計金額"
        Me.合計金額.Size = New System.Drawing.Size(100, 23)
        Me.合計金額.TabIndex = 25
        Me.合計金額.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "（ｻｰﾋﾞｽ額） :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 171)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "（種類） :"
        '
        'c0200_売上入力
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 375)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.合計金額)
        Me.Controls.Add(Me.小計金額)
        Me.Controls.Add(Me.Cmbサービス名)
        Me.Controls.Add(Me.売上担当者番号)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.売上担当変更)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.売上)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtサービス額)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtサービス)
        Me.Controls.Add(Me.金額)
        Me.Controls.Add(Me.数量)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "c0200_売上入力"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 売上入力"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents 数量 As System.Windows.Forms.TextBox
    Friend WithEvents 金額 As System.Windows.Forms.TextBox
    Friend WithEvents txtサービス As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtサービス額 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents 売上 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents 売上担当変更 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents 売上担当者番号 As System.Windows.Forms.TextBox
    Friend WithEvents Cmbサービス名 As System.Windows.Forms.ComboBox
    Friend WithEvents lblDivision As System.Windows.Forms.Label
    Friend WithEvents lblStaff As System.Windows.Forms.Label
    Friend WithEvents lblGoods As System.Windows.Forms.Label
    Friend WithEvents 分類 As System.Windows.Forms.Label
    Friend WithEvents 売上担当者 As System.Windows.Forms.Label
    Friend WithEvents 名称 As System.Windows.Forms.Label
    Friend WithEvents 小計金額 As System.Windows.Forms.Label
    Friend WithEvents 合計金額 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
