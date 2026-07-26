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
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}