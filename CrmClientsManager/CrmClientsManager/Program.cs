using CrmClientsManager.Application.Services;
using CrmClientsManager.Application.Servicess;
using CrmClientsManager.Database.Configuration;
using CrmClientsManager.Infrastructure.Factories;
using CrmClientsManager.Infrastructure.Interfaces;
using CrmClientsManager.Infrastructure.Mapping;
using CrmClientsManager.Infrastructure.Repositories;
using CrmClientsManager.UI;
using System.Windows.Forms;

namespace CrmClientsManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
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
        }
    }
}