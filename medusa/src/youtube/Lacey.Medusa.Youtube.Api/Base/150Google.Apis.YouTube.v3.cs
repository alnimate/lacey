// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoContentDetailsRegionRestriction
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>DEPRECATED Region restriction of the video.</summary>
  public class VideoContentDetailsRegionRestriction : IDirectResponseSchema
  {
    /// <summary>A list of region codes that identify countries where the video is viewable. If this property is
    /// present and a country is not listed in its value, then the video is blocked from appearing in that country.
    /// If this property is present and contains an empty list, the video is blocked in all countries.</summary>
    [JsonProperty("allowed")]
    public virtual IList<string> Allowed { get; set; }

    /// <summary>A list of region codes that identify countries where the video is blocked. If this property is
    /// present and a country is not listed in its value, then the video is viewable in that country. If this
    /// property is present and contains an empty list, the video is viewable in all countries.</summary>
    [JsonProperty("blocked")]
    public virtual IList<string> Blocked { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
