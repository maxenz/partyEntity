Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors.Controls
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.TileControl
Imports DevExpress.XtraBars.Alerter
Imports System.Linq
Imports System.Resources
Imports System.Reflection
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class Main

    Private db As PartyIdeaEntities
    Dim defController As ToolTipController = ToolTipController.DefaultController

    Private Sub Main_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Try
            Global.System.Windows.Forms.Application.Exit()
        Catch ex As Exception
            'HandleError(Me.Name, "Main_FormClosed", ex)
        End Try

    End Sub

    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Me.dockForms.View.Documents.Clear()

    End Sub

    Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        db = New PartyIdeaEntities

        Try       
            ShowDocument(frmRetiros)
            'ShowDocument(frmAlquileres)
            setFilterDisfraces()
            setItemsGalleryDisfraces()
            UserLookAndFeel.Default.SetSkinStyle("Office 2007 Green")
            formatTooltipGallery()
            setComboEstGestion()
            formatGridGestion()
            formatGridResumenGestion()
            setResumenGestion()

        Catch ex As Exception
            'HandleError(Me.Name, "Main_Load", ex)
        End Try

    End Sub

    Private Sub ShowDocument(ByVal pFrm As DevExpress.XtraEditors.XtraForm)
        Try
            Me.vewForms.BeginUpdate()
            Me.vewForms.AddDocument(pFrm)
            'Me.vewForms.AddDocument(frmEstadisticas)
            'Me.vewForms.AddDocument(frmAlquileres)
            'frmAlquileres.Visible = False
            'frmEstadisticas.Visible = False
            Me.vewForms.EndUpdate()
        Catch ex As Exception
            'HandleError(Me.Name, "ShowDocument", ex)
        End Try

    End Sub

    Public Sub New()

        InitSkins()
        InitializeComponent()
        Me.InitSkinGallery()

    End Sub

    Sub InitSkins()

        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.BonusSkins.Register()


    End Sub
    Private Sub InitSkinGallery()
        SkinHelper.InitSkinGallery(rgbiSkins, True)

    End Sub

    Private Sub btnCerrar_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCerrar.ItemClick
        Me.Close()
    End Sub

    Private Sub btnEntidadesPrestacion_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEntidadesPrestacion.ItemClick
        'ShowDocument(frmTabPrestaciones)
    End Sub

    Private Sub btnDespacho_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDespacho.ItemClick
        'ShowDocument(frmIncidentes)
    End Sub

    Public Sub ShowGuardarExcel(ByVal pGrid As DevExpress.XtraPivotGrid.PivotGridControl, ByVal pGrf As DevExpress.XtraCharts.ChartControl)
        'Try
        '    Me.dlgGuardar.Title = "Establezca el destino de su archivo"
        '    Me.dlgGuardar.Filter = "Archivos Excel (*.xls)|*.xls"
        '    Me.dlgGuardar.ShowDialog()
        '    If Me.dlgGuardar.FileName <> "" Then
        '        pGrid.ExportToXls(Me.dlgGuardar.FileName)
        '        Dim vExcelGrf As String = Me.dlgGuardar.FileName
        '        vExcelGrf = Parcer(vExcelGrf, ".") & " Grafico." & Parcer(vExcelGrf, ".", 1)
        '        pGrf.ExportToXls(vExcelGrf)
        '        MsgBox("Se generaron corractemente los archivos " & vbCrLf & Me.dlgGuardar.FileName & ", " & vbCrLf & vExcelGrf, MsgBoxStyle.Information, "Exportación")
        '    End If
        'Catch ex As Exception
        '    HandleError(Me.Name, "ShowGuardarExcel", ex)
        'End Try
    End Sub

    Private Sub btnOfertaDemanda_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOfertaDemanda.ItemClick
        'ShowDocument(frmTabOfertaDemanda)
    End Sub



    Private Sub BarButtonItem31_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem31.ItemClick

        frmEstadisticas.ChartControl1.Visible = True
        frmEstadisticas.ChartControl3.Visible = False
        frmEstadisticas.ChartControl2.Visible = False

    End Sub

    Private Sub BarButtonItem32_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem32.ItemClick

        frmEstadisticas.ChartControl1.Visible = False
        frmEstadisticas.ChartControl3.Visible = False
        frmEstadisticas.ChartControl2.Visible = True

    End Sub

    Private Sub BarButtonItem33_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem33.ItemClick
        frmEstadisticas.ChartControl1.Visible = False
        frmEstadisticas.ChartControl3.Visible = True
        frmEstadisticas.ChartControl2.Visible = False
    End Sub

    Private Sub ribbonMain_SelectedPageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ribbonMain.SelectedPageChanged

        Dim vPage As RibbonControl = CType(sender, RibbonControl)

        If vPage.SelectedPage.Name = "RibbonPage1" Then
            frmEstadisticas.Visible = True
            frmRetiros.Visible = False
        Else
            frmEstadisticas.Visible = False
            frmRetiros.Visible = True
        End If


    End Sub

    Private Sub setFilterDisfraces()

        Dim qCat = (From c In db.Categorias Select c.ID, c.Descripcion).ToList
        lkFiltroCat.Properties.DataSource = qCat
        setLookupProperties(lkFiltroCat)
        lkFiltroCat.Text = "DISFRAZ MUJER"

        dtFiltroGaleria.Properties.ShowClear = False
        dtFiltroGaleria.DateTime = Date.Today

        Dim qGenero = (From g In db.Generos Select g.ID, g.Descripcion).ToList
        lkFiltroGen.Properties.DataSource = qGenero
        setLookupProperties(lkFiltroGen)

    End Sub

    Private Sub btnFiltrarDisfraces_Click(sender As Object, e As EventArgs) Handles btnFiltrarDisfraces.Click

        setItemsGalleryDisfraces()

    End Sub

    Private Sub setItemsGalleryDisfraces()

        TileGroup1.Items.Clear()
        tileGaleria.Refresh()

        Dim cat_id As Integer = lkFiltroCat.EditValue

        Dim qArt = db.Articulos.Where(Function(a) a.CategoriaId = cat_id).ToList

        If Not (IsNothing(lkFiltroGen.EditValue)) Then

            Dim id_gen As Integer = lkFiltroGen.EditValue

            qArt = qArt.Where(Function(a) a.GeneroId = id_gen).ToList()

        End If

        For Each art In qArt

            Dim img = My.Resources.ResourceManager.GetObject(art.ImageUrl)

            If (Not IsNothing(img)) Then

                Dim tItem As TileItem = New TileItem()

                TileGroup1.Items.Add(tItem)
                Dim tItemElement As TileItemElement = New TileItemElement
                tItemElement.Image = CType(img, System.Drawing.Image)
                tItemElement.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch
                tItem.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
                tItem.Id = art.ID
                tItem.Name = "TileItem" & art.Descripcion
                tItem.Padding = New System.Windows.Forms.Padding(0)
                tItem.Elements.Add(tItemElement)

            End If

        Next

    End Sub

    Private Sub tileGaleria_Click(sender As Object, e As MouseEventArgs) Handles tileGaleria.MouseClick

        Dim control As TileControl = TryCast(sender, TileControl)
        Dim item As TileItem = control.SelectedItem

        Dim id_art As Integer = item.Id
        Dim qItem = db.Articulos.Find(id_art)
        Dim fechaDesde As DateTime = dtFiltroGaleria.DateTime
        Dim fechaHasta As DateTime = getFechaDevolucion(fechaDesde)
        Dim hi As TileControlHitInfo = control.CalcHitInfo(control.PointToClient(MousePosition))
        If hi.InItem Then
            Dim msj As String = ""
            For Each ats In qItem.ArticulosTalleStock.ToList
                Dim strCant As String = ""
                Dim cant As Integer = getStock(ats, fechaDesde, fechaHasta, db)
                If cant = 0 Then
                    strCant = ", Stock: " & "<color=red><b>" & cant & "</b></color>"
                Else
                    strCant = ", Stock: " & cant
                End If
                msj = msj & "<size=12>Talle: " & ats.Talle & strCant & "</size>" & Environment.NewLine
            Next
            defController.ShowHint(msj, MousePosition)
        Else
            defController.HideHint()
        End If

    End Sub

    Private Sub formatTooltipGallery()

        defController.Appearance.BackColor = Color.Orange
        defController.Rounded = True
        defController.ShowBeak = True
        defController.AllowHtmlText = True

    End Sub

    Private Sub setComboEstGestion()

        Dim cmbCol As ComboBoxItemCollection = cmbEstadosGestion.Properties.Items
        cmbCol.BeginUpdate()

        cmbCol.Add("ALQUILADOS")
        cmbCol.Add("RESERVADOS")
        cmbCol.Add("TODOS")

        cmbCol.EndUpdate()
        cmbEstadosGestion.SelectedIndex = 2

    End Sub

    Private Sub cmbEstadosGestion_EditValueChanged(sender As Object, e As EventArgs) Handles cmbEstadosGestion.EditValueChanged

        setMovimientosGestion()

    End Sub

    Public Sub setMovimientosGestion()

        Dim optFilter As String = cmbEstadosGestion.SelectedText

        Dim operacion As Operaciones = getOperacionByDesc(optFilter, db)

        Dim operacionId As Integer = 0

        If (Not (IsNothing(operacion))) Then

            operacionId = operacion.ID

        End If

        Dim lstMovGestion As List(Of MovimientosGestion) = getListMovGestion()

        lstMovGestion = (lstMovGestion.Where(Function(mg) mg.OperacionId <> 3)).ToList

        If operacionId <> 0 Then 'Si tengo que filtrar, porque no está TODOS -->

            lstMovGestion = (lstMovGestion.Where(Function(mg) mg.OperacionId = operacionId)).ToList

        End If

        lstMovGestion = (lstMovGestion.OrderBy(Function(mg) mg.FecDevolucion)).ToList
        lstMovGestion = (lstMovGestion.OrderBy(Function(mg) mg.OperacionId)).ToList

        Dim dtMovGestion As DataTable = ListToDataTable(lstMovGestion)

        grdGestion.DataSource = New DataView(dtMovGestion)


    End Sub

    Private Function getListMovGestion() As List(Of MovimientosGestion)

        Dim colMovNoFinalizados As Collection = New Collection

        Dim estFinalizado As Estados = getEstadoByDesc("FINALIZADO", db)

        Dim idFinalizado As Integer = estFinalizado.ID

        Dim mov = (From m In db.Movimientos Select m.ID Distinct).ToList

        For Each idMov As Integer In mov

            Dim movFlz = (From eMov In db.EstadosMovimientos Where _
                        eMov.MovimientoId = idMov And _
                        eMov.EstadoId = idFinalizado).FirstOrDefault

            If (IsNothing(movFlz)) Then

                colMovNoFinalizados.Add(idMov)

            End If

        Next

        Dim lstMovGestion As List(Of MovimientosGestion) = New List(Of MovimientosGestion)

        For Each idMov As Integer In colMovNoFinalizados

            Dim qMov = (From movArt In db.MovimientosArticulos Where _
                       movArt.MovimientoId = idMov _
                       Select New MovimientosGestion With { _
                            .Gestion = movArt.Movimientos.NroSolicitud, _
                            .Cliente = String.Concat(movArt.Movimientos.Clientes.Apellido, _
                                                     ", ", movArt.Movimientos.Clientes.Nombre), _
                            .Disfraz = movArt.ArticulosTalleStock.Articulos.Descripcion,
                            .OperacionId = movArt.OperacionId,
                            .FecDevolucion = movArt.FecDevolucion,
                            .MovId = movArt.MovimientoId,
                            .Estado = movArt.Movimientos.EstadosMovimientos.FirstOrDefault.Estados.Descripcion
                        }).ToList()


            For Each movArt As MovimientosGestion In qMov

                lstMovGestion.Add(movArt)

            Next

        Next

        Return lstMovGestion

    End Function

    Private Sub formatGridGestion()

        grdViewMovGestion.OptionsView.ShowGroupPanel = False
        grdViewMovGestion.OptionsBehavior.Editable = False
        grdViewMovGestion.Columns(0).Width = 30
        grdViewMovGestion.Columns(3).Visible = False
        grdViewMovGestion.Columns(4).Visible = False
        grdViewMovGestion.Columns(5).Visible = False
        grdViewMovGestion.Columns(0).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
        grdViewMovGestion.Columns(6).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
        grdViewMovGestion.OptionsSelection.EnableAppearanceFocusedCell = False
        grdViewMovGestion.OptionsSelection.EnableAppearanceFocusedRow = False

    End Sub

    Private Sub formatGridResumenGestion()

        grdViewResumenGestion.OptionsView.ShowGroupPanel = False
        grdViewResumenGestion.OptionsBehavior.Editable = False
        grdViewResumenGestion.OptionsBehavior.ReadOnly = True

    End Sub

    Private Sub grdViewMovGestion_DoubleClick(sender As Object, e As EventArgs) Handles grdViewMovGestion.DoubleClick

        Dim view As GridView = CType(sender, GridView)

        Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)

        DoRowDoubleClick(view, pt)

    End Sub


    Private Sub DoRowDoubleClick(ByVal view As GridView, ByVal pt As Point)

        Dim info As GridHitInfo = view.CalcHitInfo(pt)

        Dim movId As Integer = view.GetRowCellValue(info.RowHandle, "MovId")

        Dim mov As Movimientos = db.Movimientos.Find(movId)

        frmRetiros.setMovimiento(mov)

    End Sub

    Private Sub grdViewMovGestion_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles grdViewMovGestion.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            e.Appearance.ForeColor = Color.White
            Dim operacionId As Integer = View.GetRowCellDisplayText(e.RowHandle, View.Columns("OperacionId"))
            If (operacionId = 1) Then
                Dim fecDevolucion As DateTime = View.GetRowCellDisplayText(e.RowHandle, View.Columns("FecDevolucion"))
                If Date.Today > fecDevolucion Then
                    e.Appearance.BackColor = Color.Tomato
                Else
                    e.Appearance.BackColor = Color.DeepSkyBlue
                End If
            Else
                e.Appearance.BackColor = Color.MediumSeaGreen
            End If
        End If
    End Sub

    Public Sub setResumenGestion()

        Dim lstMovGestion As List(Of MovimientosGestion) = getListMovGestion()

        Dim cantAlqDeudores As Integer = (lstMovGestion.Where(Function(mg) mg.OperacionId = 1).Where(Function(mg) mg.FecDevolucion < Date.Today)).Count
        Dim cantAlqNormales As Integer = ((lstMovGestion.Where(Function(mg) mg.OperacionId = 1)).Count - cantAlqDeudores)
        Dim cantReservados As Integer = (lstMovGestion.Where(Function(mg) mg.OperacionId = 2)).Count

        Dim lstResumen As List(Of MovimientosResumen) = New List(Of MovimientosResumen)

        Dim resAlqDeudores As MovimientosResumen = New MovimientosResumen
        resAlqDeudores.Estado = "ALQUILER NO DEVUELTO"
        resAlqDeudores.Color = "ROJO"
        resAlqDeudores.Cantidad = cantAlqDeudores

        Dim resAlqNormales As MovimientosResumen = New MovimientosResumen
        resAlqNormales.Estado = "ALQUILER EN TRANSCURSO"
        resAlqNormales.Color = "AZUL"
        resAlqNormales.Cantidad = cantAlqNormales

        Dim resReservas As MovimientosResumen = New MovimientosResumen
        resReservas.Estado = "RESERVA"
        resReservas.Color = "VERDE"
        resReservas.Cantidad = cantReservados

        lstResumen.Add(resAlqDeudores)
        lstResumen.Add(resAlqNormales)
        lstResumen.Add(resReservas)

        Dim dtResumenMovGestion As DataTable = ListToDataTable(lstResumen)

        grdResumenGestion.DataSource = New DataView(dtResumenMovGestion)

        grdViewResumenGestion.Columns(0).Visible = False
        grdViewResumenGestion.OptionsSelection.EnableAppearanceFocusedCell = False
        grdViewResumenGestion.OptionsSelection.EnableAppearanceFocusedRow = False
        grdViewResumenGestion.Columns(2).Width = 50
        grdViewResumenGestion.Columns(2).AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

    End Sub

    Private Sub grdViewResumenGestion_RowStyle(sender As Object, e As RowStyleEventArgs) Handles grdViewResumenGestion.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            e.Appearance.ForeColor = Color.White
            Dim rowColor As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Color"))
            If rowColor = "ROJO" Then
                e.Appearance.BackColor = Color.Tomato
            ElseIf rowColor = "VERDE" Then
                e.Appearance.BackColor = Color.MediumSeaGreen
            Else
                e.Appearance.BackColor = Color.DeepSkyBlue
            End If
        End If

    End Sub


End Class