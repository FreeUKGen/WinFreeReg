Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Text
Imports System.IO

Public Class CustomToolTip
   Inherits ToolTip

   Private _filename As String
   Public Property FileName() As String
      Get
         Return _filename
      End Get
      Set(ByVal value As String)
         _filename = value
      End Set
   End Property

   Private _ds As ToolTips
   Public Property Data() As ToolTips
      Get
         Return _ds
      End Get
      Set(ByVal value As ToolTips)
         _ds = value
      End Set
   End Property

   Public Sub New()
      MyBase.New()
      '      Me.OwnerDraw = True
      Me._ds = New ToolTips()
      '      AddHandler Me.Popup, AddressOf Me.OnPopup
      '      AddHandler Me.Draw, AddressOf Me.OnDraw
   End Sub

   Public Sub New(ByVal strFileName As String, ByVal form As Form)
      Me.New()
      If File.Exists(strFileName) Then
         FileName = strFileName
         _ds.ReadXml(strFileName)
         Me.IsBalloon = True
         Me.ToolTipTitle = form.Text
         Me.ToolTipIcon = ToolTipIcon.Info
         Me.SetToolTips(form)
      End If
   End Sub

   Private Sub OnPopup(sender As Object, e As PopupEventArgs)
      ' use this event to set the size of the tool tip
      e.ToolTipSize = New Size(200, 100)
   End Sub

   Private Sub OnDraw(sender As Object, e As DrawToolTipEventArgs)
      ' use this event to customise the tool tip
      Dim g As Graphics = e.Graphics

      Dim b As New LinearGradientBrush(e.Bounds, Color.GreenYellow, Color.MintCream, 45.0F)

      g.FillRectangle(b, e.Bounds)

      g.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1))

      g.DrawString(e.ToolTipText, New Font(e.Font, FontStyle.Bold), Brushes.Silver, New PointF(e.Bounds.X + 6, e.Bounds.Y + 6))
      ' shadow layer
      g.DrawString(e.ToolTipText, New Font(e.Font, FontStyle.Bold), Brushes.Black, New PointF(e.Bounds.X + 5, e.Bounds.Y + 5))
      ' top layer
      b.Dispose()
   End Sub

   Public Sub SetToolTips(ByVal form As Form)
      Dim dt As ToolTips.ToolTipsDataTable = _ds.Tables("ToolTips")

      Dim WindowControls = From rec As WinFreeReg.ToolTips.ToolTipsRow In dt.Rows _
                      Where rec.FormName = form.Name _
                      Select rec

      If WindowControls.Count = 0 Then
         Dim row = dt.NewToolTipsRow()
         row.FormName = form.Name
         dt.AddToolTipsRow(row)
         Dim olist As List(Of Control) = form.FindAllChildren()
         For Each item In olist
            If Not String.IsNullOrEmpty(item.Name) Then
               If Not (TypeOf item Is Label Or TypeOf item Is SplitContainer Or TypeOf item Is Panel Or TypeOf item Is StatusStrip Or TypeOf item Is MenuStrip Or TypeOf item Is BindingNavigator) Then
                  row = dt.NewToolTipsRow()
                  row.FormName = form.Name
                  row.ControlName = item.Name
                  dt.AddToolTipsRow(row)
               End If
            End If
         Next
         dt.AcceptChanges()
         Dim fi = New FileInfo(_filename)
         If fi.IsReadOnly Then File.SetAttributes(_filename, File.GetAttributes(_filename) And (Not FileAttributes.ReadOnly))
         _ds.WriteXml(_filename, XmlWriteMode.WriteSchema)
         File.SetAttributes(_filename, File.GetAttributes(_filename) Or FileAttributes.ReadOnly)
         WindowControls = From rec As WinFreeReg.ToolTips.ToolTipsRow In dt.Rows _
                         Where rec.FormName = form.Name _
                         Select rec
      End If

      For Each row In WindowControls
         If row.IsControlNameNull Then
            If Not row.IsToolTipTextNull Then
               Me.SetToolTip(form, AddNewLinesForTooltip(row.ToolTipText))
            End If
         Else
            If Not row.IsToolTipTextNull Then
               If Not String.IsNullOrEmpty(row.ToolTipText) Then
                  Dim ctl() = form.Controls.Find(row.ControlName, False)
                  If ctl.Count > 0 Then
                     Me.SetToolTip(ctl(0), AddNewLinesForTooltip(row.ToolTipText))
                  End If
               End If
            End If
         End If
      Next
   End Sub

   Private Const MAXIMUMSINGLELINETOOLTIPLENGTH As Integer = 64

   Private Function AddNewLinesForTooltip(text As String) As String
      If text.Length < MAXIMUMSINGLELINETOOLTIPLENGTH Then
         Return text
      End If
      Dim lineLength As Integer = Convert.ToInt16(Math.Sqrt(Convert.ToDouble(text.Length))) * 2
      Dim sb As New StringBuilder()
      Dim currentLinePosition As Integer = 0
      Dim textIndex As Integer = 0
      While textIndex < text.Length
         ' If we have reached the target line length and the next 
         ' character is whitespace then begin a new line.
         If currentLinePosition >= lineLength AndAlso Char.IsWhiteSpace(text(textIndex)) Then
            sb.Append(Environment.NewLine)
            currentLinePosition = 0
         End If
         ' If we have just started a new line, skip all the whitespace.
         If currentLinePosition = 0 Then
            While textIndex < text.Length AndAlso Char.IsWhiteSpace(text(textIndex))
               System.Math.Max(System.Threading.Interlocked.Increment(textIndex), textIndex - 1)
            End While
         End If
         ' Append the next character.
         If textIndex < text.Length Then
            sb.Append(text(textIndex))
         End If

         System.Math.Max(System.Threading.Interlocked.Increment(currentLinePosition), currentLinePosition - 1)
         System.Math.Max(System.Threading.Interlocked.Increment(textIndex), textIndex - 1)
      End While
      Return sb.ToString()
   End Function

End Class
