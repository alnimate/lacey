using System;

namespace Lacey.Medusa.Youtube.Common.Video.Base.Core.Helpers
{
    internal static class Require
    {
        public static void NotNull<T>(T obj, string name)
            where T : class
        {
            if (obj == null)
                throw new ArgumentNullException(name);
        }
    }
}
