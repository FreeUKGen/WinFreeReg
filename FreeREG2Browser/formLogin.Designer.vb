<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class formLogin
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
	Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formLogin))
		Me.UsernameLabel = New System.Windows.Forms.Label
		Me.PasswordLabel = New System.Windows.Forms.Label
		Me.UsernameTextBox = New System.Windows.Forms.TextBox
		Me.PasswordTextBox = New System.Windows.Forms.TextBox
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.UrlLabel = New System.Windows.Forms.Label
		Me.UrlTextBox = New System.Windows.Forms.TextBox
		Me.SuspendLayout()
		'
		'UsernameLabel
		'
		Me.UsernameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.UsernameLabel.Location = New System.Drawing.Point(11, 46)
		Me.UsernameLabel.Name = "UsernameLabel"
		Me.UsernameLabel.Size = New System.Drawing.Size(220, 23)
		Me.UsernameLabel.TabIndex = 0
		Me.UsernameLabel.Text = "&User name"
		Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'PasswordLabel
		'
		Me.PasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PasswordLabel.Location = New System.Drawing.Point(13, 96)
		Me.PasswordLabel.Name = "PasswordLabel"
		Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
		Me.PasswordLabel.TabIndex = 2
		Me.PasswordLabel.Text = "&Password"
		Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'UsernameTextBox
		'
		Me.UsernameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.UsernameTextBox.Location = New System.Drawing.Point(12, 66)
		Me.UsernameTextBox.Name = "UsernameTextBox"
		Me.UsernameTextBox.Size = New System.Drawing.Size(220, 26)
		Me.UsernameTextBox.TabIndex = 1
		'
		'PasswordTextBox
		'
		Me.PasswordTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PasswordTextBox.Location = New System.Drawing.Point(15, 116)
		Me.PasswordTextBox.Name = "PasswordTextBox"
		Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
		Me.PasswordTextBox.Size = New System.Drawing.Size(220, 26)
		Me.PasswordTextBox.TabIndex = 3
		'
		'OK_Button
		'
		Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.OK_Button.Location = New System.Drawing.Point(197, 161)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(94, 23)
		Me.OK_Button.TabIndex = 4
		Me.OK_Button.Text = "&OK"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.Cancel_Button.Location = New System.Drawing.Point(300, 161)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(94, 23)
		Me.Cancel_Button.TabIndex = 5
		Me.Cancel_Button.Text = "&Cancel"
		'
		'UrlLabel
		'
		Me.UrlLabel.AutoSize = True
		Me.UrlLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.UrlLabel.Location = New System.Drawing.Point(12, 11)
		Me.UrlLabel.Name = "UrlLabel"
		Me.UrlLabel.Size = New System.Drawing.Size(33, 20)
		Me.UrlLabel.TabIndex = 6
		Me.UrlLabel.Text = "Url:"
		'
		'UrlTextBox
		'
		Me.UrlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.UrlTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.UrlTextBox.Location = New System.Drawing.Point(42, 11)
		Me.UrlTextBox.Name = "UrlTextBox"
		Me.UrlTextBox.ReadOnly = True
		Me.UrlTextBox.Size = New System.Drawing.Size(347, 19)
		Me.UrlTextBox.TabIndex = 7
		'
		'formLogin
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(401, 192)
		Me.Controls.Add(Me.UrlTextBox)
		Me.Controls.Add(Me.UrlLabel)
		Me.Controls.Add(Me.Cancel_Button)
		Me.Controls.Add(Me.OK_Button)
		Me.Controls.Add(Me.PasswordTextBox)
		Me.Controls.Add(Me.UsernameTextBox)
		Me.Controls.Add(Me.PasswordLabel)
		Me.Controls.Add(Me.UsernameLabel)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "formLogin"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Login to FreeREG"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents UrlLabel As System.Windows.Forms.Label
	Friend WithEvents UrlTextBox As System.Windows.Forms.TextBox

End Class
