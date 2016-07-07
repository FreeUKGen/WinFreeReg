Imports System.IO
Imports System.Windows.Forms

Public Class formLogin

   ' TODO: Insert code to perform custom authentication using the provided username and password 
   ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
   ' The custom principal can then be attached to the current thread's principal as follows: 
   '     My.User.CurrentPrincipal = CustomPrincipal
   ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
   ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
   ' such as the username, display name, etc.

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
