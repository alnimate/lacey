﻿namespace Lacey.Medusa.Youtube.App.Configuration
{
    public sealed class AppConfiguration
    {
        public string VideosFolder { get; set; }

        public string ApiKeyFile { get; set; }

        public string[] SourceChannels { get; set; }

        public string[] DestChannels { get; set; }
    }
}