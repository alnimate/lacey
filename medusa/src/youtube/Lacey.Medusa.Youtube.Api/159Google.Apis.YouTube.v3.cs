// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoPlayer
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Player to be used for a video playback.</summary>
  public class VideoPlayer : IDirectResponseSchema
  {
    [JsonProperty("embedHeight")]
    public virtual long? EmbedHeight { get; set; }

    /// <summary>An  tag that embeds a player that will play the video.</summary>
    [JsonProperty("embedHtml")]
    public virtual string EmbedHtml { get; set; }

    /// <summary>The embed width</summary>
    [JsonProperty("embedWidth")]
    public virtual long? EmbedWidth { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
