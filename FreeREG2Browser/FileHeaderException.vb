Imports System.Runtime.Serialization

<Serializable()> _
Public Class FileHeaderException
   Inherits Exception
   Implements ISerializable

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

End Class
