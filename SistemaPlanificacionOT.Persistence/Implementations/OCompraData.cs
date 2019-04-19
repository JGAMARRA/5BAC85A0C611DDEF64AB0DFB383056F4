using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Persistence.Common;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPlanificacionOT.Persistence.Implementations
{
    public class OCompraData
    {
        public List<OCompraInfo> ListarOCompra(int tipo_consulta)
        {
            var list = new List<OCompraInfo>();
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_OrdenCompra_ConsultaGeneral";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@tipo_consulta", tipo_consulta));
                using (var reader = helper.ExecDataReaderProc(sql, parameters.ToArray()))
                {
                    while (reader.Read())
                    {
                        list.Add(new OCompraInfo
                        {
                            id = (int)reader["idCotizacionCab"],
                            codigo = (string)reader["codigo"],
                            fecRecepcion = (string)reader["fecRecepcion"],
                            cliente = (string)reader["cliente"],
                            estadoOC = (string)reader["estadoOC"],
                            ncotref = (string)reader["Cotizacion_Ref"],
                            total = (decimal)reader["total"],
                            responsable = (string)reader["responsable"],
                            equipo=(string)reader["equipo"],
                            moneda = (string)reader["moneda"]
                        });

                    }
                }
            }
            return list;
        }
        public int EliminarOCompra(int idcot)
        {
            int n = 0;
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_OrdenCompra_Eliminar";
                List<SqlParameter> parameters;
                parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@idcot", idcot));
                parameters.Add(new SqlParameter("@respuesta", -1));
                parameters[1].Direction = ParameterDirection.InputOutput;
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                cmd.ExecuteNonQuery();
                n = int.Parse(parameters[1].Value.ToString());
            }
            return n;
        }

        public string InsertarOCompra(Cotizacion oCotizacion)
        {
            string cod_oc = "            ";
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                int cod = 0;
                int duracion = 0;
                int hor_horas = 0;
                int hor_incremento = 0;
                int lug_incremento = 0;
                //var sql = "usp_CotizacionCab_Insertar";
                var sql = "usp_OrdenCompra_Insertar";
                
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@idmoneda", oCotizacion.idmoneda));
                parameters.Add(new SqlParameter("@idresponsable", oCotizacion.idresponsable));
                parameters.Add(new SqlParameter("@idformapago", oCotizacion.idfpago));
                parameters.Add(new SqlParameter("@fecrecepcion", oCotizacion.frecepcion));
                parameters.Add(new SqlParameter("@fecvencimiento", oCotizacion.fvencimiento));
                parameters.Add(new SqlParameter("@fectermino", oCotizacion.fterminado));
                parameters.Add(new SqlParameter("@fecinicio", oCotizacion.finicio));
                parameters.Add(new SqlParameter("@cod_cotizacion", oCotizacion.idCot));
                parameters.Add(new SqlParameter("@idCotizacionCab", cod));
                parameters.Add(new SqlParameter("@duracion", duracion));
                parameters.Add(new SqlParameter("@valorventa", oCotizacion.valorventa));
                parameters.Add(new SqlParameter("@igv", oCotizacion.igv));
                parameters.Add(new SqlParameter("@total", oCotizacion.total));
                parameters.Add(new SqlParameter("@lugar", oCotizacion.enTaller));
                parameters.Add(new SqlParameter("@horario", oCotizacion.HorarioEmergencia));
                parameters.Add(new SqlParameter("@hor_incremento", hor_incremento));
                parameters.Add(new SqlParameter("@lug_incremento", lug_incremento));
                parameters.Add(new SqlParameter("@hor_horas", hor_horas));
                parameters.Add(new SqlParameter("@codigo", cod_oc));
                parameters[8].Direction = ParameterDirection.InputOutput;
                parameters[9].Direction = ParameterDirection.InputOutput;
                parameters[15].Direction = ParameterDirection.InputOutput;
                parameters[16].Direction = ParameterDirection.InputOutput;
                parameters[17].Direction = ParameterDirection.InputOutput;
                parameters[18].Direction = ParameterDirection.InputOutput;
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                int n = cmd.ExecuteNonQuery();
                oCotizacion.idCot = int.Parse(parameters[8].Value.ToString());
                oCotizacion.n_dias_hasta_termino = int.Parse(parameters[9].Value.ToString());
                oCotizacion.hor_incremento = parameters[15].Value.ToString();
                oCotizacion.lug_incremento = parameters[16].Value.ToString();
                oCotizacion.hor_horas = parameters[17].Value.ToString();
                oCotizacion.codigo = parameters[18].Value.ToString();
                cod_oc = oCotizacion.codigo;
                if (oCotizacion.lceldas == null)
                {
                    oCotizacion.lceldas = new List<Celda>();
                }
                if (oCotizacion.lempleados == null)
                {
                    oCotizacion.lempleados = new List<Empleado>();
                }
                if (oCotizacion.lespecialidades == null)
                {
                    oCotizacion.lespecialidades = new List<Especialidad>();
                }
                if (oCotizacion.lcomponentes == null)
                {
                    oCotizacion.lcomponentes = new List<Componente>();
                }
                if (oCotizacion.ltipocomponentes == null)
                {
                    oCotizacion.ltipocomponentes = new List<TipoComponente>();
                }
                InsertarCotizacionServicio(oCotizacion);
                InsertarCotizacionComponentes(oCotizacion);
                InsertarCotizacionEspecialidad(oCotizacion);
                InsertarCotizacionCelda(oCotizacion);
                InsertarCotizacionTipoComponentes(oCotizacion);
                InsertarCotizacionEmpleado(oCotizacion);
            }
            return cod_oc;
        }
        public int InsertarCotizacionEmpleado(Cotizacion oCotizacion)
        {
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_CotizacionEmpleado_insertar";
                List<SqlParameter> parameters;
                foreach (var item in oCotizacion.lempleados)
                {
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@idCotizacionCab", oCotizacion.idCot));
                    parameters.Add(new SqlParameter("@idEmpleado", item.codigo));
                    parameters.Add(new SqlParameter("@cantidad", item.cantidad));
                    parameters.Add(new SqlParameter("@preciounitario", item.costosoles));
                    parameters.Add(new SqlParameter("@valorventa", item.vventa));
                    parameters.Add(new SqlParameter("@descuento", decimal.Parse("0.0")));
                    parameters.Add(new SqlParameter("@horarioregular", item.hnormal));
                    parameters.Add(new SqlParameter("@horarioextendido", item.hextendido));
                    SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                    int n = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
        public int InsertarCotizacionCelda(Cotizacion oCotizacion)
        {

            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_CotizacionCelda_Insertar";
                List<SqlParameter> parameters;
                foreach (var item in oCotizacion.lceldas)
                {
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@idCotizacionCab", oCotizacion.idCot));
                    parameters.Add(new SqlParameter("@idCelda", item.id));
                    parameters.Add(new SqlParameter("@cantidad", item.cantidad));
                    parameters.Add(new SqlParameter("@preciounitario", item.costosoles));
                    parameters.Add(new SqlParameter("@valorventa", item.costosoles * item.cantidad));
                    parameters.Add(new SqlParameter("@descuento", decimal.Parse("0.0")));
                    SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                    int n = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }

        public int InsertarCotizacionServicio(Cotizacion oCotizacion)
        {

            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_CotizacionServicio_Insertar";
                List<SqlParameter> parameters;
                foreach (var item in oCotizacion.lservicios)
                {
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@idCotizacionCab", oCotizacion.idCot));
                    parameters.Add(new SqlParameter("@idServicio", item.id));
                    parameters.Add(new SqlParameter("@cantidad", item.cantidad));
                    parameters.Add(new SqlParameter("@preciounitario", item.costosoles));
                    parameters.Add(new SqlParameter("@vventa", item.vventa));
                    SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                    int n = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
        public int InsertarCotizacionComponentes(Cotizacion oCotizacion)
        {
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_CotizacionComponente_Insertar";
                List<SqlParameter> parameters;
                foreach (var item in oCotizacion.lcomponentes)
                {
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@idCotizacionCab", oCotizacion.idCot));
                    parameters.Add(new SqlParameter("@idComponente", item.idcomponente));
                    parameters.Add(new SqlParameter("@cantidad", item.cantidad));
                    parameters.Add(new SqlParameter("@precioUnitario", item.costosoles));
                    parameters.Add(new SqlParameter("@descuento", 0));
                    parameters.Add(new SqlParameter("@valorventa", item.vventa));
                    parameters.Add(new SqlParameter("@obtenido", item.obtenidos));
                    SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                    int n = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
        public int InsertarCotizacionEspecialidad(Cotizacion oCotizacion)
        {
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_CotizacionEspecialidad_Insertar";
                List<SqlParameter> parameters;
                foreach (var item in oCotizacion.lespecialidades)
                {
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@idCotizacionCab", oCotizacion.idCot));
                    parameters.Add(new SqlParameter("@idEspecialidad", item.idespecialidad));
                    parameters.Add(new SqlParameter("@cantidad", item.cantidad));
                    SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                    int n = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
        public int InsertarCotizacionTipoComponentes(Cotizacion oCotizacion)
        {
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_CotizacionComponenteTipo_Insertar";
                List<SqlParameter> parameters;
                foreach (var item in oCotizacion.ltipocomponentes)
                {
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@idCotizacionCab", oCotizacion.idCot));
                    parameters.Add(new SqlParameter("@idComponenteTipo", item.id));
                    parameters.Add(new SqlParameter("@cantidad", item.cantidad));
                    SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                    int n = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
    }
}
