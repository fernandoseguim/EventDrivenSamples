using CustomersService.Domain.Contracts.Handlers;

namespace CustomersService.Domain.Commands.Responses
{
    public struct SuccessfulCommandResult : ICommandResult
    {
        public SuccessfulCommandResult(string message, object data)
        {
            Message = message;
            Data = data;
            StatusCode = StatusCode.Success;
            Success = true;
        }

        public StatusCode StatusCode { get; }
        public bool Success { get; }
        public string Message { get; }
        public object Data { get; }
    }
}
