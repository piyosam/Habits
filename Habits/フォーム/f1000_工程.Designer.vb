<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f1000_工程
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(f1000_工程))
        Me.商品 = New System.Windows.Forms.Label
        Me.登録済データ = New System.Windows.Forms.DataGridView
        Me.lavel商品 = New System.Windows.Forms.Label
        Me.閉じる = New System.Windows.Forms.Button
        Me.売上区分番号 = New System.Windows.Forms.TextBox
        Me.分類番号 = New System.Windows.Forms.TextBox
        Me.工程マスタ = New System.Windows.Forms.DataGridView
        Me.btn選択 = New System.Windows.Forms.Button
        Me.btn解除 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.商品名 = New System.Windows.Forms.Label
        Me.btn下へ = New System.Windows.Forms.Button
        Me.btn上へ = New System.Windows.Forms.Button
        Me.商品番号 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.登録済データ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.工程マスタ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '商品
        '
        Me.商品.AutoSize = True
        Me.商品.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.商品.Location = New System.Drawing.Point(26, 43)
        Me.商品.Name = "商品"
        Me.商品.Size = New System.Drawing.Size(53, 13)
        Me.商品.TabIndex = 0
        Me.商品.Text = "商品名 :"
        '
        '登録済データ
        '
        Me.登録済データ.AllowUserToAddRows = False
        Me.登録済データ.AllowUserToDeleteRows = False
        Me.登録済データ.AllowUserToResizeColumns = False
        Me.登録済データ.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.登録済データ.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.登録済データ.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.登録済データ.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.登録済データ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.登録済データ.EnableHeadersVisualStyles = False
        Me.登録済データ.Location = New System.Drawing.Point(350, 95)
        Me.登録済データ.MultiSelect = False
        Me.登録済データ.Name = "登録済データ"
        Me.登録済データ.ReadOnly = True
        Me.登録済データ.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.登録済データ.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.登録済データ.RowTemplate.Height = 17
        Me.登録済データ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.登録済データ.Size = New System.Drawing.Size(270, 206)
        Me.登録済データ.TabIndex = 5
        Me.登録済データ.TabStop = False
        '
        'lavel商品
        '
        Me.lavel商品.AutoSize = True
        Me.lavel商品.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lavel商品.Location = New System.Drawing.Point(13, 17)
        Me.lavel商品.Name = "lavel商品"
        Me.lavel商品.Size = New System.Drawing.Size(66, 13)
        Me.lavel商品.TabIndex = 13
        Me.lavel商品.Text = "商品番号 :"
        '
        '閉じる
        '
        Me.閉じる.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.閉じる.Location = New System.Drawing.Point(523, 316)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 3
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        '売上区分番号
        '
        Me.売上区分番号.Location = New System.Drawing.Point(145, 15)
        Me.売上区分番号.Name = "売上区分番号"
        Me.売上区分番号.ReadOnly = True
        Me.売上区分番号.Size = New System.Drawing.Size(100, 19)
        Me.売上区分番号.TabIndex = 21
        Me.売上区分番号.Visible = False
        '
        '分類番号
        '
        Me.分類番号.Location = New System.Drawing.Point(247, 15)
        Me.分類番号.Name = "分類番号"
        Me.分類番号.ReadOnly = True
        Me.分類番号.Size = New System.Drawing.Size(100, 19)
        Me.分類番号.TabIndex = 22
        Me.分類番号.Visible = False
        '
        '工程マスタ
        '
        Me.工程マスタ.AllowUserToAddRows = False
        Me.工程マスタ.AllowUserToDeleteRows = False
        Me.工程マスタ.AllowUserToResizeColumns = False
        Me.工程マスタ.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue
        Me.工程マスタ.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.工程マスタ.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.工程マスタ.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.工程マスタ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.工程マスタ.EnableHeadersVisualStyles = False
        Me.工程マスタ.Location = New System.Drawing.Point(15, 95)
        Me.工程マスタ.MultiSelect = False
        Me.工程マスタ.Name = "工程マスタ"
        Me.工程マスタ.ReadOnly = True
        Me.工程マスタ.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.工程マスタ.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.工程マスタ.RowTemplate.Height = 17
        Me.工程マスタ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.工程マスタ.Size = New System.Drawing.Size(270, 206)
        Me.工程マスタ.TabIndex = 23
        Me.工程マスタ.TabStop = False
        '
        'btn選択
        '
        Me.btn選択.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.btn選択.Image = Global.Habits.My.Resources.Resources.right
        Me.btn選択.Location = New System.Drawing.Point(298, 145)
        Me.btn選択.Name = "btn選択"
        Me.btn選択.Size = New System.Drawing.Size(40, 24)
        Me.btn選択.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.btn選択, "選択")
        Me.btn選択.UseVisualStyleBackColor = True
        '
        'btn解除
        '
        Me.btn解除.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.btn解除.Image = Global.Habits.My.Resources.Resources.left
        Me.btn解除.Location = New System.Drawing.Point(298, 212)
        Me.btn解除.Name = "btn解除"
        Me.btn解除.Size = New System.Drawing.Size(40, 24)
        Me.btn解除.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btn解除, "解除")
        Me.btn解除.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "工程一覧 :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(348, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "登録済工程一覧 :"
        '
        '商品名
        '
        Me.商品名.AutoSize = True
        Me.商品名.BackColor = System.Drawing.Color.White
        Me.商品名.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.商品名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.商品名.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.商品名.Location = New System.Drawing.Point(85, 41)
        Me.商品名.Name = "商品名"
        Me.商品名.Padding = New System.Windows.Forms.Padding(3, 3, 3, 2)
        Me.商品名.Size = New System.Drawing.Size(68, 20)
        Me.商品名.TabIndex = 29
        Me.商品名.Text = "（商品名）"
        '
        'btn下へ
        '
        Me.btn下へ.BackgroundImage = Global.Habits.My.Resources.Resources.down
        Me.btn下へ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn下へ.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.btn下へ.Location = New System.Drawing.Point(629, 212)
        Me.btn下へ.Name = "btn下へ"
        Me.btn下へ.Size = New System.Drawing.Size(40, 24)
        Me.btn下へ.TabIndex = 31
        Me.ToolTip1.SetToolTip(Me.btn下へ, "表示順を下へ")
        Me.btn下へ.UseVisualStyleBackColor = True
        '
        'btn上へ
        '
        Me.btn上へ.BackgroundImage = Global.Habits.My.Resources.Resources.up
        Me.btn上へ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn上へ.Font = New System.Drawing.Font("MS UI Gothic", 9.75!)
        Me.btn上へ.Location = New System.Drawing.Point(630, 145)
        Me.btn上へ.Name = "btn上へ"
        Me.btn上へ.Size = New System.Drawing.Size(40, 24)
        Me.btn上へ.TabIndex = 30
        Me.btn上へ.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ToolTip1.SetToolTip(Me.btn上へ, "表示順を上へ")
        Me.btn上へ.UseVisualStyleBackColor = True
        '
        '商品番号
        '
        Me.商品番号.BackColor = System.Drawing.Color.White
        Me.商品番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.商品番号.Location = New System.Drawing.Point(85, 15)
        Me.商品番号.Name = "商品番号"
        Me.商品番号.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.商品番号.Size = New System.Drawing.Size(54, 20)
        Me.商品番号.TabIndex = 32
        Me.商品番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.商品番号, "選択")
        '
        'f1000_工程
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 350)
        Me.Controls.Add(Me.商品番号)
        Me.Controls.Add(Me.btn下へ)
        Me.Controls.Add(Me.btn上へ)
        Me.Controls.Add(Me.商品名)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn解除)
        Me.Controls.Add(Me.btn選択)
        Me.Controls.Add(Me.工程マスタ)
        Me.Controls.Add(Me.分類番号)
        Me.Controls.Add(Me.売上区分番号)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.lavel商品)
        Me.Controls.Add(Me.登録済データ)
        Me.Controls.Add(Me.商品)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "f1000_工程"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 工程"
        CType(Me.登録済データ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.工程マスタ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 商品 As System.Windows.Forms.Label
    Friend WithEvents 登録済データ As System.Windows.Forms.DataGridView
    Friend WithEvents lavel商品 As System.Windows.Forms.Label
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents 売上区分番号 As System.Windows.Forms.TextBox
    Friend WithEvents 分類番号 As System.Windows.Forms.TextBox
    Friend WithEvents 工程マスタ As System.Windows.Forms.DataGridView
    Friend WithEvents btn選択 As System.Windows.Forms.Button
    Friend WithEvents btn解除 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 商品名 As System.Windows.Forms.Label
    Friend WithEvents btn下へ As System.Windows.Forms.Button
    Friend WithEvents btn上へ As System.Windows.Forms.Button
    Friend WithEvents 商品番号 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
