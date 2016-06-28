<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formBurialRecord
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
      Dim BurialDateLabel As System.Windows.Forms.Label
      Dim ForenamesLabel As System.Windows.Forms.Label
      Dim RelationshipLabel As System.Windows.Forms.Label
      Dim MaleForenamesLabel As System.Windows.Forms.Label
      Dim FemaleForenamesLabel As System.Windows.Forms.Label
      Dim RelativeSurnameLabel As System.Windows.Forms.Label
      Dim SurnameLabel As System.Windows.Forms.Label
      Dim AgeLabel As System.Windows.Forms.Label
      Dim AbodeLabel As System.Windows.Forms.Label
      Dim NotesLabel As System.Windows.Forms.Label
      Dim LDSFicheLabel As System.Windows.Forms.Label
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.RegNoTextBox = New System.Windows.Forms.TextBox()
      Me.BurialDateTextBox = New System.Windows.Forms.TextBox()
      Me.ForenamesTextBox = New System.Windows.Forms.TextBox()
      Me.RelationshipComboBox = New System.Windows.Forms.ComboBox()
      Me.BurialRelationshipBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.MaleForenamesTextBox = New System.Windows.Forms.TextBox()
      Me.FemaleForenamesTextBox = New System.Windows.Forms.TextBox()
      Me.RelativeSurnameTextBox = New System.Windows.Forms.TextBox()
      Me.SurnameTextBox = New System.Windows.Forms.TextBox()
      Me.AgeTextBox = New System.Windows.Forms.TextBox()
      Me.AbodeTextBox = New System.Windows.Forms.TextBox()
      Me.NotesTextBox = New System.Windows.Forms.TextBox()
      Me.LDSFicheTextBox = New System.Windows.Forms.TextBox()
      Me.LDSImageTextBox = New System.Windows.Forms.TextBox()
      Me.ButtonOK = New System.Windows.Forms.Button()
      Me.ButtonCancel = New System.Windows.Forms.Button()
      Me.BurialToolTip = New System.Windows.Forms.ToolTip(Me.components)
      RegNoLabel = New System.Windows.Forms.Label()
      BurialDateLabel = New System.Windows.Forms.Label()
      ForenamesLabel = New System.Windows.Forms.Label()
      RelationshipLabel = New System.Windows.Forms.Label()
      MaleForenamesLabel = New System.Windows.Forms.Label()
      FemaleForenamesLabel = New System.Windows.Forms.Label()
      RelativeSurnameLabel = New System.Windows.Forms.Label()
      SurnameLabel = New System.Windows.Forms.Label()
      AgeLabel = New System.Windows.Forms.Label()
      AbodeLabel = New System.Windows.Forms.Label()
      NotesLabel = New System.Windows.Forms.Label()
      LDSFicheLabel = New System.Windows.Forms.Label()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.BurialRelationshipBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'RegNoLabel
      '
      RegNoLabel.AutoSize = True
      RegNoLabel.Location = New System.Drawing.Point(19, 14)
      RegNoLabel.Name = "RegNoLabel"
      RegNoLabel.Size = New System.Drawing.Size(47, 13)
      RegNoLabel.TabIndex = 1
      RegNoLabel.Text = "Reg No:"
      '
      'BurialDateLabel
      '
      BurialDateLabel.AutoSize = True
      BurialDateLabel.Location = New System.Drawing.Point(19, 40)
      BurialDateLabel.Name = "BurialDateLabel"
      BurialDateLabel.Size = New System.Drawing.Size(62, 13)
      BurialDateLabel.TabIndex = 3
      BurialDateLabel.Text = "Burial Date:"
      '
      'ForenamesLabel
      '
      ForenamesLabel.AutoSize = True
      ForenamesLabel.Location = New System.Drawing.Point(19, 66)
      ForenamesLabel.Name = "ForenamesLabel"
      ForenamesLabel.Size = New System.Drawing.Size(62, 13)
      ForenamesLabel.TabIndex = 5
      ForenamesLabel.Text = "Forenames:"
      '
      'RelationshipLabel
      '
      RelationshipLabel.AutoSize = True
      RelationshipLabel.Location = New System.Drawing.Point(19, 92)
      RelationshipLabel.Name = "RelationshipLabel"
      RelationshipLabel.Size = New System.Drawing.Size(68, 13)
      RelationshipLabel.TabIndex = 7
      RelationshipLabel.Text = "Relationship:"
      '
      'MaleForenamesLabel
      '
      MaleForenamesLabel.AutoSize = True
      MaleForenamesLabel.Location = New System.Drawing.Point(19, 119)
      MaleForenamesLabel.Name = "MaleForenamesLabel"
      MaleForenamesLabel.Size = New System.Drawing.Size(88, 13)
      MaleForenamesLabel.TabIndex = 9
      MaleForenamesLabel.Text = "Male Forenames:"
      '
      'FemaleForenamesLabel
      '
      FemaleForenamesLabel.AutoSize = True
      FemaleForenamesLabel.Location = New System.Drawing.Point(19, 145)
      FemaleForenamesLabel.Name = "FemaleForenamesLabel"
      FemaleForenamesLabel.Size = New System.Drawing.Size(99, 13)
      FemaleForenamesLabel.TabIndex = 11
      FemaleForenamesLabel.Text = "Female Forenames:"
      '
      'RelativeSurnameLabel
      '
      RelativeSurnameLabel.AutoSize = True
      RelativeSurnameLabel.Location = New System.Drawing.Point(19, 171)
      RelativeSurnameLabel.Name = "RelativeSurnameLabel"
      RelativeSurnameLabel.Size = New System.Drawing.Size(94, 13)
      RelativeSurnameLabel.TabIndex = 13
      RelativeSurnameLabel.Text = "Relative Surname:"
      '
      'SurnameLabel
      '
      SurnameLabel.AutoSize = True
      SurnameLabel.Location = New System.Drawing.Point(255, 66)
      SurnameLabel.Name = "SurnameLabel"
      SurnameLabel.Size = New System.Drawing.Size(52, 13)
      SurnameLabel.TabIndex = 15
      SurnameLabel.Text = "Surname:"
      '
      'AgeLabel
      '
      AgeLabel.AutoSize = True
      AgeLabel.Location = New System.Drawing.Point(259, 92)
      AgeLabel.Name = "AgeLabel"
      AgeLabel.Size = New System.Drawing.Size(29, 13)
      AgeLabel.TabIndex = 17
      AgeLabel.Text = "Age:"
      '
      'AbodeLabel
      '
      AbodeLabel.AutoSize = True
      AbodeLabel.Location = New System.Drawing.Point(19, 197)
      AbodeLabel.Name = "AbodeLabel"
      AbodeLabel.Size = New System.Drawing.Size(41, 13)
      AbodeLabel.TabIndex = 19
      AbodeLabel.Text = "Abode:"
      '
      'NotesLabel
      '
      NotesLabel.AutoSize = True
      NotesLabel.Location = New System.Drawing.Point(19, 223)
      NotesLabel.Name = "NotesLabel"
      NotesLabel.Size = New System.Drawing.Size(38, 13)
      NotesLabel.TabIndex = 21
      NotesLabel.Text = "Notes:"
      '
      'LDSFicheLabel
      '
      LDSFicheLabel.AutoSize = True
      LDSFicheLabel.Location = New System.Drawing.Point(19, 249)
      LDSFicheLabel.Name = "LDSFicheLabel"
      LDSFicheLabel.Size = New System.Drawing.Size(73, 13)
      LDSFicheLabel.TabIndex = 23
      LDSFicheLabel.Text = "Fiche:/Image:"
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'RegNoTextBox
      '
      Me.RegNoTextBox.Location = New System.Drawing.Point(124, 11)
      Me.RegNoTextBox.Name = "RegNoTextBox"
      Me.RegNoTextBox.Size = New System.Drawing.Size(121, 20)
      Me.RegNoTextBox.TabIndex = 2
      Me.RegNoTextBox.Tag = "RegNo"
      '
      'BurialDateTextBox
      '
      Me.BurialDateTextBox.Location = New System.Drawing.Point(124, 37)
      Me.BurialDateTextBox.Name = "BurialDateTextBox"
      Me.BurialDateTextBox.Size = New System.Drawing.Size(121, 20)
      Me.BurialDateTextBox.TabIndex = 4
      Me.BurialDateTextBox.Tag = "BurialDate"
      '
      'ForenamesTextBox
      '
      Me.ForenamesTextBox.Location = New System.Drawing.Point(124, 63)
      Me.ForenamesTextBox.Name = "ForenamesTextBox"
      Me.ForenamesTextBox.Size = New System.Drawing.Size(121, 20)
      Me.ForenamesTextBox.TabIndex = 6
      Me.ForenamesTextBox.Tag = "Forenames"
      '
      'RelationshipComboBox
      '
      Me.RelationshipComboBox.DataSource = Me.BurialRelationshipBindingSource
      Me.RelationshipComboBox.DisplayMember = "DisplayValue"
      Me.RelationshipComboBox.FormattingEnabled = True
      Me.RelationshipComboBox.Location = New System.Drawing.Point(124, 89)
      Me.RelationshipComboBox.Name = "RelationshipComboBox"
      Me.RelationshipComboBox.Size = New System.Drawing.Size(121, 21)
      Me.RelationshipComboBox.TabIndex = 8
      Me.RelationshipComboBox.Tag = "Relationship"
      Me.RelationshipComboBox.ValueMember = "FileValue"
      '
      'BurialRelationshipBindingSource
      '
      Me.BurialRelationshipBindingSource.DataMember = "BurialRelationship"
      Me.BurialRelationshipBindingSource.DataSource = GetType(WinFreeReg.LookupTables)
      '
      'MaleForenamesTextBox
      '
      Me.MaleForenamesTextBox.Location = New System.Drawing.Point(124, 116)
      Me.MaleForenamesTextBox.Name = "MaleForenamesTextBox"
      Me.MaleForenamesTextBox.Size = New System.Drawing.Size(121, 20)
      Me.MaleForenamesTextBox.TabIndex = 10
      Me.MaleForenamesTextBox.Tag = "MalesForenames"
      '
      'FemaleForenamesTextBox
      '
      Me.FemaleForenamesTextBox.Location = New System.Drawing.Point(124, 142)
      Me.FemaleForenamesTextBox.Name = "FemaleForenamesTextBox"
      Me.FemaleForenamesTextBox.Size = New System.Drawing.Size(121, 20)
      Me.FemaleForenamesTextBox.TabIndex = 12
      Me.FemaleForenamesTextBox.Tag = "FemaleForenames"
      '
      'RelativeSurnameTextBox
      '
      Me.RelativeSurnameTextBox.Location = New System.Drawing.Point(124, 168)
      Me.RelativeSurnameTextBox.Name = "RelativeSurnameTextBox"
      Me.RelativeSurnameTextBox.Size = New System.Drawing.Size(121, 20)
      Me.RelativeSurnameTextBox.TabIndex = 14
      Me.RelativeSurnameTextBox.Tag = "RelativeSurname"
      '
      'SurnameTextBox
      '
      Me.SurnameTextBox.Location = New System.Drawing.Point(313, 63)
      Me.SurnameTextBox.Name = "SurnameTextBox"
      Me.SurnameTextBox.Size = New System.Drawing.Size(121, 20)
      Me.SurnameTextBox.TabIndex = 16
      Me.SurnameTextBox.Tag = "Surname"
      '
      'AgeTextBox
      '
      Me.AgeTextBox.Location = New System.Drawing.Point(313, 89)
      Me.AgeTextBox.Name = "AgeTextBox"
      Me.AgeTextBox.Size = New System.Drawing.Size(121, 20)
      Me.AgeTextBox.TabIndex = 18
      Me.AgeTextBox.Tag = "Age"
      '
      'AbodeTextBox
      '
      Me.AbodeTextBox.Location = New System.Drawing.Point(124, 194)
      Me.AbodeTextBox.Name = "AbodeTextBox"
      Me.AbodeTextBox.Size = New System.Drawing.Size(121, 20)
      Me.AbodeTextBox.TabIndex = 20
      Me.AbodeTextBox.Tag = "Abode"
      '
      'NotesTextBox
      '
      Me.NotesTextBox.Location = New System.Drawing.Point(124, 220)
      Me.NotesTextBox.Name = "NotesTextBox"
      Me.NotesTextBox.Size = New System.Drawing.Size(310, 20)
      Me.NotesTextBox.TabIndex = 22
      Me.NotesTextBox.Tag = "Notes"
      '
      'LDSFicheTextBox
      '
      Me.LDSFicheTextBox.Location = New System.Drawing.Point(124, 246)
      Me.LDSFicheTextBox.Name = "LDSFicheTextBox"
      Me.LDSFicheTextBox.Size = New System.Drawing.Size(121, 20)
      Me.LDSFicheTextBox.TabIndex = 24
      Me.LDSFicheTextBox.Tag = "LDSFiche"
      '
      'LDSImageTextBox
      '
      Me.LDSImageTextBox.Location = New System.Drawing.Point(267, 246)
      Me.LDSImageTextBox.Name = "LDSImageTextBox"
      Me.LDSImageTextBox.Size = New System.Drawing.Size(121, 20)
      Me.LDSImageTextBox.TabIndex = 26
      Me.LDSImageTextBox.Tag = "LDSImage"
      '
      'ButtonOK
      '
      Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.ButtonOK.Location = New System.Drawing.Point(295, 304)
      Me.ButtonOK.Name = "ButtonOK"
      Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
      Me.ButtonOK.TabIndex = 27
      Me.ButtonOK.Text = "OK"
      Me.ButtonOK.UseVisualStyleBackColor = True
      '
      'ButtonCancel
      '
      Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.ButtonCancel.Location = New System.Drawing.Point(376, 304)
      Me.ButtonCancel.Name = "ButtonCancel"
      Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
      Me.ButtonCancel.TabIndex = 28
      Me.ButtonCancel.Text = "Cancel"
      Me.ButtonCancel.UseVisualStyleBackColor = True
      '
      'formBurialRecord
      '
      Me.AcceptButton = Me.ButtonOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.ButtonCancel
      Me.ClientSize = New System.Drawing.Size(463, 339)
      Me.Controls.Add(Me.ButtonCancel)
      Me.Controls.Add(Me.ButtonOK)
      Me.Controls.Add(RegNoLabel)
      Me.Controls.Add(Me.RegNoTextBox)
      Me.Controls.Add(BurialDateLabel)
      Me.Controls.Add(Me.BurialDateTextBox)
      Me.Controls.Add(ForenamesLabel)
      Me.Controls.Add(Me.ForenamesTextBox)
      Me.Controls.Add(RelationshipLabel)
      Me.Controls.Add(Me.RelationshipComboBox)
      Me.Controls.Add(MaleForenamesLabel)
      Me.Controls.Add(Me.MaleForenamesTextBox)
      Me.Controls.Add(FemaleForenamesLabel)
      Me.Controls.Add(Me.FemaleForenamesTextBox)
      Me.Controls.Add(RelativeSurnameLabel)
      Me.Controls.Add(Me.RelativeSurnameTextBox)
      Me.Controls.Add(SurnameLabel)
      Me.Controls.Add(Me.SurnameTextBox)
      Me.Controls.Add(AgeLabel)
      Me.Controls.Add(Me.AgeTextBox)
      Me.Controls.Add(AbodeLabel)
      Me.Controls.Add(Me.AbodeTextBox)
      Me.Controls.Add(NotesLabel)
      Me.Controls.Add(Me.NotesTextBox)
      Me.Controls.Add(LDSFicheLabel)
      Me.Controls.Add(Me.LDSFicheTextBox)
      Me.Controls.Add(Me.LDSImageTextBox)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "formBurialRecord"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Burial Record"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.BurialRelationshipBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
	Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
	Friend WithEvents RegNoTextBox As System.Windows.Forms.TextBox
	Friend WithEvents BurialDateTextBox As System.Windows.Forms.TextBox
	Friend WithEvents ForenamesTextBox As System.Windows.Forms.TextBox
	Friend WithEvents RelationshipComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents MaleForenamesTextBox As System.Windows.Forms.TextBox
	Friend WithEvents FemaleForenamesTextBox As System.Windows.Forms.TextBox
	Friend WithEvents RelativeSurnameTextBox As System.Windows.Forms.TextBox
	Friend WithEvents SurnameTextBox As System.Windows.Forms.TextBox
	Friend WithEvents AgeTextBox As System.Windows.Forms.TextBox
	Friend WithEvents AbodeTextBox As System.Windows.Forms.TextBox
	Friend WithEvents NotesTextBox As System.Windows.Forms.TextBox
	Friend WithEvents LDSFicheTextBox As System.Windows.Forms.TextBox
	Friend WithEvents LDSImageTextBox As System.Windows.Forms.TextBox
	Friend WithEvents BurialRelationshipBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents ButtonCancel As System.Windows.Forms.Button
   Friend WithEvents ButtonOK As System.Windows.Forms.Button
   Friend WithEvents BurialToolTip As System.Windows.Forms.ToolTip
End Class
