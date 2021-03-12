using Dapper;
using DetailersApp.WebService.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DetailersApp.WebService.Util
{
    public class DbConnectionManager
    {
        public IDbConnection Connection => GetConnection();
        private string CONN_STRING { get; }

        public DbConnectionManager(string connection)
        {
            this.CONN_STRING = connection;
        }

        private IDbConnection GetConnection()
        {
            return new SqlConnection(CONN_STRING);
        }
    }
}
