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

Partial Public Class TipoDocumentos
    Public Property ID As Long
    Public Property AbreviaturaId As String
    Public Property Descripcion As String
    Public Property regUsuarioId As Long
    Public Property regFechaHora As Date
    Public Property regTerminalId As Nullable(Of Long)

    Public Overridable Property Clientes As ICollection(Of Clientes) = New HashSet(Of Clientes)
    Public Overridable Property TipoDocumentos1 As TipoDocumentos
    Public Overridable Property TipoDocumentos2 As TipoDocumentos

End Class