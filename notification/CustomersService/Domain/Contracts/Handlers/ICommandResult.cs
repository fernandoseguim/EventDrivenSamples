namespace CustomersService.Domain.Contracts.Handlers
{
    public interface ICommandResult
    {
        StatusCode StatusCode { get; }
        bool Success { get; }
        string Message { get; }
        object Data { get; }
    }
}