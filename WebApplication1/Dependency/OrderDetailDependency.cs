using WebApplication1.Interfaces;
using WebApplication1.Services;

namespace WebApplication1.Dependency
{
    public static class OrderDetailDependency
    {
        public static IServiceCollection AddOrderDetailService(
            this IServiceCollection services)
        {
            services.AddScoped<IOrderDetailService, OrderDetailService>();

            return services;
        }
    }
}