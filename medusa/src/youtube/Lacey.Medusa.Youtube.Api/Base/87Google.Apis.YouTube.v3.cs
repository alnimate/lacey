// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ImageSettings
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Branding properties for images associated with the channel.</summary>
  public class ImageSettings : IDirectResponseSchema
  {
    /// <summary>The URL for the background image shown on the video watch page. The image should be 1200px by
    /// 615px, with a maximum file size of 128k.</summary>
    [JsonProperty("backgroundImageUrl")]
    public virtual LocalizedProperty BackgroundImageUrl { get; set; }

    /// <summary>This is used only in update requests; if it's set, we use this URL to generate all of the above
    /// banner URLs.</summary>
    [JsonProperty("bannerExternalUrl")]
    public virtual string BannerExternalUrl { get; set; }

    /// <summary>Banner image. Desktop size (1060x175).</summary>
    [JsonProperty("bannerImageUrl")]
    public virtual string BannerImageUrl { get; set; }

    /// <summary>Banner image. Mobile size high resolution (1440x395).</summary>
    [JsonProperty("bannerMobileExtraHdImageUrl")]
    public virtual string BannerMobileExtraHdImageUrl { get; set; }

    /// <summary>Banner image. Mobile size high resolution (1280x360).</summary>
    [JsonProperty("bannerMobileHdImageUrl")]
    public virtual string BannerMobileHdImageUrl { get; set; }

    /// <summary>Banner image. Mobile size (640x175).</summary>
    [JsonProperty("bannerMobileImageUrl")]
    public virtual string BannerMobileImageUrl { get; set; }

    /// <summary>Banner image. Mobile size low resolution (320x88).</summary>
    [JsonProperty("bannerMobileLowImageUrl")]
    public virtual string BannerMobileLowImageUrl { get; set; }

    /// <summary>Banner image. Mobile size medium/high resolution (960x263).</summary>
    [JsonProperty("bannerMobileMediumHdImageUrl")]
    public virtual string BannerMobileMediumHdImageUrl { get; set; }

    /// <summary>Banner image. Tablet size extra high resolution (2560x424).</summary>
    [JsonProperty("bannerTabletExtraHdImageUrl")]
    public virtual string BannerTabletExtraHdImageUrl { get; set; }

    /// <summary>Banner image. Tablet size high resolution (2276x377).</summary>
    [JsonProperty("bannerTabletHdImageUrl")]
    public virtual string BannerTabletHdImageUrl { get; set; }

    /// <summary>Banner image. Tablet size (1707x283).</summary>
    [JsonProperty("bannerTabletImageUrl")]
    public virtual string BannerTabletImageUrl { get; set; }

    /// <summary>Banner image. Tablet size low resolution (1138x188).</summary>
    [JsonProperty("bannerTabletLowImageUrl")]
    public virtual string BannerTabletLowImageUrl { get; set; }

    /// <summary>Banner image. TV size high resolution (1920x1080).</summary>
    [JsonProperty("bannerTvHighImageUrl")]
    public virtual string BannerTvHighImageUrl { get; set; }

    /// <summary>Banner image. TV size extra high resolution (2120x1192).</summary>
    [JsonProperty("bannerTvImageUrl")]
    public virtual string BannerTvImageUrl { get; set; }

    /// <summary>Banner image. TV size low resolution (854x480).</summary>
    [JsonProperty("bannerTvLowImageUrl")]
    public virtual string BannerTvLowImageUrl { get; set; }

    /// <summary>Banner image. TV size medium resolution (1280x720).</summary>
    [JsonProperty("bannerTvMediumImageUrl")]
    public virtual string BannerTvMediumImageUrl { get; set; }

    /// <summary>The image map script for the large banner image.</summary>
    [JsonProperty("largeBrandedBannerImageImapScript")]
    public virtual LocalizedProperty LargeBrandedBannerImageImapScript { get; set; }

    /// <summary>The URL for the 854px by 70px image that appears below the video player in the expanded video view
    /// of the video watch page.</summary>
    [JsonProperty("largeBrandedBannerImageUrl")]
    public virtual LocalizedProperty LargeBrandedBannerImageUrl { get; set; }

    /// <summary>The image map script for the small banner image.</summary>
    [JsonProperty("smallBrandedBannerImageImapScript")]
    public virtual LocalizedProperty SmallBrandedBannerImageImapScript { get; set; }

    /// <summary>The URL for the 640px by 70px banner image that appears below the video player in the default view
    /// of the video watch page.</summary>
    [JsonProperty("smallBrandedBannerImageUrl")]
    public virtual LocalizedProperty SmallBrandedBannerImageUrl { get; set; }

    /// <summary>The URL for a 1px by 1px tracking pixel that can be used to collect statistics for views of the
    /// channel or video pages.</summary>
    [JsonProperty("trackingImageUrl")]
    public virtual string TrackingImageUrl { get; set; }

    /// <summary>The URL for the image that appears above the top-left corner of the video player. This is a 25
    /// -pixel-high image with a flexible width that cannot exceed 170 pixels.</summary>
    [JsonProperty("watchIconImageUrl")]
    public virtual string WatchIconImageUrl { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
