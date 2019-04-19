using System;
using System.IO;
using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Domain.Models.Common;
using SistemaPlanificacionOT.Infraestructure.Settings;
using SistemaPlanificacionOT.Persistence.Common;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace SistemaPlanificacionOT.Persistence.Data
{
    public class ExcelDataAccess : IDisposable
    {
        private readonly Stream _stream;
        readonly IWorkbook _workbook;
        private string _sheetName;
        public ExcelDataAccess(Stream stream, string excelFileExtension, string sheetName)
        {
            _stream = stream;
            _sheetName = sheetName;


            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                ms.Position = 0;
                _workbook = excelFileExtension.Equals(ApplicationConstants.ExtensionXlsx, StringComparison.OrdinalIgnoreCase) ? (IWorkbook)new XSSFWorkbook(ms) : new HSSFWorkbook(ms);
                //WorkbookFactory
            }
        }

        public T GetCellValue<T>(int fila, int columna)
        {
            var sheet = _workbook.GetSheet(_sheetName);
            var cellValue = sheet.GetRow(fila).GetCellValue(columna);
            if (string.IsNullOrWhiteSpace(cellValue))
                return default(T);
            var value = (T)Convert.ChangeType(cellValue, typeof(T), null);
            return value;
        }

        public Range GetCellRange(int fila, int columna)
        {
            Range cell=new Range();
            cell.column = columna;
            cell.row = fila;
            cell.value = ObtenerValor(GetCellValue<string>(fila, columna));
            return cell;
        }

        public void SelectWorkBookSheet(string sheetName)
        {
            _sheetName = sheetName;
        }

        private string ObtenerValor(string cellValue)
        {
            string[] arr = null;

            string valor = null;
            if (string.IsNullOrWhiteSpace(cellValue)==false)
            {
                arr = cellValue.Split('_');
                if (arr.Length == 2)
                {
                    valor = arr[1].ToString().TrimEnd();
                }
                else {
                    valor = arr[0];
                }

            }
            else {
                valor = "";
            }                                        
            return valor;
        }
        public bool EsValido(string cell, bool validaVacio)
        {
            bool val = true;
            if (validaVacio == true)
            {
                if (string.IsNullOrWhiteSpace(cell) == true) { val = false; };
            }
            return val;
        }


        public void Dispose()
        {
            _stream?.Dispose();
        }

    }
}