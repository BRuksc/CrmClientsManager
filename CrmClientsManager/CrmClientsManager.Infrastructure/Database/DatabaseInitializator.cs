using CrmClientsManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CrmClientsManager.Infrastructure.Database
{
    public class DatabaseInitializator : IDatabaseInitialize
    {
        private readonly SqlConnection _connection;

        public DatabaseInitializator(SqlConnection connection)
        {
            _connection = connection;
        }

        public void Initialize()
        {
            _connection.Open();
             
            var path = Path.Combine(AppContext.BaseDirectory, "CrmClientsManager.Database", "Scripts", "Initialize.sql");

            var script = File.ReadAllText(path);

            var command = new SqlCommand(script, _connection);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
