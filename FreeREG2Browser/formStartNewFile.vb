Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.IO
Imports Microsoft.WindowsAPICodePack.Shell

Public Class formStartNewFile

   Private m_TablesDataSet As WinFreeReg.FreeregTables
   Private m_LookupsDataSet As WinFreeReg.LookupTables
   Private m_SelectedCounty As String
   Private m_SelectedPlace As String
   Private m_SelectedChurch As String
   Private m_SelectedRegisterType As String
   Private m_SelectedRecordType As String
   Private m_RecordType As String
   Private AppDataLocalFolder = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName)

   Private m_UserName As String
   Public Property Username() As String
      Get
         Return m_UserName
      End Get
      Set(ByVal value As String)
         m_UserName = value
      End Set
   End Property

   Private m_EmailAddress As String
   Public Property EmailAddress() As String
      Get
         Return m_EmailAddress
      End Get
      Set(ByVal value As String)
         m_EmailAddress = value
      End Set
   End Property

   Public Property dsFreeRegTables() As WinFreeReg.FreeregTables
      Get
         Return m_TablesDataSet
      End Get
      Set(ByVal value As WinFreeReg.FreeregTables)
         m_TablesDataSet = value
      End Set
   End Property

   Public Property dsLookupTables() As WinFreeReg.LookupTables
      Get
         Return m_LookupsDataSet
      End Get
      Set(ByVal value As WinFreeReg.LookupTables)
         m_LookupsDataSet = value
      End Set
   End Property

   Private _myDefaultCounty As WinFreeReg.LookupTables.ChapmanCodesRow
   Public Property DefaultCounty() As WinFreeReg.LookupTables.ChapmanCodesRow
      Get
         Return _myDefaultCounty
      End Get
      Set(ByVal value As WinFreeReg.LookupTables.ChapmanCodesRow)
         _myDefaultCounty = value
      End Set
   End Property

   Private _myTranscriptionLibrary As String
   Public Property TranscriptionLibrary() As String
      Get
         Return _myTranscriptionLibrary
      End Get
      Set(ByVal value As String)
         _myTranscriptionLibrary = value
      End Set
   End Property

   Private _myNewFile As TranscriptionFileClass
   Public ReadOnly Property NewTranscriptionFile() As TranscriptionFileClass
      Get
         Return _myNewFile
      End Get
   End Property

   Private _TablesUpdated As Boolean
   Public Property TablesUpdated() As Boolean
      Get
         Return _TablesUpdated
      End Get
      Set(ByVal value As Boolean)
         _TablesUpdated = value
      End Set
   End Property

   Private formHelp As formGeneralHelp = Nothing

   Public Sub New(helpForm As formGeneralHelp)
      InitializeComponent()

      formHelp = helpForm
   End Sub

   Property Settings As FreeReg2BrowserSettings
   Property UserTablesFile As String

   Property LibraryName As String

   Property UseLibrary As Boolean

   Private Sub formStartNewFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If USE_FILECODES Then
      CodeTextBox.MaxLength = 8
#Else
      CodeTextBox.MaxLength = 3
#End If
      CodeTextBox.Size = New Drawing.Size(CodeTextBox.MaxLength * 10 + 10, 20)
      linkUpdate.Location = New Drawing.Point(CodeTextBox.Location.X + CodeTextBox.Size.Width + 2, 100)

      CountiesBindingSource.DataSource = m_TablesDataSet
      PlacesBindingSource.DataSource = m_TablesDataSet
      ChurchesBindingSource.DataSource = m_TablesDataSet
      RegisterTypesBindingSource.DataSource = m_TablesDataSet
      RecordTypesBindingSource.DataSource = m_LookupsDataSet

      If _myDefaultCounty IsNot Nothing Then CountiesComboBox.SelectedIndex = CountiesComboBox.FindString(_myDefaultCounty.County)

      Dim AppDataLocalFolder = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName)
      Dim ToolTipsFile As String = Path.Combine(AppDataLocalFolder, "ToolTips.xml")
      Dim MyToolTips = New CustomToolTip(ToolTipsFile, Me)
   End Sub

   Private Sub CountiesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CountiesComboBox.SelectedIndexChanged
      If CountiesComboBox.SelectedItem IsNot Nothing Then
         Dim row As WinFreeReg.FreeregTables.CountiesRow = CType(CountiesComboBox.SelectedItem(), DataRowView).Row
         m_SelectedCounty = row.ChapmanCode

         Dim ChurchesInCounty() = m_TablesDataSet.Counties.FindByChapmanCode(row.ChapmanCode).GetChildRows("ChurchesInCounty")
         If ChurchesInCounty.Length > 0 Then
            Dim dtChurchesInCounty = ChurchesInCounty.CopyToDataTable()
            Dim dtPlacesWithChurchesInCounty = dtChurchesInCounty.DefaultView.ToTable(True, "PlaceName")
            labPlace.Visible = True
            PlacesBindingSource.DataSource = dtPlacesWithChurchesInCounty
            PlacesBindingSource.Sort = "PlaceName"
            PlacesComboBox.Enabled = True
            PlacesComboBox.Visible = True
            labPlacesMessage.Visible = False
            PlacesComboBox.SelectedIndex = -1
            PlacesComboBox.SelectedIndex = PlacesComboBox.FindString(dtPlacesWithChurchesInCounty(0).Item(0))
         Else
            PlacesComboBox.DataSource = Nothing
            PlacesComboBox.Visible = False
            labPlacesMessage.Visible = True
         End If

      End If
   End Sub

   Private Sub PlacesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlacesComboBox.SelectedIndexChanged
      If PlacesComboBox.SelectedItem IsNot Nothing Then
         '         Dim row As WinFreeReg.FreeregTables.PlacesRow = CType(PlacesComboBox.SelectedItem(), DataRowView).Row
         Dim row As WinFreeReg.FreeregTables.PlacesRow = m_TablesDataSet.Places.FindByPlaceNameChapmanCode(PlacesComboBox.SelectedValue, m_SelectedCounty)
         m_SelectedPlace = row.PlaceName

         labChurch.Visible = True
         ChurchesBindingSource.Filter = String.Format("ChapmanCode = '{0}' AND PlaceName = '{1}'", m_SelectedCounty, m_SelectedPlace)
         Select Case ChurchesBindingSource.Count
            Case 0
               MessageBox.Show("The selected Place has no Church information available. Download the Church information before creating the new file.", "Create New File", MessageBoxButtons.OK, MessageBoxIcon.Error)
               Beep()

            Case 1
               Dim rowChurch As WinFreeReg.FreeregTables.ChurchesRow = ChurchesBindingSource.Item(0).Row
               ChurchesComboBox.Enabled = False
               ChurchesComboBox.Visible = False
               ChurchTextBox.Enabled = True
               ChurchTextBox.Visible = True
               ChurchTextBox.Text = rowChurch.ChurchName
               m_SelectedChurch = rowChurch.ChurchName
               labCode.Visible = True
               CodeTextBox.Visible = True

#If USE_FILECODES Then
               CodeTextBox.Text = rowChurch.Code
               If Not String.IsNullOrEmpty(rowChurch.Code) Then
                  Label1.Visible = True
                  Dim strFileName As String = CodeTextBox.Text + m_SelectedRecordType
                  labFilename.Text = CodeTextBox.Text + " " + m_SelectedRecordType + " " + SuffixNumber(strFileName).ToString
                  labFilename.Visible = True
               End If
#Else
               If rowChurch.FileCode.Length = 3 Then CodeTextBox.Text = rowChurch.FileCode Else CodeTextBox.Text = String.Empty
               If Not String.IsNullOrEmpty(CodeTextBox.Text) Then
                  Label1.Visible = True
                  Dim strFileName As String = m_SelectedCounty + CodeTextBox.Text + m_SelectedRecordType
                  labFilename.Text = m_SelectedCounty + " " + CodeTextBox.Text + " " + m_SelectedRecordType + " " + SuffixNumber(strFileName).ToString
                  labFilename.Visible = True
               End If
#End If

               labRegisterType.Visible = True
               RegisterTypesComboBox.Enabled = True
               RegisterTypesComboBox.Visible = True
               RegisterTypesComboBox.SelectedIndex = -1
               RegisterTypesComboBox.SelectedIndex = RegisterTypesComboBox.FindString(RegisterTypesComboBox.Text)

            Case Else
               ChurchesComboBox.Enabled = True
               ChurchesComboBox.Visible = True
               ChurchTextBox.Enabled = False
               ChurchTextBox.Visible = False
               labCode.Visible = True
               CodeTextBox.Visible = True
               CodeTextBox.Text = String.Empty
         End Select
      End If
   End Sub

   Private Sub ChurchesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChurchesComboBox.SelectedIndexChanged
      If ChurchesComboBox.SelectedItem IsNot Nothing Then
         Dim row As WinFreeReg.FreeregTables.ChurchesRow = CType(ChurchesComboBox.SelectedItem(), DataRowView).Row
         m_SelectedChurch = row.ChurchName
         labCode.Visible = True
         CodeTextBox.Visible = True
         linkUpdate.Visible = True

#If USE_FILECODES Then
         CodeTextBox.Text = row.Code
         If Not String.IsNullOrEmpty(row.Code) Then
            Label1.Visible = True
            Dim strFileName As String = CodeTextBox.Text + m_SelectedRecordType
            labFilename.Text = CodeTextBox.Text + " " + m_SelectedRecordType +" " + SuffixNumber(strFileName).ToString
            labFilename.Visible = True
         End If
#Else
         If row.FileCode.Length = 3 Then CodeTextBox.Text = row.FileCode Else CodeTextBox.Text = String.Empty
         If Not String.IsNullOrEmpty(CodeTextBox.Text) Then
            Label1.Visible = True
            Dim strFileName As String = m_SelectedCounty + CodeTextBox.Text + m_SelectedRecordType
            labFilename.Text = m_SelectedCounty + " " + CodeTextBox.Text + " " + m_SelectedRecordType + " " + SuffixNumber(strFileName).ToString
            labFilename.Visible = True
         End If
#End If

         labRegisterType.Visible = True
         RegisterTypesComboBox.Enabled = True
         RegisterTypesComboBox.Visible = True
      End If
   End Sub

   Private Sub RegisterTypesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterTypesComboBox.SelectedIndexChanged
      If RegisterTypesComboBox.SelectedItem IsNot Nothing Then
         Dim row As WinFreeReg.FreeregTables.ApprovedRegisterTypesRow = CType(RegisterTypesComboBox.SelectedItem(), DataRowView).Row
         m_SelectedRegisterType = row.Type

         labRecordType.Visible = True
         RecordTypesComboBox.Enabled = True
         RecordTypesComboBox.Visible = True
         Dim x = CType(CType(RecordTypesComboBox.SelectedItem, DataRowView).Row, WinFreeReg.LookupTables.RecordTypesRow).Type
         RecordTypesComboBox.SelectedIndex = -1
         RecordTypesComboBox.SelectedIndex = RecordTypesComboBox.FindString(x)
      End If
   End Sub

   Private Sub RecordTypesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecordTypesComboBox.SelectedIndexChanged
      If RecordTypesComboBox.SelectedItem IsNot Nothing Then
         Dim row As WinFreeReg.LookupTables.RecordTypesRow = CType(RecordTypesComboBox.SelectedItem(), DataRowView).Row
         m_SelectedRecordType = row.Type
         m_RecordType = row.Description

#If USE_FILECODES Then
         If Not String.IsNullOrEmpty(CodeTextBox.Text) Then
            Label1.Visible = True
            Dim strFileName As String = CodeTextBox.Text + m_SelectedRecordType
            labFilename.Text = CodeTextBox.Text + " " + m_SelectedRecordType + " " + SuffixNumber(strFileName).ToString
            labFilename.Visible = True
         End If
#Else
         Label1.Visible = True
         Dim strFileName As String = m_SelectedCounty + CodeTextBox.Text + m_SelectedRecordType
         labFilename.Text = m_SelectedCounty + " " + CodeTextBox.Text + " " + m_SelectedRecordType + " " + SuffixNumber(strFileName).ToString
         labFilename.Visible = True
#End If

         labComments.Visible = True
         Comment1TextBox.Enabled = True
         Comment1TextBox.Visible = True
         Comment2TextBox.Enabled = True
         Comment2TextBox.Visible = True

         ldsCheckBox.Visible = True

         labCreditName.Visible = True
         CreditNameTextBox.Visible = True
         labCreditEmail.Visible = True
         CreditEmailTextBox.Visible = True

         StartFileButton.Visible = AreAllComponentsValid()
      End If
   End Sub

   Private Sub CodeTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodeTextBox.TextChanged
#If USE_FILECODES Then
      Dim strFileName As String = CodeTextBox.Text + m_SelectedRecordType
      labFilename.Text = CodeTextBox.Text + " " + m_SelectedRecordType + " " + SuffixNumber(strFileName).ToString
#Else
      Dim strFileName As String = m_SelectedCounty + CodeTextBox.Text + m_SelectedRecordType
      labFilename.Text = m_SelectedCounty + " " + CodeTextBox.Text + " " + m_SelectedRecordType + " " + SuffixNumber(strFileName).ToString
#End If
      Label1.Visible = CodeTextBox.TextLength > 0
      labFilename.Visible = True
      linkUpdate.Visible = (CodeTextBox.TextLength = CodeTextBox.MaxLength)
   End Sub

   Private Function ListFiles(ByVal root As String) As System.Collections.Generic.IEnumerable(Of System.IO.FileInfo)
      ' Function to retrieve a list of files. Note that this is a copy
      ' of the file information.
      Return From file In My.Computer.FileSystem.GetFiles(root, FileIO.SearchOption.SearchTopLevelOnly, "*.*") _
       Select New System.IO.FileInfo(file)
   End Function

   Private Function SuffixNumber(ByVal name As String) As String
      Dim result As String = String.Empty

      Dim fileQuery = From file As FileInfo In ListFiles(_myTranscriptionLibrary) _
                      Where file.Extension.Equals(".csv", StringComparison.CurrentCultureIgnoreCase) And file.Name.StartsWith(name) _
                      Order By file.Name _
                      Select file
      If fileQuery.Count = 0 Then Return result
      Return fileQuery.Count.ToString
   End Function

   Private Sub StartFileButton_Click(sender As Object, e As EventArgs) Handles StartFileButton.Click
      Try
         Dim NewFile As New TranscriptionFileClass()

         If UseLibrary Then
            Dim libtrans As ShellLibrary
            libtrans = ShellLibrary.Load(LibraryName, True)
            Dim listFolders As List(Of String) = New List(Of String)
            For i As Integer = 0 To libtrans.Count - 1
               listFolders.Add(libtrans(i).Path)
            Next
            Dim defFolder = listFolders.IndexOf(libtrans.DefaultSaveFolder)

            Using dlg As New dlgSaveFile With {.ReturnFolder = True, .listFolders = listFolders, .DefaultFolder = defFolder, .FileName = labFilename.Text.Replace(" ", "") + ".CSV"}
               dlg.Text = "Create New File"
               dlg.formHelp = formHelp
               Dim rc As DialogResult = dlg.ShowDialog()
               If rc = DialogResult.OK Then
                  NewFile.Create(Path.Combine(dlg.SelectedFileName, labFilename.Text.Replace(" ", "") + ".CSV"), dsLookupTables, dsFreeRegTables, m_RecordType)
               Else
                  Return
               End If
            End Using
         Else
            NewFile.Create(Path.Combine(_myTranscriptionLibrary, labFilename.Text.Replace(" ", "") + ".CSV"), dsLookupTables, dsFreeRegTables, m_RecordType)
         End If

         NewFile.FileHeader.MyEmail = m_EmailAddress
         NewFile.FileHeader.MyName = m_UserName
         NewFile.FileHeader.MyPassword = "password"
         NewFile.FileHeader.MySyndicate = CType(CType(CountiesComboBox.SelectedItem(), DataRowView).Row, WinFreeReg.FreeregTables.CountiesRow).CountyName
         NewFile.FileHeader.InternalFilename = labFilename.Text.Replace(" ", "") + ".CSV"
         NewFile.FileHeader.VersionUsed = ""
         NewFile.FileHeader.DateCreated = Format(Now(), "dd-MMM-yyyy")
         NewFile.FileHeader.DateLastChanged = Format(Now(), "dd-MMM-yyyy")
         NewFile.FileHeader.CreditName = CreditNameTextBox.Text
         NewFile.FileHeader.CreditEmail = CreditEmailTextBox.Text
         NewFile.FileHeader.Comment1 = Comment1TextBox.Text
         NewFile.FileHeader.Comment2 = Comment2TextBox.Text
         NewFile.FileHeader.County = m_SelectedCounty
         NewFile.FileHeader.Place = m_SelectedPlace
         NewFile.FileHeader.Church = m_SelectedChurch
         NewFile.FileHeader.RegisterType = m_SelectedRegisterType
         NewFile.FileHeader.isLDS = ldsCheckBox.Checked

         Select Case NewFile.FileHeader.FileType
            Case TranscriptionFileClass.FileTypes.BAPTISMS
               Dim recordcollection = New TranscriptionTables.BaptismsDataTable
               recordcollection.LinkLookupTables(True, True, dsLookupTables.BaptismSex)
               recordcollection.AcceptChanges()
               NewFile.Items = recordcollection

            Case TranscriptionFileClass.FileTypes.BURIALS
               Dim recordcollection = New TranscriptionTables.BurialsDataTable
               recordcollection.LinkLookupTables(True, True, dsLookupTables.BurialRelationship)
               recordcollection.AcceptChanges()
               NewFile.Items = recordcollection

            Case TranscriptionFileClass.FileTypes.MARRIAGES
               Dim recordcollection = New TranscriptionTables.MarriagesDataTable
               recordcollection.LinkLookupTables(True, True, dsLookupTables.GroomCondition, dsLookupTables.BrideCondition)
               recordcollection.AcceptChanges()
               NewFile.Items = recordcollection

         End Select

         Dim ErrorMessagesDataSet As New ErrorMessages()
         Dim ErrorMessagesFileName As String = Path.Combine(AppDataLocalFolder, "ErrorMessages.xml")

         Using dlg As New formFileWorkspace(formHelp) With {.TranscriptionFile = NewFile, .SelectedRow = Nothing, .BaseDirectory = AppDataLocalFolder, .ErrorMessageTable = ErrorMessagesDataSet.Tables("ErrorMessages")}
            Try
               dlg.IsNewFile = True
               dlg.Settings = Settings
               dlg.DefaultCounty = DefaultCounty
               dlg.UserTablesFile = UserTablesFile
               Dim rc = dlg.ShowDialog()
               Me.DialogResult = rc
               _myNewFile = NewFile

            Catch ex As Exception
               Beep()
               MessageBox.Show(ex.Message, "Start New File", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Finally
               Me.Close()
            End Try
         End Using

      Catch ex As FileHeaderException
         MessageBox.Show(ex.Message, "Start New File", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try
   End Sub

   Private Sub linkUpdate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkUpdate.LinkClicked
      If CodeTextBox.TextLength > 0 Then
#If USE_FILECODES Then
         Dim row As WinFreeReg.FreeregTables.ChurchesRow = CType(ChurchesComboBox.SelectedItem(), DataRowView).Row
         row.Code = CodeTextBox.Text
         m_TablesDataSet.AcceptChanges()
         _TablesUpdated = True
#Else
         Dim row As WinFreeReg.FreeregTables.ChurchesRow = CType(ChurchesComboBox.SelectedItem(), DataRowView).Row
         row.FileCode = CodeTextBox.Text
         m_TablesDataSet.AcceptChanges()
         _TablesUpdated = True
#End If
         linkUpdate.Visible = False
      End If
   End Sub

   Private Sub formStartNewFile_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles MyBase.HelpRequested
      Try
         formHelp.Title = "Start New File"
         formHelp.StartPage = "StartNewFile.html"
         formHelp.Show()

      Catch ex As Exception
         formHelp.Hide()
         MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try
   End Sub

   Private Function AreAllComponentsValid() As Boolean
      AreAllComponentsValid = True
      If String.IsNullOrEmpty(CodeTextBox.Text) Then
         MessageBox.Show(My.Resources.msgFileCodeIsRequired, "Start New File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
         AreAllComponentsValid = False
      End If
   End Function

End Class