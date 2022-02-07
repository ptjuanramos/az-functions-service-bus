using PurchaseApp.API.Dtos;
using System.Threading.Tasks;

namespace PurchaseApp.API.Services.Order
{
    public interface IOrderPublisher
    {
        Task<OperationResult> CreateOrder(OrderDto order);
    }
}