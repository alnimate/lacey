namespace Lacey.Medusa.Youtube.App.Configuration
{
    public sealed class AppConfiguration
    {
        public string VideosFolder { get; set; }

        public string ApiKeyFile { get; set; }

        public string[] ChannelsForImport { get; set; }

        public string ChannelToImport { get; set; }
    }
}