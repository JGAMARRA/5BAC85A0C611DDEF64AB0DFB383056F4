using SistemaPlanificacionOT.Domain.Implementations;
using SistemaPlanificacionOT.Domain.Models;
using System.Web.Mvc;

namespace SistemaPlanificacionOT.Web.Controllers
{
    public class ParametroController : Controller
    {
        ParametroDomain oParametroDomain = new ParametroDomain();
        // GET: Parametro
        [HttpPost]
        public ActionResult CargarDatosGeneralesCotizacion()
        {            
            return Json(oParametroDomain.ObtenerDatosGeneralesCotizacion(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerServicioTipo()
        {
            return Json(oParametroDomain.obtenerParametrosServicio(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ObtenerDatosRecurso(int tipo)
        {
            return Json(oParametroDomain.obtenerDatosRecurso(tipo), JsonRequestBehavior.AllowGet);
        }
    }
}