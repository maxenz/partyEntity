Imports System.Linq
Imports DevExpress.XtraGrid.Columns

Public Class frmArticulos

    Private db As PartyIdeaEntities
    Private frmEdit As frmArticulosEditar
    Private artToEdit As Articulos

    Public Sub New()

        InitializeComponent()
        db = New PartyIdeaEntities
        AddHandler grdViewArticulos.DoubleClick, AddressOf grdViewArticulos_DoubleClick
        grdArticulos.DataSource = getDatasourceGrid()
        formatGrid()

    End Sub

    Private Sub formatGrid()

        grdViewArticulos.OptionsBehavior.Editable = False
        grdViewArticulos.OptionsSelection.EnableAppearanceFocusedCell = False
        grdViewArticulos.OptionsView.ShowGroupPanel = False
        grdViewArticulos.Appearance.FocusedRow.BackColor = Color.MediumSeaGreen
        grdViewArticulos.Appearance.FocusedRow.BackColor2 = Color.MediumSeaGreen
        grdViewArticulos.OptionsView.ShowAutoFilterRow = True
        grdViewArticulos.Columns("ID").Visible = False

    End Sub

    Private Function getDatasourceGrid() As DataTable

        Dim lstArticulos = (From art In db.Articulos _
                           Select New With {
                                .ID = art.ID,
                                .Codigo = art.Codigo,
                                .Descripcion = art.Descripcion,
                                .Categoria = art.Categorias.Descripcion,
                                .Genero = art.Generos.Descripcion,
                                .Procedencia = art.Procedencia,
                                .ValorAdquisicion = art.ValorAdquisicion,
                                .Precio = art.Precio,
                                .Observaciones = art.Observaciones
                            }).ToList

        Dim dtArticulos As DataTable = ListToDataTable(lstArticulos)

        Return dtArticulos

    End Function

    Private Sub grdViewArticulos_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdViewArticulos.RowStyle

        If (e.RowHandle Mod 2 = 1) Then
            e.Appearance.BackColor = Color.FromArgb(206, 232, 195)
        End If

    End Sub

    Private Sub EditArticulo(ByVal articulo As Articulos, ByVal windowTitle As String, ByVal closedDelegate As FormClosingEventHandler)

        frmEdit = New frmArticulosEditar(articulo, False) With {.Text = windowTitle}
        AddHandler frmEdit.FormClosing, closedDelegate
        frmEdit.StartPosition = FormStartPosition.CenterScreen
        frmEdit.ShowDialog()

    End Sub

    Private Sub CloseEditArticuloHandler(ByVal sender As Object, ByVal e As EventArgs)

        If (CType(sender, frmArticulosEditar)).DialogResult = System.Windows.Forms.DialogResult.OK Then
            Try

                artToEdit.regFechaHora = getFechaHoraActual()
                If (Not (IsDBNull(frmEdit.picEdArticulo.EditValue))) Then
                    artToEdit.Imagen = frmEdit.picEdArticulo.EditValue
                End If
                artToEdit.regUsuarioId = 1
                db.Entry(artToEdit).State = EntityState.Modified
                db.SaveChanges()
                saveATS()
                grdArticulos.DataSource = Nothing
                grdArticulos.DataSource = getDatasourceGrid()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        artToEdit = Nothing
    End Sub

    Private Sub CloseNewArticuloHandler(ByVal sender As Object, ByVal e As FormClosingEventArgs)

        If (CType(sender, frmArticulosEditar)).DialogResult = System.Windows.Forms.DialogResult.OK Then
            Try
                artToEdit.regFechaHora = getFechaHoraActual()
                If (Not (IsDBNull(frmEdit.picEdArticulo.EditValue))) Then
                    artToEdit.Imagen = frmEdit.picEdArticulo.EditValue
                End If
                artToEdit.regUsuarioId = 1
                artToEdit.Codigo = getCodigoArticulo(artToEdit.CategoriaId)
                db.Entry(artToEdit).State = EntityState.Added
                db.SaveChanges()
                saveATS()
                grdArticulos.DataSource = Nothing
                grdArticulos.DataSource = getDatasourceGrid()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
        artToEdit = Nothing
    End Sub

    Private Function getCodigoArticulo(ByVal catId As Integer) As String

        Dim objArt = (From a In db.Articulos Where a.CategoriaId = catId _
                          Select a Order By a.Codigo Descending).FirstOrDefault

        If (objArt Is Nothing) Then
            Dim ultCod As String = (From a In db.Articulos Select a.Codigo Order By Codigo Descending).FirstOrDefault()
            ultCod = ultCod.Substring(0, 3)
            ultCod = Convert.ToInt32(ultCod)
            ultCod = ultCod + 1
            ultCod = "" & ultCod & "0000"
            Return ultCod
        End If

        Dim cod As String = objArt.Codigo

        Return cod.Substring(0, 2) & Format(Val(cod.Substring(2, cod.Length - 2)) + 1, "0000")

    End Function

    Private Function GetCurrentArticulo() As Articulos

        Dim idArt As Integer = grdViewArticulos.GetRowCellValue(grdViewArticulos.FocusedRowHandle, "ID")

        Return db.Articulos.Find(idArt)

    End Function

    Private Sub btnNuevoArticulo_Click(sender As Object, e As EventArgs) Handles btnNuevoArticulo.Click

        artToEdit = New Articulos()
        InsertArticulo(artToEdit, "Nuevo Artículo", AddressOf CloseNewArticuloHandler)

    End Sub

    Private Sub btnEditarArticulo_Click(sender As Object, e As EventArgs) Handles btnEditarArticulo.Click
        If grdViewArticulos.FocusedRowHandle < 0 Then
            MessageBox.Show("No seleccionaste ningun artículo para editar.")
            Return
        End If
        artToEdit = Nothing
        artToEdit = GetCurrentArticulo()
        EditArticulo(artToEdit, "Editar Artículo", AddressOf CloseEditArticuloHandler)
    End Sub
    Private Sub InsertArticulo(ByVal articulo As Articulos, ByVal windowTitle As String, ByVal closedDelegate As FormClosingEventHandler)

        frmEdit = New frmArticulosEditar(articulo, True) With {.Text = windowTitle}
        AddHandler frmEdit.FormClosing, closedDelegate
        frmEdit.StartPosition = FormStartPosition.CenterScreen
        frmEdit.ShowDialog()

    End Sub

    Private Sub grdViewArticulos_DoubleClick(sender As Object, e As EventArgs)
        artToEdit = GetCurrentArticulo()
        EditArticulo(artToEdit, "Editar Artículo", AddressOf CloseEditArticuloHandler)
    End Sub

    Private Sub saveATS()

        Try
            Dim talle As Integer = 0
            Dim cant As Integer = 0
            Dim idArt = artToEdit.ID
            Dim i As Integer = 0
            Do While i < frmEdit.grdViewTallesCant.RowCount
                Dim row As DataRow = frmEdit.grdViewTallesCant.GetDataRow(i)
                If Not row Is Nothing Then
                    talle = row("TalleId")
                    cant = row("Cantidad")
                    Dim id = row("ID")
                    If (IsDBNull(id)) Then
                        Dim objAts As ArticulosTalleStock = New ArticulosTalleStock
                        objAts.TalleId = talle
                        objAts.Cantidad = cant
                        objAts.IdArticulo = idArt
                        objAts.regFechaHora = getFechaHoraActual()
                        objAts.regUsuarioId = 1
                        db.Entry(objAts).State = EntityState.Added
                    Else
                        Dim objAts As ArticulosTalleStock = db.ArticulosTalleStock.Find(id)
                        objAts.TalleId = talle
                        objAts.Cantidad = cant
                        db.Entry(objAts).State = EntityState.Modified
                    End If
                    db.SaveChanges()
                End If
                i += 1
            Loop

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnEliminarArticulo_Click(sender As Object, e As EventArgs) Handles btnEliminarArticulo.Click
        If grdViewArticulos.FocusedRowHandle < 0 Then
            MessageBox.Show("No seleccionaste ningun artículo para editar.")
            Return
        End If
        Try
            artToEdit = GetCurrentArticulo()

            Dim movAfectado = (From m In db.MovimientosArticulos Where _
                                    m.ArticulosTalleStock.IdArticulo = artToEdit.ID _
                                    Select m.Movimientos.NroSolicitud).FirstOrDefault

            If (Not (IsNothing(movAfectado))) Then
                MsgBox("No se puede borrar el artículo. Está afectado a la gestión " & movAfectado, MsgBoxStyle.Information)
            Else
                Dim result = MessageBox.Show("¿Desea eliminar el artículo seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.No Then
                    Return
                ElseIf result = DialogResult.Yes Then
                    db.Articulos.Remove(artToEdit)
                    db.SaveChanges()
                    grdArticulos.DataSource = Nothing
                    grdArticulos.DataSource = getDatasourceGrid()
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
End Class