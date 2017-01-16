Public Class UCFDataClass

   Private _FieldText As String
   Private _FieldName As String
   Private _InsertionPoint As Integer

   Public Property FieldName() As String
      Get
         Return _FieldName
      End Get
      Set(ByVal value As String)
         _FieldName = value
      End Set
   End Property

   Public Property FieldText() As String
      Get
         Return _FieldText
      End Get
      Set(ByVal value As String)
         _FieldText = value
      End Set
   End Property

   Public Property InsertionPoint() As Integer
      Get
         Return _InsertionPoint
      End Get
      Set(ByVal value As Integer)
         _InsertionPoint = value
      End Set
   End Property
End Class
