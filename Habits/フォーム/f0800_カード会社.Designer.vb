﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f0800_カード会社
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(f0800_カード会社))
        Me.新規 = New System.Windows.Forms.Button
        Me.登録 = New System.Windows.Forms.Button
        Me.項目クリア = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.カード会社名 = New System.Windows.Forms.TextBox
        Me.表示順 = New System.Windows.Forms.TextBox
        Me.削除フラグ = New System.Windows.Forms.CheckBox
        Me.dgv一覧 = New System.Windows.Forms.DataGridView
        Me.カード会社番号 = New System.Windows.Forms.Label
        CType(Me.dgv一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '新規
        '
        Me.新規.Location = New System.Drawing.Point(412, 15)
        Me.新規.Name = "新規"
        Me.新規.Size = New System.Drawing.Size(100, 23)
        Me.新規.TabIndex = 1
        Me.新規.Text = "新規"
        Me.新規.UseVisualStyleBackColor = True
        '
        '登録
        '
        Me.登録.Location = New System.Drawing.Point(412, 44)
        Me.登録.Name = "登録"
        Me.登録.Size = New System.Drawing.Size(100, 23)
        Me.登録.TabIndex = 7
        Me.登録.Text = "変更"
        Me.登録.UseVisualStyleBackColor = True
        '
        '項目クリア
        '
        Me.項目クリア.Location = New System.Drawing.Point(412, 85)
        Me.項目クリア.Name = "項目クリア"
        Me.項目クリア.Size = New System.Drawing.Size(100, 23)
        Me.項目クリア.TabIndex = 8
        Me.項目クリア.Text = "項目クリア"
        Me.項目クリア.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(412, 114)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 9
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 365)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "カード会社番号 :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 392)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "カード会社名 :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 418)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "表示順 :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 441)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "非表示 :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'カード会社名
        '
        Me.カード会社名.BackColor = System.Drawing.Color.White
        Me.カード会社名.ForeColor = System.Drawing.Color.Black
        Me.カード会社名.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.カード会社名.Location = New System.Drawing.Point(114, 393)
        Me.カード会社名.MaxLength = 32
        Me.カード会社名.Name = "カード会社名"
        Me.カード会社名.Size = New System.Drawing.Size(241, 20)
        Me.カード会社名.TabIndex = 4
        '
        '表示順
        '
        Me.表示順.BackColor = System.Drawing.Color.White
        Me.表示順.ForeColor = System.Drawing.Color.Black
        Me.表示順.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.表示順.Location = New System.Drawing.Point(114, 419)
        Me.表示順.MaxLength = 4
        Me.表示順.Name = "表示順"
        Me.表示順.Size = New System.Drawing.Size(57, 20)
        Me.表示順.TabIndex = 5
        Me.表示順.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '削除フラグ
        '
        Me.削除フラグ.AutoSize = True
        Me.削除フラグ.Location = New System.Drawing.Point(114, 445)
        Me.削除フラグ.Name = "削除フラグ"
        Me.削除フラグ.Size = New System.Drawing.Size(15, 14)
        Me.削除フラグ.TabIndex = 6
        Me.削除フラグ.UseVisualStyleBackColor = True
        '
        'dgv一覧
        '
        Me.dgv一覧.AllowUserToAddRows = False
        Me.dgv一覧.AllowUserToDeleteRows = False
        Me.dgv一覧.AllowUserToResizeColumns = False
        Me.dgv一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.dgv一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv一覧.EnableHeadersVisualStyles = False
        Me.dgv一覧.Location = New System.Drawing.Point(18, 16)
        Me.dgv一覧.MultiSelect = False
        Me.dgv一覧.Name = "dgv一覧"
        Me.dgv一覧.ReadOnly = True
        Me.dgv一覧.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.dgv一覧.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv一覧.RowTemplate.Height = 16
        Me.dgv一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv一覧.Size = New System.Drawing.Size(383, 340)
        Me.dgv一覧.TabIndex = 2
        Me.dgv一覧.TabStop = False
        '
        'カード会社番号
        '
        Me.カード会社番号.BackColor = System.Drawing.Color.White
        Me.カード会社番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.カード会社番号.Location = New System.Drawing.Point(114, 367)
        Me.カード会社番号.Name = "カード会社番号"
        Me.カード会社番号.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.カード会社番号.Size = New System.Drawing.Size(57, 20)
        Me.カード会社番号.TabIndex = 3
        Me.カード会社番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'f0800_カード会社
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 474)
        Me.Controls.Add(Me.カード会社番号)
        Me.Controls.Add(Me.dgv一覧)
        Me.Controls.Add(Me.削除フラグ)
        Me.Controls.Add(Me.表示順)
        Me.Controls.Add(Me.カード会社名)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.項目クリア)
        Me.Controls.Add(Me.登録)
        Me.Controls.Add(Me.新規)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "f0800_カード会社"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - カード会社"
        CType(Me.dgv一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 新規 As System.Windows.Forms.Button
    Friend WithEvents 登録 As System.Windows.Forms.Button
    Friend WithEvents 項目クリア As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents カード会社名 As System.Windows.Forms.TextBox
    Friend WithEvents 表示順 As System.Windows.Forms.TextBox
    Friend WithEvents 削除フラグ As System.Windows.Forms.CheckBox
    Public WithEvents dgv一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents カード会社番号 As System.Windows.Forms.Label
End Class
