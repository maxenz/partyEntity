Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Linq

Module modLookUp

    Public Sub setLookupProperties(ByVal pCombo As LookUpEdit)

        pCombo.Properties.Columns.Add(New LookUpColumnInfo("ID"))
        pCombo.Properties.Columns.Add(New LookUpColumnInfo("Descripcion", 10))
        pCombo.Properties.Columns(0).Visible = False
        pCombo.Properties.ShowFooter = False
        pCombo.Properties.ShowHeader = False
        pCombo.Properties.DisplayMember = "Descripcion"
        pCombo.Properties.ValueMember = "ID"
        pCombo.Properties.NullText = "..."

    End Sub

End Module
