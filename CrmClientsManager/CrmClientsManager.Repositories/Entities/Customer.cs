using CrmClientsManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace CrmClientsManager.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Nip { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public CustomerType Type { get; set; }

        public IList<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
