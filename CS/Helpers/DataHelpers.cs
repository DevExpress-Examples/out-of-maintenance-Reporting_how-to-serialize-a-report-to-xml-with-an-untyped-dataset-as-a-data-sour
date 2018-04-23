using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Data {
    static class DataHelpers {
        public static void AddColumns(this DataTable source, params DataColumn[] columns) {
            source.Columns.AddRange(columns);
        }

        public static void AddRow(this DataTable source, params object[] values) {
            source.Rows.Add(values);
        }
    }

}