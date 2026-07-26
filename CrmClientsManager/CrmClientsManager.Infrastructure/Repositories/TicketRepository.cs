using CrmClientsManager.Database.Resources;
using CrmClientsManager.Domain.Entities;
using CrmClientsManager.Infrastructure.Interfaces;
using CrmClientsManager.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Infrastructure.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        protected override IDataMap<Ticket> Mapper { get; set; }
        protected override IDbConnectionFactory ConnectionFactory { get; set; }

        public TicketRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
            Mapper = new TicketDataMapper();
        }

        public IList<Ticket> GetByCustomerId(int customerId)
        {
            using var command = CreateCommand(ConnectionFactory.CreateConnection(),
                ProceduresNames.TicketGetByCustomerId);

            command.Parameters.AddWithValue(
                "@CustomerId",
                customerId);


            return ExecuteReader(command);
        }

        public IList<Ticket> GetOpen()
        {
            using var command = CreateCommand(ConnectionFactory.CreateConnection(),
                ProceduresNames.TicketGetOpen);

            return ExecuteReader(command);
        }

        public Ticket? GetById(int id)
        {
            using var command = CreateCommand(ConnectionFactory.CreateConnection(),
                ProceduresNames.CustomerGetById);

            command.Parameters.AddWithValue(
                "@TicketId",
                id);


            return ExecuteReader(command)
                .FirstOrDefault();
        }

        public int Create(Ticket ticket)
        {
            using var command = CreateCommand(ConnectionFactory.CreateConnection(),
                ProceduresNames.TicketCreate);

            command.Parameters.AddWithValue(
                "@CustomerId",
                ticket.CustomerId);

            command.Parameters.AddWithValue(
                "@ContractId",
                (object?)ticket.ContractId ?? DBNull.Value);

            command.Parameters.AddWithValue(
                "@Subject",
                ticket.Subject);

            command.Parameters.AddWithValue(
                "@Description",
                ticket.Description);

            command.Parameters.AddWithValue(
                "@Priority",
                ticket.Priority.ToString());

            return ExecuteScalar(command);
        }

        public void Close(int ticketId, DateTime closedDate, string resolutionComment)
        {
            using var command = CreateCommand(ConnectionFactory.CreateConnection(), 
                ProceduresNames.TicketClose);

            command.Parameters.AddWithValue(
                "@TicketId",
                ticketId);

            command.Parameters.AddWithValue(
                "@ClosedDate",
                closedDate);

            command.Parameters.AddWithValue(
                "@ResolutionComment",
                resolutionComment);


            ExecuteNonQuery(command);
        }
    }
}
