// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelBannerResource
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>A channel banner returned as the response to a channel_banner.insert call.</summary>
  internal class ChannelBannerResource : IDirectResponseSchema
  {
    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string
    /// "youtube#channelBannerResource".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The URL of this banner image.</summary>
    [JsonProperty("url")]
    public virtual string Url { get; set; }
  }
}
