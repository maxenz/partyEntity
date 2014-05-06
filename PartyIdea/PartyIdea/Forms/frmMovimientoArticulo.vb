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

Public Class frmMovimientoArticulo

    Private db As PartyIdeaEntities
    Private insFlag As Boolean
    Private actualRow As Integer
    Private movArt As MovimientosArticulos

    Private Sub formatGrid()

        GridView1.OptionsBehavior.Editable = False
        GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        GridView1.OptionsView.ShowGroupPanel = False
        GridView1.Appearance.FocusedRow.BackColor = Color.MediumSeaGreen
        GridView1.Appearance.FocusedRow.BackColor2 = Color.MediumSeaGreen
        GridView1.Appearance.SelectedRow.BackColor = Color.MediumSeaGreen
        GridView1.Appearance.SelectedRow.BackColor2 = Color.MediumSeaGreen

    End Sub

    Private Sub setLookupOperacion()

        Dim srcOpe = (From o In db.Operaciones Select o.ID, o.Descripcion).ToList
        cmbOperaciones.Properties.DataSource = srcOpe
        setLookupProperties(cmbOperaciones)

    End Sub

    Public Sub New(ByVal mArt As MovimientosArticulos, ByVal insertFlag As Boolean, Optional ByVal row As Integer = -1)

        ' This call is required by the designer.
        InitializeComponent()
        db = New PartyIdeaEntities

        movArt = mArt

        'insFlag sirve para ver si vengo del boton agregar o editar movimientoArticulo
        insFlag = insertFlag

        'row seleccionada en grilla de movimientosArticulos
        actualRow = row

        'seteo general de los LookupEdit
        setLookupOperacion()
        setLookupProperties(cmbDescArticulos)
        setLookupPropertiesCod(cmbCodArticulos)
        setLookupProperties(cmbTalle)

        'hago el clear de los textbox y dateedit del formulario de movimientosArticulos
        clearTextbox(New String() {"txtImporte", "txtAbona", "txtCantidad", "txtRestan"})
        clearDates(New String() {"dtEntrega", "dtDevolucion", "dtStockDisp"})

        txtImporte.Properties.ReadOnly = True
        txtRestan.Properties.ReadOnly = True

        'format de la grilla
        formatGrid()

        'Si estoy editando un movArt...
        If (Not (insertFlag)) Then

            'traigo los datos del movArt que estoy editando

            Dim ats As ArticulosTalleStock = (From s In db.ArticulosTalleStock Where s.ID = mArt.ArticuloTalleId).FirstOrDefault
            Dim idArt As Integer = ats.IdArticulo
            Dim talle As String = ats.Talles.ID

            cmbOperaciones.EditValue = mArt.OperacionId
            cmbCodArticulos.EditValue = idArt
            cmbDescArticulos.EditValue = idArt
            dtEntrega.DateTime = mArt.FecEntrega
            dtDevolucion.DateTime = mArt.FecDevolucion
            txtCantidad.EditValue = mArt.Cantidad
            txtImporte.EditValue = mArt.Importe
            txtAbona.EditValue = mArt.Abona

            cmbTalle.EditValue = talle

            txtRestan.EditValue = mArt.Importe - mArt.Abona

            'Seteo el stock para visualizarlo en el costado derecho del form
            setStockMovArt()

            'Seteo la imagen del artículo
            setImage(idArt)

        End If

    End Sub

    Private Sub cmbOperaciones_EditValueChanged(sender As Object, e As EventArgs) Handles cmbOperaciones.EditValueChanged

        'valido los combos de codigo y descripcion. Si es art. venta, obviamente no pongo los disfraces en los combos.

        Dim srcCmbDescArt, srcCmbCodArt

        If (cmbOperaciones.EditValue = 3) Then

            srcCmbDescArt = (From a In db.Articulos _
                                Where a.Categorias.Descripcion = "ARTVENTA" _
                                Select a.ID, a.Descripcion) _
                                .ToList()

            srcCmbCodArt = (From a In db.Articulos _
                               Where a.Categorias.Descripcion = "ARTVENTA" _
                               Select a.ID, a.Codigo) _
                              .ToList()
        Else

            cmbTalle.Enabled = True

            srcCmbDescArt = (From a In db.Articulos _
                                Where a.Categorias.Descripcion <> "ARTVENTA" _
                                Select a.ID, a.Descripcion) _
                                .ToList()

            srcCmbCodArt = (From a In db.Articulos _
                               Where a.Categorias.Descripcion <> "ARTVENTA" _
                               Select a.ID, a.Codigo) _
                              .ToList()
        End If

        cmbDescArticulos.Properties.DataSource = srcCmbDescArt
        cmbCodArticulos.Properties.DataSource = srcCmbCodArt
        cmbTalle.Properties.DataSource = Nothing
        cmbTalle.EditValue = Nothing

        clearTextbox(New String() {"txtImporte", "txtAbona", "txtCantidad", "txtRestan"})
        clearDates(New String() {"dtEntrega", "dtDevolucion", "dtStockDisp"})
        clearLookup(New String() {"cmbCodArticulos", "cmbDescArticulos"})

        cmbDescArticulos.ClosePopup()
        cmbCodArticulos.ClosePopup()

    End Sub
    Private Sub clearLookup(ByVal vLookup As String())

        For Each l In vLookup

            Dim ctrl_lookup As LookUpEdit = CType(grpMovArt.Controls(l), LookUpEdit)

            ctrl_lookup.EditValue = Nothing

        Next

    End Sub

    Private Sub clearTextbox(ByVal vTbox As String())

        For Each tbox In vTbox

            Dim ctrl_textbox As TextEdit = CType(grpMovArt.Controls(tbox), TextEdit)

            ctrl_textbox.Text = ""

        Next

        txtAbona.EditValue = 0D
        txtImporte.EditValue = 0D

    End Sub

    Private Sub clearDates(ByVal vDates As String())

        For Each dt In vDates

            Dim ctrl_dateedit As DateEdit = CType(grpMovArt.Controls(dt), DateEdit)

            ctrl_dateedit.DateTime = Date.Today

        Next

        dtDevolucion.DateTime = Date.Today.AddDays(3)

    End Sub

    Private Sub cmbCodArticulos_EditValueChanged(sender As Object, e As EventArgs) Handles cmbCodArticulos.EditValueChanged

        'valido contra el combo de descripcion

        clearTxtAndDates()

        Dim codSelected As String = cmbCodArticulos.Text
        Dim idArt As Integer = cmbCodArticulos.EditValue
        Dim descSelected As String = (From a In db.Articulos Where a.Codigo = codSelected Select a.Descripcion).FirstOrDefault()

        cmbDescArticulos.Text = descSelected
        cmbDescArticulos.ClosePopup()

        setImage(idArt)

        setStockMovArt()

        setTallesDatasource()

    End Sub

    Private Sub cmbDescArticulos_EditValueChanged(sender As Object, e As EventArgs) Handles cmbDescArticulos.EditValueChanged

        'valido contra el combo de codigo

        clearTxtAndDates()

        Dim descSelected As String = cmbDescArticulos.Text
        Dim idArt As Integer = cmbCodArticulos.EditValue

        Dim codSelected As String = (From a In db.Articulos Where a.Descripcion = descSelected Select a.Codigo).FirstOrDefault()

        cmbCodArticulos.Text = codSelected
        cmbCodArticulos.ClosePopup()

        setImage(idArt)

        setStockMovArt()

        setTallesDatasource()

    End Sub

    Private Sub setImage(ByVal id As Integer)

        'seteo la imagen del articulo
        Dim img = (From a In db.Articulos Where a.ID = id Select a.Imagen).FirstOrDefault()

        If (img Is Nothing) Then

            picArt.EditValue = Nothing

        Else

            picArt.EditValue = img

        End If

    End Sub

    Private Sub setTallesDatasource()

        'seteo el datasource del combo de talles, dependiendo del articulo seleccionado

        cmbTalle.Properties.DataSource = Nothing

        Dim idArt As Integer = cmbCodArticulos.EditValue

        Dim talles = (From a In db.ArticulosTalleStock Where a.IdArticulo = idArt Select a.Talles.ID, a.Talles.Descripcion).ToList()

        cmbTalle.Properties.DataSource = talles

    End Sub

    Private Sub clearTxtAndDates()

        clearTextbox(New String() {"txtImporte", "txtAbona", "txtCantidad", "txtRestan"})
        clearDates(New String() {"dtEntrega", "dtDevolucion", "dtStockDisp"})

    End Sub

    Private Sub setStockMovArt()

        Dim dateStock As Date = dtStockDisp.DateTime

        If (dateStock.Date = Nothing) Then
            dateStock = Date.Today
        End If

        Dim idArt As Integer = cmbCodArticulos.EditValue

        Dim lstATS = (From a In db.ArticulosTalleStock Where a.IdArticulo = idArt).ToList()

        Dim lstStock As List(Of Stock) = New List(Of Stock)

        For Each ats In lstATS

            Dim cant As Integer

            If (cmbOperaciones.EditValue = 3) Then
                cant = ats.Cantidad
            Else
                cant = getStock(ats, dateStock, dateStock.AddDays(3), db)

            End If
            lstStock.Add(New Stock With {.Cantidad = cant, .Talle = ats.Talles.Descripcion})


        Next

        Dim dtStock As DataTable = ListToDataTable(lstStock)

        grdStockMovArt.DataSource = dtStock

        GridView1.Columns(0).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
        GridView1.Columns(1).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

    End Sub

    Private Sub btnBuscarStock_Click(sender As Object, e As EventArgs) Handles btnBuscarStock.Click

        If (cmbCodArticulos.EditValue = Nothing) Then
            MsgBox("Debe seleccionar un artículo", MsgBoxStyle.Critical)
        Else
            setStockMovArt()
        End If

    End Sub


    Private Sub btnGuardarMovArt_Click(sender As Object, e As EventArgs) Handles btnGuardarMovArt.Click

        Dim idArt As Integer = cmbCodArticulos.EditValue
        Dim cant As Integer = txtCantidad.Text
        Dim talle As String = cmbTalle.Text

        Dim idTalle As Integer = (From t In db.Talles Where t.Descripcion = talle Select t.ID).FirstOrDefault()

        Dim ats As ArticulosTalleStock = (From a In db.ArticulosTalleStock _
                                         Where a.TalleId = idTalle _
                                         Where a.IdArticulo = idArt).FirstOrDefault()

        Dim dateEntrega As Date = dtEntrega.DateTime
        Dim dateDevolucion As Date = dtDevolucion.DateTime

        'valido el stock

        Dim stockDisp As Integer
        If (cmbOperaciones.Text = "VENTA") Then
            stockDisp = ats.Cantidad
        Else
            stockDisp = getStock(ats, dateEntrega, dateDevolucion, db)
        End If

        If (Not (insFlag)) Then
            If (movArt.ID <> 0) Then
                Dim dt As DataTable = frmRetiros.grdArticulosMov.DataSource
                Dim drow As DataRow = dt.Rows(actualRow)
                stockDisp = stockDisp + drow(7)
            End If
        End If

        'si hay stock
        If (stockDisp >= cant) Then

            'si estoy agregando un movimiento
            If (insFlag) Then

                Dim dt As DataTable = frmRetiros.grdArticulosMov.DataSource
                Dim vRow As DataRow = dt.NewRow
                vRow(0) = 0
                vRow(1) = cmbCodArticulos.Text
                vRow(2) = cmbDescArticulos.Text
                vRow(3) = cmbOperaciones.Text
                vRow(4) = dtEntrega.DateTime
                vRow(5) = dtDevolucion.DateTime
                vRow(6) = cmbTalle.Text
                vRow(7) = txtCantidad.Text
                vRow(8) = txtImporte.EditValue
                vRow(9) = txtAbona.EditValue

                dt.Rows.Add(vRow)

                frmRetiros.grdArticulosMov.DataSource = dt

                Me.Close()

                'si estoy editando un artículo
            Else

                Dim dt As DataTable = frmRetiros.grdArticulosMov.DataSource
                Dim vRow As DataRow = dt.Rows(actualRow)
                vRow(1) = cmbCodArticulos.Text
                vRow(2) = cmbDescArticulos.Text
                vRow(3) = cmbOperaciones.Text
                vRow(4) = dtEntrega.DateTime
                vRow(5) = dtDevolucion.DateTime
                vRow(6) = cmbTalle.Text
                vRow(7) = txtCantidad.Text
                vRow(8) = txtImporte.EditValue
                vRow(9) = txtAbona.EditValue

                frmRetiros.grdArticulosMov.DataSource = dt

                Me.Close()

            End If
            frmRetiros.calculoTotales()
        Else
            MsgBox("No hay stock disponible.", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown

        If e.KeyCode = Keys.Enter Then

            validarImporteMovimiento()

        End If

    End Sub

    Private Sub validarImporteMovimiento()

        'valido los importes del artículo y cantidades seleccionadas

        If (Not (cmbTalle.EditValue = Nothing) And Not (cmbCodArticulos.EditValue = Nothing)) Then

            Dim idArt As Integer = cmbCodArticulos.EditValue
            Dim cant As Integer = txtCantidad.Text

            Dim valArt As Double = (From a In db.Articulos Where a.ID = idArt Select a.Precio).FirstOrDefault()

            Dim importe As Double = cant * valArt

            Dim abona As Double = txtAbona.Text

            txtImporte.Text = importe
            txtRestan.Text = importe - abona

            If (cmbOperaciones.Text = "VENTA") Then
                txtAbona.Text = importe
                txtRestan.Text = 0D
            End If

        Else

            MsgBox("Debe seleccionar artículo y talle.", MsgBoxStyle.Critical)

        End If

    End Sub

    Private Sub txtAbona_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAbona.KeyDown

        If e.KeyCode = Keys.Enter Then

            Dim importe As Double = txtImporte.Text
            Dim abona As Double = txtAbona.Text

            txtRestan.Text = importe - abona

        End If
    End Sub

    Private Sub btnCancMovArt_Click(sender As Object, e As EventArgs) Handles btnCancMovArt.Click
        Me.Close()
    End Sub
End Class