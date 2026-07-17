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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public CustomerRepository(IDbConnectionFactory connectionFactory) => 
            _connectionFactory = connectionFactory;

        public int Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            using var connection =
                _connectionFactory.CreateConnection();

            using var command =
                new SqlCommand(
                    ProceduresNames.CustomerGetAll,
                    connection);

            command.CommandType =
                CommandType.StoredProcedure;

            connection.Open();

            using var reader =
                command.ExecuteReader();
            
            IDataMap<Customer> customersMapper = new CustomerDataMapper();

            var customers = customersMapper.Map(reader);

            return customers;
        }

        public Customer? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
