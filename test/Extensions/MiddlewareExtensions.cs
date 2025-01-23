﻿using test.Middleware;

namespace test.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseJwt(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtMiddleware>();
        }
    }
}
