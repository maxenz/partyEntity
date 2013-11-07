Imports Microsoft.VisualBasic.FileIO.TextFieldParser

Module modFunciones

    Public Sub SetFormatGroupBox(ByVal pGrp As GroupBox)
        Dim Control As Control
        With pGrp
            .FlatStyle = FlatStyle.Popup
            .Font = New Font("Tahoma", 11, FontStyle.Bold, GraphicsUnit.Pixel, 1)
            .ForeColor = Color.SteelBlue
            For Each Control In .Controls
                If Control.GetType.Name = "Label" Then
                    Control.ForeColor = Color.SteelBlue
                End If
                Control.Font = New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel, 1)
            Next
        End With
    End Sub
    Public Sub SetFormatGroupControl(ByVal pGrp As DevExpress.XtraEditors.GroupControl)
        Dim Control As Control
        With pGrp

            .Font = New Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Pixel, 1)

            '.ForeColor = Color.SteelBlue
            .Appearance.BackColor2 = Color.Beige
            .Appearance.BackColor = Color.Beige
            .Appearance.BorderColor = Color.Gray

            .LookAndFeel.UseDefaultLookAndFeel = False
            .LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003
            .AppearanceCaption.BackColor = Color.LemonChiffon
            .AppearanceCaption.ForeColor = Color.Black

            For Each Control In .Controls
                If Control.GetType.Name = "Label" Or Control.GetType.Name = "LabelControl" Then
                    Control.ForeColor = Color.Black
                End If
                If Control.GetType.Name = "DateEdit" Then
                    Dim devControl As DevExpress.XtraEditors.DateEdit = Control
                    devControl.Properties.AppearanceFocused.BackColor = Color.LemonChiffon
                    SetDateEditFormat(devControl)
                End If
                If Control.GetType.Name = "TimeEdit" Then
                    Dim devControl As DevExpress.XtraEditors.TimeEdit = Control
                    devControl.Properties.AppearanceFocused.BackColor = Color.LemonChiffon
                    SetTimeEditFormat(devControl)
                End If
                If Control.GetType.Name = "TextEdit" Then
                    Dim devControl As DevExpress.XtraEditors.TextEdit = Control
                    devControl.Properties.AppearanceFocused.BackColor = Color.LemonChiffon
                End If
                If Control.GetType.Name = "ComboBoxEdit" Then
                    Dim devControl As DevExpress.XtraEditors.ComboBoxEdit = Control
                    devControl.Properties.AppearanceFocused.BackColor = Color.LemonChiffon
                End If
                If Control.GetType.Name = "LookUpEdit" Then
                    Dim devControl As DevExpress.XtraEditors.LookUpEdit = Control
                    devControl.Properties.AppearanceFocused.BackColor = Color.LemonChiffon
                End If
                If Control.GetType.Name = "MemoEdit" Then
                    Dim devControl As DevExpress.XtraEditors.MemoEdit = Control
                    devControl.Properties.AppearanceFocused.BackColor = Color.LemonChiffon
                End If
                If Not Control.Font.Bold Then
                    Control.Font = New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel, 1)
                End If
            Next
        End With
    End Sub

    Public Sub SetFormatTabControl(ByVal pTab As DevExpress.XtraTab.XtraTabControl)
        Dim vPag As DevExpress.XtraTab.XtraTabPage
        With pTab
            .Font = New Font("Tahoma", 11, FontStyle.Bold, GraphicsUnit.Pixel, 1)
            .ForeColor = Color.SteelBlue
            .BackColor = Color.Beige
            '.PaintStyleName = 1

            .LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin
            .LookAndFeel.UseDefaultLookAndFeel = False

            .AppearancePage.Header.Font = New Font("Tahoma", 11, FontStyle.Bold, GraphicsUnit.Pixel, 1)
            .AppearancePage.Header.BackColor = Color.LemonChiffon
            .AppearancePage.HeaderActive.BackColor = Color.Wheat

            '.Font = New Font("Tahoma", 11, FontStyle.Bold)
            For Each vPag In .TabPages
                vPag.BackColor = Color.Beige
                vPag.Font = New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel, 1)
            Next
        End With
    End Sub

    Public Sub SetFormatTabControl(ByVal pTab As TabControl)
        Dim vPag As TabPage
        With pTab
            .Font = New Font("Tahoma", 11, FontStyle.Bold, GraphicsUnit.Pixel, 1)
            .ForeColor = Color.SteelBlue
            .DrawMode = TabDrawMode.OwnerDrawFixed
            For Each vPag In .TabPages
                vPag.ForeColor = Color.SteelBlue
                vPag.BackColor = Color.Beige
                vPag.Font = New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel, 1)
            Next
        End With
    End Sub
    Public Sub SetFormatGrid(ByVal pGrid As DataGridView, ByVal pCol As Integer, Optional ByVal pAltClr As Boolean = True, Optional ByVal pByRow As Boolean = True)
        With pGrid
            '----> Comportamiento
            .RowCount = 1
            .ColumnCount = pCol
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .ScrollBars = ScrollBars.Vertical
            .MultiSelect = False
            .ReadOnly = True
            '----> Formato General
            .Font = New Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel, 1)
            .ForeColor = Color.Black
            .BackgroundColor = Color.LightSlateGray
            If pAltClr Then
                .RowsDefaultCellStyle.BackColor = Color.Azure
                .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
                .RowsDefaultCellStyle.SelectionBackColor = Color.Wheat
                .RowsDefaultCellStyle.SelectionForeColor = Color.Black
            Else
                .RowsDefaultCellStyle.BackColor = Color.Beige
                .RowsDefaultCellStyle.SelectionBackColor = Color.AliceBlue
                .RowsDefaultCellStyle.SelectionForeColor = Color.Black
            End If
            If pByRow Then
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Else
                .SelectionMode = DataGridViewSelectionMode.CellSelect
            End If
            '----> Formato de Headers
            With .ColumnHeadersDefaultCellStyle
                .Alignment = DataGridViewContentAlignment.MiddleCenter
                .BackColor = Color.Beige
                .Font = New Font("Tahoma", 11, FontStyle.Bold, GraphicsUnit.Pixel, 1)
            End With
        End With
    End Sub
    Public Sub SetFormatToolStrip(ByVal pTbr As ToolStrip, ByVal pIco As ImageList, Optional ByVal pSal As Boolean = True, Optional ByVal pPrn As Boolean = False, Optional ByVal pAgr As Boolean = True, Optional ByVal pSup As Boolean = True, Optional ByVal pMod As Boolean = True, Optional ByVal pRfr As Boolean = True, Optional ByVal pImport As Boolean = False)

        With pTbr

            .ImageScalingSize = New System.Drawing.Size(16, 16)
            .BackColor = Color.Beige

            If pAgr Then
                Dim btnAgregar = New ToolStripButton
                btnAgregar = MakeToolStripButton(pIco.Images(pIco.Images.IndexOfKey("agregar")), "Agregar", "Agregar [F3]")
                .Items.Add(btnAgregar)
            End If
            If pSup Then
                Dim btnEliminar = New ToolStripButton
                btnEliminar = MakeToolStripButton(pIco.Images(pIco.Images.IndexOfKey("eliminar")), "Eliminar", "Eliminar [Supr]")
                .Items.Add(btnEliminar)
            End If
            If pMod Then
                Dim btnModificar = New ToolStripButton
                btnModificar = MakeToolStripButton(pIco.Images(pIco.Images.IndexOfKey("modificar")), "Modificar", "Modificar [Enter]")
                .Items.Add(btnModificar)
            End If
            If pRfr Then
                Dim btnConsultar = New ToolStripButton
                btnConsultar = MakeToolStripButton(pIco.Images(pIco.Images.IndexOfKey("refrescar")), "Refrescar", "Refrescar [F5]")
                .Items.Add(btnConsultar)
            End If
            If pSal Then
                Dim btnSalir = New ToolStripButton
                btnSalir = MakeToolStripButton(pIco.Images(pIco.Images.IndexOfKey("salir")), "Cerrar", "Cerrar [Esc]")
                .Items.Add(btnSalir)
            End If

            If pImport Then
                Dim btnImportar = New ToolStripButton
                btnImportar = MakeToolStripButton(pIco.Images(pIco.Images.IndexOfKey("agregar")), "Importar", "Importar [F8]")
                .Items.Add(btnImportar)
            End If
        End With

    End Sub
    Public Function MakeToolStripButton(ByVal pIco As Image, ByVal pNom As String, Optional ByVal pToolTipText As String = "") As ToolStripButton

        Dim vItm As New ToolStripButton

        vItm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        vItm.Image = pIco
        vItm.ImageTransparentColor = System.Drawing.Color.Magenta
        vItm.Name = pNom
        vItm.Size = New System.Drawing.Size(23, 22)
        vItm.ToolTipText = pToolTipText

        MakeToolStripButton = vItm

    End Function

    Public Sub SetFirstLine(ByVal pGrid As DataGridView, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Down Then
            If pGrid.RowCount > 0 Then
                pGrid.Rows(0).Selected = True
                pGrid.Focus()
            End If
        End If
    End Sub

    Public Function IsLoad(ByVal pFrmName As String, Optional ByVal pByAccName As Boolean = False) As Boolean
        Dim frm As Object, vLoad As Boolean = False
        For Each frm In Application.OpenForms
            If Not pByAccName Then
                If frm.name = pFrmName Then
                    vLoad = True
                End If
            Else
                If frm.AccessibleName = pFrmName Then
                    vLoad = True
                End If
            End If
        Next
        IsLoad = vLoad

    End Function

    Public Function GetFormByAccessibleName(ByVal pFrmName As String) As Object
        Dim vIdx As Integer = 0, vFnd As Boolean = False
        Do Until vIdx = Application.OpenForms.Count Or vFnd
            If Application.OpenForms(vIdx).AccessibleName = pFrmName Then
                vFnd = True
            Else
                vIdx = vIdx + 1
            End If
        Loop
        If vFnd Then
            GetFormByAccessibleName = Application.OpenForms(vIdx)
        Else
            GetFormByAccessibleName = Nothing
        End If

    End Function
    Public Function nodoArbol(ByVal pKey As String, ByVal pTxt As String, ByVal pImg As String) As TreeNode
        Dim nodo As New TreeNode
        nodo.Name = pKey
        nodo.Text = pTxt
        nodo.ImageKey = pImg
        nodo.SelectedImageKey = pImg
        nodoArbol = nodo
    End Function
    Public Function itemList(ByVal pKey As String, ByVal pTxt As String, ByVal pImg As String) As ListViewItem
        Dim item As New ListViewItem
        item.Name = pKey
        item.Text = pTxt
        item.ImageKey = pImg
        itemList = item
    End Function

    Public Sub SetDateEditFormat(ByVal pDatEdt As DevExpress.XtraEditors.DateEdit)
        pDatEdt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        pDatEdt.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        pDatEdt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        pDatEdt.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        pDatEdt.Properties.Mask.MaskType = DevExpress.Utils.FormatType.DateTime
        pDatEdt.Properties.Mask.EditMask = "dd/MM/yyyy"
        pDatEdt.Text = Now.Date
    End Sub

    Public Sub SetTimeEditFormat(ByVal pTimEdt As DevExpress.XtraEditors.TimeEdit)
        pTimEdt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        pTimEdt.Properties.DisplayFormat.FormatString = "HH:mm"
        pTimEdt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        pTimEdt.Properties.EditFormat.FormatString = "HH:mm"
        pTimEdt.Properties.Mask.MaskType = DevExpress.Utils.FormatType.DateTime
        pTimEdt.Properties.Mask.EditMask = "HH:mm"
        pTimEdt.Text = Format(Now.Hour, "00") & ":" & Format(Now.Minute, "00")
    End Sub

    Public Sub SetTextCurrencyFormat(ByVal pTxt As DevExpress.XtraEditors.TextEdit)
        pTxt.Properties.Mask.MaskType = DevExpress.Utils.FormatType.Custom
        pTxt.Properties.Mask.EditMask = "#,##0.00 $;(#,##0.00 $)"
        pTxt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        pTxt.Properties.Mask.UseMaskAsDisplayFormat = True
    End Sub

    Public Sub SetTextTimeFormat(ByVal pTxt As DevExpress.XtraEditors.TextEdit)
        pTxt.Properties.Mask.MaskType = DevExpress.Utils.FormatType.DateTime
        pTxt.Properties.Mask.EditMask = "HH:mm"
        pTxt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        pTxt.Properties.Mask.UseMaskAsDisplayFormat = True
    End Sub

    Public Function GetEdad(ByVal pFnc As Date) As Integer
        Dim vEda As Integer = 0

        If pFnc < Now.Date Then
            vEda = DateDiff(DateInterval.Year, pFnc, Now.Date)
            pFnc = CDate(pFnc.Day & "/" & pFnc.Month & "/" & Now.Date.Year)
            If DateDiff(DateInterval.Day, pFnc, Now.Date) < 0 Then
                vEda = vEda - 1
            End If
        End If

        GetEdad = vEda

    End Function

End Module