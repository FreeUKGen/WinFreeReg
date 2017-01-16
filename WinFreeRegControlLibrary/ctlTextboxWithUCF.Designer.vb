<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlTextboxWithUCF
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
      Me.txtField = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'txtField
      '
      Me.txtField.Location = New System.Drawing.Point(4, 7)
      Me.txtField.Name = "txtField"
      Me.txtField.Size = New System.Drawing.Size(143, 20)
      Me.txtField.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(168, 10)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(46, 13)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "F5=UCF"
      '
      'ctlTextboxWithUCF
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.AliceBlue
      Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtField)
      Me.Name = "ctlTextboxWithUCF"
      Me.Size = New System.Drawing.Size(217, 35)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtField As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
