using System.Collections.Generic;

namespace SistemaPlanificacionOT.Domain.Models
{
    public class OTModel
    {
        public string codigo { get; set; }
        public string equipo { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string NroOTReferencia { get; set; }
        public string NroCotizacionReferencia { get; set; }
        public string responsable { get; set; }
        public List<DocumentoGestionCelda> lceldas { get; set; }
        public List<DocumentoGestionComponente> lcomponentes { get; set; }
        public List<DocumentoGestionPersonal> lpersonal { get; set; }
        public List<OTInfo> lots { get; set; }
    }
}
