using Authorizer.Core.Domain.Entities;
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
        public AuthenticateCommandHandler(
            //SignInManager<User> signInManager,
            IOptions<AppSettingsHelper> options
        )
        {
            //SignInManager = signInManager;
            Options = options;
        }
        public async Task<AuthenticateCommandResponse> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Credential) || request.Credential != "isilveira" || string.IsNullOrWhiteSpace(request.Password) || request.Password != "is2019")
            {
                throw new Exception("Credenciais inválidas!");
            }

            /*
            var signInResponse = await SignInManager.PasswordSignInAsync(request.Credential, request.Password, true, true);

            if(!signInResponse.Succeeded){
                throw new Exception("Credentials and/or password invalids!");
            }
            */

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

            request.ClearPassword();

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
