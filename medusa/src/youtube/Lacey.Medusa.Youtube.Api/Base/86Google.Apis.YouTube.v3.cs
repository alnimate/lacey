// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.I18nRegionSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Basic details about an i18n region, such as region code and human-readable name.</summary>
  public class I18nRegionSnippet : IDirectResponseSchema
  {
    /// <summary>The region code as a 2-letter ISO country code.</summary>
    [JsonProperty("gl")]
    public virtual string Gl { get; set; }

    /// <summary>The human-readable name of the region.</summary>
    [JsonProperty("name")]
    public virtual string Name { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
