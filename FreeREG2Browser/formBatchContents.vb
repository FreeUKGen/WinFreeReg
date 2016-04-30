Imports System.Windows.Forms
Imports System.IO

Public Class formBatchContents

	Private _initialPath As String
	Public Property PersonalPath() As String
		Get
			Return _initialPath
		End Get
		Set(ByVal value As String)
			_initialPath = value
		End Set
	End Property

	Private _currentBatch As Batches.BatchRow
	Public Property CurrentBatch() As Batches.BatchRow
		Get
			Return _currentBatch
		End Get
		Set(ByVal value As Batches.BatchRow)
			_currentBatch = value
		End Set
	End Property

	Private Sub formBatchContents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		FileContentsTextBox.Select(0, 0)
	End Sub

	Private Sub btnSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveFile.Click
		Dim contents As String = FileContentsTextBox.Text

		Using dlg As New SaveFileDialog
			dlg.Title = "Save " & CurrentBatch.FileName
			dlg.Filter = "Transcription files|*.csv"
			dlg.InitialDirectory = PersonalPath
			dlg.AddExtension = False
			dlg.CreatePrompt = False
			dlg.OverwritePrompt = True
			dlg.RestoreDirectory = True
			dlg.FileName = CurrentBatch.FileName

			Dim rc As DialogResult = dlg.ShowDialog()
			If rc = DialogResult.OK Then
				Try
					File.WriteAllText(dlg.FileName, contents)
					File.SetCreationTime(dlg.FileName, _currentBatch.UploadedDate)
					File.SetLastAccessTime(dlg.FileName, _currentBatch.UploadedDate)
					File.SetLastWriteTime(dlg.FileName, _currentBatch.UploadedDate)

				Catch ex As Exception

				Finally
				End Try
			Else
			End If

		End Using
	End Sub

End Class