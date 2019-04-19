using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Persistence.Implementations;

namespace SistemaPlanificacionOT.Domain.Implementations
{
    public class OCompraDomain
    {
        private OCompraData ocompraDA = new OCompraData();
        public OCompraModel ConsultarOCompra(int ptipo)
        {
            OCompraModel oCotizacionModel = new OCompraModel();
            oCotizacionModel.lorden_compra = ocompraDA.ListarOCompra(ptipo);
            return oCotizacionModel;
        }
        //public OCompraModel CargarOCompraRegistradas()
        //{
        //    OCompraModel oCotizacionModel = new OCompraModel();
        //    oCotizacionModel.lorden_compra = ocompraDA.ListarOCompra(2);
        //    return oCotizacionModel;
        //}
        public string GrabarOCompra(Cotizacion oCotizacion)
        {
            return ocompraDA.InsertarOCompra(oCotizacion);
        }
        public int EliminarOCompra(int idcot)
        {
            return ocompraDA.EliminarOCompra(idcot);
        }
    }
}
