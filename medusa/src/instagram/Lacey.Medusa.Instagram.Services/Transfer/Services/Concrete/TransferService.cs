using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Instagram.Services.Transfer.Services.Concrete
{
    public sealed class TransferService : ITransferService
    {
        private readonly string outputFolder;

        public TransferService(
            ILogger<TransferService> logger, 
            string outputFolder)
        {
            this.outputFolder = outputFolder;
        }

        public async Task Transfer(string sourceChannelId, string destChannelId)
        {
        }
    }
}