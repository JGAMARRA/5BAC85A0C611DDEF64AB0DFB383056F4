namespace SistemaPlanificacionOT.Domain.Models
{
    public class TipoComponente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal cantidad { get; set; }
        public decimal obtenidos { get; set; }
        public TipoComponente() {
        }
        public TipoComponente(int pid,string pnombre, decimal pcantidad,decimal pobtenidos)
        {
            id = pid;
            nombre = pnombre;
            cantidad = pcantidad;
            obtenidos = pobtenidos;
        }
    }
}
