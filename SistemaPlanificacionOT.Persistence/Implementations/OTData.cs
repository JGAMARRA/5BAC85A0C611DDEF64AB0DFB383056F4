using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPlanificacionOT.Persistence.Implementations
{
    public class OTData
    {
        public List<OTInfo> ListarOT(int tipo_consulta)
        {
            var list = new List<OTInfo>();
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_OT_ConsultaGeneral";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@tipo", tipo_consulta));
                using (var reader = helper.ExecDataReaderProc(sql, parameters.ToArray()))
                {
                    while (reader.Read())
                    {
                        list.Add(new OTInfo
                        {
                            id = (int)reader["idOTrabajoCab"],
                            codigo = (string)reader["codigo"],
                            fecRecepcion = (string)reader["fecRecepcion"],
                            cliente = (string)reader["cliente"],
                            estadoOT = (string)reader["estado"],
                            nro_oc_ref = (string)reader["nroOC"],
                            total = (decimal)reader["total"],
                            responsable = (string)reader["responsable"],
                            equipo = (string)reader["equipo"],
                            moneda = (string)reader["moneda"]
                        });

                    }
                }
            }
            return list;
        }
        public OTModel ObtenerDocumentoGestion(string id)
        {
            
            var oModel = new OTModel();
            DataSet tb = new DataSet();
            DocumentoGestionCelda oCelda = null;
            DocumentoGestionComponente oComponente = null;
            DocumentoGestionPersonal oPersonal = null;
            List<DocumentoGestionCelda> lceldas = new List<DocumentoGestionCelda>();
            List<DocumentoGestionComponente> lcomponentes = new List<DocumentoGestionComponente>();
            List<DocumentoGestionPersonal> lpersonal = new List<DocumentoGestionPersonal>();
            using (var helper = new SqlHelper())
            {
                helper.Connect();

                var sql = "usp_OT_ConsultaOT";
                SqlDataAdapter sq = new SqlDataAdapter();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@codigo", id));
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                sq.SelectCommand = cmd;
                sq.Fill(tb, "Table1");
            }
            DataTable dt = tb.Tables[0];
            DataTable dt1 = tb.Tables[1];
            DataTable dt2 = tb.Tables[2];
            DataTable dt3 = tb.Tables[3];
            foreach (DataRow item in dt.Rows)
            {
                oCelda = new DocumentoGestionCelda();
                oCelda.id = item["id"].ToString();
                oCelda.documento = item["documento"].ToString();
                oCelda.codigo = item["codigo"].ToString();
                oCelda.fecha = item["fecha"].ToString();
                oCelda.cantidad = item["cantidad"].ToString();
                lceldas.Add(oCelda);
            }
            foreach (DataRow item in dt1.Rows)
            {
                oComponente = new DocumentoGestionComponente();
                oComponente.id = item["id"].ToString();
                oComponente.documento = item["documento"].ToString();
                oComponente.codigo = item["codigo"].ToString();
                oComponente.fecha = item["fecha"].ToString();
                oComponente.componente = item["componente"].ToString();
                oComponente.cantidad = item["cantidad"].ToString();
                lcomponentes.Add(oComponente);
            }
            foreach (DataRow item in dt2.Rows)
            {
                oPersonal = new DocumentoGestionPersonal();
                oPersonal.id = item["id"].ToString();
                oPersonal.documento = item["documento"].ToString();
                oPersonal.especialidad = item["especialidad"].ToString();
                oPersonal.fecha = item["fecha"].ToString();
                oPersonal.nombre = item["nombre_completo"].ToString();
                oPersonal.cantidad = item["cantidad"].ToString();
                lpersonal.Add(oPersonal);
            }
            foreach (DataRow item in dt3.Rows)
            {

                oModel.codigo = item["codigo"].ToString();
                oModel.fechaInicio = item["fecinicio"].ToString();
                oModel.fechaFin = item["fecEstimadaFin"].ToString();
                oModel.NroCotizacionReferencia = item["cotizacion_ref"].ToString();
                oModel.responsable = item["responsable"].ToString();
                oModel.equipo= item["equipo"].ToString();


            }

            oModel.lceldas = lceldas;
            oModel.lcomponentes = lcomponentes;
            oModel.lpersonal = lpersonal;
            return oModel;
        }

        public string GenerarOT(int idcotizacionpropuesta)
        {
            string cod = "              ";
            try
            {
                using (var helper = new SqlHelper())
                {
                    helper.Connect();
                    var sql = "usp_OT_Generar";
                    List<SqlParameter> parameters=new List<SqlParameter>();
                    
                   // parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@idcotizacionpropuesta", idcotizacionpropuesta));
                    parameters.Add(new SqlParameter("@codigo_ot", cod));
                    parameters[1].Direction = ParameterDirection.InputOutput;
                    SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                    int n = cmd.ExecuteNonQuery();
                    cod = parameters[1].Value.ToString().TrimEnd();

                }
            }
            catch (Exception ex)
            {

               
            }
            
            return cod;
        }
    }
}
