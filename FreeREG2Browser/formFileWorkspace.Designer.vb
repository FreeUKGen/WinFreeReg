<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formFileWorkspace
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formFileWorkspace))
      Me.bsBaptisms = New System.Windows.Forms.BindingSource(Me.components)
      Me.bsBurials = New System.Windows.Forms.BindingSource(Me.components)
      Me.bsMarriages = New System.Windows.Forms.BindingSource(Me.components)
      Me.workspaceBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
      Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorSaveFile = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorFileDetails = New System.Windows.Forms.ToolStripButton()
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.dlvBaptisms = New BrightIdeasSoftware.DataListView()
      Me.olvcRegNo = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcLoadOrder = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcCounty = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcPlace = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcChurch = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcFiche = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcImage = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcBirthDate = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcBaptismDate = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcForenames = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcSex = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcFathersName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcFathersSurname = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcMothersName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcMothersSurname = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcFathersOccupation = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcAbode = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcNotes = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.dlvBurials = New BrightIdeasSoftware.DataListView()
      Me.olvcRegNo1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcLoadOrder1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcFiche1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcImage1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcCounty1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcPlace1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcChurch1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcBurialDate = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcForenames1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcRelationship = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcMaleForenames = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcFemaleForenames = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcRelativeSurname = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcSurname = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcAge = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcAbode1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcNotes1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.dlvMarriages = New BrightIdeasSoftware.DataListView()
      Me.olvcRegNo2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcLoadOrder2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcFiche2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcImage2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcCounty2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcPlace2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcChurch2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcMarriageDate = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcGroomForenames = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcGroomSurname = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcGroomAge = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcGroomParish = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcGroomCondition = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcGroomOccupation = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcGroomAbode = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcBrideForenames = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcBrideSurname = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcBrideAge = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcBrideParish = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcBrideCondition = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcBrideOccupation = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcBrideAbode = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcGroomFatherForenames = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcGroomFatherSurname = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcGroomFatherOccupation = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcBrideFatherForenames = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcBrideFatherSurname = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcBrideFatherOccupation = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcWitness1Forenames = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcWitness1Surname = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcWitness2Forenames = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcWitness2Surname = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcNotes2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      CType(Me.bsBaptisms, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bsBurials, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bsMarriages, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.workspaceBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.workspaceBindingNavigator.SuspendLayout()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      CType(Me.dlvBaptisms, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dlvBurials, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dlvMarriages, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'workspaceBindingNavigator
      '
      Me.workspaceBindingNavigator.AddNewItem = Nothing
      Me.workspaceBindingNavigator.CountItem = Me.BindingNavigatorCountItem
      Me.workspaceBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
      Me.workspaceBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.BindingNavigatorSaveFile, Me.BindingNavigatorFileDetails})
      Me.workspaceBindingNavigator.Location = New System.Drawing.Point(0, 0)
      Me.workspaceBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.workspaceBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.workspaceBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.workspaceBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.workspaceBindingNavigator.Name = "workspaceBindingNavigator"
      Me.workspaceBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
      Me.workspaceBindingNavigator.Size = New System.Drawing.Size(1119, 25)
      Me.workspaceBindingNavigator.TabIndex = 3
      Me.workspaceBindingNavigator.Text = "BindingNavigator1"
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
      Me.BindingNavigatorDeleteItem.Text = "Delete selected record"
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
      'BindingNavigatorAddNewItem
      '
      Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
      Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
      Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorAddNewItem.Text = "Add new record"
      '
      'BindingNavigatorSaveFile
      '
      Me.BindingNavigatorSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorSaveFile.Image = Global.WinFreeReg.My.Resources.Resources.save
      Me.BindingNavigatorSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.BindingNavigatorSaveFile.Name = "BindingNavigatorSaveFile"
      Me.BindingNavigatorSaveFile.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorSaveFile.Text = "Save Transcription File"
      '
      'BindingNavigatorFileDetails
      '
      Me.BindingNavigatorFileDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorFileDetails.Image = Global.WinFreeReg.My.Resources.Resources.appico
      Me.BindingNavigatorFileDetails.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.BindingNavigatorFileDetails.Name = "BindingNavigatorFileDetails"
      Me.BindingNavigatorFileDetails.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorFileDetails.Text = "Edit File Details"
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
      Me.SplitContainer1.Name = "SplitContainer1"
      Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.workspaceBindingNavigator)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.dlvBaptisms)
      Me.SplitContainer1.Panel2.Controls.Add(Me.dlvBurials)
      Me.SplitContainer1.Panel2.Controls.Add(Me.dlvMarriages)
      Me.SplitContainer1.Size = New System.Drawing.Size(1119, 689)
      Me.SplitContainer1.SplitterDistance = 25
      Me.SplitContainer1.SplitterWidth = 5
      Me.SplitContainer1.TabIndex = 4
      '
      'dlvBaptisms
      '
      Me.dlvBaptisms.AllColumns.Add(Me.olvcRegNo)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcLoadOrder)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcCounty)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcPlace)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcChurch)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcFiche)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcImage)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcBirthDate)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcBaptismDate)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcForenames)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcSex)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcFathersName)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcFathersSurname)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcMothersName)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcMothersSurname)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcFathersOccupation)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcAbode)
      Me.dlvBaptisms.AllColumns.Add(Me.olvcNotes)
      Me.dlvBaptisms.AllowColumnReorder = True
      Me.dlvBaptisms.AlternateRowBackColor = System.Drawing.Color.LavenderBlush
      Me.dlvBaptisms.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick
      Me.dlvBaptisms.CellEditEnterChangesRows = True
      Me.dlvBaptisms.CellEditTabChangesRows = True
      Me.dlvBaptisms.CellEditUseWholeCell = False
      Me.dlvBaptisms.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvcRegNo, Me.olvcFiche, Me.olvcImage, Me.olvcBirthDate, Me.olvcBaptismDate, Me.olvcForenames, Me.olvcSex, Me.olvcFathersName, Me.olvcFathersSurname, Me.olvcMothersName, Me.olvcMothersSurname, Me.olvcFathersOccupation, Me.olvcAbode, Me.olvcNotes})
      Me.dlvBaptisms.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvBaptisms.DataSource = Me.bsBaptisms
      Me.dlvBaptisms.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvBaptisms.FullRowSelect = True
      Me.dlvBaptisms.GridLines = True
      Me.dlvBaptisms.HeaderWordWrap = True
      Me.dlvBaptisms.HideSelection = False
      Me.dlvBaptisms.Location = New System.Drawing.Point(0, 0)
      Me.dlvBaptisms.Margin = New System.Windows.Forms.Padding(4)
      Me.dlvBaptisms.MultiSelect = False
      Me.dlvBaptisms.Name = "dlvBaptisms"
      Me.dlvBaptisms.ShowCommandMenuOnRightClick = True
      Me.dlvBaptisms.ShowGroups = False
      Me.dlvBaptisms.ShowItemToolTips = True
      Me.dlvBaptisms.Size = New System.Drawing.Size(1119, 659)
      Me.dlvBaptisms.SortGroupItemsByPrimaryColumn = False
      Me.dlvBaptisms.TabIndex = 0
      Me.dlvBaptisms.TintSortColumn = True
      Me.dlvBaptisms.UseAlternatingBackColors = True
      Me.dlvBaptisms.UseCompatibleStateImageBehavior = False
      Me.dlvBaptisms.View = System.Windows.Forms.View.Details
      Me.dlvBaptisms.Visible = False
      '
      'olvcRegNo
      '
      Me.olvcRegNo.AspectName = "RegNo"
      Me.olvcRegNo.Groupable = False
      Me.olvcRegNo.Text = "Register Number"
      Me.olvcRegNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.olvcRegNo.Width = 53
      Me.olvcRegNo.WordWrap = True
      '
      'olvcLoadOrder
      '
      Me.olvcLoadOrder.AspectName = "LoadOrder"
      Me.olvcLoadOrder.Groupable = False
      Me.olvcLoadOrder.IsEditable = False
      Me.olvcLoadOrder.IsVisible = False
      Me.olvcLoadOrder.Text = "Load Order"
      Me.olvcLoadOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcCounty
      '
      Me.olvcCounty.AspectName = "County"
      Me.olvcCounty.Groupable = False
      Me.olvcCounty.IsEditable = False
      Me.olvcCounty.IsVisible = False
      Me.olvcCounty.Text = "County"
      Me.olvcCounty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcPlace
      '
      Me.olvcPlace.AspectName = "Place"
      Me.olvcPlace.Groupable = False
      Me.olvcPlace.IsEditable = False
      Me.olvcPlace.IsVisible = False
      Me.olvcPlace.Text = "Place"
      '
      'olvcChurch
      '
      Me.olvcChurch.AspectName = "Church"
      Me.olvcChurch.Groupable = False
      Me.olvcChurch.IsEditable = False
      Me.olvcChurch.IsVisible = False
      Me.olvcChurch.Text = "Church"
      '
      'olvcFiche
      '
      Me.olvcFiche.AspectName = "LDSFiche"
      Me.olvcFiche.Groupable = False
      Me.olvcFiche.Text = "Fiche"
      Me.olvcFiche.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcImage
      '
      Me.olvcImage.AspectName = "LDSImage"
      Me.olvcImage.Groupable = False
      Me.olvcImage.Text = "Image"
      Me.olvcImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcBirthDate
      '
      Me.olvcBirthDate.AspectName = "BirthDate"
      Me.olvcBirthDate.Groupable = False
      Me.olvcBirthDate.Text = "Birth Date"
      Me.olvcBirthDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcBaptismDate
      '
      Me.olvcBaptismDate.AspectName = "BaptismDate"
      Me.olvcBaptismDate.Groupable = False
      Me.olvcBaptismDate.Text = "Baptism Date"
      Me.olvcBaptismDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcForenames
      '
      Me.olvcForenames.AspectName = "Forenames"
      Me.olvcForenames.Groupable = False
      Me.olvcForenames.Text = "Forenames"
      '
      'olvcSex
      '
      Me.olvcSex.AspectName = "Sex"
      Me.olvcSex.Groupable = False
      Me.olvcSex.Text = "Sex"
      Me.olvcSex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcFathersName
      '
      Me.olvcFathersName.AspectName = "FathersName"
      Me.olvcFathersName.Groupable = False
      Me.olvcFathersName.Text = "Fathers Name"
      '
      'olvcFathersSurname
      '
      Me.olvcFathersSurname.AspectName = "FathersSurname"
      Me.olvcFathersSurname.Groupable = False
      Me.olvcFathersSurname.Text = "Fathers Surname"
      '
      'olvcMothersName
      '
      Me.olvcMothersName.AspectName = "MothersName"
      Me.olvcMothersName.Groupable = False
      Me.olvcMothersName.Text = "Mothers Name"
      '
      'olvcMothersSurname
      '
      Me.olvcMothersSurname.AspectName = "MothersSurname"
      Me.olvcMothersSurname.Text = "Mothers Surname"
      '
      'olvcFathersOccupation
      '
      Me.olvcFathersOccupation.AspectName = "FathersOccupation"
      Me.olvcFathersOccupation.Groupable = False
      Me.olvcFathersOccupation.Text = "Fathers Occupation"
      '
      'olvcAbode
      '
      Me.olvcAbode.AspectName = "Abode"
      Me.olvcAbode.Groupable = False
      Me.olvcAbode.Text = "Abode"
      '
      'olvcNotes
      '
      Me.olvcNotes.AspectName = "Notes"
      Me.olvcNotes.FillsFreeSpace = True
      Me.olvcNotes.Groupable = False
      Me.olvcNotes.Hideable = False
      Me.olvcNotes.Sortable = False
      Me.olvcNotes.Text = "Notes"
      '
      'dlvBurials
      '
      Me.dlvBurials.AllColumns.Add(Me.olvcRegNo1)
      Me.dlvBurials.AllColumns.Add(Me.olvcLoadOrder1)
      Me.dlvBurials.AllColumns.Add(Me.olvcFiche1)
      Me.dlvBurials.AllColumns.Add(Me.olvcImage1)
      Me.dlvBurials.AllColumns.Add(Me.olvcCounty1)
      Me.dlvBurials.AllColumns.Add(Me.olvcPlace1)
      Me.dlvBurials.AllColumns.Add(Me.olvcChurch1)
      Me.dlvBurials.AllColumns.Add(Me.olvcBurialDate)
      Me.dlvBurials.AllColumns.Add(Me.olvcForenames1)
      Me.dlvBurials.AllColumns.Add(Me.olvcRelationship)
      Me.dlvBurials.AllColumns.Add(Me.olvcMaleForenames)
      Me.dlvBurials.AllColumns.Add(Me.olvcFemaleForenames)
      Me.dlvBurials.AllColumns.Add(Me.olvcRelativeSurname)
      Me.dlvBurials.AllColumns.Add(Me.olvcSurname)
      Me.dlvBurials.AllColumns.Add(Me.olvcAge)
      Me.dlvBurials.AllColumns.Add(Me.olvcAbode1)
      Me.dlvBurials.AllColumns.Add(Me.olvcNotes1)
      Me.dlvBurials.AllowColumnReorder = True
      Me.dlvBurials.AlternateRowBackColor = System.Drawing.Color.Gainsboro
      Me.dlvBurials.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick
      Me.dlvBurials.CellEditEnterChangesRows = True
      Me.dlvBurials.CellEditTabChangesRows = True
      Me.dlvBurials.CellEditUseWholeCell = False
      Me.dlvBurials.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvcRegNo1, Me.olvcFiche1, Me.olvcImage1, Me.olvcBurialDate, Me.olvcForenames1, Me.olvcRelationship, Me.olvcMaleForenames, Me.olvcFemaleForenames, Me.olvcRelativeSurname, Me.olvcSurname, Me.olvcAge, Me.olvcAbode1, Me.olvcNotes1})
      Me.dlvBurials.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvBurials.DataSource = Me.bsBurials
      Me.dlvBurials.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvBurials.FullRowSelect = True
      Me.dlvBurials.GridLines = True
      Me.dlvBurials.HeaderWordWrap = True
      Me.dlvBurials.Location = New System.Drawing.Point(0, 0)
      Me.dlvBurials.Margin = New System.Windows.Forms.Padding(4)
      Me.dlvBurials.MultiSelect = False
      Me.dlvBurials.Name = "dlvBurials"
      Me.dlvBurials.ShowCommandMenuOnRightClick = True
      Me.dlvBurials.ShowItemToolTips = True
      Me.dlvBurials.Size = New System.Drawing.Size(1119, 659)
      Me.dlvBurials.SortGroupItemsByPrimaryColumn = False
      Me.dlvBurials.TabIndex = 1
      Me.dlvBurials.TintSortColumn = True
      Me.dlvBurials.UseAlternatingBackColors = True
      Me.dlvBurials.UseCompatibleStateImageBehavior = False
      Me.dlvBurials.View = System.Windows.Forms.View.Details
      Me.dlvBurials.Visible = False
      '
      'olvcRegNo1
      '
      Me.olvcRegNo1.AspectName = "RegNo"
      Me.olvcRegNo1.Groupable = False
      Me.olvcRegNo1.Text = "Register Number"
      Me.olvcRegNo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.olvcRegNo1.WordWrap = True
      '
      'olvcLoadOrder1
      '
      Me.olvcLoadOrder1.AspectName = "LoadOrder"
      Me.olvcLoadOrder1.Groupable = False
      Me.olvcLoadOrder1.IsVisible = False
      Me.olvcLoadOrder1.Text = "Load Order"
      Me.olvcLoadOrder1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcFiche1
      '
      Me.olvcFiche1.AspectName = "LDSFiche"
      Me.olvcFiche1.Groupable = False
      Me.olvcFiche1.Text = "Fiche"
      Me.olvcFiche1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcImage1
      '
      Me.olvcImage1.AspectName = "LDSImage"
      Me.olvcImage1.Groupable = False
      Me.olvcImage1.Text = "Image"
      Me.olvcImage1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcCounty1
      '
      Me.olvcCounty1.AspectName = "County"
      Me.olvcCounty1.DisplayIndex = 1
      Me.olvcCounty1.Groupable = False
      Me.olvcCounty1.IsEditable = False
      Me.olvcCounty1.IsVisible = False
      Me.olvcCounty1.Text = "County"
      Me.olvcCounty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcPlace1
      '
      Me.olvcPlace1.AspectName = "Place"
      Me.olvcPlace1.DisplayIndex = 2
      Me.olvcPlace1.Groupable = False
      Me.olvcPlace1.IsEditable = False
      Me.olvcPlace1.IsVisible = False
      Me.olvcPlace1.Text = "Place"
      '
      'olvcChurch1
      '
      Me.olvcChurch1.AspectName = "Church"
      Me.olvcChurch1.DisplayIndex = 3
      Me.olvcChurch1.Groupable = False
      Me.olvcChurch1.IsEditable = False
      Me.olvcChurch1.IsVisible = False
      Me.olvcChurch1.Text = "Church"
      '
      'olvcBurialDate
      '
      Me.olvcBurialDate.AspectName = "BurialDate"
      Me.olvcBurialDate.Groupable = False
      Me.olvcBurialDate.Text = "Burial Date"
      Me.olvcBurialDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcForenames1
      '
      Me.olvcForenames1.AspectName = "Forenames"
      Me.olvcForenames1.Groupable = False
      Me.olvcForenames1.Text = "Forenames"
      '
      'olvcRelationship
      '
      Me.olvcRelationship.AspectName = "Relationship"
      Me.olvcRelationship.Groupable = False
      Me.olvcRelationship.Text = "Relationship"
      '
      'olvcMaleForenames
      '
      Me.olvcMaleForenames.AspectName = "MaleForenames"
      Me.olvcMaleForenames.Groupable = False
      Me.olvcMaleForenames.Text = "Male Forenames"
      '
      'olvcFemaleForenames
      '
      Me.olvcFemaleForenames.AspectName = "FemaleForenames"
      Me.olvcFemaleForenames.Groupable = False
      Me.olvcFemaleForenames.Text = "Female Forenames"
      '
      'olvcRelativeSurname
      '
      Me.olvcRelativeSurname.AspectName = "RelativeSurname"
      Me.olvcRelativeSurname.Groupable = False
      Me.olvcRelativeSurname.Text = "Relative Surname"
      '
      'olvcSurname
      '
      Me.olvcSurname.AspectName = "Surname"
      Me.olvcSurname.Groupable = False
      Me.olvcSurname.Text = "Surname"
      '
      'olvcAge
      '
      Me.olvcAge.AspectName = "Age"
      Me.olvcAge.Groupable = False
      Me.olvcAge.Text = "Age"
      Me.olvcAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcAbode1
      '
      Me.olvcAbode1.AspectName = "Abode"
      Me.olvcAbode1.Groupable = False
      Me.olvcAbode1.Text = "Abode"
      '
      'olvcNotes1
      '
      Me.olvcNotes1.AspectName = "Notes"
      Me.olvcNotes1.FillsFreeSpace = True
      Me.olvcNotes1.Groupable = False
      Me.olvcNotes1.Hideable = False
      Me.olvcNotes1.Sortable = False
      Me.olvcNotes1.Text = "Notes"
      '
      'dlvMarriages
      '
      Me.dlvMarriages.AllColumns.Add(Me.olvcRegNo2)
      Me.dlvMarriages.AllColumns.Add(Me.olvcLoadOrder2)
      Me.dlvMarriages.AllColumns.Add(Me.olvcFiche2)
      Me.dlvMarriages.AllColumns.Add(Me.olvcImage2)
      Me.dlvMarriages.AllColumns.Add(Me.olvcCounty2)
      Me.dlvMarriages.AllColumns.Add(Me.olvcPlace2)
      Me.dlvMarriages.AllColumns.Add(Me.olvcChurch2)
      Me.dlvMarriages.AllColumns.Add(Me.olvcMarriageDate)
      Me.dlvMarriages.AllColumns.Add(Me.olvcGroomForenames)
      Me.dlvMarriages.AllColumns.Add(Me.olvcGroomSurname)
      Me.dlvMarriages.AllColumns.Add(Me.olvcGroomAge)
      Me.dlvMarriages.AllColumns.Add(Me.olvcGroomParish)
      Me.dlvMarriages.AllColumns.Add(Me.olvcGroomCondition)
      Me.dlvMarriages.AllColumns.Add(Me.olvcGroomOccupation)
      Me.dlvMarriages.AllColumns.Add(Me.olvcGroomAbode)
      Me.dlvMarriages.AllColumns.Add(Me.olvcBrideForenames)
      Me.dlvMarriages.AllColumns.Add(Me.olvcBrideSurname)
      Me.dlvMarriages.AllColumns.Add(Me.olvcBrideAge)
      Me.dlvMarriages.AllColumns.Add(Me.olvcBrideParish)
      Me.dlvMarriages.AllColumns.Add(Me.olvcBrideCondition)
      Me.dlvMarriages.AllColumns.Add(Me.olvcBrideOccupation)
      Me.dlvMarriages.AllColumns.Add(Me.olvcBrideAbode)
      Me.dlvMarriages.AllColumns.Add(Me.olvcGroomFatherForenames)
      Me.dlvMarriages.AllColumns.Add(Me.olvcGroomFatherSurname)
      Me.dlvMarriages.AllColumns.Add(Me.olvcGroomFatherOccupation)
      Me.dlvMarriages.AllColumns.Add(Me.olvcBrideFatherForenames)
      Me.dlvMarriages.AllColumns.Add(Me.olvcBrideFatherSurname)
      Me.dlvMarriages.AllColumns.Add(Me.olvcBrideFatherOccupation)
      Me.dlvMarriages.AllColumns.Add(Me.olvcWitness1Forenames)
      Me.dlvMarriages.AllColumns.Add(Me.olvcWitness1Surname)
      Me.dlvMarriages.AllColumns.Add(Me.olvcWitness2Forenames)
      Me.dlvMarriages.AllColumns.Add(Me.olvcWitness2Surname)
      Me.dlvMarriages.AllColumns.Add(Me.olvcNotes2)
      Me.dlvMarriages.AllowColumnReorder = True
      Me.dlvMarriages.AlternateRowBackColor = System.Drawing.Color.Honeydew
      Me.dlvMarriages.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick
      Me.dlvMarriages.CellEditEnterChangesRows = True
      Me.dlvMarriages.CellEditTabChangesRows = True
      Me.dlvMarriages.CellEditUseWholeCell = False
      Me.dlvMarriages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvcRegNo2, Me.olvcFiche2, Me.olvcImage2, Me.olvcMarriageDate, Me.olvcGroomForenames, Me.olvcGroomSurname, Me.olvcGroomAge, Me.olvcGroomParish, Me.olvcGroomCondition, Me.olvcGroomOccupation, Me.olvcGroomAbode, Me.olvcBrideForenames, Me.olvcBrideSurname, Me.olvcBrideAge, Me.olvcBrideParish, Me.olvcBrideCondition, Me.olvcBrideOccupation, Me.olvcBrideAbode, Me.olvcGroomFatherForenames, Me.olvcGroomFatherSurname, Me.olvcGroomFatherOccupation, Me.olvcBrideFatherForenames, Me.olvcBrideFatherSurname, Me.olvcBrideFatherOccupation, Me.olvcWitness1Forenames, Me.olvcWitness1Surname, Me.olvcWitness2Forenames, Me.olvcWitness2Surname, Me.olvcNotes2})
      Me.dlvMarriages.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvMarriages.DataSource = Me.bsMarriages
      Me.dlvMarriages.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvMarriages.FullRowSelect = True
      Me.dlvMarriages.GridLines = True
      Me.dlvMarriages.HeaderWordWrap = True
      Me.dlvMarriages.Location = New System.Drawing.Point(0, 0)
      Me.dlvMarriages.Margin = New System.Windows.Forms.Padding(4)
      Me.dlvMarriages.MultiSelect = False
      Me.dlvMarriages.Name = "dlvMarriages"
      Me.dlvMarriages.ShowCommandMenuOnRightClick = True
      Me.dlvMarriages.ShowItemToolTips = True
      Me.dlvMarriages.Size = New System.Drawing.Size(1119, 659)
      Me.dlvMarriages.SortGroupItemsByPrimaryColumn = False
      Me.dlvMarriages.TabIndex = 2
      Me.dlvMarriages.TintSortColumn = True
      Me.dlvMarriages.UseAlternatingBackColors = True
      Me.dlvMarriages.UseCompatibleStateImageBehavior = False
      Me.dlvMarriages.View = System.Windows.Forms.View.Details
      Me.dlvMarriages.Visible = False
      '
      'olvcRegNo2
      '
      Me.olvcRegNo2.AspectName = "RegNo"
      Me.olvcRegNo2.Groupable = False
      Me.olvcRegNo2.Text = "Register Number"
      Me.olvcRegNo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.olvcRegNo2.WordWrap = True
      '
      'olvcLoadOrder2
      '
      Me.olvcLoadOrder2.AspectName = "LoadOrder"
      Me.olvcLoadOrder2.Groupable = False
      Me.olvcLoadOrder2.IsVisible = False
      Me.olvcLoadOrder2.Text = "Load Order"
      Me.olvcLoadOrder2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcFiche2
      '
      Me.olvcFiche2.AspectName = "LDSFiche"
      Me.olvcFiche2.Groupable = False
      Me.olvcFiche2.Text = "Fiche"
      Me.olvcFiche2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcImage2
      '
      Me.olvcImage2.AspectName = "LDSImage"
      Me.olvcImage2.Groupable = False
      Me.olvcImage2.Text = "Image"
      Me.olvcImage2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcCounty2
      '
      Me.olvcCounty2.AspectName = "County"
      Me.olvcCounty2.DisplayIndex = 1
      Me.olvcCounty2.Groupable = False
      Me.olvcCounty2.IsEditable = False
      Me.olvcCounty2.IsVisible = False
      Me.olvcCounty2.Text = "County"
      Me.olvcCounty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcPlace2
      '
      Me.olvcPlace2.AspectName = "Place"
      Me.olvcPlace2.DisplayIndex = 2
      Me.olvcPlace2.Groupable = False
      Me.olvcPlace2.IsEditable = False
      Me.olvcPlace2.IsVisible = False
      Me.olvcPlace2.Text = "Place"
      '
      'olvcChurch2
      '
      Me.olvcChurch2.AspectName = "Church"
      Me.olvcChurch2.DisplayIndex = 3
      Me.olvcChurch2.Groupable = False
      Me.olvcChurch2.IsEditable = False
      Me.olvcChurch2.IsVisible = False
      Me.olvcChurch2.Text = "Church"
      '
      'olvcMarriageDate
      '
      Me.olvcMarriageDate.AspectName = "MarriageDate"
      Me.olvcMarriageDate.Groupable = False
      Me.olvcMarriageDate.Text = "Marriage Date"
      Me.olvcMarriageDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcGroomForenames
      '
      Me.olvcGroomForenames.AspectName = "GroomForenames"
      Me.olvcGroomForenames.Groupable = False
      Me.olvcGroomForenames.Text = "Groom Forenames"
      '
      'olvcGroomSurname
      '
      Me.olvcGroomSurname.AspectName = "GroomSurname"
      Me.olvcGroomSurname.Groupable = False
      Me.olvcGroomSurname.Text = "Groom Surname"
      '
      'olvcGroomAge
      '
      Me.olvcGroomAge.AspectName = "GroomAge"
      Me.olvcGroomAge.Groupable = False
      Me.olvcGroomAge.Text = "Groom Age"
      Me.olvcGroomAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcGroomParish
      '
      Me.olvcGroomParish.AspectName = "GroomParish"
      Me.olvcGroomParish.Groupable = False
      Me.olvcGroomParish.Text = "Groom Parish"
      '
      'olvcGroomCondition
      '
      Me.olvcGroomCondition.AspectName = "GroomCondition"
      Me.olvcGroomCondition.Groupable = False
      Me.olvcGroomCondition.Text = "Groom Condition"
      '
      'olvcGroomOccupation
      '
      Me.olvcGroomOccupation.AspectName = "GroomOccupation"
      Me.olvcGroomOccupation.Groupable = False
      Me.olvcGroomOccupation.Text = "Groom Occupation"
      '
      'olvcGroomAbode
      '
      Me.olvcGroomAbode.AspectName = "GroomAbode"
      Me.olvcGroomAbode.Groupable = False
      Me.olvcGroomAbode.Text = "Groom Abode"
      '
      'olvcBrideForenames
      '
      Me.olvcBrideForenames.AspectName = "BrideForenames"
      Me.olvcBrideForenames.Groupable = False
      Me.olvcBrideForenames.Text = "Bride Forenames"
      '
      'olvcBrideSurname
      '
      Me.olvcBrideSurname.AspectName = "BrideSurname"
      Me.olvcBrideSurname.Groupable = False
      Me.olvcBrideSurname.Text = "Bride Surname"
      '
      'olvcBrideAge
      '
      Me.olvcBrideAge.AspectName = "BrideAge"
      Me.olvcBrideAge.Groupable = False
      Me.olvcBrideAge.Text = "Bride Age"
      Me.olvcBrideAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcBrideParish
      '
      Me.olvcBrideParish.AspectName = "BrideParish"
      Me.olvcBrideParish.Groupable = False
      Me.olvcBrideParish.Text = "Bride Parish"
      '
      'olvcBrideCondition
      '
      Me.olvcBrideCondition.AspectName = "BrideCondition"
      Me.olvcBrideCondition.Groupable = False
      Me.olvcBrideCondition.Text = "Bride Condition"
      '
      'olvcBrideOccupation
      '
      Me.olvcBrideOccupation.AspectName = "BrideOccupation"
      Me.olvcBrideOccupation.Groupable = False
      Me.olvcBrideOccupation.Text = "Bride Occupation"
      '
      'olvcBrideAbode
      '
      Me.olvcBrideAbode.AspectName = "BrideAbode"
      Me.olvcBrideAbode.Groupable = False
      Me.olvcBrideAbode.Text = "Bride Abode"
      '
      'olvcGroomFatherForenames
      '
      Me.olvcGroomFatherForenames.AspectName = "GroomFatherForenames"
      Me.olvcGroomFatherForenames.Groupable = False
      Me.olvcGroomFatherForenames.Text = "Groom Father Forenames"
      '
      'olvcGroomFatherSurname
      '
      Me.olvcGroomFatherSurname.AspectName = "GroomFatherSurname"
      Me.olvcGroomFatherSurname.Groupable = False
      Me.olvcGroomFatherSurname.Text = "Groom Father Surname"
      '
      'olvcGroomFatherOccupation
      '
      Me.olvcGroomFatherOccupation.AspectName = "GroomFatherOccupation"
      Me.olvcGroomFatherOccupation.Groupable = False
      Me.olvcGroomFatherOccupation.Text = "Groom Father Occupation"
      '
      'olvcBrideFatherForenames
      '
      Me.olvcBrideFatherForenames.AspectName = "BrideFatherForenames"
      Me.olvcBrideFatherForenames.Groupable = False
      Me.olvcBrideFatherForenames.Text = "Bride Father Forenames"
      '
      'olvcBrideFatherSurname
      '
      Me.olvcBrideFatherSurname.AspectName = "BrideFatherSurname"
      Me.olvcBrideFatherSurname.Groupable = False
      Me.olvcBrideFatherSurname.Text = "Bride Father Surname"
      '
      'olvcBrideFatherOccupation
      '
      Me.olvcBrideFatherOccupation.AspectName = "BrideFatherOccupation"
      Me.olvcBrideFatherOccupation.Groupable = False
      Me.olvcBrideFatherOccupation.Text = "Bride Father Occupation"
      '
      'olvcWitness1Forenames
      '
      Me.olvcWitness1Forenames.AspectName = "Witness1Forenames"
      Me.olvcWitness1Forenames.Groupable = False
      Me.olvcWitness1Forenames.Text = "Witness 1 Forenames"
      '
      'olvcWitness1Surname
      '
      Me.olvcWitness1Surname.AspectName = "Witness1Surname"
      Me.olvcWitness1Surname.Groupable = False
      Me.olvcWitness1Surname.Text = "Witness 1 Surname"
      '
      'olvcWitness2Forenames
      '
      Me.olvcWitness2Forenames.AspectName = "Witness2Forenames"
      Me.olvcWitness2Forenames.Groupable = False
      Me.olvcWitness2Forenames.Text = "Witness 2 Forenames"
      '
      'olvcWitness2Surname
      '
      Me.olvcWitness2Surname.AspectName = "Witness2Surname"
      Me.olvcWitness2Surname.Groupable = False
      Me.olvcWitness2Surname.Text = "Witness 2 Surname"
      '
      'olvcNotes2
      '
      Me.olvcNotes2.AspectName = "Notes"
      Me.olvcNotes2.FillsFreeSpace = True
      Me.olvcNotes2.Groupable = False
      Me.olvcNotes2.Hideable = False
      Me.olvcNotes2.Sortable = False
      Me.olvcNotes2.Text = "Notes"
      '
      'formFileWorkspace
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1119, 689)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.Name = "formFileWorkspace"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "WinFreeREG - File Workspace - {0}"
      CType(Me.bsBaptisms, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bsBurials, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bsMarriages, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.workspaceBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
      Me.workspaceBindingNavigator.ResumeLayout(False)
      Me.workspaceBindingNavigator.PerformLayout()
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel1.PerformLayout()
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      CType(Me.dlvBaptisms, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dlvBurials, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dlvMarriages, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents dlvBaptisms As BrightIdeasSoftware.DataListView
   Friend WithEvents dlvBurials As BrightIdeasSoftware.DataListView
   Friend WithEvents dlvMarriages As BrightIdeasSoftware.DataListView
   Friend WithEvents olvcRegNo As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcCounty As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcPlace As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcChurch As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcNotes As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcRegNo1 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcCounty1 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcPlace1 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcChurch1 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcNotes1 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcRegNo2 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcCounty2 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcPlace2 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcChurch2 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcNotes2 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcBirthDate As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcBaptismDate As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcForenames As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcSex As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcLoadOrder As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcFathersName As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcMothersName As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcFathersSurname As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcMothersSurname As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcAbode As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcFathersOccupation As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcFiche As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcImage As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcFiche1 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcImage1 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcFiche2 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcImage2 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcLoadOrder1 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcLoadOrder2 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcBurialDate As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcForenames1 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcRelationship As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcMaleForenames As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcFemaleForenames As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcRelativeSurname As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcSurname As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcAge As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcAbode1 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcMarriageDate As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcGroomForenames As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcGroomSurname As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcGroomAge As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcGroomParish As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcGroomCondition As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcGroomOccupation As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcGroomAbode As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcBrideForenames As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcBrideSurname As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcBrideAge As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcBrideParish As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcBrideCondition As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcBrideOccupation As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcBrideAbode As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcGroomFatherForenames As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcGroomFatherSurname As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcGroomFatherOccupation As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcBrideFatherForenames As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcBrideFatherSurname As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcBrideFatherOccupation As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcWitness1Forenames As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcWitness2Forenames As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcWitness1Surname As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcWitness2Surname As BrightIdeasSoftware.OLVColumn
   Friend WithEvents bsBaptisms As System.Windows.Forms.BindingSource
   Friend WithEvents bsBurials As System.Windows.Forms.BindingSource
   Friend WithEvents bsMarriages As System.Windows.Forms.BindingSource
   Friend WithEvents workspaceBindingNavigator As System.Windows.Forms.BindingNavigator
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
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
	Friend WithEvents BindingNavigatorSaveFile As System.Windows.Forms.ToolStripButton
   Friend WithEvents BindingNavigatorFileDetails As System.Windows.Forms.ToolStripButton
End Class
