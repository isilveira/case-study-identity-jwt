using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Authorizer.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Authorizer.Resourses
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppSettingsHelper _appSettingsHelper;
        public UsersController(IOptions<AppSettingsHelper> options)
        {
            this._appSettingsHelper = options.Value;
        }

        [Authorize(Roles = "AccessToken")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(new string[] { "A", "B" });
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(string user, string password)
        {
            if(string.IsNullOrWhiteSpace(user) || user != "test" || string.IsNullOrWhiteSpace(password) || password != "123456")
            {
                return BadRequest();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._appSettingsHelper.Secret);
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
            return Ok(tokenHandler.WriteToken(token));
        }

        [Authorize(Roles = "IdentityToken")]
        [HttpPost("accesstoken")]
        public ActionResult<string> AccessToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._appSettingsHelper.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role,"AccessToken"),
                    new Claim(ClaimTypes.PrimarySid,"1"),
                    new Claim(ClaimTypes.Name,"Ítalo"),
                    new Claim(ClaimTypes.Surname,"Silveira"),
                    new Claim(ClaimTypes.Email,"italo.silveira@baysoft.com.br")
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(tokenHandler.WriteToken(token));
        }
    }
}