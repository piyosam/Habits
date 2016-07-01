<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class c0400_会計
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(c0400_会計))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtその他支払 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbカード会社 = New System.Windows.Forms.ComboBox
        Me.txtカード支払 = New System.Windows.Forms.TextBox
        Me.txt現金支払 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtお預り = New System.Windows.Forms.TextBox
        Me.btn登録 = New System.Windows.Forms.Button
        Me.btn閉じる = New System.Windows.Forms.Button
        Me.dgv売上発行 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblポイント割引 = New System.Windows.Forms.Label
        Me.lblポイント割引名 = New System.Windows.Forms.Label
        Me.lblサービス = New System.Windows.Forms.Label
        Me.lblサービス名 = New System.Windows.Forms.Label
        Me.lbl割引後 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblPointPurchases = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbl合計 = New System.Windows.Forms.Label
        Me.lbl消費税 = New System.Windows.Forms.Label
        Me.lbl割引後消費税 = New System.Windows.Forms.Label
        Me.lbl氏名カナ = New System.Windows.Forms.Label
        Me.lbl年齢 = New System.Windows.Forms.Label
        Me.lbl氏名 = New System.Windows.Forms.Label
        Me.lblお釣り = New System.Windows.Forms.Label
        Me.txt売上一覧消費税 = New System.Windows.Forms.TextBox
        Me.txt売上一覧小計 = New System.Windows.Forms.TextBox
        Me.btn領収書 = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv売上発行, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtその他支払)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cmbカード会社)
        Me.GroupBox2.Controls.Add(Me.txtカード支払)
        Me.GroupBox2.Controls.Add(Me.txt現金支払)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(287, 190)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 141)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "支払"
        '
        'txtその他支払
        '
        Me.txtその他支払.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtその他支払.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtその他支払.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtその他支払.Location = New System.Drawing.Point(78, 49)
        Me.txtその他支払.MaxLength = 10
        Me.txtその他支払.Name = "txtその他支払"
        Me.txtその他支払.Size = New System.Drawing.Size(110, 23)
        Me.txtその他支払.TabIndex = 3
        Me.txtその他支払.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "その他 : "
        '
        'cmbカード会社
        '
        Me.cmbカード会社.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbカード会社.DropDownWidth = 450
        Me.cmbカード会社.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.cmbカード会社.FormattingEnabled = True
        Me.cmbカード会社.Location = New System.Drawing.Point(78, 106)
        Me.cmbカード会社.Name = "cmbカード会社"
        Me.cmbカード会社.Size = New System.Drawing.Size(109, 21)
        Me.cmbカード会社.TabIndex = 7
        '
        'txtカード支払
        '
        Me.txtカード支払.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtカード支払.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtカード支払.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtカード支払.Location = New System.Drawing.Point(78, 77)
        Me.txtカード支払.MaxLength = 10
        Me.txtカード支払.Name = "txtカード支払"
        Me.txtカード支払.Size = New System.Drawing.Size(110, 23)
        Me.txtカード支払.TabIndex = 5
        Me.txtカード支払.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt現金支払
        '
        Me.txt現金支払.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txt現金支払.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt現金支払.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt現金支払.Location = New System.Drawing.Point(78, 20)
        Me.txt現金支払.MaxLength = 10
        Me.txt現金支払.Name = "txt現金支払"
        Me.txt現金支払.Size = New System.Drawing.Size(110, 23)
        Me.txt現金支払.TabIndex = 1
        Me.txt現金支払.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "カード会社 : "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(32, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "カード : "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(37, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "現金 : "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 74)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "売上合計 :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(315, 359)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "お預り : "
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(315, 389)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 13)
        Me.Label18.TabIndex = 11
        Me.Label18.Text = "お釣り : "
        '
        'txtお預り
        '
        Me.txtお預り.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtお預り.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtお預り.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtお預り.Location = New System.Drawing.Point(365, 353)
        Me.txtお預り.MaxLength = 10
        Me.txtお預り.Name = "txtお預り"
        Me.txtお預り.Size = New System.Drawing.Size(110, 23)
        Me.txtお預り.TabIndex = 10
        Me.txtお預り.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn登録
        '
        Me.btn登録.Location = New System.Drawing.Point(322, 464)
        Me.btn登録.Name = "btn登録"
        Me.btn登録.Size = New System.Drawing.Size(75, 23)
        Me.btn登録.TabIndex = 13
        Me.btn登録.Text = "登録"
        Me.btn登録.UseVisualStyleBackColor = True
        '
        'btn閉じる
        '
        Me.btn閉じる.Location = New System.Drawing.Point(403, 464)
        Me.btn閉じる.Name = "btn閉じる"
        Me.btn閉じる.Size = New System.Drawing.Size(75, 23)
        Me.btn閉じる.TabIndex = 14
        Me.btn閉じる.Text = "閉じる"
        Me.btn閉じる.UseVisualStyleBackColor = True
        '
        'dgv売上発行
        '
        Me.dgv売上発行.AllowUserToAddRows = False
        Me.dgv売上発行.AllowUserToDeleteRows = False
        Me.dgv売上発行.AllowUserToResizeColumns = False
        Me.dgv売上発行.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv売上発行.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv売上発行.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgv売上発行.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv売上発行.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv売上発行.Enabled = False
        Me.dgv売上発行.EnableHeadersVisualStyles = False
        Me.dgv売上発行.Location = New System.Drawing.Point(18, 31)
        Me.dgv売上発行.MultiSelect = False
        Me.dgv売上発行.Name = "dgv売上発行"
        Me.dgv売上発行.ReadOnly = True
        Me.dgv売上発行.RowHeadersVisible = False
        Me.dgv売上発行.RowTemplate.Height = 19
        Me.dgv売上発行.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv売上発行.Size = New System.Drawing.Size(406, 150)
        Me.dgv売上発行.TabIndex = 1
        Me.dgv売上発行.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "区分別売上 : "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblポイント割引)
        Me.GroupBox1.Controls.Add(Me.lblポイント割引名)
        Me.GroupBox1.Controls.Add(Me.lblサービス)
        Me.GroupBox1.Controls.Add(Me.lblサービス名)
        Me.GroupBox1.Controls.Add(Me.lbl割引後)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblPointPurchases)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbl合計)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.lbl消費税)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 190)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 215)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "合計内訳"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "（消費税） :"
        '
        'lblポイント割引
        '
        Me.lblポイント割引.BackColor = System.Drawing.Color.White
        Me.lblポイント割引.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblポイント割引.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
        Me.lblポイント割引.Location = New System.Drawing.Point(81, 150)
        Me.lblポイント割引.Name = "lblポイント割引"
        Me.lblポイント割引.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblポイント割引.Size = New System.Drawing.Size(110, 23)
        Me.lblポイント割引.TabIndex = 9
        Me.lblポイント割引.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblポイント割引名
        '
        Me.lblポイント割引名.BackColor = System.Drawing.SystemColors.Control
        Me.lblポイント割引名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.lblポイント割引名.Location = New System.Drawing.Point(81, 127)
        Me.lblポイント割引名.Name = "lblポイント割引名"
        Me.lblポイント割引名.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblポイント割引名.Size = New System.Drawing.Size(164, 23)
        Me.lblポイント割引名.TabIndex = 8
        Me.lblポイント割引名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblサービス
        '
        Me.lblサービス.BackColor = System.Drawing.Color.White
        Me.lblサービス.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblサービス.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
        Me.lblサービス.Location = New System.Drawing.Point(81, 40)
        Me.lblサービス.Name = "lblサービス"
        Me.lblサービス.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblサービス.Size = New System.Drawing.Size(110, 23)
        Me.lblサービス.TabIndex = 2
        Me.lblサービス.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblサービス名
        '
        Me.lblサービス名.BackColor = System.Drawing.SystemColors.Control
        Me.lblサービス名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.lblサービス名.Location = New System.Drawing.Point(78, 17)
        Me.lblサービス名.Name = "lblサービス名"
        Me.lblサービス名.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblサービス名.Size = New System.Drawing.Size(164, 23)
        Me.lblサービス名.TabIndex = 1
        Me.lblサービス名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl割引後
        '
        Me.lbl割引後.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbl割引後.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl割引後.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
        Me.lbl割引後.Location = New System.Drawing.Point(81, 179)
        Me.lbl割引後.Name = "lbl割引後"
        Me.lbl割引後.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lbl割引後.Size = New System.Drawing.Size(110, 23)
        Me.lbl割引後.TabIndex = 11
        Me.lbl割引後.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 185)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "割引後 :"
        '
        'lblPointPurchases
        '
        Me.lblPointPurchases.AutoSize = True
        Me.lblPointPurchases.Location = New System.Drawing.Point(3, 132)
        Me.lblPointPurchases.Name = "lblPointPurchases"
        Me.lblPointPurchases.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPointPurchases.Size = New System.Drawing.Size(77, 13)
        Me.lblPointPurchases.TabIndex = 7
        Me.lblPointPurchases.Text = "ポイント割引:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "サービス:"
        '
        'lbl合計
        '
        Me.lbl合計.BackColor = System.Drawing.Color.White
        Me.lbl合計.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl合計.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
        Me.lbl合計.Location = New System.Drawing.Point(81, 69)
        Me.lbl合計.Name = "lbl合計"
        Me.lbl合計.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lbl合計.Size = New System.Drawing.Size(110, 23)
        Me.lbl合計.TabIndex = 6
        Me.lbl合計.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl消費税
        '
        Me.lbl消費税.BackColor = System.Drawing.Color.White
        Me.lbl消費税.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl消費税.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
        Me.lbl消費税.Location = New System.Drawing.Point(81, 99)
        Me.lbl消費税.Name = "lbl消費税"
        Me.lbl消費税.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lbl消費税.Size = New System.Drawing.Size(110, 23)
        Me.lbl消費税.TabIndex = 4
        Me.lbl消費税.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl割引後消費税
        '
        Me.lbl割引後消費税.BackColor = System.Drawing.Color.White
        Me.lbl割引後消費税.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl割引後消費税.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
        Me.lbl割引後消費税.Location = New System.Drawing.Point(213, 289)
        Me.lbl割引後消費税.Name = "lbl割引後消費税"
        Me.lbl割引後消費税.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lbl割引後消費税.Size = New System.Drawing.Size(55, 23)
        Me.lbl割引後消費税.TabIndex = 13
        Me.lbl割引後消費税.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl割引後消費税.Visible = False
        '
        'lbl氏名カナ
        '
        Me.lbl氏名カナ.BackColor = System.Drawing.Color.White
        Me.lbl氏名カナ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl氏名カナ.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.lbl氏名カナ.Location = New System.Drawing.Point(24, 414)
        Me.lbl氏名カナ.Name = "lbl氏名カナ"
        Me.lbl氏名カナ.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lbl氏名カナ.Size = New System.Drawing.Size(169, 20)
        Me.lbl氏名カナ.TabIndex = 5
        Me.lbl氏名カナ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl年齢
        '
        Me.lbl年齢.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl年齢.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl年齢.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.lbl年齢.Location = New System.Drawing.Point(24, 467)
        Me.lbl年齢.Name = "lbl年齢"
        Me.lbl年齢.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lbl年齢.Size = New System.Drawing.Size(169, 20)
        Me.lbl年齢.TabIndex = 7
        Me.lbl年齢.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl氏名
        '
        Me.lbl氏名.BackColor = System.Drawing.Color.White
        Me.lbl氏名.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl氏名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.lbl氏名.Location = New System.Drawing.Point(24, 440)
        Me.lbl氏名.Name = "lbl氏名"
        Me.lbl氏名.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lbl氏名.Size = New System.Drawing.Size(169, 20)
        Me.lbl氏名.TabIndex = 6
        Me.lbl氏名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblお釣り
        '
        Me.lblお釣り.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblお釣り.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblお釣り.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!)
        Me.lblお釣り.Location = New System.Drawing.Point(365, 383)
        Me.lblお釣り.Name = "lblお釣り"
        Me.lblお釣り.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lblお釣り.Size = New System.Drawing.Size(110, 23)
        Me.lblお釣り.TabIndex = 12
        Me.lblお釣り.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt売上一覧消費税
        '
        Me.txt売上一覧消費税.Enabled = False
        Me.txt売上一覧消費税.Location = New System.Drawing.Point(414, 5)
        Me.txt売上一覧消費税.Name = "txt売上一覧消費税"
        Me.txt売上一覧消費税.Size = New System.Drawing.Size(10, 20)
        Me.txt売上一覧消費税.TabIndex = 3
        Me.txt売上一覧消費税.Visible = False
        '
        'txt売上一覧小計
        '
        Me.txt売上一覧小計.Enabled = False
        Me.txt売上一覧小計.Location = New System.Drawing.Point(398, 5)
        Me.txt売上一覧小計.Name = "txt売上一覧小計"
        Me.txt売上一覧小計.Size = New System.Drawing.Size(10, 20)
        Me.txt売上一覧小計.TabIndex = 2
        Me.txt売上一覧小計.Visible = False
        '
        'btn領収書
        '
        Me.btn領収書.Location = New System.Drawing.Point(213, 464)
        Me.btn領収書.Name = "btn領収書"
        Me.btn領収書.Size = New System.Drawing.Size(75, 23)
        Me.btn領収書.TabIndex = 15
        Me.btn領収書.Text = "領収書"
        Me.btn領収書.UseVisualStyleBackColor = True
        '
        'c0400_会計
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 505)
        Me.Controls.Add(Me.lbl割引後消費税)
        Me.Controls.Add(Me.btn領収書)
        Me.Controls.Add(Me.lblお釣り)
        Me.Controls.Add(Me.lbl氏名)
        Me.Controls.Add(Me.lbl年齢)
        Me.Controls.Add(Me.lbl氏名カナ)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt売上一覧小計)
        Me.Controls.Add(Me.txt売上一覧消費税)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv売上発行)
        Me.Controls.Add(Me.btn閉じる)
        Me.Controls.Add(Me.btn登録)
        Me.Controls.Add(Me.txtお預り)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "c0400_会計"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 会計"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv売上発行, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtカード支払 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbカード会社 As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtお預り As System.Windows.Forms.TextBox
    Friend WithEvents btn登録 As System.Windows.Forms.Button
    Friend WithEvents btn閉じる As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents dgv売上発行 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl合計 As System.Windows.Forms.Label
    Friend WithEvents lbl消費税 As System.Windows.Forms.Label
    Friend WithEvents lbl氏名カナ As System.Windows.Forms.Label
    Friend WithEvents lbl年齢 As System.Windows.Forms.Label
    Friend WithEvents lbl氏名 As System.Windows.Forms.Label
    Friend WithEvents lblお釣り As System.Windows.Forms.Label
    Friend WithEvents txtその他支払 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt売上一覧消費税 As System.Windows.Forms.TextBox
    Friend WithEvents txt売上一覧小計 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl割引後 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblPointPurchases As System.Windows.Forms.Label
    Friend WithEvents txt現金支払 As System.Windows.Forms.TextBox
    Friend WithEvents lblポイント割引 As System.Windows.Forms.Label
    Friend WithEvents lblポイント割引名 As System.Windows.Forms.Label
    Friend WithEvents lblサービス As System.Windows.Forms.Label
    Friend WithEvents lblサービス名 As System.Windows.Forms.Label
    Friend WithEvents btn領収書 As System.Windows.Forms.Button
    Friend WithEvents lbl割引後消費税 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
