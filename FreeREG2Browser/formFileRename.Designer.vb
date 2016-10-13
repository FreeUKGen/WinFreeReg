<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formFileRename
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
      Me.Label1 = New System.Windows.Forms.Label()
      Me.labelFilename = New System.Windows.Forms.Label()
      Me.labelPlace = New System.Windows.Forms.Label()
      Me.labelChurch = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.labelFileCode = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(13, 13)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(52, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Filename:"
      '
      'labelFilename
      '
      Me.labelFilename.AutoSize = True
      Me.labelFilename.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.labelFilename.Location = New System.Drawing.Point(61, 9)
      Me.labelFilename.Name = "labelFilename"
      Me.labelFilename.Size = New System.Drawing.Size(53, 20)
      Me.labelFilename.TabIndex = 1
      Me.labelFilename.Text = "name"
      '
      'labelPlace
      '
      Me.labelPlace.AutoSize = True
      Me.labelPlace.Location = New System.Drawing.Point(62, 38)
      Me.labelPlace.Name = "labelPlace"
      Me.labelPlace.Size = New System.Drawing.Size(33, 13)
      Me.labelPlace.TabIndex = 2
      Me.labelPlace.Text = "place"
      '
      'labelChurch
      '
      Me.labelChurch.AutoSize = True
      Me.labelChurch.Location = New System.Drawing.Point(62, 62)
      Me.labelChurch.Name = "labelChurch"
      Me.labelChurch.Size = New System.Drawing.Size(40, 13)
      Me.labelChurch.TabIndex = 3
      Me.labelChurch.Text = "church"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(344, 13)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(38, 13)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "Code: "
      '
      'labelFileCode
      '
      Me.labelFileCode.AutoSize = True
      Me.labelFileCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.labelFileCode.Location = New System.Drawing.Point(377, 9)
      Me.labelFileCode.Name = "labelFileCode"
      Me.labelFileCode.Size = New System.Drawing.Size(48, 20)
      Me.labelFileCode.TabIndex = 5
      Me.labelFileCode.Text = "code"
      '
      'formFileRename
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(474, 265)
      Me.Controls.Add(Me.labelFileCode)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.labelChurch)
      Me.Controls.Add(Me.labelPlace)
      Me.Controls.Add(Me.labelFilename)
      Me.Controls.Add(Me.Label1)
      Me.Name = "formFileRename"
      Me.Text = "Rename File"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents labelFilename As System.Windows.Forms.Label
   Friend WithEvents labelPlace As System.Windows.Forms.Label
   Friend WithEvents labelChurch As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents labelFileCode As System.Windows.Forms.Label
End Class
