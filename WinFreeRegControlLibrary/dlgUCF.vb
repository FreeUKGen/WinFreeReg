Imports System.Windows.Forms

Public Class dlgUCF
   Dim fRestoreComplete As Boolean = True
   Property formHelp As formGeneralHelp

   Public _ucf As UCFDataClass = New UCFDataClass

   Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUcfOK.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._ucf.FieldText = txtDataField.Text
      Me._ucf.InsertionPoint = txtDataField.SelectionStart
      Me.Close()
   End Sub

   Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUcfCancel.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub UCFdialog_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      My.Settings.MyUCFWindowState = Me.WindowState

      If Me.WindowState = FormWindowState.Normal Then
         '			My.Settings.MyUCFSize = Me.Size
         My.Settings.MyUCFLocation = Me.Location
      Else
         '			My.Settings.MyUCFSize = Me.RestoreBounds.Size
         My.Settings.MyUCFLocation = Me.RestoreBounds.Location
      End If
      My.Settings.Save()
   End Sub

   Private Sub UCFdialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Restore window state & position
      '		Me.Size = My.Settings.MyUCFSize
      Me.Location = My.Settings.MyUCFLocation
      Me.WindowState = My.Settings.MyUCFWindowState

      lbl1Either.Visible = False
      txt1Either.Visible = False
      lbl1Or.Visible = False
      txt1Or.Visible = False

      lbl2Leader.Visible = False
      nud2CannotRead.Visible = False
      lbl2Chars.Visible = False

      lbl3Leader.Visible = False
      txt3Letter.Visible = False

      lbl4Leader.Visible = False
      nud4From.Visible = False
      lbl4Or.Visible = False
      nud4To.Visible = False
      lbl4Chars.Visible = False

      txtDataField.Text = Me._ucf.FieldText
      txtDataField.SelectionStart = Me._ucf.InsertionPoint
      txtDataField.SelectionLength = 0
      txtDataField.Focus()
   End Sub

   Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
      If RadioButton1.Checked Then
         lbl1Either.Visible = True
         txt1Either.Visible = True
         lbl1Or.Visible = True
         txt1or.visible = True
      Else
         lbl1Either.Visible = False
         txt1Either.Visible = False
         lbl1Or.Visible = False
         txt1Or.Visible = False
      End If
   End Sub

   Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
      If RadioButton2.Checked Then
         lbl2Leader.Visible = True
         nud2CannotRead.Visible = True
         lbl2Chars.Visible = True
      Else
         lbl2Leader.Visible = False
         nud2CannotRead.Visible = False
         lbl2Chars.Visible = False
      End If
   End Sub

   Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
      If RadioButton3.Checked Then
         lbl3Leader.Visible = True
         txt3Letter.Visible = True
      Else
         lbl3Leader.Visible = False
         txt3Letter.Visible = False
      End If
   End Sub

   Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
      If RadioButton4.Checked Then
         lbl4Leader.Visible = True
         nud4from.visible = True
         lbl4Or.Visible = True
         nud4To.Visible = True
         lbl4Chars.Visible = True
      Else
         lbl4Leader.Visible = False
         nud4From.Visible = False
         lbl4Or.Visible = False
         nud4To.Visible = False
         lbl4Chars.Visible = False
      End If
   End Sub

   Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
      If RadioButton5.Checked Then
      Else
      End If
   End Sub

   Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
      If RadioButton6.Checked Then
      Else
      End If
   End Sub

   Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
      Dim strToInsert As String

      If RadioButton1.Checked Then
         strToInsert = "[" + txt1Either.Text + txt1Or.Text + "]"
      ElseIf RadioButton2.Checked Then
         strToInsert = ""
         strToInsert = strToInsert.PadLeft(nud2CannotRead.Value, "_"c)
      ElseIf RadioButton3.Checked Then
         strToInsert = "[" + txt3Letter.Text + "_]"
      ElseIf RadioButton4.Checked Then
         strToInsert = "_{" + nud4From.Value.ToString() + "," + nud4To.Value.ToString() + "}"
      ElseIf RadioButton5.Checked Then
         strToInsert = "*"
      Else
         strToInsert = "_{0,1}"
      End If

      Me._ucf.InsertionPoint = txtDataField.SelectionStart
      txtDataField.Text = txtDataField.Text.Insert(txtDataField.SelectionStart, strToInsert)
      txtDataField.SelectionStart = Me._ucf.InsertionPoint + strToInsert.Length
      txtDataField.Focus()
   End Sub

   Private Sub txtDataField_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDataField.KeyPress
      Me._ucf.InsertionPoint = txtDataField.SelectionStart
      Me._ucf.FieldText = txtDataField.Text
   End Sub

   Private Sub dlgUCF_HelpButtonClicked(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
      If formHelp IsNot Nothing Then
         Try
            formHelp.Title = "UCF Helper"
            formHelp.StartPage = "UncertainCharacterFormat.html"
            formHelp.Show()

         Catch ex As Exception
            formHelp.Hide()
            MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

         End Try
      Else
         e.Cancel = True
      End If
   End Sub

   Private Sub dlgUCF_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles MyBase.HelpRequested
      If formHelp IsNot Nothing Then
         Try
            formHelp.Title = "UCF Helper"
            formHelp.StartPage = "UncertainCharacterFormat.html"
            formHelp.Show()

         Catch ex As Exception
            formHelp.Hide()
            MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

         End Try
      End If
   End Sub
End Class
