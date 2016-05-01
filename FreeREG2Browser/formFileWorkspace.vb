Imports BrightIdeasSoftware
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing
Imports System.Text

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

	Private m_fname As String
	Private m_dlvStates()() As Byte = New Byte(3)() {}

	Private Sub SaveDLVState(ByVal [enum] As TranscriptionFileClass.FileTypes, ByVal state As Byte())
		m_dlvStates([enum]) = state
	End Sub

	Sub New()

		' This call is required by the Windows Form Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		m_dlvStates(TranscriptionFileClass.FileTypes.BAPTISMS) = dlvBaptisms.SaveState()
		m_dlvStates(TranscriptionFileClass.FileTypes.BURIALS) = dlvBurials.SaveState()
		m_dlvStates(TranscriptionFileClass.FileTypes.MARRIAGES) = dlvMarriages.SaveState()
	End Sub

	Private Sub formFileDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Dim title = String.Format(Me.Text, m_Row("Name"))
		Me.Text = title

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
				BindingNavigator1.BindingSource = bsBaptisms
				If m_TranscriptionFile.FileHeader.isLDS Then
					olvcFiche.IsVisible = True
					olvcImage.IsVisible = True
				Else
					olvcFiche.IsVisible = False
					olvcImage.IsVisible = False
				End If
				olvcSex.AspectToStringConverter = AddressOf SexDescription
				dlvBaptisms.RebuildColumns()
				dlvBaptisms.AddDecoration(New EditingCellBorderDecoration(True))
				dlvBaptisms.Visible = True

			Case TranscriptionFileClass.FileTypes.BURIALS
				Dim dt As TranscriptionTables.BurialsDataTable = TranscriptionFile.Items
				bsBurials.DataSource = dt
				BindingNavigator1.BindingSource = bsBurials
				If m_TranscriptionFile.FileHeader.isLDS Then
					olvcFiche1.IsVisible = True
					olvcImage1.IsVisible = True
				Else
					olvcFiche1.IsVisible = False
					olvcImage1.IsVisible = False
				End If
				olvcRelationship.AspectToStringConverter = AddressOf RelationshipDescription
				dlvBurials.RebuildColumns()
				dlvBurials.AddDecoration(New EditingCellBorderDecoration(True))
				dlvBurials.Visible = True

			Case TranscriptionFileClass.FileTypes.MARRIAGES
				Dim dt As TranscriptionTables.MarriagesDataTable = TranscriptionFile.Items
				bsMarriages.DataSource = dt
				BindingNavigator1.BindingSource = bsMarriages
				If m_TranscriptionFile.FileHeader.isLDS Then
					olvcFiche2.IsVisible = True
					olvcImage2.IsVisible = True
				Else
					olvcFiche2.IsVisible = False
					olvcImage2.IsVisible = False
				End If
				olvcGroomCondition.AspectToStringConverter = AddressOf GroomConditionDescription
				olvcBrideCondition.AspectToStringConverter = AddressOf BrideConditionDescription
				dlvMarriages.RebuildColumns()
				dlvMarriages.AddDecoration(New EditingCellBorderDecoration(True))
				dlvMarriages.Visible = True

		End Select

	End Sub

	Private Function SexDescription(ByVal model As Object) As String
		Dim x = m_TranscriptionFile.LookupTables.BaptismSex.FindByCode(CType(model, String))
		If x Is Nothing Then
			Return "Unknown?"
		End If
		Return x.Description
	End Function

	Private Function RelationshipDescription(ByVal model As Object) As String
		Dim x = m_TranscriptionFile.LookupTables.BurialRelationship.FindByFileValue(CType(model, String))
		Return x.DisplayValue
	End Function

	Private Function GroomConditionDescription(ByVal model As Object) As String
		Dim x = m_TranscriptionFile.LookupTables.GroomCondition.FindByFileValue(CType(model, String))
		Return x.DisplayValue
	End Function

	Private Function BrideConditionDescription(ByVal model As Object) As String
		Dim x = m_TranscriptionFile.LookupTables.BrideCondition.FindByFileValue(CType(model, String))
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

					Using dlg As New formTablesErrors() With {.Lookups = m_TranscriptionFile.LookupTables}
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

					Using dlg As New formTablesErrors() With {.Lookups = m_TranscriptionFile.LookupTables}
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

					Using dlg As New formTablesErrors() With {.Lookups = m_TranscriptionFile.LookupTables}
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

						End Try
					End Using
				End If

		End Select
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

		End Try

	End Sub

	Private Sub CellEditStarting(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvBaptisms.CellEditStarting, dlvBurials.CellEditStarting, dlvMarriages.CellEditStarting
		If e.Column.AspectName.Contains("Surname") Then
			If TypeOf e.Control Is System.Windows.Forms.TextBox Then
				CType(e.Control, System.Windows.Forms.TextBox).CharacterCasing = CharacterCasing.Upper
			End If
		Else
			Select Case e.Column.AspectName
				Case "Sex"
					Dim ctl = New ComboBox()
					ctl.SetBounds(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height)
					ctl.DataSource = m_TranscriptionFile.LookupTables.BaptismSex
					ctl.DisplayMember = "Description"
					ctl.ValueMember = "Code"
					ctl.AutoCompleteMode = AutoCompleteMode.Suggest
					ctl.AutoCompleteSource = AutoCompleteSource.ListItems
					e.Control = ctl

				Case "Relationship"
					Dim ctl = New ComboBox()
					ctl.SetBounds(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height)
					ctl.DataSource = m_TranscriptionFile.LookupTables.BurialRelationship
					ctl.DisplayMember = "DisplayValue"
					ctl.ValueMember = "FileValue"
					ctl.AutoCompleteMode = AutoCompleteMode.Suggest
					ctl.AutoCompleteSource = AutoCompleteSource.ListItems
					e.Control = ctl

				Case "GroomCondition"
					Dim ctl = New ComboBox()
					ctl.SetBounds(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height)
					ctl.DataSource = m_TranscriptionFile.LookupTables.GroomCondition
					ctl.DisplayMember = "DisplayValue"
					ctl.ValueMember = "FileValue"
					ctl.AutoCompleteMode = AutoCompleteMode.Suggest
					ctl.AutoCompleteSource = AutoCompleteSource.ListItems
					e.Control = ctl

				Case "BrideCondition"
					Dim ctl = New ComboBox()
					ctl.SetBounds(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height)
					ctl.DataSource = m_TranscriptionFile.LookupTables.BrideCondition
					ctl.DisplayMember = "DisplayValue"
					ctl.ValueMember = "FileValue"
					ctl.AutoCompleteMode = AutoCompleteMode.Suggest
					ctl.AutoCompleteSource = AutoCompleteSource.ListItems
					e.Control = ctl
			End Select
		End If
	End Sub

	Private Sub dlvBaptisms_CellEditValidating(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvBaptisms.CellEditValidating
		'		Console.WriteLine(String.Format("Validating: {0}", e.Column.AspectName))
	End Sub

	Private Sub dlvBaptisms_CellEditFinishing(ByVal sender As Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvBaptisms.CellEditFinishing
		'		Console.WriteLine(String.Format(" Finishing: {0}", e.Column.AspectName))
	End Sub

	Private Sub CellEditFinished(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.CellEditEventArgs) Handles dlvBurials.CellEditFinished, dlvMarriages.CellEditFinished, dlvBaptisms.CellEditFinished
		'Console.WriteLine(String.Format("  Finished: {0}", e.Column.AspectName))
		'Select Case m_TranscriptionFile.FileHeader.FileType
		'	Case TranscriptionFileClass.FileTypes.BAPTISMS
		'		Dim row As TranscriptionTables.BaptismsRow = CType(e.RowObject.Row, TranscriptionTables.BaptismsRow)
		'		If row.HasErrors Then
		'			Dim errStr = row.GetColumnsInError().ToLookup(Function(a) a.ColumnName)
		'			If errStr.Contains(e.Column.AspectName) Then
		'				e.ListViewItem.UseItemStyleForSubItems = False
		'				e.ListViewItem.SubItems(e.SubItemIndex).BackColor = Drawing.Color.Red
		'			End If
		'		End If

		'	Case TranscriptionFileClass.FileTypes.BURIALS
		'			Dim row As TranscriptionTables.BurialsRow = CType(e.RowObject.Row, TranscriptionTables.BurialsRow)
		'			If row.HasErrors Then
		'				Dim errStr = row.GetColumnsInError().ToLookup(Function(a) a.ColumnName)
		'				If errStr.Contains(e.Column.AspectName) Then
		'					e.ListViewItem.UseItemStyleForSubItems = False
		'					e.ListViewItem.SubItems(e.SubItemIndex).BackColor = Drawing.Color.Red
		'				End If
		'			End If

		'	Case TranscriptionFileClass.FileTypes.MARRIAGES
		'			Dim row As TranscriptionTables.MarriagesRow = CType(e.RowObject.Row, TranscriptionTables.MarriagesRow)
		'			If row.HasErrors Then
		'				Dim errStr = row.GetColumnsInError().ToLookup(Function(a) a.ColumnName)
		'				If errStr.Contains(e.Column.AspectName) Then
		'					e.ListViewItem.UseItemStyleForSubItems = False
		'					e.ListViewItem.SubItems(e.SubItemIndex).BackColor = Drawing.Color.Red
		'				End If
		'			End If

		'End Select
	End Sub

	Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
		Select Case m_TranscriptionFile.FileHeader.FileType
			Case TranscriptionFileClass.FileTypes.BAPTISMS
				Dim dt As TranscriptionTables.BaptismsDataTable = CType(bsBaptisms.DataSource, TranscriptionTables.BaptismsDataTable)
				Dim row As TranscriptionTables.BaptismsRow = dt.NewRow()
				row.County = m_TranscriptionFile.FileHeader.County()
				row.Place = m_TranscriptionFile.FileHeader.Place()
				row.Church = m_TranscriptionFile.FileHeader.Church()
				dt.AddBaptismsRow(row)

				Dim model = dt.DefaultView.Item(row.LoadOrder)
				dlvBaptisms.EnsureModelVisible(model)
				dlvBaptisms.SelectObject(model, True)
				dlvBaptisms.Select()

			Case TranscriptionFileClass.FileTypes.BURIALS
				Dim dt As TranscriptionTables.BurialsDataTable = CType(bsBurials.DataSource, TranscriptionTables.BurialsDataTable)
				Dim row As TranscriptionTables.BurialsRow = dt.NewRow()
				row.County = m_TranscriptionFile.FileHeader.County()
				row.Place = m_TranscriptionFile.FileHeader.Place()
				row.Church = m_TranscriptionFile.FileHeader.Church()
				dt.AddBurialsRow(row)

				Dim model = dt.DefaultView.Item(row.LoadOrder)
				dlvBurials.EnsureModelVisible(model)
				dlvBurials.SelectObject(model, True)
				dlvBurials.Select()

			Case TranscriptionFileClass.FileTypes.MARRIAGES
				Dim dt As TranscriptionTables.MarriagesDataTable = CType(bsMarriages.DataSource, TranscriptionTables.MarriagesDataTable)
				Dim row As TranscriptionTables.MarriagesRow = dt.NewRow()
				row.County = m_TranscriptionFile.FileHeader.County()
				row.Place = m_TranscriptionFile.FileHeader.Place()
				row.Church = m_TranscriptionFile.FileHeader.Church()
				dt.AddMarriagesRow(row)

				Dim model = dt.DefaultView.Item(row.LoadOrder)
				dlvMarriages.EnsureModelVisible(model)
				dlvMarriages.SelectObject(model, True)
				dlvMarriages.Select()

		End Select
	End Sub

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
		Using dlg As New formFileDetails() With {.TranscriptionFile = m_TranscriptionFile}
			dlg.ShowDialog()
		End Using
	End Sub

	Private Sub FormatErrorRow(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.FormatRowEventArgs) Handles dlvBaptisms.FormatRow, dlvMarriages.FormatRow, dlvBurials.FormatRow
		Dim row = CType(e.Model, DataRowView).Row
		If row.HasErrors Then e.UseCellFormatEvents = True
	End Sub

	Private Sub FormatErrorCell(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.FormatCellEventArgs) Handles dlvBaptisms.FormatCell, dlvMarriages.FormatCell, dlvBurials.FormatCell
		Dim row = CType(e.Model, DataRowView).Row
		Dim cols = row.GetColumnsInError()
		If cols IsNot Nothing Then
			For Each col In cols
				If col.ColumnName = e.Column.AspectName Then
					Dim err = row.GetColumnError(col.ColumnName)
					If err.Contains("Warning:") Then
						e.SubItem.BackColor = Drawing.Color.Gold
					Else
						e.SubItem.BackColor = Drawing.Color.Red
					End If
				End If
			Next
		End If
	End Sub

	Private Sub ShowCellErrorInformation(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.ToolTipShowingEventArgs) Handles dlvBaptisms.CellToolTipShowing, dlvMarriages.CellToolTipShowing, dlvBurials.CellToolTipShowing
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

End Class