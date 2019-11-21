using Authorizer.Core.Domain.Entities;
using Authorizer.Core.Domain.Services;
using Authorizer.CrossCutting.Helpers;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authorizer.Core.Application.Users.Queries.GetAccessToken
{
    public class GetAccessTokenQueryHandler : IRequestHandler<GetAccessTokenQuery, GetAccessTokenQueryResponse>
    {
        //private SignInManager<User> SignInManager{ get; set; }

        private IOptions<AppSettingsHelper> Options { get; set; }
        private TokenService TokenService { get; set; }
        public GetAccessTokenQueryHandler(
            IOptions<AppSettingsHelper> options
        )
        {
            Options = options;
            TokenService = new TokenService();
        }
        public async Task<GetAccessTokenQueryResponse> Handle(GetAccessTokenQuery request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = "1",
                UserName = "Ítalo",
                Email = "italo.silveira@baysoft.com.br"
            };

            var accessToken = TokenService.GenerateAccessTokenForUser(user, Options.Value.Secret);

            return new GetAccessTokenQueryResponse
            {
                Request = request,
                Message = "Operação realizada com sucesso!",
                Data = new GetAccessTokenQueryResponseDTO
                {
                    AccessToken = accessToken
                }
            };
        }
    }
}
