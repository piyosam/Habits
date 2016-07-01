<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a1100_目標額
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a1100_目標額))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt対象年月 = New System.Windows.Forms.TextBox
        Me.txt目標額 = New System.Windows.Forms.TextBox
        Me.txt営業日数 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btn閉じる = New System.Windows.Forms.Button
        Me.cmb売上区分 = New System.Windows.Forms.ComboBox
        Me.dgv目標額一覧 = New System.Windows.Forms.DataGridView
        Me.txt月日数 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt前年度比 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lbl前年度目標額 = New System.Windows.Forms.Label
        Me.btn項目クリア = New System.Windows.Forms.Button
        Me.btn登録 = New System.Windows.Forms.Button
        CType(Me.dgv目標額一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "対象年月 : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "売上区分 : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(51, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "目標額 : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "営業日数 : "
        '
        'txt対象年月
        '
        Me.txt対象年月.BackColor = System.Drawing.Color.White
        Me.txt対象年月.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt対象年月.Location = New System.Drawing.Point(105, 15)
        Me.txt対象年月.MaxLength = 7
        Me.txt対象年月.Name = "txt対象年月"
        Me.txt対象年月.Size = New System.Drawing.Size(121, 20)
        Me.txt対象年月.TabIndex = 1
        Me.txt対象年月.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt目標額
        '
        Me.txt目標額.BackColor = System.Drawing.Color.White
        Me.txt目標額.Enabled = False
        Me.txt目標額.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt目標額.Location = New System.Drawing.Point(105, 124)
        Me.txt目標額.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.txt目標額.MaxLength = 9
        Me.txt目標額.Name = "txt目標額"
        Me.txt目標額.Size = New System.Drawing.Size(121, 20)
        Me.txt目標額.TabIndex = 5
        Me.txt目標額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt営業日数
        '
        Me.txt営業日数.BackColor = System.Drawing.Color.White
        Me.txt営業日数.Enabled = False
        Me.txt営業日数.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt営業日数.Location = New System.Drawing.Point(105, 151)
        Me.txt営業日数.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.txt営業日数.MaxLength = 2
        Me.txt営業日数.Name = "txt営業日数"
        Me.txt営業日数.Size = New System.Drawing.Size(121, 20)
        Me.txt営業日数.TabIndex = 6
        Me.txt営業日数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(260, 367)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "（過去36ヶ月間表示）"
        '
        'btn閉じる
        '
        Me.btn閉じる.Location = New System.Drawing.Point(282, 85)
        Me.btn閉じる.Name = "btn閉じる"
        Me.btn閉じる.Size = New System.Drawing.Size(100, 23)
        Me.btn閉じる.TabIndex = 9
        Me.btn閉じる.Text = "閉じる"
        Me.btn閉じる.UseVisualStyleBackColor = True
        '
        'cmb売上区分
        '
        Me.cmb売上区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb売上区分.DropDownWidth = 335
        Me.cmb売上区分.FormattingEnabled = True
        Me.cmb売上区分.Location = New System.Drawing.Point(105, 42)
        Me.cmb売上区分.Name = "cmb売上区分"
        Me.cmb売上区分.Size = New System.Drawing.Size(163, 21)
        Me.cmb売上区分.TabIndex = 2
        '
        'dgv目標額一覧
        '
        Me.dgv目標額一覧.AllowUserToAddRows = False
        Me.dgv目標額一覧.AllowUserToDeleteRows = False
        Me.dgv目標額一覧.AllowUserToResizeColumns = False
        Me.dgv目標額一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv目標額一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv目標額一覧.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgv目標額一覧.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv目標額一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv目標額一覧.EnableHeadersVisualStyles = False
        Me.dgv目標額一覧.Location = New System.Drawing.Point(29, 184)
        Me.dgv目標額一覧.MultiSelect = False
        Me.dgv目標額一覧.Name = "dgv目標額一覧"
        Me.dgv目標額一覧.ReadOnly = True
        Me.dgv目標額一覧.RowHeadersVisible = False
        Me.dgv目標額一覧.RowTemplate.Height = 16
        Me.dgv目標額一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv目標額一覧.Size = New System.Drawing.Size(354, 180)
        Me.dgv目標額一覧.TabIndex = 11
        Me.dgv目標額一覧.TabStop = False
        '
        'txt月日数
        '
        Me.txt月日数.Location = New System.Drawing.Point(280, 151)
        Me.txt月日数.Name = "txt月日数"
        Me.txt月日数.Size = New System.Drawing.Size(75, 20)
        Me.txt月日数.TabIndex = 10
        Me.txt月日数.TabStop = False
        Me.txt月日数.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "前年度比 : "
        '
        'txt前年度比
        '
        Me.txt前年度比.BackColor = System.Drawing.Color.White
        Me.txt前年度比.Enabled = False
        Me.txt前年度比.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt前年度比.Location = New System.Drawing.Point(105, 96)
        Me.txt前年度比.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.txt前年度比.MaxLength = 3
        Me.txt前年度比.Name = "txt前年度比"
        Me.txt前年度比.Size = New System.Drawing.Size(121, 20)
        Me.txt前年度比.TabIndex = 4
        Me.txt前年度比.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(228, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "％"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "前年度目標額 : "
        '
        'lbl前年度目標額
        '
        Me.lbl前年度目標額.BackColor = System.Drawing.Color.White
        Me.lbl前年度目標額.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl前年度目標額.Location = New System.Drawing.Point(105, 69)
        Me.lbl前年度目標額.Name = "lbl前年度目標額"
        Me.lbl前年度目標額.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl前年度目標額.Size = New System.Drawing.Size(121, 20)
        Me.lbl前年度目標額.TabIndex = 3
        Me.lbl前年度目標額.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn項目クリア
        '
        Me.btn項目クリア.Location = New System.Drawing.Point(283, 56)
        Me.btn項目クリア.Name = "btn項目クリア"
        Me.btn項目クリア.Size = New System.Drawing.Size(100, 23)
        Me.btn項目クリア.TabIndex = 8
        Me.btn項目クリア.Text = "項目クリア"
        Me.btn項目クリア.UseVisualStyleBackColor = True
        '
        'btn登録
        '
        Me.btn登録.Location = New System.Drawing.Point(283, 15)
        Me.btn登録.Name = "btn登録"
        Me.btn登録.Size = New System.Drawing.Size(100, 23)
        Me.btn登録.TabIndex = 7
        Me.btn登録.Text = "変更"
        Me.btn登録.UseVisualStyleBackColor = True
        '
        'a1100_目標額
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 389)
        Me.Controls.Add(Me.btn項目クリア)
        Me.Controls.Add(Me.btn登録)
        Me.Controls.Add(Me.lbl前年度目標額)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt前年度比)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt月日数)
        Me.Controls.Add(Me.dgv目標額一覧)
        Me.Controls.Add(Me.cmb売上区分)
        Me.Controls.Add(Me.btn閉じる)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt営業日数)
        Me.Controls.Add(Me.txt目標額)
        Me.Controls.Add(Me.txt対象年月)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a1100_目標額"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 目標額"
        CType(Me.dgv目標額一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt対象年月 As System.Windows.Forms.TextBox
    Friend WithEvents txt目標額 As System.Windows.Forms.TextBox
    Friend WithEvents txt営業日数 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn閉じる As System.Windows.Forms.Button
    Friend WithEvents cmb売上区分 As System.Windows.Forms.ComboBox
    Public WithEvents dgv目標額一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents txt月日数 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt前年度比 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbl前年度目標額 As System.Windows.Forms.Label
    Friend WithEvents btn項目クリア As System.Windows.Forms.Button
    Friend WithEvents btn登録 As System.Windows.Forms.Button
End Class
