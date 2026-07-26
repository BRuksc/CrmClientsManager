using CrmClientsManager.Database.Resources;
using CrmClientsManager.Domain.Entities;
using CrmClientsManager.Infrastructure.Interfaces;
using CrmClientsManager.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CrmClientsManager.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, IRepository<Customer>
    {
        protected override IDataMap<Customer> Mapper { get; set; }
        protected override IDbConnectionFactory ConnectionFactory { get; set; }

        public CustomerRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
            Mapper = new CustomerDataMapper();
        }

        public int Add(Customer customer)
        {
            using var command =
                CreateCommand(ConnectionFactory.CreateConnection(), ProceduresNames.CustomerInsert);

            command.Parameters.AddWithValue(
                "@Name",
                customer.Name);

            command.Parameters.AddWithValue(
                "@Nip",
                customer.Nip);

            command.Parameters.AddWithValue(
                "@Address",
                customer.Address);

            command.Parameters.AddWithValue(
                "@Email",
                customer.Email);

            command.Parameters.AddWithValue(
                "@Phone",
                customer.Phone);

            command.Parameters.AddWithValue(
                "@CustomerType",
                customer.Type.ToString());


            return ExecuteScalar(command);
        }


        public void Update(Customer customer)
        {
            using var command =
                CreateCommand(ConnectionFactory.CreateConnection(), ProceduresNames.CustomerUpdate);

            command.Parameters.AddWithValue(
                "@CustomerId",
                customer.CustomerId);

            command.Parameters.AddWithValue(
                "@Name",
                customer.Name);

            command.Parameters.AddWithValue(
                "@Nip",
                customer.Nip);

            command.Parameters.AddWithValue(
                "@Address",
                customer.Address);

            command.Parameters.AddWithValue(
                "@Email",
                customer.Email);

            command.Parameters.AddWithValue(
                "@Phone",
                customer.Phone);

            command.Parameters.AddWithValue("@CustomerType", customer.Type.ToString());

            ExecuteNonQuery(command);
        }
    }
}
