using System;
using System.Data;

namespace WebEUD {
    static class DataSourceInitializer {
        public static object GetData() {
            System.Data.DataSet ds = GetDataSource("dataSet1");
            return ds;
        }
        private static System.Data.DataSet GetDataSource(string name) {
            var ds = new System.Data.DataSet(name);
            var table = new System.Data.DataTable("TestTable");
            table.AddColumns(new DataColumn("TaxType", typeof(string)), new DataColumn("TaxPercent", typeof(double)));
            table.AddRow("Lorem", 0.137);
            table.AddRow("Ipsum", 0.144);
            table.AddRow("Dolor", 0.004);
            table.AddRow("Sit", 0.025);
            table.AddRow("Amet", 0.074);
            table.AddRow("Consectetur", 0.616);
            ds.Tables.Add(table);
            return ds;
        }
    }
}
