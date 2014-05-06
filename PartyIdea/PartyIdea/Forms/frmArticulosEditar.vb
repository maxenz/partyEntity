Imports System.Linq
Imports System.Drawing.Imaging
Imports System.IO
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Controls

Public Class frmArticulosEditar

    Private db As PartyIdeaEntities
    Private art As Articulos
    Private lkTalle As New RepositoryItemLookUpEdit()
    Private insFlag As Boolean

    Public Sub New(ByVal articulo As Articulos, ByVal insertFlag As Boolean)

        ' This call is required by the designer.
        InitializeComponent()
        db = New PartyIdeaEntities
        setLookupsArticulo()
        setGrid(articulo)
        insFlag = insertFlag
        art = articulo

        txtDescripcionArt.DataBindings.Add("EditValue", articulo, "Descripcion", True)
        txtObservArt.DataBindings.Add("EditValue", articulo, "Observaciones", True)
        txtPrecioArt.DataBindings.Add("EditValue", articulo, "Precio", True)
        txtProcedenciaArt.DataBindings.Add("EditValue", articulo, "Procedencia", True)
        txtValorAdqArt.DataBindings.Add("EditValue", articulo, "ValorAdquisicion", True)
        picEdArticulo.DataBindings.Add("EditValue", articulo, "Imagen", True)
        lkCategArt.DataBindings.Add("EditValue", articulo, "CategoriaId")
        lkGeneroArt.DataBindings.Add("EditValue", articulo, "GeneroId")

        If (Not insFlag) Then
            lkCategArt.Enabled = False
        End If

        'txtCantArtVenta.Properties.ReadOnly = True

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub setGrid(ByVal articulo As Articulos)
        Dim ats = (From a In db.ArticulosTalleStock Where _
          a.IdArticulo = articulo.ID Select _
          a.ID, a.TalleId, a.Cantidad).ToList

        Dim dtAts As DataTable = ListToDataTable(ats)

        grdTallesCantidad.DataSource = New DataView(dtAts)

        ' Seteo lookupedit TALLES

        lkTalle.DisplayMember = ""
        Dim talleLookup = (From t In db.Talles _
                             Select t.ID, t.Descripcion).ToList
        lkTalle.DataSource = talleLookup
        setLookupRepositoryProperties(lkTalle)
        grdViewTallesCant.Columns("TalleId").ColumnEdit = lkTalle
        lkTalle.TextEditStyle = TextEditStyles.DisableTextEditor

        grdViewTallesCant.OptionsView.ShowGroupPanel = False
        grdViewTallesCant.Columns("ID").Visible = False
        grdViewTallesCant.Columns("TalleId").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdViewTallesCant.Columns("Cantidad").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

    End Sub

    Private Sub setLookupsArticulo()

        Dim srcLookupCateg = (From c In db.Categorias Select c.ID, c.Descripcion Order By Descripcion Ascending).ToList
        lkCategArt.Properties.DataSource = srcLookupCateg
        setLookupProperties(lkCategArt)

        Dim srcLookupGen = (From c In db.Generos Select c.ID, c.Descripcion).ToList
        lkGeneroArt.Properties.DataSource = srcLookupGen
        setLookupProperties(lkGeneroArt)

    End Sub

    Private Sub frmArticulosEditar_KeyDown(sender As Object, e As KeyEventArgs) Handles grdTallesCantidad.ProcessGridKey

        If (e.KeyCode = Keys.F2) Then

            If validateCompleteRows() Then

                grdViewTallesCant.AddNewRow()
                grdViewTallesCant.UpdateCurrentRow()

            End If
        ElseIf (e.KeyCode = Keys.F3) Then

            Dim nroRow As Integer = grdViewTallesCant.GetSelectedRows().FirstOrDefault()

            Dim result = MessageBox.Show("¿Desea eliminar el talle seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                Return
            ElseIf result = DialogResult.Yes Then
                Dim ats_id As Integer = grdViewTallesCant.GetRowCellValue(nroRow, "ID")
                Dim ats = db.ArticulosTalleStock.Find(ats_id)
                db.ArticulosTalleStock.Remove(ats)
                grdViewTallesCant.DeleteRow(nroRow)
                db.SaveChanges()
            End If

        End If
    End Sub

    Private Function validateCompleteRows() As Boolean

        Dim i As Integer = 0
        Do While i < grdViewTallesCant.RowCount
            Dim row As DataRow = grdViewTallesCant.GetDataRow(i)
            If Not row Is Nothing Then
                If (Not (validoRow(row))) Then
                    Return False
                End If
            End If
            i += 1
        Loop

        Return True

    End Function

    Public Function validoRow(ByVal row As DataRow) As Boolean

        'Valido que todos los campos tenga un valor correcto

        Dim talle = row.ItemArray.GetValue(1)
        Dim cant = row.ItemArray.GetValue(2)

        If (IsDBNull(talle) Or IsDBNull(cant)) Then

            MsgBox("Complete los campos correctamente", MsgBoxStyle.Critical)

            Return False

        End If

        Return True

    End Function

    Private Sub frmArticulosEditar_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        txtDescripcionArt.Focus()

    End Sub

    Private Sub btnCargarImagen_Click(sender As Object, e As EventArgs) Handles btnCargarImagen.ButtonClick

        Dim dlg As New OpenFileDialog()
        dlg.Filter = "image Files|*.jpg"

        Dim result As Nullable(Of Boolean) = dlg.ShowDialog()
        If result = True Then
            btnCargarImagen.Text = dlg.FileName
            If (dlg.FileName <> "") Then

                Dim img As Image = Image.FromFile(dlg.FileName)
                Dim data As Byte() = DevExpress.XtraEditors.Controls.ByteImageConverter.ToByteArray(img, img.RawFormat)
                picEdArticulo.EditValue = data

            End If
        End If

    End Sub

    Private Sub btnAceptarArt_Click(sender As Object, e As EventArgs) Handles btnAceptarArt.Click

        Dim vBoolValidation As Boolean = True

        For Each ctrl In gpArticulos.Controls

            Dim typeCtrl = ctrl.GetType.Name
            Dim tagCtrl = ctrl.Tag

            If ((typeCtrl = "TextEdit" Or typeCtrl = "LookUpEdit") And tagCtrl = "required") Then

                If ctrl.Text.Length = 0 Then
                    errorProviderArticulos.SetIconPadding(ctrl, -20)
                    errorProviderArticulos.SetError(ctrl, "El campo no puede estar vacío.")
                    vBoolValidation = False
                Else
                    errorProviderArticulos.SetError(ctrl, "")
                End If
            End If
        Next

        If vBoolValidation Then

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            MsgBox("Complete todos los campos indicados", MsgBoxStyle.Critical)
        End If


    End Sub

    Private Sub btnCancelarArt_Click(sender As Object, e As EventArgs) Handles btnCancelarArt.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

    End Sub

    Private Sub lkCategArt_EditValueChanged(sender As Object, e As EventArgs) Handles lkCategArt.EditValueChanged

        If (insFlag) Then

        If (lkCategArt.Text = "ARTVENTA") Then

            For i As Integer = 0 To grdViewTallesCant.RowCount - 1
                grdViewTallesCant.DeleteRow(i)
            Next

            Dim idTalle As Integer = (From t In db.Talles Where (t.Descripcion = "UNICO") Select t.ID).FirstOrDefault()
            grdViewTallesCant.AddNewRow()
            grdViewTallesCant.UpdateCurrentRow()
            grdViewTallesCant.SetRowCellValue(0, "TalleId", idTalle)
            grdViewTallesCant.SetRowCellValue(0, "Cantidad", 0)
            lkTalle.ReadOnly = True

        Else
            lkTalle.ReadOnly = False

            End If
        End If
    End Sub

    Private Sub grdViewTallesCant_KeyDown(sender As Object, e As KeyEventArgs) Handles grdViewTallesCant.KeyDown

        If (e.KeyCode = Keys.Delete) Then

            Dim result = MessageBox.Show("¿Está seguro que desea eliminar el elemento?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowHandle = grdViewTallesCant.FocusedRowHandle

                Dim idATS = grdViewTallesCant.GetRowCellValue(rowHandle, "ID")

                Try

                    Dim ats As ArticulosTalleStock = db.ArticulosTalleStock.Find(idATS)
                    db.ArticulosTalleStock.Remove(ats)
                    db.SaveChanges()
                    Dim ats_all = (From a In db.ArticulosTalleStock Where _
                             a.IdArticulo = art.ID Select _
                             a.ID, a.TalleId, a.Cantidad).ToList

                    Dim dtAts As DataTable = ListToDataTable(ats_all)

                    grdTallesCantidad.DataSource = New DataView(dtAts)

                Catch ex As Exception

                    MsgBox("Error eliminando el talle", MsgBoxStyle.Critical)

                End Try
            End If

        End If

    End Sub
End Class