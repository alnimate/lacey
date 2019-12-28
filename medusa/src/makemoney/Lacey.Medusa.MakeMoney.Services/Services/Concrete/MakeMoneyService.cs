using System.Threading.Tasks;
using Lacey.Medusa.Common.Email.Services.Email;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.MakeMoney.Services.Services.Concrete
{
    public sealed class MakeMoneyService : IMakeMoneyService
    {
        private readonly ILogger logger;

        private readonly IEmailProvider emailProvider;

        private readonly bool isSendEmails;

        private readonly string userSecretsFile;

        private readonly string commonSecretsFile;

        public MakeMoneyService(
            ILogger logger,
            IEmailProvider emailProvider,
            bool isSendEmails, 
            string userSecretsFile, 
            string commonSecretsFile)
        {
            this.logger = logger;
            this.emailProvider = emailProvider;
            this.isSendEmails = isSendEmails;
            this.userSecretsFile = userSecretsFile;
            this.commonSecretsFile = commonSecretsFile;
        }

        public async Task Run()
        {
        }
    }
}