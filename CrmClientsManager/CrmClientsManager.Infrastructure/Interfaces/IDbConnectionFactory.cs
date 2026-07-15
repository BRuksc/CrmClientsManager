using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CrmClientsManager.Infrastructure.Interfaces
{
    public interface IDbConnectionFactory
    {
        public SqlConnection CreateConnection();
    }
}
