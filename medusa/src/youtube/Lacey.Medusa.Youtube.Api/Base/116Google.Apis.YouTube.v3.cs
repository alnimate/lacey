// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.PlaylistItemSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Basic details about a playlist, including title, description and thumbnails.</summary>
  public class PlaylistItemSnippet : IDirectResponseSchema
  {
    /// <summary>The ID that YouTube uses to uniquely identify the user that added the item to the
    /// playlist.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>Channel title for the channel that the playlist item belongs to.</summary>
    [JsonProperty("channelTitle")]
    public virtual string ChannelTitle { get; set; }

    /// <summary>The item's description.</summary>
    [JsonProperty("description")]
    public virtual string Description { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the playlist that the playlist item is in.</summary>
    [JsonProperty("playlistId")]
    public virtual string PlaylistId { get; set; }

    /// <summary>The order in which the item appears in the playlist. The value uses a zero-based index, so the
    /// first item has a position of 0, the second item has a position of 1, and so forth.</summary>
    [JsonProperty("position")]
    public virtual long? Position { get; set; }

    /// <summary>The date and time that the item was added to the playlist. The value is specified in ISO 8601
    /// (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("publishedAt")]
    public virtual string PublishedAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.PlaylistItemSnippet.PublishedAtRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? PublishedAt
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.PublishedAtRaw);
      }
      set
      {
        this.PublishedAtRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The id object contains information that can be used to uniquely identify the resource that is
    /// included in the playlist as the playlist item.</summary>
    [JsonProperty("resourceId")]
    public virtual ResourceId ResourceId { get; set; }

    /// <summary>A map of thumbnail images associated with the playlist item. For each object in the map, the key is
    /// the name of the thumbnail image, and the value is an object that contains other information about the
    /// thumbnail.</summary>
    [JsonProperty("thumbnails")]
    public virtual ThumbnailDetails Thumbnails { get; set; }

    /// <summary>The item's title.</summary>
    [JsonProperty("title")]
    public virtual string Title { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
