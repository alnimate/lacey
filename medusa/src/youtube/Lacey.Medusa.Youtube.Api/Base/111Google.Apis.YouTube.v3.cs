// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.Playlist
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>A playlist resource represents a YouTube playlist. A playlist is a collection of videos that can be
  /// viewed sequentially and shared with other users. A playlist can contain up to 200 videos, and YouTube does not
  /// limit the number of playlists that each user creates. By default, playlists are publicly visible to other users,
  /// but playlists can be public or private.
  /// 
  /// YouTube also uses playlists to identify special collections of videos for a channel, such as: - uploaded videos
  /// - favorite videos - positively rated (liked) videos - watch history - watch later  To be more specific, these
  /// lists are associated with a channel, which is a collection of a person, group, or company's videos, playlists,
  /// and other YouTube information. You can retrieve the playlist IDs for each of these lists from the  channel
  /// resource for a given channel.
  /// 
  /// You can then use the   playlistItems.list method to retrieve any of those lists. You can also add or remove
  /// items from those lists by calling the   playlistItems.insert and   playlistItems.delete methods.</summary>
  public class Playlist : IDirectResponseSchema
  {
    /// <summary>The contentDetails object contains information like video count.</summary>
    [JsonProperty("contentDetails")]
    public virtual PlaylistContentDetails ContentDetails { get; set; }

    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the playlist.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string "youtube#playlist".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>Localizations for different languages</summary>
    [JsonProperty("localizations")]
    public virtual IDictionary<string, PlaylistLocalization> Localizations { get; set; }

    /// <summary>The player object contains information that you would use to play the playlist in an embedded
    /// player.</summary>
    [JsonProperty("player")]
    public virtual PlaylistPlayer Player { get; set; }

    /// <summary>The snippet object contains basic details about the playlist, such as its title and
    /// description.</summary>
    [JsonProperty("snippet")]
    public virtual PlaylistSnippet Snippet { get; set; }

    /// <summary>The status object contains status information for the playlist.</summary>
    [JsonProperty("status")]
    public virtual PlaylistStatus Status { get; set; }
  }
}
