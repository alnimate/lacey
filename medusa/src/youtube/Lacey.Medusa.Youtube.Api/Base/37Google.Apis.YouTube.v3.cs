// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ActivityContentDetailsPromotedItem
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Details about a resource which is being promoted.</summary>
  internal class ActivityContentDetailsPromotedItem : IDirectResponseSchema
  {
    /// <summary>The URL the client should fetch to request a promoted item.</summary>
    [JsonProperty("adTag")]
    public virtual string AdTag { get; set; }

    /// <summary>The URL the client should ping to indicate that the user clicked through on this promoted
    /// item.</summary>
    [JsonProperty("clickTrackingUrl")]
    public virtual string ClickTrackingUrl { get; set; }

    /// <summary>The URL the client should ping to indicate that the user was shown this promoted item.</summary>
    [JsonProperty("creativeViewUrl")]
    public virtual string CreativeViewUrl { get; set; }

    /// <summary>The type of call-to-action, a message to the user indicating action that can be taken.</summary>
    [JsonProperty("ctaType")]
    public virtual string CtaType { get; set; }

    /// <summary>The custom call-to-action button text. If specified, it will override the default button text for
    /// the cta_type.</summary>
    [JsonProperty("customCtaButtonText")]
    public virtual string CustomCtaButtonText { get; set; }

    /// <summary>The text description to accompany the promoted item.</summary>
    [JsonProperty("descriptionText")]
    public virtual string DescriptionText { get; set; }

    /// <summary>The URL the client should direct the user to, if the user chooses to visit the advertiser's
    /// website.</summary>
    [JsonProperty("destinationUrl")]
    public virtual string DestinationUrl { get; set; }

    /// <summary>The list of forecasting URLs. The client should ping all of these URLs when a promoted item is not
    /// available, to indicate that a promoted item could have been shown.</summary>
    [JsonProperty("forecastingUrl")]
    public virtual IList<string> ForecastingUrl { get; set; }

    /// <summary>The list of impression URLs. The client should ping all of these URLs to indicate that the user was
    /// shown this promoted item.</summary>
    [JsonProperty("impressionUrl")]
    public virtual IList<string> ImpressionUrl { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the promoted video.</summary>
    [JsonProperty("videoId")]
    public virtual string VideoId { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
