// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoStatistics
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Statistics about the video, such as the number of times the video was viewed or liked.</summary>
  internal class VideoStatistics : IDirectResponseSchema
  {
    /// <summary>The number of comments for the video.</summary>
    [JsonProperty("commentCount")]
    public virtual ulong? CommentCount { get; set; }

    /// <summary>The number of users who have indicated that they disliked the video by giving it a negative
    /// rating.</summary>
    [JsonProperty("dislikeCount")]
    public virtual ulong? DislikeCount { get; set; }

    /// <summary>The number of users who currently have the video marked as a favorite video.</summary>
    [JsonProperty("favoriteCount")]
    public virtual ulong? FavoriteCount { get; set; }

    /// <summary>The number of users who have indicated that they liked the video by giving it a positive
    /// rating.</summary>
    [JsonProperty("likeCount")]
    public virtual ulong? LikeCount { get; set; }

    /// <summary>The number of times the video has been viewed.</summary>
    [JsonProperty("viewCount")]
    public virtual ulong? ViewCount { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
