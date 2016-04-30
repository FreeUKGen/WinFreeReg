<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formStartNewFile
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formStartNewFile))
		Me.labCounty = New System.Windows.Forms.Label
		Me.FreeregTables = New WinREG.FreeregTables
		Me.CountiesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.CountiesComboBox = New System.Windows.Forms.ComboBox
		Me.labPlace = New System.Windows.Forms.Label
		Me.PlacesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.PlacesComboBox = New System.Windows.Forms.ComboBox
		Me.labChurch = New System.Windows.Forms.Label
		Me.ChurchesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.ChurchesComboBox = New System.Windows.Forms.ComboBox
		Me.RegisterTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.RegisterTypesComboBox = New System.Windows.Forms.ComboBox
		Me.labRegisterType = New System.Windows.Forms.Label
		Me.LookupTables = New WinREG.LookupTables
		Me.RecordTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.RecordTypesComboBox = New System.Windows.Forms.ComboBox
		Me.labRecordType = New System.Windows.Forms.Label
		Me.labComments = New System.Windows.Forms.Label
		Me.Comment1TextBox = New System.Windows.Forms.TextBox
		Me.Comment2TextBox = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.labFilename = New System.Windows.Forms.Label
		Me.labCode = New System.Windows.Forms.Label
		Me.CodeTextBox = New System.Windows.Forms.TextBox
		Me.ChurchTextBox = New System.Windows.Forms.TextBox
		CType(Me.FreeregTables, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.CountiesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PlacesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ChurchesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.RegisterTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.LookupTables, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.RecordTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'labCounty
		'
		Me.labCounty.AutoSize = True
		Me.labCounty.Location = New System.Drawing.Point(41, 35)
		Me.labCounty.Name = "labCounty"
		Me.labCounty.Size = New System.Drawing.Size(40, 13)
		Me.labCounty.TabIndex = 0
		Me.labCounty.Text = "County"
		'
		'FreeregTables
		'
		Me.FreeregTables.DataSetName = "FreeregTables"
		Me.FreeregTables.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'CountiesBindingSource
		'
		Me.CountiesBindingSource.DataMember = "Counties"
		Me.CountiesBindingSource.DataSource = Me.FreeregTables
		'
		'CountiesComboBox
		'
		Me.CountiesComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
		Me.CountiesComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.CountiesComboBox.DataSource = Me.CountiesBindingSource
		Me.CountiesComboBox.DisplayMember = "CountyName"
		Me.CountiesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.CountiesComboBox.FormattingEnabled = True
		Me.CountiesComboBox.Location = New System.Drawing.Point(87, 32)
		Me.CountiesComboBox.Name = "CountiesComboBox"
		Me.CountiesComboBox.Size = New System.Drawing.Size(155, 21)
		Me.CountiesComboBox.TabIndex = 1
		Me.CountiesComboBox.ValueMember = "ChapmanCode"
		'
		'labPlace
		'
		Me.labPlace.AutoSize = True
		Me.labPlace.Location = New System.Drawing.Point(47, 67)
		Me.labPlace.Name = "labPlace"
		Me.labPlace.Size = New System.Drawing.Size(34, 13)
		Me.labPlace.TabIndex = 2
		Me.labPlace.Text = "Place"
		Me.labPlace.Visible = False
		'
		'PlacesBindingSource
		'
		Me.PlacesBindingSource.DataMember = "Places"
		Me.PlacesBindingSource.DataSource = Me.FreeregTables
		'
		'PlacesComboBox
		'
		Me.PlacesComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
		Me.PlacesComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.PlacesComboBox.DataSource = Me.PlacesBindingSource
		Me.PlacesComboBox.DisplayMember = "PlaceName"
		Me.PlacesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.PlacesComboBox.Enabled = False
		Me.PlacesComboBox.FormattingEnabled = True
		Me.PlacesComboBox.Location = New System.Drawing.Point(87, 64)
		Me.PlacesComboBox.Name = "PlacesComboBox"
		Me.PlacesComboBox.Size = New System.Drawing.Size(300, 21)
		Me.PlacesComboBox.TabIndex = 3
		Me.PlacesComboBox.ValueMember = "PlaceName"
		Me.PlacesComboBox.Visible = False
		'
		'labChurch
		'
		Me.labChurch.AutoSize = True
		Me.labChurch.Location = New System.Drawing.Point(40, 99)
		Me.labChurch.Name = "labChurch"
		Me.labChurch.Size = New System.Drawing.Size(41, 13)
		Me.labChurch.TabIndex = 4
		Me.labChurch.Text = "Church"
		Me.labChurch.Visible = False
		'
		'ChurchesBindingSource
		'
		Me.ChurchesBindingSource.DataMember = "Churches"
		Me.ChurchesBindingSource.DataSource = Me.FreeregTables
		'
		'ChurchesComboBox
		'
		Me.ChurchesComboBox.DataSource = Me.ChurchesBindingSource
		Me.ChurchesComboBox.DisplayMember = "ChurchName"
		Me.ChurchesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ChurchesComboBox.Enabled = False
		Me.ChurchesComboBox.FormattingEnabled = True
		Me.ChurchesComboBox.Location = New System.Drawing.Point(87, 96)
		Me.ChurchesComboBox.Name = "ChurchesComboBox"
		Me.ChurchesComboBox.Size = New System.Drawing.Size(300, 21)
		Me.ChurchesComboBox.TabIndex = 5
		Me.ChurchesComboBox.ValueMember = "ChurchName"
		Me.ChurchesComboBox.Visible = False
		'
		'RegisterTypesBindingSource
		'
		Me.RegisterTypesBindingSource.DataMember = "RegisterTypes"
		Me.RegisterTypesBindingSource.DataSource = Me.FreeregTables
		'
		'RegisterTypesComboBox
		'
		Me.RegisterTypesComboBox.DataSource = Me.RegisterTypesBindingSource
		Me.RegisterTypesComboBox.DisplayMember = "Description"
		Me.RegisterTypesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.RegisterTypesComboBox.Enabled = False
		Me.RegisterTypesComboBox.FormattingEnabled = True
		Me.RegisterTypesComboBox.Location = New System.Drawing.Point(87, 128)
		Me.RegisterTypesComboBox.Name = "RegisterTypesComboBox"
		Me.RegisterTypesComboBox.Size = New System.Drawing.Size(300, 21)
		Me.RegisterTypesComboBox.TabIndex = 9
		Me.RegisterTypesComboBox.ValueMember = "Type"
		Me.RegisterTypesComboBox.Visible = False
		'
		'labRegisterType
		'
		Me.labRegisterType.AutoSize = True
		Me.labRegisterType.Location = New System.Drawing.Point(12, 131)
		Me.labRegisterType.Name = "labRegisterType"
		Me.labRegisterType.Size = New System.Drawing.Size(69, 13)
		Me.labRegisterType.TabIndex = 8
		Me.labRegisterType.Text = "Register type"
		Me.labRegisterType.Visible = False
		'
		'LookupTables
		'
		Me.LookupTables.DataSetName = "LookupTables"
		Me.LookupTables.Locale = New System.Globalization.CultureInfo("")
		Me.LookupTables.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'RecordTypesBindingSource
		'
		Me.RecordTypesBindingSource.DataMember = "RecordTypes"
		Me.RecordTypesBindingSource.DataSource = Me.LookupTables
		'
		'RecordTypesComboBox
		'
		Me.RecordTypesComboBox.DataSource = Me.RecordTypesBindingSource
		Me.RecordTypesComboBox.DisplayMember = "Description"
		Me.RecordTypesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.RecordTypesComboBox.Enabled = False
		Me.RecordTypesComboBox.FormattingEnabled = True
		Me.RecordTypesComboBox.Location = New System.Drawing.Point(87, 160)
		Me.RecordTypesComboBox.Name = "RecordTypesComboBox"
		Me.RecordTypesComboBox.Size = New System.Drawing.Size(100, 21)
		Me.RecordTypesComboBox.TabIndex = 11
		Me.RecordTypesComboBox.ValueMember = "Type"
		Me.RecordTypesComboBox.Visible = False
		'
		'labRecordType
		'
		Me.labRecordType.AutoSize = True
		Me.labRecordType.Location = New System.Drawing.Point(12, 163)
		Me.labRecordType.Name = "labRecordType"
		Me.labRecordType.Size = New System.Drawing.Size(69, 13)
		Me.labRecordType.TabIndex = 10
		Me.labRecordType.Text = "Record Type"
		Me.labRecordType.Visible = False
		'
		'labComments
		'
		Me.labComments.AutoSize = True
		Me.labComments.Location = New System.Drawing.Point(25, 236)
		Me.labComments.Name = "labComments"
		Me.labComments.Size = New System.Drawing.Size(56, 13)
		Me.labComments.TabIndex = 14
		Me.labComments.Text = "Comments"
		Me.labComments.Visible = False
		'
		'Comment1TextBox
		'
		Me.Comment1TextBox.Enabled = False
		Me.Comment1TextBox.Location = New System.Drawing.Point(87, 233)
		Me.Comment1TextBox.Name = "Comment1TextBox"
		Me.Comment1TextBox.Size = New System.Drawing.Size(568, 20)
		Me.Comment1TextBox.TabIndex = 15
		Me.Comment1TextBox.Visible = False
		'
		'Comment2TextBox
		'
		Me.Comment2TextBox.Enabled = False
		Me.Comment2TextBox.Location = New System.Drawing.Point(87, 260)
		Me.Comment2TextBox.Name = "Comment2TextBox"
		Me.Comment2TextBox.Size = New System.Drawing.Size(568, 20)
		Me.Comment2TextBox.TabIndex = 16
		Me.Comment2TextBox.Visible = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(32, 202)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(49, 13)
		Me.Label1.TabIndex = 12
		Me.Label1.Text = "Filename"
		'
		'labFilename
		'
		Me.labFilename.AutoSize = True
		Me.labFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labFilename.Location = New System.Drawing.Point(87, 197)
		Me.labFilename.Name = "labFilename"
		Me.labFilename.Size = New System.Drawing.Size(106, 20)
		Me.labFilename.TabIndex = 13
		Me.labFilename.Text = "labFilename"
		'
		'labCode
		'
		Me.labCode.AutoSize = True
		Me.labCode.Location = New System.Drawing.Point(411, 99)
		Me.labCode.Name = "labCode"
		Me.labCode.Size = New System.Drawing.Size(32, 13)
		Me.labCode.TabIndex = 6
		Me.labCode.Text = "Code"
		Me.labCode.Visible = False
		'
		'CodeTextBox
		'
		Me.CodeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.CodeTextBox.Enabled = False
		Me.CodeTextBox.Location = New System.Drawing.Point(449, 96)
		Me.CodeTextBox.MaxLength = 3
		Me.CodeTextBox.Name = "CodeTextBox"
		Me.CodeTextBox.Size = New System.Drawing.Size(44, 20)
		Me.CodeTextBox.TabIndex = 7
		Me.CodeTextBox.Visible = False
		'
		'ChurchTextBox
		'
		Me.ChurchTextBox.Enabled = False
		Me.ChurchTextBox.Location = New System.Drawing.Point(87, 96)
		Me.ChurchTextBox.Name = "ChurchTextBox"
		Me.ChurchTextBox.ReadOnly = True
		Me.ChurchTextBox.Size = New System.Drawing.Size(300, 20)
		Me.ChurchTextBox.TabIndex = 17
		Me.ChurchTextBox.Visible = False
		'
		'formStartNewFile
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(708, 357)
		Me.Controls.Add(Me.ChurchTextBox)
		Me.Controls.Add(Me.CodeTextBox)
		Me.Controls.Add(Me.labCode)
		Me.Controls.Add(Me.labFilename)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Comment2TextBox)
		Me.Controls.Add(Me.Comment1TextBox)
		Me.Controls.Add(Me.labComments)
		Me.Controls.Add(Me.RecordTypesComboBox)
		Me.Controls.Add(Me.labRecordType)
		Me.Controls.Add(Me.RegisterTypesComboBox)
		Me.Controls.Add(Me.labRegisterType)
		Me.Controls.Add(Me.ChurchesComboBox)
		Me.Controls.Add(Me.labChurch)
		Me.Controls.Add(Me.PlacesComboBox)
		Me.Controls.Add(Me.labPlace)
		Me.Controls.Add(Me.CountiesComboBox)
		Me.Controls.Add(Me.labCounty)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "formStartNewFile"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Start New File"
		CType(Me.FreeregTables, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.CountiesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PlacesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ChurchesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.RegisterTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.LookupTables, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.RecordTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents labCounty As System.Windows.Forms.Label
	Friend WithEvents FreeregTables As WinREG.FreeregTables
	Friend WithEvents CountiesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents CountiesComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents labPlace As System.Windows.Forms.Label
	Friend WithEvents PlacesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents PlacesComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents labChurch As System.Windows.Forms.Label
	Friend WithEvents ChurchesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents ChurchesComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents RegisterTypesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents RegisterTypesComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents labRegisterType As System.Windows.Forms.Label
	Friend WithEvents LookupTables As WinREG.LookupTables
	Friend WithEvents RecordTypesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents RecordTypesComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents labRecordType As System.Windows.Forms.Label
	Friend WithEvents labComments As System.Windows.Forms.Label
	Friend WithEvents Comment1TextBox As System.Windows.Forms.TextBox
	Friend WithEvents Comment2TextBox As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents labFilename As System.Windows.Forms.Label
	Friend WithEvents labCode As System.Windows.Forms.Label
	Friend WithEvents CodeTextBox As System.Windows.Forms.TextBox
	Friend WithEvents ChurchTextBox As System.Windows.Forms.TextBox
End Class
