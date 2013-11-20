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

Public Class frmRetiros

    Private db As PartyIdeaEntities
    Dim ciUSA As CultureInfo = New CultureInfo("en-US")
    Dim global_cliente_id As Integer = 0


    Public Sub New()

        InitializeComponent()

        'Abro conexion a la base de datos
        db = New PartyIdeaEntities

        'Muestro el último movimiento registrado
        Dim ultMov = getLastMov()
        If (Not (IsNothing(ultMov))) Then
            setMovimiento(ultMov)
        Else
            setMovArtDatasource(0)
        End If


        ' Seteo columna unbound Restan ->
        Dim columnExtPrice As GridColumn = New GridColumn()
        columnExtPrice.FieldName = "Restan"
        columnExtPrice.Caption = "Restan"
        columnExtPrice.Name = "Restan"
        columnExtPrice.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
        columnExtPrice.UnboundExpression = "[Importe] - [Abona]"
        grdViewArticulosMov.Columns.Add(columnExtPrice)
        columnExtPrice.VisibleIndex = grdViewArticulosMov.Columns.Count
        columnExtPrice.AppearanceCell.BackColor = Color.Pink
        columnExtPrice.OptionsColumn.AllowEdit = False

        ' Seteo lookupedit para CODIGO DE ARTICULO (valido el otro lookup de DESCRIPCION con este)
        Dim lkCodArt As New RepositoryItemLookUpEdit()
        lkCodArt.DisplayMember = "Codigo"
        lkCodArt.ValueMember = "Codigo"
        lkCodArt.NullText = "Sel. Código ..."
        Dim codArtLookup = (From a In db.Articulos Select a.Descripcion, a.Codigo).ToList
        lkCodArt.Columns.Add(New LookUpColumnInfo("Codigo", 40, "Codigo"))
        lkCodArt.Columns.Add(New LookUpColumnInfo("Descripcion", 150, "Descripcion"))
        lkCodArt.PopupWidth = 300
        lkCodArt.DataSource = codArtLookup
        grdViewArticulosMov.Columns("Codigo").ColumnEdit = lkCodArt

        ' Seteo lookupedit para DESCRIPCION DE ARTICULO (valido el otro lookup de CODIGO con este)
        Dim lkDescrArt As New RepositoryItemLookUpEdit()
        lkDescrArt.DisplayMember = "Descripcion"
        lkDescrArt.ValueMember = "Descripcion"
        lkDescrArt.NullText = "Sel. Disfraz..."
        Dim descArtLookup = (From a In db.Articulos Select a.Descripcion, a.Codigo).ToList
        lkDescrArt.Columns.Add(New LookUpColumnInfo("Descripcion", 150, "Descripcion"))
        lkDescrArt.Columns.Add(New LookUpColumnInfo("Codigo", 40, "Codigo"))
        lkDescrArt.PopupWidth = 300
        lkDescrArt.DataSource = descArtLookup
        grdViewArticulosMov.Columns("Descripcion").ColumnEdit = lkDescrArt

        'Seteo combobox de cantidades
        Dim cmbCantidad = RepositoryItemComboBox2
        For i As Integer = 0 To 20
            cmbCantidad.Items.Add(i)
        Next
        grdViewArticulosMov.Columns("Cantidad").ColumnEdit = cmbCantidad
        cmbCantidad.TextEditStyle = TextEditStyles.DisableTextEditor

        'Seteo lookupedit de operaciones
        Dim lkOperacion As RepositoryItemLookUpEdit = RepositoryItemLookUpEdit2
        lkOperacion.DisplayMember = "Descripcion"
        lkOperacion.ValueMember = "ID"
        lkOperacion.AllowNullInput = DefaultBoolean.False
        lkOperacion.NullText = "Sel. Operacion..."
        Dim opeLookup = (From a In db.Operaciones Select a.ID, a.Descripcion).ToList
        lkOperacion.Columns.Add(New LookUpColumnInfo("Descripcion", 20, "Descripcion"))
        lkOperacion.DataSource = opeLookup

        'Seteo configuraciones generales grilla movArt
        grdViewArticulosMov.Columns("OperacionId").ColumnEdit = lkOperacion
        grdViewArticulosMov.Columns("OperacionId").Caption = "Operación"
        grdViewArticulosMov.Columns("Importe").OptionsColumn.AllowEdit = False
        grdViewArticulosMov.Columns("Codigo").Width = 50
        grdViewArticulosMov.Columns("Descripcion").Width = 100
        grdViewArticulosMov.Columns("OperacionId").Width = 50
        grdViewArticulosMov.Columns("Talle").Width = 50
        grdViewArticulosMov.Columns("Talle").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
        grdViewArticulosMov.Columns("Cantidad").Width = 25
        grdViewArticulosMov.Columns("Cantidad").Caption = "Cant"
        grdViewArticulosMov.Columns("Cantidad").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
        grdViewArticulosMov.Columns("Importe").Width = 40
        grdViewArticulosMov.Columns("Abona").Width = 30
        grdViewArticulosMov.Columns("FecEntrega").Width = 45
        grdViewArticulosMov.Columns("FecEntrega").Caption = "Entrega"
        grdViewArticulosMov.Columns("FecDevolucion").Caption = "Devolución"
        grdViewArticulosMov.Columns("FecDevolucion").Width = 45
        grdViewArticulosMov.Columns("Restan").Width = 45
        grdViewArticulosMov.Columns("ID").Visible = False


        'Setos generales de controles
        dtFechaMovimiento.DateTime = Date.Today
        btnNuevoAlquiler.Focus()
        createCmbTalle()
        setAutocompleteEventos()
        setLookupTipoDoc()
        setFormatTextEdit()
        setLookupLocalidades()
        setComboSexo()
        setLocationErrorProviders()
        blockClientControls()


    End Sub
    Public Sub setMovimiento(ByVal mov As Movimientos)

        'Seteo movimiento en pantalla


        txtNroAlquiler.Text = mov.NroSolicitud
        dtFechaMovimiento.DateTime = mov.FecMovimiento

        Dim cliente_tel As String = db.Clientes.Find(mov.ClienteId).TelefonoCelular

        Dim cliente As New Clientes

        cliente = db.Clientes.Find(cliente.searchByTel(cliente_tel, db))

        global_cliente_id = cliente.ID

        txtEventoFiesta.Text = mov.EventosMovimientos.FirstOrDefault.Eventos.Descripcion
        setCheckboxesMov(mov)
        setClienteData(cliente)
        setMovArtDatasource(mov.ID)
        calculoTotales()
        blockClientControls()

        txtDeposito.Text = mov.Deposito
        btnAceptarMovimiento.Enabled = False
        btnAntMov.Enabled = True
        btnSigMov.Enabled = True
        grdViewArticulosMov.OptionsBehavior.Editable = False

    End Sub
    Public Sub setCheckboxesMov(ByVal mov As Movimientos)

        setChkMov(mov.ID, "ENTREGADO")
        setChkMov(mov.ID, "PAGADO")
        setChkMov(mov.ID, "FINALIZADO")

    End Sub

    Public Sub setChkMov(ByVal movId As Integer, ByVal estado As String)

        Dim estadoId As Integer = (From est In db.Estados Where est.Descripcion = estado Select est.ID).FirstOrDefault

        Dim estMov = (From em In db.EstadosMovimientos Where _
                            em.MovimientoId = movId And _
                            em.EstadoId = estadoId _
                            Select em).FirstOrDefault


        For Each chk As CheckEdit In gpCliente.Controls.OfType(Of CheckEdit)()

            If chk.Tag = estado Then
                If (IsNothing(estMov)) Then
                    chk.Checked = False
                Else
                    chk.Checked = True
                End If
            End If

        Next


    End Sub

    Public Sub setMovArtDatasource(ByVal movId As Integer)

        'Seteo el datasource de la grilla de movArt

        Dim movArt = (From m In db.MovimientosArticulos _
                      Where m.MovimientoId = movId _
                      Select m.ArticulosTalleStock.Articulos.Codigo, _
                      m.ArticulosTalleStock.Articulos.Descripcion, _
                      m.OperacionId, _
                      m.FecEntrega, m.FecDevolucion, _
                      m.ArticulosTalleStock.Talle, _
                      m.ArticulosTalleStock.Cantidad, _
                      m.Importe, m.Abona, m.ID).ToList

        Dim dtMovArt As DataTable = ListToDataTable(movArt)

        grdArticulosMov.DataSource = New DataView(dtMovArt)

    End Sub

    Private Sub btnNuevoAlquiler_Click(sender As Object, e As EventArgs) Handles btnNuevoAlquiler.Click

        'Nuevo alquiler en pantalla - Bloqueo y Desbloqueo generalidades
        global_cliente_id = 0
        blankErrorProviders()
        blankClientControls()
        blockClientControls()
        btnAceptarMovimiento.Enabled = True
        txtTelefonoPrincipal.Enabled = True
        btnAntMov.Enabled = False
        btnSigMov.Enabled = False
        grdViewArticulosMov.OptionsBehavior.Editable = True
        txtEventoFiesta.Enabled = True
        txtDeposito.Enabled = True
        txtEventoFiesta.Text = ""
        txtEventoFiesta.Focus()
        dtFechaMovimiento.DateTime = Date.Today
        txtNroAlquiler.Text = getMovimientoNro()
        grdArticulosMov.DataSource = Nothing
        setMovArtDatasource(0)
        grdViewArticulosMov.AddNewRow()
        grdViewArticulosMov.UpdateCurrentRow()

    End Sub

    Private Sub txtTelefonoPrincipal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelefonoPrincipal.KeyDown

        'Valido el cliente contra el telefono cuando apreto enter

        If e.KeyCode = Keys.Enter Then
            'Valido si existe el cliente con el telefono
            ValidateCliente()
        End If

    End Sub

    Private Sub setLookupTipoDoc()

        Dim srcTipoDoc = (From td In db.TipoDocumentos Select td.ID, td.Descripcion).ToList
        cmbTipoDoc.Properties.DataSource = srcTipoDoc
        setLookupProperties(cmbTipoDoc)

    End Sub

    Private Sub setLookupLocalidades()

        Dim srcLoc = (From loc In db.Localidades Select loc.ID, loc.Descripcion).ToList
        cmbLocalidad.Properties.DataSource = srcLoc
        setLookupProperties(cmbLocalidad)

    End Sub

    Private Sub ValidateCliente()

        Dim cliente_tel As String = txtTelefonoPrincipal.Text

        If cliente_tel = "" Then
            MsgBox("Debe ingresar el telefono", MsgBoxStyle.Critical)
            Return
        End If

        Dim cliente As New Clientes

        cliente = db.Clientes.Find(cliente.searchByTel(cliente_tel, db))

        'Busco al cliente por telefono. Si no existe, enableo todo para llenar datos para un nuevo cliente.
        'Si existe, seteo los datos en formulario y bloqueo los controles de datos del cliente.
        If IsNothing(cliente) Then

            unblockClientControls()
            blankClientControls()
            txtTelefonoPrincipal.Text = cliente_tel

        Else
            unblockClientControls()
            setClienteData(cliente)

        End If

        txtNombreCliente.Focus()
        blankErrorProviders()

    End Sub

    Private Sub unblockClientControls()

        For Each ctrl In gpCliente.Controls
            ctrl.Enabled = True
        Next

        txtNombreCliente.Focus()

    End Sub

    Private Sub blockClientControls()

        txtEventoFiesta.Enabled = False
        txtDeposito.Enabled = False
        For Each ctrl In gpCliente.Controls
            Dim typeCtrl = ctrl.GetType.Name
            If typeCtrl <> "LabelControl" Then
                ctrl.Enabled = False
            End If
        Next

        txtApellidoCliente.Focus()

    End Sub

    Private Sub setClienteData(ByVal cliente As Clientes)

        'Seteo los datos en formulario del cliente especificado
        txtApellidoCliente.Text = cliente.Apellido
        txtNombreCliente.Text = cliente.Nombre
        cmbTipoDoc.EditValue = cliente.TipoDocumentoId
        txtNroDoc.Text = cliente.NroDocumento
        cmbSexo.EditValue = cliente.Sexo
        txtCalle.Text = cliente.dmCalle
        txtAltura.Text = cliente.dmAltura
        txtDepto.Text = cliente.dmDepto
        cmbLocalidad.EditValue = cliente.LocalidadId
        txtPiso.Text = cliente.dmPiso
        txtCodPostal.Text = cliente.CodigoPostal
        txtTelefono2.Text = cliente.TelefonoLinea
        txtEmail.Text = cliente.Email
        txtTelefonoPrincipal.Text = cliente.TelefonoCelular
        txtObservaciones.Text = cliente.Observaciones
        dtFecNac.DateTime = cliente.FecNacimiento


    End Sub

    Private Sub setComboSexo()

        Dim cmbCol As ComboBoxItemCollection = cmbSexo.Properties.Items
        cmbCol.BeginUpdate()

        cmbCol.Add("M")
        cmbCol.Add("F")

        cmbCol.EndUpdate()
        cmbSexo.SelectedIndex = -1

    End Sub

    Private Sub btnAceptarMovimiento_Click(sender As Object, e As EventArgs) Handles btnAceptarMovimiento.Click

        'Uso transacción para mantener consistencia

        Using transaction As New TransactionScope()

            Try

                'Valido que haya completado todos los campos del cliente

                If (Not validateControls()) Then

                    MsgBox("Complete los campos obligatorios.", MsgBoxStyle.Critical)
                    Return

                End If

                If (txtEventoFiesta.Text = "") Then

                    txtEventoFiesta.Text = "SIN ESPECIFICAR"

                End If

                If (Not (existeEvento())) Then

                    Dim result = MessageBox.Show("El evento seleccionado no existe. ¿Desea crearlo?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.No Then
                        txtEventoFiesta.Focus()
                        Return
                    ElseIf result = DialogResult.Yes Then
                        createEvento()
                    End If
                End If
                Dim cliente_tel As String = txtTelefonoPrincipal.Text
                Dim movimiento_nro_solicitud As String = txtNroAlquiler.Text

                Dim cliente_id As Integer = 0
                Dim movimiento_id As Integer = 0

                Dim cliente As New Clientes
                Dim movimiento As New Movimientos

                If (global_cliente_id = 0) Then
                    cliente = db.Clientes.Find(cliente.searchByTel(cliente_tel, db))
                Else
                    cliente = db.Clientes.Find(global_cliente_id)
                End If

                movimiento = db.Movimientos.Find(movimiento.searchMovByNroSolicitud(movimiento_nro_solicitud, db))

                'Agrego o modifico al cliente
                cliente_id = createOrModifyCliente(cliente)
                'Agrego o modifico el movimiento
                movimiento_id = createOrModifyMovimiento(movimiento, cliente_id)

                Dim evento As String = txtEventoFiesta.Text
                Dim ev_id As Integer = (From ev In db.Eventos Where ev.Descripcion = evento Select ev.ID).FirstOrDefault

                Dim evMov = (From em In db.EventosMovimientos Where _
                                    em.MovimientoId = movimiento_id _
                                    Select em).FirstOrDefault

                If (IsNothing(evMov)) Then
                    evMov = New EventosMovimientos
                End If

                evMov.EventoId = ev_id
                evMov.MovimientoId = movimiento_id
                evMov.regFechaHora = getFechaHoraActual()
                evMov.regUsuarioId = 1

                db.Entry(evMov).State = If(evMov.ID = 0, EntityState.Added, EntityState.Modified)
                db.SaveChanges()

                'Valido las rows de la grilla movArt
                Dim i As Integer = 0
                Do While i < grdViewArticulosMov.RowCount
                    Dim row As DataRow = grdViewArticulosMov.GetDataRow(i)
                    If Not row Is Nothing Then
                        If (Not (validoRow(row))) Then
                            Return
                        Else
                            Dim movArtId As Integer = 0
                            If (Not (IsDBNull(row("ID")))) Then movArtId = row("ID")

                            Dim movArt As MovimientosArticulos = db.MovimientosArticulos.Find(movArtId)
                            createOrModifyMovArt(row, movimiento_id, movArt)
                        End If
                    End If
                    i += 1
                Loop

                'Si todos los datos se guardaron bien, termino la transacción
                transaction.Complete()

            Catch ex As Exception
                If ex.[GetType]() <> GetType(UpdateException) Then
                    Console.WriteLine(("Ocurrió un error. " & "La operación no se pudo hacer.") + ex.Message)
                    Exit Try
                End If
            End Try

        End Using

        MsgBox("El proceso se realizó correctamente.", MsgBoxStyle.Exclamation)

        Dim ultMov = getLastMov()
        setMovimiento(ultMov)
        Main.setMovimientosGestion()
        Main.setResumenGestion()

        'Dejo todo deshabilitado como seleccionado el proceso.


    End Sub
    Private Sub createOrModifyMovArt(ByVal row As DataRow, ByVal mov_id As Integer, ByVal movArt As MovimientosArticulos)

        If (IsNothing(movArt)) Then

            movArt = New MovimientosArticulos

        End If

        'Guardo el pedido del articulo para el movimiento pedido

        Try

            Dim codArt As String = row("Codigo")
            Dim talle As String = row("Talle")

            Dim idArt = (From a In db.Articulos Where a.Codigo = codArt Select a.ID).FirstOrDefault

            Dim aTStock = (From ats In db.ArticulosTalleStock _
                          Where ats.Talle = talle And ats.IdArticulo = idArt
                          Select ats).FirstOrDefault

            movArt.MovimientoId = mov_id
            movArt.ArticuloTalleId = aTStock.ID
            movArt.FecEntrega = row("FecEntrega")
            movArt.OperacionId = row("OperacionId")
            movArt.FecDevolucion = row("FecDevolucion")
            movArt.Abona = row("Abona")
            movArt.Cantidad = row("Cantidad")
            movArt.Importe = row("Importe")
            movArt.flgDevuelto = 0
            movArt.regUsuarioId = 1
            movArt.regFechaHora = getFechaHoraActual()
            movArt.Descripcion = "ALQUILER NORMAL"

            db.Entry(movArt).State = If(movArt.ID = 0, EntityState.Added, EntityState.Modified)
            db.SaveChanges()

        Catch ex As Exception
            MsgBox(ex.InnerException.Message)
        End Try

    End Sub

    Public Function getLastMov() As Movimientos

        'Obtengo el último movimiento realizado
        Dim ultMov = (From m In db.Movimientos Order By m.ID _
                           Descending Select m).FirstOrDefault

        Return ultMov

    End Function

    Private Function createOrModifyCliente(ByVal cliente As Clientes) As Integer

        If (IsNothing(cliente)) Then

            cliente = New Clientes
            cliente.NroCliente = cliente.getNroNuevoCliente(db)

        End If

        Try
            'Genero numero secuencial de numero de cliente (no se si lo voy a usar pero x las dudas..)


            'Si algun control falla la validacion, seteo los errorProviders y no avanzo

            cliente.Apellido = txtApellidoCliente.Text
            cliente.CodigoPostal = txtCodPostal.Text
            cliente.dmAltura = txtAltura.Text
            cliente.dmCalle = txtCalle.Text
            cliente.dmDepto = txtDepto.Text
            cliente.dmPiso = txtPiso.Text
            cliente.Email = txtEmail.Text
            cliente.FecNacimiento = dtFecNac.DateTime
            cliente.LocalidadId = cmbLocalidad.EditValue
            cliente.Nombre = txtNombreCliente.Text
            cliente.NroDocumento = txtNroDoc.Text
            cliente.Observaciones = txtObservaciones.Text
            cliente.Sexo = cmbSexo.Text
            cliente.TelefonoCelular = txtTelefonoPrincipal.Text
            cliente.TelefonoLinea = txtTelefono2.Text
            cliente.TipoDocumentoId = cmbTipoDoc.EditValue
            cliente.regFechaHora = getFechaHoraActual()
            cliente.regUsuarioId = 1

            db.Entry(cliente).State = If(cliente.ID = 0, EntityState.Added, EntityState.Modified)
            db.SaveChanges()

        Catch ex As Exception

            MsgBox(ex.InnerException.Message)

        End Try

        Return cliente.ID

    End Function

    Private Function validateControls() As Boolean

        'Valido los controles del cliente que no esten vacíos o sean erróneos

        Dim vBoolValidation = True

        For Each ctrl In gpCliente.Controls

            Dim typeCtrl = ctrl.GetType.Name
            Dim tagCtrl = ctrl.Tag

            If typeCtrl = "TextEdit" And tagCtrl = "required" Then

                If ctrl.Text.Length = 0 Then
                    errorProviderCliente.SetIconPadding(ctrl, -20)
                    errorProviderCliente.SetError(ctrl, "El campo no puede estar vacío.")
                    vBoolValidation = False
                Else
                    errorProviderCliente.SetError(ctrl, "")
                End If

                'ElseIf typeCtrl = "ComboBoxEdit" Then
                '    If ctrl.SelectedIndex = -1 Then
                '        errorProviderCliente.SetIconPadding(ctrl, -30)
                '        errorProviderCliente.SetError(ctrl, "Debe seleccionar una opción.")
                '        vBoolValidation = False
                '    Else
                '        errorProviderCliente.SetError(ctrl, "")
                '    End If

                'ElseIf typeCtrl = "LookUpEdit" Then
                '    If ctrl.ItemIndex = -1 Then
                '        errorProviderCliente.SetIconPadding(ctrl, -30)
                '        errorProviderCliente.SetError(ctrl, "Debe seleccionar una opción.")
                '        vBoolValidation = False
                '    Else
                '        errorProviderCliente.SetError(ctrl, "")
                '    End If
            End If

        Next

        Return vBoolValidation
    End Function

    Private Sub blankErrorProviders()

        For Each ctrl In gpCliente.Controls

            errorProviderCliente.SetError(ctrl, "")

        Next

    End Sub

    Private Sub blankClientControls()

        For Each ctrl In gpCliente.Controls

            Dim typeCtrl = ctrl.GetType.Name

            If typeCtrl = "TextEdit" Then
                ctrl.Text = ""
            ElseIf typeCtrl = "ComboBoxEdit" Then
                ctrl.SelectedIndex = -1
            ElseIf typeCtrl = "LookUpEdit" Then
                ctrl.EditValue = Nothing
            ElseIf typeCtrl = "DateEdit" Then
                ctrl.EditValue = Nothing
            ElseIf typeCtrl = "CheckEdit" Then
                ctrl.Checked = False
            End If

        Next

        txtDeposito.Text = 0D

    End Sub

    Private Sub setLocationErrorProviders()

        errorProviderCliente.SetIconPadding(txtApellidoCliente, -20)

    End Sub

    Private Function getMovimientoNro() As String

        'Toda la logica de los nro de alquileres. Deben respetar el formato AA01

        Dim vLetras As Char() = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()

        Dim movNroFinal As String = ""

        Dim cantMov = db.Movimientos.Count

        If cantMov = 0 Then
            Return "AA01"
        End If

        Dim ultMov = (From m In db.Movimientos Order By m.ID Descending Select m).FirstOrDefault

        Dim ultNumMov As String = ultMov.NroSolicitud

        Dim letrasUltMov As String = ultNumMov.Substring(0, 2)
        Dim numUltMov As Integer = CType(ultNumMov.Substring(2, 2), Integer)

        If numUltMov < 99 Then

            numUltMov += 1
            movNroFinal = letrasUltMov & formatNroMov(numUltMov)

        Else

            Dim primeraLetra As String = letrasUltMov.Substring(0, 1)
            Dim segundaLetra As String = letrasUltMov.Substring(1, 1)

            If (segundaLetra <> "Z") Then
                Dim sigSegundaLetra As String = getSigLetra(vLetras, segundaLetra)
                movNroFinal = primeraLetra & sigSegundaLetra & "01"
            Else
                Dim sigPrimeraLetra As String = getSigLetra(vLetras, primeraLetra)
                movNroFinal = sigPrimeraLetra & "A01"
            End If

        End If

        Return movNroFinal

    End Function

    Private Function getSigLetra(ByVal vLetras As Char(), ByVal letra As String)

        'Obtengo la siguiente letra del abecedario

        Dim sigLetra As String = ""

        For i As Integer = 0 To vLetras.Length

            If vLetras(i) = letra Then

                sigLetra = vLetras(i + 1)

                Return sigLetra

            End If

        Next

        Return ""

    End Function

    Private Function formatNroMov(ByVal nroMov As Integer) As String

        'Formateo los nro de movimientos por si son menores que 10, agregarle un 0 antes.
        Dim nroMovStr As String = ""

        If nroMov < 10 Then
            nroMovStr = "0" & nroMov.ToString
        Else
            nroMovStr = nroMov.ToString
        End If

        Return nroMovStr

    End Function

    Private Sub setAutocompleteEventos()

        Dim colAutoComplete As New AutoCompleteStringCollection

        Dim eventos = From e In db.Eventos Where e.FechaEvento > Date.Today Or _
                             e.Descripcion = "SIN ESPECIFICAR" Select e

        For Each ev In eventos

            colAutoComplete.Add(ev.Descripcion)

        Next

        txtEventoFiesta.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtEventoFiesta.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtEventoFiesta.MaskBox.AutoCompleteCustomSource = colAutoComplete

    End Sub

    Private Sub grdViewArticulosMov_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdViewArticulosMov.CellValueChanged
        Dim fieldName As String = e.Column.FieldName
        Select Case fieldName
            Case "Abona"

                calculoTotales()

        End Select
    End Sub

    Private Sub grdViewArticulosMov_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdViewArticulosMov.CellValueChanging

        Dim fieldName As String = e.Column.FieldName
        Select Case fieldName

            Case "Codigo"

                Dim cod As String = e.Value

                'createLookupTalle()

                Dim disfraz = (From a In db.Articulos Where a.Codigo = cod Select a.Descripcion).FirstOrDefault

                validarDisfrazDatagrid("Descripcion", disfraz, e.RowHandle)

                setDefaultValuesInGrid(e.RowHandle)

                grdViewArticulosMov.SetRowCellValue(e.RowHandle, "Codigo", e.Value)

                grdViewArticulosMov.SetRowCellValue(e.RowHandle, "Talle", Nothing)

            Case "Talle"

                setDefaultValuesInGrid(e.RowHandle)

            Case "Descripcion"

                Dim desc As String = e.Value

                Dim disfraz = (From a In db.Articulos Where a.Descripcion = desc Select a.Codigo).FirstOrDefault

                'createLookupTalle()

                validarDisfrazDatagrid("Codigo", disfraz, e.RowHandle)

                setDefaultValuesInGrid(e.RowHandle)

                grdViewArticulosMov.SetRowCellValue(e.RowHandle, "Descripcion", e.Value)

                grdViewArticulosMov.SetRowCellValue(e.RowHandle, "Talle", Nothing)

            Case "Abona"

                calculoTotales()

            Case "FecEntrega"

                Dim dateDevolucion As DateTime = getFechaDevolucion(e.Value)
                grdViewArticulosMov.SetRowCellValue(e.RowHandle, "FecDevolucion", dateDevolucion)
                grdViewArticulosMov.SetRowCellValue(e.RowHandle, "Talle", Nothing)
                setDefaultValuesInGrid(e.RowHandle)

            Case "FecDevolucion"

                grdViewArticulosMov.SetRowCellValue(e.RowHandle, "Talle", Nothing)
                setDefaultValuesInGrid(e.RowHandle)

            Case "OperacionId"

                Dim rowHandle As Integer = grdViewArticulosMov.FocusedRowHandle

                If (e.Value = 3) Then

                    grdViewArticulosMov.SetRowCellValue(rowHandle, "FecEntrega", Date.Today)
                    grdViewArticulosMov.SetRowCellValue(rowHandle, "FecDevolucion", Date.Today)
                    grdViewArticulosMov.SetRowCellValue(rowHandle, "Talle", "UNICO")
                Else
                    grdViewArticulosMov.SetRowCellValue(rowHandle, "Talle", Nothing)
                    grdViewArticulosMov.SetRowCellValue(rowHandle, "FecEntrega", Nothing)
                    grdViewArticulosMov.SetRowCellValue(rowHandle, "FecDevolucion", Nothing)
                End If

                grdViewArticulosMov.SetRowCellValue(rowHandle, "OperacionId", e.Value)

        End Select

    End Sub

    Private Sub validarDisfrazDatagrid(ByVal campo As String, ByVal disfraz As String, ByVal rowHandle As Integer)

        If IsNothing(disfraz) Then
            MsgBox("No se encuentra el disfraz especificado", MsgBoxStyle.Critical)
        Else
            grdViewArticulosMov.SetRowCellValue(rowHandle, campo, disfraz)
        End If

    End Sub
    Private Sub createCmbTalle()

        Dim cmbTalle As New RepositoryItemComboBox
        Dim qTalle = (From ats In db.ArticulosTalleStock Select ats.Talle).Distinct.ToList

        For Each talle In qTalle
            cmbTalle.Items.Add(talle.ToString)
        Next
        cmbTalle.TextEditStyle = TextEditStyles.DisableTextEditor
        grdViewArticulosMov.Columns("Talle").ColumnEdit = cmbTalle

    End Sub

    Private Sub grdViewArticulosMov_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles grdViewArticulosMov.CustomColumnDisplayText


        Dim field = e.Column.FieldName
        If (field = "Importe" Or field = "Abona" Or field = "Restan") Then

            Dim valor = grdViewArticulosMov.GetRowCellValue(e.RowHandle, grdViewArticulosMov.Columns(field))
            If Not (IsDBNull(valor)) Then
                valor = CDec(valor)
                e.DisplayText = String.Format(ciUSA, "{0:c}", valor)
            End If

        End If
    End Sub

    Private Sub calculoTotales()

        'Calculo los totales de los articulos seleccionados para el movimiento

        Dim i As Integer = 0
        Dim acFacturado As Double
        Dim acCobrado As Double
        Do While i < grdViewArticulosMov.RowCount
            Dim importe As Double = grdViewArticulosMov.GetRowCellValue(i, grdViewArticulosMov.Columns("Importe"))
            Dim abona As Double = grdViewArticulosMov.GetRowCellValue(i, grdViewArticulosMov.Columns("Abona"))
            acFacturado += CDbl(importe)
            acCobrado += abona
            i += 1
        Loop

        Dim totPendiente As Double = acFacturado - acCobrado

        txtTotFacturado.Text = String.Format(ciUSA, "{0:c}", acFacturado)
        txtTotCobrado.Text = String.Format(ciUSA, "{0:c}", acCobrado)
        txtTotPendiente.Text = String.Format(ciUSA, "{0:c}", totPendiente)
        txtDeposito.Text = acFacturado

    End Sub

    Private Sub grdViewArticulosMov_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles grdViewArticulosMov.InitNewRow

        setDefaultValuesInGrid(e.RowHandle)
        grdViewArticulosMov.SetRowCellValue(e.RowHandle, "Talle", Nothing)

    End Sub

    Private Sub setDefaultValuesInGrid(ByVal rowHandle As Integer)

        grdViewArticulosMov.SetRowCellValue(rowHandle, "Importe", 0)
        grdViewArticulosMov.SetRowCellValue(rowHandle, "Abona", 0)
        grdViewArticulosMov.SetRowCellValue(rowHandle, "Cantidad", 0)

    End Sub

    Private Sub RepositoryItemComboBox2_SelectedValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemComboBox2.SelectedValueChanged

        'Aca veo si hay stock, si hay, calculo el importe

        Dim edit As ComboBoxEdit = DirectCast(sender, ComboBoxEdit)
        Dim editValue As Object = edit.EditValue

        'Cálculo de importe ->
        Dim rowHandle = grdViewArticulosMov.FocusedRowHandle
        Dim dataRow = grdViewArticulosMov.GetDataRow(rowHandle)
        Dim objCodArt = dataRow("Codigo")
        Dim objTalle = dataRow("Talle")
        Dim objFecEntrega = dataRow("FecEntrega")
        Dim objFecDevolucion = dataRow("FecDevolucion")
        Dim cant = editValue
        Dim stockDisponible As Integer

        If (cant > 0) Then

            cant = CInt(cant)

            If (Not (IsDBNull(objCodArt)) And Not (IsDBNull(objTalle)) And Not (IsDBNull(objFecEntrega)) And Not (IsDBNull(objFecDevolucion))) Then

                Dim talle As String = CStr(objTalle)
                Dim codArt As String = CStr(objCodArt)

                Dim ats = (From a In db.ArticulosTalleStock Where a.Articulos.Codigo = codArt _
                              And a.Talle = talle Select a).FirstOrDefault

                If (Not (IsNothing(ats))) Then

                    If (IsDBNull(dataRow("ID"))) Then
                        stockDisponible = getStock(ats, objFecEntrega, objFecDevolucion, db)
                    Else
                        stockDisponible = getStock(ats, objFecEntrega, objFecDevolucion, db, dataRow("ID"))
                    End If

                    If (cant > stockDisponible) Then

                        MsgBox("No hay stock.", MsgBoxStyle.Critical)
                        grdViewArticulosMov.SetRowCellValue(rowHandle, "Cantidad", 0)

                    Else

                        Dim importe As Double = ats.Articulos.Precio
                        Dim impTotal As Double = importe * cant
                        dataRow("Importe") = impTotal

                        Dim operacionId = grdViewArticulosMov.GetRowCellValue(rowHandle, "OperacionId")
                        If operacionId = 3 Then
                            dataRow("Abona") = impTotal
                        End If


                    End If

                Else

                    MsgBox("No hay stock.", MsgBoxStyle.Critical)
                    grdViewArticulosMov.SetRowCellValue(rowHandle, "Cantidad", 0)

                End If

            Else
                grdViewArticulosMov.SetRowCellValue(rowHandle, "Cantidad", 0)
                MsgBox("Ingrese código, talle y fechas antes de ingresar la cantidad", MsgBoxStyle.Critical)

            End If

        Else

            grdViewArticulosMov.SetRowCellValue(rowHandle, "Importe", 0)
            grdViewArticulosMov.SetRowCellValue(rowHandle, "Cantidad", 0)

        End If

    End Sub

    Private Function validateCompleteRows() As Boolean

        Dim i As Integer = 0
        Do While i < grdViewArticulosMov.RowCount
            Dim row As DataRow = grdViewArticulosMov.GetDataRow(i)
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

        For i As Integer = 0 To 5

            If (IsDBNull(row.ItemArray.GetValue(i))) Then

                Dim col As String = row.Table.Columns(i).ColumnName

                makeErrorInvalidColumn(col)

                Return False

            End If

        Next

        If (row.ItemArray.GetValue(6) = 0) Then

            Dim col As String = row.Table.Columns(4).ColumnName

            makeErrorInvalidColumn(col)

            Return False

        End If


        For i As Integer = 7 To 8

            If (row.ItemArray.GetValue(i) = 0D) Then

                Dim col As String = row.Table.Columns(i).ColumnName

                makeErrorInvalidColumn(col)

                Return False

            End If

        Next


        Return True

    End Function

    Public Sub makeErrorInvalidColumn(ByVal col As String)

        Dim msjError = "Para agregar un nuevo artículo, complete el campo " & col & "."

        MsgBox(msjError, MsgBoxStyle.Critical)

    End Sub

    Private Sub frmRetiros_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F2 Then
            If (grdViewArticulosMov.OptionsBehavior.Editable) Then
                If Not (IsNothing(grdViewArticulosMov.DataSource)) Then
                    If validateCompleteRows() Then

                        grdViewArticulosMov.AddNewRow()
                        grdViewArticulosMov.UpdateCurrentRow()

                    End If
                End If
            End If
        End If
    End Sub


    Private Sub btnCancelarMov_Click(sender As Object, e As EventArgs) Handles btnCancelarMov.Click

        Dim ultMov = getLastMov()
        setMovimiento(ultMov)

    End Sub


    Private Sub btnAntMov_Click(sender As Object, e As EventArgs) Handles btnAntMov.Click

        Dim movId As Integer = getActualMovId()

        Dim movAnt = (From m In db.Movimientos Where m.ID < movId
                      Order By m.ID Descending Select m).FirstOrDefault

        If Not (IsNothing(movAnt)) Then setMovimiento(movAnt)

    End Sub

    Private Sub btnSigMov_Click(sender As Object, e As EventArgs) Handles btnSigMov.Click

        Dim movId As Integer = getActualMovId()

        Dim movSig = (From m In db.Movimientos Where m.ID > movId
                      Order By m.ID Ascending Select m).FirstOrDefault

        If Not (IsNothing(movSig)) Then setMovimiento(movSig)

    End Sub

    Private Function getActualMovId() As Integer

        Dim movActual As String = txtNroAlquiler.Text

        Dim movActualId As Integer = (From m In db.Movimientos Where _
                           m.NroSolicitud = movActual Select m.ID).FirstOrDefault

        Return movActualId

    End Function

    Private Sub setFormatTextEdit()

        For Each ctrl In gpCliente.Controls

            Dim typeCtrl = ctrl.GetType.Name
            If typeCtrl = "TextEdit" Then

                ctrl.Properties.AppearanceFocused.BackColor = Color.LemonChiffon
                ctrl.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
                ctrl.Properties.Mask.EditMask = "(\p{Lu}|\W|\d|\s)+"

            End If
        Next


    End Sub

    Private Function createOrModifyMovimiento(ByVal mov As Movimientos, ByVal cliente_id As Integer) As Integer

        If (IsNothing(mov)) Then

            mov = New Movimientos

        End If

        Try

            mov.ClienteId = cliente_id
            mov.NroSolicitud = txtNroAlquiler.Text
            mov.regUsuarioId = 1
            mov.FecMovimiento = dtFechaMovimiento.DateTime
            mov.FecAnticipo = dtFechaMovimiento.DateTime
            mov.Deposito = CDec(txtDeposito.Text)
            mov.Observaciones = txtObservaciones.Text
            mov.ImpAnticipo = 0
            mov.regFechaHora = getFechaHoraActual()


            db.Entry(mov).State = If(mov.ID = 0, EntityState.Added, EntityState.Modified)
            db.SaveChanges()

            saveMovimientosEstados(mov)

        Catch ex As Exception

            MsgBox(ex.InnerException.Message)

        End Try

        Return mov.ID

    End Function

    Private Sub btnModifAlquiler_Click(sender As Object, e As EventArgs) Handles btnModifAlquiler.Click

        Dim nroMov As String = txtNroAlquiler.Text

        Dim mov As Movimientos = New Movimientos

        Dim mov_id As Integer = mov.searchMovByNroSolicitud(nroMov, db)

        mov = db.Movimientos.Find(mov_id)

        If (IsNothing(mov)) Then

            MsgBox("Debe seleccionar un movimiento válido para modificarlo.")

        Else

            setMovimiento(mov)
            unblockClientControls()
            btnAceptarMovimiento.Enabled = True
            txtTelefonoPrincipal.Enabled = True
            grdViewArticulosMov.OptionsBehavior.Editable = True
            txtEventoFiesta.Enabled = True
            txtDeposito.Enabled = True

        End If

    End Sub

    Private Function existeEvento() As Boolean

        Dim str_evento As String = txtEventoFiesta.Text

        Dim evento = (From e In db.Eventos Where e.Descripcion = str_evento Select e).FirstOrDefault

        If (IsNothing(evento)) Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub createEvento()

        Dim evento As Eventos = New Eventos
        evento.Descripcion = txtEventoFiesta.Text
        evento.Contacto = txtApellidoCliente.Text & ", " & txtNombreCliente.Text
        evento.Direccion = txtCalle.Text & " " & txtAltura.Text & " " & txtPiso.Text & " " & txtDepto.Text
        evento.Telefono = txtTelefonoPrincipal.Text
        evento.TipoEvento = 1
        evento.regUsuarioId = 1
        evento.FechaEvento = dtFechaMovimiento.DateTime
        evento.regFechaHora = getFechaHoraActual()

        db.Eventos.Add(evento)
        db.SaveChanges()

    End Sub

    Private Sub saveMovimientosEstados(ByVal mov As Movimientos)

        setMovEstado(mov.ID, "ENTREGADO", chkEntregado.Checked)
        setMovEstado(mov.ID, "PAGADO", chkPagado.Checked)
        setMovEstado(mov.ID, "FINALIZADO", chkFinalizado.Checked)

    End Sub

    Private Sub setMovEstado(ByVal movId As Integer, ByVal estado As String, ByVal isChecked As Boolean)

        Dim estadoId As Integer = (From est In db.Estados Where est.Descripcion = estado Select est.ID).FirstOrDefault

        Dim estMov = (From em In db.EstadosMovimientos Where _
                            em.MovimientoId = movId And _
                            em.EstadoId = estadoId _
                            Select em).FirstOrDefault

        If (isChecked) Then
            If (IsNothing(estMov)) Then
                Try
                    Dim objEstMov As EstadosMovimientos = New EstadosMovimientos
                    objEstMov.MovimientoId = movId
                    objEstMov.EstadoId = estadoId
                    objEstMov.regFechaHora = getFechaHoraActual()
                    objEstMov.regUsuarioId = 1
                    db.EstadosMovimientos.Add(objEstMov)
                    db.SaveChanges()
                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                End Try

            End If
        Else
            If (Not (IsNothing(estMov))) Then
                Try
                    db.EstadosMovimientos.Remove(estMov)
                    db.SaveChanges()
                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                End Try

            End If
        End If

    End Sub

End Class