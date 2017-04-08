Imports System.Windows.Forms

Public Class formMissingDetails

	Property TranscriptionFile As TranscriptionFileClass

	Property Tables As FreeregTables

	Property FormHelp As formGeneralHelp

	Private Sub formMissingDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		TranscriptionFile.FileCorrected = False
		Dim msg = String.Format("Unable to find Church record for County:{0} Place:{1} Church:{2}", TranscriptionFile.FileHeader.County, TranscriptionFile.FileHeader.Place, TranscriptionFile.FileHeader.Church)
		labelMessage.Text = msg
		textMessage.Text = String.Empty

		Try
			Dim rowCounty = Tables.Counties.FindByChapmanCode(TranscriptionFile.FileHeader.County)
			CountiesBindingSource.DataSource = Tables
			If rowCounty Is Nothing Then
				textCounty.Text = String.Format("{0} - <Not found>", TranscriptionFile.FileHeader.County)
				textCounty.ForeColor = Drawing.Color.Red
			Else
				textCounty.Text = String.Format("{0} - {1}", rowCounty.ChapmanCode, rowCounty.CountyName)
				countiesComboBox.SelectedIndex = countiesComboBox.FindString(TranscriptionFile.FileHeader.County)

				Dim ChurchesInCounty() = Tables.Counties.FindByChapmanCode(rowCounty.ChapmanCode).GetChildRows("ChurchesInCounty")
				If ChurchesInCounty.Length > 0 Then
					Dim dtChurchesInCounty = ChurchesInCounty.CopyToDataTable()
					Dim dtPlacesWithChurchesInCounty = dtChurchesInCounty.DefaultView.ToTable(True, "PlaceName")
					PlacesBindingSource.DataSource = dtPlacesWithChurchesInCounty
					ChurchesBindingSource.DataSource = dtChurchesInCounty
				End If
			End If

			Dim rowPlace = Tables.Places.FindByPlaceNameChapmanCode(TranscriptionFile.FileHeader.Place, TranscriptionFile.FileHeader.County)
			textPlace.Text = TranscriptionFile.FileHeader.Place
			If rowPlace Is Nothing Then
				textPlace.ForeColor = Drawing.Color.Red
			Else
				placesComboBox.SelectedIndex = placesComboBox.FindString(TranscriptionFile.FileHeader.Place)
				If placesComboBox.SelectedIndex = -1 Then
					textMessage.Text = String.Format("The placename ({0}) whilst valid, does not have any Churches downloaded for it from FreeREG. Before you can edit files for this place, you must download the Churches.", TranscriptionFile.FileHeader.Place)
				End If
			End If

			Dim rowChurch = Tables.Churches.FindByChurchNameChapmanCodePlaceName(TranscriptionFile.FileHeader.Church, TranscriptionFile.FileHeader.County, TranscriptionFile.FileHeader.Place)
			Dim strFilter As String
			textChurch.Text = TranscriptionFile.FileHeader.Church
			If rowChurch Is Nothing Then
				textChurch.ForeColor = Drawing.Color.Red
				strFilter = "PlaceName = '" + TranscriptionFile.FileHeader.Place.Replace("'", "''") + "'"
				ChurchesBindingSource.Filter = strFilter
			End If


		Catch ex As Exception
			MessageBox.Show(ex.Message, "title", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
		If countiesComboBox.SelectedIndex >= 0 Then
			Dim selectedCounty As FreeregTables.CountiesRow = CType(countiesComboBox.SelectedItem(), DataRowView).Row
			If selectedCounty.ChapmanCode <> TranscriptionFile.FileHeader.County Then
				TranscriptionFile.FileHeader.County = selectedCounty.ChapmanCode
				TranscriptionFile.FileCorrected = True
			End If
		End If

		If placesComboBox.SelectedIndex >= 0 Then
			Dim selectedPlace As DataRow = CType(placesComboBox.SelectedItem(), DataRowView).Row
			If selectedPlace.Item(0) <> TranscriptionFile.FileHeader.Place Then
				TranscriptionFile.FileHeader.Place = selectedPlace.Item(0)
				TranscriptionFile.FileCorrected = True
			End If
		End If

		If churchesComboBox.SelectedIndex >= 0 Then
			Dim selectedChurch As DataRow = CType(churchesComboBox.SelectedItem(), DataRowView).Row
			If selectedChurch.Item(0) <> TranscriptionFile.FileHeader.Church Then
				TranscriptionFile.FileHeader.Church = selectedChurch.Item(0)
				TranscriptionFile.PlaceCode = selectedChurch.Item(3)
				TranscriptionFile.FileCorrected = True
			End If
		End If
	End Sub

	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
		TranscriptionFile.FileCorrected = False
	End Sub

	Private Sub countiesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles countiesComboBox.SelectedIndexChanged
		If countiesComboBox.SelectedItem() Is Nothing Then Return
		Dim selectedCounty As FreeregTables.CountiesRow = CType(countiesComboBox.SelectedItem(), DataRowView).Row
		Dim ChurchesInCounty() = Tables.Counties.FindByChapmanCode(selectedCounty.ChapmanCode).GetChildRows("ChurchesInCounty")
		If ChurchesInCounty.Length > 0 Then
			Dim dtChurchesInCounty = ChurchesInCounty.CopyToDataTable()
			Dim dtPlacesWithChurchesInCounty = dtChurchesInCounty.DefaultView.ToTable(True, "PlaceName")
			PlacesBindingSource.DataSource = dtPlacesWithChurchesInCounty
		End If
	End Sub

	Private Sub placesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles placesComboBox.SelectedIndexChanged
		If placesComboBox.SelectedItem() Is Nothing Then Return
		Dim selectedPlace As DataRow = CType(placesComboBox.SelectedItem(), DataRowView).Row
		ChurchesBindingSource.Filter = String.Format("PlaceName = '{0}'", selectedPlace.Item(0).Replace("'", "''"))
		textMessage.Text = String.Empty
	End Sub

	Private Sub formMissingDetails_HelpRequested(sender As Object, hlpevent As Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
		Try
			FormHelp.Title = "Missing File Details"
			FormHelp.StartPage = "MissingFileDetails.html"
			FormHelp.Show()

		Catch ex As Exception
			FormHelp.Hide()
			MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)
		End Try

	End Sub
End Class