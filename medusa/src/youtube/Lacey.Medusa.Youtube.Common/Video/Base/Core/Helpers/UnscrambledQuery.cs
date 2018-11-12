﻿namespace Lacey.Medusa.Youtube.Common.Video.Base.Core.Helpers
{
    internal struct UnscrambledQuery
    {
        public UnscrambledQuery(
            string uri, bool encrypted)
        {
            this.Uri = uri;
            this.IsEncrypted = encrypted;
        }

        public string Uri { get; }
        public bool IsEncrypted { get; }
    }
}
