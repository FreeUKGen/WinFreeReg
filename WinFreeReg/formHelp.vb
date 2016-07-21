Imports System.Windows.Forms
Imports System.IO

Public Class formHelp

   Private AppDataLocalFolder = String.Format("{0}\{1}\doc", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName)

   Private m_Title As String
   Public Property Title() As String
      Get
         Return m_Title
      End Get
      Set(ByVal value As String)
         m_Title = value
      End Set
   End Property

   Private m_StartPageName As String
   Public Property StartPage() As String
      Get
         Return m_StartPageName
      End Get
      Set(ByVal value As String)
         m_StartPageName = value
      End Set
   End Property

   Private m_StartPagePath As String

   Private Sub formHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
   End Sub

   Private Sub formHelp_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
      If [String].IsNullOrEmpty(m_StartPageName) Then Throw New ArgumentException(My.Resources.msgHelpPageError, "Pagename")
      m_StartPagePath = Path.Combine(AppDataLocalFolder, m_StartPageName)
      If Not File.Exists(m_StartPagePath) Then Throw New FileNotFoundException(My.Resources.msgHelpFileNotFound, m_StartPagePath)

      Try
         Text = String.Format(Me.Text, m_Title)
         wbPage.Navigate(m_StartPagePath)

      Catch ex As Exception
         Beep()

      End Try
   End Sub

   Private Sub wbPage_CanGoBackChanged(ByVal sender As Object, ByVal e As EventArgs) Handles wbPage.CanGoBackChanged
      ToolStripButton4.Enabled = wbPage.CanGoBack
   End Sub

   Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
      wbPage.GoBack()
   End Sub

   Private Sub wbPage_CanGoForwardChanged(ByVal sender As Object, ByVal e As EventArgs) Handles wbPage.CanGoForwardChanged
      ToolStripButton5.Enabled = wbPage.CanGoForward
   End Sub

   Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
      wbPage.GoForward()
   End Sub
End Class