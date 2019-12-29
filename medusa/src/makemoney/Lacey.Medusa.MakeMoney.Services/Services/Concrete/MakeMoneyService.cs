using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Core.Serializers;
using Lacey.Medusa.Common.Core.Utils;
using Lacey.Medusa.Common.Email.Services.Email;
using Lacey.Medusa.MakeMoney.Services.Models.ScDevice;
using Lacey.Medusa.MakeMoney.Services.Providers;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.MakeMoney.Services.Services.Concrete
{
    public sealed class MakeMoneyService : IMakeMoneyService
    {
        #region Fields/Constructors

        private readonly ILogger logger;

        private readonly IEmailProvider emailProvider;

        private readonly bool isSendEmails;

        private readonly string userSecretsFile;

        private readonly string commonSecretsFile;

        private readonly MakeMoneyProvider makeMoney;
            
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

            this.makeMoney = new MakeMoneyProvider(new BaseClientService.Initializer
            {
                Serializer = new WebFormsToXmlSerializer()
            });
        }

        #endregion

        public async Task Run()
        {
            await this.ScDevice();
        }

        private async Task ScDevice()
        {
            await ProceedUtils.Proceed<bool?>(this.logger, async () =>
            {
                var sr = new WebFormsToXmlSerializer();
                var response = sr.Deserialize<ScDeviceResponse>(
                    "<REQ_STATUS>0</REQ_STATUS><CUSTOMER_ID>2179107453</CUSTOMER_ID><USC_BALANCE>30.0</USC_BALANCE><SUSPENDED>0</SUSPENDED><EMAIL_ADDRESS></EMAIL_ADDRESS><REFERAL_CODE>J22GYB</REFERAL_CODE><RETURNING>YES</RETURNING><REFERRED>NO</REFERRED>");

                return true;
            });
        }
    }
}