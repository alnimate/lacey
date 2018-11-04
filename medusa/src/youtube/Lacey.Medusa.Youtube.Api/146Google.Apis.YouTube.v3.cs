// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoCategory
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>A videoCategory resource identifies a category that has been or could be associated with uploaded
  /// videos.</summary>
  public class VideoCategory : IDirectResponseSchema
  {
    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the video category.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string
    /// "youtube#videoCategory".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The snippet object contains basic details about the video category, including its title.</summary>
    [JsonProperty("snippet")]
    public virtual VideoCategorySnippet Snippet { get; set; }
  }
}
