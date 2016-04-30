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
		CookieContainer = New CookieContainer()
	End Sub

	'Method to handle setting the optional timeout (in milliseconds)
	Public Sub SetTimeout(ByVal timeout As Integer)
		_timeout = timeout
	End Sub

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
					Console.WriteLine("Cookie:")
					Console.WriteLine("{0} = {1}", cookie.Name, cookie.Value)
					Console.WriteLine("Domain: {0}", cookie.Domain)
					Console.WriteLine("Path: {0}", cookie.Path)
					Console.WriteLine("Port: {0}", cookie.Port)
					Console.WriteLine("Secure: {0}", cookie.Secure)
					Console.WriteLine("When issued: {0}", cookie.TimeStamp)
					Console.WriteLine("Expires: {0} (expired? {1})", cookie.Expires, cookie.Expired)
					Console.WriteLine("Don't save: {0}", cookie.Discard)
					Console.WriteLine("Comment: {0}", cookie.Comment)
					Console.WriteLine("Uri for comments: {0}", cookie.CommentUri)
					Console.WriteLine("Version: RFC {0}", IIf(cookie.Version = 1, "2109", "2965"))
					Console.WriteLine("String: {0}", cookie.ToString())
				Next
			End If

		Catch ex As Exception
			Beep()
		End Try
	End Sub

End Class