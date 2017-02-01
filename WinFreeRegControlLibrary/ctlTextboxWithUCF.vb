Public Class ctlTextboxWithUCF

   Private m_CellValue As String
   Public Property Value() As String
      Get
         Return m_CellValue
      End Get
      Set(ByVal value As String)
         m_CellValue = value
      End Set
   End Property

   Private m_CharacterCasing As CharacterCasing
   Public Property CharacterCasing() As CharacterCasing
      Get
         Return m_CharacterCasing
      End Get
      Set(ByVal value As CharacterCasing)
         m_CharacterCasing = value
      End Set
   End Property

   Private m_LocationChangedCount As Integer = 0
   Private m_TargetLocation As New Point(0, 0)
   Public Property TargetLocation() As Point
      Get
         Return m_TargetLocation
      End Get
      Set(value As Point)
         m_TargetLocation = value
         Console.WriteLine(String.Format("Create:: target: {0}", m_TargetLocation))
      End Set
   End Property

   Private m_CellName As String
   Public Property CellName() As String
      Get
         Return m_CellName
      End Get
      Set(ByVal value As String)
         m_CellName = value
      End Set
   End Property

   Sub New()
      ' This call is required by the designer.
      InitializeComponent()
   End Sub

   Sub New(ByVal columnName As String, ByVal columnValue As String)
      InitializeComponent()

      CellName = columnName
      Value = columnValue
      CharacterCasing = Windows.Forms.CharacterCasing.Normal
   End Sub

   Private Sub ctlTextboxWithUCF_Load(sender As Object, e As EventArgs) Handles Me.Load
      labColumn.Text = CellName
      txtField.Text = Value
      txtField.CharacterCasing = CharacterCasing
      Me.SetBounds(TargetLocation.X - txtField.Location.X - Margin.Left, TargetLocation.Y - txtField.Location.Y - Margin.Top, 0, 0, BoundsSpecified.Location)
      Console.WriteLine(String.Format("Load: {0}, Location: {1} TextBox: {2}", CellName, Me.Location, txtField.Location))
      SelectNextControl(txtField, True, True, True, True)
   End Sub

   Private Sub txtField_TextChanged(sender As Object, e As EventArgs) Handles txtField.TextChanged
      Value = txtField.Text
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         ' F5 is the key in WinREG that starts the UCF dialog
         '
         Using dlg As New dlgUCF
            dlg._ucf.FieldName = CellName
            dlg._ucf.FieldText = Value
            dlg._ucf.InsertionPoint = txtField.SelectionStart
            dlg.StartPosition = FormStartPosition.WindowsDefaultLocation

            If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Value = dlg._ucf.FieldText
               txtField.SelectionStart = dlg._ucf.InsertionPoint
            End If
         End Using
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

End Class
