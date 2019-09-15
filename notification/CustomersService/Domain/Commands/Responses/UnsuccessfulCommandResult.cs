using CustomersService.Domain.Contracts.Handlers;

namespace CustomersService.Domain.Commands.Responses
{
    public struct UnsuccessfulCommandResult : ICommandResult
    {
        public UnsuccessfulCommandResult(StatusCode statusCode, string message, object data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
            Success = false;
        }
        
        public StatusCode StatusCode { get; }
        public bool Success { get; }
        public string Message { get; }
        public object Data { get; }
    }
}
