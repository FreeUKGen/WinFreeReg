Imports System.IO
Imports System.Windows.Forms

Public Class formUserDetails

   Private ThisUser As UserDetails.UserRow
   Private _userid As String
   Public Property RecordToShow() As String
      Get
         Return _userid
      End Get
      Set(ByVal value As String)
         _userid = value
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

   Private formHelp As formGeneralHelp = Nothing
   Public Sub New(ByVal helpForm As formGeneralHelp)
      InitializeComponent()

      formHelp = helpForm
   End Sub

   Property UserDataSet As UserDetails

   Private Sub formUserDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim AppDataLocalFolder = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName)
      Dim ToolTipsFile As String = Path.Combine(AppDataLocalFolder, "ToolTips.xml")
      Dim MyToolTips = New CustomToolTip(ToolTipsFile, Me)
      If _userid Is Nothing Then
      Else
         ThisUser = UserDataSet.User.FindByuserid(_userid)
         FillFormFields(ThisUser)
      End If
   End Sub

   Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
      MyOwner.RefreshTranscriber()
      ThisUser = UserDataSet.User.FindByuserid(_userid)
      FillFormFields(ThisUser)
   End Sub

   Private Sub FillFormFields(ThisUser As UserDetails.UserRow)
      If ThisUser IsNot Nothing Then
         NameTextBox.Text = ThisUser.person_forename + " " + ThisUser.person_surname
         Skill_levelTextBox.Text = ThisUser.skill_level
         Number_of_filesTextBox.Text = ThisUser.number_of_files
         Number_of_recordsTextBox.Text = ThisUser.number_of_records
         Person_roleTextBox.Text = ThisUser.person_role
         UseridTextBox.Text = ThisUser.userid
         PasswordTextBox.Text = ThisUser.password
         Email_addressTextBox.Text = ThisUser.email_address
         If Not ThisUser.Isdisabled_dateNull Then Disabled_dateTextBox.Text = ThisUser.disabled_date.ToString("F")
         Disabled_reasonTextBox.Text = ThisUser.disabled_reason
         AddressTextBox.Text = ThisUser.address
         Telephone_numberTextBox.Text = ThisUser.telephone_number
         SyndicateTextBox.Text = ThisUser.syndicate
         Submitter_numberTextBox.Text = ThisUser.submitter_number
         Previous_syndicateTextBox.Text = ThisUser.previous_syndicate
         DigestTextBox.Text = ThisUser.digest
         Syndicate_groupsTextBox.Text = ThisUser.syndicate_groups
         County_groupsTextBox.Text = ThisUser.county_groups
         Country_groupsTextBox.Text = ThisUser.country_groups
         Userid_lower_caseTextBox.Text = ThisUser.userid_lower_case
         ActiveCheckBox.Checked = ThisUser.active
         Fiche_readerCheckBox.Checked = ThisUser.fiche_reader
         If Not ThisUser.Issign_up_dateNull Then Sign_up_dateTextBox.Text = ThisUser.sign_up_date.ToString("F")
         If Not ThisUser.Isu_atNull Then U_atTextBox.Text = ThisUser.u_at.ToString("F")
         If Not ThisUser.Isc_atNull Then C_atTextBox.Text = ThisUser.c_at.ToString("F")
         If Not ThisUser.Islast_uploadNull Then Last_uploadTextBox.Text = ThisUser.last_upload.ToString("F")
         Technical_agreementCheckBox.Checked = ThisUser.technical_agreement
         Research_agreementCheckBox.Checked = ThisUser.research_agreement
         Transcription_agreementCheckBox.Checked = ThisUser.transcription_agreement
         Password_confirmationTextBox.Text = ThisUser.password_confirmation
      End If
   End Sub


   Private Sub formUserDetails_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles MyBase.HelpRequested
      Try
         formHelp.Title = "FreeREG Browser"
         formHelp.StartPage = "UserDetails.html"
         formHelp.Show()

      Catch ex As Exception
         formHelp.Hide()
         MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try
   End Sub

   Private Sub formUserDetails_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
      Try
         formHelp.Title = "FreeREG Browser"
         formHelp.StartPage = "UserDetails.html"
         formHelp.Show()

      Catch ex As Exception
         formHelp.Hide()
         MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try
   End Sub

End Class
