using System.Collections.Generic;

namespace SistemaPlanificacionOT.Domain.Models.AG
{
    public class Solucion
    {
        public int nroSoluciones { get; set; }
        public int margen { get; set; }
        public decimal gananciaTope { get; set; }
        public List<Propuesta> lpropuesta { get; set; }


    }
}
