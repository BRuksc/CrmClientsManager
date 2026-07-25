using CrmClientsManager.Application.Interfaces;
using CrmClientsManager.Domain.Entities;
using CrmClientsManager.Domain.Enums;
using CrmClientsManager.Infrastructure.Interfaces;
using CrmClientsManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly ContractRepository _contractRepository;
        private readonly ITicketRepository _ticketRepository;

        public DashboardService(
            CustomerRepository customerRepository,
            ContractRepository contractRepository,
            ITicketRepository ticketRepository)
        {
            _customerRepository = customerRepository;
            _contractRepository = contractRepository;
            _ticketRepository = ticketRepository;
        }

        public DashboardDto GetDashboardData()
        {
            var customers = _customerRepository.GetAll();

            var contracts = _contractRepository.GetAll();

            var openTickets = _ticketRepository.GetOpen();


            return new DashboardDto()
            {
                ActiveCustomersCount =
                    customers.Count,

                ExpiringContractsCount =
                    contracts.Count(x =>
                        x.DateTo <= DateTime.Now.AddDays(30) &&
                        x.DateTo >= DateTime.Now),

                LowPriorityOpenTicketsCount =
                    openTickets.Count(x =>
                        x.Priority == TicketPriority.Low),

                MediumPriorityOpenTicketsCount =
                    openTickets.Count(x =>
                        x.Priority == TicketPriority.Normal),

                HighPriorityOpenTicketsCount =
                    openTickets.Count(x =>
                        x.Priority == TicketPriority.High)
            };
        }
    }
}
