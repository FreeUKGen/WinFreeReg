Imports System.Drawing
Imports System.Windows.Forms
Imports WinFreeReg.TranscriptionFileClass
Imports System.IO

Public Class formFileDetails

   Private m_TranscriptionFile As TranscriptionFileClass
   Public Property TranscriptionFile() As TranscriptionFileClass
      Get
         Return m_TranscriptionFile
      End Get
      Set(ByVal value As TranscriptionFileClass)
         m_TranscriptionFile = value
      End Set
   End Property

   Private m_HeaderChanged As Boolean
   Public ReadOnly Property HeaderChanged() As Boolean
      Get
         Return m_HeaderChanged
      End Get
   End Property

   Private Sub formFileDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      FileHeaderClassBindingSource.DataSource = m_TranscriptionFile.FileHeader
      m_HeaderChanged = False
      Dim title = String.Format(Me.Text, m_TranscriptionFile.FileName)
      Me.Text = title

      CountiesBindingSource.DataSource = m_TranscriptionFile.FreeregTables
      PlacesBindingSource.DataSource = m_TranscriptionFile.FreeregTables
      ChurchesBindingSource.DataSource = m_TranscriptionFile.FreeregTables
      RegisterTypesBindingSource.DataSource = m_TranscriptionFile.FreeregTables
      FileTypesBindingSource.DataSource = m_TranscriptionFile.LookupTables

      Dim AppDataLocalFolder = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName)
      Dim ToolTipsFile As String = Path.Combine(AppDataLocalFolder, "ToolTips.xml")
      Dim MyToolTips = New CustomToolTip(ToolTipsFile, Me)
   End Sub

   Private Sub LinkLabel1_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
      If LinkLabel1.Tag.ToString = "False" Then
         Me.Size = New Drawing.Size With {.Width = Me.Width, .Height = 524}
         LinkLabel1.Text = "<--Less"
         LinkLabel1.Tag = "True"
      Else
         Me.Size = New Drawing.Size With {.Width = Me.Width, .Height = 324}
         LinkLabel1.Text = "More-->"
         LinkLabel1.Tag = "False"
      End If
   End Sub

   Private Sub formFileDetails_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
   End Sub

   Private Sub formFileDetails_FormClosed(sender As Object, e As Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
      DialogResult = Windows.Forms.DialogResult.OK
      m_TranscriptionFile.FileHeader.Place = PlaceComboBox.SelectedValue
      m_TranscriptionFile.FileHeader.Church = ChurchComboBox.SelectedValue
      m_TranscriptionFile.FileHeader.RegisterType = RegisterTypeComboBox.SelectedValue
      m_TranscriptionFile.FileHeader.isLDS = IsLDSCheckBox.Checked
      m_TranscriptionFile.FileHeader.CreditName = CreditNameTextBox.Text
      m_TranscriptionFile.FileHeader.CreditEmail = CreditEmailTextBox.Text
      m_TranscriptionFile.FileHeader.Comment1 = Comment1TextBox.Text
      m_TranscriptionFile.FileHeader.Comment2 = Comment2TextBox.Text
      m_TranscriptionFile.FileHeader.MyName = MyNameTextBox.Text
      m_TranscriptionFile.FileHeader.MyEmail = MyEmailTextBox.Text
   End Sub

   Private Sub CountyComboBox_DrawItem(sender As Object, e As Windows.Forms.DrawItemEventArgs) Handles CountyComboBox.DrawItem
      e.DrawBackground()
      If e.State = DrawItemState.Focus Then
         e.DrawFocusRectangle()
      End If
      Dim x = CountyComboBox.Items(e.Index)
      Dim r = x.Row
      Dim s = String.Format("{0} - {1}", r.ChapmanCode, r.CountyName)
      e.Graphics.DrawString(s, e.Font, Brushes.Black, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
   End Sub

   Private Sub formFileDetails_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      CountyComboBox.SelectedValue = m_TranscriptionFile.FileHeader.County
      PlacesBindingSource.Filter = String.Format("ChapmanCode = '{0}'", m_TranscriptionFile.FileHeader.County)
      PlaceComboBox.SelectedValue = m_TranscriptionFile.FileHeader.Place
      ChurchesBindingSource.Filter = String.Format("ChapmanCode = '{0}' AND PlaceName = '{1}'", m_TranscriptionFile.FileHeader.County, m_TranscriptionFile.FileHeader.Place)
      ChurchComboBox.SelectedValue = m_TranscriptionFile.FileHeader.Church
      RegisterTypeComboBox.SelectedValue = m_TranscriptionFile.FileHeader.RegisterType
      FileTypeComboBox.SelectedValue = [Enum].GetName(GetType(FileTypes), m_TranscriptionFile.FileHeader.FileType).Substring(0, 2)
   End Sub

   Private Sub PlaceComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PlaceComboBox.SelectedIndexChanged
      ChurchesBindingSource.Filter = String.Format("ChapmanCode = '{0}' AND PlaceName = '{1}'", CountyComboBox.SelectedValue, PlaceComboBox.SelectedValue)
   End Sub
End Class