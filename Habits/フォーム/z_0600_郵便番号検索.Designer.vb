<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class z_0600_郵便番号検索
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(z_0600_郵便番号検索))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.都道府県 = New System.Windows.Forms.ComboBox
        Me.市区町村 = New System.Windows.Forms.ComboBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.あ行 = New System.Windows.Forms.TabPage
        Me.dgv町域名0 = New System.Windows.Forms.DataGridView
        Me.か行 = New System.Windows.Forms.TabPage
        Me.dgv町域名1 = New System.Windows.Forms.DataGridView
        Me.さ行 = New System.Windows.Forms.TabPage
        Me.dgv町域名2 = New System.Windows.Forms.DataGridView
        Me.た行 = New System.Windows.Forms.TabPage
        Me.dgv町域名3 = New System.Windows.Forms.DataGridView
        Me.な行 = New System.Windows.Forms.TabPage
        Me.dgv町域名4 = New System.Windows.Forms.DataGridView
        Me.は行 = New System.Windows.Forms.TabPage
        Me.dgv町域名5 = New System.Windows.Forms.DataGridView
        Me.ま行 = New System.Windows.Forms.TabPage
        Me.dgv町域名6 = New System.Windows.Forms.DataGridView
        Me.や行 = New System.Windows.Forms.TabPage
        Me.dgv町域名7 = New System.Windows.Forms.DataGridView
        Me.ら行 = New System.Windows.Forms.TabPage
        Me.dgv町域名8 = New System.Windows.Forms.DataGridView
        Me.わ行 = New System.Windows.Forms.TabPage
        Me.dgv町域名9 = New System.Windows.Forms.DataGridView
        Me.他行 = New System.Windows.Forms.TabPage
        Me.dgv町域名10 = New System.Windows.Forms.DataGridView
        Me.選択 = New System.Windows.Forms.Button
        Me.閉じる = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.あ行.SuspendLayout()
        CType(Me.dgv町域名0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.か行.SuspendLayout()
        CType(Me.dgv町域名1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.さ行.SuspendLayout()
        CType(Me.dgv町域名2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.た行.SuspendLayout()
        CType(Me.dgv町域名3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.な行.SuspendLayout()
        CType(Me.dgv町域名4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.は行.SuspendLayout()
        CType(Me.dgv町域名5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ま行.SuspendLayout()
        CType(Me.dgv町域名6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.や行.SuspendLayout()
        CType(Me.dgv町域名7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ら行.SuspendLayout()
        CType(Me.dgv町域名8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.わ行.SuspendLayout()
        CType(Me.dgv町域名9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.他行.SuspendLayout()
        CType(Me.dgv町域名10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "都道府県 :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "市区町村 :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '都道府県
        '
        Me.都道府県.BackColor = System.Drawing.Color.White
        Me.都道府県.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.都道府県.FormattingEnabled = True
        Me.都道府県.Location = New System.Drawing.Point(85, 15)
        Me.都道府県.Name = "都道府県"
        Me.都道府県.Size = New System.Drawing.Size(206, 21)
        Me.都道府県.TabIndex = 1
        '
        '市区町村
        '
        Me.市区町村.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.市区町村.DropDownWidth = 300
        Me.市区町村.FormattingEnabled = True
        Me.市区町村.Location = New System.Drawing.Point(85, 51)
        Me.市区町村.Name = "市区町村"
        Me.市区町村.Size = New System.Drawing.Size(206, 21)
        Me.市区町村.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.あ行)
        Me.TabControl1.Controls.Add(Me.か行)
        Me.TabControl1.Controls.Add(Me.さ行)
        Me.TabControl1.Controls.Add(Me.た行)
        Me.TabControl1.Controls.Add(Me.な行)
        Me.TabControl1.Controls.Add(Me.は行)
        Me.TabControl1.Controls.Add(Me.ま行)
        Me.TabControl1.Controls.Add(Me.や行)
        Me.TabControl1.Controls.Add(Me.ら行)
        Me.TabControl1.Controls.Add(Me.わ行)
        Me.TabControl1.Controls.Add(Me.他行)
        Me.TabControl1.Location = New System.Drawing.Point(14, 87)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(471, 362)
        Me.TabControl1.TabIndex = 10
        '
        'あ行
        '
        Me.あ行.Controls.Add(Me.dgv町域名0)
        Me.あ行.Location = New System.Drawing.Point(4, 22)
        Me.あ行.Name = "あ行"
        Me.あ行.Padding = New System.Windows.Forms.Padding(3)
        Me.あ行.Size = New System.Drawing.Size(463, 336)
        Me.あ行.TabIndex = 0
        Me.あ行.Text = "　あ　"
        Me.あ行.UseVisualStyleBackColor = True
        '
        'dgv町域名0
        '
        Me.dgv町域名0.AllowUserToAddRows = False
        Me.dgv町域名0.AllowUserToDeleteRows = False
        Me.dgv町域名0.AllowUserToResizeColumns = False
        Me.dgv町域名0.AllowUserToResizeRows = False
        Me.dgv町域名0.BackgroundColor = System.Drawing.Color.White
        Me.dgv町域名0.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgv町域名0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv町域名0.ColumnHeadersVisible = False
        Me.dgv町域名0.Location = New System.Drawing.Point(15, 16)
        Me.dgv町域名0.MultiSelect = False
        Me.dgv町域名0.Name = "dgv町域名0"
        Me.dgv町域名0.ReadOnly = True
        Me.dgv町域名0.RowHeadersVisible = False
        Me.dgv町域名0.RowTemplate.Height = 15
        Me.dgv町域名0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv町域名0.Size = New System.Drawing.Size(433, 302)
        Me.dgv町域名0.TabIndex = 0
        Me.dgv町域名0.TabStop = False
        '
        'か行
        '
        Me.か行.Controls.Add(Me.dgv町域名1)
        Me.か行.Location = New System.Drawing.Point(4, 22)
        Me.か行.Name = "か行"
        Me.か行.Padding = New System.Windows.Forms.Padding(3)
        Me.か行.Size = New System.Drawing.Size(463, 336)
        Me.か行.TabIndex = 1
        Me.か行.Text = "　か　"
        Me.か行.UseVisualStyleBackColor = True
        '
        'dgv町域名1
        '
        Me.dgv町域名1.AllowUserToAddRows = False
        Me.dgv町域名1.AllowUserToDeleteRows = False
        Me.dgv町域名1.AllowUserToResizeColumns = False
        Me.dgv町域名1.AllowUserToResizeRows = False
        Me.dgv町域名1.BackgroundColor = System.Drawing.Color.White
        Me.dgv町域名1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgv町域名1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv町域名1.ColumnHeadersVisible = False
        Me.dgv町域名1.Location = New System.Drawing.Point(15, 16)
        Me.dgv町域名1.MultiSelect = False
        Me.dgv町域名1.Name = "dgv町域名1"
        Me.dgv町域名1.ReadOnly = True
        Me.dgv町域名1.RowHeadersVisible = False
        Me.dgv町域名1.RowTemplate.Height = 15
        Me.dgv町域名1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv町域名1.Size = New System.Drawing.Size(433, 302)
        Me.dgv町域名1.TabIndex = 1
        Me.dgv町域名1.TabStop = False
        '
        'さ行
        '
        Me.さ行.Controls.Add(Me.dgv町域名2)
        Me.さ行.Location = New System.Drawing.Point(4, 22)
        Me.さ行.Name = "さ行"
        Me.さ行.Padding = New System.Windows.Forms.Padding(3)
        Me.さ行.Size = New System.Drawing.Size(463, 336)
        Me.さ行.TabIndex = 2
        Me.さ行.Text = "　さ　"
        Me.さ行.UseVisualStyleBackColor = True
        '
        'dgv町域名2
        '
        Me.dgv町域名2.AllowUserToAddRows = False
        Me.dgv町域名2.AllowUserToDeleteRows = False
        Me.dgv町域名2.AllowUserToResizeColumns = False
        Me.dgv町域名2.AllowUserToResizeRows = False
        Me.dgv町域名2.BackgroundColor = System.Drawing.Color.White
        Me.dgv町域名2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgv町域名2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv町域名2.ColumnHeadersVisible = False
        Me.dgv町域名2.Location = New System.Drawing.Point(15, 16)
        Me.dgv町域名2.MultiSelect = False
        Me.dgv町域名2.Name = "dgv町域名2"
        Me.dgv町域名2.ReadOnly = True
        Me.dgv町域名2.RowHeadersVisible = False
        Me.dgv町域名2.RowTemplate.Height = 15
        Me.dgv町域名2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv町域名2.Size = New System.Drawing.Size(433, 302)
        Me.dgv町域名2.TabIndex = 2
        Me.dgv町域名2.TabStop = False
        '
        'た行
        '
        Me.た行.Controls.Add(Me.dgv町域名3)
        Me.た行.Location = New System.Drawing.Point(4, 22)
        Me.た行.Name = "た行"
        Me.た行.Padding = New System.Windows.Forms.Padding(3)
        Me.た行.Size = New System.Drawing.Size(463, 336)
        Me.た行.TabIndex = 3
        Me.た行.Text = "　た　"
        Me.た行.UseVisualStyleBackColor = True
        '
        'dgv町域名3
        '
        Me.dgv町域名3.AllowUserToAddRows = False
        Me.dgv町域名3.AllowUserToDeleteRows = False
        Me.dgv町域名3.AllowUserToResizeColumns = False
        Me.dgv町域名3.AllowUserToResizeRows = False
        Me.dgv町域名3.BackgroundColor = System.Drawing.Color.White
        Me.dgv町域名3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgv町域名3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv町域名3.ColumnHeadersVisible = False
        Me.dgv町域名3.Location = New System.Drawing.Point(15, 16)
        Me.dgv町域名3.MultiSelect = False
        Me.dgv町域名3.Name = "dgv町域名3"
        Me.dgv町域名3.ReadOnly = True
        Me.dgv町域名3.RowHeadersVisible = False
        Me.dgv町域名3.RowTemplate.Height = 15
        Me.dgv町域名3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv町域名3.Size = New System.Drawing.Size(433, 302)
        Me.dgv町域名3.TabIndex = 3
        Me.dgv町域名3.TabStop = False
        '
        'な行
        '
        Me.な行.Controls.Add(Me.dgv町域名4)
        Me.な行.Location = New System.Drawing.Point(4, 22)
        Me.な行.Name = "な行"
        Me.な行.Padding = New System.Windows.Forms.Padding(3)
        Me.な行.Size = New System.Drawing.Size(463, 336)
        Me.な行.TabIndex = 4
        Me.な行.Text = "　な　"
        Me.な行.UseVisualStyleBackColor = True
        '
        'dgv町域名4
        '
        Me.dgv町域名4.AllowUserToAddRows = False
        Me.dgv町域名4.AllowUserToDeleteRows = False
        Me.dgv町域名4.AllowUserToResizeColumns = False
        Me.dgv町域名4.AllowUserToResizeRows = False
        Me.dgv町域名4.BackgroundColor = System.Drawing.Color.White
        Me.dgv町域名4.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgv町域名4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv町域名4.ColumnHeadersVisible = False
        Me.dgv町域名4.Location = New System.Drawing.Point(15, 16)
        Me.dgv町域名4.MultiSelect = False
        Me.dgv町域名4.Name = "dgv町域名4"
        Me.dgv町域名4.ReadOnly = True
        Me.dgv町域名4.RowHeadersVisible = False
        Me.dgv町域名4.RowTemplate.Height = 15
        Me.dgv町域名4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv町域名4.Size = New System.Drawing.Size(433, 302)
        Me.dgv町域名4.TabIndex = 4
        Me.dgv町域名4.TabStop = False
        '
        'は行
        '
        Me.は行.Controls.Add(Me.dgv町域名5)
        Me.は行.Location = New System.Drawing.Point(4, 22)
        Me.は行.Name = "は行"
        Me.は行.Padding = New System.Windows.Forms.Padding(3)
        Me.は行.Size = New System.Drawing.Size(463, 336)
        Me.は行.TabIndex = 5
        Me.は行.Text = "　は　"
        Me.は行.UseVisualStyleBackColor = True
        '
        'dgv町域名5
        '
        Me.dgv町域名5.AllowUserToAddRows = False
        Me.dgv町域名5.AllowUserToDeleteRows = False
        Me.dgv町域名5.AllowUserToResizeColumns = False
        Me.dgv町域名5.AllowUserToResizeRows = False
        Me.dgv町域名5.BackgroundColor = System.Drawing.Color.White
        Me.dgv町域名5.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgv町域名5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv町域名5.ColumnHeadersVisible = False
        Me.dgv町域名5.Location = New System.Drawing.Point(15, 16)
        Me.dgv町域名5.MultiSelect = False
        Me.dgv町域名5.Name = "dgv町域名5"
        Me.dgv町域名5.ReadOnly = True
        Me.dgv町域名5.RowHeadersVisible = False
        Me.dgv町域名5.RowTemplate.Height = 15
        Me.dgv町域名5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv町域名5.Size = New System.Drawing.Size(433, 302)
        Me.dgv町域名5.TabIndex = 5
        Me.dgv町域名5.TabStop = False
        '
        'ま行
        '
        Me.ま行.Controls.Add(Me.dgv町域名6)
        Me.ま行.Location = New System.Drawing.Point(4, 22)
        Me.ま行.Name = "ま行"
        Me.ま行.Padding = New System.Windows.Forms.Padding(3)
        Me.ま行.Size = New System.Drawing.Size(463, 336)
        Me.ま行.TabIndex = 6
        Me.ま行.Text = "　ま　"
        Me.ま行.UseVisualStyleBackColor = True
        '
        'dgv町域名6
        '
        Me.dgv町域名6.AllowUserToAddRows = False
        Me.dgv町域名6.AllowUserToDeleteRows = False
        Me.dgv町域名6.AllowUserToResizeColumns = False
        Me.dgv町域名6.AllowUserToResizeRows = False
        Me.dgv町域名6.BackgroundColor = System.Drawing.Color.White
        Me.dgv町域名6.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgv町域名6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv町域名6.ColumnHeadersVisible = False
        Me.dgv町域名6.Location = New System.Drawing.Point(15, 16)
        Me.dgv町域名6.MultiSelect = False
        Me.dgv町域名6.Name = "dgv町域名6"
        Me.dgv町域名6.ReadOnly = True
        Me.dgv町域名6.RowHeadersVisible = False
        Me.dgv町域名6.RowTemplate.Height = 15
        Me.dgv町域名6.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv町域名6.Size = New System.Drawing.Size(433, 302)
        Me.dgv町域名6.TabIndex = 6
        Me.dgv町域名6.TabStop = False
        '
        'や行
        '
        Me.や行.Controls.Add(Me.dgv町域名7)
        Me.や行.Location = New System.Drawing.Point(4, 22)
        Me.や行.Name = "や行"
        Me.や行.Padding = New System.Windows.Forms.Padding(3)
        Me.や行.Size = New System.Drawing.Size(463, 336)
        Me.や行.TabIndex = 7
        Me.や行.Text = "　や　"
        Me.や行.UseVisualStyleBackColor = True
        '
        'dgv町域名7
        '
        Me.dgv町域名7.AllowUserToAddRows = False
        Me.dgv町域名7.AllowUserToDeleteRows = False
        Me.dgv町域名7.AllowUserToResizeColumns = False
        Me.dgv町域名7.AllowUserToResizeRows = False
        Me.dgv町域名7.BackgroundColor = System.Drawing.Color.White
        Me.dgv町域名7.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgv町域名7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv町域名7.ColumnHeadersVisible = False
        Me.dgv町域名7.Location = New System.Drawing.Point(15, 16)
        Me.dgv町域名7.MultiSelect = False
        Me.dgv町域名7.Name = "dgv町域名7"
        Me.dgv町域名7.ReadOnly = True
        Me.dgv町域名7.RowHeadersVisible = False
        Me.dgv町域名7.RowTemplate.Height = 15
        Me.dgv町域名7.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv町域名7.Size = New System.Drawing.Size(433, 302)
        Me.dgv町域名7.TabIndex = 7
        Me.dgv町域名7.TabStop = False
        '
        'ら行
        '
        Me.ら行.Controls.Add(Me.dgv町域名8)
        Me.ら行.Location = New System.Drawing.Point(4, 22)
        Me.ら行.Name = "ら行"
        Me.ら行.Padding = New System.Windows.Forms.Padding(3)
        Me.ら行.Size = New System.Drawing.Size(463, 336)
        Me.ら行.TabIndex = 8
        Me.ら行.Text = "　ら　"
        Me.ら行.UseVisualStyleBackColor = True
        '
        'dgv町域名8
        '
        Me.dgv町域名8.AllowUserToAddRows = False
        Me.dgv町域名8.AllowUserToDeleteRows = False
        Me.dgv町域名8.AllowUserToResizeColumns = False
        Me.dgv町域名8.AllowUserToResizeRows = False
        Me.dgv町域名8.BackgroundColor = System.Drawing.Color.White
        Me.dgv町域名8.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgv町域名8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv町域名8.ColumnHeadersVisible = False
        Me.dgv町域名8.Location = New System.Drawing.Point(15, 16)
        Me.dgv町域名8.MultiSelect = False
        Me.dgv町域名8.Name = "dgv町域名8"
        Me.dgv町域名8.ReadOnly = True
        Me.dgv町域名8.RowHeadersVisible = False
        Me.dgv町域名8.RowTemplate.Height = 15
        Me.dgv町域名8.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv町域名8.Size = New System.Drawing.Size(433, 302)
        Me.dgv町域名8.TabIndex = 8
        Me.dgv町域名8.TabStop = False
        '
        'わ行
        '
        Me.わ行.Controls.Add(Me.dgv町域名9)
        Me.わ行.Location = New System.Drawing.Point(4, 22)
        Me.わ行.Name = "わ行"
        Me.わ行.Padding = New System.Windows.Forms.Padding(3)
        Me.わ行.Size = New System.Drawing.Size(463, 336)
        Me.わ行.TabIndex = 9
        Me.わ行.Text = "　わ　"
        Me.わ行.UseVisualStyleBackColor = True
        '
        'dgv町域名9
        '
        Me.dgv町域名9.AllowUserToAddRows = False
        Me.dgv町域名9.AllowUserToDeleteRows = False
        Me.dgv町域名9.AllowUserToResizeColumns = False
        Me.dgv町域名9.AllowUserToResizeRows = False
        Me.dgv町域名9.BackgroundColor = System.Drawing.Color.White
        Me.dgv町域名9.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgv町域名9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv町域名9.ColumnHeadersVisible = False
        Me.dgv町域名9.Location = New System.Drawing.Point(15, 16)
        Me.dgv町域名9.MultiSelect = False
        Me.dgv町域名9.Name = "dgv町域名9"
        Me.dgv町域名9.ReadOnly = True
        Me.dgv町域名9.RowHeadersVisible = False
        Me.dgv町域名9.RowTemplate.Height = 15
        Me.dgv町域名9.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv町域名9.Size = New System.Drawing.Size(433, 302)
        Me.dgv町域名9.TabIndex = 9
        Me.dgv町域名9.TabStop = False
        '
        '他行
        '
        Me.他行.Controls.Add(Me.dgv町域名10)
        Me.他行.Location = New System.Drawing.Point(4, 22)
        Me.他行.Name = "他行"
        Me.他行.Padding = New System.Windows.Forms.Padding(3)
        Me.他行.Size = New System.Drawing.Size(463, 336)
        Me.他行.TabIndex = 10
        Me.他行.Text = "　他　"
        Me.他行.UseVisualStyleBackColor = True
        '
        'dgv町域名10
        '
        Me.dgv町域名10.AllowUserToAddRows = False
        Me.dgv町域名10.AllowUserToDeleteRows = False
        Me.dgv町域名10.AllowUserToResizeColumns = False
        Me.dgv町域名10.AllowUserToResizeRows = False
        Me.dgv町域名10.BackgroundColor = System.Drawing.Color.White
        Me.dgv町域名10.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgv町域名10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv町域名10.ColumnHeadersVisible = False
        Me.dgv町域名10.Location = New System.Drawing.Point(15, 16)
        Me.dgv町域名10.MultiSelect = False
        Me.dgv町域名10.Name = "dgv町域名10"
        Me.dgv町域名10.ReadOnly = True
        Me.dgv町域名10.RowHeadersVisible = False
        Me.dgv町域名10.RowTemplate.Height = 15
        Me.dgv町域名10.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv町域名10.Size = New System.Drawing.Size(433, 302)
        Me.dgv町域名10.TabIndex = 10
        Me.dgv町域名10.TabStop = False
        '
        '選択
        '
        Me.選択.Location = New System.Drawing.Point(497, 110)
        Me.選択.Name = "選択"
        Me.選択.Size = New System.Drawing.Size(100, 23)
        Me.選択.TabIndex = 3
        Me.選択.Text = "選択"
        Me.選択.UseVisualStyleBackColor = True
        '
        '閉じる
        '
        Me.閉じる.Location = New System.Drawing.Point(497, 146)
        Me.閉じる.Name = "閉じる"
        Me.閉じる.Size = New System.Drawing.Size(100, 23)
        Me.閉じる.TabIndex = 4
        Me.閉じる.Text = "閉じる"
        Me.閉じる.UseVisualStyleBackColor = True
        '
        'z_0600_郵便番号検索
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 457)
        Me.Controls.Add(Me.閉じる)
        Me.Controls.Add(Me.選択)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.市区町村)
        Me.Controls.Add(Me.都道府県)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "z_0600_郵便番号検索"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "HABITS - 郵便番号検索"
        Me.TabControl1.ResumeLayout(False)
        Me.あ行.ResumeLayout(False)
        CType(Me.dgv町域名0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.か行.ResumeLayout(False)
        CType(Me.dgv町域名1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.さ行.ResumeLayout(False)
        CType(Me.dgv町域名2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.た行.ResumeLayout(False)
        CType(Me.dgv町域名3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.な行.ResumeLayout(False)
        CType(Me.dgv町域名4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.は行.ResumeLayout(False)
        CType(Me.dgv町域名5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ま行.ResumeLayout(False)
        CType(Me.dgv町域名6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.や行.ResumeLayout(False)
        CType(Me.dgv町域名7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ら行.ResumeLayout(False)
        CType(Me.dgv町域名8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.わ行.ResumeLayout(False)
        CType(Me.dgv町域名9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.他行.ResumeLayout(False)
        CType(Me.dgv町域名10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 都道府県 As System.Windows.Forms.ComboBox
    Friend WithEvents 市区町村 As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents あ行 As System.Windows.Forms.TabPage
    Friend WithEvents か行 As System.Windows.Forms.TabPage
    Friend WithEvents さ行 As System.Windows.Forms.TabPage
    Friend WithEvents た行 As System.Windows.Forms.TabPage
    Friend WithEvents な行 As System.Windows.Forms.TabPage
    Friend WithEvents は行 As System.Windows.Forms.TabPage
    Friend WithEvents ま行 As System.Windows.Forms.TabPage
    Friend WithEvents や行 As System.Windows.Forms.TabPage
    Friend WithEvents ら行 As System.Windows.Forms.TabPage
    Friend WithEvents わ行 As System.Windows.Forms.TabPage
    Friend WithEvents 他行 As System.Windows.Forms.TabPage
    Friend WithEvents 選択 As System.Windows.Forms.Button
    Friend WithEvents 閉じる As System.Windows.Forms.Button
    Public WithEvents dgv町域名0 As System.Windows.Forms.DataGridView
    Public WithEvents dgv町域名1 As System.Windows.Forms.DataGridView
    Public WithEvents dgv町域名2 As System.Windows.Forms.DataGridView
    Public WithEvents dgv町域名3 As System.Windows.Forms.DataGridView
    Public WithEvents dgv町域名4 As System.Windows.Forms.DataGridView
    Public WithEvents dgv町域名5 As System.Windows.Forms.DataGridView
    Public WithEvents dgv町域名6 As System.Windows.Forms.DataGridView
    Public WithEvents dgv町域名7 As System.Windows.Forms.DataGridView
    Public WithEvents dgv町域名8 As System.Windows.Forms.DataGridView
    Public WithEvents dgv町域名9 As System.Windows.Forms.DataGridView
    Public WithEvents dgv町域名10 As System.Windows.Forms.DataGridView
End Class
