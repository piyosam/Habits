<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a1000_ユーザー情報
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
        Dim Label16 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a1000_ユーザー情報))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtShopName = New System.Windows.Forms.TextBox
        Me.txtShopNameKana = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtOwner = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtPostCode = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.txtPhone = New System.Windows.Forms.TextBox
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.txtChairs = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtCash = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblShopCode = New System.Windows.Forms.Label
        Me.txtStartDay = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Label16 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label16
        '
        Label16.AutoSize = True
        Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Label16.Location = New System.Drawing.Point(29, 302)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(86, 13)
        Label16.TabIndex = 26
        Label16.Text = "月締・開始日 :"
        Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(76, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "名称 : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(54, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "名称カナ : "
        '
        'txtShopName
        '
        Me.txtShopName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtShopName.Location = New System.Drawing.Point(117, 38)
        Me.txtShopName.MaxLength = 25
        Me.txtShopName.Name = "txtShopName"
        Me.txtShopName.Size = New System.Drawing.Size(351, 20)
        Me.txtShopName.TabIndex = 1
        '
        'txtShopNameKana
        '
        Me.txtShopNameKana.ImeMode = System.Windows.Forms.ImeMode.Katakana
        Me.txtShopNameKana.Location = New System.Drawing.Point(117, 65)
        Me.txtShopNameKana.MaxLength = 25
        Me.txtShopNameKana.Name = "txtShopNameKana"
        Me.txtShopNameKana.Size = New System.Drawing.Size(351, 20)
        Me.txtShopNameKana.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(50, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "代表者名 : "
        '
        'txtOwner
        '
        Me.txtOwner.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtOwner.Location = New System.Drawing.Point(117, 91)
        Me.txtOwner.MaxLength = 25
        Me.txtOwner.Name = "txtOwner"
        Me.txtOwner.Size = New System.Drawing.Size(351, 20)
        Me.txtOwner.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(89, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "〒 : "
        '
        'txtPostCode
        '
        Me.txtPostCode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPostCode.Location = New System.Drawing.Point(117, 117)
        Me.txtPostCode.MaxLength = 7
        Me.txtPostCode.Name = "txtPostCode"
        Me.txtPostCode.Size = New System.Drawing.Size(103, 20)
        Me.txtPostCode.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(12, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "住所（番地まで） : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(63, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "建物名 : "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Location = New System.Drawing.Point(50, 198)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "電話番号 : "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Location = New System.Drawing.Point(53, 224)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "FAX番号 : "
        '
        'txtAddress
        '
        Me.txtAddress.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtAddress.Location = New System.Drawing.Point(117, 143)
        Me.txtAddress.MaxLength = 25
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(351, 20)
        Me.txtAddress.TabIndex = 5
        '
        'txtAddress2
        '
        Me.txtAddress2.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtAddress2.Location = New System.Drawing.Point(117, 169)
        Me.txtAddress2.MaxLength = 25
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(351, 20)
        Me.txtAddress2.TabIndex = 6
        '
        'txtPhone
        '
        Me.txtPhone.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPhone.Location = New System.Drawing.Point(117, 195)
        Me.txtPhone.MaxLength = 19
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(185, 20)
        Me.txtPhone.TabIndex = 7
        '
        'txtFax
        '
        Me.txtFax.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtFax.Location = New System.Drawing.Point(117, 221)
        Me.txtFax.MaxLength = 19
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(185, 20)
        Me.txtFax.TabIndex = 8
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(481, 13)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(100, 23)
        Me.btnSubmit.TabIndex = 20
        Me.btnSubmit.Text = "設定"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(481, 49)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 23)
        Me.btnClose.TabIndex = 21
        Me.btnClose.Text = "閉じる"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtChairs
        '
        Me.txtChairs.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtChairs.Location = New System.Drawing.Point(117, 247)
        Me.txtChairs.MaxLength = 4
        Me.txtChairs.Name = "txtChairs"
        Me.txtChairs.Size = New System.Drawing.Size(103, 20)
        Me.txtChairs.TabIndex = 9
        Me.txtChairs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label14.Location = New System.Drawing.Point(50, 250)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "設備台数 : "
        '
        'txtCash
        '
        Me.txtCash.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtCash.Location = New System.Drawing.Point(117, 273)
        Me.txtCash.MaxLength = 9
        Me.txtCash.Name = "txtCash"
        Me.txtCash.Size = New System.Drawing.Size(103, 20)
        Me.txtCash.TabIndex = 10
        Me.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Location = New System.Drawing.Point(53, 276)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "レジ金額 : "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.Location = New System.Drawing.Point(45, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "店舗コード :"
        '
        'lblShopCode
        '
        Me.lblShopCode.AutoSize = True
        Me.lblShopCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblShopCode.Location = New System.Drawing.Point(114, 16)
        Me.lblShopCode.Name = "lblShopCode"
        Me.lblShopCode.Size = New System.Drawing.Size(95, 13)
        Me.lblShopCode.TabIndex = 24
        Me.lblShopCode.Text = "                      "
        '
        'txtStartDay
        '
        Me.txtStartDay.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtStartDay.Location = New System.Drawing.Point(157, 299)
        Me.txtStartDay.MaxLength = 2
        Me.txtStartDay.Name = "txtStartDay"
        Me.txtStartDay.Size = New System.Drawing.Size(63, 20)
        Me.txtStartDay.TabIndex = 11
        Me.txtStartDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label17.Location = New System.Drawing.Point(114, 302)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(37, 13)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "毎月 "
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(226, 302)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 13)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "日 ～"
        '
        'a1000_ユーザー情報
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 347)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtStartDay)
        Me.Controls.Add(Label16)
        Me.Controls.Add(Me.lblShopCode)
        Me.Controls.Add(Me.txtCash)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtChairs)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.txtFax)
        Me.Controls.Add(Me.txtPhone)
        Me.Controls.Add(Me.txtAddress2)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPostCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtOwner)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtShopNameKana)
        Me.Controls.Add(Me.txtShopName)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a1000_ユーザー情報"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - ユーザー情報"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtShopName As System.Windows.Forms.TextBox
    Friend WithEvents txtShopNameKana As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOwner As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPostCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtChairs As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCash As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblShopCode As System.Windows.Forms.Label
    Friend WithEvents txtStartDay As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
