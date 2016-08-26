<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formUserTables
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formUserTables))
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.UserTablesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
      Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
      Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
      Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
      Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
      Me.BindingNavigatorSaveChanges = New System.Windows.Forms.ToolStripButton()
      Me.UserTablesTabControl = New System.Windows.Forms.TabControl()
      Me.tabBaptismSex = New System.Windows.Forms.TabPage()
      Me.dlvBaptismSex = New BrightIdeasSoftware.DataListView()
      Me.olvcCode = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcType = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcDescription = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.bsBaptismSex = New System.Windows.Forms.BindingSource(Me.components)
      Me.tabBurialRelationship = New System.Windows.Forms.TabPage()
      Me.dlvBurialRelationship = New BrightIdeasSoftware.DataListView()
      Me.olvcFileValue1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcType1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcDisplayValue1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.bsBurialRelationship = New System.Windows.Forms.BindingSource(Me.components)
      Me.tabGroomCondition = New System.Windows.Forms.TabPage()
      Me.dlvGroomCondition = New BrightIdeasSoftware.DataListView()
      Me.olvcFileValue2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcType2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcDisplayValue2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.bsGroomCondition = New System.Windows.Forms.BindingSource(Me.components)
      Me.tabBrideCondition = New System.Windows.Forms.TabPage()
      Me.dlvBrideCondition = New BrightIdeasSoftware.DataListView()
      Me.olvcFileValue3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcType3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcDisplayValue3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.bsBrideCOndition = New System.Windows.Forms.BindingSource(Me.components)
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      CType(Me.UserTablesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.UserTablesBindingNavigator.SuspendLayout()
      Me.UserTablesTabControl.SuspendLayout()
      Me.tabBaptismSex.SuspendLayout()
      CType(Me.dlvBaptismSex, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bsBaptismSex, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tabBurialRelationship.SuspendLayout()
      CType(Me.dlvBurialRelationship, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bsBurialRelationship, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tabGroomCondition.SuspendLayout()
      CType(Me.dlvGroomCondition, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bsGroomCondition, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tabBrideCondition.SuspendLayout()
      CType(Me.dlvBrideCondition, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bsBrideCOndition, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer1.Name = "SplitContainer1"
      Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.UserTablesBindingNavigator)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.UserTablesTabControl)
      Me.SplitContainer1.Size = New System.Drawing.Size(542, 340)
      Me.SplitContainer1.SplitterDistance = 25
      Me.SplitContainer1.TabIndex = 0
      '
      'UserTablesBindingNavigator
      '
      Me.UserTablesBindingNavigator.AddNewItem = Nothing
      Me.UserTablesBindingNavigator.CountItem = Me.BindingNavigatorCountItem
      Me.UserTablesBindingNavigator.DeleteItem = Nothing
      Me.UserTablesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.BindingNavigatorSaveChanges})
      Me.UserTablesBindingNavigator.Location = New System.Drawing.Point(0, 0)
      Me.UserTablesBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.UserTablesBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.UserTablesBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.UserTablesBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.UserTablesBindingNavigator.Name = "UserTablesBindingNavigator"
      Me.UserTablesBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
      Me.UserTablesBindingNavigator.Size = New System.Drawing.Size(542, 25)
      Me.UserTablesBindingNavigator.TabIndex = 0
      Me.UserTablesBindingNavigator.Text = "BindingNavigator1"
      '
      'BindingNavigatorCountItem
      '
      Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
      Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
      Me.BindingNavigatorCountItem.Text = "of {0}"
      Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
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
      Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
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
      Me.BindingNavigatorAddNewItem.Text = "Add new"
      '
      'BindingNavigatorDeleteItem
      '
      Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
      Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
      Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
      Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorDeleteItem.Text = "Delete"
      '
      'BindingNavigatorSaveChanges
      '
      Me.BindingNavigatorSaveChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.BindingNavigatorSaveChanges.Image = Global.WinFreeReg.My.Resources.Resources.save
      Me.BindingNavigatorSaveChanges.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.BindingNavigatorSaveChanges.Name = "BindingNavigatorSaveChanges"
      Me.BindingNavigatorSaveChanges.Size = New System.Drawing.Size(23, 22)
      Me.BindingNavigatorSaveChanges.Text = "Save"
      '
      'UserTablesTabControl
      '
      Me.UserTablesTabControl.Controls.Add(Me.tabBaptismSex)
      Me.UserTablesTabControl.Controls.Add(Me.tabBurialRelationship)
      Me.UserTablesTabControl.Controls.Add(Me.tabGroomCondition)
      Me.UserTablesTabControl.Controls.Add(Me.tabBrideCondition)
      Me.UserTablesTabControl.Dock = System.Windows.Forms.DockStyle.Fill
      Me.UserTablesTabControl.Location = New System.Drawing.Point(0, 0)
      Me.UserTablesTabControl.Name = "UserTablesTabControl"
      Me.UserTablesTabControl.SelectedIndex = 0
      Me.UserTablesTabControl.Size = New System.Drawing.Size(542, 311)
      Me.UserTablesTabControl.TabIndex = 0
      '
      'tabBaptismSex
      '
      Me.tabBaptismSex.Controls.Add(Me.dlvBaptismSex)
      Me.tabBaptismSex.Location = New System.Drawing.Point(4, 22)
      Me.tabBaptismSex.Name = "tabBaptismSex"
      Me.tabBaptismSex.Padding = New System.Windows.Forms.Padding(3)
      Me.tabBaptismSex.Size = New System.Drawing.Size(534, 285)
      Me.tabBaptismSex.TabIndex = 0
      Me.tabBaptismSex.Text = "Baptism Sex"
      Me.tabBaptismSex.UseVisualStyleBackColor = True
      '
      'dlvBaptismSex
      '
      Me.dlvBaptismSex.AllColumns.Add(Me.olvcCode)
      Me.dlvBaptismSex.AllColumns.Add(Me.olvcType)
      Me.dlvBaptismSex.AllColumns.Add(Me.olvcDescription)
      Me.dlvBaptismSex.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick
      Me.dlvBaptismSex.CellEditUseWholeCell = False
      Me.dlvBaptismSex.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvcCode, Me.olvcDescription})
      Me.dlvBaptismSex.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvBaptismSex.DataSource = Me.bsBaptismSex
      Me.dlvBaptismSex.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvBaptismSex.FullRowSelect = True
      Me.dlvBaptismSex.GridLines = True
      Me.dlvBaptismSex.Location = New System.Drawing.Point(3, 3)
      Me.dlvBaptismSex.MultiSelect = False
      Me.dlvBaptismSex.Name = "dlvBaptismSex"
      Me.dlvBaptismSex.ShowGroups = False
      Me.dlvBaptismSex.Size = New System.Drawing.Size(528, 279)
      Me.dlvBaptismSex.TabIndex = 0
      Me.dlvBaptismSex.UseCompatibleStateImageBehavior = False
      Me.dlvBaptismSex.View = System.Windows.Forms.View.Details
      '
      'olvcCode
      '
      Me.olvcCode.AspectName = "Code"
      Me.olvcCode.Groupable = False
      Me.olvcCode.Text = "Code"
      Me.olvcCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcType
      '
      Me.olvcType.AspectName = "Type"
      Me.olvcType.IsVisible = False
      Me.olvcType.Text = "Type"
      '
      'olvcDescription
      '
      Me.olvcDescription.AspectName = "Description"
      Me.olvcDescription.FillsFreeSpace = True
      Me.olvcDescription.Groupable = False
      Me.olvcDescription.Text = "Description"
      '
      'bsBaptismSex
      '
      Me.bsBaptismSex.DataMember = "BaptismSex"
      Me.bsBaptismSex.DataSource = GetType(WinFreeReg.LookupTables)
      '
      'tabBurialRelationship
      '
      Me.tabBurialRelationship.Controls.Add(Me.dlvBurialRelationship)
      Me.tabBurialRelationship.Location = New System.Drawing.Point(4, 22)
      Me.tabBurialRelationship.Name = "tabBurialRelationship"
      Me.tabBurialRelationship.Padding = New System.Windows.Forms.Padding(3)
      Me.tabBurialRelationship.Size = New System.Drawing.Size(534, 285)
      Me.tabBurialRelationship.TabIndex = 1
      Me.tabBurialRelationship.Text = "Burial Relationships"
      Me.tabBurialRelationship.UseVisualStyleBackColor = True
      '
      'dlvBurialRelationship
      '
      Me.dlvBurialRelationship.AllColumns.Add(Me.olvcFileValue1)
      Me.dlvBurialRelationship.AllColumns.Add(Me.olvcType1)
      Me.dlvBurialRelationship.AllColumns.Add(Me.olvcDisplayValue1)
      Me.dlvBurialRelationship.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick
      Me.dlvBurialRelationship.CellEditUseWholeCell = False
      Me.dlvBurialRelationship.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvcFileValue1, Me.olvcDisplayValue1})
      Me.dlvBurialRelationship.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvBurialRelationship.DataSource = Me.bsBurialRelationship
      Me.dlvBurialRelationship.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvBurialRelationship.FullRowSelect = True
      Me.dlvBurialRelationship.GridLines = True
      Me.dlvBurialRelationship.Location = New System.Drawing.Point(3, 3)
      Me.dlvBurialRelationship.MultiSelect = False
      Me.dlvBurialRelationship.Name = "dlvBurialRelationship"
      Me.dlvBurialRelationship.ShowGroups = False
      Me.dlvBurialRelationship.Size = New System.Drawing.Size(528, 279)
      Me.dlvBurialRelationship.TabIndex = 0
      Me.dlvBurialRelationship.UseCompatibleStateImageBehavior = False
      Me.dlvBurialRelationship.View = System.Windows.Forms.View.Details
      '
      'olvcFileValue1
      '
      Me.olvcFileValue1.AspectName = "FileValue"
      Me.olvcFileValue1.Groupable = False
      Me.olvcFileValue1.Text = "Code"
      Me.olvcFileValue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcType1
      '
      Me.olvcType1.AspectName = "Type"
      Me.olvcType1.DisplayIndex = 0
      Me.olvcType1.Groupable = False
      Me.olvcType1.IsVisible = False
      Me.olvcType1.Text = "Type"
      '
      'olvcDisplayValue1
      '
      Me.olvcDisplayValue1.AspectName = "DisplayValue"
      Me.olvcDisplayValue1.FillsFreeSpace = True
      Me.olvcDisplayValue1.Groupable = False
      Me.olvcDisplayValue1.Text = "Description"
      '
      'bsBurialRelationship
      '
      Me.bsBurialRelationship.DataMember = "BurialRelationship"
      Me.bsBurialRelationship.DataSource = GetType(WinFreeReg.LookupTables)
      '
      'tabGroomCondition
      '
      Me.tabGroomCondition.Controls.Add(Me.dlvGroomCondition)
      Me.tabGroomCondition.Location = New System.Drawing.Point(4, 22)
      Me.tabGroomCondition.Name = "tabGroomCondition"
      Me.tabGroomCondition.Padding = New System.Windows.Forms.Padding(3)
      Me.tabGroomCondition.Size = New System.Drawing.Size(534, 285)
      Me.tabGroomCondition.TabIndex = 2
      Me.tabGroomCondition.Text = "Groom Conditions"
      Me.tabGroomCondition.UseVisualStyleBackColor = True
      '
      'dlvGroomCondition
      '
      Me.dlvGroomCondition.AllColumns.Add(Me.olvcFileValue2)
      Me.dlvGroomCondition.AllColumns.Add(Me.olvcType2)
      Me.dlvGroomCondition.AllColumns.Add(Me.olvcDisplayValue2)
      Me.dlvGroomCondition.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick
      Me.dlvGroomCondition.CellEditUseWholeCell = False
      Me.dlvGroomCondition.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvcFileValue2, Me.olvcDisplayValue2})
      Me.dlvGroomCondition.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvGroomCondition.DataSource = Me.bsGroomCondition
      Me.dlvGroomCondition.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvGroomCondition.FullRowSelect = True
      Me.dlvGroomCondition.GridLines = True
      Me.dlvGroomCondition.Location = New System.Drawing.Point(3, 3)
      Me.dlvGroomCondition.MultiSelect = False
      Me.dlvGroomCondition.Name = "dlvGroomCondition"
      Me.dlvGroomCondition.ShowGroups = False
      Me.dlvGroomCondition.Size = New System.Drawing.Size(528, 279)
      Me.dlvGroomCondition.TabIndex = 0
      Me.dlvGroomCondition.UseCompatibleStateImageBehavior = False
      Me.dlvGroomCondition.View = System.Windows.Forms.View.Details
      '
      'olvcFileValue2
      '
      Me.olvcFileValue2.AspectName = "FileValue"
      Me.olvcFileValue2.Groupable = False
      Me.olvcFileValue2.Text = "Code"
      Me.olvcFileValue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcType2
      '
      Me.olvcType2.AspectName = "Type"
      Me.olvcType2.Groupable = False
      Me.olvcType2.IsVisible = False
      Me.olvcType2.Text = "Type"
      '
      'olvcDisplayValue2
      '
      Me.olvcDisplayValue2.AspectName = "DisplayValue"
      Me.olvcDisplayValue2.FillsFreeSpace = True
      Me.olvcDisplayValue2.Groupable = False
      Me.olvcDisplayValue2.Text = "Description"
      '
      'bsGroomCondition
      '
      Me.bsGroomCondition.DataMember = "GroomCondition"
      Me.bsGroomCondition.DataSource = GetType(WinFreeReg.LookupTables)
      '
      'tabBrideCondition
      '
      Me.tabBrideCondition.Controls.Add(Me.dlvBrideCondition)
      Me.tabBrideCondition.Location = New System.Drawing.Point(4, 22)
      Me.tabBrideCondition.Name = "tabBrideCondition"
      Me.tabBrideCondition.Padding = New System.Windows.Forms.Padding(3)
      Me.tabBrideCondition.Size = New System.Drawing.Size(534, 285)
      Me.tabBrideCondition.TabIndex = 3
      Me.tabBrideCondition.Text = "Bride Conditions"
      Me.tabBrideCondition.UseVisualStyleBackColor = True
      '
      'dlvBrideCondition
      '
      Me.dlvBrideCondition.AllColumns.Add(Me.olvcFileValue3)
      Me.dlvBrideCondition.AllColumns.Add(Me.olvcType3)
      Me.dlvBrideCondition.AllColumns.Add(Me.olvcDisplayValue3)
      Me.dlvBrideCondition.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick
      Me.dlvBrideCondition.CellEditUseWholeCell = False
      Me.dlvBrideCondition.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvcFileValue3, Me.olvcDisplayValue3})
      Me.dlvBrideCondition.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvBrideCondition.DataSource = Me.bsBrideCOndition
      Me.dlvBrideCondition.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvBrideCondition.FullRowSelect = True
      Me.dlvBrideCondition.GridLines = True
      Me.dlvBrideCondition.Location = New System.Drawing.Point(3, 3)
      Me.dlvBrideCondition.MultiSelect = False
      Me.dlvBrideCondition.Name = "dlvBrideCondition"
      Me.dlvBrideCondition.ShowGroups = False
      Me.dlvBrideCondition.Size = New System.Drawing.Size(528, 279)
      Me.dlvBrideCondition.TabIndex = 0
      Me.dlvBrideCondition.UseCompatibleStateImageBehavior = False
      Me.dlvBrideCondition.View = System.Windows.Forms.View.Details
      '
      'olvcFileValue3
      '
      Me.olvcFileValue3.AspectName = "FileValue"
      Me.olvcFileValue3.Groupable = False
      Me.olvcFileValue3.Text = "Code"
      Me.olvcFileValue3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcType3
      '
      Me.olvcType3.AspectName = "Type"
      Me.olvcType3.Groupable = False
      Me.olvcType3.IsVisible = False
      Me.olvcType3.Text = "Type"
      '
      'olvcDisplayValue3
      '
      Me.olvcDisplayValue3.AspectName = "DisplayValue"
      Me.olvcDisplayValue3.FillsFreeSpace = True
      Me.olvcDisplayValue3.Groupable = False
      Me.olvcDisplayValue3.Text = "Description"
      '
      'bsBrideCOndition
      '
      Me.bsBrideCOndition.DataMember = "BrideCondition"
      Me.bsBrideCOndition.DataSource = GetType(WinFreeReg.LookupTables)
      '
      'formUserTables
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(542, 340)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.Name = "formUserTables"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "WinFreeREG - User Tables"
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel1.PerformLayout()
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      CType(Me.UserTablesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
      Me.UserTablesBindingNavigator.ResumeLayout(False)
      Me.UserTablesBindingNavigator.PerformLayout()
      Me.UserTablesTabControl.ResumeLayout(False)
      Me.tabBaptismSex.ResumeLayout(False)
      CType(Me.dlvBaptismSex, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bsBaptismSex, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tabBurialRelationship.ResumeLayout(False)
      CType(Me.dlvBurialRelationship, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bsBurialRelationship, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tabGroomCondition.ResumeLayout(False)
      CType(Me.dlvGroomCondition, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bsGroomCondition, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tabBrideCondition.ResumeLayout(False)
      CType(Me.dlvBrideCondition, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bsBrideCOndition, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents UserTablesTabControl As System.Windows.Forms.TabControl
   Friend WithEvents tabBaptismSex As System.Windows.Forms.TabPage
   Friend WithEvents tabBurialRelationship As System.Windows.Forms.TabPage
   Friend WithEvents tabGroomCondition As System.Windows.Forms.TabPage
   Friend WithEvents tabBrideCondition As System.Windows.Forms.TabPage
   Friend WithEvents UserTablesBindingNavigator As System.Windows.Forms.BindingNavigator
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
	Friend WithEvents bsBaptismSex As System.Windows.Forms.BindingSource
	Friend WithEvents bsBurialRelationship As System.Windows.Forms.BindingSource
	Friend WithEvents bsGroomCondition As System.Windows.Forms.BindingSource
	Friend WithEvents bsBrideCOndition As System.Windows.Forms.BindingSource
	Friend WithEvents dlvBaptismSex As BrightIdeasSoftware.DataListView
	Friend WithEvents dlvBurialRelationship As BrightIdeasSoftware.DataListView
	Friend WithEvents dlvGroomCondition As BrightIdeasSoftware.DataListView
	Friend WithEvents dlvBrideCondition As BrightIdeasSoftware.DataListView
	Friend WithEvents olvcCode As BrightIdeasSoftware.OLVColumn
	Friend WithEvents olvcType As BrightIdeasSoftware.OLVColumn
	Friend WithEvents olvcDescription As BrightIdeasSoftware.OLVColumn
	Friend WithEvents olvcFileValue1 As BrightIdeasSoftware.OLVColumn
	Friend WithEvents olvcType1 As BrightIdeasSoftware.OLVColumn
	Friend WithEvents olvcDisplayValue1 As BrightIdeasSoftware.OLVColumn
	Friend WithEvents olvcType2 As BrightIdeasSoftware.OLVColumn
	Friend WithEvents olvcFileValue2 As BrightIdeasSoftware.OLVColumn
	Friend WithEvents olvcDisplayValue2 As BrightIdeasSoftware.OLVColumn
	Friend WithEvents olvcFileValue3 As BrightIdeasSoftware.OLVColumn
	Friend WithEvents olvcType3 As BrightIdeasSoftware.OLVColumn
	Friend WithEvents olvcDisplayValue3 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents BindingNavigatorSaveChanges As System.Windows.Forms.ToolStripButton
End Class
