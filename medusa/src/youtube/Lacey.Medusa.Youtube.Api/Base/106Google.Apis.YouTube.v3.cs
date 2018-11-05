// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveStreamStatus
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Brief description of the live stream status.</summary>
  public class LiveStreamStatus : IDirectResponseSchema
  {
    /// <summary>The health status of the stream.</summary>
    [JsonProperty("healthStatus")]
    public virtual LiveStreamHealthStatus HealthStatus { get; set; }

    [JsonProperty("streamStatus")]
    public virtual string StreamStatus { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
