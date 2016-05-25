Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class formStartUp

   Private Sub formStartUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      If My.Settings.MyTranscriptionLibrary = String.Empty Then
         My.Settings.MyTranscriptionLibrary = String.Format("{0}\FreeREG\WinREG for Windows\Transcripts", My.Computer.FileSystem.SpecialDirectories.MyDocuments)
      End If
      UsernameTextBox.Text = My.Settings.MyUserName
      PasswordTextBox.Text = My.Settings.MyPassword
      LibraryTextBox.Text = My.Settings.MyTranscriptionLibrary

      buttonStart.Enabled = UsernameTextBox.Text <> String.Empty AndAlso PasswordTextBox.Text <> String.Empty AndAlso ValidTranscriptionFolder(LibraryTextBox.Text)
   End Sub

   Private Sub UsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles UsernameTextBox.TextChanged
      buttonStart.Enabled = UsernameTextBox.Text <> String.Empty AndAlso PasswordTextBox.Text <> String.Empty AndAlso ValidTranscriptionFolder(LibraryTextBox.Text)
   End Sub

   Private Sub PasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles PasswordTextBox.TextChanged
      buttonStart.Enabled = UsernameTextBox.Text <> String.Empty AndAlso PasswordTextBox.Text <> String.Empty AndAlso ValidTranscriptionFolder(LibraryTextBox.Text)
   End Sub

   Private Sub LibraryTextBox_TextChanged(sender As Object, e As EventArgs) Handles LibraryTextBox.TextChanged
      buttonStart.Enabled = UsernameTextBox.Text <> String.Empty AndAlso PasswordTextBox.Text <> String.Empty AndAlso ValidTranscriptionFolder(LibraryTextBox.Text)
   End Sub

   Private Sub buttonStart_Click(sender As Object, e As EventArgs) Handles buttonStart.Click
      Using frm As New FreeREG2Browser() With {.Username = UsernameTextBox.Text, .Password = PasswordTextBox.Text}
         Me.Hide()
         frm.ShowDialog()
         Me.Show()
         UsernameTextBox.Text = frm.Username
         PasswordTextBox.Text = frm.Password
      End Using
   End Sub

   Private Sub formStartUp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
      My.Settings.MyPassword = PasswordTextBox.Text
      My.Settings.MyUserName = UsernameTextBox.Text
   End Sub

   Private Function ValidTranscriptionFolder(ByVal strFolder As String) As Boolean
      Dim result As Boolean = False
      If LibraryTextBox.Text <> String.Empty Then
         result = Directory.Exists(strFolder)
      End If
      Return result
   End Function
End Class
