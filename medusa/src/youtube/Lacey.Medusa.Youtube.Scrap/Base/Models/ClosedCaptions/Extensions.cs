using System;
using System.Linq;
using Lacey.Medusa.Youtube.Scrap.Base.Internal;

namespace Lacey.Medusa.Youtube.Scrap.Base.Models.ClosedCaptions
{
    /// <summary>
    /// Extensions for <see cref="ClosedCaptions"/>.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Gets caption displayed at the given point in time.
        /// Returns null if not found.
        /// </summary>
        [CanBeNull]
        public static ClosedCaption GetByTime(this ClosedCaptionTrack track, TimeSpan time)
        {
            return track.Captions.FirstOrDefault(c => time >= c.Offset && time <= c.Offset + c.Duration);
        }
    }
}