// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.CommentThreadSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Basic details about a comment thread.</summary>
  public class CommentThreadSnippet : IDirectResponseSchema
  {
    /// <summary>Whether the current viewer of the thread can reply to it. This is viewer specific - other viewers
    /// may see a different value for this field.</summary>
    [JsonProperty("canReply")]
    public virtual bool? CanReply { get; set; }

    /// <summary>The YouTube channel the comments in the thread refer to or the channel with the video the comments
    /// refer to. If video_id isn't set the comments refer to the channel itself.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>Whether the thread (and therefore all its comments) is visible to all YouTube users.</summary>
    [JsonProperty("isPublic")]
    public virtual bool? IsPublic { get; set; }

    /// <summary>The top level comment of this thread.</summary>
    [JsonProperty("topLevelComment")]
    public virtual Comment TopLevelComment { get; set; }

    /// <summary>The total number of replies (not including the top level comment).</summary>
    [JsonProperty("totalReplyCount")]
    public virtual long? TotalReplyCount { get; set; }

    /// <summary>The ID of the video the comments refer to, if any. No video_id implies a channel discussion
    /// comment.</summary>
    [JsonProperty("videoId")]
    public virtual string VideoId { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
