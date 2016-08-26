<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formGeneralHelp
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formGeneralHelp))
      Me.wbPage = New System.Windows.Forms.WebBrowser()
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.btnBack = New System.Windows.Forms.ToolStripButton()
      Me.btnForward = New System.Windows.Forms.ToolStripButton()
      Me.ToolStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'wbPage
      '
      Me.wbPage.AllowWebBrowserDrop = False
      Me.wbPage.Dock = System.Windows.Forms.DockStyle.Fill
      Me.wbPage.Location = New System.Drawing.Point(0, 25)
      Me.wbPage.MinimumSize = New System.Drawing.Size(20, 20)
      Me.wbPage.Name = "wbPage"
      Me.wbPage.Size = New System.Drawing.Size(553, 252)
      Me.wbPage.TabIndex = 0
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBack, Me.btnForward})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(553, 25)
      Me.ToolStrip1.TabIndex = 1
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'btnBack
      '
      Me.btnBack.Enabled = False
      Me.btnBack.Image = CType(resources.GetObject("btnBack.Image"), System.Drawing.Image)
      Me.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.btnBack.Name = "btnBack"
      Me.btnBack.Size = New System.Drawing.Size(52, 22)
      Me.btnBack.Text = "Back"
      '
      'btnForward
      '
      Me.btnForward.Enabled = False
      Me.btnForward.Image = CType(resources.GetObject("btnForward.Image"), System.Drawing.Image)
      Me.btnForward.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.btnForward.Name = "btnForward"
      Me.btnForward.Size = New System.Drawing.Size(70, 22)
      Me.btnForward.Text = "Forward"
      '
      'formGeneralHelp
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(553, 277)
      Me.Controls.Add(Me.wbPage)
      Me.Controls.Add(Me.ToolStrip1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "formGeneralHelp"
      Me.Text = "General Help - {0}"
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents wbPage As System.Windows.Forms.WebBrowser
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents btnBack As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnForward As System.Windows.Forms.ToolStripButton
End Class
