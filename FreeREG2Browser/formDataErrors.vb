Imports BrightIdeasSoftware
Imports System.Drawing
Imports System.Windows.Forms

Public Class formDataErrors

   Private formHelp As formGeneralHelp = Nothing
   Sub New(HelpForm As formGeneralHelp)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      formHelp = HelpForm
   End Sub

   Private m_Lookups As WinFreeReg.LookupTables
   Public Property Lookups() As WinFreeReg.LookupTables
      Get
         Return m_Lookups
      End Get
      Set(ByVal value As WinFreeReg.LookupTables)
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
            Using dlg As New dlgCorrectTableError(formHelp)
               dlg.txtTableName.Text = "Baptism Sex"
               dlg.txtFileValue.Text = row.Code
               dlg.txtDisplayValue.Text = row.Description
               dlg.labError.Text = objActivated.ColummnError
               dlg.ShowDialog()
            End Using

         Case "BurialRelationship"
            Dim dt = m_Lookups.BurialRelationship
            Dim row = dt.FindByFileValue(objActivated.Row(1))
            Using dlg As New dlgCorrectTableError(formHelp)
               dlg.txtTableName.Text = "Burial Relationship"
               dlg.txtFileValue.Text = row.FileValue
               dlg.txtDisplayValue.Text = row.DisplayValue
               dlg.labError.Text = objActivated.ColummnError
               dlg.ShowDialog()
            End Using

         Case "GroomCondition"
            Dim dt = m_Lookups.GroomCondition
            Dim row = dt.FindByFileValue(objActivated.Row(1))
            Using dlg As New dlgCorrectTableError(formHelp)
               dlg.txtTableName.Text = "Groom Condition"
               dlg.txtFileValue.Text = row.FileValue
               dlg.txtDisplayValue.Text = row.DisplayValue
               dlg.labError.Text = objActivated.ColummnError
               dlg.ShowDialog()
            End Using

         Case "BrideCondition"
            Dim dt = m_Lookups.BrideCondition
            Dim row = dt.FindByFileValue(objActivated.Row(1))
            Using dlg As New dlgCorrectTableError(formHelp)
               dlg.txtTableName.Text = "Bride Condition"
               dlg.txtFileValue.Text = row.FileValue
               dlg.txtDisplayValue.Text = row.DisplayValue
               dlg.labError.Text = objActivated.ColummnError
               dlg.ShowDialog()
            End Using

         Case "Baptisms"
            Using dlg As New formBaptismRecord(formHelp) With {.Lookups = m_Lookups, .ErrorRecord = objActivated}
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
            Using dlg As New formBurialRecord(formHelp) With {.Lookups = m_Lookups, .ErrorRecord = objActivated}
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
            Using dlg As New formMarriageRecord(formHelp) With {.Lookups = m_Lookups, .ErrorRecord = objActivated}
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

   Private Sub formTablesErrors_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
      Try
         formHelp.Title = "Data Errors"
         formHelp.StartPage = "TableErrors.html"
         formHelp.Show()

      Catch ex As Exception
         formHelp.Hide()
         MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try
   End Sub
End Class
