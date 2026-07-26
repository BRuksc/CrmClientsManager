using CrmClientsManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.Interfaces
{
    public interface IServiceValidation
    {
        public void ValidateCustomer(Customer customer);
        public void ValidateTicket(Ticket ticket);
    }
}
