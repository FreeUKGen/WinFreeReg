Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Class LabelEllipsis
   Inherits Label
   Public Overrides Property Text() As String
      ' store full text and calculate ellipsis text
      Set(value As String)
         longText = value
         shortText = WinFreeReg.Ellipsis.Compact(longText, Me, AutoEllipsis)

         tooltip.SetToolTip(Me, longText)
         MyBase.Text = shortText
      End Set
      Get
         Return MyBase.Text
      End Get
   End Property

   Private longText As String
   Private shortText As String

   ' control size changed, recalculate ellipsis text
   Protected Overrides Sub OnResize(e As EventArgs)
      MyBase.OnResize(e)
      Me.Text = FullText
   End Sub

#Region "AutoEllipsis property"

   ''' <summary>
   ''' Get the text associated with the control without ellipsis.
   ''' </summary>
   <Browsable(False)> _
   Public Overridable ReadOnly Property FullText() As String
      Get
         Return longText
      End Get
   End Property

   ''' <summary>
   ''' Get the text associated with the control truncated if it exceeds the width of the control.
   ''' </summary>
   <Browsable(False)> _
   Public Overridable ReadOnly Property EllipsisText() As String
      Get
         Return shortText
      End Get
   End Property

   ''' <summary>
   ''' Indicates whether the text exceeds the witdh of the control.
   ''' </summary>
   <Browsable(False)> _
   Public Overridable ReadOnly Property IsEllipsis() As Boolean
      Get
         Return longText <> shortText
      End Get
   End Property

   Private ellipsis As EllipsisFormat

   <Category("Behavior")> _
   <Description("Define ellipsis format and alignment when text exceeds the width of the control")> _
   Public Shadows Property AutoEllipsis() As EllipsisFormat
      Get
         Return ellipsis
      End Get
      Set(value As EllipsisFormat)
         If ellipsis <> value Then
            ellipsis = value
            ' ellipsis type changed, recalculate ellipsis text
            Me.Text = FullText
            OnAutoEllipsisChanged(EventArgs.Empty)
         End If
      End Set
   End Property

   <Category("Property Changed")> _
   <Description("Event raised when the value of AutoEllipsis property is changed on Control")> _
   Public Event AutoEllipsisChanged As EventHandler

   Protected Sub OnAutoEllipsisChanged(e As EventArgs)
      '      If AutoEllipsisChanged IsNot Nothing Then
      RaiseEvent AutoEllipsisChanged(Me, e)
      '      End If
   End Sub

#End Region

#Region "Tooltip"

   Private tooltip As New ToolTip()

#End Region
End Class

