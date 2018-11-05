// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ActivityContentDetailsSocial
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Details about a social network post.</summary>
  public class ActivityContentDetailsSocial : IDirectResponseSchema
  {
    /// <summary>The author of the social network post.</summary>
    [JsonProperty("author")]
    public virtual string Author { get; set; }

    /// <summary>An image of the post's author.</summary>
    [JsonProperty("imageUrl")]
    public virtual string ImageUrl { get; set; }

    /// <summary>The URL of the social network post.</summary>
    [JsonProperty("referenceUrl")]
    public virtual string ReferenceUrl { get; set; }

    /// <summary>The resourceId object encapsulates information that identifies the resource associated with a
    /// social network post.</summary>
    [JsonProperty("resourceId")]
    public virtual ResourceId ResourceId { get; set; }

    /// <summary>The name of the social network.</summary>
    [JsonProperty("type")]
    public virtual string Type { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
