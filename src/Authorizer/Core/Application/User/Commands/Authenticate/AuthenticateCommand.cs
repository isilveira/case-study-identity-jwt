using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorizer.Core.Application.User.Commands.Authenticate
{
    public class AuthenticateCommand
    {
        public string Credential { get; set; }
        public string Password { get; set; }
    }
}
