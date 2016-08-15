Imports System.Windows.Forms
Imports System.IO

Public Class formBurialRecord

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

   Private m_ErrorRecord As classUncorrectedErrors
   Public Property ErrorRecord() As classUncorrectedErrors
      Get
         Return m_ErrorRecord
      End Get
      Set(ByVal value As classUncorrectedErrors)
         m_ErrorRecord = value
      End Set
   End Property

   Private Sub formBurialRecord_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

   End Sub

   Private Sub formBurialRecord_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      Select Case e.CloseReason
         Case CloseReason.None
            Select Case Me.DialogResult
               Case Windows.Forms.DialogResult.OK
                  Dim row = CType(m_ErrorRecord.Row, TranscriptionTables.BurialsRow)
                  row.RegNo = RegNoTextBox.Text
                  row.BurialDate = BurialDateTextBox.Text
                  row.Forenames = ForenamesTextBox.Text
                  row.Relationship = RelationshipComboBox.SelectedValue
                  row.MaleForenames = MaleForenamesTextBox.Text
                  row.FemaleForenames = FemaleForenamesTextBox.Text
                  row.RelativeSurname = RelativeSurnameTextBox.Text
                  row.Surname = SurnameTextBox.Text
                  row.Age = AgeTextBox.Text
                  row.Abode = AbodeTextBox.Text
                  row.Notes = NotesTextBox.Text
                  row.LDSFiche = LDSFicheTextBox.Text
                  row.LDSImage = LDSImageTextBox.Text
                  If row.HasErrors Then
                     Dim errColumns = row.GetColumnsInError()
                     m_ErrorRecord.TableName = row.Table.TableName
                     m_ErrorRecord.Row = row
                     ReloadRecord(row)
                     e.Cancel = True
                  Else
                     m_ErrorRecord.TableName = ""
                  End If

               Case Windows.Forms.DialogResult.Cancel
            End Select

         Case CloseReason.UserClosing
         Case CloseReason.WindowsShutDown
         Case Else
      End Select
   End Sub

   Private Sub ReloadRecord(ByVal row As TranscriptionTables.BurialsRow)
      With row
         RegNoTextBox.Text = .RegNo
         BurialDateTextBox.Text = .BurialDate
         ForenamesTextBox.Text = .Forenames
         RelationshipComboBox.SelectedIndex = BurialRelationshipBindingSource.Find("FileValue", .Relationship)
         MaleForenamesTextBox.Text = .MaleForenames
         FemaleForenamesTextBox.Text = .FemaleForenames
         RelativeSurnameTextBox.Text = .RelativeSurname
         SurnameTextBox.Text = .Surname
         AgeTextBox.Text = .Age
         AbodeTextBox.Text = .Abode
         NotesTextBox.Text = .Notes
         LDSFicheTextBox.Text = .LDSFiche
         LDSImageTextBox.Text = .LDSImage
      End With

      For Each col As DataColumn In m_ErrorRecord.ColumnName
         Dim c1 As DataColumn = col
         Dim c As List(Of Control) = Controls().Cast(Of Control)().Where(Function(ctl As Control) ctl.Tag IsNot Nothing AndAlso ctl.Tag.ToString() = c1.ColumnName).ToList()
         Dim errStr = row.GetColumnError(col.ColumnName)
         ErrorProvider1.SetError(c(0), errStr)
      Next
   End Sub

   Private Sub formBurialRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ReloadRecord(CType(m_ErrorRecord.Row, TranscriptionTables.BurialsRow))

      Dim AppDataLocalFolder = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName)
      Dim ToolTipsFile As String = Path.Combine(AppDataLocalFolder, "ToolTips.xml")
      Dim MyToolTips = New CustomToolTip(ToolTipsFile, Me)
   End Sub

   'Public Function DecodeBurialRelationship(ByVal Description As String) As String
   '	Dim dt As LookupTables.BurialRelationshipDataTable = m_Lookups.BurialRelationship
   '	Dim x = dt.AsEnumerable().Where(Function(row As LookupTables.BurialRelationshipRow) row.DisplayValue = Description)
   '	If x Is Nothing OrElse x.Count = 0 Then Return Description
   '	Return x(0).FileValue
   'End Function

   Private Sub formBurialRecord_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
      Try
         formHelp.Title = "Correct Burial Errors"
         formHelp.StartPage = "BurialErrors.html"
         formHelp.Show()

      Catch ex As Exception
         formHelp.Hide()
         MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try
   End Sub
End Class
