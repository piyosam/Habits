<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f0500_商品
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(f0500_商品))
        Me.Label1 = New System.Windows.Forms.Label
        Me.分類 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt商品名 = New System.Windows.Forms.TextBox
        Me.txt表示順 = New System.Windows.Forms.TextBox
        Me.削除フラグ = New System.Windows.Forms.CheckBox
        Me.新規 = New System.Windows.Forms.Button
        Me.登録 = New System.Windows.Forms.Button
        Me.項目クリア = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.売上区分 = New System.Windows.Forms.ComboBox
        Me.dgv商品一覧 = New System.Windows.Forms.DataGridView
        Me.売上区分編集 = New System.Windows.Forms.Button
        Me.分類編集 = New System.Windows.Forms.Button
        Me.工程 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.既定在庫数 = New System.Windows.Forms.TextBox
        Me.txt標準時間 = New System.Windows.Forms.TextBox
        Me.txt発注点 = New System.Windows.Forms.TextBox
        Me.txt在庫数 = New System.Windows.Forms.TextBox
        Me.txt販売金額 = New System.Windows.Forms.TextBox
        Me.txt仕入金額 = New System.Windows.Forms.TextBox
        Me.txtメーカー名 = New System.Windows.Forms.ComboBox
        Me.lbl商品番号 = New System.Windows.Forms.Label
        Me.rbnWithoutTax = New System.Windows.Forms.RadioButton
        Me.rbnWithTax = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.dgv商品一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "分類名 : "
        '
        '分類
        '
        Me.分類.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.分類.DropDownWidth = 450
        Me.分類.FormattingEnabled = True
        Me.分類.Location = New System.Drawing.Point(90, 50)
        Me.分類.Name = "分類"
        Me.分類.Size = New System.Drawing.Size(335, 21)
        Me.分類.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(12, 360)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "商品番号 : "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(12, 386)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "商品名 : "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Location = New System.Drawing.Point(12, 412)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 20)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "表示順 : "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(12, 438)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 20)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "非表示 : "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt商品名
        '
        Me.txt商品名.BackColor = System.Drawing.Color.White
        Me.txt商品名.ForeColor = System.Drawing.Color.Black
        Me.txt商品名.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txt商品名.Location = New System.Drawing.Point(84, 386)
        Me.txt商品名.MaxLength = 32
        Me.txt商品名.Name = "txt商品名"
        Me.txt商品名.Size = New System.Drawing.Size(356, 20)
        Me.txt商品名.TabIndex = 7
        '
        'txt表示順
        '
        Me.txt表示順.BackColor = System.Drawing.Color.White
        Me.txt表示順.ForeColor = System.Drawing.Color.Black
        Me.txt表示順.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt表示順.Location = New System.Drawing.Point(84, 412)
        Me.txt表示順.MaxLength = 4
        Me.txt表示順.Name = "txt表示順"
        Me.txt表示順.Size = New System.Drawing.Size(54, 20)
        Me.txt表示順.TabIndex = 8
        Me.txt表示順.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '削除フラグ
        '
        Me.削除フラグ.AutoSize = True
        Me.削除フラグ.Location = New System.Drawing.Point(84, 441)
        Me.削除フラグ.Name = "削除フラグ"
        Me.削除フラグ.Size = New System.Drawing.Size(15, 14)
        Me.削除フラグ.TabIndex = 9
        Me.削除フラグ.UseVisualStyleBackColor = True
        '
        '新規
        '
        Me.新規.Location = New System.Drawing.Point(820, 359)
        Me.新規.Name = "新規"
        Me.新規.Size = New System.Drawing.Size(100, 23)
        Me.新規.TabIndex = 1
        Me.新規.Text = "新規"
        Me.新規.UseVisualStyleBackColor = True
        '
        '登録
        '
        Me.登録.Location = New System.Drawing.Point(820, 388)
        Me.登録.Name = "登録"
        Me.登録.Size = New System.Drawing.Size(100, 23)
        Me.登録.TabIndex = 19
        Me.登録.Text = "変更"
        Me.登録.UseVisualStyleBackColor = True
        '
        '項目クリア
        '
        Me.項目クリア.Location = New System.Drawing.Point(820, 429)
        Me.項目クリア.Name = "項目クリア"
        Me.項目クリア.Size = New System.Drawing.Size(100, 23)
        Me.項目クリア.TabIndex = 20
        Me.項目クリア.Text = "項目クリア"
        Me.項目クリア.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(820, 458)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 21
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "売上区分 : "
        '
        '売上区分
        '
        Me.売上区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.売上区分.FormattingEnabled = True
        Me.売上区分.Location = New System.Drawing.Point(90, 14)
        Me.売上区分.Name = "売上区分"
        Me.売上区分.Size = New System.Drawing.Size(335, 21)
        Me.売上区分.TabIndex = 2
        '
        'dgv商品一覧
        '
        Me.dgv商品一覧.AllowUserToAddRows = False
        Me.dgv商品一覧.AllowUserToDeleteRows = False
        Me.dgv商品一覧.AllowUserToResizeColumns = False
        Me.dgv商品一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv商品一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv商品一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv商品一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv商品一覧.EnableHeadersVisualStyles = False
        Me.dgv商品一覧.Location = New System.Drawing.Point(12, 86)
        Me.dgv商品一覧.MultiSelect = False
        Me.dgv商品一覧.Name = "dgv商品一覧"
        Me.dgv商品一覧.ReadOnly = True
        Me.dgv商品一覧.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv商品一覧.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv商品一覧.RowTemplate.Height = 16
        Me.dgv商品一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv商品一覧.Size = New System.Drawing.Size(906, 260)
        Me.dgv商品一覧.TabIndex = 5
        Me.dgv商品一覧.TabStop = False
        '
        '売上区分編集
        '
        Me.売上区分編集.Location = New System.Drawing.Point(434, 12)
        Me.売上区分編集.Name = "売上区分編集"
        Me.売上区分編集.Size = New System.Drawing.Size(154, 23)
        Me.売上区分編集.TabIndex = 3
        Me.売上区分編集.Text = "売上区分の追加・編集"
        Me.売上区分編集.UseVisualStyleBackColor = True
        '
        '分類編集
        '
        Me.分類編集.Location = New System.Drawing.Point(434, 48)
        Me.分類編集.Name = "分類編集"
        Me.分類編集.Size = New System.Drawing.Size(154, 23)
        Me.分類編集.TabIndex = 5
        Me.分類編集.Text = "分類の追加・編集"
        Me.分類編集.UseVisualStyleBackColor = True
        '
        '工程
        '
        Me.工程.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.工程.Location = New System.Drawing.Point(644, 490)
        Me.工程.Name = "工程"
        Me.工程.Size = New System.Drawing.Size(80, 23)
        Me.工程.TabIndex = 16
        Me.工程.Text = "工程"
        Me.工程.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(606, 364)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 13)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "分"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label15.Location = New System.Drawing.Point(446, 519)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(83, 13)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "既定在庫数 : "
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label14.Location = New System.Drawing.Point(446, 363)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 13)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "標準時間 : "
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(446, 494)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "発注点 : "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Location = New System.Drawing.Point(446, 467)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "在庫数 : "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(446, 442)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "販売金額 : "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Location = New System.Drawing.Point(446, 415)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "仕入金額 : "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(446, 390)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "メーカー名 : "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '既定在庫数
        '
        Me.既定在庫数.BackColor = System.Drawing.Color.White
        Me.既定在庫数.ForeColor = System.Drawing.Color.Black
        Me.既定在庫数.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.既定在庫数.Location = New System.Drawing.Point(531, 516)
        Me.既定在庫数.MaxLength = 9
        Me.既定在庫数.Name = "既定在庫数"
        Me.既定在庫数.Size = New System.Drawing.Size(109, 20)
        Me.既定在庫数.TabIndex = 17
        Me.既定在庫数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt標準時間
        '
        Me.txt標準時間.BackColor = System.Drawing.Color.White
        Me.txt標準時間.ForeColor = System.Drawing.Color.Black
        Me.txt標準時間.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt標準時間.Location = New System.Drawing.Point(531, 360)
        Me.txt標準時間.MaxLength = 4
        Me.txt標準時間.Name = "txt標準時間"
        Me.txt標準時間.Size = New System.Drawing.Size(73, 20)
        Me.txt標準時間.TabIndex = 10
        Me.txt標準時間.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt発注点
        '
        Me.txt発注点.BackColor = System.Drawing.Color.White
        Me.txt発注点.ForeColor = System.Drawing.Color.Black
        Me.txt発注点.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt発注点.Location = New System.Drawing.Point(531, 490)
        Me.txt発注点.MaxLength = 9
        Me.txt発注点.Name = "txt発注点"
        Me.txt発注点.Size = New System.Drawing.Size(107, 20)
        Me.txt発注点.TabIndex = 15
        Me.txt発注点.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt在庫数
        '
        Me.txt在庫数.BackColor = System.Drawing.Color.White
        Me.txt在庫数.ForeColor = System.Drawing.Color.Black
        Me.txt在庫数.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt在庫数.Location = New System.Drawing.Point(531, 464)
        Me.txt在庫数.MaxLength = 9
        Me.txt在庫数.Name = "txt在庫数"
        Me.txt在庫数.Size = New System.Drawing.Size(107, 20)
        Me.txt在庫数.TabIndex = 14
        Me.txt在庫数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt販売金額
        '
        Me.txt販売金額.BackColor = System.Drawing.Color.White
        Me.txt販売金額.ForeColor = System.Drawing.Color.Black
        Me.txt販売金額.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt販売金額.Location = New System.Drawing.Point(531, 438)
        Me.txt販売金額.MaxLength = 9
        Me.txt販売金額.Name = "txt販売金額"
        Me.txt販売金額.Size = New System.Drawing.Size(107, 20)
        Me.txt販売金額.TabIndex = 13
        Me.txt販売金額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt仕入金額
        '
        Me.txt仕入金額.BackColor = System.Drawing.Color.White
        Me.txt仕入金額.ForeColor = System.Drawing.Color.Black
        Me.txt仕入金額.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt仕入金額.Location = New System.Drawing.Point(531, 412)
        Me.txt仕入金額.MaxLength = 9
        Me.txt仕入金額.Name = "txt仕入金額"
        Me.txt仕入金額.Size = New System.Drawing.Size(107, 20)
        Me.txt仕入金額.TabIndex = 12
        Me.txt仕入金額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtメーカー名
        '
        Me.txtメーカー名.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtメーカー名.DropDownWidth = 450
        Me.txtメーカー名.FormattingEnabled = True
        Me.txtメーカー名.Location = New System.Drawing.Point(531, 386)
        Me.txtメーカー名.Name = "txtメーカー名"
        Me.txtメーカー名.Size = New System.Drawing.Size(250, 21)
        Me.txtメーカー名.TabIndex = 11
        '
        'lbl商品番号
        '
        Me.lbl商品番号.BackColor = System.Drawing.Color.White
        Me.lbl商品番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl商品番号.Location = New System.Drawing.Point(84, 360)
        Me.lbl商品番号.Name = "lbl商品番号"
        Me.lbl商品番号.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl商品番号.Size = New System.Drawing.Size(54, 20)
        Me.lbl商品番号.TabIndex = 6
        Me.lbl商品番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbnWithoutTax
        '
        Me.rbnWithoutTax.AutoSize = True
        Me.rbnWithoutTax.Location = New System.Drawing.Point(19, 16)
        Me.rbnWithoutTax.Name = "rbnWithoutTax"
        Me.rbnWithoutTax.Size = New System.Drawing.Size(77, 17)
        Me.rbnWithoutTax.TabIndex = 0
        Me.rbnWithoutTax.TabStop = True
        Me.rbnWithoutTax.Text = "本体価格"
        Me.rbnWithoutTax.UseVisualStyleBackColor = True
        '
        'rbnWithTax
        '
        Me.rbnWithTax.AutoSize = True
        Me.rbnWithTax.Location = New System.Drawing.Point(19, 36)
        Me.rbnWithTax.Name = "rbnWithTax"
        Me.rbnWithTax.Size = New System.Drawing.Size(77, 17)
        Me.rbnWithTax.TabIndex = 1
        Me.rbnWithTax.TabStop = True
        Me.rbnWithTax.Text = "税込価格"
        Me.rbnWithTax.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbnWithoutTax)
        Me.GroupBox1.Controls.Add(Me.rbnWithTax)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 474)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(173, 62)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "金額管理方法"
        '
        'f0500_商品
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 565)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl商品番号)
        Me.Controls.Add(Me.txt商品名)
        Me.Controls.Add(Me.工程)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.既定在庫数)
        Me.Controls.Add(Me.txt標準時間)
        Me.Controls.Add(Me.txt発注点)
        Me.Controls.Add(Me.txt在庫数)
        Me.Controls.Add(Me.txt販売金額)
        Me.Controls.Add(Me.txt仕入金額)
        Me.Controls.Add(Me.txtメーカー名)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.分類編集)
        Me.Controls.Add(Me.売上区分編集)
        Me.Controls.Add(Me.dgv商品一覧)
        Me.Controls.Add(Me.売上区分)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.項目クリア)
        Me.Controls.Add(Me.登録)
        Me.Controls.Add(Me.新規)
        Me.Controls.Add(Me.削除フラグ)
        Me.Controls.Add(Me.txt表示順)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.分類)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "f0500_商品"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 商品登録"
        CType(Me.dgv商品一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 分類 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt表示順 As System.Windows.Forms.TextBox
    Friend WithEvents 削除フラグ As System.Windows.Forms.CheckBox
    Friend WithEvents 新規 As System.Windows.Forms.Button
    Friend WithEvents 登録 As System.Windows.Forms.Button
    Friend WithEvents 項目クリア As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents 売上区分 As System.Windows.Forms.ComboBox
    Friend WithEvents dgv商品一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents 売上区分編集 As System.Windows.Forms.Button
    Friend WithEvents 分類編集 As System.Windows.Forms.Button
    Friend WithEvents 工程 As System.Windows.Forms.Button
    Friend WithEvents txt商品名 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents 既定在庫数 As System.Windows.Forms.TextBox
    Friend WithEvents txt標準時間 As System.Windows.Forms.TextBox
    Friend WithEvents txt発注点 As System.Windows.Forms.TextBox
    Friend WithEvents txt在庫数 As System.Windows.Forms.TextBox
    Friend WithEvents txt販売金額 As System.Windows.Forms.TextBox
    Friend WithEvents txt仕入金額 As System.Windows.Forms.TextBox
    Friend WithEvents txtメーカー名 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl商品番号 As System.Windows.Forms.Label
    Friend WithEvents rbnWithTax As System.Windows.Forms.RadioButton
    Friend WithEvents rbnWithoutTax As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
