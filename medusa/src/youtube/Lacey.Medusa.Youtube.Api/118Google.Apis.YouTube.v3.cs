// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.PlaylistListResponse
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  public class PlaylistListResponse : IDirectResponseSchema
  {
    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>Serialized EventId of the request which produced this response.</summary>
    [JsonProperty("eventId")]
    public virtual string EventId { get; set; }

    /// <summary>A list of playlists that match the request criteria.</summary>
    [JsonProperty("items")]
    public virtual IList<Playlist> Items { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string
    /// "youtube#playlistListResponse".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The token that can be used as the value of the pageToken parameter to retrieve the next page in the
    /// result set.</summary>
    [JsonProperty("nextPageToken")]
    public virtual string NextPageToken { get; set; }

    [JsonProperty("pageInfo")]
    public virtual PageInfo PageInfo { get; set; }

    /// <summary>The token that can be used as the value of the pageToken parameter to retrieve the previous page in
    /// the result set.</summary>
    [JsonProperty("prevPageToken")]
    public virtual string PrevPageToken { get; set; }

    [JsonProperty("tokenPagination")]
    public virtual TokenPagination TokenPagination { get; set; }

    /// <summary>The visitorId identifies the visitor.</summary>
    [JsonProperty("visitorId")]
    public virtual string VisitorId { get; set; }
  }
}
