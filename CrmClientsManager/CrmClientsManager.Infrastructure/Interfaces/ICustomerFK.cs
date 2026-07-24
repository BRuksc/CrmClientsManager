using CrmClientsManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Infrastructure.Interfaces
{
    public interface ICustomerFK<T> : IRepository<T>
    {
        public IList<T> GetByCustomerId(int customerId);
    }
}
