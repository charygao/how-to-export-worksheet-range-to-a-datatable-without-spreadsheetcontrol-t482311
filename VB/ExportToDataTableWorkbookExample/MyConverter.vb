Imports DevExpress.Spreadsheet
Imports DevExpress.Spreadsheet.Export
Imports System

Namespace ExportToDataTableWorkbookExample
    #Region "#MyConverter"
    Friend Class MyConverter
        Implements ICellValueToColumnTypeConverter

        Public Property SkipErrorValues() As Boolean
        Public Property EmptyCellValue() As CellValue Implements ICellValueToColumnTypeConverter.EmptyCellValue

        Public Function Convert(ByVal readOnlyCell As Cell, ByVal cellValue As CellValue, ByVal dataColumnType As Type, <System.Runtime.InteropServices.Out()> ByRef result As Object) As ConversionResult Implements ICellValueToColumnTypeConverter.Convert
            result = DBNull.Value
            Dim converted As ConversionResult = ConversionResult.Success
            If cellValue.IsEmpty Then
                result = EmptyCellValue
                Return converted
            End If
            If cellValue.IsError Then
                ' You can return an error, subsequently the exporter throws an exception if the CellValueConversionError event is unhandled.
                'return SkipErrorValues ? ConversionResult.Success : ConversionResult.Error;
                result = "N/A"
                Return ConversionResult.Success
            End If
            result = String.Format("{0:MMMM-yyyy}", cellValue.DateTimeValue)
            Return converted
        End Function
    End Class
    #End Region ' #MyConverter
End Namespace
