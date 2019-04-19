using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Persistence.Common;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPlanificacionOT.Persistence.Implementations
{
    public class CotizacionData
    {
        //public List<FormaPago> ListarFormaPago()
        //{
        //    var list = new List<FormaPago>();
        //    using (var helper = new SqlHelper())
        //    {
        //        helper.Connect();
        //        var sql = "usp_FormaPago_ConsultaGeneral";

        //        using (var reader = helper.ExecDataReaderProc(sql, null))
        //        {
        //            while (reader.Read())
        //            {
        //                list.Add(new FormaPago
        //                {
        //                    codigo = (int)reader["codigo"],
        //                    descripcion = (string)reader["descripcion"]                           
        //                });

        //            }
        //        }
        //    }
        //    return list;
        //}
        public int EliminarCotizacion(int idcot)
        {
            int n = 0;
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_CotizacionCab_Eliminar";
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
        //public List<Celda> ListarCeldas()
        //{
        //    var list = new List<Celda>();
        //    using (var helper = new SqlHelper())
        //    {
        //        helper.Connect();
        //        var sql = "usp_Celda_Consulta";

        //        using (var reader = helper.ExecDataReaderProc(sql, null))
        //        {
        //            while (reader.Read())
        //            {
        //                list.Add(new Celda
        //                {

        //                    nombre = (string)reader["codigo"],
        //                    largo = (decimal)reader["largo"],
        //                    ancho = (decimal)reader["ancho"]
        //                });

        //            }
        //        }
        //    }
        //    return list;
        //}



        public List<CotizacionInfo> ListarCotizacion(int ptipo)
        {
            var list = new List<CotizacionInfo>();
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_Cotizacion_ConsultaGeneral";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@tipo", ptipo));
                using (var reader = helper.ExecDataReaderProc(sql, parameters.ToArray()))
                {
                    while (reader.Read())
                    {
                        list.Add(new CotizacionInfo
                        {
                            idCotizacionCab = (int)reader["idCotizacionCab"],
                            idSolicitudServicioCab = (int)reader["idSolicitudServicioCab"],
                            codigosolicitud = (string)reader["codigosolicitud"],
                            fecRegistro = (string)reader["fecRegistro"],
                            cliente = (string)reader["cliente"],
                            equipo = (string)reader["equipo"],
                            responsable = (string)reader["responsable"],
                            estado = (string)reader["estadocotizacion"],
                            nCotizacion = (string)reader["nCotizacion"],
                            fecVencimiento = (string)reader["fecVencimiento"],
                            total = (decimal)reader["total"],
                            moneda = (string)reader["moneda"]

                        });

                    }
                }
            }
            return list;
        }
        public Cotizacion InsertarTmpCotizacion(Cotizacion oCotizacion)
        {

            using (var helper = new SqlHelper())
            {
                helper.Connect();
                int cod = 0;
                var sql = "usp_TmpCotizacionCab_Insertar";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@idmoneda", oCotizacion.idmoneda));
                parameters.Add(new SqlParameter("@idresponsable", oCotizacion.idresponsable));
                parameters.Add(new SqlParameter("@idformapago", oCotizacion.idfpago));
                parameters.Add(new SqlParameter("@fecvencimiento", oCotizacion.fvencimiento));
                parameters.Add(new SqlParameter("@fectermino", oCotizacion.fterminado));
                parameters.Add(new SqlParameter("@fecinicio", oCotizacion.finicio));
                parameters.Add(new SqlParameter("@cod_solicitud", oCotizacion.numSolicitud));
                parameters.Add(new SqlParameter("@idCotizacionCab", oCotizacion.idCot));
                parameters.Add(new SqlParameter("@valorventa", oCotizacion.valorventa));
                parameters.Add(new SqlParameter("@igv", oCotizacion.igv));
                parameters.Add(new SqlParameter("@total", oCotizacion.total));
                parameters.Add(new SqlParameter("@rentabilidad", oCotizacion.rentabilidad));
                parameters.Add(new SqlParameter("@calidad", oCotizacion.calidad));
                parameters.Add(new SqlParameter("@lugar", oCotizacion.enTaller));
                parameters.Add(new SqlParameter("@horario", oCotizacion.HorarioEmergencia));      
                parameters[7].Direction = ParameterDirection.InputOutput; 
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                int n = cmd.ExecuteNonQuery();
                oCotizacion.idCot = int.Parse(parameters[7].Value.ToString());
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
                InsertarTmpCotizacionServicio(oCotizacion);
                InsertarTmpCotizacionComponentes(oCotizacion);
                InsertarTmpCotizacionEspecialidad(oCotizacion);
                InsertarTmpCotizacionEmpleado(oCotizacion);
                InsertarTmpCotizacionCelda(oCotizacion);
                InsertarTmpCotizacionTipoComponentes(oCotizacion);
            }
            return oCotizacion;
        }
        public int InsertarTmpCotizacionServicio(Cotizacion oCotizacion)
        {

            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_TmpCotizacionServicio_Insertar";
                List<SqlParameter> parameters;
                foreach (var item in oCotizacion.lservicios)
                {
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@idCotizacionCab", oCotizacion.idCot));
                    parameters.Add(new SqlParameter("@idServicio", item.id));
                    parameters.Add(new SqlParameter("@cantidad", item.cantidad));
                    parameters.Add(new SqlParameter("@costosoles", item.costosoles));
                    parameters.Add(new SqlParameter("@vventa", item.vventa));
                    SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                    int n = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
        public int InsertarTmpCotizacionComponentes(Cotizacion oCotizacion)
        {
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_TmpCotizacionComponente_Insertar";
                List<SqlParameter> parameters;
                foreach (var item in oCotizacion.lcomponentes)
                {
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@idCotizacionCab", oCotizacion.idCot));
                    parameters.Add(new SqlParameter("@idComponente", item.idcomponente));
                    parameters.Add(new SqlParameter("@cantidad", item.cantidad));
                    parameters.Add(new SqlParameter("@preciounitario", item.costosoles));
                    parameters.Add(new SqlParameter("@descuento", decimal.Parse("0.0")));
                    parameters.Add(new SqlParameter("@valorventa", item.vventa));
                    parameters.Add(new SqlParameter("@obtenido", item.obtenidos));

                    SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                    int n = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
        public int InsertarTmpCotizacionEspecialidad(Cotizacion oCotizacion)
        {
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_TmpCotizacionEspecialidad_Insertar";
                List<SqlParameter> parameters;
                foreach (var item in oCotizacion.lespecialidades)
                {
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@idCotizacionCab", oCotizacion.idCot));
                    parameters.Add(new SqlParameter("@idEspecialidad", item.idespecialidad));
                    parameters.Add(new SqlParameter("@cantidad", item.cantidad));
                    parameters.Add(new SqlParameter("@obtenido", item.obtenidos));
                    SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                    int n = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
        public int InsertarTmpCotizacionEmpleado(Cotizacion oCotizacion)
        {
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_TmpCotizacionEmpleado_insertar";
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
        public int InsertarTmpCotizacionCelda(Cotizacion oCotizacion)
        {

            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_TmpCotizacionCelda_Insertar";
                List<SqlParameter> parameters;
                foreach (var item in oCotizacion.lceldas)
                {
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@idCotizacionCab", oCotizacion.idCot));
                    parameters.Add(new SqlParameter("@idCelda", item.id));
                    parameters.Add(new SqlParameter("@cantidad", item.cantidad));
                    parameters.Add(new SqlParameter("@preciounitario", item.costosoles));
                    parameters.Add(new SqlParameter("@valorventa", item.vventa));
                    parameters.Add(new SqlParameter("@descuento", decimal.Parse("0.0")));
                    parameters.Add(new SqlParameter("@obtenido", item.obtenidos));
                    SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                    int n = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }
        public int InsertarTmpCotizacionTipoComponentes(Cotizacion oCotizacion)
        {
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_TmpCotizacionComponenteTipo_Insertar";
                List<SqlParameter> parameters;
                foreach (var item in oCotizacion.ltipocomponentes)
                {
                    parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@idCotizacionCab", oCotizacion.idCot));
                    parameters.Add(new SqlParameter("@idComponenteTipo", item.id));
                    parameters.Add(new SqlParameter("@cantidad", item.cantidad));
                    parameters.Add(new SqlParameter("@obtenido", item.obtenidos));
                    SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                    int n = cmd.ExecuteNonQuery();
                }
            }
            return 1;
        }

        public string GenerarCotizacion(int idcot)
        {
            string cod = "               ";
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_Cotizacion_Generar";
                List<SqlParameter> parameters;

                parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@idcot", idcot));
                parameters.Add(new SqlParameter("@codigo_cot", cod));
                parameters[1].Direction = ParameterDirection.InputOutput;
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                int n = cmd.ExecuteNonQuery();
                cod = parameters[1].Value.ToString().TrimEnd();

            }
            return cod;
        }

    

        public Cotizacion InsertarCotizacion(Cotizacion oCotizacion)
        {

            using (var helper = new SqlHelper())
            {
                helper.Connect();
                int cod = 0;
                int duracion = 0;
                int hor_horas = 0;
                int hor_incremento = 0;
                int lug_incremento = 0;
                var sql = "usp_CotizacionCab_Insertar";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@idmoneda", oCotizacion.idmoneda));
                parameters.Add(new SqlParameter("@idresponsable", oCotizacion.idresponsable));
                parameters.Add(new SqlParameter("@idformapago", oCotizacion.idfpago));
                parameters.Add(new SqlParameter("@fecvencimiento", oCotizacion.fvencimiento));
                parameters.Add(new SqlParameter("@fectermino", oCotizacion.fterminado));
                parameters.Add(new SqlParameter("@fecinicio", oCotizacion.finicio));

                parameters.Add(new SqlParameter("@cod_solicitud", oCotizacion.numSolicitud));
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
                parameters[7].Direction = ParameterDirection.InputOutput;
                parameters[8].Direction = ParameterDirection.InputOutput;
                parameters[14].Direction = ParameterDirection.InputOutput;
                parameters[15].Direction = ParameterDirection.InputOutput;
                parameters[16].Direction = ParameterDirection.InputOutput;
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                int n = cmd.ExecuteNonQuery();
                oCotizacion.idCot = int.Parse(parameters[7].Value.ToString());
                oCotizacion.n_dias_hasta_termino = int.Parse(parameters[8].Value.ToString());
                oCotizacion.hor_incremento = parameters[14].Value.ToString();
                oCotizacion.lug_incremento = parameters[15].Value.ToString();
                oCotizacion.hor_horas = parameters[16].Value.ToString();
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
            }
            return oCotizacion;
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

        public Cotizacion ObtenerInfoTmpCotizacion(string pidpropuesta)
        {
            Cotizacion oCotizacion = new Cotizacion();
            oCotizacion.lceldas = new List<Celda>();
            oCotizacion.lcomponentes = new List<Componente>();
            oCotizacion.lespecialidades = new List<Especialidad>();
            oCotizacion.lservicios = new List<Servicio>();
            DataSet tb = new DataSet();
            using (var helper = new SqlHelper())
            {
                helper.Connect();

                var sql = "usp_TmpCotizacion_ConsultaInfoDetalle";
                SqlDataAdapter sq = new SqlDataAdapter();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@idpropuesta", pidpropuesta));
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                sq.SelectCommand = cmd;
                sq.Fill(tb, "Table1");
            }
            DataTable dt = tb.Tables[0];
            DataTable dt1 = tb.Tables[1];
            DataTable dt2 = tb.Tables[2];
            DataTable dt3 = tb.Tables[3];
            DataTable dt4 = tb.Tables[4];
            DataTable dt5 = tb.Tables[5];
            DataTable dt6 = tb.Tables[6];           
            foreach (DataRow row in dt.Rows)
            {
                oCotizacion.idCot = int.Parse(row["idcotizacioncab"].ToString());                
                oCotizacion.numCotizacion = row["codigo"].ToString();                
                oCotizacion.nomCliente = row["cliente"].ToString();
                oCotizacion.nomEquipo = row["equipo"].ToString();
                oCotizacion.idresponsable = int.Parse(row["idresponsable"].ToString());
                oCotizacion.idfpago = int.Parse(row["idFormaPago"].ToString());
                oCotizacion.idmoneda = int.Parse(row["idmoneda"].ToString());
                oCotizacion.finicio = row["fecInicio"].ToString();
                oCotizacion.fterminado = row["fecTerminado"].ToString();
                oCotizacion.total = decimal.Parse(row["total"].ToString());
                oCotizacion.valorventa = decimal.Parse(row["valorventa"].ToString());
                oCotizacion.igv = decimal.Parse(row["igv"].ToString());
                oCotizacion.enTaller= row["flag_lugar"].ToString();
                oCotizacion.HorarioEmergencia= row["flag_horaextendida"].ToString();
                oCotizacion.n_dias_hasta_termino = int.Parse(row["duracion"].ToString());
                
            }
            decimal servicio = 0;
            foreach (DataRow row in dt1.Rows)
            {
                oCotizacion.lservicios.Add(new Servicio(int.Parse(row["idservicio"].ToString()), row["servicio"].ToString(), decimal.Parse(row["cantidad"].ToString()), decimal.Parse(row["preciounitario"].ToString()), decimal.Parse(row["vventa"].ToString())));
                servicio =servicio+ decimal.Parse(row["cantidad"].ToString()) * decimal.Parse(row["preciounitario"].ToString())* int.Parse(row["horas"].ToString());
            }
            oCotizacion.servicio = servicio;   
            foreach (DataRow row in dt3.Rows)
            {
                oCotizacion.lcomponentes.Add(new Componente(int.Parse(row["id"].ToString()), row["componente"].ToString(), decimal.Parse(row["cantidad"].ToString())
                    , row["codigo"].ToString(), row["tipocomponente"].ToString(), decimal.Parse(row["pcotizacion"].ToString()), "S", decimal.Parse(row["vventa"].ToString()), decimal.Parse(row["obtenido"].ToString()), int.Parse(row["idComponenteTipo"].ToString()), int.Parse(row["duracion"].ToString()), int.Parse(row["horas"].ToString())));
            }
            foreach (DataRow row in dt2.Rows)
            {
                oCotizacion.lespecialidades.Add(new Especialidad(int.Parse(row["idespecialidad"].ToString()), row["especialidad"].ToString(), decimal.Parse(row["cantidad"].ToString()), 0, decimal.Parse(row["obtenido"].ToString())));
            }
            if (oCotizacion.lceldas == null || oCotizacion.lceldas.Count == 0)
            {
                oCotizacion.lceldas = new List<Celda>();
            } 
                foreach (DataRow row in dt4.Rows)
                {
                    oCotizacion.lceldas.Add(new Celda(int.Parse(row["id"].ToString()), row["codigo"].ToString(), decimal.Parse(row["costosoles"].ToString()), decimal.Parse(row["cantidad"].ToString()), decimal.Parse(row["vventa"].ToString()), decimal.Parse(row["obtenidos"].ToString()), int.Parse(row["duracion"].ToString()), int.Parse(row["horas"].ToString())));
                }            
            if (oCotizacion.lempleados == null)
            {
                oCotizacion.lempleados = new List<Empleado>();
                foreach (DataRow row in dt5.Rows)
                {
                    oCotizacion.lempleados.Add(new Empleado(row["nombre_completo"].ToString(), row["especialidad"].ToString(), int.Parse(row["id"].ToString()), decimal.Parse(row["pcotizacion"].ToString()), decimal.Parse(row["cantidad"].ToString()), decimal.Parse(row["vventa"].ToString()), decimal.Parse(row["HorarioRegular"].ToString()), decimal.Parse(row["HorarioExtendido"].ToString()), int.Parse(row["duracion"].ToString()), int.Parse(row["horas"].ToString())));
                }
            }
            if (oCotizacion.ltipocomponentes == null|| oCotizacion.ltipocomponentes.Count ==0)
            {
                oCotizacion.ltipocomponentes = new List<TipoComponente>();
                foreach (DataRow row in dt6.Rows)//7
                {
                    oCotizacion.ltipocomponentes.Add(new TipoComponente(int.Parse(row["idComponenteTipo"].ToString()), row["descripcion"].ToString(), decimal.Parse(row["cantidad"].ToString()), decimal.Parse(row["obtenido"].ToString())));
                }
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
            return oCotizacion;
        }

        public Cotizacion ObtenerInfoCotizacion(int pidcot)
        {
            Cotizacion oCotizacion = new Cotizacion();
            oCotizacion.lceldas = new List<Celda>();
            oCotizacion.lcomponentes = new List<Componente>();
            oCotizacion.lespecialidades = new List<Especialidad>();
            oCotizacion.lservicios = new List<Servicio>();
            DataSet tb = new DataSet();
            using (var helper = new SqlHelper())
            {
                helper.Connect();

                var sql = "usp_Cotizacion_ConsultaInfoDetalle";
                SqlDataAdapter sq = new SqlDataAdapter();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@idcotizacioncab", pidcot));
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                sq.SelectCommand = cmd;
                sq.Fill(tb, "Table1");
            }
            DataTable dt = tb.Tables[0];
            DataTable dt1 = tb.Tables[1];
            DataTable dt2 = tb.Tables[2];
            DataTable dt3 = tb.Tables[3];
            DataTable dt4 = tb.Tables[4];
            DataTable dt5 = tb.Tables[5];
            DataTable dt6 = tb.Tables[6];
            foreach (DataRow row in dt.Rows)
            {
                oCotizacion.idCot = int.Parse(row["idcotizacioncab"].ToString());
                oCotizacion.numCotizacion = row["codigo"].ToString();
                oCotizacion.nomCliente = row["cliente"].ToString();
                oCotizacion.nomEquipo = row["equipo"].ToString();
                oCotizacion.idresponsable = int.Parse(row["idresponsable"].ToString());
                oCotizacion.idfpago = int.Parse(row["idFormaPago"].ToString());
                oCotizacion.idmoneda = int.Parse(row["idmoneda"].ToString());
                oCotizacion.finicio = row["fecInicio"].ToString();
                oCotizacion.fterminado = row["fecTerminado"].ToString();
                oCotizacion.total = decimal.Parse(row["total"].ToString());
                oCotizacion.valorventa = decimal.Parse(row["valorventa"].ToString());
                oCotizacion.igv = decimal.Parse(row["igv"].ToString());
                oCotizacion.enTaller = row["flag_lugar"].ToString();
                oCotizacion.HorarioEmergencia = row["flag_horaextendida"].ToString();
                oCotizacion.n_dias_hasta_termino = int.Parse(row["duracion"].ToString());
                oCotizacion.fvencimiento = row["fecvencimiento"].ToString();
                oCotizacion.idfpago = int.Parse(row["idformapago"].ToString());
                oCotizacion.idmoneda = int.Parse(row["idmoneda"].ToString());


            }
            decimal servicio = 0;
            foreach (DataRow row in dt1.Rows)
            {
                oCotizacion.lservicios.Add(new Servicio(int.Parse(row["idservicio"].ToString()), row["servicio"].ToString(), decimal.Parse(row["cantidad"].ToString()), decimal.Parse(row["preciounitario"].ToString()), decimal.Parse(row["vventa"].ToString())));
                servicio = servicio + decimal.Parse(row["cantidad"].ToString()) * decimal.Parse(row["preciounitario"].ToString()) * int.Parse(row["horas"].ToString());
            }
            oCotizacion.servicio = servicio;
            foreach (DataRow row in dt3.Rows)
            {
                oCotizacion.lcomponentes.Add(new Componente(int.Parse(row["id"].ToString()), row["componente"].ToString(), decimal.Parse(row["cantidad"].ToString())
                    , row["codigo"].ToString(), row["tipocomponente"].ToString(), decimal.Parse(row["pcotizacion"].ToString()), "S", decimal.Parse(row["vventa"].ToString()), decimal.Parse(row["obtenido"].ToString()), int.Parse(row["idComponenteTipo"].ToString()), int.Parse(row["duracion"].ToString()), int.Parse(row["horas"].ToString())));
            }
            foreach (DataRow row in dt2.Rows)
            {
                oCotizacion.lespecialidades.Add(new Especialidad(int.Parse(row["idespecialidad"].ToString()), row["especialidad"].ToString(), decimal.Parse(row["cantidad"].ToString()), 0, decimal.Parse(row["obtenido"].ToString())));
            }
            if (oCotizacion.lceldas == null || oCotizacion.lceldas.Count == 0)
            {
                oCotizacion.lceldas = new List<Celda>();
            }
            foreach (DataRow row in dt4.Rows)
            {
                oCotizacion.lceldas.Add(new Celda(int.Parse(row["id"].ToString()), row["codigo"].ToString(), decimal.Parse(row["costosoles"].ToString()), decimal.Parse(row["cantidad"].ToString()), decimal.Parse(row["vventa"].ToString()), decimal.Parse(row["obtenidos"].ToString()), int.Parse(row["duracion"].ToString()), int.Parse(row["horas"].ToString())));
            }
            if (oCotizacion.lempleados == null)
            {
                oCotizacion.lempleados = new List<Empleado>();
                foreach (DataRow row in dt5.Rows)
                {
                    oCotizacion.lempleados.Add(new Empleado(row["nombre_completo"].ToString(), row["especialidad"].ToString(), int.Parse(row["id"].ToString()), decimal.Parse(row["pcotizacion"].ToString()), decimal.Parse(row["cantidad"].ToString()), decimal.Parse(row["vventa"].ToString()), decimal.Parse(row["HorarioRegular"].ToString()), decimal.Parse(row["HorarioExtendido"].ToString()), int.Parse(row["duracion"].ToString()), int.Parse(row["horas"].ToString())));
                }
            }
            if (oCotizacion.ltipocomponentes == null || oCotizacion.ltipocomponentes.Count == 0)
            {
                oCotizacion.ltipocomponentes = new List<TipoComponente>();
                foreach (DataRow row in dt6.Rows)//7
                {
                    oCotizacion.ltipocomponentes.Add(new TipoComponente(int.Parse(row["idComponenteTipo"].ToString()), row["descripcion"].ToString(), decimal.Parse(row["cantidad"].ToString()), decimal.Parse(row["obtenido"].ToString())));
                }
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
            return oCotizacion;
        }

        public Cotizacion ObtenerInfoCotizacion1(int pidCotizacion)
        {
            Cotizacion oCotizacion = new Cotizacion();
            oCotizacion.lceldas = new List<Celda>();
            oCotizacion.lcomponentes = new List<Componente>();
            oCotizacion.lespecialidades = new List<Especialidad>();
            oCotizacion.lservicios = new List<Servicio>();
            DataSet tb = new DataSet();
            using (var helper = new SqlHelper())
            {
                helper.Connect();

                var sql = "usp_Cotizacion_ConsultaInfoDetalle";
                SqlDataAdapter sq = new SqlDataAdapter();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@idcotizacioncab", pidCotizacion));
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure, parameters.ToArray());
                sq.SelectCommand = cmd;
                sq.Fill(tb, "Table1");
            }
            DataTable dt = tb.Tables[0];
            DataTable dt1 = tb.Tables[1];
            DataTable dt2 = tb.Tables[2];
            DataTable dt3 = tb.Tables[3];
            DataTable dt4 = tb.Tables[4];
            DataTable dt5 = tb.Tables[5];
            foreach (DataRow row in dt.Rows)
            {
                // oCotizacion.idCot = int.Parse(row["idcotizacioncab"].ToString());
                // oCotizacion.numSolicitud = row["codigo"].ToString();
                oCotizacion.numCotizacion = row["codigo"].ToString();
                // oCotizacion.enTaller = row["entaller"].ToString();
                oCotizacion.nomCliente = row["cliente"].ToString();
                oCotizacion.nomEquipo = row["equipo"].ToString();
                oCotizacion.fvencimiento = row["fecVencimiento"].ToString();
                oCotizacion.fterminado = row["fecTerminado"].ToString();
                oCotizacion.finicio = row["fecInicio"].ToString();
                oCotizacion.numSolicitud = row["codigosolicitud"].ToString();
                oCotizacion.idCot = int.Parse(row["idCotizacionCab"].ToString());
                //oCotizacion.idCot = int.Parse(row["idcotizacioncab"].ToString());
                // oCotizacion.numSolicitud = row["codigo"].ToString();
                //oCotizacion.numCotizacion = row["codigo"].ToString();
                //oCotizacion.enTaller = row["entaller"].ToString();
                //oCotizacion.nomCliente = row["cliente"].ToString();
                //oCotizacion.nomEquipo = row["equipo"].ToString();
                oCotizacion.idresponsable = int.Parse(row["idresponsable"].ToString());
                oCotizacion.idfpago = int.Parse(row["idFormaPago"].ToString());
                oCotizacion.idmoneda = int.Parse(row["idmoneda"].ToString());
                oCotizacion.enTaller = row["flag_lugar"].ToString();
                oCotizacion.HorarioEmergencia = row["flag_horaextendida"].ToString();
                oCotizacion.valorventa = decimal.Parse(row["valorventa"].ToString());
                oCotizacion.igv = decimal.Parse(row["igv"].ToString());
                oCotizacion.total = decimal.Parse(row["total"].ToString());
                oCotizacion.rentabilidad = 0;

                oCotizacion.n_dias_hasta_termino = int.Parse(row["Duracion"].ToString());
            }
            foreach (DataRow row in dt1.Rows)
            {
                oCotizacion.lservicios.Add(new Servicio(int.Parse(row["idservicio"].ToString()), row["servicio"].ToString(), decimal.Parse(row["cantidad"].ToString()), decimal.Parse(row["costosoles"].ToString()), decimal.Parse(row["vventa"].ToString())));
            }
            foreach (DataRow row in dt2.Rows)
            {
                oCotizacion.lespecialidades.Add(new Especialidad(int.Parse(row["idEspecialidad"].ToString()), row["especialidad"].ToString(), decimal.Parse(row["cantidad"].ToString()), decimal.Parse(row["costosoles"].ToString()), decimal.Parse(row["obtenido"].ToString())));
            }
            foreach (DataRow row in dt3.Rows)
            {
                oCotizacion.lcomponentes.Add(new Componente(int.Parse(row["idcomponente"].ToString()), row["componente"].ToString(), decimal.Parse(row["cantidad"].ToString())
                    , row["codigo"].ToString(), row["tipocomponente"].ToString(), 0, "S", 0, decimal.Parse(row["obtenido"].ToString()), int.Parse(row["idComponenteTipo"].ToString()) ));
            }
            foreach (DataRow row in dt4.Rows)
            {
                oCotizacion.ltipocomponentes.Add(new TipoComponente(int.Parse(row["idcomponentetipo"].ToString()), row["especialidad"].ToString(), decimal.Parse(row["cantidad"].ToString()), decimal.Parse(row["obtenido"].ToString())));
            }
            if (oCotizacion.lceldas == null)
            {
                oCotizacion.lceldas = new List<Celda>();
            }
            if (oCotizacion.lempleados == null)
            {
                oCotizacion.lempleados = new List<Empleado>();
            }
            else
            {
                foreach (DataRow row in dt5.Rows)
                {
                    oCotizacion.lempleados.Add(new Empleado(row["nombre_completo"].ToString(), row["especialidad"].ToString(), int.Parse(row["idpersona"].ToString()), decimal.Parse(row["pcotizacion"].ToString()), decimal.Parse(row["cantidad"].ToString()), 0,0,0));
                }
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
            return oCotizacion;
        }


    }
}
