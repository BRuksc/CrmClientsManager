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
        private readonly IServiceValidation _serviceValidator;

        public TicketService(ITicketRepository repository)
        {
            _repository = repository;
            _serviceValidator = new ServiceValidator();
        }

        public IList<Ticket> GetOpen()
            => _repository.GetOpen();

        public int Create(Ticket ticket)
        {
            _serviceValidator.ValidateTicket(ticket);

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
