using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Server
{
    public class SqlConnectionProvider
    {
        private readonly string _connectionString = new string("Data Source=77.240.38.138;Initial Catalog=FinalExamWpf;User ID=sa;Password=wsehinvaj@13;");

        public SqlConnectionProvider()
        {

        }

        public SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }

}
