using System.Collections.Generic;

namespace SistemaPlanificacionOT.Domain.Models
{
    public class Plantilla
    {
        public List<Servicio> lservicios { get; set; }
        public List<Especialidad> lespecialidades { get; set; }
        public List<Componente> lcomponentes { get; set; }
        public List<TipoComponente> ltipocomponentes { get; set; }
        public List<Empleado> lempleados { get; set; }
       // public List<Celda> lceldas { get; set; }
    }
}
