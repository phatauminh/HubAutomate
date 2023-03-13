using Hub.Retailer.Common.Configurations;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Hub.Retailer.Data.Services
{
    public static class OracleDataAccess
    {
        public delegate void HandleDataReader(DbDataReader reader);
        public static async Task<T> ExecuteScalar<T>(string sql, List<OracleParameter> parameters = null)
        {
            using (var conn = GetConnection())
            {
                var command = new OracleCommand(sql, conn);

                if (parameters != null && parameters.Count > 0)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                conn.Open();

                var result = await command.ExecuteScalarAsync();

                if (Equals(result, null) || Equals(result, DBNull.Value))
                    return default(T);
                return (T)result;
            }
        }

        public static async Task<int> ExecuteNonQuery(string sql, List<OracleParameter> parameters = null, CommandType cmdType = CommandType.Text)
        {
            using (var conn = GetConnection())
            {
                var setInfoCommand = new OracleCommand("select pkg_audit.setinfo('Phu',2) from dual", conn);

                var command = new OracleCommand(sql, conn) { CommandType = cmdType };
                command.BindByName = true;
                if (parameters != null && parameters.Count > 0)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                conn.Open();

                await setInfoCommand.ExecuteReaderAsync();

                return await command.ExecuteNonQueryAsync();
            }
        }

        public static async Task ExecuteManyNonQuery(List<string> queries, CommandType cmdType = CommandType.Text)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var setInfoCommand = new OracleCommand("select pkg_audit.setinfo('Phu',2) from dual", conn);
                    conn.Open();
                    setInfoCommand.ExecuteReader();
                    foreach (string query in queries)
                    {
                        var command = new OracleCommand(query, conn) { CommandType = cmdType };
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (OracleException ex)
            {
                if (!ex.Message.Contains("ORA-02185: a token other than WORK follows COMMIT")) throw ex;
            }
        }


        public static async Task<int> ExecuteProcedureNonQuery(string procedure, List<OracleParameter> parameters = null, CommandType cmdType = CommandType.StoredProcedure)
        {
            using (var conn = GetConnection())
            {
                var command = conn.CreateCommand();
                command.CommandType = cmdType;
                command.CommandText = procedure;
                command.BindByName = true;

                if (parameters != null && parameters.Count > 0)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                conn.Open();

                return await command.ExecuteNonQueryAsync();
            }
        }

        public static async Task ExecuteReader(string sql, HandleDataReader dataReaderHandler, List<OracleParameter> parameters = null)
        {

            using (var conn = GetConnection())
            {
                var cmd = new OracleCommand(sql, conn);

                if (parameters != null && parameters.Count > 0)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                conn.Open();
                dataReaderHandler(await cmd.ExecuteReaderAsync());
            }
        }

        public static string ExecuteWithOutput(string scriptPath, string param)
        {

            var dataSource = RetailerConfiguration.DatabaseSettings.ConnectionString.Split(';')[0].Replace("Data Source=", "");
            var userName = RetailerConfiguration.DatabaseSettings.ConnectionString.Split(';')[1].Replace("User Id=", "");
            var password = RetailerConfiguration.DatabaseSettings.ConnectionString.Split(';')[2].Replace("Password=", "");

            var DbConnectString = string.Format("\"{0}/{1}@{2}\"", userName, password, dataSource);

            var process = new Process
            {
                StartInfo = new ProcessStartInfo("sqlplus.exe")
                {
                    Arguments =
                        string.Format("{0} @\"{1}\" {2}", DbConnectString, scriptPath, param),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                }
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            process.Close();
            process.Dispose();
            return output;
        }

        private static OracleConnection GetConnection()
        {
            return new OracleConnection(RetailerConfiguration.DatabaseSettings.ConnectionString);
        }

    }
}
