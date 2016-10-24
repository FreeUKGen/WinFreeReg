Imports System.IO
Imports System.Windows.Forms

Public Class formLogin

   Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
      Me.Close()
   End Sub

   Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
      Me.Close()
   End Sub

   Private Sub formLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Dim StartToolTip = New CustomToolTip(Path.Combine(String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName), "ToolTips.xml"), Me)
   End Sub
End Class
