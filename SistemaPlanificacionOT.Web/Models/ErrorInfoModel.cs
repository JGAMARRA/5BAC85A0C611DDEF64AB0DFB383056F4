using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;

namespace SistemaPlanificacionOT.Web.Models
{
    public class ErrorInfoModel
    {
        public Exception Exception { get; set; }
        public string TipoError { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}