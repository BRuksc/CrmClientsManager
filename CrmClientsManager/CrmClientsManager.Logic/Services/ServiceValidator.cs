using CrmClientsManager.Application.Interfaces;
using CrmClientsManager.Domain.Entities;
using CrmClientsManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.Services
{
    public class ServiceValidator : IServiceValidation
    {
        public void ValidateCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name))
                throw new Exception("Customer name is required.");

            if (string.IsNullOrWhiteSpace(customer.Nip))
                throw new Exception("NIP is required.");

            if (customer.Nip.Length != 10)
                throw new Exception("NIP must contain 10 digits.");

            if (!customer.Nip.All(char.IsDigit))
                throw new Exception("NIP must contain only digits.");

            if (string.IsNullOrWhiteSpace(customer.Email))
                throw new Exception("Email is required.");
        }

        public void ValidateTicket(Ticket ticket)
        {
            if (ticket.CustomerId <= 0)
                throw new Exception("Customer is required.");

            if (string.IsNullOrWhiteSpace(ticket.Subject))
                throw new Exception("Subject is required.");

            if (string.IsNullOrWhiteSpace(ticket.Description))
                throw new Exception("Description is required.");
        }
    }
}
