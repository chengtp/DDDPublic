using DDD.Data.Config;
using DDD.Data.CriteriaConvert;
using DDD.Develop.CQuery.CriteriaConvert;
using DDD.Develop.CQuery.Translator;
using DDD.Util.Fault;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DDD.Data.MySQL
{
    /// <summary>
    /// db server factory
    /// </summary>
    internal static class MySqlFactory
    {
        #region get db connection

        /// <summary>
        /// get mysql database connection
        /// </summary>
        /// <param name="server">database server</param>
        /// <returns>db connection</returns>
        public static IDbConnection GetConnection(ServerInfo server)
        {
            IDbConnection conn = DataManager.GetDBConnection?.Invoke(server) ?? new MySqlConnection(server.ConnectionString);
            return conn;
        }

        #endregion

        #region get query translator

        /// <summary>
        /// get query translator
        /// </summary>
        /// <param name="server">database server</param>
        /// <returns></returns>
        internal static IQueryTranslator GetQueryTranslator(ServerInfo server)
        {
            var translator = DataManager.GetQueryTranslator?.Invoke(server);
            if (translator == null)
            {
                translator = new MySqlQueryTranslator();
            }
            return translator;
        }

        #endregion

        #region criteria convert

        /// <summary>
        /// parse criteria convert
        /// </summary>
        /// <param name="convert">convert</param>
        /// <param name="objectName">object name</param>
        /// <param name="fieldName">field name</param>
        /// <returns></returns>
        internal static string ParseCriteriaConvert(ICriteriaConvert convert, string objectName, string fieldName)
        {
            var criteriaConvertParse = DataManager.GetCriteriaConvertParse(convert?.Name) ?? Parse;
            return criteriaConvertParse(new CriteriaConvertParseOption()
            {
                CriteriaConvert = convert,
                ServerType = ServerType.MySQL,
                ObjectName = objectName,
                FieldName = fieldName
            });
        }

        /// <summary>
        /// parse
        /// </summary>
        /// <param name="option">parse option</param>
        /// <returns></returns>
        static string Parse(CriteriaConvertParseOption option)
        {
            if (string.IsNullOrWhiteSpace(option?.CriteriaConvert?.Name))
            {
                throw new DDDException("criteria convert config name is null or empty");
            }
            string format = null;
            switch (option.CriteriaConvert.Name)
            {
                case CriteriaConvertNames.StringLength:
                    format = $"CHAR_LENGTH({option.ObjectName}.`{option.FieldName}`)";
                    break;
            }
            if (string.IsNullOrWhiteSpace(format))
            {
                throw new DDDException($"cann't resolve criteria convert:{option.CriteriaConvert.Name} for MySQL");
            }
            return format;
        }

        #endregion
    }
}
