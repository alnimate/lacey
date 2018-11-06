using Lacey.Medusa.Common.Web.Mvc;
using Lacey.Medusa.Common.Web.Validation;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Lacey.Medusa.Common.Web.Infrastructure
{
    public static class ServicesExtentions
    {
        public static IServiceCollection AddMvcWithModelValidation(
            this IServiceCollection services,
            out IMvcBuilder mvcBuilder)
        {
            mvcBuilder = services.AddMvc(
                config =>
                    {
                        config.ModelBinderProviders.Insert(0, new AppModelBinderProvider());
                        config.Filters.Add(typeof(ValidateModelFilter));
                        config.Filters.Add(typeof(ModelErrorsFilter));
                    });

            return services;
        }

        public static IServiceCollection AddCorsEnable(
            this IServiceCollection services)
        {
            services.AddCors(options =>
                {
                    options.AddPolicy(Constants.AllowCors,
                        builder => builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod());
                });

            return services;
        }

        public static IServiceCollection AddSwagger(
            this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
                    {
                        s.SwaggerDoc("v1", new Info { Title = "API", Version = "v1" });
                    });
            
            return services;
        }
    }
}