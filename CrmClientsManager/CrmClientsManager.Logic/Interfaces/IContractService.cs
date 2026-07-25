using CrmClientsManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.Interfaces
{
    public interface IContractService
    {
        public IList<Contract> GetAll();
        public Contract? GetById(int id);
        public IList<Contract> GetByCustomerId(int customerId);
        public int Create(Contract contract);
        public void Update(Contract contract);
        public void Delete(int id);
    }
}
