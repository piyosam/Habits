<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a1600_発注画面
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a1600_発注画面))
        Me.dgv発注一覧 = New System.Windows.Forms.DataGridView
        Me.Excel出力 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        CType(Me.dgv発注一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv発注一覧
        '
        Me.dgv発注一覧.AllowUserToAddRows = False
        Me.dgv発注一覧.AllowUserToDeleteRows = False
        Me.dgv発注一覧.AllowUserToResizeColumns = False
        Me.dgv発注一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv発注一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv発注一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv発注一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv発注一覧.EnableHeadersVisualStyles = False
        Me.dgv発注一覧.Location = New System.Drawing.Point(14, 16)
        Me.dgv発注一覧.MultiSelect = False
        Me.dgv発注一覧.Name = "dgv発注一覧"
        Me.dgv発注一覧.ReadOnly = True
        Me.dgv発注一覧.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv発注一覧.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv発注一覧.RowTemplate.Height = 16
        Me.dgv発注一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv発注一覧.Size = New System.Drawing.Size(879, 499)
        Me.dgv発注一覧.TabIndex = 0
        Me.dgv発注一覧.TabStop = False
        '
        'Excel出力
        '
        Me.Excel出力.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.Excel出力.Location = New System.Drawing.Point(903, 16)
        Me.Excel出力.Name = "Excel出力"
        Me.Excel出力.Size = New System.Drawing.Size(100, 23)
        Me.Excel出力.TabIndex = 1
        Me.Excel出力.Text = "Excel出力"
        Me.Excel出力.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.閉じる.Location = New System.Drawing.Point(903, 52)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 2
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'a1600_発注画面
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 529)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.Excel出力)
        Me.Controls.Add(Me.dgv発注一覧)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a1600_発注画面"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 発注確認"
        CType(Me.dgv発注一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv発注一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents Excel出力 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
End Class
