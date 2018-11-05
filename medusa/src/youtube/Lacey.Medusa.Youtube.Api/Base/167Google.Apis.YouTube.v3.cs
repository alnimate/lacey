// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoStatus
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Google.Apis.Requests;
using Google.Apis.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Basic details about a video category, such as its localized title.</summary>
  public class VideoStatus : IDirectResponseSchema
  {
    /// <summary>This value indicates if the video can be embedded on another website.</summary>
    [JsonProperty("embeddable")]
    public virtual bool? Embeddable { get; set; }

    /// <summary>This value explains why a video failed to upload. This property is only present if the uploadStatus
    /// property indicates that the upload failed.</summary>
    [JsonProperty("failureReason")]
    public virtual string FailureReason { get; set; }

    /// <summary>The video's license.</summary>
    [JsonProperty("license")]
    public virtual string License { get; set; }

    /// <summary>The video's privacy status.</summary>
    [JsonProperty("privacyStatus")]
    public virtual string PrivacyStatus { get; set; }

    /// <summary>This value indicates if the extended video statistics on the watch page can be viewed by everyone.
    /// Note that the view count, likes, etc will still be visible if this is disabled.</summary>
    [JsonProperty("publicStatsViewable")]
    public virtual bool? PublicStatsViewable { get; set; }

    /// <summary>The date and time when the video is scheduled to publish. It can be set only if the privacy status
    /// of the video is private. The value is specified in ISO 8601 (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("publishAt")]
    public virtual string PublishAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.VideoStatus.PublishAtRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? PublishAt
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.PublishAtRaw);
      }
      set
      {
        this.PublishAtRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>This value explains why YouTube rejected an uploaded video. This property is only present if the
    /// uploadStatus property indicates that the upload was rejected.</summary>
    [JsonProperty("rejectionReason")]
    public virtual string RejectionReason { get; set; }

    /// <summary>The status of the uploaded video.</summary>
    [JsonProperty("uploadStatus")]
    public virtual string UploadStatus { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
