using System.Collections.Generic;

namespace SistemaPlanificacionOT.Domain.Models
{
    public class ParametrosModel
    {
        public List<Moneda> lmonedas { get; set; }
        public List<Empleado> lempleados { get; set; }
        public List<ServicioTipo> ltiposervicios { get; set; }
        public List<FormaPago> lfpagos { get; set; }
        public List<Celda> lceldas { get; set; }
        public List<Componente> lcomponentes { get; set; }
        public List<TipoComponente> ltipocomponentes { get; set; }
        public List<Especialidad> lespecialidades { get; set; }
        public List<Servicio> lservicios { get; set; }
    }
}
