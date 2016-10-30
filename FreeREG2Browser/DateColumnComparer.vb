Imports System.Windows.Forms
Imports BrightIdeasSoftware

Class DateColumnComparer
   Implements IComparer

   Private _column As BrightIdeasSoftware.OLVColumn
   Private _order As Windows.Forms.SortOrder

   Sub New(column As BrightIdeasSoftware.OLVColumn, order As Windows.Forms.SortOrder)
      _column = column
      _order = order
   End Sub

   Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
      Return Me.Compare(CType(x, OLVListItem), CType(y, OLVListItem))
   End Function

   Public Function Compare(ByVal x As OLVListItem, ByVal y As OLVListItem) As Integer
      If Me._order = SortOrder.None Then Return 0

      Dim result As Integer = 0
      Dim x1 As Object = Me._column.GetValue(x.RowObject)
      Dim y1 As Object = Me._column.GetValue(y.RowObject)

      If TypeOf x1 Is [String] And TypeOf y1 Is [String] Then
         If String.IsNullOrEmpty(x1) And String.IsNullOrEmpty(y1) Then Return 0

         Dim splitchars = {" "c, "/"c}
         Dim ax1 = CType(x1, String).Split(splitchars)
         If ax1.Length = 4 Then Array.Resize(ax1, 3)
         Array.Reverse(ax1)
         Dim cmpstrX = ax1(0) + MonthNumber(ax1(1)) + ax1(2)

         Dim ay1 = CType(y1, String).Split(splitchars)
         If ay1.Length = 4 Then Array.Resize(ay1, 3)
         Array.Reverse(ay1)
         Dim cmpstrY = ay1(0) + MonthNumber(ay1(1)) + ay1(2)

         result = String.Compare(cmpstrX, cmpstrY)
         If _order = SortOrder.Descending Then result *= -1
      End If
      Return result
   End Function

   Private Function MonthNumber(ByVal month As String) As String
      Dim months = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
      MonthNumber = (Array.IndexOf(months, month) + 1).ToString("D2")
   End Function
End Class
