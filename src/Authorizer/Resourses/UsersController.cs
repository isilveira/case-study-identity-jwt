using Authorizer.Core.Application.Users.Commands.Authenticate;
using Authorizer.Core.Application.Users.Queries.GetAccessToken;
using Authorizer.Resourses.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
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
        public async Task<ActionResult<AuthenticateCommandResponse>> Authenticate(AuthenticateCommand request)
        {
            return await Send(request);
        }

        [Authorize(Roles = "IdentityToken")]
        [HttpGet("accesstoken")]
        public async Task<ActionResult<GetAccessTokenQueryResponse>> GetAccessToken(GetAccessTokenQuery request)
        {
            return await Send(request);
        }
    }
}