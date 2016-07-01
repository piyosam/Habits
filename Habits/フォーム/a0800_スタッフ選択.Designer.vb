<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a0800_スタッフ選択
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a0800_スタッフ選択))
        Me.Label1 = New System.Windows.Forms.Label
        Me.全選択 = New System.Windows.Forms.Button
        Me.選択 = New System.Windows.Forms.Button
        Me.解除 = New System.Windows.Forms.Button
        Me.全解除 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.btn選択 = New System.Windows.Forms.Button
        Me.dgv担当者一覧 = New System.Windows.Forms.DataGridView
        Me.dgvスタッフ一覧 = New System.Windows.Forms.DataGridView
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgv担当者一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvスタッフ一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "総スタッフ一覧 : "
        '
        '全選択
        '
        Me.全選択.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.全選択.Image = Global.Habits.My.Resources.Resources.all_right
        Me.全選択.Location = New System.Drawing.Point(188, 96)
        Me.全選択.Name = "全選択"
        Me.全選択.Size = New System.Drawing.Size(39, 23)
        Me.全選択.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.全選択, "全選択")
        Me.全選択.UseVisualStyleBackColor = True
        '
        '選択
        '
        Me.選択.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.選択.Image = Global.Habits.My.Resources.Resources.right
        Me.選択.Location = New System.Drawing.Point(188, 125)
        Me.選択.Name = "選択"
        Me.選択.Size = New System.Drawing.Size(39, 23)
        Me.選択.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.選択, "選択")
        Me.選択.UseVisualStyleBackColor = True
        '
        '解除
        '
        Me.解除.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.解除.Image = Global.Habits.My.Resources.Resources.left
        Me.解除.Location = New System.Drawing.Point(188, 170)
        Me.解除.Name = "解除"
        Me.解除.Size = New System.Drawing.Size(39, 23)
        Me.解除.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.解除, "解除")
        Me.解除.UseVisualStyleBackColor = True
        '
        '全解除
        '
        Me.全解除.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.全解除.Image = Global.Habits.My.Resources.Resources.all_left
        Me.全解除.Location = New System.Drawing.Point(188, 199)
        Me.全解除.Name = "全解除"
        Me.全解除.Size = New System.Drawing.Size(39, 23)
        Me.全解除.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.全解除, "全解除")
        Me.全解除.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(244, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "出勤スタッフ一覧 : "
        '
        'btn選択
        '
        Me.btn選択.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn選択.Location = New System.Drawing.Point(410, 35)
        Me.btn選択.Name = "btn選択"
        Me.btn選択.Size = New System.Drawing.Size(100, 23)
        Me.btn選択.TabIndex = 6
        Me.btn選択.Text = "選択"
        Me.btn選択.UseVisualStyleBackColor = True
        '
        'dgv担当者一覧
        '
        Me.dgv担当者一覧.AllowUserToAddRows = False
        Me.dgv担当者一覧.AllowUserToDeleteRows = False
        Me.dgv担当者一覧.AllowUserToResizeColumns = False
        Me.dgv担当者一覧.AllowUserToResizeRows = False
        Me.dgv担当者一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv担当者一覧.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgv担当者一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv担当者一覧.ColumnHeadersVisible = False
        Me.dgv担当者一覧.Location = New System.Drawing.Point(24, 35)
        Me.dgv担当者一覧.MultiSelect = False
        Me.dgv担当者一覧.Name = "dgv担当者一覧"
        Me.dgv担当者一覧.ReadOnly = True
        Me.dgv担当者一覧.RowHeadersVisible = False
        Me.dgv担当者一覧.RowTemplate.Height = 16
        Me.dgv担当者一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv担当者一覧.Size = New System.Drawing.Size(150, 322)
        Me.dgv担当者一覧.TabIndex = 10
        Me.dgv担当者一覧.TabStop = False
        '
        'dgvスタッフ一覧
        '
        Me.dgvスタッフ一覧.AllowUserToAddRows = False
        Me.dgvスタッフ一覧.AllowUserToDeleteRows = False
        Me.dgvスタッフ一覧.AllowUserToResizeColumns = False
        Me.dgvスタッフ一覧.AllowUserToResizeRows = False
        Me.dgvスタッフ一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgvスタッフ一覧.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvスタッフ一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvスタッフ一覧.ColumnHeadersVisible = False
        Me.dgvスタッフ一覧.Location = New System.Drawing.Point(243, 35)
        Me.dgvスタッフ一覧.MultiSelect = False
        Me.dgvスタッフ一覧.Name = "dgvスタッフ一覧"
        Me.dgvスタッフ一覧.ReadOnly = True
        Me.dgvスタッフ一覧.RowHeadersVisible = False
        Me.dgvスタッフ一覧.RowTemplate.Height = 16
        Me.dgvスタッフ一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvスタッフ一覧.Size = New System.Drawing.Size(150, 322)
        Me.dgvスタッフ一覧.TabIndex = 11
        Me.dgvスタッフ一覧.TabStop = False
        '
        'a0800_スタッフ選択
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 376)
        Me.Controls.Add(Me.dgvスタッフ一覧)
        Me.Controls.Add(Me.dgv担当者一覧)
        Me.Controls.Add(Me.btn選択)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.全解除)
        Me.Controls.Add(Me.解除)
        Me.Controls.Add(Me.選択)
        Me.Controls.Add(Me.全選択)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a0800_スタッフ選択"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - スタッフ選択"
        CType(Me.dgv担当者一覧, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvスタッフ一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 全選択 As System.Windows.Forms.Button
    Friend WithEvents 選択 As System.Windows.Forms.Button
    Friend WithEvents 解除 As System.Windows.Forms.Button
    Friend WithEvents 全解除 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn選択 As System.Windows.Forms.Button
    Public WithEvents dgv担当者一覧 As System.Windows.Forms.DataGridView
    Public WithEvents dgvスタッフ一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
