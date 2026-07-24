using CrmClientsManager.Database.Resources;
using CrmClientsManager.Domain.Entities;
using CrmClientsManager.Infrastructure.Interfaces;
using CrmClientsManager.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmClientsManager.Infrastructure.Repositories
{
    public class ContractRepository : BaseRepository<Contract>, ICustomerFK<Contract>
    {
        protected override IDataMap<Contract> Mapper { get; set; }
        protected override IDbConnectionFactory ConnectionFactory { get; set; }

        public ContractRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
            Mapper = new ContractDataMapper();
        }

        public int Add(Contract contract)
        {
            using var command = CreateCommand(ConnectionFactory.CreateConnection(), 
                ProceduresNames.ContractInsert);

            command.Parameters.AddWithValue(
                "@CustomerId",
                contract.ContractId);

            command.Parameters.AddWithValue(
                "@DateFrom",
                contract.DateFrom);

            command.Parameters.AddWithValue(
                "@DateTo",
                contract.DateTo);

            command.Parameters.AddWithValue(
                "@EnergyType",
                contract.EnergyType);

            command.Parameters.AddWithValue(
                "@AnnualValue",
                contract.AnnualValue);

            command.Parameters.AddWithValue(
                "@Status",
                contract.Status);

            return ExecuteScalar(command);
        }

        public void Update(Contract contract)
        {
            using var command =
                CreateCommand(ConnectionFactory.CreateConnection(), ProceduresNames.ContractUpdate);

            command.Parameters.AddWithValue(
                "@CustomerId",
                contract.ContractId);

            command.Parameters.AddWithValue(
                "@DateFrom",
                contract.DateFrom);

            command.Parameters.AddWithValue(
                "@DateTo",
                contract.DateTo);

            command.Parameters.AddWithValue(
                "@EnergyType",
                contract.EnergyType);

            command.Parameters.AddWithValue(
                "@AnnualValue",
                contract.AnnualValue);

            command.Parameters.AddWithValue(
                "@Status",
                contract.Status);


            ExecuteNonQuery(command);
        }

        public IList<Contract> GetByCustomerId(int customerId)
        {
            using var command = CreateCommand(ConnectionFactory.CreateConnection(),
                ProceduresNames.ContractGetByCustomerId);

            command.Parameters.AddWithValue(
                "@CustomerId",
                customerId);

            return ExecuteReader(command);
        }
    }
}
