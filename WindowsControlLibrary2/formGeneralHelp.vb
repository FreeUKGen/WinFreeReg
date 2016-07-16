Imports System.Windows.Forms
Imports System.IO

Public Class formGeneralHelp

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

   Private Sub formGeneralHelp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      Visible = False
      e.Cancel = True
   End Sub

   Private Sub formGeneralHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
End Class