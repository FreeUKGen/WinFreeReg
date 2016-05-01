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
		Me.components = New System.ComponentModel.Container
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
		Me.TranscriptionFileClassBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.ChurchComboBox = New System.Windows.Forms.ComboBox
		Me.ChurchesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.FreeregTables = New WinFreeReg.FreeregTables
      Me.Comment1TextBox = New System.Windows.Forms.TextBox
      Me.Comment2TextBox = New System.Windows.Forms.TextBox
      Me.CountyComboBox = New System.Windows.Forms.ComboBox
      Me.CountiesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.CreditEmailTextBox = New System.Windows.Forms.TextBox
      Me.CreditNameTextBox = New System.Windows.Forms.TextBox
      Me.FileTypeComboBox = New System.Windows.Forms.ComboBox
      Me.RecordTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.InternalFilenameTextBox = New System.Windows.Forms.TextBox
      Me.IsLDSCheckBox = New System.Windows.Forms.CheckBox
      Me.MyEmailTextBox = New System.Windows.Forms.TextBox
      Me.MyNameTextBox = New System.Windows.Forms.TextBox
      Me.MyPasswordTextBox = New System.Windows.Forms.TextBox
      Me.MySyndicateTextBox = New System.Windows.Forms.TextBox
      Me.PlaceComboBox = New System.Windows.Forms.ComboBox
      Me.PlacesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.RegisterTypeComboBox = New System.Windows.Forms.ComboBox
      Me.RegisterTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      ChurchLabel = New System.Windows.Forms.Label
      Comment1Label = New System.Windows.Forms.Label
      Comment2Label = New System.Windows.Forms.Label
      CountyLabel = New System.Windows.Forms.Label
      CreditEmailLabel = New System.Windows.Forms.Label
      CreditNameLabel = New System.Windows.Forms.Label
      FileTypeLabel = New System.Windows.Forms.Label
      InternalFilenameLabel = New System.Windows.Forms.Label
      MyEmailLabel = New System.Windows.Forms.Label
      MyNameLabel = New System.Windows.Forms.Label
      MyPasswordLabel = New System.Windows.Forms.Label
      MySyndicateLabel = New System.Windows.Forms.Label
      PlaceLabel = New System.Windows.Forms.Label
      RegisterTypeLabel = New System.Windows.Forms.Label
      CType(Me.TranscriptionFileClassBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ChurchesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.FreeregTables, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.CountiesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RecordTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PlacesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RegisterTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ChurchLabel
      '
      ChurchLabel.AutoSize = True
      ChurchLabel.Location = New System.Drawing.Point(23, 36)
      ChurchLabel.Name = "ChurchLabel"
      ChurchLabel.Size = New System.Drawing.Size(44, 13)
      ChurchLabel.TabIndex = 1
      ChurchLabel.Text = "Church:"
      '
      'Comment1Label
      '
      Comment1Label.AutoSize = True
      Comment1Label.Location = New System.Drawing.Point(23, 63)
      Comment1Label.Name = "Comment1Label"
      Comment1Label.Size = New System.Drawing.Size(60, 13)
      Comment1Label.TabIndex = 3
      Comment1Label.Text = "Comment1:"
      '
      'Comment2Label
      '
      Comment2Label.AutoSize = True
      Comment2Label.Location = New System.Drawing.Point(23, 89)
      Comment2Label.Name = "Comment2Label"
      Comment2Label.Size = New System.Drawing.Size(60, 13)
      Comment2Label.TabIndex = 5
      Comment2Label.Text = "Comment2:"
      '
      'CountyLabel
      '
      CountyLabel.AutoSize = True
      CountyLabel.Location = New System.Drawing.Point(23, 115)
      CountyLabel.Name = "CountyLabel"
      CountyLabel.Size = New System.Drawing.Size(43, 13)
      CountyLabel.TabIndex = 7
      CountyLabel.Text = "County:"
      '
      'CreditEmailLabel
      '
      CreditEmailLabel.AutoSize = True
      CreditEmailLabel.Location = New System.Drawing.Point(23, 142)
      CreditEmailLabel.Name = "CreditEmailLabel"
      CreditEmailLabel.Size = New System.Drawing.Size(65, 13)
      CreditEmailLabel.TabIndex = 9
      CreditEmailLabel.Text = "Credit Email:"
      '
      'CreditNameLabel
      '
      CreditNameLabel.AutoSize = True
      CreditNameLabel.Location = New System.Drawing.Point(23, 168)
      CreditNameLabel.Name = "CreditNameLabel"
      CreditNameLabel.Size = New System.Drawing.Size(68, 13)
      CreditNameLabel.TabIndex = 11
      CreditNameLabel.Text = "Credit Name:"
      '
      'FileTypeLabel
      '
      FileTypeLabel.AutoSize = True
      FileTypeLabel.Location = New System.Drawing.Point(23, 194)
      FileTypeLabel.Name = "FileTypeLabel"
      FileTypeLabel.Size = New System.Drawing.Size(53, 13)
      FileTypeLabel.TabIndex = 13
      FileTypeLabel.Text = "File Type:"
      '
      'InternalFilenameLabel
      '
      InternalFilenameLabel.AutoSize = True
      InternalFilenameLabel.Location = New System.Drawing.Point(23, 221)
      InternalFilenameLabel.Name = "InternalFilenameLabel"
      InternalFilenameLabel.Size = New System.Drawing.Size(90, 13)
      InternalFilenameLabel.TabIndex = 15
      InternalFilenameLabel.Text = "Internal Filename:"
      '
      'MyEmailLabel
      '
      MyEmailLabel.AutoSize = True
      MyEmailLabel.Location = New System.Drawing.Point(23, 277)
      MyEmailLabel.Name = "MyEmailLabel"
      MyEmailLabel.Size = New System.Drawing.Size(52, 13)
      MyEmailLabel.TabIndex = 19
      MyEmailLabel.Text = "My Email:"
      '
      'MyNameLabel
      '
      MyNameLabel.AutoSize = True
      MyNameLabel.Location = New System.Drawing.Point(23, 303)
      MyNameLabel.Name = "MyNameLabel"
      MyNameLabel.Size = New System.Drawing.Size(55, 13)
      MyNameLabel.TabIndex = 21
      MyNameLabel.Text = "My Name:"
      '
      'MyPasswordLabel
      '
      MyPasswordLabel.AutoSize = True
      MyPasswordLabel.Location = New System.Drawing.Point(23, 329)
      MyPasswordLabel.Name = "MyPasswordLabel"
      MyPasswordLabel.Size = New System.Drawing.Size(73, 13)
      MyPasswordLabel.TabIndex = 23
      MyPasswordLabel.Text = "My Password:"
      '
      'MySyndicateLabel
      '
      MySyndicateLabel.AutoSize = True
      MySyndicateLabel.Location = New System.Drawing.Point(23, 355)
      MySyndicateLabel.Name = "MySyndicateLabel"
      MySyndicateLabel.Size = New System.Drawing.Size(74, 13)
      MySyndicateLabel.TabIndex = 25
      MySyndicateLabel.Text = "My Syndicate:"
      '
      'PlaceLabel
      '
      PlaceLabel.AutoSize = True
      PlaceLabel.Location = New System.Drawing.Point(23, 381)
      PlaceLabel.Name = "PlaceLabel"
      PlaceLabel.Size = New System.Drawing.Size(37, 13)
      PlaceLabel.TabIndex = 27
      PlaceLabel.Text = "Place:"
      '
      'RegisterTypeLabel
      '
      RegisterTypeLabel.AutoSize = True
      RegisterTypeLabel.Location = New System.Drawing.Point(23, 408)
      RegisterTypeLabel.Name = "RegisterTypeLabel"
      RegisterTypeLabel.Size = New System.Drawing.Size(76, 13)
      RegisterTypeLabel.TabIndex = 29
      RegisterTypeLabel.Text = "Register Type:"
      '
      'TranscriptionFileClassBindingSource
      '
      Me.TranscriptionFileClassBindingSource.DataSource = GetType(WinFreeReg.TranscriptionFileClass)
      '
      'ChurchComboBox
      '
      Me.ChurchComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TranscriptionFileClassBindingSource, "FileHeader.Church", True))
      Me.ChurchComboBox.DataSource = Me.ChurchesBindingSource
      Me.ChurchComboBox.DisplayMember = "ChurchName"
      Me.ChurchComboBox.FormattingEnabled = True
      Me.ChurchComboBox.Location = New System.Drawing.Point(119, 33)
      Me.ChurchComboBox.Name = "ChurchComboBox"
      Me.ChurchComboBox.Size = New System.Drawing.Size(192, 21)
      Me.ChurchComboBox.TabIndex = 2
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
      Me.Comment1TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TranscriptionFileClassBindingSource, "FileHeader.Comment1", True))
      Me.Comment1TextBox.Location = New System.Drawing.Point(119, 60)
      Me.Comment1TextBox.Name = "Comment1TextBox"
      Me.Comment1TextBox.Size = New System.Drawing.Size(261, 20)
      Me.Comment1TextBox.TabIndex = 4
      '
      'Comment2TextBox
      '
      Me.Comment2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TranscriptionFileClassBindingSource, "FileHeader.Comment2", True))
      Me.Comment2TextBox.Location = New System.Drawing.Point(119, 86)
      Me.Comment2TextBox.Name = "Comment2TextBox"
      Me.Comment2TextBox.Size = New System.Drawing.Size(261, 20)
      Me.Comment2TextBox.TabIndex = 6
      '
      'CountyComboBox
      '
      Me.CountyComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TranscriptionFileClassBindingSource, "FileHeader.County", True))
      Me.CountyComboBox.DataSource = Me.CountiesBindingSource
      Me.CountyComboBox.DisplayMember = "CountyName"
      Me.CountyComboBox.FormattingEnabled = True
      Me.CountyComboBox.Location = New System.Drawing.Point(119, 112)
      Me.CountyComboBox.Name = "CountyComboBox"
      Me.CountyComboBox.Size = New System.Drawing.Size(121, 21)
      Me.CountyComboBox.TabIndex = 8
      Me.CountyComboBox.ValueMember = "ChapmanCode"
      '
      'CountiesBindingSource
      '
      Me.CountiesBindingSource.DataMember = "Counties"
      Me.CountiesBindingSource.DataSource = Me.FreeregTables
      '
      'CreditEmailTextBox
      '
      Me.CreditEmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TranscriptionFileClassBindingSource, "FileHeader.CreditEmail", True))
      Me.CreditEmailTextBox.Location = New System.Drawing.Point(119, 139)
      Me.CreditEmailTextBox.Name = "CreditEmailTextBox"
      Me.CreditEmailTextBox.Size = New System.Drawing.Size(121, 20)
      Me.CreditEmailTextBox.TabIndex = 10
      '
      'CreditNameTextBox
      '
      Me.CreditNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TranscriptionFileClassBindingSource, "FileHeader.CreditName", True))
      Me.CreditNameTextBox.Location = New System.Drawing.Point(119, 165)
      Me.CreditNameTextBox.Name = "CreditNameTextBox"
      Me.CreditNameTextBox.Size = New System.Drawing.Size(121, 20)
      Me.CreditNameTextBox.TabIndex = 12
      '
      'FileTypeComboBox
      '
      Me.FileTypeComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TranscriptionFileClassBindingSource, "FileHeader.FileType", True))
      Me.FileTypeComboBox.DataSource = Me.RecordTypesBindingSource
      Me.FileTypeComboBox.DisplayMember = "Description"
      Me.FileTypeComboBox.FormattingEnabled = True
      Me.FileTypeComboBox.Location = New System.Drawing.Point(119, 191)
      Me.FileTypeComboBox.Name = "FileTypeComboBox"
      Me.FileTypeComboBox.Size = New System.Drawing.Size(121, 21)
      Me.FileTypeComboBox.TabIndex = 14
      Me.FileTypeComboBox.ValueMember = "Type"
      '
      'RecordTypesBindingSource
      '
      Me.RecordTypesBindingSource.DataMember = "RecordTypes"
      Me.RecordTypesBindingSource.DataSource = GetType(WinFreeReg.LookupTables)
      '
      'InternalFilenameTextBox
      '
      Me.InternalFilenameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TranscriptionFileClassBindingSource, "FileHeader.InternalFilename", True))
      Me.InternalFilenameTextBox.Location = New System.Drawing.Point(119, 218)
      Me.InternalFilenameTextBox.Name = "InternalFilenameTextBox"
      Me.InternalFilenameTextBox.Size = New System.Drawing.Size(121, 20)
      Me.InternalFilenameTextBox.TabIndex = 16
      '
      'IsLDSCheckBox
      '
      Me.IsLDSCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TranscriptionFileClassBindingSource, "FileHeader.isLDS", True))
      Me.IsLDSCheckBox.Location = New System.Drawing.Point(119, 244)
      Me.IsLDSCheckBox.Name = "IsLDSCheckBox"
      Me.IsLDSCheckBox.Size = New System.Drawing.Size(121, 24)
      Me.IsLDSCheckBox.TabIndex = 18
      Me.IsLDSCheckBox.Text = "Extra columns"
      Me.IsLDSCheckBox.UseVisualStyleBackColor = True
      '
      'MyEmailTextBox
      '
      Me.MyEmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TranscriptionFileClassBindingSource, "FileHeader.MyEmail", True))
      Me.MyEmailTextBox.Location = New System.Drawing.Point(119, 274)
      Me.MyEmailTextBox.Name = "MyEmailTextBox"
      Me.MyEmailTextBox.Size = New System.Drawing.Size(121, 20)
      Me.MyEmailTextBox.TabIndex = 20
      '
      'MyNameTextBox
      '
      Me.MyNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TranscriptionFileClassBindingSource, "FileHeader.MyName", True))
      Me.MyNameTextBox.Location = New System.Drawing.Point(119, 300)
      Me.MyNameTextBox.Name = "MyNameTextBox"
      Me.MyNameTextBox.Size = New System.Drawing.Size(121, 20)
      Me.MyNameTextBox.TabIndex = 22
      '
      'MyPasswordTextBox
      '
      Me.MyPasswordTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TranscriptionFileClassBindingSource, "FileHeader.MyPassword", True))
      Me.MyPasswordTextBox.Location = New System.Drawing.Point(119, 326)
      Me.MyPasswordTextBox.Name = "MyPasswordTextBox"
      Me.MyPasswordTextBox.Size = New System.Drawing.Size(121, 20)
      Me.MyPasswordTextBox.TabIndex = 24
      Me.MyPasswordTextBox.UseSystemPasswordChar = True
      '
      'MySyndicateTextBox
      '
      Me.MySyndicateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TranscriptionFileClassBindingSource, "FileHeader.MySyndicate", True))
      Me.MySyndicateTextBox.Location = New System.Drawing.Point(119, 352)
      Me.MySyndicateTextBox.Name = "MySyndicateTextBox"
      Me.MySyndicateTextBox.Size = New System.Drawing.Size(121, 20)
      Me.MySyndicateTextBox.TabIndex = 26
      '
      'PlaceComboBox
      '
      Me.PlaceComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TranscriptionFileClassBindingSource, "FileHeader.Place", True))
      Me.PlaceComboBox.DataSource = Me.PlacesBindingSource
      Me.PlaceComboBox.DisplayMember = "PlaceName"
      Me.PlaceComboBox.FormattingEnabled = True
      Me.PlaceComboBox.Location = New System.Drawing.Point(119, 378)
      Me.PlaceComboBox.Name = "PlaceComboBox"
      Me.PlaceComboBox.Size = New System.Drawing.Size(192, 21)
      Me.PlaceComboBox.TabIndex = 28
      Me.PlaceComboBox.ValueMember = "PlaceName"
      '
      'PlacesBindingSource
      '
      Me.PlacesBindingSource.DataMember = "Places"
      Me.PlacesBindingSource.DataSource = Me.FreeregTables
      '
      'RegisterTypeComboBox
      '
      Me.RegisterTypeComboBox.DataSource = Me.RegisterTypesBindingSource
      Me.RegisterTypeComboBox.DisplayMember = "Description"
      Me.RegisterTypeComboBox.FormattingEnabled = True
      Me.RegisterTypeComboBox.Location = New System.Drawing.Point(119, 405)
      Me.RegisterTypeComboBox.Name = "RegisterTypeComboBox"
      Me.RegisterTypeComboBox.Size = New System.Drawing.Size(121, 21)
      Me.RegisterTypeComboBox.TabIndex = 30
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
      Me.ClientSize = New System.Drawing.Size(426, 506)
      Me.Controls.Add(ChurchLabel)
      Me.Controls.Add(Me.ChurchComboBox)
      Me.Controls.Add(Comment1Label)
      Me.Controls.Add(Me.Comment1TextBox)
      Me.Controls.Add(Comment2Label)
      Me.Controls.Add(Me.Comment2TextBox)
      Me.Controls.Add(CountyLabel)
      Me.Controls.Add(Me.CountyComboBox)
      Me.Controls.Add(CreditEmailLabel)
      Me.Controls.Add(Me.CreditEmailTextBox)
      Me.Controls.Add(CreditNameLabel)
      Me.Controls.Add(Me.CreditNameTextBox)
      Me.Controls.Add(FileTypeLabel)
      Me.Controls.Add(Me.FileTypeComboBox)
      Me.Controls.Add(InternalFilenameLabel)
      Me.Controls.Add(Me.InternalFilenameTextBox)
      Me.Controls.Add(Me.IsLDSCheckBox)
      Me.Controls.Add(MyEmailLabel)
      Me.Controls.Add(Me.MyEmailTextBox)
      Me.Controls.Add(MyNameLabel)
      Me.Controls.Add(Me.MyNameTextBox)
      Me.Controls.Add(MyPasswordLabel)
      Me.Controls.Add(Me.MyPasswordTextBox)
      Me.Controls.Add(MySyndicateLabel)
      Me.Controls.Add(Me.MySyndicateTextBox)
      Me.Controls.Add(PlaceLabel)
      Me.Controls.Add(Me.PlaceComboBox)
      Me.Controls.Add(RegisterTypeLabel)
      Me.Controls.Add(Me.RegisterTypeComboBox)
      Me.Name = "formFileDetails"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "FIle Details - {0}"
      CType(Me.TranscriptionFileClassBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ChurchesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.FreeregTables, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.CountiesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RecordTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PlacesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RegisterTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents TranscriptionFileClassBindingSource As System.Windows.Forms.BindingSource
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
   Friend WithEvents RecordTypesBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents ChurchesBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents FreeregTables As WinFreeReg.FreeregTables
	Friend WithEvents CountiesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents PlacesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents RegisterTypesBindingSource As System.Windows.Forms.BindingSource
End Class
