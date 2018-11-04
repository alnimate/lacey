﻿// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveStreamHealthStatus
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  public class LiveStreamHealthStatus : IDirectResponseSchema
  {
    /// <summary>The configurations issues on this stream</summary>
    [JsonProperty("configurationIssues")]
    public virtual IList<LiveStreamConfigurationIssue> ConfigurationIssues { get; set; }

    /// <summary>The last time this status was updated (in seconds)</summary>
    [JsonProperty("lastUpdateTimeSeconds")]
    public virtual ulong? LastUpdateTimeSeconds { get; set; }

    /// <summary>The status code of this stream</summary>
    [JsonProperty("status")]
    public virtual string Status { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
