﻿// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.PageInfo
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>Paging details for lists of resources, including total number of items available and number of
  /// resources returned in a single page.</summary>
  public class PageInfo : IDirectResponseSchema
  {
    /// <summary>The number of results included in the API response.</summary>
    [JsonProperty("resultsPerPage")]
    public virtual int? ResultsPerPage { get; set; }

    /// <summary>The total number of results in the result set.</summary>
    [JsonProperty("totalResults")]
    public virtual int? TotalResults { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
