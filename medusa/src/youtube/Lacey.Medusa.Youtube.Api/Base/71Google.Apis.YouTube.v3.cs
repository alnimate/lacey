// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.CommentSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Basic details about a comment, such as its author and text.</summary>
  internal class CommentSnippet : IDirectResponseSchema
  {
    /// <summary>The id of the author's YouTube channel, if any.</summary>
    [JsonProperty("authorChannelId")]
    public virtual object AuthorChannelId { get; set; }

    /// <summary>Link to the author's YouTube channel, if any.</summary>
    [JsonProperty("authorChannelUrl")]
    public virtual string AuthorChannelUrl { get; set; }

    /// <summary>The name of the user who posted the comment.</summary>
    [JsonProperty("authorDisplayName")]
    public virtual string AuthorDisplayName { get; set; }

    /// <summary>The URL for the avatar of the user who posted the comment.</summary>
    [JsonProperty("authorProfileImageUrl")]
    public virtual string AuthorProfileImageUrl { get; set; }

    /// <summary>Whether the current viewer can rate this comment.</summary>
    [JsonProperty("canRate")]
    public virtual bool? CanRate { get; set; }

    /// <summary>The id of the corresponding YouTube channel. In case of a channel comment this is the channel the
    /// comment refers to. In case of a video comment it's the video's channel.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>The total number of likes this comment has received.</summary>
    [JsonProperty("likeCount")]
    public virtual long? LikeCount { get; set; }

    /// <summary>The comment's moderation status. Will not be set if the comments were requested through the id
    /// filter.</summary>
    [JsonProperty("moderationStatus")]
    public virtual string ModerationStatus { get; set; }

    /// <summary>The unique id of the parent comment, only set for replies.</summary>
    [JsonProperty("parentId")]
    public virtual string ParentId { get; set; }

    /// <summary>The date and time when the comment was orignally published. The value is specified in ISO 8601
    /// (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("publishedAt")]
    public virtual string PublishedAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.CommentSnippet.PublishedAtRaw" />.</summary>
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

    /// <summary>The comment's text. The format is either plain text or HTML dependent on what has been requested.
    /// Even the plain text representation may differ from the text originally posted in that it may replace video
    /// links with video titles etc.</summary>
    [JsonProperty("textDisplay")]
    public virtual string TextDisplay { get; set; }

    /// <summary>The comment's original raw text as initially posted or last updated. The original text will only be
    /// returned if it is accessible to the viewer, which is only guaranteed if the viewer is the comment's
    /// author.</summary>
    [JsonProperty("textOriginal")]
    public virtual string TextOriginal { get; set; }

    /// <summary>The date and time when was last updated . The value is specified in ISO 8601 (YYYY-MM-
    /// DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("updatedAt")]
    public virtual string UpdatedAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.CommentSnippet.UpdatedAtRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? UpdatedAt
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.UpdatedAtRaw);
      }
      set
      {
        this.UpdatedAtRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The ID of the video the comment refers to, if any.</summary>
    [JsonProperty("videoId")]
    public virtual string VideoId { get; set; }

    /// <summary>The rating the viewer has given to this comment. For the time being this will never return
    /// RATE_TYPE_DISLIKE and instead return RATE_TYPE_NONE. This may change in the future.</summary>
    [JsonProperty("viewerRating")]
    public virtual string ViewerRating { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
