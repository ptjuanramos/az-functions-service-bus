using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PurchaseApp.API.Dtos;
using PurchaseApp.API.Services.Order;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ConcurrentDictionary<Guid, OrderDto> _orders = new();

        private readonly ILogger<OrderController> _logger;
        private readonly IOrderPublisher _orderPublisher;

        public OrderController(ILogger<OrderController> logger, IOrderPublisher orderPublisher)
        {
            _logger = logger;
            _orderPublisher = orderPublisher;
        }

        [HttpGet("{id}")]
        public OrderDto GetById(Guid id)
        {
            if(_orders.TryGetValue(id, out OrderDto order))
            {
                return order;
            }

            return null;
        }

        [HttpPost]
        public async Task<OperationResult<OrderDto>> CreateOrder(OrderDto order)
        {
            if(_orders.TryAdd(order.Id, order))
            {
                OperationResult publishOperation = await _orderPublisher.CreateOrder(order);
                return new OperationResult<OrderDto>(publishOperation.WasSuccess, order, publishOperation.ErrorMessage);
            }

            return new OperationResult<OrderDto>(false, null, "already exists");
        }

        [HttpGet]
        public IEnumerable<OrderDto> Get() => _orders.Values;
    }
}
