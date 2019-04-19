using System.Collections.Generic;

namespace SistemaPlanificacionOT.Domain.Models.AG
{
    public class Propuesta
    {
        public decimal costoTotal { get; set; }
        public List<Cantidad> lcantidades { get; set; }
        public List<Recurso> lpropuesta { get; set; }
    }
}
