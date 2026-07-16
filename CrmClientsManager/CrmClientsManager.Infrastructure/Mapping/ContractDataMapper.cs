using CrmClientsManager.Domain.Entities;
using CrmClientsManager.Domain.Enums;
using CrmClientsManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Net.NetworkInformation;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CrmClientsManager.Infrastructure.Mapping
{
    public class ContractDataMapper : IDataMap<CrmClientsManager.Domain.Entities.Contract>
    {
        public IList<Domain.Entities.Contract> Map(SqlDataReader reader)
        {
            IList<Domain.Entities.Contract> contracts = new List<Domain.Entities.Contract>();

            while (reader.Read())
            {
                contracts.Add(
                    new Domain.Entities.Contract()
                    {
                        ContractId = reader.GetInt32(reader.GetOrdinal(nameof(Domain.Entities.Contract.ContractId))),
                        CustomerId = reader.GetInt32(reader.GetOrdinal(nameof(Domain.Entities.Contract.CustomerId))),
                        ContractNumber = reader.GetString(reader.GetOrdinal(nameof(Domain.Entities.Contract.ContractNumber))),
                        DateFrom = reader.GetDateTime(reader.GetOrdinal(nameof(Domain.Entities.Contract.DateFrom))),
                        DateTo = reader.GetDateTime(reader.GetOrdinal(nameof(Domain.Entities.Contract.DateTo))),
                        AnnualValue = reader.GetDecimal(reader.GetOrdinal(nameof(Domain.Entities.Contract.AnnualValue))),
                        EnergyType = Enum.Parse<EnergyType>(
                        reader.GetString(reader.GetOrdinal("EnergyType"))),
                        Status = Enum.Parse<ContractStatus>(
                        reader.GetString(reader.GetOrdinal("Status")))
                    });
            }

            return contracts;
        }

    }
}
