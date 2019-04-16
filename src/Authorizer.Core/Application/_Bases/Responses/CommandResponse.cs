using Authorizer.Core.Application.Interfaces.Responses;

namespace Authorizer.Core.Application.Bases.Responses
{
    public class CommandResponse<TRequest, TDTO> : Response<TRequest, TDTO>, ICommandResponse<TRequest, TDTO>
    {
        public string Message { get; set; }
    }
}
