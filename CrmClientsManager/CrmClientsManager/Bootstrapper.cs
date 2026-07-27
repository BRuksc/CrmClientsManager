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
        private readonly IServicesRunner _servicesRunner;

        public Bootstrapper()
        {
            _executor = new Executor<object>(); 
            _servicesRunner = new ServicseRunner();
        }

        public void Run()
        {
            var result = 
                _executor.Execute(() =>
            {
                ApplicationConfiguration.Initialize();

                _servicesRunner.Initialize(); 

                System.Windows.Forms.Application.Run(
                    new MainForm(
                        _servicesRunner.CustomerService,
                        _servicesRunner.ContractService,
                        _servicesRunner.TicketService,
                        _servicesRunner.DashboardService));

                return new object();
            });

            if (!result.IsSuccess)
            {
                foreach (var e in _executor.Errors.Criticals)
                {
                    MessageBox.Show("Critical error: " + e.Message);
                }

                foreach (var e in _executor.Errors.Warnings)
                {
                    MessageBox.Show("Warning: " + e.Message);
                }
            }
        }
    }
}
