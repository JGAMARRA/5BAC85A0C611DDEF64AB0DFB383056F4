using SistemaPlanificacionOT.Domain.Implementations;
using SistemaPlanificacionOT.Domain.Models;
using System.Web.Mvc;

namespace SistemaPlanificacionOT.Web.Controllers
{
    public class OTController : Controller
    {
        // GET: OT
        AGDomain oAGDomain = new AGDomain();
        
        OTDomain oOTDomain = new OTDomain();
        public ActionResult Consultar()
        {
            return View();
        }
        public JsonResult ConsultarOT(int ptipo)
        {
            return Json(oOTDomain.ConsultarOT(ptipo), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Nuevo()
        {
            return View();
        }
        //public JsonResult ObtenerPropuestas(int pcodcotizacion)
        //{
        //    //foreach (var item in oSolucion.lsoluciones)
        //    //{
        //    //    if (item.idCot == pcodcotizacion)
        //    //    {
        //    //        return Json(item, JsonRequestBehavior.AllowGet);
        //    //    }
        //    //}
        //    SolucionModel oSolucion = new SolucionModel();
        //    Cotizacion oCotizacion=oCotizacionDomain.obtenerInfoCotizacion(pcodcotizacion);
        //    oSolucion.lsoluciones = oAGDomain.obtenerOptimoRentabilidad(oCotizacion);
        //    return Json(oSolucion, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GenerarOT(int pcodpropuesta)
        {
            string cod = oOTDomain.GenerarOT(pcodpropuesta);
            return Json(cod, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult ObtenerOT(string pcodot)
        //{
        //   OTModel oModel= oOTDomain.obtenerModel(pcodot);

        //    return Json(oModel, JsonRequestBehavior.AllowGet);
        //}
    }
}