<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formDataErrors
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
      Me.olvErrors = New BrightIdeasSoftware.ObjectListView()
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.btnIgnore = New System.Windows.Forms.Button()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.btnOK = New System.Windows.Forms.Button()
      CType(Me.olvErrors, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.SuspendLayout()
      '
      'olvErrors
      '
      Me.olvErrors.CellEditUseWholeCell = False
      Me.olvErrors.Cursor = System.Windows.Forms.Cursors.Default
      Me.olvErrors.Dock = System.Windows.Forms.DockStyle.Fill
      Me.olvErrors.EmptyListMsg = "No erors found"
      Me.olvErrors.FullRowSelect = True
      Me.olvErrors.GridLines = True
      Me.olvErrors.Location = New System.Drawing.Point(0, 0)
      Me.olvErrors.Name = "olvErrors"
      Me.olvErrors.ShowGroups = False
      Me.olvErrors.Size = New System.Drawing.Size(544, 282)
      Me.olvErrors.TabIndex = 0
      Me.olvErrors.UseCompatibleStateImageBehavior = False
      Me.olvErrors.View = System.Windows.Forms.View.Details
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer1.Name = "SplitContainer1"
      Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.olvErrors)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.btnIgnore)
      Me.SplitContainer1.Panel2.Controls.Add(Me.btnCancel)
      Me.SplitContainer1.Panel2.Controls.Add(Me.btnOK)
      Me.SplitContainer1.Size = New System.Drawing.Size(544, 339)
      Me.SplitContainer1.SplitterDistance = 282
      Me.SplitContainer1.TabIndex = 1
      '
      'btnIgnore
      '
      Me.btnIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore
      Me.btnIgnore.Location = New System.Drawing.Point(330, 17)
      Me.btnIgnore.Name = "btnIgnore"
      Me.btnIgnore.Size = New System.Drawing.Size(111, 23)
      Me.btnIgnore.TabIndex = 2
      Me.btnIgnore.Text = "Ignore errors"
      Me.btnIgnore.UseVisualStyleBackColor = True
      '
      'btnCancel
      '
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(217, 17)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 1
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'btnOK
      '
      Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOK.Location = New System.Drawing.Point(104, 17)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(75, 23)
      Me.btnOK.TabIndex = 0
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'formDataErrors
      '
      Me.AcceptButton = Me.btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(544, 339)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.HelpButton = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "formDataErrors"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Data Errors"
      CType(Me.olvErrors, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents olvErrors As BrightIdeasSoftware.ObjectListView
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents btnIgnore As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
