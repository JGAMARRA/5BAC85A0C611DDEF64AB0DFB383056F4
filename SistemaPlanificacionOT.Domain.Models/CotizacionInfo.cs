namespace SistemaPlanificacionOT.Domain.Models
{
    public class CotizacionInfo
    {
        public int idSolicitudServicioCab { get; set; }
        public int idCotizacionCab { get; set; }
        public string codigosolicitud { get; set; }
        public string fecRegistro { get; set; }
        public string cliente { get; set; }
        public string equipo { get; set; }
        public string responsable { get; set; }
        public string estado { get; set; }
        public string nCotizacion { get; set; }
        public string fecVencimiento { get; set; }
        public decimal total { get; set; }
        public string moneda { get; set; }


    }
}

