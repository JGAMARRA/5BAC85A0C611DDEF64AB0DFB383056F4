using SistemaPlanificacionOT.Domain.Implementations;
using SistemaPlanificacionOT.Domain.Models;
using System.Web.Mvc;

namespace SistemaPlanificacionOT.Web.Controllers
{
    public class CotizacionController : Controller
    {
        CotizacionDomain oCotizacionDomain = new CotizacionDomain();
        
        ParametroDomain oParametroDomain = new ParametroDomain();
        AGDomain oAGDomain = new AGDomain();                
        public ActionResult Consultar()
        {
            return View();
        }
        public JsonResult ConsultarCotizaciones(int ptipo) {
            return Json(oCotizacionDomain.CargarModel(ptipo), JsonRequestBehavior.AllowGet);
        }
        public JsonResult EliminarCotizacion(int idcot)
        {
            return Json(oCotizacionDomain.EliminarCotizacion(idcot), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        // Obtener Cotizaciones: Cotizacion
        //public JsonResult Obtener(string Usuario)
        //{
        //    CotizacionModel oCotizacionModel = new CotizacionModel();
        //    oCotizacionModel = oCotizacionDomain.obtenerModel();
        //    return Json(oCotizacionModel, JsonRequestBehavior.AllowGet);
        //}

        //// Obtener Ordenes de Compra: OCompra
        //public JsonResult ObtenerOCompra(string Usuario)
        //{
        //    OCompraModel oOCompraModel = new OCompraModel();
        //    oOCompraModel = oCotizacionDomain.obtenerModelOCompra();
        //    return Json(oOCompraModel, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult ObtenerFPago(string Usuario)
        //{
        //    FormaPagoModel oFormaPago = new FormaPagoModel();
        //    oFormaPago = oCotizacionDomain.obtenerFormaPago();
        //    return Json(oFormaPago, JsonRequestBehavior.AllowGet);
        //}



        ////public JsonResult GenerarOT(Cotizacion objCotizacion)
        ////{

        ////    SolucionModel oSolucion = new SolucionModel();

        ////    //objCotizacion.idCot = 5;
        ////    //objCotizacion = oCotizacionDomain.obtenerInfoCotizacion(5);
        ////    oSolucion.lsoluciones = oAGDomain.obtenerOptimoRentabilidad(objCotizacion);
        ////    //desplegar respuestas

        ////    return Json(oSolucion, JsonRequestBehavior.AllowGet);
        ////}
        public JsonResult GrabarCotizacion(Cotizacion objCotizacion)
        {

            objCotizacion = oCotizacionDomain.GrabarCotizacion(objCotizacion);
            SolucionModel oSolucion = new SolucionModel();            
            oSolucion.lsoluciones = oAGDomain.obtenerOptimoRentabilidad(objCotizacion);
            return Json(oSolucion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ConsultarCotizacion(string pcodpropuesta)
        {
            Cotizacion oCot = oCotizacionDomain.obtenerInfoTmpCotizacion(pcodpropuesta);
            return Json(oCot, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ConsultarCotizacionFinal(int pidcot)
        {
            Cotizacion oCot = oCotizacionDomain.obtenerInfoCotizacion(pidcot);
            return Json(oCot, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AceptarPropuesta(int pcodcotizacion)
        {
            string cod = oCotizacionDomain.GrabarCotizacionPropuesta(pcodcotizacion);
            return Json(cod, JsonRequestBehavior.AllowGet);
        }
    }
}