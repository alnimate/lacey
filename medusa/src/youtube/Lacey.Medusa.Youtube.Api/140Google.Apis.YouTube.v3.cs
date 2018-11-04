// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoAbuseReport
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  public class VideoAbuseReport : IDirectResponseSchema
  {
    /// <summary>Additional comments regarding the abuse report.</summary>
    [JsonProperty("comments")]
    public virtual string Comments { get; set; }

    /// <summary>The language that the content was viewed in.</summary>
    [JsonProperty("language")]
    public virtual string Language { get; set; }

    /// <summary>The high-level, or primary, reason that the content is abusive. The value is an abuse report reason
    /// ID.</summary>
    [JsonProperty("reasonId")]
    public virtual string ReasonId { get; set; }

    /// <summary>The specific, or secondary, reason that this content is abusive (if available). The value is an
    /// abuse report reason ID that is a valid secondary reason for the primary reason.</summary>
    [JsonProperty("secondaryReasonId")]
    public virtual string SecondaryReasonId { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the video.</summary>
    [JsonProperty("videoId")]
    public virtual string VideoId { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
