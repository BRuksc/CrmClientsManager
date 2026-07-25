using CrmClientsManager.Application.Interfaces;
using CrmClientsManager.Domain.Entities;
using CrmClientsManager.Domain.Enums;
using CrmClientsManager.Infrastructure.Interfaces;
using CrmClientsManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrmClientsManager.Application.Servicess
{
    public  class ContractService : IContractService
    {
        private readonly ContractRepository _repository;

        public ContractService(ContractRepository repository)
        {
            _repository = repository;
        }

        public IList<Contract> GetAll()
            => _repository.GetAll();

        public Contract? GetById(int id)
            => _repository.GetById(id);

        public IList<Contract> GetByCustomerId(int customerId)
            => _repository.GetByCustomerId(customerId);

        public int Create(Contract contract)
        {
            ValidateContract(contract);

            return _repository.Add(contract);
        }

        public void Update(Contract contract)
        {
            ValidateContract(contract);

            _repository.Update(contract);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        private void ValidateContract(Contract contract)
        {
            var customerContracts =
                _repository.GetByCustomerId(contract.CustomerId);

            bool overlapExists =
                customerContracts.Any(x =>
                    x.ContractId != contract.ContractId &&
                    x.Status == ContractStatus.Active &&
                    contract.Status == ContractStatus.Active &&
                    x.EnergyType == contract.EnergyType &&
                    x.DateTo <= contract.DateTo &&
                    x.DateFrom >= contract.DateFrom);

            if (overlapExists)
            {
                throw new ValidationException(
                    "Customer already has an active overlapping contract of this energy type.");
            }
        }
    }
}
