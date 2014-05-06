Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Linq
Imports DevExpress.XtraEditors.Repository

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

    Public Sub setLookupPropertiesCod(ByVal pCombo As LookUpEdit)

        pCombo.Properties.Columns.Add(New LookUpColumnInfo("ID"))
        pCombo.Properties.Columns.Add(New LookUpColumnInfo("Codigo", 10))
        pCombo.Properties.Columns(0).Visible = False
        pCombo.Properties.ShowFooter = False
        pCombo.Properties.ShowHeader = False
        pCombo.Properties.DisplayMember = "Codigo"
        pCombo.Properties.ValueMember = "ID"
        pCombo.Properties.NullText = "..."

    End Sub

    Public Sub setLookupRepositoryProperties(ByVal pCombo As RepositoryItemLookUpEdit)

        pCombo.Columns.Add(New LookUpColumnInfo("ID"))
        pCombo.Columns.Add(New LookUpColumnInfo("Descripcion", 10))
        pCombo.Columns(0).Visible = False
        pCombo.ShowFooter = False
        pCombo.ShowHeader = False
        pCombo.DisplayMember = "Descripcion"
        pCombo.ValueMember = "ID"
        pCombo.NullText = "..."

    End Sub

End Module
