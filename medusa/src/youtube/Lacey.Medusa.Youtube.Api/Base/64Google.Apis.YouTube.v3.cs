// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelSettings
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Branding properties for the channel view.</summary>
  internal class ChannelSettings : IDirectResponseSchema
  {
    /// <summary>The country of the channel.</summary>
    [JsonProperty("country")]
    public virtual string Country { get; set; }

    [JsonProperty("defaultLanguage")]
    public virtual string DefaultLanguage { get; set; }

    /// <summary>Which content tab users should see when viewing the channel.</summary>
    [JsonProperty("defaultTab")]
    public virtual string DefaultTab { get; set; }

    /// <summary>Specifies the channel description.</summary>
    [JsonProperty("description")]
    public virtual string Description { get; set; }

    /// <summary>Title for the featured channels tab.</summary>
    [JsonProperty("featuredChannelsTitle")]
    public virtual string FeaturedChannelsTitle { get; set; }

    /// <summary>The list of featured channels.</summary>
    [JsonProperty("featuredChannelsUrls")]
    public virtual IList<string> FeaturedChannelsUrls { get; set; }

    /// <summary>Lists keywords associated with the channel, comma-separated.</summary>
    [JsonProperty("keywords")]
    public virtual string Keywords { get; set; }

    /// <summary>Whether user-submitted comments left on the channel page need to be approved by the channel owner
    /// to be publicly visible.</summary>
    [JsonProperty("moderateComments")]
    public virtual bool? ModerateComments { get; set; }

    /// <summary>A prominent color that can be rendered on this channel page.</summary>
    [JsonProperty("profileColor")]
    public virtual string ProfileColor { get; set; }

    /// <summary>Whether the tab to browse the videos should be displayed.</summary>
    [JsonProperty("showBrowseView")]
    public virtual bool? ShowBrowseView { get; set; }

    /// <summary>Whether related channels should be proposed.</summary>
    [JsonProperty("showRelatedChannels")]
    public virtual bool? ShowRelatedChannels { get; set; }

    /// <summary>Specifies the channel title.</summary>
    [JsonProperty("title")]
    public virtual string Title { get; set; }

    /// <summary>The ID for a Google Analytics account to track and measure traffic to the channels.</summary>
    [JsonProperty("trackingAnalyticsAccountId")]
    public virtual string TrackingAnalyticsAccountId { get; set; }

    /// <summary>The trailer of the channel, for users that are not subscribers.</summary>
    [JsonProperty("unsubscribedTrailer")]
    public virtual string UnsubscribedTrailer { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
