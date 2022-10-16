using System.Threading.Tasks;
using ShopsRUs.Models;

namespace ShopsRUs.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerById(long customerId);
    }
}