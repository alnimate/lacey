using Lacey.Medusa.Boost.Run.Models;

namespace Lacey.Medusa.Boost.Run.Configuration
{
    internal sealed class AppConfiguration
    {        
        public string YoutubeSecretsFile { get; set; }

        public string InstagramSecretsFile { get; set; }

        public string FacebookSecretsFile { get; set; }

        public string GoogleSecretsFile { get; set; }

        public string InstagramStateFile { get; set; }

        public string UserName { get; set; }

        public string TempFolder { get; set; }

        public int BoostInterval { get; set; }

        public YoutubeChannel[] YoutubeChannels { get; set; }

        public EmailConfiguration Email { get; set; }

        public LogsConfiguration Logs { get; set; }
    }
}