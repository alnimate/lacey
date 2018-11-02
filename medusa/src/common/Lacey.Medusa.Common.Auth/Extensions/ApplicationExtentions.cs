using Microsoft.AspNetCore.Builder;

namespace Lacey.Medusa.Common.Auth.Extensions
{
    public static class ApplicationExtentions
    {
        public static IApplicationBuilder UseAuth(
            this IApplicationBuilder app)
        {
            app.UseAuthentication();

            return app;
        }
    }
}