// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.PromotedItemId
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Describes a single promoted item id. It is a union of various possible types.</summary>
  internal class PromotedItemId : IDirectResponseSchema
  {
    /// <summary>If type is recentUpload, this field identifies the channel from which to take the recent upload. If
    /// missing, the channel is assumed to be the same channel for which the invideoPromotion is set.</summary>
    [JsonProperty("recentlyUploadedBy")]
    public virtual string RecentlyUploadedBy { get; set; }

    /// <summary>Describes the type of the promoted item.</summary>
    [JsonProperty("type")]
    public virtual string Type { get; set; }

    /// <summary>If the promoted item represents a video, this field represents the unique YouTube ID identifying
    /// it. This field will be present only if type has the value video.</summary>
    [JsonProperty("videoId")]
    public virtual string VideoId { get; set; }

    /// <summary>If the promoted item represents a website, this field represents the url pointing to the website.
    /// This field will be present only if type has the value website.</summary>
    [JsonProperty("websiteUrl")]
    public virtual string WebsiteUrl { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
