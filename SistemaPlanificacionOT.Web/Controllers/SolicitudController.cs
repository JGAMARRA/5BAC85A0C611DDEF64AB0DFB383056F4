using SistemaPlanificacionOT.Domain.Implementations;
using SistemaPlanificacionOT.Domain.Models;
using System.Web.Mvc;

namespace SistemaPlanificacionOT.Web.Controllers
{
    public class SolicitudController : Controller
    {
        SolicitudDomain oSolicitudDomain = new SolicitudDomain();
        // GET: Solicitud
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ConsultarSolicitudes()
        {
            return Json(oSolicitudDomain.CargarModel(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ConsultarSolicitud(string pcodsolicitud)
        {         
            return Json(oSolicitudDomain.ObtenerSolicitud(pcodsolicitud), JsonRequestBehavior.AllowGet);
        }

    }
}