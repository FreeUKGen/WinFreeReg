<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formBaptismRecord
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
      Me.components = New System.ComponentModel.Container()
      Dim RegNoLabel As System.Windows.Forms.Label
      Dim BirthDateLabel As System.Windows.Forms.Label
      Dim BaptismDateLabel As System.Windows.Forms.Label
      Dim ForenamesLabel As System.Windows.Forms.Label
      Dim SexLabel As System.Windows.Forms.Label
      Dim FathersNameLabel As System.Windows.Forms.Label
      Dim MothersNameLabel As System.Windows.Forms.Label
      Dim FathersSurnameLabel As System.Windows.Forms.Label
      Dim MothersSurnameLabel As System.Windows.Forms.Label
      Dim AbodeLabel As System.Windows.Forms.Label
      Dim FathersOccupationLabel As System.Windows.Forms.Label
      Dim NotesLabel As System.Windows.Forms.Label
      Dim LDSFicheLabel As System.Windows.Forms.Label
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.RegNoTextBox = New System.Windows.Forms.TextBox()
      Me.BirthDateTextBox = New System.Windows.Forms.TextBox()
      Me.BaptismDateTextBox = New System.Windows.Forms.TextBox()
      Me.ForenamesTextBox = New System.Windows.Forms.TextBox()
      Me.SexComboBox = New System.Windows.Forms.ComboBox()
      Me.BaptismSexBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.FathersNameTextBox = New System.Windows.Forms.TextBox()
      Me.MothersNameTextBox = New System.Windows.Forms.TextBox()
      Me.FathersSurnameTextBox = New System.Windows.Forms.TextBox()
      Me.MothersSurnameTextBox = New System.Windows.Forms.TextBox()
      Me.AbodeTextBox = New System.Windows.Forms.TextBox()
      Me.FathersOccupationTextBox = New System.Windows.Forms.TextBox()
      Me.NotesTextBox = New System.Windows.Forms.TextBox()
      Me.LDSFicheTextBox = New System.Windows.Forms.TextBox()
      Me.LDSImageTextBox = New System.Windows.Forms.TextBox()
      Me.ButtonOK = New System.Windows.Forms.Button()
      Me.ButtonCancel = New System.Windows.Forms.Button()
      Me.BaptismToolTip = New System.Windows.Forms.ToolTip(Me.components)
      RegNoLabel = New System.Windows.Forms.Label()
      BirthDateLabel = New System.Windows.Forms.Label()
      BaptismDateLabel = New System.Windows.Forms.Label()
      ForenamesLabel = New System.Windows.Forms.Label()
      SexLabel = New System.Windows.Forms.Label()
      FathersNameLabel = New System.Windows.Forms.Label()
      MothersNameLabel = New System.Windows.Forms.Label()
      FathersSurnameLabel = New System.Windows.Forms.Label()
      MothersSurnameLabel = New System.Windows.Forms.Label()
      AbodeLabel = New System.Windows.Forms.Label()
      FathersOccupationLabel = New System.Windows.Forms.Label()
      NotesLabel = New System.Windows.Forms.Label()
      LDSFicheLabel = New System.Windows.Forms.Label()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.BaptismSexBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'RegNoLabel
      '
      RegNoLabel.AutoSize = True
      RegNoLabel.Location = New System.Drawing.Point(16, 19)
      RegNoLabel.Name = "RegNoLabel"
      RegNoLabel.Size = New System.Drawing.Size(47, 13)
      RegNoLabel.TabIndex = 1
      RegNoLabel.Text = "Reg No:"
      '
      'BirthDateLabel
      '
      BirthDateLabel.AutoSize = True
      BirthDateLabel.Location = New System.Drawing.Point(16, 45)
      BirthDateLabel.Name = "BirthDateLabel"
      BirthDateLabel.Size = New System.Drawing.Size(57, 13)
      BirthDateLabel.TabIndex = 3
      BirthDateLabel.Text = "Birth Date:"
      '
      'BaptismDateLabel
      '
      BaptismDateLabel.AutoSize = True
      BaptismDateLabel.Location = New System.Drawing.Point(16, 71)
      BaptismDateLabel.Name = "BaptismDateLabel"
      BaptismDateLabel.Size = New System.Drawing.Size(73, 13)
      BaptismDateLabel.TabIndex = 5
      BaptismDateLabel.Text = "Baptism Date:"
      '
      'ForenamesLabel
      '
      ForenamesLabel.AutoSize = True
      ForenamesLabel.Location = New System.Drawing.Point(16, 97)
      ForenamesLabel.Name = "ForenamesLabel"
      ForenamesLabel.Size = New System.Drawing.Size(62, 13)
      ForenamesLabel.TabIndex = 7
      ForenamesLabel.Text = "Forenames:"
      '
      'SexLabel
      '
      SexLabel.AutoSize = True
      SexLabel.Location = New System.Drawing.Point(16, 123)
      SexLabel.Name = "SexLabel"
      SexLabel.Size = New System.Drawing.Size(28, 13)
      SexLabel.TabIndex = 9
      SexLabel.Text = "Sex:"
      '
      'FathersNameLabel
      '
      FathersNameLabel.AutoSize = True
      FathersNameLabel.Location = New System.Drawing.Point(16, 150)
      FathersNameLabel.Name = "FathersNameLabel"
      FathersNameLabel.Size = New System.Drawing.Size(76, 13)
      FathersNameLabel.TabIndex = 11
      FathersNameLabel.Text = "Fathers Name:"
      '
      'MothersNameLabel
      '
      MothersNameLabel.AutoSize = True
      MothersNameLabel.Location = New System.Drawing.Point(16, 176)
      MothersNameLabel.Name = "MothersNameLabel"
      MothersNameLabel.Size = New System.Drawing.Size(79, 13)
      MothersNameLabel.TabIndex = 13
      MothersNameLabel.Text = "Mothers Name:"
      '
      'FathersSurnameLabel
      '
      FathersSurnameLabel.AutoSize = True
      FathersSurnameLabel.Location = New System.Drawing.Point(252, 150)
      FathersSurnameLabel.Name = "FathersSurnameLabel"
      FathersSurnameLabel.Size = New System.Drawing.Size(90, 13)
      FathersSurnameLabel.TabIndex = 15
      FathersSurnameLabel.Text = "Fathers Surname:"
      '
      'MothersSurnameLabel
      '
      MothersSurnameLabel.AutoSize = True
      MothersSurnameLabel.Location = New System.Drawing.Point(252, 176)
      MothersSurnameLabel.Name = "MothersSurnameLabel"
      MothersSurnameLabel.Size = New System.Drawing.Size(93, 13)
      MothersSurnameLabel.TabIndex = 17
      MothersSurnameLabel.Text = "Mothers Surname:"
      '
      'AbodeLabel
      '
      AbodeLabel.AutoSize = True
      AbodeLabel.Location = New System.Drawing.Point(16, 202)
      AbodeLabel.Name = "AbodeLabel"
      AbodeLabel.Size = New System.Drawing.Size(41, 13)
      AbodeLabel.TabIndex = 19
      AbodeLabel.Text = "Abode:"
      '
      'FathersOccupationLabel
      '
      FathersOccupationLabel.AutoSize = True
      FathersOccupationLabel.Location = New System.Drawing.Point(16, 228)
      FathersOccupationLabel.Name = "FathersOccupationLabel"
      FathersOccupationLabel.Size = New System.Drawing.Size(103, 13)
      FathersOccupationLabel.TabIndex = 21
      FathersOccupationLabel.Text = "Fathers Occupation:"
      '
      'NotesLabel
      '
      NotesLabel.AutoSize = True
      NotesLabel.Location = New System.Drawing.Point(16, 254)
      NotesLabel.Name = "NotesLabel"
      NotesLabel.Size = New System.Drawing.Size(38, 13)
      NotesLabel.TabIndex = 23
      NotesLabel.Text = "Notes:"
      '
      'LDSFicheLabel
      '
      LDSFicheLabel.AutoSize = True
      LDSFicheLabel.Location = New System.Drawing.Point(16, 280)
      LDSFicheLabel.Name = "LDSFicheLabel"
      LDSFicheLabel.Size = New System.Drawing.Size(70, 13)
      LDSFicheLabel.TabIndex = 25
      LDSFicheLabel.Text = "Fiche/Image:"
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'RegNoTextBox
      '
      Me.RegNoTextBox.Location = New System.Drawing.Point(125, 16)
      Me.RegNoTextBox.Name = "RegNoTextBox"
      Me.RegNoTextBox.Size = New System.Drawing.Size(121, 20)
      Me.RegNoTextBox.TabIndex = 2
      Me.RegNoTextBox.Tag = "RegNo"
      '
      'BirthDateTextBox
      '
      Me.BirthDateTextBox.Location = New System.Drawing.Point(125, 42)
      Me.BirthDateTextBox.Name = "BirthDateTextBox"
      Me.BirthDateTextBox.Size = New System.Drawing.Size(121, 20)
      Me.BirthDateTextBox.TabIndex = 4
      Me.BirthDateTextBox.Tag = "BirthDate"
      '
      'BaptismDateTextBox
      '
      Me.BaptismDateTextBox.Location = New System.Drawing.Point(125, 68)
      Me.BaptismDateTextBox.Name = "BaptismDateTextBox"
      Me.BaptismDateTextBox.Size = New System.Drawing.Size(121, 20)
      Me.BaptismDateTextBox.TabIndex = 6
      Me.BaptismDateTextBox.Tag = "BaptismDate"
      '
      'ForenamesTextBox
      '
      Me.ForenamesTextBox.Location = New System.Drawing.Point(125, 94)
      Me.ForenamesTextBox.Name = "ForenamesTextBox"
      Me.ForenamesTextBox.Size = New System.Drawing.Size(121, 20)
      Me.ForenamesTextBox.TabIndex = 8
      Me.ForenamesTextBox.Tag = "Forenames"
      '
      'SexComboBox
      '
      Me.SexComboBox.DataSource = Me.BaptismSexBindingSource
      Me.SexComboBox.DisplayMember = "Description"
      Me.SexComboBox.FormattingEnabled = True
      Me.SexComboBox.Location = New System.Drawing.Point(125, 120)
      Me.SexComboBox.Name = "SexComboBox"
      Me.SexComboBox.Size = New System.Drawing.Size(121, 21)
      Me.SexComboBox.TabIndex = 10
      Me.SexComboBox.Tag = "Sex"
      Me.SexComboBox.ValueMember = "Code"
      '
      'BaptismSexBindingSource
      '
      Me.BaptismSexBindingSource.DataMember = "BaptismSex"
      Me.BaptismSexBindingSource.DataSource = GetType(WinFreeReg.LookupTables)
      '
      'FathersNameTextBox
      '
      Me.FathersNameTextBox.Location = New System.Drawing.Point(125, 147)
      Me.FathersNameTextBox.Name = "FathersNameTextBox"
      Me.FathersNameTextBox.Size = New System.Drawing.Size(121, 20)
      Me.FathersNameTextBox.TabIndex = 12
      Me.FathersNameTextBox.Tag = "FathersName"
      '
      'MothersNameTextBox
      '
      Me.MothersNameTextBox.Location = New System.Drawing.Point(125, 173)
      Me.MothersNameTextBox.Name = "MothersNameTextBox"
      Me.MothersNameTextBox.Size = New System.Drawing.Size(121, 20)
      Me.MothersNameTextBox.TabIndex = 14
      Me.MothersNameTextBox.Tag = "MothersName"
      '
      'FathersSurnameTextBox
      '
      Me.FathersSurnameTextBox.Location = New System.Drawing.Point(361, 147)
      Me.FathersSurnameTextBox.Name = "FathersSurnameTextBox"
      Me.FathersSurnameTextBox.Size = New System.Drawing.Size(121, 20)
      Me.FathersSurnameTextBox.TabIndex = 16
      Me.FathersSurnameTextBox.Tag = "FathersSurname"
      '
      'MothersSurnameTextBox
      '
      Me.MothersSurnameTextBox.Location = New System.Drawing.Point(361, 173)
      Me.MothersSurnameTextBox.Name = "MothersSurnameTextBox"
      Me.MothersSurnameTextBox.Size = New System.Drawing.Size(121, 20)
      Me.MothersSurnameTextBox.TabIndex = 18
      Me.MothersSurnameTextBox.Tag = "MothersSurname"
      '
      'AbodeTextBox
      '
      Me.AbodeTextBox.Location = New System.Drawing.Point(125, 199)
      Me.AbodeTextBox.Name = "AbodeTextBox"
      Me.AbodeTextBox.Size = New System.Drawing.Size(121, 20)
      Me.AbodeTextBox.TabIndex = 20
      Me.AbodeTextBox.Tag = "Abode"
      '
      'FathersOccupationTextBox
      '
      Me.FathersOccupationTextBox.Location = New System.Drawing.Point(125, 225)
      Me.FathersOccupationTextBox.Name = "FathersOccupationTextBox"
      Me.FathersOccupationTextBox.Size = New System.Drawing.Size(121, 20)
      Me.FathersOccupationTextBox.TabIndex = 22
      Me.FathersOccupationTextBox.Tag = "FathersOccupation"
      '
      'NotesTextBox
      '
      Me.NotesTextBox.Location = New System.Drawing.Point(125, 251)
      Me.NotesTextBox.Name = "NotesTextBox"
      Me.NotesTextBox.Size = New System.Drawing.Size(357, 20)
      Me.NotesTextBox.TabIndex = 24
      Me.NotesTextBox.Tag = "Notes"
      '
      'LDSFicheTextBox
      '
      Me.LDSFicheTextBox.Location = New System.Drawing.Point(125, 277)
      Me.LDSFicheTextBox.Name = "LDSFicheTextBox"
      Me.LDSFicheTextBox.Size = New System.Drawing.Size(121, 20)
      Me.LDSFicheTextBox.TabIndex = 26
      Me.LDSFicheTextBox.Tag = "LDSFiche"
      '
      'LDSImageTextBox
      '
      Me.LDSImageTextBox.Location = New System.Drawing.Point(267, 277)
      Me.LDSImageTextBox.Name = "LDSImageTextBox"
      Me.LDSImageTextBox.Size = New System.Drawing.Size(121, 20)
      Me.LDSImageTextBox.TabIndex = 28
      Me.LDSImageTextBox.Tag = "LDSImage"
      '
      'ButtonOK
      '
      Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.ButtonOK.Location = New System.Drawing.Point(326, 349)
      Me.ButtonOK.Name = "ButtonOK"
      Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
      Me.ButtonOK.TabIndex = 29
      Me.ButtonOK.Text = "OK"
      Me.ButtonOK.UseVisualStyleBackColor = True
      '
      'ButtonCancel
      '
      Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.ButtonCancel.Location = New System.Drawing.Point(407, 349)
      Me.ButtonCancel.Name = "ButtonCancel"
      Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
      Me.ButtonCancel.TabIndex = 30
      Me.ButtonCancel.Text = "Cancel"
      Me.ButtonCancel.UseVisualStyleBackColor = True
      '
      'BaptismToolTip
      '
      Me.BaptismToolTip.ToolTipTitle = "WinFreeREG - Baptism Record"
      '
      'formBaptismRecord
      '
      Me.AcceptButton = Me.ButtonOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.ButtonCancel
      Me.ClientSize = New System.Drawing.Size(500, 384)
      Me.Controls.Add(Me.ButtonCancel)
      Me.Controls.Add(Me.ButtonOK)
      Me.Controls.Add(RegNoLabel)
      Me.Controls.Add(Me.RegNoTextBox)
      Me.Controls.Add(BirthDateLabel)
      Me.Controls.Add(Me.BirthDateTextBox)
      Me.Controls.Add(BaptismDateLabel)
      Me.Controls.Add(Me.BaptismDateTextBox)
      Me.Controls.Add(ForenamesLabel)
      Me.Controls.Add(Me.ForenamesTextBox)
      Me.Controls.Add(SexLabel)
      Me.Controls.Add(Me.SexComboBox)
      Me.Controls.Add(FathersNameLabel)
      Me.Controls.Add(Me.FathersNameTextBox)
      Me.Controls.Add(MothersNameLabel)
      Me.Controls.Add(Me.MothersNameTextBox)
      Me.Controls.Add(FathersSurnameLabel)
      Me.Controls.Add(Me.FathersSurnameTextBox)
      Me.Controls.Add(MothersSurnameLabel)
      Me.Controls.Add(Me.MothersSurnameTextBox)
      Me.Controls.Add(AbodeLabel)
      Me.Controls.Add(Me.AbodeTextBox)
      Me.Controls.Add(FathersOccupationLabel)
      Me.Controls.Add(Me.FathersOccupationTextBox)
      Me.Controls.Add(NotesLabel)
      Me.Controls.Add(Me.NotesTextBox)
      Me.Controls.Add(LDSFicheLabel)
      Me.Controls.Add(Me.LDSFicheTextBox)
      Me.Controls.Add(Me.LDSImageTextBox)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "formBaptismRecord"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "WinFreeREG - Baptism Record"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.BaptismSexBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
	Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
	Friend WithEvents RegNoTextBox As System.Windows.Forms.TextBox
	Friend WithEvents BirthDateTextBox As System.Windows.Forms.TextBox
	Friend WithEvents BaptismDateTextBox As System.Windows.Forms.TextBox
	Friend WithEvents ForenamesTextBox As System.Windows.Forms.TextBox
	Friend WithEvents SexComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents FathersNameTextBox As System.Windows.Forms.TextBox
	Friend WithEvents MothersNameTextBox As System.Windows.Forms.TextBox
	Friend WithEvents FathersSurnameTextBox As System.Windows.Forms.TextBox
	Friend WithEvents MothersSurnameTextBox As System.Windows.Forms.TextBox
	Friend WithEvents AbodeTextBox As System.Windows.Forms.TextBox
	Friend WithEvents FathersOccupationTextBox As System.Windows.Forms.TextBox
	Friend WithEvents NotesTextBox As System.Windows.Forms.TextBox
	Friend WithEvents LDSFicheTextBox As System.Windows.Forms.TextBox
	Friend WithEvents LDSImageTextBox As System.Windows.Forms.TextBox
	Friend WithEvents BaptismSexBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents ButtonCancel As System.Windows.Forms.Button
   Friend WithEvents ButtonOK As System.Windows.Forms.Button
   Friend WithEvents BaptismToolTip As System.Windows.Forms.ToolTip
End Class
