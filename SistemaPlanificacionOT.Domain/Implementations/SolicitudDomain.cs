using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Persistence.Implementations;

namespace SistemaPlanificacionOT.Domain.Implementations
{
    public class SolicitudDomain
    {
        private SolicitudData solicitudDA = new SolicitudData();

        public SolicitudModel CargarModel()
        {
            SolicitudModel oSolicitudModel = new SolicitudModel();
            oSolicitudModel.lsolicitudes = solicitudDA.ListarSolicitud();
            return oSolicitudModel;
        }
        public Solicitud ObtenerSolicitud(string pcodsolicitud)
        {
            return solicitudDA.ObtenerSolicitud(pcodsolicitud);
        }
    }
}
