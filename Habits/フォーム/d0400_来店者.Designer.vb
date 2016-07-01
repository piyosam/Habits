<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class d0400_来店者
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(d0400_来店者))
        Me.dgv来店者一覧 = New System.Windows.Forms.DataGridView
        Me.閉じる = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblDate = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dgv来店者一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv来店者一覧
        '
        Me.dgv来店者一覧.AllowUserToAddRows = False
        Me.dgv来店者一覧.AllowUserToDeleteRows = False
        Me.dgv来店者一覧.AllowUserToResizeColumns = False
        Me.dgv来店者一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv来店者一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv来店者一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv来店者一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv来店者一覧.EnableHeadersVisualStyles = False
        Me.dgv来店者一覧.Location = New System.Drawing.Point(20, 36)
        Me.dgv来店者一覧.MultiSelect = False
        Me.dgv来店者一覧.Name = "dgv来店者一覧"
        Me.dgv来店者一覧.ReadOnly = True
        Me.dgv来店者一覧.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv来店者一覧.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv来店者一覧.RowTemplate.Height = 16
        Me.dgv来店者一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv来店者一覧.Size = New System.Drawing.Size(870, 436)
        Me.dgv来店者一覧.TabIndex = 0
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(790, 483)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 1
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "来店者一覧"
        '
        'LblDate
        '
        Me.LblDate.AutoSize = True
        Me.LblDate.Location = New System.Drawing.Point(180, 15)
        Me.LblDate.Name = "LblDate"
        Me.LblDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblDate.Size = New System.Drawing.Size(77, 13)
        Me.LblDate.TabIndex = 3
        Me.LblDate.Text = "ｙｙｙｙ/mm/dd"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(121, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "対象日 :"
        '
        'd0400_来店者
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 518)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.dgv来店者一覧)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "d0400_来店者"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 来店者一覧"
        CType(Me.dgv来店者一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Public WithEvents dgv来店者一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblDate As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
