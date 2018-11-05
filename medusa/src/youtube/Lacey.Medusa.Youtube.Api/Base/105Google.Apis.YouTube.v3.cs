// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveStreamSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  public class LiveStreamSnippet : IDirectResponseSchema
  {
    /// <summary>The ID that YouTube uses to uniquely identify the channel that is transmitting the
    /// stream.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>The stream's description. The value cannot be longer than 10000 characters.</summary>
    [JsonProperty("description")]
    public virtual string Description { get; set; }

    [JsonProperty("isDefaultStream")]
    public virtual bool? IsDefaultStream { get; set; }

    /// <summary>The date and time that the stream was created. The value is specified in ISO 8601 (YYYY-MM-
    /// DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("publishedAt")]
    public virtual string PublishedAtRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.LiveStreamSnippet.PublishedAtRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? PublishedAt
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.PublishedAtRaw);
      }
      set
      {
        this.PublishedAtRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The stream's title. The value must be between 1 and 128 characters long.</summary>
    [JsonProperty("title")]
    public virtual string Title { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
