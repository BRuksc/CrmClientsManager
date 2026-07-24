using CrmClientsManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Infrastructure.Interfaces
{
    public interface ITicketRepository
    {
        IList<Ticket> GetOpen();

        IList<Ticket> GetByCustomerId(int customerId);

        Ticket? GetById(int id);

        int Create(Ticket ticket);

        void Close(
            int ticketId,
            DateTime closeDate,
            string resolutionComment);
    }
}
