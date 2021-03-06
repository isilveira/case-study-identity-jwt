﻿using Authorizer.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authorizer.Core.Infrastructures.Data
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }

        public IdentityContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected IdentityContext()
        {
            this.Database.EnsureCreated();
        }
    }
}
