<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a1300_カルテ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a1300_カルテ))
        Me.閉じる = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.登録 = New System.Windows.Forms.Button
        Me.登録者番号 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.カルテ = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.コピー = New System.Windows.Forms.Button
        Me.変更 = New System.Windows.Forms.Button
        Me.過去カルテ = New System.Windows.Forms.TextBox
        Me.dgv来店日一覧 = New System.Windows.Forms.DataGridView
        Me.来店者番号 = New System.Windows.Forms.TextBox
        Me.担当者名 = New System.Windows.Forms.TextBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv来店日一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(343, 16)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 4
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(14, 208)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(446, 166)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.登録)
        Me.TabPage1.Controls.Add(Me.登録者番号)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.カルテ)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(438, 140)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "　新　規　"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        '登録
        '
        Me.登録.Location = New System.Drawing.Point(325, 16)
        Me.登録.Name = "登録"
        Me.登録.Size = New System.Drawing.Size(100, 23)
        Me.登録.TabIndex = 3
        Me.登録.Text = "登録"
        Me.登録.UseVisualStyleBackColor = True
        '
        '登録者番号
        '
        Me.登録者番号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.登録者番号.DropDownWidth = 450
        Me.登録者番号.FormattingEnabled = True
        Me.登録者番号.Location = New System.Drawing.Point(102, 110)
        Me.登録者番号.Name = "登録者番号"
        Me.登録者番号.Size = New System.Drawing.Size(209, 21)
        Me.登録者番号.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "登録スタッフ : "
        '
        'カルテ
        '
        Me.カルテ.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.カルテ.Location = New System.Drawing.Point(15, 16)
        Me.カルテ.MaxLength = 256
        Me.カルテ.Multiline = True
        Me.カルテ.Name = "カルテ"
        Me.カルテ.Size = New System.Drawing.Size(296, 85)
        Me.カルテ.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.コピー)
        Me.TabPage2.Controls.Add(Me.変更)
        Me.TabPage2.Controls.Add(Me.過去カルテ)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(438, 140)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "　過　去　"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'コピー
        '
        Me.コピー.Location = New System.Drawing.Point(325, 47)
        Me.コピー.Name = "コピー"
        Me.コピー.Size = New System.Drawing.Size(100, 23)
        Me.コピー.TabIndex = 3
        Me.コピー.Text = "新規へコピー"
        Me.コピー.UseVisualStyleBackColor = True
        '
        '変更
        '
        Me.変更.Location = New System.Drawing.Point(325, 16)
        Me.変更.Name = "変更"
        Me.変更.Size = New System.Drawing.Size(100, 23)
        Me.変更.TabIndex = 2
        Me.変更.Text = "変更"
        Me.変更.UseVisualStyleBackColor = True
        '
        '過去カルテ
        '
        Me.過去カルテ.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.過去カルテ.Location = New System.Drawing.Point(15, 16)
        Me.過去カルテ.MaxLength = 256
        Me.過去カルテ.Multiline = True
        Me.過去カルテ.Name = "過去カルテ"
        Me.過去カルテ.Size = New System.Drawing.Size(296, 85)
        Me.過去カルテ.TabIndex = 1
        '
        'dgv来店日一覧
        '
        Me.dgv来店日一覧.AllowUserToAddRows = False
        Me.dgv来店日一覧.AllowUserToDeleteRows = False
        Me.dgv来店日一覧.AllowUserToResizeColumns = False
        Me.dgv来店日一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv来店日一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv来店日一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv来店日一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv来店日一覧.Location = New System.Drawing.Point(14, 15)
        Me.dgv来店日一覧.MultiSelect = False
        Me.dgv来店日一覧.Name = "dgv来店日一覧"
        Me.dgv来店日一覧.ReadOnly = True
        Me.dgv来店日一覧.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv来店日一覧.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv来店日一覧.RowTemplate.Height = 16
        Me.dgv来店日一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv来店日一覧.Size = New System.Drawing.Size(257, 180)
        Me.dgv来店日一覧.TabIndex = 0
        '
        '来店者番号
        '
        Me.来店者番号.Location = New System.Drawing.Point(307, 161)
        Me.来店者番号.Name = "来店者番号"
        Me.来店者番号.ReadOnly = True
        Me.来店者番号.Size = New System.Drawing.Size(100, 20)
        Me.来店者番号.TabIndex = 4
        Me.来店者番号.Visible = False
        '
        '担当者名
        '
        Me.担当者名.Location = New System.Drawing.Point(307, 135)
        Me.担当者名.Name = "担当者名"
        Me.担当者名.ReadOnly = True
        Me.担当者名.Size = New System.Drawing.Size(100, 20)
        Me.担当者名.TabIndex = 5
        Me.担当者名.Visible = False
        '
        'a1300_カルテ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 389)
        Me.Controls.Add(Me.担当者名)
        Me.Controls.Add(Me.来店者番号)
        Me.Controls.Add(Me.dgv来店日一覧)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.閉じる)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a1300_カルテ"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - カルテ入力"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgv来店日一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents カルテ As System.Windows.Forms.TextBox
    Friend WithEvents 過去カルテ As System.Windows.Forms.TextBox
    Friend WithEvents 登録 As System.Windows.Forms.Button
    Friend WithEvents 登録者番号 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents コピー As System.Windows.Forms.Button
    Friend WithEvents 変更 As System.Windows.Forms.Button
    Public WithEvents dgv来店日一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents 来店者番号 As System.Windows.Forms.TextBox
    Friend WithEvents 担当者名 As System.Windows.Forms.TextBox
End Class
