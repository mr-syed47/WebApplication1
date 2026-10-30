using WebApplication1.Interfaces;
using WebApplication1.Services;

namespace WebApplication1.Dependency
{
    public static class OrderDependency
    {
        public static IServiceCollection AddOrderService(
            this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}