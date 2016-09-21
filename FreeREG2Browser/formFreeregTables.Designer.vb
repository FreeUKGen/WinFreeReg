<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formFreeregTables
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formFreeregTables))
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.tabRegisterTypes = New System.Windows.Forms.TabPage()
      Me.dlvRegisterTypes = New BrightIdeasSoftware.DataListView()
      Me.olvc0Type = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc0Description = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.tabCounties = New System.Windows.Forms.TabPage()
      Me.dlvCounties = New BrightIdeasSoftware.DataListView()
      Me.olvc1ChapmanCode = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc1CountyName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc1Notes = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.tabPlaces = New System.Windows.Forms.TabPage()
      Me.dlvPlaces = New BrightIdeasSoftware.DataListView()
      Me.olvc2PlaceName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc2Notes = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc2ChapmanCode = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc2CountyName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc2Country = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.tabChurches = New System.Windows.Forms.TabPage()
      Me.dlvChurches = New BrightIdeasSoftware.DataListView()
      Me.olvc3ChurchName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc3FileCode = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc3Notes = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc3ChapmanCode = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc3PlaceName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc3Denomination = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc3Location = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc3Website = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvc3LastAmended = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.cboxPlaces = New System.Windows.Forms.ComboBox()
      Me.labPlace = New System.Windows.Forms.Label()
      Me.cboxCounties = New System.Windows.Forms.ComboBox()
      Me.labCounty = New System.Windows.Forms.Label()
      Me.btnFetch = New System.Windows.Forms.Button()
      Me.btnApproved = New System.Windows.Forms.Button()
      Me.backgroundRegisterTypes = New System.ComponentModel.BackgroundWorker()
      Me.backgroundCounties = New System.ComponentModel.BackgroundWorker()
      Me.backgroundPlaces = New System.ComponentModel.BackgroundWorker()
      Me.backgroundChurches = New System.ComponentModel.BackgroundWorker()
      Me.TabControl1.SuspendLayout()
      Me.tabRegisterTypes.SuspendLayout()
      CType(Me.dlvRegisterTypes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tabCounties.SuspendLayout()
      CType(Me.dlvCounties, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tabPlaces.SuspendLayout()
      CType(Me.dlvPlaces, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tabChurches.SuspendLayout()
      CType(Me.dlvChurches, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.SuspendLayout()
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.tabRegisterTypes)
      Me.TabControl1.Controls.Add(Me.tabCounties)
      Me.TabControl1.Controls.Add(Me.tabPlaces)
      Me.TabControl1.Controls.Add(Me.tabChurches)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 0)
      Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(497, 235)
      Me.TabControl1.TabIndex = 0
      '
      'tabRegisterTypes
      '
      Me.tabRegisterTypes.Controls.Add(Me.dlvRegisterTypes)
      Me.tabRegisterTypes.Location = New System.Drawing.Point(4, 22)
      Me.tabRegisterTypes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tabRegisterTypes.Name = "tabRegisterTypes"
      Me.tabRegisterTypes.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tabRegisterTypes.Size = New System.Drawing.Size(489, 209)
      Me.tabRegisterTypes.TabIndex = 3
      Me.tabRegisterTypes.Text = "Register Types"
      Me.tabRegisterTypes.UseVisualStyleBackColor = True
      '
      'dlvRegisterTypes
      '
      Me.dlvRegisterTypes.AllColumns.Add(Me.olvc0Type)
      Me.dlvRegisterTypes.AllColumns.Add(Me.olvc0Description)
      Me.dlvRegisterTypes.CellEditUseWholeCell = False
      Me.dlvRegisterTypes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvc0Type, Me.olvc0Description})
      Me.dlvRegisterTypes.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvRegisterTypes.DataSource = Nothing
      Me.dlvRegisterTypes.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvRegisterTypes.EmptyListMsg = "The Register Types table has no entries"
      Me.dlvRegisterTypes.FullRowSelect = True
      Me.dlvRegisterTypes.GridLines = True
      Me.dlvRegisterTypes.HeaderWordWrap = True
      Me.dlvRegisterTypes.Location = New System.Drawing.Point(3, 2)
      Me.dlvRegisterTypes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.dlvRegisterTypes.MultiSelect = False
      Me.dlvRegisterTypes.Name = "dlvRegisterTypes"
      Me.dlvRegisterTypes.SelectColumnsOnRightClick = False
      Me.dlvRegisterTypes.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
      Me.dlvRegisterTypes.ShowGroups = False
      Me.dlvRegisterTypes.ShowSortIndicators = False
      Me.dlvRegisterTypes.Size = New System.Drawing.Size(483, 205)
      Me.dlvRegisterTypes.TabIndex = 0
      Me.dlvRegisterTypes.UseCompatibleStateImageBehavior = False
      Me.dlvRegisterTypes.View = System.Windows.Forms.View.Details
      '
      'olvc0Type
      '
      Me.olvc0Type.AspectName = "Type"
      Me.olvc0Type.Groupable = False
      Me.olvc0Type.Hideable = False
      Me.olvc0Type.IsEditable = False
      Me.olvc0Type.MaximumWidth = 50
      Me.olvc0Type.MinimumWidth = 50
      Me.olvc0Type.Text = "Type"
      Me.olvc0Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.olvc0Type.Width = 50
      '
      'olvc0Description
      '
      Me.olvc0Description.AspectName = "Description"
      Me.olvc0Description.FillsFreeSpace = True
      Me.olvc0Description.Groupable = False
      Me.olvc0Description.Hideable = False
      Me.olvc0Description.IsEditable = False
      Me.olvc0Description.Text = "Description"
      Me.olvc0Description.WordWrap = True
      '
      'tabCounties
      '
      Me.tabCounties.Controls.Add(Me.dlvCounties)
      Me.tabCounties.Location = New System.Drawing.Point(4, 22)
      Me.tabCounties.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tabCounties.Name = "tabCounties"
      Me.tabCounties.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tabCounties.Size = New System.Drawing.Size(456, 208)
      Me.tabCounties.TabIndex = 1
      Me.tabCounties.Text = "Counties"
      Me.tabCounties.UseVisualStyleBackColor = True
      '
      'dlvCounties
      '
      Me.dlvCounties.AllColumns.Add(Me.olvc1ChapmanCode)
      Me.dlvCounties.AllColumns.Add(Me.olvc1CountyName)
      Me.dlvCounties.AllColumns.Add(Me.olvc1Notes)
      Me.dlvCounties.CellEditUseWholeCell = False
      Me.dlvCounties.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvc1ChapmanCode, Me.olvc1CountyName, Me.olvc1Notes})
      Me.dlvCounties.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvCounties.DataSource = Nothing
      Me.dlvCounties.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvCounties.EmptyListMsg = "The Counties table has no entries"
      Me.dlvCounties.FullRowSelect = True
      Me.dlvCounties.GridLines = True
      Me.dlvCounties.HeaderWordWrap = True
      Me.dlvCounties.Location = New System.Drawing.Point(3, 2)
      Me.dlvCounties.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.dlvCounties.MultiSelect = False
      Me.dlvCounties.Name = "dlvCounties"
      Me.dlvCounties.ShowCommandMenuOnRightClick = True
      Me.dlvCounties.ShowFilterMenuOnRightClick = False
      Me.dlvCounties.ShowGroups = False
      Me.dlvCounties.ShowItemCountOnGroups = True
      Me.dlvCounties.Size = New System.Drawing.Size(450, 204)
      Me.dlvCounties.SortGroupItemsByPrimaryColumn = False
      Me.dlvCounties.TabIndex = 0
      Me.dlvCounties.UseCompatibleStateImageBehavior = False
      Me.dlvCounties.UseFilterIndicator = True
      Me.dlvCounties.UseFiltering = True
      Me.dlvCounties.View = System.Windows.Forms.View.Details
      '
      'olvc1ChapmanCode
      '
      Me.olvc1ChapmanCode.AspectName = "ChapmanCode"
      Me.olvc1ChapmanCode.Groupable = False
      Me.olvc1ChapmanCode.Hideable = False
      Me.olvc1ChapmanCode.IsEditable = False
      Me.olvc1ChapmanCode.MaximumWidth = 80
      Me.olvc1ChapmanCode.MinimumWidth = 80
      Me.olvc1ChapmanCode.Text = "Chapman Code"
      Me.olvc1ChapmanCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.olvc1ChapmanCode.Width = 80
      '
      'olvc1CountyName
      '
      Me.olvc1CountyName.AspectName = "CountyName"
      Me.olvc1CountyName.Groupable = False
      Me.olvc1CountyName.Hideable = False
      Me.olvc1CountyName.IsEditable = False
      Me.olvc1CountyName.MaximumWidth = 150
      Me.olvc1CountyName.MinimumWidth = 80
      Me.olvc1CountyName.Sortable = False
      Me.olvc1CountyName.Text = "Name"
      Me.olvc1CountyName.Width = 150
      '
      'olvc1Notes
      '
      Me.olvc1Notes.AspectName = "Notes"
      Me.olvc1Notes.FillsFreeSpace = True
      Me.olvc1Notes.Groupable = False
      Me.olvc1Notes.Hideable = False
      Me.olvc1Notes.IsEditable = False
      Me.olvc1Notes.Sortable = False
      Me.olvc1Notes.Text = "Notes"
      Me.olvc1Notes.WordWrap = True
      '
      'tabPlaces
      '
      Me.tabPlaces.Controls.Add(Me.dlvPlaces)
      Me.tabPlaces.Location = New System.Drawing.Point(4, 22)
      Me.tabPlaces.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tabPlaces.Name = "tabPlaces"
      Me.tabPlaces.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tabPlaces.Size = New System.Drawing.Size(456, 208)
      Me.tabPlaces.TabIndex = 2
      Me.tabPlaces.Text = "Places"
      Me.tabPlaces.UseVisualStyleBackColor = True
      '
      'dlvPlaces
      '
      Me.dlvPlaces.AllColumns.Add(Me.olvc2PlaceName)
      Me.dlvPlaces.AllColumns.Add(Me.olvc2Notes)
      Me.dlvPlaces.AllColumns.Add(Me.olvc2ChapmanCode)
      Me.dlvPlaces.AllColumns.Add(Me.olvc2CountyName)
      Me.dlvPlaces.AllColumns.Add(Me.olvc2Country)
      Me.dlvPlaces.CellEditUseWholeCell = False
      Me.dlvPlaces.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvc2PlaceName, Me.olvc2Notes})
      Me.dlvPlaces.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvPlaces.DataSource = Nothing
      Me.dlvPlaces.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvPlaces.EmptyListMsg = "The Places table has no entries"
      Me.dlvPlaces.FullRowSelect = True
      Me.dlvPlaces.GridLines = True
      Me.dlvPlaces.HeaderWordWrap = True
      Me.dlvPlaces.Location = New System.Drawing.Point(3, 2)
      Me.dlvPlaces.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.dlvPlaces.MultiSelect = False
      Me.dlvPlaces.Name = "dlvPlaces"
      Me.dlvPlaces.ShowCommandMenuOnRightClick = True
      Me.dlvPlaces.ShowGroups = False
      Me.dlvPlaces.ShowItemCountOnGroups = True
      Me.dlvPlaces.Size = New System.Drawing.Size(450, 204)
      Me.dlvPlaces.SortGroupItemsByPrimaryColumn = False
      Me.dlvPlaces.Sorting = System.Windows.Forms.SortOrder.Ascending
      Me.dlvPlaces.TabIndex = 0
      Me.dlvPlaces.UseCompatibleStateImageBehavior = False
      Me.dlvPlaces.UseFilterIndicator = True
      Me.dlvPlaces.UseFiltering = True
      Me.dlvPlaces.View = System.Windows.Forms.View.Details
      '
      'olvc2PlaceName
      '
      Me.olvc2PlaceName.AspectName = "PlaceName"
      Me.olvc2PlaceName.Groupable = False
      Me.olvc2PlaceName.Hideable = False
      Me.olvc2PlaceName.IsEditable = False
      Me.olvc2PlaceName.MaximumWidth = 120
      Me.olvc2PlaceName.MinimumWidth = 120
      Me.olvc2PlaceName.Text = "Place name"
      Me.olvc2PlaceName.UseFiltering = False
      Me.olvc2PlaceName.Width = 120
      '
      'olvc2Notes
      '
      Me.olvc2Notes.AspectName = "Notes"
      Me.olvc2Notes.FillsFreeSpace = True
      Me.olvc2Notes.Groupable = False
      Me.olvc2Notes.Hideable = False
      Me.olvc2Notes.IsEditable = False
      Me.olvc2Notes.Sortable = False
      Me.olvc2Notes.Text = "Notes"
      '
      'olvc2ChapmanCode
      '
      Me.olvc2ChapmanCode.AspectName = "ChapmanCode"
      Me.olvc2ChapmanCode.DisplayIndex = 2
      Me.olvc2ChapmanCode.IsEditable = False
      Me.olvc2ChapmanCode.IsVisible = False
      Me.olvc2ChapmanCode.MaximumWidth = 80
      Me.olvc2ChapmanCode.MinimumWidth = 80
      Me.olvc2ChapmanCode.Text = "Chapman Code"
      Me.olvc2ChapmanCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.olvc2ChapmanCode.Width = 80
      '
      'olvc2CountyName
      '
      Me.olvc2CountyName.AspectName = "CountyName"
      Me.olvc2CountyName.DisplayIndex = 3
      Me.olvc2CountyName.Groupable = False
      Me.olvc2CountyName.IsEditable = False
      Me.olvc2CountyName.IsVisible = False
      Me.olvc2CountyName.MaximumWidth = 120
      Me.olvc2CountyName.MinimumWidth = 120
      Me.olvc2CountyName.Sortable = False
      Me.olvc2CountyName.Text = "County"
      Me.olvc2CountyName.Width = 120
      '
      'olvc2Country
      '
      Me.olvc2Country.AspectName = "Country"
      Me.olvc2Country.DisplayIndex = 4
      Me.olvc2Country.IsEditable = False
      Me.olvc2Country.IsVisible = False
      Me.olvc2Country.Text = "Country"
      Me.olvc2Country.UseFiltering = False
      Me.olvc2Country.Width = 80
      '
      'tabChurches
      '
      Me.tabChurches.Controls.Add(Me.dlvChurches)
      Me.tabChurches.Location = New System.Drawing.Point(4, 22)
      Me.tabChurches.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tabChurches.Name = "tabChurches"
      Me.tabChurches.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.tabChurches.Size = New System.Drawing.Size(456, 208)
      Me.tabChurches.TabIndex = 0
      Me.tabChurches.Text = "Churches"
      Me.tabChurches.UseVisualStyleBackColor = True
      '
      'dlvChurches
      '
      Me.dlvChurches.AllColumns.Add(Me.olvc3ChurchName)
      Me.dlvChurches.AllColumns.Add(Me.olvc3FileCode)
      Me.dlvChurches.AllColumns.Add(Me.olvc3Notes)
      Me.dlvChurches.AllColumns.Add(Me.olvc3ChapmanCode)
      Me.dlvChurches.AllColumns.Add(Me.olvc3PlaceName)
      Me.dlvChurches.AllColumns.Add(Me.olvc3Denomination)
      Me.dlvChurches.AllColumns.Add(Me.olvc3Location)
      Me.dlvChurches.AllColumns.Add(Me.olvc3Website)
      Me.dlvChurches.AllColumns.Add(Me.olvc3LastAmended)
      Me.dlvChurches.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick
      Me.dlvChurches.CellEditUseWholeCell = False
      Me.dlvChurches.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvc3ChurchName, Me.olvc3FileCode, Me.olvc3Notes})
      Me.dlvChurches.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvChurches.DataSource = Nothing
      Me.dlvChurches.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvChurches.EmptyListMsg = "The Churches table has no entries"
      Me.dlvChurches.FullRowSelect = True
      Me.dlvChurches.GridLines = True
      Me.dlvChurches.HeaderWordWrap = True
      Me.dlvChurches.Location = New System.Drawing.Point(3, 2)
      Me.dlvChurches.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.dlvChurches.MultiSelect = False
      Me.dlvChurches.Name = "dlvChurches"
      Me.dlvChurches.ShowCommandMenuOnRightClick = True
      Me.dlvChurches.ShowGroups = False
      Me.dlvChurches.ShowItemCountOnGroups = True
      Me.dlvChurches.ShowItemToolTips = True
      Me.dlvChurches.Size = New System.Drawing.Size(450, 204)
      Me.dlvChurches.SortGroupItemsByPrimaryColumn = False
      Me.dlvChurches.TabIndex = 0
      Me.dlvChurches.UseCompatibleStateImageBehavior = False
      Me.dlvChurches.UseFilterIndicator = True
      Me.dlvChurches.UseFiltering = True
      Me.dlvChurches.View = System.Windows.Forms.View.Details
      '
      'olvc3ChurchName
      '
      Me.olvc3ChurchName.AspectName = "ChurchName"
      Me.olvc3ChurchName.Groupable = False
      Me.olvc3ChurchName.IsEditable = False
      Me.olvc3ChurchName.Sortable = False
      Me.olvc3ChurchName.Text = "Church Name"
      Me.olvc3ChurchName.Width = 120
      '
      'olvc3FileCode
      '
      Me.olvc3FileCode.AspectName = "FileCode"
      Me.olvc3FileCode.CellEditUseWholeCell = True
      Me.olvc3FileCode.Groupable = False
      Me.olvc3FileCode.Sortable = False
      Me.olvc3FileCode.Text = "File Code"
      Me.olvc3FileCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.olvc3FileCode.ToolTipText = "This field is user-defined and controls that part of the transcription filename t" & _
    "hat is allocated to the place/church"
      Me.olvc3FileCode.Width = 35
      '
      'olvc3Notes
      '
      Me.olvc3Notes.AspectName = "Notes"
      Me.olvc3Notes.FillsFreeSpace = True
      Me.olvc3Notes.Groupable = False
      Me.olvc3Notes.Hideable = False
      Me.olvc3Notes.IsEditable = False
      Me.olvc3Notes.Text = "Notes"
      Me.olvc3Notes.WordWrap = True
      '
      'olvc3ChapmanCode
      '
      Me.olvc3ChapmanCode.AspectName = "ChapmanCode"
      Me.olvc3ChapmanCode.DisplayIndex = 3
      Me.olvc3ChapmanCode.Groupable = False
      Me.olvc3ChapmanCode.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.olvc3ChapmanCode.IsEditable = False
      Me.olvc3ChapmanCode.IsVisible = False
      Me.olvc3ChapmanCode.MaximumWidth = 80
      Me.olvc3ChapmanCode.MinimumWidth = 80
      Me.olvc3ChapmanCode.Text = "Chapman Code"
      Me.olvc3ChapmanCode.Width = 80
      '
      'olvc3PlaceName
      '
      Me.olvc3PlaceName.AspectName = "PlaceName"
      Me.olvc3PlaceName.DisplayIndex = 4
      Me.olvc3PlaceName.Groupable = False
      Me.olvc3PlaceName.IsEditable = False
      Me.olvc3PlaceName.IsVisible = False
      Me.olvc3PlaceName.Text = "Place Name"
      Me.olvc3PlaceName.Width = 92
      '
      'olvc3Denomination
      '
      Me.olvc3Denomination.AspectName = "Denomination"
      Me.olvc3Denomination.DisplayIndex = 5
      Me.olvc3Denomination.Groupable = False
      Me.olvc3Denomination.IsEditable = False
      Me.olvc3Denomination.IsVisible = False
      Me.olvc3Denomination.Sortable = False
      Me.olvc3Denomination.Text = "Denomination"
      '
      'olvc3Location
      '
      Me.olvc3Location.AspectName = "Location"
      Me.olvc3Location.DisplayIndex = 6
      Me.olvc3Location.Groupable = False
      Me.olvc3Location.IsEditable = False
      Me.olvc3Location.IsVisible = False
      Me.olvc3Location.Sortable = False
      Me.olvc3Location.Text = "Location"
      '
      'olvc3Website
      '
      Me.olvc3Website.AspectName = "Website"
      Me.olvc3Website.DisplayIndex = 7
      Me.olvc3Website.Groupable = False
      Me.olvc3Website.IsEditable = False
      Me.olvc3Website.IsVisible = False
      Me.olvc3Website.Sortable = False
      Me.olvc3Website.Text = "Website"
      '
      'olvc3LastAmended
      '
      Me.olvc3LastAmended.AspectName = "LastAmended"
      Me.olvc3LastAmended.DisplayIndex = 8
      Me.olvc3LastAmended.Groupable = False
      Me.olvc3LastAmended.IsEditable = False
      Me.olvc3LastAmended.IsVisible = False
      Me.olvc3LastAmended.Searchable = False
      Me.olvc3LastAmended.Sortable = False
      Me.olvc3LastAmended.Text = "Date last Changed"
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
      Me.SplitContainer1.IsSplitterFixed = True
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.SplitContainer1.Name = "SplitContainer1"
      Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.cboxPlaces)
      Me.SplitContainer1.Panel2.Controls.Add(Me.labPlace)
      Me.SplitContainer1.Panel2.Controls.Add(Me.cboxCounties)
      Me.SplitContainer1.Panel2.Controls.Add(Me.labCounty)
      Me.SplitContainer1.Panel2.Controls.Add(Me.btnFetch)
      Me.SplitContainer1.Panel2.Controls.Add(Me.btnApproved)
      Me.SplitContainer1.Size = New System.Drawing.Size(497, 275)
      Me.SplitContainer1.SplitterDistance = 235
      Me.SplitContainer1.SplitterWidth = 3
      Me.SplitContainer1.TabIndex = 1
      '
      'cboxPlaces
      '
      Me.cboxPlaces.FormattingEnabled = True
      Me.cboxPlaces.Location = New System.Drawing.Point(158, 8)
      Me.cboxPlaces.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.cboxPlaces.Name = "cboxPlaces"
      Me.cboxPlaces.Size = New System.Drawing.Size(187, 21)
      Me.cboxPlaces.TabIndex = 5
      Me.cboxPlaces.Visible = False
      '
      'labPlace
      '
      Me.labPlace.AutoSize = True
      Me.labPlace.Location = New System.Drawing.Point(120, 11)
      Me.labPlace.Name = "labPlace"
      Me.labPlace.Size = New System.Drawing.Size(34, 13)
      Me.labPlace.TabIndex = 4
      Me.labPlace.Text = "Place"
      Me.labPlace.Visible = False
      '
      'cboxCounties
      '
      Me.cboxCounties.FormattingEnabled = True
      Me.cboxCounties.Location = New System.Drawing.Point(51, 8)
      Me.cboxCounties.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.cboxCounties.Name = "cboxCounties"
      Me.cboxCounties.Size = New System.Drawing.Size(61, 21)
      Me.cboxCounties.TabIndex = 3
      Me.cboxCounties.Visible = False
      '
      'labCounty
      '
      Me.labCounty.AutoSize = True
      Me.labCounty.Location = New System.Drawing.Point(9, 11)
      Me.labCounty.Name = "labCounty"
      Me.labCounty.Size = New System.Drawing.Size(40, 13)
      Me.labCounty.TabIndex = 1
      Me.labCounty.Text = "County"
      Me.labCounty.Visible = False
      '
      'btnFetch
      '
      Me.btnFetch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnFetch.AutoSize = True
      Me.btnFetch.Location = New System.Drawing.Point(428, 2)
      Me.btnFetch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
      Me.btnFetch.Name = "btnFetch"
      Me.btnFetch.Size = New System.Drawing.Size(57, 31)
      Me.btnFetch.TabIndex = 0
      Me.btnFetch.Text = "Fetch"
      Me.btnFetch.UseVisualStyleBackColor = True
      '
      'btnApproved
      '
      Me.btnApproved.AutoSize = True
      Me.btnApproved.Font = New System.Drawing.Font("Segoe Condensed", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.btnApproved.Location = New System.Drawing.Point(7, 8)
      Me.btnApproved.Name = "btnApproved"
      Me.btnApproved.Size = New System.Drawing.Size(85, 23)
      Me.btnApproved.TabIndex = 6
      Me.btnApproved.Text = "Show Approved Types"
      Me.btnApproved.UseVisualStyleBackColor = True
      Me.btnApproved.Visible = False
      '
      'backgroundRegisterTypes
      '
      Me.backgroundRegisterTypes.WorkerReportsProgress = True
      '
      'backgroundCounties
      '
      '
      'backgroundPlaces
      '
      '
      'backgroundChurches
      '
      '
      'formFreeregTables
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(497, 275)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.HelpButton = True
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "formFreeregTables"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "WinFreeREG - FreeREG Tables"
      Me.TabControl1.ResumeLayout(False)
      Me.tabRegisterTypes.ResumeLayout(False)
      CType(Me.dlvRegisterTypes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tabCounties.ResumeLayout(False)
      CType(Me.dlvCounties, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tabPlaces.ResumeLayout(False)
      CType(Me.dlvPlaces, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tabChurches.ResumeLayout(False)
      CType(Me.dlvChurches, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.Panel2.PerformLayout()
      Me.SplitContainer1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
	Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
	Friend WithEvents tabChurches As System.Windows.Forms.TabPage
	Friend WithEvents tabCounties As System.Windows.Forms.TabPage
	Friend WithEvents tabPlaces As System.Windows.Forms.TabPage
	Friend WithEvents tabRegisterTypes As System.Windows.Forms.TabPage
	Friend WithEvents dlvRegisterTypes As BrightIdeasSoftware.DataListView
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
	Friend WithEvents btnFetch As System.Windows.Forms.Button
	Friend WithEvents backgroundRegisterTypes As System.ComponentModel.BackgroundWorker
	Friend WithEvents dlvChurches As BrightIdeasSoftware.DataListView
	Friend WithEvents dlvCounties As BrightIdeasSoftware.DataListView
	Friend WithEvents dlvPlaces As BrightIdeasSoftware.DataListView
	Friend WithEvents backgroundCounties As System.ComponentModel.BackgroundWorker
	Friend WithEvents backgroundPlaces As System.ComponentModel.BackgroundWorker
	Friend WithEvents backgroundChurches As System.ComponentModel.BackgroundWorker
	Friend WithEvents cboxCounties As System.Windows.Forms.ComboBox
	Friend WithEvents labCounty As System.Windows.Forms.Label
	Friend WithEvents cboxPlaces As System.Windows.Forms.ComboBox
   Friend WithEvents labPlace As System.Windows.Forms.Label
   Friend WithEvents olvc1ChapmanCode As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc1CountyName As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc1Notes As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc0Type As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc0Description As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc2ChapmanCode As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc2CountyName As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc2PlaceName As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc2Country As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc3ChapmanCode As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc3LastAmended As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc3PlaceName As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc3ChurchName As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc3Location As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc3Denomination As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc3Website As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc3FileCode As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc3Notes As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvc2Notes As BrightIdeasSoftware.OLVColumn
   Friend WithEvents btnApproved As System.Windows.Forms.Button
End Class
