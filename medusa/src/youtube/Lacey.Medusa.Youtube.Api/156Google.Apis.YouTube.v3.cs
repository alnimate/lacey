// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoLiveStreamingDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Google.Apis.Requests;
using Google.Apis.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Details about the live streaming metadata.</summary>
  public class VideoLiveStreamingDetails : IDirectResponseSchema
  {
    /// <summary>The ID of the currently active live chat attached to this video. This field is filled only if the
    /// video is a currently live broadcast that has live chat. Once the broadcast transitions to complete this
    /// field will be removed and the live chat closed down. For persistent broadcasts that live chat id will no
    /// longer be tied to this video but rather to the new video being displayed at the persistent page.</summary>
    [JsonProperty("activeLiveChatId")]
    public virtual string ActiveLiveChatId { get; set; }

    /// <summary>The time that the broadcast actually ended. The value is specified in ISO 8601 (YYYY-MM-
    /// DDThh:mm:ss.sZ) format. This value will not be available until the broadcast is over.</summary>
    [JsonProperty("actualEndTime")]
    public virtual string ActualEndTimeRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.VideoLiveStreamingDetails.ActualEndTimeRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? ActualEndTime
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.ActualEndTimeRaw);
      }
      set
      {
        this.ActualEndTimeRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The time that the broadcast actually started. The value is specified in ISO 8601 (YYYY-MM-
    /// DDThh:mm:ss.sZ) format. This value will not be available until the broadcast begins.</summary>
    [JsonProperty("actualStartTime")]
    public virtual string ActualStartTimeRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.VideoLiveStreamingDetails.ActualStartTimeRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? ActualStartTime
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.ActualStartTimeRaw);
      }
      set
      {
        this.ActualStartTimeRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The number of viewers currently watching the broadcast. The property and its value will be present
    /// if the broadcast has current viewers and the broadcast owner has not hidden the viewcount for the video.
    /// Note that YouTube stops tracking the number of concurrent viewers for a broadcast when the broadcast ends.
    /// So, this property would not identify the number of viewers watching an archived video of a live broadcast
    /// that already ended.</summary>
    [JsonProperty("concurrentViewers")]
    public virtual ulong? ConcurrentViewers { get; set; }

    /// <summary>The time that the broadcast is scheduled to end. The value is specified in ISO 8601 (YYYY-MM-
    /// DDThh:mm:ss.sZ) format. If the value is empty or the property is not present, then the broadcast is
    /// scheduled to continue indefinitely.</summary>
    [JsonProperty("scheduledEndTime")]
    public virtual string ScheduledEndTimeRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.VideoLiveStreamingDetails.ScheduledEndTimeRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? ScheduledEndTime
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.ScheduledEndTimeRaw);
      }
      set
      {
        this.ScheduledEndTimeRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The time that the broadcast is scheduled to begin. The value is specified in ISO 8601 (YYYY-MM-
    /// DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("scheduledStartTime")]
    public virtual string ScheduledStartTimeRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.VideoLiveStreamingDetails.ScheduledStartTimeRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? ScheduledStartTime
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.ScheduledStartTimeRaw);
      }
      set
      {
        this.ScheduledStartTimeRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
