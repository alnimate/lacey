using System;

namespace Lacey.Medusa.Youtube.Common.Video.Base.Compat
{
    public class VideoNotAvailableException : Exception
    {
        public VideoNotAvailableException()
        { }

        public VideoNotAvailableException(string message)
            : base(message)
        { }
    }
}
