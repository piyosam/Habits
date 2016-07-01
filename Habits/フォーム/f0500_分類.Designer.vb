<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f0500_分類

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
        Dim lbl売上区分 As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(f0500_分類))
        Me.新規 = New System.Windows.Forms.Button
        Me.登録 = New System.Windows.Forms.Button
        Me.項目クリア = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.lbl分類番号_文言 = New System.Windows.Forms.Label
        Me.lbl分類名 = New System.Windows.Forms.Label
        Me.lbl表示順 = New System.Windows.Forms.Label
        Me.lbl非表示 = New System.Windows.Forms.Label
        Me.txt分類名 = New System.Windows.Forms.TextBox
        Me.txt表示順 = New System.Windows.Forms.TextBox
        Me.削除フラグ = New System.Windows.Forms.CheckBox
        Me.商品 = New System.Windows.Forms.Button
        Me.売上区分 = New System.Windows.Forms.ComboBox
        Me.dgv分類一覧 = New System.Windows.Forms.DataGridView
        Me.店販対象フラグ = New System.Windows.Forms.CheckBox
        Me.lbl店販対象FLG = New System.Windows.Forms.Label
        Me.lbl分類番号 = New System.Windows.Forms.Label
        lbl売上区分 = New System.Windows.Forms.Label
        CType(Me.dgv分類一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl売上区分
        '
        lbl売上区分.AutoSize = True
        lbl売上区分.Location = New System.Drawing.Point(17, 19)
        lbl売上区分.Name = "lbl売上区分"
        lbl売上区分.Size = New System.Drawing.Size(70, 13)
        lbl売上区分.TabIndex = 28
        lbl売上区分.Text = "売上区分 : "
        '
        '新規
        '
        Me.新規.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.新規.Location = New System.Drawing.Point(512, 49)
        Me.新規.Name = "新規"
        Me.新規.Size = New System.Drawing.Size(100, 23)
        Me.新規.TabIndex = 1
        Me.新規.Text = "新規"
        Me.新規.UseVisualStyleBackColor = True
        '
        '登録
        '
        Me.登録.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.登録.Location = New System.Drawing.Point(512, 78)
        Me.登録.Name = "登録"
        Me.登録.Size = New System.Drawing.Size(100, 23)
        Me.登録.TabIndex = 7
        Me.登録.Text = "変更"
        Me.登録.UseVisualStyleBackColor = True
        '
        '項目クリア
        '
        Me.項目クリア.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.項目クリア.Location = New System.Drawing.Point(512, 107)
        Me.項目クリア.Name = "項目クリア"
        Me.項目クリア.Size = New System.Drawing.Size(100, 23)
        Me.項目クリア.TabIndex = 8
        Me.項目クリア.Text = "項目クリア"
        Me.項目クリア.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.閉じる.Location = New System.Drawing.Point(512, 177)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 10
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'lbl分類番号_文言
        '
        Me.lbl分類番号_文言.Location = New System.Drawing.Point(17, 323)
        Me.lbl分類番号_文言.Name = "lbl分類番号_文言"
        Me.lbl分類番号_文言.Size = New System.Drawing.Size(70, 20)
        Me.lbl分類番号_文言.TabIndex = 6
        Me.lbl分類番号_文言.Text = "分類番号 : "
        Me.lbl分類番号_文言.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl分類名
        '
        Me.lbl分類名.Location = New System.Drawing.Point(17, 349)
        Me.lbl分類名.Name = "lbl分類名"
        Me.lbl分類名.Size = New System.Drawing.Size(70, 20)
        Me.lbl分類名.TabIndex = 7
        Me.lbl分類名.Text = "分類名 : "
        Me.lbl分類名.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl表示順
        '
        Me.lbl表示順.Location = New System.Drawing.Point(17, 375)
        Me.lbl表示順.Name = "lbl表示順"
        Me.lbl表示順.Size = New System.Drawing.Size(70, 20)
        Me.lbl表示順.TabIndex = 8
        Me.lbl表示順.Text = "表示順 : "
        Me.lbl表示順.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl非表示
        '
        Me.lbl非表示.Location = New System.Drawing.Point(17, 427)
        Me.lbl非表示.Name = "lbl非表示"
        Me.lbl非表示.Size = New System.Drawing.Size(70, 20)
        Me.lbl非表示.TabIndex = 9
        Me.lbl非表示.Text = "非表示 : "
        Me.lbl非表示.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt分類名
        '
        Me.txt分類名.BackColor = System.Drawing.Color.White
        Me.txt分類名.ForeColor = System.Drawing.Color.Black
        Me.txt分類名.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txt分類名.Location = New System.Drawing.Point(82, 349)
        Me.txt分類名.MaxLength = 32
        Me.txt分類名.Name = "txt分類名"
        Me.txt分類名.Size = New System.Drawing.Size(417, 20)
        Me.txt分類名.TabIndex = 3
        '
        'txt表示順
        '
        Me.txt表示順.BackColor = System.Drawing.Color.White
        Me.txt表示順.ForeColor = System.Drawing.Color.Black
        Me.txt表示順.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt表示順.Location = New System.Drawing.Point(82, 375)
        Me.txt表示順.MaxLength = 4
        Me.txt表示順.Name = "txt表示順"
        Me.txt表示順.Size = New System.Drawing.Size(59, 20)
        Me.txt表示順.TabIndex = 4
        Me.txt表示順.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '削除フラグ
        '
        Me.削除フラグ.AutoSize = True
        Me.削除フラグ.Location = New System.Drawing.Point(82, 430)
        Me.削除フラグ.Name = "削除フラグ"
        Me.削除フラグ.Size = New System.Drawing.Size(15, 14)
        Me.削除フラグ.TabIndex = 6
        Me.削除フラグ.UseVisualStyleBackColor = True
        '
        '商品
        '
        Me.商品.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.商品.Location = New System.Drawing.Point(512, 136)
        Me.商品.Name = "商品"
        Me.商品.Size = New System.Drawing.Size(100, 23)
        Me.商品.TabIndex = 9
        Me.商品.Text = "商品"
        Me.商品.UseVisualStyleBackColor = True
        '
        '売上区分
        '
        Me.売上区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.売上区分.DropDownWidth = 450
        Me.売上区分.FormattingEnabled = True
        Me.売上区分.Location = New System.Drawing.Point(92, 16)
        Me.売上区分.Name = "売上区分"
        Me.売上区分.Size = New System.Drawing.Size(407, 21)
        Me.売上区分.TabIndex = 2
        '
        'dgv分類一覧
        '
        Me.dgv分類一覧.AllowUserToAddRows = False
        Me.dgv分類一覧.AllowUserToDeleteRows = False
        Me.dgv分類一覧.AllowUserToResizeColumns = False
        Me.dgv分類一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv分類一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv分類一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv分類一覧.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgv分類一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv分類一覧.EnableHeadersVisualStyles = False
        Me.dgv分類一覧.Location = New System.Drawing.Point(18, 49)
        Me.dgv分類一覧.MultiSelect = False
        Me.dgv分類一覧.Name = "dgv分類一覧"
        Me.dgv分類一覧.ReadOnly = True
        Me.dgv分類一覧.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv分類一覧.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv分類一覧.RowTemplate.Height = 16
        Me.dgv分類一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv分類一覧.Size = New System.Drawing.Size(482, 260)
        Me.dgv分類一覧.TabIndex = 1
        Me.dgv分類一覧.TabStop = False
        '
        '店販対象フラグ
        '
        Me.店販対象フラグ.AutoSize = True
        Me.店販対象フラグ.Location = New System.Drawing.Point(82, 404)
        Me.店販対象フラグ.Name = "店販対象フラグ"
        Me.店販対象フラグ.Size = New System.Drawing.Size(15, 14)
        Me.店販対象フラグ.TabIndex = 5
        Me.店販対象フラグ.UseVisualStyleBackColor = True
        '
        'lbl店販対象FLG
        '
        Me.lbl店販対象FLG.Location = New System.Drawing.Point(17, 401)
        Me.lbl店販対象FLG.Name = "lbl店販対象FLG"
        Me.lbl店販対象FLG.Size = New System.Drawing.Size(70, 20)
        Me.lbl店販対象FLG.TabIndex = 31
        Me.lbl店販対象FLG.Text = "店販対象 : "
        Me.lbl店販対象FLG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl分類番号
        '
        Me.lbl分類番号.BackColor = System.Drawing.Color.White
        Me.lbl分類番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl分類番号.Location = New System.Drawing.Point(82, 323)
        Me.lbl分類番号.Name = "lbl分類番号"
        Me.lbl分類番号.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl分類番号.Size = New System.Drawing.Size(59, 20)
        Me.lbl分類番号.TabIndex = 32
        Me.lbl分類番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'f0500_分類
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 458)
        Me.Controls.Add(Me.lbl分類番号)
        Me.Controls.Add(Me.店販対象フラグ)
        Me.Controls.Add(Me.lbl店販対象FLG)
        Me.Controls.Add(Me.dgv分類一覧)
        Me.Controls.Add(Me.売上区分)
        Me.Controls.Add(lbl売上区分)
        Me.Controls.Add(Me.商品)
        Me.Controls.Add(Me.削除フラグ)
        Me.Controls.Add(Me.txt表示順)
        Me.Controls.Add(Me.txt分類名)
        Me.Controls.Add(Me.lbl非表示)
        Me.Controls.Add(Me.lbl表示順)
        Me.Controls.Add(Me.lbl分類名)
        Me.Controls.Add(Me.lbl分類番号_文言)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.項目クリア)
        Me.Controls.Add(Me.登録)
        Me.Controls.Add(Me.新規)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "f0500_分類"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 分類"
        CType(Me.dgv分類一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 新規 As System.Windows.Forms.Button
    Friend WithEvents 登録 As System.Windows.Forms.Button
    Friend WithEvents 項目クリア As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents lbl分類番号_文言 As System.Windows.Forms.Label
    Friend WithEvents lbl分類名 As System.Windows.Forms.Label
    Friend WithEvents lbl表示順 As System.Windows.Forms.Label
    Friend WithEvents lbl非表示 As System.Windows.Forms.Label
    Friend WithEvents txt分類名 As System.Windows.Forms.TextBox
    Friend WithEvents txt表示順 As System.Windows.Forms.TextBox
    Friend WithEvents 削除フラグ As System.Windows.Forms.CheckBox
    Friend WithEvents 商品 As System.Windows.Forms.Button
    Friend WithEvents 売上区分 As System.Windows.Forms.ComboBox
    Friend WithEvents dgv分類一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents 店販対象フラグ As System.Windows.Forms.CheckBox
    Friend WithEvents lbl店販対象FLG As System.Windows.Forms.Label
    Friend WithEvents lbl分類番号 As System.Windows.Forms.Label
End Class
