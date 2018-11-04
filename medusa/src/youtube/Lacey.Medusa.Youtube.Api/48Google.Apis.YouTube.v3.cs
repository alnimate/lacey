// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.Channel
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>A channel resource contains information about a YouTube channel.</summary>
  public class Channel : IDirectResponseSchema
  {
    /// <summary>The auditionDetails object encapsulates channel data that is relevant for YouTube Partners during
    /// the audition process.</summary>
    [JsonProperty("auditDetails")]
    public virtual ChannelAuditDetails AuditDetails { get; set; }

    /// <summary>The brandingSettings object encapsulates information about the branding of the channel.</summary>
    [JsonProperty("brandingSettings")]
    public virtual ChannelBrandingSettings BrandingSettings { get; set; }

    /// <summary>The contentDetails object encapsulates information about the channel's content.</summary>
    [JsonProperty("contentDetails")]
    public virtual ChannelContentDetails ContentDetails { get; set; }

    /// <summary>The contentOwnerDetails object encapsulates channel data that is relevant for YouTube Partners
    /// linked with the channel.</summary>
    [JsonProperty("contentOwnerDetails")]
    public virtual ChannelContentOwnerDetails ContentOwnerDetails { get; set; }

    /// <summary>The conversionPings object encapsulates information about conversion pings that need to be
    /// respected by the channel.</summary>
    [JsonProperty("conversionPings")]
    public virtual ChannelConversionPings ConversionPings { get; set; }

    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the channel.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>The invideoPromotion object encapsulates information about promotion campaign associated with the
    /// channel.</summary>
    [JsonProperty("invideoPromotion")]
    public virtual InvideoPromotion InvideoPromotion { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string "youtube#channel".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>Localizations for different languages</summary>
    [JsonProperty("localizations")]
    public virtual IDictionary<string, ChannelLocalization> Localizations { get; set; }

    /// <summary>The snippet object contains basic details about the channel, such as its title, description, and
    /// thumbnail images.</summary>
    [JsonProperty("snippet")]
    public virtual ChannelSnippet Snippet { get; set; }

    /// <summary>The statistics object encapsulates statistics for the channel.</summary>
    [JsonProperty("statistics")]
    public virtual ChannelStatistics Statistics { get; set; }

    /// <summary>The status object encapsulates information about the privacy status of the channel.</summary>
    [JsonProperty("status")]
    public virtual ChannelStatus Status { get; set; }

    /// <summary>The topicDetails object encapsulates information about Freebase topics associated with the
    /// channel.</summary>
    [JsonProperty("topicDetails")]
    public virtual ChannelTopicDetails TopicDetails { get; set; }
  }
}
