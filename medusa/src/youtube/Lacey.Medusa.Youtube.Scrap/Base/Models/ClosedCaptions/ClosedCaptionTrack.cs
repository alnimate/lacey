using System.Collections.Generic;
using Lacey.Medusa.Youtube.Scrap.Base.Internal;

namespace Lacey.Medusa.Youtube.Scrap.Base.Models.ClosedCaptions
{
    /// <summary>
    /// Set of captions that get displayed during video playback.
    /// </summary>
    public class ClosedCaptionTrack
    {
        /// <summary>
        /// Metadata associated with this track.
        /// </summary>
        [NotNull]
        public ClosedCaptionTrackInfo Info { get; }

        /// <summary>
        /// Collection of closed captions that belong to this track.
        /// </summary>
        [NotNull, ItemNotNull]
        public IReadOnlyList<ClosedCaption> Captions { get; }

        /// <summary />
        public ClosedCaptionTrack(ClosedCaptionTrackInfo info, IReadOnlyList<ClosedCaption> captions)
        {
            Info = info.GuardNotNull(nameof(info));
            Captions = captions.GuardNotNull(nameof(captions));
        }
    }
}