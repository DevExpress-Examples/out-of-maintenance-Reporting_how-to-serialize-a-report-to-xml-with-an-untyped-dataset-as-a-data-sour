Imports System
Imports System.Data

Namespace WebEUD
	Friend NotInheritable Class DataSourceInitializer

		Private Sub New()
		End Sub

		Public Shared Function GetData() As Object
			Dim ds As System.Data.DataSet = GetDataSource("dataSet1")
			Return ds
		End Function
		Private Shared Function GetDataSource(ByVal name As String) As System.Data.DataSet
			Dim ds = New System.Data.DataSet(name)
			Dim table = New System.Data.DataTable("TestTable")
			table.AddColumns(New DataColumn("TaxType", GetType(String)), New DataColumn("TaxPercent", GetType(Double)))
			table.AddRow("Lorem", 0.137)
			table.AddRow("Ipsum", 0.144)
			table.AddRow("Dolor", 0.004)
			table.AddRow("Sit", 0.025)
			table.AddRow("Amet", 0.074)
			table.AddRow("Consectetur", 0.616)
			ds.Tables.Add(table)
			Return ds
		End Function
	End Class
End Namespace
