using System;

namespace Lacey.Medusa.Youtube.Api.Video.Base.Compat
{
    public class YoutubeParseException : Exception
    {
        public YoutubeParseException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
