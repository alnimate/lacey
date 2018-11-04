// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelSection
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  public class ChannelSection : IDirectResponseSchema
  {
    /// <summary>The contentDetails object contains details about the channel section content, such as a list of
    /// playlists or channels featured in the section.</summary>
    [JsonProperty("contentDetails")]
    public virtual ChannelSectionContentDetails ContentDetails { get; set; }

    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the channel section.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string
    /// "youtube#channelSection".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>Localizations for different languages</summary>
    [JsonProperty("localizations")]
    public virtual IDictionary<string, ChannelSectionLocalization> Localizations { get; set; }

    /// <summary>The snippet object contains basic details about the channel section, such as its type, style and
    /// title.</summary>
    [JsonProperty("snippet")]
    public virtual ChannelSectionSnippet Snippet { get; set; }

    /// <summary>The targeting object contains basic targeting settings about the channel section.</summary>
    [JsonProperty("targeting")]
    public virtual ChannelSectionTargeting Targeting { get; set; }
  }
}
