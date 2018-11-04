// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelSectionContentDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Details about a channelsection, including playlists and channels.</summary>
  public class ChannelSectionContentDetails : IDirectResponseSchema
  {
    /// <summary>The channel ids for type multiple_channels.</summary>
    [JsonProperty("channels")]
    public virtual IList<string> Channels { get; set; }

    /// <summary>The playlist ids for type single_playlist and multiple_playlists. For singlePlaylist, only one
    /// playlistId is allowed.</summary>
    [JsonProperty("playlists")]
    public virtual IList<string> Playlists { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
