Imports System.IO
Imports WinFreeReg

Public Class frmTestBrowser

   Private AppDataLocalFolder = "C:\Users\User\Documents\Visual Studio 2012\Projects\WinFreeReg\FreeREG2Browser\Other Files"

   Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
      Using frm As New FreeREG2Browser()
         frm.ShowDialog()
      End Using
   End Sub

   Private Sub frmTestBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   End Sub

   Private Sub btnErrorMessages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnErrorMessages.Click
      Try
         Dim ErrorMEssageFileName As String = Path.Combine(AppDataLocalFolder, "ErrorMessages.xml")

         Using dlg As New dlgErrorMessage(ErrorMEssageFileName)
            dlg.ShowDialog()
         End Using

      Catch ex As ArgumentNullException

      Catch ex As Exception

      End Try
   End Sub

   Private Sub btnToolTips_Click(sender As Object, e As EventArgs) Handles btnToolTips.Click
      Try
         Dim ToolTipsFileName As String = Path.Combine(AppDataLocalFolder, "ToolTips.xml")

         Using dlg As New dlgToolTips(ToolTipsFileName)
            dlg.ShowDialog()
         End Using

      Catch ex As ArgumentNullException

      Catch ex As Exception

      End Try
   End Sub
End Class
