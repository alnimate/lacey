// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveBroadcastContentDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Google.Apis.Requests;
using Google.Apis.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Detailed settings of a broadcast.</summary>
  public class LiveBroadcastContentDetails : IDirectResponseSchema
  {
    /// <summary>This value uniquely identifies the live stream bound to the broadcast.</summary>
    [JsonProperty("boundStreamId")]
    public virtual string BoundStreamId { get; set; }

    /// <summary>The date and time that the live stream referenced by boundStreamId was last updated.</summary>
    [JsonProperty("boundStreamLastUpdateTimeMs")]
    public virtual string BoundStreamLastUpdateTimeMsRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.LiveBroadcastContentDetails.BoundStreamLastUpdateTimeMsRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? BoundStreamLastUpdateTimeMs
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.BoundStreamLastUpdateTimeMsRaw);
      }
      set
      {
        this.BoundStreamLastUpdateTimeMsRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    [JsonProperty("closedCaptionsType")]
    public virtual string ClosedCaptionsType { get; set; }

    /// <summary>This setting indicates whether auto start is enabled for this broadcast.</summary>
    [JsonProperty("enableAutoStart")]
    public virtual bool? EnableAutoStart { get; set; }

    /// <summary>This setting indicates whether HTTP POST closed captioning is enabled for this broadcast. The
    /// ingestion URL of the closed captions is returned through the liveStreams API. This is mutually exclusive
    /// with using the closed_captions_type property, and is equivalent to setting closed_captions_type to
    /// CLOSED_CAPTIONS_HTTP_POST.</summary>
    [JsonProperty("enableClosedCaptions")]
    public virtual bool? EnableClosedCaptions { get; set; }

    /// <summary>This setting indicates whether YouTube should enable content encryption for the
    /// broadcast.</summary>
    [JsonProperty("enableContentEncryption")]
    public virtual bool? EnableContentEncryption { get; set; }

    /// <summary>This setting determines whether viewers can access DVR controls while watching the video. DVR
    /// controls enable the viewer to control the video playback experience by pausing, rewinding, or fast
    /// forwarding content. The default value for this property is true.
    /// 
    /// Important: You must set the value to true and also set the enableArchive property's value to true if you
    /// want to make playback available immediately after the broadcast ends.</summary>
    [JsonProperty("enableDvr")]
    public virtual bool? EnableDvr { get; set; }

    /// <summary>This setting indicates whether the broadcast video can be played in an embedded player. If you
    /// choose to archive the video (using the enableArchive property), this setting will also apply to the archived
    /// video.</summary>
    [JsonProperty("enableEmbed")]
    public virtual bool? EnableEmbed { get; set; }

    /// <summary>Indicates whether this broadcast has low latency enabled.</summary>
    [JsonProperty("enableLowLatency")]
    public virtual bool? EnableLowLatency { get; set; }

    /// <summary>If both this and enable_low_latency are set, they must match. LATENCY_NORMAL should match
    /// enable_low_latency=false LATENCY_LOW should match enable_low_latency=true LATENCY_ULTRA_LOW should have
    /// enable_low_latency omitted.</summary>
    [JsonProperty("latencyPreference")]
    public virtual string LatencyPreference { get; set; }

    [JsonProperty("mesh")]
    public virtual string Mesh { get; set; }

    /// <summary>The monitorStream object contains information about the monitor stream, which the broadcaster can
    /// use to review the event content before the broadcast stream is shown publicly.</summary>
    [JsonProperty("monitorStream")]
    public virtual MonitorStreamInfo MonitorStream { get; set; }

    /// <summary>The projection format of this broadcast. This defaults to rectangular.</summary>
    [JsonProperty("projection")]
    public virtual string Projection { get; set; }

    /// <summary>Automatically start recording after the event goes live. The default value for this property is
    /// true.
    /// 
    /// Important: You must also set the enableDvr property's value to true if you want the playback to be available
    /// immediately after the broadcast ends. If you set this property's value to true but do not also set the
    /// enableDvr property to true, there may be a delay of around one day before the archived video will be
    /// available for playback.</summary>
    [JsonProperty("recordFromStart")]
    public virtual bool? RecordFromStart { get; set; }

    /// <summary>This setting indicates whether the broadcast should automatically begin with an in-stream slate
    /// when you update the broadcast's status to live. After updating the status, you then need to send a
    /// liveCuepoints.insert request that sets the cuepoint's eventState to end to remove the in-stream slate and
    /// make your broadcast stream visible to viewers.</summary>
    [JsonProperty("startWithSlate")]
    public virtual bool? StartWithSlate { get; set; }

    [JsonProperty("stereoLayout")]
    public virtual string StereoLayout { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
