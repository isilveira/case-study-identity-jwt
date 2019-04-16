using Authorizer.Core.Application.Interfaces.Responses;

namespace Authorizer.Core.Application.Bases.Responses
{
    public class QueryResponse<TRequest, TDTO> : Response<TRequest, TDTO>, IQueryResponse<TRequest, TDTO>
    {
        public int ResultCount { get; set; }
    }
}
