Imports System.Windows.Forms
Imports System.Text
Imports BrightIdeasSoftware

Public Class formUserTables

	Private m_LookupsFilename As String
	Public Property LookupsFilename() As String
		Get
			Return m_LookupsFilename
		End Get
		Set(ByVal value As String)
			m_LookupsFilename = value
		End Set
	End Property

   Private m_lookups As WinFreeReg.LookupTables
   Public Property LookupTables() As WinFreeReg.LookupTables
      Get
         Return m_lookups
      End Get
      Set(ByVal value As WinFreeReg.LookupTables)
         m_lookups = value
      End Set
   End Property

   Private Sub formUserTables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      bsBaptismSex.DataSource = m_lookups
      dlvBaptismSex.RebuildColumns()
      For Each model In dlvBaptismSex.Objects()
         If CType(CType(model, DataRowView).Row, LookupTables.BaptismSexRow).Type = "Application" Then
            dlvBaptismSex.DisableObject(model)
         End If
      Next

      bsBurialRelationship.DataSource = m_lookups
      dlvBurialRelationship.RebuildColumns()
      For Each model In dlvBurialRelationship.Objects()
         If CType(CType(model, DataRowView).Row, LookupTables.BurialRelationshipRow).Type = "Application" Then
            dlvBurialRelationship.DisableObject(model)
         End If
      Next

      bsGroomCondition.DataSource = m_lookups
      dlvGroomCondition.RebuildColumns()
      For Each model In dlvGroomCondition.Objects()
         If CType(CType(model, DataRowView).Row, LookupTables.GroomConditionRow).Type = "Application" Then
            dlvGroomCondition.DisableObject(model)
         End If
      Next

      bsBrideCOndition.DataSource = m_lookups
      dlvBrideCondition.RebuildColumns()
      For Each model In dlvBrideCondition.Objects()
         If CType(CType(model, DataRowView).Row, LookupTables.BrideConditionRow).Type = "Application" Then
            dlvBrideCondition.DisableObject(model)
         End If
      Next

      UserTablesTabControl.SelectTab(tabBaptismSex)
      BindingNavigator1.BindingSource = bsBaptismSex
      BindingNavigatorAddNewItem.Enabled = False
      BindingNavigatorDeleteItem.Enabled = False
      BindingNavigatorSaveChanges.Enabled = LookupTables.HasChanges()

   End Sub

   Private Sub UserTablesTabControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserTablesTabControl.SelectedIndexChanged
      Select Case UserTablesTabControl.SelectedTab.Name
         Case "tabBaptismSex"
            BindingNavigator1.BindingSource = bsBaptismSex
            BindingNavigatorAddNewItem.Enabled = False
            BindingNavigatorDeleteItem.Enabled = False

         Case "tabBurialRelationship"
            BindingNavigator1.BindingSource = bsBurialRelationship
            BindingNavigatorAddNewItem.Enabled = True
            BindingNavigatorDeleteItem.Enabled = True

         Case "tabGroomCondition"
            BindingNavigator1.BindingSource = bsGroomCondition
            BindingNavigatorAddNewItem.Enabled = True
            BindingNavigatorDeleteItem.Enabled = True

         Case "tabBrideCondition"
            BindingNavigator1.BindingSource = bsBrideCOndition
            BindingNavigatorAddNewItem.Enabled = True
            BindingNavigatorDeleteItem.Enabled = True

      End Select

      BindingNavigatorSaveChanges.Enabled = LookupTables.HasChanges()
   End Sub

   Private Sub BindingNavigatorDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
      Select Case UserTablesTabControl.SelectedTab.Name
         Case "tabBaptismSex"
            If dlvBaptismSex.SelectedObject() IsNot Nothing Then
               Dim objectToDelete = dlvBaptismSex.SelectedObject()
               If Not dlvBaptismSex.IsDisabled(objectToDelete) Then
                  If MessageBox.Show(My.Resources.msgConfirmDeleteObject, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                     m_lookups.BaptismSex.RemoveBaptismSexRow(CType(objectToDelete, DataRowView).Row)
                  End If
               End If
            End If

         Case "tabBurialRelationship"
            If dlvBurialRelationship.SelectedObject() IsNot Nothing Then
               Dim objectToDelete = dlvBurialRelationship.SelectedObject()
               If Not dlvBurialRelationship.IsDisabled(objectToDelete) Then
                  If MessageBox.Show(My.Resources.msgConfirmDeleteObject, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                     m_lookups.BurialRelationship.RemoveBurialRelationshipRow(CType(objectToDelete, DataRowView).Row)
                  End If
               End If
            End If

         Case "tabGroomCondition"
            If dlvGroomCondition.SelectedObject() IsNot Nothing Then
               Dim objectToDelete = dlvGroomCondition.SelectedObject()
               If Not dlvGroomCondition.IsDisabled(objectToDelete) Then
                  If MessageBox.Show(My.Resources.msgConfirmDeleteObject, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                     m_lookups.GroomCondition.RemoveGroomConditionRow(CType(objectToDelete, DataRowView).Row)
                  End If
               End If
            End If

         Case "tabBrideCondition"
            If dlvBrideCondition.SelectedObject() IsNot Nothing Then
               Dim objectToDelete = dlvBrideCondition.SelectedObject()
               If Not dlvBrideCondition.IsDisabled(objectToDelete) Then
                  If MessageBox.Show(My.Resources.msgConfirmDeleteObject, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                     m_lookups.BrideCondition.RemoveBrideConditionRow(CType(objectToDelete, DataRowView).Row)
                  End If
               End If
            End If

      End Select
      BindingNavigatorSaveChanges.Enabled = LookupTables.HasChanges()

   End Sub

   Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
      Select Case UserTablesTabControl.SelectedTab.Name
         Case "tabBaptismSex"
            Dim dt As LookupTables.BaptismSexDataTable = m_lookups.BaptismSex
            Dim row As LookupTables.BaptismSexRow = dt.NewRow()
            row.Type = "User"
            row.Code = "<New>"
            row.Description = ""
            Try
               dt.AddBaptismSexRow(row)

            Catch ex As ConstraintException
               MessageBox.Show(My.Resources.msgNewRecordNotUnique, "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Dim model = dt.DefaultView.Item(dt.Rows.Count - 1)
            dlvBaptismSex.EnsureModelVisible(model)
            dlvBaptismSex.SelectObject(model, True)
            dlvBaptismSex.Select()
            BindingNavigatorSaveChanges.Enabled = LookupTables.HasChanges()

         Case "tabBurialRelationship"
            Dim dt As LookupTables.BurialRelationshipDataTable = m_lookups.BurialRelationship
            Dim row As LookupTables.BurialRelationshipRow = dt.NewRow()
            row.Type = "User"
            row.FileValue = "<New>"
            row.DisplayValue = "<New>"
            Try
               dt.AddBurialRelationshipRow(row)

            Catch ex As ConstraintException
               MessageBox.Show(My.Resources.msgNewRecordNotUnique, "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Dim model = dt.DefaultView.Item(dt.Rows.Count - 1)
            dlvBurialRelationship.EnsureModelVisible(model)
            dlvBurialRelationship.SelectObject(model, True)
            dlvBurialRelationship.Select()
            BindingNavigatorSaveChanges.Enabled = LookupTables.HasChanges()

         Case "tabGroomCondition"
            Dim dt As LookupTables.GroomConditionDataTable = m_lookups.GroomCondition
            Dim row As LookupTables.GroomConditionRow = dt.NewRow()
            row.Type = "User"
            row.FileValue = "<New>"
            row.DisplayValue = "<New>"
            Try
               dt.AddGroomConditionRow(row)

            Catch ex As ConstraintException
               MessageBox.Show(My.Resources.msgNewRecordNotUnique, "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Dim model = dt.DefaultView.Item(dt.Rows.Count - 1)
            dlvGroomCondition.EnsureModelVisible(model)
            dlvGroomCondition.SelectObject(model, True)
            dlvGroomCondition.Select()
            BindingNavigatorSaveChanges.Enabled = LookupTables.HasChanges()

         Case "tabBrideCondition"
            Dim dt As LookupTables.BrideConditionDataTable = m_lookups.BrideCondition
            Dim row As LookupTables.BrideConditionRow = dt.NewRow()
            row.Type = "User"
            row.FileValue = "<New>"
            row.DisplayValue = "<New>"
            Try
               dt.AddBrideConditionRow(row)

            Catch ex As ConstraintException
               MessageBox.Show(My.Resources.msgNewRecordNotUnique, "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Dim model = dt.DefaultView.Item(dt.Rows.Count - 1)
            dlvBrideCondition.EnsureModelVisible(model)
            dlvBrideCondition.SelectObject(model, True)
            dlvBrideCondition.Select()
            BindingNavigatorSaveChanges.Enabled = LookupTables.HasChanges()

      End Select

   End Sub

   Private Sub formUserTables_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
      If LookupTables.HasErrors Then
         Dim errors As New List(Of classUncorrectedErrors)

         For Each dt As DataTable In LookupTables.Tables
            If dt.HasErrors() Then
               For Each row As DataRow In dt.GetErrors()
                  For Each col As DataColumn In row.GetColumnsInError()
                     Dim err As New classUncorrectedErrors()
                     err.TableName = dt.TableName
                     err.Row = row
                     err.ColumnName = row.GetColumnsInError()
                     err.ColummnError = row.GetColumnError(col.ColumnName)
                     errors.Add(err)
                  Next
               Next
            End If
         Next

         Using dlg As New formTablesErrors() With {.Lookups = LookupTables}
            Generator.GenerateColumns(dlg.olvErrors, GetType(classUncorrectedErrors), True)
            dlg.olvErrors.SetObjects(errors)
            Try
               dlg.ShowDialog()

            Catch ex As Exception

            End Try
         End Using

         e.Cancel = True
         Return
      End If

      If LookupTables.HasChanges Then
         Dim errString As New StringBuilder("unsaved changes in User Tables" + vbCrLf)

         Dim changed As WinFreeReg.LookupTables = LookupTables.GetChanges()
         For Each dt As DataTable In changed.Tables
            Dim changes As DataTable = dt.GetChanges()
            If changes IsNot Nothing Then
               errString.AppendLine(String.Format("  {0}", dt.TableName))
               For Each row As DataRow In changes.Rows
                  errString.AppendLine(String.Format("    {0}-{1}", row(1), row(2)))
               Next
            End If
         Next

         MessageBox.Show(errString.ToString(), "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
      End If
   End Sub

	Private Sub BindingNavigatorSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorSaveChanges.Click
		LookupTables.AcceptChanges()
		LookupTables.WriteXml(m_LookupsFilename, XmlWriteMode.WriteSchema)
		BindingNavigatorSaveChanges.Enabled = LookupTables.HasChanges()
	End Sub

End Class