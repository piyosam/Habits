<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class h0200_確認
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(h0200_確認))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.全選択 = New System.Windows.Forms.Button
        Me.全解除 = New System.Windows.Forms.Button
        Me.出力 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(15, 15)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.RowTemplate.Height = 16
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(871, 560)
        Me.DataGridView1.TabIndex = 0
        '
        '全選択
        '
        Me.全選択.Location = New System.Drawing.Point(900, 15)
        Me.全選択.Name = "全選択"
        Me.全選択.Size = New System.Drawing.Size(100, 23)
        Me.全選択.TabIndex = 1
        Me.全選択.Text = "全て選択"
        Me.全選択.UseVisualStyleBackColor = True
        '
        '全解除
        '
        Me.全解除.Location = New System.Drawing.Point(900, 44)
        Me.全解除.Name = "全解除"
        Me.全解除.Size = New System.Drawing.Size(100, 23)
        Me.全解除.TabIndex = 2
        Me.全解除.Text = "全て解除"
        Me.全解除.UseVisualStyleBackColor = True
        '
        '出力
        '
        Me.出力.Location = New System.Drawing.Point(900, 89)
        Me.出力.Name = "出力"
        Me.出力.Size = New System.Drawing.Size(100, 23)
        Me.出力.TabIndex = 3
        Me.出力.Text = "Excel出力"
        Me.出力.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(900, 118)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 5
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'h0200_確認
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 590)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.出力)
        Me.Controls.Add(Me.全解除)
        Me.Controls.Add(Me.全選択)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "h0200_確認"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 確認"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents 全選択 As System.Windows.Forms.Button
    Friend WithEvents 全解除 As System.Windows.Forms.Button
    Friend WithEvents 出力 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
End Class
