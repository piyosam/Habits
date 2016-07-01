<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a1400_入出庫
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a1400_入出庫))
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.dgv商品 = New System.Windows.Forms.DataGridView
        Me.dgv売上区分 = New System.Windows.Forms.DataGridView
        Me.dgv分類 = New System.Windows.Forms.DataGridView
        Me.dgvメーカー = New System.Windows.Forms.DataGridView
        Me.閉じる = New System.Windows.Forms.Button
        Me.項目クリア = New System.Windows.Forms.Button
        Me.btn選択 = New System.Windows.Forms.Button
        CType(Me.dgv商品, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv売上区分, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv分類, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvメーカー, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "売上区分選択 : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(246, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "分類選択 : "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(475, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "メーカー選択 : "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 211)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 43
        Me.Label10.Text = "商品選択 :"
        '
        'dgv商品
        '
        Me.dgv商品.AllowUserToAddRows = False
        Me.dgv商品.AllowUserToDeleteRows = False
        Me.dgv商品.AllowUserToResizeColumns = False
        Me.dgv商品.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv商品.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv商品.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv商品.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv商品.EnableHeadersVisualStyles = False
        Me.dgv商品.Location = New System.Drawing.Point(15, 228)
        Me.dgv商品.MultiSelect = False
        Me.dgv商品.Name = "dgv商品"
        Me.dgv商品.ReadOnly = True
        Me.dgv商品.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv商品.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv商品.RowTemplate.Height = 16
        Me.dgv商品.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv商品.ShowCellErrors = False
        Me.dgv商品.Size = New System.Drawing.Size(873, 280)
        Me.dgv商品.TabIndex = 5
        Me.dgv商品.TabStop = False
        '
        'dgv売上区分
        '
        Me.dgv売上区分.AllowUserToAddRows = False
        Me.dgv売上区分.AllowUserToDeleteRows = False
        Me.dgv売上区分.AllowUserToResizeColumns = False
        Me.dgv売上区分.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv売上区分.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv売上区分.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv売上区分.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv売上区分.ColumnHeadersVisible = False
        Me.dgv売上区分.Location = New System.Drawing.Point(17, 31)
        Me.dgv売上区分.MultiSelect = False
        Me.dgv売上区分.Name = "dgv売上区分"
        Me.dgv売上区分.ReadOnly = True
        Me.dgv売上区分.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv売上区分.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv売上区分.RowTemplate.Height = 16
        Me.dgv売上区分.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv売上区分.ShowCellErrors = False
        Me.dgv売上区分.Size = New System.Drawing.Size(211, 163)
        Me.dgv売上区分.TabIndex = 52
        Me.dgv売上区分.TabStop = False
        '
        'dgv分類
        '
        Me.dgv分類.AllowUserToAddRows = False
        Me.dgv分類.AllowUserToDeleteRows = False
        Me.dgv分類.AllowUserToResizeColumns = False
        Me.dgv分類.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv分類.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv分類.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv分類.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv分類.ColumnHeadersVisible = False
        Me.dgv分類.Location = New System.Drawing.Point(246, 31)
        Me.dgv分類.MultiSelect = False
        Me.dgv分類.Name = "dgv分類"
        Me.dgv分類.ReadOnly = True
        Me.dgv分類.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv分類.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv分類.RowTemplate.Height = 16
        Me.dgv分類.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv分類.ShowCellErrors = False
        Me.dgv分類.Size = New System.Drawing.Size(211, 163)
        Me.dgv分類.TabIndex = 53
        Me.dgv分類.TabStop = False
        '
        'dgvメーカー
        '
        Me.dgvメーカー.AllowUserToAddRows = False
        Me.dgvメーカー.AllowUserToDeleteRows = False
        Me.dgvメーカー.AllowUserToResizeColumns = False
        Me.dgvメーカー.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvメーカー.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvメーカー.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvメーカー.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvメーカー.ColumnHeadersVisible = False
        Me.dgvメーカー.Location = New System.Drawing.Point(475, 31)
        Me.dgvメーカー.MultiSelect = False
        Me.dgvメーカー.Name = "dgvメーカー"
        Me.dgvメーカー.ReadOnly = True
        Me.dgvメーカー.RowHeadersVisible = False
        DataGridViewCellStyle8.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgvメーカー.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvメーカー.RowTemplate.Height = 16
        Me.dgvメーカー.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvメーカー.ShowCellErrors = False
        Me.dgvメーカー.Size = New System.Drawing.Size(211, 163)
        Me.dgvメーカー.TabIndex = 54
        Me.dgvメーカー.TabStop = False
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(742, 101)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 2
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        '項目クリア
        '
        Me.項目クリア.Location = New System.Drawing.Point(742, 72)
        Me.項目クリア.Name = "項目クリア"
        Me.項目クリア.Size = New System.Drawing.Size(100, 23)
        Me.項目クリア.TabIndex = 1
        Me.項目クリア.Text = "項目クリア"
        Me.項目クリア.UseVisualStyleBackColor = True
        '
        'btn選択
        '
        Me.btn選択.Location = New System.Drawing.Point(742, 31)
        Me.btn選択.Name = "btn選択"
        Me.btn選択.Size = New System.Drawing.Size(100, 23)
        Me.btn選択.TabIndex = 55
        Me.btn選択.Text = "選択"
        Me.btn選択.UseVisualStyleBackColor = True
        '
        'a1400_入出庫
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 527)
        Me.Controls.Add(Me.btn選択)
        Me.Controls.Add(Me.項目クリア)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.dgvメーカー)
        Me.Controls.Add(Me.dgv分類)
        Me.Controls.Add(Me.dgv売上区分)
        Me.Controls.Add(Me.dgv商品)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a1400_入出庫"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 入出庫"
        CType(Me.dgv商品, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv売上区分, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv分類, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvメーカー, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgv商品 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv売上区分 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv分類 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvメーカー As System.Windows.Forms.DataGridView
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents 項目クリア As System.Windows.Forms.Button
    Friend WithEvents btn選択 As System.Windows.Forms.Button
End Class
