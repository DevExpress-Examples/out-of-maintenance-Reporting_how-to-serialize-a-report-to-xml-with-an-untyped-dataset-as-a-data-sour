Imports System
Imports System.Data
Imports System.IO
Imports System.Xml
Imports DevExpress.XtraReports.Native

Namespace WebEUD
	Public Class CustomUntypedDataSetSerializer
		Implements IDataSerializer

		Public Const Name As String = "CustomUntypedDataSetSerializer"
		Public Function CanSerialize(ByVal data As Object, ByVal extensionProvider As Object) As Boolean Implements IDataSerializer.CanSerialize
			Return (TypeOf data Is DataSet)
		End Function
		Public Function Serialize(ByVal data As Object, ByVal extensionProvider As Object) As String Implements IDataSerializer.Serialize
			If TypeOf data Is DataSet Then
				Dim ds As DataSet = TryCast(data, DataSet)
				Dim sb As New System.Text.StringBuilder()
				Dim writer As XmlWriter = XmlWriter.Create(sb)
				ds.WriteXml(writer, XmlWriteMode.WriteSchema)
				Return sb.ToString()
			End If
			Return String.Empty
		End Function
		Public Function CanDeserialize(ByVal value As String, ByVal typeName As String, ByVal extensionProvider As Object) As Boolean Implements IDataSerializer.CanDeserialize
			Return typeName = "System.Data.DataSet"
		End Function
		Public Function Deserialize(ByVal value As String, ByVal typeName As String, ByVal extensionProvider As Object) As Object Implements IDataSerializer.Deserialize
			Dim ds As New DataSet()
			Using reader As XmlReader = XmlReader.Create(New StringReader(value))
				ds.ReadXml(reader, XmlReadMode.ReadSchema)
			End Using
			Return ds
		End Function
	End Class
End Namespace
