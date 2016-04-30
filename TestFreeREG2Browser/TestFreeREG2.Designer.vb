<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestBrowser
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTestBrowser))
		Me.btnStart = New System.Windows.Forms.Button
		Me.btnErrorMessages = New System.Windows.Forms.Button
		Me.SuspendLayout()
		'
		'btnStart
		'
		Me.btnStart.Location = New System.Drawing.Point(121, 111)
		Me.btnStart.Name = "btnStart"
		Me.btnStart.Size = New System.Drawing.Size(75, 23)
		Me.btnStart.TabIndex = 0
		Me.btnStart.Text = "Start"
		Me.btnStart.UseVisualStyleBackColor = True
		'
		'btnErrorMessages
		'
		Me.btnErrorMessages.Location = New System.Drawing.Point(13, 226)
		Me.btnErrorMessages.Name = "btnErrorMessages"
		Me.btnErrorMessages.Size = New System.Drawing.Size(94, 23)
		Me.btnErrorMessages.TabIndex = 1
		Me.btnErrorMessages.Text = "Error Messages"
		Me.btnErrorMessages.UseVisualStyleBackColor = True
		'
		'frmTestBrowser
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(332, 261)
		Me.Controls.Add(Me.btnErrorMessages)
		Me.Controls.Add(Me.btnStart)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmTestBrowser"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Test FreeREG/2 Browser"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents btnStart As System.Windows.Forms.Button
	Friend WithEvents btnErrorMessages As System.Windows.Forms.Button

End Class
