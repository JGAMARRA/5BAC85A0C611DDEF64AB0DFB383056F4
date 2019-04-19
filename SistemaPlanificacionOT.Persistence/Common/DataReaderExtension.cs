using System;
using System.Data;

namespace SistemaPlanificacionOT.Persistence.Common
{
    internal static class DataReaderExtension
    {
        /// <summary>
        /// Recupera un valor int nulo
        /// </summary>
        /// <param name="reader">Objeto DataReader</param>
        /// <param name="paramName">Nombre del parametro</param>
        /// <param name="defaultValue">Valor por defecto</param>
        /// <returns>Int nulo</returns>
        public static int? GetIntOrNull(this IDataReader reader, string paramName, int? defaultValue = null)
        {
            return reader.IsDBNull(reader.GetOrdinal(paramName)) ? defaultValue : reader.GetInt32(reader.GetOrdinal(paramName));
        }

        /// <summary>
        /// Recupera un valor int
        /// </summary>
        /// <param name="reader">Objeto DataReader</param>
        /// <param name="paramName">Nombre del parametro</param>
        /// <returns>Int</returns>
        public static int GetInt(this IDataReader reader, string paramName)
        {
            var valueReturn = Convert.ToInt32(reader[paramName]);
            //return reader.GetInt32(reader.GetOrdinal(paramName));
            return valueReturn;
        }

        /// <summary>
        /// Recupera un valor int16
        /// </summary>
        /// <param name="reader">Objeto DataReader</param>
        /// <param name="paramName">Nombre del parametro</param>
        /// <returns>Int</returns>
        public static Int16 GetInt16(this IDataReader reader, string paramName)
        {
            return reader.GetInt16(reader.GetOrdinal(paramName));
        }

        /// <summary>
        /// Recupera un valor decimal
        /// </summary>
        /// <param name="reader">Objeto DataReader</param>
        /// <param name="paramName">Nombre del parametro</param>
        /// <returns>decimal</returns>
        public static decimal GetDecimal(this IDataReader reader, string paramName)
        {
            return reader.GetDecimal(reader.GetOrdinal(paramName));
        }

        /// <summary>
        /// Recupera un valor decimal
        /// </summary>
        /// <param name="reader">Objeto DataReader</param>
        /// <param name="paramName">Nombre del parametro</param>
        /// <param name="defaultValue">Valor por defecto</param>
        /// <returns>decimal</returns>
        public static decimal? GetDecimalOrNull(this IDataReader reader, string paramName, decimal? defaultValue = null)
        {
            return reader.IsDBNull(reader.GetOrdinal(paramName)) ? defaultValue : reader.GetDecimal(reader.GetOrdinal(paramName));
        }

        /// <summary>
        /// Recupera un valor string
        /// </summary>
        /// <param name="reader">Objeto DataReader</param>
        /// <param name="paramName">Nombre del parametro</param>
        /// <param name="defaultValue">Valor por defecto</param>
        /// <returns>String</returns>
        public static string GetString(this IDataReader reader, string paramName, string defaultValue = null)
        {
            return reader.IsDBNull(reader.GetOrdinal(paramName)) ? defaultValue : Convert.ToString(reader[paramName]).Trim();
        }

        /// <summary>
        /// Recupera un valor DateTime nulo
        /// </summary>
        /// <param name="reader">Objeto DataReader</param>
        /// <param name="paramName">Nombre del parametro</param>
        /// <param name="defaultValue">Valor por defecto</param>
        /// <returns>DateTime nulo</returns>
        public static DateTime? GetDateTimeNull(this IDataReader reader, string paramName, DateTime? defaultValue = null)
        {
            return reader.IsDBNull(reader.GetOrdinal(paramName)) ? defaultValue : reader.GetDateTime(reader.GetOrdinal(paramName));
        }

        /// <summary>
        /// Recupera un valor DateTime
        /// </summary>
        /// <param name="reader">Objeto DataReader</param>
        /// <param name="paramName">Nombre del parametro</param>
        /// <returns>DateTime</returns>
        public static DateTime GetDateTime(this IDataReader reader, string paramName)
        {
            return reader.GetDateTime(reader.GetOrdinal(paramName));
        }

        /// <summary>
        /// Recupera un valor Bool
        /// </summary>
        /// <param name="reader">Objeto DataReader</param>
        /// <param name="paramName">Nombre del parametro</param>
        /// <returns>Bool</returns>
        public static bool GetBool(this IDataReader reader, string paramName)
        {
            return reader.GetBoolean(reader.GetOrdinal(paramName));
        }

        /// <summary>
        /// Recupera un valor Bool
        /// </summary>
        /// <param name="reader">Objeto DataReader</param>
        /// <param name="paramName">Nombre del parametro</param>
        /// <param name="defaultValue">Valor por defecto</param>
        /// <returns>Bool</returns>
        public static bool GetBoolOrNull(this IDataReader reader, string paramName, bool defaultValue = false)
        {
            return reader.IsDBNull(reader.GetOrdinal(paramName)) ? defaultValue : reader.GetBoolean(reader.GetOrdinal(paramName));
        }

        public static double GetDouble(this IDataReader reader, string paramName)
        {
            var doubleValue = Convert.ToDouble(reader[paramName]);
            //return reader.GetDouble(reader.GetOrdinal(paramName));
            return doubleValue;
        }

        public static double? GetDoubleOrNull(this IDataReader reader, string paramName, double? defaultValue = null)
        {
            return reader.IsDBNull(reader.GetOrdinal(paramName)) ? defaultValue : reader.GetDouble(reader.GetOrdinal(paramName));
        }
    }
}