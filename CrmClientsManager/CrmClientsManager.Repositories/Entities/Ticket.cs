using CrmClientsManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Domain.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public int CustomerId { get; set; }

        public int? ContractId { get; set; }

        public string Subject { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public TicketPriority Priority { get; set; }

        public TicketStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        public string? ResolutionComment { get; set; }
    }
}
