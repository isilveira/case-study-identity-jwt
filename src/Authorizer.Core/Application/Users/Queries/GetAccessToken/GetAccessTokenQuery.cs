using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authorizer.Core.Application.Users.Queries.GetAccessToken
{
    public class GetAccessTokenQuery : IRequest<GetAccessTokenQueryResponse>
    {
    }
}
