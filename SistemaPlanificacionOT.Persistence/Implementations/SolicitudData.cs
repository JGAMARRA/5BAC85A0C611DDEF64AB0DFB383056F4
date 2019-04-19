using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Persistence.Common;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPlanificacionOT.Persistence.Implementations
{
    public class SolicitudData
    {
        public List<Solicitud> ListarSolicitud()
        {
            var list = new List<Solicitud>();
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_Solicitud_ConsultaGeneral";
                using (var reader = helper.ExecDataReaderProc(sql, null))
                {
                    while (reader.Read())
                    {
                        list.Add(new Solicitud
                        {
                            cliente=(string)reader["cliente"],
                            entaller = (string)reader["entallerdesc"],
                            codigo  = (string)reader["codigosolicitud"],
                            equipo = (string)reader["equipo"],
                            fregistro = (string)reader["fecRegistro"]
                           
                        });
                    }
                }
            }
            return list;
        }

        public Solicitud ObtenerSolicitud(string pcodsolicitud)
        {
            Solicitud oSolicitud = new Solicitud();
            Plantilla oPlantilla = new Plantilla();

            //oPlantilla.lceldas = new List<Celda>();
            oPlantilla.lcomponentes = new List<Componente>();
            oPlantilla.lespecialidades = new List<Especialidad>();
            oPlantilla.lservicios = new List<Servicio>();
            oPlantilla.ltipocomponentes = new List<TipoComponente>();

            DataSet tb = new DataSet();
            using (var helper = new SqlHelper())
            {
                helper.Connect();

                var sql = "usp_Solicitud_ConsultaInfoPlantilla";
                SqlDataAdapter sq = new SqlDataAdapter();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@cod_solicitud", pcodsolicitud));
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                sq.SelectCommand = cmd;
                sq.Fill(tb, "Table1");
            }
            DataTable dt = tb.Tables[0];
            DataTable dt1 = tb.Tables[1];
            DataTable dt2 = tb.Tables[2];
            DataTable dt3 = tb.Tables[3];
            DataTable dt4 = tb.Tables[4];

            foreach (DataRow row in dt.Rows)
            {
                oSolicitud.codigo = row["codigosolicitud"].ToString();
                oSolicitud.entaller = row["entaller"].ToString();
                oSolicitud.cliente = row["cliente"].ToString();
                oSolicitud.equipo = row["equipo"].ToString();
            }
            foreach (DataRow row in dt1.Rows)
            {
                oPlantilla.lservicios.Add(new Servicio(int.Parse(row["idservicio"].ToString()), row["servicio"].ToString(), decimal.Parse(row["cantidad"].ToString()), decimal.Parse(row["costohora"].ToString()),0));
            }
            foreach (DataRow row in dt2.Rows)
            {
                oPlantilla.lespecialidades.Add(new Especialidad(int.Parse(row["idEspecialidad"].ToString()), row["especialidad"].ToString(), decimal.Parse(row["cantidad"].ToString()), 0, 0));
            }
            foreach (DataRow row in dt3.Rows)
            {
                oPlantilla.lcomponentes.Add(new Componente(int.Parse(row["id"].ToString()), row["componente"].ToString(), decimal.Parse(row["cantidad"].ToString())
                    , row["codigo"].ToString(), row["tipocomponente"].ToString(), decimal.Parse(row["costosoles"].ToString()), row["moneda"].ToString(), 0, 0, int.Parse(row["idComponenteTipo"].ToString()) ));
            }
            foreach (DataRow row in dt4.Rows)
            {
                oPlantilla.ltipocomponentes.Add(new TipoComponente(int.Parse(row["id"].ToString()),row["tipocomponente"].ToString(), decimal.Parse(row["cantidad"].ToString()), decimal.Parse(row["obtenido"].ToString())));
            }
            oSolicitud.requerimientos_basicos = oPlantilla;
            return oSolicitud;
        }
    }
}
