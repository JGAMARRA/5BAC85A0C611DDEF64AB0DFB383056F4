namespace SistemaPlanificacionOT.Domain.Models
{
    public class Componente
    {
        public int idcomponente { get; set; }
        public decimal cantidad { get; set; }
        public decimal obtenidos { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string tipocomponente { get; set; }
        public int idtipocomponente { get; set; }
        public decimal costosoles { get; set; }
        public decimal vventa { get; set; }
        public string moneda { get; set; }
        public int duracion { get; set; }
        public int horas { get; set; }
        public Componente() {
        }
        public Componente(int pid,string pnombre, decimal pcantidad,string pcodigo,string ptipocomponente,decimal pcostosoles,string pmoneda,decimal pvventa,decimal pobtenido,int pidtipocomponente, int pduracion = 0, int phoras = 0)
        {
            idcomponente = pid;
            nombre = pnombre;
            cantidad = pcantidad;
            codigo = pcodigo;
            tipocomponente = ptipocomponente;
            costosoles = pcostosoles;
            moneda = pmoneda;
            vventa = pvventa;
            obtenidos = pobtenido;
            idtipocomponente = pidtipocomponente;
                  duracion = pduracion;
            horas = phoras;
        }
    }
}
