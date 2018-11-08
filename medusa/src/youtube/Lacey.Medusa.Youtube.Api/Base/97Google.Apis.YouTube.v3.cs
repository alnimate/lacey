// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveBroadcastSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  internal class LiveBroadcastSnippet : IDirectResponseSchema
  {
    /// <summary>The date and time that the broadcast actually ended. This information is only available once the
    /// broadcast's state is complete. The value is specified in ISO 8601 (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("actualEndTime")]
    public virtual string ActualEndTimeRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.LiveBroadcastSnippet.ActualEndTimeRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? ActualEndTime
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.ActualEndTimeRaw);
      }
      set
      {
        this.ActualEndTimeRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The date and time that the broadcast actually started. This information is only available once the
    /// broadcast's state is live. The value is specified in ISO 8601 (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("actualStartTime")]
    public virtual string ActualStartTimeRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.LiveBroadcastSnippet.ActualStartTimeRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? ActualStartTime
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.ActualStartTimeRaw);
      }
      set
      {
        this.ActualStartTimeRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The ID that YouTube uses to uniquely identify the channel that is publishing the
    /// broadcast.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>The broadcast's description. As with the title, you can set this field by modifying the broadcast
    /// resource or by setting the description field of the corresponding video resource.</summary>
    [JsonProperty("description")]
    public virtual string Description { get; set; }

    [JsonProperty("isDefaultBroadcast")]
    public virtual bool? IsDefaultBroadcast { get; set; }

    /// <summary>The id of the live chat for this broadcast.</summary>
    [JsonProperty("liveChatId")]
    public virtual string LiveChatId { get; set; }

    /// <summary>The date and time that the broadcast was added to YouTube's live broadcast schedule. The value is
    /// specified in ISO 8601 (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("publishedAt")]
    public virtual string PublishedAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.LiveBroadcastSnippet.PublishedAtRaw" />.</summary>
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

    /// <summary>The date and time that the broadcast is scheduled to end. The value is specified in ISO 8601 (YYYY-
    /// MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("scheduledEndTime")]
    public virtual string ScheduledEndTimeRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.LiveBroadcastSnippet.ScheduledEndTimeRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? ScheduledEndTime
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.ScheduledEndTimeRaw);
      }
      set
      {
        this.ScheduledEndTimeRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The date and time that the broadcast is scheduled to start. The value is specified in ISO 8601
    /// (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("scheduledStartTime")]
    public virtual string ScheduledStartTimeRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.LiveBroadcastSnippet.ScheduledStartTimeRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? ScheduledStartTime
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.ScheduledStartTimeRaw);
      }
      set
      {
        this.ScheduledStartTimeRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>A map of thumbnail images associated with the broadcast. For each nested object in this object, the
    /// key is the name of the thumbnail image, and the value is an object that contains other information about the
    /// thumbnail.</summary>
    [JsonProperty("thumbnails")]
    public virtual ThumbnailDetails Thumbnails { get; set; }

    /// <summary>The broadcast's title. Note that the broadcast represents exactly one YouTube video. You can set
    /// this field by modifying the broadcast resource or by setting the title field of the corresponding video
    /// resource.</summary>
    [JsonProperty("title")]
    public virtual string Title { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
