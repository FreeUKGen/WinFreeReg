Public Class formUserDetails

	Private _record As UserDetails.UserRow

	Public Property RecordToShow() As UserDetails.UserRow
		Get
			Return _record
		End Get
		Set(ByVal value As UserDetails.UserRow)
			_record = value
		End Set
	End Property

	Private m_Owner As FreeREG2Browser
	Public Property MyOwner() As FreeREG2Browser
		Get
			Return m_Owner
		End Get
		Set(ByVal value As FreeREG2Browser)
			m_Owner = value
		End Set
	End Property

	Private Sub formUserDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		If _record Is Nothing Then
		Else
			FillFormFields()
		End If
	End Sub

	Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
      MyOwner.RefreshTranscriber()
		FillFormFields()
	End Sub

	Private Sub FillFormFields()
		NameTextBox.Text = _record("person_forename") + " " + _record("person_surname")
		Skill_levelTextBox.Text = _record("skill_level")
		Number_of_filesTextBox.Text = _record("number_of_files")
		Number_of_recordsTextBox.Text = _record("number_of_records")
		Person_roleTextBox.Text = _record("person_role")
		UseridTextBox.Text = _record("userid")
		PasswordTextBox.Text = _record("password")
		Email_addressTextBox.Text = _record("email_address")
		Disabled_dateTextBox.Text = _record("disabled_date").ToString
		Disabled_reasonTextBox.Text = _record("disabled_reason")
		AddressTextBox.Text = _record("address")
		Telephone_numberTextBox.Text = _record("telephone_number")
		SyndicateTextBox.Text = _record("syndicate")
		Submitter_numberTextBox.Text = _record("submitter_number")
		Previous_syndicateTextBox.Text = _record("previous_syndicate")
		DigestTextBox.Text = _record("digest")
		Syndicate_groupsTextBox.Text = _record("syndicate_groups")
		County_groupsTextBox.Text = _record("county_groups")
		Country_groupsTextBox.Text = _record("country_groups")
		Userid_lower_caseTextBox.Text = _record("userid_lower_case")
		ActiveCheckBox.Checked = _record("active")
		Fiche_readerCheckBox.Checked = _record("fiche_reader")
		Sign_up_dateTextBox.Text = _record("sign_up_date").ToString
		U_atTextBox.Text = _record("u_at").ToString
		C_atTextBox.Text = _record("c_at").ToString
		Last_uploadTextBox.Text = _record("last_upload").ToString
		Technical_agreementCheckBox.Checked = _record("technical_agreement")
		Research_agreementCheckBox.Checked = _record("research_agreement")
		Transcription_agreementCheckBox.Checked = _record("transcription_agreement")
		Password_confirmationTextBox.Text = _record("password_confirmation")
	End Sub
End Class