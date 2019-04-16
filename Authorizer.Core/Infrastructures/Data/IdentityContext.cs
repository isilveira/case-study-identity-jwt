using Authorizer.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authorizer.Core.Infrastructures.Data
{
    public class IdentityContext : IdentityDbContext<User>
    {
    }
}
