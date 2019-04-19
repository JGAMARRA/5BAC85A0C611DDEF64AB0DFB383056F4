using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Persistence.Common;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPlanificacionOT.Persistence.Implementations
{
    public class ServicioData
    {
        public List<Servicio> Consultar()
        {
            var list = new List<Servicio>();
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_Servicio_ConsultaGeneral";

                using (var reader = helper.ExecDataReaderProc(sql, null))
                {
                    while (reader.Read())
                    {
                        list.Add(new Servicio
                        {
                            id = (int)reader["id"],
                            nombre = (string)reader["servicio"],
                            costosoles = (decimal)reader["costosoles"],
                             moneda= (string)reader["monedaorigen"]
                        });

                    }
                }
            }
            return list;
        }
        public int Agregar(Servicio oServicio)
        {
            int n = -1;
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_Servicio_Agregar";
                
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@descripcion", oServicio.nombre));
                parameters.Add(new SqlParameter("@tiposervicio",oServicio.tiposervicio));                     
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                n = cmd.ExecuteNonQuery();

            }
            return n;
        }

    }
}
