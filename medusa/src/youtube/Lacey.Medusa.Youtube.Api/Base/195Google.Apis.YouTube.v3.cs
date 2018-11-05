// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.Sponsor
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>A sponsor resource represents a sponsor for a YouTube channel. A sponsor provides recurring monetary
  /// support to a creator and receives special benefits.</summary>
  public class Sponsor : IDirectResponseSchema
  {
    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string "youtube#sponsor".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The snippet object contains basic details about the sponsor.</summary>
    [JsonProperty("snippet")]
    public virtual SponsorSnippet Snippet { get; set; }
  }
}
