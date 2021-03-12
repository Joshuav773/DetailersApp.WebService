using Dapper;
using DetailersApp.WebService.Model;
using DetailersApp.WebService.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DetailersApp.WebService.Service
{
    public abstract class CustomerService<T>
    {
        protected IDbConnection _connection;
        protected readonly string CONN_STR = Startup.Configuration?.GetSection("ConnectionStrings:detailersApp").Value;
        
        public CustomerService()
        {
            _connection = new DbConnectionManager(CONN_STR).Connection;
        }

        public virtual async Task<(IEnumerable<T>, string)> GetAll()
        {
            try
            {
                if (_connection is null)
                    return (null, $"SQL Connection error, cannot continue the connections status is [{ Enum.Parse(typeof(ConnectionState), _connection.State.ToString()) }]");

                using (var conn = _connection)
                {
                    var ret = await conn.QueryAsync<T>($"Select * From DetailersApp.dbo.{ GetTableName() }");
                    return (ret, null);
                }
            }
            catch (Exception ex)
            {
                return (null, $"An Exception has occured\n Exception Message: [{ ex?.Message }]");
            }
        }

        public virtual async Task<(T, string)> GetById(int id)
        {
            try
            {
                if (_connection is null)
                    return (default(T), $"SQL Connection error, cannot continue the connections status is [{ Enum.Parse(typeof(ConnectionState), _connection.State.ToString()) }]");

                using (var conn = _connection)
                {
                    var ret = await conn.QueryAsync<T>($"Select * From DetailersApp.dbo.{ GetTableName() } where Id = @Id",
                            new { @Id = id }
                        )
                        ;

                    return (ret.FirstOrDefault(), null);
                }
            }
            catch (Exception ex)
            {
                return (default(T), $"An Exception has occured\n Exception Message: [{ ex?.Message }]");
            }
        }

        private string GetTableName()
        {
            return typeof(T).Name;
        }
    }
}
