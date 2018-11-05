// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelSectionSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Basic details about a channel section, including title, style and position.</summary>
  public class ChannelSectionSnippet : IDirectResponseSchema
  {
    /// <summary>The ID that YouTube uses to uniquely identify the channel that published the channel
    /// section.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>The language of the channel section's default title and description.</summary>
    [JsonProperty("defaultLanguage")]
    public virtual string DefaultLanguage { get; set; }

    /// <summary>Localized title, read-only.</summary>
    [JsonProperty("localized")]
    public virtual ChannelSectionLocalization Localized { get; set; }

    /// <summary>The position of the channel section in the channel.</summary>
    [JsonProperty("position")]
    public virtual long? Position { get; set; }

    /// <summary>The style of the channel section.</summary>
    [JsonProperty("style")]
    public virtual string Style { get; set; }

    /// <summary>The channel section's title for multiple_playlists and multiple_channels.</summary>
    [JsonProperty("title")]
    public virtual string Title { get; set; }

    /// <summary>The type of the channel section.</summary>
    [JsonProperty("type")]
    public virtual string Type { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
