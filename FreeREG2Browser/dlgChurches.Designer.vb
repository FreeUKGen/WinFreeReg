<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgChurches
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgChurches))
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.OK_Button = New System.Windows.Forms.Button()
      Me.Cancel_Button = New System.Windows.Forms.Button()
      Me.FreeregTablesDataSet = New WinFreeReg.FreeregTables()
      Me.CountiesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.CountiesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
      Me.CountiesBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
      Me.PlacesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.ChurchesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.DataListView2 = New BrightIdeasSoftware.DataListView()
      Me.OlvColumn1 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.OlvColumn4 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.DataListView3 = New BrightIdeasSoftware.DataListView()
      Me.OlvColumn2 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.OlvColumn5 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.OlvColumn8 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.ChurchesBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
      Me.DataListView4 = New BrightIdeasSoftware.DataListView()
      Me.DefaultCountyComboBox = New System.Windows.Forms.ComboBox()
      Me.OlvColumn3 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.OlvColumn6 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.OlvColumn7 = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.TableLayoutPanel1.SuspendLayout()
      CType(Me.FreeregTablesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.CountiesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.CountiesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.CountiesBindingNavigator.SuspendLayout()
      CType(Me.PlacesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ChurchesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataListView2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataListView3, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ChurchesBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataListView4, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TableLayoutPanel1.ColumnCount = 2
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(642, 529)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 1
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
      Me.TableLayoutPanel1.TabIndex = 0
      '
      'OK_Button
      '
      Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.OK_Button.Location = New System.Drawing.Point(3, 3)
      Me.OK_Button.Name = "OK_Button"
      Me.OK_Button.Size = New System.Drawing.Size(67, 23)
      Me.OK_Button.TabIndex = 0
      Me.OK_Button.Text = "OK"
      '
      'Cancel_Button
      '
      Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
      Me.Cancel_Button.Name = "Cancel_Button"
      Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
      Me.Cancel_Button.TabIndex = 1
      Me.Cancel_Button.Text = "Cancel"
      '
      'FreeregTablesDataSet
      '
      Me.FreeregTablesDataSet.DataSetName = "FreeregTables"
      Me.FreeregTablesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'CountiesBindingSource
      '
      Me.CountiesBindingSource.DataMember = "Counties"
      Me.CountiesBindingSource.DataSource = Me.FreeregTablesDataSet
      '
      'CountiesBindingNavigator
      '
      Me.CountiesBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
      Me.CountiesBindingNavigator.BindingSource = Me.CountiesBindingSource
      Me.CountiesBindingNavigator.CountItem = Me.BindingNavigatorCountItem
      Me.CountiesBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
      Me.CountiesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.CountiesBindingNavigatorSaveItem})
      Me.CountiesBindingNavigator.Location = New System.Drawing.Point(0, 0)
      Me.CountiesBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.CountiesBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.CountiesBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.CountiesBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.CountiesBindingNavigator.Name = "CountiesBindingNavigator"
      Me.CountiesBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
      Me.CountiesBindingNavigator.Size = New System.Drawing.Size(800, 25)
      Me.CountiesBindingNavigator.TabIndex = 1
      Me.CountiesBindingNavigator.Text = "BindingNavigator1"
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
      'CountiesBindingNavigatorSaveItem
      '
      Me.CountiesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.CountiesBindingNavigatorSaveItem.Enabled = False
      Me.CountiesBindingNavigatorSaveItem.Image = CType(resources.GetObject("CountiesBindingNavigatorSaveItem.Image"), System.Drawing.Image)
      Me.CountiesBindingNavigatorSaveItem.Name = "CountiesBindingNavigatorSaveItem"
      Me.CountiesBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
      Me.CountiesBindingNavigatorSaveItem.Text = "Save Data"
      '
      'PlacesBindingSource
      '
      Me.PlacesBindingSource.DataMember = "PlacesInCounty"
      Me.PlacesBindingSource.DataSource = Me.CountiesBindingSource
      '
      'ChurchesBindingSource
      '
      Me.ChurchesBindingSource.DataMember = "ChurchesInCounty"
      Me.ChurchesBindingSource.DataSource = Me.CountiesBindingSource
      '
      'DataListView2
      '
      Me.DataListView2.AllColumns.Add(Me.OlvColumn1)
      Me.DataListView2.AllColumns.Add(Me.OlvColumn4)
      Me.DataListView2.AutoGenerateColumns = False
      Me.DataListView2.CellEditUseWholeCell = False
      Me.DataListView2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn1, Me.OlvColumn4})
      Me.DataListView2.Cursor = System.Windows.Forms.Cursors.Default
      Me.DataListView2.DataSource = Nothing
      Me.DataListView2.HeaderWordWrap = True
      Me.DataListView2.Location = New System.Drawing.Point(16, 61)
      Me.DataListView2.MultiSelect = False
      Me.DataListView2.Name = "DataListView2"
      Me.DataListView2.ShowGroups = False
      Me.DataListView2.Size = New System.Drawing.Size(603, 146)
      Me.DataListView2.TabIndex = 6
      Me.DataListView2.UseCompatibleStateImageBehavior = False
      Me.DataListView2.View = System.Windows.Forms.View.Details
      '
      'OlvColumn1
      '
      Me.OlvColumn1.AspectName = "PlaceName"
      Me.OlvColumn1.Text = "Placename"
      '
      'OlvColumn4
      '
      Me.OlvColumn4.AspectName = "Notes"
      Me.OlvColumn4.FillsFreeSpace = True
      Me.OlvColumn4.Text = "Notes"
      '
      'DataListView3
      '
      Me.DataListView3.AllColumns.Add(Me.OlvColumn2)
      Me.DataListView3.AllColumns.Add(Me.OlvColumn5)
      Me.DataListView3.AllColumns.Add(Me.OlvColumn8)
      Me.DataListView3.AutoGenerateColumns = False
      Me.DataListView3.CellEditUseWholeCell = False
      Me.DataListView3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn2, Me.OlvColumn5, Me.OlvColumn8})
      Me.DataListView3.Cursor = System.Windows.Forms.Cursors.Default
      Me.DataListView3.DataSource = Nothing
      Me.DataListView3.Location = New System.Drawing.Point(16, 222)
      Me.DataListView3.MultiSelect = False
      Me.DataListView3.Name = "DataListView3"
      Me.DataListView3.ShowCommandMenuOnRightClick = True
      Me.DataListView3.ShowItemCountOnGroups = True
      Me.DataListView3.Size = New System.Drawing.Size(603, 146)
      Me.DataListView3.SortGroupItemsByPrimaryColumn = False
      Me.DataListView3.TabIndex = 7
      Me.DataListView3.UseCompatibleStateImageBehavior = False
      Me.DataListView3.UseFiltering = True
      Me.DataListView3.View = System.Windows.Forms.View.Details
      '
      'OlvColumn2
      '
      Me.OlvColumn2.AspectName = "PlaceName"
      Me.OlvColumn2.Text = "Place"
      '
      'OlvColumn5
      '
      Me.OlvColumn5.AspectName = "ChurchName"
      Me.OlvColumn5.Groupable = False
      Me.OlvColumn5.Text = "Church"
      Me.OlvColumn5.UseFiltering = False
      '
      'OlvColumn8
      '
      Me.OlvColumn8.AspectName = "Notes"
      Me.OlvColumn8.FillsFreeSpace = True
      Me.OlvColumn8.Groupable = False
      Me.OlvColumn8.Text = "Notes"
      Me.OlvColumn8.UseFiltering = False
      '
      'ChurchesBindingSource1
      '
      Me.ChurchesBindingSource1.DataMember = "ChurchesInPlace"
      Me.ChurchesBindingSource1.DataSource = Me.PlacesBindingSource
      '
      'DataListView4
      '
      Me.DataListView4.AllColumns.Add(Me.OlvColumn3)
      Me.DataListView4.AllColumns.Add(Me.OlvColumn6)
      Me.DataListView4.AllColumns.Add(Me.OlvColumn7)
      Me.DataListView4.AutoGenerateColumns = False
      Me.DataListView4.CellEditUseWholeCell = False
      Me.DataListView4.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OlvColumn3, Me.OlvColumn6, Me.OlvColumn7})
      Me.DataListView4.Cursor = System.Windows.Forms.Cursors.Default
      Me.DataListView4.DataSource = Nothing
      Me.DataListView4.Location = New System.Drawing.Point(16, 383)
      Me.DataListView4.MultiSelect = False
      Me.DataListView4.Name = "DataListView4"
      Me.DataListView4.ShowGroups = False
      Me.DataListView4.Size = New System.Drawing.Size(603, 146)
      Me.DataListView4.TabIndex = 8
      Me.DataListView4.UseCompatibleStateImageBehavior = False
      Me.DataListView4.View = System.Windows.Forms.View.Details
      '
      'DefaultCountyComboBox
      '
      Me.DefaultCountyComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
      Me.DefaultCountyComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.DefaultCountyComboBox.DataSource = Me.CountiesBindingSource
      Me.DefaultCountyComboBox.DisplayMember = "ChapmanCode"
      Me.DefaultCountyComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
      Me.DefaultCountyComboBox.FormattingEnabled = True
      Me.DefaultCountyComboBox.Location = New System.Drawing.Point(16, 25)
      Me.DefaultCountyComboBox.Name = "DefaultCountyComboBox"
      Me.DefaultCountyComboBox.Size = New System.Drawing.Size(299, 21)
      Me.DefaultCountyComboBox.TabIndex = 9
      Me.DefaultCountyComboBox.ValueMember = "CountyName"
      '
      'OlvColumn3
      '
      Me.OlvColumn3.AspectName = "ChurchName"
      Me.OlvColumn3.Groupable = False
      Me.OlvColumn3.Text = "Church"
      '
      'OlvColumn6
      '
      Me.OlvColumn6.AspectName = "PlaceName"
      Me.OlvColumn6.Groupable = False
      Me.OlvColumn6.Text = "Place"
      '
      'OlvColumn7
      '
      Me.OlvColumn7.AspectName = "Notes"
      Me.OlvColumn7.FillsFreeSpace = True
      Me.OlvColumn7.Groupable = False
      Me.OlvColumn7.Sortable = False
      Me.OlvColumn7.Text = "Notes"
      '
      'dlgChurches
      '
      Me.AcceptButton = Me.OK_Button
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.Cancel_Button
      Me.ClientSize = New System.Drawing.Size(800, 570)
      Me.Controls.Add(Me.DefaultCountyComboBox)
      Me.Controls.Add(Me.DataListView4)
      Me.Controls.Add(Me.DataListView3)
      Me.Controls.Add(Me.DataListView2)
      Me.Controls.Add(Me.CountiesBindingNavigator)
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "dlgChurches"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "dlgChurches"
      Me.TableLayoutPanel1.ResumeLayout(False)
      CType(Me.FreeregTablesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.CountiesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.CountiesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
      Me.CountiesBindingNavigator.ResumeLayout(False)
      Me.CountiesBindingNavigator.PerformLayout()
      CType(Me.PlacesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ChurchesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataListView2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataListView3, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ChurchesBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataListView4, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents OK_Button As System.Windows.Forms.Button
   Friend WithEvents Cancel_Button As System.Windows.Forms.Button
   Friend WithEvents FreeregTablesDataSet As WinFreeReg.FreeregTables
   Friend WithEvents CountiesBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents CountiesBindingNavigator As System.Windows.Forms.BindingNavigator
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
   Friend WithEvents CountiesBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
   Friend WithEvents PlacesBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents ChurchesBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents DataListView2 As BrightIdeasSoftware.DataListView
   Friend WithEvents DataListView3 As BrightIdeasSoftware.DataListView
   Friend WithEvents ChurchesBindingSource1 As System.Windows.Forms.BindingSource
   Friend WithEvents DataListView4 As BrightIdeasSoftware.DataListView
   Friend WithEvents DefaultCountyComboBox As System.Windows.Forms.ComboBox
   Friend WithEvents OlvColumn1 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents OlvColumn4 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents OlvColumn2 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents OlvColumn5 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents OlvColumn8 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents OlvColumn3 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents OlvColumn6 As BrightIdeasSoftware.OLVColumn
   Friend WithEvents OlvColumn7 As BrightIdeasSoftware.OLVColumn

End Class
