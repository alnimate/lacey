using Lacey.Medusa.Common.Email.Services.Auth;
using Lacey.Medusa.Common.Email.Services.Auth.Concrete;
using Lacey.Medusa.Common.Email.Services.Email;
using Lacey.Medusa.Common.Email.Services.Email.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Lacey.Medusa.Common.Email.Infrastructure
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddEmailServices(
            this IServiceCollection services,
            string smtpHost,
            int smtpPort,
            string userName,
            string secretFilePath)
        {
            services
                .AddTransient<IEmailAuthProvider, SimpleEmailAuthProvider>(
                    provider => new SimpleEmailAuthProvider(
                        userName,
                        secretFilePath))
                .AddTransient<IEmailProvider, EmailProvider>(
                    provider => new EmailProvider(
                        smtpHost,
                        smtpPort,
                        provider.GetService<IEmailAuthProvider>()));

            return services;
        }
    }
}