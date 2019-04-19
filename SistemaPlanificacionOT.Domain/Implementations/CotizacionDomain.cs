using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Persistence.Implementations;

namespace SistemaPlanificacionOT.Domain.Implementations
{
    public class CotizacionDomain
    {
        private CotizacionData cotizacionDA = new CotizacionData();


        public CotizacionModel CargarModel(int ptipo)
        {
            CotizacionModel oCotizacionModel = new CotizacionModel();
            oCotizacionModel.lcotizaciones = cotizacionDA.ListarCotizacion(ptipo);
            return oCotizacionModel;
        }
        public int EliminarCotizacion(int idcot)
        {                        
            return cotizacionDA.EliminarCotizacion(idcot);
        }

        //public OCompraModel obtenerModelOCompra()
        //{
        //    OCompraModel oOCompraModel = new OCompraModel();
        //    oOCompraModel.lorden_compra = cotizacionDA.ListarOCompra(1);
        //    return oOCompraModel;
        //}

        public Cotizacion obtenerInfoCotizacion(int pidcotizacion)
        {
            Cotizacion oCotizacion = new Cotizacion();
            return cotizacionDA.ObtenerInfoCotizacion(pidcotizacion); ;
        }

        public Cotizacion obtenerInfoTmpCotizacion(string pidpropuesta)
        {
            Cotizacion oCotizacion = new Cotizacion();
            return cotizacionDA.ObtenerInfoTmpCotizacion(pidpropuesta); ;
        }


        //public FormaPagoModel obtenerFormaPago()
        //{
        //    FormaPagoModel oFormaPago = new FormaPagoModel();
        //    oFormaPago.lfpagos = cotizacionDA.ListarFormaPago();
        //    return oFormaPago;
        //}
        public Cotizacion GrabarCotizacion(Cotizacion oCotizacion)
        {
            return cotizacionDA.InsertarCotizacion(oCotizacion);
        }
        public string GrabarCotizacionPropuesta(int idcot)
        {
            return cotizacionDA.GenerarCotizacion(idcot);
        }
        //public CeldaModel obtenerCeldas()
        //{
        //    CeldaModel oCelda = new CeldaModel();
        //    oCelda.lceldas= cotizacionDA.ListarCeldas();
        //    return oCelda;
        //}
    }
}
