<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSaveFile
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
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.OK_Button = New System.Windows.Forms.Button()
      Me.Cancel_Button = New System.Windows.Forms.Button()
      Me.lboxFolders = New System.Windows.Forms.ListBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtFileName = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
      Me.DataListView1 = New BrightIdeasSoftware.DataListView()
      Me.olvcName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcLength = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcReadOnly = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.olvcFullName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
      Me.TableLayoutPanel1.SuspendLayout()
      CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataListView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(370, 338)
      Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 1
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(195, 36)
      Me.TableLayoutPanel1.TabIndex = 0
      '
      'OK_Button
      '
      Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.OK_Button.Location = New System.Drawing.Point(4, 4)
      Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
      Me.OK_Button.Name = "OK_Button"
      Me.OK_Button.Size = New System.Drawing.Size(89, 28)
      Me.OK_Button.TabIndex = 0
      Me.OK_Button.Text = "OK"
      '
      'Cancel_Button
      '
      Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Cancel_Button.Location = New System.Drawing.Point(101, 4)
      Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
      Me.Cancel_Button.Name = "Cancel_Button"
      Me.Cancel_Button.Size = New System.Drawing.Size(89, 28)
      Me.Cancel_Button.TabIndex = 1
      Me.Cancel_Button.Text = "Cancel"
      '
      'lboxFolders
      '
      Me.lboxFolders.FormattingEnabled = True
      Me.lboxFolders.ItemHeight = 16
      Me.lboxFolders.Location = New System.Drawing.Point(13, 36)
      Me.lboxFolders.Margin = New System.Windows.Forms.Padding(4)
      Me.lboxFolders.Name = "lboxFolders"
      Me.lboxFolders.Size = New System.Drawing.Size(545, 116)
      Me.lboxFolders.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(16, 11)
      Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(249, 17)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Select a folder in which to save the file"
      '
      'txtFileName
      '
      Me.txtFileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
      Me.txtFileName.Location = New System.Drawing.Point(370, 299)
      Me.txtFileName.Margin = New System.Windows.Forms.Padding(4)
      Me.txtFileName.Name = "txtFileName"
      Me.txtFileName.Size = New System.Drawing.Size(193, 23)
      Me.txtFileName.TabIndex = 3
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(292, 302)
      Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(69, 17)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "File name"
      '
      'DataListView1
      '
      Me.DataListView1.AllColumns.Add(Me.olvcName)
      Me.DataListView1.AllColumns.Add(Me.olvcLength)
      Me.DataListView1.AllColumns.Add(Me.olvcReadOnly)
      Me.DataListView1.AllColumns.Add(Me.olvcFullName)
      Me.DataListView1.AutoGenerateColumns = False
      Me.DataListView1.CellEditUseWholeCell = False
      Me.DataListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.olvcName, Me.olvcLength, Me.olvcReadOnly, Me.olvcFullName})
      Me.DataListView1.DataSource = Nothing
      Me.DataListView1.Location = New System.Drawing.Point(13, 160)
      Me.DataListView1.MultiSelect = False
      Me.DataListView1.Name = "DataListView1"
      Me.DataListView1.ShowGroups = False
      Me.DataListView1.ShowImagesOnSubItems = True
      Me.DataListView1.ShowItemToolTips = True
      Me.DataListView1.Size = New System.Drawing.Size(545, 132)
      Me.DataListView1.TabIndex = 5
      Me.DataListView1.UseCompatibleStateImageBehavior = False
      Me.DataListView1.UseSubItemCheckBoxes = True
      Me.DataListView1.View = System.Windows.Forms.View.Details
      '
      'olvcName
      '
      Me.olvcName.AspectName = "Name"
      Me.olvcName.IsEditable = False
      Me.olvcName.Text = "Name"
      '
      'olvcLength
      '
      Me.olvcLength.AspectName = "Length"
      Me.olvcLength.Text = "Size"
      Me.olvcLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'olvcReadOnly
      '
      Me.olvcReadOnly.AspectName = "IsReadOnly"
      Me.olvcReadOnly.CheckBoxes = True
      Me.olvcReadOnly.Text = "Read Only"
      Me.olvcReadOnly.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'olvcFullName
      '
      Me.olvcFullName.AspectName = "FullName"
      Me.olvcFullName.FillsFreeSpace = True
      Me.olvcFullName.Text = "Full name"
      '
      'dlgSaveFile
      '
      Me.AcceptButton = Me.OK_Button
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.Cancel_Button
      Me.ClientSize = New System.Drawing.Size(580, 388)
      Me.Controls.Add(Me.DataListView1)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtFileName)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lboxFolders)
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "dlgSaveFile"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "dlgSaveFile"
      Me.TableLayoutPanel1.ResumeLayout(False)
      CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataListView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents OK_Button As System.Windows.Forms.Button
   Friend WithEvents Cancel_Button As System.Windows.Forms.Button
   Friend WithEvents lboxFolders As System.Windows.Forms.ListBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtFileName As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
   Friend WithEvents DataListView1 As BrightIdeasSoftware.DataListView
   Friend WithEvents olvcName As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcLength As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcReadOnly As BrightIdeasSoftware.OLVColumn
   Friend WithEvents olvcFullName As BrightIdeasSoftware.OLVColumn

End Class
