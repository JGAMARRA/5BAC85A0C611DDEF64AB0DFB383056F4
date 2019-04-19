using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Persistence.Implementations;

namespace SistemaPlanificacionOT.Domain.Implementations
{
    public class OTDomain
    {
        private OTData oOTDA = new OTData();

        public OTModel obtenerModel(string id)
        {                    
            return oOTDA.ObtenerDocumentoGestion(id);
        }
        public OTModel ConsultarOT(int ptipo)
        {
            OTModel oOTModel = new OTModel();
            oOTModel.lots = oOTDA.ListarOT(ptipo);
            return oOTModel;
        }

        public string GenerarOT(int idpropuesta)
        {
            return oOTDA.GenerarOT(idpropuesta);
        }
    }
}
