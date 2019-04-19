using System.Linq;
using NPOI.SS.UserModel;

namespace SistemaPlanificacionOT.Persistence.Common
{
    public static class NpoiExtensions
    {
        public static string GetCellValue(this ICell cell)
        {
            string returnValue = string.Empty;
            if (cell != null)
            {
                switch (cell.CellType)
                {
                    case CellType.String:
                        returnValue = cell.StringCellValue;
                        cell.SetCellValue(cell.StringCellValue);
                        break;
                    case CellType.Numeric:
                        returnValue = cell.NumericCellValue.ToString();
                        cell.SetCellValue(cell.NumericCellValue);
                        break;
                    case CellType.Boolean:
                        returnValue = cell.BooleanCellValue.ToString();
                        cell.SetCellValue(cell.BooleanCellValue);
                        break;
                    case CellType.Formula:
                        switch (cell.CachedFormulaResultType)
                        {
                            case CellType.Numeric:
                                returnValue = cell.NumericCellValue.ToString();
                                break;
                            case CellType.String:
                                returnValue = cell.StringCellValue;
                                break;
                        }
                        break;
                }
            }
            return returnValue;
        }

        public static string GetCellValue(this IRow row, int columnIndex)
        {
            string returnValue = string.Empty;
            if (row != null)
            {
                var cell = row.Cells.AsParallel().FirstOrDefault(c => c.ColumnIndex == columnIndex);
                returnValue = cell.GetCellValue();
            }
            return returnValue;
        }
    }
}