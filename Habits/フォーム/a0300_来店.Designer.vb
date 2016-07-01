<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class a0300_来店
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(a0300_来店))
        Me.btn待ち = New System.Windows.Forms.Button
        Me.txt新規姓 = New System.Windows.Forms.TextBox
        Me.txtフリー姓カナ = New System.Windows.Forms.TextBox
        Me.tc来店状況 = New System.Windows.Forms.TabControl
        Me.顧客番号 = New System.Windows.Forms.TabPage
        Me.lbl町域 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.lbl名カナ = New System.Windows.Forms.Label
        Me.lbl姓 = New System.Windows.Forms.Label
        Me.lbl名 = New System.Windows.Forms.Label
        Me.lbl姓カナ = New System.Windows.Forms.Label
        Me.lblカルテ = New System.Windows.Forms.Label
        Me.lbl住所 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtカードあり顧客番号 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.カードなし = New System.Windows.Forms.TabPage
        Me.dgv顧客一覧 = New System.Windows.Forms.DataGridView
        Me.txtカードなし名カナ = New System.Windows.Forms.TextBox
        Me.txtカードなし姓カナ = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.新規 = New System.Windows.Forms.TabPage
        Me.lbl新規顧客番号 = New System.Windows.Forms.Label
        Me.txt新規名 = New System.Windows.Forms.TextBox
        Me.txt新規名カナ = New System.Windows.Forms.TextBox
        Me.txt新規姓カナ = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.フリー = New System.Windows.Forms.TabPage
        Me.lblフリー顧客番号 = New System.Windows.Forms.Label
        Me.txtフリー名 = New System.Windows.Forms.TextBox
        Me.txtフリー姓 = New System.Windows.Forms.TextBox
        Me.txtフリー名カナ = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.btn来店登録 = New System.Windows.Forms.Button
        Me.btn空番 = New System.Windows.Forms.Button
        Me.btn設定 = New System.Windows.Forms.Button
        Me.btnクリア = New System.Windows.Forms.Button
        Me.btn閉じる = New System.Windows.Forms.Button
        Me.カードあり = New System.Windows.Forms.TabPage
        Me.TextBox15 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextBox16 = New System.Windows.Forms.TextBox
        Me.TextBox17 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBox18 = New System.Windows.Forms.TextBox
        Me.TextBox19 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextBox20 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextBox21 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.ListBox2 = New System.Windows.Forms.ListBox
        Me.TextBox22 = New System.Windows.Forms.TextBox
        Me.TextBox23 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.TextBox24 = New System.Windows.Forms.TextBox
        Me.TextBox25 = New System.Windows.Forms.TextBox
        Me.TextBox26 = New System.Windows.Forms.TextBox
        Me.TextBox27 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.TextBox28 = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.btnカルテ = New System.Windows.Forms.Button
        Me.txtCustomerNum = New System.Windows.Forms.TextBox
        Me.tc来店状況.SuspendLayout()
        Me.顧客番号.SuspendLayout()
        Me.カードなし.SuspendLayout()
        CType(Me.dgv顧客一覧, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.新規.SuspendLayout()
        Me.フリー.SuspendLayout()
        Me.カードあり.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn待ち
        '
        Me.btn待ち.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btn待ち.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn待ち.Location = New System.Drawing.Point(649, 75)
        Me.btn待ち.Name = "btn待ち"
        Me.btn待ち.Size = New System.Drawing.Size(100, 30)
        Me.btn待ち.TabIndex = 2
        Me.btn待ち.Text = "施術待ち"
        Me.btn待ち.UseVisualStyleBackColor = False
        Me.btn待ち.Visible = False
        '
        'txt新規姓
        '
        Me.txt新規姓.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt新規姓.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txt新規姓.Location = New System.Drawing.Point(88, 55)
        Me.txt新規姓.MaxLength = 16
        Me.txt新規姓.Name = "txt新規姓"
        Me.txt新規姓.Size = New System.Drawing.Size(170, 20)
        Me.txt新規姓.TabIndex = 12
        '
        'txtフリー姓カナ
        '
        Me.txtフリー姓カナ.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtフリー姓カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtフリー姓カナ.Location = New System.Drawing.Point(88, 81)
        Me.txtフリー姓カナ.MaxLength = 32
        Me.txtフリー姓カナ.Name = "txtフリー姓カナ"
        Me.txtフリー姓カナ.Size = New System.Drawing.Size(170, 20)
        Me.txtフリー姓カナ.TabIndex = 2
        '
        'tc来店状況
        '
        Me.tc来店状況.Controls.Add(Me.顧客番号)
        Me.tc来店状況.Controls.Add(Me.カードなし)
        Me.tc来店状況.Controls.Add(Me.新規)
        Me.tc来店状況.Controls.Add(Me.フリー)
        Me.tc来店状況.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tc来店状況.Location = New System.Drawing.Point(12, 12)
        Me.tc来店状況.Name = "tc来店状況"
        Me.tc来店状況.SelectedIndex = 0
        Me.tc来店状況.Size = New System.Drawing.Size(630, 325)
        Me.tc来店状況.TabIndex = 7
        '
        '顧客番号
        '
        Me.顧客番号.Controls.Add(Me.lbl町域)
        Me.顧客番号.Controls.Add(Me.Label22)
        Me.顧客番号.Controls.Add(Me.lbl名カナ)
        Me.顧客番号.Controls.Add(Me.lbl姓)
        Me.顧客番号.Controls.Add(Me.lbl名)
        Me.顧客番号.Controls.Add(Me.lbl姓カナ)
        Me.顧客番号.Controls.Add(Me.lblカルテ)
        Me.顧客番号.Controls.Add(Me.lbl住所)
        Me.顧客番号.Controls.Add(Me.Label5)
        Me.顧客番号.Controls.Add(Me.Label4)
        Me.顧客番号.Controls.Add(Me.Label3)
        Me.顧客番号.Controls.Add(Me.Label2)
        Me.顧客番号.Controls.Add(Me.txtカードあり顧客番号)
        Me.顧客番号.Controls.Add(Me.Label1)
        Me.顧客番号.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.顧客番号.Location = New System.Drawing.Point(4, 22)
        Me.顧客番号.Name = "顧客番号"
        Me.顧客番号.Padding = New System.Windows.Forms.Padding(3)
        Me.顧客番号.Size = New System.Drawing.Size(622, 299)
        Me.顧客番号.TabIndex = 0
        Me.顧客番号.Text = " 顧客番号 "
        Me.顧客番号.UseVisualStyleBackColor = True
        '
        'lbl町域
        '
        Me.lbl町域.AutoEllipsis = True
        Me.lbl町域.BackColor = System.Drawing.Color.White
        Me.lbl町域.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl町域.Location = New System.Drawing.Point(88, 73)
        Me.lbl町域.Name = "lbl町域"
        Me.lbl町域.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lbl町域.Size = New System.Drawing.Size(344, 20)
        Me.lbl町域.TabIndex = 30
        Me.lbl町域.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(48, 77)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(44, 13)
        Me.Label22.TabIndex = 29
        Me.Label22.Text = "町域 : "
        '
        'lbl名カナ
        '
        Me.lbl名カナ.AutoEllipsis = True
        Me.lbl名カナ.BackColor = System.Drawing.Color.White
        Me.lbl名カナ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl名カナ.Location = New System.Drawing.Point(262, 101)
        Me.lbl名カナ.Name = "lbl名カナ"
        Me.lbl名カナ.Size = New System.Drawing.Size(170, 20)
        Me.lbl名カナ.TabIndex = 17
        Me.lbl名カナ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl姓
        '
        Me.lbl姓.AutoEllipsis = True
        Me.lbl姓.BackColor = System.Drawing.Color.White
        Me.lbl姓.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl姓.Location = New System.Drawing.Point(88, 127)
        Me.lbl姓.Name = "lbl姓"
        Me.lbl姓.Size = New System.Drawing.Size(170, 20)
        Me.lbl姓.TabIndex = 16
        Me.lbl姓.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl名
        '
        Me.lbl名.AutoEllipsis = True
        Me.lbl名.BackColor = System.Drawing.Color.White
        Me.lbl名.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl名.Location = New System.Drawing.Point(262, 127)
        Me.lbl名.Name = "lbl名"
        Me.lbl名.Size = New System.Drawing.Size(170, 20)
        Me.lbl名.TabIndex = 15
        Me.lbl名.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl姓カナ
        '
        Me.lbl姓カナ.AutoEllipsis = True
        Me.lbl姓カナ.BackColor = System.Drawing.Color.White
        Me.lbl姓カナ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl姓カナ.Location = New System.Drawing.Point(88, 101)
        Me.lbl姓カナ.Name = "lbl姓カナ"
        Me.lbl姓カナ.Size = New System.Drawing.Size(170, 20)
        Me.lbl姓カナ.TabIndex = 14
        Me.lbl姓カナ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblカルテ
        '
        Me.lblカルテ.BackColor = System.Drawing.Color.White
        Me.lblカルテ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblカルテ.Location = New System.Drawing.Point(88, 153)
        Me.lblカルテ.Margin = New System.Windows.Forms.Padding(3)
        Me.lblカルテ.Name = "lblカルテ"
        Me.lblカルテ.Size = New System.Drawing.Size(344, 126)
        Me.lblカルテ.TabIndex = 13
        '
        'lbl住所
        '
        Me.lbl住所.AutoEllipsis = True
        Me.lbl住所.BackColor = System.Drawing.Color.White
        Me.lbl住所.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl住所.Location = New System.Drawing.Point(88, 45)
        Me.lbl住所.Name = "lbl住所"
        Me.lbl住所.Size = New System.Drawing.Size(344, 20)
        Me.lbl住所.TabIndex = 12
        Me.lbl住所.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "カルテ :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "氏名 :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "カナ :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "市区町村 :"
        '
        'txtカードあり顧客番号
        '
        Me.txtカードあり顧客番号.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtカードあり顧客番号.Location = New System.Drawing.Point(88, 19)
        Me.txtカードあり顧客番号.Margin = New System.Windows.Forms.Padding(3, 3, 20, 3)
        Me.txtカードあり顧客番号.MaxLength = 6
        Me.txtカードあり顧客番号.Name = "txtカードあり顧客番号"
        Me.txtカードあり顧客番号.Size = New System.Drawing.Size(80, 20)
        Me.txtカードあり顧客番号.TabIndex = 1
        Me.txtカードあり顧客番号.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "顧客番号 :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'カードなし
        '
        Me.カードなし.Controls.Add(Me.dgv顧客一覧)
        Me.カードなし.Controls.Add(Me.txtカードなし名カナ)
        Me.カードなし.Controls.Add(Me.txtカードなし姓カナ)
        Me.カードなし.Controls.Add(Me.Label6)
        Me.カードなし.Location = New System.Drawing.Point(4, 22)
        Me.カードなし.Name = "カードなし"
        Me.カードなし.Padding = New System.Windows.Forms.Padding(3)
        Me.カードなし.Size = New System.Drawing.Size(622, 299)
        Me.カードなし.TabIndex = 1
        Me.カードなし.Text = " 顧客氏名 "
        Me.カードなし.UseVisualStyleBackColor = True
        '
        'dgv顧客一覧
        '
        Me.dgv顧客一覧.AllowUserToAddRows = False
        Me.dgv顧客一覧.AllowUserToDeleteRows = False
        Me.dgv顧客一覧.AllowUserToResizeColumns = False
        Me.dgv顧客一覧.AllowUserToResizeRows = False
        Me.dgv顧客一覧.BackgroundColor = System.Drawing.Color.White
        Me.dgv顧客一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv顧客一覧.ColumnHeadersVisible = False
        Me.dgv顧客一覧.Location = New System.Drawing.Point(12, 44)
        Me.dgv顧客一覧.MultiSelect = False
        Me.dgv顧客一覧.Name = "dgv顧客一覧"
        Me.dgv顧客一覧.ReadOnly = True
        Me.dgv顧客一覧.RowHeadersVisible = False
        Me.dgv顧客一覧.RowTemplate.Height = 16
        Me.dgv顧客一覧.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv顧客一覧.Size = New System.Drawing.Size(600, 243)
        Me.dgv顧客一覧.TabIndex = 4
        Me.dgv顧客一覧.TabStop = False
        '
        'txtカードなし名カナ
        '
        Me.txtカードなし名カナ.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtカードなし名カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtカードなし名カナ.Location = New System.Drawing.Point(194, 19)
        Me.txtカードなし名カナ.MaxLength = 32
        Me.txtカードなし名カナ.Name = "txtカードなし名カナ"
        Me.txtカードなし名カナ.Size = New System.Drawing.Size(100, 20)
        Me.txtカードなし名カナ.TabIndex = 2
        '
        'txtカードなし姓カナ
        '
        Me.txtカードなし姓カナ.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtカードなし姓カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtカードなし姓カナ.Location = New System.Drawing.Point(88, 19)
        Me.txtカードなし姓カナ.MaxLength = 32
        Me.txtカードなし姓カナ.Name = "txtカードなし姓カナ"
        Me.txtカードなし姓カナ.Size = New System.Drawing.Size(100, 20)
        Me.txtカードなし姓カナ.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "顧客カナ  :"
        '
        '新規
        '
        Me.新規.Controls.Add(Me.lbl新規顧客番号)
        Me.新規.Controls.Add(Me.txt新規名)
        Me.新規.Controls.Add(Me.txt新規姓)
        Me.新規.Controls.Add(Me.txt新規名カナ)
        Me.新規.Controls.Add(Me.txt新規姓カナ)
        Me.新規.Controls.Add(Me.Label7)
        Me.新規.Controls.Add(Me.Label8)
        Me.新規.Controls.Add(Me.Label9)
        Me.新規.Location = New System.Drawing.Point(4, 22)
        Me.新規.Name = "新規"
        Me.新規.Padding = New System.Windows.Forms.Padding(3)
        Me.新規.Size = New System.Drawing.Size(622, 299)
        Me.新規.TabIndex = 2
        Me.新規.Text = "　新　規　"
        Me.新規.UseVisualStyleBackColor = True
        '
        'lbl新規顧客番号
        '
        Me.lbl新規顧客番号.BackColor = System.Drawing.Color.White
        Me.lbl新規顧客番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl新規顧客番号.Location = New System.Drawing.Point(88, 19)
        Me.lbl新規顧客番号.Name = "lbl新規顧客番号"
        Me.lbl新規顧客番号.Size = New System.Drawing.Size(80, 20)
        Me.lbl新規顧客番号.TabIndex = 16
        Me.lbl新規顧客番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt新規名
        '
        Me.txt新規名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt新規名.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txt新規名.Location = New System.Drawing.Point(262, 55)
        Me.txt新規名.MaxLength = 16
        Me.txt新規名.Name = "txt新規名"
        Me.txt新規名.Size = New System.Drawing.Size(170, 20)
        Me.txt新規名.TabIndex = 14
        '
        'txt新規名カナ
        '
        Me.txt新規名カナ.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt新規名カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt新規名カナ.Location = New System.Drawing.Point(262, 81)
        Me.txt新規名カナ.MaxLength = 32
        Me.txt新規名カナ.Name = "txt新規名カナ"
        Me.txt新規名カナ.Size = New System.Drawing.Size(170, 20)
        Me.txt新規名カナ.TabIndex = 15
        '
        'txt新規姓カナ
        '
        Me.txt新規姓カナ.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txt新規姓カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt新規姓カナ.Location = New System.Drawing.Point(88, 81)
        Me.txt新規姓カナ.MaxLength = 32
        Me.txt新規姓カナ.Name = "txt新規姓カナ"
        Me.txt新規姓カナ.Size = New System.Drawing.Size(170, 20)
        Me.txt新規姓カナ.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.Location = New System.Drawing.Point(52, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "カナ :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.Location = New System.Drawing.Point(48, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "氏名 :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.Location = New System.Drawing.Point(22, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "顧客番号 :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'フリー
        '
        Me.フリー.Controls.Add(Me.lblフリー顧客番号)
        Me.フリー.Controls.Add(Me.txtフリー名)
        Me.フリー.Controls.Add(Me.txtフリー姓)
        Me.フリー.Controls.Add(Me.txtフリー名カナ)
        Me.フリー.Controls.Add(Me.txtフリー姓カナ)
        Me.フリー.Controls.Add(Me.Label19)
        Me.フリー.Controls.Add(Me.Label20)
        Me.フリー.Controls.Add(Me.Label21)
        Me.フリー.Location = New System.Drawing.Point(4, 22)
        Me.フリー.Name = "フリー"
        Me.フリー.Padding = New System.Windows.Forms.Padding(3)
        Me.フリー.Size = New System.Drawing.Size(622, 299)
        Me.フリー.TabIndex = 3
        Me.フリー.Text = " フ リ ー "
        Me.フリー.UseVisualStyleBackColor = True
        '
        'lblフリー顧客番号
        '
        Me.lblフリー顧客番号.BackColor = System.Drawing.Color.White
        Me.lblフリー顧客番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblフリー顧客番号.Location = New System.Drawing.Point(88, 19)
        Me.lblフリー顧客番号.Name = "lblフリー顧客番号"
        Me.lblフリー顧客番号.Size = New System.Drawing.Size(80, 20)
        Me.lblフリー顧客番号.TabIndex = 20
        Me.lblフリー顧客番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtフリー名
        '
        Me.txtフリー名.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtフリー名.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtフリー名.Location = New System.Drawing.Point(262, 55)
        Me.txtフリー名.MaxLength = 16
        Me.txtフリー名.Name = "txtフリー名"
        Me.txtフリー名.Size = New System.Drawing.Size(170, 20)
        Me.txtフリー名.TabIndex = 3
        '
        'txtフリー姓
        '
        Me.txtフリー姓.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtフリー姓.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtフリー姓.Location = New System.Drawing.Point(88, 55)
        Me.txtフリー姓.MaxLength = 16
        Me.txtフリー姓.Name = "txtフリー姓"
        Me.txtフリー姓.Size = New System.Drawing.Size(170, 20)
        Me.txtフリー姓.TabIndex = 1
        '
        'txtフリー名カナ
        '
        Me.txtフリー名カナ.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtフリー名カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtフリー名カナ.Location = New System.Drawing.Point(262, 81)
        Me.txtフリー名カナ.MaxLength = 32
        Me.txtフリー名カナ.Name = "txtフリー名カナ"
        Me.txtフリー名カナ.Size = New System.Drawing.Size(170, 20)
        Me.txtフリー名カナ.TabIndex = 4
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label19.Location = New System.Drawing.Point(52, 84)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(36, 13)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "カナ :"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(48, 58)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "氏名 :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label21.Location = New System.Drawing.Point(22, 22)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(66, 13)
        Me.Label21.TabIndex = 16
        Me.Label21.Text = "顧客番号 :"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btn来店登録
        '
        Me.btn来店登録.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn来店登録.Location = New System.Drawing.Point(649, 34)
        Me.btn来店登録.Name = "btn来店登録"
        Me.btn来店登録.Size = New System.Drawing.Size(100, 30)
        Me.btn来店登録.TabIndex = 1
        Me.btn来店登録.Text = "登録"
        Me.btn来店登録.UseVisualStyleBackColor = True
        '
        'btn空番
        '
        Me.btn空番.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn空番.Location = New System.Drawing.Point(649, 136)
        Me.btn空番.Name = "btn空番"
        Me.btn空番.Size = New System.Drawing.Size(100, 23)
        Me.btn空番.TabIndex = 3
        Me.btn空番.Text = "空番号"
        Me.btn空番.UseVisualStyleBackColor = True
        '
        'btn設定
        '
        Me.btn設定.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn設定.Location = New System.Drawing.Point(649, 172)
        Me.btn設定.Name = "btn設定"
        Me.btn設定.Size = New System.Drawing.Size(100, 23)
        Me.btn設定.TabIndex = 4
        Me.btn設定.Text = "顧客番号設定"
        Me.btn設定.UseVisualStyleBackColor = True
        '
        'btnクリア
        '
        Me.btnクリア.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnクリア.Location = New System.Drawing.Point(649, 244)
        Me.btnクリア.Name = "btnクリア"
        Me.btnクリア.Size = New System.Drawing.Size(100, 23)
        Me.btnクリア.TabIndex = 6
        Me.btnクリア.Text = "項目クリア"
        Me.btnクリア.UseVisualStyleBackColor = True
        '
        'btn閉じる
        '
        Me.btn閉じる.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btn閉じる.Location = New System.Drawing.Point(649, 293)
        Me.btn閉じる.Name = "btn閉じる"
        Me.btn閉じる.Size = New System.Drawing.Size(100, 23)
        Me.btn閉じる.TabIndex = 7
        Me.btn閉じる.Text = "閉じる"
        Me.btn閉じる.UseVisualStyleBackColor = True
        '
        'カードあり
        '
        Me.カードあり.Controls.Add(Me.TextBox15)
        Me.カードあり.Controls.Add(Me.Label10)
        Me.カードあり.Controls.Add(Me.TextBox16)
        Me.カードあり.Controls.Add(Me.TextBox17)
        Me.カードあり.Controls.Add(Me.Label11)
        Me.カードあり.Controls.Add(Me.TextBox18)
        Me.カードあり.Controls.Add(Me.TextBox19)
        Me.カードあり.Controls.Add(Me.Label12)
        Me.カードあり.Controls.Add(Me.TextBox20)
        Me.カードあり.Controls.Add(Me.Label13)
        Me.カードあり.Controls.Add(Me.TextBox21)
        Me.カードあり.Controls.Add(Me.Label14)
        Me.カードあり.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.カードあり.Location = New System.Drawing.Point(4, 22)
        Me.カードあり.Name = "カードあり"
        Me.カードあり.Padding = New System.Windows.Forms.Padding(3)
        Me.カードあり.Size = New System.Drawing.Size(432, 307)
        Me.カードあり.TabIndex = 0
        Me.カードあり.Text = "顧客番号"
        Me.カードあり.UseVisualStyleBackColor = True
        '
        'TextBox15
        '
        Me.TextBox15.Location = New System.Drawing.Point(88, 123)
        Me.TextBox15.Multiline = True
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(284, 126)
        Me.TextBox15.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(39, 126)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "カルテ : "
        '
        'TextBox16
        '
        Me.TextBox16.Location = New System.Drawing.Point(196, 97)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(108, 20)
        Me.TextBox16.TabIndex = 9
        '
        'TextBox17
        '
        Me.TextBox17.Location = New System.Drawing.Point(88, 97)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(108, 20)
        Me.TextBox17.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(48, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "氏名 : "
        '
        'TextBox18
        '
        Me.TextBox18.Location = New System.Drawing.Point(196, 71)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(108, 20)
        Me.TextBox18.TabIndex = 6
        '
        'TextBox19
        '
        Me.TextBox19.Location = New System.Drawing.Point(88, 71)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New System.Drawing.Size(108, 20)
        Me.TextBox19.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(52, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "カナ : "
        '
        'TextBox20
        '
        Me.TextBox20.Location = New System.Drawing.Point(88, 45)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(216, 20)
        Me.TextBox20.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(48, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "住所 : "
        '
        'TextBox21
        '
        Me.TextBox21.Location = New System.Drawing.Point(88, 19)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(80, 20)
        Me.TextBox21.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label14.Location = New System.Drawing.Point(22, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "顧客番号 : "
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.ListBox2)
        Me.TabPage4.Controls.Add(Me.TextBox22)
        Me.TabPage4.Controls.Add(Me.TextBox23)
        Me.TabPage4.Controls.Add(Me.Label15)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(432, 307)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "顧客氏名"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(81, 47)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(324, 238)
        Me.ListBox2.TabIndex = 3
        '
        'TextBox22
        '
        Me.TextBox22.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox22.Location = New System.Drawing.Point(187, 20)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New System.Drawing.Size(100, 20)
        Me.TextBox22.TabIndex = 2
        '
        'TextBox23
        '
        Me.TextBox23.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox23.Location = New System.Drawing.Point(81, 20)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(100, 20)
        Me.TextBox23.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label15.Location = New System.Drawing.Point(19, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "顧客カナ : "
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.TextBox24)
        Me.TabPage5.Controls.Add(Me.TextBox25)
        Me.TabPage5.Controls.Add(Me.TextBox26)
        Me.TabPage5.Controls.Add(Me.TextBox27)
        Me.TabPage5.Controls.Add(Me.Label16)
        Me.TabPage5.Controls.Add(Me.Label17)
        Me.TabPage5.Controls.Add(Me.TextBox28)
        Me.TabPage5.Controls.Add(Me.Label18)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(432, 307)
        Me.TabPage5.TabIndex = 2
        Me.TabPage5.Text = "新規"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TextBox24
        '
        Me.TextBox24.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox24.Location = New System.Drawing.Point(196, 45)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New System.Drawing.Size(108, 20)
        Me.TextBox24.TabIndex = 15
        '
        'TextBox25
        '
        Me.TextBox25.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox25.Location = New System.Drawing.Point(88, 45)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New System.Drawing.Size(108, 20)
        Me.TextBox25.TabIndex = 14
        '
        'TextBox26
        '
        Me.TextBox26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox26.Location = New System.Drawing.Point(196, 71)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(108, 20)
        Me.TextBox26.TabIndex = 13
        '
        'TextBox27
        '
        Me.TextBox27.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox27.Location = New System.Drawing.Point(88, 71)
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New System.Drawing.Size(108, 20)
        Me.TextBox27.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label16.Location = New System.Drawing.Point(52, 74)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "カナ : "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label17.Location = New System.Drawing.Point(48, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 13)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "氏名 : "
        '
        'TextBox28
        '
        Me.TextBox28.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TextBox28.Location = New System.Drawing.Point(88, 19)
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New System.Drawing.Size(80, 20)
        Me.TextBox28.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label18.Location = New System.Drawing.Point(22, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(70, 13)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "顧客番号 : "
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnカルテ
        '
        Me.btnカルテ.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnカルテ.Location = New System.Drawing.Point(649, 208)
        Me.btnカルテ.Name = "btnカルテ"
        Me.btnカルテ.Size = New System.Drawing.Size(100, 23)
        Me.btnカルテ.TabIndex = 5
        Me.btnカルテ.Text = "カルテ"
        Me.btnカルテ.UseVisualStyleBackColor = True
        '
        'txtCustomerNum
        '
        Me.txtCustomerNum.Location = New System.Drawing.Point(649, 12)
        Me.txtCustomerNum.Name = "txtCustomerNum"
        Me.txtCustomerNum.Size = New System.Drawing.Size(100, 19)
        Me.txtCustomerNum.TabIndex = 8
        Me.txtCustomerNum.Visible = False
        '
        'a0300_来店
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(761, 349)
        Me.Controls.Add(Me.txtCustomerNum)
        Me.Controls.Add(Me.btn待ち)
        Me.Controls.Add(Me.btnカルテ)
        Me.Controls.Add(Me.btn閉じる)
        Me.Controls.Add(Me.btnクリア)
        Me.Controls.Add(Me.btn設定)
        Me.Controls.Add(Me.btn空番)
        Me.Controls.Add(Me.btn来店登録)
        Me.Controls.Add(Me.tc来店状況)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "a0300_来店"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 来店"
        Me.tc来店状況.ResumeLayout(False)
        Me.顧客番号.ResumeLayout(False)
        Me.顧客番号.PerformLayout()
        Me.カードなし.ResumeLayout(False)
        Me.カードなし.PerformLayout()
        CType(Me.dgv顧客一覧, System.ComponentModel.ISupportInitialize).EndInit()
        Me.新規.ResumeLayout(False)
        Me.新規.PerformLayout()
        Me.フリー.ResumeLayout(False)
        Me.フリー.PerformLayout()
        Me.カードあり.ResumeLayout(False)
        Me.カードあり.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tc来店状況 As System.Windows.Forms.TabControl
    Friend WithEvents カードなし As System.Windows.Forms.TabPage
    Friend WithEvents 新規 As System.Windows.Forms.TabPage
    Friend WithEvents btn来店登録 As System.Windows.Forms.Button
    Friend WithEvents btn空番 As System.Windows.Forms.Button
    Friend WithEvents btn設定 As System.Windows.Forms.Button
    Friend WithEvents btnクリア As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btn閉じる As System.Windows.Forms.Button
    Friend WithEvents txtカードなし姓カナ As System.Windows.Forms.TextBox
    Friend WithEvents txtカードなし名カナ As System.Windows.Forms.TextBox
    Friend WithEvents txt新規名カナ As System.Windows.Forms.TextBox
    Friend WithEvents txt新規姓カナ As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt新規名 As System.Windows.Forms.TextBox
    Friend WithEvents フリー As System.Windows.Forms.TabPage
    Friend WithEvents カードあり As System.Windows.Forms.TabPage
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox19 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox21 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TextBox24 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox25 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox27 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBox28 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents 顧客番号 As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtフリー名 As System.Windows.Forms.TextBox
    Friend WithEvents txtフリー姓 As System.Windows.Forms.TextBox
    Friend WithEvents txtフリー名カナ As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt新規姓 As System.Windows.Forms.TextBox
    Friend WithEvents txtフリー姓カナ As System.Windows.Forms.TextBox
    Friend WithEvents txtカードあり顧客番号 As System.Windows.Forms.TextBox
    Friend WithEvents dgv顧客一覧 As System.Windows.Forms.DataGridView
    Friend WithEvents btnカルテ As System.Windows.Forms.Button
    Friend WithEvents lbl住所 As System.Windows.Forms.Label
    Friend WithEvents lbl名カナ As System.Windows.Forms.Label
    Friend WithEvents lbl姓 As System.Windows.Forms.Label
    Friend WithEvents lbl名 As System.Windows.Forms.Label
    Friend WithEvents lbl姓カナ As System.Windows.Forms.Label
    Friend WithEvents lblカルテ As System.Windows.Forms.Label
    Friend WithEvents lbl新規顧客番号 As System.Windows.Forms.Label
    Friend WithEvents lblフリー顧客番号 As System.Windows.Forms.Label
    Friend WithEvents btn待ち As System.Windows.Forms.Button
    Friend WithEvents txtCustomerNum As System.Windows.Forms.TextBox
    Friend WithEvents lbl町域 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
