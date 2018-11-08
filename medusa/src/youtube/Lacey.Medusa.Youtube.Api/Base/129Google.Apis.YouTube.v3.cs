// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.SearchResultSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Basic details about a search result, including title, description and thumbnails of the item referenced
  /// by the search result.</summary>
  internal class SearchResultSnippet : IDirectResponseSchema
  {
    /// <summary>The value that YouTube uses to uniquely identify the channel that published the resource that the
    /// search result identifies.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>The title of the channel that published the resource that the search result identifies.</summary>
    [JsonProperty("channelTitle")]
    public virtual string ChannelTitle { get; set; }

    /// <summary>A description of the search result.</summary>
    [JsonProperty("description")]
    public virtual string Description { get; set; }

    /// <summary>It indicates if the resource (video or channel) has upcoming/active live broadcast content. Or it's
    /// "none" if there is not any upcoming/active live broadcasts.</summary>
    [JsonProperty("liveBroadcastContent")]
    public virtual string LiveBroadcastContent { get; set; }

    /// <summary>The creation date and time of the resource that the search result identifies. The value is
    /// specified in ISO 8601 (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("publishedAt")]
    public virtual string PublishedAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.SearchResultSnippet.PublishedAtRaw" />.</summary>
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

    /// <summary>A map of thumbnail images associated with the search result. For each object in the map, the key is
    /// the name of the thumbnail image, and the value is an object that contains other information about the
    /// thumbnail.</summary>
    [JsonProperty("thumbnails")]
    public virtual ThumbnailDetails Thumbnails { get; set; }

    /// <summary>The title of the search result.</summary>
    [JsonProperty("title")]
    public virtual string Title { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
