<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class d0200_営業日
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(d0200_営業日))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.天候 = New System.Windows.Forms.ComboBox
        Me.スタッフ数 = New System.Windows.Forms.TextBox
        Me.レジ金額 = New System.Windows.Forms.TextBox
        Me.変更 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.dgv一覧 = New System.Windows.Forms.DataGridView
        Me.営業日 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.dgv一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 261)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "営業日 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "天候 :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 318)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "スタッフ数 :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 347)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "レジ金額 :"
        '
        '天候
        '
        Me.天候.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.天候.FormattingEnabled = True
        Me.天候.Location = New System.Drawing.Point(87, 284)
        Me.天候.Name = "天候"
        Me.天候.Size = New System.Drawing.Size(179, 21)
        Me.天候.TabIndex = 7
        '
        'スタッフ数
        '
        Me.スタッフ数.BackColor = System.Drawing.Color.White
        Me.スタッフ数.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.スタッフ数.Location = New System.Drawing.Point(87, 315)
        Me.スタッフ数.MaxLength = 3
        Me.スタッフ数.Name = "スタッフ数"
        Me.スタッフ数.ReadOnly = True
        Me.スタッフ数.Size = New System.Drawing.Size(108, 20)
        Me.スタッフ数.TabIndex = 8
        Me.スタッフ数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'レジ金額
        '
        Me.レジ金額.BackColor = System.Drawing.Color.White
        Me.レジ金額.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.レジ金額.Location = New System.Drawing.Point(87, 344)
        Me.レジ金額.MaxLength = 9
        Me.レジ金額.Name = "レジ金額"
        Me.レジ金額.ReadOnly = True
        Me.レジ金額.Size = New System.Drawing.Size(108, 20)
        Me.レジ金額.TabIndex = 9
        Me.レジ金額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '変更
        '
        Me.変更.Location = New System.Drawing.Point(382, 13)
        Me.変更.Name = "変更"
        Me.変更.Size = New System.Drawing.Size(100, 23)
        Me.変更.TabIndex = 10
        Me.変更.Text = "変更"
        Me.変更.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(382, 51)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 11
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'dgv一覧
        '
        Me.dgv一覧.AllowUserToAddRows = False
        Me.dgv一覧.AllowUserToDeleteRows = False
        Me.dgv一覧.AllowUserToResizeColumns = False
        Me.dgv一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv一覧.Location = New System.Drawing.Point(15, 13)
        Me.dgv一覧.MultiSelect = False
        Me.dgv一覧.Name = "dgv一覧"
        Me.dgv一覧.ReadOnly = True
        Me.dgv一覧.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv一覧.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv一覧.RowTemplate.Height = 16
        Me.dgv一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv一覧.Size = New System.Drawing.Size(356, 228)
        Me.dgv一覧.TabIndex = 12
        Me.dgv一覧.TabStop = False
        '
        '営業日
        '
        Me.営業日.BackColor = System.Drawing.Color.White
        Me.営業日.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.営業日.Location = New System.Drawing.Point(87, 258)
        Me.営業日.Name = "営業日"
        Me.営業日.Size = New System.Drawing.Size(108, 20)
        Me.営業日.TabIndex = 13
        Me.営業日.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(261, 245)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "(過去6ヶ月間表示）"
        '
        'd0200_営業日
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 378)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.営業日)
        Me.Controls.Add(Me.dgv一覧)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.変更)
        Me.Controls.Add(Me.レジ金額)
        Me.Controls.Add(Me.スタッフ数)
        Me.Controls.Add(Me.天候)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "d0200_営業日"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 営業日"
        CType(Me.dgv一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents 天候 As System.Windows.Forms.ComboBox
    Friend WithEvents スタッフ数 As System.Windows.Forms.TextBox
    Friend WithEvents レジ金額 As System.Windows.Forms.TextBox
    Friend WithEvents 変更 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Public WithEvents dgv一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents 営業日 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
