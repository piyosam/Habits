<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f0600_スタッフ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(f0600_スタッフ))
        Me.担当者一覧 = New System.Windows.Forms.DataGridView
        Me.新規 = New System.Windows.Forms.Button
        Me.登録 = New System.Windows.Forms.Button
        Me.項目クリア = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.担当者名 = New System.Windows.Forms.TextBox
        Me.表示順 = New System.Windows.Forms.TextBox
        Me.削除フラグ = New System.Windows.Forms.CheckBox
        Me.全件表示 = New System.Windows.Forms.CheckBox
        Me.lbl担当者番号 = New System.Windows.Forms.Label
        CType(Me.担当者一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '担当者一覧
        '
        Me.担当者一覧.AllowUserToAddRows = False
        Me.担当者一覧.AllowUserToDeleteRows = False
        Me.担当者一覧.AllowUserToResizeColumns = False
        Me.担当者一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.担当者一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.担当者一覧.BackgroundColor = System.Drawing.Color.White
        Me.担当者一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.担当者一覧.EnableHeadersVisualStyles = False
        Me.担当者一覧.Location = New System.Drawing.Point(18, 16)
        Me.担当者一覧.MultiSelect = False
        Me.担当者一覧.Name = "担当者一覧"
        Me.担当者一覧.ReadOnly = True
        Me.担当者一覧.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.担当者一覧.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.担当者一覧.RowTemplate.Height = 16
        Me.担当者一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.担当者一覧.Size = New System.Drawing.Size(383, 340)
        Me.担当者一覧.TabIndex = 2
        Me.担当者一覧.TabStop = False
        '
        '新規
        '
        Me.新規.Location = New System.Drawing.Point(418, 16)
        Me.新規.Name = "新規"
        Me.新規.Size = New System.Drawing.Size(100, 23)
        Me.新規.TabIndex = 1
        Me.新規.Text = "新規"
        Me.新規.UseVisualStyleBackColor = True
        '
        '登録
        '
        Me.登録.Location = New System.Drawing.Point(418, 45)
        Me.登録.Name = "登録"
        Me.登録.Size = New System.Drawing.Size(100, 23)
        Me.登録.TabIndex = 7
        Me.登録.Text = "変更"
        Me.登録.UseVisualStyleBackColor = True
        '
        '項目クリア
        '
        Me.項目クリア.Location = New System.Drawing.Point(418, 86)
        Me.項目クリア.Name = "項目クリア"
        Me.項目クリア.Size = New System.Drawing.Size(100, 23)
        Me.項目クリア.TabIndex = 8
        Me.項目クリア.Text = "項目クリア"
        Me.項目クリア.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(418, 115)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 9
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 371)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "スタッフ番号 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 397)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "スタッフ名 :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 422)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "表示順 :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 445)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "非表示 :"
        '
        '担当者名
        '
        Me.担当者名.BackColor = System.Drawing.Color.White
        Me.担当者名.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.担当者名.Location = New System.Drawing.Point(100, 394)
        Me.担当者名.MaxLength = 32
        Me.担当者名.Name = "担当者名"
        Me.担当者名.Size = New System.Drawing.Size(234, 20)
        Me.担当者名.TabIndex = 4
        '
        '表示順
        '
        Me.表示順.BackColor = System.Drawing.Color.White
        Me.表示順.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.表示順.Location = New System.Drawing.Point(100, 419)
        Me.表示順.MaxLength = 4
        Me.表示順.Name = "表示順"
        Me.表示順.Size = New System.Drawing.Size(48, 20)
        Me.表示順.TabIndex = 5
        Me.表示順.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '削除フラグ
        '
        Me.削除フラグ.AutoSize = True
        Me.削除フラグ.Location = New System.Drawing.Point(100, 445)
        Me.削除フラグ.Name = "削除フラグ"
        Me.削除フラグ.Size = New System.Drawing.Size(15, 14)
        Me.削除フラグ.TabIndex = 6
        Me.削除フラグ.UseVisualStyleBackColor = True
        '
        '全件表示
        '
        Me.全件表示.AutoSize = True
        Me.全件表示.Location = New System.Drawing.Point(418, 148)
        Me.全件表示.Name = "全件表示"
        Me.全件表示.Size = New System.Drawing.Size(90, 17)
        Me.全件表示.TabIndex = 10
        Me.全件表示.Text = "非表示含む"
        Me.全件表示.UseVisualStyleBackColor = True
        '
        'lbl担当者番号
        '
        Me.lbl担当者番号.BackColor = System.Drawing.Color.White
        Me.lbl担当者番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl担当者番号.Location = New System.Drawing.Point(100, 368)
        Me.lbl担当者番号.Name = "lbl担当者番号"
        Me.lbl担当者番号.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl担当者番号.Size = New System.Drawing.Size(47, 20)
        Me.lbl担当者番号.TabIndex = 3
        Me.lbl担当者番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'f0600_スタッフ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(535, 472)
        Me.Controls.Add(Me.lbl担当者番号)
        Me.Controls.Add(Me.全件表示)
        Me.Controls.Add(Me.削除フラグ)
        Me.Controls.Add(Me.表示順)
        Me.Controls.Add(Me.担当者名)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.項目クリア)
        Me.Controls.Add(Me.登録)
        Me.Controls.Add(Me.新規)
        Me.Controls.Add(Me.担当者一覧)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "f0600_スタッフ"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - スタッフ"
        CType(Me.担当者一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 担当者一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents 新規 As System.Windows.Forms.Button
    Friend WithEvents 登録 As System.Windows.Forms.Button
    Friend WithEvents 項目クリア As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents 担当者名 As System.Windows.Forms.TextBox
    Friend WithEvents 表示順 As System.Windows.Forms.TextBox
    Friend WithEvents 削除フラグ As System.Windows.Forms.CheckBox
    Friend WithEvents 全件表示 As System.Windows.Forms.CheckBox
    Friend WithEvents lbl担当者番号 As System.Windows.Forms.Label
End Class
