Public Class formFileRename

   Property SelectedFile As DataRow
   Property TranscriptionFile As TranscriptionFileClass

   Private Sub formFileRename_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Dim recPlace = TranscriptionFile.FreeregTables.Places.FindByPlaceNameChapmanCode(TranscriptionFile.FileHeader.Place, TranscriptionFile.FileHeader.County)
      Dim recChurch = TranscriptionFile.FreeregTables.Churches.FindByChurchNameChapmanCodePlaceName(TranscriptionFile.FileHeader.Church, TranscriptionFile.FileHeader.County, TranscriptionFile.FileHeader.Place)
      Dim regType = TranscriptionFile.FreeregTables.RegisterTypes.FindByType(TranscriptionFile.FileHeader.RegisterType).Description
      If regType Is Nothing Then regType = TranscriptionFile.FreeregTables.ApprovedRegisterTypes.FindByType(TranscriptionFile.FileHeader.RegisterType).Description

      labelFilename.Text = SelectedFile("Name")
      labelPlace.Text = TranscriptionFile.FileHeader.Place
      labelChurch.Text = String.Format("{0}, {1}", TranscriptionFile.FileHeader.Church, regType)
      labelFileCode.Text = recChurch.FileCode

   End Sub
End Class