// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveChatBanSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  public class LiveChatBanSnippet : IDirectResponseSchema
  {
    /// <summary>The duration of a ban, only filled if the ban has type TEMPORARY.</summary>
    [JsonProperty("banDurationSeconds")]
    public virtual ulong? BanDurationSeconds { get; set; }

    [JsonProperty("bannedUserDetails")]
    public virtual ChannelProfileDetails BannedUserDetails { get; set; }

    /// <summary>The chat this ban is pertinent to.</summary>
    [JsonProperty("liveChatId")]
    public virtual string LiveChatId { get; set; }

    /// <summary>The type of ban.</summary>
    [JsonProperty("type")]
    public virtual string Type { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
