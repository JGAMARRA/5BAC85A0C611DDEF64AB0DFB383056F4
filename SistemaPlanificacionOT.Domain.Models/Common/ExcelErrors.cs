using System;

namespace SistemaPlanificacionOT.Domain.Models.Common
{
    public class ExcelErrors
    {
        public string value { get; set; }
        public string msg { get; set; }
        public string row { get; set; }
        public string column { get; set; }
        public ExcelErrors(string pvalue, string pmsg, string prow, string pcolumn)
        {
            value = pvalue;
            msg = pmsg;
            row = prow;
            column = pcolumn;
        }
    }
}
