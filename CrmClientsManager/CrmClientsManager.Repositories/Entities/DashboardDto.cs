using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Domain.Entities
{
    public class DashboardDto
    {
        public int ActiveCustomersCount { get; set; }

        public int ExpiringContractsCount { get; set; }

        public int LowPriorityOpenTicketsCount { get; set; }

        public int MediumPriorityOpenTicketsCount { get; set; }

        public int HighPriorityOpenTicketsCount { get; set; }
    }
}
