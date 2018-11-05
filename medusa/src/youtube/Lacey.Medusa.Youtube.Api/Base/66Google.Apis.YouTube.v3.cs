// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelStatistics
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Statistics about a channel: number of subscribers, number of videos in the channel, etc.</summary>
  public class ChannelStatistics : IDirectResponseSchema
  {
    /// <summary>The number of comments for the channel.</summary>
    [JsonProperty("commentCount")]
    public virtual ulong? CommentCount { get; set; }

    /// <summary>Whether or not the number of subscribers is shown for this user.</summary>
    [JsonProperty("hiddenSubscriberCount")]
    public virtual bool? HiddenSubscriberCount { get; set; }

    /// <summary>The number of subscribers that the channel has.</summary>
    [JsonProperty("subscriberCount")]
    public virtual ulong? SubscriberCount { get; set; }

    /// <summary>The number of videos uploaded to the channel.</summary>
    [JsonProperty("videoCount")]
    public virtual ulong? VideoCount { get; set; }

    /// <summary>The number of times the channel has been viewed.</summary>
    [JsonProperty("viewCount")]
    public virtual ulong? ViewCount { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
