using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Infrastructure.Interfaces
{
    public interface IBaseRepository<T>
    {
        public IList<T> GetAll();
        public T? GetById(int id);
        public void Delete(int id);
    }
}
