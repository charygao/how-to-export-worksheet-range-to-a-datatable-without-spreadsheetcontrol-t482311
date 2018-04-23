using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using System;

namespace ExportToDataTableWorkbookExample {
    #region #MyConverter
    class MyConverter : ICellValueToColumnTypeConverter {
        public bool SkipErrorValues { get; set; }
        public CellValue EmptyCellValue { get; set; }

        public ConversionResult Convert(Cell readOnlyCell, CellValue cellValue, Type dataColumnType, out object result) {
            result = DBNull.Value;
            ConversionResult converted = ConversionResult.Success;
            if (cellValue.IsEmpty) {
                result = EmptyCellValue;
                return converted;
            }
            if (cellValue.IsError) {
                // You can return an error, subsequently the exporter throws an exception if the CellValueConversionError event is unhandled.
                //return SkipErrorValues ? ConversionResult.Success : ConversionResult.Error;
                result = "N/A";
                return ConversionResult.Success;
            }
            result = String.Format("{0:MMMM-yyyy}", cellValue.DateTimeValue);
            return converted;
        }
    }
    #endregion #MyConverter
}
