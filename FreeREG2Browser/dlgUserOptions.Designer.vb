<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgUserOptions
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
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.OK_Button = New System.Windows.Forms.Button()
      Me.Cancel_Button = New System.Windows.Forms.Button()
      Me.groupCellEditActivation = New System.Windows.Forms.GroupBox()
      Me.radioF2Only = New System.Windows.Forms.RadioButton()
      Me.radioDoubleClick = New System.Windows.Forms.RadioButton()
      Me.radioSingleClickAlways = New System.Windows.Forms.RadioButton()
      Me.radioSingleClick = New System.Windows.Forms.RadioButton()
      Me.checkShowEditingCellBorder = New System.Windows.Forms.CheckBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.labelFont = New System.Windows.Forms.LinkLabel()
      Me.checkReplicateFicheAndImage = New System.Windows.Forms.CheckBox()
      Me.checkReplicateDates = New System.Windows.Forms.CheckBox()
      Me.checkAutoIncrementRegisterNumber = New System.Windows.Forms.CheckBox()
      Me.TableLayoutPanel1.SuspendLayout()
      Me.groupCellEditActivation.SuspendLayout()
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
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 274)
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
      'groupCellEditActivation
      '
      Me.groupCellEditActivation.Controls.Add(Me.radioF2Only)
      Me.groupCellEditActivation.Controls.Add(Me.radioDoubleClick)
      Me.groupCellEditActivation.Controls.Add(Me.radioSingleClickAlways)
      Me.groupCellEditActivation.Controls.Add(Me.radioSingleClick)
      Me.groupCellEditActivation.Location = New System.Drawing.Point(13, 13)
      Me.groupCellEditActivation.Name = "groupCellEditActivation"
      Me.groupCellEditActivation.Size = New System.Drawing.Size(200, 100)
      Me.groupCellEditActivation.TabIndex = 1
      Me.groupCellEditActivation.TabStop = False
      Me.groupCellEditActivation.Text = "Cell Edit Activate"
      '
      'radioF2Only
      '
      Me.radioF2Only.AutoSize = True
      Me.radioF2Only.Location = New System.Drawing.Point(7, 77)
      Me.radioF2Only.Name = "radioF2Only"
      Me.radioF2Only.Size = New System.Drawing.Size(59, 17)
      Me.radioF2Only.TabIndex = 3
      Me.radioF2Only.Text = "F2 only"
      Me.radioF2Only.UseVisualStyleBackColor = True
      '
      'radioDoubleClick
      '
      Me.radioDoubleClick.AutoSize = True
      Me.radioDoubleClick.Location = New System.Drawing.Point(7, 58)
      Me.radioDoubleClick.Name = "radioDoubleClick"
      Me.radioDoubleClick.Size = New System.Drawing.Size(84, 17)
      Me.radioDoubleClick.TabIndex = 2
      Me.radioDoubleClick.Text = "Double click"
      Me.radioDoubleClick.UseVisualStyleBackColor = True
      '
      'radioSingleClickAlways
      '
      Me.radioSingleClickAlways.AutoSize = True
      Me.radioSingleClickAlways.Location = New System.Drawing.Point(7, 39)
      Me.radioSingleClickAlways.Name = "radioSingleClickAlways"
      Me.radioSingleClickAlways.Size = New System.Drawing.Size(114, 17)
      Me.radioSingleClickAlways.TabIndex = 1
      Me.radioSingleClickAlways.Text = "Single click always"
      Me.radioSingleClickAlways.UseVisualStyleBackColor = True
      '
      'radioSingleClick
      '
      Me.radioSingleClick.AutoSize = True
      Me.radioSingleClick.Location = New System.Drawing.Point(7, 20)
      Me.radioSingleClick.Name = "radioSingleClick"
      Me.radioSingleClick.Size = New System.Drawing.Size(79, 17)
      Me.radioSingleClick.TabIndex = 0
      Me.radioSingleClick.Text = "Single click"
      Me.radioSingleClick.UseVisualStyleBackColor = True
      '
      'checkShowEditingCellBorder
      '
      Me.checkShowEditingCellBorder.AutoSize = True
      Me.checkShowEditingCellBorder.Location = New System.Drawing.Point(219, 22)
      Me.checkShowEditingCellBorder.Name = "checkShowEditingCellBorder"
      Me.checkShowEditingCellBorder.Size = New System.Drawing.Size(142, 17)
      Me.checkShowEditingCellBorder.TabIndex = 2
      Me.checkShowEditingCellBorder.Text = "Show Editing Cell Border"
      Me.checkShowEditingCellBorder.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(13, 120)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(31, 13)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Font:"
      '
      'labelFont
      '
      Me.labelFont.AutoSize = True
      Me.labelFont.Location = New System.Drawing.Point(40, 120)
      Me.labelFont.Name = "labelFont"
      Me.labelFont.Size = New System.Drawing.Size(25, 13)
      Me.labelFont.TabIndex = 5
      Me.labelFont.TabStop = True
      Me.labelFont.Text = "font"
      '
      'checkReplicateFicheAndImage
      '
      Me.checkReplicateFicheAndImage.AutoSize = True
      Me.checkReplicateFicheAndImage.Location = New System.Drawing.Point(219, 44)
      Me.checkReplicateFicheAndImage.Name = "checkReplicateFicheAndImage"
      Me.checkReplicateFicheAndImage.Size = New System.Drawing.Size(158, 17)
      Me.checkReplicateFicheAndImage.TabIndex = 6
      Me.checkReplicateFicheAndImage.Text = "Replicate Fiche/Image data"
      Me.checkReplicateFicheAndImage.UseVisualStyleBackColor = True
      '
      'checkReplicateDates
      '
      Me.checkReplicateDates.AutoSize = True
      Me.checkReplicateDates.Location = New System.Drawing.Point(219, 66)
      Me.checkReplicateDates.Name = "checkReplicateDates"
      Me.checkReplicateDates.Size = New System.Drawing.Size(102, 17)
      Me.checkReplicateDates.TabIndex = 7
      Me.checkReplicateDates.Text = "Replicate Dates"
      Me.checkReplicateDates.UseVisualStyleBackColor = True
      '
      'checkAutoIncrementRegisterNumber
      '
      Me.checkAutoIncrementRegisterNumber.AutoSize = True
      Me.checkAutoIncrementRegisterNumber.Location = New System.Drawing.Point(219, 88)
      Me.checkAutoIncrementRegisterNumber.Name = "checkAutoIncrementRegisterNumber"
      Me.checkAutoIncrementRegisterNumber.Size = New System.Drawing.Size(177, 17)
      Me.checkAutoIncrementRegisterNumber.TabIndex = 8
      Me.checkAutoIncrementRegisterNumber.Text = "AutoIncrement Register Number"
      Me.checkAutoIncrementRegisterNumber.UseVisualStyleBackColor = True
      '
      'dlgUserOptions
      '
      Me.AcceptButton = Me.OK_Button
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.Cancel_Button
      Me.ClientSize = New System.Drawing.Size(435, 315)
      Me.Controls.Add(Me.checkAutoIncrementRegisterNumber)
      Me.Controls.Add(Me.checkReplicateDates)
      Me.Controls.Add(Me.checkReplicateFicheAndImage)
      Me.Controls.Add(Me.labelFont)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.checkShowEditingCellBorder)
      Me.Controls.Add(Me.groupCellEditActivation)
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.HelpButton = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "dlgUserOptions"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "User Options"
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.groupCellEditActivation.ResumeLayout(False)
      Me.groupCellEditActivation.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents OK_Button As System.Windows.Forms.Button
   Friend WithEvents Cancel_Button As System.Windows.Forms.Button
   Friend WithEvents groupCellEditActivation As System.Windows.Forms.GroupBox
   Friend WithEvents radioF2Only As System.Windows.Forms.RadioButton
   Friend WithEvents radioDoubleClick As System.Windows.Forms.RadioButton
   Friend WithEvents radioSingleClickAlways As System.Windows.Forms.RadioButton
   Friend WithEvents radioSingleClick As System.Windows.Forms.RadioButton
   Friend WithEvents checkShowEditingCellBorder As System.Windows.Forms.CheckBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents labelFont As System.Windows.Forms.LinkLabel
   Friend WithEvents checkReplicateFicheAndImage As System.Windows.Forms.CheckBox
   Friend WithEvents checkReplicateDates As System.Windows.Forms.CheckBox
   Friend WithEvents checkAutoIncrementRegisterNumber As System.Windows.Forms.CheckBox

End Class
