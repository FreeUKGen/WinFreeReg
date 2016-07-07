Imports System.Windows.Forms
Imports System.IO

Public Class dlgToolTips

   Private m_FileName As String
   Public Property FileName() As String
      Get
         Return m_FileName
      End Get
      Set(ByVal value As String)
         m_FileName = value
      End Set
   End Property

   Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Sub New(ByRef name As String)
      InitializeComponent()

      If String.IsNullOrEmpty(name) Then Throw New ArgumentNullException("name", "A valid pathname must be assigned when creating the DLG")
      m_FileName = name
   End Sub

   Private Sub dlgToolTips_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then Exit Sub

      If File.Exists(m_FileName) Then File.SetAttributes(m_FileName, File.GetAttributes(m_FileName) And (Not FileAttributes.ReadOnly))
      ToolTips.AcceptChanges()
      ToolTips.WriteXml(m_FileName, XmlWriteMode.WriteSchema)
      If File.Exists(m_FileName) Then File.SetAttributes(m_FileName, File.GetAttributes(m_FileName) Or FileAttributes.ReadOnly)
   End Sub

   Private Sub dlgToolTips_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then Exit Sub

      If ToolTips.Tables("ToolTips").HasErrors Then
         Dim errors As WinFreeReg.ToolTips.ToolTipsRow() = ToolTips.Tables("ToolTips").GetErrors()
         e.Cancel = True
      Else
         Dim changes As WinFreeReg.ToolTips.ToolTipsDataTable = CType(ToolTips.Tables("ToolTips"), WinFreeReg.ToolTips.ToolTipsDataTable).GetChanges()
         If changes IsNot Nothing Then
            For Each row In changes.Rows
               Beep()
            Next
         End If
      End If
   End Sub

   Private Sub dlgToolTips_Load(sender As Object, e As EventArgs) Handles Me.Load
      If File.Exists(m_FileName) Then ToolTips.ReadXml(m_FileName)
   End Sub
End Class
