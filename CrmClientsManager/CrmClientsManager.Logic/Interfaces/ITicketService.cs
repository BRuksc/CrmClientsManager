using CrmClientsManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Application.Interfaces
{
    public interface ITicketService
    {
        public IList<Ticket> GetOpen();
        public int Create(Ticket ticket);
        public void Close(int ticketId, DateTime closeDate, string resolutionComment);
    }
}
