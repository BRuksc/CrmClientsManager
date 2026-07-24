using CrmClientsManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        int Add(T record);
        void Update(T record);
    }
}
