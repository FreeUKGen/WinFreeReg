Imports System.Windows.Forms

Public Class formMissingDetails

	Property TranscriptionFile As TranscriptionFileClass

	Property Tables As FreeregTables

	Property FileCorrected As Boolean

	Property FormHelp As formGeneralHelp

	Private Sub formMissingDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		FileCorrected = False
		Dim msg = String.Format("Unable to find Church record for County:{0} Place:{1} Church:{2}", TranscriptionFile.FileHeader.County, TranscriptionFile.FileHeader.Place, TranscriptionFile.FileHeader.Church)
		labelMessage.Text = msg
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
			End If

			Dim rowChurch = Tables.Churches.FindByChurchNameChapmanCodePlaceName(TranscriptionFile.FileHeader.Church, TranscriptionFile.FileHeader.County, TranscriptionFile.FileHeader.Place)
			textChurch.Text = TranscriptionFile.FileHeader.Church
			If rowChurch Is Nothing Then
				textChurch.ForeColor = Drawing.Color.Red
				ChurchesBindingSource.Filter = String.Format("PlaceName = '{0}'", TranscriptionFile.FileHeader.Place)
			End If


		Catch ex As Exception

		End Try
	End Sub

	Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
		If countiesComboBox.SelectedIndex >= 0 Then
			Dim selectedCounty As FreeregTables.CountiesRow = CType(countiesComboBox.SelectedItem(), DataRowView).Row
			TranscriptionFile.FileHeader.County = selectedCounty.ChapmanCode
			FileCorrected = True
		End If

		If placesComboBox.SelectedIndex >= 0 Then
			Dim selectedPlace As DataRow = CType(placesComboBox.SelectedItem(), DataRowView).Row
			TranscriptionFile.FileHeader.Place = selectedPlace.Item(0)
			FileCorrected = True
		End If

		If churchesComboBox.SelectedIndex >= 0 Then
			Dim selectedChurch As DataRow = CType(churchesComboBox.SelectedItem(), DataRowView).Row
			TranscriptionFile.FileHeader.Church = selectedChurch.Item(0)
			TranscriptionFile.PlaceCode = selectedChurch.Item(3)
			FileCorrected = True
		End If
	End Sub

	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
		FileCorrected = False
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
		ChurchesBindingSource.Filter = String.Format("PlaceName = '{0}'", selectedPlace.Item(0))
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