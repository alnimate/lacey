using System;
using Lacey.Medusa.Common.Extensions.Base.Internal;

namespace Lacey.Medusa.Common.Extensions.Base
{
    public static partial class Ext
    {
        /// <summary>
        /// Multiplies the given timespan by a scalar value.
        /// </summary>
        [Pure]
        public static TimeSpan Multiply(this TimeSpan timeSpan, double multiplier)
        {
            return TimeSpan.FromMilliseconds(timeSpan.TotalMilliseconds * multiplier);
        }

        /// <summary>
        /// Divides the given timespan by a scalar value.
        /// </summary>
        [Pure]
        public static TimeSpan Divide(this TimeSpan timeSpan, double divider)
        {
            return TimeSpan.FromMilliseconds(timeSpan.TotalMilliseconds / divider);
        }
    }
}