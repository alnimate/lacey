using System;

namespace Lacey.Medusa.Youtube.Api.Video.Base.Core.Exceptions
{
    internal class BadQueryException : Exception
    {
        public BadQueryException()
            : base()
        { }

        public BadQueryException(string message)
            : base(message)
        { }

        public BadQueryException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
