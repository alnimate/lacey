// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using System.Collections.Generic;
using Google.Apis.Requests;
using Google.Apis.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Basic details about a video, including title, description, uploader, thumbnails and category.</summary>
  public class VideoSnippet : IDirectResponseSchema
  {
    /// <summary>The YouTube video category associated with the video.</summary>
    [JsonProperty("categoryId")]
    public virtual string CategoryId { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the channel that the video was uploaded to.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>Channel title for the channel that the video belongs to.</summary>
    [JsonProperty("channelTitle")]
    public virtual string ChannelTitle { get; set; }

    /// <summary>The default_audio_language property specifies the language spoken in the video's default audio
    /// track.</summary>
    [JsonProperty("defaultAudioLanguage")]
    public virtual string DefaultAudioLanguage { get; set; }

    /// <summary>The language of the videos's default snippet.</summary>
    [JsonProperty("defaultLanguage")]
    public virtual string DefaultLanguage { get; set; }

    /// <summary>The video's description.</summary>
    [JsonProperty("description")]
    public virtual string Description { get; set; }

    /// <summary>Indicates if the video is an upcoming/active live broadcast. Or it's "none" if the video is not an
    /// upcoming/active live broadcast.</summary>
    [JsonProperty("liveBroadcastContent")]
    public virtual string LiveBroadcastContent { get; set; }

    /// <summary>Localized snippet selected with the hl parameter. If no such localization exists, this field is
    /// populated with the default snippet. (Read-only)</summary>
    [JsonProperty("localized")]
    public virtual VideoLocalization Localized { get; set; }

    /// <summary>The date and time that the video was uploaded. The value is specified in ISO 8601 (YYYY-MM-
    /// DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("publishedAt")]
    public virtual string PublishedAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.VideoSnippet.PublishedAtRaw" />.</summary>
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

    /// <summary>A list of keyword tags associated with the video. Tags may contain spaces.</summary>
    [JsonProperty("tags")]
    public virtual IList<string> Tags { get; set; }

    /// <summary>A map of thumbnail images associated with the video. For each object in the map, the key is the
    /// name of the thumbnail image, and the value is an object that contains other information about the
    /// thumbnail.</summary>
    [JsonProperty("thumbnails")]
    public virtual ThumbnailDetails Thumbnails { get; set; }

    /// <summary>The video's title.</summary>
    [JsonProperty("title")]
    public virtual string Title { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
