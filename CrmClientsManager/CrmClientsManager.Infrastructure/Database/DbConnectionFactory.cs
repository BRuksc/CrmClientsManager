using CrmClientsManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CrmClientsManager.Infrastructure.Database
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString) =>
            _connectionString = connectionString;

        public SqlConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
