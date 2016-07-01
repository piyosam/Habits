<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class c0100_売上
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(c0100_売上))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.性別番号 = New System.Windows.Forms.ComboBox
        Me.主担当者 = New System.Windows.Forms.ComboBox
        Me.来店区分 = New System.Windows.Forms.ComboBox
        Me.指名 = New System.Windows.Forms.CheckBox
        Me.btn会計 = New System.Windows.Forms.Button
        Me.btn仮登録 = New System.Windows.Forms.Button
        Me.btnメモ = New System.Windows.Forms.Button
        Me.btn閉じる = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn削除 = New System.Windows.Forms.Button
        Me.dgv売上一覧 = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.メーカー = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.dgv分類一覧 = New System.Windows.Forms.DataGridView
        Me.dgv商品一覧 = New System.Windows.Forms.DataGridView
        Me.Label9 = New System.Windows.Forms.Label
        Me.氏名 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.dgv売上区分 = New System.Windows.Forms.DataGridView
        Me.cmbポイント割引 = New System.Windows.Forms.ComboBox
        Me.txtポイント割引額 = New System.Windows.Forms.TextBox
        Me.lblPointPurchases2 = New System.Windows.Forms.Label
        Me.btnSlip = New System.Windows.Forms.Button
        Me.txtサービス = New System.Windows.Forms.TextBox
        Me.cmbサービス = New System.Windows.Forms.ComboBox
        Me.lblTotal = New System.Windows.Forms.Label
        Me.合計金額 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtサービス率 = New System.Windows.Forms.TextBox
        Me.消費税 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbnServiceAmount = New System.Windows.Forms.RadioButton
        Me.rbnServiceRate = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        CType(Me.dgv売上一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv分類一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv商品一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv売上区分, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(14, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "氏 　名 :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(14, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "性　 別 :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(14, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "主担当 :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(14, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "来店区分 :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '性別番号
        '
        Me.性別番号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.性別番号.FormattingEnabled = True
        Me.性別番号.Location = New System.Drawing.Point(86, 42)
        Me.性別番号.Name = "性別番号"
        Me.性別番号.Size = New System.Drawing.Size(82, 21)
        Me.性別番号.TabIndex = 3
        '
        '主担当者
        '
        Me.主担当者.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.主担当者.DropDownWidth = 450
        Me.主担当者.FormattingEnabled = True
        Me.主担当者.Location = New System.Drawing.Point(86, 69)
        Me.主担当者.Name = "主担当者"
        Me.主担当者.Size = New System.Drawing.Size(183, 21)
        Me.主担当者.TabIndex = 5
        '
        '来店区分
        '
        Me.来店区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.来店区分.FormattingEnabled = True
        Me.来店区分.Location = New System.Drawing.Point(86, 96)
        Me.来店区分.Name = "来店区分"
        Me.来店区分.Size = New System.Drawing.Size(82, 21)
        Me.来店区分.TabIndex = 7
        '
        '指名
        '
        Me.指名.AutoSize = True
        Me.指名.Location = New System.Drawing.Point(182, 98)
        Me.指名.Name = "指名"
        Me.指名.Size = New System.Drawing.Size(52, 17)
        Me.指名.TabIndex = 8
        Me.指名.Text = "指名"
        Me.指名.UseVisualStyleBackColor = True
        '
        'btn会計
        '
        Me.btn会計.Location = New System.Drawing.Point(703, 215)
        Me.btn会計.Name = "btn会計"
        Me.btn会計.Size = New System.Drawing.Size(90, 36)
        Me.btn会計.TabIndex = 31
        Me.btn会計.Text = "会計"
        Me.btn会計.UseVisualStyleBackColor = True
        '
        'btn仮登録
        '
        Me.btn仮登録.Location = New System.Drawing.Point(703, 266)
        Me.btn仮登録.Name = "btn仮登録"
        Me.btn仮登録.Size = New System.Drawing.Size(90, 36)
        Me.btn仮登録.TabIndex = 32
        Me.btn仮登録.Text = "仮登録"
        Me.btn仮登録.UseVisualStyleBackColor = True
        '
        'btnメモ
        '
        Me.btnメモ.Location = New System.Drawing.Point(703, 318)
        Me.btnメモ.Name = "btnメモ"
        Me.btnメモ.Size = New System.Drawing.Size(90, 23)
        Me.btnメモ.TabIndex = 33
        Me.btnメモ.Text = "メモ設定"
        Me.btnメモ.UseVisualStyleBackColor = True
        '
        'btn閉じる
        '
        Me.btn閉じる.Location = New System.Drawing.Point(703, 359)
        Me.btn閉じる.Name = "btn閉じる"
        Me.btn閉じる.Size = New System.Drawing.Size(90, 23)
        Me.btn閉じる.TabIndex = 34
        Me.btn閉じる.Text = "閉じる"
        Me.btn閉じる.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 383)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "売上・発行一覧 : "
        '
        'btn削除
        '
        Me.btn削除.Location = New System.Drawing.Point(703, 587)
        Me.btn削除.Name = "btn削除"
        Me.btn削除.Size = New System.Drawing.Size(90, 23)
        Me.btn削除.TabIndex = 36
        Me.btn削除.Text = "売上削除"
        Me.btn削除.UseVisualStyleBackColor = True
        '
        'dgv売上一覧
        '
        Me.dgv売上一覧.AllowUserToAddRows = False
        Me.dgv売上一覧.AllowUserToDeleteRows = False
        Me.dgv売上一覧.AllowUserToResizeColumns = False
        Me.dgv売上一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv売上一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv売上一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv売上一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv売上一覧.ColumnHeadersVisible = False
        Me.dgv売上一覧.Location = New System.Drawing.Point(17, 416)
        Me.dgv売上一覧.MultiSelect = False
        Me.dgv売上一覧.Name = "dgv売上一覧"
        Me.dgv売上一覧.ReadOnly = True
        Me.dgv売上一覧.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv売上一覧.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv売上一覧.RowTemplate.Height = 16
        Me.dgv売上一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv売上一覧.Size = New System.Drawing.Size(776, 163)
        Me.dgv売上一覧.TabIndex = 30
        Me.dgv売上一覧.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "売上区分 :"
        '
        'メーカー
        '
        Me.メーカー.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.メーカー.DropDownWidth = 450
        Me.メーカー.Enabled = False
        Me.メーカー.FormattingEnabled = True
        Me.メーカー.Location = New System.Drawing.Point(330, 171)
        Me.メーカー.Name = "メーカー"
        Me.メーカー.Size = New System.Drawing.Size(300, 21)
        Me.メーカー.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(329, 154)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "メーカー :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 199)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "分類一覧 : "
        '
        'dgv分類一覧
        '
        Me.dgv分類一覧.AllowUserToAddRows = False
        Me.dgv分類一覧.AllowUserToDeleteRows = False
        Me.dgv分類一覧.AllowUserToResizeColumns = False
        Me.dgv分類一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv分類一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv分類一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv分類一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv分類一覧.ColumnHeadersVisible = False
        Me.dgv分類一覧.Location = New System.Drawing.Point(17, 215)
        Me.dgv分類一覧.MultiSelect = False
        Me.dgv分類一覧.Name = "dgv分類一覧"
        Me.dgv分類一覧.ReadOnly = True
        Me.dgv分類一覧.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv分類一覧.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv分類一覧.RowTemplate.Height = 16
        Me.dgv分類一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv分類一覧.Size = New System.Drawing.Size(300, 162)
        Me.dgv分類一覧.TabIndex = 19
        Me.dgv分類一覧.TabStop = False
        '
        'dgv商品一覧
        '
        Me.dgv商品一覧.AllowUserToAddRows = False
        Me.dgv商品一覧.AllowUserToDeleteRows = False
        Me.dgv商品一覧.AllowUserToResizeColumns = False
        Me.dgv商品一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv商品一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv商品一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv商品一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv商品一覧.ColumnHeadersVisible = False
        Me.dgv商品一覧.Location = New System.Drawing.Point(330, 215)
        Me.dgv商品一覧.MultiSelect = False
        Me.dgv商品一覧.Name = "dgv商品一覧"
        Me.dgv商品一覧.ReadOnly = True
        Me.dgv商品一覧.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv商品一覧.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv商品一覧.RowTemplate.Height = 16
        Me.dgv商品一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv商品一覧.Size = New System.Drawing.Size(300, 162)
        Me.dgv商品一覧.TabIndex = 21
        Me.dgv商品一覧.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(327, 199)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "商品一覧 : "
        '
        '氏名
        '
        Me.氏名.AutoSize = True
        Me.氏名.Location = New System.Drawing.Point(86, 15)
        Me.氏名.Name = "氏名"
        Me.氏名.Padding = New System.Windows.Forms.Padding(2, 3, 5, 2)
        Me.氏名.Size = New System.Drawing.Size(54, 18)
        Me.氏名.TabIndex = 1
        Me.氏名.Text = "（氏名）"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(19, 403)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "分類"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(210, 403)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 12)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "商品"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(410, 403)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 12)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "数量"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label13.Location = New System.Drawing.Point(447, 403)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 12)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "金額"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(526, 403)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 12)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "ｻｰﾋﾞｽ額"
        '
        'dgv売上区分
        '
        Me.dgv売上区分.AllowUserToAddRows = False
        Me.dgv売上区分.AllowUserToDeleteRows = False
        Me.dgv売上区分.AllowUserToResizeColumns = False
        Me.dgv売上区分.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv売上区分.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv売上区分.BackgroundColor = System.Drawing.Color.White
        Me.dgv売上区分.CausesValidation = False
        Me.dgv売上区分.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv売上区分.ColumnHeadersVisible = False
        Me.dgv売上区分.Location = New System.Drawing.Point(17, 143)
        Me.dgv売上区分.MultiSelect = False
        Me.dgv売上区分.Name = "dgv売上区分"
        Me.dgv売上区分.ReadOnly = True
        Me.dgv売上区分.RowHeadersVisible = False
        DataGridViewCellStyle8.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv売上区分.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgv売上区分.RowTemplate.Height = 16
        Me.dgv売上区分.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv売上区分.Size = New System.Drawing.Size(300, 51)
        Me.dgv売上区分.TabIndex = 15
        Me.dgv売上区分.TabStop = False
        '
        'cmbポイント割引
        '
        Me.cmbポイント割引.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbポイント割引.DropDownWidth = 450
        Me.cmbポイント割引.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.cmbポイント割引.FormattingEnabled = True
        Me.cmbポイント割引.Location = New System.Drawing.Point(13, 15)
        Me.cmbポイント割引.Name = "cmbポイント割引"
        Me.cmbポイント割引.Size = New System.Drawing.Size(171, 21)
        Me.cmbポイント割引.TabIndex = 0
        '
        'txtポイント割引額
        '
        Me.txtポイント割引額.BackColor = System.Drawing.Color.White
        Me.txtポイント割引額.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.txtポイント割引額.ForeColor = System.Drawing.Color.Black
        Me.txtポイント割引額.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtポイント割引額.Location = New System.Drawing.Point(275, 15)
        Me.txtポイント割引額.MaxLength = 9
        Me.txtポイント割引額.Name = "txtポイント割引額"
        Me.txtポイント割引額.Size = New System.Drawing.Size(100, 20)
        Me.txtポイント割引額.TabIndex = 2
        Me.txtポイント割引額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPointPurchases2
        '
        Me.lblPointPurchases2.AutoSize = True
        Me.lblPointPurchases2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.lblPointPurchases2.Location = New System.Drawing.Point(229, 18)
        Me.lblPointPurchases2.Name = "lblPointPurchases2"
        Me.lblPointPurchases2.Size = New System.Drawing.Size(40, 13)
        Me.lblPointPurchases2.TabIndex = 1
        Me.lblPointPurchases2.Text = "金額 :"
        Me.lblPointPurchases2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSlip
        '
        Me.btnSlip.Location = New System.Drawing.Point(703, 169)
        Me.btnSlip.Name = "btnSlip"
        Me.btnSlip.Size = New System.Drawing.Size(90, 23)
        Me.btnSlip.TabIndex = 35
        Me.btnSlip.Text = "伝票"
        Me.btnSlip.UseVisualStyleBackColor = True
        '
        'txtサービス
        '
        Me.txtサービス.BackColor = System.Drawing.Color.White
        Me.txtサービス.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.txtサービス.ForeColor = System.Drawing.Color.Black
        Me.txtサービス.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtサービス.Location = New System.Drawing.Point(275, 35)
        Me.txtサービス.MaxLength = 9
        Me.txtサービス.Name = "txtサービス"
        Me.txtサービス.Size = New System.Drawing.Size(100, 20)
        Me.txtサービス.TabIndex = 5
        Me.txtサービス.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbサービス
        '
        Me.cmbサービス.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbサービス.DropDownWidth = 450
        Me.cmbサービス.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.cmbサービス.FormattingEnabled = True
        Me.cmbサービス.Location = New System.Drawing.Point(13, 18)
        Me.cmbサービス.Name = "cmbサービス"
        Me.cmbサービス.Size = New System.Drawing.Size(171, 21)
        Me.cmbサービス.TabIndex = 0
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.Location = New System.Drawing.Point(544, 130)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(44, 13)
        Me.lblTotal.TabIndex = 12
        Me.lblTotal.Text = "合計 :"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '合計金額
        '
        Me.合計金額.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.合計金額.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.合計金額.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.合計金額.Location = New System.Drawing.Point(594, 126)
        Me.合計金額.Margin = New System.Windows.Forms.Padding(3)
        Me.合計金額.Name = "合計金額"
        Me.合計金額.Size = New System.Drawing.Size(100, 20)
        Me.合計金額.TabIndex = 13
        Me.合計金額.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(684, 403)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 12)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "担当者"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(607, 403)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(29, 12)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "小計"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.Label15.Location = New System.Drawing.Point(323, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(20, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "％"
        '
        'txtサービス率
        '
        Me.txtサービス率.BackColor = System.Drawing.Color.White
        Me.txtサービス率.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.txtサービス率.ForeColor = System.Drawing.Color.Black
        Me.txtサービス率.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtサービス率.Location = New System.Drawing.Point(275, 12)
        Me.txtサービス率.MaxLength = 5
        Me.txtサービス率.Name = "txtサービス率"
        Me.txtサービス率.Size = New System.Drawing.Size(46, 20)
        Me.txtサービス率.TabIndex = 2
        Me.txtサービス率.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '消費税
        '
        Me.消費税.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.消費税.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.消費税.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.消費税.Location = New System.Drawing.Point(388, 126)
        Me.消費税.Margin = New System.Windows.Forms.Padding(3)
        Me.消費税.Name = "消費税"
        Me.消費税.Size = New System.Drawing.Size(100, 20)
        Me.消費税.TabIndex = 11
        Me.消費税.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.消費税.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbnServiceAmount)
        Me.GroupBox1.Controls.Add(Me.rbnServiceRate)
        Me.GroupBox1.Controls.Add(Me.cmbサービス)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtサービス率)
        Me.GroupBox1.Controls.Add(Me.txtサービス)
        Me.GroupBox1.Location = New System.Drawing.Point(319, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(395, 63)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "サービス"
        '
        'rbnServiceAmount
        '
        Me.rbnServiceAmount.AutoSize = True
        Me.rbnServiceAmount.Location = New System.Drawing.Point(214, 37)
        Me.rbnServiceAmount.Name = "rbnServiceAmount"
        Me.rbnServiceAmount.Size = New System.Drawing.Size(58, 17)
        Me.rbnServiceAmount.TabIndex = 4
        Me.rbnServiceAmount.TabStop = True
        Me.rbnServiceAmount.Text = "金額 :"
        Me.rbnServiceAmount.UseVisualStyleBackColor = True
        '
        'rbnServiceRate
        '
        Me.rbnServiceRate.AutoSize = True
        Me.rbnServiceRate.Location = New System.Drawing.Point(214, 14)
        Me.rbnServiceRate.Name = "rbnServiceRate"
        Me.rbnServiceRate.Size = New System.Drawing.Size(58, 17)
        Me.rbnServiceRate.TabIndex = 1
        Me.rbnServiceRate.TabStop = True
        Me.rbnServiceRate.Text = "割合 :"
        Me.rbnServiceRate.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbポイント割引)
        Me.GroupBox2.Controls.Add(Me.txtポイント割引額)
        Me.GroupBox2.Controls.Add(Me.lblPointPurchases2)
        Me.GroupBox2.Location = New System.Drawing.Point(319, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(395, 42)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "ポイント割引等（掛支払）"
        '
        'c0100_売上
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(805, 624)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.消費税)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.合計金額)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.btnSlip)
        Me.Controls.Add(Me.dgv売上区分)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.氏名)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgv商品一覧)
        Me.Controls.Add(Me.dgv分類一覧)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.メーカー)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgv売上一覧)
        Me.Controls.Add(Me.btn削除)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn閉じる)
        Me.Controls.Add(Me.btnメモ)
        Me.Controls.Add(Me.btn仮登録)
        Me.Controls.Add(Me.btn会計)
        Me.Controls.Add(Me.指名)
        Me.Controls.Add(Me.来店区分)
        Me.Controls.Add(Me.主担当者)
        Me.Controls.Add(Me.性別番号)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "c0100_売上"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 売上"
        CType(Me.dgv売上一覧, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv分類一覧, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv商品一覧, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv売上区分, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents 性別番号 As System.Windows.Forms.ComboBox
    Friend WithEvents 主担当者 As System.Windows.Forms.ComboBox
    Friend WithEvents 来店区分 As System.Windows.Forms.ComboBox
    Friend WithEvents 指名 As System.Windows.Forms.CheckBox
    Friend WithEvents btn会計 As System.Windows.Forms.Button
    Friend WithEvents btn仮登録 As System.Windows.Forms.Button
    Friend WithEvents btnメモ As System.Windows.Forms.Button
    Friend WithEvents btn閉じる As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn削除 As System.Windows.Forms.Button
    Public WithEvents dgv売上一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents メーカー As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents dgv商品一覧 As System.Windows.Forms.DataGridView
    Public WithEvents dgv分類一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents 氏名 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents dgv売上区分 As System.Windows.Forms.DataGridView
    Friend WithEvents cmbポイント割引 As System.Windows.Forms.ComboBox
    Friend WithEvents txtポイント割引額 As System.Windows.Forms.TextBox
    Friend WithEvents lblPointPurchases2 As System.Windows.Forms.Label
    Friend WithEvents btnSlip As System.Windows.Forms.Button
    Friend WithEvents txtサービス As System.Windows.Forms.TextBox
    Friend WithEvents cmbサービス As System.Windows.Forms.ComboBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents 合計金額 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtサービス率 As System.Windows.Forms.TextBox
    Friend WithEvents 消費税 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbnServiceRate As System.Windows.Forms.RadioButton
    Friend WithEvents rbnServiceAmount As System.Windows.Forms.RadioButton
End Class
