Public Class formStartNewFile

	Private m_TablesDataSet As WinREG.FreeregTables
	Private m_LookupsDataSet As WinREG.LookupTables
	Private m_SelectedCounty As String
	Private m_SelectedPlace As String
	Private m_SelectedChurch As String
	Private m_SelectedRegisterType As String
	Private m_SelectedRecordType As String

	Public Property TablesDataset() As WinREG.FreeregTables
		Get
			Return m_TablesDataSet
		End Get
		Set(ByVal value As WinREG.FreeregTables)
			m_TablesDataSet = value
		End Set
	End Property

	Public Property LookUpsDataset() As WinREG.LookupTables
		Get
			Return m_LookupsDataSet
		End Get
		Set(ByVal value As WinREG.LookupTables)
			m_LookupsDataSet = value
		End Set
	End Property

	Private Sub formStartNewFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		CountiesBindingSource.DataSource = m_TablesDataSet
		PlacesBindingSource.DataSource = m_TablesDataSet
		ChurchesBindingSource.DataSource = m_TablesDataSet
		RegisterTypesBindingSource.DataSource = m_TablesDataSet
		RecordTypesBindingSource.DataSource = m_LookupsDataSet

		Label1.Visible = False
		labFilename.Text = ""
	End Sub

	Private Sub CountiesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CountiesComboBox.SelectedIndexChanged
		If CountiesComboBox.SelectedItem IsNot Nothing Then
			Dim row As WinREG.FreeregTables.CountiesRow = CType(CountiesComboBox.SelectedItem(), DataRowView).Row
			m_SelectedCounty = row.ChapmanCode
			Label1.Visible = True
			labFilename.Text = m_SelectedCounty

			labPlace.Visible = True
			PlacesBindingSource.Filter = String.Format("ChapmanCode = '{0}'", m_SelectedCounty)
			PlacesComboBox.Enabled = True
			PlacesComboBox.Visible = True
		End If
	End Sub

	Private Sub PlacesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlacesComboBox.SelectedIndexChanged
		If PlacesComboBox.SelectedItem IsNot Nothing Then
			Dim row As WinREG.FreeregTables.PlacesRow = CType(PlacesComboBox.SelectedItem(), DataRowView).Row
			m_SelectedPlace = row.PlaceName

			labChurch.Visible = True
			ChurchesBindingSource.Filter = String.Format("ChapmanCode = '{0}' AND PlaceName = '{1}'", m_SelectedCounty, m_SelectedPlace)
			If ChurchesBindingSource.Count = 1 Then
				Dim rowChurch As WinREG.FreeregTables.ChurchesRow = ChurchesBindingSource.Item(0).Row
				ChurchesComboBox.Enabled = False
				ChurchesComboBox.Visible = False
				ChurchTextBox.Enabled = True
				ChurchTextBox.Visible = True
				ChurchTextBox.Text = rowChurch.ChurchName
				m_SelectedChurch = rowChurch.ChurchName

				labCode.Visible = True
				CodeTextBox.Text = m_SelectedPlace.Substring(0, 3).ToUpper
				labFilename.Text = m_SelectedCounty + " " + CodeTextBox.Text
				CodeTextBox.Enabled = True
				CodeTextBox.Visible = True

				labRegisterType.Visible = True
				RegisterTypesComboBox.Enabled = True
				RegisterTypesComboBox.Visible = True
			Else
				ChurchesComboBox.Enabled = True
				ChurchesComboBox.Visible = True
			End If
		End If
	End Sub

	Private Sub ChurchesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChurchesComboBox.SelectedIndexChanged
		If ChurchesComboBox.SelectedItem IsNot Nothing Then
			Dim row As WinREG.FreeregTables.ChurchesRow = CType(ChurchesComboBox.SelectedItem(), DataRowView).Row
			m_SelectedChurch = row.ChurchName

			labCode.Visible = True
			CodeTextBox.Text = m_SelectedPlace.Substring(0, 3).ToUpper
			labFilename.Text = m_SelectedCounty + " " + CodeTextBox.Text
			CodeTextBox.Enabled = True
			CodeTextBox.Visible = True

			labRegisterType.visible = True
			RegisterTypesComboBox.Enabled = True
			RegisterTypesComboBox.Visible = True
		End If
	End Sub

	Private Sub RegisterTypesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterTypesComboBox.SelectedIndexChanged
		If RegisterTypesComboBox.SelectedItem IsNot Nothing Then
			Dim row As WinREG.FreeregTables.RegisterTypesRow = CType(RegisterTypesComboBox.SelectedItem(), DataRowView).Row
			m_SelectedRegisterType = row.Type

			labRecordType.Visible = True
			RecordTypesComboBox.Enabled = True
			RecordTypesComboBox.Visible = True
		End If
	End Sub

	Private Sub RecordTypesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecordTypesComboBox.SelectedIndexChanged
		If RecordTypesComboBox.SelectedItem IsNot Nothing Then
			Dim row As WinREG.LookupTables.RecordTypesRow = CType(RecordTypesComboBox.SelectedItem(), DataRowView).Row
			m_SelectedRecordType = row.Type
			labFilename.Text = m_SelectedCounty + " " + CodeTextBox.Text + " " + m_SelectedRecordType

			labComments.Visible = True
			Comment1TextBox.Enabled = True
			Comment1TextBox.Visible = True
			Comment2TextBox.Enabled = True
			Comment2TextBox.Visible = True
		End If
	End Sub

	Private Sub CodeTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodeTextBox.TextChanged
		If CodeTextBox.TextLength = 3 Then
			labFilename.Text = m_SelectedCounty + " " + CodeTextBox.Text + " " + m_SelectedRecordType
		ElseIf CodeTextBox.TextLength = 0 Then
			labFilename.Text = m_SelectedCounty + " " + m_SelectedPlace.Substring(0, 3).ToUpper + " " + m_SelectedRecordType
		End If
	End Sub
End Class