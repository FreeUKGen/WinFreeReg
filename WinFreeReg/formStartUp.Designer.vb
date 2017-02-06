<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formStartUp
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formStartUp))
      Me.PasswordTextBox = New System.Windows.Forms.TextBox()
      Me.UserIdTextBox = New System.Windows.Forms.TextBox()
      Me.PasswordLabel = New System.Windows.Forms.Label()
      Me.UserIdLabel = New System.Windows.Forms.Label()
      Me.buttonStart = New System.Windows.Forms.Button()
      Me.TranscriptionLibraryLabel = New System.Windows.Forms.Label()
      Me.linkBrowse = New System.Windows.Forms.LinkLabel()
      Me.dlgTranscriptionFolderBrowser = New System.Windows.Forms.FolderBrowserDialog()
      Me.LibraryTextBox = New System.Windows.Forms.TextBox()
      Me.UrlLabel = New System.Windows.Forms.Label()
      Me.UrlTextBox = New System.Windows.Forms.TextBox()
      Me.urlErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.libraryErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.DefaultCountyLabel = New System.Windows.Forms.Label()
      Me.DefaultCountyComboBox = New System.Windows.Forms.ComboBox()
      Me.TraceCheckBox = New System.Windows.Forms.CheckBox()
      Me.UserNameLabel = New System.Windows.Forms.Label()
      Me.UserNameTextBox = New System.Windows.Forms.TextBox()
      Me.EmailAddressLabel = New System.Windows.Forms.Label()
      Me.EmailAddressTextBox = New System.Windows.Forms.TextBox()
      Me.linkPassword = New System.Windows.Forms.LinkLabel()
      Me.KeepOpenCheckBox = New System.Windows.Forms.CheckBox()
      Me.UserLookupTables = New WinFreeReg.LookupTables()
      Me.btnConfigureLibrary = New System.Windows.Forms.Button()
      CType(Me.urlErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.libraryErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.UserLookupTables, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'PasswordTextBox
      '
      Me.PasswordTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.PasswordTextBox.Location = New System.Drawing.Point(238, 98)
      Me.PasswordTextBox.Name = "PasswordTextBox"
      Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.PasswordTextBox.Size = New System.Drawing.Size(220, 26)
      Me.PasswordTextBox.TabIndex = 7
      '
      'UserIdTextBox
      '
      Me.UserIdTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.UserIdTextBox.Location = New System.Drawing.Point(12, 98)
      Me.UserIdTextBox.Name = "UserIdTextBox"
      Me.UserIdTextBox.Size = New System.Drawing.Size(220, 26)
      Me.UserIdTextBox.TabIndex = 5
      '
      'PasswordLabel
      '
      Me.PasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.PasswordLabel.Location = New System.Drawing.Point(238, 78)
      Me.PasswordLabel.Name = "PasswordLabel"
      Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
      Me.PasswordLabel.TabIndex = 6
      Me.PasswordLabel.Text = "&Password"
      Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'UserIdLabel
      '
      Me.UserIdLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.UserIdLabel.Location = New System.Drawing.Point(12, 78)
      Me.UserIdLabel.Name = "UserIdLabel"
      Me.UserIdLabel.Size = New System.Drawing.Size(220, 23)
      Me.UserIdLabel.TabIndex = 4
      Me.UserIdLabel.Text = "FreeREG &User Id."
      Me.UserIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'buttonStart
      '
      Me.buttonStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.buttonStart.AutoSize = True
      Me.buttonStart.Enabled = False
      Me.buttonStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.buttonStart.Location = New System.Drawing.Point(377, 292)
      Me.buttonStart.Name = "buttonStart"
      Me.buttonStart.Size = New System.Drawing.Size(81, 35)
      Me.buttonStart.TabIndex = 16
      Me.buttonStart.Text = "Begin"
      Me.buttonStart.UseVisualStyleBackColor = True
      '
      'TranscriptionLibraryLabel
      '
      Me.TranscriptionLibraryLabel.AutoSize = True
      Me.TranscriptionLibraryLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.TranscriptionLibraryLabel.Location = New System.Drawing.Point(8, 237)
      Me.TranscriptionLibraryLabel.Name = "TranscriptionLibraryLabel"
      Me.TranscriptionLibraryLabel.Size = New System.Drawing.Size(157, 20)
      Me.TranscriptionLibraryLabel.TabIndex = 12
      Me.TranscriptionLibraryLabel.Text = "Transcriptions Folder"
      '
      'linkBrowse
      '
      Me.linkBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.linkBrowse.AutoSize = True
      Me.linkBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.linkBrowse.Location = New System.Drawing.Point(416, 264)
      Me.linkBrowse.Margin = New System.Windows.Forms.Padding(0)
      Me.linkBrowse.Name = "linkBrowse"
      Me.linkBrowse.Size = New System.Drawing.Size(42, 13)
      Me.linkBrowse.TabIndex = 14
      Me.linkBrowse.TabStop = True
      Me.linkBrowse.Text = "Browse"
      '
      'LibraryTextBox
      '
      Me.LibraryTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.LibraryTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LibraryTextBox.Location = New System.Drawing.Point(12, 257)
      Me.LibraryTextBox.Name = "LibraryTextBox"
      Me.LibraryTextBox.Size = New System.Drawing.Size(391, 26)
      Me.LibraryTextBox.TabIndex = 13
      '
      'UrlLabel
      '
      Me.UrlLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.UrlLabel.Location = New System.Drawing.Point(12, 178)
      Me.UrlLabel.Name = "UrlLabel"
      Me.UrlLabel.Size = New System.Drawing.Size(220, 23)
      Me.UrlLabel.TabIndex = 10
      Me.UrlLabel.Text = "FreeREG Url"
      Me.UrlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'UrlTextBox
      '
      Me.UrlTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.UrlTextBox.Location = New System.Drawing.Point(12, 198)
      Me.UrlTextBox.Name = "UrlTextBox"
      Me.UrlTextBox.Size = New System.Drawing.Size(387, 26)
      Me.UrlTextBox.TabIndex = 11
      '
      'urlErrorProvider
      '
      Me.urlErrorProvider.ContainerControl = Me
      '
      'libraryErrorProvider
      '
      Me.libraryErrorProvider.ContainerControl = Me
      '
      'DefaultCountyLabel
      '
      Me.DefaultCountyLabel.AutoSize = True
      Me.DefaultCountyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DefaultCountyLabel.Location = New System.Drawing.Point(12, 127)
      Me.DefaultCountyLabel.Name = "DefaultCountyLabel"
      Me.DefaultCountyLabel.Size = New System.Drawing.Size(115, 20)
      Me.DefaultCountyLabel.TabIndex = 8
      Me.DefaultCountyLabel.Text = "Default County"
      '
      'DefaultCountyComboBox
      '
      Me.DefaultCountyComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
      Me.DefaultCountyComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.DefaultCountyComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
      Me.DefaultCountyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.DefaultCountyComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DefaultCountyComboBox.FormattingEnabled = True
      Me.DefaultCountyComboBox.Location = New System.Drawing.Point(12, 150)
      Me.DefaultCountyComboBox.Name = "DefaultCountyComboBox"
      Me.DefaultCountyComboBox.Size = New System.Drawing.Size(220, 27)
      Me.DefaultCountyComboBox.TabIndex = 9
      '
      'TraceCheckBox
      '
      Me.TraceCheckBox.AutoSize = True
      Me.TraceCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.TraceCheckBox.Location = New System.Drawing.Point(12, 308)
      Me.TraceCheckBox.Name = "TraceCheckBox"
      Me.TraceCheckBox.Size = New System.Drawing.Size(76, 14)
      Me.TraceCheckBox.TabIndex = 15
      Me.TraceCheckBox.Text = "Network trace?"
      Me.TraceCheckBox.UseVisualStyleBackColor = True
      Me.TraceCheckBox.Visible = False
      '
      'UserNameLabel
      '
      Me.UserNameLabel.AutoSize = True
      Me.UserNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.UserNameLabel.Location = New System.Drawing.Point(12, 9)
      Me.UserNameLabel.Name = "UserNameLabel"
      Me.UserNameLabel.Size = New System.Drawing.Size(89, 20)
      Me.UserNameLabel.TabIndex = 0
      Me.UserNameLabel.Text = "Your Name"
      '
      'UserNameTextBox
      '
      Me.UserNameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.UserNameTextBox.Location = New System.Drawing.Point(16, 32)
      Me.UserNameTextBox.Name = "UserNameTextBox"
      Me.UserNameTextBox.Size = New System.Drawing.Size(216, 26)
      Me.UserNameTextBox.TabIndex = 1
      '
      'EmailAddressLabel
      '
      Me.EmailAddressLabel.AutoSize = True
      Me.EmailAddressLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.EmailAddressLabel.Location = New System.Drawing.Point(238, 9)
      Me.EmailAddressLabel.Name = "EmailAddressLabel"
      Me.EmailAddressLabel.Size = New System.Drawing.Size(111, 20)
      Me.EmailAddressLabel.TabIndex = 2
      Me.EmailAddressLabel.Text = "Email Address"
      '
      'EmailAddressTextBox
      '
      Me.EmailAddressTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.EmailAddressTextBox.Location = New System.Drawing.Point(242, 32)
      Me.EmailAddressTextBox.Name = "EmailAddressTextBox"
      Me.EmailAddressTextBox.Size = New System.Drawing.Size(216, 26)
      Me.EmailAddressTextBox.TabIndex = 3
      '
      'linkPassword
      '
      Me.linkPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.linkPassword.AutoSize = True
      Me.linkPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.linkPassword.Location = New System.Drawing.Point(376, 132)
      Me.linkPassword.Name = "linkPassword"
      Me.linkPassword.Size = New System.Drawing.Size(82, 13)
      Me.linkPassword.TabIndex = 17
      Me.linkPassword.TabStop = True
      Me.linkPassword.Tag = ""
      Me.linkPassword.Text = "Show password"
      '
      'KeepOpenCheckBox
      '
      Me.KeepOpenCheckBox.AutoSize = True
      Me.KeepOpenCheckBox.Checked = True
      Me.KeepOpenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
      Me.KeepOpenCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.KeepOpenCheckBox.Location = New System.Drawing.Point(312, 308)
      Me.KeepOpenCheckBox.Name = "KeepOpenCheckBox"
      Me.KeepOpenCheckBox.Size = New System.Drawing.Size(59, 14)
      Me.KeepOpenCheckBox.TabIndex = 18
      Me.KeepOpenCheckBox.Text = "Keep open"
      Me.KeepOpenCheckBox.UseVisualStyleBackColor = True
      '
      'UserLookupTables
      '
      Me.UserLookupTables.DataSetName = "LookupTables"
      Me.UserLookupTables.Locale = New System.Globalization.CultureInfo("")
      Me.UserLookupTables.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'btnConfigureLibrary
      '
      Me.btnConfigureLibrary.AutoSize = True
      Me.btnConfigureLibrary.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnConfigureLibrary.Location = New System.Drawing.Point(97, 237)
      Me.btnConfigureLibrary.Name = "btnConfigureLibrary"
      Me.btnConfigureLibrary.Size = New System.Drawing.Size(274, 46)
      Me.btnConfigureLibrary.TabIndex = 19
      Me.btnConfigureLibrary.Text = "Configure Transcriptions Library"
      Me.btnConfigureLibrary.UseVisualStyleBackColor = True
      Me.btnConfigureLibrary.Visible = False
      '
      'formStartUp
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.ClientSize = New System.Drawing.Size(468, 339)
      Me.Controls.Add(Me.btnConfigureLibrary)
      Me.Controls.Add(Me.KeepOpenCheckBox)
      Me.Controls.Add(Me.linkPassword)
      Me.Controls.Add(Me.EmailAddressTextBox)
      Me.Controls.Add(Me.EmailAddressLabel)
      Me.Controls.Add(Me.UserNameTextBox)
      Me.Controls.Add(Me.UserNameLabel)
      Me.Controls.Add(Me.TraceCheckBox)
      Me.Controls.Add(Me.DefaultCountyComboBox)
      Me.Controls.Add(Me.DefaultCountyLabel)
      Me.Controls.Add(Me.UrlTextBox)
      Me.Controls.Add(Me.UrlLabel)
      Me.Controls.Add(Me.linkBrowse)
      Me.Controls.Add(Me.LibraryTextBox)
      Me.Controls.Add(Me.TranscriptionLibraryLabel)
      Me.Controls.Add(Me.buttonStart)
      Me.Controls.Add(Me.PasswordTextBox)
      Me.Controls.Add(Me.UserIdTextBox)
      Me.Controls.Add(Me.PasswordLabel)
      Me.Controls.Add(Me.UserIdLabel)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.HelpButton = True
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "formStartUp"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "WinFreeReg - Startup"
      CType(Me.urlErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.libraryErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.UserLookupTables, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
   Friend WithEvents UserIdTextBox As System.Windows.Forms.TextBox
   Friend WithEvents PasswordLabel As System.Windows.Forms.Label
   Friend WithEvents UserIdLabel As System.Windows.Forms.Label
   Friend WithEvents buttonStart As System.Windows.Forms.Button
   Friend WithEvents TranscriptionLibraryLabel As System.Windows.Forms.Label
   Friend WithEvents LibraryTextBox As System.Windows.Forms.TextBox
   Private WithEvents linkBrowse As System.Windows.Forms.LinkLabel
   Friend WithEvents dlgTranscriptionFolderBrowser As System.Windows.Forms.FolderBrowserDialog
   Friend WithEvents UrlLabel As System.Windows.Forms.Label
   Friend WithEvents UrlTextBox As System.Windows.Forms.TextBox
   Friend WithEvents urlErrorProvider As System.Windows.Forms.ErrorProvider
   Friend WithEvents libraryErrorProvider As System.Windows.Forms.ErrorProvider
   Friend WithEvents DefaultCountyComboBox As System.Windows.Forms.ComboBox
   Friend WithEvents DefaultCountyLabel As System.Windows.Forms.Label
   Friend WithEvents UserLookupTables As WinFreeReg.LookupTables
   Friend WithEvents TraceCheckBox As System.Windows.Forms.CheckBox
   Friend WithEvents UserNameLabel As System.Windows.Forms.Label
   Friend WithEvents EmailAddressTextBox As System.Windows.Forms.TextBox
   Friend WithEvents EmailAddressLabel As System.Windows.Forms.Label
   Friend WithEvents UserNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents linkPassword As System.Windows.Forms.LinkLabel
   Friend WithEvents KeepOpenCheckBox As System.Windows.Forms.CheckBox
   Friend WithEvents btnConfigureLibrary As System.Windows.Forms.Button

End Class
