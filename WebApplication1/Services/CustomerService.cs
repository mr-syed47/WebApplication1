using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IConfiguration _configuration;

        public CustomerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = "SELECT * FROM dbo.Customer";

            return await connection.QueryAsync<Customer>(query);
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = "SELECT * FROM Customers WHERE CustomerId = @CustomerId";

            return await connection.QueryFirstOrDefaultAsync<Customer>(
                query,
                new { CustomerId = id });
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = @"
                INSERT INTO Customers
                (CustomerName, Phone, Email, Address)
                VALUES
                (@CustomerName, @Phone, @Email, @Address)";

            return await connection.ExecuteAsync(query, customer);
        }

        public async Task<int> UpdateCustomer(Customer customer)
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = @"
                UPDATE Customers
                SET CustomerName = @CustomerName,
                    Phone = @Phone,
                    Email = @Email,
                    Address = @Address
                WHERE CustomerId = @CustomerId";

            return await connection.ExecuteAsync(query, customer);
        }

        public async Task<int> DeleteCustomer(int id)
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = "DELETE FROM Customers WHERE CustomerId = @CustomerId";

            return await connection.ExecuteAsync(
                query,
                new { CustomerId = id });
        }
    }
}