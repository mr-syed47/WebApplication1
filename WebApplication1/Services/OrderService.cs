using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class OrderService : IOrderService
    {
        private readonly IConfiguration _configuration;

        public OrderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = "SELECT * FROM Orders";

            return await connection.QueryAsync<Order>(query);
        }

        public async Task<Order> GetOrderById(int id)
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = "SELECT * FROM Orders WHERE OrderId = @OrderId";

            return await connection.QueryFirstOrDefaultAsync<Order>(
                query,
                new { OrderId = id });
        }

        public async Task<int> AddOrder(Order order)
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = @"
                INSERT INTO Orders
                (CustomerId, OrderDate, TotalAmount, OrderStatus)
                VALUES
                (@CustomerId, @OrderDate, @TotalAmount, @OrderStatus)";

            return await connection.ExecuteAsync(query, order);
        }

        public async Task<int> UpdateOrder(Order order)
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = @"
                UPDATE Orders
                SET CustomerId = @CustomerId,
                    OrderDate = @OrderDate,
                    TotalAmount = @TotalAmount,
                    OrderStatus = @OrderStatus
                WHERE OrderId = @OrderId";

            return await connection.ExecuteAsync(query, order);
        }

        public async Task<int> DeleteOrder(int id)
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = "DELETE FROM Orders WHERE OrderId = @OrderId";

            return await connection.ExecuteAsync(
                query,
                new { OrderId = id });
        }
    }
}