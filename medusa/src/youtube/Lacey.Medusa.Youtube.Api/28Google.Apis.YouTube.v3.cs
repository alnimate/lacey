// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.AccessPolicy
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Rights management policy for YouTube resources.</summary>
  public class AccessPolicy : IDirectResponseSchema
  {
    /// <summary>The value of allowed indicates whether the access to the policy is allowed or denied by
    /// default.</summary>
    [JsonProperty("allowed")]
    public virtual bool? Allowed { get; set; }

    /// <summary>A list of region codes that identify countries where the default policy do not apply.</summary>
    [JsonProperty("exception")]
    public virtual IList<string> Exception { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
