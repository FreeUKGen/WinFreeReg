Imports System.Runtime.Serialization

<Serializable()> _
Public Class BackgroundWorkerException
	Inherits Exception
	Implements ISerializable

   Private _page As String
   Public Property Page() As String
      Get
         Return _page
      End Get
      Set(ByVal value As String)
         _page = value
      End Set
   End Property


   Public Sub New()
      ' Add other code for custom properties here.
   End Sub

   Public Sub New(ByVal message As String)
      MyBase.New(message)
      ' Add other code for custom properties here.
   End Sub

   Public Sub New(ByVal message As String, ByVal inner As Exception)
      MyBase.New(message, inner)
      ' Add other code for custom properties here.
   End Sub

   Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
      MyBase.New(info, context)
      ' Insert code here for custom properties here.
   End Sub

   Sub New(p1 As String, page As String)
      MyBase.New(p1)
      _page = page
   End Sub

End Class

