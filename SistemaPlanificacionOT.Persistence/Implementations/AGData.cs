using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Domain.Models.AG;
using SistemaPlanificacionOT.Persistence.Common;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPlanificacionOT.Persistence.Implementations
{
    public class AGData
    { //, List<Parametros> lparametros
        public void BuscarRecursos(Cotizacion oCotizacion,List<Recurso> lceldas_dispo, List<Recurso> lcomponentes_dispo, List<Recurso> lespecialidades_dispo, List<Recurso> lcomponentesTipo_dispo)
        {
            DataSet tb = new DataSet();
            Recurso oRecurso;            
            using (var helper = new SqlHelper())
            {
                helper.Connect();

                var sql = "usp_Cotizacion_ConsultaRecursos";
                SqlDataAdapter sq = new SqlDataAdapter();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@idcotizacioncab", oCotizacion.idCot));
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                sq.SelectCommand = cmd;
                sq.Fill(tb, "Table1");
            }
            DataTable dt = tb.Tables[0];
            DataTable dt1 = tb.Tables[1];
            DataTable dt2 = tb.Tables[2];
            DataTable dt3 = tb.Tables[3];
            foreach (DataRow row in dt.Rows)
            {
                oRecurso = new Recurso();
                oRecurso.idtiporecurso= int.Parse(row["tipo"].ToString());
                oRecurso.id = int.Parse(row["id"].ToString());
                oRecurso.costo= decimal.Parse(row["costo"].ToString());
                oRecurso.ancho = decimal.Parse(row["ancho"].ToString());
                oRecurso.largo = decimal.Parse(row["largo"].ToString());
                oRecurso.idespecialidad = int.Parse(row["idespecialidad"].ToString());
                oRecurso.idcomponentetipo = int.Parse(row["idcomponentetipo"].ToString());
                oRecurso.cantidad = int.Parse(row["cantidad"].ToString());
                oRecurso.usados = int.Parse(row["cantidad"].ToString());
                oRecurso.elegido = 0;
                lceldas_dispo.Add(oRecurso);
            }
            foreach (DataRow row in dt1.Rows)
            {
                oRecurso = new Recurso();
                oRecurso.idtiporecurso = int.Parse(row["tipo"].ToString());
                oRecurso.id = int.Parse(row["id"].ToString());
                oRecurso.costo = decimal.Parse(row["costo"].ToString());
                oRecurso.ancho = decimal.Parse(row["ancho"].ToString());
                oRecurso.largo = decimal.Parse(row["largo"].ToString());
                oRecurso.idespecialidad = int.Parse(row["idespecialidad"].ToString());
                oRecurso.idcomponentetipo = int.Parse(row["idcomponentetipo"].ToString());
                oRecurso.cantidad = int.Parse(row["cantidad"].ToString());
                oRecurso.usados = int.Parse(row["cantidad"].ToString());
                oRecurso.elegido = 0;
                lcomponentes_dispo.Add(oRecurso);
            }
            foreach (DataRow row in dt2.Rows)
            {
                oRecurso = new Recurso();
                oRecurso.idtiporecurso = int.Parse(row["tipo"].ToString());
                oRecurso.id = int.Parse(row["id"].ToString());
                oRecurso.costo = decimal.Parse(row["costo"].ToString());
                oRecurso.ancho = decimal.Parse(row["ancho"].ToString());
                oRecurso.largo = decimal.Parse(row["largo"].ToString());
                oRecurso.idespecialidad = int.Parse(row["idespecialidad"].ToString());
                oRecurso.idcomponentetipo = int.Parse(row["idcomponentetipo"].ToString());
                oRecurso.cantidad = int.Parse(row["cantidad"].ToString());
                oRecurso.usados = int.Parse(row["cantidad"].ToString());
                oRecurso.elegido = 0;
                lespecialidades_dispo.Add(oRecurso);
            }
            foreach (DataRow row in dt3.Rows)
            {
                oRecurso = new Recurso();
                oRecurso.idtiporecurso = int.Parse(row["tipo"].ToString());
                oRecurso.id = int.Parse(row["id"].ToString());
                oRecurso.costo = decimal.Parse(row["costo"].ToString());
                oRecurso.ancho = decimal.Parse(row["ancho"].ToString());
                oRecurso.largo = decimal.Parse(row["largo"].ToString());
                oRecurso.idespecialidad = int.Parse(row["idespecialidad"].ToString());
                oRecurso.idcomponentetipo = int.Parse(row["idcomponentetipo"].ToString());
                oRecurso.cantidad = int.Parse(row["cantidad"].ToString());
                oRecurso.usados = int.Parse(row["cantidad"].ToString());
                oRecurso.elegido = 0;
                lcomponentesTipo_dispo.Add(oRecurso);
            }
            //foreach (DataRow row in dt1.Rows)
            //{
            //    oCantidad = new Cantidad();
            //    oCantidad.clave= row["clave"].ToString();
            //    oCantidad.idtiporecursoparametro= int.Parse(row["idtiporecursoparametro"].ToString());
            //    oCantidad.id= int.Parse(row["id"].ToString());
            //    oCantidad.cantidad= int.Parse(row["cantidad"].ToString());

            //}


        }
    }
}
