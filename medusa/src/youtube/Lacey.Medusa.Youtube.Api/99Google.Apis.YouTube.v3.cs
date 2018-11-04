// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveBroadcastStatus
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  public class LiveBroadcastStatus : IDirectResponseSchema
  {
    /// <summary>The broadcast's status. The status can be updated using the API's liveBroadcasts.transition
    /// method.</summary>
    [JsonProperty("lifeCycleStatus")]
    public virtual string LifeCycleStatus { get; set; }

    /// <summary>Priority of the live broadcast event (internal state).</summary>
    [JsonProperty("liveBroadcastPriority")]
    public virtual string LiveBroadcastPriority { get; set; }

    /// <summary>The broadcast's privacy status. Note that the broadcast represents exactly one YouTube video, so
    /// the privacy settings are identical to those supported for videos. In addition, you can set this field by
    /// modifying the broadcast resource or by setting the privacyStatus field of the corresponding video
    /// resource.</summary>
    [JsonProperty("privacyStatus")]
    public virtual string PrivacyStatus { get; set; }

    /// <summary>The broadcast's recording status.</summary>
    [JsonProperty("recordingStatus")]
    public virtual string RecordingStatus { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
