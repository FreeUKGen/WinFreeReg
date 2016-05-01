Imports System.IO
Imports WinFreeReg

Public Class frmTestBrowser


   Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

      Using frm As New FreeREG2Browser()
         frm.ShowDialog()
      End Using

   End Sub

   Private Sub frmTestBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   End Sub

   Private Sub btnErrorMessages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnErrorMessages.Click
      Try
         Dim BaseDataDirectory = String.Format("{0}\{1}\{2}", My.Computer.FileSystem.SpecialDirectories.MyDocuments, Application.CompanyName, Application.ProductName)
         Dim ErrorMEssageFileName As String = Path.Combine(BaseDataDirectory, "ErrorMessages.xml")

         Using dlg As New dlgErrorMessage(ErrorMEssageFileName)
            dlg.ShowDialog()
         End Using

      Catch ex As ArgumentNullException

      Catch ex As Exception

      End Try
   End Sub
End Class
