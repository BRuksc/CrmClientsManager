using CrmClientsManager.Application.Interfaces;
using CrmClientsManager.Domain.Entities;
using CrmClientsManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrmClientsManager.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;

        public TicketService(ITicketRepository repository)
        {
            _repository = repository;
        }

        public IList<Ticket> GetOpen()
            => _repository.GetOpen();

        public int Create(Ticket ticket)
        {
            if (string.IsNullOrWhiteSpace(ticket.Subject))
                throw new ValidationException("Subject is required.");

            if (string.IsNullOrWhiteSpace(ticket.Description))
                throw new ValidationException("Description is required.");

            return _repository.Create(ticket);
        }

        public void Close(
            int ticketId,
            DateTime closeDate,
            string resolutionComment)
        {
            if (string.IsNullOrWhiteSpace(resolutionComment))
            {
                throw new ValidationException(
                    "Resolution comment is required.");
            }

            if (closeDate == default)
            {
                throw new ValidationException(
                    "Close date is required.");
            }

            _repository.Close(
                ticketId,
                closeDate,
                resolutionComment);
        }
    }
}
