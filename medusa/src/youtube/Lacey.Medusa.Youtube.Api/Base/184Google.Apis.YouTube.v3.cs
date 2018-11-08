// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.LiveChatModeratorSnippet
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  internal class LiveChatModeratorSnippet : IDirectResponseSchema
  {
    /// <summary>The ID of the live chat this moderator can act on.</summary>
    [JsonProperty("liveChatId")]
    public virtual string LiveChatId { get; set; }

    /// <summary>Details about the moderator.</summary>
    [JsonProperty("moderatorDetails")]
    public virtual ChannelProfileDetails ModeratorDetails { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
