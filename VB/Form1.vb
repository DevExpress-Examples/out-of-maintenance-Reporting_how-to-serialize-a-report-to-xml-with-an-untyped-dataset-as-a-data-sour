Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraReports.Native
Imports DevExpress.XtraReports.UI
Imports WebEUD

Namespace dxSample
	Partial Public Class Form1
		Inherits Form

		Private fileName As String = ".\testReport.xml"
		Shared Sub New()
			SerializationService.RegisterSerializer(CustomUntypedDataSetSerializer.Name, New CustomUntypedDataSetSerializer())
		End Sub
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			LoadReportAndSaveToXml()
		End Sub
		Private Sub LoadReportAndSaveToXml()
			Dim report As New XtraReport()
			InitDataSource(report)
			InitControls(report)
			InitExtensions(report)
			report.SaveLayoutToXml(fileName)
		End Sub
		Private Sub btnOpenDesigner_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOpenDesigner.Click
			Dim report As New XtraReport()
			report.LoadLayoutFromXml(fileName)
			CType(New ReportDesignTool(report), ReportDesignTool).ShowDesigner()
		End Sub
		Private Shared Sub InitExtensions(ByVal report As XtraReport)
			report.Extensions(SerializationService.Guid) = CustomUntypedDataSetSerializer.Name
		End Sub
		Private Shared Sub InitDataSource(ByVal report As XtraReport)
			report.DataSource = DataSourceInitializer.GetData()
			report.DataMember = "TestTable"
		End Sub
		Private Shared Sub InitControls(ByVal report As XtraReport)
			Dim lbl As New XRLabel()
			lbl.LocationF = New System.Drawing.PointF(0, 0)
			lbl.SizeF = New System.Drawing.SizeF(200, 20)
			lbl.DataBindings.Add(New XRBinding("Text", Nothing, "TaxType"))
			If report.Bands(BandKind.Detail) Is Nothing Then
				report.Bands.Add(New DetailBand())
			End If
			report.Bands(BandKind.Detail).Controls.Add(lbl)
		End Sub


	End Class
End Namespace
