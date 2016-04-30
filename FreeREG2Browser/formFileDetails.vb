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

	Private Sub formFileDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Dim title = String.Format(Me.Text, m_TranscriptionFile.FileName)
		Me.Text = title
		TranscriptionFileClassBindingSource.DataSource = m_TranscriptionFile.FileHeader
		RecordTypesBindingSource.DataSource = m_TranscriptionFile.LookupTables.RecordTypes

		RegisterTypesBindingSource.DataSource = m_TranscriptionFile.FreeregTables
		RegisterTypesBindingSource.DataMember = "RegisterTypes"

		CountiesBindingSource.DataSource = m_TranscriptionFile.FreeregTables
		CountiesBindingSource.DataMember = "Counties"

		PlacesBindingSource.DataSource = m_TranscriptionFile.FreeregTables
		PlacesBindingSource.DataMember = "Places"
		PlacesBindingSource.Filter = String.Format("ChapmanCode='{0}'", m_TranscriptionFile.FileHeader.County)

		ChurchesBindingSource.DataSource = m_TranscriptionFile.FreeregTables
		ChurchesBindingSource.DataMember = "Churches"
		ChurchesBindingSource.Filter = String.Format("ChapmanCode='{0}' AND PlaceName='{1}'", m_TranscriptionFile.FileHeader.County, m_TranscriptionFile.FileHeader.Place)

		CountyComboBox.SelectedValue = m_TranscriptionFile.FileHeader.County
	End Sub

	Private Sub formFileDetails_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
		Dim x = m_TranscriptionFile.FileHeader.RegisterType
		RegisterTypeComboBox.SelectedValue = m_TranscriptionFile.FileHeader.RegisterType
		CountyComboBox.SelectedValue = m_TranscriptionFile.FileHeader.County
		PlaceComboBox.SelectedValue = m_TranscriptionFile.FileHeader.Place
		ChurchComboBox.SelectedValue = m_TranscriptionFile.FileHeader.Church
		FileTypeComboBox.SelectedValue = m_TranscriptionFile.FileHeader.FileType.ToString.Substring(0, 2)
	End Sub
End Class