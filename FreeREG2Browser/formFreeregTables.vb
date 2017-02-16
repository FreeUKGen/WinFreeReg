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
Imports System.Text.RegularExpressions

Public Class formFreeregTables

   Structure paramChurches
      Public County As FreeregTables.CountiesRow
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

   Private formHelp As formGeneralHelp = Nothing
   Public Sub New(helpForm As formGeneralHelp)
      InitializeComponent()

      formHelp = helpForm
   End Sub

   Private _FileIsChanged As Boolean
   Public ReadOnly Property IsChanged() As Boolean
      Get
         Return _FileIsChanged
      End Get
   End Property

   Private uri As Uri
   Private currentCountyCode As String = Nothing

   Private Sub formFreeregTables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ConfigureTextOverlay(dlvRegisterTypes.EmptyListMsgOverlay)
      ConfigureTextOverlay(dlvPlaces.EmptyListMsgOverlay)
      ConfigureTextOverlay(dlvCounties.EmptyListMsgOverlay)
      ConfigureTextOverlay(dlvChurches.EmptyListMsgOverlay)

      ConfigureRegisterTypesOLV()
      ConfigureCountiesOLV()
      ConfigurePlacesOLV()
      ConfigureChurchesOLV()

      CountiesBindingSource.DataSource = _tables
      currentCountyCode = _myDefaultCounty.Code
      cboxCounties.SelectedIndex = cboxCounties.FindString(_myDefaultCounty.Code)
      TabControl1.SelectTab("tabCounties")

      Dim StartToolTip = New CustomToolTip(Path.Combine(String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName), "ToolTips.xml"), Me)
      _FileIsChanged = False
   End Sub

   Sub ConfigureRegisterTypesOLV()
      dlvRegisterTypes.DataSource = _tables
      dlvRegisterTypes.Sort("Type")
   End Sub

   Sub ConfigureCountiesOLV()
   End Sub

   Sub ConfigurePlacesOLV()
      olvc2ChapmanCode.GroupKeyGetter = New GroupKeyGetterDelegate(AddressOf SetCountyGroupKey)
      olvc2ChapmanCode.GroupKeyToTitleConverter = New GroupKeyToTitleConverterDelegate(AddressOf SetCountyGroupTitle)

      olvc2Country.GroupKeyGetter = New GroupKeyGetterDelegate(AddressOf SetCountryGroupKey)
      olvc2Country.GroupKeyToTitleConverter = New GroupKeyToTitleConverterDelegate(AddressOf SetCountryGroupTitle)
   End Sub

   Sub ConfigureChurchesOLV()
      dlvChurches.CellEditActivation = My.Settings.optionCellEditing
      dlvChurches.CellEditUseWholeCell = True
      If My.Settings.optionEditingCellBorder Then dlvChurches.AddDecoration(New EditingCellBorderDecoration(True))
   End Sub

#Region "ObjectListView delegates"

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
            Dim row As FreeregTables.CountiesRow = cboxCounties.SelectedItem().Row
            backgroundPlaces.RunWorkerAsync(row)

         Case "tabChurches"
            Dim params As paramChurches = New paramChurches()
            params.County = cboxCounties.SelectedItem().Row
            params.Place = cboxPlaces.SelectedItem().row.PlaceName
            backgroundChurches.RunWorkerAsync(params)

      End Select
   End Sub

   Private Sub btnApproved_Click(sender As Object, e As EventArgs) Handles btnApproved.Click
      If dlvRegisterTypes.DataMember = "RegisterTypes" Then
         dlvRegisterTypes.DataMember = "ApprovedRegisterTypes"
         btnApproved.Text = "Show All Types"
         dlvRegisterTypes.Sort("Type")
      Else
         dlvRegisterTypes.DataMember = "RegisterTypes"
         btnApproved.Text = "Show Approved Types"
         dlvRegisterTypes.Sort("Type")
      End If
   End Sub

   Private Sub TabControl1_Selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
      Select Case e.TabPage.Name
         Case "tabRegisterTypes"
            HideSelectionFields()
            btnFetch.Text = "Fetch Register Types"
            btnApproved.Visible = True
         Case "tabCounties"
            HideSelectionFields()
            btnFetch.Text = "Fetch Counties"
            btnApproved.Visible = False
            cboxCounties.SelectedIndex = cboxCounties.FindString(_myDefaultCounty.Code)
         Case "tabPlaces"
            ShowSelectionFields(False)
            btnFetch.Text = "Fetch Places"
            btnApproved.Visible = False
         Case "tabChurches"
            ShowSelectionFields(True)
            btnFetch.Text = "Fetch Churches"
            btnApproved.Visible = False
      End Select
   End Sub

   Private Sub HideSelectionFields()
      labCounty.Visible = False
      cboxCounties.Visible = False
      labPlaces.Visible = False
      cboxPlaces.Visible = False
   End Sub

   Private Sub ShowSelectionFields(ByVal showPlaces As Boolean)
      labCounty.Visible = True
      cboxCounties.Visible = True
      labPlaces.Visible = showPlaces
      cboxPlaces.Visible = showPlaces
   End Sub

   Private Sub dlvCounties_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dlvCounties.SelectedIndexChanged
   End Sub

   Private Sub formFreeregTables_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles MyBase.HelpRequested
      Try
         formHelp.Title = "FreeREG Browser"
         formHelp.StartPage = "FreeregTables.html"
         formHelp.Show()

      Catch ex As Exception
         formHelp.Hide()
         MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try
   End Sub

   Private Sub dlvChurches_CellEditStarting(sender As Object, e As CellEditEventArgs) Handles dlvChurches.CellEditStarting
      If e.Column.AspectName = "FileCode" Then
         With CType(e.Control, TextBox)
            .CharacterCasing = CharacterCasing.Upper
#If USE_FILECODES Then
            .MaxLength = 8
#Else
            .MaxLength = 3
#End If
         End With
      End If
   End Sub

#End Region

#Region "Get Register Types Background Thread"

   Private Sub backgroundRegisterTypes_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundRegisterTypes.DoWork
      Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
      GetRegisterTypes(worker, e)
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
         MessageBox.Show(e.Result, "Get Register Types", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Private Sub GetRegisterTypes(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs)

      Using webClient As New CookieAwareWebClient()
         Try
            webClient.SetTimeout(30000)
            For Each cookie In _settings.Cookies
               webClient.AddCookie(uri, New Cookie(cookie.Name, cookie.Value))
            Next

            ' "Archdeacon's Transcripts" >= "AT",
            ' "Bishop's Transcripts" >= "BT",
            ' "Dwelly's Transcripts" >= "DW",
            ' "Extract of a Register" >= "EX",
            ' "Memorial Inscription" >= "MI",
            ' "Other Register" >= "OR",
            ' "Parish Register" >= "PR",
            ' "Phillimore's Transcripts" >= "PH",
            ' "Transcript" >= "TR",
            ' "Unknown" >= "UK"}

            Dim addrRequest As String = _settings.BaseUrl + "/transreg_counties/register_types.xml"   ' APPROVED_OPTIONS
            Dim contents = webClient.DownloadString(addrRequest).Trim
            Dim hdr = webClient.ResponseHeaders("Set-Cookie")
            _settings.Cookies.Add(webClient.GetAllCookiesFromHeader(hdr, _settings.BaseUrl))

            If contents.StartsWith("<RegisterTypes>") Then
               Dim xmlDoc As XmlDocument = New XmlDocument()
               Dim buf As Byte() = ASCIIEncoding.ASCII.GetBytes(contents)
               Dim ms As MemoryStream = New MemoryStream(buf)
               xmlDoc.Load(ms)
               ms.Close()

               buf = ASCIIEncoding.ASCII.GetBytes(xmlDoc.OuterXml)
               ms = New MemoryStream(buf)
               Dim ds As DataSet = New DataSet()
               ds.ReadXml(ms, XmlReadMode.InferSchema)
               ms.Close()

               _tables.ApprovedRegisterTypes.Clear()
               For Each row As DataRow In ds.Tables("registertype").Rows
                  _tables.ApprovedRegisterTypes.AddApprovedRegisterTypesRow(row("Type"), row("Description"))
               Next
               _tables.ApprovedRegisterTypes.AcceptChanges()
               _FileIsChanged = True

               ' "Archdeacon's Transcripts" >= "AT",
               ' "Bishop's Transcripts" >= "BT",
               ' "Dwelly's Transcript (New)" >= "DT",
               ' "Dwelly's Transcripts" >= "DW",
               ' "Extract of a Register" >= "EX",
               ' "Memorial Inscription" >= "MI",
               ' "Other Register" >= "OR"
               ' "Other Transcript" >= "OT",
               ' "Phillimore's Transcripts" >= "PH",
               ' "Parish Register" >= "PR",
               ' "Phillimore's Transcript (New)" >= "PT",
               ' "Transcript" >= "TR",
               ' "Unknown" >= "UK",
               ' "Unspecified" >= " ",
               addrRequest = _settings.BaseUrl + "/transreg_counties/all_register_types.xml"       ' OPTIONS
               contents = webClient.DownloadString(addrRequest).Trim
               hdr = webClient.ResponseHeaders("Set-Cookie")
               _settings.Cookies.Add(webClient.GetAllCookiesFromHeader(hdr, _settings.BaseUrl))

               If contents.StartsWith("<AllRegisterTypes>") Then
                  xmlDoc = New XmlDocument()
                  buf = ASCIIEncoding.ASCII.GetBytes(contents)
                  ms = New MemoryStream(buf)
                  xmlDoc.Load(ms)
                  ms.Close()

                  buf = ASCIIEncoding.ASCII.GetBytes(xmlDoc.OuterXml)
                  ms = New MemoryStream(buf)
                  ds = New DataSet()
                  ds.ReadXml(ms, XmlReadMode.InferSchema)
                  ms.Close()

                  _tables.RegisterTypes.Clear()
                  For Each row As DataRow In ds.Tables("registertype").Rows
                     _tables.RegisterTypes.AddRegisterTypesRow(row("Type"), row("Description"))
                  Next
                  _tables.RegisterTypes.AcceptChanges()
                  _FileIsChanged = True
                  e.Result = My.Resources.msgRegisterTypesRefreshed
               ElseIf contents.StartsWith("<?xml version=""1.0"" encoding=""UTF-8""?>") Then
                  xmlDoc = New XmlDocument()
                  xmlDoc.LoadXml(contents)
                  Dim root As XmlElement = xmlDoc.DocumentElement()
                  If root Is Nothing Then
                     ' No root element
                     Throw New BackgroundWorkerException("Fetch Register Types failed - Missing root element")
                  Else
                     If String.Compare(root.Name, "register-types", True) = 0 Then
                        Dim result As XmlElement = xmlDoc.SelectSingleNode("/register-types/result")
                        If result Is Nothing Then
                           ' Missing 'result' node
                           Throw New BackgroundWorkerException("Fetch Register Types failed - Missing result node")
                        Else
                           Select Case result.FirstChild.Value
                              Case "success"
                              Case "failure"
                                 Dim message = xmlDoc.SelectSingleNode("/register-types/message").FirstChild.Value
                                 '  <message>You are not authorised to use these facilities</message>
                                 Throw New BackgroundWorkerException(message)
                              Case Else
                                 Throw New BackgroundWorkerException("Fetch Register Types failed - XML format error")
                           End Select
                        End If
                     End If
                  End If
               Else
                  Throw New BackgroundWorkerException("Fetching Register Types from FreeREG failed - not logged on")
               End If
            ElseIf contents.StartsWith("<?xml version=""1.0"" encoding=""UTF-8""?>") Then
               Dim xmlDoc As XmlDocument = New XmlDocument()
               xmlDoc.LoadXml(contents)
               Dim root As XmlElement = xmlDoc.DocumentElement()
               If root Is Nothing Then
                  ' No root element
                  Throw New BackgroundWorkerException("Fetch Register Types failed - Missing root element")
               Else
                  If String.Compare(root.Name, "register-types", True) = 0 Then
                     Dim result As XmlElement = xmlDoc.SelectSingleNode("/register-types/result")
                     If result Is Nothing Then
                        ' Missing 'result' node
                        Throw New BackgroundWorkerException("Fetch Register Types failed - Missing result node")
                     Else
                        Select Case result.FirstChild.Value
                           Case "success"
                           Case "failure"
                              Dim message = xmlDoc.SelectSingleNode("/register-types/message").FirstChild.Value
                              '  <message>You are not authorised to use these facilities</message>
                              Throw New BackgroundWorkerException(message)
                           Case Else
                              Throw New BackgroundWorkerException("Fetch Register Types failed - XML format error")
                        End Select
                     End If
                  End If
               End If
            Else
               Throw New BackgroundWorkerException("Fetching Register Types from FreeREG failed - not logged on")
            End If

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

   End Sub

#End Region

#Region "Get Counties Background Thread"

   Private Sub backgroundCounties_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundCounties.DoWork
      Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
      GetCounties(worker, e)
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
         MessageBox.Show(e.Result, "Get Counties", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Private Sub GetCounties(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs)

      Using webClient As New CookieAwareWebClient()
         Try
            webClient.SetTimeout(30000)
            For Each cookie In _settings.Cookies
               webClient.AddCookie(uri, New Cookie(cookie.Name, cookie.Value))
            Next

            Dim addrRequest As String = _settings.BaseUrl + "/transreg_counties/list.xml"
            Dim contents As String = webClient.DownloadString(addrRequest)

            Dim hdr = webClient.ResponseHeaders("Set-Cookie")
            _settings.Cookies.Add(webClient.GetAllCookiesFromHeader(hdr, _settings.BaseUrl))

            If contents.StartsWith("<CountiesTable>") Then
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

               _tables.Counties.Clear()
               For Each row As DataRow In ds.Tables("County").Rows
                  _tables.Counties.AddCountiesRow(row("ChapmanCode"), row("Description"), row("Notes"))
               Next
               _tables.Counties.AcceptChanges()
               _FileIsChanged = True
               e.Result = My.Resources.msgCountiesRefreshed
            ElseIf contents.StartsWith("<?xml version=""1.0"" encoding=""UTF-8""?>") Then
               Dim xmlDoc As XmlDocument = New XmlDocument()
               xmlDoc.LoadXml(contents)
               Dim root As XmlElement = xmlDoc.DocumentElement()
               If root Is Nothing Then
                  ' No root element
                  Throw New BackgroundWorkerException("Getting Counties from FreeREG failed - Missing root element")
               Else
                  If String.Compare(root.Name, "list", True) = 0 Then
                     Dim result As XmlElement = xmlDoc.SelectSingleNode("/list/result")
                     If result Is Nothing Then
                        ' Missing 'result' node
                        Throw New BackgroundWorkerException("Getting Counties from FreeREG failed - Missing result node")
                     Else
                        Select Case result.FirstChild.Value
                           Case "success"
                           Case "failure"
                              Dim message = xmlDoc.SelectSingleNode("/list/message").FirstChild.Value
                              '  <message>You are not authorised to use these facilities</message>
                              Throw New BackgroundWorkerException(message)
                           Case Else
                              Throw New BackgroundWorkerException("Getting Counties from FreeREG failed - XML format error")
                        End Select
                     End If
                  End If
               End If
            Else
               Throw New BackgroundWorkerException("Getting Counties from FreeREG failed - not logged on")
            End If

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
   End Sub

#End Region

#Region "Get Places Background Thread"

   Private Sub backgroundPlaces_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundPlaces.DoWork
      Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
      GetPlaces(e.Argument, worker, e)
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
         MessageBox.Show(e.Result, "Get Places", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Private Sub GetPlaces(ByVal selectedCounty As FreeregTables.CountiesRow, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs)

      Using webClient As New CookieAwareWebClient()
         Try
            webClient.SetTimeout(30000)
            For Each cookie In _settings.Cookies
               webClient.AddCookie(uri, New Cookie(cookie.Name, cookie.Value))
            Next

            Dim addrRequest As String = _settings.BaseUrl + "/transreg_places/list.xml"
            Dim query_data = New NameValueCollection()
            query_data.Add("county", selectedCounty.ChapmanCode)
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
                  If Not ds.Tables("Place") Is Nothing Then
                     If ds.Tables("Place").Rows.Count > 0 Then

                        ' Get a list of all the Place records for the selected County and delete then
                        Dim places = (From place As FreeregTables.PlacesRow In _tables.Places _
                                     Where place.ChapmanCode = selectedCounty.ChapmanCode _
                                     Select place).ToList
                        For Each place In places
                           _tables.Places.RemovePlacesRow(place)
                        Next

                        ' Now, add all the incoming Places to the table
                        For Each row As DataRow In ds.Tables("Place").Rows
                           _tables.Places.AddPlacesRow(row.Item("PlaceName"), selectedCounty, row.Item("Country"), row.Item("CountyName"), row.Item("Notes"))
                        Next

                        _tables.Places.AcceptChanges()
                        _FileIsChanged = True
                        e.Result = String.Format(My.Resources.msgPlacesUpdated, selectedCounty.ChapmanCode)
                     Else
                        e.Result = String.Format("No places found for {0}", selectedCounty)
                     End If
                  Else
                     e.Result = String.Format("No places found for {0}", selectedCounty)
                  End If
               ElseIf contents.StartsWith("<?xml version=""1.0"" encoding=""UTF-8""?>") Then
                  Dim xmlDoc As XmlDocument = New XmlDocument()
                  xmlDoc.LoadXml(contents)
                  Dim root As XmlElement = xmlDoc.DocumentElement()
                  If root Is Nothing Then
                     ' No root element
                     Throw New BackgroundWorkerException("Getting Places from FreeREG failed - Missing root element")
                  Else
                     If String.Compare(root.Name, "list", True) = 0 Then
                        Dim result As XmlElement = xmlDoc.SelectSingleNode("/list/result")
                        If result Is Nothing Then
                           ' Missing 'result' node
                           Throw New BackgroundWorkerException("Getting Places from FreeREG failed - Missing result node")
                        Else
                           Select Case result.FirstChild.Value
                              Case "success"
                              Case "failure"
                                 Dim message = xmlDoc.SelectSingleNode("/list/message").FirstChild.Value
                                 '  <message>You are not authorised to use these facilities</message>
                                 Throw New BackgroundWorkerException(message)
                              Case Else
                                 Throw New BackgroundWorkerException("Getting Places from FreeREG failed - XML format error")
                           End Select
                        End If
                     End If
                  End If
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

   End Sub

#End Region

#Region "Get Churches Background Thread"

   Private Sub backgroundChurches_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundChurches.DoWork
      Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
      GetChurches(e.Argument, worker, e)
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
         MessageBox.Show(e.Result, "Get Churches", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Private Sub GetChurches(ByVal params As paramChurches, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs)

      Using webClient As New CookieAwareWebClient()
         Try
            webClient.SetTimeout(30000)
            For Each cookie In _settings.Cookies
               webClient.AddCookie(uri, New Cookie(cookie.Name, cookie.Value))
            Next

            Dim addrRequest As String = _settings.BaseUrl + "/transreg_churches/list.xml"
            Dim query_data = New NameValueCollection()
            query_data.Add("county", params.County.ChapmanCode)
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
                     If ds.Tables("Church").Rows.Count > 0 Then
                        Try
                           For Each rowIncoming As DataRow In ds.Tables("Church").Rows
                              Dim newNotes As String = rowIncoming.Item("Notes").ToString.Replace(vbCrLf, " ")
                              Dim newFileCode As String = String.Empty
#If USE_FILECODES Then
                           Dim reg As New Regex("FILE: (?<FileCode>\w{3,8})", RegexOptions.IgnoreCase)
                           Dim mat As Match = reg.Match(newNotes)
                           If mat.Success Then
                              If mat.Groups("FileCode").Success Then
                                 Dim code = mat.Groups("FileCode").Value.Trim.ToUpper
                                 If code.Length = 8 Then
                                    newFileCode = mat.Groups("FileCode").Value
                                 Else
                                    Beep()
                                 End If
                              Else
                                 Beep()
                              End If
                           End If
#End If

                              Dim rowExisting As FreeregTables.ChurchesRow = _tables.Churches.FindByChurchNameChapmanCodePlaceName(rowIncoming.Item("ChurchName"), params.County.ChapmanCode, params.Place)
                              If rowExisting Is Nothing Then
                                 _tables.Churches.AddChurchesRow(rowIncoming.Item("ChurchName"), params.County, params.Place, newFileCode, rowIncoming.Item("Location"), rowIncoming.Item("Denomination"), rowIncoming.Item("Website"), rowIncoming.Item("LastAmended"), newNotes)
                              Else
                                 With rowExisting
                                    .ChapmanCode = params.County.ChapmanCode
                                    .PlaceName = params.Place
                                    .ChurchName = rowIncoming.Item("ChurchName")
                                    .Location = rowIncoming.Item("Location")
                                    .Denomination = rowIncoming.Item("Denomination")
                                    .Website = rowIncoming.Item("Website")
                                    .LastAmended = rowIncoming.Item("LastAmended")
                                    .Notes = newNotes
                                 End With
                              End If
                           Next

                        Catch ex As Exception

                        End Try

                        ' Get a list of all the unchanged Church records for the selected County and Place
                        ' These should be those records that are no longer present on FreeREG and can be deleted
                        Dim churches = From church As FreeregTables.ChurchesRow In _tables.Churches _
                                     Where church.ChapmanCode = params.County.ChapmanCode And church.PlaceName = params.Place And church.RowState = DataRowState.Unchanged _
                                     Select church
                        For Each church In churches
                           _tables.Churches.RemoveChurchesRow(church)
                        Next

                        _tables.Churches.AcceptChanges()
                        _FileIsChanged = True
                        e.Result = String.Format(My.Resources.msgChurchesUpdated, params.County.ChapmanCode, params.Place)
                     Else
                        e.Result = String.Format("No Churches found for {1} in {0}", params.County, params.Place)
                     End If
                  Else
                     e.Result = String.Format("No Churches found for {1} in {0}", params.County, params.Place)
                  End If
               ElseIf contents.StartsWith("<?xml version=""1.0"" encoding=""UTF-8""?>") Then
                  Dim xmlDoc As XmlDocument = New XmlDocument()
                  xmlDoc.LoadXml(contents)
                  Dim root As XmlElement = xmlDoc.DocumentElement()
                  If root Is Nothing Then
                     ' No root element
                     Throw New BackgroundWorkerException("Getting Churches from FreeREG failed - Missing root element")
                  Else
                     If String.Compare(root.Name, "list", True) = 0 Then
                        Dim result As XmlElement = xmlDoc.SelectSingleNode("/list/result")
                        If result Is Nothing Then
                           ' Missing 'result' node
                           Throw New BackgroundWorkerException("Getting Churches from FreeREG failed - Missing result node")
                        Else
                           Select Case result.FirstChild.Value
                              Case "success"
                              Case "failure"
                                 Dim message = xmlDoc.SelectSingleNode("/list/message").FirstChild.Value
                                 '  <message>You are not authorised to use these facilities</message>
                                 Throw New BackgroundWorkerException(message)
                              Case Else
                                 Throw New BackgroundWorkerException("Getting Churches from FreeREG failed - XML format error")
                           End Select
                        End If
                     End If
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
   End Sub

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


   'Public Class FilterPlacesByCounty
   '   Implements IModelFilter

   '   Private m_Chapmancode As String

   '   Sub New(ByVal ChapmanCode As String)
   '      m_Chapmancode = ChapmanCode
   '   End Sub

   '   Public Function Filter(ByVal modelObject As Object) As Boolean Implements BrightIdeasSoftware.IModelFilter.Filter
   '      Dim row As FreeregTables.PlacesRow = CType(modelObject.Row, FreeregTables.PlacesRow)
   '      Return row.ChapmanCode = m_Chapmancode
   '   End Function
   'End Class

   'Public Class FilterChurchesByCountyAndPlace
   '   Implements IModelFilter

   '   Private m_Chapmancode As String
   '   Public Property ChapmanCode() As String
   '      Get
   '         Return m_Chapmancode
   '      End Get
   '      Set(ByVal value As String)
   '         m_Chapmancode = value
   '      End Set
   '   End Property

   '   Private m_place As String
   '   Public Property PlaceName() As String
   '      Get
   '         Return m_place
   '      End Get
   '      Set(ByVal value As String)
   '         m_place = value
   '      End Set
   '   End Property

   '   Public Function Filter(ByVal modelObject As Object) As Boolean Implements BrightIdeasSoftware.IModelFilter.Filter
   '      Dim row As FreeregTables.ChurchesRow = CType(modelObject.Row, FreeregTables.ChurchesRow)
   '      Return row.ChapmanCode = m_Chapmancode AndAlso row.PlaceName = m_place
   '   End Function
   'End Class

End Class