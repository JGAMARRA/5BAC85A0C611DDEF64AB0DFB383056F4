using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Persistence.Implementations;

namespace SistemaPlanificacionOT.Domain.Implementations
{
    public class ParametroDomain
    {
        private ParametroData parametroDA = new ParametroData();
        public ParametrosModel ObtenerDatosGeneralesCotizacion()
        {
            ParametrosModel oParametro = new ParametrosModel();
            oParametro = parametroDA.ObtenerDatosCotizacion();
            return oParametro;
        }
        public ParametrosModel obtenerParametrosServicio()
        {
            return parametroDA.ObtenerParametrosServicio();
        }
        public ParametrosModel obtenerDatosRecurso(int tipo)
        {
            return parametroDA.ObtenerDatosRecurso(tipo);
        }
    }
}
