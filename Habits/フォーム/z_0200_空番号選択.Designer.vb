<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class z_0200_空番号選択
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(z_0200_空番号選択))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt開始顧客番号 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.選択 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.dgv空番号一覧 = New System.Windows.Forms.DataGridView
        Me.lbl終了顧客番号 = New System.Windows.Forms.Label
        CType(Me.dgv空番号一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "顧客番号 :"
        '
        'txt開始顧客番号
        '
        Me.txt開始顧客番号.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt開始顧客番号.Location = New System.Drawing.Point(84, 15)
        Me.txt開始顧客番号.MaxLength = 6
        Me.txt開始顧客番号.Name = "txt開始顧客番号"
        Me.txt開始顧客番号.Size = New System.Drawing.Size(63, 20)
        Me.txt開始顧客番号.TabIndex = 1
        Me.txt開始顧客番号.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "～"
        '
        '選択
        '
        Me.選択.Location = New System.Drawing.Point(215, 49)
        Me.選択.Name = "選択"
        Me.選択.Size = New System.Drawing.Size(100, 23)
        Me.選択.TabIndex = 4
        Me.選択.Text = "選択"
        Me.選択.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(215, 85)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 5
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'dgv空番号一覧
        '
        Me.dgv空番号一覧.AllowUserToAddRows = False
        Me.dgv空番号一覧.AllowUserToDeleteRows = False
        Me.dgv空番号一覧.AllowUserToResizeColumns = False
        Me.dgv空番号一覧.AllowUserToResizeRows = False
        Me.dgv空番号一覧.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv空番号一覧.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgv空番号一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv空番号一覧.ColumnHeadersVisible = False
        Me.dgv空番号一覧.Location = New System.Drawing.Point(15, 49)
        Me.dgv空番号一覧.MultiSelect = False
        Me.dgv空番号一覧.Name = "dgv空番号一覧"
        Me.dgv空番号一覧.ReadOnly = True
        Me.dgv空番号一覧.RowHeadersVisible = False
        Me.dgv空番号一覧.RowTemplate.Height = 16
        Me.dgv空番号一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv空番号一覧.Size = New System.Drawing.Size(186, 322)
        Me.dgv空番号一覧.TabIndex = 8
        Me.dgv空番号一覧.TabStop = False
        '
        'lbl終了顧客番号
        '
        Me.lbl終了顧客番号.BackColor = System.Drawing.Color.White
        Me.lbl終了顧客番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl終了顧客番号.Location = New System.Drawing.Point(179, 15)
        Me.lbl終了顧客番号.Name = "lbl終了顧客番号"
        Me.lbl終了顧客番号.Size = New System.Drawing.Size(63, 20)
        Me.lbl終了顧客番号.TabIndex = 9
        Me.lbl終了顧客番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'z_0200_空番号選択
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 386)
        Me.Controls.Add(Me.lbl終了顧客番号)
        Me.Controls.Add(Me.dgv空番号一覧)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.選択)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt開始顧客番号)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "z_0200_空番号選択"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 空番号選択"
        CType(Me.dgv空番号一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt開始顧客番号 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 選択 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Public WithEvents dgv空番号一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents lbl終了顧客番号 As System.Windows.Forms.Label
End Class
