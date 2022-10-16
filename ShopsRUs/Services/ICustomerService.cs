using System.Threading.Tasks;
using ShopsRUs.Models;

namespace ShopsRUs.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerById(long customerId);
    }
}