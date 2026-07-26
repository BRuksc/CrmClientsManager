using CrmClientsManager.Application.Services;
using CrmClientsManager.Domain.Entities;
using CrmClientsManager.Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CrmClientsManager.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public void Add_ShouldThrow_WhenNameIsEmpty()
        {
            var repository =
                new Mock<CustomerRepository>();

            var service =
                new CustomerService(repository.Object);


            var customer = new Customer
            {
                Name = "",
                Nip = "1234567890",
                Email = "test@test.com"
            };


            Assert.Throws<Exception>(() =>
                service.Create(customer));
        }

        [Fact]
        public void Add_ShouldThrow_WhenNipIsInvalid()
        {
            var repository =
                new Mock<CustomerRepository>();

            var service =
                new CustomerService(repository.Object);


            var customer = new Customer
            {
                Name = "Test",
                Nip = "123",
                Email = "test@test.com"
            };


            Assert.Throws<Exception>(() =>
                service.Create(customer));
        }
    }
}
