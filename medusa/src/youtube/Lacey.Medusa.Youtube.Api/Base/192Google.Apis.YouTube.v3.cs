// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveChatUserBannedMessageDetails
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  internal class LiveChatUserBannedMessageDetails : IDirectResponseSchema
  {
    /// <summary>The duration of the ban. This property is only present if the banType is temporary.</summary>
    [JsonProperty("banDurationSeconds")]
    public virtual ulong? BanDurationSeconds { get; set; }

    /// <summary>The type of ban.</summary>
    [JsonProperty("banType")]
    public virtual string BanType { get; set; }

    /// <summary>The details of the user that was banned.</summary>
    [JsonProperty("bannedUserDetails")]
    public virtual ChannelProfileDetails BannedUserDetails { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
