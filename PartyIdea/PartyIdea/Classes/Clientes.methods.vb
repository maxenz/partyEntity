Imports System.Linq

Partial Public Class Clientes

    Public Function searchByTel(ByVal tel As String, ByVal db As PartyIdeaEntities) As Integer

        Dim cliente_id As Integer = (From c In db.Clientes Where c.TelefonoCelular = tel Select c.ID).FirstOrDefault

        Return cliente_id

    End Function

    Public Function getNroNuevoCliente(ByVal db As PartyIdeaEntities) As Integer

        'Genero nuevo número de cliente

        Dim cantCli = db.Clientes.Count()

        If cantCli = 0 Then

            Return 1500

        End If

        Dim lastCliente = (From c In db.Clientes Order By c.NroCliente _
                          Descending Select c).FirstOrDefault

        Dim lastNroCli = lastCliente.NroCliente

        Return lastNroCli + 1

    End Function

End Class
