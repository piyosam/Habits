<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class h0400_未登録者
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(h0400_未登録者))
        Me.未登録者一覧 = New System.Windows.Forms.DataGridView
        Me.変更 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.仮登録 = New System.Windows.Forms.Button
        Me.chk区分 = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.未登録者一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '未登録者一覧
        '
        Me.未登録者一覧.AllowUserToAddRows = False
        Me.未登録者一覧.AllowUserToDeleteRows = False
        Me.未登録者一覧.AllowUserToResizeColumns = False
        Me.未登録者一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.未登録者一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.未登録者一覧.BackgroundColor = System.Drawing.Color.White
        Me.未登録者一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.未登録者一覧.EnableHeadersVisualStyles = False
        Me.未登録者一覧.Location = New System.Drawing.Point(20, 32)
        Me.未登録者一覧.MultiSelect = False
        Me.未登録者一覧.Name = "未登録者一覧"
        Me.未登録者一覧.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.未登録者一覧.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.未登録者一覧.RowHeadersVisible = False
        Me.未登録者一覧.RowTemplate.Height = 16
        Me.未登録者一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.未登録者一覧.Size = New System.Drawing.Size(406, 339)
        Me.未登録者一覧.TabIndex = 0
        Me.未登録者一覧.TabStop = False
        '
        '変更
        '
        Me.変更.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.変更.Location = New System.Drawing.Point(443, 32)
        Me.変更.Name = "変更"
        Me.変更.Size = New System.Drawing.Size(100, 23)
        Me.変更.TabIndex = 1
        Me.変更.Text = "変更"
        Me.変更.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.閉じる.Location = New System.Drawing.Point(443, 109)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 3
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        '仮登録
        '
        Me.仮登録.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.仮登録.Location = New System.Drawing.Point(443, 61)
        Me.仮登録.Name = "仮登録"
        Me.仮登録.Size = New System.Drawing.Size(100, 23)
        Me.仮登録.TabIndex = 2
        Me.仮登録.Text = "仮登録"
        Me.仮登録.UseVisualStyleBackColor = True
        '
        'chk区分
        '
        Me.chk区分.AutoSize = True
        Me.chk区分.Location = New System.Drawing.Point(22, 386)
        Me.chk区分.Name = "chk区分"
        Me.chk区分.Size = New System.Drawing.Size(122, 16)
        Me.chk区分.TabIndex = 0
        Me.chk区分.Text = "仮登録データを除く"
        Me.chk区分.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "住所未登録者一覧 :"
        '
        'h0400_未登録者
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 415)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chk区分)
        Me.Controls.Add(Me.仮登録)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.変更)
        Me.Controls.Add(Me.未登録者一覧)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "h0400_未登録者"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABTIS - 住所未登録者"
        CType(Me.未登録者一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 変更 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Public WithEvents 未登録者一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents 仮登録 As System.Windows.Forms.Button
    Friend WithEvents chk区分 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
