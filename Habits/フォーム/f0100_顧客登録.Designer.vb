<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f0100_顧客登録
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(f0100_顧客登録))
        Me.Label1 = New System.Windows.Forms.Label
        Me.姓 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.姓カナ = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.名 = New System.Windows.Forms.TextBox
        Me.名カナ = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label27 = New System.Windows.Forms.Label
        Me.メールアドレス = New System.Windows.Forms.TextBox
        Me.住所３ = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.登録区分番号 = New System.Windows.Forms.ComboBox
        Me.電話番号 = New System.Windows.Forms.TextBox
        Me.住所２ = New System.Windows.Forms.TextBox
        Me.住所１ = New System.Windows.Forms.TextBox
        Me.都道府県 = New System.Windows.Forms.TextBox
        Me.郵便番号 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.電話番号ラベル = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.郵便番号ラベル = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lbl生年月日 = New System.Windows.Forms.Label
        Me.趣味 = New System.Windows.Forms.TextBox
        Me.家族名 = New System.Windows.Forms.TextBox
        Me.性別番号 = New System.Windows.Forms.ComboBox
        Me.趣味ラベル = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.元号生年月日 = New System.Windows.Forms.TextBox
        Me.生年月日ラベル = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.主担当者 = New System.Windows.Forms.ComboBox
        Me.紹介者 = New System.Windows.Forms.TextBox
        Me.担当者名ラベル = New System.Windows.Forms.Label
        Me.紹介者ラベル = New System.Windows.Forms.Label
        Me.メモラベル = New System.Windows.Forms.Label
        Me.メモ = New System.Windows.Forms.TextBox
        Me.嫌いな話題ラベル = New System.Windows.Forms.Label
        Me.嫌いな話題 = New System.Windows.Forms.TextBox
        Me.好きな話題 = New System.Windows.Forms.TextBox
        Me.好きな話題ラベル = New System.Windows.Forms.Label
        Me.登録 = New System.Windows.Forms.Button
        Me.郵便番号検索 = New System.Windows.Forms.Button
        Me.空番 = New System.Windows.Forms.Button
        Me.クリア = New System.Windows.Forms.Button
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
        Me.Label1.Location = New System.Drawing.Point(3, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "顧客番号 : "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '姓
        '
        Me.姓.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.姓.Location = New System.Drawing.Point(83, 42)
        Me.姓.MaxLength = 16
        Me.姓.Name = "姓"
        Me.姓.Size = New System.Drawing.Size(160, 20)
        Me.姓.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "氏名 : "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '姓カナ
        '
        Me.姓カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.姓カナ.Location = New System.Drawing.Point(83, 69)
        Me.姓カナ.MaxLength = 32
        Me.姓カナ.Name = "姓カナ"
        Me.姓カナ.Size = New System.Drawing.Size(160, 20)
        Me.姓カナ.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "カナ : "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '名
        '
        Me.名.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.名.Location = New System.Drawing.Point(249, 42)
        Me.名.MaxLength = 16
        Me.名.Name = "名"
        Me.名.Size = New System.Drawing.Size(160, 20)
        Me.名.TabIndex = 4
        '
        '名カナ
        '
        Me.名カナ.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.名カナ.Location = New System.Drawing.Point(249, 69)
        Me.名カナ.MaxLength = 32
        Me.名カナ.Name = "名カナ"
        Me.名カナ.Size = New System.Drawing.Size(160, 20)
        Me.名カナ.TabIndex = 5
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(14, 103)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(420, 288)
        Me.TabControl1.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label27)
        Me.TabPage1.Controls.Add(Me.メールアドレス)
        Me.TabPage1.Controls.Add(Me.住所３)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.登録区分番号)
        Me.TabPage1.Controls.Add(Me.電話番号)
        Me.TabPage1.Controls.Add(Me.住所２)
        Me.TabPage1.Controls.Add(Me.住所１)
        Me.TabPage1.Controls.Add(Me.都道府県)
        Me.TabPage1.Controls.Add(Me.郵便番号)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.電話番号ラベル)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.郵便番号ラベル)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(412, 262)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "　住　所　"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(14, 228)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(224, 13)
        Me.Label27.TabIndex = 19
        Me.Label27.Text = "注）　町域に番地を入力しないでください"
        '
        'メールアドレス
        '
        Me.メールアドレス.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.メールアドレス.Location = New System.Drawing.Point(109, 171)
        Me.メールアドレス.MaxLength = 256
        Me.メールアドレス.Name = "メールアドレス"
        Me.メールアドレス.Size = New System.Drawing.Size(283, 20)
        Me.メールアドレス.TabIndex = 12
        '
        '住所３
        '
        Me.住所３.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.住所３.Location = New System.Drawing.Point(109, 119)
        Me.住所３.MaxLength = 64
        Me.住所３.Name = "住所３"
        Me.住所３.Size = New System.Drawing.Size(283, 20)
        Me.住所３.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(281, 93)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 20)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "（例：雪ノ下）"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(281, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 20)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "（例：鎌倉市）"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(281, 41)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 20)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "（例：神奈川県）"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '登録区分番号
        '
        Me.登録区分番号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.登録区分番号.FormattingEnabled = True
        Me.登録区分番号.Location = New System.Drawing.Point(109, 197)
        Me.登録区分番号.Name = "登録区分番号"
        Me.登録区分番号.Size = New System.Drawing.Size(121, 21)
        Me.登録区分番号.TabIndex = 13
        '
        '電話番号
        '
        Me.電話番号.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.電話番号.Location = New System.Drawing.Point(109, 145)
        Me.電話番号.MaxLength = 19
        Me.電話番号.Name = "電話番号"
        Me.電話番号.Size = New System.Drawing.Size(164, 20)
        Me.電話番号.TabIndex = 11
        '
        '住所２
        '
        Me.住所２.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.住所２.Location = New System.Drawing.Point(109, 93)
        Me.住所２.MaxLength = 64
        Me.住所２.Name = "住所２"
        Me.住所２.Size = New System.Drawing.Size(164, 20)
        Me.住所２.TabIndex = 9
        '
        '住所１
        '
        Me.住所１.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.住所１.Location = New System.Drawing.Point(109, 67)
        Me.住所１.MaxLength = 64
        Me.住所１.Name = "住所１"
        Me.住所１.Size = New System.Drawing.Size(164, 20)
        Me.住所１.TabIndex = 8
        '
        '都道府県
        '
        Me.都道府県.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.都道府県.Location = New System.Drawing.Point(109, 41)
        Me.都道府県.MaxLength = 8
        Me.都道府県.Name = "都道府県"
        Me.都道府県.Size = New System.Drawing.Size(164, 20)
        Me.都道府県.TabIndex = 7
        '
        '郵便番号
        '
        Me.郵便番号.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.郵便番号.Location = New System.Drawing.Point(109, 15)
        Me.郵便番号.MaxLength = 8
        Me.郵便番号.Name = "郵便番号"
        Me.郵便番号.Size = New System.Drawing.Size(164, 20)
        Me.郵便番号.TabIndex = 6
        Me.郵便番号.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(14, 197)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 20)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "登録区分 : "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(14, 171)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 20)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "E-mailｱﾄﾞﾚｽ : "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '電話番号ラベル
        '
        Me.電話番号ラベル.Location = New System.Drawing.Point(14, 145)
        Me.電話番号ラベル.Name = "電話番号ラベル"
        Me.電話番号ラベル.Size = New System.Drawing.Size(95, 20)
        Me.電話番号ラベル.TabIndex = 5
        Me.電話番号ラベル.Text = "電話番号 : "
        Me.電話番号ラベル.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(14, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 20)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "番地・建物等 : "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(14, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "町域 : "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '郵便番号ラベル
        '
        Me.郵便番号ラベル.Location = New System.Drawing.Point(14, 67)
        Me.郵便番号ラベル.Name = "郵便番号ラベル"
        Me.郵便番号ラベル.Size = New System.Drawing.Size(95, 20)
        Me.郵便番号ラベル.TabIndex = 2
        Me.郵便番号ラベル.Text = "市区町村 : "
        Me.郵便番号ラベル.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(14, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "都道府県 : "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(14, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "〒 : "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lbl生年月日)
        Me.TabPage2.Controls.Add(Me.趣味)
        Me.TabPage2.Controls.Add(Me.家族名)
        Me.TabPage2.Controls.Add(Me.性別番号)
        Me.TabPage2.Controls.Add(Me.趣味ラベル)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.元号生年月日)
        Me.TabPage2.Controls.Add(Me.生年月日ラベル)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(412, 262)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "　個人情報　"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lbl生年月日
        '
        Me.lbl生年月日.BackColor = System.Drawing.Color.White
        Me.lbl生年月日.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl生年月日.Location = New System.Drawing.Point(109, 41)
        Me.lbl生年月日.Name = "lbl生年月日"
        Me.lbl生年月日.Size = New System.Drawing.Size(164, 20)
        Me.lbl生年月日.TabIndex = 15
        Me.lbl生年月日.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '趣味
        '
        Me.趣味.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.趣味.Location = New System.Drawing.Point(109, 116)
        Me.趣味.MaxLength = 32
        Me.趣味.Multiline = True
        Me.趣味.Name = "趣味"
        Me.趣味.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.趣味.Size = New System.Drawing.Size(283, 53)
        Me.趣味.TabIndex = 18
        '
        '家族名
        '
        Me.家族名.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.家族名.Location = New System.Drawing.Point(109, 91)
        Me.家族名.MaxLength = 32
        Me.家族名.Name = "家族名"
        Me.家族名.Size = New System.Drawing.Size(283, 20)
        Me.家族名.TabIndex = 17
        '
        '性別番号
        '
        Me.性別番号.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.性別番号.FormattingEnabled = True
        Me.性別番号.Location = New System.Drawing.Point(109, 66)
        Me.性別番号.Name = "性別番号"
        Me.性別番号.Size = New System.Drawing.Size(100, 21)
        Me.性別番号.TabIndex = 16
        '
        '趣味ラベル
        '
        Me.趣味ラベル.Location = New System.Drawing.Point(14, 116)
        Me.趣味ラベル.Name = "趣味ラベル"
        Me.趣味ラベル.Size = New System.Drawing.Size(95, 20)
        Me.趣味ラベル.TabIndex = 16
        Me.趣味ラベル.Text = "趣味 : "
        Me.趣味ラベル.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(14, 91)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(95, 20)
        Me.Label20.TabIndex = 15
        Me.Label20.Text = "家族名 : "
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(14, 67)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(95, 20)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "性別 : "
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(14, 41)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 20)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "(西暦) : "
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '元号生年月日
        '
        Me.元号生年月日.Location = New System.Drawing.Point(109, 15)
        Me.元号生年月日.Name = "元号生年月日"
        Me.元号生年月日.Size = New System.Drawing.Size(164, 20)
        Me.元号生年月日.TabIndex = 14
        Me.元号生年月日.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        '生年月日ラベル
        '
        Me.生年月日ラベル.Location = New System.Drawing.Point(14, 15)
        Me.生年月日ラベル.Name = "生年月日ラベル"
        Me.生年月日ラベル.Size = New System.Drawing.Size(95, 20)
        Me.生年月日ラベル.TabIndex = 1
        Me.生年月日ラベル.Text = "生年月日 : "
        Me.生年月日ラベル.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.主担当者)
        Me.TabPage3.Controls.Add(Me.紹介者)
        Me.TabPage3.Controls.Add(Me.担当者名ラベル)
        Me.TabPage3.Controls.Add(Me.紹介者ラベル)
        Me.TabPage3.Controls.Add(Me.メモラベル)
        Me.TabPage3.Controls.Add(Me.メモ)
        Me.TabPage3.Controls.Add(Me.嫌いな話題ラベル)
        Me.TabPage3.Controls.Add(Me.嫌いな話題)
        Me.TabPage3.Controls.Add(Me.好きな話題)
        Me.TabPage3.Controls.Add(Me.好きな話題ラベル)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(412, 262)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "　店使用　"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        '主担当者
        '
        Me.主担当者.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.主担当者.DropDownWidth = 450
        Me.主担当者.FormattingEnabled = True
        Me.主担当者.Location = New System.Drawing.Point(109, 230)
        Me.主担当者.Name = "主担当者"
        Me.主担当者.Size = New System.Drawing.Size(164, 21)
        Me.主担当者.TabIndex = 23
        '
        '紹介者
        '
        Me.紹介者.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.紹介者.Location = New System.Drawing.Point(109, 203)
        Me.紹介者.MaxLength = 32
        Me.紹介者.Name = "紹介者"
        Me.紹介者.Size = New System.Drawing.Size(164, 20)
        Me.紹介者.TabIndex = 22
        '
        '担当者名ラベル
        '
        Me.担当者名ラベル.Location = New System.Drawing.Point(14, 231)
        Me.担当者名ラベル.Name = "担当者名ラベル"
        Me.担当者名ラベル.Size = New System.Drawing.Size(95, 20)
        Me.担当者名ラベル.TabIndex = 29
        Me.担当者名ラベル.Text = "主担当 : "
        Me.担当者名ラベル.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '紹介者ラベル
        '
        Me.紹介者ラベル.Location = New System.Drawing.Point(14, 203)
        Me.紹介者ラベル.Name = "紹介者ラベル"
        Me.紹介者ラベル.Size = New System.Drawing.Size(95, 20)
        Me.紹介者ラベル.TabIndex = 28
        Me.紹介者ラベル.Text = "紹介者 : "
        Me.紹介者ラベル.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'メモラベル
        '
        Me.メモラベル.Location = New System.Drawing.Point(14, 141)
        Me.メモラベル.Name = "メモラベル"
        Me.メモラベル.Size = New System.Drawing.Size(95, 20)
        Me.メモラベル.TabIndex = 27
        Me.メモラベル.Text = "メモ : "
        Me.メモラベル.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'メモ
        '
        Me.メモ.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.メモ.Location = New System.Drawing.Point(109, 141)
        Me.メモ.MaxLength = 32
        Me.メモ.Multiline = True
        Me.メモ.Name = "メモ"
        Me.メモ.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.メモ.Size = New System.Drawing.Size(283, 53)
        Me.メモ.TabIndex = 21
        '
        '嫌いな話題ラベル
        '
        Me.嫌いな話題ラベル.Location = New System.Drawing.Point(14, 78)
        Me.嫌いな話題ラベル.Name = "嫌いな話題ラベル"
        Me.嫌いな話題ラベル.Size = New System.Drawing.Size(95, 20)
        Me.嫌いな話題ラベル.TabIndex = 25
        Me.嫌いな話題ラベル.Text = "嫌いな話題 : "
        Me.嫌いな話題ラベル.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '嫌いな話題
        '
        Me.嫌いな話題.ForeColor = System.Drawing.Color.Red
        Me.嫌いな話題.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.嫌いな話題.Location = New System.Drawing.Point(109, 78)
        Me.嫌いな話題.MaxLength = 32
        Me.嫌いな話題.Multiline = True
        Me.嫌いな話題.Name = "嫌いな話題"
        Me.嫌いな話題.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.嫌いな話題.Size = New System.Drawing.Size(283, 53)
        Me.嫌いな話題.TabIndex = 20
        '
        '好きな話題
        '
        Me.好きな話題.ForeColor = System.Drawing.Color.Blue
        Me.好きな話題.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.好きな話題.Location = New System.Drawing.Point(109, 15)
        Me.好きな話題.MaxLength = 32
        Me.好きな話題.Multiline = True
        Me.好きな話題.Name = "好きな話題"
        Me.好きな話題.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.好きな話題.Size = New System.Drawing.Size(283, 53)
        Me.好きな話題.TabIndex = 19
        '
        '好きな話題ラベル
        '
        Me.好きな話題ラベル.Location = New System.Drawing.Point(14, 15)
        Me.好きな話題ラベル.Name = "好きな話題ラベル"
        Me.好きな話題ラベル.Size = New System.Drawing.Size(95, 20)
        Me.好きな話題ラベル.TabIndex = 22
        Me.好きな話題ラベル.Text = "好きな話題 : "
        Me.好きな話題ラベル.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '登録
        '
        Me.登録.Location = New System.Drawing.Point(446, 126)
        Me.登録.Name = "登録"
        Me.登録.Size = New System.Drawing.Size(100, 23)
        Me.登録.TabIndex = 24
        Me.登録.Text = "登録"
        Me.登録.UseVisualStyleBackColor = True
        '
        '郵便番号検索
        '
        Me.郵便番号検索.Location = New System.Drawing.Point(446, 155)
        Me.郵便番号検索.Name = "郵便番号検索"
        Me.郵便番号検索.Size = New System.Drawing.Size(100, 23)
        Me.郵便番号検索.TabIndex = 25
        Me.郵便番号検索.Text = "郵便番号検索"
        Me.郵便番号検索.UseVisualStyleBackColor = True
        '
        '空番
        '
        Me.空番.Location = New System.Drawing.Point(446, 184)
        Me.空番.Name = "空番"
        Me.空番.Size = New System.Drawing.Size(100, 23)
        Me.空番.TabIndex = 26
        Me.空番.Text = "空番号"
        Me.空番.UseVisualStyleBackColor = True
        '
        'クリア
        '
        Me.クリア.Location = New System.Drawing.Point(446, 225)
        Me.クリア.Name = "クリア"
        Me.クリア.Size = New System.Drawing.Size(100, 23)
        Me.クリア.TabIndex = 27
        Me.クリア.Text = "項目クリア"
        Me.クリア.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(446, 254)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 28
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'lbl顧客番号
        '
        Me.lbl顧客番号.BackColor = System.Drawing.Color.White
        Me.lbl顧客番号.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl顧客番号.Location = New System.Drawing.Point(83, 15)
        Me.lbl顧客番号.Name = "lbl顧客番号"
        Me.lbl顧客番号.Size = New System.Drawing.Size(72, 20)
        Me.lbl顧客番号.TabIndex = 1
        Me.lbl顧客番号.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'f0100_顧客登録
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 407)
        Me.Controls.Add(Me.lbl顧客番号)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.クリア)
        Me.Controls.Add(Me.空番)
        Me.Controls.Add(Me.郵便番号検索)
        Me.Controls.Add(Me.登録)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.名カナ)
        Me.Controls.Add(Me.名)
        Me.Controls.Add(Me.姓カナ)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.姓)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "f0100_顧客登録"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 顧客登録"
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
    Friend WithEvents 姓 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 姓カナ As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents 名 As System.Windows.Forms.TextBox
    Friend WithEvents 名カナ As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents 登録 As System.Windows.Forms.Button
    Friend WithEvents 郵便番号検索 As System.Windows.Forms.Button
    Friend WithEvents 空番 As System.Windows.Forms.Button
    Friend WithEvents クリア As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents 電話番号ラベル As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents 郵便番号ラベル As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents メールアドレス As System.Windows.Forms.TextBox
    Friend WithEvents 住所３ As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents 登録区分番号 As System.Windows.Forms.ComboBox
    Friend WithEvents 電話番号 As System.Windows.Forms.TextBox
    Friend WithEvents 住所２ As System.Windows.Forms.TextBox
    Friend WithEvents 住所１ As System.Windows.Forms.TextBox
    Friend WithEvents 都道府県 As System.Windows.Forms.TextBox
    Friend WithEvents 郵便番号 As System.Windows.Forms.TextBox
    Friend WithEvents 趣味ラベル As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents 元号生年月日 As System.Windows.Forms.TextBox
    Friend WithEvents 生年月日ラベル As System.Windows.Forms.Label
    Friend WithEvents 趣味 As System.Windows.Forms.TextBox
    Friend WithEvents 家族名 As System.Windows.Forms.TextBox
    Friend WithEvents 性別番号 As System.Windows.Forms.ComboBox
    Friend WithEvents 嫌いな話題ラベル As System.Windows.Forms.Label
    Friend WithEvents 嫌いな話題 As System.Windows.Forms.TextBox
    Friend WithEvents 好きな話題 As System.Windows.Forms.TextBox
    Friend WithEvents 好きな話題ラベル As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents 主担当者 As System.Windows.Forms.ComboBox
    Friend WithEvents 紹介者 As System.Windows.Forms.TextBox
    Friend WithEvents 担当者名ラベル As System.Windows.Forms.Label
    Friend WithEvents 紹介者ラベル As System.Windows.Forms.Label
    Friend WithEvents メモラベル As System.Windows.Forms.Label
    Friend WithEvents メモ As System.Windows.Forms.TextBox
    Friend WithEvents lbl顧客番号 As System.Windows.Forms.Label
    Friend WithEvents lbl生年月日 As System.Windows.Forms.Label
End Class
