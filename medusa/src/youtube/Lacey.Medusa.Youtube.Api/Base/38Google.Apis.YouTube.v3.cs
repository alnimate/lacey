// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ActivityContentDetailsRecommendation
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Information that identifies the recommended resource.</summary>
  public class ActivityContentDetailsRecommendation : IDirectResponseSchema
  {
    /// <summary>The reason that the resource is recommended to the user.</summary>
    [JsonProperty("reason")]
    public virtual string Reason { get; set; }

    /// <summary>The resourceId object contains information that identifies the recommended resource.</summary>
    [JsonProperty("resourceId")]
    public virtual ResourceId ResourceId { get; set; }

    /// <summary>The seedResourceId object contains information about the resource that caused the
    /// recommendation.</summary>
    [JsonProperty("seedResourceId")]
    public virtual ResourceId SeedResourceId { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
