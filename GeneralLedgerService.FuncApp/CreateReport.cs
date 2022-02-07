using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace GeneralLedgerService.FuncApp
{
    public static class CreateReport
    {
        [Function("CreateReport")]
        public static void Run([ServiceBusTrigger("ordercreated", "generalledger", Connection = "OrderServiceBus")] string mySbMsg, FunctionContext context)
        {
            var logger = context.GetLogger("Function1");
            logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
