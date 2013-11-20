Imports System.Linq

Partial Public Class Movimientos

    Public Function searchMovByNroSolicitud(ByVal nroSol As String, ByVal db As PartyIdeaEntities) As Integer

        Dim mov_id = (From m In db.Movimientos Where m.NroSolicitud = nroSol Select m.ID).FirstOrDefault

        Return mov_id

    End Function

End Class
