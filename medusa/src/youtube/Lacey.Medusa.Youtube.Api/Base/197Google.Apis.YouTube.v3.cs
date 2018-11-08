// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.SponsorSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System;
using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  internal class SponsorSnippet : IDirectResponseSchema
  {
    /// <summary>The id of the channel being sponsored.</summary>
    [JsonProperty("channelId")]
    public virtual string ChannelId { get; set; }

    /// <summary>The cumulative time a user has been a sponsor in months.</summary>
    [JsonProperty("cumulativeDurationMonths")]
    public virtual int? CumulativeDurationMonths { get; set; }

    /// <summary>Details about the sponsor.</summary>
    [JsonProperty("sponsorDetails")]
    public virtual ChannelProfileDetails SponsorDetails { get; set; }

    /// <summary>The date and time when the user became a sponsor. The value is specified in ISO 8601 (YYYY-MM-
    /// DDThh:mm:ss.sZ) format.</summary>
    [JsonProperty("sponsorSince")]
    public virtual string SponsorSinceRaw { get; set; }

    /// <summary><seealso cref="T:System.DateTime" /> representation of <see cref="P:Lacey.Medusa.Youtube.Api.Base.SponsorSnippet.SponsorSinceRaw" />.</summary>
    [JsonIgnore]
    public virtual DateTime? SponsorSince
    {
      get
      {
        return Utilities.GetDateTimeFromString(this.SponsorSinceRaw);
      }
      set
      {
        this.SponsorSinceRaw = Utilities.GetStringFromDateTime(value);
      }
    }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
