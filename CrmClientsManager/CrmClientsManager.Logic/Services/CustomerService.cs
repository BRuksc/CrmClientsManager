using CrmClientsManager.Application.Interfaces;
using CrmClientsManager.Domain.Entities;
using CrmClientsManager.Infrastructure.Interfaces;
using CrmClientsManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrmClientsManager.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService(
            CustomerRepository repository)
        {
            _repository = repository;
        }


        public IList<Customer> GetCustomers()
        {
            return _repository.GetAll();
        }


        public int Create(Customer customer)
        {
            Validate(customer);

            return _repository.Add(customer);
        }


        private void Validate(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Nip))
            {
                throw new ValidationException(
                    "NIP is required");
            }
        }
    }
}
