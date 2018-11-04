// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ActivityContentDetailsPlaylistItem
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Information about a new playlist item.</summary>
  public class ActivityContentDetailsPlaylistItem : IDirectResponseSchema
  {
    /// <summary>The value that YouTube uses to uniquely identify the playlist.</summary>
    [JsonProperty("playlistId")]
    public virtual string PlaylistId { get; set; }

    /// <summary>ID of the item within the playlist.</summary>
    [JsonProperty("playlistItemId")]
    public virtual string PlaylistItemId { get; set; }

    /// <summary>The resourceId object contains information about the resource that was added to the
    /// playlist.</summary>
    [JsonProperty("resourceId")]
    public virtual ResourceId ResourceId { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
