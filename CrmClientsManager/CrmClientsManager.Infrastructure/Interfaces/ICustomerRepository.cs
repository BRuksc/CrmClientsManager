using CrmClientsManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Infrastructure.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Customer? GetById(int id);

        int Add(Customer customer);

        void Update(Customer customer);

        void Delete(int id);
    }
}
