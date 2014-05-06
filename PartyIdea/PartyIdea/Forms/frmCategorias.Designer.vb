<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCategorias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCategorias))
        Me.grdCategorias = New DevExpress.XtraGrid.GridControl()
        Me.grdViewCategorias = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnAgregarCat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnModifCat = New DevExpress.XtraEditors.SimpleButton()
        Me.btnElimCat = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.grdCategorias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewCategorias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdCategorias
        '
        Me.grdCategorias.Location = New System.Drawing.Point(0, 36)
        Me.grdCategorias.MainView = Me.grdViewCategorias
        Me.grdCategorias.Name = "grdCategorias"
        Me.grdCategorias.Size = New System.Drawing.Size(531, 226)
        Me.grdCategorias.TabIndex = 0
        Me.grdCategorias.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdViewCategorias})
        '
        'grdViewCategorias
        '
        Me.grdViewCategorias.GridControl = Me.grdCategorias
        Me.grdViewCategorias.Name = "grdViewCategorias"
        '
        'btnAgregarCat
        '
        Me.btnAgregarCat.Image = CType(resources.GetObject("btnAgregarCat.Image"), System.Drawing.Image)
        Me.btnAgregarCat.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAgregarCat.Location = New System.Drawing.Point(195, 5)
        Me.btnAgregarCat.Name = "btnAgregarCat"
        Me.btnAgregarCat.Size = New System.Drawing.Size(31, 25)
        Me.btnAgregarCat.TabIndex = 1
        '
        'btnModifCat
        '
        Me.btnModifCat.Image = CType(resources.GetObject("btnModifCat.Image"), System.Drawing.Image)
        Me.btnModifCat.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnModifCat.Location = New System.Drawing.Point(232, 5)
        Me.btnModifCat.Name = "btnModifCat"
        Me.btnModifCat.Size = New System.Drawing.Size(31, 25)
        Me.btnModifCat.TabIndex = 2
        '
        'btnElimCat
        '
        Me.btnElimCat.Image = CType(resources.GetObject("btnElimCat.Image"), System.Drawing.Image)
        Me.btnElimCat.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnElimCat.Location = New System.Drawing.Point(269, 5)
        Me.btnElimCat.Name = "btnElimCat"
        Me.btnElimCat.Size = New System.Drawing.Size(31, 25)
        Me.btnElimCat.TabIndex = 3
        '
        'frmCategorias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 262)
        Me.Controls.Add(Me.btnElimCat)
        Me.Controls.Add(Me.btnModifCat)
        Me.Controls.Add(Me.btnAgregarCat)
        Me.Controls.Add(Me.grdCategorias)
        Me.Name = "frmCategorias"
        Me.Text = "Categorías"
        CType(Me.grdCategorias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewCategorias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdCategorias As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewCategorias As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnAgregarCat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnModifCat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnElimCat As DevExpress.XtraEditors.SimpleButton
End Class
