// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoFileDetailsAudioStream
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Information about an audio stream.</summary>
  public class VideoFileDetailsAudioStream : IDirectResponseSchema
  {
    /// <summary>The audio stream's bitrate, in bits per second.</summary>
    [JsonProperty("bitrateBps")]
    public virtual ulong? BitrateBps { get; set; }

    /// <summary>The number of audio channels that the stream contains.</summary>
    [JsonProperty("channelCount")]
    public virtual long? ChannelCount { get; set; }

    /// <summary>The audio codec that the stream uses.</summary>
    [JsonProperty("codec")]
    public virtual string Codec { get; set; }

    /// <summary>A value that uniquely identifies a video vendor. Typically, the value is a four-letter vendor
    /// code.</summary>
    [JsonProperty("vendor")]
    public virtual string Vendor { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
