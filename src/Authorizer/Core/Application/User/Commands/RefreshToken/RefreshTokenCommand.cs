using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorizer.Core.Application.User.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string UserToken { get; set; }
    }
}
