namespace Lacey.Medusa.Youtube.Transfer.Configuration
{
    public sealed class AppConfiguration
    {        
        public string ClientSecretsFilePath { get; set; }

        public string UserName { get; set; }

        public string TempFolder { get; set; }

        public string SourceChannelId { get; set; }

        public string DestChannelId { get; set; }

        public EmailConfiguration Email { get; set; }

        public LogsConfiguration Logs { get; set; }
    }
}