using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanificacionOT.Domain.Models.Common
{
    public class ImportExcelResponseModel
    {
        public string code { get; set; }
        public string idReg { get; set; }
        public string totReg { get; set; }
        public string message { get; set; }
        public List<ExcelErrors> listErrors { get; set; }
        public List<ParametricasModel> lstCalificacionesSBS { get; set; }

        public ImportExcelResponseModel()
        {
            code = "";
            idReg = "";
            totReg = "";
            message = "";
            listErrors = new List<ExcelErrors>();
        }

        public ImportExcelResponseModel(string mensaje)
        {
            string[] arr = mensaje.Split('|');

            listErrors = new List<ExcelErrors>();
            arr = mensaje.Split('|');
            if (arr[0] == "99")
            {
                code = arr[0];
                idReg = arr[1];
                totReg = arr[2];
                message = arr[3].ToString();

            }
            else
            {
                listErrors.Add(new ExcelErrors(arr[0], arr[1], arr[2], arr[3]));
            }
        }
    }
}
