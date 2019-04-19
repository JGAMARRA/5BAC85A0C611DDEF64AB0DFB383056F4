using System;
using System.Data;
using System.Text;
using log4net;
using log4net.Appender;

namespace SistemaPlanificacionOT.Infraestructure.Helpers
{
    public class Logger
    {
        private static readonly ILog Log;

        public Logger()
        {
        }

        static Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
            Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>
        /// Logs the Information messages
        /// </summary>
        /// <param name="message"></param>
        public static void LogInformation(string message)
        {
            Log.Debug(message);
        }

        /// <summary>
        /// Logs the warning messages
        /// </summary>
        /// <param name="message"></param>
        public static void LogWarning(string message)
        {
            Log.Warn(message);
        }

        /// <summary>
        /// Logs the error message
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message)
        {
            Log.Error(message);
        }

        /// <summary>
        /// Logs the exception messages
        /// </summary>
        /// <param name="exc"></param>
        /// <param name="message"></param>
        public static void LogException(Exception exc, string message)
        {
            var builder = new StringBuilder();
            var ex = exc;
            builder.Append("Message:" + message);
            while (null != ex)
            {
                builder.Append("Message:" + ex.Message + "\n");
                builder.Append("StackTrace:" + ex.StackTrace + "\n");
                ex = ex.InnerException;
            }
            Log.Error(builder.ToString());
        }

        public static void LogDbParameters(IDbDataParameter[] parameters)
        {
            foreach (var parameter in parameters)
            {
                Log.Info($"-{parameter.ParameterName}: {parameter.Value}");
            }
        }
    }
}