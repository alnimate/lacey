// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.GuideCategory
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>A guideCategory resource identifies a category that YouTube algorithmically assigns based on a
  /// channel's content or other indicators, such as the channel's popularity. The list is similar to video
  /// categories, with the difference being that a video's uploader can assign a video category but only YouTube can
  /// assign a channel category.</summary>
  public class GuideCategory : IDirectResponseSchema
  {
    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the guide category.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string
    /// "youtube#guideCategory".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The snippet object contains basic details about the category, such as its title.</summary>
    [JsonProperty("snippet")]
    public virtual GuideCategorySnippet Snippet { get; set; }
  }
}
