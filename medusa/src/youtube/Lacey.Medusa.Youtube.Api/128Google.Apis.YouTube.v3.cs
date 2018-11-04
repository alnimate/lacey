// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.SearchResult
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>A search result contains information about a YouTube video, channel, or playlist that matches the
  /// search parameters specified in an API request. While a search result points to a uniquely identifiable resource,
  /// like a video, it does not have its own persistent data.</summary>
  public class SearchResult : IDirectResponseSchema
  {
    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The id object contains information that can be used to uniquely identify the resource that matches
    /// the search request.</summary>
    [JsonProperty("id")]
    public virtual ResourceId Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string "youtube#searchResult".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The snippet object contains basic details about a search result, such as its title or description.
    /// For example, if the search result is a video, then the title will be the video's title and the description
    /// will be the video's description.</summary>
    [JsonProperty("snippet")]
    public virtual SearchResultSnippet Snippet { get; set; }
  }
}
