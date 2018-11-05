// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveBroadcastStatistics
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Statistics about the live broadcast. These represent a snapshot of the values at the time of the
  /// request. Statistics are only returned for live broadcasts.</summary>
  public class LiveBroadcastStatistics : IDirectResponseSchema
  {
    /// <summary>The number of viewers currently watching the broadcast. The property and its value will be present
    /// if the broadcast has current viewers and the broadcast owner has not hidden the viewcount for the video.
    /// Note that YouTube stops tracking the number of concurrent viewers for a broadcast when the broadcast ends.
    /// So, this property would not identify the number of viewers watching an archived video of a live broadcast
    /// that already ended.</summary>
    [JsonProperty("concurrentViewers")]
    public virtual ulong? ConcurrentViewers { get; set; }

    /// <summary>The total number of live chat messages currently on the broadcast. The property and its value will
    /// be present if the broadcast is public, has the live chat feature enabled, and has at least one message. Note
    /// that this field will not be filled after the broadcast ends. So this property would not identify the number
    /// of chat messages for an archived video of a completed live broadcast.</summary>
    [JsonProperty("totalChatCount")]
    public virtual ulong? TotalChatCount { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
