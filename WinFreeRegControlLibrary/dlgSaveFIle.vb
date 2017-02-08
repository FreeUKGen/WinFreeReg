Imports System.Windows.Forms
Imports System.IO
Imports System.Reflection
Imports BrightIdeasSoftware

Public Class dlgSaveFile

   Property listFolders As List(Of String)

   Property DefaultFolder As Integer

   Property FileName As String

   Property SelectedFileName As String

   Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
      Dim item = CType(DataListView1.SelectedItem.RowObject, DataRowView).Row
      SelectedFileName = item("FullName")
      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub dlgSaveFIle_Load(sender As Object, e As EventArgs) Handles Me.Load
      lboxFolders.BeginUpdate()
      For Each folder In listFolders
         lboxFolders.Items.Add(folder)
      Next
      lboxFolders.SelectedIndex = DefaultFolder
      lboxFolders.EndUpdate()

   End Sub

   Private Sub lboxFolders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lboxFolders.SelectedIndexChanged
      Dim currentItem = lboxFolders.SelectedItem.ToString
      Dim fileQuery = From file As FileInfo In ListFiles(currentItem) _
                      Where file.Extension.Equals(".csv", StringComparison.CurrentCultureIgnoreCase) _
                      Order By file.Name _
                      Select file
      Dim tableLocalFiles = CreateDataTable(Of FileInfo)(fileQuery)

      Try
         BindingSource1.DataSource = tableLocalFiles
         With DataListView1
            .DataSource = BindingSource1
            .AutoResizeColumns()
         End With

      Catch ex As Exception

      End Try
   End Sub

   Private Function ListFiles(ByVal root As String) As System.Collections.Generic.IEnumerable(Of System.IO.FileInfo)
      ' Function to retrieve a list of files. Note that this is a copy
      ' of the file information.
      Return From file In My.Computer.FileSystem.GetFiles(root, FileIO.SearchOption.SearchTopLevelOnly, "*.*") _
             Select New System.IO.FileInfo(file)
   End Function

   Private Shared Function CreateDataTable(Of T)(ByVal list As IEnumerable(Of T)) As DataTable
      Dim type As Type = GetType(T)
      Dim properties = type.GetProperties()

      Dim dataTable As New DataTable()
      For Each info As PropertyInfo In properties
         dataTable.Columns.Add(New DataColumn(info.Name, If(Nullable.GetUnderlyingType(info.PropertyType), info.PropertyType)))
      Next

      For Each entity As T In list
         Dim values As Object() = New Object(properties.Length - 1) {}
         Dim i As Integer = 0
         While i < properties.Length
            values(i) = properties(i).GetValue(entity, Nothing)
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
         End While

         dataTable.Rows.Add(values)
      Next

      Return dataTable
   End Function

   Private Sub DataListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataListView1.SelectedIndexChanged
      If DataListView1.SelectedItem IsNot Nothing Then
         txtFileName.Text = DataListView1.SelectedItem.Text
      End If
   End Sub
End Class
