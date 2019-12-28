using Lacey.Medusa.Common.Email.Services.Email;
using Lacey.Medusa.MakeMoney.Services.Services;
using Lacey.Medusa.MakeMoney.Services.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.MakeMoney.Services.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddMakeMoneyServices(
            this IServiceCollection services,
            string userSecretsFile,
            string commonSecretsFile,
            bool isSendEmails)
        {
            services
            .AddTransient<IMakeMoneyService, MakeMoneyService>(
                provider => new MakeMoneyService(
                    provider.GetService<ILogger<MakeMoneyService>>(),
                    provider.GetService<IEmailProvider>(),
                    isSendEmails, 
                    userSecretsFile, 
                    commonSecretsFile));

            return services;
        }
    }
}