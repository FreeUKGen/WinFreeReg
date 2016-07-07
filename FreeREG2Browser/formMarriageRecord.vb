Imports System.Windows.Forms
Imports System.IO

Public Class formMarriageRecord

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

   Private Sub formMarriageRecord_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

   End Sub

   Private Sub formMarriageRecord_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      Select Case e.CloseReason
         Case CloseReason.None
            Select Case Me.DialogResult
               Case Windows.Forms.DialogResult.OK
                  Dim row = CType(m_ErrorRecord.Row, TranscriptionTables.MarriagesRow)
                  row.RegNo = RegNoTextBox.Text
                  row.MarriageDate = MarriageDateTextBox.Text
                  row.GroomForenames = MarriageDateTextBox.Text
                  row.GroomSurname = GroomSurnameTextBox.Text
                  row.GroomAge = GroomAgeTextBox.Text
                  row.GroomParish = GroomParishTextBox.Text
                  row.GroomCondition = GroomConditionComboBox.SelectedValue
                  row.GroomOccupation = GroomOccupationTextBox.Text
                  row.GroomAbode = GroomAbodeTextBox.Text
                  row.BrideForenames = BrideForenamesTextBox.Text
                  row.BrideSurname = BrideSurnameTextBox.Text
                  row.BrideAge = BrideAgeTextBox.Text
                  row.BrideParish = BrideParishTextBox.Text
                  row.BrideCondition = BrideConditionComboBox.SelectedValue
                  row.BrideOccupation = BrideOccupationTextBox.Text
                  row.BrideAbode = BrideAbodeTextBox.Text
                  row.GroomFatherForenames = GroomFatherForenamesTextBox.Text
                  row.GroomFatherSurname = GroomFatherSurnameTextBox.Text
                  row.GroomFatherOccupation = GroomFatherOccupationTextBox.Text
                  row.BrideFatherForenames = BrideFatherForenamesTextBox.Text
                  row.BrideFatherSurname = BrideFatherSurnameTextBox.Text
                  row.BrideFatherOccupation = BrideFatherOccupationTextBox.Text
                  row.Witness1Forenames = Witness1ForenamesTextBox.Text
                  row.Witness1Surname = Witness1SurnameTextBox.Text
                  row.Witness2Forenames = Witness2ForenamesTextBox.Text
                  row.Witness2Surname = Witness2SurnameTextBox.Text
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

   Private Sub ReloadRecord(ByVal row As TranscriptionTables.MarriagesRow)
      With row
         RegNoTextBox.Text = .RegNo
         MarriageDateTextBox.Text = .MarriageDate
         GroomForenamesTextBox.Text = .GroomForenames
         GroomSurnameTextBox.Text = .GroomSurname
         GroomAgeTextBox.Text = .GroomAge
         GroomParishTextBox.Text = .GroomParish
         GroomConditionComboBox.SelectedIndex = GroomConditionBindingSource.Find("FileValue", .GroomCondition)
         GroomOccupationTextBox.Text = .GroomOccupation
         GroomAbodeTextBox.Text = .GroomAbode
         BrideForenamesTextBox.Text = .BrideForenames
         BrideSurnameTextBox.Text = .BrideSurname
         BrideAgeTextBox.Text = .BrideAge
         BrideParishTextBox.Text = .BrideParish
         BrideConditionComboBox.SelectedIndex = BrideConditionBindingSource.Find("FileValue", .BrideCondition)
         BrideOccupationTextBox.Text = .BrideOccupation
         BrideAbodeTextBox.Text = .BrideAbode
         GroomFatherForenamesTextBox.Text = .GroomFatherForenames
         GroomFatherSurnameTextBox.Text = .GroomFatherSurname
         GroomFatherOccupationTextBox.Text = .GroomFatherOccupation
         BrideFatherForenamesTextBox.Text = .BrideFatherForenames
         BrideFatherSurnameTextBox.Text = .BrideFatherSurname
         BrideFatherOccupationTextBox.Text = .BrideFatherOccupation
         Witness1ForenamesTextBox.Text = .Witness1Forenames
         Witness1SurnameTextBox.Text = .Witness1Surname
         Witness2ForenamesTextBox.Text = .Witness2Forenames
         Witness2SurnameTextBox.Text = .Witness2Surname
         NotesTextBox.Text = .Notes
         LDSFicheTextBox.Text = .LDSFiche
         LDSImageTextBox.Text = .LDSImage
      End With

      For Each col As DataColumn In m_ErrorRecord.ColumnName
         Dim c1 As DataColumn = col
         Dim c As List(Of Control) = Controls().Cast(Of Control)().Where(Function(ctl As Control) ctl.Tag IsNot Nothing AndAlso ctl.Tag.ToString() = c1.ColumnName).ToList()
         Dim errStr = row.GetColumnError(col.ColumnName)
         MarriageErrorProvider.SetError(c(0), errStr)
      Next
   End Sub

   Private Sub formMarriageRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ReloadRecord(CType(m_ErrorRecord.Row, TranscriptionTables.MarriagesRow))

      Dim AppDataLocalFolder = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName)
      Dim ToolTipsFile As String = Path.Combine(AppDataLocalFolder, "ToolTips.xml")
      Dim MyToolTips = New CustomToolTip(ToolTipsFile, Me)
   End Sub

   'Public Function DecodeBrideCondition(ByVal Description As String) As String
   '	Dim dt As LookupTables.BrideConditionDataTable = m_Lookups.BrideCondition
   '	Dim x = dt.AsEnumerable().Where(Function(row As LookupTables.BrideConditionRow) row.DisplayValue = Description)
   '	If x Is Nothing OrElse x.Count = 0 Then Return Description
   '	Return x(0).FileValue
   'End Function

   'Public Function DecodeGroomCondition(ByVal Description As String) As String
   '	Dim dt As LookupTables.GroomConditionDataTable = m_Lookups.GroomCondition
   '	Dim x = dt.AsEnumerable().Where(Function(row As LookupTables.GroomConditionRow) row.DisplayValue = Description)
   '	If x Is Nothing OrElse x.Count = 0 Then Return Description
   '	Return x(0).FileValue
   'End Function

End Class