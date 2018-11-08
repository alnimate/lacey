// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoAbuseReportReason
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>A videoAbuseReportReason resource identifies a reason that a video could be reported as abusive. Video
  /// abuse report reasons are used with video.ReportAbuse.</summary>
  internal class VideoAbuseReportReason : IDirectResponseSchema
  {
    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID of this abuse report reason.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string
    /// "youtube#videoAbuseReportReason".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The snippet object contains basic details about the abuse report reason.</summary>
    [JsonProperty("snippet")]
    public virtual VideoAbuseReportReasonSnippet Snippet { get; set; }
  }
}
