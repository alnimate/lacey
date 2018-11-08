// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ActivityContentDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Details about the content of an activity: the video that was shared, the channel that was subscribed
  /// to, etc.</summary>
  internal class ActivityContentDetails : IDirectResponseSchema
  {
    /// <summary>The bulletin object contains details about a channel bulletin post. This object is only present if
    /// the snippet.type is bulletin.</summary>
    [JsonProperty("bulletin")]
    public virtual ActivityContentDetailsBulletin Bulletin { get; set; }

    /// <summary>The channelItem object contains details about a resource which was added to a channel. This
    /// property is only present if the snippet.type is channelItem.</summary>
    [JsonProperty("channelItem")]
    public virtual ActivityContentDetailsChannelItem ChannelItem { get; set; }

    /// <summary>The comment object contains information about a resource that received a comment. This property is
    /// only present if the snippet.type is comment.</summary>
    [JsonProperty("comment")]
    public virtual ActivityContentDetailsComment Comment { get; set; }

    /// <summary>The favorite object contains information about a video that was marked as a favorite video. This
    /// property is only present if the snippet.type is favorite.</summary>
    [JsonProperty("favorite")]
    public virtual ActivityContentDetailsFavorite Favorite { get; set; }

    /// <summary>The like object contains information about a resource that received a positive (like) rating. This
    /// property is only present if the snippet.type is like.</summary>
    [JsonProperty("like")]
    public virtual ActivityContentDetailsLike Like { get; set; }

    /// <summary>The playlistItem object contains information about a new playlist item. This property is only
    /// present if the snippet.type is playlistItem.</summary>
    [JsonProperty("playlistItem")]
    public virtual ActivityContentDetailsPlaylistItem PlaylistItem { get; set; }

    /// <summary>The promotedItem object contains details about a resource which is being promoted. This property is
    /// only present if the snippet.type is promotedItem.</summary>
    [JsonProperty("promotedItem")]
    public virtual ActivityContentDetailsPromotedItem PromotedItem { get; set; }

    /// <summary>The recommendation object contains information about a recommended resource. This property is only
    /// present if the snippet.type is recommendation.</summary>
    [JsonProperty("recommendation")]
    public virtual ActivityContentDetailsRecommendation Recommendation { get; set; }

    /// <summary>The social object contains details about a social network post. This property is only present if
    /// the snippet.type is social.</summary>
    [JsonProperty("social")]
    public virtual ActivityContentDetailsSocial Social { get; set; }

    /// <summary>The subscription object contains information about a channel that a user subscribed to. This
    /// property is only present if the snippet.type is subscription.</summary>
    [JsonProperty("subscription")]
    public virtual ActivityContentDetailsSubscription Subscription { get; set; }

    /// <summary>The upload object contains information about the uploaded video. This property is only present if
    /// the snippet.type is upload.</summary>
    [JsonProperty("upload")]
    public virtual ActivityContentDetailsUpload Upload { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
