// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoAgeGating
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  public class VideoAgeGating : IDirectResponseSchema
  {
    /// <summary>Indicates whether or not the video has alcoholic beverage content. Only users of legal purchasing
    /// age in a particular country, as identified by ICAP, can view the content.</summary>
    [JsonProperty("alcoholContent")]
    public virtual bool? AlcoholContent { get; set; }

    /// <summary>Age-restricted trailers. For redband trailers and adult-rated video-games. Only users aged 18+ can
    /// view the content. The the field is true the content is restricted to viewers aged 18+. Otherwise The field
    /// won't be present.</summary>
    [JsonProperty("restricted")]
    public virtual bool? Restricted { get; set; }

    /// <summary>Video game rating, if any.</summary>
    [JsonProperty("videoGameRating")]
    public virtual string VideoGameRating { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
