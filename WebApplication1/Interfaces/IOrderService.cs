using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task<int> AddOrder(Order order);
        Task<int> UpdateOrder(Order order);
        Task<int> DeleteOrder(int id);
    }
}