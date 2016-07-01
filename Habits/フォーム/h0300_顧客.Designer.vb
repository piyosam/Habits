<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class h0300_顧客
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(h0300_顧客))
        Me.閉じる = New System.Windows.Forms.Button
        Me.btn戻る = New System.Windows.Forms.Button
        Me.btn進む = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt開始顧客番号 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmb表示件数 = New System.Windows.Forms.ComboBox
        Me.dgv一覧 = New System.Windows.Forms.DataGridView
        Me.lbl最大顧客番号 = New System.Windows.Forms.Label
        Me.lbl終了顧客番号 = New System.Windows.Forms.Label
        Me.lbl_検索最大顧客番号 = New System.Windows.Forms.Label
        Me.btn_Search = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbl最小顧客番号 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbReg = New System.Windows.Forms.ComboBox
        Me.lbl最小顧客番号_仮登録 = New System.Windows.Forms.Label
        Me.lbl最大顧客番号_仮登録 = New System.Windows.Forms.Label
        Me.lbl最小顧客番号_登録済 = New System.Windows.Forms.Label
        Me.lbl最大顧客番号_登録済 = New System.Windows.Forms.Label
        CType(Me.dgv一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(837, 589)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 16
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'btn戻る
        '
        Me.btn戻る.Image = Global.Habits.My.Resources.Resources.left
        Me.btn戻る.Location = New System.Drawing.Point(533, 586)
        Me.btn戻る.Name = "btn戻る"
        Me.btn戻る.Size = New System.Drawing.Size(40, 24)
        Me.btn戻る.TabIndex = 10
        Me.btn戻る.UseVisualStyleBackColor = True
        '
        'btn進む
        '
        Me.btn進む.Image = Global.Habits.My.Resources.Resources.right
        Me.btn進む.Location = New System.Drawing.Point(593, 586)
        Me.btn進む.Name = "btn進む"
        Me.btn進む.Size = New System.Drawing.Size(40, 24)
        Me.btn進む.TabIndex = 11
        Me.btn進む.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 557)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "顧客番号 :"
        '
        'txt開始顧客番号
        '
        Me.txt開始顧客番号.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt開始顧客番号.Location = New System.Drawing.Point(84, 554)
        Me.txt開始顧客番号.MaxLength = 6
        Me.txt開始顧客番号.Name = "txt開始顧客番号"
        Me.txt開始顧客番号.Size = New System.Drawing.Size(71, 20)
        Me.txt開始顧客番号.TabIndex = 2
        Me.txt開始顧客番号.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(175, 557)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "～"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(90, 589)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "最大登録顧客番号 :"
        '
        'cmb表示件数
        '
        Me.cmb表示件数.BackColor = System.Drawing.SystemColors.Window
        Me.cmb表示件数.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb表示件数.FormattingEnabled = True
        Me.cmb表示件数.Location = New System.Drawing.Point(389, 553)
        Me.cmb表示件数.Name = "cmb表示件数"
        Me.cmb表示件数.Size = New System.Drawing.Size(95, 21)
        Me.cmb表示件数.TabIndex = 4
        '
        'dgv一覧
        '
        Me.dgv一覧.AllowUserToAddRows = False
        Me.dgv一覧.AllowUserToDeleteRows = False
        Me.dgv一覧.AllowUserToResizeColumns = False
        Me.dgv一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv一覧.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgv一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv一覧.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.dgv一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv一覧.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv一覧.EnableHeadersVisualStyles = False
        Me.dgv一覧.Location = New System.Drawing.Point(18, 16)
        Me.dgv一覧.MultiSelect = False
        Me.dgv一覧.Name = "dgv一覧"
        Me.dgv一覧.ReadOnly = True
        Me.dgv一覧.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv一覧.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv一覧.RowTemplate.Height = 16
        Me.dgv一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv一覧.Size = New System.Drawing.Size(919, 520)
        Me.dgv一覧.TabIndex = 1
        Me.dgv一覧.TabStop = False
        '
        'lbl最大顧客番号
        '
        Me.lbl最大顧客番号.BackColor = System.Drawing.Color.White
        Me.lbl最大顧客番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl最大顧客番号.Location = New System.Drawing.Point(213, 586)
        Me.lbl最大顧客番号.Name = "lbl最大顧客番号"
        Me.lbl最大顧客番号.Size = New System.Drawing.Size(71, 20)
        Me.lbl最大顧客番号.TabIndex = 5
        Me.lbl最大顧客番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl終了顧客番号
        '
        Me.lbl終了顧客番号.BackColor = System.Drawing.Color.White
        Me.lbl終了顧客番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl終了顧客番号.Location = New System.Drawing.Point(779, 539)
        Me.lbl終了顧客番号.Name = "lbl終了顧客番号"
        Me.lbl終了顧客番号.Size = New System.Drawing.Size(22, 20)
        Me.lbl終了顧客番号.TabIndex = 12
        Me.lbl終了顧客番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl終了顧客番号.Visible = False
        '
        'lbl_検索最大顧客番号
        '
        Me.lbl_検索最大顧客番号.BackColor = System.Drawing.Color.White
        Me.lbl_検索最大顧客番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_検索最大顧客番号.Location = New System.Drawing.Point(214, 553)
        Me.lbl_検索最大顧客番号.Name = "lbl_検索最大顧客番号"
        Me.lbl_検索最大顧客番号.Size = New System.Drawing.Size(71, 20)
        Me.lbl_検索最大顧客番号.TabIndex = 3
        Me.lbl_検索最大顧客番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_Search
        '
        Me.btn_Search.Location = New System.Drawing.Point(533, 552)
        Me.btn_Search.Name = "btn_Search"
        Me.btn_Search.Size = New System.Drawing.Size(100, 23)
        Me.btn_Search.TabIndex = 9
        Me.btn_Search.Text = "検索"
        Me.btn_Search.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(317, 557)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "表示件数 :"
        '
        'lbl最小顧客番号
        '
        Me.lbl最小顧客番号.BackColor = System.Drawing.Color.White
        Me.lbl最小顧客番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl最小顧客番号.Location = New System.Drawing.Point(837, 539)
        Me.lbl最小顧客番号.Name = "lbl最小顧客番号"
        Me.lbl最小顧客番号.Size = New System.Drawing.Size(23, 20)
        Me.lbl最小顧客番号.TabIndex = 13
        Me.lbl最小顧客番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl最小顧客番号.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(317, 586)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "登録区分 :"
        '
        'cmbReg
        '
        Me.cmbReg.BackColor = System.Drawing.SystemColors.Window
        Me.cmbReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReg.FormattingEnabled = True
        Me.cmbReg.Location = New System.Drawing.Point(389, 583)
        Me.cmbReg.Name = "cmbReg"
        Me.cmbReg.Size = New System.Drawing.Size(95, 21)
        Me.cmbReg.TabIndex = 8
        '
        'lbl最小顧客番号_仮登録
        '
        Me.lbl最小顧客番号_仮登録.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl最小顧客番号_仮登録.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl最小顧客番号_仮登録.Location = New System.Drawing.Point(865, 539)
        Me.lbl最小顧客番号_仮登録.Name = "lbl最小顧客番号_仮登録"
        Me.lbl最小顧客番号_仮登録.Size = New System.Drawing.Size(23, 20)
        Me.lbl最小顧客番号_仮登録.TabIndex = 14
        Me.lbl最小顧客番号_仮登録.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl最小顧客番号_仮登録.Visible = False
        '
        'lbl最大顧客番号_仮登録
        '
        Me.lbl最大顧客番号_仮登録.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl最大顧客番号_仮登録.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl最大顧客番号_仮登録.Location = New System.Drawing.Point(214, 610)
        Me.lbl最大顧客番号_仮登録.Name = "lbl最大顧客番号_仮登録"
        Me.lbl最大顧客番号_仮登録.Size = New System.Drawing.Size(22, 15)
        Me.lbl最大顧客番号_仮登録.TabIndex = 6
        Me.lbl最大顧客番号_仮登録.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl最大顧客番号_仮登録.Visible = False
        '
        'lbl最小顧客番号_登録済
        '
        Me.lbl最小顧客番号_登録済.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbl最小顧客番号_登録済.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl最小顧客番号_登録済.Location = New System.Drawing.Point(893, 539)
        Me.lbl最小顧客番号_登録済.Name = "lbl最小顧客番号_登録済"
        Me.lbl最小顧客番号_登録済.Size = New System.Drawing.Size(23, 20)
        Me.lbl最小顧客番号_登録済.TabIndex = 15
        Me.lbl最小顧客番号_登録済.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl最小顧客番号_登録済.Visible = False
        '
        'lbl最大顧客番号_登録済
        '
        Me.lbl最大顧客番号_登録済.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbl最大顧客番号_登録済.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl最大顧客番号_登録済.Location = New System.Drawing.Point(242, 610)
        Me.lbl最大顧客番号_登録済.Name = "lbl最大顧客番号_登録済"
        Me.lbl最大顧客番号_登録済.Size = New System.Drawing.Size(22, 15)
        Me.lbl最大顧客番号_登録済.TabIndex = 7
        Me.lbl最大顧客番号_登録済.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl最大顧客番号_登録済.Visible = False
        '
        'h0300_顧客
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 629)
        Me.Controls.Add(Me.lbl最小顧客番号_登録済)
        Me.Controls.Add(Me.lbl最大顧客番号_登録済)
        Me.Controls.Add(Me.lbl最小顧客番号_仮登録)
        Me.Controls.Add(Me.lbl最大顧客番号_仮登録)
        Me.Controls.Add(Me.cmbReg)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl最小顧客番号)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl終了顧客番号)
        Me.Controls.Add(Me.lbl_検索最大顧客番号)
        Me.Controls.Add(Me.lbl最大顧客番号)
        Me.Controls.Add(Me.dgv一覧)
        Me.Controls.Add(Me.cmb表示件数)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt開始顧客番号)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn進む)
        Me.Controls.Add(Me.btn戻る)
        Me.Controls.Add(Me.btn_Search)
        Me.Controls.Add(Me.閉じる)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "h0300_顧客"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 顧客一覧"
        CType(Me.dgv一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents btn戻る As System.Windows.Forms.Button
    Friend WithEvents btn進む As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt開始顧客番号 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb表示件数 As System.Windows.Forms.ComboBox
    Public WithEvents dgv一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents lbl最大顧客番号 As System.Windows.Forms.Label
    Friend WithEvents lbl終了顧客番号 As System.Windows.Forms.Label
    Friend WithEvents lbl_検索最大顧客番号 As System.Windows.Forms.Label
    Friend WithEvents btn_Search As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl最小顧客番号 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbReg As System.Windows.Forms.ComboBox
    Friend WithEvents lbl最小顧客番号_仮登録 As System.Windows.Forms.Label
    Friend WithEvents lbl最大顧客番号_仮登録 As System.Windows.Forms.Label
    Friend WithEvents lbl最小顧客番号_登録済 As System.Windows.Forms.Label
    Friend WithEvents lbl最大顧客番号_登録済 As System.Windows.Forms.Label
End Class
