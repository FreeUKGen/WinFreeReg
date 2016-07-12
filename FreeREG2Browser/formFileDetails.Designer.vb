<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formFileDetails
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
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

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim ChurchLabel As System.Windows.Forms.Label
      Dim Comment1Label As System.Windows.Forms.Label
      Dim Comment2Label As System.Windows.Forms.Label
      Dim CountyLabel As System.Windows.Forms.Label
      Dim CreditEmailLabel As System.Windows.Forms.Label
      Dim CreditNameLabel As System.Windows.Forms.Label
      Dim FileTypeLabel As System.Windows.Forms.Label
      Dim InternalFilenameLabel As System.Windows.Forms.Label
      Dim MyEmailLabel As System.Windows.Forms.Label
      Dim MyNameLabel As System.Windows.Forms.Label
      Dim MyPasswordLabel As System.Windows.Forms.Label
      Dim MySyndicateLabel As System.Windows.Forms.Label
      Dim PlaceLabel As System.Windows.Forms.Label
      Dim RegisterTypeLabel As System.Windows.Forms.Label
      Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
      Me.FileHeaderClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.ChurchComboBox = New System.Windows.Forms.ComboBox()
      Me.ChurchesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.FreeregTables = New WinFreeReg.FreeregTables()
      Me.Comment1TextBox = New System.Windows.Forms.TextBox()
      Me.Comment2TextBox = New System.Windows.Forms.TextBox()
      Me.CountyComboBox = New System.Windows.Forms.ComboBox()
      Me.CountiesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.CreditEmailTextBox = New System.Windows.Forms.TextBox()
      Me.CreditNameTextBox = New System.Windows.Forms.TextBox()
      Me.FileTypeComboBox = New System.Windows.Forms.ComboBox()
      Me.FileTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.InternalFilenameTextBox = New System.Windows.Forms.TextBox()
      Me.IsLDSCheckBox = New System.Windows.Forms.CheckBox()
      Me.MyEmailTextBox = New System.Windows.Forms.TextBox()
      Me.MyNameTextBox = New System.Windows.Forms.TextBox()
      Me.MyPasswordTextBox = New System.Windows.Forms.TextBox()
      Me.MySyndicateTextBox = New System.Windows.Forms.TextBox()
      Me.PlaceComboBox = New System.Windows.Forms.ComboBox()
      Me.PlacesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.RegisterTypeComboBox = New System.Windows.Forms.ComboBox()
      Me.RegisterTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      ChurchLabel = New System.Windows.Forms.Label()
      Comment1Label = New System.Windows.Forms.Label()
      Comment2Label = New System.Windows.Forms.Label()
      CountyLabel = New System.Windows.Forms.Label()
      CreditEmailLabel = New System.Windows.Forms.Label()
      CreditNameLabel = New System.Windows.Forms.Label()
      FileTypeLabel = New System.Windows.Forms.Label()
      InternalFilenameLabel = New System.Windows.Forms.Label()
      MyEmailLabel = New System.Windows.Forms.Label()
      MyNameLabel = New System.Windows.Forms.Label()
      MyPasswordLabel = New System.Windows.Forms.Label()
      MySyndicateLabel = New System.Windows.Forms.Label()
      PlaceLabel = New System.Windows.Forms.Label()
      RegisterTypeLabel = New System.Windows.Forms.Label()
      CType(Me.FileHeaderClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ChurchesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.FreeregTables, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.CountiesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.FileTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PlacesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RegisterTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ChurchLabel
      '
      ChurchLabel.AutoSize = True
      ChurchLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      ChurchLabel.Location = New System.Drawing.Point(22, 73)
      ChurchLabel.Name = "ChurchLabel"
      ChurchLabel.Size = New System.Drawing.Size(52, 16)
      ChurchLabel.TabIndex = 1
      ChurchLabel.Text = "Church:"
      '
      'Comment1Label
      '
      Comment1Label.AutoSize = True
      Comment1Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Comment1Label.Location = New System.Drawing.Point(22, 222)
      Comment1Label.Name = "Comment1Label"
      Comment1Label.Size = New System.Drawing.Size(75, 16)
      Comment1Label.TabIndex = 3
      Comment1Label.Text = "Comment1:"
      '
      'Comment2Label
      '
      Comment2Label.AutoSize = True
      Comment2Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Comment2Label.Location = New System.Drawing.Point(22, 253)
      Comment2Label.Name = "Comment2Label"
      Comment2Label.Size = New System.Drawing.Size(75, 16)
      Comment2Label.TabIndex = 5
      Comment2Label.Text = "Comment2:"
      '
      'CountyLabel
      '
      CountyLabel.AutoSize = True
      CountyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      CountyLabel.Location = New System.Drawing.Point(22, 13)
      CountyLabel.Name = "CountyLabel"
      CountyLabel.Size = New System.Drawing.Size(52, 16)
      CountyLabel.TabIndex = 7
      CountyLabel.Text = "County:"
      '
      'CreditEmailLabel
      '
      CreditEmailLabel.AutoSize = True
      CreditEmailLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      CreditEmailLabel.Location = New System.Drawing.Point(22, 163)
      CreditEmailLabel.Name = "CreditEmailLabel"
      CreditEmailLabel.Size = New System.Drawing.Size(83, 16)
      CreditEmailLabel.TabIndex = 9
      CreditEmailLabel.Text = "Credit Email:"
      '
      'CreditNameLabel
      '
      CreditNameLabel.AutoSize = True
      CreditNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      CreditNameLabel.Location = New System.Drawing.Point(22, 194)
      CreditNameLabel.Name = "CreditNameLabel"
      CreditNameLabel.Size = New System.Drawing.Size(86, 16)
      CreditNameLabel.TabIndex = 11
      CreditNameLabel.Text = "Credit Name:"
      '
      'FileTypeLabel
      '
      FileTypeLabel.AutoSize = True
      FileTypeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      FileTypeLabel.Location = New System.Drawing.Point(22, 133)
      FileTypeLabel.Name = "FileTypeLabel"
      FileTypeLabel.Size = New System.Drawing.Size(68, 16)
      FileTypeLabel.TabIndex = 13
      FileTypeLabel.Text = "File Type:"
      '
      'InternalFilenameLabel
      '
      InternalFilenameLabel.AutoSize = True
      InternalFilenameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      InternalFilenameLabel.Location = New System.Drawing.Point(22, 323)
      InternalFilenameLabel.Name = "InternalFilenameLabel"
      InternalFilenameLabel.Size = New System.Drawing.Size(113, 16)
      InternalFilenameLabel.TabIndex = 15
      InternalFilenameLabel.Text = "Internal Filename:"
      '
      'MyEmailLabel
      '
      MyEmailLabel.AutoSize = True
      MyEmailLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      MyEmailLabel.Location = New System.Drawing.Point(22, 354)
      MyEmailLabel.Name = "MyEmailLabel"
      MyEmailLabel.Size = New System.Drawing.Size(66, 16)
      MyEmailLabel.TabIndex = 19
      MyEmailLabel.Text = "My Email:"
      '
      'MyNameLabel
      '
      MyNameLabel.AutoSize = True
      MyNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      MyNameLabel.Location = New System.Drawing.Point(22, 385)
      MyNameLabel.Name = "MyNameLabel"
      MyNameLabel.Size = New System.Drawing.Size(69, 16)
      MyNameLabel.TabIndex = 21
      MyNameLabel.Text = "My Name:"
      '
      'MyPasswordLabel
      '
      MyPasswordLabel.AutoSize = True
      MyPasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      MyPasswordLabel.Location = New System.Drawing.Point(22, 416)
      MyPasswordLabel.Name = "MyPasswordLabel"
      MyPasswordLabel.Size = New System.Drawing.Size(92, 16)
      MyPasswordLabel.TabIndex = 23
      MyPasswordLabel.Text = "My Password:"
      '
      'MySyndicateLabel
      '
      MySyndicateLabel.AutoSize = True
      MySyndicateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      MySyndicateLabel.Location = New System.Drawing.Point(22, 447)
      MySyndicateLabel.Name = "MySyndicateLabel"
      MySyndicateLabel.Size = New System.Drawing.Size(92, 16)
      MySyndicateLabel.TabIndex = 25
      MySyndicateLabel.Text = "My Syndicate:"
      '
      'PlaceLabel
      '
      PlaceLabel.AutoSize = True
      PlaceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      PlaceLabel.Location = New System.Drawing.Point(22, 43)
      PlaceLabel.Name = "PlaceLabel"
      PlaceLabel.Size = New System.Drawing.Size(46, 16)
      PlaceLabel.TabIndex = 27
      PlaceLabel.Text = "Place:"
      '
      'RegisterTypeLabel
      '
      RegisterTypeLabel.AutoSize = True
      RegisterTypeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      RegisterTypeLabel.Location = New System.Drawing.Point(22, 103)
      RegisterTypeLabel.Name = "RegisterTypeLabel"
      RegisterTypeLabel.Size = New System.Drawing.Size(97, 16)
      RegisterTypeLabel.TabIndex = 29
      RegisterTypeLabel.Text = "Register Type:"
      '
      'LinkLabel1
      '
      Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.LinkLabel1.AutoSize = True
      Me.LinkLabel1.Location = New System.Drawing.Point(563, 265)
      Me.LinkLabel1.Name = "LinkLabel1"
      Me.LinkLabel1.Size = New System.Drawing.Size(43, 13)
      Me.LinkLabel1.TabIndex = 31
      Me.LinkLabel1.TabStop = True
      Me.LinkLabel1.Tag = "False"
      Me.LinkLabel1.Text = "More-->"
      '
      'FileHeaderClassBindingSource
      '
      Me.FileHeaderClassBindingSource.DataSource = GetType(WinFreeReg.TranscriptionFileClass.FileHeaderClass)
      '
      'ChurchComboBox
      '
      Me.ChurchComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "Church", True))
      Me.ChurchComboBox.DataSource = Me.ChurchesBindingSource
      Me.ChurchComboBox.DisplayMember = "ChurchName"
      Me.ChurchComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ChurchComboBox.FormattingEnabled = True
      Me.ChurchComboBox.Location = New System.Drawing.Point(132, 72)
      Me.ChurchComboBox.Name = "ChurchComboBox"
      Me.ChurchComboBox.Size = New System.Drawing.Size(170, 24)
      Me.ChurchComboBox.TabIndex = 33
      Me.ChurchComboBox.ValueMember = "ChurchName"
      '
      'ChurchesBindingSource
      '
      Me.ChurchesBindingSource.DataMember = "Churches"
      Me.ChurchesBindingSource.DataSource = Me.FreeregTables
      '
      'FreeregTables
      '
      Me.FreeregTables.DataSetName = "FreeregTables"
      Me.FreeregTables.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'Comment1TextBox
      '
      Me.Comment1TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "Comment1", True))
      Me.Comment1TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Comment1TextBox.Location = New System.Drawing.Point(132, 221)
      Me.Comment1TextBox.Name = "Comment1TextBox"
      Me.Comment1TextBox.Size = New System.Drawing.Size(419, 23)
      Me.Comment1TextBox.TabIndex = 35
      '
      'Comment2TextBox
      '
      Me.Comment2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "Comment2", True))
      Me.Comment2TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Comment2TextBox.Location = New System.Drawing.Point(132, 252)
      Me.Comment2TextBox.Name = "Comment2TextBox"
      Me.Comment2TextBox.Size = New System.Drawing.Size(419, 23)
      Me.Comment2TextBox.TabIndex = 37
      '
      'CountyComboBox
      '
      Me.CountyComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "County", True))
      Me.CountyComboBox.DataSource = Me.CountiesBindingSource
      Me.CountyComboBox.DisplayMember = "CountyName"
      Me.CountyComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
      Me.CountyComboBox.Enabled = False
      Me.CountyComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.CountyComboBox.FormattingEnabled = True
      Me.CountyComboBox.Location = New System.Drawing.Point(132, 12)
      Me.CountyComboBox.Name = "CountyComboBox"
      Me.CountyComboBox.Size = New System.Drawing.Size(170, 24)
      Me.CountyComboBox.TabIndex = 39
      Me.CountyComboBox.ValueMember = "ChapmanCode"
      '
      'CountiesBindingSource
      '
      Me.CountiesBindingSource.DataMember = "Counties"
      Me.CountiesBindingSource.DataSource = Me.FreeregTables
      '
      'CreditEmailTextBox
      '
      Me.CreditEmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "CreditEmail", True))
      Me.CreditEmailTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.CreditEmailTextBox.Location = New System.Drawing.Point(132, 162)
      Me.CreditEmailTextBox.Name = "CreditEmailTextBox"
      Me.CreditEmailTextBox.Size = New System.Drawing.Size(170, 23)
      Me.CreditEmailTextBox.TabIndex = 41
      '
      'CreditNameTextBox
      '
      Me.CreditNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "CreditName", True))
      Me.CreditNameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.CreditNameTextBox.Location = New System.Drawing.Point(132, 193)
      Me.CreditNameTextBox.Name = "CreditNameTextBox"
      Me.CreditNameTextBox.Size = New System.Drawing.Size(170, 23)
      Me.CreditNameTextBox.TabIndex = 43
      '
      'FileTypeComboBox
      '
      Me.FileTypeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "FileType", True))
      Me.FileTypeComboBox.DataSource = Me.FileTypesBindingSource
      Me.FileTypeComboBox.DisplayMember = "Description"
      Me.FileTypeComboBox.Enabled = False
      Me.FileTypeComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FileTypeComboBox.FormattingEnabled = True
      Me.FileTypeComboBox.Location = New System.Drawing.Point(132, 132)
      Me.FileTypeComboBox.Name = "FileTypeComboBox"
      Me.FileTypeComboBox.Size = New System.Drawing.Size(121, 24)
      Me.FileTypeComboBox.TabIndex = 45
      Me.FileTypeComboBox.ValueMember = "Type"
      '
      'FileTypesBindingSource
      '
      Me.FileTypesBindingSource.DataMember = "RecordTypes"
      Me.FileTypesBindingSource.DataSource = GetType(WinFreeReg.LookupTables)
      '
      'InternalFilenameTextBox
      '
      Me.InternalFilenameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "InternalFilename", True))
      Me.InternalFilenameTextBox.Enabled = False
      Me.InternalFilenameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.InternalFilenameTextBox.Location = New System.Drawing.Point(132, 322)
      Me.InternalFilenameTextBox.Name = "InternalFilenameTextBox"
      Me.InternalFilenameTextBox.Size = New System.Drawing.Size(121, 23)
      Me.InternalFilenameTextBox.TabIndex = 47
      '
      'IsLDSCheckBox
      '
      Me.IsLDSCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.FileHeaderClassBindingSource, "isLDS", True))
      Me.IsLDSCheckBox.Location = New System.Drawing.Point(272, 130)
      Me.IsLDSCheckBox.Name = "IsLDSCheckBox"
      Me.IsLDSCheckBox.Size = New System.Drawing.Size(181, 24)
      Me.IsLDSCheckBox.TabIndex = 49
      Me.IsLDSCheckBox.Text = "Include Fiche/Image columns"
      Me.IsLDSCheckBox.UseVisualStyleBackColor = True
      '
      'MyEmailTextBox
      '
      Me.MyEmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "MyEmail", True))
      Me.MyEmailTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.MyEmailTextBox.Location = New System.Drawing.Point(132, 353)
      Me.MyEmailTextBox.Name = "MyEmailTextBox"
      Me.MyEmailTextBox.Size = New System.Drawing.Size(170, 23)
      Me.MyEmailTextBox.TabIndex = 51
      '
      'MyNameTextBox
      '
      Me.MyNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "MyName", True))
      Me.MyNameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.MyNameTextBox.Location = New System.Drawing.Point(132, 384)
      Me.MyNameTextBox.Name = "MyNameTextBox"
      Me.MyNameTextBox.Size = New System.Drawing.Size(170, 23)
      Me.MyNameTextBox.TabIndex = 53
      '
      'MyPasswordTextBox
      '
      Me.MyPasswordTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "MyPassword", True))
      Me.MyPasswordTextBox.Enabled = False
      Me.MyPasswordTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.MyPasswordTextBox.Location = New System.Drawing.Point(132, 415)
      Me.MyPasswordTextBox.Name = "MyPasswordTextBox"
      Me.MyPasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.MyPasswordTextBox.Size = New System.Drawing.Size(170, 23)
      Me.MyPasswordTextBox.TabIndex = 55
      '
      'MySyndicateTextBox
      '
      Me.MySyndicateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "MySyndicate", True))
      Me.MySyndicateTextBox.Enabled = False
      Me.MySyndicateTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.MySyndicateTextBox.Location = New System.Drawing.Point(132, 446)
      Me.MySyndicateTextBox.Name = "MySyndicateTextBox"
      Me.MySyndicateTextBox.Size = New System.Drawing.Size(170, 23)
      Me.MySyndicateTextBox.TabIndex = 57
      '
      'PlaceComboBox
      '
      Me.PlaceComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "Place", True))
      Me.PlaceComboBox.DataSource = Me.PlacesBindingSource
      Me.PlaceComboBox.DisplayMember = "PlaceName"
      Me.PlaceComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.PlaceComboBox.FormattingEnabled = True
      Me.PlaceComboBox.Location = New System.Drawing.Point(132, 42)
      Me.PlaceComboBox.Name = "PlaceComboBox"
      Me.PlaceComboBox.Size = New System.Drawing.Size(170, 24)
      Me.PlaceComboBox.TabIndex = 59
      Me.PlaceComboBox.ValueMember = "PlaceName"
      '
      'PlacesBindingSource
      '
      Me.PlacesBindingSource.DataMember = "Places"
      Me.PlacesBindingSource.DataSource = Me.FreeregTables
      '
      'RegisterTypeComboBox
      '
      Me.RegisterTypeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FileHeaderClassBindingSource, "RegisterType", True))
      Me.RegisterTypeComboBox.DataSource = Me.RegisterTypesBindingSource
      Me.RegisterTypeComboBox.DisplayMember = "Description"
      Me.RegisterTypeComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.RegisterTypeComboBox.FormattingEnabled = True
      Me.RegisterTypeComboBox.Location = New System.Drawing.Point(132, 102)
      Me.RegisterTypeComboBox.Name = "RegisterTypeComboBox"
      Me.RegisterTypeComboBox.Size = New System.Drawing.Size(170, 24)
      Me.RegisterTypeComboBox.TabIndex = 61
      Me.RegisterTypeComboBox.ValueMember = "Type"
      '
      'RegisterTypesBindingSource
      '
      Me.RegisterTypesBindingSource.DataMember = "RegisterTypes"
      Me.RegisterTypesBindingSource.DataSource = Me.FreeregTables
      '
      'formFileDetails
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(618, 287)
      Me.Controls.Add(Me.ChurchComboBox)
      Me.Controls.Add(Me.Comment1TextBox)
      Me.Controls.Add(Me.Comment2TextBox)
      Me.Controls.Add(Me.CountyComboBox)
      Me.Controls.Add(Me.CreditEmailTextBox)
      Me.Controls.Add(Me.CreditNameTextBox)
      Me.Controls.Add(Me.FileTypeComboBox)
      Me.Controls.Add(Me.InternalFilenameTextBox)
      Me.Controls.Add(Me.IsLDSCheckBox)
      Me.Controls.Add(Me.MyEmailTextBox)
      Me.Controls.Add(Me.MyNameTextBox)
      Me.Controls.Add(Me.MyPasswordTextBox)
      Me.Controls.Add(Me.MySyndicateTextBox)
      Me.Controls.Add(Me.PlaceComboBox)
      Me.Controls.Add(Me.RegisterTypeComboBox)
      Me.Controls.Add(Me.LinkLabel1)
      Me.Controls.Add(ChurchLabel)
      Me.Controls.Add(Comment1Label)
      Me.Controls.Add(Comment2Label)
      Me.Controls.Add(CountyLabel)
      Me.Controls.Add(CreditEmailLabel)
      Me.Controls.Add(CreditNameLabel)
      Me.Controls.Add(FileTypeLabel)
      Me.Controls.Add(InternalFilenameLabel)
      Me.Controls.Add(MyEmailLabel)
      Me.Controls.Add(MyNameLabel)
      Me.Controls.Add(MyPasswordLabel)
      Me.Controls.Add(MySyndicateLabel)
      Me.Controls.Add(PlaceLabel)
      Me.Controls.Add(RegisterTypeLabel)
      Me.Name = "formFileDetails"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "WinFreeREG - FIle Details - {0}"
      CType(Me.FileHeaderClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ChurchesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.FreeregTables, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.CountiesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.FileTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PlacesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RegisterTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
   Friend WithEvents FileHeaderClassBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents ChurchComboBox As System.Windows.Forms.ComboBox
   Friend WithEvents Comment1TextBox As System.Windows.Forms.TextBox
   Friend WithEvents Comment2TextBox As System.Windows.Forms.TextBox
   Friend WithEvents CountyComboBox As System.Windows.Forms.ComboBox
   Friend WithEvents CreditEmailTextBox As System.Windows.Forms.TextBox
   Friend WithEvents CreditNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents FileTypeComboBox As System.Windows.Forms.ComboBox
   Friend WithEvents InternalFilenameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents IsLDSCheckBox As System.Windows.Forms.CheckBox
   Friend WithEvents MyEmailTextBox As System.Windows.Forms.TextBox
   Friend WithEvents MyNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents MyPasswordTextBox As System.Windows.Forms.TextBox
   Friend WithEvents MySyndicateTextBox As System.Windows.Forms.TextBox
   Friend WithEvents PlaceComboBox As System.Windows.Forms.ComboBox
   Friend WithEvents RegisterTypeComboBox As System.Windows.Forms.ComboBox
   Friend WithEvents CountiesBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents FreeregTables As WinFreeReg.FreeregTables
   Friend WithEvents PlacesBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents ChurchesBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents RegisterTypesBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents FileTypesBindingSource As System.Windows.Forms.BindingSource
End Class
