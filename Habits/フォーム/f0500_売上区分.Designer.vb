<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f0500_売上区分

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(f0500_売上区分))
        Me.dgv売上区分一覧 = New System.Windows.Forms.DataGridView
        Me.閉じる = New System.Windows.Forms.Button
        Me.項目クリア = New System.Windows.Forms.Button
        Me.登録 = New System.Windows.Forms.Button
        Me.新規 = New System.Windows.Forms.Button
        Me.txt売上区分 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.分類 = New System.Windows.Forms.Button
        Me.削除フラグ = New System.Windows.Forms.CheckBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txt表示順 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.売上区分番号 = New System.Windows.Forms.Label
        CType(Me.dgv売上区分一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv売上区分一覧
        '
        Me.dgv売上区分一覧.AllowUserToAddRows = False
        Me.dgv売上区分一覧.AllowUserToDeleteRows = False
        Me.dgv売上区分一覧.AllowUserToResizeColumns = False
        Me.dgv売上区分一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv売上区分一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv売上区分一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv売上区分一覧.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv売上区分一覧.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv売上区分一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv売上区分一覧.EnableHeadersVisualStyles = False
        Me.dgv売上区分一覧.Location = New System.Drawing.Point(18, 17)
        Me.dgv売上区分一覧.MultiSelect = False
        Me.dgv売上区分一覧.Name = "dgv売上区分一覧"
        Me.dgv売上区分一覧.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv売上区分一覧.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv売上区分一覧.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv売上区分一覧.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv売上区分一覧.RowTemplate.Height = 16
        Me.dgv売上区分一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv売上区分一覧.Size = New System.Drawing.Size(349, 259)
        Me.dgv売上区分一覧.TabIndex = 0
        Me.dgv売上区分一覧.TabStop = False
        '
        '閉じる
        '
        Me.閉じる.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.閉じる.Location = New System.Drawing.Point(381, 144)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 8
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        '項目クリア
        '
        Me.項目クリア.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.項目クリア.Location = New System.Drawing.Point(381, 74)
        Me.項目クリア.Name = "項目クリア"
        Me.項目クリア.Size = New System.Drawing.Size(100, 23)
        Me.項目クリア.TabIndex = 6
        Me.項目クリア.Text = "項目クリア"
        Me.項目クリア.UseVisualStyleBackColor = True
        '
        '登録
        '
        Me.登録.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.登録.Location = New System.Drawing.Point(381, 45)
        Me.登録.Name = "登録"
        Me.登録.Size = New System.Drawing.Size(100, 23)
        Me.登録.TabIndex = 5
        Me.登録.Text = "変更"
        Me.登録.UseVisualStyleBackColor = True
        '
        '新規
        '
        Me.新規.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.新規.Location = New System.Drawing.Point(381, 16)
        Me.新規.Name = "新規"
        Me.新規.Size = New System.Drawing.Size(100, 23)
        Me.新規.TabIndex = 1
        Me.新規.Text = "新規"
        Me.新規.UseVisualStyleBackColor = True
        '
        'txt売上区分
        '
        Me.txt売上区分.BackColor = System.Drawing.Color.White
        Me.txt売上区分.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.txt売上区分.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txt売上区分.Location = New System.Drawing.Point(117, 313)
        Me.txt売上区分.MaxLength = 20
        Me.txt売上区分.Name = "txt売上区分"
        Me.txt売上区分.Size = New System.Drawing.Size(250, 20)
        Me.txt売上区分.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 311)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 20)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "売上区分 :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 285)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "売上区分番号 :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '分類
        '
        Me.分類.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.分類.Location = New System.Drawing.Point(381, 103)
        Me.分類.Name = "分類"
        Me.分類.Size = New System.Drawing.Size(100, 23)
        Me.分類.TabIndex = 7
        Me.分類.Text = "分類"
        Me.分類.UseVisualStyleBackColor = True
        '
        '削除フラグ
        '
        Me.削除フラグ.AutoSize = True
        Me.削除フラグ.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.削除フラグ.Location = New System.Drawing.Point(117, 363)
        Me.削除フラグ.Name = "削除フラグ"
        Me.削除フラグ.Size = New System.Drawing.Size(15, 14)
        Me.削除フラグ.TabIndex = 4
        Me.削除フラグ.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(16, 358)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 20)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "非表示 :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt表示順
        '
        Me.txt表示順.BackColor = System.Drawing.Color.White
        Me.txt表示順.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.txt表示順.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt表示順.Location = New System.Drawing.Point(117, 338)
        Me.txt表示順.MaxLength = 4
        Me.txt表示順.Name = "txt表示順"
        Me.txt表示順.Size = New System.Drawing.Size(54, 20)
        Me.txt表示順.TabIndex = 3
        Me.txt表示順.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.Location = New System.Drawing.Point(16, 336)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 20)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "表示順 :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '売上区分番号
        '
        Me.売上区分番号.BackColor = System.Drawing.Color.White
        Me.売上区分番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.売上区分番号.Location = New System.Drawing.Point(117, 288)
        Me.売上区分番号.Margin = New System.Windows.Forms.Padding(3)
        Me.売上区分番号.Name = "売上区分番号"
        Me.売上区分番号.Size = New System.Drawing.Size(54, 20)
        Me.売上区分番号.TabIndex = 0
        Me.売上区分番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'f0500_売上区分
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 392)
        Me.Controls.Add(Me.売上区分番号)
        Me.Controls.Add(Me.txt表示順)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.削除フラグ)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.分類)
        Me.Controls.Add(Me.txt売上区分)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.項目クリア)
        Me.Controls.Add(Me.登録)
        Me.Controls.Add(Me.新規)
        Me.Controls.Add(Me.dgv売上区分一覧)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "f0500_売上区分"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 売上区分"
        CType(Me.dgv売上区分一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv売上区分一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents 項目クリア As System.Windows.Forms.Button
    Friend WithEvents 登録 As System.Windows.Forms.Button
    Friend WithEvents 新規 As System.Windows.Forms.Button
    Friend WithEvents txt売上区分 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 分類 As System.Windows.Forms.Button
    Friend WithEvents 削除フラグ As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt表示順 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents 売上区分番号 As System.Windows.Forms.Label
End Class
