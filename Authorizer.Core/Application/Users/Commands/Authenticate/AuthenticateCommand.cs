using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authorizer.Core.Application.Users.Commands.Authenticate
{
    public class AuthenticateCommand : IRequest<AuthenticateCommandResponse>
    {
        public string Credential { get; set; }
        public string Password { get; set; }
    }
}
