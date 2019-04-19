using System.Configuration;

namespace SistemaPlanificacionOT.Infraestructure.Settings
{
    public static class ApplicationKeys
    {
        public static string RegeditFolder => ConfigurationManager.AppSettings["config:ApplicationName"];

        public static string RegeditPass => ConfigurationManager.AppSettings["config:key"];

        public static string RutaTemporales => ConfigurationManager.AppSettings["config:RutaTemporales"];

        public static string FtpServer => ConfigurationManager.AppSettings["config:FtpServerImagen"];
        public static string FtpUser => ConfigurationManager.AppSettings["config:FtpUser"];
        public static string FtpPassword => ConfigurationManager.AppSettings["config:FtpPassword"];
        public static  string CadenaConexionExcel => ConfigurationManager.AppSettings["Excel"];


        public static string MaximoFilas => ConfigurationManager.AppSettings["MaxFilasFI"];

        public static string PlantillaAgrupamiento => ConfigurationManager.AppSettings["config:Agrupamiento"];
        public static string PlantillaProspecto => ConfigurationManager.AppSettings["config:Prospecto"];
        public static string FlujoCajaHojaFlujoCaja => ConfigurationManager.AppSettings["config:CargarFlujoCaja"];
        public static string FlujoCajaHojaResumen => ConfigurationManager.AppSettings["config:CargarFlujoCajaResumen"];


        public static string LaserFicheRegeditFolder => ConfigurationManager.AppSettings["config:LFApplicationName"];
        public static string LaserFicheRepository => ConfigurationManager.AppSettings["config:LfRepositorio"];
        public static string LaserFicheFolderBase => ConfigurationManager.AppSettings["config:LfFolderDocument"];
        public static string LaserFicheTemplateName => ConfigurationManager.AppSettings["config:LfTemplate"];


        public static string Db2Esquema => ConfigurationManager.AppSettings["config:DbEschema"];


        public static string FirmaRepositoryPath => ConfigurationManager.AppSettings["config:FirmaRepoPath"];
    }
}