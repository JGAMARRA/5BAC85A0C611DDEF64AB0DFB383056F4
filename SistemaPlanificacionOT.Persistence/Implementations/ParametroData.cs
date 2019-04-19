using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Persistence.Common;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SistemaPlanificacionOT.Persistence.Implementations
{
    public class ParametroData
    {
        public ParametrosModel ObtenerDatosCotizacion()
        {
            var oParametroModel = new ParametrosModel();
            List<Moneda> lmonedas = new List<Moneda>();
            List<Empleado> lempleados = new List<Empleado>();
            List<FormaPago> lfpagos = new List<FormaPago>();
            DataSet tb = new DataSet();
            
            using (var helper = new SqlHelper())
            {
                helper.Connect();

                var sql = "usp_Parametro_ConsultaCotizacion";
                SqlDataAdapter sq = new SqlDataAdapter();            
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure);
                sq.SelectCommand = cmd;
                sq.Fill(tb, "Table1");
            }
            DataTable dt = tb.Tables[0];
            DataTable dt1 = tb.Tables[1];
            DataTable dt2 = tb.Tables[2];
            Moneda oMoneda;
            Empleado oEmpleado;
            FormaPago oFPago;
            foreach (DataRow row in dt.Rows)
            {
                oMoneda=new Moneda();
                oMoneda.codigo = int.Parse(row["codigo"].ToString());
                oMoneda.descripcion = row["descripcion"].ToString();
                oMoneda.tipocambio = decimal.Parse(row["tipocambio"].ToString());
                lmonedas.Add(oMoneda);
            }
            foreach (DataRow row in dt1.Rows)
            {
                oEmpleado = new Empleado();
                oEmpleado.codigo = int.Parse(row["codigo"].ToString());
                oEmpleado.nombre = row["nombre_completo"].ToString();
                lempleados.Add(oEmpleado);
            }
            foreach (DataRow row in dt2.Rows)
            {
                oFPago = new FormaPago();
                oFPago.codigo = int.Parse(row["codigo"].ToString());
                oFPago.descripcion = row["descripcion"].ToString();
                lfpagos.Add(oFPago);
            }
            oParametroModel.lmonedas = lmonedas;
            oParametroModel.lempleados = lempleados;
            oParametroModel.lfpagos = lfpagos;
            return oParametroModel;
        }

        public ParametrosModel ObtenerDatosRecurso(int tipo)
        {
            var oParametroModel = new ParametrosModel();            
            DataSet tb = new DataSet();            
            using (var helper = new SqlHelper())
            {
                helper.Connect();
                var sql = "usp_Parametro_ConsultaRecurso";
                SqlDataAdapter sq = new SqlDataAdapter();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@tipo", tipo));
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure,parameters.ToArray());
                sq.SelectCommand = cmd;
                sq.Fill(tb, "Table1");
            }
            DataTable dt = tb.Tables[0];
            if (tipo==1) {
                Celda oCelda;
                List<Celda> lceldas = new List<Celda>();
                foreach (DataRow row in dt.Rows)
                {
                    oCelda = new Celda();
                    oCelda.nombre = row["codigo"].ToString();
                    oCelda.idvalor= row["idvalor"].ToString();
                    //oCelda.largo= decimal.Parse(row["largo"].ToString());
                    //oCelda.costosoles= decimal.Parse(row["costosoles"].ToString());
                    lceldas.Add(oCelda);
                }
                oParametroModel.lceldas = lceldas;
            }
            if (tipo == 2)
            {
                Componente oComponente;
                List<Componente> lcomponentes = new List<Componente>();
                foreach (DataRow row in dt.Rows)
                {
                    oComponente = new Componente();
                    oComponente.idcomponente = int.Parse(row["id"].ToString());
                    oComponente.codigo = row["codigo"].ToString();
                    oComponente.nombre = row["componente"].ToString();
                    oComponente.tipocomponente = row["tipocomponente"].ToString();
                    oComponente.costosoles = decimal.Parse(row["costosoles"].ToString());
                    oComponente.cantidad = decimal.Parse(row["stock"].ToString());
                    lcomponentes.Add(oComponente);
                }
                oParametroModel.lcomponentes = lcomponentes;
            }
            if (tipo == 3)
            {
                TipoComponente oTipoComponente;
                List<TipoComponente> ltipocomponentes = new List<TipoComponente>();
                foreach (DataRow row in dt.Rows)
                {
                    oTipoComponente = new TipoComponente();
                    oTipoComponente.id= int.Parse(row["idcomponentetipo"].ToString());                    
                    oTipoComponente.nombre = row["descripcion"].ToString();
                    ltipocomponentes.Add(oTipoComponente);
                }
                oParametroModel.ltipocomponentes = ltipocomponentes;
            }
            if (tipo == 4)
            {
                Empleado oEmpleado;
                List<Empleado> lempleados = new List<Empleado>();
                foreach (DataRow row in dt.Rows)
                {
                    oEmpleado = new Empleado();
                    oEmpleado.codigo = int.Parse(row["id"].ToString());
                    oEmpleado.nombre = row["nombre_completo"].ToString();
                    oEmpleado.especialidad = row["especialidad"].ToString();
                    oEmpleado.costosoles = decimal.Parse(row["costosoles"].ToString());
                    lempleados.Add(oEmpleado);
                }
                oParametroModel.lempleados = lempleados;
            }
            if (tipo == 5)
            {
                Especialidad oEspecialidad;
                List<Especialidad> lespecialidades = new List<Especialidad>();
                foreach (DataRow row in dt.Rows)
                {
                    oEspecialidad = new Especialidad();
                    oEspecialidad.idespecialidad = int.Parse(row["idespecialidad"].ToString());
                    oEspecialidad.nombre = row["descripcion"].ToString();
                    lespecialidades.Add(oEspecialidad);
                }
                oParametroModel.lespecialidades = lespecialidades;
            }
            if (tipo == 6)
            {
                Servicio oServicio;
                List<Servicio> lservicios = new List<Servicio>();
                foreach (DataRow row in dt.Rows)
                {
                    oServicio = new Servicio();
                    oServicio.idvalor = row["idvalor"].ToString();
                    oServicio.nombre = row["servicio"].ToString();
                    lservicios.Add(oServicio);
                }
                oParametroModel.lservicios = lservicios;
            }
            return oParametroModel;
        }

        public ParametrosModel ObtenerParametrosServicio()
        {
            var oParametroModel = new ParametrosModel();
            List<Moneda> lmonedas = new List<Moneda>();
            List<ServicioTipo> lserviciotipo = new List<ServicioTipo>();
            DataSet tb = new DataSet();
            //var list = new List<CotizacionInfo>();
            using (var helper = new SqlHelper())
            {
                helper.Connect();

                var sql = "usp_Parametro_ConsultaServicio";
                SqlDataAdapter sq = new SqlDataAdapter();
                //List<SqlParameter> parameters = new List<SqlParameter>();                
                SqlCommand cmd = helper.CreateCommand(sql, CommandType.StoredProcedure);
                sq.SelectCommand = cmd;
                sq.Fill(tb, "Table1");
            }
            DataTable dt = tb.Tables[0];
            DataTable dt1 = tb.Tables[1];
            Moneda oMoneda;
            ServicioTipo oServicioTipo;
            foreach (DataRow row in dt.Rows)
            {
                oMoneda = new Moneda();
                oMoneda.codigo = int.Parse(row["codigo"].ToString());
                oMoneda.descripcion = row["descripcion"].ToString();
                oMoneda.tipocambio = decimal.Parse(row["tipocambio"].ToString());
                lmonedas.Add(oMoneda);
            }
            foreach (DataRow row in dt1.Rows)
            {
                oServicioTipo = new ServicioTipo();
                oServicioTipo.id = int.Parse(row["codigo"].ToString());
                oServicioTipo.descripcion = row["descripcion"].ToString();
                lserviciotipo.Add(oServicioTipo);
            }
            oParametroModel.lmonedas = lmonedas;
            oParametroModel.ltiposervicios = lserviciotipo;
            return oParametroModel;
        }
    }
}
