using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<int> DeleteCustomer(int id);
        Task<int> AddCustomer(Customer customer);
        Task<int> UpdateCustomer(Customer customer);
    }
}