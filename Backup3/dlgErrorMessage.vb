Imports System.Windows.Forms
Imports System.IO

Public Class dlgErrorMessage

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

	Private Sub dlgErrorMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		If File.Exists(m_FileName) Then ErrorMessages.ReadXml(m_FileName)

		NumberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
	End Sub

	Private Sub dlgErrorMessage_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
		If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then Exit Sub

		If ErrorMessages.Tables("ErrorMessages").HasErrors Then
			Dim errors As WinREG.ErrorMessages.ErrorMessagesRow() = ErrorMessages.Tables("ErrorMessages").GetErrors()
			e.Cancel = True
		Else
			Dim changes As WinREG.ErrorMessages.ErrorMessagesDataTable = CType(ErrorMessages.Tables("ErrorMessages"), WinREG.ErrorMessages.ErrorMessagesDataTable).GetChanges()
			If changes IsNot Nothing Then
				For Each row In changes.Rows
					Beep()
				Next
			End If
		End If
	End Sub

	Private Sub dlgErrorMessage_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
		If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then Exit Sub

		If File.Exists(m_FileName) Then File.SetAttributes(m_FileName, File.GetAttributes(m_FileName) And (Not FileAttributes.ReadOnly))
		ErrorMessages.AcceptChanges()
		ErrorMessages.WriteXml(m_FileName, XmlWriteMode.WriteSchema)
		If File.Exists(m_FileName) Then File.SetAttributes(m_FileName, File.GetAttributes(m_FileName) Or FileAttributes.ReadOnly)
	End Sub
End Class
