Imports System.IO

Partial Class LookupTables

	Public Sub LoadXmlData(ByRef filename As String)
		Try
			Dim fi As FileInfo = New FileInfo(filename)
			If fi.Exists Then
				If fi.IsReadOnly Then fi.IsReadOnly = False
            Me.ReadXml(filename, XmlReadMode.Auto)
         End If

			Try
				If Me.RecordTypes.Rows.Count = 0 Then
					Me.RecordTypes.LoadDefaultValues()
					My.Application.Log.WriteEntry(Date.Now() + " default Record Types table has been created", TraceEventType.Information)
				End If
			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Error, Date.Now() + " Creating default Record Types table")
				Dim newException As New ApplicationException("", ex)
				Throw newException
			End Try

			Try
				If Me.ChapmanCodes.Rows.Count = 0 Then
					Me.ChapmanCodes.LoadDefaultValues()
					My.Application.Log.WriteEntry(Date.Now() + " default Chapman Codes table has been created", TraceEventType.Information)
				End If
			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Error, Date.Now() + " Creating default Chapman Codes table")
				Dim newException As New ApplicationException("", ex)
				Throw newException
			End Try

			Try
				If Me.BaptismSex.Rows.Count = 0 Then
					Me.BaptismSex.LoadDefaultValues()
					My.Application.Log.WriteEntry(Date.Now() + " default Baptism Sex table has been created", TraceEventType.Information)
				End If
			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Error, Date.Now() + " Creating default Baptism Sex table")
				Dim newException As New ApplicationException("", ex)
				Throw newException
			End Try

			Try
				If Me.BurialRelationship.Rows.Count = 0 Then
					Me.BurialRelationship.LoadDefaultValues()
					My.Application.Log.WriteEntry(Date.Now() + " default Burial Relationships table has been created", TraceEventType.Information)
				End If
			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Error, Date.Now() + " Creating default Burial Relationships table")
				Dim newException As New ApplicationException("", ex)
				Throw newException
			End Try

			Try
				If Me.GroomCondition.Rows.Count = 0 Then
					Me.GroomCondition.LoadDefaultValues()
					My.Application.Log.WriteEntry(Date.Now() + " default Groom Marriage Conditions table has been created", TraceEventType.Information)
				End If
			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Error, Date.Now() + " Creating default Groom Marriage Conditions table")
				Dim newException As New ApplicationException("", ex)
				Throw newException
			End Try

			Try
				If Me.BrideCondition.Rows.Count = 0 Then
					Me.BrideCondition.LoadDefaultValues()
					My.Application.Log.WriteEntry(Date.Now() + " default Bride Marriage Conditions table has been created", TraceEventType.Information)
				End If
			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Error, Date.Now() + " Creating default Bride Marriage Conditions table")
				Dim newException As New ApplicationException("", ex)
				Throw newException
			End Try

			Try
				If Me.RegisterTypes.Rows.Count = 0 Then
					Me.RegisterTypes.LoadDefaultValues()
					My.Application.Log.WriteEntry(Date.Now() + " default Register types table has been created", TraceEventType.Information)
				End If
			Catch ex As Exception
				My.Application.Log.WriteException(ex, TraceEventType.Error, Date.Now() + " Creating default Register Types table")
				Dim newException As New ApplicationException("", ex)
				Throw newException
			End Try

		Catch ex As Exception

		End Try
	End Sub

	Public Sub SaveXmlData(ByRef filename As String)
		Dim stream As New FileStream(filename, FileMode.Create)
		Me.WriteXml(stream, XmlWriteMode.WriteSchema)
		stream.Close()
	End Sub

#Region "Bride Conditions Table"
	Partial Class BrideConditionDataTable

		Public Sub LoadDefaultValues()
			Me.AddBrideConditionHelper("Application", String.Empty, String.Empty)
			Me.AddBrideConditionHelper("Application", "spinster", "spinster")
			Me.AddBrideConditionHelper("Application", "widow", "widow")
			Me.AddBrideConditionHelper("Application", "single", "single woman")
			Me.AddBrideConditionHelper("Application", "maiden", "maiden")
			Me.AddBrideConditionHelper("Application", "virgin", "virgin")
			Me.AddBrideConditionHelper("Application", "minor", "minor")
			Me.AddBrideConditionHelper("Application", "divorcee", "divorcee")
			Me.AddBrideConditionHelper("Application", "annulled", "previous marriage annulled")
			Me.AddBrideConditionHelper("Application", "dissolved", "previous marriage dissolved")
		End Sub

		Public Sub AddBrideConditionHelper(ByVal type As String, ByVal filevalue As String, ByVal displayvalue As String)
			Try
				Me.AddBrideConditionRow(type, filevalue, displayvalue)

			Catch ex As ConstraintException
				Dim exn As New ConstraintException("Unable to add to the BrideConditionTable", ex)
				exn.Source = "BrideConditionTable"
				ex.Data.Add("Type", type)
				ex.Data.Add("FileValue", filevalue)
				ex.Data.Add("DisplayValue", displayvalue)
				Throw exn
			End Try
		End Sub

		Private Sub BrideConditionDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If e.Row("Type") = "User" Then
				If (e.Column.ColumnName = Me.TypeColumn.ColumnName) Then
					'Add user code here
				ElseIf (e.Column.ColumnName = Me.FileValueColumn.ColumnName) Then
					If String.IsNullOrEmpty(e.ProposedValue) Then
						e.Row.SetColumnError(e.Column, "The File Value must be entered")
					ElseIf CType(e.ProposedValue, String) = "<New>" OrElse CType(e.ProposedValue, String) = "<Default>" Then
						e.Row.SetColumnError(e.Column, "The default File Value must be replaced")
					Else
						If Me.FindByFileValue(e.ProposedValue) IsNot Nothing Then
							e.Row.SetColumnError(e.Column, String.Format("Duplicate value '{0}'", e.ProposedValue))
							e.ProposedValue += "_1"
						Else
							e.Row.SetColumnError(e.Column, "")
						End If
					End If
				ElseIf (e.Column.ColumnName = Me.DisplayValueColumn.ColumnName) Then
					If String.IsNullOrEmpty(e.ProposedValue) Then
						e.Row.SetColumnError(e.Column, "The Display Value field must be entered")
					ElseIf CType(e.ProposedValue, String) = "You must change these fields" OrElse CType(e.ProposedValue, String) = "<New>" Then
						e.Row.SetColumnError(e.Column, "The Display Value must be replaced")
					Else
						e.Row.SetColumnError(e.Column, "")
					End If
				End If
			End If
		End Sub

	End Class
#End Region

#Region "Groom Conditions Table"
	Partial Class GroomConditionDataTable

		Public Sub LoadDefaultValues()
			Me.AddGroomConditionHelper("Application", String.Empty, String.Empty)
			Me.AddGroomConditionHelper("Application", "bachelor", "bachelor")
			Me.AddGroomConditionHelper("Application", "widower", "widower")
			Me.AddGroomConditionHelper("Application", "single", "single man")
			Me.AddGroomConditionHelper("Application", "virgin", "virgin")
			Me.AddGroomConditionHelper("Application", "annulled", "previous marriage annulled")
			Me.AddGroomConditionHelper("Application", "divorced", "divorced man")
			Me.AddGroomConditionHelper("Application", "dissolved", "previous marriage dissolved")
			Me.AddGroomConditionHelper("Application", "minor", "minor")
		End Sub

		Public Sub AddGroomConditionHelper(ByVal type As String, ByVal filevalue As String, ByVal displayvalue As String)
			Try
				Me.AddGroomConditionRow(type, filevalue, displayvalue)

			Catch ex As ConstraintException
				Dim exn As New ConstraintException("Unable to add to the GroomConditionDataTable", ex)
				exn.Source = "GroomConditionTable"
				ex.Data.Add("Type", type)
				ex.Data.Add("FileValue", filevalue)
				ex.Data.Add("DisplayValue", displayvalue)
				Throw exn
			End Try
		End Sub

		Private Sub GroomConditionDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If e.Row("Type") = "User" Then
				If (e.Column.ColumnName = Me.TypeColumn.ColumnName) Then
					'Add user code here
				ElseIf (e.Column.ColumnName = Me.FileValueColumn.ColumnName) Then
					If String.IsNullOrEmpty(e.ProposedValue) Then
						e.Row.SetColumnError(e.Column, "The File Value must be entered")
					ElseIf CType(e.ProposedValue, String) = "<New>" OrElse CType(e.ProposedValue, String) = "<Default>" Then
						e.Row.SetColumnError(e.Column, "The default File Value must be replaced")
					Else
						If Me.FindByFileValue(e.ProposedValue) IsNot Nothing Then
							e.Row.SetColumnError(e.Column, String.Format("Duplicate value '{0}'", e.ProposedValue))
							e.ProposedValue += "_1"
						Else
							e.Row.SetColumnError(e.Column, "")
						End If
					End If
				ElseIf (e.Column.ColumnName = Me.DisplayValueColumn.ColumnName) Then
					If String.IsNullOrEmpty(e.ProposedValue) Then
						e.Row.SetColumnError(e.Column, "The Display Value field must be entered")
					ElseIf CType(e.ProposedValue, String) = "You must change these fields" OrElse CType(e.ProposedValue, String) = "<New>" Then
						e.Row.SetColumnError(e.Column, "The Display Value must be replaced")
					Else
						e.Row.SetColumnError(e.Column, "")
					End If
				End If
			End If
		End Sub

	End Class
#End Region

#Region "Burial Relationships Table"
	Partial Class BurialRelationshipDataTable

		Public Sub LoadDefaultValues()
			Me.AddBurialRelationshipHelper("Application", String.Empty, String.Empty)
			Me.AddBurialRelationshipHelper("Application", "son of", "son of")
			Me.AddBurialRelationshipHelper("Application", "dau of", "dau of")
			Me.AddBurialRelationshipHelper("Application", "wife of", "wife of")
			Me.AddBurialRelationshipHelper("Application", "husband of", "husband of")
			Me.AddBurialRelationshipHelper("Application", "widow of", "widow of")
			Me.AddBurialRelationshipHelper("Application", "relict of", "relict of")
		End Sub

		Public Sub AddBurialRelationshipHelper(ByVal type As String, ByVal filevalue As String, ByVal displayvalue As String)
			Try
				Me.AddBurialRelationshipRow(type, filevalue, displayvalue)

			Catch ex As ConstraintException
				Dim exn As New ConstraintException("Unable to add to the BurialRelationshipDataTable", ex)
				exn.Source = "BurialRelationshipsTable"
				ex.Data.Add("Type", type)
				ex.Data.Add("FileValue", filevalue)
				ex.Data.Add("DisplayValue", displayvalue)
				Throw exn
			End Try
		End Sub

		Private Sub BurialRelationshipDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If e.Row("Type") = "User" Then
				If (e.Column.ColumnName = Me.TypeColumn.ColumnName) Then
					'Add user code here
				ElseIf (e.Column.ColumnName = Me.FileValueColumn.ColumnName) Then
					If String.IsNullOrEmpty(e.ProposedValue) Then
						e.Row.SetColumnError(e.Column, "The File Value must be entered")
					ElseIf CType(e.ProposedValue, String) = "<New>" OrElse CType(e.ProposedValue, String) = "<Default>" Then
						e.Row.SetColumnError(e.Column, "The default File Value must be replaced")
					Else
						If Me.FindByFileValue(e.ProposedValue) IsNot Nothing Then
							e.Row.SetColumnError(e.Column, String.Format("Duplicate value '{0}'", e.ProposedValue))
							e.ProposedValue += "_1"
						Else
							e.Row.SetColumnError(e.Column, "")
						End If
					End If
				ElseIf (e.Column.ColumnName = Me.DisplayValueColumn.ColumnName) Then
					If String.IsNullOrEmpty(e.ProposedValue) Then
						e.Row.SetColumnError(e.Column, "The Display Value field must be entered")
					ElseIf CType(e.ProposedValue, String) = "You must change these fields" OrElse CType(e.ProposedValue, String) = "<New>" Then
						e.Row.SetColumnError(e.Column, "The Display Value must be replaced")
					Else
						e.Row.SetColumnError(e.Column, "")
					End If
				End If
			End If
		End Sub

		Private Sub BurialRelationshipDataTable_BurialRelationshipRowChanging(ByVal sender As System.Object, ByVal e As BurialRelationshipRowChangeEvent) Handles Me.BurialRelationshipRowChanging

		End Sub

	End Class
#End Region

#Region "Baptism Sex Table"
	Partial Class BaptismSexDataTable

		Public Sub LoadDefaultValues()
			Me.AddBaptismSexHelper("Application", String.Empty, String.Empty)
			Me.AddBaptismSexHelper("Application", "-", "Unknown")
			Me.AddBaptismSexHelper("Application", "M", "Male")
			Me.AddBaptismSexHelper("Application", "F", "Female")
		End Sub

		Public Sub AddBaptismSexHelper(ByVal type As String, ByVal code As String, ByVal description As String)
			Try
				Me.AddBaptismSexRow(type, code, description)

			Catch ex As ConstraintException
				Dim exn As New ConstraintException("Unable to add to the BaptismSexDataTable", ex)
				exn.Source = "BaptismSexTable"
				exn.Data.Add("Type", type)
				exn.Data.Add("Code", code)
				exn.Data.Add("Description", description)
				Throw exn
			End Try
		End Sub

		Private Sub BaptismSexDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If e.Row("Type") = "User" Then
				If (e.Column.ColumnName = Me.TypeColumn.ColumnName) Then
					'Add user code here
				ElseIf (e.Column.ColumnName = Me.CodeColumn.ColumnName) Then
					'Add user code here
				ElseIf (e.Column.ColumnName = Me.DescriptionColumn.ColumnName) Then
					'Add user code here
				End If
			End If
		End Sub

	End Class
#End Region

#Region "Chapman Codes Table"
	Partial Class ChapmanCodesDataTable

		Public Sub LoadDefaultValues()
			Me.AddChapmanCodeHelper("CHI", "Channel Isles")
			Me.AddChapmanCodeHelper("ENG", "England")
			Me.AddChapmanCodeHelper("IOM", "Isle of Man")
			Me.AddChapmanCodeHelper("IRL", "Ireland")
			Me.AddChapmanCodeHelper("SCT", "Scotland")
			Me.AddChapmanCodeHelper("WLS", "Wales")
			Me.AddChapmanCodeHelper("ALL", "All countries")

			Me.AddChapmanCodeHelper("ALD", "Alderney")
			Me.AddChapmanCodeHelper("GSY", "Guernsey")
			Me.AddChapmanCodeHelper("JSY", "Jersey")
			Me.AddChapmanCodeHelper("SRK", "Sark")

			Me.AddChapmanCodeHelper("BDF", "Bedfordshire")
			Me.AddChapmanCodeHelper("BRK", "Berkshire")
			Me.AddChapmanCodeHelper("BKM", "Buckinghamshire")
			Me.AddChapmanCodeHelper("CAM", "Cambridgeshire")
			Me.AddChapmanCodeHelper("CHS", "Cheshire")
			Me.AddChapmanCodeHelper("CON", "Cornwall")
			Me.AddChapmanCodeHelper("CUL", "Cumberland")
			Me.AddChapmanCodeHelper("DBY", "Derbyshire")
			Me.AddChapmanCodeHelper("DEV", "Devonshire")
			Me.AddChapmanCodeHelper("DOR", "Dorset")
			Me.AddChapmanCodeHelper("DUR", "Durham")
			Me.AddChapmanCodeHelper("ESS", "Essex")
			Me.AddChapmanCodeHelper("GLS", "Gloucestershire")
			Me.AddChapmanCodeHelper("HAM", "Hampshire")
			Me.AddChapmanCodeHelper("HEF", "Herefordshire")
			Me.AddChapmanCodeHelper("HRT", "Hertfordshire")
			Me.AddChapmanCodeHelper("HUN", "Huntingdonshire")
			Me.AddChapmanCodeHelper("IOW", "Isle of Wight")
			Me.AddChapmanCodeHelper("KEN", "Kent")
			Me.AddChapmanCodeHelper("LAN", "Lancashire")
			Me.AddChapmanCodeHelper("LEI", "Leicestershire")
			Me.AddChapmanCodeHelper("LIN", "Lincolnshire")
			Me.AddChapmanCodeHelper("LND", "London")
			Me.AddChapmanCodeHelper("MDX", "Middlesex")
			Me.AddChapmanCodeHelper("NFK", "Norfolk")
			Me.AddChapmanCodeHelper("NTH", "Northamptonshire")
			Me.AddChapmanCodeHelper("NBL", "Northumberland")
			Me.AddChapmanCodeHelper("NTT", "Nottinghamshire")
			Me.AddChapmanCodeHelper("OXF", "Oxfordshire")
			Me.AddChapmanCodeHelper("RUT", "Rutland")
			Me.AddChapmanCodeHelper("SAL", "Shropshire")
			Me.AddChapmanCodeHelper("SOM", "Somerset")
			Me.AddChapmanCodeHelper("STS", "Staffordshire")
			Me.AddChapmanCodeHelper("SFK", "Suffolk")
			Me.AddChapmanCodeHelper("SRY", "Surrey")
			Me.AddChapmanCodeHelper("SSX", "Sussex")
			Me.AddChapmanCodeHelper("WAR", "Warwickshire")
			Me.AddChapmanCodeHelper("WES", "Westmorland")
			Me.AddChapmanCodeHelper("WIL", "Wiltshire")
			Me.AddChapmanCodeHelper("WOR", "Worcestershire")
			Me.AddChapmanCodeHelper("YKS", "Yorkshire")
			Me.AddChapmanCodeHelper("ERY", "East Riding Yorkshire")
			Me.AddChapmanCodeHelper("NRY", "North Riding Yorkshire")
			Me.AddChapmanCodeHelper("WRY", "West Riding Yorkshire")

			Me.AddChapmanCodeHelper("ABD", "Aberdeenshire")
			Me.AddChapmanCodeHelper("ANS", "Angus")
			Me.AddChapmanCodeHelper("ARL", "Argyllshire")
			Me.AddChapmanCodeHelper("AYR", "Ayrshire")
			Me.AddChapmanCodeHelper("BAN", "Banffshire")
			Me.AddChapmanCodeHelper("BEW", "Berwickshire")
			Me.AddChapmanCodeHelper("BUT", "Bute")
			Me.AddChapmanCodeHelper("CAI", "Caithness")
			Me.AddChapmanCodeHelper("CLK", "Clackmannanshire")
			Me.AddChapmanCodeHelper("DFS", "Dumfriesshire")
			Me.AddChapmanCodeHelper("DNB", "Dunbartonshire")
			Me.AddChapmanCodeHelper("ELN", "East Lothian")
			Me.AddChapmanCodeHelper("FIF", "Fifeshire")
			Me.AddChapmanCodeHelper("INV", "Inverness-shire")
			Me.AddChapmanCodeHelper("KCD", "Kincardineshire")
			Me.AddChapmanCodeHelper("KRS", "Kinross-shire")
			Me.AddChapmanCodeHelper("KKD", "Kircudbrightshire")
			Me.AddChapmanCodeHelper("LKS", "Lanarkshire")
			Me.AddChapmanCodeHelper("MLN", "Midlothian")
			Me.AddChapmanCodeHelper("MOR", "Moray")
			Me.AddChapmanCodeHelper("NAI", "Nairnshire")
			Me.AddChapmanCodeHelper("OKI", "Orkney")
			Me.AddChapmanCodeHelper("PEE", "Peeblesshire")
			Me.AddChapmanCodeHelper("PER", "Perthshire")
			Me.AddChapmanCodeHelper("RFW", "Renfrewshire")
			Me.AddChapmanCodeHelper("ROC", "Ross & Cromarty")
			Me.AddChapmanCodeHelper("ROX", "Roxburghshire")
			Me.AddChapmanCodeHelper("SEL", "Selkirkshire")
			Me.AddChapmanCodeHelper("SHI", "Shetland")
			Me.AddChapmanCodeHelper("STI", "Stirlingshire")
			Me.AddChapmanCodeHelper("SUT", "Sutherland")
			Me.AddChapmanCodeHelper("WLN", "West Lothian")
			Me.AddChapmanCodeHelper("WIG", "Wigtownshire")

			Me.AddChapmanCodeHelper("BOR", "Borders")
			Me.AddChapmanCodeHelper("CEN", "Central")
			Me.AddChapmanCodeHelper("DGY", "Dumfries & Galloway")
			Me.AddChapmanCodeHelper("GMP", "Grampian")
			Me.AddChapmanCodeHelper("HLD", "Highland")
			Me.AddChapmanCodeHelper("LTN", "Lothian")
			Me.AddChapmanCodeHelper("STD", "Strathclyde")
			Me.AddChapmanCodeHelper("TAY", "Tayside")
			Me.AddChapmanCodeHelper("WIS", "Western Isles")

			Me.AddChapmanCodeHelper("AGY", "Anglesey")
			Me.AddChapmanCodeHelper("BRE", "Brecknockshire")
			Me.AddChapmanCodeHelper("CAE", "Caernarfonshire")
			Me.AddChapmanCodeHelper("CGN", "Cardiganshire")
			Me.AddChapmanCodeHelper("CMN", "Carmarthenshire")
			Me.AddChapmanCodeHelper("DEN", "Denbighshire")
			Me.AddChapmanCodeHelper("FLN", "Flintshire")
			Me.AddChapmanCodeHelper("GLA", "Glamorgan")
			Me.AddChapmanCodeHelper("MER", "Merionethshire")
			Me.AddChapmanCodeHelper("MON", "Monmouthshire")
			Me.AddChapmanCodeHelper("MGY", "Montgomeryshire")
			Me.AddChapmanCodeHelper("PEM", "Pembrokeshire")
			Me.AddChapmanCodeHelper("RAD", "Radnorshire")

			Me.AddChapmanCodeHelper("CWD", "Clywd")
			Me.AddChapmanCodeHelper("DFD", "Dyfed")
			Me.AddChapmanCodeHelper("GNT", "Gwent")
			Me.AddChapmanCodeHelper("GWN", "Gwynedd")
			Me.AddChapmanCodeHelper("MGM", "Mid Glamorgan")
			Me.AddChapmanCodeHelper("POW", "Powys")
			Me.AddChapmanCodeHelper("SGM", "South Glamorgan")
			Me.AddChapmanCodeHelper("WGM", "West Glamorgan")

			Me.AddChapmanCodeHelper("ANT", "Antrim")
			Me.AddChapmanCodeHelper("ARM", "Armagh")
			Me.AddChapmanCodeHelper("CAR", "Carlow")
			Me.AddChapmanCodeHelper("CAV", "Cavan")
			Me.AddChapmanCodeHelper("CLA", "Clare")
			Me.AddChapmanCodeHelper("COR", "Cork")
			Me.AddChapmanCodeHelper("DON", "Donegal")
			Me.AddChapmanCodeHelper("DOW", "Down")
			Me.AddChapmanCodeHelper("DUB", "Dublin")
			Me.AddChapmanCodeHelper("FER", "Fermanagh")
			Me.AddChapmanCodeHelper("GAL", "Galway")
			Me.AddChapmanCodeHelper("KER", "Kerry")
			Me.AddChapmanCodeHelper("KID", "Kildare")
			Me.AddChapmanCodeHelper("KIK", "Kilkenny")
			Me.AddChapmanCodeHelper("LET", "Leitrim")
			Me.AddChapmanCodeHelper("LEX", "Leix")
			Me.AddChapmanCodeHelper("LIM", "Limerick")
			Me.AddChapmanCodeHelper("LDY", "Londonderry")
			Me.AddChapmanCodeHelper("LOG", "Longford")
			Me.AddChapmanCodeHelper("LOU", "Louth")
			Me.AddChapmanCodeHelper("MAY", "Mayo")
			Me.AddChapmanCodeHelper("MEA", "Meath")
			Me.AddChapmanCodeHelper("MOG", "Monaghan")
			Me.AddChapmanCodeHelper("OFF", "Offaly")
			Me.AddChapmanCodeHelper("ROS", "Roscommon")
			Me.AddChapmanCodeHelper("SLI", "Sligo")
			Me.AddChapmanCodeHelper("TIP", "Tipperary")
			Me.AddChapmanCodeHelper("TYR", "Tyrone")
			Me.AddChapmanCodeHelper("WAT", "Waterford")
			Me.AddChapmanCodeHelper("WEM", "Westmeath")
			Me.AddChapmanCodeHelper("WEX", "Wexford")
			Me.AddChapmanCodeHelper("WIC", "Wicklow")

			Me.AddChapmanCodeHelper("OVB", "Overseas (British Subject)")
			Me.AddChapmanCodeHelper("OVF", "Overseas (Foreign)")
			Me.AddChapmanCodeHelper("UNK", "Unknown")
		End Sub

		Public Sub AddChapmanCodeHelper(ByVal code As String, ByVal county As String)
			Try
				Me.AddChapmanCodesRow(code, county)

			Catch ex As ConstraintException
				Dim exn As New ConstraintException("Unable to add to the ChapmanCodesDataTable", ex)
				exn.Source = "ChapmanCodesTable"
				ex.Data.Add("Code", code)
				ex.Data.Add("County", county)
				Throw exn
			End Try
		End Sub

		Private Sub ChapmanCodesDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If (e.Column.ColumnName = Me.CodeColumn.ColumnName) Then
				'Add user code here
			ElseIf (e.Column.ColumnName = Me.CountyColumn.ColumnName) Then
				'Add user code here
			End If
		End Sub

	End Class
#End Region

#Region "Record Types Table"
	Partial Class RecordTypesDataTable

		Public Sub LoadDefaultValues()
			Me.AddRecordTypeHelper("BA", "Baptisms")
			Me.AddRecordTypeHelper("BU", "Burials")
			Me.AddRecordTypeHelper("MA", "Marriages")
		End Sub

		Public Sub AddRecordTypeHelper(ByVal type As String, ByVal description As String)
			Try
				Me.AddRecordTypesRow(type, description)

			Catch ex As ConstraintException
				Dim exn As New ConstraintException("Unable to add to the RecordTypesDataTable", ex)
				exn.Source = "RecordTypesTable"
				ex.Data.Add("Type", type)
				ex.Data.Add("Description", description)
				Throw exn
			End Try
		End Sub

		Private Sub RecordTypesDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If (e.Column.ColumnName = Me.TypeColumn.ColumnName) Then
				'Add user code here
			ElseIf (e.Column.ColumnName = Me.DescriptionColumn.ColumnName) Then
				'Add user code here
			End If
		End Sub

	End Class
#End Region

#Region "Register Types Table"
	Partial Class RegisterTypesDataTable

		Public Sub LoadDefaultValues()
			Me.AddRegisterTypeHelper("Application", String.Empty, "Unspecified")
			Me.AddRegisterTypeHelper("Application", "UK", "Unknown Source")
			Me.AddRegisterTypeHelper("Application", "PR", "Parish Register")
			Me.AddRegisterTypeHelper("Application", "OR", "Other Register")
			Me.AddRegisterTypeHelper("Application", "AT", "Archdeacon's Transcript")
			Me.AddRegisterTypeHelper("Application", "BT", "Bishop's Transcript")
			Me.AddRegisterTypeHelper("Application", "PT", "Philimore's Transcript")
			Me.AddRegisterTypeHelper("Application", "DT", "Dwelly's Transcript")
			Me.AddRegisterTypeHelper("Application", "OT", "Other Transcript")
			Me.AddRegisterTypeHelper("Application", "EX", "Extract of a Register")
			Me.AddRegisterTypeHelper("Application", "MI", "Memorial Inscription")
			Me.AddRegisterTypeHelper("Application", "TR", "Transcription")
		End Sub

		Public Sub AddRegisterTypeHelper(ByVal type As String, ByVal code As String, ByVal description As String)
			Try
				Me.AddRegisterTypesRow(type, code, description)

			Catch ex As ConstraintException
				Dim exn As New ConstraintException("Unable to add to the RegisterTypesDataTable", ex)
				exn.Source = "RegisterTypesTable"
				ex.Data.Add("Type", type)
				ex.Data.Add("Code", code)
				ex.Data.Add("Description", description)
				Throw exn
			End Try
		End Sub


		Private Sub RegisterTypesDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If e.Row("Type") = "User" Then
				If (e.Column.ColumnName = Me.TypeColumn.ColumnName) Then
					'Add user code here
				ElseIf (e.Column.ColumnName = Me.CodeColumn.ColumnName) Then
					If String.IsNullOrEmpty(e.ProposedValue) Then
						e.Row.SetColumnError(e.Column, "The Register Type must be entered")
					ElseIf CType(e.ProposedValue, String) = "<New>" OrElse CType(e.ProposedValue, String) = "<Default>" Then
						e.Row.SetColumnError(e.Column, "The default Register Type must be replaced")
					Else
						e.Row.SetColumnError(e.Column, "")
						e.ProposedValue = CType(e.ProposedValue, String).ToUpper
					End If
				ElseIf (e.Column.ColumnName = Me.DescriptionColumn.ColumnName) Then
					If String.IsNullOrEmpty(e.ProposedValue) Then
						e.Row.SetColumnError(e.Column, "The Description field must be entered")
					ElseIf CType(e.ProposedValue, String) = "You must change these fields" Then
						e.Row.SetColumnError(e.Column, "The Description must be replaced")
					Else
						e.Row.SetColumnError(e.Column, "")
					End If
				End If
			End If
		End Sub

	End Class
#End Region

End Class
