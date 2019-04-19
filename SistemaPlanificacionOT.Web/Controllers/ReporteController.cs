using iTextSharp.text;
using SistemaPlanificacionOT.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace SistemaPlanificacionOT.Web.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public void CreatePdf(string idcot)
        {
            var fontColor = new BaseColor(0, 0, 0);
            var fontColor_Titulo = new BaseColor(255,255,255);
            var parametros = GetParametros();
            var stream = new MemoryStream();
            //var baseFont=
        }
        public ParametrosPdf GetParametros() {
            var item = new ParametrosPdf();
            var config = XElement.Load(Server.MapPath("..")+"/Content/xml/Reporte.xml");
            var baseFont = config.Element("BaseFont");
            if (baseFont == null) return item;
            var fontFamily = baseFont.Element("FontFamily").Attribute("name").Value;
            var fontSize = Convert.ToSingle(baseFont.Element("FonSize").Attribute("name").Value);
            var r = Convert.ToInt32(baseFont.Element("FontColor").Attribute("r").Value);
            var g = Convert.ToInt32(baseFont.Element("FontColor").Attribute("g").Value);
            var b = Convert.ToInt32(baseFont.Element("FontColor").Attribute("b").Value);
            var fontColor = new BaseColor(r,g,b);

            item.BaseFont = FontFactory.GetFont(fontFamily,fontSize,fontColor);


            return null;
        }
        public static string ConvertToDateTime(string fecha)
        {
            string result = "";
            if (fecha!=null) {
                if (fecha.Length==8) {
                    string _day = fecha.Substring(6,2);
                    string _mes = fecha.Substring(4, 2);
                    string _anio = fecha.Substring(0, 4);
                    result = $"{_day}-{_mes}-{_anio}";
                }
            }
            return result;
        }
    }
}