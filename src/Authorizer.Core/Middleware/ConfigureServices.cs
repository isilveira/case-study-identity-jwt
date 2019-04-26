using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authorizer.Core.Middleware
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCoreMiddleware(this IServiceCollection services)
        {
            return services;
        }
    }
}
