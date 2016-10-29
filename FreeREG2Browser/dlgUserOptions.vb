Imports System.Windows.Forms
Imports BrightIdeasSoftware.ObjectListView
Imports System.IO

Public Class dlgUserOptions

   Private formHelp As formGeneralHelp = Nothing
   Sub New(HelpForm As formGeneralHelp)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      formHelp = HelpForm
   End Sub

   Private _selectedValue As CellEditActivateMode
   Public Property SelectedValue() As CellEditActivateMode
      Get
         Return _selectedValue
      End Get
      Set(ByVal value As CellEditActivateMode)
         _selectedValue = value
      End Set
   End Property

   Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.OK
   End Sub

   Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub dlgUserOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Dim AppDataLocalFolder = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName)
      Dim ToolTipsFile As String = Path.Combine(AppDataLocalFolder, "ToolTips.xml")
      Dim MyToolTips = New CustomToolTip(ToolTipsFile, Me)

      radioDoubleClick.Tag = CellEditActivateMode.DoubleClick
      radioF2Only.Tag = CellEditActivateMode.F2Only
      radioSingleClick.Tag = CellEditActivateMode.SingleClick
      radioSingleClickAlways.Tag = CellEditActivateMode.SingleClickAlways
      Dim rButton As RadioButton = groupCellEditActivation.Controls.OfType(Of RadioButton)().FirstOrDefault(Function(r) r.Tag = _selectedValue)
      rButton.Checked = True

      checkShowEditingCellBorder.Checked = My.Settings.optionEditingCellBorder

      labelFont.Font = My.Settings.optionFont
      labelFont.Text = String.Format("{0}, {1}, {2}", My.Settings.optionFont.Name, My.Settings.optionFont.SizeInPoints, My.Settings.optionFont.Style)

   End Sub

   Private Sub radio_CheckedChanged(sender As Object, e As EventArgs) Handles radioSingleClick.CheckedChanged, radioSingleClickAlways.CheckedChanged, radioF2Only.CheckedChanged, radioDoubleClick.CheckedChanged
      Dim button = CType(sender, RadioButton)
      If button.Checked Then _selectedValue = button.Tag
   End Sub

   Private Shadows Sub HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
      Try
         formHelp.Title = "User Options"
         formHelp.StartPage = "userOptions.html"
         formHelp.Show()

      Catch ex As Exception
         formHelp.Hide()
         MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try
   End Sub

   Private Sub labelFont_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles labelFont.LinkClicked
      Using dlg As New FontDialog()
         dlg.Font = My.Settings.optionFont

         If dlg.ShowDialog() = DialogResult.OK Then
            If dlg.Font.Equals(My.Settings.optionFont) = False Then
               My.Settings.optionFont = dlg.Font
               labelFont.Font = My.Settings.optionFont
               labelFont.Text = String.Format("{0}, {1}, {2}", My.Settings.optionFont.Name, My.Settings.optionFont.SizeInPoints, My.Settings.optionFont.Style)
            End If
         End If
      End Using
   End Sub
End Class
