<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f1100_工程マスタ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(f1100_工程マスタ))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.工程名 = New System.Windows.Forms.TextBox
        Me.ポイント = New System.Windows.Forms.TextBox
        Me.登録済データ = New System.Windows.Forms.DataGridView
        Me.登録 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.新規 = New System.Windows.Forms.Button
        Me.項目クリア = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.削除フラグ = New System.Windows.Forms.CheckBox
        Me.表示順 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl工程番号 = New System.Windows.Forms.Label
        CType(Me.登録済データ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 371)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "工程番号 :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 398)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "工程名 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 424)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ポイント :"
        '
        '工程名
        '
        Me.工程名.BackColor = System.Drawing.Color.White
        Me.工程名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.工程名.ForeColor = System.Drawing.Color.Black
        Me.工程名.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.工程名.Location = New System.Drawing.Point(90, 395)
        Me.工程名.MaxLength = 32
        Me.工程名.Name = "工程名"
        Me.工程名.Size = New System.Drawing.Size(348, 20)
        Me.工程名.TabIndex = 2
        '
        'ポイント
        '
        Me.ポイント.BackColor = System.Drawing.Color.White
        Me.ポイント.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.ポイント.ForeColor = System.Drawing.Color.Black
        Me.ポイント.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ポイント.Location = New System.Drawing.Point(90, 421)
        Me.ポイント.MaxLength = 4
        Me.ポイント.Name = "ポイント"
        Me.ポイント.Size = New System.Drawing.Size(59, 20)
        Me.ポイント.TabIndex = 3
        Me.ポイント.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '登録済データ
        '
        Me.登録済データ.AllowUserToAddRows = False
        Me.登録済データ.AllowUserToDeleteRows = False
        Me.登録済データ.AllowUserToResizeColumns = False
        Me.登録済データ.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.登録済データ.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.登録済データ.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.登録済データ.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.登録済データ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.登録済データ.EnableHeadersVisualStyles = False
        Me.登録済データ.Location = New System.Drawing.Point(18, 16)
        Me.登録済データ.MultiSelect = False
        Me.登録済データ.Name = "登録済データ"
        Me.登録済データ.ReadOnly = True
        Me.登録済データ.RowHeadersVisible = False
        Me.登録済データ.RowTemplate.Height = 21
        Me.登録済データ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.登録済データ.Size = New System.Drawing.Size(418, 339)
        Me.登録済データ.TabIndex = 0
        Me.登録済データ.TabStop = False
        '
        '登録
        '
        Me.登録.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.登録.Location = New System.Drawing.Point(449, 46)
        Me.登録.Name = "登録"
        Me.登録.Size = New System.Drawing.Size(100, 23)
        Me.登録.TabIndex = 7
        Me.登録.Text = "登録"
        Me.登録.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.閉じる.Location = New System.Drawing.Point(449, 116)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 9
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        '新規
        '
        Me.新規.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.新規.Location = New System.Drawing.Point(449, 17)
        Me.新規.Name = "新規"
        Me.新規.Size = New System.Drawing.Size(100, 23)
        Me.新規.TabIndex = 1
        Me.新規.Text = "新規"
        Me.新規.UseVisualStyleBackColor = True
        '
        '項目クリア
        '
        Me.項目クリア.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.項目クリア.Location = New System.Drawing.Point(449, 87)
        Me.項目クリア.Name = "項目クリア"
        Me.項目クリア.Size = New System.Drawing.Size(100, 23)
        Me.項目クリア.TabIndex = 8
        Me.項目クリア.Text = "項目クリア"
        Me.項目クリア.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(31, 475)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "非表示 :"
        '
        '削除フラグ
        '
        Me.削除フラグ.AutoSize = True
        Me.削除フラグ.Location = New System.Drawing.Point(90, 476)
        Me.削除フラグ.Name = "削除フラグ"
        Me.削除フラグ.Size = New System.Drawing.Size(15, 14)
        Me.削除フラグ.TabIndex = 5
        Me.削除フラグ.UseVisualStyleBackColor = True
        '
        '表示順
        '
        Me.表示順.BackColor = System.Drawing.Color.White
        Me.表示順.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.表示順.ForeColor = System.Drawing.Color.Black
        Me.表示順.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.表示順.Location = New System.Drawing.Point(90, 447)
        Me.表示順.MaxLength = 4
        Me.表示順.Name = "表示順"
        Me.表示順.Size = New System.Drawing.Size(59, 20)
        Me.表示順.TabIndex = 4
        Me.表示順.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(31, 450)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "表示順 :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl工程番号
        '
        Me.lbl工程番号.BackColor = System.Drawing.Color.White
        Me.lbl工程番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl工程番号.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbl工程番号.Location = New System.Drawing.Point(90, 368)
        Me.lbl工程番号.Name = "lbl工程番号"
        Me.lbl工程番号.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl工程番号.Size = New System.Drawing.Size(59, 20)
        Me.lbl工程番号.TabIndex = 0
        Me.lbl工程番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'f1100_工程マスタ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 505)
        Me.Controls.Add(Me.lbl工程番号)
        Me.Controls.Add(Me.表示順)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.削除フラグ)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.項目クリア)
        Me.Controls.Add(Me.新規)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.登録)
        Me.Controls.Add(Me.登録済データ)
        Me.Controls.Add(Me.ポイント)
        Me.Controls.Add(Me.工程名)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "f1100_工程マスタ"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 工程登録"
        CType(Me.登録済データ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents 工程名 As System.Windows.Forms.TextBox
    Friend WithEvents ポイント As System.Windows.Forms.TextBox
    Friend WithEvents 登録済データ As System.Windows.Forms.DataGridView
    Friend WithEvents 登録 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents 新規 As System.Windows.Forms.Button
    Friend WithEvents 項目クリア As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents 削除フラグ As System.Windows.Forms.CheckBox
    Friend WithEvents 表示順 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl工程番号 As System.Windows.Forms.Label
End Class
