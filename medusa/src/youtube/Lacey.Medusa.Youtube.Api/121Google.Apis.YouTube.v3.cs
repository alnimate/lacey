// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.PlaylistSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using System.Collections.Generic;
using Google.Apis.Requests;
using Google.Apis.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Basic details about a playlist, including title, description and thumbnails.</summary>
  public class PlaylistSnippet : IDirectResponseSchema
  {
    /// <summary>The ID that YouTube uses to uniquely identify the channel that published the playlist.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>The channel title of the channel that the video belongs to.</summary>
    [JsonProperty("channelTitle")]
    public virtual string ChannelTitle { get; set; }

    /// <summary>The language of the playlist's default title and description.</summary>
    [JsonProperty("defaultLanguage")]
    public virtual string DefaultLanguage { get; set; }

    /// <summary>The playlist's description.</summary>
    [JsonProperty("description")]
    public virtual string Description { get; set; }

    /// <summary>Localized title and description, read-only.</summary>
    [JsonProperty("localized")]
    public virtual PlaylistLocalization Localized { get; set; }

    /// <summary>The date and time that the playlist was created. The value is specified in ISO 8601 (YYYY-MM-
    /// DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("publishedAt")]
    public virtual string PublishedAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.PlaylistSnippet.PublishedAtRaw" />.</summary>
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

    /// <summary>Keyword tags associated with the playlist.</summary>
    [JsonProperty("tags")]
    public virtual IList<string> Tags { get; set; }

    /// <summary>A map of thumbnail images associated with the playlist. For each object in the map, the key is the
    /// name of the thumbnail image, and the value is an object that contains other information about the
    /// thumbnail.</summary>
    [JsonProperty("thumbnails")]
    public virtual ThumbnailDetails Thumbnails { get; set; }

    /// <summary>The playlist's title.</summary>
    [JsonProperty("title")]
    public virtual string Title { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
