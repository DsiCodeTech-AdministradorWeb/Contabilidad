using System;

using System.Data.EntityClient;
using System.Data.SqlClient;

using DsiCodeTech.Common.Security;

namespace DsiCodeTech.Common.Util
{
    public sealed class SqlInjectConnection
    {
        public static readonly string SYSTEM_ENVIRONMENT_ACCESS_SQL_SERVER = "SYSTEM_ENVIRONMENT_ACCESS_SQL_SERVER";
        public static readonly string SYSTEM_ENVIRONMENT_ACCESS_SQL_USER = "SYSTEM_ENVIRONMENT_ACCESS_SQL_USER";
        public static readonly string SYSTEM_ENVIRONMENT_ACCESS_SQL_PASSWORD = "SYSTEM_ENVIRONMENT_ACCESS_SQL_PASSWORD";

        private static AesCrypto aesManager = new AesCrypto();
        private static SqlInjectConnection _connection = null;

        private SqlInjectConnection() { }

        public static SqlInjectConnection Connection
        {
            get
            {
                if (_connection is null)
                {
                    _connection = new SqlInjectConnection();
                }

                return _connection;
            }
        }

        public static string ConnectionString()
        {
            SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = @Environment.GetEnvironmentVariable(SYSTEM_ENVIRONMENT_ACCESS_SQL_SERVER, EnvironmentVariableTarget.Machine),
                InitialCatalog = "pos_admin",
                UserID = aesManager.Decrypt(Environment.GetEnvironmentVariable(SYSTEM_ENVIRONMENT_ACCESS_SQL_USER, EnvironmentVariableTarget.Machine)),
                Password = aesManager.Decrypt(Environment.GetEnvironmentVariable(SYSTEM_ENVIRONMENT_ACCESS_SQL_PASSWORD, EnvironmentVariableTarget.Machine)),
                MultipleActiveResultSets = true,
            };

            EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder()
            {
                Provider = "System.Data.SqlClient",
                Metadata = "res://*/PosContabilidad.PosAdmin.csdl|res://*/PosContabilidad.PosAdmin.ssdl|res://*/PosContabilidad.PosAdmin.msl",
                ProviderConnectionString = SqlConnectionStringBuilder.ToString()
            };

            return entityConnectionStringBuilder.ConnectionString;
        }
    }
}
