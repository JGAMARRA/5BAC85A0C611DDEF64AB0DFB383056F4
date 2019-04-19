namespace SistemaPlanificacionOT.Domain.Models
{
    public class Empleado
    {
        public string nombre { get; set; }
        public int codigo { get; set; }
        public decimal costosoles { get; set; }
        public decimal cantidad { get; set; }
        public decimal vventa { get; set; }
        public decimal hnormal { get; set; }
        public decimal hextendido { get; set; }
        public string especialidad { get; set; }
        public int duracion { get; set; }
        public int horas { get; set; }
        public Empleado() {
        }
        public Empleado(string pnombre,string pespecialidad,int pcodigo,decimal pcostosoles,decimal pcantidad,decimal pvventa,decimal phnormal,decimal phextendido, int pduracion = 0, int phoras = 0)
        {
            nombre = pnombre;
            codigo = pcodigo;
            costosoles = pcostosoles;
            cantidad = pcantidad;
            especialidad = pespecialidad;
            vventa=pvventa;
            duracion = pduracion;
            horas = phoras;
            hextendido=phextendido;
            hnormal=phnormal;
        }
    }
}
