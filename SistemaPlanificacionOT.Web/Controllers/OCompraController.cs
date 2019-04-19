using SistemaPlanificacionOT.Domain.Implementations;
using SistemaPlanificacionOT.Domain.Models;
using System.Web.Mvc;

namespace SistemaPlanificacionOT.Web.Controllers
{
    public class OCompraController : Controller
    {
        OCompraDomain oOCompraDomain = new OCompraDomain();
        // GET: OCompra
        public ActionResult Consultar()
        {
            return View();
        }
        public JsonResult ConsultarOCompra(int ptipo) {
            return Json(oOCompraDomain.ConsultarOCompra(ptipo), JsonRequestBehavior.AllowGet);
        }
        //public JsonResult CargarOCompraRegistradas()
        //{
        //    return Json(oOCompraDomain.CargarOCompraRegistradas(), JsonRequestBehavior.AllowGet);
        //}
        public ActionResult Nuevo()
        {
            return View();
        }
        public JsonResult GrabarOCompra(Cotizacion objCotizacion)
        {                        
            return Json(oOCompraDomain.GrabarOCompra(objCotizacion), JsonRequestBehavior.AllowGet);
        }
        public JsonResult EliminarOCompra(int idcot)
        {
            return Json(oOCompraDomain.EliminarOCompra(idcot), JsonRequestBehavior.AllowGet);
        }

    }
}