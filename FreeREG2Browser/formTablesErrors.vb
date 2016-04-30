Imports BrightIdeasSoftware
Imports System.Drawing

Public Class formTablesErrors

	Private m_Lookups As WinREG.LookupTables
	Public Property Lookups() As WinREG.LookupTables
		Get
			Return m_Lookups
		End Get
		Set(ByVal value As WinREG.LookupTables)
			m_Lookups = value
		End Set
	End Property

	Private Sub formTablesErrors_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
	End Sub

	Private Sub formTablesErrors_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
	End Sub

	Private Sub formTablesErrors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	End Sub

	Private Sub olvErrors_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles olvErrors.ItemActivate
		Dim objActivated = CType(olvErrors.SelectedObject(), classUncorrectedErrors)
		Select Case objActivated.TableName
			Case "BaptismSex"
				Dim dt = m_Lookups.BaptismSex
				Dim row = dt.FindByCode(objActivated.Row(1))
				Using dlg As New dlgCorrectTableError()
					dlg.txtTableName.Text = "Baptism Sex"
					dlg.txtFileValue.Text = row.Code
					dlg.txtDisplayValue.Text = row.Description
					dlg.labError.Text = objActivated.ColummnError
					dlg.ShowDialog()
				End Using

			Case "BurialRelationship"
				Dim dt = m_Lookups.BurialRelationship
				Dim row = dt.FindByFileValue(objActivated.Row(1))
				Using dlg As New dlgCorrectTableError()
					dlg.txtTableName.Text = "Burial Relationship"
					dlg.txtFileValue.Text = row.FileValue
					dlg.txtDisplayValue.Text = row.DisplayValue
					dlg.labError.Text = objActivated.ColummnError
					dlg.ShowDialog()
				End Using

			Case "GroomCondition"
				Dim dt = m_Lookups.GroomCondition
				Dim row = dt.FindByFileValue(objActivated.Row(1))
				Using dlg As New dlgCorrectTableError()
					dlg.txtTableName.Text = "Groom Condition"
					dlg.txtFileValue.Text = row.FileValue
					dlg.txtDisplayValue.Text = row.DisplayValue
					dlg.labError.Text = objActivated.ColummnError
					dlg.ShowDialog()
				End Using

			Case "BrideCondition"
				Dim dt = m_Lookups.BrideCondition
				Dim row = dt.FindByFileValue(objActivated.Row(1))
				Using dlg As New dlgCorrectTableError()
					dlg.txtTableName.Text = "Bride Condition"
					dlg.txtFileValue.Text = row.FileValue
					dlg.txtDisplayValue.Text = row.DisplayValue
					dlg.labError.Text = objActivated.ColummnError
					dlg.ShowDialog()
				End Using

			Case "Baptisms"
				Using dlg As New formBaptismRecord With {.Lookups = m_Lookups, .ErrorRecord = objActivated}
					dlg.BaptismSexBindingSource.DataSource = m_Lookups
					dlg.ShowDialog()
					Select Case dlg.DialogResult
						Case Windows.Forms.DialogResult.OK
							olvErrors.RemoveObject(objActivated)
						Case Windows.Forms.DialogResult.Cancel
							olvErrors.RefreshObject(objActivated)
					End Select
				End Using

			Case "Burials"
				Using dlg As New formBurialRecord With {.Lookups = m_Lookups, .ErrorRecord = objActivated}
					dlg.BurialRelationshipBindingSource.DataSource = m_Lookups
					dlg.ShowDialog()
					Select Case dlg.DialogResult
						Case Windows.Forms.DialogResult.OK
							olvErrors.RemoveObject(objActivated)
						Case Windows.Forms.DialogResult.Cancel
							olvErrors.RefreshObject(objActivated)
					End Select
				End Using

			Case "Marriages"
				Using dlg As New formMarriageRecord With {.Lookups = m_Lookups, .ErrorRecord = objActivated}
					dlg.GroomConditionBindingSource.DataSource = m_Lookups
					dlg.BrideConditionBindingSource.DataSource = m_Lookups
					dlg.ShowDialog()
					Select Case dlg.DialogResult
						Case Windows.Forms.DialogResult.OK
							olvErrors.RemoveObject(objActivated)
						Case Windows.Forms.DialogResult.Cancel
							olvErrors.RefreshObject(objActivated)
					End Select
				End Using

		End Select
	End Sub
End Class