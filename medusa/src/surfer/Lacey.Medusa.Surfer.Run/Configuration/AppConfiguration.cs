namespace Lacey.Medusa.Surfer.Run.Configuration
{
    internal sealed class AppConfiguration
    {
        public string LikesRockSecretsFilePath { get; set; }

        public string TempFolder { get; set; }

        public EmailConfiguration Email { get; set; }

        public LogsConfiguration Logs { get; set; }
    }
}