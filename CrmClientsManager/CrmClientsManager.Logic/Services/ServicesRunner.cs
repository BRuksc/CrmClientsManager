using CrmClientsManager.Application.Interfaces;
using CrmClientsManager.Application.Servicess;
using CrmClientsManager.Database.Configuration;
using CrmClientsManager.Infrastructure.Factories;
using CrmClientsManager.Infrastructure.Interfaces;
using CrmClientsManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.Services
{
    public class ServicseRunner : IServicesRunner
    {
        public ICustomerService CustomerService { get; set; }
        public IContractService ContractService { get; set; }
        public ITicketService TicketService { get; set; }
        public IDashboardService DashboardService { get; set; }

        public void Initialize()
        {
            IDbConnectionFactory connectionFactory =
                new DbConnectionFactory(DatabaseSettings.ConnectionString);

            var customerRepository =
                new CustomerRepository(connectionFactory);

            var contractRepository =
                new ContractRepository(connectionFactory);

            var ticketRepository =
                new TicketRepository(connectionFactory);

            CustomerService =
                new CustomerService(
                    customerRepository);

            ContractService =
                new ContractService(
                    contractRepository);

             TicketService = 
                new TicketService(
                    ticketRepository);

            DashboardService =
                new DashboardService(
                    customerRepository,
                    contractRepository,
                    ticketRepository);
        }
    }
}
