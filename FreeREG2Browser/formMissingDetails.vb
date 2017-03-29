Public Class formMissingDetails

	Property TranscriptionFile As TranscriptionFileClass

	Property Tables As FreeregTables

	Property FileCorrected As Boolean

	Private Sub formMissingDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		FileCorrected = False
		Dim msg = String.Format("Unable to find Church record for County:{0} Place:{1} Church:{2}", TranscriptionFile.FileHeader.County, TranscriptionFile.FileHeader.Place, TranscriptionFile.FileHeader.Church)
		labelMessage.Text = msg

		Dim rowCounty = Tables.Counties.FindByChapmanCode(TranscriptionFile.FileHeader.County)
		CountiesBindingSource.DataSource = Tables
		If rowCounty Is Nothing Then
			textCounty.Text = String.Format("{0} - <Not found>", TranscriptionFile.FileHeader.County)
			textCounty.ForeColor = Drawing.Color.Red
		Else
			textCounty.Text = String.Format("{0} - {1}", rowCounty.ChapmanCode, rowCounty.CountyName)
			countiesComboBox.SelectedIndex = countiesComboBox.FindString(TranscriptionFile.FileHeader.County)
		End If

		Dim ChurchesInCounty() = Tables.Counties.FindByChapmanCode(rowCounty.ChapmanCode).GetChildRows("ChurchesInCounty")
		Dim dtChurchesInCounty = ChurchesInCounty.CopyToDataTable()
		Dim dtPlacesWithChurchesInCounty = dtChurchesInCounty.DefaultView.ToTable(True, "PlaceName")

		Dim rowPlace = Tables.Places.FindByPlaceNameChapmanCode(TranscriptionFile.FileHeader.Place, TranscriptionFile.FileHeader.County)
		PlacesBindingSource.DataSource = dtPlacesWithChurchesInCounty
		textPlace.Text = TranscriptionFile.FileHeader.Place
		If rowPlace Is Nothing Then
			textPlace.ForeColor = Drawing.Color.Red
		Else
			placesComboBox.SelectedIndex = placesComboBox.FindString(TranscriptionFile.FileHeader.Place)
		End If


		Dim rowChurch = Tables.Churches.FindByChurchNameChapmanCodePlaceName(TranscriptionFile.FileHeader.Church, TranscriptionFile.FileHeader.County, TranscriptionFile.FileHeader.Place)
		ChurchesBindingSource.DataSource = dtChurchesInCounty
		textChurch.Text = TranscriptionFile.FileHeader.Church
		If rowChurch Is Nothing Then
			textChurch.ForeColor = Drawing.Color.Red
			ChurchesBindingSource.Filter = String.Format("PlaceName = '{0}'", TranscriptionFile.FileHeader.Place)
		End If

	End Sub

	Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
		Dim selectedCounty As FreeregTables.CountiesRow = CType(countiesComboBox.SelectedItem(), DataRowView).Row
		Dim selectedPlace As DataRow = CType(placesComboBox.SelectedItem(), DataRowView).Row
		Dim selectedChurch As DataRow = CType(churchesComboBox.SelectedItem(), DataRowView).Row

		TranscriptionFile.FileHeader.County = selectedCounty.ChapmanCode
		TranscriptionFile.FileHeader.Place = selectedPlace.Item(0)
		TranscriptionFile.FileHeader.Church = selectedChurch.Item(0)
		TranscriptionFile.PlaceCode = selectedChurch.Item(3)
		FileCorrected = True
	End Sub

	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

	End Sub

	Private Sub countiesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
		If countiesComboBox.SelectedItem() Is Nothing Then Return
		Dim selectedCounty As FreeregTables.CountiesRow = CType(countiesComboBox.SelectedItem(), DataRowView).Row
		Dim ChurchesInCounty() = Tables.Counties.FindByChapmanCode(selectedCounty.ChapmanCode).GetChildRows("ChurchesInCounty")
		Dim dtChurchesInCounty = ChurchesInCounty.CopyToDataTable()
		Dim dtPlacesWithChurchesInCounty = dtChurchesInCounty.DefaultView.ToTable(True, "PlaceName")
		PlacesBindingSource.DataSource = dtPlacesWithChurchesInCounty
	End Sub

	Private Sub placesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
		If placesComboBox.SelectedItem() Is Nothing Then Return
		Dim selectedPlace As DataRow = CType(placesComboBox.SelectedItem(), DataRowView).Row
		ChurchesBindingSource.Filter = String.Format("PlaceName = '{0}'", selectedPlace.Item(0))
	End Sub
End Class