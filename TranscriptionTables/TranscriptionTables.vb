'	$Date: 2016-02-23 13:43:42 +0200 (Tue, 23 Feb 2016) $
'	$Rev: 537 $
'	$Id: TranscriptionTables.vb 537 2016-02-23 11:43:42Z Mikefry $
'
'	WinREG/3 - Version 3.2.21
'

Imports System.IO
Imports WinFreeReg.LookupTables

Partial Class TranscriptionTables
	Private Shared MyLeadingZeroOnDates As Boolean
	Private Shared MyAddErrorNumberToMessage As Boolean

	Public Sub SaveXmlData(ByRef filename As String)
		Dim stream As New FileStream(filename, FileMode.Create)
		Me.WriteXml(stream, XmlWriteMode.WriteSchema)
		stream.Close()
	End Sub

	Partial Class BaptismsDataTable
		Private tabBapSex As BaptismSexDataTable

		Public Sub LinkLookupTables(ByVal LeadingZeroOnDates As Boolean, ByVal AddErrorNumberToMessage As Boolean, ByVal bapSex As BaptismSexDataTable)
			tabBapSex = bapSex
			MyLeadingZeroOnDates = LeadingZeroOnDates
			MyAddErrorNumberToMessage = AddErrorNumberToMessage
		End Sub

		Public Sub CopyPrivates(ByVal dst As BaptismsDataTable)
			dst.tabBapSex = Me.tabBapSex
      End Sub

		Private Sub BaptismsDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If (e.Column.ColumnName = Me.BirthDateColumn.ColumnName) Then
				'Add user code here
				Dim value As String = e.ProposedValue.ToString
				e.Row.SetColumnError(e.Column.ColumnName, "")
				If Not String.IsNullOrEmpty(value) Then
					Dim strErrMessage As String = ""
					Dim strBits(4) As String
					If Not TranscriptionValidations.ValidateDate(value, strErrMessage, strBits, MyLeadingZeroOnDates, MyAddErrorNumberToMessage) Then
						e.Row.SetColumnError(e.Column.ColumnName, strErrMessage)
					End If
					e.ProposedValue = value
				End If
			End If

			If (e.Column.ColumnName = Me.BaptismDateColumn.ColumnName) Then
				'Add user code here
				Dim value As String = e.ProposedValue.ToString
				e.Row.SetColumnError(e.Column.ColumnName, "")
				If Not String.IsNullOrEmpty(value) Then
					Dim strErrMessage As String = ""
					Dim strBits(4) As String
					If Not TranscriptionValidations.ValidateDate(value, strErrMessage, strBits, MyLeadingZeroOnDates, MyAddErrorNumberToMessage) Then
						e.Row.SetColumnError(e.Column.ColumnName, strErrMessage)
					End If
					e.ProposedValue = value
				End If
			End If

			If (e.Column.ColumnName = Me.SexColumn.ColumnName) Then
            'Add user code here
            Try
               If e.ProposedValue IsNot Nothing Then
                  Dim value As String = e.ProposedValue.ToString.ToUpper()
                  e.Row.SetColumnError(e.Column.ColumnName, "")
                  If Not String.IsNullOrEmpty(value) Then
                     If tabBapSex IsNot Nothing Then
                        If tabBapSex.FindByCode(value) Is Nothing Then
                           e.Row.SetColumnError(e.Column.ColumnName, IIf(MyAddErrorNumberToMessage, String.Format("????:{0}", String.Format("The value '{0}' is not present in the Baptism Sex table", value)), String.Format("The value '{0}' is not present in the Baptism Sex table", value)))
                           '						Else
                           '							Dim x = tabBapSex.FindByCode(value)
                           '							e.ProposedValue = x.Description
                        End If
                     Else
                        e.Row.SetColumnError(e.Column.ColumnName, IIf(MyAddErrorNumberToMessage, String.Format("????:{0}", String.Format("Baptism Sex table not linked to dataset", value)), String.Format("Baptism Sex table not linked to dataset", value)))
                     End If
                  End If
               Else
                  Beep()
               End If

            Catch ex As Exception

            End Try
         End If

		End Sub

		Private Sub BaptismsDataTable_BaptismsRowChanging(ByVal sender As System.Object, ByVal e As BaptismsRowChangeEvent) Handles Me.BaptismsRowChanging
         If e.Row.HasErrors Then
            Dim x = e.Row.GetColumnsInError().ToLookup(Function(a) a.ColumnName)
            If x.Contains("BirthDate") OrElse x.Contains("BaptismDate") Then Exit Sub
         End If

         If e.Row.RowState <> DataRowState.Deleted Then
            If Not String.IsNullOrEmpty(e.Row.BirthDate) And Not String.IsNullOrEmpty(e.Row.BaptismDate) Then
               If Not TranscriptionValidations.ValidateBirthAndBaptismDates(e.Row.BirthDate, e.Row.BaptismDate, MyAddErrorNumberToMessage) Then
                  e.Row.SetColumnError("BirthDate", IIf(MyAddErrorNumberToMessage, String.Format("0049:{0}", My.Resources.err0049), My.Resources.err0049))
               End If
            End If
         End If
      End Sub

      Private Sub BaptismsDataTable_BaptismsRowDeleting(sender As Object, e As BaptismsRowChangeEvent) Handles Me.BaptismsRowDeleting

      End Sub
   End Class

	Partial Class BurialsDataTable
		Private tabBurialRelationship As BurialRelationshipDataTable

		Public Sub LinkLookupTables(ByVal LeadingZeroOnDates As Boolean, ByVal AddErrorNumberToMessage As Boolean, ByVal burRelationship As BurialRelationshipDataTable)
			tabBurialRelationship = burRelationship
			MyLeadingZeroOnDates = LeadingZeroOnDates
			MyAddErrorNumberToMessage = AddErrorNumberToMessage
		End Sub

		Public Sub CopyPrivates(ByVal dst As BurialsDataTable)
			dst.tabBurialRelationship = Me.tabBurialRelationship
      End Sub

		Private Sub BurialsDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If (e.Column.ColumnName = Me.BurialDateColumn.ColumnName) Then
				'Add user code here
				Dim value As String = e.ProposedValue.ToString
				e.Row.SetColumnError(e.Column.ColumnName, "")
				If Not String.IsNullOrEmpty(value) Then
					Dim strErrMessage As String = ""
					Dim strBits(4) As String
					If Not TranscriptionValidations.ValidateDate(value, strErrMessage, strBits, MyLeadingZeroOnDates, MyAddErrorNumberToMessage) Then
						e.Row.SetColumnError(e.Column.ColumnName, strErrMessage)
					End If
					e.ProposedValue = value
				End If
			End If

			If (e.Column.ColumnName = Me.RelationshipColumn.ColumnName) Then
				'Add user code here
				Dim value As String = e.ProposedValue.ToString
				e.Row.SetColumnError(e.Column.ColumnName, "")
				If Not String.IsNullOrEmpty(value) Then
               If tabBurialRelationship IsNot Nothing Then
                  If tabBurialRelationship.FindByFileValue(value) Is Nothing Then
                     e.Row.SetColumnError(e.Column.ColumnName, IIf(MyAddErrorNumberToMessage, String.Format("????:{0}", String.Format("The value '{0}' is not present in the Burial Relationship table", value)), String.Format("The value '{0}' is not present in the Burial Relationship table", value)))
                     '						Else
                     '							Dim x = tabBurialRelationship.FindByFileValue(value)
                     '							e.ProposedValue = x.DisplayValue
                  End If
               Else
                  e.Row.SetColumnError(e.Column.ColumnName, IIf(MyAddErrorNumberToMessage, String.Format("????:{0}", String.Format("Burial Relationship table is not linked to dataset", value)), String.Format("Burial Relationship table is not linked to dataset", value)))
               End If
				End If
			End If

			If (e.Column.ColumnName = Me.AgeColumn.ColumnName) Then
				'Add user code here
				Dim value As String = e.ProposedValue.ToString
				e.Row.SetColumnError(e.Column.ColumnName, "")
				If Not String.IsNullOrEmpty(value) Then
					Dim strErrMessage As String = ""
					If Not TranscriptionValidations.ValidateBurialAge(value, strErrMessage, True, MyAddErrorNumberToMessage) Then
						e.Row.SetColumnError(e.Column.ColumnName, strErrMessage)
					End If
					e.ProposedValue = value
				End If
			End If

		End Sub

      Private Sub BurialsDataTable_BurialsRowChanging(sender As Object, e As BurialsRowChangeEvent) Handles Me.BurialsRowChanging

      End Sub

      Private Sub BurialsDataTable_BurialsRowDeleting(sender As Object, e As BurialsRowChangeEvent) Handles Me.BurialsRowDeleting

      End Sub
   End Class

	Partial Class MarriagesDataTable
		Private tabGroomCondition As GroomConditionDataTable
		Private tabBrideCondition As BrideConditionDataTable

		Public Sub LinkLookupTables(ByVal LeadingZeroOnDates As Boolean, ByVal AddErrorNumberToMessage As Boolean, ByVal marGroomCondition As GroomConditionDataTable, ByVal marBrideCondition As BrideConditionDataTable)
			tabGroomCondition = marGroomCondition
			tabBrideCondition = marBrideCondition
			MyLeadingZeroOnDates = LeadingZeroOnDates
			MyAddErrorNumberToMessage = AddErrorNumberToMessage
		End Sub

		Public Sub CopyPrivates(ByVal dst As MarriagesDataTable)
			dst.tabGroomCondition = Me.tabGroomCondition
			dst.tabBrideCondition = Me.tabBrideCondition
		End Sub

		Private Sub MarriagesDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If (e.Column.ColumnName = Me.MarriageDateColumn.ColumnName) Then
				'Add user code here
				Dim value As String = e.ProposedValue.ToString
				e.Row.SetColumnError(e.Column.ColumnName, "")
				If Not String.IsNullOrEmpty(value) Then
					Dim strErrMessage As String = ""
					Dim strBits(4) As String
					If Not TranscriptionValidations.ValidateDate(value, strErrMessage, strBits, MyLeadingZeroOnDates, MyAddErrorNumberToMessage) Then
						e.Row.SetColumnError(e.Column.ColumnName, strErrMessage)
					End If
					e.ProposedValue = value
				End If
			End If

			If (e.Column.ColumnName = Me.GroomConditionColumn.ColumnName) Then
				'Add user code here
				Dim value As String = e.ProposedValue.ToString
				e.Row.SetColumnError(e.Column.ColumnName, "")
				If Not String.IsNullOrEmpty(value) Then
					If tabGroomCondition IsNot Nothing Then
						If tabGroomCondition.FindByFileValue(value) Is Nothing Then
							e.Row.SetColumnError(e.Column.ColumnName, IIf(MyAddErrorNumberToMessage, String.Format("????:{0}", String.Format("The value '{0}' is not present in the Groom Condition table", value)), String.Format("The value '{0}' is not present in the Groom Condition table", value)))
							'						Else
							'							Dim x = tabGroomCondition.FindByFileValue(value)
							'							e.ProposedValue = x.DisplayValue
						End If
					Else
						e.Row.SetColumnError(e.Column.ColumnName, IIf(MyAddErrorNumberToMessage, String.Format("????:{0}", String.Format("Groom Condition table is not linked to dataset", value)), String.Format("Groom Condition table is not linked to dataset", value)))
					End If
				End If
			End If

			If (e.Column.ColumnName = Me.BrideConditionColumn.ColumnName) Then
				'Add user code here
				Dim value As String = e.ProposedValue.ToString
				e.Row.SetColumnError(e.Column.ColumnName, "")
				If Not String.IsNullOrEmpty(value) Then
					If tabBrideCondition IsNot Nothing Then
						If tabBrideCondition.FindByFileValue(value) Is Nothing Then
							e.Row.SetColumnError(e.Column.ColumnName, IIf(MyAddErrorNumberToMessage, String.Format("????:{0}", String.Format("The value '{0}' is not present in the Bride Condition table", value)), String.Format("The value '{0}' is not present in the bride Condition table", value)))
							'						Else
							'							Dim x = tabBrideCondition.FindByFileValue(value)
							'							e.ProposedValue = x.DisplayValue
						End If
					Else
						e.Row.SetColumnError(e.Column.ColumnName, IIf(MyAddErrorNumberToMessage, String.Format("????:{0}", String.Format("Bride Condition table is not linked to dataset", value)), String.Format("Bride Condition table is not linked to dataset", value)))
					End If
				End If
			End If

			If (e.Column.ColumnName = Me.BrideAgeColumn.ColumnName) Then
				'Add user code here
				Dim value As String = e.ProposedValue.ToString
				e.Row.SetColumnError(e.Column.ColumnName, "")
				If Not String.IsNullOrEmpty(value) Then
					Dim strErrMessage As String = ""
					If Not TranscriptionValidations.ValidateMarriageAge(value, strErrMessage, "Bride", True, MyAddErrorNumberToMessage) Then
						e.Row.SetColumnError(e.Column.ColumnName, strErrMessage)
					End If
					e.ProposedValue = value
				End If
			End If

			If (e.Column.ColumnName = Me.GroomAgeColumn.ColumnName) Then
				'Add user code here
				Dim value As String = e.ProposedValue.ToString
				e.Row.SetColumnError(e.Column.ColumnName, "")
				If Not String.IsNullOrEmpty(value) Then
					Dim strErrMessage As String = ""
					If Not TranscriptionValidations.ValidateMarriageAge(value, strErrMessage, "Groom", True, MyAddErrorNumberToMessage) Then
						e.Row.SetColumnError(e.Column.ColumnName, strErrMessage)
					End If
					e.ProposedValue = value
				End If
			End If

      End Sub

      Private Sub MarriagesDataTable_MarriagesRowChanging(sender As Object, e As MarriagesRowChangeEvent) Handles Me.MarriagesRowChanging

      End Sub

      Private Sub MarriagesDataTable_MarriagesRowDeleting(sender As Object, e As MarriagesRowChangeEvent) Handles Me.MarriagesRowDeleting

      End Sub
   End Class

End Class
