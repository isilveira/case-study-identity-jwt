using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authorizer.Core.Domain.Entities
{
    public class User : IdentityUser<long>
    {
        public User()
        {
        }
    }
}
