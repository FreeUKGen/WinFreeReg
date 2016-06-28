Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Class TextBoxEllipsis
   Inherits TextBox
   Public Overrides Property Text() As String
      ' store full text, calculate ellipsis text and
      ' display full text if textbox has focused, display truncated text otherwise
      Set(value As String)
         longText = value
         shortText = WinFreeReg.Ellipsis.Compact(longText, Me, AutoEllipsis)

         tooltip.SetToolTip(Me, longText)
         MyBase.Text = If(Focused, longText, shortText)
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

      If Not Focused Then
         ' doesn't apply if textbox has the focus
         Me.Text = FullText
      End If
   End Sub

   ' control gains focus, display full text
   Protected Overrides Sub OnGotFocus(e As EventArgs)
      MyBase.Text = FullText
      MyBase.OnGotFocus(e)
   End Sub

   ' lose focus, calculate ellipsis of (possibly) modified text
   Protected Overrides Sub OnLostFocus(e As EventArgs)
      MyBase.OnLostFocus(e)
      Me.Text = MyBase.Text
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
   Public Overridable Property AutoEllipsis() As EllipsisFormat
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

#Region "P/Invoke for context menu"

   ' credit is due to zsh
   ' http://www.codeproject.com/KB/edit/cmenuedit.aspx?msg=2774005#xx2774005xx

   Const MSGF_MENU As UInteger = 2
   Const OBJID_CLIENT As UInteger = &HFFFFFFFCUI

   Const MF_SEPARATOR As UInteger = &H800
   Const MF_BYCOMMAND As UInteger = 0
   Const MF_POPUP As UInteger = 16
   Const MF_UNCHECKED As UInteger = 0
   Const MF_CHECKED As UInteger = 8

   Const WM_ENTERIDLE As Integer = &H121
   Const WM_APP As Integer = &H8000

   ' user-defined windows messages
   Const WM_NONE As Integer = WM_APP + 1
   Const WM_LEFT As Integer = WM_APP + 2
   Const WM_RIGHT As Integer = WM_APP + 3
   Const WM_CENTER As Integer = WM_APP + 4
   Const WM_PATH As Integer = WM_APP + 5
   Const WM_WORD As Integer = WM_APP + 6

   <StructLayout(LayoutKind.Sequential)> _
   Structure RECT
      Private Left As Integer
      Private Top As Integer
      Private Right As Integer
      Private Bottom As Integer
   End Structure

   <StructLayout(LayoutKind.Sequential)> _
   Structure MENUBARINFO
      Public cbSize As Integer
      Public rcBar As RECT
      Public hMenu As IntPtr
      Public hwndMenu As IntPtr
      Public fBarFocused_fFocused As UShort
   End Structure

   <DllImport("user32.dll")> _
   Shared Function GetMenuBarInfo(hwnd As IntPtr, idObject As UInteger, idItem As UInteger, ByRef pmbi As MENUBARINFO) As Boolean
   End Function

   <DllImport("user32.dll")> _
   Shared Function GetMenuState(hMenu As IntPtr, uId As UInteger, uFlags As UInteger) As Integer
   End Function

   <DllImport("user32.dll")> _
   Shared Function AppendMenu(hMenu As IntPtr, uFlags As UInteger, uIDNewItem As UInteger, lpNewItem As String) As UInteger
   End Function

   <DllImport("user32.dll")> _
   Shared Function CreatePopupMenu() As IntPtr
   End Function

   Protected Overrides Sub WndProc(ByRef m As Message)
      Select Case m.Msg
         Case WM_ENTERIDLE
            MyBase.WndProc(m)

            If MSGF_MENU = CType(m.WParam, Integer) Then
               Dim mbi As New MENUBARINFO()
               mbi.cbSize = Marshal.SizeOf(mbi)

               GetMenuBarInfo(m.LParam, OBJID_CLIENT, 0, mbi)

               If GetMenuState(mbi.hMenu, WM_APP + 1, MF_BYCOMMAND) = -1 Then
                  Dim hSubMenu As IntPtr = CreatePopupMenu()

                  If hSubMenu <> IntPtr.Zero Then
                     AppendMenu(hSubMenu, isChecked(EllipsisFormat.None), WM_NONE, "None")
                     AppendMenu(hSubMenu, isChecked(EllipsisFormat.Start), WM_LEFT, "Left")
                     AppendMenu(hSubMenu, isChecked(EllipsisFormat.[End]), WM_RIGHT, "Right")
                     AppendMenu(hSubMenu, isChecked(EllipsisFormat.Middle), WM_CENTER, "Center")
                     AppendMenu(hSubMenu, MF_SEPARATOR, 0, Nothing)
                     AppendMenu(hSubMenu, isChecked(EllipsisFormat.Path), WM_PATH, "Path Ellipsis")
                     AppendMenu(hSubMenu, isChecked(EllipsisFormat.Word), WM_WORD, "Word Ellipsis")

                     AppendMenu(mbi.hMenu, MF_SEPARATOR, 0, Nothing)
                     AppendMenu(mbi.hMenu, MF_POPUP, CType(hSubMenu, UInteger), "Auto Ellipsis")
                  End If
               End If
            End If
            Exit Select

         Case WM_NONE
            AutoEllipsis = EllipsisFormat.None
            Exit Select

         Case WM_LEFT
            AutoEllipsis = AutoEllipsis And Not EllipsisFormat.Middle Or EllipsisFormat.Start
            Exit Select

         Case WM_RIGHT
            AutoEllipsis = AutoEllipsis And Not EllipsisFormat.Middle Or EllipsisFormat.[End]
            Exit Select

         Case WM_CENTER
            AutoEllipsis = AutoEllipsis Or EllipsisFormat.Middle
            Exit Select

         Case WM_PATH
            If (AutoEllipsis And EllipsisFormat.Path) = 0 Then
               AutoEllipsis = AutoEllipsis Or EllipsisFormat.Path
            Else
               AutoEllipsis = AutoEllipsis And Not EllipsisFormat.Path
            End If
            Exit Select

         Case WM_WORD
            If (AutoEllipsis And EllipsisFormat.Word) = 0 Then
               AutoEllipsis = AutoEllipsis Or EllipsisFormat.Word
            Else
               AutoEllipsis = AutoEllipsis And Not EllipsisFormat.Word
            End If
            Exit Select
         Case Else

            MyBase.WndProc(m)
            Exit Select
      End Select
   End Sub

   Function isChecked(fmt As EllipsisFormat) As UInteger
      Dim mask As EllipsisFormat = fmt

      Select Case fmt
         Case EllipsisFormat.None, EllipsisFormat.Start, EllipsisFormat.[End]
            mask = EllipsisFormat.Middle
            Exit Select
      End Select
      Return If(((AutoEllipsis And mask) = fmt), MF_CHECKED, MF_UNCHECKED)
   End Function

#End Region

#Region "Tooltip"

   Private tooltip As New ToolTip()

#End Region
End Class
