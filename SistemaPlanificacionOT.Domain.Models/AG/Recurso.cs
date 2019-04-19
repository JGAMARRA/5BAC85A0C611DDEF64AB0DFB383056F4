namespace SistemaPlanificacionOT.Domain.Models.AG
{
    public class Recurso
    {
        public int id { get; set; }
        public int idtiporecurso { get; set; }
        public decimal costo { get; set; }
        public decimal largo { get; set; }
        public decimal ancho { get; set; }
        public int idespecialidad { get; set; }
        public int idcomponentetipo { get; set; }
        public int elegido { get; set; }
        public int cantidad { get; set; }
        public int usados { get; set; }
    }
}
