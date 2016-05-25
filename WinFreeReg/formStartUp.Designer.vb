<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formStartUp
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formStartUp))
      Me.PasswordTextBox = New System.Windows.Forms.TextBox()
      Me.UsernameTextBox = New System.Windows.Forms.TextBox()
      Me.PasswordLabel = New System.Windows.Forms.Label()
      Me.UsernameLabel = New System.Windows.Forms.Label()
      Me.buttonStart = New System.Windows.Forms.Button()
      Me.TranscriptionLibraryLabel = New System.Windows.Forms.Label()
      Me.LibraryTextBox = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      '
      'PasswordTextBox
      '
      Me.PasswordTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.PasswordTextBox.Location = New System.Drawing.Point(12, 79)
      Me.PasswordTextBox.Name = "PasswordTextBox"
      Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.PasswordTextBox.Size = New System.Drawing.Size(220, 26)
      Me.PasswordTextBox.TabIndex = 7
      '
      'UsernameTextBox
      '
      Me.UsernameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.UsernameTextBox.Location = New System.Drawing.Point(12, 29)
      Me.UsernameTextBox.Name = "UsernameTextBox"
      Me.UsernameTextBox.Size = New System.Drawing.Size(220, 26)
      Me.UsernameTextBox.TabIndex = 5
      '
      'PasswordLabel
      '
      Me.PasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.PasswordLabel.Location = New System.Drawing.Point(12, 59)
      Me.PasswordLabel.Name = "PasswordLabel"
      Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
      Me.PasswordLabel.TabIndex = 6
      Me.PasswordLabel.Text = "&Password"
      Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'UsernameLabel
      '
      Me.UsernameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.UsernameLabel.Location = New System.Drawing.Point(12, 9)
      Me.UsernameLabel.Name = "UsernameLabel"
      Me.UsernameLabel.Size = New System.Drawing.Size(220, 23)
      Me.UsernameLabel.TabIndex = 4
      Me.UsernameLabel.Text = "&User name"
      Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'buttonStart
      '
      Me.buttonStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.buttonStart.Enabled = False
      Me.buttonStart.Location = New System.Drawing.Point(300, 226)
      Me.buttonStart.Name = "buttonStart"
      Me.buttonStart.Size = New System.Drawing.Size(75, 23)
      Me.buttonStart.TabIndex = 8
      Me.buttonStart.Text = "Go!"
      Me.buttonStart.UseVisualStyleBackColor = True
      '
      'TranscriptionLibraryLabel
      '
      Me.TranscriptionLibraryLabel.AutoSize = True
      Me.TranscriptionLibraryLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.TranscriptionLibraryLabel.Location = New System.Drawing.Point(12, 127)
      Me.TranscriptionLibraryLabel.Name = "TranscriptionLibraryLabel"
      Me.TranscriptionLibraryLabel.Size = New System.Drawing.Size(151, 20)
      Me.TranscriptionLibraryLabel.TabIndex = 9
      Me.TranscriptionLibraryLabel.Text = "Transcription Library"
      '
      'LibraryTextBox
      '
      Me.LibraryTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.LibraryTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LibraryTextBox.Location = New System.Drawing.Point(12, 150)
      Me.LibraryTextBox.Name = "LibraryTextBox"
      Me.LibraryTextBox.Size = New System.Drawing.Size(363, 24)
      Me.LibraryTextBox.TabIndex = 10
      '
      'formStartUp
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(399, 261)
      Me.Controls.Add(Me.LibraryTextBox)
      Me.Controls.Add(Me.TranscriptionLibraryLabel)
      Me.Controls.Add(Me.buttonStart)
      Me.Controls.Add(Me.PasswordTextBox)
      Me.Controls.Add(Me.UsernameTextBox)
      Me.Controls.Add(Me.PasswordLabel)
      Me.Controls.Add(Me.UsernameLabel)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "formStartUp"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "WinFreeReg - Startup"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
   Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents PasswordLabel As System.Windows.Forms.Label
   Friend WithEvents UsernameLabel As System.Windows.Forms.Label
   Friend WithEvents buttonStart As System.Windows.Forms.Button
   Friend WithEvents TranscriptionLibraryLabel As System.Windows.Forms.Label
   Friend WithEvents LibraryTextBox As System.Windows.Forms.TextBox

End Class
