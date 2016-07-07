<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formBatchContents
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formBatchContents))
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
      Me.FileContentsTextBox = New System.Windows.Forms.TextBox()
      Me.btnSaveFile = New System.Windows.Forms.Button()
      Me.BatchContentsToolTip = New System.Windows.Forms.ToolTip(Me.components)
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.SuspendLayout()
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
      Me.SplitContainer1.IsSplitterFixed = True
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
      Me.SplitContainer1.Name = "SplitContainer1"
      Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.FileContentsTextBox)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.btnSaveFile)
      Me.SplitContainer1.Size = New System.Drawing.Size(856, 615)
      Me.SplitContainer1.SplitterDistance = 564
      Me.SplitContainer1.SplitterWidth = 5
      Me.SplitContainer1.TabIndex = 0
      '
      'FileContentsTextBox
      '
      Me.FileContentsTextBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.FileContentsTextBox.Location = New System.Drawing.Point(0, 0)
      Me.FileContentsTextBox.Margin = New System.Windows.Forms.Padding(4)
      Me.FileContentsTextBox.Multiline = True
      Me.FileContentsTextBox.Name = "FileContentsTextBox"
      Me.FileContentsTextBox.ReadOnly = True
      Me.FileContentsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.FileContentsTextBox.Size = New System.Drawing.Size(856, 564)
      Me.FileContentsTextBox.TabIndex = 0
      Me.FileContentsTextBox.WordWrap = False
      '
      'btnSaveFile
      '
      Me.btnSaveFile.Location = New System.Drawing.Point(16, 12)
      Me.btnSaveFile.Margin = New System.Windows.Forms.Padding(4)
      Me.btnSaveFile.Name = "btnSaveFile"
      Me.btnSaveFile.Size = New System.Drawing.Size(100, 28)
      Me.btnSaveFile.TabIndex = 0
      Me.btnSaveFile.Text = "Save File"
      Me.btnSaveFile.UseVisualStyleBackColor = True
      '
      'BatchContentsToolTip
      '
      Me.BatchContentsToolTip.ToolTipTitle = "WinFreeREG - batch Contents"
      '
      'formBatchContents
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(856, 615)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Margin = New System.Windows.Forms.Padding(4)
      Me.Name = "formBatchContents"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "WinFreeREG - Batch Contents"
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel1.PerformLayout()
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
	Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
	Friend WithEvents FileContentsTextBox As System.Windows.Forms.TextBox
   Friend WithEvents btnSaveFile As System.Windows.Forms.Button
   Friend WithEvents BatchContentsToolTip As System.Windows.Forms.ToolTip
End Class
