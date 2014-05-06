<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArticulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArticulos))
        Me.btnNuevoArticulo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEditarArticulo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEliminarArticulo = New DevExpress.XtraEditors.SimpleButton()
        Me.gpArticulos = New DevExpress.XtraEditors.GroupControl()
        Me.gpGrillaArticulos = New DevExpress.XtraEditors.GroupControl()
        Me.grdArticulos = New DevExpress.XtraGrid.GridControl()
        Me.grdViewArticulos = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.gpArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpArticulos.SuspendLayout()
        CType(Me.gpGrillaArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpGrillaArticulos.SuspendLayout()
        CType(Me.grdArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnNuevoArticulo
        '
        Me.btnNuevoArticulo.Image = CType(resources.GetObject("btnNuevoArticulo.Image"), System.Drawing.Image)
        Me.btnNuevoArticulo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnNuevoArticulo.Location = New System.Drawing.Point(523, 23)
        Me.btnNuevoArticulo.Name = "btnNuevoArticulo"
        Me.btnNuevoArticulo.Size = New System.Drawing.Size(101, 26)
        Me.btnNuevoArticulo.TabIndex = 1
        Me.btnNuevoArticulo.Text = "Nuevo"
        '
        'btnEditarArticulo
        '
        Me.btnEditarArticulo.Image = CType(resources.GetObject("btnEditarArticulo.Image"), System.Drawing.Image)
        Me.btnEditarArticulo.Location = New System.Drawing.Point(630, 23)
        Me.btnEditarArticulo.Name = "btnEditarArticulo"
        Me.btnEditarArticulo.Size = New System.Drawing.Size(101, 26)
        Me.btnEditarArticulo.TabIndex = 2
        Me.btnEditarArticulo.Text = "Editar"
        '
        'btnEliminarArticulo
        '
        Me.btnEliminarArticulo.Image = CType(resources.GetObject("btnEliminarArticulo.Image"), System.Drawing.Image)
        Me.btnEliminarArticulo.Location = New System.Drawing.Point(737, 23)
        Me.btnEliminarArticulo.Name = "btnEliminarArticulo"
        Me.btnEliminarArticulo.Size = New System.Drawing.Size(101, 26)
        Me.btnEliminarArticulo.TabIndex = 3
        Me.btnEliminarArticulo.Text = "Eliminar"
        '
        'gpArticulos
        '
        Me.gpArticulos.Controls.Add(Me.btnEliminarArticulo)
        Me.gpArticulos.Controls.Add(Me.btnNuevoArticulo)
        Me.gpArticulos.Controls.Add(Me.btnEditarArticulo)
        Me.gpArticulos.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpArticulos.Location = New System.Drawing.Point(0, 0)
        Me.gpArticulos.Name = "gpArticulos"
        Me.gpArticulos.Size = New System.Drawing.Size(821, 55)
        Me.gpArticulos.TabIndex = 8
        Me.gpArticulos.Text = "Artículos"
        '
        'gpGrillaArticulos
        '
        Me.gpGrillaArticulos.Controls.Add(Me.grdArticulos)
        Me.gpGrillaArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpGrillaArticulos.Location = New System.Drawing.Point(0, 55)
        Me.gpGrillaArticulos.Name = "gpGrillaArticulos"
        Me.gpGrillaArticulos.Size = New System.Drawing.Size(821, 367)
        Me.gpGrillaArticulos.TabIndex = 6
        '
        'grdArticulos
        '
        Me.grdArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdArticulos.Location = New System.Drawing.Point(2, 21)
        Me.grdArticulos.MainView = Me.grdViewArticulos
        Me.grdArticulos.Name = "grdArticulos"
        Me.grdArticulos.Size = New System.Drawing.Size(817, 344)
        Me.grdArticulos.TabIndex = 0
        Me.grdArticulos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdViewArticulos})
        '
        'grdViewArticulos
        '
        Me.grdViewArticulos.GridControl = Me.grdArticulos
        Me.grdViewArticulos.Name = "grdViewArticulos"
        '
        'frmArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 422)
        Me.Controls.Add(Me.gpGrillaArticulos)
        Me.Controls.Add(Me.gpArticulos)
        Me.Name = "frmArticulos"
        Me.Text = "Gestión de Artículos"
        CType(Me.gpArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpArticulos.ResumeLayout(False)
        CType(Me.gpGrillaArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpGrillaArticulos.ResumeLayout(False)
        CType(Me.grdArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnNuevoArticulo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEditarArticulo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEliminarArticulo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gpArticulos As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gpGrillaArticulos As DevExpress.XtraEditors.GroupControl
    Friend WithEvents grdArticulos As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewArticulos As DevExpress.XtraGrid.Views.Grid.GridView
End Class
