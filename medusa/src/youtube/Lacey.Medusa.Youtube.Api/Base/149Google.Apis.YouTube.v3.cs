// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.VideoContentDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Details about the content of a YouTube Video.</summary>
  public class VideoContentDetails : IDirectResponseSchema
  {
    /// <summary>The value of captions indicates whether the video has captions or not.</summary>
    [JsonProperty("caption")]
    public virtual string Caption { get; set; }

    /// <summary>Specifies the ratings that the video received under various rating schemes.</summary>
    [JsonProperty("contentRating")]
    public virtual ContentRating ContentRating { get; set; }

    /// <summary>The countryRestriction object contains information about the countries where a video is (or is not)
    /// viewable.</summary>
    [JsonProperty("countryRestriction")]
    public virtual AccessPolicy CountryRestriction { get; set; }

    /// <summary>The value of definition indicates whether the video is available in high definition or only in
    /// standard definition.</summary>
    [JsonProperty("definition")]
    public virtual string Definition { get; set; }

    /// <summary>The value of dimension indicates whether the video is available in 3D or in 2D.</summary>
    [JsonProperty("dimension")]
    public virtual string Dimension { get; set; }

    /// <summary>The length of the video. The tag value is an ISO 8601 duration in the format PT#M#S, in which the
    /// letters PT indicate that the value specifies a period of time, and the letters M and S refer to length in
    /// minutes and seconds, respectively. The # characters preceding the M and S letters are both integers that
    /// specify the number of minutes (or seconds) of the video. For example, a value of PT15M51S indicates that the
    /// video is 15 minutes and 51 seconds long.</summary>
    [JsonProperty("duration")]
    public virtual string Duration { get; set; }

    /// <summary>Indicates whether the video uploader has provided a custom thumbnail image for the video. This
    /// property is only visible to the video uploader.</summary>
    [JsonProperty("hasCustomThumbnail")]
    public virtual bool? HasCustomThumbnail { get; set; }

    /// <summary>The value of is_license_content indicates whether the video is licensed content.</summary>
    [JsonProperty("licensedContent")]
    public virtual bool? LicensedContent { get; set; }

    /// <summary>Specifies the projection format of the video.</summary>
    [JsonProperty("projection")]
    public virtual string Projection { get; set; }

    /// <summary>The regionRestriction object contains information about the countries where a video is (or is not)
    /// viewable. The object will contain either the contentDetails.regionRestriction.allowed property or the
    /// contentDetails.regionRestriction.blocked property.</summary>
    [JsonProperty("regionRestriction")]
    public virtual VideoContentDetailsRegionRestriction RegionRestriction { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
