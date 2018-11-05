// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ThumbnailDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Internal representation of thumbnails for a YouTube resource.</summary>
  internal class ThumbnailDetails : IDirectResponseSchema
  {
    /// <summary>The default image for this resource.</summary>
    [JsonProperty("default")]
    public virtual Thumbnail Default__ { get; set; }

    /// <summary>The high quality image for this resource.</summary>
    [JsonProperty("high")]
    public virtual Thumbnail High { get; set; }

    /// <summary>The maximum resolution quality image for this resource.</summary>
    [JsonProperty("maxres")]
    public virtual Thumbnail Maxres { get; set; }

    /// <summary>The medium quality image for this resource.</summary>
    [JsonProperty("medium")]
    public virtual Thumbnail Medium { get; set; }

    /// <summary>The standard quality image for this resource.</summary>
    [JsonProperty("standard")]
    public virtual Thumbnail Standard { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
