<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadisticas
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim SimpleDiagram3D1 As DevExpress.XtraCharts.SimpleDiagram3D = New DevExpress.XtraCharts.SimpleDiagram3D()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim Pie3DSeriesLabel1 As DevExpress.XtraCharts.Pie3DSeriesLabel = New DevExpress.XtraCharts.Pie3DSeriesLabel()
        Dim PiePointOptions1 As DevExpress.XtraCharts.PiePointOptions = New DevExpress.XtraCharts.PiePointOptions()
        Dim PiePointOptions2 As DevExpress.XtraCharts.PiePointOptions = New DevExpress.XtraCharts.PiePointOptions()
        Dim SeriesPoint1 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("MUJERES", New Object() {CType(30.0R, Object)}, 0)
        Dim SeriesPoint2 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("HOMBRES", New Object() {CType(30.0R, Object)}, 1)
        Dim SeriesPoint3 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("NIÑOS", New Object() {CType(40.0R, Object)}, 2)
        Dim Pie3DSeriesView1 As DevExpress.XtraCharts.Pie3DSeriesView = New DevExpress.XtraCharts.Pie3DSeriesView()
        Dim Pie3DSeriesLabel2 As DevExpress.XtraCharts.Pie3DSeriesLabel = New DevExpress.XtraCharts.Pie3DSeriesLabel()
        Dim PiePointOptions3 As DevExpress.XtraCharts.PiePointOptions = New DevExpress.XtraCharts.PiePointOptions()
        Dim Pie3DSeriesView2 As DevExpress.XtraCharts.Pie3DSeriesView = New DevExpress.XtraCharts.Pie3DSeriesView()
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim StockSeriesLabel1 As DevExpress.XtraCharts.StockSeriesLabel = New DevExpress.XtraCharts.StockSeriesLabel()
        Dim SeriesPoint4 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("DISFRAZ MUJER", New Object() {CType(10.0R, Object), CType(20.0R, Object), CType(0.0R, Object), CType(0.0R, Object)})
        Dim SeriesPoint5 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("DISFRAZ HOMBRE", New Object() {CType(20.0R, Object), CType(40.0R, Object), CType(0.0R, Object), CType(0.0R, Object)})
        Dim SeriesPoint6 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("DISFRAZ NIÑO", New Object() {CType(15.0R, Object), CType(30.0R, Object), CType(0.0R, Object), CType(0.0R, Object)})
        Dim StockSeriesView1 As DevExpress.XtraCharts.StockSeriesView = New DevExpress.XtraCharts.StockSeriesView()
        Dim StockSeriesLabel2 As DevExpress.XtraCharts.StockSeriesLabel = New DevExpress.XtraCharts.StockSeriesLabel()
        Dim StockSeriesView2 As DevExpress.XtraCharts.StockSeriesView = New DevExpress.XtraCharts.StockSeriesView()
        Dim XyDiagram2 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series3 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim PointSeriesLabel1 As DevExpress.XtraCharts.PointSeriesLabel = New DevExpress.XtraCharts.PointSeriesLabel()
        Dim SeriesPoint7 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("SUPERMAN", New Object() {CType(400.0R, Object)})
        Dim SeriesPoint8 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("BATMAN", New Object() {CType(200.0R, Object)})
        Dim AreaSeriesView1 As DevExpress.XtraCharts.AreaSeriesView = New DevExpress.XtraCharts.AreaSeriesView()
        Dim Series4 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim PointSeriesLabel2 As DevExpress.XtraCharts.PointSeriesLabel = New DevExpress.XtraCharts.PointSeriesLabel()
        Dim SeriesPoint9 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("MUJER MARAVILLA", New Object() {CType(100.0R, Object)})
        Dim SeriesPoint10 As DevExpress.XtraCharts.SeriesPoint = New DevExpress.XtraCharts.SeriesPoint("REY LEON", New Object() {CType(150.0R, Object)})
        Dim AreaSeriesView2 As DevExpress.XtraCharts.AreaSeriesView = New DevExpress.XtraCharts.AreaSeriesView()
        Dim PointSeriesLabel3 As DevExpress.XtraCharts.PointSeriesLabel = New DevExpress.XtraCharts.PointSeriesLabel()
        Dim AreaSeriesView3 As DevExpress.XtraCharts.AreaSeriesView = New DevExpress.XtraCharts.AreaSeriesView()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        Me.ChartControl2 = New DevExpress.XtraCharts.ChartControl()
        Me.ChartControl3 = New DevExpress.XtraCharts.ChartControl()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SimpleDiagram3D1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Pie3DSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Pie3DSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Pie3DSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Pie3DSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(StockSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(StockSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(StockSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(StockSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PointSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(AreaSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PointSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(AreaSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PointSeriesLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(AreaSeriesView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChartControl1
        '
        Me.ChartControl1.BackColor = System.Drawing.Color.Transparent
        SimpleDiagram3D1.RotationMatrixSerializable = "1;0;0;0;0;0.5;-0.866025403784439;0;0;0.866025403784439;0.5;0;0;0;0;1"
        Me.ChartControl1.Diagram = SimpleDiagram3D1
        Me.ChartControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartControl1.Location = New System.Drawing.Point(0, 0)
        Me.ChartControl1.Name = "ChartControl1"
        Pie3DSeriesLabel1.LineVisible = True
        PiePointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent
        Pie3DSeriesLabel1.PointOptions = PiePointOptions1
        Series1.Label = Pie3DSeriesLabel1
        Series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[True]
        PiePointOptions2.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues
        PiePointOptions2.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Percent
        Series1.LegendPointOptions = PiePointOptions2
        Series1.Name = "Ventas"
        Series1.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint1, SeriesPoint2, SeriesPoint3})
        Series1.SynchronizePointOptions = False
        Pie3DSeriesView1.SizeAsPercentage = 100.0R
        Series1.View = Pie3DSeriesView1
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        Pie3DSeriesLabel2.LineVisible = True
        PiePointOptions3.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
        Pie3DSeriesLabel2.PointOptions = PiePointOptions3
        Me.ChartControl1.SeriesTemplate.Label = Pie3DSeriesLabel2
        Pie3DSeriesView2.SizeAsPercentage = 100.0R
        Me.ChartControl1.SeriesTemplate.View = Pie3DSeriesView2
        Me.ChartControl1.Size = New System.Drawing.Size(821, 422)
        Me.ChartControl1.TabIndex = 0
        '
        'ChartControl2
        '
        XyDiagram1.AxisX.Range.AlwaysShowZeroLevel = True
        XyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram1.AxisX.Range.SideMarginsEnabled = True
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.Range.AlwaysShowZeroLevel = True
        XyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram1.AxisY.Range.SideMarginsEnabled = True
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.ChartControl2.Diagram = XyDiagram1
        Me.ChartControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartControl2.Location = New System.Drawing.Point(0, 0)
        Me.ChartControl2.Name = "ChartControl2"
        Series2.Label = StockSeriesLabel1
        Series2.Name = "Series 1"
        Series2.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint4, SeriesPoint5, SeriesPoint6})
        Series2.View = StockSeriesView1
        Me.ChartControl2.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series2}
        Me.ChartControl2.SeriesTemplate.Label = StockSeriesLabel2
        Me.ChartControl2.SeriesTemplate.View = StockSeriesView2
        Me.ChartControl2.Size = New System.Drawing.Size(821, 422)
        Me.ChartControl2.TabIndex = 1
        Me.ChartControl2.Visible = False
        '
        'ChartControl3
        '
        XyDiagram2.AxisX.Range.AlwaysShowZeroLevel = True
        XyDiagram2.AxisX.Range.ScrollingRange.SideMarginsEnabled = False
        XyDiagram2.AxisX.Range.SideMarginsEnabled = False
        XyDiagram2.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram2.AxisY.Range.AlwaysShowZeroLevel = True
        XyDiagram2.AxisY.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram2.AxisY.Range.SideMarginsEnabled = True
        XyDiagram2.AxisY.VisibleInPanesSerializable = "-1"
        Me.ChartControl3.Diagram = XyDiagram2
        Me.ChartControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartControl3.Location = New System.Drawing.Point(0, 0)
        Me.ChartControl3.Name = "ChartControl3"
        PointSeriesLabel1.LineVisible = True
        Series3.Label = PointSeriesLabel1
        Series3.Name = "Series 1"
        Series3.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint7, SeriesPoint8})
        Series3.View = AreaSeriesView1
        PointSeriesLabel2.LineVisible = True
        Series4.Label = PointSeriesLabel2
        Series4.Name = "Series 2"
        Series4.Points.AddRange(New DevExpress.XtraCharts.SeriesPoint() {SeriesPoint9, SeriesPoint10})
        Series4.View = AreaSeriesView2
        Me.ChartControl3.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series3, Series4}
        PointSeriesLabel3.LineVisible = True
        Me.ChartControl3.SeriesTemplate.Label = PointSeriesLabel3
        AreaSeriesView3.Transparency = CType(0, Byte)
        Me.ChartControl3.SeriesTemplate.View = AreaSeriesView3
        Me.ChartControl3.Size = New System.Drawing.Size(821, 422)
        Me.ChartControl3.TabIndex = 2
        Me.ChartControl3.Visible = False
        '
        'frmEstadisticas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 422)
        Me.Controls.Add(Me.ChartControl3)
        Me.Controls.Add(Me.ChartControl2)
        Me.Controls.Add(Me.ChartControl1)
        Me.Name = "frmEstadisticas"
        Me.Text = "Estadísticas"
        CType(SimpleDiagram3D1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Pie3DSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Pie3DSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Pie3DSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Pie3DSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(StockSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(StockSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(StockSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(StockSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PointSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(AreaSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PointSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(AreaSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PointSeriesLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(AreaSeriesView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents ChartControl2 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents ChartControl3 As DevExpress.XtraCharts.ChartControl
End Class
