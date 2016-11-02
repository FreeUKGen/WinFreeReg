'	$Date: 2016-04-13 10:34:32 +0200 (Wed, 13 Apr 2016) $
'	$Rev: 542 $
'	$Id: FreeREG2Browser.vb 542 2016-04-13 08:34:32Z Mikefry $
'
'	WinFreeReg
'

' Waffle Board story - 985 -
'
' TODO:  1. The Fiche and the Image information does not automatically insert itself from last record
' TODO:  2. Don't like that it doesn't enter Register increment automatically
' TODO:  3. Not having a working down arrow to open next line is a draw back
' TODO:  4. When a new line is opened, the first cell is not active, so you have to double-click with mouse, which is a pain.
' TODO:  5. The edit box is small making it difficult to see what you are entering - especially in the Notes
' DONE:  6. Don't like removal of colour backgrounds, the pink was always a reminder to save
' TODO:  7. Capital letters are only possible on the first word in Notes. For example a name will appear as thomas bowker if within a note
' TODO:  8. I am used to saving with Ctrl S every few records. Don't think that works with this program so have to click on the save icon.
' DONE:  9. As an older person with poor sight I would  prefer larger text if that was possible.
' DONE: 10. At the end of a file I always sort by date to make sure the date range is sensible and no obvious year typos.  Now however the date column sorts by day then month then year so not a lot of help to spot an error.
' TODO: 11. If you have made an error and not changed say 'Image Nr' over several entries, I would normally type in first cell correct number and CTL C and CTL V to change several cells at once, can't do in latest.
' TODO: 12. Automatically backup existing file as editing begins, to provide a recovery position if required.
' TODO: 13. Add a "Save As" option that permits the current file to be saved somewhere different to where it was read from
' TODO: 14. Replicate dates from previous record to give a starting point for the new record

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
Imports System.Threading
Imports Microsoft.VisualBasic.FileIO

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
   Private PgmAppDataLocalFolder As String = AppDataLocalFolder
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
   Public ToolTipsFile As String = Path.Combine(AppDataLocalFolder, "ToolTips.xml")

   Public TranscriberProfileFile As String
   Public FreeregTablesFile As String
   Public LookupTablesFile As String

   Private formHelp As New formGeneralHelp() With {.Visible = False}

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
   Friend WithEvents LdsCheckBox As System.Windows.Forms.CheckBox
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
         If _myUrl = "https://test3.freereg.org.uk" Then
            PgmAppDataLocalFolder = Path.Combine(AppDataLocalFolder, "test")
         End If
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
   Friend WithEvents FileListProgressBar As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents miGeneralHelp As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents localContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents OpenWithNotepadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents DeleteFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
   Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents RenameFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UserOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

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
      Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.UserOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.miTranscriptions = New System.Windows.Forms.ToolStripMenuItem()
      Me.miLocalFiles = New System.Windows.Forms.ToolStripMenuItem()
      Me.miUploadedFiles = New System.Windows.Forms.ToolStripMenuItem()
      Me.miTranscriptionData = New System.Windows.Forms.ToolStripMenuItem()
      Me.miFreeREG2Tables = New System.Windows.Forms.ToolStripMenuItem()
      Me.miUserTables = New System.Windows.Forms.ToolStripMenuItem()
      Me.miGeneralHelp = New System.Windows.Forms.ToolStripMenuItem()
      Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.BrowserStatusStrip = New System.Windows.Forms.StatusStrip()
      Me.labelStatus = New System.Windows.Forms.ToolStripStatusLabel()
      Me.FileListProgressBar = New System.Windows.Forms.ToolStripProgressBar()
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
      Me.LdsCheckBox = New System.Windows.Forms.CheckBox()
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
      Me.localContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.OpenWithNotepadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.RenameFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.DeleteFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
      Me.CheckBox1 = New System.Windows.Forms.CheckBox()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.FreeregTablesDataSet = New WinFreeReg.FreeregTables()
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
      Me.localContextMenuStrip.SuspendLayout()
      Me.TableLayoutPanel1.SuspendLayout()
      CType(Me.FreeregTablesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'IDLabel
      '
      IDLabel.AutoSize = True
      IDLabel.Location = New System.Drawing.Point(26, 10)
      IDLabel.Name = "IDLabel"
      IDLabel.Size = New System.Drawing.Size(21, 13)
      IDLabel.TabIndex = 65
      IDLabel.Text = "ID:"
      IDLabel.Visible = False
      '
      'CountyNameLabel
      '
      CountyNameLabel.AutoSize = True
      CountyNameLabel.Location = New System.Drawing.Point(26, 36)
      CountyNameLabel.Name = "CountyNameLabel"
      CountyNameLabel.Size = New System.Drawing.Size(74, 13)
      CountyNameLabel.TabIndex = 67
      CountyNameLabel.Text = "County Name:"
      '
      'PlaceNameLabel
      '
      PlaceNameLabel.AutoSize = True
      PlaceNameLabel.Location = New System.Drawing.Point(26, 62)
      PlaceNameLabel.Name = "PlaceNameLabel"
      PlaceNameLabel.Size = New System.Drawing.Size(68, 13)
      PlaceNameLabel.TabIndex = 69
      PlaceNameLabel.Text = "Place Name:"
      '
      'ChurchNameLabel
      '
      ChurchNameLabel.AutoSize = True
      ChurchNameLabel.Location = New System.Drawing.Point(26, 88)
      ChurchNameLabel.Name = "ChurchNameLabel"
      ChurchNameLabel.Size = New System.Drawing.Size(75, 13)
      ChurchNameLabel.TabIndex = 71
      ChurchNameLabel.Text = "Church Name:"
      '
      'RegisterTypeLabel
      '
      RegisterTypeLabel.AutoSize = True
      RegisterTypeLabel.Location = New System.Drawing.Point(26, 114)
      RegisterTypeLabel.Name = "RegisterTypeLabel"
      RegisterTypeLabel.Size = New System.Drawing.Size(76, 13)
      RegisterTypeLabel.TabIndex = 73
      RegisterTypeLabel.Text = "Register Type:"
      '
      'RecordTypeLabel
      '
      RecordTypeLabel.AutoSize = True
      RecordTypeLabel.Location = New System.Drawing.Point(26, 140)
      RecordTypeLabel.Name = "RecordTypeLabel"
      RecordTypeLabel.Size = New System.Drawing.Size(72, 13)
      RecordTypeLabel.TabIndex = 75
      RecordTypeLabel.Text = "Record Type:"
      '
      'RecordsLabel
      '
      RecordsLabel.AutoSize = True
      RecordsLabel.Location = New System.Drawing.Point(26, 166)
      RecordsLabel.Name = "RecordsLabel"
      RecordsLabel.Size = New System.Drawing.Size(50, 13)
      RecordsLabel.TabIndex = 77
      RecordsLabel.Text = "Records:"
      '
      'DateMinLabel
      '
      DateMinLabel.AutoSize = True
      DateMinLabel.Location = New System.Drawing.Point(26, 192)
      DateMinLabel.Name = "DateMinLabel"
      DateMinLabel.Size = New System.Drawing.Size(53, 13)
      DateMinLabel.TabIndex = 79
      DateMinLabel.Text = "Date Min:"
      '
      'DateMaxLabel
      '
      DateMaxLabel.AutoSize = True
      DateMaxLabel.Location = New System.Drawing.Point(26, 218)
      DateMaxLabel.Name = "DateMaxLabel"
      DateMaxLabel.Size = New System.Drawing.Size(56, 13)
      DateMaxLabel.TabIndex = 81
      DateMaxLabel.Text = "Date Max:"
      '
      'DateRangeLabel
      '
      DateRangeLabel.AutoSize = True
      DateRangeLabel.Location = New System.Drawing.Point(26, 244)
      DateRangeLabel.Name = "DateRangeLabel"
      DateRangeLabel.Size = New System.Drawing.Size(68, 13)
      DateRangeLabel.TabIndex = 83
      DateRangeLabel.Text = "Date Range:"
      '
      'UserIdLabel
      '
      UserIdLabel.AutoSize = True
      UserIdLabel.Location = New System.Drawing.Point(26, 270)
      UserIdLabel.Name = "UserIdLabel"
      UserIdLabel.Size = New System.Drawing.Size(44, 13)
      UserIdLabel.TabIndex = 85
      UserIdLabel.Text = "User Id:"
      '
      'UserIdLowerCaseLabel
      '
      UserIdLowerCaseLabel.AutoSize = True
      UserIdLowerCaseLabel.Location = New System.Drawing.Point(26, 296)
      UserIdLowerCaseLabel.Name = "UserIdLowerCaseLabel"
      UserIdLowerCaseLabel.Size = New System.Drawing.Size(103, 13)
      UserIdLowerCaseLabel.TabIndex = 87
      UserIdLowerCaseLabel.Text = "User Id Lower Case:"
      UserIdLowerCaseLabel.Visible = False
      '
      'FileNameLabel
      '
      FileNameLabel.AutoSize = True
      FileNameLabel.Location = New System.Drawing.Point(26, 322)
      FileNameLabel.Name = "FileNameLabel"
      FileNameLabel.Size = New System.Drawing.Size(57, 13)
      FileNameLabel.TabIndex = 89
      FileNameLabel.Text = "File Name:"
      '
      'TranscriberNameLabel
      '
      TranscriberNameLabel.AutoSize = True
      TranscriberNameLabel.Location = New System.Drawing.Point(26, 348)
      TranscriberNameLabel.Name = "TranscriberNameLabel"
      TranscriberNameLabel.Size = New System.Drawing.Size(94, 13)
      TranscriberNameLabel.TabIndex = 91
      TranscriberNameLabel.Text = "Transcriber Name:"
      '
      'TranscriberEmailLabel
      '
      TranscriberEmailLabel.AutoSize = True
      TranscriberEmailLabel.Location = New System.Drawing.Point(26, 374)
      TranscriberEmailLabel.Name = "TranscriberEmailLabel"
      TranscriberEmailLabel.Size = New System.Drawing.Size(91, 13)
      TranscriberEmailLabel.TabIndex = 93
      TranscriberEmailLabel.Text = "Transcriber Email:"
      '
      'TranscriberSyndicateLabel
      '
      TranscriberSyndicateLabel.AutoSize = True
      TranscriberSyndicateLabel.Location = New System.Drawing.Point(26, 400)
      TranscriberSyndicateLabel.Name = "TranscriberSyndicateLabel"
      TranscriberSyndicateLabel.Size = New System.Drawing.Size(113, 13)
      TranscriberSyndicateLabel.TabIndex = 95
      TranscriberSyndicateLabel.Text = "Transcriber Syndicate:"
      '
      'CreditEmailLabel
      '
      CreditEmailLabel.AutoSize = True
      CreditEmailLabel.Location = New System.Drawing.Point(382, 10)
      CreditEmailLabel.Name = "CreditEmailLabel"
      CreditEmailLabel.Size = New System.Drawing.Size(65, 13)
      CreditEmailLabel.TabIndex = 97
      CreditEmailLabel.Text = "Credit Email:"
      '
      'CreditNameLabel
      '
      CreditNameLabel.AutoSize = True
      CreditNameLabel.Location = New System.Drawing.Point(382, 36)
      CreditNameLabel.Name = "CreditNameLabel"
      CreditNameLabel.Size = New System.Drawing.Size(68, 13)
      CreditNameLabel.TabIndex = 99
      CreditNameLabel.Text = "Credit Name:"
      '
      'FirstCommentLabel
      '
      FirstCommentLabel.AutoSize = True
      FirstCommentLabel.Location = New System.Drawing.Point(382, 62)
      FirstCommentLabel.Name = "FirstCommentLabel"
      FirstCommentLabel.Size = New System.Drawing.Size(76, 13)
      FirstCommentLabel.TabIndex = 101
      FirstCommentLabel.Text = "First Comment:"
      '
      'SecondCommentLabel
      '
      SecondCommentLabel.AutoSize = True
      SecondCommentLabel.Location = New System.Drawing.Point(382, 88)
      SecondCommentLabel.Name = "SecondCommentLabel"
      SecondCommentLabel.Size = New System.Drawing.Size(94, 13)
      SecondCommentLabel.TabIndex = 103
      SecondCommentLabel.Text = "Second Comment:"
      '
      'TranscriptionDateLabel
      '
      TranscriptionDateLabel.AutoSize = True
      TranscriptionDateLabel.Location = New System.Drawing.Point(382, 114)
      TranscriptionDateLabel.Name = "TranscriptionDateLabel"
      TranscriptionDateLabel.Size = New System.Drawing.Size(97, 13)
      TranscriptionDateLabel.TabIndex = 105
      TranscriptionDateLabel.Text = "Transcription Date:"
      '
      'ModificationDateLabel
      '
      ModificationDateLabel.AutoSize = True
      ModificationDateLabel.Location = New System.Drawing.Point(382, 140)
      ModificationDateLabel.Name = "ModificationDateLabel"
      ModificationDateLabel.Size = New System.Drawing.Size(93, 13)
      ModificationDateLabel.TabIndex = 107
      ModificationDateLabel.Text = "Modification Date:"
      '
      'UploadedDateLabel
      '
      UploadedDateLabel.AutoSize = True
      UploadedDateLabel.Location = New System.Drawing.Point(382, 166)
      UploadedDateLabel.Name = "UploadedDateLabel"
      UploadedDateLabel.Size = New System.Drawing.Size(82, 13)
      UploadedDateLabel.TabIndex = 109
      UploadedDateLabel.Text = "Uploaded Date:"
      '
      'ErrorLabel
      '
      ErrorLabel.AutoSize = True
      ErrorLabel.Location = New System.Drawing.Point(382, 192)
      ErrorLabel.Name = "ErrorLabel"
      ErrorLabel.Size = New System.Drawing.Size(32, 13)
      ErrorLabel.TabIndex = 111
      ErrorLabel.Text = "Error:"
      '
      'DigestLabel
      '
      DigestLabel.AutoSize = True
      DigestLabel.Location = New System.Drawing.Point(382, 218)
      DigestLabel.Name = "DigestLabel"
      DigestLabel.Size = New System.Drawing.Size(40, 13)
      DigestLabel.TabIndex = 113
      DigestLabel.Text = "Digest:"
      DigestLabel.Visible = False
      '
      'ActionLabel
      '
      ActionLabel.AutoSize = True
      ActionLabel.Location = New System.Drawing.Point(382, 330)
      ActionLabel.Name = "ActionLabel"
      ActionLabel.Size = New System.Drawing.Size(40, 13)
      ActionLabel.TabIndex = 121
      ActionLabel.Text = "Action:"
      '
      'CharacterSetLabel
      '
      CharacterSetLabel.AutoSize = True
      CharacterSetLabel.Location = New System.Drawing.Point(382, 356)
      CharacterSetLabel.Name = "CharacterSetLabel"
      CharacterSetLabel.Size = New System.Drawing.Size(75, 13)
      CharacterSetLabel.TabIndex = 123
      CharacterSetLabel.Text = "Character Set:"
      '
      'AlternateRegisterNameLabel
      '
      AlternateRegisterNameLabel.AutoSize = True
      AlternateRegisterNameLabel.Location = New System.Drawing.Point(382, 382)
      AlternateRegisterNameLabel.Name = "AlternateRegisterNameLabel"
      AlternateRegisterNameLabel.Size = New System.Drawing.Size(125, 13)
      AlternateRegisterNameLabel.TabIndex = 125
      AlternateRegisterNameLabel.Text = "Alternate Register Name:"
      '
      'CsvFileLabel
      '
      CsvFileLabel.AutoSize = True
      CsvFileLabel.Location = New System.Drawing.Point(382, 408)
      CsvFileLabel.Name = "CsvFileLabel"
      CsvFileLabel.Size = New System.Drawing.Size(47, 13)
      CsvFileLabel.TabIndex = 127
      CsvFileLabel.Text = "Csv File:"
      '
      'BrowserMenuStrip
      '
      Me.BrowserMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miFreeREG, Me.OptionsToolStripMenuItem, Me.miTranscriptions, Me.miTranscriptionData, Me.miGeneralHelp, Me.AboutToolStripMenuItem})
      Me.BrowserMenuStrip.Location = New System.Drawing.Point(0, 0)
      Me.BrowserMenuStrip.Name = "BrowserMenuStrip"
      Me.BrowserMenuStrip.Size = New System.Drawing.Size(903, 24)
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
      Me.miLogin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.miLogin.Name = "miLogin"
      Me.miLogin.Size = New System.Drawing.Size(155, 22)
      Me.miLogin.Text = "Log on ..."
      Me.miLogin.ToolTipText = "Log on to FreeREG"
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
      Me.miUserProfile.AutoToolTip = True
      Me.miUserProfile.Name = "miUserProfile"
      Me.miUserProfile.Size = New System.Drawing.Size(155, 22)
      Me.miUserProfile.Text = "User Profile ..."
      Me.miUserProfile.ToolTipText = "Display your User Profile"
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
      Me.miNetworkTrace.Enabled = False
      Me.miNetworkTrace.Name = "miNetworkTrace"
      Me.miNetworkTrace.Size = New System.Drawing.Size(155, 22)
      Me.miNetworkTrace.Text = "Network Trace?"
      Me.miNetworkTrace.Visible = False
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(152, 6)
      Me.ToolStripSeparator3.Visible = False
      '
      'miExit
      '
      Me.miExit.Name = "miExit"
      Me.miExit.Size = New System.Drawing.Size(155, 22)
      Me.miExit.Text = "Exit"
      '
      'OptionsToolStripMenuItem
      '
      Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserOptionsToolStripMenuItem})
      Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
      Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
      Me.OptionsToolStripMenuItem.Text = "Options"
      '
      'UserOptionsToolStripMenuItem
      '
      Me.UserOptionsToolStripMenuItem.Name = "UserOptionsToolStripMenuItem"
      Me.UserOptionsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.UserOptionsToolStripMenuItem.Text = "User options"
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
      Me.miFreeREG2Tables.Size = New System.Drawing.Size(153, 22)
      Me.miFreeREG2Tables.Text = "FreeREG Tables"
      '
      'miUserTables
      '
      Me.miUserTables.Name = "miUserTables"
      Me.miUserTables.Size = New System.Drawing.Size(153, 22)
      Me.miUserTables.Text = "User Tables"
      '
      'miGeneralHelp
      '
      Me.miGeneralHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
      Me.miGeneralHelp.Image = Global.WinFreeReg.My.Resources.Resources.help
      Me.miGeneralHelp.Name = "miGeneralHelp"
      Me.miGeneralHelp.ShortcutKeys = System.Windows.Forms.Keys.F1
      Me.miGeneralHelp.Size = New System.Drawing.Size(60, 20)
      Me.miGeneralHelp.Text = "Help"
      '
      'AboutToolStripMenuItem
      '
      Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
      Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
      Me.AboutToolStripMenuItem.Text = "About"
      '
      'BrowserStatusStrip
      '
      Me.BrowserStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelStatus, Me.FileListProgressBar})
      Me.BrowserStatusStrip.Location = New System.Drawing.Point(0, 519)
      Me.BrowserStatusStrip.Name = "BrowserStatusStrip"
      Me.BrowserStatusStrip.Size = New System.Drawing.Size(903, 22)
      Me.BrowserStatusStrip.TabIndex = 1
      Me.BrowserStatusStrip.Text = "StatusStrip1"
      '
      'labelStatus
      '
      Me.labelStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
      Me.labelStatus.Name = "labelStatus"
      Me.labelStatus.Size = New System.Drawing.Size(0, 17)
      '
      'FileListProgressBar
      '
      Me.FileListProgressBar.Name = "FileListProgressBar"
      Me.FileListProgressBar.Size = New System.Drawing.Size(75, 16)
      Me.FileListProgressBar.Visible = False
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
      Me.bnavShowData.Size = New System.Drawing.Size(903, 25)
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
      Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorAddNewItem.Text = "Add new"
      Me.BindingNavigatorAddNewItem.Visible = False
      '
      'BindingNavigatorCountItem
      '
      Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
      Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
      Me.BindingNavigatorCountItem.Text = "of {0}"
      Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
      '
      'BindingNavigatorDeleteItem
      '
      Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
      Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
      Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorDeleteItem.Text = "Delete"
      Me.BindingNavigatorDeleteItem.Visible = False
      '
      'BindingNavigatorMoveFirstItem
      '
      Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
      Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
      Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorMoveFirstItem.Text = "Move first"
      '
      'BindingNavigatorMovePreviousItem
      '
      Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
      Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
      Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
      '
      'BindingNavigatorSeparator
      '
      Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
      Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
      '
      'BindingNavigatorPositionItem
      '
      Me.BindingNavigatorPositionItem.AccessibleName = "Position"
      Me.BindingNavigatorPositionItem.AutoSize = False
      Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
      Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(65, 23)
      Me.BindingNavigatorPositionItem.Text = "0"
      Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
      '
      'BindingNavigatorSeparator1
      '
      Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
      Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      'BindingNavigatorMoveNextItem
      '
      Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
      Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
      Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorMoveNextItem.Text = "Move next"
      '
      'BindingNavigatorMoveLastItem
      '
      Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
      Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
      Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorMoveLastItem.Text = "Move last"
      '
      'BindingNavigatorSeparator2
      '
      Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
      Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
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
      Me.panelUploadedFiles.Controls.Add(Me.LdsCheckBox)
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
      Me.panelUploadedFiles.Name = "panelUploadedFiles"
      Me.panelUploadedFiles.Size = New System.Drawing.Size(752, 460)
      Me.panelUploadedFiles.TabIndex = 5
      '
      'IDTextBox
      '
      Me.IDTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "ID", True))
      Me.IDTextBox.Enabled = False
      Me.IDTextBox.Location = New System.Drawing.Point(157, 7)
      Me.IDTextBox.Name = "IDTextBox"
      Me.IDTextBox.Size = New System.Drawing.Size(203, 20)
      Me.IDTextBox.TabIndex = 66
      Me.IDTextBox.Visible = False
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
      Me.CountyNameTextBox.Enabled = False
      Me.CountyNameTextBox.Location = New System.Drawing.Point(157, 33)
      Me.CountyNameTextBox.Name = "CountyNameTextBox"
      Me.CountyNameTextBox.Size = New System.Drawing.Size(203, 20)
      Me.CountyNameTextBox.TabIndex = 68
      '
      'PlaceNameTextBox
      '
      Me.PlaceNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "PlaceName", True))
      Me.PlaceNameTextBox.Enabled = False
      Me.PlaceNameTextBox.Location = New System.Drawing.Point(157, 59)
      Me.PlaceNameTextBox.Name = "PlaceNameTextBox"
      Me.PlaceNameTextBox.Size = New System.Drawing.Size(203, 20)
      Me.PlaceNameTextBox.TabIndex = 70
      '
      'ChurchNameTextBox
      '
      Me.ChurchNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "ChurchName", True))
      Me.ChurchNameTextBox.Enabled = False
      Me.ChurchNameTextBox.Location = New System.Drawing.Point(157, 85)
      Me.ChurchNameTextBox.Name = "ChurchNameTextBox"
      Me.ChurchNameTextBox.Size = New System.Drawing.Size(203, 20)
      Me.ChurchNameTextBox.TabIndex = 72
      '
      'RegisterTypeTextBox
      '
      Me.RegisterTypeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "RegisterType", True))
      Me.RegisterTypeTextBox.Enabled = False
      Me.RegisterTypeTextBox.Location = New System.Drawing.Point(157, 111)
      Me.RegisterTypeTextBox.Name = "RegisterTypeTextBox"
      Me.RegisterTypeTextBox.Size = New System.Drawing.Size(203, 20)
      Me.RegisterTypeTextBox.TabIndex = 74
      '
      'RecordTypeTextBox
      '
      Me.RecordTypeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "RecordType", True))
      Me.RecordTypeTextBox.Enabled = False
      Me.RecordTypeTextBox.Location = New System.Drawing.Point(157, 137)
      Me.RecordTypeTextBox.Name = "RecordTypeTextBox"
      Me.RecordTypeTextBox.Size = New System.Drawing.Size(203, 20)
      Me.RecordTypeTextBox.TabIndex = 76
      '
      'RecordsTextBox
      '
      Me.RecordsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "Records", True))
      Me.RecordsTextBox.Enabled = False
      Me.RecordsTextBox.Location = New System.Drawing.Point(157, 163)
      Me.RecordsTextBox.Name = "RecordsTextBox"
      Me.RecordsTextBox.Size = New System.Drawing.Size(203, 20)
      Me.RecordsTextBox.TabIndex = 78
      '
      'DateMinTextBox
      '
      Me.DateMinTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "DateMin", True))
      Me.DateMinTextBox.Enabled = False
      Me.DateMinTextBox.Location = New System.Drawing.Point(157, 189)
      Me.DateMinTextBox.Name = "DateMinTextBox"
      Me.DateMinTextBox.Size = New System.Drawing.Size(203, 20)
      Me.DateMinTextBox.TabIndex = 80
      '
      'DateMaxTextBox
      '
      Me.DateMaxTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "DateMax", True))
      Me.DateMaxTextBox.Enabled = False
      Me.DateMaxTextBox.Location = New System.Drawing.Point(157, 215)
      Me.DateMaxTextBox.Name = "DateMaxTextBox"
      Me.DateMaxTextBox.Size = New System.Drawing.Size(203, 20)
      Me.DateMaxTextBox.TabIndex = 82
      '
      'DateRangeTextBox
      '
      Me.DateRangeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "DateRange", True))
      Me.DateRangeTextBox.Enabled = False
      Me.DateRangeTextBox.Location = New System.Drawing.Point(157, 241)
      Me.DateRangeTextBox.Name = "DateRangeTextBox"
      Me.DateRangeTextBox.Size = New System.Drawing.Size(203, 20)
      Me.DateRangeTextBox.TabIndex = 84
      '
      'UserIdTextBox
      '
      Me.UserIdTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "UserId", True))
      Me.UserIdTextBox.Enabled = False
      Me.UserIdTextBox.Location = New System.Drawing.Point(157, 267)
      Me.UserIdTextBox.Name = "UserIdTextBox"
      Me.UserIdTextBox.Size = New System.Drawing.Size(203, 20)
      Me.UserIdTextBox.TabIndex = 86
      '
      'UserIdLowerCaseTextBox
      '
      Me.UserIdLowerCaseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "UserIdLowerCase", True))
      Me.UserIdLowerCaseTextBox.Enabled = False
      Me.UserIdLowerCaseTextBox.Location = New System.Drawing.Point(157, 293)
      Me.UserIdLowerCaseTextBox.Name = "UserIdLowerCaseTextBox"
      Me.UserIdLowerCaseTextBox.Size = New System.Drawing.Size(203, 20)
      Me.UserIdLowerCaseTextBox.TabIndex = 88
      Me.UserIdLowerCaseTextBox.Visible = False
      '
      'FileNameTextBox
      '
      Me.FileNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "FileName", True))
      Me.FileNameTextBox.Enabled = False
      Me.FileNameTextBox.Location = New System.Drawing.Point(157, 319)
      Me.FileNameTextBox.Name = "FileNameTextBox"
      Me.FileNameTextBox.Size = New System.Drawing.Size(203, 20)
      Me.FileNameTextBox.TabIndex = 90
      '
      'TranscriberNameTextBox
      '
      Me.TranscriberNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "TranscriberName", True))
      Me.TranscriberNameTextBox.Enabled = False
      Me.TranscriberNameTextBox.Location = New System.Drawing.Point(157, 345)
      Me.TranscriberNameTextBox.Name = "TranscriberNameTextBox"
      Me.TranscriberNameTextBox.Size = New System.Drawing.Size(203, 20)
      Me.TranscriberNameTextBox.TabIndex = 92
      '
      'TranscriberEmailTextBox
      '
      Me.TranscriberEmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "TranscriberEmail", True))
      Me.TranscriberEmailTextBox.Enabled = False
      Me.TranscriberEmailTextBox.Location = New System.Drawing.Point(157, 371)
      Me.TranscriberEmailTextBox.Name = "TranscriberEmailTextBox"
      Me.TranscriberEmailTextBox.Size = New System.Drawing.Size(203, 20)
      Me.TranscriberEmailTextBox.TabIndex = 94
      '
      'TranscriberSyndicateTextBox
      '
      Me.TranscriberSyndicateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "TranscriberSyndicate", True))
      Me.TranscriberSyndicateTextBox.Enabled = False
      Me.TranscriberSyndicateTextBox.Location = New System.Drawing.Point(157, 397)
      Me.TranscriberSyndicateTextBox.Name = "TranscriberSyndicateTextBox"
      Me.TranscriberSyndicateTextBox.Size = New System.Drawing.Size(203, 20)
      Me.TranscriberSyndicateTextBox.TabIndex = 96
      '
      'CreditEmailTextBox
      '
      Me.CreditEmailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "CreditEmail", True))
      Me.CreditEmailTextBox.Enabled = False
      Me.CreditEmailTextBox.Location = New System.Drawing.Point(513, 7)
      Me.CreditEmailTextBox.Name = "CreditEmailTextBox"
      Me.CreditEmailTextBox.Size = New System.Drawing.Size(203, 20)
      Me.CreditEmailTextBox.TabIndex = 98
      '
      'CreditNameTextBox
      '
      Me.CreditNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "CreditName", True))
      Me.CreditNameTextBox.Enabled = False
      Me.CreditNameTextBox.Location = New System.Drawing.Point(513, 33)
      Me.CreditNameTextBox.Name = "CreditNameTextBox"
      Me.CreditNameTextBox.Size = New System.Drawing.Size(203, 20)
      Me.CreditNameTextBox.TabIndex = 100
      '
      'FirstCommentTextBox
      '
      Me.FirstCommentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "FirstComment", True))
      Me.FirstCommentTextBox.Enabled = False
      Me.FirstCommentTextBox.Location = New System.Drawing.Point(513, 59)
      Me.FirstCommentTextBox.Name = "FirstCommentTextBox"
      Me.FirstCommentTextBox.Size = New System.Drawing.Size(203, 20)
      Me.FirstCommentTextBox.TabIndex = 102
      '
      'SecondCommentTextBox
      '
      Me.SecondCommentTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "SecondComment", True))
      Me.SecondCommentTextBox.Enabled = False
      Me.SecondCommentTextBox.Location = New System.Drawing.Point(513, 85)
      Me.SecondCommentTextBox.Name = "SecondCommentTextBox"
      Me.SecondCommentTextBox.Size = New System.Drawing.Size(203, 20)
      Me.SecondCommentTextBox.TabIndex = 104
      '
      'TranscriptionDateTextBox
      '
      Me.TranscriptionDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "TranscriptionDate", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "f"))
      Me.TranscriptionDateTextBox.Enabled = False
      Me.TranscriptionDateTextBox.Location = New System.Drawing.Point(513, 111)
      Me.TranscriptionDateTextBox.Name = "TranscriptionDateTextBox"
      Me.TranscriptionDateTextBox.Size = New System.Drawing.Size(203, 20)
      Me.TranscriptionDateTextBox.TabIndex = 106
      '
      'ModificationDateTextBox
      '
      Me.ModificationDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "ModificationDate", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "f"))
      Me.ModificationDateTextBox.Enabled = False
      Me.ModificationDateTextBox.Location = New System.Drawing.Point(513, 137)
      Me.ModificationDateTextBox.Name = "ModificationDateTextBox"
      Me.ModificationDateTextBox.Size = New System.Drawing.Size(203, 20)
      Me.ModificationDateTextBox.TabIndex = 108
      '
      'UploadedDateTextBox
      '
      Me.UploadedDateTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "UploadedDate", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, Nothing, "f"))
      Me.UploadedDateTextBox.Enabled = False
      Me.UploadedDateTextBox.Location = New System.Drawing.Point(513, 163)
      Me.UploadedDateTextBox.Name = "UploadedDateTextBox"
      Me.UploadedDateTextBox.Size = New System.Drawing.Size(203, 20)
      Me.UploadedDateTextBox.TabIndex = 110
      '
      'ErrorTextBox
      '
      Me.ErrorTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "Error", True))
      Me.ErrorTextBox.Enabled = False
      Me.ErrorTextBox.Location = New System.Drawing.Point(513, 189)
      Me.ErrorTextBox.Name = "ErrorTextBox"
      Me.ErrorTextBox.Size = New System.Drawing.Size(203, 20)
      Me.ErrorTextBox.TabIndex = 112
      '
      'DigestTextBox
      '
      Me.DigestTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "Digest", True))
      Me.DigestTextBox.Enabled = False
      Me.DigestTextBox.Location = New System.Drawing.Point(513, 215)
      Me.DigestTextBox.Name = "DigestTextBox"
      Me.DigestTextBox.Size = New System.Drawing.Size(203, 20)
      Me.DigestTextBox.TabIndex = 114
      Me.DigestTextBox.Visible = False
      '
      'LockedByTranscriberCheckBox
      '
      Me.LockedByTranscriberCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BatchBindingSource, "LockedByTranscriber", True))
      Me.LockedByTranscriberCheckBox.Enabled = False
      Me.LockedByTranscriberCheckBox.Location = New System.Drawing.Point(513, 241)
      Me.LockedByTranscriberCheckBox.Name = "LockedByTranscriberCheckBox"
      Me.LockedByTranscriberCheckBox.Size = New System.Drawing.Size(130, 24)
      Me.LockedByTranscriberCheckBox.TabIndex = 116
      Me.LockedByTranscriberCheckBox.Text = "Locked by transcriber"
      Me.LockedByTranscriberCheckBox.UseVisualStyleBackColor = True
      '
      'LockedByCoordinatorCheckBox
      '
      Me.LockedByCoordinatorCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BatchBindingSource, "LockedByCoordinator", True))
      Me.LockedByCoordinatorCheckBox.Enabled = False
      Me.LockedByCoordinatorCheckBox.Location = New System.Drawing.Point(513, 272)
      Me.LockedByCoordinatorCheckBox.Name = "LockedByCoordinatorCheckBox"
      Me.LockedByCoordinatorCheckBox.Size = New System.Drawing.Size(138, 24)
      Me.LockedByCoordinatorCheckBox.TabIndex = 118
      Me.LockedByCoordinatorCheckBox.Text = "Locked by Co-ordinator"
      Me.LockedByCoordinatorCheckBox.UseVisualStyleBackColor = True
      '
      'LdsCheckBox
      '
      Me.LdsCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BatchBindingSource, "lds", True))
      Me.LdsCheckBox.Enabled = False
      Me.LdsCheckBox.Location = New System.Drawing.Point(513, 300)
      Me.LdsCheckBox.Name = "LdsCheckBox"
      Me.LdsCheckBox.Size = New System.Drawing.Size(202, 18)
      Me.LdsCheckBox.TabIndex = 120
      Me.LdsCheckBox.Text = "LDS"
      Me.LdsCheckBox.UseVisualStyleBackColor = True
      '
      'ActionTextBox
      '
      Me.ActionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "Action", True))
      Me.ActionTextBox.Enabled = False
      Me.ActionTextBox.Location = New System.Drawing.Point(513, 326)
      Me.ActionTextBox.Name = "ActionTextBox"
      Me.ActionTextBox.Size = New System.Drawing.Size(203, 20)
      Me.ActionTextBox.TabIndex = 122
      '
      'CharacterSetTextBox
      '
      Me.CharacterSetTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "CharacterSet", True))
      Me.CharacterSetTextBox.Enabled = False
      Me.CharacterSetTextBox.Location = New System.Drawing.Point(513, 352)
      Me.CharacterSetTextBox.Name = "CharacterSetTextBox"
      Me.CharacterSetTextBox.Size = New System.Drawing.Size(203, 20)
      Me.CharacterSetTextBox.TabIndex = 124
      '
      'AlternateRegisterNameTextBox
      '
      Me.AlternateRegisterNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "AlternateRegisterName", True))
      Me.AlternateRegisterNameTextBox.Enabled = False
      Me.AlternateRegisterNameTextBox.Location = New System.Drawing.Point(513, 378)
      Me.AlternateRegisterNameTextBox.Name = "AlternateRegisterNameTextBox"
      Me.AlternateRegisterNameTextBox.Size = New System.Drawing.Size(203, 20)
      Me.AlternateRegisterNameTextBox.TabIndex = 126
      '
      'CsvFileTextBox
      '
      Me.CsvFileTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BatchBindingSource, "CsvFile", True))
      Me.CsvFileTextBox.Enabled = False
      Me.CsvFileTextBox.Location = New System.Drawing.Point(513, 404)
      Me.CsvFileTextBox.Name = "CsvFileTextBox"
      Me.CsvFileTextBox.Size = New System.Drawing.Size(203, 20)
      Me.CsvFileTextBox.TabIndex = 128
      '
      'btnDeleteFile
      '
      Me.btnDeleteFile.Location = New System.Drawing.Point(542, 435)
      Me.btnDeleteFile.Name = "btnDeleteFile"
      Me.btnDeleteFile.Size = New System.Drawing.Size(82, 23)
      Me.btnDeleteFile.TabIndex = 65
      Me.btnDeleteFile.Text = "Delete Batch"
      Me.btnDeleteFile.UseVisualStyleBackColor = True
      '
      'btnViewContents
      '
      Me.btnViewContents.Location = New System.Drawing.Point(631, 435)
      Me.btnViewContents.Name = "btnViewContents"
      Me.btnViewContents.Size = New System.Drawing.Size(84, 23)
      Me.btnViewContents.TabIndex = 64
      Me.btnViewContents.Text = "View Contents"
      Me.btnViewContents.UseVisualStyleBackColor = True
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
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
      Me.SplitContainer1.Size = New System.Drawing.Size(903, 495)
      Me.SplitContainer1.SplitterDistance = 32
      Me.SplitContainer1.SplitterWidth = 3
      Me.SplitContainer1.TabIndex = 65
      Me.SplitContainer1.Visible = False
      '
      'SplitContainer2
      '
      Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
      Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
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
      Me.SplitContainer2.Size = New System.Drawing.Size(903, 460)
      Me.SplitContainer2.SplitterDistance = 397
      Me.SplitContainer2.SplitterWidth = 3
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
      Me.dlvLocalFiles.MultiSelect = False
      Me.dlvLocalFiles.Name = "dlvLocalFiles"
      Me.dlvLocalFiles.SelectColumnsOnRightClick = False
      Me.dlvLocalFiles.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
      Me.dlvLocalFiles.ShowCommandMenuOnRightClick = True
      Me.dlvLocalFiles.ShowGroups = False
      Me.dlvLocalFiles.ShowImagesOnSubItems = True
      Me.dlvLocalFiles.ShowItemToolTips = True
      Me.dlvLocalFiles.Size = New System.Drawing.Size(903, 397)
      Me.dlvLocalFiles.SpaceBetweenGroups = 5
      Me.dlvLocalFiles.TabIndex = 4
      Me.dlvLocalFiles.TintSortColumn = True
      Me.dlvLocalFiles.UseAlternatingBackColors = True
      Me.dlvLocalFiles.UseCompatibleStateImageBehavior = False
      Me.dlvLocalFiles.UseSubItemCheckBoxes = True
      Me.dlvLocalFiles.View = System.Windows.Forms.View.Details
      '
      'btnNewFile
      '
      Me.btnNewFile.Location = New System.Drawing.Point(436, 10)
      Me.btnNewFile.Name = "btnNewFile"
      Me.btnNewFile.Size = New System.Drawing.Size(91, 23)
      Me.btnNewFile.TabIndex = 10
      Me.btnNewFile.Text = "Start New File"
      Me.btnNewFile.UseVisualStyleBackColor = True
      '
      'cboxProcess
      '
      Me.cboxProcess.FormattingEnabled = True
      Me.cboxProcess.Location = New System.Drawing.Point(532, 12)
      Me.cboxProcess.MaxDropDownItems = 3
      Me.cboxProcess.Name = "cboxProcess"
      Me.cboxProcess.Size = New System.Drawing.Size(205, 21)
      Me.cboxProcess.TabIndex = 9
      '
      'labFilename
      '
      Me.labFilename.AutoSize = True
      Me.labFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.labFilename.Location = New System.Drawing.Point(89, 13)
      Me.labFilename.Name = "labFilename"
      Me.labFilename.Size = New System.Drawing.Size(0, 20)
      Me.labFilename.TabIndex = 8
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 14)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(71, 13)
      Me.Label1.TabIndex = 7
      Me.Label1.Text = "Selected File:"
      '
      'btnUploadFile
      '
      Me.btnUploadFile.Enabled = False
      Me.btnUploadFile.Location = New System.Drawing.Point(742, 10)
      Me.btnUploadFile.Name = "btnUploadFile"
      Me.btnUploadFile.Size = New System.Drawing.Size(75, 23)
      Me.btnUploadFile.TabIndex = 5
      Me.btnUploadFile.Text = "Upload file"
      Me.btnUploadFile.UseVisualStyleBackColor = True
      '
      'btnReplaceFile
      '
      Me.btnReplaceFile.Enabled = False
      Me.btnReplaceFile.Location = New System.Drawing.Point(824, 10)
      Me.btnReplaceFile.Name = "btnReplaceFile"
      Me.btnReplaceFile.Size = New System.Drawing.Size(75, 23)
      Me.btnReplaceFile.TabIndex = 6
      Me.btnReplaceFile.Text = "Replace file"
      Me.btnReplaceFile.UseVisualStyleBackColor = True
      '
      'SplitContainer3
      '
      Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
      Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer3.Name = "SplitContainer3"
      '
      'SplitContainer3.Panel1
      '
      Me.SplitContainer3.Panel1.Controls.Add(Me.dlvUploadedFiles)
      '
      'SplitContainer3.Panel2
      '
      Me.SplitContainer3.Panel2.Controls.Add(Me.panelUploadedFiles)
      Me.SplitContainer3.Size = New System.Drawing.Size(903, 460)
      Me.SplitContainer3.SplitterDistance = 147
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
      Me.dlvUploadedFiles.MultiSelect = False
      Me.dlvUploadedFiles.Name = "dlvUploadedFiles"
      Me.dlvUploadedFiles.ShowCommandMenuOnRightClick = True
      Me.dlvUploadedFiles.Size = New System.Drawing.Size(147, 460)
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
      'localContextMenuStrip
      '
      Me.localContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenWithNotepadToolStripMenuItem, Me.RenameFileToolStripMenuItem, Me.DeleteFileToolStripMenuItem})
      Me.localContextMenuStrip.Name = "localContextMenuStrip"
      Me.localContextMenuStrip.Size = New System.Drawing.Size(164, 70)
      '
      'OpenWithNotepadToolStripMenuItem
      '
      Me.OpenWithNotepadToolStripMenuItem.Name = "OpenWithNotepadToolStripMenuItem"
      Me.OpenWithNotepadToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
      Me.OpenWithNotepadToolStripMenuItem.Text = "Open with Editor"
      '
      'RenameFileToolStripMenuItem
      '
      Me.RenameFileToolStripMenuItem.Name = "RenameFileToolStripMenuItem"
      Me.RenameFileToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
      Me.RenameFileToolStripMenuItem.Text = "Rename file"
      '
      'DeleteFileToolStripMenuItem
      '
      Me.DeleteFileToolStripMenuItem.Name = "DeleteFileToolStripMenuItem"
      Me.DeleteFileToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
      Me.DeleteFileToolStripMenuItem.Text = "Delete file"
      '
      'RichTextBox1
      '
      Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RichTextBox1.Location = New System.Drawing.Point(3, 3)
      Me.RichTextBox1.Name = "RichTextBox1"
      Me.RichTextBox1.ReadOnly = True
      Me.RichTextBox1.Size = New System.Drawing.Size(897, 464)
      Me.RichTextBox1.TabIndex = 5
      Me.RichTextBox1.Text = "WinFreeREG Getting Started"
      '
      'CheckBox1
      '
      Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CheckBox1.AutoSize = True
      Me.CheckBox1.Checked = True
      Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
      Me.CheckBox1.Location = New System.Drawing.Point(773, 475)
      Me.CheckBox1.Name = "CheckBox1"
      Me.CheckBox1.Size = New System.Drawing.Size(127, 17)
      Me.CheckBox1.TabIndex = 6
      Me.CheckBox1.Text = "Show Getting Started"
      Me.CheckBox1.UseVisualStyleBackColor = True
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.ColumnCount = 1
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.Controls.Add(Me.CheckBox1, 0, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.RichTextBox1, 0, 0)
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 24)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 2
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.15151!))
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.848485!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(903, 495)
      Me.TableLayoutPanel1.TabIndex = 7
      '
      'FreeregTablesDataSet
      '
      Me.FreeregTablesDataSet.DataSetName = "FreeregTables"
      Me.FreeregTablesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'FreeREG2Browser
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(903, 541)
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Controls.Add(Me.BrowserStatusStrip)
      Me.Controls.Add(Me.BrowserMenuStrip)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MainMenuStrip = Me.BrowserMenuStrip
      Me.Name = "FreeREG2Browser"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "WinFreeREG - FreeREG Browser"
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
      Me.localContextMenuStrip.ResumeLayout(False)
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.TableLayoutPanel1.PerformLayout()
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
            BatchesDataSet.WriteXml(Path.Combine(PgmAppDataLocalFolder, String.Format("{0} batches.xml", MyAppSettings.UserId)), XmlWriteMode.WriteSchema)
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
         MessageBox.Show(ex.Message, "Corrupted Settings File", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      Finally
         If stream IsNot Nothing Then stream.Close()
      End Try

      formHelp.Dispose()
   End Sub

   Private Sub FreeREG2Browser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      If pgmState <> ProgramState.Idle Then
         backgroundLogout.RunWorkerAsync()
         While backgroundLogout.IsBusy
            Thread.Sleep(5)
            Application.DoEvents()
         End While
      End If
   End Sub

   Private Sub FreeREG2Browser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

      TranscriberProfileFile = Path.Combine(AppDataLocalFolder, "transcriber.xml")
      FreeregTablesFile = Path.Combine(PgmAppDataLocalFolder, "FreeREGTables.xml")
      LookupTablesFile = Path.Combine(PgmAppDataLocalFolder, "winfreereg.tables")

      If File.Exists(SettingsFileName) Then
         Dim stream As Stream = Nothing
         Try
            stream = File.Open(SettingsFileName, FileMode.Open)
            Dim bformatter As New BinaryFormatter()
            MyAppSettings = CType(bformatter.Deserialize(stream), FreeReg2BrowserSettings)

         Catch ex As Exception
            Beep()
            MessageBox.Show(ex.Message, "Corrupted Settings File", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            stream.Close()
            stream = Nothing
            File.Delete(SettingsFileName)
            MyAppSettings = New FreeReg2BrowserSettings()
            '            Application.Exit()

         Finally
            If stream IsNot Nothing Then stream.Close()
         End Try
      Else
         MyAppSettings = New FreeReg2BrowserSettings()
      End If

      Dim MyToolTips = New CustomToolTip(ToolTipsFile, Me)

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
         If currentUser IsNot Nothing Then
            If currentUser.person_role = "trainee" Then
               cboxProcess.Items.Add("Check for errors")
            Else
               cboxProcess.Items.AddRange(New Object() {"Process tonight", "As soon as possible"})
            End If
         End If
      End If

      CheckBox1.Checked = MyAppSettings.ShowGettingStarted
      If File.Exists(Path.Combine(AppDataLocalFolder, "GettingStarted.rtf")) Then RichTextBox1.LoadFile(Path.Combine(AppDataLocalFolder, "GettingStarted.rtf"))
      RichTextBox1.Visible = MyAppSettings.ShowGettingStarted

      If File.Exists(FreeregTablesFile) Then
         TablesDataSet.ReadXml(FreeregTablesFile, XmlReadMode.ReadSchema)
         TablesDataSet.AcceptChanges()
      Else
         ScanTranscriptionsLibrary(_myTranscriptionLibrary)
         TableLayoutPanel1.Visible = True
      End If

      LookUpsDataSet.LoadXmlData(LookupTablesFile)
      LookUpsDataSet.AcceptChanges()
      If Not File.Exists(LookupTablesFile) Then LookUpsDataSet.SaveXmlData(LookupTablesFile)

      If Not String.IsNullOrEmpty(MyAppSettings.UserId) Then
         If File.Exists(Path.Combine(PgmAppDataLocalFolder, String.Format("{0} batches.xml", MyAppSettings.UserId))) Then
            BatchesDataSet.ReadXml(Path.Combine(PgmAppDataLocalFolder, String.Format("{0} batches.xml", MyAppSettings.UserId)))
            BatchesDataSet.AcceptChanges()
         End If
      End If

      Dim x = RecordTypeTextBox.DataBindings("Text")
      AddHandler x.Format, AddressOf ExpandedRecordType
      x = RegisterTypeTextBox.DataBindings("Text")
      AddHandler x.Format, AddressOf ExpandedRegisterType

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
      Using dlg As New formUserDetails(formHelp) With {.UserDataSet = UserDataSet, .RecordToShow = MyAppSettings.UserId, .MyOwner = Me}
         dlg.ShowDialog()
      End Using
   End Sub

   Private Sub miRefreshUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRefreshUser.Click
      RefreshTranscriber()
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
      If File.Exists(Path.Combine(PgmAppDataLocalFolder, String.Format("{0} batches.xml", MyAppSettings.UserId))) Then
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
      TableLayoutPanel1.Visible = False
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
      TableLayoutPanel1.Visible = False
      FileListProgressBar.Visible = True
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
            miUserTables.Enabled = True

         Case ProgramState.LoggedOn
            miFreeREG2Tables.Enabled = False
            miUserTables.Enabled = True

         Case ProgramState.UserAuthenticated
            miFreeREG2Tables.Enabled = True
            miUserTables.Enabled = True
      End Select
   End Sub

   Private Sub miUserTables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miUserTables.Click
      Using dlg As New formUserTables(formHelp) With {.LookupTables = LookUpsDataSet, .LookupsFilename = LookupTablesFile}
         dlg.ShowAll()
         dlg.ShowDialog()
      End Using
   End Sub

   Private Sub miFreeREG2Tables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miFreeREG2Tables.Click
      Using dlg As New formFreeregTables(formHelp) With {.DataSet = TablesDataSet, .Settings = MyAppSettings, .DefaultCounty = _myDefaultCounty}
         dlg.ShowDialog()
         If dlg.IsChanged Then TablesDataSet.WriteXml(FreeregTablesFile, XmlWriteMode.WriteSchema)
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

         MessageBox.Show(My.Resources.msgLoggedIn, "FreeREG Login", MessageBoxButtons.OK, MessageBoxIcon.Information)

         ' Kick off the Batches download thread
         '
      End If
   End Sub

   Function PerformLogon(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Long
      Dim result As Long = 0
      Dim uri = New Uri(MyAppSettings.BaseUrl)
      MyAppSettings.Cookies = New CookieCollection()

      Dim euDirective As New Cookie("cookiesDirective", "1")
      MyAppSettings.Cookies.Add(euDirective)


      Using webClient As New CookieAwareWebClient()
         Try
            '  Tickle FreeREG server to get the Login page
            '
            worker.ReportProgress(0, "Logging on...")
            webClient.SetTimeout(30000)
            webClient.AddCookie(uri, euDirective)
            webClient.GetHttpRequest(uri).AllowAutoRedirect = True
            webClient.GetHttpRequest(uri).KeepAlive = True

            Dim addrRequest As String = MyAppSettings.BaseUrl + "/transreg_users/computer" + String.Format("?computerid={0}&computeridpassword={1}&transcriberid={2}&transcriberpassword={3}", MyAppSettings.TransregName, MyAppSettings.TransregPassword, MyAppSettings.UserId, MyAppSettings.Password)
            Dim login_page = webClient.DownloadString(addrRequest)

            '            webClient.ShowResponseHeaders()
            '            webClient.ShowCookies(uri)

            '  Process any cookies
            '
            Dim hdr = webClient.ResponseHeaders("Set-Cookie")
            MyAppSettings.Cookies.Add(webClient.GetAllCookiesFromHeader(hdr, MyAppSettings.BaseUrl))

            If login_page.StartsWith("<?xml", True, CultureInfo.InvariantCulture) Then
               Try
                  Dim xmlDoc As New XmlDocument()
                  xmlDoc.LoadXml(login_page)
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
                                                         If Not DateTime.TryParse(z, rec(n)) Then
                                                            Beep()
                                                         End If
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

                        worker.ReportProgress(100, "Logged on to FreeREG")
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

            Else
               worker.ReportProgress(0, "Computer Log on failed...")
               If login_page.StartsWith("<!DOCTYPE html>", True, CultureInfo.InvariantCulture) Then
                  Throw New BackgroundWorkerException("Computer Login - Unexpected response", login_page)
               End If
               Throw New BackgroundWorkerException("Computer Login - Unexpected response")
            End If

         Catch ex As BackgroundWorkerException
            Throw

         Catch ex As WebException
            If ex.Response Is Nothing Then
               Throw New BackgroundWorkerException("Logon to FreeREG failed", ex)
            Else
               Dim webResp As HttpWebResponse = ex.Response
               Console.WriteLine(String.Format("WebException:{0} Desc:{1}", webResp.StatusCode, webResp.StatusDescription))
               Select Case webResp.StatusCode
                  Case HttpStatusCode.NotFound

                  Case HttpStatusCode.NotAcceptable

                  Case HttpStatusCode.InternalServerError

                  Case Else

               End Select
               Throw New BackgroundWorkerException("Logon to FreeREG failed", ex)
            End If

         Catch ex As Exception
            Throw New BackgroundWorkerException("Logon to FreeREG failed", ex)
         End Try
      End Using

      Return result
   End Function

   Public Sub RefreshTranscriber()
      Dim uri = New Uri(MyAppSettings.BaseUrl)

      Using webClient As New CookieAwareWebClient()
         webClient.SetTimeout(60000)
         Dim addrAuth As String = MyAppSettings.BaseUrl + "/transreg_users/refreshuser"
         Dim query_data = New NameValueCollection()
         query_data.Add("transcriberid", MyAppSettings.UserId)
         webClient.QueryString = query_data

         '  Add the cookies to the request
         '
         For Each Cookie In MyAppSettings.Cookies
            webClient.AddCookie(uri, New Cookie(Cookie.name, Cookie.value))
         Next
         Dim auth_page = webClient.DownloadString(addrAuth)

         '  Process any cookies
         '
         Dim hdr = webClient.ResponseHeaders("Set-Cookie")
         MyAppSettings.Cookies.Add(webClient.GetAllCookiesFromHeader(hdr, MyAppSettings.BaseUrl))

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
      Dim uri = New Uri(MyAppSettings.BaseUrl)

      Using webClient As New CookieAwareWebClient()
         Try
            worker.ReportProgress(0, "Logging out...")
            webClient.SetTimeout(30000)
            Dim addrRequest As String = MyAppSettings.BaseUrl + "/cms/refinery/logout"

            '  Add the cookies to the request
            '
            For Each Cookie In MyAppSettings.Cookies
               webClient.AddCookie(uri, New Cookie(Cookie.Name, Cookie.Value))
            Next
            Dim logout_response = webClient.DownloadString(addrRequest)

            '  Process any cookies
            '
            Dim hdr = webClient.ResponseHeaders("Set-Cookie")
            MyAppSettings.Cookies.Add(webClient.GetAllCookiesFromHeader(hdr, MyAppSettings.BaseUrl))

         Catch ex As WebException
            Dim webResp As HttpWebResponse = ex.Response
            If webResp Is Nothing Then
               MessageBox.Show(ex.InnerException.Message, ex.Message)
               Throw New BackgroundWorkerException("Logout to FreeREG failed", ex)
            Else
               Console.WriteLine(String.Format("WebException:{0} Desc:{1}", webResp.StatusCode, webResp.StatusDescription))
               Select Case webResp.StatusCode
                  Case HttpStatusCode.NotFound

                  Case HttpStatusCode.NotAcceptable

                  Case HttpStatusCode.InternalServerError

                  Case Else

               End Select
               Throw New BackgroundWorkerException("Logout to FreeREG failed", ex)
            End If

         Catch ex As Exception
            Throw New BackgroundWorkerException("Logout to FreeREG failed", ex)
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
         Throw New BackgroundWorkerException(String.Format("Upload of {0} to FreeREG failed", fname), ex)

      Catch ex As Exception
         Throw New BackgroundWorkerException(String.Format("Upload of {0} to FreeREG failed", fname), ex)

      End Try

      Return result
   End Function

   Public Function HttpUploadFile(ByVal url As String, ByVal file As String, ByVal paramName As String, ByVal contentType As String, ByVal nvc As NameValueCollection) As Object
      Dim uri = New Uri(MyAppSettings.BaseUrl)
      Dim boundary As String = "---------------------------" + DateTime.Now.Ticks.ToString("x")
      Dim boundarybytes As Byte() = System.Text.Encoding.ASCII.GetBytes(vbCrLf + "--" + boundary + vbCrLf)

      Dim wr As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
      wr.ContentType = "multipart/form-data; boundary=" + boundary
      wr.Method = "POST"
      wr.KeepAlive = True
      wr.Credentials = System.Net.CredentialCache.DefaultCredentials
      wr.CookieContainer = New CookieContainer()

      '  Add the cookies to the request
      '
      For Each Cookie In MyAppSettings.Cookies
         wr.CookieContainer.Add(uri, New Cookie(Cookie.name, Cookie.value))
      Next
      Console.WriteLine("Out - {0}", wr.CookieContainer.GetCookieHeader(uri))

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

         '  Process any cookies
         '
         'Dim hdr = wr.ResponseHeaders("Set-Cookie")
         'MyAppSettings.Cookies.Add(wr.GetAllCookiesFromHeader(hdr, MyAppSettings.BaseUrl))

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
         Throw New BackgroundWorkerException(String.Format("Replacement of {0} to FreeREG failed", fname), ex)

      Catch ex As Exception
         Throw New BackgroundWorkerException(String.Format("Replacement of {0} to FreeREG failed", fname), ex)

      End Try

      Return result
   End Function

   Public Function HttpReplaceFile(ByVal url As String, ByVal file As String, ByVal paramName As String, ByVal contentType As String, ByVal nvc As NameValueCollection) As Object
      Dim uri = New Uri(MyAppSettings.BaseUrl)
      Dim boundary As String = "---------------------------" + DateTime.Now.Ticks.ToString("x")
      Dim boundarybytes As Byte() = System.Text.Encoding.ASCII.GetBytes(vbCrLf + "--" + boundary + vbCrLf)

      Dim wr As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
      wr.ContentType = "multipart/form-data; boundary=" + boundary
      wr.Method = "POST"
      wr.KeepAlive = True
      wr.Credentials = System.Net.CredentialCache.DefaultCredentials
      wr.CookieContainer = New CookieContainer()
      '  Add the cookies to the request
      '
      For Each Cookie In MyAppSettings.Cookies
         wr.CookieContainer.Add(uri, New Cookie(Cookie.name, Cookie.value))
      Next
      Console.WriteLine("Out - {0}", wr.CookieContainer.GetCookieHeader(uri))

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
         BatchesDataSet.WriteXml(Path.Combine(PgmAppDataLocalFolder, String.Format("{0} batches.xml", MyAppSettings.UserId)), XmlWriteMode.WriteSchema)

         ' Refresh the user profile
         '
         RefreshTranscriber()

      End If
   End Sub

   Function PerformDeleteFile(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As Object
      Dim uri = New Uri(MyAppSettings.BaseUrl)

      Using webClient As New CookieAwareWebClient()
         Try
            webClient.SetTimeout(30000)
            Dim addrRequest As String = MyAppSettings.BaseUrl + "/transreg_csvfiles/delete.xml"
            Dim query_data = New NameValueCollection()
            query_data.Add("transcriberid", MyAppSettings.UserId)
            query_data.Add("transcriberpassword", MyAppSettings.Password)
            query_data.Add("id", e.Argument)
            webClient.QueryString = query_data

            '  Add the cookies to the request
            '
            For Each Cookie In MyAppSettings.Cookies
               webClient.AddCookie(uri, New Cookie(Cookie.Name, Cookie.Value))
            Next

            Dim contents As String = webClient.DownloadString(addrRequest)

            '  Process any cookies
            '
            Dim hdr = webClient.ResponseHeaders("Set-Cookie")
            MyAppSettings.Cookies.Add(webClient.GetAllCookiesFromHeader(hdr, MyAppSettings.BaseUrl))

            Dim res As New BackgroundResult()
            res.Parameter = e.Argument
            res.Result = contents
            Return res

         Catch ex As XmlException
            Throw New BackgroundWorkerException("Deleting File from FreeREG failed", ex)

         Catch ex As WebException
            Dim webResp As HttpWebResponse = ex.Response
            If webResp Is Nothing Then
               Throw New BackgroundWorkerException("Deleting File from FreeREG failed", ex)
            Else
               Console.WriteLine(String.Format("WebException:{0} Desc:{1}", webResp.StatusCode, webResp.StatusDescription))
               Select Case webResp.StatusCode
                  Case HttpStatusCode.NotFound

                  Case HttpStatusCode.NotAcceptable

                  Case HttpStatusCode.InternalServerError

                  Case Else

               End Select
               Throw New BackgroundWorkerException("Deleting File from FreeREG failed", ex)
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
      GetBatches(worker, e)
   End Sub

   Private Sub backgroundBatches_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundBatches.ProgressChanged
      labelStatus.Text = e.UserState
      If e.ProgressPercentage > 0 Then
         FileListProgressBar.Text = e.ProgressPercentage
         FileListProgressBar.Value = e.ProgressPercentage
      End If
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
         BatchBindingSource.Sort = "FileName"
         bnavShowData.BindingSource = BatchBindingSource
         bnavShowData.Visible = True
         dlvUploadedFiles.Visible = True
         FileListProgressBar.Value = 0
         FileListProgressBar.Visible = False
         labelStatus.Text = String.Format("Batch details downloaded from FreeREG for {0}", MyAppSettings.UserId)
         dlvUploadedFiles.RebuildColumns()
         olvcFilename.Groupable = True
         olvcFilename.GroupKeyGetter = New GroupKeyGetterDelegate(AddressOf SetFileNameGroupKey)
         olvcFilename.GroupKeyToTitleConverter = New GroupKeyToTitleConverterDelegate(AddressOf SetFileNameGroupTitle)

         MessageBox.Show(e.Result, "Uploaded Batches", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub

   Function SetFileNameGroupKey(ByVal rowObject As Object)
      Dim drv As DataRowView = CType(rowObject, DataRowView)
      Dim dr As WinFreeReg.Batches.BatchRow = CType(drv.Row, WinFreeReg.Batches.BatchRow)
      Return dr.CountyName
   End Function

   Function SetFileNameGroupTitle(ByVal groupKey As Object)
      Dim s = CStr(groupKey)
      Dim r = LookUpsDataSet.ChapmanCodes.FindByCode(s)
      Return r.County
   End Function

   Private Function BatchName(ByVal objValue As String) As String
      Dim x = objValue.IndexOf("."c)
      Return objValue.Substring(0, objValue.IndexOf("."c))
   End Function

   Private Sub GetBatches(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs)
      Dim uri = New Uri(MyAppSettings.BaseUrl)

      worker.ReportProgress(0, String.Format("Fetching Batch details from FreeREG for {0}...", MyAppSettings.UserId))

      Using webClient As New CookieAwareWebClient()
         Try
            webClient.SetTimeout(60000)
            Dim addrRequest As String = MyAppSettings.BaseUrl + "/transreg_batches/list.xml"
            Dim query_data = New NameValueCollection()
            query_data.Add("transcriber", MyAppSettings.UserId)
            webClient.QueryString = query_data

            '  Add the cookies to the request
            '
            For Each Cookie In MyAppSettings.Cookies
               webClient.AddCookie(uri, New Cookie(Cookie.Name, Cookie.Value))
            Next

            Dim contents As String = webClient.DownloadString(addrRequest)

            '  Process any cookies
            '
            Dim hdr = webClient.ResponseHeaders("Set-Cookie")
            MyAppSettings.Cookies.Add(webClient.GetAllCookiesFromHeader(hdr, MyAppSettings.BaseUrl))
            worker.ReportProgress(0, "Response received...")

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
                  worker.ReportProgress(0, String.Format("Response received... {0} files listed", ds.Tables("Batch").Rows.Count))
                  For Each row As DataRow In ds.Tables("Batch").Rows
                     Try
                        Dim batch As Batches.BatchRow = BatchesDataSet.Batch.NewBatchRow()
                        batch.ID = row.Item("ID")
                        batch.CountyName = row.Item("CountyName")
                        batch.PlaceName = row.Item("PlaceName")
                        batch.ChurchName = row.Item("ChurchName")
                        batch.RegisterType = CStr(row.Item("RegisterType")).ToUpper
                        batch.RecordType = CStr(row.Item("RecordType")).ToUpper
                        batch.Records = row.Item("Records")
                        batch.DateMin = row.Item("DateMin")
                        batch.DateMax = row.Item("DateMax")
                        batch.DateRange = row.Item("DateRange")
                        batch.UserId = row.Item("UserId")
                        batch.UserIdLowerCase = row.Item("UserIdLowerCase")
                        batch.FileName = row.Item("FileName")
                        batch.TranscriberName = row.Item("TranscriberName")
                        batch.TranscriberEmail = row.Item("TranscriberEmail")
                        batch.TranscriberSyndicate = row.Item("TranscriberSyndicate")
                        batch.CreditEmail = row.Item("CreditEmail")
                        batch.CreditName = row.Item("CreditName")
                        batch.FirstComment = row.Item("FirstComment")
                        batch.SecondComment = row.Item("SecondComment")
                        Try
                           batch.TranscriptionDate = DateTime.Parse(row.Item("TranscriptionDate"))

                        Catch ex As FormatException
                           '                           batch.TranscriptionDate = DateTime.MinValue
                        End Try

                        Try
                           batch.ModificationDate = DateTime.Parse(row.Item("ModificationDate"))

                        Catch ex As FormatException
                           '                           batch.ModificationDate = DateTime.MinValue
                        End Try

                        Try
                           batch.UploadedDate = DateTime.Parse(row.Item("UploadedDate"))

                        Catch ex As FormatException
                           '                           batch.UploadedDate = DateTime.MinValue
                        End Try

                        batch._Error = row.Item("Error")
                        batch.Digest = row.Item("Digest")
                        batch.LockedByTranscriber = row.Item("LockedByTranscriber")
                        batch.LockedByCoordinator = row.Item("LockedByCoordinator")
                        batch.lds = row.Item("lds").ToString.ToLower = "yes"
                        batch.Action = row.Item("Action")
                        batch.CharacterSet = row.Item("CharacterSet")
                        batch.AlternateRegisterName = row.Item("AlternateRegisterName")
                        batch.CsvFile = row.Item("CsvFile")
                        BatchesDataSet.Batch.AddBatchRow(batch)
                        worker.ReportProgress(BatchesDataSet.Batch.Rows.Count / ds.Tables("Batch").Rows.Count * 100, "Storing file information...")

                     Catch ex As ConstraintException
                        MessageBox.Show(ex.Message, "Storing Batch Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                     Catch ex As Exception
                        Throw New BackgroundWorkerException("Getting Batch Details from FreeREG failed", ex)
                     End Try
                  Next
                  e.Result = String.Format("Uploaded {0} Batches to FreeREG", BatchesDataSet.Batch.Rows.Count)
               Else
                  ' No Batches uploaded by this user
                  e.Result = My.Resources.msgNoBatchesForUser
               End If
               BatchesDataSet.AcceptChanges()
               BatchesDataSet.WriteXml(Path.Combine(PgmAppDataLocalFolder, String.Format("{0} batches.xml", MyAppSettings.UserId)), XmlWriteMode.WriteSchema)
            Else
               Throw New BackgroundWorkerException("Getting Batch Details from FreeREG failed - Not logged on")
            End If

         Catch ex As NullReferenceException
            Throw New BackgroundWorkerException("Storing Batch data failed - ", ex)

         Catch ex As XmlException
            Throw New BackgroundWorkerException("Getting Batch Details from FreeREG failed", ex)

         Catch ex As WebException
            Dim webResp As HttpWebResponse = ex.Response
            If webResp Is Nothing Then
               Throw New BackgroundWorkerException("Getting Batch Details from FreeREG failed", ex)
            Else
               Console.WriteLine(String.Format("WebException:{0} Desc:{1}", webResp.StatusCode, webResp.StatusDescription))
               Select Case webResp.StatusCode
                  Case HttpStatusCode.NotFound

                  Case HttpStatusCode.NotAcceptable

                  Case HttpStatusCode.InternalServerError

                  Case Else

               End Select
               Throw New BackgroundWorkerException("Getting Batch Details from FreeREG failed", ex)
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
         If ex.GetType.Name = "BackgroundWorkerException" Then
            If Not DirectCast(ex, BackgroundWorkerException).Page Is Nothing Then
               Using dlg As New formPageReceived()
                  dlg.Text = DirectCast(ex, BackgroundWorkerException).Message
                  dlg.wbPage.DocumentText = DirectCast(ex, BackgroundWorkerException).Page
                  dlg.ShowDialog()
               End Using
            Else
               MessageBox.Show(ex.Message)
            End If
         Else
            MessageBox.Show(ex.Message)
         End If
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
      Dim uri = New Uri(MyAppSettings.BaseUrl)
      Dim currentBatch As Batches.BatchRow = BatchBindingSource.Current.Row

      Using webClient As New CookieAwareWebClient()
         Try
            webClient.SetTimeout(30000)
            Dim addrRequest As String = MyAppSettings.BaseUrl + "/transreg_batches/download.xml"
            Dim query_data = New NameValueCollection()
            query_data.Add("transcriber", MyAppSettings.UserId)
            query_data.Add("id", currentBatch.ID)
            webClient.QueryString = query_data

            '  Add the cookies to the request
            '
            For Each Cookie In MyAppSettings.Cookies
               webClient.AddCookie(uri, New Cookie(Cookie.Name, Cookie.Value))
            Next
            '            Console.WriteLine("Out - {0}", webClient.CookieContainer.GetCookieHeader(uri))
            Dim contents As String = webClient.DownloadString(addrRequest)

            '            Console.WriteLine(" In - {0}", webClient.CookieContainer.GetCookieHeader(uri))
            '  Process any cookies
            '
            Dim hdr = webClient.ResponseHeaders("Set-Cookie")
            MyAppSettings.Cookies.Add(webClient.GetAllCookiesFromHeader(hdr, MyAppSettings.BaseUrl))

            If contents.StartsWith("+INFO") Then
               Using dlg As New formBatchContents() With {.PersonalPath = _myTranscriptionLibrary, .CurrentBatch = currentBatch, .Text = String.Format("Batch Contents - {0}", currentBatch.FileName)}
                  dlg.FileContentsTextBox.Text = contents.Replace(",""""", ",")
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

      If MessageBox.Show(String.Format(My.Resources.msgConfirmRemoveDatabaseFile, currentBatch.FileName), "Remove Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
         Try
            backgroundDelete.RunWorkerAsync(currentBatch.ID)

         Catch ex As Exception

         End Try
      End If
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

   Private Sub btnNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewFile.Click
      Using dlg As New formStartNewFile(formHelp) With {.Username = _myUserName, .EmailAddress = _myEmailAddress, .dsFreeRegTables = TablesDataSet, .dsLookupTables = LookUpsDataSet, .DefaultCounty = _myDefaultCounty, .TranscriptionLibrary = _myTranscriptionLibrary}
         Try
            dlg.Settings = MyAppSettings
            dlg.UserTablesFile = TranscriberProfileFile
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
            MessageBox.Show(ex.Message, "Start New File", MessageBoxButtons.OK, MessageBoxIcon.Stop)

         End Try
      End Using
   End Sub
#End Region

   Private Sub dlvLocalFiles_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dlvLocalFiles.ItemActivate
      OpenWorkspace()
   End Sub

   Private Sub dlvLocalFiles_CellToolTipShowing(ByVal sender As System.Object, ByVal e As BrightIdeasSoftware.ToolTipShowingEventArgs) Handles dlvLocalFiles.CellToolTipShowing
      If e.ModifierKeys = Keys.Control Then
         If e.Column.Name = "Name" Then
            Try
               Dim tfile As New TranscriptionFileClass(CType(e.Model, DataRowView).Row, LookUpsDataSet, TablesDataSet)
               e.BackColor = Color.Bisque
               e.IsBalloon = True
               e.StandardIcon = ToolTipControl.StandardIcons.InfoLarge
               e.Title = tfile.FileName
               e.Text = tfile.FileHeader.Place + vbCrLf + tfile.FileHeader.Church + vbCrLf _
                + tfile.FileHeader.Comment1 + vbCrLf + tfile.FileHeader.Comment2 + vbCrLf + vbCrLf _
                + String.Format("File size: {0} records", tfile.Items.Rows.Count)

            Catch ex As FileHeaderException
               MessageBox.Show(ex.Message, "Open Local File", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            End Try
         End If
      End If
   End Sub

   Private Sub miGeneralHelp_Click(sender As Object, e As EventArgs) Handles miGeneralHelp.Click
      Try
         formHelp.Title = "FreeREG Browser"
         formHelp.StartPage = "GeneralHelp.html"
         formHelp.Show()

      Catch ex As Exception
         formHelp.Hide()
         MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try
   End Sub

   Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
      Using dlg As New AboutBox()
         dlg.ShowDialog()
      End Using
   End Sub

   Private selectedFile As DataRow = Nothing

   Private Sub dlvLocalFiles_CellRightClick(sender As Object, e As CellRightClickEventArgs) Handles dlvLocalFiles.CellRightClick
      If e.Model Is Nothing Then Return
      selectedFile = CType(e.Model, DataRowView).Row
      e.MenuStrip = localContextMenuStrip
   End Sub

   Private Sub OpenWithNotepadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenWithNotepadToolStripMenuItem.Click
      If selectedFile IsNot Nothing Then System.Diagnostics.Process.Start(selectedFile("FullName"))
      selectedFile = Nothing
   End Sub

   Private Sub RenameFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameFileToolStripMenuItem.Click
      If selectedFile IsNot Nothing Then
         Dim tfile = New TranscriptionFileClass(selectedFile, LookUpsDataSet, TablesDataSet)
         Using dlg As New formFileRename() With {.SelectedFile = selectedFile, .TranscriptionFile = tfile}
            dlg.ShowDialog()
         End Using
      End If
   End Sub

   Private Sub DeleteFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteFileToolStripMenuItem.Click
      If selectedFile IsNot Nothing Then
         If MessageBox.Show(String.Format(My.Resources.msgConfirmDeleteFile, selectedFile("Name")), "Delete File", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Try
               FileSystem.DeleteFile(selectedFile("FullName"), UIOption.AllDialogs, RecycleOption.SendToRecycleBin)
               MessageBox.Show(String.Format(My.Resources.msgFileRecycled, selectedFile("Name")), "File Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
               Dim tableLocalFiles As DataTable = bsrcLocalFiles.DataSource
               tableLocalFiles.Rows.Remove(selectedFile)

            Catch ex As Exception
               MessageBox.Show(ex.Message, "Delete File Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
         End If
         selectedFile = Nothing
      End If
   End Sub

   Private Sub ExpandedRecordType(sender As Object, e As ConvertEventArgs)
      If Not Convert.IsDBNull(e.Value) Then
         Dim x = LookUpsDataSet.RecordTypes.FindByType(e.Value)
         e.Value = String.Format("{0} - {1}", x.Type, x.Description)
      End If
   End Sub

   Private Sub ExpandedRegisterType(sender As Object, e As ConvertEventArgs)
      If Not Convert.IsDBNull(e.Value) Then
         Dim x = TablesDataSet.RegisterTypes.FindByType(e.Value)
         e.Value = IIf(x Is Nothing, "<Not specified>", String.Format("{0} - {1}", x.Type, x.Description))
      End If
   End Sub

   Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
      If TableLayoutPanel1.Visible Then RichTextBox1.Visible = CheckBox1.Checked
      If MyAppSettings IsNot Nothing Then MyAppSettings.ShowGettingStarted = CheckBox1.Checked
   End Sub

   Private Sub labFilename_DoubleClick(sender As Object, e As EventArgs) Handles labFilename.DoubleClick
      OpenWorkspace()
   End Sub

   Private Sub OpenWorkspace()
      Dim row As DataRow = dlvLocalFiles.SelectedObject().Row
      Try
         Using dlg As New formFileWorkspace(formHelp) With {.TranscriptionFile = New TranscriptionFileClass(row, LookUpsDataSet, TablesDataSet), .SelectedRow = row, .BaseDirectory = AppDataLocalFolder, .ErrorMessageTable = ErrorMessagesDataSet.Tables("ErrorMessages")}
            Me.Hide()
            Try
               dlg.Settings = MyAppSettings
               dlg.DefaultCounty = _myDefaultCounty
               dlg.FreeregTablesFile = FreeregTablesFile
               dlg.UserTablesFile = TranscriberProfileFile
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
               MessageBox.Show(ex.Message, "Open Local File", MessageBoxButtons.OK, MessageBoxIcon.Stop)

            Finally

            End Try
            Me.Show()
         End Using

      Catch ex As FileHeaderException
         MessageBox.Show(ex.Message, "Open Local File", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try
   End Sub

   Private Sub ScanTranscriptionsLibrary(root As String)
      Dim m_Decoding As Encoding = Encoding.GetEncoding("iso-8859-1")
      Dim dir As New DirectoryInfo(root)
      Dim filelist = dir.GetFiles("*.*", IO.SearchOption.TopDirectoryOnly)
      Dim filequery = From file In filelist _
                      Where file.Extension.Equals(".csv", StringComparison.CurrentCultureIgnoreCase) _
                      Order By file.Name _
                      Select file

      ' For each CSV file in the Default Transcriptions Library Folder
      '
      For Each csvfile In filequery
         Beep()
         '   a) Make sure the contents are of a Transcription
         Using m_Reader As New TextFieldParser(csvfile.FullName, m_Decoding)
            m_Reader.TextFieldType = FieldType.Delimited
            m_Reader.SetDelimiters(",")
            m_Reader.TrimWhiteSpace = True
            m_Reader.HasFieldsEnclosedInQuotes = True

            Dim hLine1() = m_Reader.ReadFields()
            Dim hLine2() = m_Reader.ReadFields()
            Dim hLine3() = m_Reader.ReadFields()
            Dim hLine4() = m_Reader.ReadFields()
            Dim dline() = m_Reader.ReadFields()
            If dline(0) = "+LDS" Then
               dline = m_Reader.ReadFields()
            End If

            '   b) Extract the County, Place and Church items of data
            Dim County As String = dline(0)
            Dim Place As String = dline(1)
            Dim Church As String = dline(2)
            Dim RType As String = ""
            Dim X = Church.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
            If X(X.Length - 1).Length = 2 Then
               Church = String.Join(" ", X, 0, X.Length - 1)
               RType = X(X.Length - 1)
            End If

            '   c) Add them to the FreeregTables file as the
            If TablesDataSet.ApprovedRegisterTypes.FindByType(RType) Is Nothing Then TablesDataSet.ApprovedRegisterTypes.AddApprovedRegisterTypesRow(RType, "")
            If TablesDataSet.RegisterTypes.FindByType(RType) Is Nothing Then TablesDataSet.RegisterTypes.AddRegisterTypesRow(RType, "")
            '      1) One or more County records
            Dim Notes As String = "Added from Library scan"
            Dim countyrow As FreeregTables.CountiesRow = TablesDataSet.Counties.FindByChapmanCode(County)
            If countyrow Is Nothing Then
               countyrow = TablesDataSet.Counties.NewCountiesRow()
               countyrow.ChapmanCode = County
               countyrow.CountyName = County
               countyrow.Notes = Notes
               TablesDataSet.Counties.AddCountiesRow(countyrow)
            End If
            '      2) One or more Place records
            If TablesDataSet.Places.FindByPlaceNameChapmanCode(Place, County) Is Nothing Then
               TablesDataSet.Places.AddPlacesRow(Place, countyrow, "", countyrow.CountyName, Notes)
            End If
            '      3) One of more Church records
            If TablesDataSet.Churches.FindByChurchNameChapmanCodePlaceName(Church, County, Place) Is Nothing Then
               TablesDataSet.Churches.AddChurchesRow(Church, countyrow, Place, "", "", "", "", "", Notes)
            End If
         End Using
      Next
   End Sub

   Private Sub UserOptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserOptionsToolStripMenuItem.Click
      Using dlg As New dlgUserOptions(formHelp) With {.SelectedValue = My.Settings.optionCellEditing}
         dlg.ShowDialog()
         If dlg.DialogResult = Windows.Forms.DialogResult.OK Then
            If dlg.SelectedValue <> My.Settings.optionCellEditing Then
               My.Settings.optionCellEditing = dlg.SelectedValue
            End If
            My.Settings.optionEditingCellBorder = dlg.checkShowEditingCellBorder.Checked
         End If
      End Using
   End Sub

   Private Sub ChurchesToolStripMenuItem_Click(sender As Object, e As EventArgs)
      Using dlg As New dlgChurches(formHelp) With {.FreeREGDataset = TablesDataSet, .DefaultCounty = TablesDataSet.Counties.FindByChapmanCode(_myDefaultCounty.Code)}
         dlg.ShowDialog()
         If dlg.DialogResult = Windows.Forms.DialogResult.OK Then
         End If
      End Using
   End Sub

End Class
