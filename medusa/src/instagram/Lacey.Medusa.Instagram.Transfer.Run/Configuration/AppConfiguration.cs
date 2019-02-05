namespace Lacey.Medusa.Instagram.Transfer.Run.Configuration
{
    internal sealed class AppConfiguration
    {        
        public string ClientSecretsFilePath { get; set; }

        public string TempFolder { get; set; }

        public string[] SourceChannels { get; set; }

        public string[] DestChannels { get; set; }

        public EmailConfiguration Email { get; set; }

        public LogsConfiguration Logs { get; set; }
    }
}