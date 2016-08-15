Imports System.Windows.Forms

Public Class dlgCorrectTableError

   Private formHelp As formGeneralHelp = Nothing
   Sub New(HelpForm As formGeneralHelp)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      formHelp = HelpForm
   End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

   Private Sub dlgCorrectTableError_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
      Try
         formHelp.Title = "Correct Table Error"
         formHelp.StartPage = "CorrectTableError.html"
         formHelp.Show()

      Catch ex As Exception
         formHelp.Hide()
         MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try

   End Sub
End Class
