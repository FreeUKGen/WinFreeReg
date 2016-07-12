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
      Me.tabCounties = New System.Windows.Forms.TabPage()
      Me.dlvCounties = New BrightIdeasSoftware.DataListView()
      Me.tabPlaces = New System.Windows.Forms.TabPage()
      Me.dlvPlaces = New BrightIdeasSoftware.DataListView()
      Me.tabChurches = New System.Windows.Forms.TabPage()
      Me.dlvChurches = New BrightIdeasSoftware.DataListView()
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.cboxPlaces = New System.Windows.Forms.ComboBox()
      Me.labPlace = New System.Windows.Forms.Label()
      Me.cboxCounties = New System.Windows.Forms.ComboBox()
      Me.labCounty = New System.Windows.Forms.Label()
      Me.btnFetch = New System.Windows.Forms.Button()
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
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(598, 292)
      Me.TabControl1.TabIndex = 0
      '
      'tabRegisterTypes
      '
      Me.tabRegisterTypes.Controls.Add(Me.dlvRegisterTypes)
      Me.tabRegisterTypes.Location = New System.Drawing.Point(4, 25)
      Me.tabRegisterTypes.Name = "tabRegisterTypes"
      Me.tabRegisterTypes.Padding = New System.Windows.Forms.Padding(3)
      Me.tabRegisterTypes.Size = New System.Drawing.Size(590, 263)
      Me.tabRegisterTypes.TabIndex = 3
      Me.tabRegisterTypes.Text = "Register Types"
      Me.tabRegisterTypes.UseVisualStyleBackColor = True
      '
      'dlvRegisterTypes
      '
      Me.dlvRegisterTypes.CellEditUseWholeCell = False
      Me.dlvRegisterTypes.DataSource = Nothing
      Me.dlvRegisterTypes.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvRegisterTypes.EmptyListMsg = "The Register Types table has no entries"
      Me.dlvRegisterTypes.FullRowSelect = True
      Me.dlvRegisterTypes.GridLines = True
      Me.dlvRegisterTypes.Location = New System.Drawing.Point(3, 3)
      Me.dlvRegisterTypes.MultiSelect = False
      Me.dlvRegisterTypes.Name = "dlvRegisterTypes"
      Me.dlvRegisterTypes.SelectColumnsOnRightClick = False
      Me.dlvRegisterTypes.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None
      Me.dlvRegisterTypes.ShowGroups = False
      Me.dlvRegisterTypes.ShowSortIndicators = False
      Me.dlvRegisterTypes.Size = New System.Drawing.Size(584, 257)
      Me.dlvRegisterTypes.TabIndex = 0
      Me.dlvRegisterTypes.UseCompatibleStateImageBehavior = False
      Me.dlvRegisterTypes.View = System.Windows.Forms.View.Details
      '
      'tabCounties
      '
      Me.tabCounties.Controls.Add(Me.dlvCounties)
      Me.tabCounties.Location = New System.Drawing.Point(4, 22)
      Me.tabCounties.Name = "tabCounties"
      Me.tabCounties.Padding = New System.Windows.Forms.Padding(3)
      Me.tabCounties.Size = New System.Drawing.Size(590, 266)
      Me.tabCounties.TabIndex = 1
      Me.tabCounties.Text = "Counties"
      Me.tabCounties.UseVisualStyleBackColor = True
      '
      'dlvCounties
      '
      Me.dlvCounties.CellEditUseWholeCell = False
      Me.dlvCounties.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvCounties.DataSource = Nothing
      Me.dlvCounties.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvCounties.EmptyListMsg = "The Counties table has no entries"
      Me.dlvCounties.FullRowSelect = True
      Me.dlvCounties.GridLines = True
      Me.dlvCounties.Location = New System.Drawing.Point(3, 3)
      Me.dlvCounties.MultiSelect = False
      Me.dlvCounties.Name = "dlvCounties"
      Me.dlvCounties.ShowCommandMenuOnRightClick = True
      Me.dlvCounties.ShowItemCountOnGroups = True
      Me.dlvCounties.Size = New System.Drawing.Size(584, 260)
      Me.dlvCounties.SortGroupItemsByPrimaryColumn = False
      Me.dlvCounties.TabIndex = 0
      Me.dlvCounties.UseCompatibleStateImageBehavior = False
      Me.dlvCounties.UseFilterIndicator = True
      Me.dlvCounties.UseFiltering = True
      Me.dlvCounties.View = System.Windows.Forms.View.Details
      '
      'tabPlaces
      '
      Me.tabPlaces.Controls.Add(Me.dlvPlaces)
      Me.tabPlaces.Location = New System.Drawing.Point(4, 22)
      Me.tabPlaces.Name = "tabPlaces"
      Me.tabPlaces.Padding = New System.Windows.Forms.Padding(3)
      Me.tabPlaces.Size = New System.Drawing.Size(590, 266)
      Me.tabPlaces.TabIndex = 2
      Me.tabPlaces.Text = "Places"
      Me.tabPlaces.UseVisualStyleBackColor = True
      '
      'dlvPlaces
      '
      Me.dlvPlaces.CellEditUseWholeCell = False
      Me.dlvPlaces.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvPlaces.DataSource = Nothing
      Me.dlvPlaces.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvPlaces.EmptyListMsg = "The Places table has no entries"
      Me.dlvPlaces.FullRowSelect = True
      Me.dlvPlaces.GridLines = True
      Me.dlvPlaces.Location = New System.Drawing.Point(3, 3)
      Me.dlvPlaces.MultiSelect = False
      Me.dlvPlaces.Name = "dlvPlaces"
      Me.dlvPlaces.ShowCommandMenuOnRightClick = True
      Me.dlvPlaces.ShowItemCountOnGroups = True
      Me.dlvPlaces.Size = New System.Drawing.Size(584, 260)
      Me.dlvPlaces.SortGroupItemsByPrimaryColumn = False
      Me.dlvPlaces.Sorting = System.Windows.Forms.SortOrder.Ascending
      Me.dlvPlaces.TabIndex = 0
      Me.dlvPlaces.UseCompatibleStateImageBehavior = False
      Me.dlvPlaces.UseFilterIndicator = True
      Me.dlvPlaces.UseFiltering = True
      Me.dlvPlaces.View = System.Windows.Forms.View.Details
      '
      'tabChurches
      '
      Me.tabChurches.Controls.Add(Me.dlvChurches)
      Me.tabChurches.Location = New System.Drawing.Point(4, 22)
      Me.tabChurches.Name = "tabChurches"
      Me.tabChurches.Padding = New System.Windows.Forms.Padding(3)
      Me.tabChurches.Size = New System.Drawing.Size(590, 266)
      Me.tabChurches.TabIndex = 0
      Me.tabChurches.Text = "Churches"
      Me.tabChurches.UseVisualStyleBackColor = True
      '
      'dlvChurches
      '
      Me.dlvChurches.CellEditUseWholeCell = False
      Me.dlvChurches.Cursor = System.Windows.Forms.Cursors.Default
      Me.dlvChurches.DataSource = Nothing
      Me.dlvChurches.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dlvChurches.EmptyListMsg = "The Churches table has no entries"
      Me.dlvChurches.FullRowSelect = True
      Me.dlvChurches.GridLines = True
      Me.dlvChurches.Location = New System.Drawing.Point(3, 3)
      Me.dlvChurches.MultiSelect = False
      Me.dlvChurches.Name = "dlvChurches"
      Me.dlvChurches.ShowCommandMenuOnRightClick = True
      Me.dlvChurches.ShowItemCountOnGroups = True
      Me.dlvChurches.Size = New System.Drawing.Size(584, 260)
      Me.dlvChurches.SortGroupItemsByPrimaryColumn = False
      Me.dlvChurches.TabIndex = 0
      Me.dlvChurches.UseCompatibleStateImageBehavior = False
      Me.dlvChurches.UseFilterIndicator = True
      Me.dlvChurches.UseFiltering = True
      Me.dlvChurches.View = System.Windows.Forms.View.Details
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
      Me.SplitContainer1.IsSplitterFixed = True
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
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
      Me.SplitContainer1.Size = New System.Drawing.Size(598, 339)
      Me.SplitContainer1.SplitterDistance = 292
      Me.SplitContainer1.TabIndex = 1
      '
      'cboxPlaces
      '
      Me.cboxPlaces.FormattingEnabled = True
      Me.cboxPlaces.Location = New System.Drawing.Point(196, 9)
      Me.cboxPlaces.Name = "cboxPlaces"
      Me.cboxPlaces.Size = New System.Drawing.Size(247, 24)
      Me.cboxPlaces.TabIndex = 5
      Me.cboxPlaces.Visible = False
      '
      'labPlace
      '
      Me.labPlace.AutoSize = True
      Me.labPlace.Location = New System.Drawing.Point(146, 13)
      Me.labPlace.Name = "labPlace"
      Me.labPlace.Size = New System.Drawing.Size(43, 16)
      Me.labPlace.TabIndex = 4
      Me.labPlace.Text = "Place"
      Me.labPlace.Visible = False
      '
      'cboxCounties
      '
      Me.cboxCounties.FormattingEnabled = True
      Me.cboxCounties.Location = New System.Drawing.Point(68, 9)
      Me.cboxCounties.Name = "cboxCounties"
      Me.cboxCounties.Size = New System.Drawing.Size(58, 24)
      Me.cboxCounties.TabIndex = 3
      Me.cboxCounties.Visible = False
      '
      'labCounty
      '
      Me.labCounty.AutoSize = True
      Me.labCounty.Location = New System.Drawing.Point(13, 13)
      Me.labCounty.Name = "labCounty"
      Me.labCounty.Size = New System.Drawing.Size(49, 16)
      Me.labCounty.TabIndex = 1
      Me.labCounty.Text = "County"
      Me.labCounty.Visible = False
      '
      'btnFetch
      '
      Me.btnFetch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnFetch.AutoSize = True
      Me.btnFetch.Location = New System.Drawing.Point(499, 8)
      Me.btnFetch.Name = "btnFetch"
      Me.btnFetch.Size = New System.Drawing.Size(75, 26)
      Me.btnFetch.TabIndex = 0
      Me.btnFetch.Text = "Fetch"
      Me.btnFetch.UseVisualStyleBackColor = True
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
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(598, 339)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Margin = New System.Windows.Forms.Padding(4)
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
End Class
