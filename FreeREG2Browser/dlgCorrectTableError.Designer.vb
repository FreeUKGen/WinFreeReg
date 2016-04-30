<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCorrectTableError
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
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
		Me.OK_Button = New System.Windows.Forms.Button
		Me.Cancel_Button = New System.Windows.Forms.Button
		Me.Label1 = New System.Windows.Forms.Label
		Me.txtTableName = New System.Windows.Forms.TextBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.txtFileValue = New System.Windows.Forms.TextBox
		Me.txtDisplayValue = New System.Windows.Forms.TextBox
		Me.labError = New System.Windows.Forms.Label
		Me.TableLayoutPanel1.SuspendLayout()
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
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(329, 274)
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
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(13, 13)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(34, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Table"
		'
		'txtTableName
		'
		Me.txtTableName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtTableName.Location = New System.Drawing.Point(89, 10)
		Me.txtTableName.Name = "txtTableName"
		Me.txtTableName.ReadOnly = True
		Me.txtTableName.Size = New System.Drawing.Size(140, 20)
		Me.txtTableName.TabIndex = 2
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(13, 46)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(52, 13)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "File value"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(13, 70)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(70, 13)
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "Display value"
		'
		'txtFileValue
		'
		Me.txtFileValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtFileValue.Location = New System.Drawing.Point(89, 39)
		Me.txtFileValue.Name = "txtFileValue"
		Me.txtFileValue.Size = New System.Drawing.Size(140, 20)
		Me.txtFileValue.TabIndex = 5
		'
		'txtDisplayValue
		'
		Me.txtDisplayValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtDisplayValue.Location = New System.Drawing.Point(89, 63)
		Me.txtDisplayValue.Name = "txtDisplayValue"
		Me.txtDisplayValue.Size = New System.Drawing.Size(140, 20)
		Me.txtDisplayValue.TabIndex = 6
		'
		'labError
		'
		Me.labError.Location = New System.Drawing.Point(86, 102)
		Me.labError.Name = "labError"
		Me.labError.Size = New System.Drawing.Size(386, 23)
		Me.labError.TabIndex = 7
		'
		'dlgCorrectTableError
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(487, 315)
		Me.Controls.Add(Me.labError)
		Me.Controls.Add(Me.txtDisplayValue)
		Me.Controls.Add(Me.txtFileValue)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.txtTableName)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "dlgCorrectTableError"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Correct Table Error"
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents txtTableName As System.Windows.Forms.TextBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents txtFileValue As System.Windows.Forms.TextBox
	Friend WithEvents txtDisplayValue As System.Windows.Forms.TextBox
	Friend WithEvents labError As System.Windows.Forms.Label

End Class
