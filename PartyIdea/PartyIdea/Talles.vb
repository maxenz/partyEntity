'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Talles
    Public Property ID As Long
    Public Property Descripcion As String
    Public Property regUsuarioId As Long
    Public Property regFechaHora As Date

    Public Overridable Property ArticulosTalleStock As ICollection(Of ArticulosTalleStock) = New HashSet(Of ArticulosTalleStock)

End Class