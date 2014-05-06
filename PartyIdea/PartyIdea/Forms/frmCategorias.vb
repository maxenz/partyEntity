Imports System
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Linq
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System.Reflection
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports System.Globalization
Imports System.Transactions

Public Class frmCategorias

    Private db As PartyIdeaEntities
    Private Sub formatGrid()

        grdViewCategorias.OptionsBehavior.Editable = False
        grdViewCategorias.OptionsSelection.EnableAppearanceFocusedCell = False
        grdViewCategorias.OptionsView.ShowGroupPanel = False
        grdViewCategorias.Appearance.FocusedRow.BackColor = Color.MediumSeaGreen
        grdViewCategorias.Appearance.FocusedRow.BackColor2 = Color.MediumSeaGreen
        grdViewCategorias.OptionsView.ShowAutoFilterRow = True
        grdViewCategorias.Columns("ID").Visible = False

    End Sub

    Private Sub frmCategorias_Load(sender As Object, e As EventArgs) Handles Me.Load

        db = New PartyIdeaEntities
        AddHandler grdViewCategorias.DoubleClick, AddressOf grdViewCategorias_DoubleClick
        grdCategorias.DataSource = getCategoriasDatasource()
        formatGrid()
        grdViewCategorias.Columns(0).Visible = False

    End Sub

    Public Function getCategoriasDatasource() As DataTable

        Dim lstCategorias = (From c In db.Categorias Select New With {.ID = c.ID, .Descripcion = c.Descripcion, .Fecha = c.regFechaHora}).OrderBy(Function(c) c.Descripcion).ToList()
        Dim dtCategorias As DataTable = ListToDataTable(lstCategorias)

        Return dtCategorias

    End Function

    Private Sub grdViewCategorias_DoubleClick(sender As Object, e As EventArgs)
        modifCat()
    End Sub

    Private Sub btnAgregarCat_Click(sender As Object, e As EventArgs) Handles btnAgregarCat.Click
        frmCategoriasEditar.idCat = 0
        frmCategoriasEditar.StartPosition = FormStartPosition.CenterScreen
        frmCategoriasEditar.Show()
    End Sub

    Private Sub modifCat()
        Dim idCat As Integer = grdViewCategorias.GetRowCellValue(grdViewCategorias.FocusedRowHandle, "ID")
        If (idCat = 0) Then
            MsgBox("Debe seleccionar una categoría")
            Return
        End If
        Dim cat As String = db.Categorias.Find(idCat).Descripcion
        frmCategoriasEditar.txtDescCategoria.Text = cat
        frmCategoriasEditar.idCat = idCat
        frmCategoriasEditar.StartPosition = FormStartPosition.CenterScreen
        frmCategoriasEditar.Show()
    End Sub

    Private Sub btnModifCat_Click(sender As Object, e As EventArgs) Handles btnModifCat.Click
        modifCat()
    End Sub

    Private Sub btnElimCat_Click(sender As Object, e As EventArgs) Handles btnElimCat.Click
        Dim idCat As Integer = grdViewCategorias.GetRowCellValue(grdViewCategorias.FocusedRowHandle, "ID")
        If (idCat = 0) Then
            MsgBox("Debe seleccionar una categoría")
            Return
        End If
        Dim cat As Categorias = db.Categorias.Find(idCat)
        If (cat.Articulos.Count > 0) Then
            MsgBox("No se puede eliminar. La categoría contiene artículos activos.")
            Return
        Else
            Dim result As Integer = MessageBox.Show("¿Desea eliminar la categoría?", "Atención!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Yes Then
                Try
                    db.Categorias.Remove(cat)
                    db.SaveChanges()
                    grdCategorias.DataSource = getCategoriasDatasource()
                Catch ex As Exception
                    MsgBox("No se pudo eliminar la categoría.")
                End Try
            End If
        End If
    End Sub
End Class