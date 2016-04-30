<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formUserDetails
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
		Dim Skill_levelLabel As System.Windows.Forms.Label
		Dim Number_of_filesLabel As System.Windows.Forms.Label
		Dim Number_of_recordsLabel As System.Windows.Forms.Label
		Dim Person_roleLabel As System.Windows.Forms.Label
		Dim Person_surnameLabel As System.Windows.Forms.Label
		Dim UseridLabel As System.Windows.Forms.Label
		Dim PasswordLabel As System.Windows.Forms.Label
		Dim Email_addressLabel As System.Windows.Forms.Label
		Dim AddressLabel As System.Windows.Forms.Label
		Dim SyndicateLabel As System.Windows.Forms.Label
		Dim Submitter_numberLabel As System.Windows.Forms.Label
		Dim Sign_up_dateLabel As System.Windows.Forms.Label
		Dim Previous_syndicateLabel As System.Windows.Forms.Label
		Dim DigestLabel As System.Windows.Forms.Label
		Dim Syndicate_groupsLabel As System.Windows.Forms.Label
		Dim County_groupsLabel As System.Windows.Forms.Label
		Dim Country_groupsLabel As System.Windows.Forms.Label
		Dim U_atLabel As System.Windows.Forms.Label
		Dim C_atLabel As System.Windows.Forms.Label
		Dim Userid_lower_caseLabel As System.Windows.Forms.Label
		Dim Last_uploadLabel As System.Windows.Forms.Label
		Dim Telephone_numberLabel As System.Windows.Forms.Label
		Dim Disabled_reasonLabel As System.Windows.Forms.Label
		Dim Password_confirmationLabel As System.Windows.Forms.Label
		Dim Disabled_dateLabel As System.Windows.Forms.Label
		Dim Email_address_confirmationLabel As System.Windows.Forms.Label
		Dim Skill_notesLabel As System.Windows.Forms.Label
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formUserDetails))
		Me.UserDetails = New WinREG.UserDetails
		Me.Skill_levelTextBox = New System.Windows.Forms.TextBox
		Me.Number_of_filesTextBox = New System.Windows.Forms.TextBox
		Me.Number_of_recordsTextBox = New System.Windows.Forms.TextBox
		Me.Person_roleTextBox = New System.Windows.Forms.TextBox
		Me.NameTextBox = New System.Windows.Forms.TextBox
		Me.UseridTextBox = New System.Windows.Forms.TextBox
		Me.PasswordTextBox = New System.Windows.Forms.TextBox
		Me.Email_addressTextBox = New System.Windows.Forms.TextBox
		Me.ActiveCheckBox = New System.Windows.Forms.CheckBox
		Me.Fiche_readerCheckBox = New System.Windows.Forms.CheckBox
		Me.AddressTextBox = New System.Windows.Forms.TextBox
		Me.SyndicateTextBox = New System.Windows.Forms.TextBox
		Me.Submitter_numberTextBox = New System.Windows.Forms.TextBox
		Me.Previous_syndicateTextBox = New System.Windows.Forms.TextBox
		Me.DigestTextBox = New System.Windows.Forms.TextBox
		Me.Syndicate_groupsTextBox = New System.Windows.Forms.TextBox
		Me.County_groupsTextBox = New System.Windows.Forms.TextBox
		Me.Country_groupsTextBox = New System.Windows.Forms.TextBox
		Me.Userid_lower_caseTextBox = New System.Windows.Forms.TextBox
		Me.Telephone_numberTextBox = New System.Windows.Forms.TextBox
		Me.Disabled_reasonTextBox = New System.Windows.Forms.TextBox
		Me.Technical_agreementCheckBox = New System.Windows.Forms.CheckBox
		Me.Research_agreementCheckBox = New System.Windows.Forms.CheckBox
		Me.Password_confirmationTextBox = New System.Windows.Forms.TextBox
		Me.Transcription_agreementCheckBox = New System.Windows.Forms.CheckBox
		Me.Email_address_confirmationTextBox = New System.Windows.Forms.TextBox
		Me.Skill_notesTextBox = New System.Windows.Forms.TextBox
		Me.Sign_up_dateTextBox = New System.Windows.Forms.TextBox
		Me.Last_uploadTextBox = New System.Windows.Forms.TextBox
		Me.U_atTextBox = New System.Windows.Forms.TextBox
		Me.C_atTextBox = New System.Windows.Forms.TextBox
		Me.Disabled_dateTextBox = New System.Windows.Forms.TextBox
		Me.btnRefresh = New System.Windows.Forms.Button
		Skill_levelLabel = New System.Windows.Forms.Label
		Number_of_filesLabel = New System.Windows.Forms.Label
		Number_of_recordsLabel = New System.Windows.Forms.Label
		Person_roleLabel = New System.Windows.Forms.Label
		Person_surnameLabel = New System.Windows.Forms.Label
		UseridLabel = New System.Windows.Forms.Label
		PasswordLabel = New System.Windows.Forms.Label
		Email_addressLabel = New System.Windows.Forms.Label
		AddressLabel = New System.Windows.Forms.Label
		SyndicateLabel = New System.Windows.Forms.Label
		Submitter_numberLabel = New System.Windows.Forms.Label
		Sign_up_dateLabel = New System.Windows.Forms.Label
		Previous_syndicateLabel = New System.Windows.Forms.Label
		DigestLabel = New System.Windows.Forms.Label
		Syndicate_groupsLabel = New System.Windows.Forms.Label
		County_groupsLabel = New System.Windows.Forms.Label
		Country_groupsLabel = New System.Windows.Forms.Label
		U_atLabel = New System.Windows.Forms.Label
		C_atLabel = New System.Windows.Forms.Label
		Userid_lower_caseLabel = New System.Windows.Forms.Label
		Last_uploadLabel = New System.Windows.Forms.Label
		Telephone_numberLabel = New System.Windows.Forms.Label
		Disabled_reasonLabel = New System.Windows.Forms.Label
		Password_confirmationLabel = New System.Windows.Forms.Label
		Disabled_dateLabel = New System.Windows.Forms.Label
		Email_address_confirmationLabel = New System.Windows.Forms.Label
		Skill_notesLabel = New System.Windows.Forms.Label
		CType(Me.UserDetails, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Skill_levelLabel
		'
		Skill_levelLabel.AutoSize = True
		Skill_levelLabel.Location = New System.Drawing.Point(12, 331)
		Skill_levelLabel.Name = "Skill_levelLabel"
		Skill_levelLabel.Size = New System.Drawing.Size(52, 13)
		Skill_levelLabel.TabIndex = 3
		Skill_levelLabel.Text = "skill level:"
		'
		'Number_of_filesLabel
		'
		Number_of_filesLabel.AutoSize = True
		Number_of_filesLabel.Location = New System.Drawing.Point(387, 151)
		Number_of_filesLabel.Name = "Number_of_filesLabel"
		Number_of_filesLabel.Size = New System.Drawing.Size(78, 13)
		Number_of_filesLabel.TabIndex = 5
		Number_of_filesLabel.Text = "number of files:"
		'
		'Number_of_recordsLabel
		'
		Number_of_recordsLabel.AutoSize = True
		Number_of_recordsLabel.Location = New System.Drawing.Point(387, 177)
		Number_of_recordsLabel.Name = "Number_of_recordsLabel"
		Number_of_recordsLabel.Size = New System.Drawing.Size(95, 13)
		Number_of_recordsLabel.TabIndex = 7
		Number_of_recordsLabel.Text = "number of records:"
		'
		'Person_roleLabel
		'
		Person_roleLabel.AutoSize = True
		Person_roleLabel.Location = New System.Drawing.Point(12, 356)
		Person_roleLabel.Name = "Person_roleLabel"
		Person_roleLabel.Size = New System.Drawing.Size(62, 13)
		Person_roleLabel.TabIndex = 9
		Person_roleLabel.Text = "person role:"
		'
		'Person_surnameLabel
		'
		Person_surnameLabel.AutoSize = True
		Person_surnameLabel.Location = New System.Drawing.Point(12, 18)
		Person_surnameLabel.Name = "Person_surnameLabel"
		Person_surnameLabel.Size = New System.Drawing.Size(38, 13)
		Person_surnameLabel.TabIndex = 11
		Person_surnameLabel.Text = "Name:"
		'
		'UseridLabel
		'
		UseridLabel.AutoSize = True
		UseridLabel.Location = New System.Drawing.Point(12, 44)
		UseridLabel.Name = "UseridLabel"
		UseridLabel.Size = New System.Drawing.Size(38, 13)
		UseridLabel.TabIndex = 13
		UseridLabel.Text = "userid:"
		'
		'PasswordLabel
		'
		PasswordLabel.AutoSize = True
		PasswordLabel.Location = New System.Drawing.Point(12, 122)
		PasswordLabel.Name = "PasswordLabel"
		PasswordLabel.Size = New System.Drawing.Size(55, 13)
		PasswordLabel.TabIndex = 15
		PasswordLabel.Text = "password:"
		'
		'Email_addressLabel
		'
		Email_addressLabel.AutoSize = True
		Email_addressLabel.Location = New System.Drawing.Point(12, 69)
		Email_addressLabel.Name = "Email_addressLabel"
		Email_addressLabel.Size = New System.Drawing.Size(74, 13)
		Email_addressLabel.TabIndex = 17
		Email_addressLabel.Text = "email address:"
		'
		'AddressLabel
		'
		AddressLabel.AutoSize = True
		AddressLabel.Location = New System.Drawing.Point(12, 174)
		AddressLabel.Name = "AddressLabel"
		AddressLabel.Size = New System.Drawing.Size(47, 13)
		AddressLabel.TabIndex = 25
		AddressLabel.Text = "address:"
		'
		'SyndicateLabel
		'
		SyndicateLabel.AutoSize = True
		SyndicateLabel.Location = New System.Drawing.Point(12, 226)
		SyndicateLabel.Name = "SyndicateLabel"
		SyndicateLabel.Size = New System.Drawing.Size(55, 13)
		SyndicateLabel.TabIndex = 27
		SyndicateLabel.Text = "syndicate:"
		'
		'Submitter_numberLabel
		'
		Submitter_numberLabel.AutoSize = True
		Submitter_numberLabel.Location = New System.Drawing.Point(387, 69)
		Submitter_numberLabel.Name = "Submitter_numberLabel"
		Submitter_numberLabel.Size = New System.Drawing.Size(90, 13)
		Submitter_numberLabel.TabIndex = 29
		Submitter_numberLabel.Text = "submitter number:"
		'
		'Sign_up_dateLabel
		'
		Sign_up_dateLabel.AutoSize = True
		Sign_up_dateLabel.Location = New System.Drawing.Point(387, 97)
		Sign_up_dateLabel.Name = "Sign_up_dateLabel"
		Sign_up_dateLabel.Size = New System.Drawing.Size(68, 13)
		Sign_up_dateLabel.TabIndex = 31
		Sign_up_dateLabel.Text = "sign up date:"
		'
		'Previous_syndicateLabel
		'
		Previous_syndicateLabel.AutoSize = True
		Previous_syndicateLabel.Location = New System.Drawing.Point(387, 228)
		Previous_syndicateLabel.Name = "Previous_syndicateLabel"
		Previous_syndicateLabel.Size = New System.Drawing.Size(98, 13)
		Previous_syndicateLabel.TabIndex = 33
		Previous_syndicateLabel.Text = "previous syndicate:"
		'
		'DigestLabel
		'
		DigestLabel.AutoSize = True
		DigestLabel.Location = New System.Drawing.Point(387, 253)
		DigestLabel.Name = "DigestLabel"
		DigestLabel.Size = New System.Drawing.Size(38, 13)
		DigestLabel.TabIndex = 35
		DigestLabel.Text = "digest:"
		'
		'Syndicate_groupsLabel
		'
		Syndicate_groupsLabel.AutoSize = True
		Syndicate_groupsLabel.Location = New System.Drawing.Point(12, 253)
		Syndicate_groupsLabel.Name = "Syndicate_groupsLabel"
		Syndicate_groupsLabel.Size = New System.Drawing.Size(90, 13)
		Syndicate_groupsLabel.TabIndex = 37
		Syndicate_groupsLabel.Text = "syndicate groups:"
		'
		'County_groupsLabel
		'
		County_groupsLabel.AutoSize = True
		County_groupsLabel.Location = New System.Drawing.Point(12, 278)
		County_groupsLabel.Name = "County_groupsLabel"
		County_groupsLabel.Size = New System.Drawing.Size(77, 13)
		County_groupsLabel.TabIndex = 39
		County_groupsLabel.Text = "county groups:"
		'
		'Country_groupsLabel
		'
		Country_groupsLabel.AutoSize = True
		Country_groupsLabel.Location = New System.Drawing.Point(12, 304)
		Country_groupsLabel.Name = "Country_groupsLabel"
		Country_groupsLabel.Size = New System.Drawing.Size(80, 13)
		Country_groupsLabel.TabIndex = 41
		Country_groupsLabel.Text = "country groups:"
		'
		'U_atLabel
		'
		U_atLabel.AutoSize = True
		U_atLabel.Location = New System.Drawing.Point(387, 278)
		U_atLabel.Name = "U_atLabel"
		U_atLabel.Size = New System.Drawing.Size(28, 13)
		U_atLabel.TabIndex = 43
		U_atLabel.Text = "u at:"
		'
		'C_atLabel
		'
		C_atLabel.AutoSize = True
		C_atLabel.Location = New System.Drawing.Point(387, 304)
		C_atLabel.Name = "C_atLabel"
		C_atLabel.Size = New System.Drawing.Size(28, 13)
		C_atLabel.TabIndex = 45
		C_atLabel.Text = "c at:"
		'
		'Userid_lower_caseLabel
		'
		Userid_lower_caseLabel.AutoSize = True
		Userid_lower_caseLabel.Location = New System.Drawing.Point(387, 43)
		Userid_lower_caseLabel.Name = "Userid_lower_caseLabel"
		Userid_lower_caseLabel.Size = New System.Drawing.Size(92, 13)
		Userid_lower_caseLabel.TabIndex = 47
		Userid_lower_caseLabel.Text = "userid lower case:"
		'
		'Last_uploadLabel
		'
		Last_uploadLabel.AutoSize = True
		Last_uploadLabel.Location = New System.Drawing.Point(387, 123)
		Last_uploadLabel.Name = "Last_uploadLabel"
		Last_uploadLabel.Size = New System.Drawing.Size(61, 13)
		Last_uploadLabel.TabIndex = 49
		Last_uploadLabel.Text = "last upload:"
		'
		'Telephone_numberLabel
		'
		Telephone_numberLabel.AutoSize = True
		Telephone_numberLabel.Location = New System.Drawing.Point(12, 200)
		Telephone_numberLabel.Name = "Telephone_numberLabel"
		Telephone_numberLabel.Size = New System.Drawing.Size(95, 13)
		Telephone_numberLabel.TabIndex = 51
		Telephone_numberLabel.Text = "telephone number:"
		'
		'Disabled_reasonLabel
		'
		Disabled_reasonLabel.AutoSize = True
		Disabled_reasonLabel.Location = New System.Drawing.Point(387, 381)
		Disabled_reasonLabel.Name = "Disabled_reasonLabel"
		Disabled_reasonLabel.Size = New System.Drawing.Size(84, 13)
		Disabled_reasonLabel.TabIndex = 53
		Disabled_reasonLabel.Text = "disabled reason:"
		'
		'Password_confirmationLabel
		'
		Password_confirmationLabel.AutoSize = True
		Password_confirmationLabel.Location = New System.Drawing.Point(12, 148)
		Password_confirmationLabel.Name = "Password_confirmationLabel"
		Password_confirmationLabel.Size = New System.Drawing.Size(115, 13)
		Password_confirmationLabel.TabIndex = 59
		Password_confirmationLabel.Text = "password confirmation:"
		'
		'Disabled_dateLabel
		'
		Disabled_dateLabel.AutoSize = True
		Disabled_dateLabel.Location = New System.Drawing.Point(12, 382)
		Disabled_dateLabel.Name = "Disabled_dateLabel"
		Disabled_dateLabel.Size = New System.Drawing.Size(73, 13)
		Disabled_dateLabel.TabIndex = 63
		Disabled_dateLabel.Text = "disabled date:"
		'
		'Email_address_confirmationLabel
		'
		Email_address_confirmationLabel.AutoSize = True
		Email_address_confirmationLabel.Location = New System.Drawing.Point(12, 97)
		Email_address_confirmationLabel.Name = "Email_address_confirmationLabel"
		Email_address_confirmationLabel.Size = New System.Drawing.Size(134, 13)
		Email_address_confirmationLabel.TabIndex = 65
		Email_address_confirmationLabel.Text = "email address confirmation:"
		'
		'Skill_notesLabel
		'
		Skill_notesLabel.AutoSize = True
		Skill_notesLabel.Location = New System.Drawing.Point(387, 331)
		Skill_notesLabel.Name = "Skill_notesLabel"
		Skill_notesLabel.Size = New System.Drawing.Size(56, 13)
		Skill_notesLabel.TabIndex = 67
		Skill_notesLabel.Text = "skill notes:"
		'
		'UserDetails
		'
		Me.UserDetails.DataSetName = "UserDetails"
		Me.UserDetails.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'Skill_levelTextBox
		'
		Me.Skill_levelTextBox.Location = New System.Drawing.Point(150, 327)
		Me.Skill_levelTextBox.Name = "Skill_levelTextBox"
		Me.Skill_levelTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Skill_levelTextBox.TabIndex = 4
		'
		'Number_of_filesTextBox
		'
		Me.Number_of_filesTextBox.Location = New System.Drawing.Point(527, 148)
		Me.Number_of_filesTextBox.Name = "Number_of_filesTextBox"
		Me.Number_of_filesTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Number_of_filesTextBox.TabIndex = 6
		'
		'Number_of_recordsTextBox
		'
		Me.Number_of_recordsTextBox.Location = New System.Drawing.Point(527, 174)
		Me.Number_of_recordsTextBox.Name = "Number_of_recordsTextBox"
		Me.Number_of_recordsTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Number_of_recordsTextBox.TabIndex = 8
		'
		'Person_roleTextBox
		'
		Me.Person_roleTextBox.Location = New System.Drawing.Point(150, 353)
		Me.Person_roleTextBox.Name = "Person_roleTextBox"
		Me.Person_roleTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Person_roleTextBox.TabIndex = 10
		'
		'NameTextBox
		'
		Me.NameTextBox.Location = New System.Drawing.Point(150, 15)
		Me.NameTextBox.Name = "NameTextBox"
		Me.NameTextBox.Size = New System.Drawing.Size(200, 20)
		Me.NameTextBox.TabIndex = 12
		'
		'UseridTextBox
		'
		Me.UseridTextBox.Location = New System.Drawing.Point(150, 41)
		Me.UseridTextBox.Name = "UseridTextBox"
		Me.UseridTextBox.Size = New System.Drawing.Size(200, 20)
		Me.UseridTextBox.TabIndex = 14
		'
		'PasswordTextBox
		'
		Me.PasswordTextBox.Location = New System.Drawing.Point(150, 119)
		Me.PasswordTextBox.Name = "PasswordTextBox"
		Me.PasswordTextBox.Size = New System.Drawing.Size(200, 20)
		Me.PasswordTextBox.TabIndex = 16
		'
		'Email_addressTextBox
		'
		Me.Email_addressTextBox.Location = New System.Drawing.Point(150, 67)
		Me.Email_addressTextBox.Name = "Email_addressTextBox"
		Me.Email_addressTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Email_addressTextBox.TabIndex = 18
		'
		'ActiveCheckBox
		'
		Me.ActiveCheckBox.Location = New System.Drawing.Point(527, 13)
		Me.ActiveCheckBox.Name = "ActiveCheckBox"
		Me.ActiveCheckBox.Size = New System.Drawing.Size(200, 24)
		Me.ActiveCheckBox.TabIndex = 20
		Me.ActiveCheckBox.Text = "Active"
		Me.ActiveCheckBox.UseVisualStyleBackColor = True
		'
		'Fiche_readerCheckBox
		'
		Me.Fiche_readerCheckBox.Location = New System.Drawing.Point(527, 197)
		Me.Fiche_readerCheckBox.Name = "Fiche_readerCheckBox"
		Me.Fiche_readerCheckBox.Size = New System.Drawing.Size(200, 24)
		Me.Fiche_readerCheckBox.TabIndex = 24
		Me.Fiche_readerCheckBox.Text = "Fiche reader"
		Me.Fiche_readerCheckBox.UseVisualStyleBackColor = True
		'
		'AddressTextBox
		'
		Me.AddressTextBox.Location = New System.Drawing.Point(150, 171)
		Me.AddressTextBox.Name = "AddressTextBox"
		Me.AddressTextBox.Size = New System.Drawing.Size(200, 20)
		Me.AddressTextBox.TabIndex = 26
		'
		'SyndicateTextBox
		'
		Me.SyndicateTextBox.Location = New System.Drawing.Point(150, 223)
		Me.SyndicateTextBox.Name = "SyndicateTextBox"
		Me.SyndicateTextBox.Size = New System.Drawing.Size(200, 20)
		Me.SyndicateTextBox.TabIndex = 28
		'
		'Submitter_numberTextBox
		'
		Me.Submitter_numberTextBox.Location = New System.Drawing.Point(527, 66)
		Me.Submitter_numberTextBox.Name = "Submitter_numberTextBox"
		Me.Submitter_numberTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Submitter_numberTextBox.TabIndex = 30
		'
		'Previous_syndicateTextBox
		'
		Me.Previous_syndicateTextBox.Location = New System.Drawing.Point(527, 225)
		Me.Previous_syndicateTextBox.Name = "Previous_syndicateTextBox"
		Me.Previous_syndicateTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Previous_syndicateTextBox.TabIndex = 34
		'
		'DigestTextBox
		'
		Me.DigestTextBox.Location = New System.Drawing.Point(527, 250)
		Me.DigestTextBox.Name = "DigestTextBox"
		Me.DigestTextBox.Size = New System.Drawing.Size(200, 20)
		Me.DigestTextBox.TabIndex = 36
		'
		'Syndicate_groupsTextBox
		'
		Me.Syndicate_groupsTextBox.Location = New System.Drawing.Point(150, 249)
		Me.Syndicate_groupsTextBox.Name = "Syndicate_groupsTextBox"
		Me.Syndicate_groupsTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Syndicate_groupsTextBox.TabIndex = 38
		'
		'County_groupsTextBox
		'
		Me.County_groupsTextBox.Location = New System.Drawing.Point(150, 275)
		Me.County_groupsTextBox.Name = "County_groupsTextBox"
		Me.County_groupsTextBox.Size = New System.Drawing.Size(200, 20)
		Me.County_groupsTextBox.TabIndex = 40
		'
		'Country_groupsTextBox
		'
		Me.Country_groupsTextBox.Location = New System.Drawing.Point(150, 301)
		Me.Country_groupsTextBox.Name = "Country_groupsTextBox"
		Me.Country_groupsTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Country_groupsTextBox.TabIndex = 42
		'
		'Userid_lower_caseTextBox
		'
		Me.Userid_lower_caseTextBox.Location = New System.Drawing.Point(527, 40)
		Me.Userid_lower_caseTextBox.Name = "Userid_lower_caseTextBox"
		Me.Userid_lower_caseTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Userid_lower_caseTextBox.TabIndex = 48
		'
		'Telephone_numberTextBox
		'
		Me.Telephone_numberTextBox.Location = New System.Drawing.Point(150, 197)
		Me.Telephone_numberTextBox.Name = "Telephone_numberTextBox"
		Me.Telephone_numberTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Telephone_numberTextBox.TabIndex = 52
		'
		'Disabled_reasonTextBox
		'
		Me.Disabled_reasonTextBox.Location = New System.Drawing.Point(527, 378)
		Me.Disabled_reasonTextBox.Name = "Disabled_reasonTextBox"
		Me.Disabled_reasonTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Disabled_reasonTextBox.TabIndex = 54
		'
		'Technical_agreementCheckBox
		'
		Me.Technical_agreementCheckBox.Location = New System.Drawing.Point(527, 404)
		Me.Technical_agreementCheckBox.Name = "Technical_agreementCheckBox"
		Me.Technical_agreementCheckBox.Size = New System.Drawing.Size(200, 24)
		Me.Technical_agreementCheckBox.TabIndex = 56
		Me.Technical_agreementCheckBox.Text = "Technical agreeement"
		Me.Technical_agreementCheckBox.UseVisualStyleBackColor = True
		'
		'Research_agreementCheckBox
		'
		Me.Research_agreementCheckBox.Location = New System.Drawing.Point(527, 423)
		Me.Research_agreementCheckBox.Name = "Research_agreementCheckBox"
		Me.Research_agreementCheckBox.Size = New System.Drawing.Size(200, 24)
		Me.Research_agreementCheckBox.TabIndex = 58
		Me.Research_agreementCheckBox.Text = "Research agreement"
		Me.Research_agreementCheckBox.UseVisualStyleBackColor = True
		'
		'Password_confirmationTextBox
		'
		Me.Password_confirmationTextBox.Location = New System.Drawing.Point(150, 145)
		Me.Password_confirmationTextBox.Name = "Password_confirmationTextBox"
		Me.Password_confirmationTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Password_confirmationTextBox.TabIndex = 60
		'
		'Transcription_agreementCheckBox
		'
		Me.Transcription_agreementCheckBox.Location = New System.Drawing.Point(527, 444)
		Me.Transcription_agreementCheckBox.Name = "Transcription_agreementCheckBox"
		Me.Transcription_agreementCheckBox.Size = New System.Drawing.Size(200, 24)
		Me.Transcription_agreementCheckBox.TabIndex = 62
		Me.Transcription_agreementCheckBox.Text = "Transcription agreement"
		Me.Transcription_agreementCheckBox.UseVisualStyleBackColor = True
		'
		'Email_address_confirmationTextBox
		'
		Me.Email_address_confirmationTextBox.Location = New System.Drawing.Point(150, 93)
		Me.Email_address_confirmationTextBox.Name = "Email_address_confirmationTextBox"
		Me.Email_address_confirmationTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Email_address_confirmationTextBox.TabIndex = 66
		'
		'Skill_notesTextBox
		'
		Me.Skill_notesTextBox.Location = New System.Drawing.Point(527, 328)
		Me.Skill_notesTextBox.Name = "Skill_notesTextBox"
		Me.Skill_notesTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Skill_notesTextBox.TabIndex = 68
		'
		'Sign_up_dateTextBox
		'
		Me.Sign_up_dateTextBox.Location = New System.Drawing.Point(527, 96)
		Me.Sign_up_dateTextBox.Name = "Sign_up_dateTextBox"
		Me.Sign_up_dateTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Sign_up_dateTextBox.TabIndex = 70
		'
		'Last_uploadTextBox
		'
		Me.Last_uploadTextBox.Location = New System.Drawing.Point(527, 122)
		Me.Last_uploadTextBox.Name = "Last_uploadTextBox"
		Me.Last_uploadTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Last_uploadTextBox.TabIndex = 71
		'
		'U_atTextBox
		'
		Me.U_atTextBox.Location = New System.Drawing.Point(527, 276)
		Me.U_atTextBox.Name = "U_atTextBox"
		Me.U_atTextBox.Size = New System.Drawing.Size(200, 20)
		Me.U_atTextBox.TabIndex = 72
		'
		'C_atTextBox
		'
		Me.C_atTextBox.Location = New System.Drawing.Point(527, 301)
		Me.C_atTextBox.Name = "C_atTextBox"
		Me.C_atTextBox.Size = New System.Drawing.Size(200, 20)
		Me.C_atTextBox.TabIndex = 73
		'
		'Disabled_dateTextBox
		'
		Me.Disabled_dateTextBox.Location = New System.Drawing.Point(150, 379)
		Me.Disabled_dateTextBox.Name = "Disabled_dateTextBox"
		Me.Disabled_dateTextBox.Size = New System.Drawing.Size(200, 20)
		Me.Disabled_dateTextBox.TabIndex = 74
		'
		'btnRefresh
		'
		Me.btnRefresh.Location = New System.Drawing.Point(15, 444)
		Me.btnRefresh.Name = "btnRefresh"
		Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
		Me.btnRefresh.TabIndex = 75
		Me.btnRefresh.Text = "Refresh"
		Me.btnRefresh.UseVisualStyleBackColor = True
		'
		'formUserDetails
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(786, 489)
		Me.Controls.Add(Me.btnRefresh)
		Me.Controls.Add(Me.Disabled_dateTextBox)
		Me.Controls.Add(Me.C_atTextBox)
		Me.Controls.Add(Me.U_atTextBox)
		Me.Controls.Add(Me.Last_uploadTextBox)
		Me.Controls.Add(Me.Sign_up_dateTextBox)
		Me.Controls.Add(Skill_levelLabel)
		Me.Controls.Add(Me.Skill_levelTextBox)
		Me.Controls.Add(Number_of_filesLabel)
		Me.Controls.Add(Me.Number_of_filesTextBox)
		Me.Controls.Add(Number_of_recordsLabel)
		Me.Controls.Add(Me.Number_of_recordsTextBox)
		Me.Controls.Add(Person_roleLabel)
		Me.Controls.Add(Me.Person_roleTextBox)
		Me.Controls.Add(Person_surnameLabel)
		Me.Controls.Add(Me.NameTextBox)
		Me.Controls.Add(UseridLabel)
		Me.Controls.Add(Me.UseridTextBox)
		Me.Controls.Add(PasswordLabel)
		Me.Controls.Add(Me.PasswordTextBox)
		Me.Controls.Add(Email_addressLabel)
		Me.Controls.Add(Me.Email_addressTextBox)
		Me.Controls.Add(Me.ActiveCheckBox)
		Me.Controls.Add(Me.Fiche_readerCheckBox)
		Me.Controls.Add(AddressLabel)
		Me.Controls.Add(Me.AddressTextBox)
		Me.Controls.Add(SyndicateLabel)
		Me.Controls.Add(Me.SyndicateTextBox)
		Me.Controls.Add(Submitter_numberLabel)
		Me.Controls.Add(Me.Submitter_numberTextBox)
		Me.Controls.Add(Sign_up_dateLabel)
		Me.Controls.Add(Previous_syndicateLabel)
		Me.Controls.Add(Me.Previous_syndicateTextBox)
		Me.Controls.Add(DigestLabel)
		Me.Controls.Add(Me.DigestTextBox)
		Me.Controls.Add(Syndicate_groupsLabel)
		Me.Controls.Add(Me.Syndicate_groupsTextBox)
		Me.Controls.Add(County_groupsLabel)
		Me.Controls.Add(Me.County_groupsTextBox)
		Me.Controls.Add(Country_groupsLabel)
		Me.Controls.Add(Me.Country_groupsTextBox)
		Me.Controls.Add(U_atLabel)
		Me.Controls.Add(C_atLabel)
		Me.Controls.Add(Userid_lower_caseLabel)
		Me.Controls.Add(Me.Userid_lower_caseTextBox)
		Me.Controls.Add(Last_uploadLabel)
		Me.Controls.Add(Telephone_numberLabel)
		Me.Controls.Add(Me.Telephone_numberTextBox)
		Me.Controls.Add(Disabled_reasonLabel)
		Me.Controls.Add(Me.Disabled_reasonTextBox)
		Me.Controls.Add(Me.Technical_agreementCheckBox)
		Me.Controls.Add(Me.Research_agreementCheckBox)
		Me.Controls.Add(Password_confirmationLabel)
		Me.Controls.Add(Me.Password_confirmationTextBox)
		Me.Controls.Add(Me.Transcription_agreementCheckBox)
		Me.Controls.Add(Disabled_dateLabel)
		Me.Controls.Add(Email_address_confirmationLabel)
		Me.Controls.Add(Me.Email_address_confirmationTextBox)
		Me.Controls.Add(Skill_notesLabel)
		Me.Controls.Add(Me.Skill_notesTextBox)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "formUserDetails"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "User Profile"
		CType(Me.UserDetails, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents UserDetails As WinREG.UserDetails
	Friend WithEvents Skill_levelTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Number_of_filesTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Number_of_recordsTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Person_roleTextBox As System.Windows.Forms.TextBox
	Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
	Friend WithEvents UseridTextBox As System.Windows.Forms.TextBox
	Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Email_addressTextBox As System.Windows.Forms.TextBox
	Friend WithEvents ActiveCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents Fiche_readerCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents AddressTextBox As System.Windows.Forms.TextBox
	Friend WithEvents SyndicateTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Submitter_numberTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Previous_syndicateTextBox As System.Windows.Forms.TextBox
	Friend WithEvents DigestTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Syndicate_groupsTextBox As System.Windows.Forms.TextBox
	Friend WithEvents County_groupsTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Country_groupsTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Userid_lower_caseTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Telephone_numberTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Disabled_reasonTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Technical_agreementCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents Research_agreementCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents Password_confirmationTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Transcription_agreementCheckBox As System.Windows.Forms.CheckBox
	Friend WithEvents Email_address_confirmationTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Skill_notesTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Sign_up_dateTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Last_uploadTextBox As System.Windows.Forms.TextBox
	Friend WithEvents U_atTextBox As System.Windows.Forms.TextBox
	Friend WithEvents C_atTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Disabled_dateTextBox As System.Windows.Forms.TextBox
	Friend WithEvents btnRefresh As System.Windows.Forms.Button
End Class
