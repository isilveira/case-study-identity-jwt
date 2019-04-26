using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authorizer.Core.Middleware
{
    public static class Configure
    {
        public static IApplicationBuilder UseCoreMiddleware(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
