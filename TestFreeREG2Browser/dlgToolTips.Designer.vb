<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgToolTips
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgToolTips))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.OK_Button = New System.Windows.Forms.Button()
      Me.Cancel_Button = New System.Windows.Forms.Button()
      Me.ToolTips = New WinFreeReg.ToolTips()
      Me.ToolTipsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.ToolTipsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
      Me.ToolTipsBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.DataGridView1 = New System.Windows.Forms.DataGridView()
      Me.FormNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ControlNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ToolTipTextDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TableLayoutPanel1.SuspendLayout()
      CType(Me.ToolTips, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ToolTipsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ToolTipsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ToolTipsBindingNavigator.SuspendLayout()
      Me.Panel1.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(452, 304)
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
      'ToolTips
      '
      Me.ToolTips.DataSetName = "ToolTips"
      Me.ToolTips.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'ToolTipsBindingSource
      '
      Me.ToolTipsBindingSource.DataMember = "ToolTips"
      Me.ToolTipsBindingSource.DataSource = Me.ToolTips
      '
      'ToolTipsBindingNavigator
      '
      Me.ToolTipsBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
      Me.ToolTipsBindingNavigator.BindingSource = Me.ToolTipsBindingSource
      Me.ToolTipsBindingNavigator.CountItem = Me.BindingNavigatorCountItem
      Me.ToolTipsBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
      Me.ToolTipsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ToolTipsBindingNavigatorSaveItem})
      Me.ToolTipsBindingNavigator.Location = New System.Drawing.Point(0, 0)
      Me.ToolTipsBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.ToolTipsBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.ToolTipsBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.ToolTipsBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.ToolTipsBindingNavigator.Name = "ToolTipsBindingNavigator"
      Me.ToolTipsBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
      Me.ToolTipsBindingNavigator.Size = New System.Drawing.Size(610, 25)
      Me.ToolTipsBindingNavigator.TabIndex = 1
      Me.ToolTipsBindingNavigator.Text = "BindingNavigator1"
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
      'ToolTipsBindingNavigatorSaveItem
      '
      Me.ToolTipsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ToolTipsBindingNavigatorSaveItem.Enabled = False
      Me.ToolTipsBindingNavigatorSaveItem.Image = CType(resources.GetObject("ToolTipsBindingNavigatorSaveItem.Image"), System.Drawing.Image)
      Me.ToolTipsBindingNavigatorSaveItem.Name = "ToolTipsBindingNavigatorSaveItem"
      Me.ToolTipsBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
      Me.ToolTipsBindingNavigatorSaveItem.Text = "Save Data"
      '
      'Panel1
      '
      Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Panel1.Controls.Add(Me.DataGridView1)
      Me.Panel1.Location = New System.Drawing.Point(0, 28)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(610, 270)
      Me.Panel1.TabIndex = 2
      '
      'DataGridView1
      '
      Me.DataGridView1.AutoGenerateColumns = False
      Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FormNameDataGridViewTextBoxColumn, Me.ControlNameDataGridViewTextBoxColumn, Me.ToolTipTextDataGridViewTextBoxColumn})
      Me.DataGridView1.DataSource = Me.ToolTipsBindingSource
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
      Me.DataGridView1.MultiSelect = False
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(610, 270)
      Me.DataGridView1.TabIndex = 0
      '
      'FormNameDataGridViewTextBoxColumn
      '
      Me.FormNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
      Me.FormNameDataGridViewTextBoxColumn.DataPropertyName = "FormName"
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.FormNameDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
      Me.FormNameDataGridViewTextBoxColumn.HeaderText = "Form"
      Me.FormNameDataGridViewTextBoxColumn.Name = "FormNameDataGridViewTextBoxColumn"
      Me.FormNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.FormNameDataGridViewTextBoxColumn.Width = 21
      '
      'ControlNameDataGridViewTextBoxColumn
      '
      Me.ControlNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
      Me.ControlNameDataGridViewTextBoxColumn.DataPropertyName = "ControlName"
      Me.ControlNameDataGridViewTextBoxColumn.HeaderText = "Control"
      Me.ControlNameDataGridViewTextBoxColumn.Name = "ControlNameDataGridViewTextBoxColumn"
      Me.ControlNameDataGridViewTextBoxColumn.Width = 21
      '
      'ToolTipTextDataGridViewTextBoxColumn
      '
      Me.ToolTipTextDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.ToolTipTextDataGridViewTextBoxColumn.DataPropertyName = "ToolTipText"
      DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.ToolTipTextDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
      Me.ToolTipTextDataGridViewTextBoxColumn.HeaderText = "ToolTip"
      Me.ToolTipTextDataGridViewTextBoxColumn.Name = "ToolTipTextDataGridViewTextBoxColumn"
      '
      'dlgToolTips
      '
      Me.AcceptButton = Me.OK_Button
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.Cancel_Button
      Me.ClientSize = New System.Drawing.Size(610, 345)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolTipsBindingNavigator)
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "dlgToolTips"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "dlgToolTips"
      Me.TableLayoutPanel1.ResumeLayout(False)
      CType(Me.ToolTips, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ToolTipsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ToolTipsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ToolTipsBindingNavigator.ResumeLayout(False)
      Me.ToolTipsBindingNavigator.PerformLayout()
      Me.Panel1.ResumeLayout(False)
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents OK_Button As System.Windows.Forms.Button
   Friend WithEvents Cancel_Button As System.Windows.Forms.Button
   Friend WithEvents ToolTips As WinFreeReg.ToolTips
   Friend WithEvents ToolTipsBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents ToolTipsBindingNavigator As System.Windows.Forms.BindingNavigator
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
   Friend WithEvents ToolTipsBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents FormNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ControlNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ToolTipTextDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
