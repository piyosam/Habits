<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a1900_メッセージ一覧
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a1900_メッセージ一覧))
        Me.bnt閉じる = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn確認 = New System.Windows.Forms.Button
        Me.tabMessageList = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgv一覧_受信 = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgv一覧_送信 = New System.Windows.Forms.DataGridView
        Me.lbl送信者 = New System.Windows.Forms.Label
        Me.lbl件名 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lbl本文 = New System.Windows.Forms.Label
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.lbl送信日付 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tabMessageList.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgv一覧_受信, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgv一覧_送信, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bnt閉じる
        '
        Me.bnt閉じる.Location = New System.Drawing.Point(483, 308)
        Me.bnt閉じる.Name = "bnt閉じる"
        Me.bnt閉じる.Size = New System.Drawing.Size(100, 23)
        Me.bnt閉じる.TabIndex = 7
        Me.bnt閉じる.Text = "閉じる"
        Me.bnt閉じる.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 249)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "本文 :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "件名 :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "送信者 :"
        '
        'btn確認
        '
        Me.btn確認.Location = New System.Drawing.Point(483, 266)
        Me.btn確認.Name = "btn確認"
        Me.btn確認.Size = New System.Drawing.Size(100, 23)
        Me.btn確認.TabIndex = 6
        Me.btn確認.Text = "確認"
        Me.btn確認.UseVisualStyleBackColor = True
        '
        'tabMessageList
        '
        Me.tabMessageList.Controls.Add(Me.TabPage1)
        Me.tabMessageList.Controls.Add(Me.TabPage2)
        Me.tabMessageList.Location = New System.Drawing.Point(17, 15)
        Me.tabMessageList.Name = "tabMessageList"
        Me.tabMessageList.SelectedIndex = 0
        Me.tabMessageList.Size = New System.Drawing.Size(567, 133)
        Me.tabMessageList.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgv一覧_受信)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(559, 107)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "　　受　信　　"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgv一覧_受信
        '
        Me.dgv一覧_受信.AllowUserToAddRows = False
        Me.dgv一覧_受信.AllowUserToDeleteRows = False
        Me.dgv一覧_受信.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv一覧_受信.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv一覧_受信.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv一覧_受信.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv一覧_受信.EnableHeadersVisualStyles = False
        Me.dgv一覧_受信.Location = New System.Drawing.Point(13, 11)
        Me.dgv一覧_受信.MultiSelect = False
        Me.dgv一覧_受信.Name = "dgv一覧_受信"
        Me.dgv一覧_受信.ReadOnly = True
        Me.dgv一覧_受信.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!)
        Me.dgv一覧_受信.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv一覧_受信.RowTemplate.Height = 16
        Me.dgv一覧_受信.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv一覧_受信.ShowCellErrors = False
        Me.dgv一覧_受信.Size = New System.Drawing.Size(531, 84)
        Me.dgv一覧_受信.TabIndex = 66
        Me.dgv一覧_受信.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgv一覧_送信)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(559, 107)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "　　送　信　　"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgv一覧_送信
        '
        Me.dgv一覧_送信.AllowUserToAddRows = False
        Me.dgv一覧_送信.AllowUserToDeleteRows = False
        Me.dgv一覧_送信.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv一覧_送信.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv一覧_送信.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgv一覧_送信.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv一覧_送信.EnableHeadersVisualStyles = False
        Me.dgv一覧_送信.Location = New System.Drawing.Point(13, 11)
        Me.dgv一覧_送信.MultiSelect = False
        Me.dgv一覧_送信.Name = "dgv一覧_送信"
        Me.dgv一覧_送信.ReadOnly = True
        Me.dgv一覧_送信.RowHeadersVisible = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv一覧_送信.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv一覧_送信.RowTemplate.Height = 16
        Me.dgv一覧_送信.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv一覧_送信.ShowCellErrors = False
        Me.dgv一覧_送信.Size = New System.Drawing.Size(531, 84)
        Me.dgv一覧_送信.TabIndex = 78
        Me.dgv一覧_送信.TabStop = False
        '
        'lbl送信者
        '
        Me.lbl送信者.BackColor = System.Drawing.Color.White
        Me.lbl送信者.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl送信者.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!)
        Me.lbl送信者.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl送信者.Location = New System.Drawing.Point(17, 171)
        Me.lbl送信者.Name = "lbl送信者"
        Me.lbl送信者.Size = New System.Drawing.Size(448, 20)
        Me.lbl送信者.TabIndex = 3
        '
        'lbl件名
        '
        Me.lbl件名.BackColor = System.Drawing.Color.White
        Me.lbl件名.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl件名.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!)
        Me.lbl件名.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl件名.Location = New System.Drawing.Point(17, 218)
        Me.lbl件名.Name = "lbl件名"
        Me.lbl件名.Size = New System.Drawing.Size(448, 20)
        Me.lbl件名.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lbl本文)
        Me.Panel1.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!)
        Me.Panel1.Location = New System.Drawing.Point(17, 265)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(448, 360)
        Me.Panel1.TabIndex = 5
        '
        'lbl本文
        '
        Me.lbl本文.AutoEllipsis = True
        Me.lbl本文.AutoSize = True
        Me.lbl本文.BackColor = System.Drawing.Color.White
        Me.lbl本文.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lbl本文.Location = New System.Drawing.Point(0, 0)
        Me.lbl本文.MaximumSize = New System.Drawing.Size(435, 0)
        Me.lbl本文.Name = "lbl本文"
        Me.lbl本文.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.lbl本文.Size = New System.Drawing.Size(35, 19)
        Me.lbl本文.TabIndex = 21
        Me.lbl本文.Text = "本文"
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'lbl送信日付
        '
        Me.lbl送信日付.BackColor = System.Drawing.Color.White
        Me.lbl送信日付.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl送信日付.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl送信日付.Location = New System.Drawing.Point(400, 0)
        Me.lbl送信日付.Name = "lbl送信日付"
        Me.lbl送信日付.Size = New System.Drawing.Size(39, 19)
        Me.lbl送信日付.TabIndex = 74
        Me.lbl送信日付.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(465, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 13)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "(過去3ヶ月間表示）"
        '
        'a1900_メッセージ一覧
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 644)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl送信日付)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbl件名)
        Me.Controls.Add(Me.lbl送信者)
        Me.Controls.Add(Me.tabMessageList)
        Me.Controls.Add(Me.bnt閉じる)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn確認)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a1900_メッセージ一覧"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - メッセージ一覧"
        Me.tabMessageList.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgv一覧_受信, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgv一覧_送信, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bnt閉じる As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn確認 As System.Windows.Forms.Button
    Friend WithEvents tabMessageList As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgv一覧_受信 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv一覧_送信 As System.Windows.Forms.DataGridView
    Friend WithEvents lbl送信者 As System.Windows.Forms.Label
    Friend WithEvents lbl件名 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl本文 As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents lbl送信日付 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
