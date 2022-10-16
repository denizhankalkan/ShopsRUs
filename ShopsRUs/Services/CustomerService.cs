using System;
using System.Threading.Tasks;
using ShopsRUs.Models;
using ShopsRUs.Repository;

namespace ShopsRUs.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<Customer> GetCustomerById(long customerId)
        {
            return _repository.GetCustomerById(customerId) 
                   ?? throw new NullReferenceException($"Dont have customer by id {customerId}");
        }
    }
}