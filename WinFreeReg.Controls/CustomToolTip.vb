Imports System.Drawing
Imports System.Windows.Forms

Class CustomToolTip
   Inherits ToolTip

   Public Sub New()
      Me.OwnerDraw = True
      Me.Popup += New PopupEventHandler(Me.OnPopup)
      Me.Draw += New DrawToolTipEventHandler(Me.OnDraw)
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
End Class