using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PurchaseApp.API.Dtos;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PurchaseApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ConcurrentDictionary<Guid, OrderDto> _orders = new();

        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
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
        public OperationResult<OrderDto> CreateOrder(OrderDto order)
        {
            if(_orders.TryAdd(order.Id, order))
            {
                return new OperationResult<OrderDto>(true, order, string.Empty);
            }

            return new OperationResult<OrderDto>(false, null, "already exists");
        }

        [HttpGet]
        public IEnumerable<OrderDto> Get() => _orders.Values;
    }
}
