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
      Me.labColumn = New System.Windows.Forms.Label()
      Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
      Me.FlowLayoutPanel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'txtField
      '
      Me.txtField.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.txtField.Location = New System.Drawing.Point(83, 6)
      Me.txtField.Name = "txtField"
      Me.txtField.Size = New System.Drawing.Size(143, 20)
      Me.txtField.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.Label1.AutoSize = True
      Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
      Me.Label1.Location = New System.Drawing.Point(232, 9)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(46, 13)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "F5=UCF"
      '
      'labColumn
      '
      Me.labColumn.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.labColumn.AutoSize = True
      Me.labColumn.Location = New System.Drawing.Point(6, 9)
      Me.labColumn.Name = "labColumn"
      Me.labColumn.Size = New System.Drawing.Size(71, 13)
      Me.labColumn.TabIndex = 2
      Me.labColumn.Text = "Column name"
      '
      'FlowLayoutPanel1
      '
      Me.FlowLayoutPanel1.AutoSize = True
      Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.FlowLayoutPanel1.Controls.Add(Me.labColumn)
      Me.FlowLayoutPanel1.Controls.Add(Me.txtField)
      Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
      Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
      Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
      Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(3)
      Me.FlowLayoutPanel1.Size = New System.Drawing.Size(284, 32)
      Me.FlowLayoutPanel1.TabIndex = 3
      '
      'ctlTextboxWithUCF
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.AutoSize = True
      Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.BackColor = System.Drawing.Color.AliceBlue
      Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Controls.Add(Me.FlowLayoutPanel1)
      Me.Name = "ctlTextboxWithUCF"
      Me.Size = New System.Drawing.Size(284, 32)
      Me.FlowLayoutPanel1.ResumeLayout(False)
      Me.FlowLayoutPanel1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtField As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents labColumn As System.Windows.Forms.Label
   Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel

End Class
