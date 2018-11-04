// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoProcessingDetailsProcessingProgress
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Video processing progress and completion time estimate.</summary>
  public class VideoProcessingDetailsProcessingProgress : IDirectResponseSchema
  {
    /// <summary>The number of parts of the video that YouTube has already processed. You can estimate the
    /// percentage of the video that YouTube has already processed by calculating: 100 * parts_processed /
    /// parts_total
    /// 
    /// Note that since the estimated number of parts could increase without a corresponding increase in the number
    /// of parts that have already been processed, it is possible that the calculated progress could periodically
    /// decrease while YouTube processes a video.</summary>
    [JsonProperty("partsProcessed")]
    public virtual ulong? PartsProcessed { get; set; }

    /// <summary>An estimate of the total number of parts that need to be processed for the video. The number may be
    /// updated with more precise estimates while YouTube processes the video.</summary>
    [JsonProperty("partsTotal")]
    public virtual ulong? PartsTotal { get; set; }

    /// <summary>An estimate of the amount of time, in millseconds, that YouTube needs to finish processing the
    /// video.</summary>
    [JsonProperty("timeLeftMs")]
    public virtual ulong? TimeLeftMs { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
