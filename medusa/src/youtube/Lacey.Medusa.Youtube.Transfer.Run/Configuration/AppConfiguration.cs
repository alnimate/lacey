using Lacey.Medusa.Youtube.Transfer.Run.Models;

namespace Lacey.Medusa.Youtube.Transfer.Run.Configuration
{
    internal sealed class AppConfiguration
    {        
        public string ClientSecretsFilePath { get; set; }

        public string UserName { get; set; }

        public string TempFolder { get; set; }

        public int Threshold { get; set; }

        public Channel[] SourceChannels { get; set; }

        public Channel[] DestChannels { get; set; }

        public EmailConfiguration Email { get; set; }

        public LogsConfiguration Logs { get; set; }
    }
}