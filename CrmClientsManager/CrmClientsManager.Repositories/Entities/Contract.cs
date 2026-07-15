using CrmClientsManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Domain.Entities
{
    public class Contract
    {
        public int ContractId { get; set; }

        public int CustomerId { get; set; }

        public string ContractNumber { get; set; } = string.Empty;

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public EnergyType EnergyType { get; set; }

        public decimal AnnualValue { get; set; }

        public ContractStatus Status { get; set; }
    }
}
