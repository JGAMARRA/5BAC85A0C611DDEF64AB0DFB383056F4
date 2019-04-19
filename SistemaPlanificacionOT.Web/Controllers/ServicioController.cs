using SistemaPlanificacionOT.Domain.Implementations;
using SistemaPlanificacionOT.Domain.Models;
using System.Web.Mvc;

namespace SistemaPlanificacionOT.Web.Controllers
{
    public class ServicioController : Controller
    {
        // GET: Servicio
        ServicioDomain oServicioDomain = new ServicioDomain();
        public ActionResult Consulta()
        {
            
            return View();
        }
        public JsonResult Obtener()
        {
            return Json(oServicioDomain.Obtener(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Agregar(Servicio oServicio)
        {
            return Json(oServicioDomain.Agregar(oServicio), JsonRequestBehavior.AllowGet);
        }
    }
}