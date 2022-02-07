using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ShippingService.FuncApp
{
    public static class CreateShippingRequest
    {
        [Function("CreateShippingRequest")]
        public static void Run([ServiceBusTrigger("ordercreated", "shipping", Connection = "OrderServiceBus")] string mySbMsg, FunctionContext context)
        {
            var logger = context.GetLogger("Function1");
            logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
