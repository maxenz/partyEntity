Imports System.Reflection

Module modDevGrid

    Public Function ListToDataTable(Of T)(list As List(Of T)) As DataTable
        Dim dt As New DataTable()
        For Each info As PropertyInfo In GetType(T).GetProperties()

            Dim propType As Type = info.PropertyType
            If propType.IsGenericType AndAlso propType.GetGenericTypeDefinition() = GetType(Nullable(Of )) Then
                propType = Nullable.GetUnderlyingType(propType)
            End If

            dt.Columns.Add(New DataColumn(info.Name, propType))

        Next
        For Each tipo As T In list
            Dim row As DataRow = dt.NewRow()
            For Each info As PropertyInfo In GetType(T).GetProperties()
                If info.GetValue(tipo, Nothing) Is Nothing Then
                    If info.PropertyType.IsValueType Then
                        row(info.Name) = 0
                    Else
                        row(info.Name) = ""
                    End If
                    'row(info.Name) = info.GetValue(tipo, Nothing)
                Else
                    row(info.Name) = info.GetValue(tipo, Nothing)
                End If
            Next
            dt.Rows.Add(row)
        Next
        Return dt

    End Function

End Module
