namespace PurchaseApp.API
{
    public record OperationResult<T>(bool WasSuccess, T Data, string ErrorMessage);

    public record OperationResult(bool WasSuccess, string ErrorMessage);
}