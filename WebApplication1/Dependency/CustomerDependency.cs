using WebApplication1.Interfaces;
using WebApplication1.Services;

namespace WebApplication1.Dependency
{
    public static class CustomerDependency
    {
        public static IServiceCollection AddCustomerService(
            this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}