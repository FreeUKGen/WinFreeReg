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

   Public ReadOnly Property LiveUrl() As String
      Get
         Return "http://freereg2.freereg.org.uk"
      End Get
   End Property

   Public ReadOnly Property TestUrl() As String
      Get
         Return "http://localhost:3000"
      End Get
   End Property

   Private _baseUrl As String = ""
   Private _userid As String
   Private _password As String
   Private _cookieJar As CookieContainer = New CookieContainer()
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
    Description("A container for persisting Cookies from one session to another")> _
   Public Property CookieJar() As CookieContainer
      Get
         Return _cookieJar
      End Get
      Set(ByVal value As CookieContainer)
         _cookieJar = value
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
      CookieJar = New CookieContainer()
      Dim numCookies As Integer = info.GetInt32("o")
      For ix As Integer = 1 To numCookies Step 1
         Dim key As String = "Cookie_" + (ix - 1).ToString()
         Dim c As Cookie = info.GetValue(key, GetType(Cookie))
         CookieJar.Add(c)
      Next

   End Sub

   <SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter:=True)> _
   Public Overridable Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData
      info.AddValue("i", BaseUrl)
      info.AddValue("j", UserId)
      info.AddValue("k", Password)
      info.AddValue("l", TransregName)
      info.AddValue("m", TransregPassword)
      Dim ix As Integer = 0
      info.AddValue("o", CookieJar.Count)
      For Each c As Cookie In CookieJar.GetCookies(New Uri(BaseUrl))
         Dim key As String = "Cookie_" + ix.ToString()
         info.AddValue(key, c, GetType(Cookie))
         ix += 1
      Next
   End Sub
End Class
