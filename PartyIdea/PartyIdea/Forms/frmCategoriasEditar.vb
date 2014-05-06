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

Public Class frmCategoriasEditar
    Private db As PartyIdeaEntities
    Public idCat As Integer
    Private Sub btnGuardarCategorias_Click(sender As Object, e As EventArgs) Handles btnGuardarCategorias.Click
        Try
            Dim stCat As String = txtDescCategoria.Text
            If (idCat = 0) Then
                Dim cat As New Categorias
                cat.Descripcion = stCat
                cat.regFechaHora = getFechaHoraActual()
                cat.regUsuarioId = 1
                db.Categorias.Add(cat)
            Else
                Dim cat As Categorias = db.Categorias.Find(idCat)
                cat.Descripcion = stCat
                cat.regFechaHora = getFechaHoraActual()
                db.Entry(cat).State = EntityState.Modified
            End If

            db.SaveChanges()
            frmCategorias.grdCategorias.DataSource = frmCategorias.getCategoriasDatasource()
            Me.Close()
        Catch ex As Exception
            MsgBox("Error en la base de datos, no se pudo guardar la categoría")
        End Try

    End Sub

    Private Sub frmCategorias_Load(sender As Object, e As EventArgs) Handles Me.Load
        db = New PartyIdeaEntities
    End Sub
End Class