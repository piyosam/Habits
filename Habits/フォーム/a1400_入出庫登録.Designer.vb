<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a1400_入出庫登録
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a1400_入出庫登録))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.登録 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.txt入出庫数 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtコメント = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgv入出庫履歴 = New System.Windows.Forms.DataGridView
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgv入出庫理由 = New System.Windows.Forms.DataGridView
        Me.dgv担当者 = New System.Windows.Forms.DataGridView
        Me.txt入出庫日 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.rb出庫 = New System.Windows.Forms.RadioButton
        Me.rb入庫 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl商品名 = New System.Windows.Forms.Label
        Me.lblメーカー名 = New System.Windows.Forms.Label
        Me.lbl在庫数 = New System.Windows.Forms.Label
        Me.lbl分類名 = New System.Windows.Forms.Label
        Me.lbl売上区分 = New System.Windows.Forms.Label
        Me.btn商品選択 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lbl入出庫番号 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn項目クリア = New System.Windows.Forms.Button
        CType(Me.dgv入出庫履歴, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv入出庫理由, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv担当者, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        Me.Label2.Text = "入出庫番号 :"
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
        Me.登録.Location = New System.Drawing.Point(599, 186)
        Me.登録.Name = "登録"
        Me.登録.Size = New System.Drawing.Size(100, 23)
        Me.登録.TabIndex = 8
        Me.登録.Text = "登録"
        Me.登録.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(599, 256)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 10
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'txt入出庫数
        '
        Me.txt入出庫数.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt入出庫数.Location = New System.Drawing.Point(90, 45)
        Me.txt入出庫数.MaxLength = 9
        Me.txt入出庫数.Name = "txt入出庫数"
        Me.txt入出庫数.Size = New System.Drawing.Size(108, 20)
        Me.txt入出庫数.TabIndex = 3
        Me.txt入出庫数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(43, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "数量 :"
        '
        'txtコメント
        '
        Me.txtコメント.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtコメント.Location = New System.Drawing.Point(18, 192)
        Me.txtコメント.MaxLength = 64
        Me.txtコメント.Multiline = True
        Me.txtコメント.Name = "txtコメント"
        Me.txtコメント.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtコメント.Size = New System.Drawing.Size(520, 34)
        Me.txtコメント.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "コメント : "
        '
        'dgv入出庫履歴
        '
        Me.dgv入出庫履歴.AllowUserToAddRows = False
        Me.dgv入出庫履歴.AllowUserToDeleteRows = False
        Me.dgv入出庫履歴.AllowUserToResizeColumns = False
        Me.dgv入出庫履歴.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv入出庫履歴.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv入出庫履歴.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv入出庫履歴.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv入出庫履歴.EnableHeadersVisualStyles = False
        Me.dgv入出庫履歴.Location = New System.Drawing.Point(15, 443)
        Me.dgv入出庫履歴.MultiSelect = False
        Me.dgv入出庫履歴.Name = "dgv入出庫履歴"
        Me.dgv入出庫履歴.ReadOnly = True
        Me.dgv入出庫履歴.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv入出庫履歴.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv入出庫履歴.RowTemplate.Height = 16
        Me.dgv入出庫履歴.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv入出庫履歴.Size = New System.Drawing.Size(683, 180)
        Me.dgv入出庫履歴.TabIndex = 0
        Me.dgv入出庫履歴.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 428)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(123, 13)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "入出庫履歴（当月） : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "売上区分 :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(33, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "分類名 :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(33, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "商品名 :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "メーカー名 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(128, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "入出庫理由選択 : "
        '
        'dgv入出庫理由
        '
        Me.dgv入出庫理由.AllowUserToAddRows = False
        Me.dgv入出庫理由.AllowUserToDeleteRows = False
        Me.dgv入出庫理由.AllowUserToResizeColumns = False
        Me.dgv入出庫理由.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv入出庫理由.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv入出庫理由.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv入出庫理由.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv入出庫理由.ColumnHeadersVisible = False
        Me.dgv入出庫理由.Location = New System.Drawing.Point(131, 93)
        Me.dgv入出庫理由.MultiSelect = False
        Me.dgv入出庫理由.Name = "dgv入出庫理由"
        Me.dgv入出庫理由.ReadOnly = True
        Me.dgv入出庫理由.RowHeadersVisible = False
        Me.dgv入出庫理由.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv入出庫理由.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv入出庫理由.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv入出庫理由.RowTemplate.Height = 16
        Me.dgv入出庫理由.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv入出庫理由.Size = New System.Drawing.Size(157, 83)
        Me.dgv入出庫理由.TabIndex = 5
        Me.dgv入出庫理由.TabStop = False
        '
        'dgv担当者
        '
        Me.dgv担当者.AllowUserToAddRows = False
        Me.dgv担当者.AllowUserToDeleteRows = False
        Me.dgv担当者.AllowUserToResizeColumns = False
        Me.dgv担当者.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv担当者.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv担当者.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv担当者.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv担当者.ColumnHeadersVisible = False
        Me.dgv担当者.Location = New System.Drawing.Point(331, 93)
        Me.dgv担当者.MultiSelect = False
        Me.dgv担当者.Name = "dgv担当者"
        Me.dgv担当者.ReadOnly = True
        Me.dgv担当者.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv担当者.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv担当者.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv担当者.RowTemplate.Height = 16
        Me.dgv担当者.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv担当者.Size = New System.Drawing.Size(207, 83)
        Me.dgv担当者.TabIndex = 6
        Me.dgv担当者.TabStop = False
        '
        'txt入出庫日
        '
        Me.txt入出庫日.BackColor = System.Drawing.Color.White
        Me.txt入出庫日.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt入出庫日.Location = New System.Drawing.Point(90, 19)
        Me.txt入出庫日.MaxLength = 10
        Me.txt入出庫日.Name = "txt入出庫日"
        Me.txt入出庫日.Size = New System.Drawing.Size(108, 20)
        Me.txt入出庫日.TabIndex = 2
        Me.txt入出庫日.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 59
        Me.Label11.Text = "入出庫日 :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(33, 131)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "在庫数 :"
        '
        'rb出庫
        '
        Me.rb出庫.AutoSize = True
        Me.rb出庫.Location = New System.Drawing.Point(34, 121)
        Me.rb出庫.Name = "rb出庫"
        Me.rb出庫.Size = New System.Drawing.Size(58, 17)
        Me.rb出庫.TabIndex = 4
        Me.rb出庫.TabStop = True
        Me.rb出庫.Text = ": 出庫"
        Me.rb出庫.UseVisualStyleBackColor = True
        '
        'rb入庫
        '
        Me.rb入庫.AutoSize = True
        Me.rb入庫.Location = New System.Drawing.Point(34, 101)
        Me.rb入庫.Name = "rb入庫"
        Me.rb入庫.Size = New System.Drawing.Size(58, 17)
        Me.rb入庫.TabIndex = 4
        Me.rb入庫.TabStop = True
        Me.rb入庫.Text = ": 入庫"
        Me.rb入庫.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl商品名)
        Me.GroupBox2.Controls.Add(Me.lblメーカー名)
        Me.GroupBox2.Controls.Add(Me.lbl在庫数)
        Me.GroupBox2.Controls.Add(Me.lbl分類名)
        Me.GroupBox2.Controls.Add(Me.lbl売上区分)
        Me.GroupBox2.Controls.Add(Me.btn商品選択)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(684, 161)
        Me.GroupBox2.TabIndex = 64
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "商品"
        '
        'lbl商品名
        '
        Me.lbl商品名.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl商品名.Location = New System.Drawing.Point(92, 102)
        Me.lbl商品名.Name = "lbl商品名"
        Me.lbl商品名.Size = New System.Drawing.Size(453, 20)
        Me.lbl商品名.TabIndex = 0
        Me.lbl商品名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblメーカー名
        '
        Me.lblメーカー名.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblメーカー名.Location = New System.Drawing.Point(92, 76)
        Me.lblメーカー名.Name = "lblメーカー名"
        Me.lblメーカー名.Size = New System.Drawing.Size(453, 20)
        Me.lblメーカー名.TabIndex = 0
        Me.lblメーカー名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl在庫数
        '
        Me.lbl在庫数.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl在庫数.Location = New System.Drawing.Point(92, 128)
        Me.lbl在庫数.Name = "lbl在庫数"
        Me.lbl在庫数.Size = New System.Drawing.Size(108, 20)
        Me.lbl在庫数.TabIndex = 0
        Me.lbl在庫数.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl分類名
        '
        Me.lbl分類名.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl分類名.Location = New System.Drawing.Point(92, 50)
        Me.lbl分類名.Name = "lbl分類名"
        Me.lbl分類名.Size = New System.Drawing.Size(453, 20)
        Me.lbl分類名.TabIndex = 0
        Me.lbl分類名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl売上区分
        '
        Me.lbl売上区分.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl売上区分.Location = New System.Drawing.Point(92, 24)
        Me.lbl売上区分.Name = "lbl売上区分"
        Me.lbl売上区分.Size = New System.Drawing.Size(453, 20)
        Me.lbl売上区分.TabIndex = 0
        Me.lbl売上区分.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn商品選択
        '
        Me.btn商品選択.Location = New System.Drawing.Point(565, 21)
        Me.btn商品選択.Name = "btn商品選択"
        Me.btn商品選択.Size = New System.Drawing.Size(75, 23)
        Me.btn商品選択.TabIndex = 1
        Me.btn商品選択.Text = "商品選択"
        Me.btn商品選択.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl入出庫番号)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.rb出庫)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.rb入庫)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtコメント)
        Me.GroupBox3.Controls.Add(Me.txt入出庫日)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.dgv入出庫理由)
        Me.GroupBox3.Controls.Add(Me.dgv担当者)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txt入出庫数)
        Me.GroupBox3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(15, 178)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(568, 241)
        Me.GroupBox3.TabIndex = 65
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "登録項目"
        '
        'lbl入出庫番号
        '
        Me.lbl入出庫番号.BackColor = System.Drawing.Color.White
        Me.lbl入出庫番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl入出庫番号.Location = New System.Drawing.Point(329, 19)
        Me.lbl入出庫番号.Name = "lbl入出庫番号"
        Me.lbl入出庫番号.Size = New System.Drawing.Size(60, 20)
        Me.lbl入出庫番号.TabIndex = 0
        Me.lbl入出庫番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "入出庫選択 :"
        '
        'btn項目クリア
        '
        Me.btn項目クリア.Location = New System.Drawing.Point(599, 227)
        Me.btn項目クリア.Name = "btn項目クリア"
        Me.btn項目クリア.Size = New System.Drawing.Size(100, 23)
        Me.btn項目クリア.TabIndex = 9
        Me.btn項目クリア.Text = "項目クリア"
        Me.btn項目クリア.UseVisualStyleBackColor = True
        '
        'a1400_入出庫登録
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 639)
        Me.Controls.Add(Me.btn項目クリア)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dgv入出庫履歴)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.登録)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a1400_入出庫登録"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 入出庫登録"
        CType(Me.dgv入出庫履歴, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv入出庫理由, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv担当者, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents 登録 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents txt入出庫数 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtコメント As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv入出庫履歴 As System.Windows.Forms.DataGridView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgv入出庫理由 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv担当者 As System.Windows.Forms.DataGridView
    Friend WithEvents txt入出庫日 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents rb出庫 As System.Windows.Forms.RadioButton
    Friend WithEvents rb入庫 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btn商品選択 As System.Windows.Forms.Button
    Friend WithEvents btn項目クリア As System.Windows.Forms.Button
    Friend WithEvents lbl入出庫番号 As System.Windows.Forms.Label
    Friend WithEvents lbl分類名 As System.Windows.Forms.Label
    Friend WithEvents lbl売上区分 As System.Windows.Forms.Label
    Friend WithEvents lbl商品名 As System.Windows.Forms.Label
    Friend WithEvents lblメーカー名 As System.Windows.Forms.Label
    Friend WithEvents lbl在庫数 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
