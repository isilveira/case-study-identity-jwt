using Authorizer.CrossCutting.Helpers;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authorizer.Core.Application.Users.Commands.Authenticate
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticateCommandResponse>
    {
        private IOptions<AppSettingsHelper> Options { get; set; }
        public AuthenticateCommandHandler(IOptions<AppSettingsHelper> options)
        {
            Options = options;
        }
        public async Task<AuthenticateCommandResponse> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Credential) || request.Credential != "isilveira" || string.IsNullOrWhiteSpace(request.Password) || request.Password != "is2019")
            {
                throw new Exception("Credenciais inválidas!");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Options.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role,"IdentityToken"),
                    new Claim(ClaimTypes.PrimarySid,"1"),
                    new Claim(ClaimTypes.Name,"Ítalo"),
                    new Claim(ClaimTypes.Surname,"Silveira"),
                    new Claim(ClaimTypes.Email,"italo.silveira@baysoft.com.br")
                }),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticateCommandResponse
            {
                Request = request,
                Message = "Operação realizada com sucesso!",
                Data = new AuthenticateCommandResponseDTO
                {
                    IdentityToken = tokenHandler.WriteToken(token)
                }
            };
        }
    }
}
