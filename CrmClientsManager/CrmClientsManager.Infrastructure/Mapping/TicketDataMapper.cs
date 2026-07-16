using CrmClientsManager.Domain.Entities;
using CrmClientsManager.Domain.Enums;
using CrmClientsManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CrmClientsManager.Infrastructure.Mapping
{
    public class TicketDataMapper : IDataMap<Ticket>
    {
        public IList<Ticket> Map(SqlDataReader reader)
        {
            IList<Ticket> tickets = new List<Ticket>(); 

            while (reader.Read())
            {
                tickets.Add(
                    new Ticket()
                    {
                        TicketId = reader.GetInt32(reader.GetOrdinal(nameof(Ticket.TicketId))),
                        CustomerId = reader.GetInt32(reader.GetOrdinal(nameof(Ticket.CustomerId))),
                        ContractId = reader.GetInt32(reader.GetOrdinal(nameof(Ticket.ContractId))),
                        Subject = reader.GetString(reader.GetOrdinal(nameof(Ticket.Subject))),
                        Description = reader.GetString(reader.GetOrdinal(nameof(Ticket.Description))),
                        Priority = Enum.Parse<TicketPriority>(
                        reader.GetString(reader.GetOrdinal("Priority"))),
                        Status = Enum.Parse<TicketStatus>(
                        reader.GetString(reader.GetOrdinal("Status"))),
                        CreatedDate = reader.GetDateTime(reader.GetOrdinal(nameof(Ticket.CreatedDate))),
                        ClosedDate = reader.GetDateTime(reader.GetOrdinal(nameof(Ticket.ClosedDate))),
                        ResolutionComment = reader.GetString(reader.GetOrdinal(nameof(Ticket.ResolutionComment)))
                    });
            }

            return tickets;
        }
 
    }
}
