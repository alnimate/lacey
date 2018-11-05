// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveStreamConfigurationIssue
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  public class LiveStreamConfigurationIssue : IDirectResponseSchema
  {
    /// <summary>The long-form description of the issue and how to resolve it.</summary>
    [JsonProperty("description")]
    public virtual string Description { get; set; }

    /// <summary>The short-form reason for this issue.</summary>
    [JsonProperty("reason")]
    public virtual string Reason { get; set; }

    /// <summary>How severe this issue is to the stream.</summary>
    [JsonProperty("severity")]
    public virtual string Severity { get; set; }

    /// <summary>The kind of error happening.</summary>
    [JsonProperty("type")]
    public virtual string Type { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
