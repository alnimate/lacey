using AutoMapper;
using Lacey.Medusa.Common.Files.Services;
using Lacey.Medusa.Common.Files.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Common.Files.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddFiles(
            this IServiceCollection services,
            string uploadFolder)
        {
            services.AddScoped<IEntityFilesService, EntityFilesService>(
                provider => new EntityFilesService(uploadFolder, provider.GetService<IMapper>()));

            return services;
        }
    }
}