'
' * The Alphanum Algorithm is an improved sorting algorithm for strings
' * containing numbers.  Instead of sorting numbers in ASCII order like
' * a standard sort, this algorithm sorts numbers in numeric order.
' *
' * The Alphanum Algorithm is discussed at http://www.DaveKoelle.com
' *
' * Based on the Java implementation of Dave Koelle's Alphanum algorithm.
' * Contributed by Jonathan Ruckwood <jonathan.ruckwood@gmail.com>
' * 
' * Adapted by Dominik Hurnaus <dominik.hurnaus@gmail.com> to 
' *   - correctly sort words where one word starts with another word
' *   - have slightly better performance
' * 
' * This library is free software; you can redistribute it and/or
' * modify it under the terms of the GNU Lesser General Public
' * License as published by the Free Software Foundation; either
' * version 2.1 of the License, or any later version.
' *
' * This library is distributed in the hope that it will be useful,
' * but WITHOUT ANY WARRANTY; without even the implied warranty of
' * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
' * Lesser General Public License for more details.
' *
' * You should have received a copy of the GNU Lesser General Public
' * License along with this library; if not, write to the Free Software
' * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
' *
' 

Imports System
Imports System.Collections
Imports System.Text
Imports BrightIdeasSoftware
Imports System.Windows.Forms

' 
' * Please compare against the latest Java version at http://www.DaveKoelle.com
' * to see the most recent modifications 
' 

Public Class AlphanumComparator
   Implements IComparer

   Private Enum ChunkType
      Alphanumeric
      Numeric
   End Enum

   Private _column As BrightIdeasSoftware.OLVColumn
   Private _order As Windows.Forms.SortOrder

   Sub New(column As BrightIdeasSoftware.OLVColumn, order As Windows.Forms.SortOrder)
      _column = column
      _order = order
   End Sub

   Private Function InChunk(ch As Char, otherCh As Char) As Boolean
      Dim type As ChunkType = ChunkType.Alphanumeric

      If Char.IsDigit(otherCh) Then
         type = ChunkType.Numeric
      End If

      If (type = ChunkType.Alphanumeric AndAlso Char.IsDigit(ch)) OrElse (type = ChunkType.Numeric AndAlso Not Char.IsDigit(ch)) Then
         Return False
      End If

      Return True
   End Function

   Public Function Compare(x As Object, y As Object) As Integer
      Dim s1 As [String] = TryCast(x, String)
      Dim s2 As [String] = TryCast(y, String)
      If s1 = Nothing OrElse s2 = Nothing Then
         Return 0
      End If

      Dim thisMarker As Integer = 0, thisNumericChunk As Integer = 0
      Dim thatMarker As Integer = 0, thatNumericChunk As Integer = 0

      While (thisMarker < s1.Length) OrElse (thatMarker < s2.Length)
         If thisMarker >= s1.Length Then
            If _order = SortOrder.Descending Then Return 1
            Return -1
         ElseIf thatMarker >= s2.Length Then
            If _order = SortOrder.Descending Then Return -1
            Return 1
         End If
         Dim thisCh As Char = s1(thisMarker)
         Dim thatCh As Char = s2(thatMarker)

         Dim thisChunk As New StringBuilder()
         Dim thatChunk As New StringBuilder()

         While (thisMarker < s1.Length) AndAlso (thisChunk.Length = 0 OrElse InChunk(thisCh, thisChunk(0)))
            thisChunk.Append(thisCh)
            System.Math.Max(System.Threading.Interlocked.Increment(thisMarker), thisMarker - 1)

            If thisMarker < s1.Length Then
               thisCh = s1(thisMarker)
            End If
         End While

         While (thatMarker < s2.Length) AndAlso (thatChunk.Length = 0 OrElse InChunk(thatCh, thatChunk(0)))
            thatChunk.Append(thatCh)
            System.Math.Max(System.Threading.Interlocked.Increment(thatMarker), thatMarker - 1)

            If thatMarker < s2.Length Then
               thatCh = s2(thatMarker)
            End If
         End While

         Dim result As Integer = 0
         ' If both chunks contain numeric characters, sort them numerically
         If Char.IsDigit(thisChunk(0)) AndAlso Char.IsDigit(thatChunk(0)) Then
            thisNumericChunk = Convert.ToInt32(thisChunk.ToString())
            thatNumericChunk = Convert.ToInt32(thatChunk.ToString())

            If thisNumericChunk < thatNumericChunk Then
               result = -1
            End If

            If thisNumericChunk > thatNumericChunk Then
               result = 1
            End If
         Else
            result = thisChunk.ToString().CompareTo(thatChunk.ToString())
         End If

         If result <> 0 Then
            If _order = SortOrder.Descending Then result *= -1
            Return result
         End If
      End While

      Return 0
   End Function

   Public Function Compare1(x As Object, y As Object) As Integer Implements IComparer.Compare
      Dim x1 As Object = Me._column.GetValue(x.RowObject)
      Dim y1 As Object = Me._column.GetValue(y.RowObject)
      Return Me.Compare(x1, y1)
   End Function
End Class