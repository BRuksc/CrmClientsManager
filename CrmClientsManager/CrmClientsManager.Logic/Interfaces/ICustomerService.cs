using CrmClientsManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.Interfaces
{
    public interface ICustomerService
    {
        public IList<Customer> GetCustomers();
        public int Create(Customer customer);
    }
}
