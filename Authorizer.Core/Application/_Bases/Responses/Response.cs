using Authorizer.Core.Application.Interfaces.Responses;

namespace Authorizer.Core.Application.Bases.Responses
{
    public class Response<TRequest, TDTO> : IResponse<TRequest, TDTO>
    {
        public TRequest Request { get; set; }
        public TDTO Data { get; set; }
    }
}
