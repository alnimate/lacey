using Lacey.Medusa.Boost.Run.Models;

namespace Lacey.Medusa.Boost.Run.Configuration
{
    internal sealed class AppConfiguration
    {        
        public string ClientSecretsFilePath { get; set; }

        public string UserName { get; set; }

        public string TempFolder { get; set; }

        public YoutubeChannel[] YoutubeChannels { get; set; }

        public EmailConfiguration Email { get; set; }

        public LogsConfiguration Logs { get; set; }
    }
}