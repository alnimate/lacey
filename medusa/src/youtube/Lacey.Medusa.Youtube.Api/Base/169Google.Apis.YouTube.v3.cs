// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoSuggestionsTagSuggestion
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>A single tag suggestion with it's relevance information.</summary>
  public class VideoSuggestionsTagSuggestion : IDirectResponseSchema
  {
    /// <summary>A set of video categories for which the tag is relevant. You can use this information to display
    /// appropriate tag suggestions based on the video category that the video uploader associates with the video.
    /// By default, tag suggestions are relevant for all categories if there are no restricts defined for the
    /// keyword.</summary>
    [JsonProperty("categoryRestricts")]
    public virtual IList<string> CategoryRestricts { get; set; }

    /// <summary>The keyword tag suggested for the video.</summary>
    [JsonProperty("tag")]
    public virtual string Tag { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
