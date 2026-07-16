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
    public class CustomerDataMapper : IDataMap<Customer>
    {
        public IList<Customer> Map(SqlDataReader reader)
        {
            IList<Customer> customers = new List<Customer>();

            while (reader.Read())
            {
                    customers.Add(
                        new Customer()
                        {
                            CustomerId = reader.GetInt32(reader.GetOrdinal(nameof(Customer.CustomerId))),
                            Name = reader.GetString(reader.GetOrdinal(nameof(Customer.Name))),
                            Nip = reader.GetString(reader.GetOrdinal(nameof(Customer.Nip))),
                            Address = reader.GetString(reader.GetOrdinal(nameof(Customer.Address))) ?? String.Empty,
                            Email = reader.GetString(reader.GetOrdinal(nameof(Customer.Email))) ?? String.Empty,
                            Phone = reader.GetString(reader.GetOrdinal(nameof(Customer.Phone))) ?? String.Empty,
                            Type = Enum.Parse<CustomerType>(
                            reader.GetString(reader.GetOrdinal("CustomerType")))
                        });
            }

            return customers;
        }
    }
}
