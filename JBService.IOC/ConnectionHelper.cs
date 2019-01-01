using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBService.IOC
{
    public class ConnectionHelper
    {
        private static volatile SqlConnection instance;
        private static object syncRoot = new object();
        private string _connectionString = "Data Source=ServerName;" +
                                                "Initial Catalog=DataBaseName;" +
                                                "User id=UserName;" +
                                                "Password=Secret;";

        public ConnectionHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection(string ConnectionName = "")
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new SqlConnection(_connectionString);
                }
            }
            return instance;
        }
    }
}
