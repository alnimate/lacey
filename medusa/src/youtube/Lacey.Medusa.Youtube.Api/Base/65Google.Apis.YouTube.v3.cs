// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Basic details about a channel, including title, description and thumbnails.</summary>
  internal class ChannelSnippet : IDirectResponseSchema
  {
    /// <summary>The country of the channel.</summary>
    [JsonProperty("country")]
    public virtual string Country { get; set; }

    /// <summary>The custom url of the channel.</summary>
    [JsonProperty("customUrl")]
    public virtual string CustomUrl { get; set; }

    /// <summary>The language of the channel's default title and description.</summary>
    [JsonProperty("defaultLanguage")]
    public virtual string DefaultLanguage { get; set; }

    /// <summary>The description of the channel.</summary>
    [JsonProperty("description")]
    public virtual string Description { get; set; }

    /// <summary>Localized title and description, read-only.</summary>
    [JsonProperty("localized")]
    public virtual ChannelLocalization Localized { get; set; }

    /// <summary>The date and time that the channel was created. The value is specified in ISO 8601 (YYYY-MM-
    /// DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("publishedAt")]
    public virtual string PublishedAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.ChannelSnippet.PublishedAtRaw" />.</summary>
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

    /// <summary>A map of thumbnail images associated with the channel. For each object in the map, the key is the
    /// name of the thumbnail image, and the value is an object that contains other information about the
    /// thumbnail.</summary>
    [JsonProperty("thumbnails")]
    public virtual ThumbnailDetails Thumbnails { get; set; }

    /// <summary>The channel's title.</summary>
    [JsonProperty("title")]
    public virtual string Title { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
