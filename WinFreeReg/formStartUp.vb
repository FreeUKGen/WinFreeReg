Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Configuration
Imports System.IO
Imports WinFreeReg
Imports System.Text

Public Class formStartUp

   Private AppDataLocalFolder = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName)
   Private PgmAppDataLocalFolder As String = AppDataLocalFolder

   Public TranscriberProfileFile As String
   Public SettingsFileName As String = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath

   Dim UserDataSet As UserDetails = New UserDetails()
   Private formHelp As New formHelp() With {.Visible = False}
   Private currentTranscriber As WinFreeReg.UserDetails.UserRow = Nothing

   Private Sub formStartUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      My.Settings.Upgrade()

      If String.IsNullOrEmpty(My.Settings.MyFreeREGUrl) Then
#If DEBUG Then
#If LOCAL Then
         My.Settings.MyFreeREGUrl = My.Settings.MyLocalUrl
#Else
         My.Settings.MyFreeREGUrl = My.Settings.MyTestUrl
#End If
#Else
         My.Settings.MyFreeREGUrl = My.Settings.MyLiveUrl
#End If
      End If

      If My.Settings.MyFreeREGUrl = My.Settings.MyTestUrl Then
         PgmAppDataLocalFolder = Path.Combine(AppDataLocalFolder, "test")
         If Not Directory.Exists(PgmAppDataLocalFolder) Then
            Directory.CreateDirectory(PgmAppDataLocalFolder)
         End If
      End If

      TranscriberProfileFile = Path.Combine(AppDataLocalFolder, "transcriber.xml")

      Dim StartToolTip = New CustomToolTip(Path.Combine(AppDataLocalFolder, "ToolTips.xml"), Me)

      If String.IsNullOrEmpty(My.Settings.MyTranscriptionLibrary) Then
         My.Settings.MyTranscriptionLibrary = String.Format("{0}\FreeREG\WinREG for Windows\Transcripts", Environment.GetFolderPath(Environment.SpecialFolder.Personal))
      End If

      If File.Exists(TranscriberProfileFile) Then
         UserDataSet.ReadXml(TranscriberProfileFile, XmlReadMode.ReadSchema)
         UserDataSet.AcceptChanges()
         currentTranscriber = UserDataSet.User.FindByuserid(My.Settings.MyUserId)
      End If

      If currentTranscriber IsNot Nothing Then
         UserIdTextBox.Text = currentTranscriber.userid
         PasswordTextBox.Text = currentTranscriber.PasswordInClear
         UrlTextBox.Text = currentTranscriber.Url
         LibraryTextBox.Text = currentTranscriber.DefaultFolder
         If UserDataSet.User.Count > 1 Then
            Dim sourceUserIds As New AutoCompleteStringCollection()
            Dim users = From user As WinFreeReg.UserDetails.UserRow In UserDataSet.User.Rows _
             Select user
            For Each user In users
               sourceUserIds.Add(user.userid)
            Next
            With UserIdTextBox
               .AutoCompleteMode = AutoCompleteMode.SuggestAppend
               .AutoCompleteSource = AutoCompleteSource.CustomSource
               .AutoCompleteCustomSource = sourceUserIds
            End With
         End If
      Else
         UserIdTextBox.Text = My.Settings.MyUserId
         PasswordTextBox.Text = My.Settings.MyPassword
         UrlTextBox.Text = My.Settings.MyFreeREGUrl
         LibraryTextBox.Text = My.Settings.MyTranscriptionLibrary
      End If

      UserNameTextBox.Text = My.Settings.MyUserName
      EmailAddressTextBox.Text = My.Settings.MyEmailAddress
      TraceCheckBox.Checked = My.Settings.MyNetworkTrace
      linkPassword.Tag = True

      UserLookupTables.LoadXmlData(Path.Combine(AppDataLocalFolder, "winfreereg.tables"))
      DefaultCountyComboBox.DataSource = UserLookupTables.Tables("ChapmanCodes").DefaultView
      DefaultCountyComboBox.DisplayMember = "Code"
      DefaultCountyComboBox.BindingContext = Me.BindingContext
      If Not String.IsNullOrEmpty(My.Settings.MyDefaultCounty) Then DefaultCountyComboBox.SelectedIndex = DefaultCountyComboBox.FindString(My.Settings.MyDefaultCounty)

      buttonStart.Enabled = UserNameTextBox.Text <> String.Empty AndAlso IsValidEmailAddress(EmailAddressTextBox.Text) AndAlso UserIdTextBox.Text <> String.Empty AndAlso PasswordTextBox.Text <> String.Empty AndAlso IsValidTranscriptionFolder(LibraryTextBox.Text)
   End Sub

   Private Sub UserNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles UserNameTextBox.TextChanged
      buttonStart.Enabled = UserNameTextBox.Text <> String.Empty AndAlso IsValidEmailAddress(EmailAddressTextBox.Text) AndAlso UserIdTextBox.Text <> String.Empty AndAlso PasswordTextBox.Text <> String.Empty AndAlso IsValidTranscriptionFolder(LibraryTextBox.Text)
   End Sub

   Private Sub EmailAddressTextBox_TextChanged(sender As Object, e As EventArgs) Handles EmailAddressTextBox.TextChanged
      buttonStart.Enabled = UserNameTextBox.Text <> String.Empty AndAlso IsValidEmailAddress(EmailAddressTextBox.Text) AndAlso UserIdTextBox.Text <> String.Empty AndAlso PasswordTextBox.Text <> String.Empty AndAlso IsValidTranscriptionFolder(LibraryTextBox.Text)
   End Sub

   Private Sub UserIdTextBox_TextChanged(sender As Object, e As EventArgs) Handles UserIdTextBox.TextChanged
      buttonStart.Enabled = UserNameTextBox.Text <> String.Empty AndAlso IsValidEmailAddress(EmailAddressTextBox.Text) AndAlso UserIdTextBox.Text <> String.Empty AndAlso PasswordTextBox.Text <> String.Empty AndAlso IsValidTranscriptionFolder(LibraryTextBox.Text)
   End Sub

   Private Sub PasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles PasswordTextBox.TextChanged
      buttonStart.Enabled = UserNameTextBox.Text <> String.Empty AndAlso IsValidEmailAddress(EmailAddressTextBox.Text) AndAlso UserIdTextBox.Text <> String.Empty AndAlso PasswordTextBox.Text <> String.Empty AndAlso IsValidTranscriptionFolder(LibraryTextBox.Text)
   End Sub

   Private Sub LibraryTextBox_TextChanged(sender As Object, e As EventArgs) Handles LibraryTextBox.TextChanged
      buttonStart.Enabled = UserNameTextBox.Text <> String.Empty AndAlso IsValidEmailAddress(EmailAddressTextBox.Text) AndAlso UserIdTextBox.Text <> String.Empty AndAlso PasswordTextBox.Text <> String.Empty AndAlso IsValidTranscriptionFolder(LibraryTextBox.Text)
   End Sub

   Private Sub buttonStart_Click(sender As Object, e As EventArgs) Handles buttonStart.Click
      Dim r = Me.Validate()
      Using frm As New FreeREG2Browser() With {.UserName = UserNameTextBox.Text, .EmailAddress = EmailAddressTextBox.Text, .UserId = UserIdTextBox.Text, _
                                               .Password = PasswordTextBox.Text, .FreeregUrl = UrlTextBox.Text, .DefaultCounty = DefaultCountyComboBox.SelectedItem.Row, _
                                               .TranscriptionLibrary = LibraryTextBox.Text, .TraceNetwork = TraceCheckBox.Checked}
         Me.Hide()
         frm.ShowDialog()
         UserIdTextBox.Text = frm.UserId
         PasswordTextBox.Text = frm.Password
         UrlTextBox.Text = frm.FreeregUrl
         TraceCheckBox.Checked = frm.TraceNetwork

         UserDataSet.Clear()
         UserDataSet.ReadXml(TranscriberProfileFile, XmlReadMode.ReadSchema)
         currentTranscriber = UserDataSet.User.FindByuserid(UserIdTextBox.Text)
         If currentTranscriber IsNot Nothing Then
            currentTranscriber.PasswordInClear = frm.Password
            currentTranscriber.DefaultFolder = LibraryTextBox.Text
            currentTranscriber.Url = frm.FreeregUrl
         End If
         UserDataSet.AcceptChanges()
         UserDataSet.WriteXml(TranscriberProfileFile, XmlWriteMode.WriteSchema)

         Dim users = From user As WinFreeReg.UserDetails.UserRow In UserDataSet.User.Rows _
          Select user

         If users.Count > 1 Then
            Dim sourceUserIds As New AutoCompleteStringCollection()
            For Each user In users
               sourceUserIds.Add(user.userid)
            Next
            UserIdTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
            UserIdTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            UserIdTextBox.AutoCompleteCustomSource = sourceUserIds
         Else
            UserIdTextBox.AutoCompleteMode = AutoCompleteMode.None
         End If

         If Not KeepOpenCheckBox.Checked Then Me.Close() Else Me.Show()
      End Using
   End Sub

   Private Sub formStartUp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
      My.Settings.MyUserName = UserNameTextBox.Text
      My.Settings.MyEmailAddress = EmailAddressTextBox.Text
      My.Settings.MyPassword = PasswordTextBox.Text
      My.Settings.MyUserId = UserIdTextBox.Text
      My.Settings.MyTranscriptionLibrary = LibraryTextBox.Text
      My.Settings.MyFreeREGUrl = UrlTextBox.Text
      My.Settings.MyDefaultCounty = CType(CType(DefaultCountyComboBox.SelectedItem, DataRowView).Row, WinFreeReg.LookupTables.ChapmanCodesRow).Code
      My.Settings.MyNetworkTrace = TraceCheckBox.Checked

      If UserDataSet.HasChanges Then
         UserDataSet.AcceptChanges()
         UserDataSet.WriteXml(TranscriberProfileFile, XmlWriteMode.WriteSchema)
      End If
   End Sub

   Private Function IsValidEmailAddress(ByVal strEmailAddress As String) As Boolean
      Dim result As Boolean = False
      Dim util As New RegexUtilities()
      If Not String.IsNullOrEmpty(strEmailAddress) Then result = util.IsValidEmail(strEmailAddress)
      Return result
   End Function

   Private Function IsValidTranscriptionFolder(ByVal strFolder As String) As Boolean
      Dim result As Boolean = False
      If Not String.IsNullOrEmpty(strFolder) Then result = Directory.Exists(strFolder)
      Return result
   End Function

   Private Function IsValidUrl(ByVal strURI As String) As Boolean
      Return Uri.IsWellFormedUriString(strURI, UriKind.Absolute)
   End Function

   Private Sub linkBrowse_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkBrowse.LinkClicked
      dlgTranscriptionFolderBrowser.Description = "Select the folder in which you store, or want to store, your Transcription Files"
      dlgTranscriptionFolderBrowser.ShowNewFolderButton = False

      If Not String.IsNullOrEmpty(LibraryTextBox.Text) Then
         dlgTranscriptionFolderBrowser.Description = String.Format("Select the folder in which you store, or want to store, your Transcription Files. It is presently set as {0}", LibraryTextBox.Text)
         dlgTranscriptionFolderBrowser.SelectedPath = LibraryTextBox.Text
      End If

      Dim result = dlgTranscriptionFolderBrowser.ShowDialog()
      If result = Windows.Forms.DialogResult.OK Then
         LibraryTextBox.Text = dlgTranscriptionFolderBrowser.SelectedPath
      End If
   End Sub

   Private Sub UrlTextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles UrlTextBox.Validating
      If IsValidUrl(UrlTextBox.Text) Then
         urlErrorProvider.SetError(UrlTextBox, "")
      Else
         urlErrorProvider.SetError(UrlTextBox, "Invalid URL")
         e.Cancel = True
      End If
   End Sub

   Private Sub LibraryTextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles LibraryTextBox.Validating
      If IsValidTranscriptionFolder(LibraryTextBox.Text) Then
         libraryErrorProvider.SetError(LibraryTextBox, "")
      Else
         libraryErrorProvider.SetError(LibraryTextBox, "Transcriptions folder does not exist")
      End If
   End Sub

   Private Sub DefaultCountyComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) Handles DefaultCountyComboBox.DrawItem
      e.DrawBackground()
      If e.State = DrawItemState.Focus Then
         e.DrawFocusRectangle()
      End If
      Dim x = DefaultCountyComboBox.Items(e.Index)
      Dim r = x.Row
      Dim s = String.Format("{0} - {1}", r.Code, r.County)
      e.Graphics.DrawString(s, e.Font, Brushes.Black, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
   End Sub

   Private Sub linkPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkPassword.LinkClicked
      If TypeOf linkPassword.Tag Is Boolean Then
         If linkPassword.Tag Then
            PasswordTextBox.PasswordChar = ""
            linkPassword.Text = "Hide password"
            linkPassword.Tag = False
         Else
            PasswordTextBox.PasswordChar = "*"
            linkPassword.Text = "Show password"
            linkPassword.Tag = True
         End If
      End If
   End Sub

   Private Sub formStartUp_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
      Try
         formHelp.Title = "FreeREG StartUp"
         formHelp.StartPage = "StartUp.html"
         formHelp.ShowDialog()
         e.Cancel = True

      Catch ex As Exception
         formHelp.Hide()
         MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try
   End Sub

   Private Sub UserIdTextBox_Validated(sender As Object, e As EventArgs) Handles UserIdTextBox.Validated
      currentTranscriber = UserDataSet.User.FindByuserid(UserIdTextBox.Text)
      If currentTranscriber IsNot Nothing Then
         PasswordTextBox.Text = currentTranscriber.PasswordInClear
         UrlTextBox.Text = currentTranscriber.Url
         LibraryTextBox.Text = currentTranscriber.DefaultFolder
      End If
   End Sub
End Class
