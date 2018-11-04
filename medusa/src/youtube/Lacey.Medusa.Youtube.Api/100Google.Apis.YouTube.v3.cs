// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveStream
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>A live stream describes a live ingestion point.</summary>
  public class LiveStream : IDirectResponseSchema
  {
    /// <summary>The cdn object defines the live stream's content delivery network (CDN) settings. These settings
    /// provide details about the manner in which you stream your content to YouTube.</summary>
    [JsonProperty("cdn")]
    public virtual CdnSettings Cdn { get; set; }

    /// <summary>The content_details object contains information about the stream, including the closed captions
    /// ingestion URL.</summary>
    [JsonProperty("contentDetails")]
    public virtual LiveStreamContentDetails ContentDetails { get; set; }

    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID that YouTube assigns to uniquely identify the stream.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string "youtube#liveStream".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The snippet object contains basic details about the stream, including its channel, title, and
    /// description.</summary>
    [JsonProperty("snippet")]
    public virtual LiveStreamSnippet Snippet { get; set; }

    /// <summary>The status object contains information about live stream's status.</summary>
    [JsonProperty("status")]
    public virtual LiveStreamStatus Status { get; set; }
  }
}
