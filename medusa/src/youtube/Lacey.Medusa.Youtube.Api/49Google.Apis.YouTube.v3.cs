// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ChannelAuditDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>The auditDetails object encapsulates channel data that is relevant for YouTube Partners during the
  /// audit process.</summary>
  public class ChannelAuditDetails : IDirectResponseSchema
  {
    /// <summary>Whether or not the channel respects the community guidelines.</summary>
    [JsonProperty("communityGuidelinesGoodStanding")]
    public virtual bool? CommunityGuidelinesGoodStanding { get; set; }

    /// <summary>Whether or not the channel has any unresolved claims.</summary>
    [JsonProperty("contentIdClaimsGoodStanding")]
    public virtual bool? ContentIdClaimsGoodStanding { get; set; }

    /// <summary>Whether or not the channel has any copyright strikes.</summary>
    [JsonProperty("copyrightStrikesGoodStanding")]
    public virtual bool? CopyrightStrikesGoodStanding { get; set; }

    /// <summary>Describes the general state of the channel. This field will always show if there are any issues
    /// whatsoever with the channel. Currently this field represents the result of the logical and operation over
    /// the community guidelines good standing, the copyright strikes good standing and the content ID claims good
    /// standing, but this may change in the future.</summary>
    [JsonProperty("overallGoodStanding")]
    public virtual bool? OverallGoodStanding { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
