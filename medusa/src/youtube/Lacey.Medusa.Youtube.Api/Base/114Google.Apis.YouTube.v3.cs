// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.PlaylistItemContentDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  internal class PlaylistItemContentDetails : IDirectResponseSchema
  {
    /// <summary>The time, measured in seconds from the start of the video, when the video should stop playing. (The
    /// playlist owner can specify the times when the video should start and stop playing when the video is played
    /// in the context of the playlist.) By default, assume that the video.endTime is the end of the
    /// video.</summary>
    [JsonProperty("endAt")]
    public virtual string EndAt { get; set; }

    /// <summary>A user-generated note for this item.</summary>
    [JsonProperty("note")]
    public virtual string Note { get; set; }

    /// <summary>The time, measured in seconds from the start of the video, when the video should start playing.
    /// (The playlist owner can specify the times when the video should start and stop playing when the video is
    /// played in the context of the playlist.) The default value is 0.</summary>
    [JsonProperty("startAt")]
    public virtual string StartAt { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify a video. To retrieve the video resource, set the id
    /// query parameter to this value in your API request.</summary>
    [JsonProperty("videoId")]
    public virtual string VideoId { get; set; }

    /// <summary>The date and time that the video was published to YouTube. The value is specified in ISO 8601
    /// (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("videoPublishedAt")]
    public virtual string VideoPublishedAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.PlaylistItemContentDetails.VideoPublishedAtRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? VideoPublishedAt
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.VideoPublishedAtRaw);
      }
      set
      {
        this.VideoPublishedAtRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
