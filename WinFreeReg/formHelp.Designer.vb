<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formHelp
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formHelp))
      Me.wbPage = New System.Windows.Forms.WebBrowser()
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
      Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
      Me.btnHome = New System.Windows.Forms.ToolStripButton()
      Me.btnBack = New System.Windows.Forms.ToolStripButton()
      Me.btnForward = New System.Windows.Forms.ToolStripButton()
      Me.btnHome1 = New System.Windows.Forms.ToolStripButton()
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
      Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4, Me.ToolStripButton5})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(553, 25)
      Me.ToolStrip1.TabIndex = 1
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'ToolStripButton4
      '
      Me.ToolStripButton4.Enabled = False
      Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
      Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton4.Name = "ToolStripButton4"
      Me.ToolStripButton4.Size = New System.Drawing.Size(52, 22)
      Me.ToolStripButton4.Text = "Back"
      '
      'ToolStripButton5
      '
      Me.ToolStripButton5.Enabled = False
      Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
      Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton5.Name = "ToolStripButton5"
      Me.ToolStripButton5.Size = New System.Drawing.Size(70, 22)
      Me.ToolStripButton5.Text = "Forward"
      '
      'ToolStripButton1
      '
      Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton1.Name = "ToolStripButton1"
      Me.ToolStripButton1.Size = New System.Drawing.Size(60, 22)
      Me.ToolStripButton1.Text = "Home"
      '
      'ToolStripButton2
      '
      Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ToolStripButton2.Name = "ToolStripButton2"
      Me.ToolStripButton2.Size = New System.Drawing.Size(52, 22)
      Me.ToolStripButton2.Text = "Back"
      '
      'btnHome
      '
      Me.btnHome.Image = CType(resources.GetObject("btnHome.Image"), System.Drawing.Image)
      Me.btnHome.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.btnHome.Name = "btnHome"
      Me.btnHome.Size = New System.Drawing.Size(60, 22)
      Me.btnHome.Text = "Home"
      '
      'btnBack
      '
      Me.btnBack.Image = CType(resources.GetObject("btnBack.Image"), System.Drawing.Image)
      Me.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.btnBack.Name = "btnBack"
      Me.btnBack.Size = New System.Drawing.Size(52, 22)
      Me.btnBack.Text = "Back"
      '
      'btnForward
      '
      Me.btnForward.Image = CType(resources.GetObject("btnForward.Image"), System.Drawing.Image)
      Me.btnForward.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.btnForward.Name = "btnForward"
      Me.btnForward.Size = New System.Drawing.Size(70, 22)
      Me.btnForward.Text = "Forward"
      '
      'btnHome1
      '
      Me.btnHome1.Image = CType(resources.GetObject("btnHome1.Image"), System.Drawing.Image)
      Me.btnHome1.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.btnHome1.Name = "btnHome1"
      Me.btnHome1.Size = New System.Drawing.Size(60, 22)
      Me.btnHome1.Text = "Home"
      '
      'formHelp
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(553, 277)
      Me.Controls.Add(Me.wbPage)
      Me.Controls.Add(Me.ToolStrip1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "formHelp"
      Me.Text = "General Help - {0}"
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents wbPage As System.Windows.Forms.WebBrowser
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnHome As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnBack As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnForward As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnHome1 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
End Class
