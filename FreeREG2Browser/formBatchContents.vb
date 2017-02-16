Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.WindowsAPICodePack.Shell

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

   Property UseLibrary As Boolean

   Property LibraryName As String

   Property formHelp As formGeneralHelp

   Private Sub formBatchContents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      FileContentsTextBox.Select(0, 0)

      Dim AppDataLocalFolder = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName)
      Dim ToolTipsFile As String = Path.Combine(AppDataLocalFolder, "ToolTips.xml")
      Dim MyToolTips = New CustomToolTip(ToolTipsFile, Me)
   End Sub

   Private Sub btnSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveFile.Click
      Dim contents As String = FileContentsTextBox.Text

      If UseLibrary Then
         Dim libtrans As ShellLibrary
         libtrans = ShellLibrary.Load(LibraryName, True)
         Dim listFolders As List(Of String) = New List(Of String)
         For i As Integer = 0 To libtrans.Count - 1
            listFolders.Add(libtrans(i).Path)
         Next
         Dim defFolder = listFolders.IndexOf(libtrans.DefaultSaveFolder)

         Using dlg As New dlgSaveFile With {.ReturnFolder = False, .listFolders = listFolders, .DefaultFolder = defFolder, .FileName = CurrentBatch.FileName}
            dlg.Text = "Save Downloaded File"
            dlg.formHelp = formHelp
            Dim rc As DialogResult = dlg.ShowDialog()
            If rc = DialogResult.OK Then
               Try
                  File.WriteAllText(dlg.SelectedFileName, contents)
                  File.SetCreationTime(dlg.SelectedFileName, _currentBatch.UploadedDate)
                  File.SetLastAccessTime(dlg.SelectedFileName, _currentBatch.UploadedDate)
                  File.SetLastWriteTime(dlg.SelectedFileName, _currentBatch.UploadedDate)

               Catch ex As Exception

               Finally
               End Try
            Else
            End If
         End Using
      Else
         dlgSaveFile.Title = "Save " & CurrentBatch.FileName
         dlgSaveFile.InitialDirectory = PersonalPath
         dlgSaveFile.FileName = CurrentBatch.FileName

         Dim rc As DialogResult = dlgSaveFile.ShowDialog()
         If rc = DialogResult.OK Then
            Try
               File.WriteAllText(dlgSaveFile.FileName, contents)
               File.SetCreationTime(dlgSaveFile.FileName, _currentBatch.UploadedDate)
               File.SetLastAccessTime(dlgSaveFile.FileName, _currentBatch.UploadedDate)
               File.SetLastWriteTime(dlgSaveFile.FileName, _currentBatch.UploadedDate)

            Catch ex As Exception

            Finally
            End Try
         Else
         End If
      End If

   End Sub

End Class