using System;

namespace Lacey.Medusa.Youtube.Common.Video.Base.Compat
{
    public class AudioExtractionException : Exception
    {
        public AudioExtractionException(string message)
            : base(message)
        { }
    }
}
