namespace SistemaPlanificacionOT.Domain.Models.Common
{
    public class Range
    {
        public string value { get; set; }
        public int row { get; set; }
        public int column { get; set; }

        public Range() { }

        public Range(string pvalue, int pfila = 0, int pcolumn = 0)
        {
            value = pvalue;
            row = pfila;
            column = pcolumn;
        }
    }
}
