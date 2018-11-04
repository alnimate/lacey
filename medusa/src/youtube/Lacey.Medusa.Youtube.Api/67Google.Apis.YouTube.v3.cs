// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelStatus
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>JSON template for the status part of a channel.</summary>
  public class ChannelStatus : IDirectResponseSchema
  {
    /// <summary>If true, then the user is linked to either a YouTube username or G+ account. Otherwise, the user
    /// doesn't have a public YouTube identity.</summary>
    [JsonProperty("isLinked")]
    public virtual bool? IsLinked { get; set; }

    /// <summary>The long uploads status of this channel. See</summary>
    [JsonProperty("longUploadsStatus")]
    public virtual string LongUploadsStatus { get; set; }

    /// <summary>Privacy status of the channel.</summary>
    [JsonProperty("privacyStatus")]
    public virtual string PrivacyStatus { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
