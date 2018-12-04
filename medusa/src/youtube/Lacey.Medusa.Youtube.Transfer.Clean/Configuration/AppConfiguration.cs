namespace Lacey.Medusa.Youtube.Transfer.Clean.Configuration
{
    public sealed class AppConfiguration
    {        
        public string ClientSecretsFilePath { get; set; }

        public string UserName { get; set; }

        public string[] Channels { get; set; }
    }
}