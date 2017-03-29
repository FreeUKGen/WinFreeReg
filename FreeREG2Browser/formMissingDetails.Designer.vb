<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formMissingDetails
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
		Me.labelCounty = New System.Windows.Forms.Label()
		Me.labelPlace = New System.Windows.Forms.Label()
		Me.labelChurch = New System.Windows.Forms.Label()
		Me.FreeregTables = New WinFreeReg.FreeregTables()
		Me.countiesComboBox = New System.Windows.Forms.ComboBox()
		Me.CountiesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.PlacesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.ChurchesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
		Me.placesComboBox = New System.Windows.Forms.ComboBox()
		Me.churchesComboBox = New System.Windows.Forms.ComboBox()
		Me.textCounty = New System.Windows.Forms.Label()
		Me.textPlace = New System.Windows.Forms.Label()
		Me.textChurch = New System.Windows.Forms.Label()
		Me.labelMessage = New System.Windows.Forms.Label()
		Me.btnOK = New System.Windows.Forms.Button()
		Me.btnCancel = New System.Windows.Forms.Button()
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
		CType(Me.FreeregTables, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.CountiesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.PlacesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.ChurchesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TableLayoutPanel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'labelCounty
		'
		Me.labelCounty.AutoSize = True
		Me.labelCounty.Location = New System.Drawing.Point(52, 52)
		Me.labelCounty.Name = "labelCounty"
		Me.labelCounty.Size = New System.Drawing.Size(40, 13)
		Me.labelCounty.TabIndex = 1
		Me.labelCounty.Text = "County"
		'
		'labelPlace
		'
		Me.labelPlace.AutoSize = True
		Me.labelPlace.Location = New System.Drawing.Point(58, 79)
		Me.labelPlace.Name = "labelPlace"
		Me.labelPlace.Size = New System.Drawing.Size(34, 13)
		Me.labelPlace.TabIndex = 2
		Me.labelPlace.Text = "Place"
		'
		'labelChurch
		'
		Me.labelChurch.AutoSize = True
		Me.labelChurch.Location = New System.Drawing.Point(51, 106)
		Me.labelChurch.Name = "labelChurch"
		Me.labelChurch.Size = New System.Drawing.Size(41, 13)
		Me.labelChurch.TabIndex = 3
		Me.labelChurch.Text = "Church"
		'
		'FreeregTables
		'
		Me.FreeregTables.DataSetName = "FreeregTables"
		Me.FreeregTables.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
		'
		'countiesComboBox
		'
		Me.countiesComboBox.DataSource = Me.CountiesBindingSource
		Me.countiesComboBox.DisplayMember = "ChapmanCode"
		Me.countiesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.countiesComboBox.FormattingEnabled = True
		Me.countiesComboBox.Location = New System.Drawing.Point(342, 49)
		Me.countiesComboBox.Name = "countiesComboBox"
		Me.countiesComboBox.Size = New System.Drawing.Size(121, 21)
		Me.countiesComboBox.TabIndex = 5
		Me.countiesComboBox.ValueMember = "ChapmanCode"
		'
		'CountiesBindingSource
		'
		Me.CountiesBindingSource.DataMember = "Counties"
		Me.CountiesBindingSource.DataSource = Me.FreeregTables
		'
		'PlacesBindingSource
		'
		Me.PlacesBindingSource.DataMember = "Places"
		Me.PlacesBindingSource.DataSource = Me.FreeregTables
		'
		'ChurchesBindingSource
		'
		Me.ChurchesBindingSource.DataMember = "Churches"
		Me.ChurchesBindingSource.DataSource = Me.FreeregTables
		'
		'placesComboBox
		'
		Me.placesComboBox.DataSource = Me.PlacesBindingSource
		Me.placesComboBox.DisplayMember = "PlaceName"
		Me.placesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.placesComboBox.FormattingEnabled = True
		Me.placesComboBox.Location = New System.Drawing.Point(342, 76)
		Me.placesComboBox.Name = "placesComboBox"
		Me.placesComboBox.Size = New System.Drawing.Size(121, 21)
		Me.placesComboBox.TabIndex = 6
		Me.placesComboBox.ValueMember = "PlaceName"
		'
		'churchesComboBox
		'
		Me.churchesComboBox.DataSource = Me.ChurchesBindingSource
		Me.churchesComboBox.DisplayMember = "ChurchName"
		Me.churchesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.churchesComboBox.FormattingEnabled = True
		Me.churchesComboBox.Location = New System.Drawing.Point(342, 103)
		Me.churchesComboBox.Name = "churchesComboBox"
		Me.churchesComboBox.Size = New System.Drawing.Size(121, 21)
		Me.churchesComboBox.TabIndex = 7
		Me.churchesComboBox.ValueMember = "ChurchName"
		'
		'textCounty
		'
		Me.textCounty.AutoSize = True
		Me.textCounty.Location = New System.Drawing.Point(98, 52)
		Me.textCounty.Name = "textCounty"
		Me.textCounty.Size = New System.Drawing.Size(39, 13)
		Me.textCounty.TabIndex = 8
		Me.textCounty.Text = "Label1"
		'
		'textPlace
		'
		Me.textPlace.AutoSize = True
		Me.textPlace.Location = New System.Drawing.Point(98, 79)
		Me.textPlace.Name = "textPlace"
		Me.textPlace.Size = New System.Drawing.Size(39, 13)
		Me.textPlace.TabIndex = 9
		Me.textPlace.Text = "Label2"
		'
		'textChurch
		'
		Me.textChurch.AutoSize = True
		Me.textChurch.Location = New System.Drawing.Point(98, 106)
		Me.textChurch.Name = "textChurch"
		Me.textChurch.Size = New System.Drawing.Size(39, 13)
		Me.textChurch.TabIndex = 10
		Me.textChurch.Text = "Label3"
		'
		'labelMessage
		'
		Me.labelMessage.AutoSize = True
		Me.labelMessage.Location = New System.Drawing.Point(23, 21)
		Me.labelMessage.Name = "labelMessage"
		Me.labelMessage.Size = New System.Drawing.Size(39, 13)
		Me.labelMessage.TabIndex = 11
		Me.labelMessage.Text = "Label1"
		'
		'btnOK
		'
		Me.btnOK.AutoSize = True
		Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOK.Location = New System.Drawing.Point(3, 3)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(75, 23)
		Me.btnOK.TabIndex = 12
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = True
		'
		'btnCancel
		'
		Me.btnCancel.AutoSize = True
		Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancel.Location = New System.Drawing.Point(84, 3)
		Me.btnCancel.Name = "btnCancel"
		Me.btnCancel.Size = New System.Drawing.Size(75, 23)
		Me.btnCancel.TabIndex = 13
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.UseVisualStyleBackColor = True
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.AutoSize = True
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.btnOK, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 1, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(421, 248)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(162, 29)
		Me.TableLayoutPanel1.TabIndex = 14
		'
		'formMissingDetails
		'
		Me.AcceptButton = Me.btnOK
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.btnCancel
		Me.ClientSize = New System.Drawing.Size(595, 289)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.Controls.Add(Me.labelMessage)
		Me.Controls.Add(Me.textChurch)
		Me.Controls.Add(Me.textPlace)
		Me.Controls.Add(Me.textCounty)
		Me.Controls.Add(Me.churchesComboBox)
		Me.Controls.Add(Me.placesComboBox)
		Me.Controls.Add(Me.countiesComboBox)
		Me.Controls.Add(Me.labelChurch)
		Me.Controls.Add(Me.labelPlace)
		Me.Controls.Add(Me.labelCounty)
		Me.Name = "formMissingDetails"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Missing Header Details"
		CType(Me.FreeregTables, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.CountiesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.PlacesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.ChurchesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.TableLayoutPanel1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents labelCounty As System.Windows.Forms.Label
	Friend WithEvents labelPlace As System.Windows.Forms.Label
	Friend WithEvents labelChurch As System.Windows.Forms.Label
	Friend WithEvents FreeregTables As WinFreeReg.FreeregTables
	Friend WithEvents countiesComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents CountiesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents PlacesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents ChurchesBindingSource As System.Windows.Forms.BindingSource
	Friend WithEvents placesComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents churchesComboBox As System.Windows.Forms.ComboBox
	Friend WithEvents textCounty As System.Windows.Forms.Label
	Friend WithEvents textPlace As System.Windows.Forms.Label
	Friend WithEvents textChurch As System.Windows.Forms.Label
	Friend WithEvents labelMessage As System.Windows.Forms.Label
	Friend WithEvents btnOK As System.Windows.Forms.Button
	Friend WithEvents btnCancel As System.Windows.Forms.Button
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
End Class
