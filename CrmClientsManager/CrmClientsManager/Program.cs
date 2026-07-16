using CrmClientsManager.Database.Configuration;
using CrmClientsManager.Infrastructure.Factories;
using CrmClientsManager.Infrastructure.Interfaces;
using CrmClientsManager.Infrastructure.Repositories;
using CrmClientsManager.UI;

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
            Bootstrapper.Run();

            IDbConnectionFactory connFactory = 
                new DbConnectionFactory(DatabaseSettings.ConnectionString);
            var repo = new CustomerRepository(connFactory);

            var test = repo.GetAll();

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}