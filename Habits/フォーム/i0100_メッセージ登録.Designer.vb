<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class i0100_メッセージ登録
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(i0100_メッセージ登録))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.btnSelectOne = New System.Windows.Forms.Button
        Me.btnDeleteOne = New System.Windows.Forms.Button
        Me.btnDeleteAll = New System.Windows.Forms.Button
        Me.lblSender = New System.Windows.Forms.Label
        Me.lblSubject = New System.Windows.Forms.Label
        Me.lblMsgBody = New System.Windows.Forms.Label
        Me.txtSender = New System.Windows.Forms.TextBox
        Me.txtSubject = New System.Windows.Forms.TextBox
        Me.txtMsgBody = New System.Windows.Forms.TextBox
        Me.btnConfirm = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblShopAll = New System.Windows.Forms.Label
        Me.lblShopSelected = New System.Windows.Forms.Label
        Me.btnPreview = New System.Windows.Forms.Button
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.dgvShopAll = New System.Windows.Forms.DataGridView
        Me.dgvShopSelected = New System.Windows.Forms.DataGridView
        Me.btnClear = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgvShopAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvShopSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSelectAll.Image = Global.Habits.My.Resources.Resources.all_right
        Me.btnSelectAll.Location = New System.Drawing.Point(275, 28)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(52, 25)
        Me.btnSelectAll.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnSelectAll, "全選択")
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnSelectOne
        '
        Me.btnSelectOne.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnSelectOne.Image = Global.Habits.My.Resources.Resources.right
        Me.btnSelectOne.Location = New System.Drawing.Point(275, 59)
        Me.btnSelectOne.Name = "btnSelectOne"
        Me.btnSelectOne.Size = New System.Drawing.Size(52, 25)
        Me.btnSelectOne.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btnSelectOne, "選択")
        Me.btnSelectOne.UseVisualStyleBackColor = True
        '
        'btnDeleteOne
        '
        Me.btnDeleteOne.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDeleteOne.Image = Global.Habits.My.Resources.Resources.left
        Me.btnDeleteOne.Location = New System.Drawing.Point(275, 90)
        Me.btnDeleteOne.Name = "btnDeleteOne"
        Me.btnDeleteOne.Size = New System.Drawing.Size(52, 25)
        Me.btnDeleteOne.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.btnDeleteOne, "解除")
        Me.btnDeleteOne.UseVisualStyleBackColor = True
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnDeleteAll.Image = Global.Habits.My.Resources.Resources.all_left
        Me.btnDeleteAll.Location = New System.Drawing.Point(275, 122)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(52, 25)
        Me.btnDeleteAll.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btnDeleteAll, "全解除")
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        '
        'lblSender
        '
        Me.lblSender.AutoSize = True
        Me.lblSender.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSender.Location = New System.Drawing.Point(17, 155)
        Me.lblSender.Name = "lblSender"
        Me.lblSender.Size = New System.Drawing.Size(53, 13)
        Me.lblSender.TabIndex = 0
        Me.lblSender.Text = "送信者 :"
        '
        'lblSubject
        '
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSubject.Location = New System.Drawing.Point(17, 202)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(40, 13)
        Me.lblSubject.TabIndex = 0
        Me.lblSubject.Text = "件名 :"
        '
        'lblMsgBody
        '
        Me.lblMsgBody.AutoSize = True
        Me.lblMsgBody.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMsgBody.Location = New System.Drawing.Point(17, 249)
        Me.lblMsgBody.Name = "lblMsgBody"
        Me.lblMsgBody.Size = New System.Drawing.Size(40, 13)
        Me.lblMsgBody.TabIndex = 0
        Me.lblMsgBody.Text = "本文 :"
        '
        'txtSender
        '
        Me.txtSender.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!)
        Me.txtSender.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtSender.Location = New System.Drawing.Point(20, 171)
        Me.txtSender.Name = "txtSender"
        Me.txtSender.Size = New System.Drawing.Size(448, 20)
        Me.txtSender.TabIndex = 7
        '
        'txtSubject
        '
        Me.txtSubject.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!)
        Me.txtSubject.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtSubject.Location = New System.Drawing.Point(20, 218)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(448, 20)
        Me.txtSubject.TabIndex = 8
        '
        'txtMsgBody
        '
        Me.txtMsgBody.Font = New System.Drawing.Font("ＭＳ ゴシック", 9.75!)
        Me.txtMsgBody.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtMsgBody.Location = New System.Drawing.Point(20, 265)
        Me.txtMsgBody.Multiline = True
        Me.txtMsgBody.Name = "txtMsgBody"
        Me.txtMsgBody.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMsgBody.Size = New System.Drawing.Size(448, 360)
        Me.txtMsgBody.TabIndex = 9
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(487, 265)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(100, 23)
        Me.btnConfirm.TabIndex = 10
        Me.btnConfirm.Text = "送信"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(487, 390)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 23)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "閉じる"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblShopAll
        '
        Me.lblShopAll.AutoSize = True
        Me.lblShopAll.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblShopAll.Location = New System.Drawing.Point(17, 15)
        Me.lblShopAll.Name = "lblShopAll"
        Me.lblShopAll.Size = New System.Drawing.Size(66, 13)
        Me.lblShopAll.TabIndex = 0
        Me.lblShopAll.Text = "店舗一覧 :"
        '
        'lblShopSelected
        '
        Me.lblShopSelected.AutoSize = True
        Me.lblShopSelected.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblShopSelected.Location = New System.Drawing.Point(347, 15)
        Me.lblShopSelected.Name = "lblShopSelected"
        Me.lblShopSelected.Size = New System.Drawing.Size(105, 13)
        Me.lblShopSelected.TabIndex = 0
        Me.lblShopSelected.Text = "送信先店舗一覧 :"
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(487, 306)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(100, 23)
        Me.btnPreview.TabIndex = 11
        Me.btnPreview.Text = "プレビュー"
        Me.btnPreview.UseVisualStyleBackColor = True
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
        'PrintDocument1
        '
        '
        'dgvShopAll
        '
        Me.dgvShopAll.AllowUserToAddRows = False
        Me.dgvShopAll.AllowUserToDeleteRows = False
        Me.dgvShopAll.AllowUserToResizeColumns = False
        Me.dgvShopAll.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvShopAll.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShopAll.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvShopAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShopAll.ColumnHeadersVisible = False
        Me.dgvShopAll.EnableHeadersVisualStyles = False
        Me.dgvShopAll.Location = New System.Drawing.Point(20, 28)
        Me.dgvShopAll.Name = "dgvShopAll"
        Me.dgvShopAll.RowHeadersVisible = False
        Me.dgvShopAll.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgvShopAll.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvShopAll.RowTemplate.Height = 21
        Me.dgvShopAll.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvShopAll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShopAll.Size = New System.Drawing.Size(230, 108)
        Me.dgvShopAll.TabIndex = 1
        '
        'dgvShopSelected
        '
        Me.dgvShopSelected.AllowUserToAddRows = False
        Me.dgvShopSelected.AllowUserToDeleteRows = False
        Me.dgvShopSelected.AllowUserToResizeColumns = False
        Me.dgvShopSelected.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue
        Me.dgvShopSelected.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvShopSelected.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvShopSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShopSelected.ColumnHeadersVisible = False
        Me.dgvShopSelected.EnableHeadersVisualStyles = False
        Me.dgvShopSelected.Location = New System.Drawing.Point(350, 29)
        Me.dgvShopSelected.Name = "dgvShopSelected"
        Me.dgvShopSelected.RowHeadersVisible = False
        Me.dgvShopSelected.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvShopSelected.RowTemplate.Height = 21
        Me.dgvShopSelected.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvShopSelected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShopSelected.Size = New System.Drawing.Size(230, 108)
        Me.dgvShopSelected.TabIndex = 6
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(487, 359)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 23)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "項目クリア"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'i0100_メッセージ登録
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 644)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.dgvShopSelected)
        Me.Controls.Add(Me.dgvShopAll)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.txtMsgBody)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.txtSender)
        Me.Controls.Add(Me.lblMsgBody)
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.lblShopSelected)
        Me.Controls.Add(Me.lblShopAll)
        Me.Controls.Add(Me.lblSender)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.btnDeleteAll)
        Me.Controls.Add(Me.btnDeleteOne)
        Me.Controls.Add(Me.btnSelectOne)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "i0100_メッセージ登録"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - メッセージ送信"
        CType(Me.dgvShopAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvShopSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnSelectOne As System.Windows.Forms.Button
    Friend WithEvents btnDeleteOne As System.Windows.Forms.Button
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents lblSender As System.Windows.Forms.Label
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents lblMsgBody As System.Windows.Forms.Label
    Friend WithEvents txtSender As System.Windows.Forms.TextBox
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents txtMsgBody As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblShopAll As System.Windows.Forms.Label
    Friend WithEvents lblShopSelected As System.Windows.Forms.Label
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Private WithEvents dgvShopAll As System.Windows.Forms.DataGridView
    Private WithEvents dgvShopSelected As System.Windows.Forms.DataGridView
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
