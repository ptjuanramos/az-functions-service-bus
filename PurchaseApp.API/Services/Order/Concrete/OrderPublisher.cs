using Azure.Messaging.ServiceBus;
using PurchaseApp.API.Dtos;
using System;
using System.Threading.Tasks;

namespace PurchaseApp.API.Services.Order.Concrete
{
    internal class OrderPublisher : IOrderPublisher
    {
        private readonly ServiceBusSender _serviceBusSender;

        public OrderPublisher(ServiceBusSender serviceBusSender)
        {
            _serviceBusSender = serviceBusSender;
        }

        public async Task<OperationResult> CreateOrder(OrderDto order)
        {
            try
            {
                MessageSerializer<OrderDto> orderSerializer = new(order);
                await _serviceBusSender.SendMessageAsync(new ServiceBusMessage(orderSerializer.Serialize()));
                return new(true, string.Empty);
            
            } catch(Exception ex)
            {
                return new(false, ex.Message);
            }
        }
    }
}
