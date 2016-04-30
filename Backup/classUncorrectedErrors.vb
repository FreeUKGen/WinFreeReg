Imports BrightIdeasSoftware

Public Class classUncorrectedErrors

	Private m_TableName As String
	Private m_Row As DataRow
	Private m_ColumnName As DataColumn()
	Private m_Error As String

	<OLVColumn(Width:=75, IsEditable:=False, Name:="TableName", Title:="Table Name")> _
 Public Property TableName() As String
		Get
			Return m_TableName
		End Get
		Set(ByVal value As String)
			m_TableName = value
		End Set
	End Property

	<OLVColumn(IsVisible:=False)> _
	Public Property Row() As DataRow
		Get
			Return m_Row
		End Get
		Set(ByVal value As DataRow)
			m_Row = value
		End Set
	End Property

	<OLVColumn(IsVisible:=False)> _
	Public Property ColumnName() As DataColumn()
		Get
			Return m_ColumnName
		End Get
		Set(ByVal value As DataColumn())
			m_ColumnName = value
		End Set
	End Property

	<OLVColumn(IsVisible:=False)> _
	Public Property ColummnError() As String
		Get
			Return m_Error
		End Get
		Set(ByVal value As String)
			m_Error = value
		End Set
	End Property

	<OLVColumn(Width:=50, IsEditable:=False, Name:="NumberErrors", Title:="#Errors")> _
 Public ReadOnly Property NumberErrors() As Integer
		Get
			Return m_ColumnName.Count
		End Get
	End Property

	<OLVColumn(Width:=100, IsEditable:=False, Name:="Errors", Title:="Errors", FillsFreeSpace:=True)> _
 Public ReadOnly Property ColumnsInError() As String
		Get
			Dim str As New String("")
			For Each col In m_ColumnName
				str += String.Format(" {0}({1}) {2}", col.ColumnName, m_Row(col.ColumnName), m_Row.GetColumnError(col.ColumnName))
			Next
			Return str.Trim()
		End Get
	End Property

End Class
