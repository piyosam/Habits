<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class d0500_現金入出金登録
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(d0500_現金入出金登録))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.登録 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.txt入出金額 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt摘要 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgv入出金履歴 = New System.Windows.Forms.DataGridView
        Me.dgv担当者 = New System.Windows.Forms.DataGridView
        Me.txt入出金日 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.rb出金 = New System.Windows.Forms.RadioButton
        Me.rb入金 = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbl入出金番号 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn項目クリア = New System.Windows.Forms.Button
        Me.btn入出金履歴削除 = New System.Windows.Forms.Button
        Me.txt検索開始日 = New System.Windows.Forms.TextBox
        Me.txt検索終了日 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btn検索 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnExcel出力 = New System.Windows.Forms.Button
        CType(Me.dgv入出金履歴, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv担当者, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(244, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "入出金番号 :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(328, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "スタッフ選択 : "
        '
        '登録
        '
        Me.登録.Location = New System.Drawing.Point(599, 34)
        Me.登録.Name = "登録"
        Me.登録.Size = New System.Drawing.Size(100, 23)
        Me.登録.TabIndex = 7
        Me.登録.Text = BTN_REGIST
        Me.登録.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(599, 104)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 9
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'txt入出金額
        '
        Me.txt入出金額.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt入出金額.Location = New System.Drawing.Point(90, 45)
        Me.txt入出金額.MaxLength = 9
        Me.txt入出金額.Name = "txt入出金額"
        Me.txt入出金額.Size = New System.Drawing.Size(108, 20)
        Me.txt入出金額.TabIndex = 3
        Me.txt入出金額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(43, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "金額 :"
        '
        'txt摘要
        '
        Me.txt摘要.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txt摘要.Location = New System.Drawing.Point(18, 192)
        Me.txt摘要.MaxLength = 64
        Me.txt摘要.Multiline = True
        Me.txt摘要.Name = "txt摘要"
        Me.txt摘要.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt摘要.Size = New System.Drawing.Size(520, 34)
        Me.txt摘要.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "摘要 : "
        '
        'dgv入出金履歴
        '
        Me.dgv入出金履歴.AllowUserToAddRows = False
        Me.dgv入出金履歴.AllowUserToDeleteRows = False
        Me.dgv入出金履歴.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv入出金履歴.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv入出金履歴.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv入出金履歴.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv入出金履歴.EnableHeadersVisualStyles = False
        Me.dgv入出金履歴.Location = New System.Drawing.Point(15, 332)
        Me.dgv入出金履歴.MultiSelect = False
        Me.dgv入出金履歴.Name = "dgv入出金履歴"
        Me.dgv入出金履歴.ReadOnly = True
        Me.dgv入出金履歴.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv入出金履歴.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv入出金履歴.RowTemplate.Height = 16
        Me.dgv入出金履歴.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv入出金履歴.Size = New System.Drawing.Size(683, 260)
        Me.dgv入出金履歴.TabIndex = 13
        Me.dgv入出金履歴.TabStop = False
        '
        'dgv担当者
        '
        Me.dgv担当者.AllowUserToAddRows = False
        Me.dgv担当者.AllowUserToDeleteRows = False
        Me.dgv担当者.AllowUserToResizeColumns = False
        Me.dgv担当者.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv担当者.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv担当者.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv担当者.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv担当者.ColumnHeadersVisible = False
        Me.dgv担当者.Location = New System.Drawing.Point(331, 93)
        Me.dgv担当者.MultiSelect = False
        Me.dgv担当者.Name = "dgv担当者"
        Me.dgv担当者.ReadOnly = True
        Me.dgv担当者.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv担当者.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv担当者.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv担当者.RowTemplate.Height = 16
        Me.dgv担当者.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv担当者.Size = New System.Drawing.Size(207, 83)
        Me.dgv担当者.TabIndex = 5
        Me.dgv担当者.TabStop = False
        '
        'txt入出金日
        '
        Me.txt入出金日.BackColor = System.Drawing.Color.White
        Me.txt入出金日.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt入出金日.Location = New System.Drawing.Point(90, 19)
        Me.txt入出金日.MaxLength = 10
        Me.txt入出金日.Name = "txt入出金日"
        Me.txt入出金日.Size = New System.Drawing.Size(108, 20)
        Me.txt入出金日.TabIndex = 2
        Me.txt入出金日.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "入出金日 :"
        '
        'rb出金
        '
        Me.rb出金.AutoSize = True
        Me.rb出金.Location = New System.Drawing.Point(34, 121)
        Me.rb出金.Name = "rb出金"
        Me.rb出金.Size = New System.Drawing.Size(58, 17)
        Me.rb出金.TabIndex = 4
        Me.rb出金.TabStop = True
        Me.rb出金.Text = ": 出金"
        Me.rb出金.UseVisualStyleBackColor = True
        '
        'rb入金
        '
        Me.rb入金.AutoSize = True
        Me.rb入金.Location = New System.Drawing.Point(34, 101)
        Me.rb入金.Name = "rb入金"
        Me.rb入金.Size = New System.Drawing.Size(58, 17)
        Me.rb入金.TabIndex = 4
        Me.rb入金.TabStop = True
        Me.rb入金.Text = ": 入金"
        Me.rb入金.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl入出金番号)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.rb出金)
        Me.GroupBox3.Controls.Add(Me.rb入金)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txt摘要)
        Me.GroupBox3.Controls.Add(Me.txt入出金日)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.dgv担当者)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txt入出金額)
        Me.GroupBox3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(15, 26)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(568, 241)
        Me.GroupBox3.TabIndex = 65
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "登録項目"
        '
        'lbl入出金番号
        '
        Me.lbl入出金番号.BackColor = System.Drawing.Color.White
        Me.lbl入出金番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl入出金番号.Location = New System.Drawing.Point(329, 19)
        Me.lbl入出金番号.Name = "lbl入出金番号"
        Me.lbl入出金番号.Size = New System.Drawing.Size(60, 20)
        Me.lbl入出金番号.TabIndex = 0
        Me.lbl入出金番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "入出金選択 :"
        '
        'btn項目クリア
        '
        Me.btn項目クリア.Location = New System.Drawing.Point(599, 75)
        Me.btn項目クリア.Name = "btn項目クリア"
        Me.btn項目クリア.Size = New System.Drawing.Size(100, 23)
        Me.btn項目クリア.TabIndex = 8
        Me.btn項目クリア.Text = "項目クリア"
        Me.btn項目クリア.UseVisualStyleBackColor = True
        '
        'btn入出金履歴削除
        '
        Me.btn入出金履歴削除.Location = New System.Drawing.Point(530, 604)
        Me.btn入出金履歴削除.Name = "btn入出金履歴削除"
        Me.btn入出金履歴削除.Size = New System.Drawing.Size(75, 23)
        Me.btn入出金履歴削除.TabIndex = 14
        Me.btn入出金履歴削除.Text = "削除"
        Me.btn入出金履歴削除.UseVisualStyleBackColor = True
        '
        'txt検索開始日
        '
        Me.txt検索開始日.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt検索開始日.Location = New System.Drawing.Point(15, 303)
        Me.txt検索開始日.Name = "txt検索開始日"
        Me.txt検索開始日.Size = New System.Drawing.Size(100, 20)
        Me.txt検索開始日.TabIndex = 10
        Me.txt検索開始日.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt検索終了日
        '
        Me.txt検索終了日.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt検索終了日.Location = New System.Drawing.Point(139, 303)
        Me.txt検索終了日.Name = "txt検索終了日"
        Me.txt検索終了日.Size = New System.Drawing.Size(100, 20)
        Me.txt検索終了日.TabIndex = 11
        Me.txt検索終了日.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(118, 307)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "～"
        '
        'btn検索
        '
        Me.btn検索.Location = New System.Drawing.Point(262, 301)
        Me.btn検索.Name = "btn検索"
        Me.btn検索.Size = New System.Drawing.Size(75, 23)
        Me.btn検索.TabIndex = 12
        Me.btn検索.Text = "検索"
        Me.btn検索.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 282)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 13)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "入出金履歴 : "
        '
        'btnExcel出力
        '
        Me.btnExcel出力.Location = New System.Drawing.Point(623, 604)
        Me.btnExcel出力.Name = "btnExcel出力"
        Me.btnExcel出力.Size = New System.Drawing.Size(75, 23)
        Me.btnExcel出力.TabIndex = 15
        Me.btnExcel出力.Text = "Excel出力"
        Me.btnExcel出力.UseVisualStyleBackColor = True
        '
        'd0500_現金入出金登録
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 639)
        Me.Controls.Add(Me.btnExcel出力)
        Me.Controls.Add(Me.btn検索)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt検索終了日)
        Me.Controls.Add(Me.txt検索開始日)
        Me.Controls.Add(Me.btn入出金履歴削除)
        Me.Controls.Add(Me.btn項目クリア)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dgv入出金履歴)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.登録)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "d0500_現金入出金登録"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 現金入出金登録"
        CType(Me.dgv入出金履歴, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv担当者, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents 登録 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents txt入出金額 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt摘要 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv入出金履歴 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv担当者 As System.Windows.Forms.DataGridView
    Friend WithEvents txt入出金日 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents rb出金 As System.Windows.Forms.RadioButton
    Friend WithEvents rb入金 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn項目クリア As System.Windows.Forms.Button
    Friend WithEvents lbl入出金番号 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn入出金履歴削除 As System.Windows.Forms.Button
    Friend WithEvents txt検索開始日 As System.Windows.Forms.TextBox
    Friend WithEvents txt検索終了日 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn検索 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnExcel出力 As System.Windows.Forms.Button
End Class
