using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.Interfaces
{
    public interface IServicesRunner
    {
        public ICustomerService CustomerService { get; set; }
        public IContractService ContractService { get; set; }
        public ITicketService TicketService { get; set; }
        public IDashboardService DashboardService { get; set; }
        public void Initialize();
    }
}
