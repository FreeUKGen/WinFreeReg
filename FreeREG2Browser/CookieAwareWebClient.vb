Imports System.Net

''' <summary>
''' A Cookie-aware WebClient that will store authentication cookie information and persist it through subsequent requests.
''' </summary>
Public Class CookieAwareWebClient
	Inherits WebClient

	'Properties to handle implementing a timeout
	Private _timeout As System.Nullable(Of Integer) = Nothing
	Public Property Timeout() As System.Nullable(Of Integer)
		Get
			Return _timeout
		End Get
		Set(ByVal value As System.Nullable(Of Integer))
			_timeout = value
		End Set
	End Property

	'A CookieContainer class to house the Cookie once it is contained within one of the Requests
	Private _cookiejar As CookieContainer = Nothing
	Public Property CookieContainer() As CookieContainer
		Get
			Return _cookiejar
		End Get
		Set(ByVal value As CookieContainer)
			_cookiejar = value
		End Set
	End Property

	'Constructor
	Public Sub New()
      CookieContainer = Nothing
	End Sub

	'Method to handle setting the optional timeout (in milliseconds)
	Public Sub SetTimeout(ByVal timeout As Integer)
		_timeout = timeout
	End Sub

   Public Function GetHttpRequest(ByVal address As Uri) As HttpWebRequest
      Return MyBase.GetWebRequest(address)
   End Function

	'This handles using and storing the Cookie information as well as managing the Request timeout
	Protected Overrides Function GetWebRequest(ByVal address As Uri) As WebRequest
		'Handles the CookieContainer
		Dim request As HttpWebRequest = CType(MyBase.GetWebRequest(address), HttpWebRequest)
		request.CookieContainer = CookieContainer
		'Sets the Timeout if it exists
		If _timeout.HasValue Then
			request.Timeout = _timeout.Value
		End If
		Return request
	End Function

	Protected Overrides Function GetWebResponse(ByVal request As System.Net.WebRequest) As System.Net.WebResponse
		Dim response = MyBase.GetWebResponse(request)
		ReadCookies(response)
		Return response
	End Function

	Protected Overrides Function GetWebResponse(ByVal request As System.Net.WebRequest, ByVal result As System.IAsyncResult) As System.Net.WebResponse
		Dim response = MyBase.GetWebResponse(request, result)
		ReadCookies(response)
		Return response
	End Function

	Private Sub ReadCookies(ByVal r As WebResponse)
		Dim response As HttpWebResponse = CType(r, HttpWebResponse)
		If response IsNot Nothing Then
			Dim cookies As CookieCollection = response.Cookies()
			CookieContainer.Add(cookies)
		End If
	End Sub

	Public Sub ShowResponseHeaders()
		Dim rsp = Me.ResponseHeaders()
		Dim i As Integer
		For i = 0 To rsp.Count - 1
			' Display the headers as name/value pairs.
			Console.WriteLine((ControlChars.Tab + rsp.GetKey(i) + " " + ChrW(61) + " " + rsp.Get(i)))
		Next i
	End Sub

	Public Sub ShowCookies(ByVal uri As Uri)
		Try
			If Me.CookieContainer.Count > 0 Then
				For Each cookie As Cookie In Me.CookieContainer.GetCookies(uri)
               '					Console.WriteLine("Cookie:")
               '					Console.WriteLine("{0} = {1}", cookie.Name, cookie.Value)
               '					Console.WriteLine("Domain: {0}", cookie.Domain)
               '					Console.WriteLine("Path: {0}", cookie.Path)
               '					Console.WriteLine("Port: {0}", cookie.Port)
               '					Console.WriteLine("Secure: {0}", cookie.Secure)
               '					Console.WriteLine("When issued: {0}", cookie.TimeStamp)
               '					Console.WriteLine("Expires: {0} (expired? {1})", cookie.Expires, cookie.Expired)
               '					Console.WriteLine("Don't save: {0}", cookie.Discard)
               '					Console.WriteLine("Comment: {0}", cookie.Comment)
               '					Console.WriteLine("Uri for comments: {0}", cookie.CommentUri)
               '					Console.WriteLine("Version: RFC {0}", IIf(cookie.Version = 1, "2109", "2965"))
					Console.WriteLine("String: {0}", cookie.ToString())
				Next
			End If

		Catch ex As Exception
			Beep()
		End Try
	End Sub

   Public Function GetAllCookiesFromHeader(strHeader As String, strHost As String) As CookieCollection
      Dim al As New ArrayList()
      Dim cc As New CookieCollection()
      If strHeader <> String.Empty Then
         al = ConvertCookieHeaderToArrayList(strHeader)
         cc = ConvertCookieArraysToCookieCollection(al, strHost)
      End If
      Return cc
   End Function


   Private Shared Function ConvertCookieHeaderToArrayList(strCookHeader As String) As ArrayList
      strCookHeader = strCookHeader.Replace(vbCr, "")
      strCookHeader = strCookHeader.Replace(vbLf, "")
      Dim strCookTemp As String() = strCookHeader.Split(","c)
      Dim al As New ArrayList()
      Dim i As Integer = 0
      Dim n As Integer = strCookTemp.Length
      While i < n
         If strCookTemp(i).IndexOf("expires=", StringComparison.OrdinalIgnoreCase) > 0 Then
            al.Add(strCookTemp(i) + "," + strCookTemp(i + 1))
            i = i + 1
         Else
            al.Add(strCookTemp(i))
         End If
         i = i + 1
      End While
      Return al
   End Function


   Private Shared Function ConvertCookieArraysToCookieCollection(al As ArrayList, strHost As String) As CookieCollection
      Dim cc As New CookieCollection()

      Dim alcount As Integer = al.Count
      Dim strEachCook As String
      Dim strEachCookParts As String()
      Dim i As Integer = 0
      While i < alcount
         strEachCook = al(i).ToString()
         strEachCookParts = strEachCook.Split(";"c)
         Dim intEachCookPartsCount As Integer = strEachCookParts.Length
         Dim strCNameAndCValue As String = String.Empty
         Dim strPNameAndPValue As String = String.Empty
         Dim strDNameAndDValue As String = String.Empty
         Dim NameValuePairTemp As String()
         Dim cookTemp As New Cookie()

         Dim j As Integer = 0
         While j < intEachCookPartsCount
            If j = 0 Then
               strCNameAndCValue = strEachCookParts(j)
               If strCNameAndCValue <> String.Empty Then
                  Dim firstEqual As Integer = strCNameAndCValue.IndexOf("=")
                  Dim firstName As String = strCNameAndCValue.Substring(0, firstEqual)
                  Dim allValue As String = strCNameAndCValue.Substring(firstEqual + 1, strCNameAndCValue.Length - (firstEqual + 1))
                  cookTemp.Name = firstName
                  cookTemp.Value = allValue
               End If
               j += 1
               Continue While
            End If
            If strEachCookParts(j).IndexOf("path", StringComparison.OrdinalIgnoreCase) >= 0 Then
               strPNameAndPValue = strEachCookParts(j)
               If strPNameAndPValue <> String.Empty Then
                  NameValuePairTemp = strPNameAndPValue.Split("="c)
                  If NameValuePairTemp(1) <> String.Empty Then
                     cookTemp.Path = NameValuePairTemp(1)
                  Else
                     cookTemp.Path = "/"
                  End If
               End If
               j += 1
               Continue While
            End If

            If strEachCookParts(j).IndexOf("domain", StringComparison.OrdinalIgnoreCase) >= 0 Then
               strPNameAndPValue = strEachCookParts(j)
               If strPNameAndPValue <> String.Empty Then
                  NameValuePairTemp = strPNameAndPValue.Split("="c)

                  If NameValuePairTemp(1) <> String.Empty Then
                     cookTemp.Domain = NameValuePairTemp(1)
                  Else
                     cookTemp.Domain = strHost
                  End If
               End If
               Continue While
            End If
            System.Math.Max(System.Threading.Interlocked.Increment(j), j - 1)
         End While

         If cookTemp.Path = String.Empty Then
            cookTemp.Path = "/"
         End If
         If cookTemp.Domain = String.Empty Then
            cookTemp.Domain = strHost
         End If
         cc.Add(cookTemp)
         System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
      End While
      Return cc
   End Function

End Class