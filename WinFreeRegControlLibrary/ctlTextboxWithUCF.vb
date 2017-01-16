Public Class ctlTextboxWithUCF

   Private _Value As String
   Public Property Value() As String
      Get
         Return _Value
      End Get
      Set(ByVal value As String)
         _Value = value
         txtField.Text = value
      End Set
   End Property

   Private _CharacterCasing As CharacterCasing
   Public Property CharacterCasing() As CharacterCasing
      Get
         Return _CharacterCasing
      End Get
      Set(ByVal value As CharacterCasing)
         _CharacterCasing = value
         txtField.CharacterCasing = value
      End Set
   End Property

   Sub New()
      ' This call is required by the designer.
      InitializeComponent()

      ' TODO: Complete member initialization 
   End Sub

   Private Sub txtField_TextChanged(sender As Object, e As EventArgs) Handles txtField.TextChanged
      _Value = txtField.Text
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         ' F5 is the key in WinREG that starts the UCF dialog
         '
         Using dlg As New dlgUCF
            dlg._ucf.FieldName = txtField.Name
            dlg._ucf.FieldText = txtField.Text
            dlg._ucf.InsertionPoint = txtField.SelectionStart

            If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Value = dlg._ucf.FieldText
               txtField.SelectionStart = dlg._ucf.InsertionPoint
            End If
         End Using
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

   Private Sub ctlTextboxWithUCF_Load(sender As Object, e As EventArgs) Handles Me.Load
      SelectNextControl(txtField, True, True, True, True)
   End Sub
End Class
