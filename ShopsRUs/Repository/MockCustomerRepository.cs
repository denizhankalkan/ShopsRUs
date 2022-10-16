using System;
using System.Threading.Tasks;
using ShopsRUs.Models;
using ShopsRUs.Types;

namespace ShopsRUs.Repository
{
    public class MockCustomerRepository : ICustomerRepository
    {
        public Task<Customer> GetCustomerById(long customerId)
        {
            return Task.FromResult(new Customer(customerId, CustomerType.Client, DateTime.Now));
        }
    }
}