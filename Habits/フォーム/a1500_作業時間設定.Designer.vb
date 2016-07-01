<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a1500_作業時間設定
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a1500_作業時間設定))
        Me.工程一覧 = New System.Windows.Forms.DataGridView
        Me.担当者一覧 = New System.Windows.Forms.DataGridView
        Me.登録済一覧 = New System.Windows.Forms.DataGridView
        Me.閉じる = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.登録 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.削除 = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.来店者番号 = New System.Windows.Forms.TextBox
        Me.商品一覧 = New System.Windows.Forms.DataGridView
        Me.Label8 = New System.Windows.Forms.Label
        Me.来店日 = New System.Windows.Forms.TextBox
        Me.売上番号 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.設定 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.作業時間設定 = New System.Windows.Forms.GroupBox
        Me.作業終了 = New System.Windows.Forms.Label
        Me.作業開始 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.日付 = New System.Windows.Forms.Label
        Me.顧客番号 = New System.Windows.Forms.Label
        Me.顧客名 = New System.Windows.Forms.Label
        Me.主担当者名 = New System.Windows.Forms.Label
        CType(Me.工程一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.担当者一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.登録済一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.商品一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.作業時間設定.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        '工程一覧
        '
        Me.工程一覧.AllowUserToAddRows = False
        Me.工程一覧.AllowUserToDeleteRows = False
        Me.工程一覧.AllowUserToResizeColumns = False
        Me.工程一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.工程一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.工程一覧.BackgroundColor = System.Drawing.Color.White
        Me.工程一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.工程一覧.ColumnHeadersVisible = False
        Me.工程一覧.Location = New System.Drawing.Point(180, 41)
        Me.工程一覧.MultiSelect = False
        Me.工程一覧.Name = "工程一覧"
        Me.工程一覧.ReadOnly = True
        Me.工程一覧.RowHeadersVisible = False
        Me.工程一覧.RowTemplate.Height = 16
        Me.工程一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.工程一覧.Size = New System.Drawing.Size(199, 84)
        Me.工程一覧.TabIndex = 0
        Me.工程一覧.TabStop = False
        '
        '担当者一覧
        '
        Me.担当者一覧.AllowUserToAddRows = False
        Me.担当者一覧.AllowUserToDeleteRows = False
        Me.担当者一覧.AllowUserToResizeColumns = False
        Me.担当者一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue
        Me.担当者一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.担当者一覧.BackgroundColor = System.Drawing.Color.White
        Me.担当者一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.担当者一覧.ColumnHeadersVisible = False
        Me.担当者一覧.Location = New System.Drawing.Point(402, 41)
        Me.担当者一覧.MultiSelect = False
        Me.担当者一覧.Name = "担当者一覧"
        Me.担当者一覧.ReadOnly = True
        Me.担当者一覧.RowHeadersVisible = False
        Me.担当者一覧.RowTemplate.Height = 16
        Me.担当者一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.担当者一覧.Size = New System.Drawing.Size(151, 83)
        Me.担当者一覧.TabIndex = 1
        Me.担当者一覧.TabStop = False
        '
        '登録済一覧
        '
        Me.登録済一覧.AllowUserToAddRows = False
        Me.登録済一覧.AllowUserToDeleteRows = False
        Me.登録済一覧.AllowUserToResizeColumns = False
        Me.登録済一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue
        Me.登録済一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.登録済一覧.BackgroundColor = System.Drawing.Color.White
        Me.登録済一覧.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.登録済一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.登録済一覧.EnableHeadersVisualStyles = False
        Me.登録済一覧.Location = New System.Drawing.Point(10, 149)
        Me.登録済一覧.MultiSelect = False
        Me.登録済一覧.Name = "登録済一覧"
        Me.登録済一覧.ReadOnly = True
        Me.登録済一覧.RowHeadersVisible = False
        Me.登録済一覧.RowTemplate.Height = 16
        Me.登録済一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.登録済一覧.Size = New System.Drawing.Size(543, 99)
        Me.登録済一覧.TabIndex = 2
        Me.登録済一覧.TabStop = False
        '
        '閉じる
        '
        Me.閉じる.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.閉じる.Location = New System.Drawing.Point(564, 111)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 4
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(401, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "スタッフ一覧 :"
        '
        '登録
        '
        Me.登録.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.登録.Location = New System.Drawing.Point(564, 41)
        Me.登録.Name = "登録"
        Me.登録.Size = New System.Drawing.Size(100, 23)
        Me.登録.TabIndex = 2
        Me.登録.Text = "登録"
        Me.登録.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(47, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "氏名 :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.Location = New System.Drawing.Point(34, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "主担当 :"
        '
        '削除
        '
        Me.削除.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.削除.Location = New System.Drawing.Point(564, 82)
        Me.削除.Name = "削除"
        Me.削除.Size = New System.Drawing.Size(100, 23)
        Me.削除.TabIndex = 3
        Me.削除.Text = "削除"
        Me.削除.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "顧客番号 :"
        '
        '来店者番号
        '
        Me.来店者番号.Location = New System.Drawing.Point(248, 22)
        Me.来店者番号.Name = "来店者番号"
        Me.来店者番号.Size = New System.Drawing.Size(10, 19)
        Me.来店者番号.TabIndex = 19
        Me.来店者番号.Visible = False
        '
        '商品一覧
        '
        Me.商品一覧.AllowUserToAddRows = False
        Me.商品一覧.AllowUserToDeleteRows = False
        Me.商品一覧.AllowUserToResizeColumns = False
        Me.商品一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue
        Me.商品一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.商品一覧.BackgroundColor = System.Drawing.Color.White
        Me.商品一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.商品一覧.ColumnHeadersVisible = False
        Me.商品一覧.EnableHeadersVisualStyles = False
        Me.商品一覧.Location = New System.Drawing.Point(10, 41)
        Me.商品一覧.MultiSelect = False
        Me.商品一覧.Name = "商品一覧"
        Me.商品一覧.ReadOnly = True
        Me.商品一覧.RowHeadersVisible = False
        Me.商品一覧.RowTemplate.Height = 16
        Me.商品一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.商品一覧.Size = New System.Drawing.Size(151, 83)
        Me.商品一覧.TabIndex = 20
        Me.商品一覧.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "商品一覧 :"
        '
        '来店日
        '
        Me.来店日.Location = New System.Drawing.Point(248, 71)
        Me.来店日.Name = "来店日"
        Me.来店日.Size = New System.Drawing.Size(10, 19)
        Me.来店日.TabIndex = 22
        Me.来店日.Visible = False
        '
        '売上番号
        '
        Me.売上番号.Location = New System.Drawing.Point(248, 46)
        Me.売上番号.Name = "売上番号"
        Me.売上番号.Size = New System.Drawing.Size(10, 19)
        Me.売上番号.TabIndex = 23
        Me.売上番号.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(179, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "番号"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(213, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "工程名"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.Location = New System.Drawing.Point(326, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "ポイント"
        '
        '設定
        '
        Me.設定.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.設定.Location = New System.Drawing.Point(286, 45)
        Me.設定.Name = "設定"
        Me.設定.Size = New System.Drawing.Size(100, 23)
        Me.設定.TabIndex = 1
        Me.設定.Text = "変更"
        Me.設定.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "来店日 :"
        '
        '作業時間設定
        '
        Me.作業時間設定.Controls.Add(Me.作業終了)
        Me.作業時間設定.Controls.Add(Me.作業開始)
        Me.作業時間設定.Controls.Add(Me.設定)
        Me.作業時間設定.Controls.Add(Me.Label16)
        Me.作業時間設定.Controls.Add(Me.Label1)
        Me.作業時間設定.Controls.Add(Me.Label11)
        Me.作業時間設定.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.作業時間設定.Location = New System.Drawing.Point(290, 16)
        Me.作業時間設定.Name = "作業時間設定"
        Me.作業時間設定.Size = New System.Drawing.Size(394, 98)
        Me.作業時間設定.TabIndex = 40
        Me.作業時間設定.TabStop = False
        Me.作業時間設定.Text = "作業時間設定"
        '
        '作業終了
        '
        Me.作業終了.BackColor = System.Drawing.Color.White
        Me.作業終了.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.作業終了.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.作業終了.Location = New System.Drawing.Point(172, 45)
        Me.作業終了.Name = "作業終了"
        Me.作業終了.Size = New System.Drawing.Size(100, 26)
        Me.作業終了.TabIndex = 53
        Me.作業終了.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '作業開始
        '
        Me.作業開始.BackColor = System.Drawing.Color.White
        Me.作業開始.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.作業開始.Font = New System.Drawing.Font("MS UI Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.作業開始.Location = New System.Drawing.Point(27, 45)
        Me.作業開始.Name = "作業開始"
        Me.作業開始.Size = New System.Drawing.Size(100, 26)
        Me.作業開始.TabIndex = 52
        Me.作業開始.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(172, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "終了 :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(133, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "　～　"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.Location = New System.Drawing.Point(28, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "開始 :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.登録)
        Me.GroupBox1.Controls.Add(Me.工程一覧)
        Me.GroupBox1.Controls.Add(Me.担当者一覧)
        Me.GroupBox1.Controls.Add(Me.閉じる)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.削除)
        Me.GroupBox1.Controls.Add(Me.商品一覧)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.登録済一覧)
        Me.GroupBox1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 140)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(672, 265)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "工程設定"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 134)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 13)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "獲得ポイント一覧 :"
        '
        '日付
        '
        Me.日付.AutoEllipsis = True
        Me.日付.BackColor = System.Drawing.Color.White
        Me.日付.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.日付.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.日付.Location = New System.Drawing.Point(93, 20)
        Me.日付.Name = "日付"
        Me.日付.Size = New System.Drawing.Size(149, 20)
        Me.日付.TabIndex = 42
        Me.日付.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '顧客番号
        '
        Me.顧客番号.AutoEllipsis = True
        Me.顧客番号.BackColor = System.Drawing.Color.White
        Me.顧客番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.顧客番号.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.顧客番号.Location = New System.Drawing.Point(93, 46)
        Me.顧客番号.Name = "顧客番号"
        Me.顧客番号.Size = New System.Drawing.Size(149, 20)
        Me.顧客番号.TabIndex = 43
        Me.顧客番号.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '顧客名
        '
        Me.顧客名.AutoEllipsis = True
        Me.顧客名.BackColor = System.Drawing.Color.White
        Me.顧客名.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.顧客名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.顧客名.Location = New System.Drawing.Point(93, 72)
        Me.顧客名.Name = "顧客名"
        Me.顧客名.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.顧客名.Size = New System.Drawing.Size(149, 20)
        Me.顧客名.TabIndex = 44
        Me.顧客名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '主担当者名
        '
        Me.主担当者名.AutoEllipsis = True
        Me.主担当者名.BackColor = System.Drawing.Color.White
        Me.主担当者名.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.主担当者名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.主担当者名.Location = New System.Drawing.Point(93, 98)
        Me.主担当者名.Name = "主担当者名"
        Me.主担当者名.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.主担当者名.Size = New System.Drawing.Size(149, 20)
        Me.主担当者名.TabIndex = 45
        Me.主担当者名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'a1500_作業時間設定
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 424)
        Me.Controls.Add(Me.主担当者名)
        Me.Controls.Add(Me.顧客名)
        Me.Controls.Add(Me.顧客番号)
        Me.Controls.Add(Me.日付)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.作業時間設定)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.売上番号)
        Me.Controls.Add(Me.来店日)
        Me.Controls.Add(Me.来店者番号)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a1500_作業時間設定"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 作業時間・工程設定"
        CType(Me.工程一覧, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.担当者一覧, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.登録済一覧, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.商品一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.作業時間設定.ResumeLayout(False)
        Me.作業時間設定.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents 工程一覧 As System.Windows.Forms.DataGridView
    Public WithEvents 担当者一覧 As System.Windows.Forms.DataGridView
    Public WithEvents 登録済一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 登録 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents 削除 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents 来店者番号 As System.Windows.Forms.TextBox
    Public WithEvents 商品一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents 来店日 As System.Windows.Forms.TextBox
    Friend WithEvents 売上番号 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents 設定 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents 作業時間設定 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents 日付 As System.Windows.Forms.Label
    Friend WithEvents 顧客番号 As System.Windows.Forms.Label
    Friend WithEvents 顧客名 As System.Windows.Forms.Label
    Friend WithEvents 主担当者名 As System.Windows.Forms.Label
    Friend WithEvents 作業終了 As System.Windows.Forms.Label
    Friend WithEvents 作業開始 As System.Windows.Forms.Label
End Class
