using System.Collections.Generic;

namespace SistemaPlanificacionOT.Domain.Models
{
    public class Cotizacion
    {
        public string seleccion { get; set; }
        public int generacion { get; set; }
        public int idCot { get; set; }
        public string numSolicitud { get; set; }
        public string fvencimiento { get; set; }
        public string fterminado { get; set; }
        public string frecepcion { get; set; }
        public string finicio { get; set; }
        
        public int n_dias_hasta_termino { get; set; }
        public string nomCliente { get; set; }
        public string nomEquipo { get; set; }
        public int idmoneda { get; set; }
        public int idresponsable { get; set; }
        public int idfpago { get; set; }
        public decimal total { get; set; }
        public decimal igv { get; set; }
        public decimal valorventa { get; set; }
        public string codigo { get; set; }
        public string enTaller { get; set; }
        public string HorarioEmergencia { get; set; }
        public decimal rentabilidad { get; set; }
        public double calidad { get; set; }
        public decimal descuento { get; set; }
        public string numCotizacion { get; set; }
        public decimal servicio { get; set; }
        public string hor_incremento { get; set; }
        public string lug_incremento { get; set; }
        public string hor_horas { get; set; }
        //public string numOT { get; set; }
        //public string estado { get; set; }
        public List<Servicio> lservicios { get; set; }
        public List<Especialidad> lespecialidades { get; set; }
        public List<Componente> lcomponentes { get; set; }
        public List<TipoComponente> ltipocomponentes { get; set; }
        public List<Empleado> lempleados { get; set; }
        public List<Celda> lceldas { get; set; }
        public Cotizacion() {
        }
        //public Cotizacion()
        //{
        //    lservicios = new List<Servicio>();
        //    lespecialidades = new List<Especialidad>();
        //    lcomponentes = new List<Componente>();
        //    lceldas = new List<Celda>();
        //}
    }
}
