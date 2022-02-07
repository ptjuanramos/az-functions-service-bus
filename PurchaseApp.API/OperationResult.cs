namespace PurchaseApp.API
{
    public record OperationResult<T>(bool WasSuccess, T Data, string ErrorMessage);
}