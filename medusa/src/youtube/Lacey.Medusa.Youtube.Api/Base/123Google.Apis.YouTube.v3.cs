// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.PromotedItem
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Describes a single promoted item.</summary>
  public class PromotedItem : IDirectResponseSchema
  {
    /// <summary>A custom message to display for this promotion. This field is currently ignored unless the promoted
    /// item is a website.</summary>
    [JsonProperty("customMessage")]
    public virtual string CustomMessage { get; set; }

    /// <summary>Identifies the promoted item.</summary>
    [JsonProperty("id")]
    public virtual PromotedItemId Id { get; set; }

    /// <summary>If true, the content owner's name will be used when displaying the promotion. This field can only
    /// be set when the update is made on behalf of the content owner.</summary>
    [JsonProperty("promotedByContentOwner")]
    public virtual bool? PromotedByContentOwner { get; set; }

    /// <summary>The temporal position within the video where the promoted item will be displayed. If present, it
    /// overrides the default timing.</summary>
    [JsonProperty("timing")]
    public virtual InvideoTiming Timing { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
