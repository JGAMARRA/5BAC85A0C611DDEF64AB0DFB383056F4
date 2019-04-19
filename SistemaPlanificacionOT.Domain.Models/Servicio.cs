namespace SistemaPlanificacionOT.Domain.Models
{
    public class Servicio
    {
        public int id { get; set; }
        public string idvalor { get; set; }
        public string nombre { get; set; }
        public decimal cantidad { get; set; }
        public decimal costosoles { get; set; }
        public int  tiposervicio { get; set; }
        public string moneda { get; set; }
        public int duracion { get; set; }
        public decimal vventa { get; set; }
        public decimal incremento { get; set; }
        public int horas { get; set; }
        public Servicio() {
        }
        public Servicio(int pid,string pnombre,decimal pcantidad,decimal pcostosoles,decimal pvventa, int pduracion = 0, int phoras = 0) {
            id = pid;
            nombre = pnombre;
            cantidad = pcantidad;
            costosoles = pcostosoles;
            duracion = pduracion;
            horas = phoras;
            vventa = pvventa;
        }
    }
}
