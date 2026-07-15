using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Database.Configuration
{
    public static class DatabaseSettings
    {
        public const string MasterConnectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=True";

        public const string ConnectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=CrmClientsManager;Integrated Security=True";
    }
}
