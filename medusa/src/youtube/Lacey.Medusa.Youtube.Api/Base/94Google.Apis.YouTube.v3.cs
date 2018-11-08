// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveBroadcast
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>A liveBroadcast resource represents an event that will be streamed, via live video, on
  /// YouTube.</summary>
  internal class LiveBroadcast : IDirectResponseSchema
  {
    /// <summary>The contentDetails object contains information about the event's video content, such as whether the
    /// content can be shown in an embedded video player or if it will be archived and therefore available for
    /// viewing after the event has concluded.</summary>
    [JsonProperty("contentDetails")]
    public virtual LiveBroadcastContentDetails ContentDetails { get; set; }

    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID that YouTube assigns to uniquely identify the broadcast.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string
    /// "youtube#liveBroadcast".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The snippet object contains basic details about the event, including its title, description, start
    /// time, and end time.</summary>
    [JsonProperty("snippet")]
    public virtual LiveBroadcastSnippet Snippet { get; set; }

    /// <summary>The statistics object contains info about the event's current stats. These include concurrent
    /// viewers and total chat count. Statistics can change (in either direction) during the lifetime of an event.
    /// Statistics are only returned while the event is live.</summary>
    [JsonProperty("statistics")]
    public virtual LiveBroadcastStatistics Statistics { get; set; }

    /// <summary>The status object contains information about the event's status.</summary>
    [JsonProperty("status")]
    public virtual LiveBroadcastStatus Status { get; set; }
  }
}
