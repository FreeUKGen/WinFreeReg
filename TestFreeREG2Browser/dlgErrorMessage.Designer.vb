<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgErrorMessage
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgErrorMessage))
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.OK_Button = New System.Windows.Forms.Button()
      Me.Cancel_Button = New System.Windows.Forms.Button()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.ErrorMessagesDataGridView = New System.Windows.Forms.DataGridView()
      Me.NumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.MessageColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ExplanationColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ErrorMessagesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.ErrorMessages = New WinFreeReg.ErrorMessages()
      Me.ErrorMessagesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
      Me.ErrorMessagesBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
      Me.TableLayoutPanel1.SuspendLayout()
      Me.Panel1.SuspendLayout()
      CType(Me.ErrorMessagesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorMessagesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorMessages, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorMessagesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ErrorMessagesBindingNavigator.SuspendLayout()
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
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(597, 397)
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
      'Panel1
      '
      Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Panel1.Controls.Add(Me.ErrorMessagesDataGridView)
      Me.Panel1.Location = New System.Drawing.Point(-2, 28)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(758, 363)
      Me.Panel1.TabIndex = 1
      '
      'ErrorMessagesDataGridView
      '
      Me.ErrorMessagesDataGridView.AutoGenerateColumns = False
      Me.ErrorMessagesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
      Me.ErrorMessagesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.ErrorMessagesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NumberColumn, Me.MessageColumn, Me.ExplanationColumn})
      Me.ErrorMessagesDataGridView.DataSource = Me.ErrorMessagesBindingSource
      Me.ErrorMessagesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ErrorMessagesDataGridView.Location = New System.Drawing.Point(0, 0)
      Me.ErrorMessagesDataGridView.Name = "ErrorMessagesDataGridView"
      Me.ErrorMessagesDataGridView.Size = New System.Drawing.Size(758, 363)
      Me.ErrorMessagesDataGridView.TabIndex = 0
      '
      'NumberColumn
      '
      Me.NumberColumn.DataPropertyName = "Number"
      Me.NumberColumn.HeaderText = "Number"
      Me.NumberColumn.MaxInputLength = 4
      Me.NumberColumn.MinimumWidth = 20
      Me.NumberColumn.Name = "NumberColumn"
      Me.NumberColumn.Width = 60
      '
      'MessageColumn
      '
      Me.MessageColumn.DataPropertyName = "Message"
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.MessageColumn.DefaultCellStyle = DataGridViewCellStyle1
      Me.MessageColumn.HeaderText = "Message"
      Me.MessageColumn.Name = "MessageColumn"
      Me.MessageColumn.Width = 150
      '
      'ExplanationColumn
      '
      Me.ExplanationColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.ExplanationColumn.DataPropertyName = "Explanation"
      DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.ExplanationColumn.DefaultCellStyle = DataGridViewCellStyle2
      Me.ExplanationColumn.HeaderText = "Explanation"
      Me.ExplanationColumn.Name = "ExplanationColumn"
      Me.ExplanationColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      '
      'ErrorMessagesBindingSource
      '
      Me.ErrorMessagesBindingSource.DataMember = "ErrorMessages"
      Me.ErrorMessagesBindingSource.DataSource = Me.ErrorMessages
      '
      'ErrorMessages
      '
      Me.ErrorMessages.DataSetName = "ErrorMessages"
      Me.ErrorMessages.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'ErrorMessagesBindingNavigator
      '
      Me.ErrorMessagesBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
      Me.ErrorMessagesBindingNavigator.BindingSource = Me.ErrorMessagesBindingSource
      Me.ErrorMessagesBindingNavigator.CountItem = Me.BindingNavigatorCountItem
      Me.ErrorMessagesBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
      Me.ErrorMessagesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ErrorMessagesBindingNavigatorSaveItem})
      Me.ErrorMessagesBindingNavigator.Location = New System.Drawing.Point(0, 0)
      Me.ErrorMessagesBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
      Me.ErrorMessagesBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
      Me.ErrorMessagesBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
      Me.ErrorMessagesBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
      Me.ErrorMessagesBindingNavigator.Name = "ErrorMessagesBindingNavigator"
      Me.ErrorMessagesBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
      Me.ErrorMessagesBindingNavigator.Size = New System.Drawing.Size(755, 25)
      Me.ErrorMessagesBindingNavigator.TabIndex = 2
      Me.ErrorMessagesBindingNavigator.Text = "BindingNavigator1"
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
      'ErrorMessagesBindingNavigatorSaveItem
      '
      Me.ErrorMessagesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.ErrorMessagesBindingNavigatorSaveItem.Enabled = False
      Me.ErrorMessagesBindingNavigatorSaveItem.Image = CType(resources.GetObject("ErrorMessagesBindingNavigatorSaveItem.Image"), System.Drawing.Image)
      Me.ErrorMessagesBindingNavigatorSaveItem.Name = "ErrorMessagesBindingNavigatorSaveItem"
      Me.ErrorMessagesBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
      Me.ErrorMessagesBindingNavigatorSaveItem.Text = "Save Data"
      '
      'dlgErrorMessage
      '
      Me.AcceptButton = Me.OK_Button
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.Cancel_Button
      Me.ClientSize = New System.Drawing.Size(755, 438)
      Me.Controls.Add(Me.ErrorMessagesBindingNavigator)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "dlgErrorMessage"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Error Messages"
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.Panel1.ResumeLayout(False)
      CType(Me.ErrorMessagesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorMessagesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorMessages, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorMessagesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ErrorMessagesBindingNavigator.ResumeLayout(False)
      Me.ErrorMessagesBindingNavigator.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents OK_Button As System.Windows.Forms.Button
   Friend WithEvents Cancel_Button As System.Windows.Forms.Button
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents ErrorMessagesDataGridView As System.Windows.Forms.DataGridView
   Friend WithEvents ErrorMessagesBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents ErrorMessages As WinFreeReg.ErrorMessages
	Friend WithEvents ErrorMessagesBindingNavigator As System.Windows.Forms.BindingNavigator
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
	Friend WithEvents ErrorMessagesBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
	Friend WithEvents NumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents MessageColumn As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ExplanationColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
