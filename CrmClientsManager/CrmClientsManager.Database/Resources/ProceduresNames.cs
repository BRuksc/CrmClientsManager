using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Text;

namespace CrmClientsManager.Database.Resources
{
    public static class ProceduresNames
    {
        public const string CustomerGetAll = "Customer_GetAll";
        public const string CustomerGetById = "Customer_GetById";
        public const string CustomerInsert = "Customer_Insert";
        public const string CustomerUpdate = "Customer_Update";
        public const string CustomerDelete = "Customer_Delete";
        public const string ContractInsert = "Contract_Insert";
        public const string ContractUpdate = "Contract_Update";
        public const string ContractGetByCustomerId = "Contract_GetByCustomerId";
        public const string TicketInsert = "Ticket_Insert";
        public const string TicketUpdate = "Ticket_Update";
        public const string TicketCreate = "Ticket_Create";
        public const string TicketClose = "Ticket_Close";
        public const string TicketGetOpen = "Ticket_GetOpen";
        public const string TicketGetByCustomerId = "Ticket_GetByCustomerId";
    }
}
