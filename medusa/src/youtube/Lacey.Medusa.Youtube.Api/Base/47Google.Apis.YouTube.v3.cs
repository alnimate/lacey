// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.CdnSettings
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Brief description of the live stream cdn settings.</summary>
  public class CdnSettings : IDirectResponseSchema
  {
    /// <summary>The format of the video stream that you are sending to Youtube.</summary>
    [JsonProperty("format")]
    public virtual string Format { get; set; }

    /// <summary>The frame rate of the inbound video data.</summary>
    [JsonProperty("frameRate")]
    public virtual string FrameRate { get; set; }

    /// <summary>The ingestionInfo object contains information that YouTube provides that you need to transmit your
    /// RTMP or HTTP stream to YouTube.</summary>
    [JsonProperty("ingestionInfo")]
    public virtual IngestionInfo IngestionInfo { get; set; }

    /// <summary>The method or protocol used to transmit the video stream.</summary>
    [JsonProperty("ingestionType")]
    public virtual string IngestionType { get; set; }

    /// <summary>The resolution of the inbound video data.</summary>
    [JsonProperty("resolution")]
    public virtual string Resolution { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
