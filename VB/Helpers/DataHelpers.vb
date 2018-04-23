Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace System.Data
	Friend Module DataHelpers
		<System.Runtime.CompilerServices.Extension> _
		Public Sub AddColumns(ByVal source As DataTable, ParamArray ByVal columns() As DataColumn)
			source.Columns.AddRange(columns)
		End Sub

		<System.Runtime.CompilerServices.Extension> _
		Public Sub AddRow(ByVal source As DataTable, ParamArray ByVal values() As Object)
			source.Rows.Add(values)
		End Sub
	End Module

End Namespace