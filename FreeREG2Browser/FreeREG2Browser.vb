'	$Date: 2016-04-13 10:34:32 +0200 (Wed, 13 Apr 2016) $
'	$Rev: 542 $
'	$Id: FreeREG2Browser.vb 542 2016-04-13 08:34:32Z Mikefry $
'
'	WinFreeReg
'

Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Net
Imports HtmlAgilityPack
Imports System.Collections.Specialized
Imports System.Runtime.InteropServices
Imports System.Configuration
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Reflection
Imports BrightIdeasSoftware
Imports System.Drawing
Imports System.Globalization

Public Class FreeREG2Browser
	Inherits System.Windows.Forms.Form

	Friend WithEvents miLogout As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miLogin As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents miFreeREG As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents BrowserStatusStrip As System.Windows.Forms.StatusStrip
	Friend WithEvents labelStatus As System.Windows.Forms.ToolStripStatusLabel
	Friend WithEvents BrowserMenuStrip As System.Windows.Forms.MenuStrip
	Friend WithEvents backgroundLogon As System.ComponentModel.BackgroundWorker
	Friend WithEvents backgroundLogout As System.ComponentModel.BackgroundWorker
	Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents miUserProfile As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents miExit As System.Windows.Forms.ToolStripMenuItem

	Enum ProgramState
		Idle
		LoggedOn
		UserAuthenticated
	End Enum

	Private nameMachineConfig As String = RuntimeEnvironment.GetRuntimeDirectory() + "CONFIG\machine.config"
	Private nameAppConfig As String = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile
   Private AppDataLocalFolder = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName)
   Private pathRoamingAppData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
	Private pathUserConfig As String = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath()

	Private pgmState As ProgramState = ProgramState.Idle
	Private authenticity_token As String = ""
	Private utf8_token As String = ""
	Private UserDataSet As UserDetails = New UserDetails()
	Public TablesDataSet As FreeregTables = New FreeregTables()
	Public LookUpsDataSet As New LookupTables()
	Public ErrorMessagesDataSet As New ErrorMessages()

   Public ErrorMessagesFileName As String = Path.Combine(AppDataLocalFolder, "ErrorMessages.xml")
   Public SettingsFileName As String = Path.Combine(AppDataLocalFolder, "FreeRegBrowserSetttings.dat")
   Public TranscriberProfileFile As String = Path.Combine(AppDataLocalFolder, "transcriber.xml")
   Public FreeregTablesFile As String = Path.Combine(AppDataLocalFolder, "FreeREGTables.xml")
   Public LookupTablesFile As String = Path.Combine(AppDataLocalFolder, "winfreereg.tables")

	Friend WithEvents bnavShowData As System.Windows.Forms.BindingNavigator
	Private components As System.ComponentModel.IContainer
	Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
	Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
	Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents bsrcLocalFiles As System.Windows.Forms.BindingSource
	Friend WithEvents dlvLocalFiles As BrightIdeasSoftware.DataListView
	Friend WithEvents backgroundBatches As System.ComponentModel.BackgroundWorker
	Friend WithEvents panelUploadedFiles As System.Windows.Forms.Panel
	Friend WithEvents BatchBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents BatchesDataSet As WinFreeReg.Batches
   Friend WithEvents btnViewContents As System.Windows.Forms.Button
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents btnDeleteFile As System.Windows.Forms.Button
   Friend WithEvents btnUploadFile As System.Windows.Forms.Button
   Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
   Friend WithEvents btnReplaceFile As System.Windows.Forms.Button
   Friend WithEvents labFilename As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents IDTextBox As System.Windows.Forms.TextBox
   Friend WithEvents CountyNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents PlaceNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents ChurchNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents RegisterTypeTextBox As System.Windows.Forms.TextBox
   Friend WithEvents RecordTypeTextBox As System.Windows.Forms.TextBox
   Friend WithEvents RecordsTextBox As System.Windows.Forms.TextBox
   Friend WithEvents DateMinTextBox As System.Windows.Forms.TextBox
   Friend WithEvents DateMaxTextBox As System.Windows.Forms.TextBox
   Friend WithEvents DateRangeTextBox As System.Windows.Forms.TextBox
   Friend WithEvents UserIdTextBox As System.Windows.Forms.TextBox
   Friend WithEvents UserIdLowerCaseTextBox As System.Windows.Forms.TextBox
   Friend WithEvents FileNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents TranscriberNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents TranscriberEmailTextBox As System.Windows.Forms.TextBox
   Friend WithEvents TranscriberSyndicateTextBox As System.Windows.Forms.TextBox
   Friend WithEvents CreditEmailTextBox As System.Windows.Forms.TextBox
   Friend WithEvents CreditNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents FirstCommentTextBox As System.Windows.Forms.TextBox
   Friend WithEvents SecondCommentTextBox As System.Windows.Forms.TextBox
   Friend WithEvents TranscriptionDateTextBox As System.Windows.Forms.TextBox
   Friend WithEvents ModificationDateTextBox As System.Windows.Forms.TextBox
   Friend WithEvents UploadedDateTextBox As System.Windows.Forms.TextBox
   Friend WithEvents ErrorTextBox As System.Windows.Forms.TextBox
   Friend WithEvents DigestTextBox As System.Windows.Forms.TextBox
   Friend WithEvents LockedByTranscriberCheckBox As System.Windows.Forms.CheckBox
   Friend WithEvents LockedByCoordinatorCheckBox As System.Windows.Forms.CheckBox
   Friend WithEvents LdsTextBox As System.Windows.Forms.TextBox
   Friend WithEvents ActionTextBox As System.Windows.Forms.TextBox
   Friend WithEvents CharacterSetTextBox As System.Windows.Forms.TextBox
   Friend WithEvents AlternateRegisterNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents CsvFileTextBox As System.Windows.Forms.TextBox
   Friend WithEvents backgroundUpload As System.ComponentModel.BackgroundWorker
   Friend WithEvents backgroundReplace As System.ComponentModel.BackgroundWorker
   Friend WithEvents backgroundDelete As System.ComponentModel.BackgroundWorker
   Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
   Friend WithEvents dlvUploadedFiles As BrightIdeasSoftware.DataListView
   Friend WithEvents olvcFilename As BrightIdeasSoftware.OLVColumn
   Friend WithEvents miRefreshUser As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents cboxProcess As System.Windows.Forms.ComboBox
   Friend WithEvents FreeregTablesDataSet As WinFreeReg.FreeregTables
   Friend WithEvents miTranscriptionData As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents miFreeREG2Tables As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents miTranscriptions As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents miLocalFiles As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents miUploadedFiles As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents miUserTables As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents btnNewFile As System.Windows.Forms.Button

   Public MyAppSettings As FreeReg2BrowserSettings

   Private _myUserName As String
   Public Property UserName() As String
      Get
         Return _myUserName
      End Get
      Set(ByVal value As String)
         _myUserName = value
      End Set
   End Property

   Private _myEmailAddress As String
   Public Property EmailAddress() As String
      Get
         Return _myEmailAddress
      End Get
      Set(ByVal value As String)
         _myEmailAddress = value
      End Set
   End Property

   Private _myUserId As String
   Public Property UserId() As String
      Get
         Return _myUserId
      End Get
      Set(ByVal value As String)
         _myUserId = value
      End Set
   End Property

   Private _myPassword As String
   Public Property Password() As String
      Get
         Return _myPassword
      End Get
      Set(ByVal value As String)
         _myPassword = value
      End Set
   End Property

   Private _myUrl As String
   Public Property FreeregUrl() As String
      Get
         Return _myUrl
      End Get
      Set(ByVal value As String)
         _myUrl = value
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

   Private _myTranscriptionLibrary As String
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents miNetworkTrace As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents BrowserToolTip As System.Windows.Forms.ToolTip
   Public Property TranscriptionLibrary() As String
      Get
         Return _myTranscriptionLibrary
      End Get
      Set(ByVal value As String)
         _myTranscriptionLibrary = value
      End Set
   End Property

   Private _myNetworkTrace As Boolean
   Public Property TraceNetwork() As Boolean
      Get
         Return _myNetworkTrace
      End Get
      Set(ByVal value As Boolean)
         _myNetworkTrace = value
      End Set
   End Property

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim IDLabel As System.Windows.Forms.Label
      Dim CountyNameLabel As System.Windows.Forms.Label
      Dim PlaceNameLabel As System.Windows.Forms.Label
      Dim ChurchNameLabel As System.Windows.Forms.Label
      Dim RegisterTypeLabel As System.Windows.Forms.Label
      Dim RecordTypeLabel As System.Windows.Forms.Label
      Dim RecordsLabel As System.Windows.Forms.Label
      Dim DateMinLabel As System.Windows.Forms.Label
      Dim DateMaxLabel As System.Windows.Forms.Label
      Dim DateRangeLabel As System.Windows.Forms.Label
      Dim UserIdLabel As System.Windows.Forms.Label
      Dim UserIdLowerCaseLabel As System.Windows.Forms.Label
      Dim FileNameLabel As System.Windows.Forms.Label
      Dim TranscriberNameLabel As System.Windows.Forms.Label
      Dim TranscriberEmailLabel As System.Windows.Forms.Label
      Dim TranscriberSyndicateLabel As System.Windows.Forms.Label
      Dim CreditEmailLabel As System.Windows.Forms.Label
      Dim CreditNameLabel As System.Windows.Forms.Label
      Dim FirstCommentLabel As System.Windows.Forms.Label
      Dim SecondCommentLabel As System.Windows.Forms.Label
      Dim TranscriptionDateLabel As System.Windows.Forms.Label
      Dim ModificationDateLabel As System.Windows.Forms.Label
      Dim UploadedDateLabel As System.Windows.Forms.Label
      Dim ErrorLabel As System.Windows.Forms.Label
      Dim DigestLabel As System.Windows.Forms.Label
      Dim LdsLabel As System.Windows.Forms.Label
      Dim ActionLabel As System.Windows.Forms.Label
      Dim CharacterSetLabel As System.Windows.Forms.Label
      Dim AlternateRegisterNameLabel As System.Windows.Forms.Label
      Dim CsvFileLabel As System.Windows.Forms.Label
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FreeREG2Browser))
      Me.BrowserMenuStrip = New System.Windows.Forms.MenuStrip()
      Me.miFreeREG = New System.Windows.Forms.ToolStripMenuItem()
      Me.miLogin = New System.Windows.Forms.ToolStripMenuItem()
      Me.miLogout = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.miUserProfile = New System.Windows.Forms.ToolStripMenuItem()
      Me.miRefreshUser = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.miNetworkTrace = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.miExit = New System.Windows.Forms.ToolStripMenuItem()
      Me.miTranscriptions = New System.Windows.Forms.ToolStripMenuItem()
      Me.miLocalFiles = New System.Windows.Forms.ToolStripMenuItem()
      Me.miUploadedFiles = New System.Windows.Forms.ToolStripMenuItem()
      Me.miTranscriptionData = New System.Windows.Forms.ToolStripMenuItem()
      Me.miFreeREG2Tables = New System.Windows.Forms.ToolStripMenuItem()
      Me.miUserTables = New System.Windows.Forms.ToolStripMenuItem()
      Me.BrowserStatusStrip = New System.Windows.Forms.StatusStrip()
      Me.labelStatus = New System.Windows.Forms.ToolStripStatusLabel()
      Me.backgroundLogon = New System.ComponentModel.BackgroundWorker()
      Me.backgroundLogout = New System.ComponentModel.BackgroundWorker()
      Me.bnavShowData = New System.Windows.Forms.BindingNavigator(Me.components)
      Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
      Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
      Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.bsrcLocalFiles = New System.Windows.Forms.BindingSource(Me.components)
      Me.backgroundBatches = New System.ComponentModel.BackgroundWorker()
      Me.panelUploadedFiles = New System.Windows.Forms.Panel()
      Me.IDTextBox = New System.Windows.Forms.TextBox()
      Me.BatchBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.BatchesDataSet = New WinFreeReg.Batches()
      Me.CountyNameTextBox = New System.Windows.Forms.TextBox()
      Me.PlaceNameTextBox = New System.Windows.Forms.TextBox()
      Me.ChurchNameTextBox = New System.Windows.Forms.TextBox()
      Me.RegisterTypeTextBox = New System.Windows.Forms.TextBox()
      Me.RecordTypeTextBox = New System.Windows.Forms.TextBox()
      Me.RecordsTextBox = New System.Windows.Forms.TextBox()
      Me.DateMinTextBox = New System.Windows.Forms.TextBox()
      Me.DateMaxTextBox = New System.Windows.Forms.TextBox()
      Me.DateRangeTextBox = New System.Windows.Forms.TextBox()
      Me.UserIdTextBox = New System.Windows.Forms.TextBox()
      Me.UserIdLowerCaseTextBox = New System.Windows.Forms.TextBox()
      Me.FileNameTextBox = New System.Windows.Forms.TextBox()
      Me.TranscriberNameTextBox = New System.Windows.Forms.TextBox()
      Me.TranscriberEmailTextBox = New System.Windows.Forms.TextBox()
      Me.TranscriberSyndicateTextBox = New System.Windows.Forms.TextBox()
      Me.CreditEmailTextBox = New System.Windows.Forms.TextBox()
      Me.CreditNameTextBox = New System.Windows.Forms.TextBox()
      Me.FirstCommentTextBox = New System.Windows.Forms.TextBox()
      Me.SecondCommentTextBox = New System.Windows.Forms.TextBox()
      Me.TranscriptionDateTextBox = New System.Windows.Forms.TextBox()
      Me.ModificationDateTextBox = New System.Windows.Forms.TextBox()
      Me.UploadedDateTextBox = New System.Windows.Forms.TextBox()
      Me.ErrorTextBox = New System.Windows.Forms.TextBox()
      Me.DigestTextBox = New System.Windows.Forms.TextBox()
      Me.LockedByTranscriberCheckBox = New System.Windows.Forms.CheckBox()
      Me.LockedByCoordinatorCheckBox = New System.Windows.Forms.CheckBox()
      Me.LdsTextBox = New System.Windows.Forms.TextBox()
      Me.ActionTextBox = New System.Windows.Forms.TextBox()
      Me.CharacterSetTextBox = New System.Windows.Forms.TextBox()
      Me.AlternateRegisterNameTextBox = New System.Windows.Forms.TextBox()
      Me.CsvFileTextBox = New System.Windows.Forms.TextBox()
      Me.btnDeleteFile = New System.Windows.Forms.Button()
      Me.btnViewContents = New System.Windows.Forms.Button()
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
      Me.dlvLocalFiles = New BrightIdeasSoftware.DataListView()
      Me.btnNewFile = New System.Windows.Forms.Button()
      Me.cboxProcess = New System.Windows.Forms.ComboBox()
      Me.labFilename = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.btnUploadFile = New System.Windows.Forms.Button()
      Me.btnReplaceFile = New System.Windows.Forms.Button()
      Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
      Me.dlvUploadedFiles = New BrightIdeasSoftware.DataListView()
      Me.olvcFilename = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.backgroundUpload = New System.ComponentModel.BackgroundWorker()
      Me.backgroundReplace = New System.ComponentModel.BackgroundWorker()
      Me.backgroundDelete = New System.ComponentModel.BackgroundWorker()
      Me.FreeregTablesDataSet = New WinFreeReg.FreeregTables()
      Me.BrowserToolTip = New System.Windows.Forms.ToolTip(Me.components)
      IDLabel = New System.Windows.Forms.Label()
      CountyNameLabel = New System.Windows.Forms.Label()
      PlaceNameLabel = New System.Windows.Forms.Label()
      ChurchNameLabel = New System.Windows.Forms.Label()
      RegisterTypeLabel = New System.Windows.Forms.Label()
      RecordTypeLabel = New System.Windows.Forms.Label()
      RecordsLabel = New System.Windows.Forms.Label()
      DateMinLabel = New System.Windows.Forms.Label()
      DateMaxLabel = New System.Windows.Forms.Label()
      DateRangeLabel = New System.Windows.Forms.Label()
      UserIdLabel = New System.Windows.Forms.Label()
      UserIdLowerCaseLabel = New System.Windows.Forms.Label()
      FileNameLabel = New System.Windows.Forms.Label()
      TranscriberNameLabel = New System.Windows.Forms.Label()
      TranscriberEmailLabel = New System.Windows.Forms.Label()
      TranscriberSyndicateLabel = New System.Windows.Forms.Label()
      CreditEmailLabel = New System.Windows.Forms.Label()
      CreditNameLabel = New System.Windows.Forms.Label()
      FirstCommentLabel = New System.Windows.Forms.Label()
      SecondCommentLabel = New System.Windows.Forms.Label()
      TranscriptionDateLabel = New System.Windows.Forms.Label()
      ModificationDateLabel = New System.Windows.Forms.Label()
      UploadedDateLabel = New System.Windows.Forms.Label()
      ErrorLabel = New System.Windows.Forms.Label()
      DigestLabel = New System.Windows.Forms.Label()
      LdsLabel = New System.Windows.Forms.Label()
      ActionLabel = New System.Windows.Forms.Label()
      CharacterSetLabel = New System.Windows.Forms.Label()
      AlternateRegisterNameLabel = New System.Windows.Forms.Label()
      CsvFileLabel = New System.Windows.Forms.Label()
      Me.BrowserMenuStrip.SuspendLayout()
      Me.BrowserStatusStrip.SuspendLayout()
      CType(Me.bnavShowData, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.bnavShowData.SuspendLayout()
      CType(Me.bsrcLocalFiles, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.panelUploadedFiles.SuspendLayout()
      CType(Me.BatchBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.BatchesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.SplitContainer2.Panel1.SuspendLayout()
      Me.SplitContainer2.Panel2.SuspendLayout()
      Me.SplitContainer2.SuspendLayout()
      CType(Me.dlvLocalFiles, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SplitContainer3.Panel1.SuspendLayout()
      Me.SplitContainer3.Panel2.SuspendLayout()
      Me.SplitContainer3.SuspendLayout()
      CType(Me.dlvUploadedFiles, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.FreeregTablesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'IDLabel
      '
      IDLabel.AutoSize = True
      IDLabel.Location = New System.Drawing.Point(35, 12)
      IDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      IDLabel.Name = "IDLabel"
      IDLabel.Size = New System.Drawing.Size(24, 16)
      IDLabel.TabIndex = 65
      IDLabel.Text = "ID:"
      '
      'CountyNameLabel
      '
      CountyNameLabel.AutoSize = True
      CountyNameLabel.Location = New System.Drawing.Point(35, 44)
      CountyNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      CountyNameLabel.Name = "CountyNameLabel"
      CountyNameLabel.Size = New System.Drawing.Size(92, 16)
      CountyNameLabel.TabIndex = 67
      CountyNameLabel.Text = "County Name:"
      '
      'PlaceNameLabel
      '
      PlaceNameLabel.AutoSize = True
      PlaceNameLabel.Location = New System.Drawing.Point(35, 76)
      PlaceNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      PlaceNameLabel.Name = "PlaceNameLabel"
      PlaceNameLabel.Size = New System.Drawing.Size(86, 16)
      PlaceNameLabel.TabIndex = 69
      PlaceNameLabel.Text = "Place Name:"
      '
      'ChurchNameLabel
      '
      ChurchNameLabel.AutoSize = True
      ChurchNameLabel.Location = New System.Drawing.Point(35, 108)
      ChurchNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      ChurchNameLabel.Name = "ChurchNameLabel"
      ChurchNameLabel.Size = New System.Drawing.Size(92, 16)
      ChurchNameLabel.TabIndex = 71
      ChurchNameLabel.Text = "Church Name:"
      '
      'RegisterTypeLabel
      '
      RegisterTypeLabel.AutoSize = True
      RegisterTypeLabel.Location = New System.Drawing.Point(35, 140)
      RegisterTypeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      RegisterTypeLabel.Name = "RegisterTypeLabel"
      RegisterTypeLabel.Size = New System.Drawing.Size(97, 16)
      RegisterTypeLabel.TabIndex = 73
      RegisterTypeLabel.Text = "Register Type:"
      '
      'RecordTypeLabel
      '
      RecordTypeLabel.AutoSize = True
      RecordTypeLabel.Location = New System.Drawing.Point(35, 172)
      RecordTypeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      RecordTypeLabel.Name = "RecordTypeLabel"
      RecordTypeLabel.Size = New System.Drawing.Size(91, 16)
      RecordTypeLabel.TabIndex = 75
      RecordTypeLabel.Text = "Record Type:"
      '
      'RecordsLabel
      '
      RecordsLabel.AutoSize = True
      RecordsLabel.Location = New System.Drawing.Point(35, 204)
      RecordsLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      RecordsLabel.Name = "RecordsLabel"
      RecordsLabel.Size = New System.Drawing.Size(63, 16)
      RecordsLabel.TabIndex = 77
      RecordsLabel.Text = "Records:"
      '
      'DateMinLabel
      '
      DateMinLabel.AutoSize = True
      DateMinLabel.Location = New System.Drawing.Point(35, 236)
      DateMinLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      DateMinLabel.Name = "DateMinLabel"
      DateMinLabel.Size = New System.Drawing.Size(64, 16)
      DateMinLabel.TabIndex = 79
      DateMinLabel.Text = "Date Min:"
      '
      'DateMaxLabel
      '
      DateMaxLabel.AutoSize = True
      DateMaxLabel.Location = New System.Drawing.Point(35, 268)
      DateMaxLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      DateMaxLabel.Name = "DateMaxLabel"
      DateMaxLabel.Size = New System.Drawing.Size(68, 16)
      DateMaxLabel.TabIndex = 81
      DateMaxLabel.Text = "Date Max:"
      '
      'DateRangeLabel
      '
      DateRangeLabel.AutoSize = True
      DateRangeLabel.Location = New System.Drawing.Point(35, 300)
      DateRangeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      DateRangeLabel.Name = "DateRangeLabel"
      DateRangeLabel.Size = New System.Drawing.Size(84, 16)
      DateRangeLabel.TabIndex = 83
      DateRangeLabel.Text = "Date Range:"
      '
      'UserIdLabel
      '
      UserIdLabel.AutoSize = True
      UserIdLabel.Location = New System.Drawing.Point(35, 332)
      UserIdLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      UserIdLabel.Name = "UserIdLabel"
      UserIdLabel.Size = New System.Drawing.Size(54, 16)
      UserIdLabel.TabIndex = 85
      UserIdLabel.Text = "User Id:"
      '
      'UserIdLowerCaseLabel
      '
      UserIdLowerCaseLabel.AutoSize = True
      UserIdLowerCaseLabel.Location = New System.Drawing.Point(35, 364)
      UserIdLowerCaseLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      UserIdLowerCaseLabel.Name = "UserIdLowerCaseLabel"
      UserIdLowerCaseLabel.Size = New System.Drawing.Size(128, 16)
      UserIdLowerCaseLabel.TabIndex = 87
      UserIdLowerCaseLabel.Text = "User Id Lower Case:"
      '
      'FileNameLabel
      '
      FileNameLabel.AutoSize = True
      FileNameLabel.Location = New System.Drawing.Point(35, 396)
      FileNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      FileNameLabel.Name = "FileNameLabel"
      FileNameLabel.Size = New System.Drawing.Size(73, 16)
      FileNameLabel.TabIndex = 89
      FileNameLabel.Text = "File Name:"
      '
      'TranscriberNameLabel
      '
      TranscriberNameLabel.AutoSize = True
      TranscriberNameLabel.Location = New System.Drawing.Point(35, 428)
      TranscriberNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      TranscriberNameLabel.Name = "TranscriberNameLabel"
      TranscriberNameLabel.Size = New System.Drawing.Size(120, 16)
      TranscriberNameLabel.TabIndex = 91
      TranscriberNameLabel.Text = "Transcriber Name:"
      '
      'TranscriberEmailLabel
      '
      TranscriberEmailLabel.AutoSize = True
      TranscriberEmailLabel.Location = New System.Drawing.Point(35, 460)
      TranscriberEmailLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      TranscriberEmailLabel.Name = "TranscriberEmailLabel"
      TranscriberEmailLabel.Size = New System.Drawing.Size(117, 16)
      TranscriberEmailLabel.TabIndex = 93
      TranscriberEmailLabel.Text = "Transcriber Email:"
      '
      'TranscriberSyndicateLabel
      '
      TranscriberSyndicateLabel.AutoSize = True
      TranscriberSyndicateLabel.Location = New System.Drawing.Point(35, 492)
      TranscriberSyndicateLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      TranscriberSyndicateLabel.Name = "TranscriberSyndicateLabel"
      TranscriberSyndicateLabel.Size = New System.Drawing.Size(143, 16)
      TranscriberSyndicateLabel.TabIndex = 95
      TranscriberSyndicateLabel.Text = "Transcriber Syndicate:"
      '
      'CreditEmailLabel
      '
      CreditEmailLabel.AutoSize = True
      CreditEmailLabel.Location = New System.Drawing.Point(509, 12)
      CreditEmailLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      CreditEmailLabel.Name = "CreditEmailLabel"
      CreditEmailLabel.Size = New System.Drawing.Size(83, 16)
      CreditEmailLabel.TabIndex = 97
      CreditEmailLabel.Text = "Credit Email:"
      '
      'CreditNameLabel
      '
      CreditNameLabel.AutoSize = True
      CreditNameLabel.Location = New System.Drawing.Point(509, 44)
      CreditNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      CreditNameLabel.Name = "CreditNameLabel"
      CreditNameLabel.Size = New System.Drawing.Size(86, 16)
      CreditNameLabel.TabIndex = 99
      CreditNameLabel.Text = "Credit Name:"
      '
      'FirstCommentLabel
      '
      FirstCommentLabel.AutoSize = True
      FirstCommentLabel.Location = New System.Drawing.Point(509, 76)
      FirstCommentLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      FirstCommentLabel.Name = "FirstCommentLabel"
      FirstCommentLabel.Size = New System.Drawing.Size(96, 16)
      FirstCommentLabel.TabIndex = 101
      FirstCommentLabel.Text = "First Comment:"
      '
      'SecondCommentLabel
      '
      SecondCommentLabel.AutoSize = True
      SecondCommentLabel.Location = New System.Drawing.Point(509, 108)
      SecondCommentLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      SecondCommentLabel.Name = "SecondCommentLabel"
      SecondCommentLabel.Size = New System.Drawing.Size(118, 16)
      SecondCommentLabel.TabIndex = 103
      SecondCommentLabel.Text = "Second Comment:"
      '
      'TranscriptionDateLabel
      '
      TranscriptionDateLabel.AutoSize = True
      TranscriptionDateLabel.Location = New System.Drawing.Point(509, 140)
      TranscriptionDateLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      TranscriptionDateLabel.Name = "TranscriptionDateLabel"
      TranscriptionDateLabel.Size = New System.Drawing.Size(121, 16)
      TranscriptionDateLabel.TabIndex = 105
      TranscriptionDateLabel.Text = "Transcription Date:"
      '
      'ModificationDateLabel
      '
      ModificationDateLabel.AutoSize = True
      ModificationDateLabel.Location = New System.Drawing.Point(509, 172)
      ModificationDateLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      ModificationDateLabel.Name = "ModificationDateLabel"
      ModificationDateLabel.Size = New System.Drawing.Size(115, 16)
      ModificationDateLabel.TabIndex = 107
      ModificationDateLabel.Text = "Modification Date:"
      '
      'UploadedDateLabel
      '
      UploadedDateLabel.AutoSize = True
      UploadedDateLabel.Location = New System.Drawing.Point(509, 204)
      UploadedDateLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      UploadedDateLabel.Name = "UploadedDateLabel"
      UploadedDateLabel.Size = New System.Drawing.Size(104, 16)
      UploadedDateLabel.TabIndex = 109
      UploadedDateLabel.Text = "Uploaded Date:"
      '
      'ErrorLabel
      '
      ErrorLabel.AutoSize = True
      ErrorLabel.Location = New System.Drawing.Point(509, 236)
      ErrorLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      ErrorLabel.Name = "ErrorLabel"
      ErrorLabel.Size = New System.Drawing.Size(40, 16)
      ErrorLabel.TabIndex = 111
      ErrorLabel.Text = "Error:"
      '
      'DigestLabel
      '
      DigestLabel.AutoSize = True
      DigestLabel.Location = New System.Drawing.Point(509, 268)
      DigestLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      DigestLabel.Name = "DigestLabel"
      DigestLabel.Size = New System.Drawing.Size(50, 16)
      DigestLabel.TabIndex = 113
      DigestLabel.Text = "Digest:"
      '
      'LdsLabel
      '
      LdsLabel.AutoSize = True
      LdsLabel.Location = New System.Drawing.Point(509, 374)
      LdsLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      LdsLabel.Name = "LdsLabel"
      LdsLabel.Size = New System.Drawing.Size(29, 16)
      LdsLabel.TabIndex = 119
      LdsLabel.Text = "lds:"
      '
      'ActionLabel
      '
      ActionLabel.AutoSize = True
      ActionLabel.Location = New System.Drawing.Point(509, 406)
      ActionLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      ActionLabel.Name = "ActionLabel"
      ActionLabel.Size = New System.Drawing.Size(48, 16)
      ActionLabel.TabIndex = 121
      ActionLabel.Text = "Action:"
      '
      'CharacterSetLabel
      '
      CharacterSetLabel.AutoSize = True
      CharacterSetLabel.Location = New System.Drawing.Point(509, 438)
      CharacterSetLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      CharacterSetLabel.Name = "CharacterSetLabel"
      CharacterSetLabel.Size = New System.Drawing.Size(92, 16)
      CharacterSetLabel.TabIndex = 123
      CharacterSetLabel.Text = "Character Set:"
      '
      'AlternateRegisterNameLabel
      '
      AlternateRegisterNameLabel.AutoSize = True
      AlternateRegisterNameLabel.Location = New System.Drawing.Point(509, 470)
      AlternateRegisterNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      AlternateRegisterNameLabel.Name = "AlternateRegisterNameLabel"
      AlternateRegisterNameLabel.Size = New System.Drawing.Size(158, 16)
      AlternateRegisterNameLabel.TabIndex = 125
      AlternateRegisterNameLabel.Text = "Alternate Register Name:"
      '
      'CsvFileLabel
      '
      CsvFileLabel.AutoSize = True
      CsvFileLabel.Location = New System.Drawing.Point(509, 502)
      CsvFileLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      CsvFileLabel.Name = "CsvFileLabel"
      CsvFileLabel.Size = New System.Drawing.Size(59, 16)
      CsvFileLabel.TabIndex = 127
      CsvFileLabel.Text = "Csv File:"
      '
      'BrowserMenuStrip
      '
      Me.BrowserMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miFreeREG, Me.miTranscriptions, Me.miTranscriptionData})
      Me.BrowserMenuStrip.Location = New System.Drawing.Point(0, 0)
      Me.BrowserMenuStrip.Name = "BrowserMenuStrip"
      Me.BrowserMenuStrip.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
      Me.BrowserMenuStrip.Size = New System.Drawing.Size(1229, 24)
      Me.BrowserMenuStrip.TabIndex = 0
      Me.BrowserMenuStrip.Text = "MenuStrip1"
      '
      'miFreeREG
      '
      Me.miFreeREG.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miLogin, Me.miLogout, Me.ToolStripSeparator1, Me.miUserProfile, Me.miRefreshUser, Me.ToolStripSeparator2, Me.miNetworkTrace, Me.ToolStripSeparator3, Me.miExit})
      Me.miFreeREG.Name = "miFreeREG"
      Me.miFreeREG.Size = New System.Drawing.Size(62, 20)
      Me.miFreeREG.Text = "FreeREG"
      '
      'miLogin
      '
      Me.miLogin.Name = "miLogin"
      Me.miLogin.Size = New System.Drawing.Size(155, 22)
      Me.miLogin.Text = "Log on ..."
      '
      'miLogout
      '
      Me.miLogout.Name = "miLogout"
      Me.miLogout.Size = New System.Drawing.Size(155, 22)
      Me.miLogout.Text = "Log off"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(152, 6)
      '
      'miUserProfile
      '
      Me.miUserProfile.Name = "miUserProfile"
      Me.miUserProfile.Size = New System.Drawing.Size(155, 22)
      Me.miUserProfile.Text = "User Profile ..."
      '
      'miRefreshUser
      '
      Me.miRefreshUser.Enabled = False
      Me.miRefreshUser.Name = "miRefreshUser"
      Me.miRefreshUser.Size = New System.Drawing.Size(155, 22)
      Me.miRefreshUser.Text = "Refresh user"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(152, 6)
      '
      'miNetworkTrace
      '
      Me.miNetworkTrace.CheckOnClick = True
      Me.miNetworkTrace.Name = "miNetworkTrace"
      Me.miNetworkTrace.Size = New System.Drawing.Size(155, 22)
      Me.miNetworkTrace.Text = "Network Trace?"
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(152, 6)
      '
      'miExit
      '
      Me.miExit.Name = "miExit"
      Me.miExit.Size = New System.Drawing.Size(155, 22)
      Me.miExit.Text = "Exit"
      '
      'miTranscriptions
      '
      Me.miTranscriptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miLocalFiles, Me.miUploadedFiles})
      Me.miTranscriptions.Name = "miTranscriptions"
      Me.miTranscriptions.Size = New System.Drawing.Size(93, 20)
      Me.miTranscriptions.Text = "Transcriptions"
      '
      'miLocalFiles
      '
      Me.miLocalFiles.Name = "miLocalFiles"
      Me.miLocalFiles.Size = New System.Drawing.Size(161, 22)
      Me.miLocalFiles.Text = "Local files ..."
      '
      'miUploadedFiles
      '
      Me.miUploadedFiles.Name = "miUploadedFiles"
      Me.miUploadedFiles.Size = New System.Drawing.Size(161, 22)
      Me.miUploadedFiles.Text = "Uploaded files ..."
      '
      'miTranscriptionData
      '
      Me.miTranscriptionData.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miFreeREG2Tables, Me.miUserTables})
      Me.miTranscriptionData.Name = "miTranscriptionData"
      Me.miTranscriptionData.Size = New System.Drawing.Size(115, 20)
      Me.miTranscriptionData.Text = "Transcription Data"
      '
      'miFreeREG2Tables
      '
      Me.miFreeREG2Tables.Name = "miFreeREG2Tables"
      Me.miFreeREG2Tables.Size = New System.Drawing.Size(159, 22)
      Me.miFreeREG2Tables.Text = "FreeREG2 Tables"
      '
      'miUserTables
      '
      Me.miUserTables.Name = "miUserTables"
      Me.miUserTables.Size = New System.Drawing.Size(159, 22)
      Me.miUserTables.Text = "User Tables"
      '
      'BrowserStatusStrip
      '
      Me.BrowserStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelStatus})
      Me.BrowserStatusStrip.Location = New System.Drawing.Point(0, 644)
      Me.BrowserStatusStrip.Name = "BrowserStatusStrip"
      Me.BrowserStatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
      Me.BrowserStatusStrip.Size = New System.Drawing.Size(1229, 22)
      Me.BrowserStatusStrip.TabIndex = 1
      Me.BrowserStatusStrip.Text = "StatusStrip1"
      '
      'labelStatus
      '
      Me.labelStatus.Name = "labelStatus"
      Me.labelStatus.Size = New System.Drawing.Size(0, 17)
      '
      'backgroundLogon
      '
      Me.backgroundLogon.WorkerReportsProgress = True
      '
      'backgroundLogout
      '
      Me.backgroundLogout.WorkerReportsProgress = True
      '
      'bnavShowData
      '
      Me.bnavShowData.AddNewItem = Me.BindingNavigatorAddNewItem
      Me.bnavShowData.CountItem = Me.BindingNavigatorCountItem
      Me.bnavShowData.DeleteItem = Me.BindingNavigatorDeleteItem
      Me.bnavShowData.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
      Me.bnavShowData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem})
      Me.bnavShowData.Location = New System.Drawing.Point(0, 0)
      Me.bnavShowData.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.bnavShowData.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.bnavShowData.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.bnavShowData.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.bnavShowData.Name = "bnavShowData"
      Me.bnavShowData.PositionItem = Me.BindingNavigatorPositionItem
      Me.bnavShowData.Size = New System.Drawing.Size(1229, 31)
      Me.bnavShowData.TabIndex = 3
      Me.bnavShowData.Text = "BindingNavigator1"
      Me.bnavShowData.Visible = False
      '
      'BindingNavigatorAddNewItem
      '
      Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
      Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
      Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 28)
      Me.BindingNavigatorAddNewItem.Text = "Add new"
      Me.BindingNavigatorAddNewItem.Visible = False
      '
      'BindingNavigatorCountItem
      '
      Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
      Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 28)
      Me.BindingNavigatorCountItem.Text = "of {0}"
      Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
      '
      'BindingNavigatorDeleteItem
      '
      Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
      Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
      Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 28)
      Me.BindingNavigatorDeleteItem.Text = "Delete"
      Me.BindingNavigatorDeleteItem.Visible = False
      '
      'BindingNavigatorMoveFirstItem
      '
      Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
      Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
      Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 28)
      Me.BindingNavigatorMoveFirstItem.Text = "Move first"
      '
      'BindingNavigatorMovePreviousItem
      '
      Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
      Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
      Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 28)
      Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
      '
      'BindingNavigatorSeparator
      '
      Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
      Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 31)
      '
      'BindingNavigatorPositionItem
      '
      Me.BindingNavigatorPositionItem.AccessibleName = "Position"
      Me.BindingNavigatorPositionItem.AutoSize = False
      Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
      Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(85, 23)
      Me.BindingNavigatorPositionItem.Text = "0"
      Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
      '
      'BindingNavigatorSeparator1
      '
      Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
      Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 31)
      '
      'BindingNavigatorMoveNextItem
      '
      Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
      Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
      Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 28)
      Me.BindingNavigatorMoveNextItem.Text = "Move next"
      '
      'BindingNavigatorMoveLastItem
      '
      Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
      Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
      Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 28)
      Me.BindingNavigatorMoveLastItem.Text = "Move last"
      '
      'BindingNavigatorSeparator2
      '
      Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
      Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 31)
      '
      'backgroundBatches
      '
      Me.backgroundBatches.WorkerReportsProgress = True
      '
      'panelUploadedFiles
      '
      Me.panelUploadedFiles.AutoScroll = True
      Me.panelUploadedFiles.Controls.Add(IDLabel)
      Me.panelUploadedFiles.Controls.Add(Me.IDTextBox)
      Me.panelUploadedFiles.Controls.Add(CountyNameLabel)
      Me.panelUploadedFiles.Controls.Add(Me.CountyNameTextBox)
      Me.panelUploadedFiles.Controls.Add(PlaceNameLabel)
      Me.panelUploadedFiles.Controls.Add(Me.PlaceNameTextBox)
      Me.panelUploadedFiles.Controls.Add(ChurchNameLabel)
      Me.panelUploadedFiles.Controls.Add(Me.ChurchNameTextBox)
      Me.panelUploadedFiles.Controls.Add(RegisterTypeLabel)
      Me.panelUploadedFiles.Controls.Add(Me.RegisterTypeTextBox)
      Me.panelUploadedFiles.Controls.Add(RecordTypeLabel)
      Me.panelUploadedFiles.Controls.Add(Me.RecordTypeTextBox)
      Me.panelUploadedFiles.Controls.Add(RecordsLabel)
      Me.panelUploadedFiles.Controls.Add(Me.RecordsTextBox)
      Me.panelUploadedFiles.Controls.Add(DateMinLabel)
      Me.panelUploadedFiles.Controls.Add(Me.DateMinTextBox)
      Me.panelUploadedFiles.Controls.Add(DateMaxLabel)
      Me.panelUploadedFiles.Controls.Add(Me.DateMaxTextBox)
      Me.panelUploadedFiles.Controls.Add(DateRangeLabel)
      Me.panelUploadedFiles.Controls.Add(Me.DateRangeTextBox)
      Me.panelUploadedFiles.Controls.Add(UserIdLabel)
      Me.panelUploadedFiles.Controls.Add(Me.UserIdTextBox)
      Me.panelUploadedFiles.Controls.Add(UserIdLowerCaseLabel)
      Me.panelUploadedFiles.Controls.Add(Me.UserIdLowerCaseTextBox)
      Me.panelUploadedFiles.Controls.Add(FileNameLabel)
      Me.panelUploadedFiles.Controls.Add(Me.FileNameTextBox)
      Me.panelUploadedFiles.Controls.Add(TranscriberNameLabel)
      Me.panelUploadedFiles.Controls.Add(Me.TranscriberNameTextBox)
      Me.panelUploadedFiles.Controls.Add(TranscriberEmailLabel)
      Me.panelUploadedFiles.Controls.Add(Me.TranscriberEmailTextBox)
      Me.panelUploadedFiles.Controls.Add(TranscriberSyndicateLabel)
      Me.panelUploadedFiles.Controls.Add(Me.TranscriberSyndicateTextBox)
      Me.panelUploadedFiles.Controls.Add(CreditEmailLabel)
      Me.panelUploadedFiles.Controls.Add(Me.CreditEmailTextBox)
      Me.panelUploadedFiles.Controls.Add(CreditNameLabel)
      Me.panelUploadedFiles.Controls.Add(Me.CreditNameTextBox)
      Me.panelUploadedFiles.Controls.Add(FirstCommentLabel)
      Me.panelUploadedFiles.Controls.Add(Me.FirstCommentTextBox)
      Me.panelUploadedFiles.Controls.Add(SecondCommentLabel)
      Me.panelUploadedFiles.Controls.Add(Me.SecondCommentTextBox)
      Me.panelUploadedFiles.Controls.Add(TranscriptionDateLabel)
      Me.panelUploadedFiles.Controls.Add(Me.TranscriptionDateTextBox)
      Me.panelUploadedFiles.Controls.Add(ModificationDateLabel)
      Me.panelUploadedFiles.Controls.Add(Me.ModificationDateTextBox)
      Me.panelUploadedFiles.Controls.Add(UploadedDateLabel)
      Me.panelUploadedFiles.Controls.Add(Me.UploadedDateTextBox)
      Me.panelUploadedFiles.Controls.Add(ErrorLabel)
      Me.panelUploadedFiles.Controls.Add(Me.ErrorTextBox)
      Me.panelUploadedFiles.Controls.Add(DigestLabel)
      Me.panelUploadedFiles.Controls.Add(Me.DigestTextBox)
      Me.panelUploadedFiles.Controls.Add(Me.LockedByTranscriberCheckBox)
      Me.panelUploadedFiles.Controls.Add(Me.LockedByCoordinatorCheckBox)
      Me.panelUploadedFiles.Controls.Add(LdsLabel)
      Me.panelUploadedFiles.Controls.Add(Me.LdsTextBox)
      Me.panelUploadedFiles.Controls.Add(ActionLabel)
      Me.panelUploadedFiles.Controls.Add(Me.ActionTextBox)
      Me.panelUploadedFiles.Controls.Add(CharacterSetLabel)
      Me.panelUploadedFiles.Controls.Add(Me.CharacterSetTextBox)
      Me.panelUploadedFiles.Controls.Add(AlternateRegisterNameLabel)
      Me.panelUploadedFiles.Controls.Add(Me.AlternateRegisterNameTextBox)
      Me.panelUploadedFiles.Controls.Add(CsvFileLabel)
      Me.panelUploadedFiles.Controls.Add(Me.CsvFileTextBox)
      Me.panelUploadedFiles.Controls.Add(Me.btnDeleteFile)
      Me.panelUploadedFiles.Controls.Add(Me.btnViewContents)
      Me.panelUploadedFiles.Dock = System.Windows.Forms.DockStyle.Fill
      Me.panelUploadedFiles.Location = New System.Drawing.Point(0, 0)
      Me.panelUploadedFiles.Margin = New System.Windows.Forms.Padding(4)
      Me.panelUploadedFiles.Name = "panelUploadedFiles"
      Me.panelUploadedFiles.Size = New System.Drawing.Size(1095, 583)
      Me.panelUploadedFiles.TabIndex = 5
      '
      'IDTextBox
      '
      Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "ID", True))
      Me.IDTextBox.Location = New System.Drawing.Point(209, 9)
      Me.IDTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.IDTextBox.Name = "IDTextBox"
      Me.IDTextBox.Size = New System.Drawing.Size(269, 22)
      Me.IDTextBox.TabIndex = 66
      '
      'BatchBindingSource
      '
      Me.BatchBindingSource.AllowNew = False
      Me.BatchBindingSource.DataMember = "Batch"
      Me.BatchBindingSource.DataSource = Me.BatchesDataSet
      '
      'BatchesDataSet
      '
      Me.BatchesDataSet.DataSetName = "Batches"
      Me.BatchesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'CountyNameTextBox
      '
      Me.CountyNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "CountyName", True))
      Me.CountyNameTextBox.Location = New System.Drawing.Point(209, 41)
      Me.CountyNameTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.CountyNameTextBox.Name = "CountyNameTextBox"
      Me.CountyNameTextBox.Size = New System.Drawing.Size(269, 22)
      Me.CountyNameTextBox.TabIndex = 68
      '
      'PlaceNameTextBox
      '
      Me.PlaceNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "PlaceName", True))
      Me.PlaceNameTextBox.Location = New System.Drawing.Point(209, 73)
      Me.PlaceNameTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.PlaceNameTextBox.Name = "PlaceNameTextBox"
      Me.PlaceNameTextBox.Size = New System.Drawing.Size(269, 22)
      Me.PlaceNameTextBox.TabIndex = 70
      '
      'ChurchNameTextBox
      '
      Me.ChurchNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "ChurchName", True))
      Me.ChurchNameTextBox.Location = New System.Drawing.Point(209, 105)
      Me.ChurchNameTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.ChurchNameTextBox.Name = "ChurchNameTextBox"
      Me.ChurchNameTextBox.Size = New System.Drawing.Size(269, 22)
      Me.ChurchNameTextBox.TabIndex = 72
      '
      'RegisterTypeTextBox
      '
      Me.RegisterTypeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "RegisterType", True))
      Me.RegisterTypeTextBox.Location = New System.Drawing.Point(209, 137)
      Me.RegisterTypeTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.RegisterTypeTextBox.Name = "RegisterTypeTextBox"
      Me.RegisterTypeTextBox.Size = New System.Drawing.Size(269, 22)
      Me.RegisterTypeTextBox.TabIndex = 74
      '
      'RecordTypeTextBox
      '
      Me.RecordTypeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "RecordType", True))
      Me.RecordTypeTextBox.Location = New System.Drawing.Point(209, 169)
      Me.RecordTypeTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.RecordTypeTextBox.Name = "RecordTypeTextBox"
      Me.RecordTypeTextBox.Size = New System.Drawing.Size(269, 22)
      Me.RecordTypeTextBox.TabIndex = 76
      '
      'RecordsTextBox
      '
      Me.RecordsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "Records", True))
      Me.RecordsTextBox.Location = New System.Drawing.Point(209, 201)
      Me.RecordsTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.RecordsTextBox.Name = "RecordsTextBox"
      Me.RecordsTextBox.Size = New System.Drawing.Size(269, 22)
      Me.RecordsTextBox.TabIndex = 78
      '
      'DateMinTextBox
      '
      Me.DateMinTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "DateMin", True))
      Me.DateMinTextBox.Location = New System.Drawing.Point(209, 233)
      Me.DateMinTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.DateMinTextBox.Name = "DateMinTextBox"
      Me.DateMinTextBox.Size = New System.Drawing.Size(269, 22)
      Me.DateMinTextBox.TabIndex = 80
      '
      'DateMaxTextBox
      '
      Me.DateMaxTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "DateMax", True))
      Me.DateMaxTextBox.Location = New System.Drawing.Point(209, 265)
      Me.DateMaxTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.DateMaxTextBox.Name = "DateMaxTextBox"
      Me.DateMaxTextBox.Size = New System.Drawing.Size(269, 22)
      Me.DateMaxTextBox.TabIndex = 82
      '
      'DateRangeTextBox
      '
      Me.DateRangeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "DateRange", True))
      Me.DateRangeTextBox.Location = New System.Drawing.Point(209, 297)
      Me.DateRangeTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.DateRangeTextBox.Name = "DateRangeTextBox"
      Me.DateRangeTextBox.Size = New System.Drawing.Size(269, 22)
      Me.DateRangeTextBox.TabIndex = 84
      '
      'UserIdTextBox
      '
      Me.UserIdTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "UserId", True))
      Me.UserIdTextBox.Location = New System.Drawing.Point(209, 329)
      Me.UserIdTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.UserIdTextBox.Name = "UserIdTextBox"
      Me.UserIdTextBox.Size = New System.Drawing.Size(269, 22)
      Me.UserIdTextBox.TabIndex = 86
      '
      'UserIdLowerCaseTextBox
      '
      Me.UserIdLowerCaseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "UserIdLowerCase", True))
      Me.UserIdLowerCaseTextBox.Location = New System.Drawing.Point(209, 361)
      Me.UserIdLowerCaseTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.UserIdLowerCaseTextBox.Name = "UserIdLowerCaseTextBox"
      Me.UserIdLowerCaseTextBox.Size = New System.Drawing.Size(269, 22)
      Me.UserIdLowerCaseTextBox.TabIndex = 88
      '
      'FileNameTextBox
      '
      Me.FileNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "FileName", True))
      Me.FileNameTextBox.Location = New System.Drawing.Point(209, 393)
      Me.FileNameTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.FileNameTextBox.Name = "FileNameTextBox"
      Me.FileNameTextBox.Size = New System.Drawing.Size(269, 22)
      Me.FileNameTextBox.TabIndex = 90
      '
      'TranscriberNameTextBox
      '
      Me.TranscriberNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "TranscriberName", True))
      Me.TranscriberNameTextBox.Location = New System.Drawing.Point(209, 425)
      Me.TranscriberNameTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.TranscriberNameTextBox.Name = "TranscriberNameTextBox"
      Me.TranscriberNameTextBox.Size = New System.Drawing.Size(269, 22)
      Me.TranscriberNameTextBox.TabIndex = 92
      '
      'TranscriberEmailTextBox
      '
      Me.TranscriberEmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "TranscriberEmail", True))
      Me.TranscriberEmailTextBox.Location = New System.Drawing.Point(209, 457)
      Me.TranscriberEmailTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.TranscriberEmailTextBox.Name = "TranscriberEmailTextBox"
      Me.TranscriberEmailTextBox.Size = New System.Drawing.Size(269, 22)
      Me.TranscriberEmailTextBox.TabIndex = 94
      '
      'TranscriberSyndicateTextBox
      '
      Me.TranscriberSyndicateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "TranscriberSyndicate", True))
      Me.TranscriberSyndicateTextBox.Location = New System.Drawing.Point(209, 489)
      Me.TranscriberSyndicateTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.TranscriberSyndicateTextBox.Name = "TranscriberSyndicateTextBox"
      Me.TranscriberSyndicateTextBox.Size = New System.Drawing.Size(269, 22)
      Me.TranscriberSyndicateTextBox.TabIndex = 96
      '
      'CreditEmailTextBox
      '
      Me.CreditEmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "CreditEmail", True))
      Me.CreditEmailTextBox.Location = New System.Drawing.Point(684, 9)
      Me.CreditEmailTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.CreditEmailTextBox.Name = "CreditEmailTextBox"
      Me.CreditEmailTextBox.Size = New System.Drawing.Size(269, 22)
      Me.CreditEmailTextBox.TabIndex = 98
      '
      'CreditNameTextBox
      '
      Me.CreditNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "CreditName", True))
      Me.CreditNameTextBox.Location = New System.Drawing.Point(684, 41)
      Me.CreditNameTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.CreditNameTextBox.Name = "CreditNameTextBox"
      Me.CreditNameTextBox.Size = New System.Drawing.Size(269, 22)
      Me.CreditNameTextBox.TabIndex = 100
      '
      'FirstCommentTextBox
      '
      Me.FirstCommentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "FirstComment", True))
      Me.FirstCommentTextBox.Location = New System.Drawing.Point(684, 73)
      Me.FirstCommentTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.FirstCommentTextBox.Name = "FirstCommentTextBox"
      Me.FirstCommentTextBox.Size = New System.Drawing.Size(269, 22)
      Me.FirstCommentTextBox.TabIndex = 102
      '
      'SecondCommentTextBox
      '
      Me.SecondCommentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "SecondComment", True))
      Me.SecondCommentTextBox.Location = New System.Drawing.Point(684, 105)
      Me.SecondCommentTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.SecondCommentTextBox.Name = "SecondCommentTextBox"
      Me.SecondCommentTextBox.Size = New System.Drawing.Size(269, 22)
      Me.SecondCommentTextBox.TabIndex = 104
      '
      'TranscriptionDateTextBox
      '
      Me.TranscriptionDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "TranscriptionDate", True))
      Me.TranscriptionDateTextBox.Location = New System.Drawing.Point(684, 137)
      Me.TranscriptionDateTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.TranscriptionDateTextBox.Name = "TranscriptionDateTextBox"
      Me.TranscriptionDateTextBox.Size = New System.Drawing.Size(269, 22)
      Me.TranscriptionDateTextBox.TabIndex = 106
      '
      'ModificationDateTextBox
      '
      Me.ModificationDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "ModificationDate", True))
      Me.ModificationDateTextBox.Location = New System.Drawing.Point(684, 169)
      Me.ModificationDateTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.ModificationDateTextBox.Name = "ModificationDateTextBox"
      Me.ModificationDateTextBox.Size = New System.Drawing.Size(269, 22)
      Me.ModificationDateTextBox.TabIndex = 108
      '
      'UploadedDateTextBox
      '
      Me.UploadedDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "UploadedDate", True))
      Me.UploadedDateTextBox.Location = New System.Drawing.Point(684, 201)
      Me.UploadedDateTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.UploadedDateTextBox.Name = "UploadedDateTextBox"
      Me.UploadedDateTextBox.Size = New System.Drawing.Size(269, 22)
      Me.UploadedDateTextBox.TabIndex = 110
      '
      'ErrorTextBox
      '
      Me.ErrorTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "Error", True))
      Me.ErrorTextBox.Location = New System.Drawing.Point(684, 233)
      Me.ErrorTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.ErrorTextBox.Name = "ErrorTextBox"
      Me.ErrorTextBox.Size = New System.Drawing.Size(269, 22)
      Me.ErrorTextBox.TabIndex = 112
      '
      'DigestTextBox
      '
      Me.DigestTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "Digest", True))
      Me.DigestTextBox.Location = New System.Drawing.Point(684, 265)
      Me.DigestTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.DigestTextBox.Name = "DigestTextBox"
      Me.DigestTextBox.Size = New System.Drawing.Size(269, 22)
      Me.DigestTextBox.TabIndex = 114
      '
      'LockedByTranscriberCheckBox
      '
      Me.LockedByTranscriberCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BatchBindingSource, "LockedByTranscriber", True))
      Me.LockedByTranscriberCheckBox.Location = New System.Drawing.Point(684, 297)
      Me.LockedByTranscriberCheckBox.Margin = New System.Windows.Forms.Padding(4)
      Me.LockedByTranscriberCheckBox.Name = "LockedByTranscriberCheckBox"
      Me.LockedByTranscriberCheckBox.Size = New System.Drawing.Size(173, 30)
      Me.LockedByTranscriberCheckBox.TabIndex = 116
      Me.LockedByTranscriberCheckBox.Text = "Locked by transcriber"
      Me.LockedByTranscriberCheckBox.UseVisualStyleBackColor = True
      '
      'LockedByCoordinatorCheckBox
      '
      Me.LockedByCoordinatorCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BatchBindingSource, "LockedByCoordinator", True))
      Me.LockedByCoordinatorCheckBox.Location = New System.Drawing.Point(684, 334)
      Me.LockedByCoordinatorCheckBox.Margin = New System.Windows.Forms.Padding(4)
      Me.LockedByCoordinatorCheckBox.Name = "LockedByCoordinatorCheckBox"
      Me.LockedByCoordinatorCheckBox.Size = New System.Drawing.Size(184, 30)
      Me.LockedByCoordinatorCheckBox.TabIndex = 118
      Me.LockedByCoordinatorCheckBox.Text = "Locked by Co-ordinator"
      Me.LockedByCoordinatorCheckBox.UseVisualStyleBackColor = True
      '
      'LdsTextBox
      '
      Me.LdsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "lds", True))
      Me.LdsTextBox.Location = New System.Drawing.Point(684, 370)
      Me.LdsTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.LdsTextBox.Name = "LdsTextBox"
      Me.LdsTextBox.Size = New System.Drawing.Size(269, 22)
      Me.LdsTextBox.TabIndex = 120
      '
      'ActionTextBox
      '
      Me.ActionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "Action", True))
      Me.ActionTextBox.Location = New System.Drawing.Point(684, 402)
      Me.ActionTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.ActionTextBox.Name = "ActionTextBox"
      Me.ActionTextBox.Size = New System.Drawing.Size(269, 22)
      Me.ActionTextBox.TabIndex = 122
      '
      'CharacterSetTextBox
      '
      Me.CharacterSetTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "CharacterSet", True))
      Me.CharacterSetTextBox.Location = New System.Drawing.Point(684, 434)
      Me.CharacterSetTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.CharacterSetTextBox.Name = "CharacterSetTextBox"
      Me.CharacterSetTextBox.Size = New System.Drawing.Size(269, 22)
      Me.CharacterSetTextBox.TabIndex = 124
      '
      'AlternateRegisterNameTextBox
      '
      Me.AlternateRegisterNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "AlternateRegisterName", True))
      Me.AlternateRegisterNameTextBox.Location = New System.Drawing.Point(684, 466)
      Me.AlternateRegisterNameTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.AlternateRegisterNameTextBox.Name = "AlternateRegisterNameTextBox"
      Me.AlternateRegisterNameTextBox.Size = New System.Drawing.Size(269, 22)
      Me.AlternateRegisterNameTextBox.TabIndex = 126
      '
      'CsvFileTextBox
      '
      Me.CsvFileTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "CsvFile", True))
      Me.CsvFileTextBox.Location = New System.Drawing.Point(684, 498)
      Me.CsvFileTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.CsvFileTextBox.Name = "CsvFileTextBox"
      Me.CsvFileTextBox.Size = New System.Drawing.Size(269, 22)
      Me.CsvFileTextBox.TabIndex = 128
      '
      'btnDeleteFile
      '
      Me.btnDeleteFile.Location = New System.Drawing.Point(813, 529)
      Me.btnDeleteFile.Margin = New System.Windows.Forms.Padding(4)
      Me.btnDeleteFile.Name = "btnDeleteFile"
      Me.btnDeleteFile.Size = New System.Drawing.Size(109, 28)
      Me.btnDeleteFile.TabIndex = 65
      Me.btnDeleteFile.Text = "Delete Batch"
      Me.btnDeleteFile.UseVisualStyleBackColor = True
      '
      'btnViewContents
      '
      Me.btnViewContents.Location = New System.Drawing.Point(931, 529)
      Me.btnViewContents.Margin = New System.Windows.Forms.Padding(4)
      Me.btnViewContents.Name = "btnViewContents"
      Me.btnViewContents.Size = New System.Drawing.Size(112, 28)
      Me.btnViewContents.TabIndex = 64
      Me.btnViewContents.Text = "View Contents"
      Me.btnViewContents.UseVisualStyleBackColor = True
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
      Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
      Me.SplitContainer1.Name = "SplitContainer1"
      Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.bnavShowData)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
      Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
      Me.SplitContainer1.Size = New System.Drawing.Size(1229, 620)
      Me.SplitContainer1.SplitterDistance = 32
      Me.SplitContainer1.SplitterWidth = 5
      Me.SplitContainer1.TabIndex = 65
      Me.SplitContainer1.Visible = False
      '
      'SplitContainer2
      '
      Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
      Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(4)
      Me.SplitContainer2.Name = "SplitContainer2"
      Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer2.Panel1
      '
      Me.SplitContainer2.Panel1.Controls.Add(Me.dlvLocalFiles)
      '
      'SplitContainer2.Panel2
      '
      Me.SplitContainer2.Panel2.Controls.Add(Me.btnNewFile)
      Me.SplitContainer2.Panel2.Controls.Add(Me.cboxProcess)
      Me.SplitContainer2.Panel2.Controls.Add(Me.labFilename)
      Me.SplitContainer2.Panel2.Controls.Add(Me.Label1)
      Me.SplitContainer2.Panel2.Controls.Add(Me.btnUploadFile)
      Me.SplitContainer2.Panel2.Controls.Add(Me.btnReplaceFile)
      Me.SplitContainer2.Size = New System.Drawing.Size(1229, 583)
      Me.SplitContainer2.SplitterDistance = 535
      Me.SplitContainer2.SplitterWidth = 5
      Me.SplitContainer2.TabIndex = 66
      Me.SplitContainer2.Visible = False
      '
      'dlvLocalFiles
      '
      Me.dlvLocalFiles.AlternateRowBackColor = System.Drawing.Color.Wheat
      Me.dlvLocalFiles.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick
      Me.dlvLocalFiles.CellEditUseWholeCell = False
      Me.dlvLocalFiles.CheckedAspectName = ""
      Me.dlvLocalFiles.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvLocalFiles.DataSource = Me.bsrcLocalFiles
      Me.dlvLocalFiles.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvLocalFiles.FullRowSelect = True
      Me.dlvLocalFiles.GridLines = True
      Me.dlvLocalFiles.Location = New System.Drawing.Point(0, 0)
      Me.dlvLocalFiles.Margin = New System.Windows.Forms.Padding(4)
      Me.dlvLocalFiles.MultiSelect = False
      Me.dlvLocalFiles.Name = "dlvLocalFiles"
      Me.dlvLocalFiles.SelectColumnsOnRightClick = False
      Me.dlvLocalFiles.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
      Me.dlvLocalFiles.ShowCommandMenuOnRightClick = True
      Me.dlvLocalFiles.ShowGroups = False
      Me.dlvLocalFiles.ShowImagesOnSubItems = True
      Me.dlvLocalFiles.ShowItemToolTips = True
      Me.dlvLocalFiles.Size = New System.Drawing.Size(1229, 535)
      Me.dlvLocalFiles.TabIndex = 4
      Me.dlvLocalFiles.TintSortColumn = True
      Me.dlvLocalFiles.UseAlternatingBackColors = True
      Me.dlvLocalFiles.UseCompatibleStateImageBehavior = False
      Me.dlvLocalFiles.UseSubItemCheckBoxes = True
      Me.dlvLocalFiles.View = System.Windows.Forms.View.Details
      '
      'btnNewFile
      '
      Me.btnNewFile.Location = New System.Drawing.Point(581, 12)
      Me.btnNewFile.Margin = New System.Windows.Forms.Padding(4)
      Me.btnNewFile.Name = "btnNewFile"
      Me.btnNewFile.Size = New System.Drawing.Size(121, 28)
      Me.btnNewFile.TabIndex = 10
      Me.btnNewFile.Text = "Start New File"
      Me.btnNewFile.UseVisualStyleBackColor = True
      '
      'cboxProcess
      '
      Me.cboxProcess.FormattingEnabled = True
      Me.cboxProcess.Location = New System.Drawing.Point(710, 14)
      Me.cboxProcess.Margin = New System.Windows.Forms.Padding(4)
      Me.cboxProcess.MaxDropDownItems = 3
      Me.cboxProcess.Name = "cboxProcess"
      Me.cboxProcess.Size = New System.Drawing.Size(272, 24)
      Me.cboxProcess.TabIndex = 9
      '
      'labFilename
      '
      Me.labFilename.AutoSize = True
      Me.labFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.labFilename.Location = New System.Drawing.Point(119, 16)
      Me.labFilename.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.labFilename.Name = "labFilename"
      Me.labFilename.Size = New System.Drawing.Size(0, 20)
      Me.labFilename.TabIndex = 8
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(16, 18)
      Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(90, 16)
      Me.Label1.TabIndex = 7
      Me.Label1.Text = "Selected File:"
      '
      'btnUploadFile
      '
      Me.btnUploadFile.Enabled = False
      Me.btnUploadFile.Location = New System.Drawing.Point(990, 12)
      Me.btnUploadFile.Margin = New System.Windows.Forms.Padding(4)
      Me.btnUploadFile.Name = "btnUploadFile"
      Me.btnUploadFile.Size = New System.Drawing.Size(100, 28)
      Me.btnUploadFile.TabIndex = 5
      Me.btnUploadFile.Text = "Upload file"
      Me.btnUploadFile.UseVisualStyleBackColor = True
      '
      'btnReplaceFile
      '
      Me.btnReplaceFile.Enabled = False
      Me.btnReplaceFile.Location = New System.Drawing.Point(1098, 12)
      Me.btnReplaceFile.Margin = New System.Windows.Forms.Padding(4)
      Me.btnReplaceFile.Name = "btnReplaceFile"
      Me.btnReplaceFile.Size = New System.Drawing.Size(100, 28)
      Me.btnReplaceFile.TabIndex = 6
      Me.btnReplaceFile.Text = "Replace file"
      Me.btnReplaceFile.UseVisualStyleBackColor = True
      '
      'SplitContainer3
      '
      Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
      Me.SplitContainer3.IsSplitterFixed = True
      Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer3.Margin = New System.Windows.Forms.Padding(4)
      Me.SplitContainer3.Name = "SplitContainer3"
      '
      'SplitContainer3.Panel1
      '
      Me.SplitContainer3.Panel1.Controls.Add(Me.dlvUploadedFiles)
      '
      'SplitContainer3.Panel2
      '
      Me.SplitContainer3.Panel2.Controls.Add(Me.panelUploadedFiles)
      Me.SplitContainer3.Size = New System.Drawing.Size(1229, 583)
      Me.SplitContainer3.SplitterDistance = 129
      Me.SplitContainer3.SplitterWidth = 5
      Me.SplitContainer3.TabIndex = 5
      '
      'dlvUploadedFiles
      '
      Me.dlvUploadedFiles.AllColumns.Add(Me.olvcFilename)
      Me.dlvUploadedFiles.AlternateRowBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.dlvUploadedFiles.AutoGenerateColumns = False
      Me.dlvUploadedFiles.CellEditUseWholeCell = False
      Me.dlvUploadedFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvcFilename})
      Me.dlvUploadedFiles.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvUploadedFiles.DataSource = Me.BatchBindingSource
      Me.dlvUploadedFiles.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvUploadedFiles.GridLines = True
      Me.dlvUploadedFiles.Location = New System.Drawing.Point(0, 0)
      Me.dlvUploadedFiles.Margin = New System.Windows.Forms.Padding(4)
      Me.dlvUploadedFiles.MultiSelect = False
      Me.dlvUploadedFiles.Name = "dlvUploadedFiles"
      Me.dlvUploadedFiles.ShowGroups = False
      Me.dlvUploadedFiles.Size = New System.Drawing.Size(129, 583)
      Me.dlvUploadedFiles.Sorting = System.Windows.Forms.SortOrder.Ascending
      Me.dlvUploadedFiles.TabIndex = 0
      Me.dlvUploadedFiles.UseAlternatingBackColors = True
      Me.dlvUploadedFiles.UseCompatibleStateImageBehavior = False
      Me.dlvUploadedFiles.View = System.Windows.Forms.View.Details
      '
      'olvcFilename
      '
      Me.olvcFilename.AspectName = "FileName"
      Me.olvcFilename.Groupable = False
      Me.olvcFilename.Text = "Batch"
      Me.olvcFilename.Width = 100
      '
      'backgroundUpload
      '
      Me.backgroundUpload.WorkerReportsProgress = True
      '
      'backgroundReplace
      '
      Me.backgroundReplace.WorkerReportsProgress = True
      '
      'backgroundDelete
      '
      Me.backgroundDelete.WorkerReportsProgress = True
      '
      'FreeregTablesDataSet
      '
      Me.FreeregTablesDataSet.DataSetName = "FreeregTables"
      Me.FreeregTablesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'FreeREG2Browser
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1229, 666)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Controls.Add(Me.BrowserStatusStrip)
      Me.Controls.Add(Me.BrowserMenuStrip)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MainMenuStrip = Me.BrowserMenuStrip
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.Name = "FreeREG2Browser"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "FreeREG/2 Browser"
      Me.BrowserMenuStrip.ResumeLayout(False)
      Me.BrowserMenuStrip.PerformLayout()
      Me.BrowserStatusStrip.ResumeLayout(False)
      Me.BrowserStatusStrip.PerformLayout()
      CType(Me.bnavShowData, System.ComponentModel.ISupportInitialize).EndInit()
      Me.bnavShowData.ResumeLayout(False)
      Me.bnavShowData.PerformLayout()
      CType(Me.bsrcLocalFiles, System.ComponentModel.ISupportInitialize).EndInit()
      Me.panelUploadedFiles.ResumeLayout(False)
      Me.panelUploadedFiles.PerformLayout()
      CType(Me.BatchBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.BatchesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel1.PerformLayout()
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      Me.SplitContainer2.Panel1.ResumeLayout(False)
      Me.SplitContainer2.Panel2.ResumeLayout(False)
      Me.SplitContainer2.Panel2.PerformLayout()
      Me.SplitContainer2.ResumeLayout(False)
      CType(Me.dlvLocalFiles, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SplitContainer3.Panel1.ResumeLayout(False)
      Me.SplitContainer3.Panel2.ResumeLayout(False)
      Me.SplitContainer3.ResumeLayout(False)
      CType(Me.dlvUploadedFiles, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.FreeregTablesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Public Structure BackgroundResult
      Dim Parameter As Object
      Dim Result As String
   End Structure

   Private Sub FreeREG2Browser_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

      If BatchesDataSet.Batch.GetChanges() IsNot Nothing Then
         If Not BatchesDataSet.Batch.HasErrors Then
            BatchesDataSet.Batch.AcceptChanges()
            BatchesDataSet.WriteXml(Path.Combine(AppDataLocalFolder, String.Format("{0} batches.xml", MyAppSettings.UserId)), XmlWriteMode.WriteSchema)
         End If
      End If

      If LookUpsDataSet.GetChanges() IsNot Nothing Then
         If Not LookUpsDataSet.HasErrors() Then
            LookUpsDataSet.AcceptChanges()
            LookUpsDataSet.WriteXml(LookupTablesFile, XmlWriteMode.WriteSchema)
         End If
      End If

      If TablesDataSet.GetChanges() IsNot Nothing Then
         If Not TablesDataSet.HasErrors Then
            TablesDataSet.AcceptChanges()
            TablesDataSet.WriteXml(FreeregTablesFile, XmlWriteMode.WriteSchema)
         End If
      End If

      If UserDataSet.GetChanges() IsNot Nothing Then
         If Not UserDataSet.HasErrors Then
            UserDataSet.AcceptChanges()
            UserDataSet.WriteXml(TranscriberProfileFile, XmlWriteMode.WriteSchema)
         End If
      End If

      ' Save Settings
      '
      Dim stream As Stream = Nothing
      Try
         stream = File.Open(SettingsFileName, FileMode.Create)
         Dim bformatter As New BinaryFormatter()
         bformatter.Serialize(stream, MyAppSettings)

      Catch ex As Exception
         Beep()

      Finally
         If stream IsNot Nothing Then stream.Close()
      End Try
   End Sub

   Private Sub FreeREG2Browser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      If File.Exists(SettingsFileName) Then
         Dim stream As Stream = Nothing
         Try
            stream = File.Open(SettingsFileName, FileMode.Open)
            Dim bformatter As New BinaryFormatter()
            MyAppSettings = CType(bformatter.Deserialize(stream), FreeReg2BrowserSettings)

         Catch ex As Exception
            Beep()

         Finally
            If stream IsNot Nothing Then stream.Close()
         End Try
      Else
         MyAppSettings = New FreeReg2BrowserSettings()
      End If

      MyAppSettings.UserId = _myUserId
      MyAppSettings.Password = _myPassword
      MyAppSettings.BaseUrl = _myUrl

      If File.Exists(ErrorMessagesFileName) Then
         ErrorMessagesDataSet.ReadXml(ErrorMessagesFileName, XmlReadMode.ReadSchema)
         ErrorMessagesDataSet.AcceptChanges()
      End If
      If File.Exists(TranscriberProfileFile) Then
         UserDataSet.ReadXml(TranscriberProfileFile, XmlReadMode.ReadSchema)
         UserDataSet.AcceptChanges()

         Dim currentUser As WinFreeReg.UserDetails.UserRow = UserDataSet.User.FindByuserid(MyAppSettings.UserId)
         If currentUser.person_role = "trainee" Then
            cboxProcess.Items.Add("Check for errors")
         Else
            cboxProcess.Items.AddRange(New Object() {"Process tonight", "As soon as possible"})
         End If
      End If
      If File.Exists(FreeregTablesFile) Then
         TablesDataSet.ReadXml(FreeregTablesFile, XmlReadMode.ReadSchema)
         TablesDataSet.AcceptChanges()
      End If

      LoadLookupTables()

      If Not String.IsNullOrEmpty(MyAppSettings.UserId) Then
         If File.Exists(Path.Combine(AppDataLocalFolder, String.Format("{0} batches.xml", MyAppSettings.UserId))) Then
            BatchesDataSet.ReadXml(Path.Combine(AppDataLocalFolder, String.Format("{0} batches.xml", MyAppSettings.UserId)))
            BatchesDataSet.AcceptChanges()
         End If
      End If
   End Sub

   Private Sub LoadLookupTables()
      LookUpsDataSet.LoadXmlData(LookupTablesFile)
      LookUpsDataSet.AcceptChanges()
      If Not File.Exists(LookupTablesFile) Then LookUpsDataSet.SaveXmlData(LookupTablesFile)
   End Sub

#Region "Menu - FreeREG"

	Private Sub miFreeREG2_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFreeREG.DropDownOpening
		Select Case pgmState
			Case ProgramState.Idle
				miLogin.Enabled = True
				miLogout.Enabled = False
				miUserProfile.Enabled = File.Exists(TranscriberProfileFile)
            miRefreshUser.Enabled = False

			Case ProgramState.LoggedOn
				miLogin.Enabled = False
				miLogout.Enabled = True
				miUserProfile.Enabled = File.Exists(TranscriberProfileFile)

			Case ProgramState.UserAuthenticated
				miLogin.Enabled = False
				miLogout.Enabled = True
				miUserProfile.Enabled = File.Exists(TranscriberProfileFile)
				miRefreshUser.Enabled = True
      End Select

      miNetworkTrace.Checked = _myNetworkTrace

   End Sub

	Private Sub miLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miLogin.Click
		Using dlg As New formLogin()
			dlg.UrlTextBox.Text = MyAppSettings.BaseUrl
			dlg.UsernameTextBox.Text = MyAppSettings.UserId
			dlg.PasswordTextBox.Text = MyAppSettings.Password
			Dim rc As DialogResult = dlg.ShowDialog()
			If rc = Windows.Forms.DialogResult.OK Then
				MyAppSettings.UserId = dlg.UsernameTextBox.Text
				MyAppSettings.Password = dlg.PasswordTextBox.Text
				backgroundLogon.RunWorkerAsync()
			Else
			End If
		End Using
	End Sub

	Private Sub miLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miLogout.Click
		miLogout.Enabled = False
		backgroundLogout.RunWorkerAsync()
	End Sub

	Private Sub miUserDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miUserProfile.Click
		Using dlg As New formUserDetails With {.RecordToShow = UserDataSet.User.FindByuserid(MyAppSettings.UserId), .MyOwner = Me}
			dlg.ShowDialog()
		End Using
	End Sub

	Private Sub miRefreshUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRefreshUser.Click
		Refreshtranscriber()
	End Sub

   Private Sub miNetworkTrace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miNetworkTrace.Click
      _myNetworkTrace = miNetworkTrace.Checked
   End Sub

	Private Sub miExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miExit.Click
		Me.Close()
	End Sub

#End Region

#Region "Menu - Transcripts"

	Private Sub miTranscriptions_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTranscriptions.DropDownOpening
		Select Case pgmState
			Case ProgramState.Idle
            miLocalFiles.Enabled = True
				miUploadedFiles.Enabled = False

			Case ProgramState.LoggedOn
            miLocalFiles.Enabled = True
				miUploadedFiles.Enabled = False

			Case ProgramState.UserAuthenticated
				miLocalFiles.Enabled = True
				miUploadedFiles.Enabled = True
		End Select
	End Sub

	Private Sub miLocalFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miLocalFiles.Click
		labelStatus.Text = ""

      Dim fileQuery = From file As FileInfo In ListFiles(_myTranscriptionLibrary) _
                      Where file.Extension.Equals(".csv", StringComparison.CurrentCultureIgnoreCase) _
                      Order By file.Name _
                      Select file

		Dim tableLocalFiles As DataTable = CreateDataTable(Of FileInfo)(fileQuery)
      If File.Exists(Path.Combine(AppDataLocalFolder, String.Format("{0} batches.xml", MyAppSettings.UserId))) Then
         Dim col As DataColumn = tableLocalFiles.Columns.Add("dateUploaded", Type.GetType("System.String"))
         col.Caption = "Date Uploaded"
         For Each row As DataRow In tableLocalFiles.Rows
            Dim batchRow As Batches.BatchRow = BatchesDataSet.Batch.FindByFileName(row("Name"))
            If batchRow IsNot Nothing Then
               Dim dtUploaded As New DateTime()
               If Date.TryParse(batchRow.UploadedDate, dtUploaded) Then
                  row("dateUploaded") = dtUploaded.ToLocalTime.ToString()
               End If
            End If
         Next
      End If

		Dim cnt = dlvLocalFiles.Columns.Count

		SplitContainer1.Visible = True
		panelUploadedFiles.Visible = False
		bsrcLocalFiles.DataSource = tableLocalFiles
		bnavShowData.BindingSource = bsrcLocalFiles

		If cnt = 0 Then
			Dim dlvcol As OLVColumn

			dlvcol = CType(dlvLocalFiles.Columns("Name"), OLVColumn)
			dlvcol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
			dlvcol.Groupable = False
			dlvcol.Sortable = True
			dlvcol.IsEditable = False

			dlvcol = CType(dlvLocalFiles.Columns("Length"), OLVColumn)
			dlvcol.Text = "Size"
			dlvcol.TextAlign = HorizontalAlignment.Right
			dlvcol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
			dlvcol.AspectToStringFormat = "{0:###,##0}"
			dlvcol.Groupable = False
			dlvcol.Sortable = False
			dlvcol.IsEditable = False

			dlvcol = CType(dlvLocalFiles.Columns("DirectoryName"), OLVColumn)
			dlvcol.IsVisible = False
			dlvcol.Groupable = False
			dlvcol.Sortable = False

			dlvcol = CType(dlvLocalFiles.Columns("Directory"), OLVColumn)
			dlvcol.IsVisible = False
			dlvcol.Groupable = False
			dlvcol.Sortable = False

			dlvcol = CType(dlvLocalFiles.Columns("IsReadOnly"), OLVColumn)
			dlvcol.Text = "Read Only"
			dlvcol.AspectGetter = New AspectGetterDelegate(AddressOf GetReadOnlyStatus)
			dlvcol.AspectPutter = New AspectPutterDelegate(AddressOf SetReadOnlyStatus)
			dlvcol.AspectToStringConverter = New AspectToStringConverterDelegate(AddressOf ReadOnlyState)
			dlvcol.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
			dlvcol.Groupable = False
			dlvcol.Sortable = False

			dlvcol = CType(dlvLocalFiles.Columns("Exists"), OLVColumn)
			dlvcol.IsVisible = False
			dlvcol.Groupable = False
			dlvcol.Sortable = False

			dlvcol = CType(dlvLocalFiles.Columns("FullName"), OLVColumn)
			dlvcol.IsVisible = False
			dlvcol.Groupable = False
			dlvcol.Sortable = False

			dlvcol = CType(dlvLocalFiles.Columns("Extension"), OLVColumn)
			dlvcol.IsVisible = False
			dlvcol.Groupable = False
			dlvcol.Sortable = False

			dlvcol = CType(dlvLocalFiles.Columns("CreationTIme"), OLVColumn)
			dlvcol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
			dlvcol.Groupable = False
			dlvcol.Sortable = False
			dlvcol.IsEditable = False

			dlvcol = CType(dlvLocalFiles.Columns("CreationTImeUtc"), OLVColumn)
			dlvcol.IsVisible = False
			dlvcol.Groupable = False
			dlvcol.Sortable = False

			dlvcol = CType(dlvLocalFiles.Columns("LastAccessTime"), OLVColumn)
			dlvcol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
			dlvcol.Groupable = False
			dlvcol.Sortable = False
			dlvcol.IsEditable = False

			dlvcol = CType(dlvLocalFiles.Columns("LastAccessTimeUtc"), OLVColumn)
			dlvcol.IsVisible = False
			dlvcol.Groupable = False
			dlvcol.Sortable = False

			dlvcol = CType(dlvLocalFiles.Columns("LastWriteTime"), OLVColumn)
			dlvcol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
			dlvcol.Groupable = False
			dlvcol.Sortable = False
			dlvcol.IsEditable = False

			dlvcol = CType(dlvLocalFiles.Columns("LastWriteTimeUtc"), OLVColumn)
			dlvcol.IsVisible = False
			dlvcol.Groupable = False
			dlvcol.Sortable = False

			dlvcol = CType(dlvLocalFiles.Columns("Attributes"), OLVColumn)
			dlvcol.IsVisible = False
			dlvcol.Groupable = False
			dlvcol.Sortable = False

			dlvcol = CType(dlvLocalFiles.Columns("dateUploaded"), OLVColumn)
			If dlvcol IsNot Nothing Then
				dlvcol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
				dlvcol.GroupKeyGetter = New GroupKeyGetterDelegate(AddressOf SetGroupKey)
				dlvcol.GroupKeyToTitleConverter = New GroupKeyToTitleConverterDelegate(AddressOf SetGroupTitle)
				dlvcol.Sortable = True
				dlvcol.IsEditable = False
			End If
		End If

		dlvLocalFiles.RebuildColumns()
		SplitContainer2.Visible = True
      If cboxProcess.Items.Count > 0 Then cboxProcess.SelectedIndex = 0
		SplitContainer3.Visible = False
		bnavShowData.Visible = True
      Me.ClientSize = New Size(SplitContainer2.PreferredSize.Width, Me.ClientSize.Height)
      btnReplaceFile.Enabled = (pgmState = ProgramState.UserAuthenticated)
	End Sub

	Private Sub miUploadedFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miUploadedFiles.Click
		backgroundBatches.RunWorkerAsync()
	End Sub

	Function ListFiles(ByVal root As String) As System.Collections.Generic.IEnumerable(Of System.IO.FileInfo)
		' Function to retrieve a list of files. Note that this is a copy
		' of the file information.
      Return From file In My.Computer.FileSystem.GetFiles(root, FileIO.SearchOption.SearchTopLevelOnly, "*.*") _
             Select New System.IO.FileInfo(file)
	End Function

	Public Shared Function CreateDataTable(Of T)(ByVal list As IEnumerable(Of T)) As DataTable
		Dim type As Type = GetType(T)
		Dim properties = type.GetProperties()

		Dim dataTable As New DataTable()
		For Each info As PropertyInfo In properties
			dataTable.Columns.Add(New DataColumn(info.Name, If(Nullable.GetUnderlyingType(info.PropertyType), info.PropertyType)))
		Next

		For Each entity As T In list
			Dim values As Object() = New Object(properties.Length - 1) {}
			Dim i As Integer = 0
			While i < properties.Length
				values(i) = properties(i).GetValue(entity, Nothing)
				System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
			End While

			dataTable.Rows.Add(values)
		Next

		Return dataTable
	End Function

	Function ReadOnlyState(ByVal objState As Object)
		Dim state As Boolean = CType(objState, Boolean)
		Return IIf(state, "True", "False")
	End Function

	Function GetReadOnlyStatus(ByVal rowObject As Object)
		Dim drv As DataRowView = CType(rowObject, DataRowView)
		Dim dr As DataRow = drv.Row
		Dim fi As New FileInfo(dr("FullName"))
		Return fi.IsReadOnly
	End Function

	Function SetReadOnlyStatus(ByVal rowObject As Object, ByVal newValue As Object)
		Dim drv As DataRowView = CType(rowObject, DataRowView)
		Dim dr As DataRow = drv.Row
		Dim fi As New FileInfo(dr("FullName"))
		fi.IsReadOnly = newValue
		Return newValue
	End Function

	Function SetGroupKey(ByVal rowObject As Object)
		Dim drv As DataRowView = CType(rowObject, DataRowView)
		Dim dr As DataRow = drv.Row
		Dim dtLastWritten As DateTime = dr("LastWriteTime")
		If DBNull.Value.Equals(dr("dateuploaded")) Then
			Return -1
		Else
			Dim dtUploaded As DateTime = dr("dateUploaded")
			If DateTime.Compare(dtLastWritten, dtUploaded) > 0 Then
				Return 0
			End If
		End If
		Return 1
	End Function

	Function SetGroupTitle(ByVal groupKey As Object)
		Dim i = CInt(groupKey)
		If i = -1 Then Return "New Files"
		If i = 0 Then Return "Files that need replacing"
		If i = 1 Then Return "Default"
		Return "Error"
	End Function

	Private Sub dlvLocalFiles_FormatRow(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.FormatRowEventArgs) Handles dlvLocalFiles.FormatRow
		Dim model As DataRowView = CType(e.Model, DataRowView)
		Dim row As DataRow = CType(model.Row, DataRow)
		Dim dtLastWritten As DateTime = row("LastWriteTime")
		If row.Table.Columns.Contains("dateuploaded") Then
			If DBNull.Value.Equals(row("dateuploaded")) Then
				e.Item.BackColor = Color.LavenderBlush
				e.Item.ForeColor = Color.Red
			Else
				Dim dtUploaded As DateTime = row("dateUploaded")
				If DateTime.Compare(dtLastWritten, dtUploaded) > 0 Then
					e.Item.BackColor = Color.Honeydew
					e.Item.ForeColor = Color.Green
				End If
			End If
		End If
	End Sub

	Private Sub dlvLocalFiles_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dlvLocalFiles.SelectionChanged
		If dlvLocalFiles.HideSelection Then dlvLocalFiles.HideSelection = False
		If dlvLocalFiles.SelectedItem IsNot Nothing Then
			Dim olvItem As OLVListItem = dlvLocalFiles.SelectedItem
			Dim dbi As DataRowView = CType(olvItem.RowObject, DataRowView)
			Dim row As DataRow = dbi.Row
			labFilename.Text = row("Name")
			If row.Table.Columns.Contains("dateuploaded") Then
            If cboxProcess.Items.Count > 0 Then cboxProcess.SelectedIndex = 0
				If DBNull.Value.Equals(row("dateuploaded")) Then
               btnUploadFile.Enabled = (pgmState = ProgramState.UserAuthenticated)
					btnReplaceFile.Enabled = False
				Else
					btnUploadFile.Enabled = False
               btnReplaceFile.Enabled = (pgmState = ProgramState.UserAuthenticated)
				End If
			End If
		End If
	End Sub

#End Region

#Region "Menu - Transcription Data"

	Private Sub miTranscriptionData_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTranscriptionData.DropDownOpening
		Select Case pgmState
			Case ProgramState.Idle
				miFreeREG2Tables.Enabled = False
				miUserTables.Enabled = False

			Case ProgramState.LoggedOn
				miFreeREG2Tables.Enabled = False
				miUserTables.Enabled = False

			Case ProgramState.UserAuthenticated
				miFreeREG2Tables.Enabled = True
				miUserTables.Enabled = True
		End Select
	End Sub

	Private Sub miUserTables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miUserTables.Click
      Using dlg As New formUserTables() With {.LookupTables = LookUpsDataSet, .LookupsFilename = LookupTablesFile}
         dlg.ShowDialog()
      End Using
	End Sub

	Private Sub miFreeREG2Tables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFreeREG2Tables.Click
      Using dlg As New formFreeregTables With {.DataSet = TablesDataSet, .TablesFileName = FreeregTablesFile, .Settings = MyAppSettings, .DefaultCounty = _myDefaultCounty}
         dlg.ShowDialog()
      End Using
	End Sub

#End Region

#Region "Logon Background Thread"

	Private Sub backgroundLogon_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundLogon.DoWork
		Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
		e.Result = PerformLogon(worker, e)
	End Sub

	Private Sub backgroundLogon_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundLogon.ProgressChanged
		labelStatus.Text = e.UserState
		Application.DoEvents()
	End Sub

	Private Sub backgroundLogon_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundLogon.RunWorkerCompleted
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
			labelStatus.Text = "Cancelled"
		Else
			' Finally, handle the case where the operation succeeded.
			miLogin.Enabled = False
			miLogout.Enabled = True
			pgmState = ProgramState.UserAuthenticated

			' Kick off the Batches download thread
			'
		End If
	End Sub

	Function PerformLogon(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Long
		Dim result As Long = 0

		Using webClient As New CookieAwareWebClient()
			Try
				worker.ReportProgress(0, "Logging on...")
				webClient.SetTimeout(30000)
				webClient.CookieContainer = New CookieContainer()
				Dim uri = New Uri(MyAppSettings.BaseUrl)
				Dim euDirective As New Cookie("cookiesDirective", "1")
				webClient.CookieContainer.Add(uri, euDirective)
				Dim addrRequest As String = MyAppSettings.BaseUrl + "/refinery/login"
				Dim login_request = webClient.DownloadString(addrRequest)
				MyAppSettings.CookieJar = webClient.CookieContainer

				HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("form")
				HtmlAgilityPack.HtmlNode.ElementsFlags.Remove("input")
				Dim doc As New HtmlAgilityPack.HtmlDocument
				doc.LoadHtml(login_request)
				Dim forms As HtmlAgilityPack.HtmlNodeCollection = doc.DocumentNode.SelectNodes("//form")
				Dim formAction As String = ""
				For Each form As HtmlAgilityPack.HtmlNode In forms
					formAction = form.GetAttributeValue("action", "")
					Dim nodes As HtmlAgilityPack.HtmlNodeCollection = form.SelectNodes("//input")
					For Each node As HtmlAgilityPack.HtmlNode In nodes
						Dim name = node.GetAttributeValue("name", "")
						Dim type = node.GetAttributeValue("type", "")
						Dim value = node.GetAttributeValue("value", "")
						If name = "utf8" Then utf8_token = value
						If name = "authenticity_token" Then authenticity_token = value
					Next
				Next

				Dim addrPost As String = MyAppSettings.BaseUrl + formAction
				Dim login_data = New NameValueCollection()
				login_data.Add("utf8", utf8_token)
				login_data.Add("authenticity_token", authenticity_token)
				login_data.Add("refinery_user[login]", MyAppSettings.TransregName)
				login_data.Add("refinery_user[password]", MyAppSettings.TransregPassword)
				login_data.Add("remember_me", "0")
				Dim login_array = webClient.UploadValues(addrPost, "POST", login_data)
				Dim login_page = Encoding.ASCII.GetString(login_array)
				MyAppSettings.CookieJar = webClient.CookieContainer

				'	Check that we've actually logged in with the transreg userid
				'
				Try
					Dim xmlDoc As New XmlDocument()
					xmlDoc.LoadXml(login_page)
					Dim root As XmlElement = xmlDoc.DocumentElement()
					If root Is Nothing Then
						' No root element
						Throw New BackgroundWorkerException("Computer Login failed - Missing root element")
					Else
						If String.Compare(root.Name, "login", True) = 0 Then
							Dim element As XmlElement = xmlDoc.SelectSingleNode("/login/result")
							If element Is Nothing Then
								' Missing 'result' node
								Throw New BackgroundWorkerException("Computer Login failed - Missing result node")
							Else
								Select Case element.FirstChild.Value
									Case "Logged in"

									Case Else
										' XML Format error
										Throw New BackgroundWorkerException("Computer Login - XML format error")

								End Select
							End If
						Else
							Throw New BackgroundWorkerException("Computer Login - Unrecognised response")
						End If
					End If

				Catch ex As BackgroundWorkerException
					Throw

				Catch ex As XmlException
					Throw New BackgroundWorkerException("Computer Login failed", ex)

				Catch ex As Exception
					Throw New BackgroundWorkerException("Computer Login failed", ex)

				End Try

				Dim loginResponse As New HtmlAgilityPack.HtmlDocument()
				loginResponse.LoadHtml(login_page)
				Dim html As HtmlAgilityPack.HtmlNode = loginResponse.DocumentNode()
				Dim divs = html.Descendants("div").Where(Function(n) n.GetAttributeValue("class", "").Equals("flash flash_alert")).Any
				If divs Then
					Dim div As HtmlAgilityPack.HtmlNode = html.Descendants("div").Where(Function(n) n.GetAttributeValue("class", "").Equals("flash flash_alert")).Single()
					If div IsNot Nothing Then
						If Not String.IsNullOrEmpty(div.InnerText) Then
							Throw New BackgroundWorkerException(String.Format("{0} Computer Login failed - {1}", MyAppSettings.TransregName, div.InnerText))
						End If
					End If
				End If

				worker.ReportProgress(50, "Authenticating transcriber...")
				Dim addrAuth As String = MyAppSettings.BaseUrl + "/transreg_users/authenticate"
				Dim query_data = New NameValueCollection()
				query_data.Add("transcriberid", MyAppSettings.UserId)
				query_data.Add("transcriberpassword", MyAppSettings.Password)
				webClient.QueryString = query_data
				Dim auth_page = webClient.DownloadString(addrAuth)
				MyAppSettings.CookieJar = webClient.CookieContainer

				Try
					Dim xmlDoc As New XmlDocument()
					xmlDoc.LoadXml(auth_page)
					Dim root As XmlElement = xmlDoc.DocumentElement()
					If root Is Nothing Then
						' No root element
						Throw New BackgroundWorkerException("User Authentication failed - Missing root element")
					Else
						If String.Compare(root.Name, "authentication", True) = 0 Then
							Dim element As XmlElement = xmlDoc.SelectSingleNode("/authentication/result")
							If element Is Nothing Then
								' Missing 'result' node
								Throw New BackgroundWorkerException("User Authentication failed - Missing result node")
							Else
								Select Case element.FirstChild.Value
									Case "success"
										Dim userid As XmlElement = xmlDoc.SelectSingleNode("/authentication/userid_detail")
										If userid Is Nothing Then
											' Missing 'userid-detail' node
											Throw New BackgroundWorkerException("User Authentication failed - Missing userid-detail node")
										Else
											Dim dt As UserDetails.UserDataTable = UserDataSet.User
											Dim rec As UserDetails.UserRow
											rec = dt.FindByuserid(MyAppSettings.UserId)
											If rec Is Nothing Then
												rec = dt.NewUserRow()
												For Each el As XmlElement In userid.ChildNodes
													Try
														Dim n As String = el.Name
														Dim z As String = el.InnerText
														If dt.Columns.Contains(n) Then
															Select Case dt.Columns(n).DataType.Name
																Case "Boolean"
																	If Not Boolean.TryParse(z, rec(n)) Then
																		rec(n) = IIf(z = "1", True, False)
																	End If
																Case "UInt16"
																	If Not UInt16.TryParse(z, rec(n)) Then
																		Beep()
																	End If
																Case "DateTime"
																	If Not String.IsNullOrEmpty(z) Then
																		rec(n) = z
																	End If
																Case Else
																	rec(n) = z
															End Select
														End If

													Catch ex As Exception
														Throw New BackgroundWorkerException("User Authentication failed", ex)
													End Try
												Next
												dt.AddUserRow(rec)
											Else
												For Each el As XmlElement In userid.ChildNodes
													Try
														Dim n As String = el.Name
														Dim z As String = el.InnerText
														If dt.Columns.Contains(n) Then
															Select Case dt.Columns(n).DataType.Name
																Case "Boolean"
																	If Not Boolean.TryParse(z, rec(n)) Then
																		rec(n) = IIf(z = "1", True, False)
																	End If
																Case "UInt16"
																	If Not UInt16.TryParse(z, rec(n)) Then
																		Beep()
																	End If
																Case "DateTime"
																	If Not String.IsNullOrEmpty(z) Then
																		rec(n) = z
																	End If
																Case Else
																	rec(n) = z
															End Select
														End If

													Catch ex As Exception
														Throw New BackgroundWorkerException("User Authentication failed", ex)
													End Try
												Next
											End If

											UserDataSet.AcceptChanges()
											UserDataSet.WriteXml(TranscriberProfileFile, XmlWriteMode.WriteSchema)

										End If

									Case "unknown_user"
										' Unknown Transcriber Id.
										Throw New BackgroundWorkerException("User Authentication - unknown transcriber-id")

									Case "no_match"
										' Invalid Transcriber Password
										Throw New BackgroundWorkerException("User Authentication - invalid transcriber password")

									Case Else
										' XML Format error
										Throw New BackgroundWorkerException("User Authentication - XML format error")

								End Select
							End If

							MyAppSettings.CookieJar = webClient.CookieContainer
							worker.ReportProgress(100, "Logged on to FreeREG/2")
						Else
							Throw New BackgroundWorkerException("User Authentication - Unrecognised response")
						End If
					End If

				Catch ex As BackgroundWorkerException
					Throw

				Catch ex As XmlException
					Throw New BackgroundWorkerException("User Authentication failed", ex)

				Catch ex As Exception
					Throw New BackgroundWorkerException("User Authentication failed", ex)

				End Try

			Catch ex As BackgroundWorkerException
				Throw

			Catch ex As WebException
				Dim webResp As HttpWebResponse = ex.Response
				If webResp Is Nothing Then
					Throw New BackgroundWorkerException("Logon to FreeREG/2 failed", ex)
				Else
					Console.WriteLine(String.Format("WebException:{0} Desc:{1}", webResp.StatusCode, webResp.StatusDescription))
					Select Case webResp.StatusCode
						Case HttpStatusCode.NotFound

						Case HttpStatusCode.NotAcceptable

						Case HttpStatusCode.InternalServerError

						Case Else

					End Select
					Throw New BackgroundWorkerException("Logon to FreeREG/2 failed", ex)
				End If

			Catch ex As Exception
				Throw New BackgroundWorkerException("Logon to FreeREG/2 failed", ex)
			End Try
		End Using

		Return result
	End Function

	Private Sub ShowAuthorisationResponse(ByVal auth_page As String)
		Dim page_data As Byte() = Encoding.UTF8.GetBytes(auth_page)
		Dim ms As New MemoryStream(page_data)
		Dim reader As New XmlTextReader(ms)
		reader.WhitespaceHandling = WhitespaceHandling.None

		While reader.Read()
			Select Case reader.NodeType
				Case XmlNodeType.Element
					Console.WriteLine("<{0}>", reader.Name)
				Case XmlNodeType.Text
					Console.WriteLine(reader.Value)
				Case XmlNodeType.CDATA
					Console.WriteLine("<![CDATA[{0}]]>", reader.Value)
				Case XmlNodeType.ProcessingInstruction
					Console.WriteLine("<?{0} {1}?>", reader.Name, reader.Value)
				Case XmlNodeType.Comment
					Console.WriteLine("<!--{0}-->", reader.Value)
				Case XmlNodeType.XmlDeclaration
					Console.WriteLine("<?xml version='1.0'?>")
				Case XmlNodeType.Document
				Case XmlNodeType.DocumentType
					Console.WriteLine("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value)
				Case XmlNodeType.EntityReference
					Console.WriteLine(reader.Name)
				Case XmlNodeType.EndElement
					Console.WriteLine("</{0}>", reader.Name)
			End Select
		End While
	End Sub

	Public Sub Refreshtranscriber()
		Using webClient As New CookieAwareWebClient()
			webClient.SetTimeout(60000)
			webClient.CookieContainer = MyAppSettings.CookieJar
			Dim addrAuth As String = MyAppSettings.BaseUrl + "/transreg_users/refreshuser"
			Dim query_data = New NameValueCollection()
			query_data.Add("transcriberid", MyAppSettings.UserId)
			webClient.QueryString = query_data
			Dim auth_page = webClient.DownloadString(addrAuth)
			MyAppSettings.CookieJar = webClient.CookieContainer

			Try
				Dim xmlDoc As New XmlDocument()
				xmlDoc.LoadXml(auth_page)
				Dim root As XmlElement = xmlDoc.DocumentElement()
				If root Is Nothing Then
					' No root element
					Throw New BackgroundWorkerException("Refresh User failed - Missing root element")
				Else
					If String.Compare(root.Name, "refresh", True) = 0 Then
						Dim element As XmlElement = xmlDoc.SelectSingleNode("/refresh/result")
						If element Is Nothing Then
							' Missing 'result' node
							Throw New BackgroundWorkerException("Refresh User failed - Missing result node")
						Else
							Select Case element.FirstChild.Value
								Case "success"
									Dim userid As XmlElement = xmlDoc.SelectSingleNode("/refresh/userid_detail")
									If userid Is Nothing Then
										' Missing 'userid-detail' node
										Throw New BackgroundWorkerException("Refresh User failed - Missing userid-detail node")
									Else
										Try
											Dim dt As UserDetails.UserDataTable = UserDataSet.User
											Dim rec As UserDetails.UserRow
											rec = dt.FindByuserid(MyAppSettings.UserId)
											If rec Is Nothing Then
												rec = dt.NewUserRow()
												For Each el As XmlElement In userid.ChildNodes
													Try
														Dim n As String = el.Name
														Dim z As String = el.InnerText
														If dt.Columns.Contains(n) Then
															Select Case dt.Columns(n).DataType.Name
																Case "Boolean"
																	If Not Boolean.TryParse(z, rec(n)) Then
																		rec(n) = IIf(z = "1", True, False)
																	End If
																Case "UInt16"
																	If Not UInt16.TryParse(z, rec(n)) Then
																		Beep()
																	End If
																Case "DateTime"
																	If Not String.IsNullOrEmpty(z) Then
																		rec(n) = z
																	End If
																Case Else
																	rec(n) = z
															End Select
														End If

													Catch ex As Exception
														Throw New BackgroundWorkerException("Refresh User failed", ex)
													End Try
												Next
												dt.AddUserRow(rec)
											Else
												For Each el As XmlElement In userid.ChildNodes
													Try
														Dim n As String = el.Name
														Dim z As String = el.InnerText
														If dt.Columns.Contains(n) Then
															Select Case dt.Columns(n).DataType.Name
																Case "Boolean"
																	If Not Boolean.TryParse(z, rec(n)) Then
																		rec(n) = IIf(z = "1", True, False)
																	End If
																Case "UInt16"
																	If Not UInt16.TryParse(z, rec(n)) Then
																		Beep()
																	End If
																Case "DateTime"
																	If Not String.IsNullOrEmpty(z) Then
																		rec(n) = z
																	End If
																Case Else
																	rec(n) = z
															End Select
														End If

													Catch ex As Exception
														Throw New BackgroundWorkerException("Refresh User failed", ex)
													End Try
												Next
											End If

											UserDataSet.AcceptChanges()
											UserDataSet.WriteXml(TranscriberProfileFile, XmlWriteMode.WriteSchema)

										Catch ex As Exception
											Throw New BackgroundWorkerException("Refresh User failed", ex)
										End Try
									End If

								Case "unknown_user"
									' Unknown Transcriber Id.
									Throw New BackgroundWorkerException("Refresh User - unknown transcriber-id")

								Case "no_match"
									' Invalid Transcriber Password
									Throw New BackgroundWorkerException("Refresh User - invalid transcriber password")

								Case Else
									' XML Format error
									Throw New BackgroundWorkerException("Refresh User - XML format error")

							End Select
						End If

					Else
						Throw New BackgroundWorkerException("Refresh User - Unrecognised response")
					End If
				End If

			Catch ex As BackgroundWorkerException
				Throw

			Catch ex As XmlException
				Throw New BackgroundWorkerException("Refresh User failed", ex)

			Catch ex As Exception
				Throw New BackgroundWorkerException("Refresh User failed", ex)

			End Try

		End Using
	End Sub

#End Region

#Region "Logout Background Thread"

	Private Sub backgroundLogout_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundLogout.DoWork
		Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
		e.Result = PerformLogout(worker, e)
	End Sub

	Private Sub backgroundLogout_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundLogout.ProgressChanged
		labelStatus.Text = e.UserState
		Application.DoEvents()
	End Sub

	Private Sub backgroundLogout_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundLogout.RunWorkerCompleted
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
			labelStatus.Text = "Cancelled"
		Else
			' Finally, handle the case where the operation succeeded.
			miLogin.Enabled = True
			miLogout.Enabled = False
			labelStatus.Text = "Logged out"
			pgmState = ProgramState.Idle
			SplitContainer1.Visible = False
			SplitContainer2.Visible = False
			panelUploadedFiles.Visible = False
		End If
	End Sub

	Function PerformLogout(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Long
		Dim result As Long = 0

		Using webClient As New CookieAwareWebClient()
			Try
				webClient.SetTimeout(30000)
				webClient.CookieContainer = MyAppSettings.CookieJar
				Dim addrRequest As String = MyAppSettings.BaseUrl + "/refinery/logout"
				Dim logout_response = webClient.DownloadString(addrRequest)

			Catch ex As WebException
				Dim webResp As HttpWebResponse = ex.Response
				If webResp Is Nothing Then
					MessageBox.Show(ex.InnerException.Message, ex.Message)
					Throw New BackgroundWorkerException("Logout to FreeREG/2 failed", ex)
				Else
					Console.WriteLine(String.Format("WebException:{0} Desc:{1}", webResp.StatusCode, webResp.StatusDescription))
					Select Case webResp.StatusCode
						Case HttpStatusCode.NotFound

						Case HttpStatusCode.NotAcceptable

						Case HttpStatusCode.InternalServerError

						Case Else

					End Select
					Throw New BackgroundWorkerException("Logout to FreeREG/2 failed", ex)
				End If

			Catch ex As Exception
				Throw New BackgroundWorkerException("Logout to FreeREG/2 failed", ex)
			End Try
		End Using

		Return result
	End Function

#End Region

#Region "Upload File Thread"

	Private Sub backgroundUpload_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundUpload.DoWork
		Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
		e.Result = PerformUpload(e.Argument, worker, e)
	End Sub

	Private Sub backgroundUpload_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundUpload.ProgressChanged
		Application.DoEvents()
	End Sub

	Private Sub backgroundUpload_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundUpload.RunWorkerCompleted
		If (e.Error IsNot Nothing) Then
			Select Case e.Error.GetType.Name
				Case "BackgroundWorkerException"
					HandleUploadBackgroundWorkerException(e.Error)
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
			labelStatus.Text = "Cancelled"
		Else
			' Finally, handle the case where the operation succeeded.
			Dim res As BackgroundResult = CType(e.Result, BackgroundResult)
			Try
				Dim xmlDoc As New XmlDocument()
				xmlDoc.LoadXml(res.Result)
				Dim root As XmlElement = xmlDoc.DocumentElement()
				If root Is Nothing Then
					' No root element
					Throw New BackgroundWorkerException("File Upload failed - Missing root element")
				Else
					If String.Compare(root.Name, "upload", True) = 0 Then
						Dim element As XmlElement = xmlDoc.SelectSingleNode("/upload/result")
						If element Is Nothing Then
							' Missing 'result' node
							Throw New BackgroundWorkerException("File Upload failed - Missing result node")
						Else
							Select Case element.FirstChild.Value
								Case "success"
									Dim message As XmlElement = xmlDoc.SelectSingleNode("/upload/message")
									MessageBox.Show(message.FirstChild.Value, "File Upload", MessageBoxButtons.OK, MessageBoxIcon.Information)

								Case "failure"
									Dim message As XmlElement = xmlDoc.SelectSingleNode("/upload/message")
									MessageBox.Show(message.FirstChild.Value, "File Upload", MessageBoxButtons.OK, MessageBoxIcon.Information)

								Case Else
									' XML Format error
									Throw New BackgroundWorkerException("File Upload failed - XML format error")

							End Select
						End If
					Else
						Throw New BackgroundWorkerException("File Upload failed - Unrecognised response")
					End If
				End If

			Catch ex As BackgroundWorkerException
				Throw

			Catch ex As XmlException
				Throw New BackgroundWorkerException("File Upload failed", ex)

			Catch ex As Exception
				Throw New BackgroundWorkerException("File Upload failed", ex)

			End Try

			' File won't be available immediately as part of the Uploaded Files dataset
			' Therefore needs to be marked as Uploaded but not yet processed
			'
		End If
	End Sub

	Function PerformUpload(ByVal fullname As String, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Object
		Dim result As Object
		Dim fname As String = Path.GetFileName(fullname)

		Try
			Dim query_data = New NameValueCollection()
			query_data.Add("transcriberid", MyAppSettings.UserId)
			query_data.Add("transcriberpassword", MyAppSettings.Password)

			result = HttpUploadFile(MyAppSettings.BaseUrl + "/transreg_csvfiles/upload", fullname, "csvfile[csvfile]", "application/octet-stream", query_data)

		Catch ex As WebException
			Throw New BackgroundWorkerException(String.Format("Upload of {0} to FreeREG/2 failed", fname), ex)

		Catch ex As Exception
			Throw New BackgroundWorkerException(String.Format("Upload of {0} to FreeREG/2 failed", fname), ex)

		End Try

		Return result
	End Function

	Public Function HttpUploadFile(ByVal url As String, ByVal file As String, ByVal paramName As String, ByVal contentType As String, ByVal nvc As NameValueCollection) As Object
		Dim boundary As String = "---------------------------" + DateTime.Now.Ticks.ToString("x")
		Dim boundarybytes As Byte() = System.Text.Encoding.ASCII.GetBytes(vbCrLf + "--" + boundary + vbCrLf)

		Dim wr As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
		wr.ContentType = "multipart/form-data; boundary=" + boundary
		wr.Method = "POST"
		wr.KeepAlive = True
		wr.Credentials = System.Net.CredentialCache.DefaultCredentials
		wr.CookieContainer = MyAppSettings.CookieJar

		Dim rs As Stream = wr.GetRequestStream()

		Dim formdataTemplate As String = "Content-Disposition: form-data; name=""{0}""" + vbCrLf + vbCrLf + "{1}"
		For Each key As String In nvc.Keys
			rs.Write(boundarybytes, 0, boundarybytes.Length)
			Dim formitem As String = String.Format(formdataTemplate, key, nvc(key))
			Dim formitembytes As Byte() = System.Text.Encoding.UTF8.GetBytes(formitem)
			rs.Write(formitembytes, 0, formitembytes.Length)
		Next
		rs.Write(boundarybytes, 0, boundarybytes.Length)

		Dim headerTemplate As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""" + vbCrLf + "Content-Type: {2}" + vbCrLf + vbCrLf
		Dim header As String = String.Format(headerTemplate, paramName, file, contentType)
		Dim headerbytes As Byte() = System.Text.Encoding.UTF8.GetBytes(header)
		rs.Write(headerbytes, 0, headerbytes.Length)

		Dim fileStream As FileStream = New FileStream(file, FileMode.Open, FileAccess.Read)
		Dim buffer(4096) As Byte
		Dim bytesRead As Integer = fileStream.Read(buffer, 0, buffer.Length)
		While (bytesRead <> 0)
			rs.Write(buffer, 0, bytesRead)
			bytesRead = fileStream.Read(buffer, 0, buffer.Length)
		End While
		fileStream.Close()

		Dim trailer As Byte() = System.Text.Encoding.ASCII.GetBytes(vbCrLf + "--" + boundary + "--" + vbCrLf)
		rs.Write(trailer, 0, trailer.Length)
		rs.Close()

		Dim wresp As WebResponse = Nothing
		Try
			wresp = wr.GetResponse()
			Dim stream2 As Stream = wresp.GetResponseStream()
			Dim reader2 As StreamReader = New StreamReader(stream2)
			Dim result As String = reader2.ReadToEnd()

			Dim res As New BackgroundResult()
			res.Parameter = file
			res.Result = result
			Return res

		Catch ex As Exception
			If wresp IsNot Nothing Then
				wresp.Close()
				wresp = Nothing
			End If
			Throw

		Finally
			wr = Nothing
		End Try

	End Function

#End Region

#Region "Replace File Thread"

	Private Sub backgroundReplace_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundReplace.DoWork
		Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
		e.Result = ReplaceFile(e.Argument, worker, e)
	End Sub

	Private Sub backgroundReplace_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundReplace.ProgressChanged
		labelStatus.Text = e.UserState
		Application.DoEvents()
	End Sub

	Private Sub backgroundReplace_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundReplace.RunWorkerCompleted
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
			labelStatus.Text = "Cancelled"
		Else
			' Finally, handle the case where the operation succeeded.
			Dim res As BackgroundResult = CType(e.Result, BackgroundResult)
			Try
				Dim xmlDoc As New XmlDocument()
				xmlDoc.LoadXml(res.Result)
				Dim root As XmlElement = xmlDoc.DocumentElement()
				If root Is Nothing Then
					' No root element
					Throw New BackgroundWorkerException("File Replace failed - Missing root element")
				Else
					If String.Compare(root.Name, "replace", True) = 0 Then
						Dim element As XmlElement = xmlDoc.SelectSingleNode("/replace/result")
						If element Is Nothing Then
							' Missing 'result' node
							Throw New BackgroundWorkerException("File Replace failed - Missing result node")
						Else
							Select Case element.FirstChild.Value
								Case "success"
									Dim message As XmlElement = xmlDoc.SelectSingleNode("/replace/message")
									MessageBox.Show(message.FirstChild.Value, "File Replace", MessageBoxButtons.OK, MessageBoxIcon.Information)

								Case "failure"
									Dim message As XmlElement = xmlDoc.SelectSingleNode("/replace/message")
									MessageBox.Show(message.FirstChild.Value, "File Replace", MessageBoxButtons.OK, MessageBoxIcon.Information)

								Case Else
									' XML Format error
									Throw New BackgroundWorkerException("File Replace failed - XML format error")

							End Select
						End If
					Else
						Throw New BackgroundWorkerException("File Replace failed - Unrecognised response")
					End If
				End If

			Catch ex As BackgroundWorkerException
				Throw

			Catch ex As XmlException
				Throw New BackgroundWorkerException("File Replace failed", ex)

			Catch ex As Exception
				Throw New BackgroundWorkerException("File Replace failed", ex)

			End Try
		End If
	End Sub

	Function ReplaceFile(ByVal fullname As String, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Object
		Dim result As Object
		Dim fname As String = Path.GetFileName(fullname)

		Try
			Dim query_data = New NameValueCollection()
			query_data.Add("transcriberid", MyAppSettings.UserId)
			query_data.Add("transcriberpassword", MyAppSettings.Password)

			result = HttpReplaceFile(MyAppSettings.BaseUrl + "/transreg_csvfiles/replace", fullname, "csvfile[csvfile]", "application/octet-stream", query_data)

		Catch ex As WebException
			Throw New BackgroundWorkerException(String.Format("Replacement of {0} to FreeREG/2 failed", fname), ex)

		Catch ex As Exception
			Throw New BackgroundWorkerException(String.Format("Replacement of {0} to FreeREG/2 failed", fname), ex)

		End Try

		Return result
	End Function

	Public Function HttpReplaceFile(ByVal url As String, ByVal file As String, ByVal paramName As String, ByVal contentType As String, ByVal nvc As NameValueCollection) As Object
		Dim boundary As String = "---------------------------" + DateTime.Now.Ticks.ToString("x")
		Dim boundarybytes As Byte() = System.Text.Encoding.ASCII.GetBytes(vbCrLf + "--" + boundary + vbCrLf)

		Dim wr As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
		wr.ContentType = "multipart/form-data; boundary=" + boundary
		wr.Method = "POST"
		wr.KeepAlive = True
		wr.Credentials = System.Net.CredentialCache.DefaultCredentials
		wr.CookieContainer = MyAppSettings.CookieJar

		Dim rs As Stream = wr.GetRequestStream()

		Dim formdataTemplate As String = "Content-Disposition: form-data; name=""{0}""" + vbCrLf + vbCrLf + "{1}"
		For Each key As String In nvc.Keys
			rs.Write(boundarybytes, 0, boundarybytes.Length)
			Dim formitem As String = String.Format(formdataTemplate, key, nvc(key))
			Dim formitembytes As Byte() = System.Text.Encoding.UTF8.GetBytes(formitem)
			rs.Write(formitembytes, 0, formitembytes.Length)
		Next
		rs.Write(boundarybytes, 0, boundarybytes.Length)

		Dim headerTemplate As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""" + vbCrLf + "Content-Type: {2}" + vbCrLf + vbCrLf
		Dim header As String = String.Format(headerTemplate, paramName, file, contentType)
		Dim headerbytes As Byte() = System.Text.Encoding.UTF8.GetBytes(header)
		rs.Write(headerbytes, 0, headerbytes.Length)

		Dim fileStream As FileStream = New FileStream(file, FileMode.Open, FileAccess.Read)
		Dim buffer(4096) As Byte
		Dim bytesRead As Integer = fileStream.Read(buffer, 0, buffer.Length)
		While (bytesRead <> 0)
			rs.Write(buffer, 0, bytesRead)
			bytesRead = fileStream.Read(buffer, 0, buffer.Length)
		End While
		fileStream.Close()

		Dim trailer As Byte() = System.Text.Encoding.ASCII.GetBytes(vbCrLf + "--" + boundary + "--" + vbCrLf)
		rs.Write(trailer, 0, trailer.Length)
		rs.Close()

		Dim wresp As WebResponse = Nothing
		Try
			wresp = wr.GetResponse()
			Dim stream2 As Stream = wresp.GetResponseStream()
			Dim reader2 As StreamReader = New StreamReader(stream2)
			Dim result As String = reader2.ReadToEnd()

			Dim res As New BackgroundResult()
			res.Parameter = file
			res.Result = result
			Return res

		Catch ex As Exception
			If wresp IsNot Nothing Then
				wresp.Close()
				wresp = Nothing
			End If
			Throw

		Finally
			wr = Nothing
		End Try

	End Function

#End Region

#Region "Delete File Thread"

	Private Sub backgroundDelete_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundDelete.DoWork
		Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
		e.Result = PerformDeleteFile(worker, e)
	End Sub

	Private Sub backgroundDelete_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundDelete.ProgressChanged
		labelStatus.Text = e.UserState
		Application.DoEvents()
	End Sub

	Private Sub backgroundDelete_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundDelete.RunWorkerCompleted
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
			labelStatus.Text = "Cancelled"
		Else
			' Finally, handle the case where the operation succeeded.
			Dim res As BackgroundResult = CType(e.Result, BackgroundResult)
			Try
				Dim xmlDoc As New XmlDocument()
				xmlDoc.LoadXml(res.Result)
				Dim root As XmlElement = xmlDoc.DocumentElement()
				If root Is Nothing Then
					' No root element
					Throw New BackgroundWorkerException("File Delete failed - Missing root element")
				Else
					If String.Compare(root.Name, "delete", True) = 0 Then
						Dim element As XmlElement = xmlDoc.SelectSingleNode("/delete/result")
						If element Is Nothing Then
							' Missing 'result' node
							Throw New BackgroundWorkerException("File Delete failed - Missing result node")
						Else
							Select Case element.FirstChild.Value
								Case "success"
									Dim message As XmlElement = xmlDoc.SelectSingleNode("/delete/message")
									MessageBox.Show(message.FirstChild.Value, "File Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

								Case "failure"
									Dim message As XmlElement = xmlDoc.SelectSingleNode("/delete/message")
									MessageBox.Show(message.FirstChild.Value, "File Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

								Case Else
									' XML Format error
									Throw New BackgroundWorkerException("File Delete failed - XML format error")

							End Select
						End If
					Else
						Throw New BackgroundWorkerException("File Delete failed - Unrecognised response")
					End If
				End If

			Catch ex As BackgroundWorkerException
				Throw

			Catch ex As XmlException
				Throw New BackgroundWorkerException("File Delete failed", ex)

			Catch ex As Exception
				Throw New BackgroundWorkerException("File Delete failed", ex)

			End Try

			' Remove the deleted file from the batches dataset
			'
			Dim dv As New DataView(BatchesDataSet.Batch, String.Format("ID='{0}'", res.Parameter), "ID", DataViewRowState.CurrentRows)
			Dim drv As DataRowView() = dv.FindRows(res.Parameter)
			BatchesDataSet.Batch.RemoveBatchRow(drv(0).Row)
			BatchesDataSet.Batch.AcceptChanges()
         BatchesDataSet.WriteXml(Path.Combine(AppDataLocalFolder, String.Format("{0} batches.xml", MyAppSettings.UserId)), XmlWriteMode.WriteSchema)

			' Refresh the user profile
			'
			Refreshtranscriber()

		End If
	End Sub

	Function PerformDeleteFile(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Object

		Using webClient As New CookieAwareWebClient()
			Try
				webClient.SetTimeout(30000)
				webClient.CookieContainer = MyAppSettings.CookieJar
				Dim addrRequest As String = MyAppSettings.BaseUrl + "/transreg_csvfiles/delete.xml"
				Dim query_data = New NameValueCollection()
				query_data.Add("transcriberid", MyAppSettings.UserId)
				query_data.Add("transcriberpassword", MyAppSettings.Password)
				query_data.Add("id", e.Argument)
				webClient.QueryString = query_data
				Dim contents As String = webClient.DownloadString(addrRequest)

				Dim res As New BackgroundResult()
				res.Parameter = e.Argument
				res.Result = contents
				Return res

			Catch ex As XmlException
				Throw New BackgroundWorkerException("Deleting File from FreeREG/2 failed", ex)

			Catch ex As WebException
				Dim webResp As HttpWebResponse = ex.Response
				If webResp Is Nothing Then
					Throw New BackgroundWorkerException("Deleting File from FreeREG/2 failed", ex)
				Else
					Console.WriteLine(String.Format("WebException:{0} Desc:{1}", webResp.StatusCode, webResp.StatusDescription))
					Select Case webResp.StatusCode
						Case HttpStatusCode.NotFound

						Case HttpStatusCode.NotAcceptable

						Case HttpStatusCode.InternalServerError

						Case Else

					End Select
					Throw New BackgroundWorkerException("Deleting File from FreeREG/2 failed", ex)
				End If

			Catch ex As Exception
				Throw

			End Try

		End Using

	End Function

#End Region

#Region "Get User Batches Background Thread"

	Private Sub backgroundBatches_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundBatches.DoWork
		Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
		e.Result = GetBatches(worker, e)
	End Sub

	Private Sub backgroundBatches_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundBatches.ProgressChanged
		labelStatus.Text = e.UserState
		Application.DoEvents()
	End Sub

	Private Sub backgroundBatches_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundBatches.RunWorkerCompleted
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
			labelStatus.Text = "Cancelled"
		Else
			' Finally, handle the case where the operation succeeded.
			SplitContainer1.Visible = True
			SplitContainer2.Visible = False
			SplitContainer3.Visible = True
			panelUploadedFiles.Visible = True

			If olvcFilename.AspectToStringConverter Is Nothing Then olvcFilename.AspectToStringConverter = New AspectToStringConverterDelegate(AddressOf BatchName)

			BatchBindingSource.DataSource = BatchesDataSet
			BatchBindingSource.DataMember = "Batch"
			bnavShowData.BindingSource = BatchBindingSource
			bnavShowData.Visible = True
			dlvUploadedFiles.Visible = True
			labelStatus.Text = ""
			dlvUploadedFiles.RebuildColumns()
		End If
	End Sub

	Private Function BatchName(ByVal objValue As String) As String
		Dim x = objValue.IndexOf("."c)
		Return objValue.Substring(0, objValue.IndexOf("."c))
	End Function

	Function GetBatches(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Long
		Dim result As Long = 0

		worker.ReportProgress(0, String.Format("Fetching batches from FreeREG/2 for {0}...", MyAppSettings.UserId))

		Using webClient As New CookieAwareWebClient()
			Try
				webClient.SetTimeout(30000)
				webClient.CookieContainer = MyAppSettings.CookieJar
				Dim addrRequest As String = MyAppSettings.BaseUrl + "/transreg_batches/list.xml"
				Dim query_data = New NameValueCollection()
				query_data.Add("transcriber", MyAppSettings.UserId)
				webClient.QueryString = query_data
				Dim contents As String = webClient.DownloadString(addrRequest)

				If contents.StartsWith("<BatchesTable>") Then
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

					BatchesDataSet.Clear()
					If ds.Tables("Batch") IsNot Nothing Then
						For Each row As DataRow In ds.Tables("Batch").Rows
							BatchesDataSet.Batch.AddBatchRow(row.Item("ID"), row.Item("CountyName"), row.Item("PlaceName"), row.Item("ChurchName"), row.Item("RegisterType"), _
							 row.Item("RecordType"), row.Item("Records"), row.Item("DateMin"), row.Item("DateMax"), row.Item("DateRange"), row.Item("UserId"), _
							 row.Item("UserIdLowerCase"), row.Item("FileName"), row.Item("TranscriberName"), row.Item("TranscriberEmail"), row.Item("TranscriberSyndicate"), _
							 row.Item("CreditEmail"), row.Item("CreditName"), row.Item("FirstComment"), row.Item("SecondComment"), row.Item("TranscriptionDate"), _
							 row.Item("ModificationDate"), row.Item("UploadedDate"), row.Item("Error"), row.Item("Digest"), row.Item("LockedByTranscriber"), _
							 row.Item("LockedByCoordinator"), row.Item("lds"), row.Item("Action"), row.Item("CharacterSet"), row.Item("AlternateRegisterName"), _
							 row.Item("CsvFile"))
						Next
					End If
					BatchesDataSet.AcceptChanges()
               BatchesDataSet.WriteXml(Path.Combine(AppDataLocalFolder, String.Format("{0} batches.xml", MyAppSettings.UserId)), XmlWriteMode.WriteSchema)
					worker.ReportProgress(100, String.Format("Batches fetched from FreeREG/2 for {0}", MyAppSettings.UserId))
				Else
					Throw New BackgroundWorkerException("Getting Batch Details from FreeREG/2 failed - Not logged on")
				End If

			Catch ex As XmlException
				Throw New BackgroundWorkerException("Getting Batch Details from FreeREG/2 failed", ex)

			Catch ex As WebException
				Dim webResp As HttpWebResponse = ex.Response
				If webResp Is Nothing Then
					Throw New BackgroundWorkerException("Getting Batch Details from FreeREG/2 failed", ex)
				Else
					Console.WriteLine(String.Format("WebException:{0} Desc:{1}", webResp.StatusCode, webResp.StatusDescription))
					Select Case webResp.StatusCode
						Case HttpStatusCode.NotFound

						Case HttpStatusCode.NotAcceptable

						Case HttpStatusCode.InternalServerError

						Case Else

					End Select
					Throw New BackgroundWorkerException("Getting Batch Details from FreeREG/2 failed", ex)
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

	Private Sub BatchBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BatchBindingSource.CurrentChanged
		Dim currentBatch As Batches.BatchRow = BatchBindingSource.Current.Row
	End Sub

	Private Sub BatchBindingSource_CurrentItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BatchBindingSource.CurrentItemChanged
		Dim currentBatch As Batches.BatchRow = BatchBindingSource.Current.Row
	End Sub

#Region "Button Click Handlers"

	Private Sub btnViewContents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewContents.Click
		Dim currentBatch As Batches.BatchRow = BatchBindingSource.Current.Row

		Using webClient As New CookieAwareWebClient()
			Try
				webClient.SetTimeout(30000)
				webClient.CookieContainer = MyAppSettings.CookieJar
				Dim addrRequest As String = MyAppSettings.BaseUrl + "/transreg_batches/download.xml"
				Dim query_data = New NameValueCollection()
				query_data.Add("transcriber", MyAppSettings.UserId)
				query_data.Add("id", currentBatch.ID)
				webClient.QueryString = query_data
				Dim contents As String = webClient.DownloadString(addrRequest)

				If contents.StartsWith("+INFO") Then
               Using dlg As New formBatchContents() With {.PersonalPath = _myTranscriptionLibrary, .CurrentBatch = currentBatch, .Text = String.Format("Batch Contents - {0}", currentBatch.FileName)}
                  dlg.FileContentsTextBox.Text = contents
                  dlg.ShowDialog()
               End Using
				Else
					Dim xmlDoc As New XmlDocument()
					xmlDoc.LoadXml(contents)
					Dim root As XmlElement = xmlDoc.DocumentElement()
					If root Is Nothing Then
						' No root element
						Throw New BackgroundWorkerException("View Contents failed - Missing root element")
					Else
						If String.Compare(root.Name, "download", True) = 0 Then
							Dim element As XmlElement = xmlDoc.SelectSingleNode("/download/result")
							If element Is Nothing Then
								' Missing 'result' node
								Throw New BackgroundWorkerException("View Contents failed - Missing result node")
							Else
								Select Case element.FirstChild.Value
									Case "failure"
										Dim message As XmlElement = xmlDoc.SelectSingleNode("download/message")
										MessageBox.Show(message.FirstChild.Value, "View Batch Contents", MessageBoxButtons.OK, MessageBoxIcon.Warning)

									Case Else
										' XML Format error
										Throw New BackgroundWorkerException("View Contents - XML format error")

								End Select
							End If
						Else
							Throw New BackgroundWorkerException("View Contents - Unrecognised response")
						End If
					End If

				End If

			Catch ex As XmlException
				HandleXmlException(ex)

			Catch ex As WebException
				Dim ex1 As New BackgroundWorkerException("Download Batch Contents", ex)
				HandleBackgroundWorkerException(ex1)

			Catch ex As Exception
				HandleException(ex)

			End Try
		End Using
	End Sub

	Private Sub btnDeleteFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteFile.Click
		Dim currentBatch As Batches.BatchRow = BatchBindingSource.Current.Row

		Try
			backgroundDelete.RunWorkerAsync(currentBatch.ID)

		Catch ex As Exception

		End Try
	End Sub

	Private Sub btnUploadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadFile.Click
		Dim olvItem As OLVListItem = dlvLocalFiles.SelectedItem
		Dim dbi As DataRowView = CType(olvItem.RowObject, DataRowView)
		Dim row As DataRow = dbi.Row

		Try
			backgroundUpload.RunWorkerAsync(row("FullName"))

		Catch ex As Exception

		End Try
	End Sub

	Private Sub btnReplaceFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplaceFile.Click
		Dim olvItem As OLVListItem = dlvLocalFiles.SelectedItem
		Dim dbi As DataRowView = CType(olvItem.RowObject, DataRowView)
		Dim row As DataRow = dbi.Row

		Try
			backgroundReplace.RunWorkerAsync(row("FullName"))

		Catch ex As Exception

		End Try
	End Sub

#End Region

	Private Sub dlvLocalFiles_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dlvLocalFiles.ItemActivate
		Dim row As DataRow = dlvLocalFiles.SelectedObject().Row
      Using dlg As New formFileWorkspace With {.TranscriptionFile = New TranscriptionFileClass(row, LookUpsDataSet, TablesDataSet), .SelectedRow = row, .BaseDirectory = AppDataLocalFolder, .ErrorMessageTable = ErrorMessagesDataSet.Tables("ErrorMessages")}
         Try
            Dim rc = dlg.ShowDialog()
            If rc = Windows.Forms.DialogResult.OK Then
               If File.Exists(dlg.TranscriptionFile.FullFileName) Then
                  ' File has been edited
                  ' Details need to be updated in the table
                  Dim fi As FileInfo = New System.IO.FileInfo(dlg.TranscriptionFile.FullFileName)
                  row("Attributes") = fi.Attributes
                  row("IsReadOnly") = fi.IsReadOnly
                  row("LastAccessTime") = fi.LastAccessTime
                  row("LastAccessTimeUtc") = fi.LastAccessTimeUtc
                  row("LastWriteTime") = fi.LastWriteTime
                  row("LastWriteTimeUtc") = fi.LastWriteTimeUtc
                  row("Length") = fi.Length
               End If
            End If

         Catch ex As Exception
            Beep()

         Finally

         End Try
      End Using
	End Sub

	Private Sub dlvLocalFiles_CellToolTipShowing(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.ToolTipShowingEventArgs) Handles dlvLocalFiles.CellToolTipShowing
		If e.ModifierKeys = Keys.Control Then
			If e.Column.Name = "Name" Then
				Dim tfile As New TranscriptionFileClass(CType(e.Model, DataRowView).Row, LookUpsDataSet, TablesDataSet)
				e.BackColor = Color.Bisque
				e.IsBalloon = True
				e.StandardIcon = ToolTipControl.StandardIcons.InfoLarge
				e.Title = tfile.FileName
				e.Text = tfile.FileHeader.Place + vbCrLf + tfile.FileHeader.Church + vbCrLf _
				 + tfile.FileHeader.Comment1 + vbCrLf + tfile.FileHeader.Comment2 + vbCrLf + vbCrLf _
				 + String.Format("File size: {0} records", tfile.Items.Rows.Count)
			End If
		End If
	End Sub

	Private Sub btnNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewFile.Click
      Using dlg As New formStartNewFile With {.Username = _myUserName, .EmailAddress = _myEmailAddress, .dsFreeRegTables = TablesDataSet, .dsLookupTables = LookUpsDataSet, .DefaultCounty = _myDefaultCounty, .TranscriptionLibrary = _myTranscriptionLibrary}
         Try
            Dim rc = dlg.ShowDialog()
            If rc = Windows.Forms.DialogResult.OK Then
               If File.Exists(dlg.NewTranscriptionFile.FullFileName) Then
                  ' File has been created
                  ' Needs to be added to the table of files
                  Dim fi As FileInfo = New System.IO.FileInfo(dlg.NewTranscriptionFile.FullFileName)
                  Dim tableLocalFiles As DataTable = bsrcLocalFiles.DataSource
                  Dim type As Type = GetType(System.IO.FileInfo)
                  Dim properties = type.GetProperties()

                  Dim values As Object() = New Object(properties.Length - 1) {}
                  Dim i As Integer = 0
                  While i < properties.Length
                     values(i) = properties(i).GetValue(fi, Nothing)
                     System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
                  End While
                  tableLocalFiles.Rows.Add(values)
               End If
            End If
            If dlg.TablesUpdated Then TablesDataSet.WriteXml(FreeregTablesFile, XmlWriteMode.WriteSchema)

         Catch ex As Exception
            Beep()

         End Try
      End Using
	End Sub

End Class
