<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientoArticulo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimientoArticulo))
        Me.grpMovArt = New DevExpress.XtraEditors.GroupControl()
        Me.btnBuscarStock = New DevExpress.XtraEditors.SimpleButton()
        Me.grdStockMovArt = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnCancMovArt = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGuardarMovArt = New DevExpress.XtraEditors.SimpleButton()
        Me.dtStockDisp = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtImporte = New DevExpress.XtraEditors.TextEdit()
        Me.txtAbona = New DevExpress.XtraEditors.TextEdit()
        Me.txtRestan = New DevExpress.XtraEditors.TextEdit()
        Me.txtCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbTalle = New DevExpress.XtraEditors.LookUpEdit()
        Me.dtDevolucion = New DevExpress.XtraEditors.DateEdit()
        Me.dtEntrega = New DevExpress.XtraEditors.DateEdit()
        Me.picArt = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbCodArticulos = New DevExpress.XtraEditors.LookUpEdit()
        Me.cmbDescArticulos = New DevExpress.XtraEditors.LookUpEdit()
        Me.cmbOperaciones = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.grpMovArt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMovArt.SuspendLayout()
        CType(Me.grdStockMovArt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtStockDisp.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtStockDisp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporte.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAbona.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRestan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTalle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDevolucion.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDevolucion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEntrega.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtEntrega.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picArt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCodArticulos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDescArticulos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOperaciones.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpMovArt
        '
        Me.grpMovArt.Controls.Add(Me.btnBuscarStock)
        Me.grpMovArt.Controls.Add(Me.grdStockMovArt)
        Me.grpMovArt.Controls.Add(Me.btnCancMovArt)
        Me.grpMovArt.Controls.Add(Me.btnGuardarMovArt)
        Me.grpMovArt.Controls.Add(Me.dtStockDisp)
        Me.grpMovArt.Controls.Add(Me.LabelControl11)
        Me.grpMovArt.Controls.Add(Me.LabelControl10)
        Me.grpMovArt.Controls.Add(Me.LabelControl9)
        Me.grpMovArt.Controls.Add(Me.LabelControl8)
        Me.grpMovArt.Controls.Add(Me.LabelControl7)
        Me.grpMovArt.Controls.Add(Me.txtImporte)
        Me.grpMovArt.Controls.Add(Me.txtAbona)
        Me.grpMovArt.Controls.Add(Me.txtRestan)
        Me.grpMovArt.Controls.Add(Me.txtCantidad)
        Me.grpMovArt.Controls.Add(Me.LabelControl6)
        Me.grpMovArt.Controls.Add(Me.LabelControl5)
        Me.grpMovArt.Controls.Add(Me.LabelControl4)
        Me.grpMovArt.Controls.Add(Me.cmbTalle)
        Me.grpMovArt.Controls.Add(Me.dtDevolucion)
        Me.grpMovArt.Controls.Add(Me.dtEntrega)
        Me.grpMovArt.Controls.Add(Me.picArt)
        Me.grpMovArt.Controls.Add(Me.LabelControl3)
        Me.grpMovArt.Controls.Add(Me.LabelControl2)
        Me.grpMovArt.Controls.Add(Me.LabelControl1)
        Me.grpMovArt.Controls.Add(Me.cmbCodArticulos)
        Me.grpMovArt.Controls.Add(Me.cmbDescArticulos)
        Me.grpMovArt.Controls.Add(Me.cmbOperaciones)
        Me.grpMovArt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpMovArt.Location = New System.Drawing.Point(0, 0)
        Me.grpMovArt.Name = "grpMovArt"
        Me.grpMovArt.Size = New System.Drawing.Size(896, 202)
        Me.grpMovArt.TabIndex = 0
        '
        'btnBuscarStock
        '
        Me.btnBuscarStock.Image = CType(resources.GetObject("btnBuscarStock.Image"), System.Drawing.Image)
        Me.btnBuscarStock.Location = New System.Drawing.Point(855, 25)
        Me.btnBuscarStock.Name = "btnBuscarStock"
        Me.btnBuscarStock.Size = New System.Drawing.Size(27, 19)
        Me.btnBuscarStock.TabIndex = 26
        '
        'grdStockMovArt
        '
        Me.grdStockMovArt.Location = New System.Drawing.Point(708, 50)
        Me.grdStockMovArt.MainView = Me.GridView1
        Me.grdStockMovArt.Name = "grdStockMovArt"
        Me.grdStockMovArt.Size = New System.Drawing.Size(174, 125)
        Me.grdStockMovArt.TabIndex = 25
        Me.grdStockMovArt.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdStockMovArt
        Me.GridView1.Name = "GridView1"
        '
        'btnCancMovArt
        '
        Me.btnCancMovArt.Image = CType(resources.GetObject("btnCancMovArt.Image"), System.Drawing.Image)
        Me.btnCancMovArt.Location = New System.Drawing.Point(266, 169)
        Me.btnCancMovArt.Name = "btnCancMovArt"
        Me.btnCancMovArt.Size = New System.Drawing.Size(106, 23)
        Me.btnCancMovArt.TabIndex = 24
        Me.btnCancMovArt.Text = "Cancelar"
        '
        'btnGuardarMovArt
        '
        Me.btnGuardarMovArt.Image = CType(resources.GetObject("btnGuardarMovArt.Image"), System.Drawing.Image)
        Me.btnGuardarMovArt.Location = New System.Drawing.Point(158, 169)
        Me.btnGuardarMovArt.Name = "btnGuardarMovArt"
        Me.btnGuardarMovArt.Size = New System.Drawing.Size(102, 23)
        Me.btnGuardarMovArt.TabIndex = 10
        Me.btnGuardarMovArt.Text = "Guardar"
        '
        'dtStockDisp
        '
        Me.dtStockDisp.EditValue = Nothing
        Me.dtStockDisp.Location = New System.Drawing.Point(753, 24)
        Me.dtStockDisp.Name = "dtStockDisp"
        Me.dtStockDisp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtStockDisp.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtStockDisp.Properties.CalendarTimeProperties.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)
        Me.dtStockDisp.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.[Default]
        Me.dtStockDisp.Size = New System.Drawing.Size(96, 20)
        Me.dtStockDisp.TabIndex = 22
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(706, 25)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl11.TabIndex = 21
        Me.LabelControl11.Text = "Stock al:"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(18, 113)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl10.TabIndex = 20
        Me.LabelControl10.Text = "Cantidad"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(128, 113)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl9.TabIndex = 19
        Me.LabelControl9.Text = "Importe"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(256, 113)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl8.TabIndex = 18
        Me.LabelControl8.Text = "Abona"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(388, 113)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl7.TabIndex = 17
        Me.LabelControl7.Text = "Restan"
        '
        'txtImporte
        '
        Me.txtImporte.EnterMoveNextControl = True
        Me.txtImporte.Location = New System.Drawing.Point(122, 129)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Properties.Mask.EditMask = "c"
        Me.txtImporte.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtImporte.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtImporte.Size = New System.Drawing.Size(122, 20)
        Me.txtImporte.TabIndex = 7
        '
        'txtAbona
        '
        Me.txtAbona.EnterMoveNextControl = True
        Me.txtAbona.Location = New System.Drawing.Point(250, 129)
        Me.txtAbona.Name = "txtAbona"
        Me.txtAbona.Properties.Mask.EditMask = "c"
        Me.txtAbona.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAbona.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtAbona.Size = New System.Drawing.Size(122, 20)
        Me.txtAbona.TabIndex = 8
        '
        'txtRestan
        '
        Me.txtRestan.EnterMoveNextControl = True
        Me.txtRestan.Location = New System.Drawing.Point(382, 129)
        Me.txtRestan.Name = "txtRestan"
        Me.txtRestan.Properties.Mask.EditMask = "c"
        Me.txtRestan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtRestan.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtRestan.Size = New System.Drawing.Size(122, 20)
        Me.txtRestan.TabIndex = 9
        '
        'txtCantidad
        '
        Me.txtCantidad.EnterMoveNextControl = True
        Me.txtCantidad.Location = New System.Drawing.Point(12, 129)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(104, 20)
        Me.txtCantidad.TabIndex = 6
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(18, 70)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(85, 13)
        Me.LabelControl6.TabIndex = 12
        Me.LabelControl6.Text = "Fecha de Entrega"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(184, 70)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(99, 13)
        Me.LabelControl5.TabIndex = 11
        Me.LabelControl5.Text = "Fecha de Devolución"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(350, 70)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl4.TabIndex = 10
        Me.LabelControl4.Text = "Talle"
        '
        'cmbTalle
        '
        Me.cmbTalle.EnterMoveNextControl = True
        Me.cmbTalle.Location = New System.Drawing.Point(344, 87)
        Me.cmbTalle.Name = "cmbTalle"
        Me.cmbTalle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbTalle.Size = New System.Drawing.Size(160, 20)
        Me.cmbTalle.TabIndex = 5
        '
        'dtDevolucion
        '
        Me.dtDevolucion.EditValue = Nothing
        Me.dtDevolucion.EnterMoveNextControl = True
        Me.dtDevolucion.Location = New System.Drawing.Point(178, 87)
        Me.dtDevolucion.Name = "dtDevolucion"
        Me.dtDevolucion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtDevolucion.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtDevolucion.Properties.CalendarTimeProperties.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)
        Me.dtDevolucion.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.[Default]
        Me.dtDevolucion.Size = New System.Drawing.Size(160, 20)
        Me.dtDevolucion.TabIndex = 4
        '
        'dtEntrega
        '
        Me.dtEntrega.EditValue = Nothing
        Me.dtEntrega.EnterMoveNextControl = True
        Me.dtEntrega.Location = New System.Drawing.Point(12, 87)
        Me.dtEntrega.Name = "dtEntrega"
        Me.dtEntrega.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtEntrega.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtEntrega.Properties.CalendarTimeProperties.CloseUpKey = New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4)
        Me.dtEntrega.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.[Default]
        Me.dtEntrega.Size = New System.Drawing.Size(160, 20)
        Me.dtEntrega.TabIndex = 3
        '
        'picArt
        '
        Me.picArt.Location = New System.Drawing.Point(526, 25)
        Me.picArt.Name = "picArt"
        Me.picArt.Size = New System.Drawing.Size(174, 150)
        Me.picArt.TabIndex = 6
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(350, 25)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Descripción"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(184, 25)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(62, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Cod. Artículo"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 25)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Operación"
        '
        'cmbCodArticulos
        '
        Me.cmbCodArticulos.EnterMoveNextControl = True
        Me.cmbCodArticulos.Location = New System.Drawing.Point(178, 44)
        Me.cmbCodArticulos.Name = "cmbCodArticulos"
        Me.cmbCodArticulos.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbCodArticulos.Size = New System.Drawing.Size(160, 20)
        Me.cmbCodArticulos.TabIndex = 1
        '
        'cmbDescArticulos
        '
        Me.cmbDescArticulos.EnterMoveNextControl = True
        Me.cmbDescArticulos.Location = New System.Drawing.Point(344, 44)
        Me.cmbDescArticulos.Name = "cmbDescArticulos"
        Me.cmbDescArticulos.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbDescArticulos.Size = New System.Drawing.Size(160, 20)
        Me.cmbDescArticulos.TabIndex = 2
        '
        'cmbOperaciones
        '
        Me.cmbOperaciones.EnterMoveNextControl = True
        Me.cmbOperaciones.Location = New System.Drawing.Point(12, 44)
        Me.cmbOperaciones.Name = "cmbOperaciones"
        Me.cmbOperaciones.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbOperaciones.Size = New System.Drawing.Size(160, 20)
        Me.cmbOperaciones.TabIndex = 0
        '
        'frmMovimientoArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 202)
        Me.Controls.Add(Me.grpMovArt)
        Me.Name = "frmMovimientoArticulo"
        Me.Text = "Registro de Movimiento"
        CType(Me.grpMovArt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMovArt.ResumeLayout(False)
        Me.grpMovArt.PerformLayout()
        CType(Me.grdStockMovArt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtStockDisp.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtStockDisp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporte.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAbona.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRestan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTalle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDevolucion.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDevolucion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEntrega.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtEntrega.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picArt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCodArticulos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDescArticulos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOperaciones.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpMovArt As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnCancMovArt As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGuardarMovArt As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtStockDisp As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtImporte As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAbona As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtRestan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCantidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTalle As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents dtDevolucion As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dtEntrega As DevExpress.XtraEditors.DateEdit
    Friend WithEvents picArt As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbCodArticulos As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cmbDescArticulos As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cmbOperaciones As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents grdStockMovArt As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnBuscarStock As DevExpress.XtraEditors.SimpleButton
End Class
