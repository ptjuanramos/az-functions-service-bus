using Microsoft.Extensions.DependencyInjection;
using PurchaseApp.API.Services.Order.Concrete;

namespace PurchaseApp.API.Services.Order
{
    public static class OrderServiceCollectionExtensions
    {
        public static void AddOrderService(this IServiceCollection services)
        {
            services.AddScoped<IOrderPublisher, OrderPublisher>();
        }
    }
}
