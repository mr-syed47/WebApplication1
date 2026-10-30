using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IConfiguration _configuration;

        public OrderDetailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetails()
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = "SELECT * FROM OrderDetails";

            return await connection.QueryAsync<OrderDetail>(query);
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = "SELECT * FROM OrderDetails WHERE OrderDetailId = @OrderDetailId";

            return await connection.QueryFirstOrDefaultAsync<OrderDetail>(
                query,
                new { OrderDetailId = id });
        }

        public async Task<int> AddOrderDetail(OrderDetail orderDetail)
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = @"
                INSERT INTO OrderDetails
                (OrderId, ItemName, Quantity, UnitPrice, TotalPrice)
                VALUES
                (@OrderId, @ItemName, @Quantity, @UnitPrice, @TotalPrice)";

            return await connection.ExecuteAsync(query, orderDetail);
        }

        public async Task<int> UpdateOrderDetail(OrderDetail orderDetail)
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = @"
                UPDATE OrderDetails
                SET OrderId = @OrderId,
                    ItemName = @ItemName,
                    Quantity = @Quantity,
                    UnitPrice = @UnitPrice,
                    TotalPrice = @TotalPrice
                WHERE OrderDetailId = @OrderDetailId";

            return await connection.ExecuteAsync(query, orderDetail);
        }

        public async Task<int> DeleteOrderDetail(int id)
        {
            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));

            string query = "DELETE FROM OrderDetails WHERE OrderDetailId = @OrderDetailId";

            return await connection.ExecuteAsync(
                query,
                new { OrderDetailId = id });
        }
    }
}