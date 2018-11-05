// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoAbuseReportSecondaryReason
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  public class VideoAbuseReportSecondaryReason : IDirectResponseSchema
  {
    /// <summary>The ID of this abuse report secondary reason.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>The localized label for this abuse report secondary reason.</summary>
    [JsonProperty("label")]
    public virtual string Label { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
