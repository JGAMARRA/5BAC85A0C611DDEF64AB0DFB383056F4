using SistemaPlanificacionOT.Domain.Models;
using SistemaPlanificacionOT.Domain.Models.AG;
using SistemaPlanificacionOT.Persistence.Implementations;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SistemaPlanificacionOT.Domain.Implementations
{
    public class AGDomain
    {
        private AGData AGDA = new AGData();
        private CotizacionData oCotizacionData = new CotizacionData();
        public List<Cotizacion> obtenerOptimoRentabilidad(Cotizacion oCotizacion)
        {
            //cromosomas
            List<Cotizacion> lsoluciones = new List<Cotizacion>();
            List<Cotizacion> lgeneracion = new List<Cotizacion>();
            //carga genes o individuos
            List<Recurso> poblacion_celdas = new List<Recurso>();
            List<Recurso> poblacion_componentes = new List<Recurso>();
            List<Recurso> poblacion_empleados = new List<Recurso>();
            List<Recurso> poblacion_componentesTipo = new List<Recurso>();
            //puede no ser necesario limites dentro del objeto ya esta

            AGDA.BuscarRecursos(oCotizacion, poblacion_celdas, poblacion_componentes, poblacion_empleados, poblacion_componentesTipo);
            //poblar,fabricar cromosomas
            int num_poblacion = 120;
            int generacion = 0;
            int tope = 70;
            //List<Cotizacion> lsoluciones = new List<Cotizacion>();
            Cotizacion hijopadre = null;
            Cotizacion hijomadre = null;
            Cotizacion padre = null;
            Cotizacion madre = null;
            poblarCromosomas(generacion, num_poblacion, poblacion_celdas, poblacion_componentes, poblacion_empleados, poblacion_componentesTipo, lsoluciones, oCotizacion);
            imprime(lsoluciones,"poblacion.txt");
            lgeneracion = lsoluciones;
            List<Cotizacion> ltemporal = new List<Cotizacion>();
            while (generacion < tope)
            {

                ltemporal.AddRange(seleccionCruce("CRUCE", generacion, lgeneracion, ref padre, ref madre));
                if (lgeneracion.Count>1) {
                    hijopadre = lgeneracion[0];
                    hijomadre = lgeneracion[1];
                    ltemporal.AddRange(mutacion("MUTACION", generacion, hijopadre, hijomadre, padre, madre));
                    ltemporal.AddRange(mutacion("MUTACION", generacion, hijopadre, hijomadre, padre, madre));
                }
                lsoluciones.AddRange(ltemporal);
                lgeneracion = ltemporal;
                ltemporal = new List<Cotizacion>();
                generacion++;
            }
            //while (generacion < tope)
            //{
            //    lsoluciones.AddRange(seleccionCruce("CRUCE", generacion, lsoluciones, ref padre, ref madre));
            //    hijopadre = lsoluciones[0];
            //    hijomadre = lsoluciones[1];
            //    //if () { break; }
            //    lsoluciones.AddRange(mutacion("MUTACION", generacion, hijopadre, hijomadre, padre, madre));
            //    lsoluciones.AddRange(mutacion("MUTACION", generacion, hijopadre, hijomadre, padre, madre));

            //    generacion++;
            //}
            int nt = 10;
            var query1  = lsoluciones
        .GroupBy(o => new { o.rentabilidad })
        .Select(o =>o.FirstOrDefault()).OrderByDescending(o => o.rentabilidad).Take(nt).ToList(); 
            int n = 1;
            string cad= "";
            foreach (var item in query1)
            {
                cad = "0000000" + n.ToString();
                
                item.idCot = oCotizacion.idCot;
                item.codigo = "PROPUESTA_"+ cad.Substring(cad.Length - 4); 
                n++;
            }

            //var query =
            //(from cust in lsoluciones            
            // orderby cust.total descending
            // select cust).Take(5);

            guardarPropuestas(query1.OrderByDescending(o => o.rentabilidad).Take(nt).ToList());
            imprime(lsoluciones,"solucion.txt");
            return query1.OrderByDescending(o=>o.rentabilidad).Take(nt).ToList();


        }


        private void guardarPropuestas(List<Cotizacion> lpropuestas) {
            foreach (var item in lpropuestas)
            {
                oCotizacionData.InsertarTmpCotizacion(item);
            }

        }

        public void imprime(List<Cotizacion> lsoluciones,string file)
        {

            //string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            //string archivo = path + @"\files\"+file+".txt";
            //string misDatos = Environment.GetFolderPath(Environment.SpecialFolders.ApplicationData);
            var ruta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory+ @"bin\files\");
            //string ruta = jsonFolder;// @"C:\Users\jorge\Downloads\PlataformaEvaluacionMasiva 201810312\PlataformaEvaluacionMasiva\SistemaPlanificacionOT.Web\bin\files\";
        
            StreamWriter sw = new StreamWriter(ruta+file);
           // StreamWriter sw = new StreamWriter(@"..\Content\files\" + file + ".txt");
            var query =
            (from cust in lsoluciones
             orderby cust.generacion descending
             select cust);
            foreach (var item in query.ToList())
            {


                sw.Write("generacion " + item.generacion.ToString() + " idcot " + item.idCot.ToString() + " tipo_sel " + item.seleccion + " cod " + item.codigo + " renta " + item.rentabilidad+" calidad "+item.calidad);
                sw.WriteLine();
                sw.Write("celdas ");
                sw.WriteLine();
                if (item.lceldas != null)
                {

                    foreach (var item1 in item.lceldas)
                    {
                        sw.Write("id: " + item1.id.ToString().PadLeft(2, '0') + " soles: " + item1.costosoles.ToString() + " cant: " + item1.cantidad);
                        sw.WriteLine();
                    }
                }
                sw.WriteLine();
                sw.Write("componentes ");
                sw.WriteLine();
                if (item.lcomponentes != null)
                {
                    foreach (var item2 in item.lcomponentes)
                    {
                        sw.Write("id: " + item2.idcomponente.ToString().PadLeft(2, '0') + " soles: " + item2.costosoles.ToString() + " cant: " + item2.cantidad);
                        sw.WriteLine();
                    }
                }
                sw.WriteLine();
                sw.Write("especialidad ");
                sw.WriteLine();
                if (item.lempleados != null)
                {

                    foreach (var item3 in item.lempleados)
                    {
                        sw.Write("id: " + item3.codigo.ToString() + " soles: " + item3.costosoles.ToString() + " cant: " + item3.cantidad);
                        sw.WriteLine();
                    }
                }
                sw.WriteLine();
                sw.Write("---------------");
                sw.WriteLine();
            }

            sw.Close();

        }
        public Cotizacion copiar(Cotizacion oCotizacion)
        {
            Cotizacion oNuevo = new Cotizacion();
            oNuevo.idCot = oCotizacion.idCot;
            oNuevo.codigo = oCotizacion.codigo;
            oNuevo.enTaller = oCotizacion.enTaller;
            oNuevo.fterminado = oCotizacion.fterminado;
            oNuevo.fvencimiento = oCotizacion.fvencimiento;
            oNuevo.idfpago = oCotizacion.idfpago;
            oNuevo.idmoneda = oCotizacion.idmoneda;
            oNuevo.finicio = oCotizacion.finicio;
            oNuevo.idresponsable = oCotizacion.idresponsable;
            oNuevo.nomCliente = oCotizacion.nomCliente;
            oNuevo.nomEquipo = oCotizacion.nomEquipo;
            oNuevo.numCotizacion = oCotizacion.numCotizacion;
            oNuevo.numSolicitud = oCotizacion.numSolicitud;
            oNuevo.total = oCotizacion.total;
            oNuevo.rentabilidad = oCotizacion.rentabilidad;
            oNuevo.ltipocomponentes = oCotizacion.ltipocomponentes;            
            oNuevo.lceldas = oCotizacion.lceldas;
            oNuevo.lcomponentes = oCotizacion.lcomponentes;
            oNuevo.lespecialidades = oCotizacion.lespecialidades;
            oNuevo.lempleados = oCotizacion.lempleados;
            oNuevo.generacion = oCotizacion.generacion;
            oNuevo.lservicios = oCotizacion.lservicios;
            oNuevo.n_dias_hasta_termino = oCotizacion.n_dias_hasta_termino;
            oNuevo.igv = oCotizacion.igv;            
            oNuevo.valorventa = oCotizacion.valorventa;            
            oNuevo.HorarioEmergencia = oCotizacion.HorarioEmergencia;
            oNuevo.hor_horas = oCotizacion.hor_horas;
            
            oNuevo.hor_incremento = oCotizacion.hor_incremento;
            oNuevo.lug_incremento = oCotizacion.lug_incremento;
                
            if (oNuevo.lceldas == null)
            {
                oNuevo.lceldas = new List<Celda>();
            }
            if (oNuevo.lempleados == null)
            {
                oNuevo.lempleados = new List<Empleado>();
            }
            if (oNuevo.lespecialidades == null)
            {
                oNuevo.lespecialidades = new List<Especialidad>();
            }
            if (oNuevo.lcomponentes == null)
            {
                oNuevo.lcomponentes = new List<Componente>();
            }
            if (oNuevo.ltipocomponentes == null)
            {
                oNuevo.ltipocomponentes = new List<TipoComponente>();
            }
            if (oNuevo.lservicios == null)
            {
                oNuevo.lservicios = new List<Servicio>();
            }
            return oNuevo;
        }
        public List<Cotizacion> mutacion(string seleccion, int generacion, Cotizacion hijopadre, Cotizacion hijomadre, Cotizacion padre, Cotizacion madre)
        {
            Random random = new Random();
            //recordemos hijo 1 es copia de padre
            int tiporecurso = random.Next(1, 4);
            int elegido_padre = 0;
            int elegido_madre = 0;
            int elegido_hijopadre = 0;
            int elegido_hijomadre = 0;
            bool cambio = false;
            List<Cotizacion> lmutados = new List<Cotizacion>();
            if (random.NextDouble() < 0.5)
            {
                if (tiporecurso == 1 && madre.lceldas != null)
                {
                    if (madre.lceldas.Count > 0)
                    {
                        elegido_padre = random.Next(padre.lceldas.Count);
                        elegido_madre = random.Next(madre.lceldas.Count);
                        elegido_hijopadre = random.Next(hijopadre.lceldas.Count);
                        elegido_hijomadre = random.Next(hijomadre.lceldas.Count);                        
                        if (hijomadre.lceldas[elegido_hijomadre] != madre.lceldas[elegido_madre]) {
                            hijomadre.lceldas[elegido_hijomadre] = madre.lceldas[elegido_madre];
                            cambio = true;
                        }
                        if (hijopadre.lceldas[elegido_hijopadre] != padre.lceldas[elegido_padre]) {
                            hijopadre.lceldas[elegido_hijopadre] = padre.lceldas[elegido_padre];
                            cambio = true;
                        }
                    }
                }
                if (tiporecurso == 2 && madre.lcomponentes != null)
                {
                    if (madre.lcomponentes.Count > 0)
                    {
                        elegido_padre = random.Next(padre.lcomponentes.Count);
                        elegido_madre = random.Next(madre.lcomponentes.Count);
                        elegido_hijopadre = random.Next(hijopadre.lcomponentes.Count);
                        elegido_hijomadre = random.Next(hijomadre.lcomponentes.Count);
                        //itemComponente = padre.lcomponentes[elegido_padre];
                        if (hijomadre.lcomponentes[elegido_hijomadre].idcomponente != madre.lcomponentes[elegido_madre].idcomponente) {
                            hijomadre.lcomponentes[elegido_hijomadre] = madre.lcomponentes[elegido_madre];
                            cambio = true;
                        }
                        if (hijopadre.lcomponentes[elegido_hijopadre].idcomponente != padre.lcomponentes[elegido_padre].idcomponente) {
                            hijopadre.lcomponentes[elegido_hijopadre] = padre.lcomponentes[elegido_padre];
                            cambio = true;
                        }

                        //hijo.lcomponentes[elegido_padre] = hijo2.lcomponentes;
                    }
                }
                if (tiporecurso == 3 && madre.lempleados != null)
                {
                    if (madre.lempleados.Count > 0)
                    {

                        elegido_padre = random.Next(padre.lempleados.Count);
                        elegido_madre = random.Next(madre.lempleados.Count);
                        elegido_hijopadre = random.Next(hijopadre.lempleados.Count);
                        elegido_hijomadre = random.Next(hijomadre.lempleados.Count);
                        //itemEmpleado = padre.lempleados[elegido_padre];
                        if (hijomadre.lempleados[elegido_hijomadre].codigo != madre.lempleados[elegido_madre].codigo) {
                            hijomadre.lempleados[elegido_hijomadre] = madre.lempleados[elegido_madre];
                            cambio = true;
                        }
                        if (hijopadre.lempleados[elegido_hijopadre].codigo != padre.lempleados[elegido_padre].codigo) {
                            hijopadre.lempleados[elegido_hijopadre] = padre.lempleados[elegido_padre];
                            cambio = true;
                        }                                               
                    }
                }
                if (cambio==true) {
                    hijopadre.rentabilidad = EvaluarTotal(hijopadre);
                    hijomadre.rentabilidad = EvaluarTotal(hijomadre);
                    hijopadre.calidad = EvaluarPenalidad(hijopadre);
                    hijomadre.calidad = EvaluarPenalidad(hijomadre);
                    hijomadre.generacion = generacion;
                    hijopadre.generacion = generacion;
                    hijomadre.seleccion = seleccion;
                    hijopadre.seleccion = seleccion;
                    lmutados.Add(hijomadre);
                    lmutados.Add(hijopadre);
                    cambio = false;
                }
                
            }
            return lmutados;
        }
        public int CalculoIdRecursos(Cotizacion obj) {
            int total = 0;
            foreach (var item in obj.lceldas)
            {

            }
            foreach (var item1 in obj.lcomponentes)
            {
                total = total + item1.idcomponente;
            }
            foreach (var item2 in obj.lempleados)
            {
                total = total + item2.codigo;
            }
            return total;
        }
        public List<Cotizacion> seleccionCruce(string seleccion, int generacion, List<Cotizacion> lsoluciones, ref Cotizacion padre, ref Cotizacion madre)
        {
            List<Cotizacion> lfamilia = new List<Cotizacion>();
            Random random = new Random();
            int tiporecurso = random.Next(1, 4);
            //int elegido_padre = 0;
            //int elegido_madre = 0;
            //indica que grupo de recursos se intercambiara 1:celda 2:componente 3:especialidad
            var query =
    from cust in lsoluciones
    orderby cust.rentabilidad descending
    select cust;
            //seleccion de los mejores
            if (query.ToList().Count > 1)
            {
                padre = query.ToList()[0];
                madre = query.ToList()[1];
                int cont1 = 0;
                int cont2 = 0;
                int n1 = 0;
                int n2 = 0;
                Cotizacion hijopadre = copiar(padre);
                Cotizacion hijomadre = copiar(madre);
                cont1 = CalculoIdRecursos(hijopadre);
                cont2 = CalculoIdRecursos(hijomadre);
                bool encontro = false;
                //obtenerOptimoRentabilidad los mejores en rentabilidad
                List<Celda> tmpCeldas1 = null;
                List<Celda> tmpCeldas2 = null;
                List<Empleado> tmpEmpleados1 = null;
                List<Empleado> tmpEmpleados2 = null;
                List<Componente> tmpComponentes1 = null;
                List<Componente> tmpComponentes2 = null;

                //if (random.NextDouble() < 0.5) {
                if (cont1 != cont2)
                {                
                    if (tiporecurso == 1)
                    {
                        n1 = hijopadre.lceldas.Count;
                        n2 = hijomadre.lceldas.Count;
                        if (n1 != 0 && n2 != 0)
                        {
                            tmpCeldas1 = hijopadre.lceldas;
                            tmpCeldas2 = hijomadre.lceldas;
                            hijopadre.lceldas = tmpCeldas2;
                            hijomadre.lceldas = tmpCeldas1;
                            encontro = true;
                        }
                        else {
                            tiporecurso = 2;
                        }
                            
                    }
                    if (tiporecurso == 2)
                    {
                        n1 = hijopadre.lcomponentes.Count;
                        n2 = hijomadre.lcomponentes.Count;
                        if (n1 != 0 && n2 != 0)
                        {
                            tmpComponentes1 = hijopadre.lcomponentes;
                            tmpComponentes2 = hijomadre.lcomponentes;
                            hijopadre.lcomponentes = tmpComponentes2;
                            hijomadre.lcomponentes = tmpComponentes1;
                            encontro = true;
                        }
                        else {
                            tiporecurso = 3;
                        }
                                        
                    }
                    if (tiporecurso == 3)
                    { n1 = hijopadre.lempleados.Count;
                        n2 = hijomadre.lempleados.Count;
                        if (n1 != 0 && n2 != 0)
                        {
                            tmpEmpleados1 = hijopadre.lempleados;
                            tmpEmpleados2 = hijomadre.lempleados;
                            hijopadre.lempleados = tmpEmpleados2;
                            hijomadre.lempleados = tmpEmpleados1;
                            encontro = true;
                        }
                         
                    }
                    //  }
                    if (encontro==true) {
                        hijopadre.rentabilidad = EvaluarTotal(hijopadre);
                        hijomadre.rentabilidad = EvaluarTotal(hijomadre);
                        hijopadre.calidad = EvaluarPenalidad(hijopadre);
                        hijomadre.calidad = EvaluarPenalidad(hijomadre);
                        hijomadre.generacion = generacion;
                        hijopadre.generacion = generacion;
                        hijomadre.seleccion = seleccion;
                        hijopadre.seleccion = seleccion;
                        lfamilia.Add(hijopadre);
                        lfamilia.Add(hijomadre);
                    }
                    
                }
            }

            return lfamilia;

        }
        //public int actualizarObtenidos(Cotizacion obj) {

        //}

        public bool elegir(List<Recurso> poblacion,Recurso item) {
            //if (item.usados==0) {
            //    item.elegido = 1;
            //}
            if (0 < item.cantidad && item.usados<=item.cantidad)
            {
                if (item.elegido == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               // return true;
            }
            else {
                item.elegido = 1;
                return false;

                //if (item.elegido == 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            //if (poblacion.Count < 10 && poblacion.Count >= 1)
            //{
            //    return true;
            //}
            //else
            //{
            //    if (item.elegido == 0)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}

        }
        public void poblarCromosomas(int generacion, int num_poblacion, List<Recurso> poblacion_celdas, List<Recurso> poblacion_componentes, List<Recurso> poblacion_empleados, List<Recurso> poblacion_componenteTipo, List<Cotizacion> lsoluciones, Cotizacion oCotizacion)
        {

            Cotizacion oCotizacionPropuesta = null;
            int n = 0;
            //para cada iteracion se trata de generar un nuevo cromosoma (solucion posible)
            List<Celda> lceldas;
            List<Componente> lcomponentes;
            List<Empleado> lempleados;
            List<Especialidad> lespecialidades;
            List<TipoComponente> lcomponentesTipo;
            Celda oCelda;
            Componente oComponente;
            Empleado oEmpleado;
            Especialidad oEspecialidad;
            TipoComponente oComponenteTipo;
            //decimal cantidad = 0;
            int calidad_soluciones = 70;
            int i = 0;
            while (n <= num_poblacion)
            {
                if (i==1000) { break; }
                lceldas = new List<Celda>();
                lcomponentes = new List<Componente>();
                lempleados = new List<Empleado>();
                lespecialidades = new List<Especialidad>();
                lcomponentesTipo = new List<TipoComponente>();
                poblacion_celdas = DesordenarLista(poblacion_celdas);
                poblacion_componentes = DesordenarLista(poblacion_componentes);
                poblacion_empleados = DesordenarLista(poblacion_empleados);
                poblacion_componenteTipo = DesordenarLista(poblacion_componenteTipo);
                oCotizacionPropuesta = new Cotizacion();
               
                foreach (var icelda in oCotizacion.lceldas)
                {
                    if (poblacion_celdas.Count == 0) { break; }
                    foreach (var ocelda1 in poblacion_celdas)
                    {
                        if (ocelda1.id== icelda.id && icelda.obtenidos < icelda.cantidad)
                        {
                           
                            if (elegir(poblacion_celdas,ocelda1)) {
                                oCelda = new Celda();
                                oCelda.id = ocelda1.id;
                                oCelda.costosoles = ocelda1.costo;
                                oCelda.cantidad = 1;
                                oCelda.obtenidos= icelda.obtenidos + 1;
                                ocelda1.elegido = 1;
                                lceldas.Add(oCelda);
                                icelda.obtenidos = icelda.obtenidos + 1;
                             
                            }                                
                        }
                    }
                }
                foreach (var icomponente in oCotizacion.lcomponentes)
                {
                    if (poblacion_componentes.Count == 0) { break; }
                    foreach (var ocomponente1 in poblacion_componentes)
                    {
                
                        if (ocomponente1.id == icomponente.idcomponente) {
                            if (ocomponente1.usados >= icomponente.cantidad)
                            {
                                if (elegir(poblacion_componentes, ocomponente1))
                                {
                                    oComponente = new Componente();
                                    oComponente.idcomponente = ocomponente1.id;
                                    oComponente.costosoles = ocomponente1.costo;
                                    oComponente.cantidad = icomponente.cantidad;
                                    oComponente.obtenidos = icomponente.cantidad;
                                    // ocomponente1.elegido = 0;
                                    ocomponente1.usados = int.Parse(ocomponente1.usados.ToString()) - int.Parse(icomponente.cantidad.ToString());
                                   // ocomponente1.cantidad = int.Parse(ocomponente1.cantidad.ToString()) - int.Parse(icomponente.cantidad.ToString());
                                    lcomponentes.Add(oComponente);
                                    icomponente.obtenidos = icomponente.cantidad ;
                                }
                            }
                            else {
                                if (elegir(poblacion_componentes, ocomponente1))
                                {
                                    oComponente = new Componente();
                                    oComponente.idcomponente = ocomponente1.id;
                                    oComponente.costosoles = ocomponente1.costo;
                                    oComponente.cantidad =icomponente.cantidad; // ocomponente1.usados;
                                    oComponente.obtenidos = ocomponente1.usados;
                                    icomponente.obtenidos = ocomponente1.usados;
                                    // ocomponente1.elegido = 0;
                                    ocomponente1.usados = 0;// int.Parse(ocomponente1.usados.ToString());
                                   // ocomponente1.cantidad = 0;
                                    lcomponentes.Add(oComponente);
                                    
                                }
                            }
                 
                        }
 

                    }
                }
                foreach (var itcomponente in oCotizacion.ltipocomponentes)
                {
                    if (poblacion_componentes.Count == 0) { break; }
                    foreach (var ocomponente1 in poblacion_componentes)
                    {
                        if (ocomponente1.idcomponentetipo == itcomponente.id && itcomponente.obtenidos<itcomponente.cantidad)
                        {
                           
                                if (ocomponente1.usados >= itcomponente.cantidad)
                                {
                                    if (elegir(poblacion_componentes, ocomponente1))
                                    {
                                        oComponente = new Componente();
                                        oComponente.idcomponente = ocomponente1.id;
                                        oComponente.costosoles = ocomponente1.costo;
                                        oComponente.cantidad = itcomponente.cantidad;
                                        oComponente.obtenidos = itcomponente.cantidad;
                                        // ocomponente1.elegido = 0;
                                        ocomponente1.usados = int.Parse(ocomponente1.usados.ToString()) - int.Parse(itcomponente.cantidad.ToString());
                                        // ocomponente1.cantidad = int.Parse(ocomponente1.cantidad.ToString()) - int.Parse(icomponente.cantidad.ToString());
                                        lcomponentes.Add(oComponente);
                                        itcomponente.obtenidos = itcomponente.cantidad;
                                    TipoComponente o = new TipoComponente();
                                    o.id = itcomponente.id;
                                    o.cantidad = itcomponente.cantidad;
                                    o.obtenidos = itcomponente.obtenidos;
                                    o.nombre = itcomponente.nombre;
                                    lcomponentesTipo.Add(o);
                                }
                                }
                                else
                                {
                                    if (elegir(poblacion_componentes, ocomponente1))
                                    {
                                        oComponente = new Componente();
                                        oComponente.idcomponente = ocomponente1.id;
                                        oComponente.costosoles = ocomponente1.costo;
                                        oComponente.cantidad = itcomponente.cantidad; // ocomponente1.usados;
                                        oComponente.obtenidos = ocomponente1.usados;
                                        itcomponente.obtenidos = ocomponente1.usados;
                                        // ocomponente1.elegido = 0;
                                        ocomponente1.usados = 0;// int.Parse(ocomponente1.usados.ToString());
                                                                // ocomponente1.cantidad = 0;
                                        lcomponentes.Add(oComponente);
                                    TipoComponente o = new TipoComponente();
                                    o.id = itcomponente.id;
                                    o.cantidad = itcomponente.cantidad;
                                    o.obtenidos = itcomponente.obtenidos;
                                    o.nombre = itcomponente.nombre;
                                    lcomponentesTipo.Add(o);

                                }
                                }
                            

                        }
                    }
                }

                foreach (var iespecialidad in oCotizacion.lespecialidades)
                {
                    oEspecialidad = new Especialidad();
                    oEspecialidad.idespecialidad = iespecialidad.idespecialidad;
                    oEspecialidad.cantidad = iespecialidad.cantidad;
                    oEspecialidad.obtenidos = 0;
                    if (poblacion_empleados.Count == 0) { break; }
                    foreach (var oempleado1 in poblacion_empleados)
                    {
                        if (oempleado1.idespecialidad == iespecialidad.idespecialidad && iespecialidad.obtenidos < iespecialidad.cantidad)
                        {
                            if (elegir(poblacion_empleados, oempleado1))
                            {
                                oEmpleado = new Empleado();
                                oEmpleado.codigo = oempleado1.id;
                                oEmpleado.costosoles = oempleado1.costo;
                                oEmpleado.cantidad = 1;

                                oempleado1.elegido = 1;
                                lempleados.Add(oEmpleado);
                                
                              oEspecialidad.obtenidos= iespecialidad.obtenidos + 1;
                                iespecialidad.obtenidos = iespecialidad.obtenidos + 1;
                               
                            }
                        }
                    }
                    lespecialidades.Add(oEspecialidad);
                }
                //falta componente tipo


                oCotizacionPropuesta = copiar(oCotizacion);
                oCotizacionPropuesta.lceldas = lceldas;
                oCotizacionPropuesta.lcomponentes = lcomponentes;
                oCotizacionPropuesta.lempleados = lempleados;
                oCotizacionPropuesta.lespecialidades = lespecialidades;
                oCotizacionPropuesta.ltipocomponentes = lcomponentesTipo;
                oCotizacionPropuesta.calidad = EvaluarPenalidad(oCotizacionPropuesta);
                //if (EvaluarPenalidad(oCotizacionPropuesta, oCotizacion) >= 1)
                if (oCotizacionPropuesta.calidad > calidad_soluciones)
                {
                    oCotizacionPropuesta.rentabilidad = EvaluarTotal(oCotizacionPropuesta);
                    oCotizacionPropuesta.generacion = 0;
                    lsoluciones.Add(oCotizacionPropuesta);
                    
                    n++;
                }
                Reset(oCotizacion,poblacion_celdas,poblacion_componentes,poblacion_empleados);
                //}
                i++;
                if (i==500 && lsoluciones.Count<5) {
                    calidad_soluciones = calidad_soluciones-10;
                    n = 0;
                    i = 0;
                }

            }
        }
        //public void ValidarObtenidos(Cotizacion oCotizacionPropuesta, Cotizacion oCotizacion)
        //{

        //}

            public double EvaluarPenalidad(Cotizacion oCotizacion)
        {
           // decimal factor = 0;
            //if (oCotizacionPropuesta.lceldas == null && oCotizacion.lceldas == null)
            //{
            //    factor = factor + 0;
            //}
            //else if (oCotizacionPropuesta.lceldas == null && oCotizacion.lceldas != null)
            //{
            //    factor = factor + 0;
            //}
            //if (oCotizacionPropuesta.lcomponentes == null && oCotizacion.lcomponentes == null)
            //{
            //    factor = factor + 1;
            //}
            //else if (oCotizacionPropuesta.lcomponentes == null && oCotizacion.lcomponentes != null)
            //{
            //    factor = factor + 0;
            //}
            //if (oCotizacionPropuesta.lespecialidades == null && oCotizacion.lespecialidades == null)
            //{
            //    factor = factor + 1;
            //}
            //else if (oCotizacionPropuesta.lespecialidades == null && oCotizacion.lespecialidades != null)
            //{
            //    factor = factor + 0;
            //}

            //if (oCotizacionPropuesta.lceldas != null && oCotizacion.lceldas != null)
            //{
            //    if (oCotizacionPropuesta.lceldas.Count == oCotizacion.lceldas.Count)
            //    {
            //        factor = factor + 1;
            //    }
            //    else if (oCotizacionPropuesta.lceldas.Count < oCotizacion.lceldas.Count)
            //    {
            //        factor = factor + decimal.Parse("0.5");
            //    }
            //    else
            //    {
            //        factor = factor + 0;
            //    }
            //}


            //if (oCotizacionPropuesta.lcomponentes != null && oCotizacion.lcomponentes != null)
            //{
            //    if (oCotizacionPropuesta.lcomponentes.Count == oCotizacion.lcomponentes.Count)
            //    {
            //        factor = factor + 1;
            //    }else if (oCotizacionPropuesta.lcomponentes.Count < oCotizacion.lcomponentes.Count)
            //    {
            //        factor = factor + decimal.Parse("0.5");
            //    }
            //    else
            //    {
            //        factor = factor + 0;
            //    }
            //}

            //if (oCotizacionPropuesta.lespecialidades != null && oCotizacion.lespecialidades != null)
            //{
            //    if (oCotizacionPropuesta.lespecialidades.Count == oCotizacion.lespecialidades.Count)
            //    {
            //        factor = factor + 1;
            //    }
            //    else if (oCotizacionPropuesta.lespecialidades.Count < oCotizacion.lespecialidades.Count)
            //    {
            //        factor = factor + decimal.Parse("0.5");
            //    }
            //    else
            //    {
            //        factor = factor + 0;
            //    }
            //}
            double cantidad = 0;
            double total = 0;
            double result = 0;
            foreach (var item in oCotizacion.lceldas)
            {
                cantidad = cantidad+  double.Parse(item.obtenidos.ToString());
                total = total + double.Parse(item.cantidad.ToString());
            }
            foreach (var item in oCotizacion.lcomponentes)
            {
                cantidad =cantidad+  double.Parse(item.obtenidos.ToString());
                total = total + double.Parse(item.cantidad.ToString());
            }
            foreach (var item in oCotizacion.lespecialidades)
            {
                cantidad =cantidad+  double.Parse(item.obtenidos.ToString());
                total = total + double.Parse(item.cantidad.ToString());
            }
            result = (cantidad / total)*100;
                

            return result;
        }
        public void Reset(Cotizacion oCotizacion,List<Recurso> lceldas, List<Recurso> lcomponentes, List<Recurso> lempleados)
        {
            foreach (var item in lceldas)
            {
                item.usados = item.cantidad;
                item.elegido = 0;
            }
            foreach (var item in lcomponentes)
            {
                item.usados = item.cantidad;
                item.elegido = 0;
            }
            foreach (var item in lempleados)
            {
                item.usados = item.cantidad;
                item.elegido = 0;
            }
       
            if (oCotizacion.lespecialidades != null)
            {
                foreach (var item in oCotizacion.lespecialidades)
                {
                    item.obtenidos = 0;                    
                }
            }
            if (oCotizacion.lcomponentes != null)
            {
                foreach (var item in oCotizacion.lcomponentes)
                {
                    item.obtenidos = 0;
                    
                }
            }
            if (oCotizacion.lceldas != null)
            {
                foreach (var item in oCotizacion.lceldas)
                {
                    item.obtenidos = 0;
                }
            }
            if (oCotizacion.ltipocomponentes != null)
            {
                foreach (var item in oCotizacion.ltipocomponentes)
                {
                    item.obtenidos = 0;
                }
            }
        }


        public decimal EvaluarTotal(Cotizacion oCotizacion)
        {
            decimal total_servicio = 0;
            decimal total = 0;
            decimal penalidad = 0;
            decimal costo_x_servicio = 0;
            //  decimal total_servicio = 5000;// x tiempo de trabajo esto viene de dato del servicio y un tiempo aproximado de duracion
            decimal gasto_fijo = 500;//x todo el tiempo
            decimal porcent_uneta = 0;
            int cant_horas = int.Parse(oCotizacion.hor_horas);
            int por_incremento = 0;
            int ndias = oCotizacion.n_dias_hasta_termino;
            int factor=ndias/ 7;
            decimal factor_incremento = 0;
           // int nhoras = 0;

            if (oCotizacion.HorarioEmergencia == "1")
            {
                por_incremento = int.Parse(oCotizacion.hor_incremento);
               factor_incremento = 1+ (decimal.Parse(por_incremento.ToString()) / decimal.Parse("100"));
                
            }
            else {
                //horario regular:
                ndias = ndias - factor * 2;
            }            
            
            if (oCotizacion.lservicios != null)
            {
                foreach (var item in oCotizacion.lservicios)
                {
                    item.vventa = item.cantidad * item.costosoles  * cant_horas;//ndias
                    total_servicio = total_servicio + item.vventa;
                }
            }
            costo_x_servicio = total_servicio;
            if (oCotizacion.lcomponentes != null)
            {
                foreach (var item in oCotizacion.lcomponentes)
                {
                    item.vventa= item.obtenidos * item.costosoles;
                    total = total + item.vventa;
                    //penalidad
                    if (item.cantidad != 0)
                    {
                        penalidad = penalidad + (item.cantidad - item.obtenidos) * (costo_x_servicio/100) * ndias * cant_horas;
                    }
                }
            }
            if (oCotizacion.lceldas != null)
            {
                foreach (var item in oCotizacion.lceldas)
                {
                    item.vventa= item.obtenidos * item.costosoles * ndias * cant_horas;
                    total = total + item.vventa;
                    //penalidad
                    if (item.cantidad!=0) {
                        penalidad = penalidad + (item.cantidad - item.obtenidos) * (costo_x_servicio/100) * ndias * cant_horas;
                    }
                    
                }
            }
            if (oCotizacion.lempleados != null)
            {
                foreach (var item in oCotizacion.lempleados)
                {
                    item.hnormal = item.cantidad* item.costosoles * ndias * 8;
                    item.hextendido= factor_incremento* item.cantidad * item.costosoles * ndias * 4;
                    
                    item.vventa = item.hnormal + item.hextendido;
                    total = total + item.vventa;

                }
            }
            if (oCotizacion.lespecialidades != null)
            {
                foreach (var item in oCotizacion.lespecialidades)
                {           
                       // total = total + item.obtenidos * item.costosoles * ndias * cant_horas;
                    if (item.cantidad != 0)
                    {    //penalidad
                        penalidad = penalidad + (item.cantidad - item.obtenidos) * (costo_x_servicio/100) * ndias * cant_horas;
                    }                    
                }
            }
            //cuando no hay recursos , el solicitarlos es un costo de tiempo y de compra, se penaliza





            oCotizacion.valorventa = total+costo_x_servicio;
            oCotizacion.igv = (total + costo_x_servicio) *decimal.Parse("0.18");
            oCotizacion.total = oCotizacion.valorventa + oCotizacion.igv;
            // porcent_ubruta = ((costo_x_servicio - total) / costo_x_servicio) * 100;
            porcent_uneta = ((costo_x_servicio - total -penalidad- gasto_fijo) / costo_x_servicio) * 100;


            return porcent_uneta;
        }

        public bool EsTerminado(Cotizacion oCotizacion)
        {
            bool flag = false;
            if (oCotizacion.lespecialidades != null)
            {
                foreach (var item in oCotizacion.lespecialidades)
                {
                    if (item.cantidad == item.obtenidos)
                    {
                        flag = true;
                    }
                }
            }
            if (oCotizacion.lcomponentes != null)
            {
                foreach (var item in oCotizacion.lcomponentes)
                {
                    if (item.cantidad == item.obtenidos)
                    {
                        flag = true;
                    }
                }
            }
            if (oCotizacion.lceldas != null)
            {
                foreach (var item in oCotizacion.lceldas)
                {
                    if (item.cantidad == item.obtenidos)
                    {
                        flag = true;
                    }
                }
            }

            return flag;
        }

        public static List<T> DesordenarLista<T>(List<T> input)
        {
            List<T> arr = input;
            List<T> arrDes = new List<T>();
            Random randNum = new Random();
            while (arr.Count > 0)
            {
                int val = randNum.Next(0, arr.Count - 1);
                arrDes.Add(arr[val]);
                arr.RemoveAt(val);
            }
            return arrDes;
        }
    }

}

