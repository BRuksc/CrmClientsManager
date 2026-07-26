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
        private readonly IServiceValidation _serviceValidator;

        public CustomerService(
            CustomerRepository repository)
        {
            _repository = repository;
            _serviceValidator = new ServiceValidator();
        }


        public IList<Customer> GetCustomers()
        {
            return _repository.GetAll();
        }


        public int Create(Customer customer)
        {
            _serviceValidator.ValidateCustomer(customer);

            return _repository.Add(customer);
        }

        public void Delete(int id) => _repository.Delete(id);

        public void Update(Customer customer)
        {
            _serviceValidator.ValidateCustomer(customer);
            _repository.Update(customer);
        }
    }
}
