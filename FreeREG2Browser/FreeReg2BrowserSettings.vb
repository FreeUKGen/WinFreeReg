Imports System.Net
Imports System.ComponentModel
Imports System.IO
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.Xml
Imports System.Xml.Schema
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Security.Permissions

<Serializable()> Public Class FreeReg2BrowserSettings
   Implements ISerializable

   Private _baseUrl As String = ""
   Private _userid As String
   Private _password As String
   Private _cookies As CookieCollection
   Private _transregName As String = "transreg"
   Private _transregPassword As String = "temppasshope"

   <Category("User"), _
    Description("URL for the root of the FreeREG2 website")> _
   Public Property BaseUrl() As String
      Get
         Return _baseUrl
      End Get
      Set(ByVal value As String)
         _baseUrl = value
      End Set
   End Property

   <Category("User"), _
    Description("Your personal, FreeREG user id.")> _
   Public Property UserId() As String
      Get
         Return _userid
      End Get
      Set(ByVal value As String)
         _userid = value
      End Set
   End Property

   <Category("User"), _
    Description("Your FreeREG password")> _
   Public Property Password() As String
      Get
         Return _password
      End Get
      Set(ByVal value As String)
         _password = value
      End Set
   End Property

   <Category("User"), _
   BrowsableAttribute(False), _
   Description("A collection of Cookies")> _
   Public Property Cookies As CookieCollection
      Get
         Return _cookies
      End Get
      Set(ByVal value As CookieCollection)
         _cookies = value
      End Set
   End Property

   <Category("Application"), _
    Description("The common WinFreeREG user id (TRANSREG)"), _
    BrowsableAttribute(False), _
    ReadOnlyAttribute(True)> _
   Public Property TransregName() As String
      Get
         Return _transregName
      End Get
      Set(ByVal value As String)
         _transregName = value
      End Set
   End Property

   <Category("Application"), _
    Description("The password for the TRANSREG user id"), _
    BrowsableAttribute(False), _
    ReadOnlyAttribute(True)> _
   Public Property TransregPassword() As String
      Get
         Return _transregPassword
      End Get
      Set(ByVal value As String)
         _transregPassword = value
      End Set
   End Property

   Public Sub New()
   End Sub

   Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
      BaseUrl = info.GetString("i")
      UserId = info.GetString("j")
      Password = info.GetString("k")
      TransregName = info.GetString("l")
      TransregPassword = info.GetString("m")
      Cookies = New CookieCollection()
      Dim x As Integer = info.GetValue("n", GetType(UInt16))
      For i As Integer = 0 To x - 1 Step 1
         Dim str = info.GetString(String.Format("Cookie:{0}", i)).Split(New Char() {" "c})
         Cookies.Add(New Cookie(str(0), str(1)))
      Next
   End Sub

   <SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter:=True)> _
   Public Overridable Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData
      info.AddValue("i", BaseUrl)
      info.AddValue("j", UserId)
      info.AddValue("k", Password)
      info.AddValue("l", TransregName)
      info.AddValue("m", TransregPassword)
      info.AddValue("n", Cookies.Count)
      For i As Integer = 0 To Cookies.Count - 1 Step 1
         info.AddValue(String.Format("Cookie:{0}", i), String.Format("{0} {1}", Cookies(i).Name, Cookies(i).Value))
      Next

   End Sub
End Class
