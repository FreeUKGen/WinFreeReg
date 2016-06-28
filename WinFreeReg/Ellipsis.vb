Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Text.RegularExpressions

''' <summary>
''' Specifies ellipsis format and alignment.
''' </summary>
<Flags> _
Public Enum EllipsisFormat
   ''' <summary>
   ''' Text is not modified.
   ''' </summary>
   None = 0
   ''' <summary>
   ''' Text is trimmed at the end of the string. An ellipsis (...) is drawn in place of remaining text.
   ''' </summary>
   [End] = 1
   ''' <summary>
   ''' Text is trimmed at the begining of the string. An ellipsis (...) is drawn in place of remaining text. 
   ''' </summary>
   Start = 2
   ''' <summary>
   ''' Text is trimmed in the middle of the string. An ellipsis (...) is drawn in place of remaining text.
   ''' </summary>
   Middle = 3
   ''' <summary>
   ''' Preserve as much as possible of the drive and filename information. Must be combined with alignment information.
   ''' </summary>
   Path = 4
   ''' <summary>
   ''' Text is trimmed at a word boundary. Must be combined with alignment information.
   ''' </summary>
   Word = 8
End Enum


Public Class Ellipsis
   ''' <summary>
   ''' String used as a place holder for trimmed text.
   ''' </summary>
   Public Shared ReadOnly EllipsisChars As String = "..."

   Private Shared prevWord As New Regex("\W*\w*$")
   Private Shared nextWord As New Regex("\w*\W*")

   ''' <summary>
   ''' Truncates a text string to fit within a given control width by replacing trimmed text with ellipses. 
   ''' </summary>
   ''' <param name="text">String to be trimmed.</param>
   ''' <param name="ctrl">text must fit within ctrl width.
   '''	The ctrl's Font is used to measure the text string.</param>
   ''' <param name="options">Format and alignment of ellipsis.</param>
   ''' <returns>This function returns text trimmed to the specified witdh.</returns>
   Public Shared Function Compact(text As String, ctrl As Control, options As EllipsisFormat) As String
      If String.IsNullOrEmpty(text) Then
         Return text
      End If

      ' no aligment information
      If (EllipsisFormat.Middle And options) = 0 Then
         Return text
      End If

      If ctrl Is Nothing Then
         Throw New ArgumentNullException("ctrl")
      End If

      Using dc As Graphics = ctrl.CreateGraphics()
         Dim s As Size = TextRenderer.MeasureText(dc, text, ctrl.Font)

         ' control is large enough to display the whole text
         If s.Width <= ctrl.Width Then
            Return text
         End If

         Dim pre As String = ""
         Dim mid As String = text
         Dim post As String = ""

         Dim isPath As Boolean = (EllipsisFormat.Path And options) <> 0

         ' split path string into <drive><directory><filename>
         If isPath Then
            pre = Path.GetPathRoot(text)
            mid = Path.GetDirectoryName(text).Substring(pre.Length)
            post = Path.GetFileName(text)
         End If

         Dim len As Integer = 0
         Dim seg As Integer = mid.Length
         Dim fit As String = ""

         ' find the longest string that fits into 
         ' the control boundaries using bisection method
         While seg > 1
            seg -= seg / 2

            Dim left As Integer = len + seg
            Dim right As Integer = mid.Length

            If left > right Then
               Continue While
            End If

            If (EllipsisFormat.Middle And options) = EllipsisFormat.Middle Then
               right -= left / 2
               left -= left / 2
            ElseIf (EllipsisFormat.Start And options) <> 0 Then
               right -= left
               left = 0
            End If

            ' trim at a word boundary using regular expressions
            If (EllipsisFormat.Word And options) <> 0 Then
               If (EllipsisFormat.[End] And options) <> 0 Then
                  left -= prevWord.Match(mid, 0, left).Length
               End If
               If (EllipsisFormat.Start And options) <> 0 Then
                  right += nextWord.Match(mid, right).Length
               End If
            End If

            ' build and measure a candidate string with ellipsis
            Dim tst As String = mid.Substring(0, left) + EllipsisChars + mid.Substring(right)

            ' restore path with <drive> and <filename>
            If isPath Then
               tst = Path.Combine(Path.Combine(pre, tst), post)
            End If
            s = TextRenderer.MeasureText(dc, tst, ctrl.Font)

            ' candidate string fits into control boundaries, try a longer string
            ' stop when seg <= 1
            If s.Width <= ctrl.Width Then
               len += seg
               fit = tst
            End If
         End While

         If len = 0 Then
            ' string can't fit into control
            ' "path" mode is off, just return ellipsis characters
            If Not isPath Then
               Return EllipsisChars
            End If

            ' <drive> and <directory> are empty, return <filename>
            If pre.Length = 0 AndAlso mid.Length = 0 Then
               Return post
            End If

            ' measure "C:\...\filename.ext"
            fit = Path.Combine(Path.Combine(pre, EllipsisChars), post)

            s = TextRenderer.MeasureText(dc, fit, ctrl.Font)

            ' if still not fit then return "...\filename.ext"
            If s.Width > ctrl.Width Then
               fit = Path.Combine(EllipsisChars, post)
            End If
         End If
         Return fit
      End Using
   End Function
End Class
