namespace Lacey.Medusa.Youtube.Transfer.Configuration
{
    public sealed class AppConfiguration
    {        
        public string ApiKeyFile { get; set; }

        public string ClientSecretsFilePath { get; set; }

        public string UserName { get; set; }

        public string TempFolder { get; set; }

        public string OutputFolder { get; set; }

        public string ConverterFile { get; set; }

        public string[] SourceChannels { get; set; }

        public string[] DestChannels { get; set; }

        public EmailConfiguration Email { get; set; }

        public LogsConfiguration Logs { get; set; }
    }
}