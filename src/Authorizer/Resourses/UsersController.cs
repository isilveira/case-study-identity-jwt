using Authorizer.Core.Application.Users.Commands.Authenticate;
using Authorizer.Resourses.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Authorizer.Resourses
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ResourceControllerBase
    {
        public UsersController()
        {
        }

        [Authorize(Roles = "AccessToken")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(new string[] { "A", "B" });
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticateCommandResponse>> Authenticate(AuthenticateCommand command)
        {
            return await Send(command);
        }

        [Authorize(Roles = "IdentityToken")]
        [HttpPost("accesstoken")]
        public ActionResult<string> AccessToken()
        {
            throw new NotImplementedException();
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(this._appSettingsHelper.Secret);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Role,"AccessToken"),
        //            new Claim(ClaimTypes.PrimarySid,"1"),
        //            new Claim(ClaimTypes.Name,"Ítalo"),
        //            new Claim(ClaimTypes.Surname,"Silveira"),
        //            new Claim(ClaimTypes.Email,"italo.silveira@baysoft.com.br")
        //        }),
        //        Expires = DateTime.UtcNow.AddMinutes(5),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return Ok(tokenHandler.WriteToken(token));
        }
    }
}