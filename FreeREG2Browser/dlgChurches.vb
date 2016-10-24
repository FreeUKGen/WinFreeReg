Imports System.Windows.Forms
Imports System.Drawing
Imports BrightIdeasSoftware

Public Class dlgChurches

   Private _formHelp As formGeneralHelp

   Sub New(formHelp As formGeneralHelp)
      InitializeComponent()
      _formHelp = formHelp
   End Sub

   Property FreeREGDataset As FreeregTables

   Property DefaultCounty As FreeregTables.CountiesRow

   Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub dlgChurches_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      CountiesBindingSource.DataSource = FreeREGDataset
      DefaultCountyComboBox.SelectedIndex = DefaultCountyComboBox.FindString(DefaultCounty.ChapmanCode)

      DataListView2.DataSource = PlacesBindingSource
      DataListView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
      DataListView2.RebuildColumns()

      DataListView3.DataSource = ChurchesBindingSource
      DataListView3.ShowGroups = False
      DataListView3.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
      DataListView3.RebuildColumns()

      DataListView4.DataSource = ChurchesBindingSource1
      DataListView4.RebuildColumns()

   End Sub

   Private Sub ComboBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles DefaultCountyComboBox.DrawItem
      e.DrawBackground()
      If e.State = DrawItemState.Focus Then e.DrawFocusRectangle()
      Dim x As DataRowView = DefaultCountyComboBox.Items(e.Index)
      Dim r As FreeregTables.CountiesRow = CType(x.Row, FreeregTables.CountiesRow)
      Dim s = String.Format("{0} - {1}", r.ChapmanCode, r.CountyName)
      e.Graphics.DrawString(s, e.Font, Brushes.Black, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
   End Sub

   Private Sub DataListView4_ItemsChanged(sender As Object, e As ItemsChangedEventArgs) Handles DataListView4.ItemsChanged
      Dim dlv As DataListView = CType(sender, DataListView)
      If dlv.Items.Count > 0 Then
         DataListView4.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
         DataListView4.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent)
      End If
   End Sub
End Class
