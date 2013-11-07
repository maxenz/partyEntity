Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors.Controls
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Linq

Public Class Main

    Private db As PartyIdeaEntities

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
            UserLookAndFeel.Default.SetSkinStyle("Office 2007 Green")


        Catch ex As Exception
            '    HandleError(Me.Name, "Main_Load", ex)
        End Try

    End Sub

    Private Sub ShowDocument(ByVal pFrm As DevExpress.XtraEditors.XtraForm)
        Try
            Me.vewForms.BeginUpdate()
            Me.vewForms.AddDocument(pFrm)
            Me.vewForms.AddDocument(frmEstadisticas)
            frmEstadisticas.Visible = False
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

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem17.ItemClick

        Dim loc = db.Localidades.Find(27)

        For Each Cliente In loc.Clientes
            MsgBox(Cliente.Localidades.Descripcion)

        Next

        Dim genPrueba = db.Generos.Find(8)

        genPrueba.Descripcion = "hola"

        db.SaveChanges()






    End Sub
End Class