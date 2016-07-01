<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class z_0500_顧客変更
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(z_0500_顧客変更))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.姓 = New System.Windows.Forms.TextBox
        Me.名 = New System.Windows.Forms.TextBox
        Me.姓カナ = New System.Windows.Forms.TextBox
        Me.名カナ = New System.Windows.Forms.TextBox
        Me.来店日 = New System.Windows.Forms.TextBox
        Me.来店者番号 = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.登録区分番号 = New System.Windows.Forms.ComboBox
        Me.メールアドレス = New System.Windows.Forms.TextBox
        Me.電話番号 = New System.Windows.Forms.TextBox
        Me.住所３ = New System.Windows.Forms.TextBox
        Me.住所２ = New System.Windows.Forms.TextBox
        Me.住所１ = New System.Windows.Forms.TextBox
        Me.都道府県 = New System.Windows.Forms.TextBox
        Me.郵便番号 = New System.Windows.Forms.TextBox
        Me.郵便番号ラベル = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.電話番号ラベル = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.生年月日 = New System.Windows.Forms.Label
        Me.趣味 = New System.Windows.Forms.TextBox
        Me.家族名 = New System.Windows.Forms.TextBox
        Me.性別番号 = New System.Windows.Forms.ComboBox
        Me.元号生年月日 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.lbl登録日 = New System.Windows.Forms.Label
        Me.lbl来店日N_2 = New System.Windows.Forms.Label
        Me.lbl来店日N_1 = New System.Windows.Forms.Label
        Me.lbl前回来店日 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.主担当者 = New System.Windows.Forms.ComboBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.紹介者 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.メモ = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.嫌いな話題 = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.好きな話題 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.btn顧客検索 = New System.Windows.Forms.Button
        Me.郵便番号検索 = New System.Windows.Forms.Button
        Me.変更 = New System.Windows.Forms.Button
        Me.削除 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.lbl顧客番号 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "顧客番号 :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(7, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "氏名 :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "カナ :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '姓
        '
        Me.姓.BackColor = System.Drawing.Color.White
        Me.姓.ForeColor = System.Drawing.Color.Black
        Me.姓.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.姓.Location = New System.Drawing.Point(85, 43)
        Me.姓.MaxLength = 16
        Me.姓.Name = "姓"
        Me.姓.Size = New System.Drawing.Size(160, 20)
        Me.姓.TabIndex = 2
        '
        '名
        '
        Me.名.BackColor = System.Drawing.Color.White
        Me.名.ForeColor = System.Drawing.Color.Black
        Me.名.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.名.Location = New System.Drawing.Point(251, 43)
        Me.名.MaxLength = 16
        Me.名.Name = "名"
        Me.名.Size = New System.Drawing.Size(160, 20)
        Me.名.TabIndex = 4
        '
        '姓カナ
        '
        Me.姓カナ.BackColor = System.Drawing.Color.White
        Me.姓カナ.ForeColor = System.Drawing.Color.Black
        Me.姓カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.姓カナ.Location = New System.Drawing.Point(85, 72)
        Me.姓カナ.MaxLength = 32
        Me.姓カナ.Name = "姓カナ"
        Me.姓カナ.Size = New System.Drawing.Size(160, 20)
        Me.姓カナ.TabIndex = 3
        '
        '名カナ
        '
        Me.名カナ.BackColor = System.Drawing.Color.White
        Me.名カナ.ForeColor = System.Drawing.Color.Black
        Me.名カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.名カナ.Location = New System.Drawing.Point(251, 72)
        Me.名カナ.MaxLength = 32
        Me.名カナ.Name = "名カナ"
        Me.名カナ.Size = New System.Drawing.Size(160, 20)
        Me.名カナ.TabIndex = 5
        '
        '来店日
        '
        Me.来店日.Enabled = False
        Me.来店日.Location = New System.Drawing.Point(429, 43)
        Me.来店日.Name = "来店日"
        Me.来店日.Size = New System.Drawing.Size(10, 20)
        Me.来店日.TabIndex = 6
        Me.来店日.Visible = False
        '
        '来店者番号
        '
        Me.来店者番号.Location = New System.Drawing.Point(429, 73)
        Me.来店者番号.Name = "来店者番号"
        Me.来店者番号.Size = New System.Drawing.Size(10, 20)
        Me.来店者番号.TabIndex = 7
        Me.来店者番号.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(14, 107)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(399, 376)
        Me.TabControl1.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label29)
        Me.TabPage1.Controls.Add(Me.Label27)
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.登録区分番号)
        Me.TabPage1.Controls.Add(Me.メールアドレス)
        Me.TabPage1.Controls.Add(Me.電話番号)
        Me.TabPage1.Controls.Add(Me.住所３)
        Me.TabPage1.Controls.Add(Me.住所２)
        Me.TabPage1.Controls.Add(Me.住所１)
        Me.TabPage1.Controls.Add(Me.都道府県)
        Me.TabPage1.Controls.Add(Me.郵便番号)
        Me.TabPage1.Controls.Add(Me.郵便番号ラベル)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.電話番号ラベル)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(391, 350)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "　住　所　"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(266, 92)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(112, 20)
        Me.Label29.TabIndex = 20
        Me.Label29.Text = "（例 : 雪ノ下）"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(266, 66)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(112, 20)
        Me.Label27.TabIndex = 19
        Me.Label27.Text = "（例 : 鎌倉市）"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(266, 40)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(112, 20)
        Me.Label26.TabIndex = 18
        Me.Label26.Text = "（例 : 神奈川県）"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(15, 220)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(359, 20)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "注）　町域に番地を入力しないでください"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '登録区分番号
        '
        Me.登録区分番号.BackColor = System.Drawing.Color.White
        Me.登録区分番号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.登録区分番号.ForeColor = System.Drawing.Color.Black
        Me.登録区分番号.FormattingEnabled = True
        Me.登録区分番号.Location = New System.Drawing.Point(109, 197)
        Me.登録区分番号.Name = "登録区分番号"
        Me.登録区分番号.Size = New System.Drawing.Size(102, 21)
        Me.登録区分番号.TabIndex = 16
        Me.登録区分番号.Tag = "15"
        '
        'メールアドレス
        '
        Me.メールアドレス.BackColor = System.Drawing.Color.White
        Me.メールアドレス.ForeColor = System.Drawing.Color.Black
        Me.メールアドレス.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.メールアドレス.Location = New System.Drawing.Point(109, 171)
        Me.メールアドレス.MaxLength = 256
        Me.メールアドレス.Name = "メールアドレス"
        Me.メールアドレス.Size = New System.Drawing.Size(264, 20)
        Me.メールアドレス.TabIndex = 14
        '
        '電話番号
        '
        Me.電話番号.BackColor = System.Drawing.Color.White
        Me.電話番号.ForeColor = System.Drawing.Color.Black
        Me.電話番号.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.電話番号.Location = New System.Drawing.Point(109, 145)
        Me.電話番号.MaxLength = 19
        Me.電話番号.Name = "電話番号"
        Me.電話番号.Size = New System.Drawing.Size(152, 20)
        Me.電話番号.TabIndex = 13
        Me.電話番号.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        '住所３
        '
        Me.住所３.BackColor = System.Drawing.Color.White
        Me.住所３.ForeColor = System.Drawing.Color.Black
        Me.住所３.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.住所３.Location = New System.Drawing.Point(109, 119)
        Me.住所３.MaxLength = 64
        Me.住所３.Name = "住所３"
        Me.住所３.Size = New System.Drawing.Size(264, 20)
        Me.住所３.TabIndex = 12
        '
        '住所２
        '
        Me.住所２.BackColor = System.Drawing.Color.White
        Me.住所２.ForeColor = System.Drawing.Color.Black
        Me.住所２.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.住所２.Location = New System.Drawing.Point(109, 93)
        Me.住所２.MaxLength = 64
        Me.住所２.Name = "住所２"
        Me.住所２.Size = New System.Drawing.Size(152, 20)
        Me.住所２.TabIndex = 11
        '
        '住所１
        '
        Me.住所１.BackColor = System.Drawing.Color.White
        Me.住所１.ForeColor = System.Drawing.Color.Black
        Me.住所１.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.住所１.Location = New System.Drawing.Point(109, 67)
        Me.住所１.MaxLength = 64
        Me.住所１.Name = "住所１"
        Me.住所１.Size = New System.Drawing.Size(152, 20)
        Me.住所１.TabIndex = 10
        '
        '都道府県
        '
        Me.都道府県.BackColor = System.Drawing.Color.White
        Me.都道府県.ForeColor = System.Drawing.Color.Black
        Me.都道府県.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.都道府県.Location = New System.Drawing.Point(109, 41)
        Me.都道府県.MaxLength = 8
        Me.都道府県.Name = "都道府県"
        Me.都道府県.Size = New System.Drawing.Size(152, 20)
        Me.都道府県.TabIndex = 9
        '
        '郵便番号
        '
        Me.郵便番号.BackColor = System.Drawing.Color.White
        Me.郵便番号.ForeColor = System.Drawing.Color.Black
        Me.郵便番号.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.郵便番号.Location = New System.Drawing.Point(109, 15)
        Me.郵便番号.MaxLength = 8
        Me.郵便番号.Name = "郵便番号"
        Me.郵便番号.Size = New System.Drawing.Size(152, 20)
        Me.郵便番号.TabIndex = 8
        Me.郵便番号.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        '郵便番号ラベル
        '
        Me.郵便番号ラベル.Location = New System.Drawing.Point(8, 66)
        Me.郵便番号ラベル.Name = "郵便番号ラベル"
        Me.郵便番号ラベル.Size = New System.Drawing.Size(95, 20)
        Me.郵便番号ラベル.TabIndex = 8
        Me.郵便番号ラベル.Text = "市区町村 :"
        Me.郵便番号ラベル.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 20)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "町域 :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 20)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "番地･建物等 :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '電話番号ラベル
        '
        Me.電話番号ラベル.Location = New System.Drawing.Point(8, 144)
        Me.電話番号ラベル.Name = "電話番号ラベル"
        Me.電話番号ラベル.Size = New System.Drawing.Size(95, 20)
        Me.電話番号ラベル.TabIndex = 5
        Me.電話番号ラベル.Text = "電話番号 :"
        Me.電話番号ラベル.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 20)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "E-mailｱﾄﾞﾚｽ :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 20)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "登録区分 :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 20)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "都道府県 :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "〒 :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.生年月日)
        Me.TabPage2.Controls.Add(Me.趣味)
        Me.TabPage2.Controls.Add(Me.家族名)
        Me.TabPage2.Controls.Add(Me.性別番号)
        Me.TabPage2.Controls.Add(Me.元号生年月日)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(391, 350)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "　個人情報　"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        '生年月日
        '
        Me.生年月日.BackColor = System.Drawing.Color.White
        Me.生年月日.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.生年月日.Location = New System.Drawing.Point(109, 41)
        Me.生年月日.Name = "生年月日"
        Me.生年月日.Size = New System.Drawing.Size(152, 20)
        Me.生年月日.TabIndex = 17
        Me.生年月日.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '趣味
        '
        Me.趣味.ForeColor = System.Drawing.Color.Black
        Me.趣味.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.趣味.Location = New System.Drawing.Point(109, 120)
        Me.趣味.MaxLength = 32
        Me.趣味.Multiline = True
        Me.趣味.Name = "趣味"
        Me.趣味.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.趣味.Size = New System.Drawing.Size(260, 57)
        Me.趣味.TabIndex = 20
        '
        '家族名
        '
        Me.家族名.ForeColor = System.Drawing.Color.Black
        Me.家族名.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.家族名.Location = New System.Drawing.Point(109, 94)
        Me.家族名.MaxLength = 32
        Me.家族名.Name = "家族名"
        Me.家族名.Size = New System.Drawing.Size(260, 20)
        Me.家族名.TabIndex = 19
        '
        '性別番号
        '
        Me.性別番号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.性別番号.ForeColor = System.Drawing.Color.Black
        Me.性別番号.FormattingEnabled = True
        Me.性別番号.Location = New System.Drawing.Point(109, 67)
        Me.性別番号.Name = "性別番号"
        Me.性別番号.Size = New System.Drawing.Size(100, 21)
        Me.性別番号.TabIndex = 18
        '
        '元号生年月日
        '
        Me.元号生年月日.ForeColor = System.Drawing.Color.Black
        Me.元号生年月日.Location = New System.Drawing.Point(109, 15)
        Me.元号生年月日.Name = "元号生年月日"
        Me.元号生年月日.Size = New System.Drawing.Size(152, 20)
        Me.元号生年月日.TabIndex = 16
        Me.元号生年月日.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(8, 91)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(95, 20)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "家族名 :"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 119)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 20)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "趣味 :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(95, 20)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "性別 :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(95, 20)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "(西暦) :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 20)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "生年月日 :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lbl登録日)
        Me.TabPage3.Controls.Add(Me.lbl来店日N_2)
        Me.TabPage3.Controls.Add(Me.lbl来店日N_1)
        Me.TabPage3.Controls.Add(Me.lbl前回来店日)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.主担当者)
        Me.TabPage3.Controls.Add(Me.Label28)
        Me.TabPage3.Controls.Add(Me.Label25)
        Me.TabPage3.Controls.Add(Me.Label24)
        Me.TabPage3.Controls.Add(Me.紹介者)
        Me.TabPage3.Controls.Add(Me.Label23)
        Me.TabPage3.Controls.Add(Me.メモ)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.嫌いな話題)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.好きな話題)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(391, 350)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "　店使用　"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lbl登録日
        '
        Me.lbl登録日.BackColor = System.Drawing.Color.White
        Me.lbl登録日.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl登録日.Location = New System.Drawing.Point(109, 320)
        Me.lbl登録日.Name = "lbl登録日"
        Me.lbl登録日.Size = New System.Drawing.Size(118, 20)
        Me.lbl登録日.TabIndex = 29
        Me.lbl登録日.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl来店日N_2
        '
        Me.lbl来店日N_2.BackColor = System.Drawing.Color.White
        Me.lbl来店日N_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl来店日N_2.Location = New System.Drawing.Point(109, 294)
        Me.lbl来店日N_2.Name = "lbl来店日N_2"
        Me.lbl来店日N_2.Size = New System.Drawing.Size(118, 20)
        Me.lbl来店日N_2.TabIndex = 28
        Me.lbl来店日N_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl来店日N_1
        '
        Me.lbl来店日N_1.BackColor = System.Drawing.Color.White
        Me.lbl来店日N_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl来店日N_1.Location = New System.Drawing.Point(109, 268)
        Me.lbl来店日N_1.Name = "lbl来店日N_1"
        Me.lbl来店日N_1.Size = New System.Drawing.Size(118, 20)
        Me.lbl来店日N_1.TabIndex = 27
        Me.lbl来店日N_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl前回来店日
        '
        Me.lbl前回来店日.BackColor = System.Drawing.Color.White
        Me.lbl前回来店日.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl前回来店日.Location = New System.Drawing.Point(109, 242)
        Me.lbl前回来店日.Name = "lbl前回来店日"
        Me.lbl前回来店日.Size = New System.Drawing.Size(118, 20)
        Me.lbl前回来店日.TabIndex = 26
        Me.lbl前回来店日.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(233, 297)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "（3回前）"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(233, 271)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "（2回前）"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(233, 245)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "（前回）"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '主担当者
        '
        Me.主担当者.BackColor = System.Drawing.Color.White
        Me.主担当者.DropDownWidth = 450
        Me.主担当者.ForeColor = System.Drawing.Color.Black
        Me.主担当者.FormattingEnabled = True
        Me.主担当者.Location = New System.Drawing.Point(109, 215)
        Me.主担当者.Name = "主担当者"
        Me.主担当者.Size = New System.Drawing.Size(154, 21)
        Me.主担当者.TabIndex = 25
        Me.主担当者.Tag = ""
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(8, 241)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(95, 20)
        Me.Label28.TabIndex = 15
        Me.Label28.Text = "来店履歴 :"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(8, 319)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(95, 20)
        Me.Label25.TabIndex = 12
        Me.Label25.Text = "登録日 :"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(8, 214)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(95, 20)
        Me.Label24.TabIndex = 11
        Me.Label24.Text = "主担当 :"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '紹介者
        '
        Me.紹介者.BackColor = System.Drawing.Color.White
        Me.紹介者.ForeColor = System.Drawing.Color.Black
        Me.紹介者.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.紹介者.Location = New System.Drawing.Point(109, 189)
        Me.紹介者.MaxLength = 32
        Me.紹介者.Name = "紹介者"
        Me.紹介者.Size = New System.Drawing.Size(154, 20)
        Me.紹介者.TabIndex = 24
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(8, 188)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(95, 20)
        Me.Label23.TabIndex = 9
        Me.Label23.Text = "紹介者 :"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'メモ
        '
        Me.メモ.BackColor = System.Drawing.Color.White
        Me.メモ.ForeColor = System.Drawing.Color.Black
        Me.メモ.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.メモ.Location = New System.Drawing.Point(109, 131)
        Me.メモ.MaxLength = 32
        Me.メモ.Multiline = True
        Me.メモ.Name = "メモ"
        Me.メモ.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.メモ.Size = New System.Drawing.Size(266, 52)
        Me.メモ.TabIndex = 23
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(8, 130)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(95, 20)
        Me.Label22.TabIndex = 7
        Me.Label22.Text = "メモ :"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '嫌いな話題
        '
        Me.嫌いな話題.BackColor = System.Drawing.Color.White
        Me.嫌いな話題.ForeColor = System.Drawing.Color.Red
        Me.嫌いな話題.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.嫌いな話題.Location = New System.Drawing.Point(109, 73)
        Me.嫌いな話題.MaxLength = 32
        Me.嫌いな話題.Multiline = True
        Me.嫌いな話題.Name = "嫌いな話題"
        Me.嫌いな話題.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.嫌いな話題.Size = New System.Drawing.Size(266, 52)
        Me.嫌いな話題.TabIndex = 22
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(8, 72)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(95, 20)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "嫌いな話題 :"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '好きな話題
        '
        Me.好きな話題.BackColor = System.Drawing.Color.White
        Me.好きな話題.ForeColor = System.Drawing.Color.Blue
        Me.好きな話題.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.好きな話題.Location = New System.Drawing.Point(109, 15)
        Me.好きな話題.MaxLength = 32
        Me.好きな話題.Multiline = True
        Me.好きな話題.Name = "好きな話題"
        Me.好きな話題.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.好きな話題.Size = New System.Drawing.Size(266, 52)
        Me.好きな話題.TabIndex = 21
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(8, 14)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(95, 20)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "好きな話題 :"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn顧客検索
        '
        Me.btn顧客検索.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.btn顧客検索.Location = New System.Drawing.Point(425, 130)
        Me.btn顧客検索.Name = "btn顧客検索"
        Me.btn顧客検索.Size = New System.Drawing.Size(100, 23)
        Me.btn顧客検索.TabIndex = 30
        Me.btn顧客検索.Text = "顧客番号検索"
        Me.btn顧客検索.UseVisualStyleBackColor = True
        Me.btn顧客検索.Visible = False
        '
        '郵便番号検索
        '
        Me.郵便番号検索.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.郵便番号検索.Location = New System.Drawing.Point(425, 159)
        Me.郵便番号検索.Name = "郵便番号検索"
        Me.郵便番号検索.Size = New System.Drawing.Size(100, 23)
        Me.郵便番号検索.TabIndex = 31
        Me.郵便番号検索.Text = "郵便番号検索"
        Me.郵便番号検索.UseVisualStyleBackColor = True
        '
        '変更
        '
        Me.変更.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.変更.Location = New System.Drawing.Point(425, 200)
        Me.変更.Name = "変更"
        Me.変更.Size = New System.Drawing.Size(100, 23)
        Me.変更.TabIndex = 32
        Me.変更.Text = "変更"
        Me.変更.UseVisualStyleBackColor = True
        '
        '削除
        '
        Me.削除.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.削除.Location = New System.Drawing.Point(425, 229)
        Me.削除.Name = "削除"
        Me.削除.Size = New System.Drawing.Size(100, 23)
        Me.削除.TabIndex = 33
        Me.削除.Text = "削除"
        Me.削除.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.閉じる.Location = New System.Drawing.Point(425, 270)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 34
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'lbl顧客番号
        '
        Me.lbl顧客番号.BackColor = System.Drawing.Color.White
        Me.lbl顧客番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl顧客番号.Location = New System.Drawing.Point(85, 16)
        Me.lbl顧客番号.Name = "lbl顧客番号"
        Me.lbl顧客番号.Size = New System.Drawing.Size(72, 20)
        Me.lbl顧客番号.TabIndex = 1
        Me.lbl顧客番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'z_0500_顧客変更
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 499)
        Me.Controls.Add(Me.lbl顧客番号)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.削除)
        Me.Controls.Add(Me.変更)
        Me.Controls.Add(Me.郵便番号検索)
        Me.Controls.Add(Me.btn顧客検索)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.来店者番号)
        Me.Controls.Add(Me.来店日)
        Me.Controls.Add(Me.名カナ)
        Me.Controls.Add(Me.姓カナ)
        Me.Controls.Add(Me.名)
        Me.Controls.Add(Me.姓)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "z_0500_顧客変更"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 顧客変更"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents 姓 As System.Windows.Forms.TextBox
    Friend WithEvents 名 As System.Windows.Forms.TextBox
    Friend WithEvents 姓カナ As System.Windows.Forms.TextBox
    Friend WithEvents 名カナ As System.Windows.Forms.TextBox
    Friend WithEvents 来店日 As System.Windows.Forms.TextBox
    Friend WithEvents 来店者番号 As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btn顧客検索 As System.Windows.Forms.Button
    Friend WithEvents 郵便番号検索 As System.Windows.Forms.Button
    Friend WithEvents 変更 As System.Windows.Forms.Button
    Friend WithEvents 削除 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents 登録区分番号 As System.Windows.Forms.ComboBox
    Friend WithEvents メールアドレス As System.Windows.Forms.TextBox
    Friend WithEvents 電話番号 As System.Windows.Forms.TextBox
    Friend WithEvents 住所３ As System.Windows.Forms.TextBox
    Friend WithEvents 住所２ As System.Windows.Forms.TextBox
    Friend WithEvents 住所１ As System.Windows.Forms.TextBox
    Friend WithEvents 都道府県 As System.Windows.Forms.TextBox
    Friend WithEvents 郵便番号 As System.Windows.Forms.TextBox
    Friend WithEvents 郵便番号ラベル As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents 電話番号ラベル As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents 趣味 As System.Windows.Forms.TextBox
    Friend WithEvents 家族名 As System.Windows.Forms.TextBox
    Friend WithEvents 性別番号 As System.Windows.Forms.ComboBox
    Friend WithEvents 元号生年月日 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents 紹介者 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents メモ As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents 嫌いな話題 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents 好きな話題 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents 主担当者 As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents 生年月日 As System.Windows.Forms.Label
    Friend WithEvents lbl顧客番号 As System.Windows.Forms.Label
    Friend WithEvents lbl登録日 As System.Windows.Forms.Label
    Friend WithEvents lbl来店日N_2 As System.Windows.Forms.Label
    Friend WithEvents lbl来店日N_1 As System.Windows.Forms.Label
    Friend WithEvents lbl前回来店日 As System.Windows.Forms.Label
End Class
