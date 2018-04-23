using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraReports.Native;
using DevExpress.XtraReports.UI;
using WebEUD;

namespace dxSample {
    public partial class Form1 : Form {
        private string fileName = @".\testReport.xml";
        static Form1() {
            SerializationService.RegisterSerializer(CustomUntypedDataSetSerializer.Name, new CustomUntypedDataSetSerializer());
        }
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            LoadReportAndSaveToXml();
        }
        private void LoadReportAndSaveToXml() {
            XtraReport report = new XtraReport();
            InitDataSource(report);
            InitControls(report);
            InitExtensions(report);
            report.SaveLayoutToXml(fileName);
        }
        private void btnOpenDesigner_Click(object sender, EventArgs e) {
            XtraReport report = new XtraReport();
            report.LoadLayoutFromXml(fileName);
            new ReportDesignTool(report).ShowDesigner();
        }
        private static void InitExtensions(XtraReport report) {
            report.Extensions[SerializationService.Guid] = CustomUntypedDataSetSerializer.Name;
        }
        private static void InitDataSource(XtraReport report) {
            report.DataSource = DataSourceInitializer.GetData();
            report.DataMember = "TestTable";
        }
        private static void InitControls(XtraReport report) {
            XRLabel lbl = new XRLabel();
            lbl.LocationF = new System.Drawing.PointF(0, 0);
            lbl.SizeF = new System.Drawing.SizeF(200, 20);
            lbl.DataBindings.Add(new XRBinding("Text", null, "TaxType"));
            if (report.Bands[BandKind.Detail] == null) {
                report.Bands.Add(new DetailBand());
            }
            report.Bands[BandKind.Detail].Controls.Add(lbl);
        }

       
    }
}
