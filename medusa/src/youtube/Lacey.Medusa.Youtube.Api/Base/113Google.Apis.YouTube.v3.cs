// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.PlaylistItem
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>A playlistItem resource identifies another resource, such as a video, that is included in a playlist.
  /// In addition, the playlistItem  resource contains details about the included resource that pertain specifically
  /// to how that resource is used in that playlist.
  /// 
  /// YouTube uses playlists to identify special collections of videos for a channel, such as: - uploaded videos -
  /// favorite videos - positively rated (liked) videos - watch history - watch later  To be more specific, these
  /// lists are associated with a channel, which is a collection of a person, group, or company's videos, playlists,
  /// and other YouTube information.
  /// 
  /// You can retrieve the playlist IDs for each of these lists from the  channel resource  for a given channel. You
  /// can then use the   playlistItems.list method to retrieve any of those lists. You can also add or remove items
  /// from those lists by calling the   playlistItems.insert and   playlistItems.delete methods. For example, if a
  /// user gives a positive rating to a video, you would insert that video into the liked videos playlist for that
  /// user's channel.</summary>
  public class PlaylistItem : IDirectResponseSchema
  {
    /// <summary>The contentDetails object is included in the resource if the included item is a YouTube video. The
    /// object contains additional information about the video.</summary>
    [JsonProperty("contentDetails")]
    public virtual PlaylistItemContentDetails ContentDetails { get; set; }

    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the playlist item.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string "youtube#playlistItem".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The snippet object contains basic details about the playlist item, such as its title and position
    /// in the playlist.</summary>
    [JsonProperty("snippet")]
    public virtual PlaylistItemSnippet Snippet { get; set; }

    /// <summary>The status object contains information about the playlist item's privacy status.</summary>
    [JsonProperty("status")]
    public virtual PlaylistItemStatus Status { get; set; }
  }
}
