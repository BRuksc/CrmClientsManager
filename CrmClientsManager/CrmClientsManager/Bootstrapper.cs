using CrmClientsManager.Application.ErrorHandling;
using CrmClientsManager.Application.Interfaces;
using CrmClientsManager.Application.Services;
using CrmClientsManager.Application.Servicess;
using CrmClientsManager.Database.Configuration;
using CrmClientsManager.Infrastructure.Factories;
using CrmClientsManager.Infrastructure.Interfaces;
using CrmClientsManager.Infrastructure.Repositories;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;

namespace CrmClientsManager.UI
{
    public class Bootstrapper
    {
        private readonly IExecute<object> _executor;

        public Bootstrapper()
        {
            _executor = new Executor<object>(); 
        }

        public void Run()
        {
            _executor.Execute(() =>
            {
                IDbConnectionFactory connectionFactory =
                    new DbConnectionFactory(DatabaseSettings.ConnectionString);

                var customerRepository =
                    new CustomerRepository(connectionFactory);

                var contractRepository =
                    new ContractRepository(connectionFactory);

                var ticketRepository =
                    new TicketRepository(connectionFactory);

                var customerService =
                    new CustomerService(
                        customerRepository);

                var contractService =
                    new ContractService(
                        contractRepository);

                var ticketService =
                    new TicketService(
                        ticketRepository);

                var dashboardService =
                    new DashboardService(
                        customerRepository,
                        contractRepository,
                        ticketRepository);

                ApplicationConfiguration.Initialize();

                System.Windows.Forms.Application.Run(
                    new MainForm(
                        customerService,
                        contractService,
                        ticketService,
                        dashboardService));

                return new object();
            });
        }
    }
}
