namespace SistemaPlanificacionOT.Domain.Models
{
    public class Solicitud
    {
        public string codigo { get; set; }
        public string fregistro { get; set; }
        public string entaller { get; set; }
        public string equipo { get; set; }
        public string cliente { get; set; }
        public Plantilla requerimientos_basicos { get; set; }
    }
}
