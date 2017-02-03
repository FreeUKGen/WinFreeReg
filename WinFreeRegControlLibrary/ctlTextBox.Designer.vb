<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlTextBox
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
      Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
      Me.FlowLayoutPanel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'txtField
      '
      Me.txtField.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
      Me.txtField.Dock = System.Windows.Forms.DockStyle.Fill
      Me.txtField.Location = New System.Drawing.Point(0, 0)
      Me.txtField.Margin = New System.Windows.Forms.Padding(0)
      Me.txtField.Name = "txtField"
      Me.txtField.Size = New System.Drawing.Size(122, 20)
      Me.txtField.TabIndex = 0
      '
      'FlowLayoutPanel1
      '
      Me.FlowLayoutPanel1.AutoSize = True
      Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.FlowLayoutPanel1.Controls.Add(Me.txtField)
      Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
      Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
      Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
      Me.FlowLayoutPanel1.Size = New System.Drawing.Size(125, 22)
      Me.FlowLayoutPanel1.TabIndex = 1
      '
      'ctlTextBox
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.AutoSize = True
      Me.Controls.Add(Me.FlowLayoutPanel1)
      Me.Margin = New System.Windows.Forms.Padding(0)
      Me.Name = "ctlTextBox"
      Me.Size = New System.Drawing.Size(125, 22)
      Me.FlowLayoutPanel1.ResumeLayout(False)
      Me.FlowLayoutPanel1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtField As System.Windows.Forms.TextBox
   Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel

End Class
