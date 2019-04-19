namespace SistemaPlanificacionOT.Domain.Models
{
    public class OTInfo
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string fecRecepcion { get; set; }
        public string cliente { get; set; }
        public string estadoOT { get; set; }
        public string nro_oc_ref { get; set; }
        public decimal total { get; set; }
        public string responsable { get; set; }
        public string equipo { get; set; }
        public string moneda { get; set; }
    }
}
