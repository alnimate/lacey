// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.InvideoPromotion
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Describes an invideo promotion campaign consisting of multiple promoted items. A campaign belongs to a
  /// single channel_id.</summary>
  public class InvideoPromotion : IDirectResponseSchema
  {
    /// <summary>The default temporal position within the video where the promoted item will be displayed. Can be
    /// overriden by more specific timing in the item.</summary>
    [JsonProperty("defaultTiming")]
    public virtual InvideoTiming DefaultTiming { get; set; }

    /// <summary>List of promoted items in decreasing priority.</summary>
    [JsonProperty("items")]
    public virtual IList<PromotedItem> Items { get; set; }

    /// <summary>The spatial position within the video where the promoted item will be displayed.</summary>
    [JsonProperty("position")]
    public virtual InvideoPosition Position { get; set; }

    /// <summary>Indicates whether the channel's promotional campaign uses "smart timing." This feature attempts to
    /// show promotions at a point in the video when they are more likely to be clicked and less likely to disrupt
    /// the viewing experience. This feature also picks up a single promotion to show on each video.</summary>
    [JsonProperty("useSmartTiming")]
    public virtual bool? UseSmartTiming { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
