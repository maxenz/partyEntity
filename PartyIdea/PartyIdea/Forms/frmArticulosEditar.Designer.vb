<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArticulosEditar
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArticulosEditar))
        Me.txtObservArt = New DevExpress.XtraEditors.TextEdit()
        Me.txtPrecioArt = New DevExpress.XtraEditors.TextEdit()
        Me.txtValorAdqArt = New DevExpress.XtraEditors.TextEdit()
        Me.txtDescripcionArt = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.lkCategArt = New DevExpress.XtraEditors.LookUpEdit()
        Me.lkGeneroArt = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProcedenciaArt = New DevExpress.XtraEditors.TextEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.grdTallesCantidad = New DevExpress.XtraGrid.GridControl()
        Me.grdViewTallesCant = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnAceptarArt = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelarArt = New DevExpress.XtraEditors.SimpleButton()
        Me.gpArticulos = New DevExpress.XtraEditors.GroupControl()
        Me.btnCargarImagen = New DevExpress.XtraEditors.ButtonEdit()
        Me.errorProviderArticulos = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.picEdArticulo = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.txtObservArt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecioArt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorAdqArt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcionArt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkCategArt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkGeneroArt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProcedenciaArt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.grdTallesCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewTallesCant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpArticulos.SuspendLayout()
        CType(Me.btnCargarImagen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errorProviderArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picEdArticulo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtObservArt
        '
        Me.txtObservArt.EnterMoveNextControl = True
        Me.txtObservArt.Location = New System.Drawing.Point(80, 124)
        Me.txtObservArt.Name = "txtObservArt"
        Me.txtObservArt.Size = New System.Drawing.Size(477, 20)
        Me.txtObservArt.TabIndex = 7
        '
        'txtPrecioArt
        '
        Me.txtPrecioArt.EnterMoveNextControl = True
        Me.txtPrecioArt.Location = New System.Drawing.Point(493, 82)
        Me.txtPrecioArt.Name = "txtPrecioArt"
        Me.txtPrecioArt.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPrecioArt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtPrecioArt.Properties.DisplayFormat.FormatString = "c"
        Me.txtPrecioArt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPrecioArt.Properties.Mask.EditMask = "c"
        Me.txtPrecioArt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPrecioArt.Size = New System.Drawing.Size(64, 20)
        Me.txtPrecioArt.TabIndex = 5
        Me.txtPrecioArt.Tag = "required"
        '
        'txtValorAdqArt
        '
        Me.txtValorAdqArt.EnterMoveNextControl = True
        Me.txtValorAdqArt.Location = New System.Drawing.Point(5, 124)
        Me.txtValorAdqArt.Name = "txtValorAdqArt"
        Me.txtValorAdqArt.Properties.Appearance.Options.UseTextOptions = True
        Me.txtValorAdqArt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtValorAdqArt.Properties.DisplayFormat.FormatString = "c"
        Me.txtValorAdqArt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtValorAdqArt.Properties.Mask.EditMask = "c"
        Me.txtValorAdqArt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtValorAdqArt.Size = New System.Drawing.Size(63, 20)
        Me.txtValorAdqArt.TabIndex = 6
        '
        'txtDescripcionArt
        '
        Me.txtDescripcionArt.EnterMoveNextControl = True
        Me.txtDescripcionArt.Location = New System.Drawing.Point(5, 40)
        Me.txtDescripcionArt.Name = "txtDescripcionArt"
        Me.txtDescripcionArt.Size = New System.Drawing.Size(397, 20)
        Me.txtDescripcionArt.TabIndex = 0
        Me.txtDescripcionArt.Tag = "required"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Location = New System.Drawing.Point(12, 24)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl2.TabIndex = 8
        Me.LabelControl2.Text = "Descripción"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl3.Location = New System.Drawing.Point(412, 24)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(55, 13)
        Me.LabelControl3.TabIndex = 9
        Me.LabelControl3.Text = "Categoría"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Location = New System.Drawing.Point(9, 66)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl4.TabIndex = 10
        Me.LabelControl4.Text = "Género"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl5.Location = New System.Drawing.Point(497, 66)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl5.TabIndex = 11
        Me.LabelControl5.Text = "Precio"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl6.Location = New System.Drawing.Point(9, 108)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl6.TabIndex = 12
        Me.LabelControl6.Text = "Val. Adq."
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl7.Location = New System.Drawing.Point(162, 66)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl7.TabIndex = 13
        Me.LabelControl7.Text = "Procedencia"
        '
        'lkCategArt
        '
        Me.lkCategArt.EnterMoveNextControl = True
        Me.lkCategArt.Location = New System.Drawing.Point(408, 40)
        Me.lkCategArt.Name = "lkCategArt"
        Me.lkCategArt.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkCategArt.Size = New System.Drawing.Size(149, 20)
        Me.lkCategArt.TabIndex = 1
        Me.lkCategArt.Tag = "required"
        '
        'lkGeneroArt
        '
        Me.lkGeneroArt.EnterMoveNextControl = True
        Me.lkGeneroArt.Location = New System.Drawing.Point(5, 82)
        Me.lkGeneroArt.Name = "lkGeneroArt"
        Me.lkGeneroArt.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkGeneroArt.Size = New System.Drawing.Size(145, 20)
        Me.lkGeneroArt.TabIndex = 2
        Me.lkGeneroArt.Tag = "required"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl8.Location = New System.Drawing.Point(80, 108)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(83, 13)
        Me.LabelControl8.TabIndex = 16
        Me.LabelControl8.Text = "Observaciones"
        '
        'txtProcedenciaArt
        '
        Me.txtProcedenciaArt.EnterMoveNextControl = True
        Me.txtProcedenciaArt.Location = New System.Drawing.Point(156, 82)
        Me.txtProcedenciaArt.Name = "txtProcedenciaArt"
        Me.txtProcedenciaArt.Size = New System.Drawing.Size(331, 20)
        Me.txtProcedenciaArt.TabIndex = 3
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.grdTallesCantidad)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 173)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(313, 149)
        Me.GroupControl1.TabIndex = 17
        Me.GroupControl1.Text = "Artículos / Talles"
        '
        'grdTallesCantidad
        '
        Me.grdTallesCantidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTallesCantidad.Location = New System.Drawing.Point(2, 21)
        Me.grdTallesCantidad.MainView = Me.grdViewTallesCant
        Me.grdTallesCantidad.Name = "grdTallesCantidad"
        Me.grdTallesCantidad.Size = New System.Drawing.Size(309, 126)
        Me.grdTallesCantidad.TabIndex = 0
        Me.grdTallesCantidad.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdViewTallesCant})
        '
        'grdViewTallesCant
        '
        Me.grdViewTallesCant.GridControl = Me.grdTallesCantidad
        Me.grdViewTallesCant.Name = "grdViewTallesCant"
        '
        'btnAceptarArt
        '
        Me.btnAceptarArt.Image = CType(resources.GetObject("btnAceptarArt.Image"), System.Drawing.Image)
        Me.btnAceptarArt.Location = New System.Drawing.Point(180, 354)
        Me.btnAceptarArt.Name = "btnAceptarArt"
        Me.btnAceptarArt.Size = New System.Drawing.Size(97, 30)
        Me.btnAceptarArt.TabIndex = 8
        Me.btnAceptarArt.Text = "Aceptar"
        '
        'btnCancelarArt
        '
        Me.btnCancelarArt.Image = CType(resources.GetObject("btnCancelarArt.Image"), System.Drawing.Image)
        Me.btnCancelarArt.Location = New System.Drawing.Point(283, 354)
        Me.btnCancelarArt.Name = "btnCancelarArt"
        Me.btnCancelarArt.Size = New System.Drawing.Size(110, 30)
        Me.btnCancelarArt.TabIndex = 9
        Me.btnCancelarArt.Text = "Cancelar"
        '
        'gpArticulos
        '
        Me.gpArticulos.Controls.Add(Me.txtValorAdqArt)
        Me.gpArticulos.Controls.Add(Me.txtDescripcionArt)
        Me.gpArticulos.Controls.Add(Me.LabelControl2)
        Me.gpArticulos.Controls.Add(Me.LabelControl8)
        Me.gpArticulos.Controls.Add(Me.lkCategArt)
        Me.gpArticulos.Controls.Add(Me.txtObservArt)
        Me.gpArticulos.Controls.Add(Me.LabelControl6)
        Me.gpArticulos.Controls.Add(Me.LabelControl3)
        Me.gpArticulos.Controls.Add(Me.LabelControl7)
        Me.gpArticulos.Controls.Add(Me.LabelControl5)
        Me.gpArticulos.Controls.Add(Me.lkGeneroArt)
        Me.gpArticulos.Controls.Add(Me.txtPrecioArt)
        Me.gpArticulos.Controls.Add(Me.LabelControl4)
        Me.gpArticulos.Controls.Add(Me.txtProcedenciaArt)
        Me.gpArticulos.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpArticulos.Location = New System.Drawing.Point(0, 0)
        Me.gpArticulos.Name = "gpArticulos"
        Me.gpArticulos.Size = New System.Drawing.Size(579, 164)
        Me.gpArticulos.TabIndex = 20
        Me.gpArticulos.Text = "Artículo"
        '
        'btnCargarImagen
        '
        Me.btnCargarImagen.EditValue = "Seleccione Imagen..."
        Me.btnCargarImagen.EnterMoveNextControl = True
        Me.btnCargarImagen.Location = New System.Drawing.Point(370, 326)
        Me.btnCargarImagen.Name = "btnCargarImagen"
        Me.btnCargarImagen.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.btnCargarImagen.Size = New System.Drawing.Size(162, 20)
        Me.btnCargarImagen.TabIndex = 4
        '
        'errorProviderArticulos
        '
        Me.errorProviderArticulos.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.errorProviderArticulos.ContainerControl = Me
        '
        'picEdArticulo
        '
        Me.picEdArticulo.Location = New System.Drawing.Point(331, 173)
        Me.picEdArticulo.Name = "picEdArticulo"
        Me.picEdArticulo.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray
        Me.picEdArticulo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.picEdArticulo.Size = New System.Drawing.Size(235, 147)
        Me.picEdArticulo.TabIndex = 21
        '
        'frmArticulosEditar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 396)
        Me.Controls.Add(Me.btnCargarImagen)
        Me.Controls.Add(Me.picEdArticulo)
        Me.Controls.Add(Me.gpArticulos)
        Me.Controls.Add(Me.btnCancelarArt)
        Me.Controls.Add(Me.btnAceptarArt)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "frmArticulosEditar"
        CType(Me.txtObservArt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecioArt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorAdqArt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcionArt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkCategArt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkGeneroArt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProcedenciaArt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.grdTallesCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewTallesCant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpArticulos.ResumeLayout(False)
        Me.gpArticulos.PerformLayout()
        CType(Me.btnCargarImagen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errorProviderArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picEdArticulo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtObservArt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPrecioArt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtValorAdqArt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDescripcionArt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lkCategArt As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents lkGeneroArt As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProcedenciaArt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnAceptarArt As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelarArt As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gpArticulos As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnCargarImagen As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents errorProviderArticulos As System.Windows.Forms.ErrorProvider
    Friend WithEvents grdTallesCantidad As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewTallesCant As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents picEdArticulo As DevExpress.XtraEditors.PictureEdit
End Class
