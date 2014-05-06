<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCategoriasEditar
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.btnGuardarCategorias = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDescCategoria = New DevExpress.XtraEditors.TextEdit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtDescCategoria.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.btnGuardarCategorias)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.txtDescCategoria)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(353, 74)
        Me.GroupControl1.TabIndex = 0
        '
        'btnGuardarCategorias
        '
        Me.btnGuardarCategorias.Location = New System.Drawing.Point(251, 41)
        Me.btnGuardarCategorias.Name = "btnGuardarCategorias"
        Me.btnGuardarCategorias.Size = New System.Drawing.Size(90, 20)
        Me.btnGuardarCategorias.TabIndex = 2
        Me.btnGuardarCategorias.Text = "Guardar"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(10, 24)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Descripción"
        '
        'txtDescCategoria
        '
        Me.txtDescCategoria.Location = New System.Drawing.Point(5, 41)
        Me.txtDescCategoria.Name = "txtDescCategoria"
        Me.txtDescCategoria.Size = New System.Drawing.Size(240, 20)
        Me.txtDescCategoria.TabIndex = 0
        '
        'frmCategorias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 74)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "frmCategorias"
        Me.Text = "Categorías"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtDescCategoria.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnGuardarCategorias As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDescCategoria As DevExpress.XtraEditors.TextEdit
End Class
