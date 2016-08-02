Imports System.Windows.Forms
Imports System.Text
Imports BrightIdeasSoftware
Imports System.IO

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

   Private formHelp As formGeneralHelp = Nothing
   Public Sub New(helpForm As formGeneralHelp)
      InitializeComponent()

      formHelp = helpForm
   End Sub

   Private boolShowBaptismSex As Boolean = False
   Private boolShowBurialRelationships As Boolean = False
   Private boolShowGroomConditions As Boolean = False
   Private boolShowBrideConditions As Boolean = False

   Public Sub ShowAll()
      ShowTable(TableType.BaptismSex Or TableType.BrideConditions Or TableType.BurialRelationships Or TableType.GroomConditions)
   End Sub

   Public Sub ShowTable(ByVal type As TableType)
      If (type And TableType.BaptismSex) = TableType.BaptismSex Then boolShowBaptismSex = True
      If (type And TableType.BrideConditions) = TableType.BrideConditions Then boolShowBrideConditions = True
      If (type And TableType.BurialRelationships) = TableType.BurialRelationships Then boolShowBurialRelationships = True
      If (type And TableType.GroomConditions) = TableType.GroomConditions Then boolShowGroomConditions = True
   End Sub

   Enum TableType
      BaptismSex = 1
      BurialRelationships = 2
      GroomConditions = 4
      BrideConditions = 8
   End Enum

   Private Sub formUserTables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim styleDisabled As New SimpleItemStyle() With {.ForeColor = Drawing.Color.DarkRed, .BackColor = Drawing.Color.Cornsilk}

      bsBaptismSex.DataSource = m_lookups
      dlvBaptismSex.RebuildColumns()
      dlvBaptismSex.DisabledItemStyle = styleDisabled
      For Each model In dlvBaptismSex.Objects()
         If CType(CType(model, DataRowView).Row, LookupTables.BaptismSexRow).Type = "Application" Then
            dlvBaptismSex.DisableObject(model)
         End If
      Next

      bsBurialRelationship.DataSource = m_lookups
      dlvBurialRelationship.RebuildColumns()
      dlvBurialRelationship.DisabledItemStyle = styleDisabled
      For Each model In dlvBurialRelationship.Objects()
         If CType(CType(model, DataRowView).Row, LookupTables.BurialRelationshipRow).Type = "Application" Then
            dlvBurialRelationship.DisableObject(model)
         End If
      Next

      bsGroomCondition.DataSource = m_lookups
      dlvGroomCondition.RebuildColumns()
      dlvGroomCondition.DisabledItemStyle = styleDisabled
      For Each model In dlvGroomCondition.Objects()
         If CType(CType(model, DataRowView).Row, LookupTables.GroomConditionRow).Type = "Application" Then
            dlvGroomCondition.DisableObject(model)
         End If
      Next

      bsBrideCOndition.DataSource = m_lookups
      dlvBrideCondition.RebuildColumns()
      dlvBrideCondition.DisabledItemStyle = styleDisabled
      For Each model In dlvBrideCondition.Objects()
         If CType(CType(model, DataRowView).Row, LookupTables.BrideConditionRow).Type = "Application" Then
            dlvBrideCondition.DisableObject(model)
         End If
      Next

      If Not boolShowBaptismSex Then UserTablesTabControl.TabPages.Remove(tabBaptismSex)
      If Not boolShowBrideConditions Then UserTablesTabControl.TabPages.Remove(tabBrideCondition)
      If Not boolShowBurialRelationships Then UserTablesTabControl.TabPages.Remove(tabBurialRelationship)
      If Not boolShowGroomConditions Then UserTablesTabControl.TabPages.Remove(tabGroomCondition)

      If UserTablesTabControl.TabPages.Contains(tabBaptismSex) Then
         UserTablesTabControl.SelectTab(tabBaptismSex)
      ElseIf UserTablesTabControl.TabPages.Contains(tabBurialRelationship) Then
         UserTablesTabControl.SelectTab(tabBurialRelationship)
      ElseIf UserTablesTabControl.TabPages.Contains(tabGroomCondition) Then
         UserTablesTabControl.SelectTab(tabGroomCondition)
      Else
         UserTablesTabControl.SelectTab(tabBrideCondition)
      End If
      UserTablesBindingNavigator.BindingSource = bsBaptismSex
      BindingNavigatorAddNewItem.Enabled = False
      BindingNavigatorDeleteItem.Enabled = False
      BindingNavigatorSaveChanges.Enabled = LookupTables.HasChanges()

      Dim AppDataLocalFolder = String.Format("{0}\{1}", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.ProductName)
      Dim ToolTipsFile As String = Path.Combine(AppDataLocalFolder, "ToolTips.xml")
      Dim MyToolTips = New CustomToolTip(ToolTipsFile, Me)

   End Sub

   Private Sub UserTablesTabControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserTablesTabControl.SelectedIndexChanged
      Select Case UserTablesTabControl.SelectedTab.Name
         Case "tabBaptismSex"
            UserTablesBindingNavigator.BindingSource = bsBaptismSex
            BindingNavigatorAddNewItem.Enabled = False
            BindingNavigatorDeleteItem.Enabled = False

         Case "tabBurialRelationship"
            UserTablesBindingNavigator.BindingSource = bsBurialRelationship
            BindingNavigatorAddNewItem.Enabled = True
            BindingNavigatorDeleteItem.Enabled = True

         Case "tabGroomCondition"
            UserTablesBindingNavigator.BindingSource = bsGroomCondition
            BindingNavigatorAddNewItem.Enabled = True
            BindingNavigatorDeleteItem.Enabled = True

         Case "tabBrideCondition"
            UserTablesBindingNavigator.BindingSource = bsBrideCOndition
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
                     BindingNavigatorSaveChanges.Enabled = True
                  End If
               End If
            End If

         Case "tabBurialRelationship"
            If dlvBurialRelationship.SelectedObject() IsNot Nothing Then
               Dim objectToDelete = dlvBurialRelationship.SelectedObject()
               If Not dlvBurialRelationship.IsDisabled(objectToDelete) Then
                  If MessageBox.Show(My.Resources.msgConfirmDeleteObject, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                     m_lookups.BurialRelationship.RemoveBurialRelationshipRow(CType(objectToDelete, DataRowView).Row)
                     BindingNavigatorSaveChanges.Enabled = True
                  End If
               End If
            End If

         Case "tabGroomCondition"
            If dlvGroomCondition.SelectedObject() IsNot Nothing Then
               Dim objectToDelete = dlvGroomCondition.SelectedObject()
               If Not dlvGroomCondition.IsDisabled(objectToDelete) Then
                  If MessageBox.Show(My.Resources.msgConfirmDeleteObject, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                     m_lookups.GroomCondition.RemoveGroomConditionRow(CType(objectToDelete, DataRowView).Row)
                     BindingNavigatorSaveChanges.Enabled = True
                  End If
               End If
            End If

         Case "tabBrideCondition"
            If dlvBrideCondition.SelectedObject() IsNot Nothing Then
               Dim objectToDelete = dlvBrideCondition.SelectedObject()
               If Not dlvBrideCondition.IsDisabled(objectToDelete) Then
                  If MessageBox.Show(My.Resources.msgConfirmDeleteObject, "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                     m_lookups.BrideCondition.RemoveBrideConditionRow(CType(objectToDelete, DataRowView).Row)
                     BindingNavigatorSaveChanges.Enabled = True
                  End If
               End If
            End If

      End Select

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

      LookupTables.AcceptChanges()
      LookupTables.WriteXml(m_LookupsFilename, XmlWriteMode.WriteSchema)
   End Sub

   Private Sub BindingNavigatorSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorSaveChanges.Click
      LookupTables.AcceptChanges()
      LookupTables.WriteXml(m_LookupsFilename, XmlWriteMode.WriteSchema)
      BindingNavigatorSaveChanges.Enabled = LookupTables.HasChanges()
   End Sub

   Private Sub formUserTables_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles MyBase.HelpRequested
      Try
         formHelp.Title = "FreeREG Browser"
         formHelp.StartPage = "UserTables.html"
         formHelp.Show()

      Catch ex As Exception
         formHelp.Hide()
         MessageBox.Show(ex.Message, "General Help", MessageBoxButtons.OK, MessageBoxIcon.Stop)

      End Try
   End Sub
End Class