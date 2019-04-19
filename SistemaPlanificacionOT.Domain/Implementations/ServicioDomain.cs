using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Persistence.Implementations;

namespace SistemaPlanificacionOT.Domain.Implementations
{
    public class ServicioDomain
    {
        private ServicioData oServicioData = new ServicioData();
        public ServicioModel Obtener()
        {
            ServicioModel oServicioModel = new ServicioModel();
            oServicioModel.Servicios = oServicioData.Consultar();
            return oServicioModel;
        }
        public int Agregar(Servicio oServicio)
        {
            return oServicioData.Agregar(oServicio); ;
        }
    }
}
