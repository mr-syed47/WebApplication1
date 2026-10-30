using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetails();
        Task<OrderDetail> GetOrderDetailById(int id);
        Task<int> AddOrderDetail(OrderDetail orderDetail);
        Task<int> UpdateOrderDetail(OrderDetail orderDetail);
        Task<int> DeleteOrderDetail(int id);
    }
}   