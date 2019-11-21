using Authorizer.Core.Domain.Entities;
using Authorizer.Core.Domain.Services;
using Authorizer.Core.Infrastructures.Data;
using Authorizer.CrossCutting.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authorizer.Core.Application.Users.Commands.Authenticate
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticateCommandResponse>
    {
        //private SignInManager<User> SignInManager{ get; set; }
        
        private IOptions<AppSettingsHelper> Options { get; set; }
        private TokenService TokenService { get; set; }
        public AuthenticateCommandHandler(
            //SignInManager<User> signInManager,
            IOptions<AppSettingsHelper> options
        )
        {
            //SignInManager = signInManager;
            Options = options;
            TokenService = new TokenService();
        }
        public async Task<AuthenticateCommandResponse> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Credential)
                || request.Credential != "isilveira"
                || string.IsNullOrWhiteSpace(request.Password)
                || request.Password != "is2019")
            {
                throw new Exception("Credenciais inválidas!");
            }

            var user = new User
            {
                Id = "1",
                UserName = "Ítalo",
                Email = "italo.silveira@baysoft.com.br"
            };

            var identityToken = TokenService.GenerateIdentityTokenForUser(user, Options.Value.Secret);
            
            return new AuthenticateCommandResponse
            {
                Request = request,
                Message = "Operação realizada com sucesso!",
                Data = new AuthenticateCommandResponseDTO
                {
                    IdentityToken = identityToken
                }
            };
        }
    }
}
