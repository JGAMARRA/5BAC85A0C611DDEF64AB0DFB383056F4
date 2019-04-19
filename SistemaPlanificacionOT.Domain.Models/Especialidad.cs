namespace SistemaPlanificacionOT.Domain.Models
{
    public class Especialidad
    {
        public int idespecialidad { get; set; }
        public string nombre { get; set; }
        public decimal cantidad { get; set; }
        public decimal obtenidos { get; set; }
        public decimal costosoles { get; set; }
        public decimal vventa { get; set; }
        
        public Especialidad() {
        }
        public Especialidad(int pid,string pnombre, decimal pcantidad,decimal pcostosoles,decimal pobtenido)
        {
            idespecialidad = pid;
            nombre = pnombre;
            cantidad = pcantidad;
            obtenidos = 0;
            costosoles = pcostosoles;
            obtenidos = pobtenido;
            vventa = pcostosoles * cantidad;
        }
    }
}
