// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveChatMessageListResponse
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
  public class LiveChatMessageListResponse : IDirectResponseSchema
  {
    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>Serialized EventId of the request which produced this response.</summary>
    [JsonProperty("eventId")]
    public virtual string EventId { get; set; }

    /// <summary>A list of live chat messages.</summary>
    [JsonProperty("items")]
    public virtual IList<LiveChatMessage> Items { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string
    /// "youtube#liveChatMessageListResponse".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The token that can be used as the value of the pageToken parameter to retrieve the next page in the
    /// result set.</summary>
    [JsonProperty("nextPageToken")]
    public virtual string NextPageToken { get; set; }

    /// <summary>The date and time when the underlying stream went offline. The value is specified in ISO 8601
    /// (YYYY-MM-DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("offlineAt")]
    public virtual string OfflineAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.LiveChatMessageListResponse.OfflineAtRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? OfflineAt
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.OfflineAtRaw);
      }
      set
      {
        this.OfflineAtRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    [JsonProperty("pageInfo")]
    public virtual PageInfo PageInfo { get; set; }

    /// <summary>The amount of time the client should wait before polling again.</summary>
    [JsonProperty("pollingIntervalMillis")]
    public virtual long? PollingIntervalMillis { get; set; }

    [JsonProperty("tokenPagination")]
    public virtual TokenPagination TokenPagination { get; set; }

    /// <summary>The visitorId identifies the visitor.</summary>
    [JsonProperty("visitorId")]
    public virtual string VisitorId { get; set; }
  }
}
