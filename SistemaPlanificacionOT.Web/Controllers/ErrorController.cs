using System.Web.Mvc;
using SistemaPlanificacionOT.Web.Models;

namespace SistemaPlanificacionOT.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ApplicationError()
        {
            var ex = HttpContext.Server.GetLastError();
            var app = HttpContext.ApplicationInstance;

            var errors = app.Context.AllErrors?.Length;
            var model = new ErrorInfoModel
            {
                Message = ex?.Message,
                Exception = ex,
                TipoError = "Server Error",
                StackTrace = $"Total errores: {errors.GetValueOrDefault()}"
            };
            return View(model: model);
        }

        public ActionResult SessionTimeOut()
        {
            return View();
        }

        public ActionResult TokenInvalido()
        {
            return View();
        }

        public ActionResult AccesoNoAutorizado()
        {
            return View();
        }

    }
}