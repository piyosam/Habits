<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f1200_ポイント割引
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(f1200_ポイント割引))
        Me.dgvポイント割引一覧 = New System.Windows.Forms.DataGridView
        Me.Btn新規 = New System.Windows.Forms.Button
        Me.Btn登録 = New System.Windows.Forms.Button
        Me.Btn項目クリア = New System.Windows.Forms.Button
        Me.Btn閉じる = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.削除フラグ = New System.Windows.Forms.CheckBox
        Me.txt表示順 = New System.Windows.Forms.TextBox
        Me.txtポイント割引名 = New System.Windows.Forms.TextBox
        Me.lblポイント割引番号 = New System.Windows.Forms.Label
        CType(Me.dgvポイント割引一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvポイント割引一覧
        '
        Me.dgvポイント割引一覧.AllowUserToAddRows = False
        Me.dgvポイント割引一覧.AllowUserToDeleteRows = False
        Me.dgvポイント割引一覧.AllowUserToResizeColumns = False
        Me.dgvポイント割引一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvポイント割引一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvポイント割引一覧.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvポイント割引一覧.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvポイント割引一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvポイント割引一覧.EnableHeadersVisualStyles = False
        Me.dgvポイント割引一覧.Location = New System.Drawing.Point(18, 16)
        Me.dgvポイント割引一覧.MultiSelect = False
        Me.dgvポイント割引一覧.Name = "dgvポイント割引一覧"
        Me.dgvポイント割引一覧.ReadOnly = True
        Me.dgvポイント割引一覧.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgvポイント割引一覧.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvポイント割引一覧.RowTemplate.Height = 16
        Me.dgvポイント割引一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvポイント割引一覧.Size = New System.Drawing.Size(387, 340)
        Me.dgvポイント割引一覧.TabIndex = 2
        Me.dgvポイント割引一覧.TabStop = False
        '
        'Btn新規
        '
        Me.Btn新規.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn新規.Location = New System.Drawing.Point(415, 18)
        Me.Btn新規.Name = "Btn新規"
        Me.Btn新規.Size = New System.Drawing.Size(100, 23)
        Me.Btn新規.TabIndex = 1
        Me.Btn新規.Text = "新規"
        Me.Btn新規.UseVisualStyleBackColor = True
        '
        'Btn登録
        '
        Me.Btn登録.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn登録.Location = New System.Drawing.Point(415, 47)
        Me.Btn登録.Name = "Btn登録"
        Me.Btn登録.Size = New System.Drawing.Size(100, 23)
        Me.Btn登録.TabIndex = 7
        Me.Btn登録.Text = "変更"
        Me.Btn登録.UseVisualStyleBackColor = True
        '
        'Btn項目クリア
        '
        Me.Btn項目クリア.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn項目クリア.Location = New System.Drawing.Point(415, 89)
        Me.Btn項目クリア.Name = "Btn項目クリア"
        Me.Btn項目クリア.Size = New System.Drawing.Size(100, 23)
        Me.Btn項目クリア.TabIndex = 8
        Me.Btn項目クリア.Text = "項目クリア"
        Me.Btn項目クリア.UseVisualStyleBackColor = True
        '
        'Btn閉じる
        '
        Me.Btn閉じる.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Btn閉じる.Location = New System.Drawing.Point(415, 117)
        Me.Btn閉じる.Name = "Btn閉じる"
        Me.Btn閉じる.Size = New System.Drawing.Size(100, 23)
        Me.Btn閉じる.TabIndex = 9
        Me.Btn閉じる.Text = "閉じる"
        Me.Btn閉じる.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(11, 370)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "ポイント割引番号 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(24, 396)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "ポイント割引名 :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Location = New System.Drawing.Point(64, 420)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "表示順 :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(64, 442)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "非表示 :"
        '
        '削除フラグ
        '
        Me.削除フラグ.AutoSize = True
        Me.削除フラグ.Location = New System.Drawing.Point(123, 443)
        Me.削除フラグ.Name = "削除フラグ"
        Me.削除フラグ.Size = New System.Drawing.Size(15, 14)
        Me.削除フラグ.TabIndex = 6
        Me.削除フラグ.UseVisualStyleBackColor = True
        '
        'txt表示順
        '
        Me.txt表示順.BackColor = System.Drawing.Color.White
        Me.txt表示順.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.txt表示順.ForeColor = System.Drawing.Color.Black
        Me.txt表示順.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt表示順.Location = New System.Drawing.Point(123, 417)
        Me.txt表示順.MaxLength = 4
        Me.txt表示順.Name = "txt表示順"
        Me.txt表示順.Size = New System.Drawing.Size(59, 20)
        Me.txt表示順.TabIndex = 5
        Me.txt表示順.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtポイント割引名
        '
        Me.txtポイント割引名.BackColor = System.Drawing.Color.White
        Me.txtポイント割引名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.txtポイント割引名.ForeColor = System.Drawing.Color.Black
        Me.txtポイント割引名.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtポイント割引名.Location = New System.Drawing.Point(123, 393)
        Me.txtポイント割引名.MaxLength = 32
        Me.txtポイント割引名.Name = "txtポイント割引名"
        Me.txtポイント割引名.Size = New System.Drawing.Size(216, 20)
        Me.txtポイント割引名.TabIndex = 4
        '
        'lblポイント割引番号
        '
        Me.lblポイント割引番号.BackColor = System.Drawing.Color.White
        Me.lblポイント割引番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblポイント割引番号.Location = New System.Drawing.Point(123, 367)
        Me.lblポイント割引番号.Name = "lblポイント割引番号"
        Me.lblポイント割引番号.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lblポイント割引番号.Size = New System.Drawing.Size(59, 20)
        Me.lblポイント割引番号.TabIndex = 3
        Me.lblポイント割引番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'f1200_ポイント割引
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 466)
        Me.Controls.Add(Me.lblポイント割引番号)
        Me.Controls.Add(Me.txtポイント割引名)
        Me.Controls.Add(Me.txt表示順)
        Me.Controls.Add(Me.削除フラグ)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Btn閉じる)
        Me.Controls.Add(Me.Btn項目クリア)
        Me.Controls.Add(Me.Btn登録)
        Me.Controls.Add(Me.Btn新規)
        Me.Controls.Add(Me.dgvポイント割引一覧)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "f1200_ポイント割引"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - ポイント割引"
        CType(Me.dgvポイント割引一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn新規 As System.Windows.Forms.Button
    Friend WithEvents Btn登録 As System.Windows.Forms.Button
    Friend WithEvents Btn項目クリア As System.Windows.Forms.Button
    Friend WithEvents Btn閉じる As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents 削除フラグ As System.Windows.Forms.CheckBox
    Friend WithEvents txt表示順 As System.Windows.Forms.TextBox
    Friend WithEvents txtポイント割引名 As System.Windows.Forms.TextBox
    Public WithEvents dgvポイント割引一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents lblポイント割引番号 As System.Windows.Forms.Label
End Class
