// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ActivitySnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Google.Apis.Requests;
using Google.Apis.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Basic details about an activity, including title, description, thumbnails, activity type and
  /// group.</summary>
  public class ActivitySnippet : IDirectResponseSchema
  {
    /// <summary>The ID that YouTube uses to uniquely identify the channel associated with the activity.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>Channel title for the channel responsible for this activity</summary>
    [JsonProperty("channelTitle")]
    public virtual string ChannelTitle { get; set; }

    /// <summary>The description of the resource primarily associated with the activity.</summary>
    [JsonProperty("description")]
    public virtual string Description { get; set; }

    /// <summary>The group ID associated with the activity. A group ID identifies user events that are associated
    /// with the same user and resource. For example, if a user rates a video and marks the same video as a
    /// favorite, the entries for those events would have the same group ID in the user's activity feed. In your
    /// user interface, you can avoid repetition by grouping events with the same groupId value.</summary>
    [JsonProperty("groupId")]
    public virtual string GroupId { get; set; }

    /// <summary>The date and time that the video was uploaded. The value is specified in ISO 8601 (YYYY-MM-
    /// DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("publishedAt")]
    public virtual string PublishedAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.ActivitySnippet.PublishedAtRaw" />.</summary>
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

    /// <summary>A map of thumbnail images associated with the resource that is primarily associated with the
    /// activity. For each object in the map, the key is the name of the thumbnail image, and the value is an object
    /// that contains other information about the thumbnail.</summary>
    [JsonProperty("thumbnails")]
    public virtual ThumbnailDetails Thumbnails { get; set; }

    /// <summary>The title of the resource primarily associated with the activity.</summary>
    [JsonProperty("title")]
    public virtual string Title { get; set; }

    /// <summary>The type of activity that the resource describes.</summary>
    [JsonProperty("type")]
    public virtual string Type { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
