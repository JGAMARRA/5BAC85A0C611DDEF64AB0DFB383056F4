namespace SistemaPlanificacionOT.Domain.Models
{
    public class Celda
    {
        public int id { get; set; }
        public string idvalor { get; set; }
        public string nombre { get; set; }
        public decimal largo { get; set; }
        public decimal ancho { get; set; }
        public decimal mcuadrados { get; set; }
        public decimal costosoles { get; set; }
        public decimal cantidad { get; set; }
        public decimal vventa { get; set; }
        public decimal obtenidos { get; set; }
        public int duracion { get; set; }
        public int horas { get; set; }
        public Celda() {
        }
        public Celda(int pid,string pnombre,decimal pcostosoles,decimal pcantidad,decimal pvventa,decimal pobtenidos, int pduracion = 0, int phoras = 0) {
            id = pid;
            nombre = pnombre;
            costosoles = pcostosoles;
            cantidad = pcantidad;
            vventa = pvventa;
            obtenidos = pobtenidos;
            duracion = pduracion;
            horas = phoras;
        }
    }
}
