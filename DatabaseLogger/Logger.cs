using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DatabaseLogger
{
    public class Logger : ILogger
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;
            var connectionString = connectionStrings[1].ToString();
            return connectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="logType"></param>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        public bool DoLog(string logType, string logMessage)
        {
            var linesAffected = 0;
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(GetConnectionString()))
                {
                    sqlConn.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("SPU_INS_DB_LOGGER", sqlConn))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@LOG_TYPE", SqlDbType.VarChar, 50).Value = logType;
                        sqlCommand.Parameters.Add("@LOG_MESSAGE", SqlDbType.VarChar, 50).Value = logMessage;

                        linesAffected = sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                //Final notes
            }
            return linesAffected > 0;
        }
    }
}
