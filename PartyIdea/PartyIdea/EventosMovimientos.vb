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

Partial Public Class EventosMovimientos
    Public Property ID As Byte
    Public Property EventoId As Byte
    Public Property MovimientoId As Long
    Public Property regUsuarioId As Long
    Public Property regFechaHora As Date
    Public Property regTerminalId As Nullable(Of Long)

    Public Overridable Property Eventos As Eventos
    Public Overridable Property Movimientos As Movimientos

End Class