<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class z_0300_顧客検索
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(z_0300_顧客検索))
        Me.tcSearchGuest = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.lbl町域 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lbl年齢 = New System.Windows.Forms.Label
        Me.lbl誕生日 = New System.Windows.Forms.Label
        Me.lbl前回来店日 = New System.Windows.Forms.Label
        Me.lbl主担当者名 = New System.Windows.Forms.Label
        Me.lbl名カナ = New System.Windows.Forms.Label
        Me.lbl名 = New System.Windows.Forms.Label
        Me.lbl姓 = New System.Windows.Forms.Label
        Me.lbl姓カナ = New System.Windows.Forms.Label
        Me.lbl住所 = New System.Windows.Forms.Label
        Me.番号検索顧客番号 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.顧客一覧 = New System.Windows.Forms.DataGridView
        Me.検索名カナ = New System.Windows.Forms.TextBox
        Me.検索姓カナ = New System.Windows.Forms.TextBox
        Me.カナ検索名カナ = New System.Windows.Forms.TextBox
        Me.カナ検索姓カナ = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.選択 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.tcSearchGuest.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.顧客一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcSearchGuest
        '
        Me.tcSearchGuest.Controls.Add(Me.TabPage1)
        Me.tcSearchGuest.Controls.Add(Me.TabPage2)
        Me.tcSearchGuest.Location = New System.Drawing.Point(21, 18)
        Me.tcSearchGuest.Name = "tcSearchGuest"
        Me.tcSearchGuest.SelectedIndex = 0
        Me.tcSearchGuest.Size = New System.Drawing.Size(660, 337)
        Me.tcSearchGuest.TabIndex = 1
        Me.tcSearchGuest.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lbl町域)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.lbl年齢)
        Me.TabPage1.Controls.Add(Me.lbl誕生日)
        Me.TabPage1.Controls.Add(Me.lbl前回来店日)
        Me.TabPage1.Controls.Add(Me.lbl主担当者名)
        Me.TabPage1.Controls.Add(Me.lbl名カナ)
        Me.TabPage1.Controls.Add(Me.lbl名)
        Me.TabPage1.Controls.Add(Me.lbl姓)
        Me.TabPage1.Controls.Add(Me.lbl姓カナ)
        Me.TabPage1.Controls.Add(Me.lbl住所)
        Me.TabPage1.Controls.Add(Me.番号検索顧客番号)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(652, 311)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "　顧客番号　"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lbl町域
        '
        Me.lbl町域.AutoEllipsis = True
        Me.lbl町域.BackColor = System.Drawing.Color.White
        Me.lbl町域.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl町域.Location = New System.Drawing.Point(101, 73)
        Me.lbl町域.Name = "lbl町域"
        Me.lbl町域.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl町域.Size = New System.Drawing.Size(344, 20)
        Me.lbl町域.TabIndex = 28
        Me.lbl町域.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(54, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "町域 : "
        '
        'lbl年齢
        '
        Me.lbl年齢.AutoEllipsis = True
        Me.lbl年齢.BackColor = System.Drawing.Color.White
        Me.lbl年齢.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl年齢.Location = New System.Drawing.Point(101, 235)
        Me.lbl年齢.Name = "lbl年齢"
        Me.lbl年齢.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl年齢.Size = New System.Drawing.Size(125, 20)
        Me.lbl年齢.TabIndex = 26
        Me.lbl年齢.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl誕生日
        '
        Me.lbl誕生日.AutoEllipsis = True
        Me.lbl誕生日.BackColor = System.Drawing.Color.White
        Me.lbl誕生日.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl誕生日.Location = New System.Drawing.Point(101, 208)
        Me.lbl誕生日.Name = "lbl誕生日"
        Me.lbl誕生日.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl誕生日.Size = New System.Drawing.Size(125, 20)
        Me.lbl誕生日.TabIndex = 25
        Me.lbl誕生日.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl前回来店日
        '
        Me.lbl前回来店日.AutoEllipsis = True
        Me.lbl前回来店日.BackColor = System.Drawing.Color.White
        Me.lbl前回来店日.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl前回来店日.Location = New System.Drawing.Point(101, 181)
        Me.lbl前回来店日.Name = "lbl前回来店日"
        Me.lbl前回来店日.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl前回来店日.Size = New System.Drawing.Size(125, 20)
        Me.lbl前回来店日.TabIndex = 24
        Me.lbl前回来店日.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl主担当者名
        '
        Me.lbl主担当者名.AutoEllipsis = True
        Me.lbl主担当者名.BackColor = System.Drawing.Color.White
        Me.lbl主担当者名.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl主担当者名.Location = New System.Drawing.Point(101, 154)
        Me.lbl主担当者名.Name = "lbl主担当者名"
        Me.lbl主担当者名.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl主担当者名.Size = New System.Drawing.Size(170, 20)
        Me.lbl主担当者名.TabIndex = 23
        Me.lbl主担当者名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl名カナ
        '
        Me.lbl名カナ.AutoEllipsis = True
        Me.lbl名カナ.BackColor = System.Drawing.Color.White
        Me.lbl名カナ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl名カナ.Location = New System.Drawing.Point(276, 100)
        Me.lbl名カナ.Name = "lbl名カナ"
        Me.lbl名カナ.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl名カナ.Size = New System.Drawing.Size(170, 20)
        Me.lbl名カナ.TabIndex = 22
        Me.lbl名カナ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl名
        '
        Me.lbl名.AutoEllipsis = True
        Me.lbl名.BackColor = System.Drawing.Color.White
        Me.lbl名.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl名.Location = New System.Drawing.Point(276, 127)
        Me.lbl名.Name = "lbl名"
        Me.lbl名.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl名.Size = New System.Drawing.Size(170, 20)
        Me.lbl名.TabIndex = 21
        Me.lbl名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl姓
        '
        Me.lbl姓.AutoEllipsis = True
        Me.lbl姓.BackColor = System.Drawing.Color.White
        Me.lbl姓.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl姓.Location = New System.Drawing.Point(101, 127)
        Me.lbl姓.Name = "lbl姓"
        Me.lbl姓.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl姓.Size = New System.Drawing.Size(170, 20)
        Me.lbl姓.TabIndex = 20
        Me.lbl姓.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl姓カナ
        '
        Me.lbl姓カナ.AutoEllipsis = True
        Me.lbl姓カナ.BackColor = System.Drawing.Color.White
        Me.lbl姓カナ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl姓カナ.Location = New System.Drawing.Point(101, 100)
        Me.lbl姓カナ.Name = "lbl姓カナ"
        Me.lbl姓カナ.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl姓カナ.Size = New System.Drawing.Size(170, 20)
        Me.lbl姓カナ.TabIndex = 19
        Me.lbl姓カナ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl住所
        '
        Me.lbl住所.AutoEllipsis = True
        Me.lbl住所.BackColor = System.Drawing.Color.White
        Me.lbl住所.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl住所.Location = New System.Drawing.Point(101, 45)
        Me.lbl住所.Name = "lbl住所"
        Me.lbl住所.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl住所.Size = New System.Drawing.Size(344, 20)
        Me.lbl住所.TabIndex = 18
        Me.lbl住所.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '番号検索顧客番号
        '
        Me.番号検索顧客番号.BackColor = System.Drawing.Color.White
        Me.番号検索顧客番号.ForeColor = System.Drawing.Color.Black
        Me.番号検索顧客番号.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.番号検索顧客番号.Location = New System.Drawing.Point(101, 18)
        Me.番号検索顧客番号.MaxLength = 6
        Me.番号検索顧客番号.Name = "番号検索顧客番号"
        Me.番号検索顧客番号.Size = New System.Drawing.Size(74, 20)
        Me.番号検索顧客番号.TabIndex = 1
        Me.番号検索顧客番号.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(54, 238)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "年齢 : "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "誕生日 : "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 184)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "前回来店日 : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "主担当者 : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(54, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "氏名 : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "カナ : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "市区町村 : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "顧客番号 : "
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.顧客一覧)
        Me.TabPage2.Controls.Add(Me.検索名カナ)
        Me.TabPage2.Controls.Add(Me.検索姓カナ)
        Me.TabPage2.Controls.Add(Me.カナ検索名カナ)
        Me.TabPage2.Controls.Add(Me.カナ検索姓カナ)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(652, 311)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "　顧客氏名　"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        '顧客一覧
        '
        Me.顧客一覧.AllowUserToAddRows = False
        Me.顧客一覧.AllowUserToDeleteRows = False
        Me.顧客一覧.AllowUserToResizeColumns = False
        Me.顧客一覧.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.顧客一覧.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.顧客一覧.BackgroundColor = System.Drawing.Color.White
        Me.顧客一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.顧客一覧.Location = New System.Drawing.Point(25, 44)
        Me.顧客一覧.MultiSelect = False
        Me.顧客一覧.Name = "顧客一覧"
        Me.顧客一覧.ReadOnly = True
        Me.顧客一覧.RowHeadersVisible = False
        Me.顧客一覧.RowTemplate.Height = 16
        Me.顧客一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.顧客一覧.Size = New System.Drawing.Size(600, 244)
        Me.顧客一覧.TabIndex = 6
        Me.顧客一覧.TabStop = False
        '
        '検索名カナ
        '
        Me.検索名カナ.Location = New System.Drawing.Point(362, 18)
        Me.検索名カナ.Name = "検索名カナ"
        Me.検索名カナ.Size = New System.Drawing.Size(10, 20)
        Me.検索名カナ.TabIndex = 5
        Me.検索名カナ.Visible = False
        '
        '検索姓カナ
        '
        Me.検索姓カナ.Location = New System.Drawing.Point(346, 18)
        Me.検索姓カナ.Name = "検索姓カナ"
        Me.検索姓カナ.Size = New System.Drawing.Size(10, 20)
        Me.検索姓カナ.TabIndex = 4
        Me.検索姓カナ.Visible = False
        '
        'カナ検索名カナ
        '
        Me.カナ検索名カナ.BackColor = System.Drawing.Color.White
        Me.カナ検索名カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.カナ検索名カナ.Location = New System.Drawing.Point(211, 18)
        Me.カナ検索名カナ.MaxLength = 32
        Me.カナ検索名カナ.Name = "カナ検索名カナ"
        Me.カナ検索名カナ.Size = New System.Drawing.Size(100, 20)
        Me.カナ検索名カナ.TabIndex = 2
        '
        'カナ検索姓カナ
        '
        Me.カナ検索姓カナ.BackColor = System.Drawing.Color.White
        Me.カナ検索姓カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.カナ検索姓カナ.Location = New System.Drawing.Point(101, 18)
        Me.カナ検索姓カナ.MaxLength = 32
        Me.カナ検索姓カナ.Name = "カナ検索姓カナ"
        Me.カナ検索姓カナ.Size = New System.Drawing.Size(104, 20)
        Me.カナ検索姓カナ.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(28, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "顧客カナ  : "
        '
        '選択
        '
        Me.選択.Location = New System.Drawing.Point(692, 34)
        Me.選択.Name = "選択"
        Me.選択.Size = New System.Drawing.Size(100, 23)
        Me.選択.TabIndex = 3
        Me.選択.Text = "選択"
        Me.選択.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(692, 70)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 4
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'z_0300_顧客検索
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 372)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.選択)
        Me.Controls.Add(Me.tcSearchGuest)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "z_0300_顧客検索"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 顧客検索"
        Me.tcSearchGuest.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.顧客一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcSearchGuest As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents 選択 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 番号検索顧客番号 As System.Windows.Forms.TextBox
    Friend WithEvents カナ検索名カナ As System.Windows.Forms.TextBox
    Friend WithEvents カナ検索姓カナ As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents 検索名カナ As System.Windows.Forms.TextBox
    Friend WithEvents 検索姓カナ As System.Windows.Forms.TextBox
    Friend WithEvents lbl住所 As System.Windows.Forms.Label
    Friend WithEvents lbl年齢 As System.Windows.Forms.Label
    Friend WithEvents lbl誕生日 As System.Windows.Forms.Label
    Friend WithEvents lbl前回来店日 As System.Windows.Forms.Label
    Friend WithEvents lbl主担当者名 As System.Windows.Forms.Label
    Friend WithEvents lbl名カナ As System.Windows.Forms.Label
    Friend WithEvents lbl名 As System.Windows.Forms.Label
    Friend WithEvents lbl姓 As System.Windows.Forms.Label
    Friend WithEvents lbl姓カナ As System.Windows.Forms.Label
    Friend WithEvents 顧客一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents lbl町域 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
