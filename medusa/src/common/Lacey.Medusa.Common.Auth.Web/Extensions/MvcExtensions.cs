using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Common.Auth.Web.Extensions
{
    public static class MvcExtensions
    {
        public static IMvcBuilder AddAuth(
            this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddMvcOptions(config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .Build();
                    config.Filters.Insert(0, new AuthorizeFilter(policy));
                });

            return mvcBuilder;
        }
    }
}