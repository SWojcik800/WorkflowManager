using Dapper;
using Microsoft.Data.SqlClient;
using StorageManager.App.Commons;
using StorageManager.App.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManager.App.Database
{
    public static class DbConnectionFactory
    {
        private static string _connectionString;

        public static Result<bool> CanConnect(ConnectionCreds creds)
        {
            try
            {
                string connectionString = GetConnectionString(creds);

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Query<int>("SELECT 1");
                    _connectionString = connectionString;
                    return Result<bool>.Success(true);
                }


            }
            catch (Exception e)
            {

                return Result<bool>.Fail("");

            }
        }

        public static string GetConnectionString(ConnectionCreds creds)
        {
            var sqlConnectionBuilder = new SqlConnectionStringBuilder();

            if (!string.IsNullOrEmpty(creds.Server))
                sqlConnectionBuilder.DataSource = creds.Server;

            if (!string.IsNullOrEmpty(creds.Database))
                sqlConnectionBuilder.InitialCatalog = creds.Database;

            if (!string.IsNullOrEmpty(creds.Login))
                sqlConnectionBuilder.UserID = creds.Login;

            if (!string.IsNullOrEmpty(creds.Password))
                sqlConnectionBuilder.Password = creds.Password;
            sqlConnectionBuilder.TrustServerCertificate = creds.TrustServerCertificate;
            sqlConnectionBuilder.IntegratedSecurity = creds.IntegratedSecurity;

            var connectionString = sqlConnectionBuilder.ToString();
            return connectionString;
        }

        public static DbConnection Create()
            => new SqlConnection(_connectionString);

        public static AppDbContext CreateDbContext()
            => new AppDbContext(_connectionString);

        public static void SaveToRegistry(ConnectionCreds creds)
        {
            RegistryAccessor.SaveValue("Server", creds.Server);
            RegistryAccessor.SaveValue("Database", creds.Database);
            RegistryAccessor.SaveValue("Password", creds.Password, true);
            RegistryAccessor.SaveValue("TrustServerCertificate", creds.TrustServerCertificate.ToString().ToLower());
            RegistryAccessor.SaveValue("IntegratedSecurity", creds.IntegratedSecurity.ToString().ToLower());
        }

        public static ConnectionCreds GetFromRegistry()
        {
            var connectionCreds = new ConnectionCreds();
            connectionCreds.Server = RegistryAccessor.GetValue("Server");
            connectionCreds.Database = RegistryAccessor.GetValue("Database");
            connectionCreds.Password = RegistryAccessor.GetValue("Password", true);
            connectionCreds.TrustServerCertificate = RegistryAccessor.GetValue("TrustServerCertificate") == "true";
            connectionCreds.IntegratedSecurity = RegistryAccessor.GetValue("IntegratedSecurity") == "true";


            return connectionCreds;
        }

        public static void InitDb(ConnectionCreds creds)
        {
        }
    }


    public class ConnectionCreds
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IntegratedSecurity { get; set; }
        public bool TrustServerCertificate { get; set; }
    }
}
