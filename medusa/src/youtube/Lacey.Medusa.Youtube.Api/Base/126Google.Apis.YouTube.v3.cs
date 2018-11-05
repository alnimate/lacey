// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ResourceId
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>A resource id is a generic reference that points to another YouTube resource.</summary>
  public class ResourceId : IDirectResponseSchema
  {
    /// <summary>The ID that YouTube uses to uniquely identify the referred resource, if that resource is a channel.
    /// This property is only present if the resourceId.kind value is youtube#channel.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>The type of the API resource.</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the referred resource, if that resource is a
    /// playlist. This property is only present if the resourceId.kind value is youtube#playlist.</summary>
    [JsonProperty("playlistId")]
    public virtual string PlaylistId { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the referred resource, if that resource is a video.
    /// This property is only present if the resourceId.kind value is youtube#video.</summary>
    [JsonProperty("videoId")]
    public virtual string VideoId { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
