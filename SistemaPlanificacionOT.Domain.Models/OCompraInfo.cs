namespace SistemaPlanificacionOT.Domain.Models
{
    public class OCompraInfo
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string fecRecepcion { get; set; }
        public string cliente { get; set; }
        public string estadoOC { get; set; }
        public string ncotref { get; set; }
        public decimal total { get; set; }
        public string responsable { get; set; }
        public string equipo { get; set; }
        public string moneda { get; set; }
    }
}
