Imports BrightIdeasSoftware
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Xml
Imports System.Text
Imports System.IO
Imports System.Net
Imports WinFreeReg.FreeREG2Browser
Imports System.Collections.Specialized

Public Class formFreeregTables

	Structure paramChurches
		Public County As String
		Public Place As String
	End Structure

	Private _tables As FreeregTables
	Public Property DataSet() As FreeregTables
		Get
			Return _tables
		End Get
		Set(ByVal value As FreeregTables)
			_tables = value
		End Set
	End Property

	Private _filename As String
	Public Property TablesFileName() As String
		Get
			Return _filename
		End Get
		Set(ByVal value As String)
			_filename = value
		End Set
	End Property

   Private _settings As FreeReg2BrowserSettings
   Public Property Settings() As FreeReg2BrowserSettings
      Get
         Return _settings
      End Get
      Set(ByVal value As FreeReg2BrowserSettings)
         _settings = value
         uri = New Uri(_settings.BaseUrl)
      End Set
   End Property

   Private _myDefaultCounty As WinFreeReg.LookupTables.ChapmanCodesRow
   Public Property DefaultCounty() As WinFreeReg.LookupTables.ChapmanCodesRow
      Get
         Return _myDefaultCounty
      End Get
      Set(ByVal value As WinFreeReg.LookupTables.ChapmanCodesRow)
         _myDefaultCounty = value
      End Set
   End Property

   Private uri As Uri
   Private currentCountyCode As String = Nothing
   Private ignoreSelection As Integer = 2

   Private Sub formFreeregTables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ConfigureTextOverlay(dlvRegisterTypes.EmptyListMsgOverlay)
      ConfigureTextOverlay(dlvPlaces.EmptyListMsgOverlay)
      ConfigureTextOverlay(dlvCounties.EmptyListMsgOverlay)
      ConfigureTextOverlay(dlvChurches.EmptyListMsgOverlay)

      ConfigureRegisterTypesOLV()
      ConfigureCountiesOLV()
      ConfigurePlacesOLV()
      ConfigureChurchesOLV()

      TabControl1.SelectTab("tabCounties")

      Dim StartToolTip = New CustomToolTip(Path.Combine(String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName), "ToolTips.xml"), Me)

   End Sub

	Sub ConfigureRegisterTypesOLV()
		Dim dlvcol As OLVColumn

		dlvRegisterTypes.DataSource = _tables
		dlvRegisterTypes.DataMember = "RegisterTypes"

		dlvcol = CType(dlvRegisterTypes.Columns("Type"), OLVColumn)
		dlvcol.Width = 50
		dlvcol.TextAlign = HorizontalAlignment.Center

		dlvcol = CType(dlvRegisterTypes.Columns("Description"), OLVColumn)
		dlvcol.Sortable = False
		dlvcol.FillsFreeSpace = True
		dlvRegisterTypes.RebuildColumns()

	End Sub

	Sub ConfigureCountiesOLV()
		Dim dlvcol As OLVColumn

		dlvCounties.DataSource = _tables
      dlvCounties.DataMember = "Counties"
      dlvCounties.ShowGroups = False

		dlvcol = CType(dlvCounties.Columns("ChapmanCode"), OLVColumn)
		dlvcol.Width = 80
		dlvcol.TextAlign = HorizontalAlignment.Center

		dlvcol = CType(dlvCounties.Columns("CountyName"), OLVColumn)
		dlvcol.Width = 120
		dlvcol.Sortable = False

		dlvcol = CType(dlvCounties.Columns("Notes"), OLVColumn)
		dlvcol.Sortable = False
		dlvcol.FillsFreeSpace = True
		dlvCounties.HeaderWordWrap = True
      dlvCounties.RebuildColumns()
      currentCountyCode = _myDefaultCounty.Code

	End Sub

	Sub ConfigurePlacesOLV()
		Dim dlvcol As OLVColumn

		dlvPlaces.DataSource = _tables
		dlvPlaces.DataMember = "Places"
      dlvPlaces.ShowGroups = False

		dlvcol = CType(dlvPlaces.Columns("ChapmanCode"), OLVColumn)
		dlvcol.Width = 80
		dlvcol.Groupable = True
		dlvcol.Sortable = True
		dlvcol.GroupKeyGetter = New GroupKeyGetterDelegate(AddressOf SetCountyGroupKey)
		dlvcol.GroupKeyToTitleConverter = New GroupKeyToTitleConverterDelegate(AddressOf SetCountyGroupTitle)
		dlvcol.TextAlign = HorizontalAlignment.Center

		dlvcol = CType(dlvPlaces.Columns("CountyName"), OLVColumn)
		dlvcol.IsVisible = False

		dlvcol = CType(dlvPlaces.Columns("PlaceName"), OLVColumn)
		dlvcol.Width = 200
		dlvcol.Groupable = False
		dlvcol.Sortable = True

      dlvcol = CType(dlvPlaces.Columns("Code"), OLVColumn)
      dlvcol.Width = 100
      dlvcol.Groupable = False
      dlvcol.Sortable = True

      dlvcol = CType(dlvPlaces.Columns("Country"), OLVColumn)
		dlvcol.Width = 65
		dlvcol.Sortable = True
		dlvcol.Groupable = True
		dlvcol.GroupKeyGetter = New GroupKeyGetterDelegate(AddressOf SetCountryGroupKey)
		dlvcol.GroupKeyToTitleConverter = New GroupKeyToTitleConverterDelegate(AddressOf SetCountryGroupTitle)
		dlvcol.UseFiltering = False

		dlvcol = CType(dlvPlaces.Columns("Notes"), OLVColumn)
		dlvcol.Sortable = False
		dlvcol.Groupable = False
		dlvcol.FillsFreeSpace = True
		dlvcol.UseFiltering = False

		'		dlvPlaces.CustomSorter = New SortDelegate(AddressOf SortPlaces)
		dlvPlaces.HeaderWordWrap = True
		dlvPlaces.IsSearchOnSortColumn = True
		dlvPlaces.RebuildColumns()

	End Sub

	Sub ConfigureChurchesOLV()
		Dim dlvcol As OLVColumn

		dlvChurches.DataSource = _tables
		dlvChurches.DataMember = "Churches"
      dlvChurches.ShowGroups = False

		dlvcol = CType(dlvChurches.Columns("ChapmanCode"), OLVColumn)
		dlvcol.IsVisible = False
      dlvcol.Groupable = False
      dlvcol.Sortable = True

		dlvcol = CType(dlvChurches.Columns("LastAmended"), OLVColumn)
		dlvcol.IsVisible = False
      dlvcol.Groupable = False

		dlvcol = CType(dlvChurches.Columns("ChurchName"), OLVColumn)
		dlvcol.Width = 58
      dlvcol.Groupable = False
      dlvcol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)

		dlvcol = CType(dlvChurches.Columns("PlaceName"), OLVColumn)
		dlvcol.Width = 53
      dlvcol.IsVisible = False
      dlvcol.Groupable = False
      dlvcol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)

		dlvcol = CType(dlvChurches.Columns("Location"), OLVColumn)
		dlvcol.Width = 66
      dlvcol.Groupable = False

		dlvcol = CType(dlvChurches.Columns("Denomination"), OLVColumn)
		dlvcol.Width = 99
      dlvcol.Groupable = False

		dlvcol = CType(dlvChurches.Columns("Website"), OLVColumn)
		dlvcol.Width = 69
      dlvcol.Groupable = False

		dlvcol = CType(dlvChurches.Columns("Notes"), OLVColumn)
		dlvcol.Sortable = False
      dlvcol.Groupable = False
      dlvcol.FillsFreeSpace = True
		dlvChurches.HeaderWordWrap = True
		dlvChurches.RebuildColumns()
	End Sub

#Region "ObjectListView delegates"

	Private Sub SortPlaces(ByVal column As OLVColumn, ByVal order As SortOrder)
		Dim dlvcol = CType(dlvPlaces.Columns("ChapmanCode"), OLVColumn)
		dlvPlaces.ListViewItemSorter = New ColumnComparer(dlvcol, SortOrder.Ascending, column, order)
	End Sub

	Private Sub ConfigureTextOverlay(ByVal textOverlay As TextOverlay)
		textOverlay.TextColor = Color.Firebrick
		textOverlay.BackColor = Color.AntiqueWhite
		textOverlay.BorderColor = Color.DarkRed
		textOverlay.BorderWidth = 4.0F
		textOverlay.Font = New Font("Chiller", 36)
		textOverlay.Rotation = -5
	End Sub

	Function SetCountyGroupKey(ByVal rowObject As Object) As Object
		Dim drv As DataRowView = CType(rowObject, DataRowView)
		Dim dr As FreeregTables.PlacesRow = drv.Row
		Return dr.ChapmanCode
	End Function

	Function SetCountyGroupTitle(ByVal groupKey As Object) As String
		Dim i = CStr(groupKey)
		Dim row = _tables.Counties.FindByChapmanCode(i)
		If Not String.IsNullOrEmpty(row.CountyName) Then Return String.Format("{0} - {1}", row.ChapmanCode, row.CountyName)
		Return String.Format("{0} - County Name not set", row.ChapmanCode)
	End Function

	Function SetCountryGroupKey(ByVal rowObject As Object) As Object
		Dim drv As DataRowView = CType(rowObject, DataRowView)
		Dim dr As FreeregTables.PlacesRow = drv.Row
		If dr.Country = "England" Then Return 1
		If dr.Country = "Scotland" Then Return 2
		If dr.Country = "Wales" Then Return 3
		If dr.Country = "Ireland" Then Return 4
		Return 0
	End Function

	Function SetCountryGroupTitle(ByVal groupKey As Object) As String
		Dim i = CInt(groupKey)
		If i = 1 Then Return "England"
		If i = 2 Then Return "Scotland"
		If i = 3 Then Return "Wales"
		If i = 4 Then Return "Ireland"
		Return "Country not set"
	End Function

#End Region

#Region "Event handlers"

	Private Sub btnFetch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFetch.Click
		Select Case TabControl1.SelectedTab.Name
			Case "tabRegisterTypes"
				backgroundRegisterTypes.RunWorkerAsync()

			Case "tabCounties"
				backgroundCounties.RunWorkerAsync()

			Case "tabPlaces"
				' Selected Chapman Code as argument
				'
				Dim row As FreeregTables.CountiesRow = cboxCounties.SelectedItem().Row
				backgroundPlaces.RunWorkerAsync(row.ChapmanCode)

			Case "tabChurches"
				' Selected Chapman Code and Place as arguments
				'
				Dim rowCounty As FreeregTables.CountiesRow = cboxCounties.SelectedItem().Row
				Dim rowPlacename As FreeregTables.PlacesRow = cboxPlaces.SelectedItem()
				Dim param As New paramChurches
				param.County = rowCounty.ChapmanCode
				param.Place = rowPlacename.PlaceName
				backgroundChurches.RunWorkerAsync(param)
		End Select
	End Sub

	Private Sub TabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
		Select Case e.TabPage.Name
			Case "tabRegisterTypes"
				HideSelectionFields()
				btnFetch.Text = "Fetch Register Types"
			Case "tabCounties"
				HideSelectionFields()
				btnFetch.Text = "Fetch Counties"
			Case "tabPlaces"
				ShowSelectionFields(False)
				btnFetch.Text = "Fetch Places"
			Case "tabChurches"
				ShowSelectionFields(True)
				btnFetch.Text = "Fetch Churches"
		End Select
	End Sub

	Private Sub HideSelectionFields()
		labCounty.Visible = False
		cboxCounties.Visible = False
		cboxCounties.DataSource = Nothing
		cboxCounties.DisplayMember = ""
		labPlace.Visible = False
		cboxPlaces.Visible = False
		cboxPlaces.DataSource = Nothing
		cboxPlaces.DisplayMember = ""
	End Sub

	Private Sub ShowSelectionFields(ByVal ShowPlaces As Boolean)
		labCounty.Visible = True
		cboxCounties.Visible = True
		cboxCounties.DataSource = _tables.Counties
      cboxCounties.DisplayMember = "ChapmanCode"
      cboxCounties.SelectedIndex = cboxCounties.FindString(currentCountyCode)
		If ShowPlaces Then
			labPlace.Visible = True
			cboxPlaces.Visible = True
			Dim dt = _tables.Places.Where(Function(row As FreeregTables.PlacesRow) row.ChapmanCode = CType(cboxCounties.SelectedItem.row, FreeregTables.CountiesRow).ChapmanCode)
			If dt.Count > 0 Then
				cboxPlaces.DataSource = New BindingSource(dt, Nothing)
				cboxPlaces.DisplayMember = "Placename"
			Else
				cboxPlaces.DataSource = Nothing
				cboxPlaces.DisplayMember = "'"
			End If
		Else
			labPlace.Visible = False
			cboxPlaces.Visible = False
			cboxPlaces.DataSource = Nothing
			cboxPlaces.DisplayMember = ""
		End If
	End Sub

#End Region

#Region "Get Register Types Background Thread"

	Private Sub backgroundRegisterTypes_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundRegisterTypes.DoWork
		Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
		e.Result = GetRegisterTypes(worker, e)
	End Sub

	Private Sub backgroundRegisterTypes_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundRegisterTypes.ProgressChanged
		Application.DoEvents()
	End Sub

	Private Sub backgroundRegisterTypes_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundRegisterTypes.RunWorkerCompleted
		If (e.Error IsNot Nothing) Then
			Select Case e.Error.GetType.Name
				Case "BackgroundWorkerException"
					HandleBackgroundWorkerException(e.Error)
				Case "XmlException"
					HandleXmlException(e.Error)
				Case "WebException"
					HandleWebException(e.Error)
				Case Else
					HandleException(e.Error)
			End Select
		ElseIf e.Cancelled Then
			' Next, handle the case where the user canceled the operation.
			' Note that due to a race condition in the DoWork event handler, the Cancelled
			' flag may not have been set, even though CancelAsync was called.
		Else
			' Finally, handle the case where the operation succeeded.
			Dim res As BackgroundResult = CType(e.Result, BackgroundResult)

			Try
				If res.Result.StartsWith("<RegisterTypes>") Then
					Dim doc As XmlDocument = New XmlDocument()
					Dim buf As Byte() = ASCIIEncoding.ASCII.GetBytes(res.Result)
					Dim ms As MemoryStream = New MemoryStream(buf)
					doc.Load(ms)
					ms.Close()

					buf = ASCIIEncoding.ASCII.GetBytes(doc.OuterXml)
					ms = New MemoryStream(buf)
					Dim ds As DataSet = New DataSet()
					ds.ReadXml(ms, XmlReadMode.InferSchema)
					ms.Close()

					_tables.RegisterTypes.Clear()
					For Each row As DataRow In ds.Tables("registertype").Rows
						Console.WriteLine(String.Format("{0} - {1}", row("Type"), row("Description")))
						_tables.RegisterTypes.AddRegisterTypesRow(row("Type"), row("Description"))
					Next
					_tables.RegisterTypes.AcceptChanges()
					_tables.WriteXml(_filename, XmlWriteMode.WriteSchema)
				Else
               Throw New BackgroundWorkerException("Getting RegisterTypes from FreeREG failed - Not logged on")
				End If

			Catch ex As BackgroundWorkerException
				Throw

			Catch ex As XmlException
				Throw New BackgroundWorkerException("Getting RegisterTypes failed", ex)

			Catch ex As Exception
				Throw New BackgroundWorkerException("Getting RegisterTypes failed", ex)

			End Try
		End If
	End Sub

	Function GetRegisterTypes(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Object

		Using webClient As New CookieAwareWebClient()
			Try
				webClient.SetTimeout(30000)
            webClient.CookieContainer = New CookieContainer()
            For Each cookie In _settings.Cookies
               webClient.CookieContainer.Add(uri, New Cookie(cookie.name, cookie.value))
            Next
            Console.WriteLine("Out - {0}", webClient.CookieContainer.GetCookieHeader(uri))
            Dim addrRequest As String = _settings.BaseUrl + "/transreg_counties/register_types.xml"
				Dim response = webClient.DownloadString(addrRequest)

            Console.WriteLine(" In - {0}", webClient.CookieContainer.GetCookieHeader(uri))
            Dim hdr = webClient.ResponseHeaders("Set-Cookie")
            _settings.Cookies.Add(webClient.GetAllCookiesFromHeader(hdr, _settings.BaseUrl))
            Dim res As New BackgroundResult()
				res.Parameter = e.Argument
				res.Result = response
				Return res

			Catch ex As XmlException
            Throw New BackgroundWorkerException("Getting RegisterTypes from FreeREG failed", ex)

			Catch ex As WebException
				Dim webResp As HttpWebResponse = ex.Response
				If webResp Is Nothing Then
               Throw New BackgroundWorkerException("Getting RegisterTypes from FreeREG failed", ex)
				Else
					Console.WriteLine(String.Format("WebException:{0} Desc:{1}", webResp.StatusCode, webResp.StatusDescription))
					Select Case webResp.StatusCode
						Case HttpStatusCode.NotFound

						Case HttpStatusCode.NotAcceptable

						Case HttpStatusCode.InternalServerError

						Case Else

					End Select
               Throw New BackgroundWorkerException("Getting RegisterTypes from FreeREG failed", ex)
				End If

			Catch ex As Exception
				Throw

			End Try

		End Using

	End Function

#End Region

#Region "Get Counties Background Thread"

	Private Sub backgroundCounties_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundCounties.DoWork
		Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
		e.Result = GetCounties(worker, e)
	End Sub

	Private Sub backgroundCounties_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundCounties.ProgressChanged
		Application.DoEvents()
	End Sub

	Private Sub backgroundCounties_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundCounties.RunWorkerCompleted
		If (e.Error IsNot Nothing) Then
			Select Case e.Error.GetType.Name
				Case "BackgroundWorkerException"
					HandleBackgroundWorkerException(e.Error)
				Case "XmlException"
					HandleXmlException(e.Error)
				Case "WebException"
					HandleWebException(e.Error)
				Case Else
					HandleException(e.Error)
			End Select
		ElseIf e.Cancelled Then
			' Next, handle the case where the user canceled the operation.
			' Note that due to a race condition in the DoWork event handler, the Cancelled
			' flag may not have been set, even though CancelAsync was called.
		Else
			' Finally, handle the case where the operation succeeded.
			Dim res As BackgroundResult = CType(e.Result, BackgroundResult)

			Try
				If res.Result.StartsWith("<CountiesTable>") Then
					Dim doc As XmlDocument = New XmlDocument()
					Dim buf As Byte() = ASCIIEncoding.ASCII.GetBytes(res.Result)
					Dim ms As MemoryStream = New MemoryStream(buf)
					doc.Load(ms)
					ms.Close()

					buf = ASCIIEncoding.ASCII.GetBytes(doc.OuterXml)
					ms = New MemoryStream(buf)
					Dim ds As DataSet = New DataSet()
					ds.ReadXml(ms, XmlReadMode.InferSchema)
					ms.Close()

					_tables.Counties.Clear()
					For Each row As DataRow In ds.Tables("County").Rows
						Console.WriteLine(String.Format("{0} - {1} - {2}", row("ChapmanCode"), row("Description"), row("Notes")))
						_tables.Counties.AddCountiesRow(row("ChapmanCode"), row("Description"), row("Notes"))
					Next
					_tables.Counties.AcceptChanges()
					_tables.WriteXml(_filename, XmlWriteMode.WriteSchema)
				Else
               Throw New BackgroundWorkerException("Getting Counties from FreeREG failed - not logged on")
				End If

			Catch ex As BackgroundWorkerException
				Throw

			Catch ex As XmlException
				Throw New BackgroundWorkerException("Getting Counties failed", ex)

			Catch ex As Exception
				Throw New BackgroundWorkerException("Getting Counties failed", ex)

			End Try
		End If
	End Sub

	Function GetCounties(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Object

		Using webClient As New CookieAwareWebClient()
			Try
				webClient.SetTimeout(30000)
            webClient.CookieContainer = New CookieContainer()
            For Each cookie In _settings.Cookies
               webClient.CookieContainer.Add(Uri, New Cookie(cookie.name, cookie.value))
            Next
            Dim addrRequest As String = _settings.BaseUrl + "/transreg_counties/list.xml"
				Dim contents As String = webClient.DownloadString(addrRequest)

            Dim hdr = webClient.ResponseHeaders("Set-Cookie")
            _settings.Cookies.Add(webClient.GetAllCookiesFromHeader(hdr, _settings.BaseUrl))
            Dim res As New BackgroundResult()
				res.Parameter = e.Argument
				res.Result = contents
				Return res

			Catch ex As XmlException
            Throw New BackgroundWorkerException("Getting Counties from FreeREG failed", ex)

			Catch ex As WebException
				Dim webResp As HttpWebResponse = ex.Response
				If webResp Is Nothing Then
               Throw New BackgroundWorkerException("Getting Counties from FreeREG failed", ex)
				Else
					Console.WriteLine(String.Format("WebException:{0} Desc:{1}", webResp.StatusCode, webResp.StatusDescription))
					Select Case webResp.StatusCode
						Case HttpStatusCode.NotFound

						Case HttpStatusCode.NotAcceptable

						Case HttpStatusCode.InternalServerError

						Case Else

					End Select
               Throw New BackgroundWorkerException("Getting Counties from FreeREG failed", ex)
				End If

			Catch ex As Exception
				Throw
			End Try
		End Using
	End Function

#End Region

#Region "Get Places Background Thread"

	Private Sub backgroundPlaces_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundPlaces.DoWork
		Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
		e.Result = GetPlaces(e.Argument, worker, e)
	End Sub

	Private Sub backgroundPlaces_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundPlaces.ProgressChanged
		Application.DoEvents()
	End Sub

	Private Sub backgroundPlaces_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundPlaces.RunWorkerCompleted
		If (e.Error IsNot Nothing) Then
			Select Case e.Error.GetType.Name
				Case "BackgroundWorkerException"
					HandleBackgroundWorkerException(e.Error)
				Case "XmlException"
					HandleXmlException(e.Error)
				Case "WebException"
					HandleWebException(e.Error)
				Case Else
					HandleException(e.Error)
			End Select
		ElseIf e.Cancelled Then
			' Next, handle the case where the user canceled the operation.
			' Note that due to a race condition in the DoWork event handler, the Cancelled
			' flag may not have been set, even though CancelAsync was called.
		Else
			' Finally, handle the case where the operation succeeded.
			dlvPlaces.DataSource = _tables
			dlvPlaces.DataMember = "Places"

		End If
	End Sub

	Function GetPlaces(ByVal selectedCounty As String, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Long

		Using webClient As New CookieAwareWebClient()
			Try
				webClient.SetTimeout(30000)
            webClient.CookieContainer = New CookieContainer()
            For Each cookie In _settings.Cookies
               webClient.CookieContainer.Add(Uri, New Cookie(cookie.name, cookie.value))
            Next
            Dim addrRequest As String = _settings.BaseUrl + "/transreg_places/list.xml"
				Dim query_data = New NameValueCollection()
				query_data.Add("county", selectedCounty)
				webClient.QueryString = query_data
				Dim contents As String = webClient.DownloadString(addrRequest)

            Dim hdr = webClient.ResponseHeaders("Set-Cookie")
            _settings.Cookies.Add(webClient.GetAllCookiesFromHeader(hdr, _settings.BaseUrl))

				Try
					If contents.StartsWith("<PlacesTable>") Then
						Dim doc As XmlDocument = New XmlDocument()
						Dim buf As Byte() = ASCIIEncoding.ASCII.GetBytes(contents)
						Dim ms As MemoryStream = New MemoryStream(buf)
						doc.Load(ms)
						ms.Close()

						buf = ASCIIEncoding.ASCII.GetBytes(doc.OuterXml)
						ms = New MemoryStream(buf)
						Dim ds As DataSet = New DataSet()
						ds.ReadXml(ms, XmlReadMode.InferSchema)
						ms.Close()

						dlvPlaces.DataSource = Nothing
                  For Each row As DataRow In ds.Tables("Place").Rows
                     Dim drow As FreeregTables.PlacesRow = _tables.Places.FindByPlaceNameChapmanCode(row.Item("PlaceName"), row.Item("ChapmanCode"))
                     If drow Is Nothing Then
                        _tables.Places.AddPlacesRow(row.Item("PlaceName"), row.Item("ChapmanCode"), row.Item("Country"), row.Item("CountyName"), row.Item("PlaceName").Substring(0, 3).ToUpper, row.Item("Notes"))
                     Else
                        drow.Country = row.Item("Country")
                        drow.CountyName = row.Item("CountyName")
                        drow.Notes = row.Item("Notes")
                        If IsNothing(drow.Code) Or IsDBNull(drow.Code) Then drow.Code = row.Item("PlaceName").Substring(0, 3).ToUpper
                     End If
                  Next
						_tables.Places.AcceptChanges()
						_tables.WriteXml(_filename, XmlWriteMode.WriteSchema)
					Else
                  Throw New BackgroundWorkerException("Getting Places from FreeREG failed - not logged on")
					End If

				Catch ex As BackgroundWorkerException
					Throw

				Catch ex As XmlException
					Throw New BackgroundWorkerException("Getting Places failed", ex)

				Catch ex As Exception
					Throw New BackgroundWorkerException("Getting Places failed", ex)

				End Try

			Catch ex As XmlException
            Throw New BackgroundWorkerException("Getting Places from FreeREG failed", ex)

			Catch ex As WebException
				Dim webResp As HttpWebResponse = ex.Response
				If webResp Is Nothing Then
               Throw New BackgroundWorkerException("Getting Places from FreeREG failed", ex)
				Else
					Console.WriteLine(String.Format("WebException:{0} Desc:{1}", webResp.StatusCode, webResp.StatusDescription))
					Select Case webResp.StatusCode
						Case HttpStatusCode.NotFound

						Case HttpStatusCode.NotAcceptable

						Case HttpStatusCode.InternalServerError

						Case Else

					End Select
               Throw New BackgroundWorkerException("Getting Places from FreeREG failed", ex)
				End If

			Catch ex As Exception
				Throw
			End Try
		End Using

	End Function

#End Region

#Region "Get Churches Background Thread"

	Private Sub backgroundChurches_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundChurches.DoWork
		Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
		e.Result = GetChurches(e.Argument, worker, e)
	End Sub

	Private Sub backgroundChurches_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundChurches.ProgressChanged
		Application.DoEvents()
	End Sub

	Private Sub backgroundChurches_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundChurches.RunWorkerCompleted
		If (e.Error IsNot Nothing) Then
			Select Case e.Error.GetType.Name
				Case "BackgroundWorkerException"
					HandleBackgroundWorkerException(e.Error)
				Case "XmlException"
					HandleXmlException(e.Error)
				Case "WebException"
					HandleWebException(e.Error)
				Case Else
					HandleException(e.Error)
			End Select
		ElseIf e.Cancelled Then
			' Next, handle the case where the user canceled the operation.
			' Note that due to a race condition in the DoWork event handler, the Cancelled
			' flag may not have been set, even though CancelAsync was called.
		Else
			' Finally, handle the case where the operation succeeded.
			dlvChurches.DataSource = _tables
			dlvChurches.DataMember = "Churches"

		End If
	End Sub

	Function GetChurches(ByVal params As paramChurches, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Long

		Using webClient As New CookieAwareWebClient()
			Try
				webClient.SetTimeout(30000)
            webClient.CookieContainer = New CookieContainer()
            For Each cookie In _settings.Cookies
               webClient.CookieContainer.Add(Uri, New Cookie(cookie.name, cookie.value))
            Next
            Dim addrRequest As String = _settings.BaseUrl + "/transreg_churches/list.xml"
				Dim query_data = New NameValueCollection()
				query_data.Add("county", params.County)
				query_data.Add("place", params.Place)
				webClient.QueryString = query_data
				Dim contents As String = webClient.DownloadString(addrRequest)

            Dim hdr = webClient.ResponseHeaders("Set-Cookie")
            _settings.Cookies.Add(webClient.GetAllCookiesFromHeader(hdr, _settings.BaseUrl))

				Try
					If contents.StartsWith("<ChurchesTable>") Then
						Dim doc As XmlDocument = New XmlDocument()
						Dim buf As Byte() = ASCIIEncoding.ASCII.GetBytes(contents)
						Dim ms As MemoryStream = New MemoryStream(buf)
						doc.Load(ms)
						ms.Close()

						buf = ASCIIEncoding.ASCII.GetBytes(doc.OuterXml)
						ms = New MemoryStream(buf)
						Dim ds As DataSet = New DataSet()
						ds.ReadXml(ms, XmlReadMode.InferSchema)
						ms.Close()

						If ds.Tables("Church") IsNot Nothing Then
							For Each row As DataRow In ds.Tables("Church").Rows
								Dim drow As FreeregTables.ChurchesRow = _tables.Churches.FindByChurchNameChapmanCodePlaceName(row.Item("ChurchName"), params.County, row.Item("PlaceName"))
								If drow Is Nothing Then
									_tables.Churches.AddChurchesRow(row.Item("ChurchName"), params.County, params.Place, row.Item("Location"), row.Item("Denomination"), row.Item("Website"), row.Item("LastAmended"), row.Item("Notes"))
								Else
									drow.Location = row.Item("Location")
									drow.Denomination = row.Item("Denomination")
									drow.Website = row.Item("Website")
									drow.LastAmended = row.Item("LastAmended")
									drow.Notes = row.Item("Notes")
								End If
							Next
							_tables.Churches.AcceptChanges()
                     _tables.WriteXml(_filename, XmlWriteMode.WriteSchema)
                  Else
                     Throw New BackgroundWorkerException(String.Format("No church information available for {0}", params.Place))
                  End If
					Else
                  Throw New BackgroundWorkerException("Getting Churches from FreeREG failed - Not logged on")
					End If

				Catch ex As BackgroundWorkerException
					Throw

				Catch ex As XmlException
					Throw New BackgroundWorkerException("Getting Places failed", ex)

				Catch ex As Exception
					Throw New BackgroundWorkerException("Getting Places failed", ex)

				End Try

			Catch ex As XmlException
            Throw New BackgroundWorkerException("Getting Churches from FreeREG failed", ex)

			Catch ex As WebException
				Dim webResp As HttpWebResponse = ex.Response
				If webResp Is Nothing Then
               Throw New BackgroundWorkerException("Getting Churches from FreeREG failed", ex)
				Else
					Console.WriteLine(String.Format("WebException:{0} Desc:{1}", webResp.StatusCode, webResp.StatusDescription))
					Select Case webResp.StatusCode
						Case HttpStatusCode.NotFound

						Case HttpStatusCode.NotAcceptable

						Case HttpStatusCode.InternalServerError

						Case Else

					End Select
               Throw New BackgroundWorkerException("Getting Churches from FreeREG failed", ex)
				End If

			Catch ex As Exception
				Throw
			End Try
		End Using
	End Function

#End Region

#Region "Exception Handlers"

	Public Sub HandleUploadBackgroundWorkerException(ByVal ex As Exception)
		Dim exi = ex.InnerException
		If exi IsNot Nothing Then
			Dim x = exi.GetType.Name
			Select Case x
				Case "WebException"
					Dim webEx As WebException = exi
					Dim webResp As HttpWebResponse = webEx.Response
					Dim strm As Stream = webResp.GetResponseStream()
					Dim encode As Encoding = Encoding.GetEncoding(webResp.CharacterSet)
					Using dlg As New formPageReceived()
						dlg.Text = "WebException"
						dlg.wbPage.DocumentStream = strm
						dlg.ShowDialog()
					End Using

					If ex.InnerException.InnerException IsNot Nothing Then
						MessageBox.Show(String.Format("{0} - {1}", ex.InnerException.Message, ex.InnerException.InnerException.Message), ex.Message)
					Else
						MessageBox.Show(String.Format("{0}", ex.InnerException.Message), ex.Message)
					End If
					webResp.Close()
					Beep()

				Case "XmlException"
					MessageBox.Show(String.Format("{0} - {1}", "", ex.InnerException.Message), ex.Message)
					Beep()

				Case Else
					MessageBox.Show(String.Format("{0} - {1}", "", ex.InnerException.Message), ex.Message)
					Beep()
			End Select
		Else
			MessageBox.Show(ex.Message)
		End If
	End Sub

	Public Sub HandleBackgroundWorkerException(ByVal ex As Exception)
		Dim exi = ex.InnerException
		If exi IsNot Nothing Then
			Dim x = exi.GetType.Name
			Select Case x
				Case "WebException"
					If ex.InnerException.InnerException IsNot Nothing Then
						MessageBox.Show(String.Format("{0} - {1}", ex.InnerException.Message, ex.InnerException.InnerException.Message), ex.Message)
					Else
						MessageBox.Show(String.Format("{0}", ex.InnerException.Message), ex.Message)
					End If
					Beep()
				Case "XmlException"
					MessageBox.Show(String.Format("{0} - {1}", "", ex.InnerException.Message), ex.Message)
					Beep()
				Case Else
					Beep()
			End Select
		Else
			MessageBox.Show(ex.Message)
		End If
	End Sub

	Public Sub HandleXmlException(ByVal ex As Exception)
		Beep()
	End Sub

	Public Sub HandleWebException(ByVal ex As Exception)
		MessageBox.Show(String.Format("{0} - {1}", ex.InnerException.Message, ex.InnerException.InnerException.Message), ex.Message)
		Beep()
	End Sub

	Public Sub HandleException(ByVal ex As Exception)
		Beep()
	End Sub

#End Region

	Private Sub cboxCounties_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxCounties.SelectedIndexChanged
		Select Case TabControl1.SelectedTab.Name
			Case "tabRegisterTypes"
			Case "tabCounties"
         Case "tabPlaces"
            If ignoreSelection > 0 Then
               dlvPlaces.ModelFilter = Nothing
               dlvPlaces.ModelFilter = New FilterPlacesByCounty(_myDefaultCounty.Code)
               ignoreSelection -= 1
            Else
               If Not String.IsNullOrEmpty(CType(cboxCounties.SelectedItem.row, FreeregTables.CountiesRow).ChapmanCode) Then
                  dlvPlaces.ModelFilter = Nothing
                  dlvPlaces.ModelFilter = New FilterPlacesByCounty(CType(cboxCounties.SelectedItem.row, FreeregTables.CountiesRow).ChapmanCode)
                  currentCountyCode = CType(cboxCounties.SelectedItem.row, FreeregTables.CountiesRow).ChapmanCode
               Else
                  dlvPlaces.ModelFilter = Nothing
                  currentCountyCode = _myDefaultCounty.Code
               End If
            End If

         Case "tabChurches"
            If Not String.IsNullOrEmpty(CType(cboxCounties.SelectedItem.row, FreeregTables.CountiesRow).ChapmanCode) Then
               dlvChurches.ModelFilter = Nothing
               Dim filterChurches = New FilterChurchesByCountyAndPlace()

               Dim dt = _tables.Places.Where(Function(row As FreeregTables.PlacesRow) row.ChapmanCode = CType(cboxCounties.SelectedItem.row, FreeregTables.CountiesRow).ChapmanCode)
               If dt.Count > 0 Then
                  cboxPlaces.DataSource = New BindingSource(dt, Nothing)
                  cboxPlaces.DisplayMember = "Placename"
               Else
                  cboxPlaces.ValueMember = ""
                  cboxPlaces.SelectedValue = ""
                  cboxPlaces.DataSource = Nothing
                  cboxPlaces.DisplayMember = ""
                  cboxPlaces.Items.Clear()
               End If
               filterChurches.ChapmanCode = CType(cboxCounties.SelectedItem.row, FreeregTables.CountiesRow).ChapmanCode

               If cboxPlaces.SelectedItem IsNot Nothing Then
                  filterChurches.PlaceName = CType(cboxPlaces.SelectedItem, FreeregTables.PlacesRow).PlaceName
               Else
                  filterChurches.PlaceName = ""
               End If

               dlvChurches.ModelFilter = filterChurches
            Else
               dlvChurches.ModelFilter = Nothing
            End If
      End Select
	End Sub

	Private Sub cboxPlaces_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxPlaces.SelectedIndexChanged
		Select Case TabControl1.SelectedTab.Name
			Case "tabRegisterTypes"
			Case "tabCounties"
			Case "tabPlaces"
			Case "tabChurches"
				If Not String.IsNullOrEmpty(CType(cboxCounties.SelectedItem.row, FreeregTables.CountiesRow).ChapmanCode) Then
					If Not String.IsNullOrEmpty(CType(cboxPlaces.SelectedItem, FreeregTables.PlacesRow).PlaceName) Then
						dlvChurches.ModelFilter = Nothing
						Dim filterChurches = New FilterChurchesByCountyAndPlace()
						filterChurches.ChapmanCode = CType(cboxCounties.SelectedItem.row, FreeregTables.CountiesRow).ChapmanCode
						filterChurches.PlaceName = CType(cboxPlaces.SelectedItem, FreeregTables.PlacesRow).PlaceName
						dlvChurches.ModelFilter = filterChurches
					End If
				End If
		End Select
	End Sub

	Public Class FilterPlacesByCounty
		Implements IModelFilter

		Private m_Chapmancode As String

		Sub New(ByVal ChapmanCode As String)
			m_Chapmancode = ChapmanCode
		End Sub

		Public Function Filter(ByVal modelObject As Object) As Boolean Implements BrightIdeasSoftware.IModelFilter.Filter
			Dim row As FreeregTables.PlacesRow = CType(modelObject.Row, FreeregTables.PlacesRow)
			Return row.ChapmanCode = m_Chapmancode
		End Function
	End Class

	Public Class FilterChurchesByCountyAndPlace
		Implements IModelFilter

		Private m_Chapmancode As String
		Public Property ChapmanCode() As String
			Get
				Return m_Chapmancode
			End Get
			Set(ByVal value As String)
				m_Chapmancode = value
			End Set
		End Property

		Private m_place As String
		Public Property PlaceName() As String
			Get
				Return m_place
			End Get
			Set(ByVal value As String)
				m_place = value
			End Set
		End Property

		Public Function Filter(ByVal modelObject As Object) As Boolean Implements BrightIdeasSoftware.IModelFilter.Filter
			Dim row As FreeregTables.ChurchesRow = CType(modelObject.Row, FreeregTables.ChurchesRow)
			Return row.ChapmanCode = m_Chapmancode AndAlso row.PlaceName = m_place
		End Function
	End Class

End Class