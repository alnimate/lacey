// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.InvideoTiming
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Describes a temporal position of a visual widget inside a video.</summary>
  internal class InvideoTiming : IDirectResponseSchema
  {
    /// <summary>Defines the duration in milliseconds for which the promotion should be displayed. If missing, the
    /// client should use the default.</summary>
    [JsonProperty("durationMs")]
    public virtual ulong? DurationMs { get; set; }

    /// <summary>Defines the time at which the promotion will appear. Depending on the value of type the value of
    /// the offsetMs field will represent a time offset from the start or from the end of the video, expressed in
    /// milliseconds.</summary>
    [JsonProperty("offsetMs")]
    public virtual ulong? OffsetMs { get; set; }

    /// <summary>Describes a timing type. If the value is offsetFromStart, then the offsetMs field represents an
    /// offset from the start of the video. If the value is offsetFromEnd, then the offsetMs field represents an
    /// offset from the end of the video.</summary>
    [JsonProperty("type")]
    public virtual string Type { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
