using System;

namespace Lacey.Medusa.Youtube.Api.Video.Base.Compat
{
    public class AudioExtractionException : Exception
    {
        public AudioExtractionException(string message)
            : base(message)
        { }
    }
}
