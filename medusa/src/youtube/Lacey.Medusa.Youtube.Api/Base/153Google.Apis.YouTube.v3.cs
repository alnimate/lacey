// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoFileDetailsVideoStream
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Information about a video stream.</summary>
  internal class VideoFileDetailsVideoStream : IDirectResponseSchema
  {
    /// <summary>The video content's display aspect ratio, which specifies the aspect ratio in which the video
    /// should be displayed.</summary>
    [JsonProperty("aspectRatio")]
    public virtual double? AspectRatio { get; set; }

    /// <summary>The video stream's bitrate, in bits per second.</summary>
    [JsonProperty("bitrateBps")]
    public virtual ulong? BitrateBps { get; set; }

    /// <summary>The video codec that the stream uses.</summary>
    [JsonProperty("codec")]
    public virtual string Codec { get; set; }

    /// <summary>The video stream's frame rate, in frames per second.</summary>
    [JsonProperty("frameRateFps")]
    public virtual double? FrameRateFps { get; set; }

    /// <summary>The encoded video content's height in pixels.</summary>
    [JsonProperty("heightPixels")]
    public virtual long? HeightPixels { get; set; }

    /// <summary>The amount that YouTube needs to rotate the original source content to properly display the
    /// video.</summary>
    [JsonProperty("rotation")]
    public virtual string Rotation { get; set; }

    /// <summary>A value that uniquely identifies a video vendor. Typically, the value is a four-letter vendor
    /// code.</summary>
    [JsonProperty("vendor")]
    public virtual string Vendor { get; set; }

    /// <summary>The encoded video content's width in pixels. You can calculate the video's encoding aspect ratio as
    /// width_pixels / height_pixels.</summary>
    [JsonProperty("widthPixels")]
    public virtual long? WidthPixels { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
