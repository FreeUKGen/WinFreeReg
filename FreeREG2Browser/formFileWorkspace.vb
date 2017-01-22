Imports BrightIdeasSoftware
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing
Imports System.Text
Imports System.Globalization
Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.Linq

Public Class formFileWorkspace

   Private Const STATEFILE As String = "FileDetailsState.dat"

   Private m_TranscriptionFile As TranscriptionFileClass
   Public Property TranscriptionFile() As TranscriptionFileClass
      Get
         Return m_TranscriptionFile
      End Get
      Set(ByVal value As TranscriptionFileClass)
         m_TranscriptionFile = value
      End Set
   End Property

   Private m_Row As DataRow
   Public Property SelectedRow() As DataRow
      Get
         Return m_Row
      End Get
      Set(ByVal value As DataRow)
         m_Row = value
      End Set
   End Property

   Private m_BaseDirectory As String
   Public Property BaseDirectory() As String
      Get
         Return m_BaseDirectory
      End Get
      Set(ByVal value As String)
         m_BaseDirectory = value
      End Set
   End Property

   Private m_ErrorMessageTable As WinFreeReg.ErrorMessages.ErrorMessagesDataTable
   Public Property ErrorMessageTable() As WinFreeReg.ErrorMessages.ErrorMessagesDataTable
      Get
         Return m_ErrorMessageTable
      End Get
      Set(ByVal value As WinFreeReg.ErrorMessages.ErrorMessagesDataTable)
         m_ErrorMessageTable = value
      End Set
   End Property

   Private m_NewFile As Boolean
   Public Property IsNewFile() As Boolean
      Get
         Return m_NewFile
      End Get
      Set(ByVal value As Boolean)
         m_NewFile = value
      End Set
   End Property

   Private m_fname As String
   Private m_dlvStates()() As Byte = New Byte(3)() {}

   Property Settings As FreeReg2BrowserSettings

   Property DefaultCounty As LookupTables.ChapmanCodesRow

   Property FreeregTablesFile As String

   Property UserTablesFile As String

   Private Sub SaveDLVState(ByVal [enum] As TranscriptionFileClass.FileTypes, ByVal state As Byte())
      m_dlvStates([enum]) = state
   End Sub

   Private formHelp As formGeneralHelp = Nothing

   Sub New(ByVal helpForm As formGeneralHelp)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      m_dlvStates(TranscriptionFileClass.FileTypes.BAPTISMS) = dlvBaptisms.SaveState()
      m_dlvStates(TranscriptionFileClass.FileTypes.BURIALS) = dlvBurials.SaveState()
      m_dlvStates(TranscriptionFileClass.FileTypes.MARRIAGES) = dlvMarriages.SaveState()

      formHelp = helpForm
   End Sub

   Private Sub formFileDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      If My.Settings.Workspace_WindowState <> FormWindowState.Normal OrElse My.Settings.Workspace_Location <> New Point(0, 0) OrElse My.Settings.Workspace_Size <> New Size(0, 0) Then
         Me.Location = My.Settings.Workspace_Location
         Me.Size = My.Settings.Workspace_Size
         If My.Settings.Workspace_WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
         Else
            Me.WindowState = My.Settings.Workspace_WindowState
         End If
      End If

      Dim title = String.Format(Me.Text, m_TranscriptionFile.FileName)
      Me.Text = title

      dlvBaptisms.CellEditActivation = My.Settings.optionCellEditing
      dlvBaptisms.CellEditUseWholeCell = True
      dlvBaptisms.Font = My.Settings.optionFont
      dlvBurials.CellEditActivation = My.Settings.optionCellEditing
      dlvBurials.CellEditUseWholeCell = True
      dlvBurials.Font = My.Settings.optionFont
      dlvMarriages.CellEditActivation = My.Settings.optionCellEditing
      dlvMarriages.CellEditUseWholeCell = True
      dlvMarriages.Font = My.Settings.optionFont


      m_fname = Path.Combine(BaseDirectory, STATEFILE)
      If File.Exists(m_fname) Then
         Dim binReader As New BinaryReader(File.Open(m_fname, FileMode.Open, FileAccess.Read, FileShare.Read))
         Try
            m_dlvStates(TranscriptionFileClass.FileTypes.BAPTISMS) = binReader.ReadBytes(m_dlvStates(TranscriptionFileClass.FileTypes.BAPTISMS).Length)
            m_dlvStates(TranscriptionFileClass.FileTypes.BURIALS) = binReader.ReadBytes(m_dlvStates(TranscriptionFileClass.FileTypes.BURIALS).Length)
            m_dlvStates(TranscriptionFileClass.FileTypes.MARRIAGES) = binReader.ReadBytes(m_dlvStates(TranscriptionFileClass.FileTypes.MARRIAGES).Length)

            dlvBaptisms.RestoreState(m_dlvStates(TranscriptionFileClass.FileTypes.BAPTISMS))
            dlvBurials.RestoreState(m_dlvStates(TranscriptionFileClass.FileTypes.BURIALS))
            dlvMarriages.RestoreState(m_dlvStates(TranscriptionFileClass.FileTypes.MARRIAGES))

         Catch ex As Exception
            Throw

         Finally
            binReader.Close()
         End Try
      End If

      Select Case m_TranscriptionFile.FileHeader.FileType
         Case TranscriptionFileClass.FileTypes.BAPTISMS
            Dim dt As TranscriptionTables.BaptismsDataTable = TranscriptionFile.Items
            bsBaptisms.DataSource = dt
            workspaceBindingNavigator.BindingSource = bsBaptisms
            If m_TranscriptionFile.FileHeader.isLDS Then
               olvcFiche.IsVisible = True
               olvcImage.IsVisible = True
            Else
               olvcFiche.IsVisible = False
               olvcImage.IsVisible = False
            End If
            olvcSex.AspectToStringConverter = AddressOf SexDescription
            dlvBaptisms.CellEditKeyEngine.SetKeyBehaviour(Keys.Enter, CellEditCharacterBehaviour.ChangeColumnRight, CellEditAtEdgeBehaviour.Ignore)
            dlvBaptisms.CellEditKeyEngine.SetKeyBehaviour(Keys.Up Or Keys.Alt, CellEditCharacterBehaviour.ChangeRowUp, CellEditAtEdgeBehaviour.ChangeRow)
            dlvBaptisms.CellEditKeyEngine.SetKeyBehaviour(Keys.Down + Keys.Alt, CellEditCharacterBehaviour.ChangeRowDown, CellEditAtEdgeBehaviour.ChangeRow)
            If My.Settings.optionEditingCellBorder Then dlvBaptisms.AddDecoration(New EditingCellBorderDecoration(True))
            dlvBaptisms.RebuildColumns()
            dlvBaptisms.Visible = True
            dlvBaptisms.CustomSorter = AddressOf BaptismsSorter
            dlvBaptisms.Select()

         Case TranscriptionFileClass.FileTypes.BURIALS
            Dim dt As TranscriptionTables.BurialsDataTable = TranscriptionFile.Items
            bsBurials.DataSource = dt
            workspaceBindingNavigator.BindingSource = bsBurials
            If m_TranscriptionFile.FileHeader.isLDS Then
               olvcFiche1.IsVisible = True
               olvcImage1.IsVisible = True
            Else
               olvcFiche1.IsVisible = False
               olvcImage1.IsVisible = False
            End If
            olvcRelationship.AspectToStringConverter = AddressOf RelationshipDescription
            dlvBurials.CellEditKeyEngine.SetKeyBehaviour(Keys.Enter, CellEditCharacterBehaviour.ChangeColumnRight, CellEditAtEdgeBehaviour.Ignore)
            dlvBurials.CellEditKeyEngine.SetKeyBehaviour(Keys.Up Or Keys.Alt, CellEditCharacterBehaviour.ChangeRowUp, CellEditAtEdgeBehaviour.ChangeRow)
            dlvBurials.CellEditKeyEngine.SetKeyBehaviour(Keys.Down + Keys.Alt, CellEditCharacterBehaviour.ChangeRowDown, CellEditAtEdgeBehaviour.ChangeRow)
            If My.Settings.optionEditingCellBorder Then dlvBurials.AddDecoration(New EditingCellBorderDecoration(True))
            dlvBurials.RebuildColumns()
            dlvBurials.Visible = True
            dlvBurials.CustomSorter = AddressOf BurialsSorter
            dlvBurials.Select()

         Case TranscriptionFileClass.FileTypes.MARRIAGES
            Dim dt As TranscriptionTables.MarriagesDataTable = TranscriptionFile.Items
            bsMarriages.DataSource = dt
            workspaceBindingNavigator.BindingSource = bsMarriages
            If m_TranscriptionFile.FileHeader.isLDS Then
               olvcFiche2.IsVisible = True
               olvcImage2.IsVisible = True
            Else
               olvcFiche2.IsVisible = False
               olvcImage2.IsVisible = False
            End If
            olvcGroomCondition.AspectToStringConverter = AddressOf GroomConditionDescription
            olvcBrideCondition.AspectToStringConverter = AddressOf BrideConditionDescription
            dlvMarriages.CellEditKeyEngine.SetKeyBehaviour(Keys.Enter, CellEditCharacterBehaviour.ChangeColumnRight, CellEditAtEdgeBehaviour.Ignore)
            dlvMarriages.CellEditKeyEngine.SetKeyBehaviour(Keys.Up Or Keys.Alt, CellEditCharacterBehaviour.ChangeRowUp, CellEditAtEdgeBehaviour.ChangeRow)
            dlvMarriages.CellEditKeyEngine.SetKeyBehaviour(Keys.Down + Keys.Alt, CellEditCharacterBehaviour.ChangeRowDown, CellEditAtEdgeBehaviour.ChangeRow)
            If My.Settings.optionEditingCellBorder Then dlvMarriages.AddDecoration(New EditingCellBorderDecoration(True))
            dlvMarriages.RebuildColumns()
            dlvMarriages.Visible = True
            dlvMarriages.CustomSorter = AddressOf MarriagesSorter
            dlvMarriages.Select()

      End Select

      If m_NewFile Then AddNewItem("", "", "", "", "")

      Dim AppDataLocalFolder = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName)
      Dim ToolTipsFile As String = Path.Combine(AppDataLocalFolder, "ToolTips.xml")
      Dim MyToolTips = New CustomToolTip(ToolTipsFile, Me)

   End Sub

   Private Function SexDescription(ByVal model As Object) As String
      If IsDBNull(model) Then
         Return String.Empty
      Else
         Dim x = m_TranscriptionFile.LookupTables.BaptismSex.FindByCode(CType(model, String))
         If x Is Nothing Then
            Return "Unknown?"
         End If
         Return x.Description
      End If
   End Function

   Private Function RelationshipDescription(ByVal model As Object) As String
      Dim x = m_TranscriptionFile.LookupTables.BurialRelationship.FindByFileValue(CType(model, String))
      If x Is Nothing Then
         Return CType(model, String)
      End If
      Return x.DisplayValue
   End Function

   Private Function GroomConditionDescription(ByVal model As Object) As String
      Dim x = m_TranscriptionFile.LookupTables.GroomCondition.FindByFileValue(CType(model, String))
      If x Is Nothing Then
         Return CType(model, String)
      End If
      Return x.DisplayValue
   End Function

   Private Function BrideConditionDescription(ByVal model As Object) As String
      Dim x = m_TranscriptionFile.LookupTables.BrideCondition.FindByFileValue(CType(model, String))
      If x Is Nothing Then
         Return CType(model, String)
      End If
      Return x.DisplayValue
   End Function

   Private Sub formFileWorkspace_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      Select Case m_TranscriptionFile.FileHeader.FileType
         Case TranscriptionFileClass.FileTypes.BAPTISMS
            Dim dt As TranscriptionTables.BaptismsDataTable = CType(bsBaptisms.DataSource, TranscriptionTables.BaptismsDataTable)
            If dt.HasErrors Then
               Dim errors As New List(Of classUncorrectedErrors)

               For Each row As DataRow In dt.GetErrors()
                  Dim err As New classUncorrectedErrors()
                  err.TableName = dt.TableName
                  err.ColumnName = row.GetColumnsInError()
                  err.Row = row
                  '						err.RowText = ""
                  err.ColummnError = ""
                  errors.Add(err)
               Next

               Using dlg As New formDataErrors(formHelp) With {.Lookups = m_TranscriptionFile.LookupTables}
                  Generator.GenerateColumns(dlg.olvErrors, GetType(classUncorrectedErrors), True)
                  dlg.olvErrors.SetObjects(errors)
                  Try
                     dlg.ShowDialog()
                     Select Case dlg.DialogResult
                        Case Windows.Forms.DialogResult.OK
                           e.Cancel = True
                        Case Windows.Forms.DialogResult.Cancel
                           e.Cancel = True
                        Case Windows.Forms.DialogResult.Ignore
                           e.Cancel = False
                     End Select

                  Catch ex As Exception
                     MessageBox.Show(ex.Message, "Workspace Form Closing - Baptisms", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                  End Try
               End Using
            End If

         Case TranscriptionFileClass.FileTypes.BURIALS
            Dim dt As TranscriptionTables.BurialsDataTable = CType(bsBurials.DataSource, TranscriptionTables.BurialsDataTable)
            If dt.HasErrors Then
               Dim errors As New List(Of classUncorrectedErrors)

               For Each row As DataRow In dt.GetErrors()
                  For Each col As DataColumn In row.GetColumnsInError()
                     Dim err As New classUncorrectedErrors()
                     err.TableName = dt.TableName
                     err.ColumnName = row.GetColumnsInError()
                     err.Row = row
                     errors.Add(err)
                  Next
               Next

               Using dlg As New formDataErrors(formHelp) With {.Lookups = m_TranscriptionFile.LookupTables}
                  Generator.GenerateColumns(dlg.olvErrors, GetType(classUncorrectedErrors), True)
                  dlg.olvErrors.SetObjects(errors)
                  Try
                     dlg.ShowDialog()
                     Select Case dlg.DialogResult
                        Case Windows.Forms.DialogResult.OK
                           e.Cancel = True
                        Case Windows.Forms.DialogResult.Cancel
                           e.Cancel = True
                        Case Windows.Forms.DialogResult.Ignore
                           e.Cancel = False
                     End Select

                  Catch ex As Exception
                     MessageBox.Show(ex.Message, "Workspace Form Closing - Burials", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                  End Try
               End Using
            End If

         Case TranscriptionFileClass.FileTypes.MARRIAGES
            Dim dt As TranscriptionTables.MarriagesDataTable = CType(bsMarriages.DataSource, TranscriptionTables.MarriagesDataTable)
            If dt.HasErrors Then
               Dim errors As New List(Of classUncorrectedErrors)

               For Each row As DataRow In dt.GetErrors()
                  For Each col As DataColumn In row.GetColumnsInError()
                     Dim err As New classUncorrectedErrors()
                     err.TableName = dt.TableName
                     err.ColumnName = row.GetColumnsInError()
                     err.Row = row
                     errors.Add(err)
                  Next
               Next

               Using dlg As New formDataErrors(formHelp) With {.Lookups = m_TranscriptionFile.LookupTables}
                  Generator.GenerateColumns(dlg.olvErrors, GetType(classUncorrectedErrors), True)
                  dlg.olvErrors.SetObjects(errors)
                  Try
                     dlg.ShowDialog()
                     Select Case dlg.DialogResult
                        Case Windows.Forms.DialogResult.OK
                           e.Cancel = True
                        Case Windows.Forms.DialogResult.Cancel
                           e.Cancel = True
                        Case Windows.Forms.DialogResult.Ignore
                           e.Cancel = False
                     End Select

                  Catch ex As Exception
                     MessageBox.Show(ex.Message, "Workspace Form Closing - Marriages", MessageBoxButtons.OK, MessageBoxIcon.Stop)

                  End Try
               End Using
            End If

      End Select

      My.Settings.Workspace_WindowState = Me.WindowState
      My.Settings.Workspace_Location = Me.Location
      My.Settings.Workspace_Size = Me.Size
      My.Settings.Save()
   End Sub

   Private Sub formFileDetails_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
      Select Case m_TranscriptionFile.FileHeader.FileType
         Case TranscriptionFileClass.FileTypes.BAPTISMS
            Dim dt As TranscriptionTables.BaptismsDataTable = CType(bsBaptisms.DataSource, TranscriptionTables.BaptismsDataTable)
            If dt.GetChanges() IsNot Nothing Then
               If MessageBox.Show(My.Resources.msgUnsavedChanges, "Save File", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                  dt.AcceptChanges()
                  m_TranscriptionFile.Save()
               Else
                  dt.RejectChanges()
               End If
            Else
               If dt.HasErrors Then
                  If MessageBox.Show(My.Resources.msgSaveFileWithErrors, "Save File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                     m_TranscriptionFile.Save()
                  End If
               End If
            End If

         Case TranscriptionFileClass.FileTypes.BURIALS
            Dim dt As TranscriptionTables.BurialsDataTable = CType(bsBurials.DataSource, TranscriptionTables.BurialsDataTable)
            If dt.GetChanges() IsNot Nothing Then
               If MessageBox.Show(My.Resources.msgUnsavedChanges, "Save File", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                  dt.AcceptChanges()
                  m_TranscriptionFile.Save()
               Else
                  dt.RejectChanges()
               End If
            Else
               If dt.HasErrors Then
                  If MessageBox.Show(My.Resources.msgSaveFileWithErrors, "Save File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                     m_TranscriptionFile.Save()
                  End If
               End If
            End If

         Case TranscriptionFileClass.FileTypes.MARRIAGES
            Dim dt As TranscriptionTables.MarriagesDataTable = CType(bsMarriages.DataSource, TranscriptionTables.MarriagesDataTable)
            If dt.GetChanges() IsNot Nothing Then
               If MessageBox.Show(My.Resources.msgUnsavedChanges, "Save File", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                  dt.AcceptChanges()
                  m_TranscriptionFile.Save()
               Else
                  dt.RejectChanges()
               End If
            Else
               If dt.HasErrors Then
                  If MessageBox.Show(My.Resources.msgSaveFileWithErrors, "Save File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                     m_TranscriptionFile.Save()
                  End If
               End If
            End If

      End Select

      ' Save the states of the 3 DLVs
      '
      Dim binWriter As New BinaryWriter(File.Open(m_fname, FileMode.Create, FileAccess.Write))
      Try
         SaveDLVState(TranscriptionFileClass.FileTypes.BAPTISMS, dlvBaptisms.SaveState())
         SaveDLVState(TranscriptionFileClass.FileTypes.BURIALS, dlvBurials.SaveState())
         SaveDLVState(TranscriptionFileClass.FileTypes.MARRIAGES, dlvMarriages.SaveState())

         binWriter.Write(m_dlvStates(TranscriptionFileClass.FileTypes.BAPTISMS))
         binWriter.Write(m_dlvStates(TranscriptionFileClass.FileTypes.BURIALS))
         binWriter.Write(m_dlvStates(TranscriptionFileClass.FileTypes.MARRIAGES))

      Catch ex As Exception
         Throw

      Finally
         binWriter.Close()
         DialogResult = Windows.Forms.DialogResult.OK
      End Try

   End Sub

#Region "Baptism Cells"

   Private Sub BaptismsSorter(column As OLVColumn, order As SortOrder)
      Select Case column.AspectName
         Case "BirthDate"
            dlvBaptisms.ListViewItemSorter = New DateColumnComparer(column, order)
         Case "BaptismDate"
            dlvBaptisms.ListViewItemSorter = New DateColumnComparer(column, order)
         Case Else
            dlvBaptisms.ListViewItemSorter = New ColumnComparer(column, order)
      End Select
   End Sub

   Private Sub BaptismCellEditStarting(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvBaptisms.CellEditStarting
      If TypeOf e.Control Is System.Windows.Forms.TextBox Then
         If e.Column.AspectName.Contains("Surname") Then
            Dim ucfBox = New ctlTextboxWithUCF()
            ucfBox.CharacterCasing = CharacterCasing.Upper
            ucfBox.SetBounds(e.CellBounds.X - e.CellBounds.Width - 1, e.CellBounds.Y, 0, 0, BoundsSpecified.Location)
            ucfBox.Value = e.Value
            e.Control = ucfBox
         ElseIf e.Column.AspectName = "Forenames" OrElse e.Column.AspectName = "FathersName" OrElse e.Column.AspectName = "MothersName" Then
            Dim ucfBox = New ctlTextboxWithUCF()
            ucfBox.CharacterCasing = CharacterCasing.Normal
            ucfBox.SetBounds(e.CellBounds.X - e.CellBounds.Width - 1, e.CellBounds.Y, 0, 0, BoundsSpecified.Location)
            ucfBox.Value = e.Value
            e.Control = ucfBox
         ElseIf e.Column.AspectName = "Abode" Then
            Dim ucfBox = New ctlTextboxWithUCF()
            ucfBox.CharacterCasing = CharacterCasing.Normal
            ucfBox.SetBounds(e.CellBounds.X - e.CellBounds.Width - 1, e.CellBounds.Y, 0, 0, BoundsSpecified.Location)
            ucfBox.Value = e.Value
            e.Control = ucfBox
         ElseIf e.Column.AspectName = "FathersOccupation" Then
            Dim ucfBox = New ctlTextboxWithUCF()
            ucfBox.CharacterCasing = CharacterCasing.Normal
            ucfBox.SetBounds(e.CellBounds.X - e.CellBounds.Width - 1, e.CellBounds.Y, 0, 0, BoundsSpecified.Location)
            ucfBox.Value = e.Value
            e.Control = ucfBox
         Else
            If e.Column.AspectName = "Sex" Then
               CType(e.Control, System.Windows.Forms.TextBox).CharacterCasing = CharacterCasing.Upper
            End If
            CType(e.Control, System.Windows.Forms.TextBox).BackColor = Color.LightGreen
         End If
      End If
   End Sub

   Private Sub BaptismCellEditValidating(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvBaptisms.CellEditValidating
   End Sub

   Private Sub BaptismCellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvBaptisms.CellEditFinishing
      If e.Cancel Then Return
      If e.NewValue = e.Value Then
         e.Cancel = True
      Else
         If TypeOf e.Control Is TextBox Then

         ElseIf TypeOf e.Control Is ctlTextboxWithUCF Then
            Select Case e.Column.AspectName
               Case "Forenames", "FathersName", "MothersName"
                  Dim culture As CultureInfo = Thread.CurrentThread.CurrentCulture
                  Dim tinfo As TextInfo = culture.TextInfo()
                  e.NewValue = tinfo.ToTitleCase(e.NewValue)
               Case "FathersOccupation"
                  Dim culture As CultureInfo = Thread.CurrentThread.CurrentCulture
                  Dim tinfo As TextInfo = culture.TextInfo()
                  e.NewValue = tinfo.ToTitleCase(e.NewValue)
               Case "Abode"
                  Dim culture As CultureInfo = Thread.CurrentThread.CurrentCulture
                  Dim tinfo As TextInfo = culture.TextInfo()
                  e.NewValue = tinfo.ToTitleCase(e.NewValue)
               Case Else
            End Select
            e.Control.Dispose()
         End If
      End If

   End Sub

   Private Sub BaptismCellEditFinished(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvBaptisms.CellEditFinished
      If e.Column.AspectName = "Notes" Then
         Dim x As DataRowView = e.RowObject
         Dim r As TranscriptionTables.BaptismsRow = x.Row
         If r.Table.Rows.Count = r.LoadOrder + 1 Then AddNewItem(r.RegNo, r.LDSFiche, r.LDSImage, r.BirthDate, r.BaptismDate)
      End If
   End Sub

#End Region

#Region "Burial Cells"

   Private Sub BurialsSorter(column As OLVColumn, order As SortOrder)
      Select Case column.AspectName
         Case "BurialDate"
            dlvBurials.ListViewItemSorter = New DateColumnComparer(column, order)
         Case Else
            dlvBurials.ListViewItemSorter = New ColumnComparer(column, order)
      End Select
   End Sub

   Private Sub BurialCellEditStarting(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvBurials.CellEditStarting
      If TypeOf e.Control Is System.Windows.Forms.TextBox Then
         If e.Column.AspectName.Contains("Surname") Then
            Dim ucfBox = New ctlTextboxWithUCF()
            ucfBox.CharacterCasing = CharacterCasing.Upper
            ucfBox.SetBounds(e.CellBounds.X - e.CellBounds.Width - 1, e.CellBounds.Y, 0, 0, BoundsSpecified.Location)
            ucfBox.Value = e.Value
            e.Control = ucfBox
         ElseIf e.Column.AspectName = "Forenames" OrElse e.Column.AspectName = "MaleForenames" OrElse e.Column.AspectName = "FemaleForenames" Then
            Dim ucfBox = New ctlTextboxWithUCF()
            ucfBox.CharacterCasing = CharacterCasing.Normal
            ucfBox.SetBounds(e.CellBounds.X - e.CellBounds.Width - 1, e.CellBounds.Y, 0, 0, BoundsSpecified.Location)
            ucfBox.Value = e.Value
            e.Control = ucfBox
         ElseIf e.Column.AspectName = "Abode" Then
            Dim ucfBox = New ctlTextboxWithUCF()
            ucfBox.CharacterCasing = CharacterCasing.Normal
            ucfBox.SetBounds(e.CellBounds.X - e.CellBounds.Width - 1, e.CellBounds.Y, 0, 0, BoundsSpecified.Location)
            ucfBox.Value = e.Value
            e.Control = ucfBox
         ElseIf e.Column.AspectName = "Relationship" Then
            Dim tCtl As TextBox = e.Control
            tCtl.Bounds = e.CellBounds
            tCtl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            tCtl.AutoCompleteSource = AutoCompleteSource.CustomSource
            Dim dt As LookupTables.BurialRelationshipDataTable = m_TranscriptionFile.LookupTables.BurialRelationship
            Dim plist = dt.AsEnumerable().Select(Function(r) r.Field(Of String)("DisplayValue")).ToArray()
            tCtl.AutoCompleteCustomSource.AddRange(plist)
         Else
            CType(e.Control, System.Windows.Forms.TextBox).BackColor = Color.LightGreen
         End If
      End If
   End Sub

   Private Sub BurialCellEditValidating(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvBurials.CellEditValidating
   End Sub

   Private Sub BurialCellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvBurials.CellEditFinishing
      If e.Cancel Then Return
      If e.NewValue = e.Value Then
         e.Cancel = True
      Else
         If TypeOf e.Control Is TextBox Then

         ElseIf TypeOf e.Control Is ctlTextboxWithUCF Then
            Select Case e.Column.AspectName
               Case "Forenames", "MaleForenames", "FemaleForenames"
                  Dim culture As CultureInfo = Thread.CurrentThread.CurrentCulture
                  Dim tinfo As TextInfo = culture.TextInfo()
                  e.NewValue = tinfo.ToTitleCase(e.NewValue)
               Case "Abode"
                  Dim culture As CultureInfo = Thread.CurrentThread.CurrentCulture
                  Dim tinfo As TextInfo = culture.TextInfo()
                  e.NewValue = tinfo.ToTitleCase(e.NewValue)
               Case Else
            End Select
            e.Control.Dispose()
         End If

      End If
   End Sub

   Private Sub BurialCellEditFinished(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvBurials.CellEditFinished
      If e.Column.AspectName = "Notes" Then
         Dim x As DataRowView = e.RowObject
         Dim r As TranscriptionTables.BurialsRow = x.Row
         If r.Table.Rows.Count = r.LoadOrder + 1 Then AddNewItem(r.RegNo, r.LDSFiche, r.LDSImage, r.BurialDate, Nothing)
      End If
   End Sub

#End Region

#Region "Marriage Cells"

   Private Sub MarriagesSorter(column As OLVColumn, order As SortOrder)
      Select Case column.AspectName
         Case "MarriageDate"
            dlvMarriages.ListViewItemSorter = New DateColumnComparer(column, order)
         Case Else
            dlvMarriages.ListViewItemSorter = New ColumnComparer(column, order)
      End Select
   End Sub

   Private Sub MarriageCellEditStarting(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvMarriages.CellEditStarting
      If TypeOf e.Control Is System.Windows.Forms.TextBox Then
         If e.Column.AspectName.Contains("Surname") Then
            Dim ucfBox = New ctlTextboxWithUCF()
            ucfBox.CharacterCasing = CharacterCasing.Upper
            ucfBox.SetBounds(e.CellBounds.X - e.CellBounds.Width - 1, e.CellBounds.Y, 0, 0, BoundsSpecified.Location)
            ucfBox.Value = e.Value
            e.Control = ucfBox
         ElseIf e.Column.AspectName = "GroomForenames" OrElse e.Column.AspectName = "BrideForenames" OrElse e.Column.AspectName = "GroomFatherForenames" OrElse e.Column.AspectName = "BrideFatherForenames" OrElse e.Column.AspectName = "Witness1Forenames" OrElse e.Column.AspectName = "Witness2Forenames" Then
            Dim ucfBox = New ctlTextboxWithUCF()
            ucfBox.CharacterCasing = CharacterCasing.Normal
            ucfBox.SetBounds(e.CellBounds.X - e.CellBounds.Width - 1, e.CellBounds.Y, 0, 0, BoundsSpecified.Location)
            ucfBox.Value = e.Value
            e.Control = ucfBox
         ElseIf e.Column.AspectName = "GroomParish" OrElse e.Column.AspectName = "BrideParish" Then
            Dim ucfBox = New ctlTextboxWithUCF()
            ucfBox.CharacterCasing = CharacterCasing.Normal
            ucfBox.SetBounds(e.CellBounds.X - e.CellBounds.Width - 1, e.CellBounds.Y, 0, 0, BoundsSpecified.Location)
            ucfBox.Value = e.Value
            e.Control = ucfBox
         ElseIf e.Column.AspectName = "GroomOccupation" OrElse e.Column.AspectName = "BrideOccupation" OrElse e.Column.AspectName = "GroomFatherOccupation" OrElse e.Column.AspectName = "BrideFatherOccupation" Then
            Dim ucfBox = New ctlTextboxWithUCF()
            ucfBox.CharacterCasing = CharacterCasing.Normal
            ucfBox.SetBounds(e.CellBounds.X - e.CellBounds.Width - 1, e.CellBounds.Y, 0, 0, BoundsSpecified.Location)
            ucfBox.Value = e.Value
            e.Control = ucfBox
         ElseIf e.Column.AspectName = "GroomAbode" OrElse e.Column.AspectName = "BrideAbode" Then
            Dim ucfBox = New ctlTextboxWithUCF()
            ucfBox.CharacterCasing = CharacterCasing.Normal
            ucfBox.SetBounds(e.CellBounds.X - e.CellBounds.Width - 1, e.CellBounds.Y, 0, 0, BoundsSpecified.Location)
            ucfBox.Value = e.Value
            e.Control = ucfBox
         ElseIf e.Column.AspectName = "GroomCondition" Then
            Dim tCtl As TextBox = e.Control
            tCtl.Bounds = e.CellBounds
            tCtl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            tCtl.AutoCompleteSource = AutoCompleteSource.CustomSource
            Dim dt As LookupTables.GroomConditionDataTable = m_TranscriptionFile.LookupTables.GroomCondition
            Dim plist = dt.AsEnumerable().Select(Function(r) r.Field(Of String)("DisplayValue")).ToArray()
            tCtl.AutoCompleteCustomSource.AddRange(plist)
         ElseIf e.Column.AspectName = "BrideCondition" Then
            Dim tCtl As TextBox = e.Control
            tCtl.Bounds = e.CellBounds
            tCtl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            tCtl.AutoCompleteSource = AutoCompleteSource.CustomSource
            Dim dt As LookupTables.BrideConditionDataTable = m_TranscriptionFile.LookupTables.BrideCondition
            Dim plist = dt.AsEnumerable().Select(Function(r) r.Field(Of String)("DisplayValue")).ToArray()
            tCtl.AutoCompleteCustomSource.AddRange(plist)
         Else
            CType(e.Control, System.Windows.Forms.TextBox).BackColor = Color.LightGreen
         End If
      End If
   End Sub

   Private Sub MarriageCellEditValidating(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvMarriages.CellEditValidating
   End Sub

   Private Sub MarriageCellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvMarriages.CellEditFinishing
      If e.Cancel Then Return
      If e.NewValue = e.Value Then
         e.Cancel = True
      Else
         If TypeOf e.Control Is TextBox Then

         ElseIf TypeOf e.Control Is ctlTextboxWithUCF Then
            Select Case e.Column.AspectName
               Case "GroomForenames", "BrideForenames", "GroomFatherForenames", "BrideFatherForenames", "Witness1Forenames", "Witness2Forenames"
                  Dim culture As CultureInfo = Thread.CurrentThread.CurrentCulture
                  Dim tinfo As TextInfo = culture.TextInfo()
                  e.NewValue = tinfo.ToTitleCase(e.NewValue)
               Case "GroomParish", "BrideParish"
                  Dim culture As CultureInfo = Thread.CurrentThread.CurrentCulture
                  Dim tinfo As TextInfo = culture.TextInfo()
                  e.NewValue = tinfo.ToTitleCase(e.NewValue)
               Case "GroomOccupation", "BrideOccupation", "GroomFatherOccupation", "BrideFatherOccupation"
                  Dim culture As CultureInfo = Thread.CurrentThread.CurrentCulture
                  Dim tinfo As TextInfo = culture.TextInfo()
                  e.NewValue = tinfo.ToTitleCase(e.NewValue)
               Case "GroomAbode", "BrideAbode"
                  Dim culture As CultureInfo = Thread.CurrentThread.CurrentCulture
                  Dim tinfo As TextInfo = culture.TextInfo()
                  e.NewValue = tinfo.ToTitleCase(e.NewValue)
               Case Else
            End Select
            e.Control.Dispose()
         End If
      End If
   End Sub

   Private Sub MarriageCellEditFinished(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvMarriages.CellEditFinished
      If e.Column.AspectName = "Notes" Then
         Dim x As DataRowView = e.RowObject
         Dim r As TranscriptionTables.MarriagesRow = x.Row
         If r.Table.Rows.Count = r.LoadOrder + 1 Then AddNewItem(r.RegNo, r.LDSFiche, r.LDSImage, r.MarriageDate, Nothing)
      End If
   End Sub

#End Region

#Region "AddnewItem"

   Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
      Select Case m_TranscriptionFile.FileHeader.FileType
         Case TranscriptionFileClass.FileTypes.BAPTISMS
            Dim currentrecord As WinFreeReg.TranscriptionTables.BaptismsRow = dlvBaptisms.SelectedItem.RowObject.row
            AddNewItem(currentrecord.RegNo, currentrecord.LDSFiche, currentrecord.LDSImage, currentrecord.BirthDate, currentrecord.BaptismDate)
         Case TranscriptionFileClass.FileTypes.BURIALS
            Dim currentrecord As WinFreeReg.TranscriptionTables.BurialsRow = dlvBaptisms.SelectedItem.RowObject.row
            AddNewItem(currentrecord.RegNo, currentrecord.LDSFiche, currentrecord.LDSImage, currentrecord.BurialDate, Nothing)
         Case TranscriptionFileClass.FileTypes.MARRIAGES
            Dim currentrecord As WinFreeReg.TranscriptionTables.MarriagesRow = dlvBaptisms.SelectedItem.RowObject.row
            AddNewItem(currentrecord.RegNo, currentrecord.LDSFiche, currentrecord.LDSImage, currentrecord.MarriageDate, Nothing)
      End Select
   End Sub

   Private Sub AddNewItem(regno As String, ldsfiche As String, ldsimage As String, date1 As String, date2 As String)
      Select Case m_TranscriptionFile.FileHeader.FileType
         Case TranscriptionFileClass.FileTypes.BAPTISMS
            Dim visibleColumns = dlvBaptisms.ColumnsInDisplayOrder()
            Dim dt As TranscriptionTables.BaptismsDataTable = CType(bsBaptisms.DataSource, TranscriptionTables.BaptismsDataTable)
            Dim row As TranscriptionTables.BaptismsRow = dt.NewRow()
            row.County = m_TranscriptionFile.FileHeader.County()
            row.Place = m_TranscriptionFile.FileHeader.Place()
            row.Church = m_TranscriptionFile.FileHeader.Church()
            If visibleColumns.Contains(olvcRegNo) Then row.RegNo = IIf(My.Settings.optionAutoIncrementRegisterNumber, NextInSequence(regno), "")
            If My.Settings.optionReplicateFicheImage Then
               If visibleColumns.Contains(olvcFiche) Then row.LDSFiche = ldsfiche
               If visibleColumns.Contains(olvcImage) Then row.LDSImage = ldsimage
            End If
            If My.Settings.optionReplicateDates Then
               If visibleColumns.Contains(olvcBirthDate) Then row.BirthDate = date1
               If visibleColumns.Contains(olvcBaptismDate) Then row.BaptismDate = date2
            End If
            dt.AddBaptismsRow(row)

            Dim model = dt.DefaultView.Item(row.LoadOrder)
            dlvBaptisms.EnsureModelVisible(model)
            dlvBaptisms.SelectObject(model, True)
            dlvBaptisms.Select()

         Case TranscriptionFileClass.FileTypes.BURIALS
            Dim visibleColumns = dlvBurials.ColumnsInDisplayOrder()
            Dim dt As TranscriptionTables.BurialsDataTable = CType(bsBurials.DataSource, TranscriptionTables.BurialsDataTable)
            Dim row As TranscriptionTables.BurialsRow = dt.NewRow()
            row.County = m_TranscriptionFile.FileHeader.County()
            row.Place = m_TranscriptionFile.FileHeader.Place()
            row.Church = m_TranscriptionFile.FileHeader.Church()
            If visibleColumns.Contains(olvcRegNo1) Then row.RegNo = IIf(My.Settings.optionAutoIncrementRegisterNumber, NextInSequence(regno), "")
            If My.Settings.optionReplicateFicheImage Then
               If visibleColumns.Contains(olvcFiche1) Then row.LDSFiche = ldsfiche
               If visibleColumns.Contains(olvcImage1) Then row.LDSImage = ldsimage
            End If
            If My.Settings.optionReplicateDates Then
               If visibleColumns.Contains(olvcBurialDate) Then row.BurialDate = date1
            End If
            dt.AddBurialsRow(row)

            Dim model = dt.DefaultView.Item(row.LoadOrder)
            dlvBurials.EnsureModelVisible(model)
            dlvBurials.SelectObject(model, True)
            dlvBurials.Select()

         Case TranscriptionFileClass.FileTypes.MARRIAGES
            Dim visibleColumns = dlvMarriages.ColumnsInDisplayOrder()
            Dim dt As TranscriptionTables.MarriagesDataTable = CType(bsMarriages.DataSource, TranscriptionTables.MarriagesDataTable)
            Dim row As TranscriptionTables.MarriagesRow = dt.NewRow()
            row.County = m_TranscriptionFile.FileHeader.County()
            row.Place = m_TranscriptionFile.FileHeader.Place()
            row.Church = m_TranscriptionFile.FileHeader.Church()
            If visibleColumns.Contains(olvcRegNo2) Then row.RegNo = IIf(My.Settings.optionAutoIncrementRegisterNumber, NextInSequence(regno), "")
            If My.Settings.optionReplicateFicheImage Then
               If visibleColumns.Contains(olvcFiche2) Then row.LDSFiche = ldsfiche
               If visibleColumns.Contains(olvcImage2) Then row.LDSImage = ldsimage
            End If
            If My.Settings.optionReplicateDates Then
               If visibleColumns.Contains(olvcMarriageDate) Then row.MarriageDate = date1
            End If
            dt.AddMarriagesRow(row)

            Dim model = dt.DefaultView.Item(row.LoadOrder)
            dlvMarriages.EnsureModelVisible(model)
            dlvMarriages.SelectObject(model, True)
            dlvMarriages.Select()

      End Select
   End Sub

   Private Function NextInSequence(ByVal regno As String) As String
      Dim x As Integer
      If Integer.TryParse(regno, x) Then
         x += 1
         Return x.ToString()
      End If
      Return regno
   End Function

#End Region

   Private Sub BindingNavigatorSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorSaveFile.Click

      Select Case m_TranscriptionFile.FileHeader.FileType
         Case TranscriptionFileClass.FileTypes.BAPTISMS
            Dim dt As TranscriptionTables.BaptismsDataTable = CType(bsBaptisms.DataSource, TranscriptionTables.BaptismsDataTable)
            Dim dChanges = dt.GetChanges()
            If dChanges IsNot Nothing Then dt.AcceptChanges()

         Case TranscriptionFileClass.FileTypes.BURIALS
            Dim dt As TranscriptionTables.BurialsDataTable = CType(bsBurials.DataSource, TranscriptionTables.BurialsDataTable)
            Dim dChanges = dt.GetChanges()
            If dChanges IsNot Nothing Then dt.AcceptChanges()

         Case TranscriptionFileClass.FileTypes.MARRIAGES
            Dim dt As TranscriptionTables.MarriagesDataTable = CType(bsMarriages.DataSource, TranscriptionTables.MarriagesDataTable)
            Dim dChanges = dt.GetChanges()
            If dChanges IsNot Nothing Then dt.AcceptChanges()
      End Select

      m_TranscriptionFile.Save()

   End Sub

   Private Sub BindingNavigatorFileDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorFileDetails.Click
      Using dlg As New formFileDetails(formHelp) With {.TranscriptionFile = m_TranscriptionFile}
         Dim rc = dlg.ShowDialog()
         If rc = Windows.Forms.DialogResult.OK Then
            If dlg.HeaderChanged Then m_TranscriptionFile.Save()
         End If
      End Using
   End Sub

   Private Sub FormatErrorRow(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.FormatRowEventArgs) Handles dlvBaptisms.FormatRow, dlvBurials.FormatRow, dlvMarriages.FormatRow
      Dim row = CType(e.Model, DataRowView).Row
      '      If row.HasErrors Then e.UseCellFormatEvents = True
      e.UseCellFormatEvents = True
   End Sub

   Private Sub FormatErrorCell(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.FormatCellEventArgs) Handles dlvBaptisms.FormatCell, dlvBurials.FormatCell, dlvMarriages.FormatCell
      Dim row = CType(e.Model, DataRowView).Row

      If row.RowState = DataRowState.Modified Then
         Dim x = row(e.Column.AspectName, DataRowVersion.Current)
         Dim y = row(e.Column.AspectName, DataRowVersion.Original)
         If x <> y Then
            e.SubItem.BackColor = Color.LightPink
         End If
      End If

      Dim cols = row.GetColumnsInError()
      If cols IsNot Nothing Then
         For Each col In cols
            If col.ColumnName = e.Column.AspectName Then
               Dim cbd As CellBorderDecoration = New CellBorderDecoration()
               cbd.FillBrush = Nothing
               cbd.CornerRounding = 0.0
               Dim err = row.GetColumnError(col.ColumnName)
               If err.Contains("Warning:") Then
                  cbd.BorderPen = Pens.Gold
                  e.SubItem.BackColor = Color.Wheat
               Else
                  cbd.BorderPen = Pens.Red
                  e.SubItem.BackColor = Color.LavenderBlush
               End If
               e.SubItem.Decoration = cbd
               Exit For
            End If
         Next
      End If
   End Sub

   Private Sub ShowCellErrorInformation(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.ToolTipShowingEventArgs) Handles dlvBaptisms.CellToolTipShowing, dlvBurials.CellToolTipShowing, dlvMarriages.CellToolTipShowing
      Dim row = CType(e.Model, DataRowView).Row
      If row.HasErrors Then
         Dim cols = row.GetColumnsInError()
         If cols IsNot Nothing Then
            For Each col In cols
               If col.ColumnName = e.Column.AspectName Then
                  Dim err = row.GetColumnError(col.ColumnName).Split(New Char() {":"}, 2)
                  e.BackColor = Color.Bisque
                  e.IsBalloon = True
                  e.StandardIcon = ToolTipControl.StandardIcons.ErrorLarge
                  If err(0) = "????" Then
                     e.Title = err(1)
                     e.Text = My.Resources.msgError
                  Else
                     Dim v As Integer
                     If Integer.TryParse(err(0), v) Then
                        Dim msg As ErrorMessages.ErrorMessagesRow = m_ErrorMessageTable.FindByNumber(v)
                        If msg Is Nothing Then
                           e.Title = err(1)
                           e.Text = err(0)
                        Else
                           e.Title = msg.Message
                           Try
                              If Not DBNull.Value.Equals(msg.Item("Explanation")) Then
                                 e.Text = WordWrap(msg.Explanation, 50)
                              Else
                                 e.Text = " "
                              End If

                           Catch ex As Exception
                              e.Text = " "
                           End Try
                        End If
                     End If
                  End If
                  Exit For
               End If
            Next
         End If
      End If
   End Sub

   Private Function WordWrap(ByVal text As String, ByVal CharsPerLine As Integer) As String
      Dim output As String = ""
      Dim words As String() = text.Split(New String() {" ", vbLf}, StringSplitOptions.RemoveEmptyEntries)
      Dim lineBuilder As New StringBuilder(CharsPerLine)
      For Each word As String In words
         If ((lineBuilder.Length + word.Length) > CharsPerLine) OrElse word.StartsWith(vbCr) Then
            output += lineBuilder.ToString() + vbCrLf
            lineBuilder.Remove(0, lineBuilder.Length)
            word = word.Replace("\r", String.Empty)
         End If
         lineBuilder.Append(word).Append(" ")
      Next
      output += lineBuilder.ToString()
      Return output
   End Function

   Private Sub miGeneralHelp_Click(sender As Object, e As EventArgs) Handles miGeneralHelp.Click
      Try
         formHelp.Title = "File Workspace"
         formHelp.StartPage = "FileWorkspace.html"
         formHelp.Show()

      Catch ex As Exception
         formHelp.Hide()
         MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try
   End Sub

   Private Sub dlvBaptisms_CellRightClick(sender As Object, e As CellRightClickEventArgs) Handles dlvBaptisms.CellRightClick
      If e.Model Is Nothing Then Return
      Beep()
      e.MenuStrip = baptismsContextMenuStrip
   End Sub

   Private Sub dlvBurials_CellRightClick(sender As Object, e As CellRightClickEventArgs) Handles dlvBurials.CellRightClick
      If e.Model Is Nothing Then Return
      Beep()
      e.MenuStrip = burialsContextMenuStrip
   End Sub

   Private Sub dlvMarriages_CellRightClick(sender As Object, e As CellRightClickEventArgs) Handles dlvMarriages.CellRightClick
      If e.Model Is Nothing Then Return
      Beep()
      e.MenuStrip = marriagesContextMenuStrip
   End Sub

   Private Sub FreeREGTablesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles bapFreeREGTablesToolStripMenuItem.Click, marFreeREGTablesToolStripMenuItem.Click, burFreeREGTablesToolStripMenuItem.Click
      Using dlg As New formFreeregTables(formHelp) With {.DataSet = m_TranscriptionFile.FreeregTables, .Settings = Settings, .DefaultCounty = DefaultCounty}
         dlg.ShowDialog()
         If dlg.IsChanged Then
            m_TranscriptionFile.FreeregTables.WriteXml(FreeregTablesFile, XmlWriteMode.WriteSchema)
         End If
      End Using
   End Sub

   Private Sub BurialRelationshipsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BurialRelationshipsToolStripMenuItem.Click
      Using dlg As New formUserTables(formHelp) With {.LookupTables = m_TranscriptionFile.LookupTables, .LookupsFilename = UserTablesFile}
         dlg.ShowTable(formUserTables.TableType.BurialRelationships)
         dlg.ShowDialog()
      End Using
   End Sub

   Private Sub GroomConditionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GroomConditionsToolStripMenuItem.Click
      Using dlg As New formUserTables(formHelp) With {.LookupTables = m_TranscriptionFile.LookupTables, .LookupsFilename = UserTablesFile}
         dlg.ShowTable(formUserTables.TableType.GroomConditions)
         dlg.ShowDialog()
      End Using
   End Sub

   Private Sub BrideConditionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrideConditionsToolStripMenuItem.Click
      Using dlg As New formUserTables(formHelp) With {.LookupTables = m_TranscriptionFile.LookupTables, .LookupsFilename = UserTablesFile}
         dlg.ShowTable(formUserTables.TableType.BrideConditions)
         dlg.ShowDialog()
      End Using
   End Sub

   Private Function ConvertToSentenceCase(ByVal str As String) As String
      Dim sentenceRegex = New Regex("(^[a-z])|[?!.:,;]\s+(.)", RegexOptions.ExplicitCapture)
      Return sentenceRegex.Replace(str.ToLower(), Function(s) s.Value.ToUpper())
   End Function

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Select Case keyData

         ' Hotkey - Ctrl-S - Save File
         '
         Case Keys.Control Or Keys.S
            BindingNavigatorSaveFile.PerformClick()
            Return True

            ' Hotkey - Ctrl-D - Duplicate current record
            '
         Case Keys.Control Or Keys.D
            DuplicateRecord()
            Return True

            ' Hotkey - Alt-X - Delete current record
            '
         Case Keys.Alt Or Keys.X
            DeleteRecord()
            Return True
      End Select

      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#Region "Duplicate Record"

   Private Sub DuplicateRecordMenuItem_Click(sender As Object, e As EventArgs) Handles bapDuplicateRecordMenuItem.Click, marDuplicateRecordMenuItem.Click, burDuplicateRecordMenuItem.Click
      DuplicateRecord()
   End Sub

   Private Sub DuplicateRecord()
      Select Case m_TranscriptionFile.FileHeader.FileType
         Case TranscriptionFileClass.FileTypes.BAPTISMS
            ' Get the currently selected object
            Dim x As DataRowView = dlvBaptisms.SelectedObject()
            If x IsNot Nothing Then
               ' Get the currently selected Baptisms row
               Dim row As TranscriptionTables.BaptismsRow = x.Row
               ' Create a new, empty row
               Dim dt As TranscriptionTables.BaptismsDataTable = CType(bsBaptisms.DataSource, TranscriptionTables.BaptismsDataTable)
               Dim newrow As TranscriptionTables.BaptismsRow = dt.NewRow()
               newrow.County = row.County
               newrow.Place = row.Place
               newrow.Church = row.Church
               newrow.RegNo = row.RegNo
               newrow.BirthDate = row.BirthDate
               newrow.BaptismDate = row.BaptismDate
               newrow.Forenames = row.Forenames
               newrow.Sex = row.Sex
               newrow.FathersName = row.FathersName
               newrow.FathersSurname = row.FathersSurname
               newrow.FathersOccupation = row.FathersOccupation
               newrow.MothersName = row.MothersName
               newrow.MothersSurname = row.MothersSurname
               newrow.Abode = row.Abode
               newrow.Notes = row.Notes
               newrow.LDSFiche = row.LDSFiche
               newrow.LDSImage = row.LDSImage

               dt.AddBaptismsRow(newrow)
               Dim model = dt.DefaultView.Item(newrow.LoadOrder)
               dlvBaptisms.EnsureModelVisible(model)
               dlvBaptisms.SelectObject(model, True)
               dlvBaptisms.Select()
            End If

         Case TranscriptionFileClass.FileTypes.BURIALS
            ' Get the currently selected object
            Dim x As DataRowView = dlvBurials.SelectedObject()
            If x IsNot Nothing Then
               ' Get the currently selected Burials row
               Dim row As TranscriptionTables.BurialsRow = x.Row
               ' Create a new, empty row
               Dim dt As TranscriptionTables.BurialsDataTable = CType(bsBurials.DataSource, TranscriptionTables.BurialsDataTable)
               Dim newrow As TranscriptionTables.BurialsRow = dt.NewRow()
               newrow.County = row.County
               newrow.Place = row.Place
               newrow.Church = row.Church
               newrow.RegNo = row.RegNo
               newrow.BurialDate = row.BurialDate
               newrow.Forenames = row.Forenames
               newrow.Surname = row.Surname
               newrow.Age = row.Age
               newrow.Relationship = row.Relationship
               newrow.MaleForenames = row.MaleForenames
               newrow.FemaleForenames = row.FemaleForenames
               newrow.RelativeSurname = row.RelativeSurname
               newrow.Abode = row.Abode
               newrow.Notes = row.Notes
               newrow.LDSFiche = row.LDSFiche
               newrow.LDSImage = row.LDSImage
               dt.AddBurialsRow(newrow)
               Dim model = dt.DefaultView.Item(newrow.LoadOrder)
               dlvBurials.EnsureModelVisible(model)
               dlvBurials.SelectObject(model, True)
               dlvBurials.Select()
            End If

         Case TranscriptionFileClass.FileTypes.MARRIAGES
            ' Get the currently selected object
            Dim x As DataRowView = dlvMarriages.SelectedObject()
            If x IsNot Nothing Then
               ' Get the currently selected Marriages row
               Dim row As TranscriptionTables.MarriagesRow = x.Row
               ' Create a new, empty row
               Dim dt As TranscriptionTables.MarriagesDataTable = CType(bsMarriages.DataSource, TranscriptionTables.MarriagesDataTable)
               Dim newrow As TranscriptionTables.MarriagesRow = dt.NewRow()
               newrow.County = row.County
               newrow.Place = row.Place
               newrow.Church = row.Church
               newrow.RegNo = row.RegNo
               newrow.MarriageDate = row.MarriageDate
               newrow.GroomForenames = row.GroomForenames
               newrow.GroomSurname = row.GroomSurname
               newrow.GroomAge = row.GroomAge
               newrow.GroomCondition = row.GroomCondition
               newrow.GroomOccupation = row.GroomOccupation
               newrow.GroomAbode = row.GroomAbode
               newrow.GroomParish = row.GroomParish
               newrow.BrideForenames = row.BrideForenames
               newrow.BrideSurname = row.BrideSurname
               newrow.BrideAge = row.BrideAge
               newrow.BrideCondition = row.BrideCondition
               newrow.BrideOccupation = row.BrideOccupation
               newrow.BrideAbode = row.BrideAbode
               newrow.BrideParish = row.BrideParish
               newrow.GroomFatherForenames = row.GroomFatherForenames
               newrow.GroomFatherSurname = row.GroomFatherSurname
               newrow.GroomFatherOccupation = row.GroomFatherOccupation
               newrow.BrideFatherForenames = row.BrideFatherForenames
               newrow.BrideFatherSurname = row.BrideFatherSurname
               newrow.BrideFatherOccupation = row.BrideFatherOccupation
               newrow.Witness1Forenames = row.Witness1Forenames
               newrow.Witness1Surname = row.Witness1Surname
               newrow.Witness2Forenames = row.Witness2Forenames
               newrow.Witness2Surname = row.Witness2Surname
               newrow.Notes = row.Notes
               newrow.LDSFiche = row.LDSFiche
               newrow.LDSImage = row.LDSImage
               dt.AddMarriagesRow(newrow)
               Dim model = dt.DefaultView.Item(newrow.LoadOrder)
               dlvMarriages.EnsureModelVisible(model)
               dlvMarriages.SelectObject(model, True)
               dlvMarriages.Select()
            End If

      End Select
   End Sub

#End Region

#Region "Delete Record"

   ' TODO: 15. Delete functions are incomplete

   Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorDeleteItem.Click
      DeleteRecord()
   End Sub

   Private Sub DeleteRecord()
      Select Case m_TranscriptionFile.FileHeader.FileType
         Case TranscriptionFileClass.FileTypes.BAPTISMS
            ' Get the currently selected object
            Dim x As DataRowView = dlvBaptisms.SelectedObject()
            If x IsNot Nothing Then dlvBaptisms.RemoveObject(x)

         Case TranscriptionFileClass.FileTypes.BURIALS
            ' Get the currently selected object
            Dim x As DataRowView = dlvBurials.SelectedObject()
            If x IsNot Nothing Then dlvBurials.RemoveObject(x)

         Case TranscriptionFileClass.FileTypes.MARRIAGES
            ' Get the currently selected object
            Dim x As DataRowView = dlvMarriages.SelectedObject()
            If x IsNot Nothing Then dlvMarriages.RemoveObject(x)

      End Select
   End Sub

   Private Sub DeleteRecordMenuItem_Click(sender As Object, e As EventArgs) Handles marDeleteRecordMenuItem.Click, burDeleteRecordMenuItem.Click, bapDeleteRecordMenuItem.Click
      DeleteRecord()
   End Sub

#End Region

End Class