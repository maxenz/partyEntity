Imports System.Reflection

Module modDevGrid

    Public Function ListToDataTable(Of T)(list As List(Of T)) As DataTable
        Dim dt As New DataTable()
        For Each info As PropertyInfo In GetType(T).GetProperties()
            dt.Columns.Add(New DataColumn(info.Name, info.PropertyType))
        Next
        For Each tipo As T In list
            Dim row As DataRow = dt.NewRow()
            For Each info As PropertyInfo In GetType(T).GetProperties()
                row(info.Name) = info.GetValue(tipo, Nothing)
            Next
            dt.Rows.Add(row)
        Next
        Return dt
    End Function

End Module
